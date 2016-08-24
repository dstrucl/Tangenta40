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
using System.Data.SqlClient;
using LanguageControl;
using MySql.Data.MySqlClient;

namespace LogFile
{
    public partial class Select_DataBase_Form : Form
    {
        string m_Title=null;

        private Form m_ParentForm = null;

        Log_DBConnection m_SQL_Connection;
        internal bool m_bNewDataBase = false;

        public Select_DataBase_Form(Form pParentForm,Log_DBConnection my_connection, string sTitle)
        {
            m_ParentForm = pParentForm;
            m_Title = sTitle;
            m_SQL_Connection = my_connection;
            InitializeComponent();
        }

        private bool GetMySQLDataBases(ref bool bInDataBase, string DataBaseToFind)
        {
            string conxString = m_SQL_Connection.ServerConnectionString;
            try
            {
                using (MySqlConnection sqlConx = new MySqlConnection(conxString))
                {
                    sqlConx.Open();
                    DataTable tblDatabases = sqlConx.GetSchema("Databases");
                    sqlConx.Close();
                    bInDataBase = false;
                    this.listBox_DataBaseNames.Items.Clear();
                    foreach (DataRow row in tblDatabases.Rows)
                    {
                        string DataBaseName;
                        DataBaseName = row["database_name"].ToString();
                        this.listBox_DataBaseNames.Items.Add(DataBaseName);
                        if (DataBaseToFind != null)
                        {
                            if (DataBaseToFind.Length > 0)
                            {
                                if (DataBaseName.Equals(DataBaseToFind))
                                {
                                    bInDataBase = true;
                                }
                            }
                        }
                        //Console.WriteLine("Database: " + row["database_name"]);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lngConn.s_Error_Can_not_get_Databases_on_Server.s + txt_ServerName.Text + "\n" + lngConn.s_Execption.s + " = " + ex.Message + "\"", lngConn.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private bool GetMicrosoftSQLDataBases(ref bool bInDataBase, string DataBaseToFind)
        {
            string conxString = m_SQL_Connection.ServerConnectionString;
            try
            {
                using (SqlConnection sqlConx = new SqlConnection(conxString))
                {
                    sqlConx.Open();
                    DataTable tblDatabases = sqlConx.GetSchema("Databases");
                    sqlConx.Close();
                    bInDataBase = false;
                    this.listBox_DataBaseNames.Items.Clear();
                    foreach (DataRow row in tblDatabases.Rows)
                    {
                        string DataBaseName;
                        DataBaseName = row["database_name"].ToString();
                        this.listBox_DataBaseNames.Items.Add(DataBaseName);
                        if (DataBaseToFind != null)
                        {
                            if (DataBaseToFind.Length > 0)
                            {
                                if (DataBaseName.Equals(DataBaseToFind))
                                {
                                    bInDataBase = true;
                                }
                            }
                        }
                        //Console.WriteLine("Database: " + row["database_name"]);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, lngConn.s_Error_Can_not_get_Databases_on_Server.s + txt_ServerName.Text + "\n" + lngConn.s_Execption.s + " = " + ex.Message + "\"", lngConn.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void Select_DataBase_Form_Load(object sender, EventArgs e)
        {
            if (m_Title != null)
            {
                this.Text = m_Title;
            }

            lbl_Server.Text = lngConn.s_Server.s;
            lbl_UserName.Text = lngConn.s_UserName.s;
            lbl_Password.Text = lngConn.s_Password.s;
            lbl_Database.Text = lngConn.s_DataBase.s;
            listBox_DataBaseNames.Enabled = false;

            this.btn_Cancel.Text = lngConn.s_Cancel.s;

            grpbox_LogOnToTheServer.Text = lngConn.s_LogOnToTheServer.s;
            grpbox_ConnectToDatabaseName.Text = lngConn.s_ConnectToDatabaseName.s;

            Btn_TestConnection.Text = lngConn.s_GetConnection.s;
            btn_CreateNewDatabase.Text = lngConn.s_CreateNewDatabase.s;
            btn_ViewRights.Text = lngConn.s_ViewPermissions.s;

            this.txt_ServerName.Text = m_SQL_Connection.DataSource;
            txt_ServerName.Visible = true;

            this.txt_DataBaseName.Text = m_SQL_Connection.DataBase;

            btn_GetDataBaseList.Text =lngConn.s_GetDataBaseList.s + " "+ m_SQL_Connection.DataSource;

            switch (m_SQL_Connection.DBType)
            {
                case Log_DBConnection.eDBType.MYSQL:
                    this.radioButton_UseWindowsAuthentication.Enabled = false;
                    txt_UserName.Enabled = true;
                    txt_UserName.Text = m_SQL_Connection.UserName;
                    txt_Password.Text = m_SQL_Connection.Password;
                    txt_Password.Visible = true;
                    txt_Password.Enabled = true;
                    lbl_Password.Enabled = true;

                    if (this.txt_DataBaseName.Text.Length > 0)
                    {
                        bool bAllreadyExist = false;
                        if (GetMySQLDataBases(ref bAllreadyExist, this.txt_DataBaseName.Text))
                        {
                            listBox_DataBaseNames.Enabled = true;
                            if (!bAllreadyExist)
                            {
                                MessageBox.Show(lngConn.s_DataBase_e.s + " " + this.txt_DataBaseName.Text + lngConn.s_Can_Not_Be_Found_On_server.s + " " + m_SQL_Connection.DataSource, lngConn.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        bool bAllreadyExist = false;
                        if (GetMySQLDataBases(ref bAllreadyExist, null))
                        {
                            listBox_DataBaseNames.Enabled = true;
                        }
                    }
                    break;

                case Log_DBConnection.eDBType.MSSQL:
                    if (m_SQL_Connection.WindowsAuthentication)
                    {
                        this.radioButton_UseWindowsAuthentication.Select();
                        txt_UserName.Text = m_SQL_Connection.WindowsAuthentication_UserName;
                        txt_UserName.Enabled = false;
                        txt_Password.Visible = false;
                        lbl_Password.Visible = false;
                    }
                    else
                    {
                        this.radioButton_UseSQLServerAuthentication.Select();
                        txt_UserName.Text = m_SQL_Connection.UserName;
                        txt_UserName.Enabled = true;
                        txt_Password.Text = m_SQL_Connection.Password;
                        txt_Password.Visible = true;
                        txt_Password.Enabled = true;
                        lbl_Password.Enabled = true;
                    }

                    if (this.txt_DataBaseName.Text.Length > 0)
                    {
                        bool bAllreadyExist = false;
                        if (GetMicrosoftSQLDataBases(ref bAllreadyExist, this.txt_DataBaseName.Text))
                        {
                            listBox_DataBaseNames.Enabled = true;
                            if (!bAllreadyExist)
                            {
                                MessageBox.Show(lngConn.s_DataBase_e.s + " " + this.txt_DataBaseName.Text + lngConn.s_Can_Not_Be_Found_On_server.s + " " + m_SQL_Connection.DataSource, lngConn.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    break;
            }
        }



        private void UpdateConData()
        {
            m_SQL_Connection.DataSource = txt_ServerName.Text;
            m_SQL_Connection.DataBase = txt_DataBaseName.Text;
            switch (m_SQL_Connection.DBType)
            {
                case Log_DBConnection.eDBType.MSSQL:
                    {
                        if (this.radioButton_UseSQLServerAuthentication.Checked)
                        {
                            m_SQL_Connection.UserName = txt_UserName.Text;
                            m_SQL_Connection.Password = txt_Password.Text;
                        }
                        m_SQL_Connection.WindowsAuthentication = radioButton_UseWindowsAuthentication.Checked;
                    }
                    break;

                case Log_DBConnection.eDBType.MYSQL:
                        m_SQL_Connection.UserName = txt_UserName.Text;
                        m_SQL_Connection.Password = txt_Password.Text;
                    break;
            }
//            m_SQL_Connection.conData.SetConnectionString();
        }

        private void listBox_DataBaseNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_DataBaseName.Text = this.listBox_DataBaseNames.SelectedItem.ToString();
            btn_CreateNewDatabase.Enabled = false;
        }

        private void GetDataBaseList()
        {
            UpdateConData();
            bool b = false;

            switch (m_SQL_Connection.DBType)
            {
                case Log_DBConnection.eDBType.MYSQL:
                    if (GetMySQLDataBases(ref b, null))
                    {
                        listBox_DataBaseNames.Enabled = true;
                    }
                    break;
                case Log_DBConnection.eDBType.MSSQL:
                    if (GetMicrosoftSQLDataBases(ref b, null))
                    {
                        listBox_DataBaseNames.Enabled = true;
                    }
                    break;
            }
        }

        private void btn_GetDataBaseList_Click(object sender, EventArgs e)
        {
            GetDataBaseList();
        }

        private void Btn_TestConnection_Click(object sender, EventArgs e)
        {
            UpdateConData();

            TestConnectionForm tConForm = new TestConnectionForm(m_ParentForm,m_SQL_Connection,  false, true, m_Title);
            if (tConForm.ShowDialog() == DialogResult.OK)
            {
//                MessageBox.Show(this, lngConn.s_ConnectionOK.s, "OK");
            }
            else
            {

            }
        }

        private void btn_ViewRights_Click(object sender, EventArgs e)
        {
            UpdateConData();
            string current_DataBaseName = m_SQL_Connection.DataBase;
            m_SQL_Connection.DataBase = "";
            //m_SQL_Connection.conData.SetConnectionString();
            string csError = "";
            if (m_SQL_Connection.Connect(ref csError))
            {
                m_SQL_Connection.Disconnect();
                View_AccessR_Form View_AccessR_Dialog = new View_AccessR_Form(m_SQL_Connection);
                View_AccessR_Dialog.ShowDialog();
                m_SQL_Connection.DataBase = current_DataBaseName;
                //m_SQL_Connection.conData.SetConnectionString();
            }
            else
            {
                m_SQL_Connection.DataBase = current_DataBaseName;
                //m_SQL_Connection.conData.SetConnectionString();
            }
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            UpdateConData();
            if (m_SQL_Connection.DataBase.Length > 0)
            {
                string csError = "";
                if (m_SQL_Connection.Connect(ref csError))
                {
                    m_SQL_Connection.Disconnect();
                    this.DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
                else
                {
                    if (MessageBox.Show(this, lngConn.s_CanNotMakeAConnection.s + "\r\n\r\n+\""+csError+"\"" , lngConn.s_Warning.s, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        Close();
                        return;
                    }
                }
            }
            else
            {
                if (MessageBox.Show(this, lngConn.s_DatabaseNotDefined.s, lngConn.s_Warning.s, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
            }
        }

        private void btn_CreateNewDatabase_Click(object sender, EventArgs e)
        {
            UpdateConData();
            bool bAllreadyExist = false;
            switch (m_SQL_Connection.DBType)
            {
                case Log_DBConnection.eDBType.MYSQL:
                    if (GetMySQLDataBases(ref bAllreadyExist, this.txt_DataBaseName.Text))
                    {
                        listBox_DataBaseNames.Enabled = true;
                        if (bAllreadyExist)
                        {
                            MessageBox.Show(lngConn.s_DataBase.s + this.txt_DataBaseName.Text + lngConn.s_Already_exist.s, lngConn.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (txt_UserName.Text.Length > 0)
                            {
                                //Test Connection and rights to create new database

                                CreateMySQLDataBase_Form CreateMySQLDataBaseDialog = new CreateMySQLDataBase_Form(ref m_SQL_Connection);
                                DialogResult dRes;
                                dRes = CreateMySQLDataBaseDialog.ShowDialog();
                                if (dRes == DialogResult.OK)
                                {
                                    this.txt_DataBaseName.Text = m_SQL_Connection.DataBase;
                                    GetDataBaseList();
                                    m_bNewDataBase = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(lngConn.s_Not_EnoughPermissions_To_List_Databases.s, lngConn.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case Log_DBConnection.eDBType.MSSQL:
                    if (GetMicrosoftSQLDataBases(ref bAllreadyExist, this.txt_DataBaseName.Text))
                    {
                        listBox_DataBaseNames.Enabled = true;
                        if (bAllreadyExist)
                        {
                            MessageBox.Show(lngConn.s_DataBase.s + this.txt_DataBaseName.Text + lngConn.s_Already_exist.s, lngConn.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (m_SQL_Connection.WindowsAuthentication)
                            {
                                CreateDataBase_Form CreateDataBaseDialog = new CreateDataBase_Form(ref m_SQL_Connection);
                                DialogResult dRes;
                                dRes = CreateDataBaseDialog.ShowDialog();
                                if (dRes == DialogResult.OK)
                                {
                                    this.txt_DataBaseName.Text = m_SQL_Connection.DataBase;
                                    GetDataBaseList();
                                    m_bNewDataBase = true;
                                }
                            }
                            else
                            {
                                if ((txt_UserName.Text.Length > 0) && (txt_Password.Text.Length > 0))
                                {
                                    //Test Connection and rights to create new database

                                    CreateDataBase_Form CreateDataBaseDialog = new CreateDataBase_Form(ref m_SQL_Connection);
                                    DialogResult dRes;
                                    dRes = CreateDataBaseDialog.ShowDialog();
                                    if (dRes == DialogResult.OK)
                                    {
                                        this.txt_DataBaseName.Text = m_SQL_Connection.DataBase;
                                        GetDataBaseList();
                                    }
                                }
                                else
                                {
                                    if (txt_UserName.Text.Length == 0)
                                    {
                                        System.Windows.Forms.MessageBox.Show(lngConn.s_User_name_is_missing_Enter_User_Name.s, lngConn.s_Warning.s, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                                    }
                                    else if (txt_Password.Text.Length == 0)
                                    {
                                        System.Windows.Forms.MessageBox.Show(lngConn.s_Password_is_missing_Enter_Password.s, lngConn.s_Warning.s, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(lngConn.s_Not_EnoughPermissions_To_List_Databases.s, lngConn.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
            }
        }

        private void radioButton_UseWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_UseWindowsAuthentication.Checked)
            {
                this.txt_Password.Enabled = false;
                txt_UserName.Text = m_SQL_Connection.WindowsAuthentication_UserName;
                txt_UserName.Enabled = false;
                txt_Password.Visible = false;
                lbl_Password.Visible = false;
            }
            else
            {
                this.txt_Password.Enabled = true;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void radioButton_UseSQLServerAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_UseSQLServerAuthentication.Checked)
            {
                txt_UserName.Text = m_SQL_Connection.UserName;
                txt_UserName.Enabled = true;
                txt_Password.Text = m_SQL_Connection.Password;
                txt_Password.Visible = true;
                txt_Password.Enabled = true;
                lbl_Password.Enabled = true;
            }
        }
    }
}
