#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LanguageControl;

namespace DBConnectionControl40
{
    public partial class TestConnectionForm : Form
    {
        private bool m_bResult = false;
        DBConnection.eStartPositionOfTestConnectionForm m_eStartPositionOfTestConnectionForm = DBConnection.eStartPositionOfTestConnectionForm.CENTER_SCREEN;

        private Form m_ParentForm = null;
        string m_Title=null;

        bool m_bDataBaseConnection=true;

        bool m_bTimerClose = false;

        DBConnection sqlConn;

        Thread CheckConnectionThread = null;
        public Mutex mutexMessageBox = new Mutex(false);
        public List<bool> MessageList = new List<bool>();

        public bool GetMessage(ref bool bConnectionOK)
        {
            if (mutexMessageBox.WaitOne())
            {
                bool bRes = false;
                if (MessageList.Count > 0)
                {
                    bConnectionOK = MessageList[0];
                    MessageList.RemoveAt(0);
                    bRes = true;
                }
                else
                {
                    bRes = false;
                }
                mutexMessageBox.ReleaseMutex();
                return bRes;
            }
            else
            {
                return false;
            }

        }

        public TestConnectionForm(Form xParentForm,DBConnection sqlCon, bool bTimerClose, bool bDataBaseConnection,string sTitle)
        {
            m_ParentForm = xParentForm;
            this.Owner = m_ParentForm;
            m_bDataBaseConnection = bDataBaseConnection;
            m_Title = sTitle;
            m_bTimerClose = bTimerClose;
            sqlConn = sqlCon;
            InitializeComponent();
            m_eStartPositionOfTestConnectionForm = sqlCon.StartPositionOfTestConnectionForm;
            switch (sqlConn.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    break;

                case DBConnection.eDBType.MSSQL:
                    break;
                case DBConnection.eDBType.SQLITE:
                    lblUserName.Visible = false;
                    this.label_UserName.Visible = false;
                    break;
            }
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {
        }

        private void TestConnectionForm_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.FromControl(this);
            this.Location = new Point((scr.Bounds.Size.Width / 2) - (this.Size.Width / 2), (scr.Bounds.Size.Height / 2) - (this.Size.Height / 2));
            SetOnScreenPosition();
            
            this.Icon = DBConnectionControl40.Properties.Resources.TestConnectionIcon;

            if (m_Title != null)
            {
                switch (sqlConn.DBType)
                {
                    case DBConnection.eDBType.MYSQL:
                        this.Text = m_Title + " (MySQL server)";
                        break;

                    case DBConnection.eDBType.MSSQL:
                        this.Text = m_Title + " (Microsoft SQL server)";
                        break;
                    case DBConnection.eDBType.SQLITE:
                        this.Text = m_Title + " (SQLite local server)";
                        break;
                }
            }
            lbl_ERROR.Visible = false;
            btn_OK.Visible = false;
            lblDataSource.Text = lngConn.s_Server.s;
            lblDataBase.Text = lngConn.s_DataBase.s+":";

            lblUserName.Text = lngConn.s_UserName.s+":";
            this.chkBoxWindowsLogon.Text = lngConn.s_WindowsAuthentication.s;

            this.lblDataSource.BackColor = Color.Transparent;
            this.lblDataBase.BackColor = Color.Transparent;
            this.lblUserName.BackColor = Color.Transparent;
            this.chkBoxWindowsLogon.BackColor = Color.Transparent;
            this.label_Server.BackColor = Color.Transparent;
            this.label_DataBase.BackColor = Color.Transparent;
            this.label_UserName.BackColor = Color.Transparent;
            this.label_Server.Text = sqlConn.DataSource;
            this.label_DataBase.Text = sqlConn.DataBase;


            switch (sqlConn.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    this.label_UserName.Text = sqlConn.UserName;
                    this.chkBoxWindowsLogon.CheckState= CheckState.Unchecked;

                    if (sqlConn.DataSource.Length == 0)
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else if (m_bDataBaseConnection && (sqlConn.DataBase.Length == 0))
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        if (CheckConnectionThread == null)
                        {
                            GetConnectionsThread.m_pForm = this;
                            GetConnectionsThread.m_sqlConnection = sqlConn;
                            CheckConnectionThread = new Thread(GetConnectionsThread.CheckConnection);
                            //CheckConnectionThreadParam scp = new CheckConnectionThreadParam(sqlConn.conData.DataSource,sqlConn.conData.DataBase,sqlConn.conData.strLoginID,sqlConn.conData.strPassword,sqlConn.conData.bWindowsAuthentication);
                            CheckConnectionThreadParam scp = new CheckConnectionThreadParam(sqlConn, m_bDataBaseConnection);
                            CheckConnectionThread.Start(scp);
                            timerFollow_CheckConnection.Interval = 200;
                            this.timerFollow_CheckConnection.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Scanner thread is allready running", "Warning");
                        }
                    }
                    break;

                case DBConnection.eDBType.MSSQL:
                    this.label_UserName.Text = sqlConn.UserName;
                    if (sqlConn.WindowsAuthentication)
                    {
                        this.chkBoxWindowsLogon.CheckState= CheckState.Checked;
                        this.label_UserName.Text = sqlConn.WindowsAuthentication_UserName;

                    }
                    else
                    {
                        this.chkBoxWindowsLogon.CheckState= CheckState.Unchecked;
                        this.label_UserName.Text = sqlConn.UserName;
                    }

                    if (sqlConn.DataSource.Length == 0)
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else if (m_bDataBaseConnection && (sqlConn.DataBase.Length == 0))
                    {
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                    else
                    {
                        if (CheckConnectionThread == null)
                        {
                            GetConnectionsThread.m_pForm = this;
                            GetConnectionsThread.m_sqlConnection = sqlConn;
                            CheckConnectionThread = new Thread(GetConnectionsThread.CheckConnection);
                            //CheckConnectionThreadParam scp = new CheckConnectionThreadParam(sqlConn.conData.DataSource,sqlConn.conData.DataBase,sqlConn.conData.strLoginID,sqlConn.conData.strPassword,sqlConn.conData.bWindowsAuthentication);
                            CheckConnectionThreadParam scp = new CheckConnectionThreadParam(sqlConn, m_bDataBaseConnection);
                            CheckConnectionThread.Start(scp);
                            timerFollow_CheckConnection.Interval = 200;
                            this.timerFollow_CheckConnection.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Scanner thread is allready running", "Warning");
                        }
                    }
                    break;

                case DBConnection.eDBType.SQLITE:
                    string sError=null;
                    if (sqlConn.Connect(ref sError))
                    {
                        sqlConn.Disconnect();
                        ShowOK();
                        this.TimerSQLiteShowOkResult.Enabled = true;
                        return;
                    }
                    else
                    {
                        sqlConn.Disconnect();
                        ShowError(sError);
                        this.TimerSQLiteShowErrorResult.Enabled = true;
                    }
                    break;
            }
        }



        private void ShowOK()
        {
            timerFollow_CheckConnection.Enabled = false;
            lbl_ERROR.Visible = true;
            lbl_ERROR.Text = sqlConn.DataBase +"\r\n\r\n" + lngConn.s_ConnectionOK.s;
            lbl_ERROR.ForeColor = Color.Blue;
            btn_OK.Visible = true;
            this.lblDataBase.Visible = false;
            this.lblDataSource.Visible = false;
            this.lblUserName.Visible = false;
            this.chkBoxWindowsLogon.Visible = false;
            this.progressBar_Connection.Visible = false;
            m_bResult = true;
        }

        private void ShowError(string s)
        {
            timerFollow_CheckConnection.Enabled = false;
            lbl_ERROR.Visible = true;
            lbl_ERROR.Text = s;
            btn_OK.Visible = true;
            this.lblDataBase.Visible = false;
            this.lblDataSource.Visible = false;
            this.lblUserName.Visible = false;
            this.chkBoxWindowsLogon.Visible = false;
            this.progressBar_Connection.Visible = false;
            m_bResult = false;

        }

        private void timerFollow_CheckConnection_Tick(object sender, EventArgs e)
        {
            if (CheckConnectionThread.ThreadState== ThreadState.Running)
            {
                if (this.progressBar_Connection.Value < this.progressBar_Connection.Maximum)
                {
                    this.progressBar_Connection.Value++;
                }
                else
                {
                    this.progressBar_Connection.Value = 0;
                }
            }
            else
            {
                bool bRes = false;
                if (GetMessage(ref bRes))
                {
                    if (bRes)
                    {
                        // connection OK
                        timerFollow_CheckConnection.Enabled = false;
                        if (m_bTimerClose)
                        {
                            this.Close();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            ShowOK();
                        }

                    }
                    else
                    {
                        this.Close();
                        this.DialogResult = DialogResult.No;

                    }
                }
            }
        }

 
        private void TimerSQLiteShowOkResult_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            System.Diagnostics.Debug.Print("\r\nTimerSQLiteShowOkResult_Tick;" + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString() + "." + dt.Millisecond.ToString());
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void TimerSQLiteShowErrorResult_Tick(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (m_bResult)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
            this.Close();
        }

        private void SetOnScreenPosition()
        {
            Screen screen = Screen.FromControl(this);
            Rectangle rect = screen.WorkingArea;
            switch (m_eStartPositionOfTestConnectionForm)
            {
                case DBConnection.eStartPositionOfTestConnectionForm.TOP_LEFT_CORNER:
                    this.Top = rect.Top;
                    this.Left = rect.Left;
                    break;
                case DBConnection.eStartPositionOfTestConnectionForm.TOP_RIGHT_CORNER:
                    this.Left = rect.Right - this.Width;
                    this.Top = rect.Top; 
                    break;
                case DBConnection.eStartPositionOfTestConnectionForm.BOTTOM_LEFT_CORNER:
                    this.Top = rect.Bottom - this.Height;
                    this.Left = rect.Left; 
                    break;
                case DBConnection.eStartPositionOfTestConnectionForm.BOTTOM_RIGHT_CORNER:
                    this.Top = rect.Bottom - this.Height;
                    this.Left = rect.Right - this.Width;
                    break;
            }
        }

        private void btn_ChangeConnection_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            this.Close();
        }
    }
}
