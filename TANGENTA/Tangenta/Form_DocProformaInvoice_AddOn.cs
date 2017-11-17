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
    public partial class Form_DocProformaInvoice_AddOn : Form
    {
        public DocProformaInvoice_AddOn m_AddOnDPI = null;
        public GlobalData.ePaymentType m_ePaymentType = GlobalData.ePaymentType.ANY_TYPE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;
        private bool m_bPrint =false;
        private usrc_AddOn m_usrc_AddOn = null;

        public Form_DocProformaInvoice_AddOn(DocProformaInvoice_AddOn x_AddOnDPI, bool bxPrint, usrc_AddOn xusrc_AddOn)
        {
            InitializeComponent();
            m_AddOnDPI = x_AddOnDPI;
            m_bPrint = bxPrint;
            m_usrc_AddOn = xusrc_AddOn;
            this.Text = lng.s_PaymentOfProformaInvoiceAndPrint.s;

        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void Form_DocProformaInvoice_Payment_Load(object sender, EventArgs e)
        {
            if (this.usrc_DocProformaInvoice_AddOn1.Init(m_AddOnDPI, m_bPrint, m_usrc_AddOn))
            {
                return;
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }


        private void usrc_DocProformaInvoice_AddOn1_OK()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void usrc_DocProformaInvoice_AddOn1_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
