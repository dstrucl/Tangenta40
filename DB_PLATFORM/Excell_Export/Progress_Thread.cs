using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageControl;
using System.Threading;
using System.Windows.Forms;
namespace Excell_Export
{
    public class Progress_Thread
    {
        public enum eMessage { CONTINUE, CANCEL };
        private string m_Message = null;
        internal bool bEnd = false;
        internal Mutex myMutex = new Mutex();
        internal System.Threading.Thread Excel_Export_Progress_Thread;
        internal int m_columns;
        internal int m_rows;
        internal bool bCancel = false;
        internal string m_FileName = null;

        public Progress_Thread(int icolumns,int iRows,string filename)
        {
            m_columns = icolumns;
            m_rows = iRows;
            m_FileName = filename;
        }

        private void Run()
        {
            Progress_Form dlg_Progress_Form = new Progress_Form(this);
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
                        dlg_Progress_Form.lbl_PercentDone.Text = lngRPM.s_ExportDoneInXprocent.s + ":%" + m_Message;
                        int iValue = Convert.ToInt32(m_Message);
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

        public eMessage Message(int iPerc)
        {
            if (myMutex.WaitOne(2000))
            {
                string sMessage = iPerc.ToString();
                m_Message = sMessage;
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
            Excel_Export_Progress_Thread = new System.Threading.Thread(Run);
            Excel_Export_Progress_Thread.SetApartmentState(ApartmentState.STA);
            Excel_Export_Progress_Thread.Start();
        }

    }
}
