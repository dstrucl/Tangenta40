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

namespace LogFile
{
    public partial class View_AccessRights_Form : Form
    {
        DataSet ds = new DataSet();
        Log_DBConnection m_con;

        public View_AccessRights_Form(Log_DBConnection con)
        {
            m_con = con;
            InitializeComponent();
        }

        private void View_AccessRights_Form_Load(object sender, EventArgs e)
        {
            this.Text = lngConn.s_DataBaseResult_Form_Title.s;

            if (m_con.WindowsAuthentication)
            {

                lbl_Success.Text = lngConn.s_Connection_to_Database.s + "\"" + m_con.DataSource + "\"" + lngConn.s_with_Windows_authentication_is_OK.s + "\"" + m_con.WindowsAuthentication_UserName + "\"" + lngConn.s_are.s;
            }
            else
            {

                lbl_Success.Text = lngConn.s_Connection_to_Database.s + "\"" + m_con.DataSource + "\"" + lngConn.s_with_SQL_authentication_is_OK.s + "\"" + m_con.UserName + "\"" + lngConn.s_are.s; ;
            }

            switch (m_con.DBType)
            {
                case Log_DBConnection.eDBType.MSSQL:
                    {
                        string sql_cmd = @"SELECT *
                                                   FROM fn_my_permissions(NULL, 'SERVER');";
                        string csError = "";
                        if (m_con.ReadDataSet(ref ds, sql_cmd, ref csError))
                        {
                            if (ds.Tables.Count > 0)
                            {
                                dataGridView_Permissions.DataSource = ds.Tables[0];
                                dataGridView_Permissions.Update();
                                dataGridView_Permissions.Visible = true;
                                dataGridView_Permissions.AutoSize = false;
                                dataGridView_Permissions.AutoResizeColumns();
                            }
                        }
                    }
                    break;

                case Log_DBConnection.eDBType.MYSQL:
                    {
                        string sql_cmd = "SELECT * FROM `information_schema`.`USER_PRIVILEGES`;";
                        string csError = "";
                        if (m_con.ReadDataSet(ref ds, sql_cmd, ref csError))
                        {
                            if (ds.Tables.Count > 0)
                            {
                                dataGridView_Permissions.DataSource = ds.Tables[0];
                                dataGridView_Permissions.Update();
                                dataGridView_Permissions.Visible = true;
                                dataGridView_Permissions.AutoSize = false;
                                dataGridView_Permissions.AutoResizeColumns();
                            }
                        }
                    }
                    break;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
