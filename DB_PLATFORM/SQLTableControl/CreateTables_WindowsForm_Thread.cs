﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SQLTableControl
{
    class CreateTables_WindowsForm_Thread
    {
            private string m_Message = null;
            internal bool bEnd = false;
            internal Mutex myMutex = new Mutex();
            internal System.Threading.Thread StartupWindow_Thread;

            private void Run(object param)
            {
                int Tables_Count = (int)param;
                CreateTables_WindowsForm dlg_CreateTables_WindowsForm = new CreateTables_WindowsForm(Tables_Count);
                dlg_CreateTables_WindowsForm.Show();
                for (; ; )
                {
                    if (myMutex.WaitOne(2000))
                    {
                        if (bEnd)
                        {
                            dlg_CreateTables_WindowsForm.Close();
                            myMutex.ReleaseMutex();
                            return;
                        }
                        if (m_Message != null)
                        {
                            dlg_CreateTables_WindowsForm.lbl_Info.Text = m_Message;
                            m_Message = null;
                        }
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
                    m_Message = sMessage;
                    myMutex.ReleaseMutex();
                }
            }

            public void Start(int Tables_Count)
            {
                StartupWindow_Thread = new System.Threading.Thread(Run);
                StartupWindow_Thread.SetApartmentState(ApartmentState.STA);
                StartupWindow_Thread.Start(Tables_Count);
            }
        }
}