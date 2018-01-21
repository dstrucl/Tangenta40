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
using System.Collections;
using GongSolutions.Shell;
using GongSolutions.Shell.Interop;


using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using LanguageControl;
using System.Management;
using System.Data.Common;
using System.Management.Automation;
using System.DirectoryServices;

namespace DBConnectionControl40
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

        private DBConnection m_con = null;

        private DataTable Table_of_ServersInLocalNetwork;

        public Select_DataSource_Form(DBConnection con)
        {
            m_con = con;
            InitializeComponent();
            this.lbl_SelectedServer.Text = lng.s_Select_Server.s + ":";

        }

        public DataTable GetSqlServers(DataTable dt,string server)
        {
            object results = null;
            string commandStr =
                @"if(Test-Connection " + server + @" -Count 2 -Quiet) {
                    Get-WmiObject win32_Service -Computer " + server + @" |`
                    where {$_.DisplayName -match ""SQL Server""} | `
                    select SystemName, DisplayName, Name, State, Status, StartMode, StartName
                }";

            PSCommand cmd = new PSCommand();

            cmd.AddScript(commandStr);
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Commands = cmd;
                results = ps.Invoke();
            }
            if (results is System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>)
            {
                if (((System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>)results).Count>0)
                {
                    foreach (PSObject psobject in (System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject>)results)
                    {
                        string stype = psobject.GetType().ToString();
                        PSMemberInfoCollection<PSMemberInfo> pinfmemberc = psobject.Members;
                        bool bDisplayNameFound = false;
                        foreach (PSMemberInfo psmemberinf in pinfmemberc)
                        {
                            PSMemberTypes psmemtypes = psmemberinf.MemberType;
                            if (psmemberinf.Name.Equals("DisplayName"))
                            {
                                bDisplayNameFound = true;
                            }
                            if (bDisplayNameFound)
                            {
                                if (psmemberinf.Value is string)
                                {
                                    string svalue = (string)psmemberinf.Value;
                                    if (svalue.Contains("SQL Server ("))
                                    {
                                        string[] sserver = svalue.Split(new char[] { '(', ')' });
                                        DataRow dr = dt.NewRow();
                                        dr["Servername"] = server;
                                        dr["InstanceName"]=sserver[1];
                                        dt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        PSMemberInfoCollection<PSMethodInfo> pinfmedthodc = psobject.Methods;
                        PSMemberInfoCollection<PSPropertyInfo> pinfpropertiesc = psobject.Properties;
                    }
                }
            }
            return dt;
        }


    public sealed class ShellNetworkComputers : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            ShellItem folder = new ShellItem((Environment.SpecialFolder)CSIDL.NETWORK);
            IEnumerator<ShellItem> e = folder.GetEnumerator(SHCONTF.FOLDERS);

            while (e.MoveNext())
            {
//                Debug.Print(e.Current.ParsingName);
                yield return e.Current.ParsingName;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    private void Timer_ShowServers_Tick(object sender, EventArgs e)
        {

            this.Timer_ShowServers.Enabled = false;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                switch (m_con.DBType)
                {
                    case DBConnection.eDBType.MYSQL:
                        //System.Web.Services.Protocols.
                        searchLocalNetwork.Visible = true;
                        this.dataGridView_SELECT_SERVER.Visible = false;
                        this.lbl_Progress.Visible = false;
                        this.lbl_Select_server_and_press_ok.Visible = false;
                        this.btn_OK.Visible = true;
                        this.Cursor = System.Windows.Forms.Cursors.Arrow;
                        this.btn_OK.Enabled = true;
                        break;

                    case DBConnection.eDBType.MSSQL:
                        searchLocalNetwork.Visible = false;

                        if (OSVer.OSVersionInfo.Name.Contains("Windows 10"))
                        {
                            Table_of_ServersInLocalNetwork = new DataTable();
                            DataColumn dcol_ServerName = new DataColumn("ServerName", typeof(string));
                            DataColumn dcol_InstanceName = new DataColumn("InstanceName", typeof(string));
                            DataColumn dcol_IsClustered = new DataColumn("IsClustered", typeof(bool));
                            DataColumn dcol_Version = new DataColumn("Version", typeof(string));
                            Table_of_ServersInLocalNetwork.Columns.Add(dcol_ServerName);
                            Table_of_ServersInLocalNetwork.Columns.Add(dcol_InstanceName);
                            Table_of_ServersInLocalNetwork.Columns.Add(dcol_IsClustered);
                            Table_of_ServersInLocalNetwork.Columns.Add(dcol_Version);

                            ShellNetworkComputers shnc = new ShellNetworkComputers();
                            foreach (string scomputer in shnc)
                            {
                                string scomp = scomputer.Replace("\\\\", "");
                                GetSqlServers(Table_of_ServersInLocalNetwork,scomp);
                            }
                        }
                        else
                        {
                            SqlDataSourceEnumerator ServerEnum = SqlDataSourceEnumerator.Instance;
                            Table_of_ServersInLocalNetwork = ServerEnum.GetDataSources();
                        }

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
                lbl_Progress.Text = lng.s_Error_browse_DataBase_servers_Error_Exception.s + ex.Message;
                lbl_Select_server_and_press_ok.Visible = false;
            }
        }

        private void Select_Server_Form_Load(object sender, EventArgs e)
        {
            switch (this.m_con.DBType)
            {
                case DBConnection.eDBType.MYSQL:
                    this.Text = lng.s_Select.s + " MySQL " + lng.s_Server.s;
                    this.searchLocalNetwork.Enabled = true;
                    this.searchLocalNetwork.Visible = true;
                    lbl_Progress.Text = lng.s_Please_wait_while_browsing_local_network_for_database_servers.s;
                    lbl_Select_server_and_press_ok.Text = lng.s_Select_server_and_press_ok.s;
                    lbl_Select_server_and_press_ok.Visible = false;
                    btn_CANCEL.Text = lng.s_Cancel.s;
                    this.Timer_ShowServers.Enabled = true;
                    this.btn_OK.Enabled = false;
                    this.rdbHostName.Enabled = true;
                    this.rdbHostName.Checked = true;
                    this.rdbIPAddress.Enabled = true;
                    this.rdbHostName.Visible = true;
                    this.rdbIPAddress.Visible = true;
                    break;

                case DBConnection.eDBType.MSSQL:
                    this.Text = lng.s_Select.s + " Microsoft SQL " + lng.s_Server.s;
                    this.searchLocalNetwork.Enabled = false;
                    this.searchLocalNetwork.Visible = false;
                    lbl_Progress.Text = lng.s_Please_wait_while_browsing_local_network_for_database_servers.s;
                    lbl_Select_server_and_press_ok.Text = lng.s_Select_server_and_press_ok.s;
                    lbl_Select_server_and_press_ok.Visible = false;
                    btn_CANCEL.Text = lng.s_Cancel.s;
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
                MessageBox.Show(this, lng.s_No_server_selected_Please_select_server.s, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
