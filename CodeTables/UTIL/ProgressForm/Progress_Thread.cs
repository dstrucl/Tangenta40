using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageControl;
using System.Threading;
using System.Windows.Forms;
namespace ProgressForm
{
    public class Progress_Thread
    {
        public enum eMessage { CONTINUE, CANCEL };
        public string sLabel1 = "";
        public string sLabel2 = "";
        public string sLabel3 = "";
        private string m_Message = null;
        private int m_ProgressBarPercent = 0;
        public bool bEnd = false;
        internal Mutex myMutex = new Mutex();
        internal System.Threading.Thread MyProgress_Thread;
        public bool bCancel = false;

        public Progress_Thread()
        {
        }

        private void Run()
        {
            Progress_Form dlg_Progress_Form = new Progress_Form(this,sLabel1,sLabel2,sLabel3);
            dlg_Progress_Form.Show();
            for (; ; )
            {
                if (myMutex.WaitOne(2000))
                {
                    if (bEnd)
                    {
                        dlg_Progress_Form.Close();
                        myMutex.ReleaseMutex();
                        return;
                    }
                    if (m_Message != null)
                    {
                        int iValue = m_ProgressBarPercent;
                        dlg_Progress_Form.Label3.Text = m_Message +" "+ iValue.ToString() + "%";
                        dlg_Progress_Form.progressBar.Value = iValue;
                        m_Message = null;
                    }
                    myMutex.ReleaseMutex();
                }
                Application.DoEvents();
                Thread.Sleep(10);
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

        public eMessage Message(string sxMessage, int iPercent)
        {
            if (myMutex.WaitOne(2000))
            {
                string sMessage = sxMessage;
                m_Message = sMessage;
                m_ProgressBarPercent = iPercent;
                if (bCancel)
                {
                    myMutex.ReleaseMutex();
                    return eMessage.CANCEL;
                }
                myMutex.ReleaseMutex();
            }
            return eMessage.CONTINUE;
        }

        public void Start()
        {
            MyProgress_Thread = new System.Threading.Thread(Run);
            MyProgress_Thread.SetApartmentState(ApartmentState.STA);
            MyProgress_Thread.Start();
        }

    }
}
