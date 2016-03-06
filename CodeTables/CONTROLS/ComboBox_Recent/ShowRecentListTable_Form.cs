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

namespace ComboBox_Recent
{
    public partial class ShowRecentListTable_Form : Form
    {
        public ShowRecentListTable_Form(DataTable dt, string XmlFile)
        {
            InitializeComponent();
            this.dgv_RecentItems.DataSource = dt;
            this.txt_XmlFile.Text = XmlFile;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
