using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPC
{
    public class RPCd
    {
        private string m_Function = null;
        private string m_data = null;
        private string m_Result = null;
        private Mutex rpcd_mutex = null;

        public string Function
        {
            get { return m_Function; }
        }

        public string data
        {
            get { return m_data; }
        }

        public string Result
        {
            get
            {
                if (rpcd_mutex.WaitOne(10000))
                {
                    string sRes = m_Result;
                    rpcd_mutex.ReleaseMutex();
                    return sRes;

                }
                else
                {
                    return null;
                }
            }
        }

        public RPCd(string xFunction, string xdata)
        {
            rpcd_mutex = new Mutex();
            m_Function = xFunction;
            m_data = xdata;
            m_Result = null;
        }

        internal void SetResult(string eResult)
        {
            if (rpcd_mutex.WaitOne(10000))
            {
                m_Result = eResult;
                rpcd_mutex.ReleaseMutex();
            }
        }

        public string GetResult(int timeout)
        {
            long StartTicks = DateTime.Now.Ticks;
            while (Result==null)
            {
                if (DateTime.Now.Ticks - StartTicks > timeout*1000)
                {
                    return null;
                }
            }
            return Result;
        }
    }
}
