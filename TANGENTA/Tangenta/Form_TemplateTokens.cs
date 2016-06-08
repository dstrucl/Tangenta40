#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_TemplateTokens : Form
    {
        private InvoiceData m_InvoiceData = null;
        public Form_TemplateTokens(InvoiceData xInvoiceData)
        {
            InitializeComponent();
            m_InvoiceData = xInvoiceData;


            this.txt_Tokens.Text = m_InvoiceData.GetAllTokens();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
