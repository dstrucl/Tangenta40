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
using CodeTables;
using DBTypes;


namespace ShopC
{
    public partial class Form_Stock_AvoidStock_Edit : Form
    {
        public DateTime_v ExpiryDate = null;
        DataTable dt_Stock = new DataTable();

        public Form_Stock_AvoidStock_Edit(DateTime_v xExpiryDate)
        {
            InitializeComponent();
            this.Text = lngRPM.s_ExpiryDateFormText.s;
            this.lbl_ExpiryDate.Text = lngRPM.s_PleaseDefineExpiryDate.s;
            this.btn_Cancel.Text = lngRPM.s_Cancel.s;
            this.btn_OK.Text = lngRPM.s_OK.s;
            ExpiryDate = xExpiryDate;
            if (ExpiryDate != null)
            {
                this.dateTimePicker.Value = ExpiryDate.v;
            }
        }

        private void Stock_EditForm_Load(object sender, EventArgs e)
        {
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (ExpiryDate == null)
            {
                ExpiryDate = new DateTime_v();
            }
            ExpiryDate.v = this.dateTimePicker.Value;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ExpiryDate = null;
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
