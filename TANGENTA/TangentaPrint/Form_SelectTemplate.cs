﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using TangentaTableClass;
using DBTypes;
using TangentaDB;
using LanguageControl;
using CodeTables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NavigationButtons;
using DBConnectionControl40;

namespace TangentaPrint
{
    public partial class Form_SelectTemplate : Form
    {
       
        public bool bCompressedDocumentTemplate = false;
        public long Default_ID = -1;
        public string Default_Tamplate = null;
        public byte[] Doc = null;

        private usrc_Invoice_Preview m_usrc_Invoice_Preview = null;
        private GlobalData.ePaymentType paymentType;
        private string sPaymentMethod;
        private string sAmountReceived;
        private string sToReturn;
        private DateTime_v issue_time;
        private InvoiceData m_InvoiceData;
        private long durationType;
        private long duration;

        public Form_SelectTemplate(InvoiceData xInvoiceData)
        {
            InitializeComponent();

            this.m_InvoiceData = xInvoiceData;
            if (m_InvoiceData.IsDocInvoice)
            {
                this.paymentType = m_InvoiceData.AddOnDI.m_MethodOfPayment.eType;
                this.sPaymentMethod = m_InvoiceData.AddOnDI.m_MethodOfPayment.PaymentType;
                this.sAmountReceived = m_InvoiceData.AddOnDI.sCash_AmountReceived;
                this.sToReturn = m_InvoiceData.AddOnDI.sCash_ToReturn;
                this.issue_time = new DateTime_v(m_InvoiceData.AddOnDI.m_IssueDate.Date);
            }
            else if (m_InvoiceData.IsDocProformaInvoice)
            {
                this.paymentType = m_InvoiceData.AddOnDPI.m_MethodOfPayment.eType;
                this.sPaymentMethod = m_InvoiceData.AddOnDPI.m_MethodOfPayment.PaymentType;
                this.issue_time = new DateTime_v(m_InvoiceData.AddOnDPI.m_IssueDate.Date);
                this.durationType = m_InvoiceData.AddOnDPI.m_Duration.type;
                this.duration = m_InvoiceData.AddOnDPI.m_Duration.length;
            }
            btn_SaveTemplate.Visible = false;
            btn_Refresh.Visible = false;
            lngRPM.s_btn_Refresh.Text(btn_Refresh);
            lngRPM.s_btn_SaveHtmlTemplate.Text(btn_SaveTemplate);
        }


        public void Init()
        {
            switch (f_doc.GetDefaultTemplate(ref Default_ID,
                                             ref Default_Tamplate,
                                             ref Doc,
                                             ref bCompressedDocumentTemplate,
                                             m_usrc_SelectPrintTemplate.SelectedLangugage,
                                             m_InvoiceData.DocInvoice,
                                             m_usrc_SelectPrintTemplate.PageType,
                                             m_usrc_SelectPrintTemplate.PageOrientation
                    ))
            {
                case f_doc.eGetPrintDocumentTemplateResult.OK:
                    Create_usrc_Invoice_Preview();
                    m_usrc_Invoice_Preview.Init(Doc, m_InvoiceData, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                    this.textEditorControl1.Text = m_usrc_Invoice_Preview.html_doc_template_text;
                    m_usrc_SelectPrintTemplate.TemplateName = Default_Tamplate;
                    break;
                
                case f_doc.eGetPrintDocumentTemplateResult.NO_DOCUMENT_TEMPLATE:
                    XMessage.Box.Show(this, lngRPM.s_YouHaveNoDocumentTemplateToPrintOnA4, "!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    Create_usrc_Invoice_Preview();
                    m_usrc_Invoice_Preview.Init(m_InvoiceData);
                    break;

            }

        }


        // 
        // m_usrc_Invoice_Preview
        // 
        public void Create_usrc_Invoice_Preview()
        {
            if (m_usrc_Invoice_Preview!=null)
            {
                this.m_usrc_Invoice_Preview.OK -= new usrc_Invoice_Preview.delegate_OK(this.m_usrc_Invoice_Preview_OK);
                this.Controls.Remove(m_usrc_Invoice_Preview);
                m_usrc_Invoice_Preview.Dispose();
                m_usrc_Invoice_Preview = null;
            }
            m_usrc_Invoice_Preview = new usrc_Invoice_Preview();
            this.m_usrc_Invoice_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_Invoice_Preview.AutoScroll = true;
            this.m_usrc_Invoice_Preview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_usrc_Invoice_Preview.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.m_usrc_Invoice_Preview.html_doc_text = "Document Template not set";
            this.m_usrc_Invoice_Preview.Location = new System.Drawing.Point(1, 42);
            this.m_usrc_Invoice_Preview.Name = "m_usrc_Invoice_Preview";
            this.m_usrc_Invoice_Preview.Size = new System.Drawing.Size(923, 560);
            this.m_usrc_Invoice_Preview.TabIndex = 0;
            this.m_usrc_Invoice_Preview.Dock = DockStyle.Fill;
            this.m_usrc_Invoice_Preview.OK += new usrc_Invoice_Preview.delegate_OK(this.m_usrc_Invoice_Preview_OK);
            this.splitContainer1.Panel1.Controls.Add(m_usrc_Invoice_Preview);

        }
        private void btn_EditTemplates_Click(object sender, EventArgs e)
        {
            SQLTable tbl_doc = new SQLTable(DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(doc)));
            Form_Templates edt_doc_dlg = new Form_Templates(DBSync.DBSync.DB_for_Tangenta.m_DBTables,
                                                            tbl_doc,
                                                            "doc_$$Name");
            if (edt_doc_dlg.ShowDialog() == DialogResult.OK)
            {
                long id = edt_doc_dlg.ID_v.v;
                string doc_name = null;
                f_doc.SetDefault(id);
                if (f_doc.GetTemplate(id,ref doc_name, ref Doc, ref bCompressedDocumentTemplate))
                {
                    this.m_usrc_SelectPrintTemplate.TemplateName = doc_name;
                }
            }
        }

  
        private void btn_Select_Template_Click(object sender, EventArgs e)
        {

        }


        private void Form_SelectTemplate_Load(object sender, EventArgs e)
        {
            if (m_usrc_SelectPrintTemplate.Init(m_InvoiceData))
            {
                Init();
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void m_usrc_Invoice_Preview_OK()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.m_usrc_Invoice_Preview.html_doc_template_text = this.textEditorControl1.Text;
            this.m_usrc_Invoice_Preview.ShowPreview(this.m_usrc_Invoice_Preview.html_doc_template_text);
        }

        private void textEditorControl1_DocumentChanged(object sender, DigitalRune.Windows.TextEditor.Document.DocumentEventArgs e)
        {
            btn_SaveTemplate.Visible = true;
            btn_Refresh.Visible = true;

        }

        private void btn_SaveTemplate_Click(object sender, EventArgs e)
        {
        }
    }
}
