﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace DBConnectionControl40
{
    public partial class Connection_Control : UserControl
    {
        private DBConnection m_con;
        public Connection_Control(DBConnection con)
        {
            InitializeComponent();
            m_con = con;
            this.lbl_DataSourceAndDatabase.AutoSize = true;
            switch (m_con.DBType)
            {
                case DBConnection.eDBType.SQLITE:
                    this.lbl_ServerType.Text = m_con.ConnectionName+":" + lngConn.s_ServerType.s + " = SQLITE";
                    this.lbl_DataSourceAndDatabase.Text = m_con.DataBase;
                    break;
                case DBConnection.eDBType.MSSQL:
                    this.lbl_ServerType.Text = m_con.ConnectionName + ":" + lngConn.s_ServerType.s + " = MSSQL";
                    this.lbl_DataSourceAndDatabase.Text = lngConn.s_Server.s + " = " + m_con.DataSource + ", " + lngConn.s_DataBase.s + " = " + m_con.DataBase;
                    break;

                case DBConnection.eDBType.MYSQL:
                    this.lbl_ServerType.Text = m_con.ConnectionName + ":" + lngConn.s_ServerType.s + " = MYSQL";
                    this.lbl_DataSourceAndDatabase.Text = lngConn.s_Server.s + " = " + m_con.DataSource + ", " + lngConn.s_DataBase.s + " = " + m_con.DataBase;
                    break;
            }
            this.Width = this.lbl_DataSourceAndDatabase.Left + this.lbl_DataSourceAndDatabase.Width + 10;
        }

        private void btn_ConnectionDialog_Click(object sender, EventArgs e)
        {
            string Err = null;
          //  bool bNewDB = false;
            if (m_con.SetNewConnection((Form)this.Parent, m_con.DB_Param))
            {
                if (m_con.DB_Param.GetType() == typeof(LocalDB_data))
                {
                    LocalDB_data xLocalDB_data = (LocalDB_data)m_con.DB_Param;
                    if (!xLocalDB_data.Save(m_con.m_inifile_prefix,ref Err))
                    {
                        LogFile.Error.Show(Err);
                    }
                }
                else
                {
                    if (m_con.DB_Param.GetType() == typeof(RemoteDB_data))
                    {
                        RemoteDB_data xRemoteDB_data = (RemoteDB_data)m_con.DB_Param;
                        if (!xRemoteDB_data.Save(this.m_con.m_inifile_prefix,ref Err))
                        {
                            LogFile.Error.Show(Err);
                        }
                    }
                }
            }
        }
    }
}
