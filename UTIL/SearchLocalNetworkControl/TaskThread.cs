using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
namespace SearchLocalNetwork
{
    public class TaskThreadParam
    {

        public TcpClient m_tcp;
        public string server;
        public Int32 port;
        public int timeout;

        public TaskThreadParam(TcpClient tcp, string srv, Int32 prt,  int tout)
        {
            m_tcp = tcp;
            server = srv;
            port = prt;
            timeout = tout;
        }

    }
    public class TaskThread
    {
        bool bConnected = false;
        bool bTaskEnd = false;

        Mutex EndMutex = new Mutex(false);

        public void taskConnect(Object data)
        {
            if (EndMutex.WaitOne(10000))
            {
                TaskThreadParam tParam = (TaskThreadParam)data;
                var ar = tParam.m_tcp.BeginConnect(tParam.server, tParam.port, null, null);
                var wh = ar.AsyncWaitHandle;
                try
                {
                    if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(tParam.timeout), false))
                    {
                        // The logic to control when the connection timed out
                        tParam.m_tcp.Close();
                        bConnected = false;
                        //throw new TimeoutException();
                    }
                    else
                    {
                        // The logic to control when the connection succeed.
                        //tcp.EndConnect(ar);
                        bConnected = true;
                    }
                }
                finally
                {
                    wh.Close();
                }
                bTaskEnd = true;
                EndMutex.ReleaseMutex();
            }
        }

        public bool Connect(TcpClient tcpClient,string srv, Int32 prt, int tout)
        {
            TaskThreadParam scp = new TaskThreadParam(tcpClient, srv, prt, tout);
            Thread taskConnectThread = new Thread(taskConnect);
            taskConnectThread.Start(scp);
            System.Threading.Thread.Sleep(100);
            if (EndMutex.WaitOne(10000))
            {
                if (bTaskEnd)
                {
                    if (bConnected)
                    {
                        EndMutex.ReleaseMutex();
                        return true;
                    }
                    else
                    {
                        EndMutex.ReleaseMutex();
                        return false;
                    }
                }
                else
                {
                    taskConnectThread.Abort();
                    //MessageBox.Show("ERROR TaskThread not ended!");
                    EndMutex.ReleaseMutex();
                    return false;
                }
            }
            else
            {
                if (!bTaskEnd)
                {
                    taskConnectThread.Abort();
                }
                return false;
            }
        }
    }
}
