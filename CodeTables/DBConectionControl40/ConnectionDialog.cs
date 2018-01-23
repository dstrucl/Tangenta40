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
using LanguageControl;
using NavigationButtons;

namespace DBConnectionControl40
{
    public partial class ConnectionDialog : Form
    {
        public NavigationButtons.Navigation.eEvent eExitEvent = NavigationButtons.Navigation.eEvent.NOTHING;
        string m_Title = null;
        NavigationButtons.Navigation nav = null;

        private int[] Y = new int[5];

        public enum ConnectionDialog_enum
        {
            EditLoginAndPassword,
            EditAll,
            TryAgain_EditAll,
            SaveConnectionData
        };


        //private conData_MSSQL original_conData_MSSQL = null;


        public ConnectionDialog_enum my_ConnectionDialog_enum;

        public DBConnection m_con = null;

        internal bool m_bNewDataBase = false;

        private bool bDataBaseConnectionChecked = false;

        public ConnectionDialog(ConnectionDialog_enum ConnectionConnectionDialog_type, DBConnection con, string sTitle, NavigationButtons.Navigation xnav)
        {
            m_Title = sTitle;
            my_ConnectionDialog_enum = ConnectionConnectionDialog_type;
            InitializeComponent();
            nav = xnav;
            usrc_NavigationButtons1.Init(nav);
            usrc_NavigationButtons1.Button_NEXT_Enabled = false;

            if (con.RecentItemsFolder.Length ==0)
            {
                con.RecentItemsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
            this.cmb_ServerName.RecentItemsFolder = con.RecentItemsFolder;
            this.cmb_DataBaseName.RecentItemsFolder = con.RecentItemsFolder;
            this.cmb_UserName.RecentItemsFolder = con.RecentItemsFolder;

            Y[0] = cmb_DataBaseName.Top;
            Y[1] = rdb_UseWindowsAuthentication.Top;
            Y[2] = rdb_SQL_Server_Authentication.Top;
            Y[3] = cmb_UserName.Top;
            Y[4] = txt_Password.Top;



            m_con = con;
            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                   rdb_UseWindowsAuthentication.Enabled = false;
                   rdb_SQL_Server_Authentication.Enabled = false;
                   this.radioButton_MicrosoftSQL.Checked = false;
                   this.radioButton_MySqlServer.Checked = true;
                   break;

                case DBConnection.eDBType.MSSQL:
                    this.radioButton_MicrosoftSQL.Checked = true;
                    rdb_UseWindowsAuthentication.Enabled = true;
                    rdb_SQL_Server_Authentication.Enabled = true;
                    if (m_con.WindowsAuthentication)
                    {
                        rdb_UseWindowsAuthentication.Checked = true;
                    }
                    else
                    {
                        rdb_SQL_Server_Authentication.Checked = true;
                    }
                    break;
            }

        }


        private void SetTextBoxes()
        {

            lng.s_Server.Text(lbl_Server);
            lng.s_DataBase.Text(lbl_DataBase);
            lng.s_UserName.Text(lbl_UserName);
            lng.s_Password.Text(lbl_Password);
            lng.s_Browse__.Text(btn_Browse_servers);
            lng.s_Browse__.Text(btn_Browse_Databases_onServer);
            usrc_NavigationButtons1.Init(nav);
            lng.s_ConnectWithDatabase.Text(btn_Action);
            lng.s_WindowsAuthentication.Text(rdb_UseWindowsAuthentication);
            lng.s_SQLServerAuthentication.Text(rdb_SQL_Server_Authentication);


            this.Text = GetTitle();

            this.cmb_ServerName.Text = m_con.DataSource;
            this.cmb_DataBaseName.Text = m_con.DataBase;
            this.cmb_UserName.Text = m_con.UserName;
            this.txt_Password.Text = m_con.Password;

            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    this.cmb_UserName.Enabled = true;
                    this.txt_Password.Enabled = true;
                    this.txt_Password.Visible = true;
                    this.lbl_Password.Visible = true;
                    break;

                case DBConnection.eDBType.MSSQL:
                    if (this.rdb_UseWindowsAuthentication.Checked)
                    {
                        this.cmb_UserName.Enabled = false;
                        this.cmb_UserName.Text = m_con.WindowsAuthentication_UserName;
                        this.txt_Password.Visible = false;
                        this.lbl_Password.Visible = false;
                        this.txt_Password.Enabled = false;
                        this.txt_Password.Text = "";
                    }
                    else
                    {
                        this.cmb_UserName.Enabled = true;
                        this.txt_Password.Enabled = true;
                        this.txt_Password.Visible = true;
                        this.lbl_Password.Visible = true;
                        this.cmb_UserName.Text = m_con.UserName;
                        this.txt_Password.Text = m_con.Password;
                    }
                    break;
            }
        }

        private string GetTitle()
        {
            if (m_Title != null)
            {
                return m_Title;
            }
            else
            {
                return lng.s_ConnectWithDatabase.s;   
            }
        }

        private void ConnectionDialog_Load(object sender, EventArgs e)
        {
            this.Text = GetTitle();

            SetTextBoxes();


            //original_conData_MSSQL.DataSource = this.cmb_ServerName.Text;
            //original_conData_MSSQL.DataBase = this.cmb_DataBaseName.Text;
            //original_conData_MSSQL.bWindowsAuthentication = this.rdb_UseWindowsAuthentication.Checked;
            //original_conData_MSSQL.UserName = this.cmb_UserName.Text;
            //original_conData_MSSQL.Password = m_con.conData.DecryptString(DBConnection.Properties.DataBaseSettings.Default.Password);
            //original_conData_MSSQL.uiDataBaseType = DBConnection.Properties.DataBaseSettings.Default.uiDataBaseType;

            switch (m_con.DBType)
            {

                case DBConnection.eDBType.MSSQL:
                    this.radioButton_MicrosoftSQL .Checked = true;
                    break;

                case DBConnection.eDBType.MYSQL:
                    radioButton_MySqlServer.Checked = true;
                    break;

                default:
                    System.Windows.Forms.MessageBox.Show(this,"Not valid server type (Properties.DataBaseSettings.Default.uiDataBaseType can be 0  for MySQL server or 1 for MicrosoftSQL)","ERROR");
                    this.Close();
                    return;
            }

            switch (my_ConnectionDialog_enum)
            {

                case ConnectionDialog_enum.EditLoginAndPassword:
                    this.Text = GetTitle(); // "Poveži se z bazo podatkov";
                    this.btn_Action.Text = lng.s_ConnectWithDatabase.s;  //"Poveži se z bazo podatkov";
                    this.lbl_Instruction.ForeColor = Color.Blue;

                    this.cmb_ServerName.ReadOnly = false;
                    this.cmb_DataBaseName.ReadOnly = false;
                    this.cmb_UserName.ReadOnly = false;
                    if (rdb_SQL_Server_Authentication.Checked)
                    {
                        this.lbl_Instruction.Text = lng.s_Enter_UsernName_and_Password_then_press_button.s; //"Vnesite uporabniško ime in geslo. Nato pritisnite gumb poveži se z bazo podatkov.";
                        this.txt_Password.Visible = true;
                        this.lbl_Password.Visible = true;
                        this.txt_Password.Focus();
                    }
                    else
                    {
                        this.lbl_Instruction.Text = lng.s_Try_Width_Different_Windows_Log_on_Or_Select_SQL_Authenticatio_UserName_AndPassword.s; //"Vnesite uporabniško ime in geslo. Nato pritisnite gumb poveži se z bazo podatkov.";
                    }
                    this.btn_Action.ForeColor = Color.Blue;
                    break;

                case ConnectionDialog_enum.EditAll:
                    this.Text =  GetTitle(); //"Poveži se z bazo podatkov";
                    this.btn_Action.Text = lng.s_ConnectWithDatabase.s; //"Poveži se z bazo podatkov";
                    this.lbl_Instruction.Text = lng.s_Connection_with_database_was_not_done_yet.s; // "Povezava z bazo podatkov o ambulantnih čakalnih vrstah še ni bila vzpostavljena. Gre za začetno (prvo) vzpostavitev povezave z bazo. Vnesite ime ali IP naslov strežnika, ime podatkovne baze, uporabniško ime in geslo. Nato pritisnite gumb poveži se z bazo podatkov.";
                    this.lbl_Instruction.ForeColor = Color.Blue;
                    this.cmb_ServerName.ReadOnly = false;
                    this.cmb_DataBaseName.ReadOnly = false;
                    this.cmb_DataBaseName.Enabled = false;
                    this.cmb_UserName.ReadOnly = false;
                    this.cmb_UserName.Visible = true;
                    this.cmb_UserName.Enabled = false;
                    if (rdb_SQL_Server_Authentication.Checked)
                    {
                        this.txt_Password.Visible = true;
                        this.txt_Password.Enabled = false;
                    }
                    this.cmb_ServerName.Focus();
                    this.btn_Action.ForeColor = Color.Blue;
                    break;

                case ConnectionDialog_enum.TryAgain_EditAll:
                    this.Text = lng.s_Connection_with_database_not_succeeded_Try_again.s; // "Povezava na bazo podatkov ni uspela, poizkusite znova.";
                    this.btn_Action.Text = lng.s_ConnectWithDatabase.s; //"Poveži se z bazo podatkov";
                    this.lbl_Instruction.Text = lng.s_Connecting_with_database_was_not_successful_Enter_UserName_And_Password_Again_Then_Press_Connect_withDatabase.s; //"Povezavanje z bazo podatkov o ambulantnih čakalnih vrstah ni bilo uspešno. Ponovno preverite in vpišite ime ali IP naslov strežnika, ime podatkovne baze, uporabniško ime ter geslo. Nato pritisnite gumb \"Poveži se z bazo podatkov.\"";
                    this.lbl_Instruction.ForeColor = Color.Red;
                    this.cmb_ServerName.ReadOnly = false;
                    this.cmb_DataBaseName.ReadOnly = false;
                    this.cmb_UserName.ReadOnly = false;
                    if (rdb_SQL_Server_Authentication.Checked)
                    {
                        this.txt_Password.Visible = true;
                        this.lbl_Password.Visible = true;
                    }
                    this.cmb_ServerName.Focus();
                    this.btn_Action.ForeColor = Color.Blue;
                    break;

                case ConnectionDialog_enum.SaveConnectionData:
                    this.Text = lng.s_Save_database_connection_data.s;// "Shrani podatke za povezavo z bazo podatkov ?";
                    this.lbl_Instruction.Text = lng.s_Connection_is_OK_Click_on_button_Save_to_save_connection_data___.s; //"Povezava z bazo je uspela. S klikom na gumb Shrani shranite podatke za povezavo z bazo podatkov, da vam jih nasldenjič (razen gesla) ne bo potrebno znova vpisovati.";
                    this.lbl_Instruction.ForeColor = Color.Blue;
                    this.btn_Action.Text = lng.s_Save.s; //"Shrani";
                    this.cmb_ServerName.ReadOnly = true;
                    this.cmb_DataBaseName.ReadOnly = true;
                    this.cmb_UserName.ReadOnly = true;
                    this.txt_Password.Visible = false;
                    this.lbl_Password.Visible = false;
                    this.btn_Action.Focus();
                    this.btn_Action.ForeColor = Color.Blue;
                    break;

            }
        }


       private void Prepare_m_conData_MSSQL()
       {
           m_con.DBType = DBConnection.eDBType.MSSQL;

           cmb_DataBaseName.Enabled = true;
           cmb_DataBaseName.Top = Y[0];
           this.lbl_DataBase.Top = Y[0];

           cmb_UserName.Top = Y[3];
           lbl_UserName.Top = Y[3];

           txt_Password.Top = Y[4];
           lbl_Password.Top = Y[4];


           rdb_UseWindowsAuthentication.Visible = true;
           rdb_SQL_Server_Authentication.Visible = true;

           this.rdb_UseWindowsAuthentication.Enabled = true;
           this.rdb_SQL_Server_Authentication.Enabled = true;
           if (this.rdb_SQL_Server_Authentication.Checked)
           {
               this.cmb_UserName.Enabled = true;
               this.txt_Password.Enabled = true;
               this.txt_Password.Visible = true;
               this.lbl_Password.Visible = true;
           }
           else
           {
               this.cmb_UserName.Enabled = false;
               this.txt_Password.Visible = false;
               this.lbl_Password.Visible = false;
           }

       }
       private void Prepare_m_conData_MYSQL()
       {
           m_con.DBType = DBConnection.eDBType.MYSQL;

           cmb_DataBaseName.Enabled = true;
           cmb_DataBaseName.ReadOnly = false;
           cmb_UserName.Top = Y[0];
           lbl_UserName.Top = Y[0];

           txt_Password.Top = Y[1] -10;
           lbl_Password.Top = Y[1] -10;

           cmb_DataBaseName.Top = Y[2];
           this.lbl_DataBase.Top = Y[2];

           rdb_UseWindowsAuthentication.Visible = false;
           rdb_SQL_Server_Authentication.Visible = false;
 
           this.rdb_UseWindowsAuthentication.Enabled = false;
           this.rdb_SQL_Server_Authentication.Enabled = false;
           this.cmb_UserName.Enabled = true;
           this.txt_Password.Enabled = true;
           this.txt_Password.Visible = true;
           this.lbl_Password.Visible = true;


       }

        private void SetServerType()
        {
            if (this.radioButton_MicrosoftSQL.Checked)
            {
                Prepare_m_conData_MSSQL();
            }
            else
            {
                Prepare_m_conData_MYSQL();
            }

        }
        private void btn_Browse_servers_Click(object sender, EventArgs e)
        {
            SetServerType();

            Select_DataSource_Form SelectServerInLocalNetwork_Form = new Select_DataSource_Form(m_con);
            SelectServerInLocalNetwork_Form.TopMost = this.TopMost;
            DialogResult dRes;
            dRes = SelectServerInLocalNetwork_Form.ShowDialog(this);
            if (dRes == DialogResult.OK)
            {
                if (m_con.DataSource != null)
                    this.cmb_ServerName.Text = m_con.DataSource;

                if (m_con.DataBase != null)
                    this.cmb_DataBaseName.Text = m_con.DataBase;

                //if (m_con.conData.UserName != null)
                //{
                //    if (rdb_UseWindowsAuthentication.Checked)
                //    {
                //        this.cmb_UserName.Text = m_con.conData.m_WindowsAuthentication_UserName;
                //    }
                //    else
                //    {
                //        this.cmb_UserName.Text = m_con.conData.UserName;
                //    }
                //}

                if (m_con.Password != null)
                    this.txt_Password.Text = m_con.Password;
            }
        }

        private void cmb_ServerName_TextChanged(object sender, EventArgs e)
        {
            if (cmb_ServerName.Text.Length > 0)
            {
                btn_Browse_Databases_onServer.Enabled = true;
                this.cmb_DataBaseName.Enabled = true;
                this.cmb_UserName.Enabled = true;
                this.txt_Password.Enabled = true;
            }
            else
            {
                btn_Browse_Databases_onServer.Enabled = false;
                this.cmb_DataBaseName.Enabled = false;
            }
        }

        private void btn_Browse_Databases_onServer_Click(object sender, EventArgs e)
        {
            SetServerType();
            switch (m_con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    m_con.DataSource = this.cmb_ServerName.Text;
                    m_con.UserName = this.cmb_UserName.Text;
                    m_con.Password = this.txt_Password.Text;

                    //m_con.conData.SetConnectionString();
                    if (m_con.CheckServerConnection(nav.parentForm,m_Title))//check server only connection
                    {
                        Select_DataBase_Form Select_Data_Base_On_Server = new Select_DataBase_Form(nav.parentForm,m_con, m_Title);
                        Select_Data_Base_On_Server.TopMost = this.TopMost;
                        DialogResult dRes;
                        dRes = Select_Data_Base_On_Server.ShowDialog(this);
                        if (dRes == DialogResult.OK)
                        {
                            m_bNewDataBase = Select_Data_Base_On_Server.m_bNewDataBase;
                            this.cmb_DataBaseName.Text = m_con.DataBase;
                            SetRecentComboBoxes();
                            bDataBaseConnectionChecked = true;
                            usrc_NavigationButtons1.Button_NEXT_Enabled = true;
                            return;
                        }
                        else
                        {
                            // Cancel pressed so set my Settings again

                            if (m_con.DataSource != null)
                                this.cmb_ServerName.Text = m_con.DataSource;

                            if (m_con.DataBase != null)
                                this.cmb_DataBaseName.Text = m_con.DataBase;

                            if (m_con.UserName != null)
                            {
                                this.cmb_UserName.Text = m_con.UserName;
                            }

                            if (m_con.Password != null)
                                this.txt_Password.Text = m_con.Password;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,lng.s_CanNotMakeServerOnlyConnection.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case DBConnection.eDBType.MSSQL:
                    m_con.DataSource = this.cmb_ServerName.Text;
                    m_con.WindowsAuthentication = rdb_UseWindowsAuthentication.Checked;
                    if (this.rdb_SQL_Server_Authentication.Checked)
                    {
                        m_con.UserName = this.cmb_UserName.Text;
                        m_con.Password = this.txt_Password.Text;
                    }
                    //m_con.conData.SetConnectionString();
                    if (m_con.CheckServerConnection(nav.parentForm, m_Title)) //check server only connection
                    {
                        Select_DataBase_Form Select_Data_Base_On_Server = new Select_DataBase_Form(nav.parentForm,m_con, m_Title);
                        Select_Data_Base_On_Server.TopMost = this.TopMost;
                        DialogResult dRes;
                        dRes = Select_Data_Base_On_Server.ShowDialog(this);
                        if (dRes == DialogResult.OK)
                        {
                            m_bNewDataBase = Select_Data_Base_On_Server.m_bNewDataBase;
                            this.cmb_DataBaseName.Text = m_con.DataBase;
                            SetRecentComboBoxes();
                            bDataBaseConnectionChecked = true;
                            usrc_NavigationButtons1.Button_NEXT_Enabled = true;
                            return;
                        }
                        else
                        {
                            // Cancel pressed so set my Settings again

                            if (m_con.DataSource != null)
                                this.cmb_ServerName.Text = m_con.DataSource;

                            if (m_con.DataBase != null)
                                this.cmb_DataBaseName.Text = m_con.DataBase;

                            if (m_con.UserName != null)
                            {
                                if (rdb_UseWindowsAuthentication.Checked)
                                {
                                    this.cmb_UserName.Text = m_con.UserName;
                                }
                                else
                                {
                                    this.cmb_UserName.Text = m_con.UserName;
                                }
                            }

                            if (m_con.Password != null)
                                this.txt_Password.Text = m_con.Password;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,lng.s_CanNotMakeServerOnlyConnection.s, lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
            }
        }

        private void SetRecentComboBoxes()
        {
            cmb_DataBaseName.Set(cmb_DataBaseName.Text);
            cmb_ServerName.Set(cmb_ServerName.Text);
            cmb_UserName.Set(cmb_UserName.Text);
        }

        private void rdb_UseWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            SetTextBoxes();
        }

        private void rdb_SQL_Server_Authentication_CheckedChanged(object sender, EventArgs e)
        {
            //this.m_con.conData.bWindowsAuthentication = !rdb_SQL_Server_Authentication.Checked;
        }

        private void btn_Action_Click(object sender, EventArgs e)
        {
            SetServerType();

            if (my_ConnectionDialog_enum == ConnectionDialog_enum.SaveConnectionData)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else
            {
                m_con.DataSource = this.cmb_ServerName.Text;
                m_con.DataBase = this.cmb_DataBaseName.Text;
                switch (m_con.DBType)
                {
                    case DBConnection.eDBType.MYSQL:
                        m_con.UserName = this.cmb_UserName.Text;
                        m_con.Password = this.txt_Password.Text;
                        //m_con.conData.bWindowsAuthentication = this.rdb_UseWindowsAuthentication.Checked;
                        break;

                    case DBConnection.eDBType.MSSQL:
                        if (rdb_SQL_Server_Authentication.Checked)
                        {
                            m_con.UserName = this.cmb_UserName.Text;
                            m_con.Password = this.txt_Password.Text;
                        }
                        m_con.WindowsAuthentication = this.rdb_UseWindowsAuthentication.Checked;
                        break;
                }
                SetRecentComboBoxes();
            }
            if (m_con.CheckDataBaseConnection(this,lng.s_Connection_to_Database.s))
            {
                bDataBaseConnectionChecked = true;
                usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            }

        }

        private void radioButton_MySqlServer_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_MySqlServer.Checked)
            {
                Prepare_m_conData_MYSQL();
            }
            else
            {
                Prepare_m_conData_MSSQL();
                this.rdb_UseWindowsAuthentication.Enabled = true;

                if (m_con.WindowsAuthentication)
                {
                    this.rdb_SQL_Server_Authentication.Checked = false;
                    this.rdb_UseWindowsAuthentication.Checked = true;
                }
                else
                {
                    this.rdb_SQL_Server_Authentication.Checked = true;
                    this.rdb_UseWindowsAuthentication.Checked = false;
                    this.lbl_Password.Visible = true;
                }
            }
        }

        private void radioButton_MicrosoftSQL_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton_MicrosoftSQL.Checked)
            {
                Prepare_m_conData_MSSQL();
            }
            else
            {
            }
        }

        private void do_OK()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void do_Cancel()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            nav.eExitResult = evt;
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch (evt)
                    {
                        case Navigation.eEvent.CANCEL:
                            do_Cancel();
                            return;
                        case Navigation.eEvent.OK:
                            do_OK();
                            return;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case Navigation.eEvent.NEXT:
                            if (bDataBaseConnectionChecked)
                            {
                                do_OK();
                            }
                            else
                            {
                                MessageBox.Show(this, lng.s_NoConnectionToDatabase_You_must_set_Database_connection_to_go_next_step.s);
                            }
                            return;
                        case Navigation.eEvent.EXIT:
                            do_Cancel();
                            return;
                        case Navigation.eEvent.PREV:
                            do_Cancel();
                            return;
                    }
                    break;
            }
        }
    }
}
