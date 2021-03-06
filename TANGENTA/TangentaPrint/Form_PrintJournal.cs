﻿#region LICENSE 
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

namespace TangentaPrint
{
    public partial class Form_PrintJournal : Form
    {
        public InvoiceData m_InvoiceData = null;
        public GlobalData.ePaymentType m_ePaymentType = GlobalData.ePaymentType.ANY_TYPE;
        public string m_sPaymentMethod = null;
        public string m_sAmountReceived = null;
        public string m_sToReturn = null;
        public Form_PrintJournal(InvoiceData xInvoiceData, string PrinterName)
        {
            InitializeComponent();
            m_InvoiceData = xInvoiceData;
            if (m_InvoiceData.IsDocInvoice)
            {
                lng.s_HistoryOfInvoiceAndPrint.Text(this);
            }
            if (m_InvoiceData.IsDocInvoice)
            {
                lng.s_HistoryOfProformaInvoiceAndPrint.Text(this);
            }
            string sED = "";
            if (m_InvoiceData.Electronic_Device_Name_v!=null)
            {
                sED = m_InvoiceData.Electronic_Device_Name_v.v;
            }
            string sOfficeShortName = "";
          
            if (m_InvoiceData.MyOrganisation!=null)
            {
                if (m_InvoiceData.MyOrganisation.Atom_Office_ShortName != null)
                {
                    sOfficeShortName = m_InvoiceData.MyOrganisation.Atom_Office_ShortName;
                }
            }
            string snumber = sOfficeShortName+"-"+sED+"-"+m_InvoiceData.NumberInFinancialYear.ToString() +"/"+ m_InvoiceData.FinancialYear.ToString();
            this.usrc_PrintExistingInvoice1.Init(xInvoiceData, snumber);
        }


        private void Form_Receipt_Preview_Load(object sender, EventArgs e)
        {
        }

        private void usrc_PrintExistingInvoice1_Cancel()
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
