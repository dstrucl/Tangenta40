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
using DBConnectionControl40;
using DBTypes;
using TangentaDB;

namespace Tangenta
{
    public partial class Form_DocInvoice_AddOn : Form
    {
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;
        private DocInvoice_AddOn m_AddOnDI;
        private usrc_AddOn m_usrc_AddOn = null;
        private bool m_bPrint = false;

        public Form_DocInvoice_AddOn(DocInvoice_AddOn x_DocInvoice_AddOn,bool x_bPrint, usrc_AddOn x_usrc_AddOn)
        {
            InitializeComponent();
            this.m_AddOnDI = x_DocInvoice_AddOn;
            m_usrc_AddOn = x_usrc_AddOn;
            m_bPrint = x_bPrint;
            this.Text = lng.s_PaymentOfInvoiceAndPrint.s;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_Payment_Load(object sender, EventArgs e)
        {
            if (this.m_usrc_DocInvoice_AddOn.Init(m_AddOnDI, m_bPrint, m_usrc_AddOn))
            {
                return;
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void m_usrc_Payment_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void m_usrc_Payment_Issue()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
