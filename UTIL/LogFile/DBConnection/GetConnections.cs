using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LogFile
{
    public class CheckConnectionThreadParam
    {
        public bool m_bDataBaseConnection;
        public Log_DBConnection m_Conn;
        public CheckConnectionThreadParam(Log_DBConnection xConn, bool bDataBaseConnection)
        {
            m_bDataBaseConnection = bDataBaseConnection;
            m_Conn = xConn;
        }
    }


    public static class GetConnectionsThread
    {
        public static Log_DBConnection m_sqlConnection = null;
        public static TestConnectionForm m_pForm = null;

        public static Mutex mutexMessageBoxScanner = new Mutex(false, "mutexMessageBoxScanner ");


        public static bool SendMessage(bool b)
        {
            if (m_pForm.mutexMessageBox.WaitOne(100))
            {
                m_pForm.MessageList.Add(b);
                m_pForm.mutexMessageBox.ReleaseMutex();
                return true;
            }
            else
            {
                return false;
            }
        }



        public static void CheckConnection(Object data)
        {
            if (data.GetType() == typeof(CheckConnectionThreadParam))
            {
                CheckConnectionThreadParam scp = (CheckConnectionThreadParam)data;
                switch (scp.m_Conn.DBType)
                {
                case Log_DBConnection.eDBType.MYSQL:
                    if (scp.m_Conn.DataSource != null)
                    {
                        if (scp.m_Conn.DataSource.Length > 0)
                        {
                            string s_Error = "";
                            bool bRes = false;

                            if (scp.m_bDataBaseConnection)
                            {
                                bRes = scp.m_Conn.Connect(ref s_Error);
                            }
                            else
                            {
                                bRes = scp.m_Conn.CheckConnectionToServerOnly();
                            }

                            if (bRes)
                            {
                                scp.m_Conn.Disconnect();
                                while (!SendMessage(true))
                                {
                                }
                            }
                            else
                            {
                                while (!SendMessage(false))
                                {
                                }
                            }
                        }
                        else
                        {
                            while (!SendMessage(false))
                            {
                            }
                        }
                    }
                    else
                    {
                        while (!SendMessage(false))
                        {
                        }
                    }
                    break;

                case Log_DBConnection.eDBType.MSSQL:
                    if (scp.m_Conn.DataSource != null)
                    {
                        if (scp.m_Conn.DataSource.Length > 0)
                        {
                            string s_Error = "";
                            bool bRes = false;

                            if (scp.m_bDataBaseConnection)
                            {
                                bRes = scp.m_Conn.Connect(ref s_Error);
                            }
                            else
                            {
                                bRes = scp.m_Conn.CheckConnectionToServerOnly();
                            }

                            if (bRes)
                            {
                                scp.m_Conn.Disconnect();
                                while (!SendMessage(true))
                                {
                                }
                            }
                            else
                            {
                                while (!SendMessage(false))
                                {
                                }
                            }
                        }
                        else
                        {
                            while (!SendMessage(false))
                            {
                            }
                        }
                    }
                    else
                    {
                        while (!SendMessage(false))
                        {
                        }
                    }
                    break;
                }
            }
        }
    }
}
