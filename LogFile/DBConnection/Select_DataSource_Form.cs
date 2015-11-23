using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using LanguageControl;

namespace LogFile
{
    public partial class Select_DataSource_Form : Form
    {
        public class Selected
        {
            public string HostName;
            public byte[] bAdress;
            public ushort uiPort;
            public Selected(string hostname, byte[] badress, ushort uiport)
            {
                HostName = hostname;
                bAdress = badress;
                uiPort = uiport;
            }
        }

        private Selected m_Selected;

        private Log_DBConnection m_con = null;

        private DataTable Table_of_ServersInLocalNetwork;

        public Select_DataSource_Form(Log_DBConnection con)
        {
            m_con = con;
            InitializeComponent();
            this.lbl_SelectedServer.Text = lngConn.s_Select_Server.s + ":";

        }

        private void Timer_ShowServers_Tick(object sender, EventArgs e)
        {

            this.Timer_ShowServers.Enabled = false;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                switch (m_con.DBType)
                {
                    case Log_DBConnection.eDBType.MYSQL:
                        //System.Web.Services.Protocols.
                        searchLocalNetwork.Visible = true;
                        this.dataGridView_SELECT_SERVER.Visible = false;
                        this.lbl_Progress.Visible = false;
                        this.lbl_Select_server_and_press_ok.Visible = false;
                        this.btn_OK.Visible = true;
                        this.Cursor = System.Windows.Forms.Cursors.Arrow;
                        this.btn_OK.Enabled = true;
                        break;

                    case Log_DBConnection.eDBType.MSSQL:
                        searchLocalNetwork.Visible = false;
                        SqlDataSourceEnumerator ServerEnum = SqlDataSourceEnumerator.Instance;
                        Table_of_ServersInLocalNetwork = ServerEnum.GetDataSources();
                        dataGridView_SELECT_SERVER.DataSource = Table_of_ServersInLocalNetwork;
                        this.lbl_Progress.Visible = false;
                        this.Cursor = System.Windows.Forms.Cursors.Arrow;
                        lbl_Select_server_and_press_ok.Visible = true;
                        this.btn_OK.Enabled = true;
                        string myDataSource = "";
                        if (GetSelectedServer(ref myDataSource))
                        {
                            textBox_SelectedServer.Text = myDataSource;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                dataGridView_SELECT_SERVER.Visible = false;
                lbl_Progress.Font = new Font("Arial", 10, FontStyle.Bold);
                lbl_Progress.Text = lngConn.s_Error_browse_DataBase_servers_Error_Exception.s + ex.Message;
                lbl_Select_server_and_press_ok.Visible = false;
            }
        }

        private void Select_Server_Form_Load(object sender, EventArgs e)
        {
            switch (this.m_con.DBType)
            {
                case Log_DBConnection.eDBType.MYSQL:
                    this.Text = lngConn.s_Select.s + " MySQL " + lngConn.s_Server.s;
                    this.searchLocalNetwork.Enabled = true;
                    this.searchLocalNetwork.Visible = true;
                    lbl_Progress.Text = lngConn.s_Please_wait_while_browsing_local_network_for_database_servers.s;
                    lbl_Select_server_and_press_ok.Text = lngConn.s_Select_server_and_press_ok.s;
                    lbl_Select_server_and_press_ok.Visible = false;
                    btn_CANCEL.Text = lngConn.s_Cancel.s;
                    this.Timer_ShowServers.Enabled = true;
                    this.btn_OK.Enabled = false;
                    this.rdbHostName.Enabled = true;
                    this.rdbHostName.Checked = true;
                    this.rdbIPAddress.Enabled = true;
                    this.rdbHostName.Visible = true;
                    this.rdbIPAddress.Visible = true;
                    break;

                case Log_DBConnection.eDBType.MSSQL:
                    this.Text = lngConn.s_Select.s + " Microsoft SQL " + lngConn.s_Server.s;
                    this.searchLocalNetwork.Enabled = false;
                    this.searchLocalNetwork.Visible = false;
                    lbl_Progress.Text = lngConn.s_Please_wait_while_browsing_local_network_for_database_servers.s;
                    lbl_Select_server_and_press_ok.Text = lngConn.s_Select_server_and_press_ok.s;
                    lbl_Select_server_and_press_ok.Visible = false;
                    btn_CANCEL.Text = lngConn.s_Cancel.s;
                    this.Timer_ShowServers.Enabled = true;
                    this.btn_OK.Enabled = false;
                    this.rdbHostName.Enabled = false;
                    this.rdbHostName.Visible = false;
                    this.rdbIPAddress.Enabled = false;
                    this.rdbIPAddress.Visible = false;
                    break;
            }
        }

        private void btn_CANCEL_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }


        private bool GetSelectedServer(ref string Server)
        {
            if (dataGridView_SELECT_SERVER.SelectedRows.Count > 0)
            {
                if (dataGridView_SELECT_SERVER.SelectedRows[0].Cells[0].Value != null)
                {
                    if (dataGridView_SELECT_SERVER.SelectedRows[0].Cells[1].Value != null)
                    {
                        string InstanceName = dataGridView_SELECT_SERVER.SelectedRows[0].Cells[1].Value.ToString();
                        if (InstanceName.Length > 0)
                        {
                            Server = dataGridView_SELECT_SERVER.SelectedRows[0].Cells[0].Value.ToString() + '\\' + InstanceName;
                        }
                        else
                        {
                            if ((dataGridView_SELECT_SERVER.SelectedRows[0].Cells[2].Value.GetType() == typeof(System.DBNull))
                                && (dataGridView_SELECT_SERVER.SelectedRows[0].Cells[3].Value.GetType() == typeof(System.DBNull))) //Tricky check for SQLExpress version 2012 
                            {
                                Server = dataGridView_SELECT_SERVER.SelectedRows[0].Cells[0].Value.ToString() + "\\SQLEXPRESS";
                            }
                            else
                            {
                                Server = dataGridView_SELECT_SERVER.SelectedRows[0].Cells[0].Value.ToString();
                            }
                        }
                        if (Server.Length > 0)
                        {
                            //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            //this.Close();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.textBox_SelectedServer.Text.Length>0)
            {
                m_con.DataSource = this.textBox_SelectedServer.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show(this, lngConn.s_No_server_selected_Please_select_server.s, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void searchLocalNetwork_SelectedServerChanged(string hostName, byte[] badress, ushort uiport)
        {
            if (m_Selected == null)
            {
                m_Selected = new Selected(hostName, badress, uiport);
            }
            else
            {
                m_Selected.HostName = hostName;
                m_Selected.bAdress = badress;
                m_Selected.uiPort = uiport;
            }

            if (rdbHostName.Checked)
            {
                textBox_SelectedServer.Text = hostName;
            }
            else
            {
                textBox_SelectedServer.Text = SearchLocalNetwork.StaticFunc.GetComputerFromIP(badress);
            }
        }

        private void dataGridView_SELECT_SERVER_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView_SELECT_SERVER_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string myDataSource = "";
            if (GetSelectedServer(ref myDataSource))
            {
                textBox_SelectedServer.Text = myDataSource;
            }

        }

        private void Select_DataSource_Form_Activated(object sender, EventArgs e)
        {
        }

        private void rdbIPAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIPAddress.Checked)
            {
                if (m_Selected != null)
                {
                    textBox_SelectedServer.Text = SearchLocalNetwork.StaticFunc.GetComputerFromIP(m_Selected.bAdress);
                }
            }
        }

        private void rdbHostName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbHostName.Checked)
            {
                if (m_Selected != null)
                {
                    textBox_SelectedServer.Text = m_Selected.HostName;
                }
            }
        }

        private void searchLocalNetwork_Load(object sender, EventArgs e)
        {

        }
    }

}
