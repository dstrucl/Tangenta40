using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    class Database_Upgrade_WindowsForm_Thread
    {
        internal bool bEnd = false;
        internal Mutex myMutex = new Mutex();
        internal System.Threading.Thread StartupWindow_Thread;
        private List<string> MessageBox = new List<string>();
        private void Run(object param)
        {
            uwpf_GUI.Upgrade_Progress_Window piu_w = new uwpf_GUI.Upgrade_Progress_Window();
            piu_w.Show();
            for (; ; )
            {
                if (myMutex.WaitOne(2000))
                {
                    if (bEnd)
                    {
                        piu_w.Close();
                        myMutex.ReleaseMutex();
                        return;
                    }
                    foreach (string smsg in MessageBox)
                    {
                        piu_w.Set_lbl_Info(smsg);
                    }
                    MessageBox.Clear();
                    myMutex.ReleaseMutex();
                }
                Application.DoEvents();
            }
        }

        public void End()
        {
            for (; ; )
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
                MessageBox.Add(sMessage);
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
