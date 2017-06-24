#region LICENSE 
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
    public partial class Form_PrintDocument : Form
    {
       
        public long Default_ID = -1;

        private usrc_Invoice_Preview m_usrc_Invoice_Preview = null;
        private GlobalData.ePaymentType paymentType;
        private string sPaymentMethod;
        private string sAmountReceived;
        private string sToReturn;
        private DateTime_v issue_time;
        private InvoiceData m_InvoiceData;
        private long durationType;
        private long duration;

        public Form_PrintDocument(InvoiceData xInvoiceData)
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
                lngRPM.s_Print_DocInvoice.Text(this);
            }
            else if (m_InvoiceData.IsDocProformaInvoice)
            {
                this.paymentType = m_InvoiceData.AddOnDPI.m_MethodOfPayment.eType;
                this.sPaymentMethod = m_InvoiceData.AddOnDPI.m_MethodOfPayment.PaymentType;
                this.issue_time = new DateTime_v(m_InvoiceData.AddOnDPI.m_IssueDate.Date);
                this.durationType = m_InvoiceData.AddOnDPI.m_Duration.type;
                this.duration = m_InvoiceData.AddOnDPI.m_Duration.length;
                lngRPM.s_Print_DocProformaInvoice.Text(this);
            }
            btn_SaveTemplate.Visible = false;
            btn_Refresh.Visible = false;
            lngRPM.s_btn_Refresh.Text(btn_Refresh);
            lngRPM.s_btn_SaveHtmlTemplate.Text(btn_SaveTemplate);
            
        }


        public void Init()
        {

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

  
        private void btn_Select_Template_Click(object sender, EventArgs e)
        {

        }


        private void Form_SelectTemplate_Load(object sender, EventArgs e)
        {
            m_usrc_SelectPrintTemplate.SettingsChanged += M_usrc_SelectPrintTemplate_SettingsChanged;
            switch (m_usrc_SelectPrintTemplate.Init(m_InvoiceData))
            {
                case f_doc.eGetPrintDocumentTemplateResult.OK:
                    Create_usrc_Invoice_Preview();
                    m_usrc_Invoice_Preview.Init(m_usrc_SelectPrintTemplate.Doc_v.v, m_usrc_SelectPrintTemplate.SelectedPrinter, m_InvoiceData, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                    this.textEditorControl1.Text = m_usrc_Invoice_Preview.html_doc_template_text;
                    btn_SaveTemplate.Visible = false;
                    btn_Refresh.Visible = false;
                    break;

                case f_doc.eGetPrintDocumentTemplateResult.NO_DOCUMENT_TEMPLATE:
                    btn_SaveTemplate.Visible = false;
                    btn_Refresh.Visible = false;
                    ltext lMsg = lngRPM.s_YouHaveNoDocumentTemplateFor;
                    string sMsg_paper = "";
                    switch (m_usrc_SelectPrintTemplate.f_doc_PageType)
                    {
                        case f_doc.StandardPages.A4:
                            sMsg_paper = lngRPM.s_Paper_A4.s;
                            break;
                        case f_doc.StandardPages.ROLL_58:
                            sMsg_paper = lngRPM.s_Paper_Roll58.s;
                            break;
                        case f_doc.StandardPages.ROLL_80:
                            sMsg_paper = lngRPM.s_Paper_Roll80.s;
                            break;
                        default:
                            sMsg_paper = lngRPM.s_PageType_NotDefined.s;
                            break;

                    }
                    string sMsg = "";
                    switch (m_usrc_SelectPrintTemplate.f_doc_PageOrientation)
                    {
                        case f_doc.PageOreintation.PORTRAIT:
                            sMsg = lngRPM.s_PageOrientation_PORTRAIT.s;
                            break;
                        case f_doc.PageOreintation.LANDSCAPE:
                            sMsg = lngRPM.s_PageOrientation_LANDSCAPE.s;
                            break;
                    }

                    string sDocMsg = "";
                    if (m_InvoiceData.DocInvoice.Equals("DocInvoice"))
                    {
                        sDocMsg = lngRPM.s_DocInvoice.s;
                    }
                    else if (m_InvoiceData.DocInvoice.Equals("DocProformaInvoice"))
                    {
                        sDocMsg = lngRPM.s_DocProformaInvoice.s;
                    }

                    XMessage.Box.Show(this, lMsg, "\r\n" + sMsg_paper + ",\r\n" + sDocMsg + ",\r\n" + sMsg, "!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    Create_usrc_Invoice_Preview();
                    m_usrc_Invoice_Preview.Init(m_InvoiceData);
                    m_usrc_SelectPrintTemplate.f_doc_TemplateName = "";
                    break;

                case f_doc.eGetPrintDocumentTemplateResult.ERROR:
                    this.Close();
                    DialogResult = DialogResult.Abort;
                    break;
            }
        }

        private void M_usrc_SelectPrintTemplate_SettingsChanged()
        {
            Init();
        }

        private void m_usrc_Invoice_Preview_OK()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            this.m_usrc_Invoice_Preview.html_doc_template_text = this.textEditorControl1.Text;
            this.m_usrc_Invoice_Preview.ShowPreview(this.m_usrc_SelectPrintTemplate.SelectedPrinter,this.m_usrc_Invoice_Preview.html_doc_template_text);
        }

        private void textEditorControl1_DocumentChanged(object sender, DigitalRune.Windows.TextEditor.Document.DocumentEventArgs e)
        {
            btn_SaveTemplate.Visible = true;
            btn_Refresh.Visible = true;

        }

        private void btn_SaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemaplate();
        }

        private void SaveTemaplate()
        {
            long Doc_ID = -1;
            switch (f_doc.Exists(m_usrc_SelectPrintTemplate.f_doc_TemplateName,GlobalData.doc_type_definitions.HTMLPrintTemplate_Invoice_doc_type_ID,ref Doc_ID))
            {
                case f_doc.ExistsResult.EXISTS:
                    if (XMessage.Box.Show(this, lngRPM.s_HTML_PrintDocument_Template_DocInvoice_Allready_Exists_SaveYesNo, "?", MessageBoxButtons.YesNo, SystemIcons.Question.Handle, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.m_usrc_Invoice_Preview.html_doc_template_text = this.textEditorControl1.Text;
                        m_usrc_SelectPrintTemplate.Doc_v.v = fs.ConvertToByteArray(this.m_usrc_Invoice_Preview.html_doc_template_text);
                        f_doc.Update(Doc_ID,
                                     m_usrc_SelectPrintTemplate.f_doc_TemplateName,
                                     m_usrc_SelectPrintTemplate.f_doc_TemplateDescription,
                                     m_usrc_SelectPrintTemplate.Doc_v.v,
                                     m_usrc_SelectPrintTemplate.f_doc_DocType_ID_v,
                                     m_usrc_SelectPrintTemplate.f_doc_page_type_ID_v,
                                     m_usrc_SelectPrintTemplate.f_doc_Language_ID_v,
                                     m_usrc_SelectPrintTemplate.f_doc_bCompressed,
                                     m_usrc_SelectPrintTemplate.f_doc_bActive,
                                     m_usrc_SelectPrintTemplate.f_doc_bDefault);

                    }
                    break;
                case f_doc.ExistsResult.NOT_FOUND:
                    if (XMessage.Box.Show(this, lngRPM.s_HTML_PrintDocument_SaveYesNo, "?", MessageBoxButtons.YesNo, SystemIcons.Question.Handle, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        long_v doc_type_ID_v = null;
                        if (m_InvoiceData.IsDocInvoice)
                        {
                            doc_type_ID_v = GlobalData.doc_type_definitions.HTMLPrintTemplate_Invoice_doc_type_ID;
                        }
                        else if (m_InvoiceData.IsDocInvoice)
                        {
                            doc_type_ID_v = GlobalData.doc_type_definitions.HTMLPrintTemplate_Proforma_Invoice_doc_type_ID;
                        }

                        if (doc_type_ID_v!=null)
                        {
                            switch (m_usrc_SelectPrintTemplate.f_doc_PageOrientation)
                            {
                                case f_doc.PageOreintation.PORTRAIT:
                                    break;
                                case f_doc.PageOreintation.LANDSCAPE:
                                    break;
                            }
                            //f_doc.Get(m_usrc_SelectPrintTemplate.TemplateName,)
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaPrint:Form_PrintDocument:SaveTemaplate:doc_type_ID_v==null");
                            return;
                        }



                        //f_doc.Get(m_usrc_SelectPrintTemplate.TemplateName,)
                    }
                    break;

            }
        }
    }
}
