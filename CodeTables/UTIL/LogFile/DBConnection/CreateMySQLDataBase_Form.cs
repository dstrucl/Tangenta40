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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using LogFile;

namespace LogFile
{
    public partial class CreateMySQLDataBase_Form : Form
    {
        Log_DBConnection m_con;
        public CreateMySQLDataBase_Form(ref Log_DBConnection xConn)
        {
            InitializeComponent();
            m_con = xConn;
            this.Text = lng.s_CreateDataBaseDialog_Form_Title.s;
            this.Icon = Properties.Resources.CreateDataBase;
            this.lbl_CreateDatabase.Text = lng.s_CreateNewDatabase.s;
            this.txtDataBaseName.Text = m_con.DataBase;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (this.txtDataBaseName.Text.Length > 0)
            {
                string SqlCreateDatabase = "\nCREATE DATABASE `" + this.txtDataBaseName.Text + "`;";
                string csError = "";
                if (this.m_con.CreateMySQLDatabase(SqlCreateDatabase,ref csError))
                {
                    m_con.DataBase = this.txtDataBaseName.Text;
                    MessageBox.Show(lng.s_DataBase.s + " " + m_con.DataBase + " " + LanguageControl.lngRPM.s_Created.s, lngRPM.s_Info.s, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Error.Show(csError);
                }
            }
            else
            {
                MessageBox.Show(lng.s_DatabaseNotDefined.s, lngRPM.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
