#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnectionControl40;

namespace DBSync
{
    public partial class Form_GetDBType : Form
    {
        NavigationButtons.NavigationButtons.eButtons m_eButtons = NavigationButtons.NavigationButtons.eButtons.OkCancel;
        public DBConnection.eDBType m_DBType = DBConnection.eDBType.SQLITE;
        public NavigationButtons.NavigationButtons.eEvent eExitType = NavigationButtons.NavigationButtons.eEvent.NOTHING;

        public Form_GetDBType(string sdbtype, NavigationButtons.NavigationButtons nav_buttons)
        {
            InitializeComponent();

            //if (xImage_Cancel!=null)
            //{
            //    this.btn_Exit.Image = xImage_Cancel;
            //}
            m_eButtons = nav_buttons.m_eButtons;
            usrc_NavigationButtons1.Init(nav_buttons);
            lngRPM.s_SelectDatabase.Text(lbl_SelectDataBase);
            if (sdbtype != null)
            {
                if (sdbtype.Equals("SQLITE"))
                {
                    rdb_SQLite.Checked = true;
                    rdb_MSSQL.Checked = false;
                    m_DBType = DBConnection.eDBType.SQLITE;
                }
                else if (sdbtype.Equals("MSSQL"))
                {
                    rdb_SQLite.Checked = false;
                    rdb_MSSQL.Checked = true;
                    m_DBType = DBConnection.eDBType.MSSQL;
                }
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rdb_SQLite.Checked)
            {
                m_DBType = DBConnection.eDBType.SQLITE;
            }
            else
            {
                m_DBType = DBConnection.eDBType.MSSQL;
            }
            this.Close();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.NavigationButtons.eEvent evt)
        {
            switch (m_eButtons)
            {
                case NavigationButtons.NavigationButtons.eButtons.OkCancel:
                    switch (evt)
                    {
                        case NavigationButtons.NavigationButtons.eEvent.OK:
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                            eExitType = NavigationButtons.NavigationButtons.eEvent.OK;
                            this.Close();
                            break;


                        case NavigationButtons.NavigationButtons.eEvent.CANCEL:
                            DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            eExitType = NavigationButtons.NavigationButtons.eEvent.CANCEL;
                            this.Close();
                            break;

                    }
                    break;
                case NavigationButtons.NavigationButtons.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.NavigationButtons.eEvent.PREV:
                            DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            eExitType = NavigationButtons.NavigationButtons.eEvent.PREV;
                            this.Close();
                            break;

                        case NavigationButtons.NavigationButtons.eEvent.NEXT:
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                            eExitType = NavigationButtons.NavigationButtons.eEvent.NEXT;
                            this.Close();
                            break;

                        case NavigationButtons.NavigationButtons.eEvent.EXIT:
                            DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            eExitType = NavigationButtons.NavigationButtons.eEvent.EXIT;
                            this.Close();
                            break;

                    }
                    break;
            }

        }

            //private void usrc_NavigationButtons1_ButtonPressed(usrc_NavigationButtons.usrc_NavigationButtons.eEvent evt)
            //{
            //    switch (evt)
            //    {
            //        case usrc_NavigationButtons.usrc_NavigationButtons.eEvent.EXIT;
            //            this.Close();
            //            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //            dlgRes = DialogResult;
            //            break;

            //    }
            //}
        }
}
