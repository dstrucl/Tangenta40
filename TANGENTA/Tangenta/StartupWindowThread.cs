using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tangenta
{
    public class StartupWindowThread
    {
        private string m_Message = null;
        internal bool bEnd = false;
        internal Mutex myMutex = new Mutex();
        internal System.Threading.Thread StartupWindow_Thread;

        private void Run()
        {
            Form_StartupWindow dlg_StartupWindow = new Form_StartupWindow();
            dlg_StartupWindow.Show();
            for (;;)
            {
                if (myMutex.WaitOne(2000))
                {
                    if (bEnd)
                    {
                        dlg_StartupWindow.Close();
                        myMutex.ReleaseMutex();
                        return;
                    }
                    if (m_Message != null)
                    {
                        dlg_StartupWindow.lbl_Info.Text = m_Message;
                        m_Message = null;
                    }
                    myMutex.ReleaseMutex();
                }
                Application.DoEvents();
            }
        }

        public void End()
        {
            for (;;)
            {
                if (myMutex.WaitOne(2000))
                {
                    bEnd = true;
                    myMutex.ReleaseMutex();
                    return;
                }
            }
        }

        public void Message(string sMessage)
        {
            if (myMutex.WaitOne(2000))
            {
                m_Message = sMessage;
                myMutex.ReleaseMutex();
            }
        }

        public void Start()
        {
            StartupWindow_Thread = new System.Threading.Thread(Run);
            StartupWindow_Thread.SetApartmentState(ApartmentState.STA);
            StartupWindow_Thread.Start();
        }

    }
}
