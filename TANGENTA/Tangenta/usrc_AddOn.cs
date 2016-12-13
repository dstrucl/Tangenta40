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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace Tangenta
{
    public partial class usrc_AddOn : UserControl
    {
        internal usrc_Invoice m_usrc_Invoice = null;

        private bool IsDocInvoice
        {
            get
            {
                if (m_usrc_Invoice!=null)
                {
                    return m_usrc_Invoice.IsDocInvoice;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool IsDocProformaInvoice
        {
            get
            {
                if (m_usrc_Invoice != null)
                {
                    return m_usrc_Invoice.IsDocProformaInvoice;
                }
                else
                {
                    return false;
                }
            }
        }

        public usrc_AddOn()
        {
            InitializeComponent();
        }

        public void Init(usrc_Invoice x_usrc_Invoice)
        {
            m_usrc_Invoice = x_usrc_Invoice;
        }
        private void btn_Notice_Click(object sender, EventArgs e)
        {
            if (IsDocInvoice)
            {
                Get_DocInvoice_AddOn(m_usrc_Invoice.AddOnDI);
            }
            else if (IsDocProformaInvoice)
            {
                Get_DocProformaInvoice_AddOn(m_usrc_Invoice.AddOnDPI);
            }
            //Form_Notice frm_notice = new Form_Notice(this);
            //frm_notice.ShowDialog();
        }

        public bool Get_DocInvoice_AddOn(DocInvoice_AddOn x_DocInvoice_AddOn)
        {
            Form_DocInvoice_AddOn payment_frm = new Form_DocInvoice_AddOn(x_DocInvoice_AddOn);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public bool Get_DocInvoice_AddOn(TangentaDB.InvoiceData xInvoiceData, string xDocInvoice)
        {
            Form_DocInvoice_AddOn payment_frm = new Form_DocInvoice_AddOn(xInvoiceData, xDocInvoice);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public bool Get_DocProformaInvoice_AddOn(DocProformaInvoice_AddOn m_DocProformaInvoice_AddOn)
        {
            Form_DocProformaInvoice_AddOn payment_frm = new Form_DocProformaInvoice_AddOn(m_DocProformaInvoice_AddOn,false,this);
            if (payment_frm.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
    }
}
