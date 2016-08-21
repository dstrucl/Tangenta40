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
using System.Data.SQLite;

namespace DBConnectionControl40
{
    public partial class SQLiteInfo_Form : Form
    {
        public SQLiteInfo_Form()
        {
            InitializeComponent();
            this.lbl_SQLiteInfo.Text = "SQLite version = " + System.Data.SQLite.SQLiteConnection.SQLiteVersion + "\r\n"
                                      + "       SourceID = " + System.Data.SQLite.SQLiteConnection.SQLiteSourceId;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
