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

        private GlobalData.ePaymentType paymentType;
        private string sPaymentMethod;
        private string sAmountReceived;
        private string sToReturn;
        private DateTime_v issue_time;
        private InvoiceData m_InvoiceData;
        private long durationType;
        private long duration;
        private Image m_image_for_btn_exit = null;

        public Form_PrintDocument(InvoiceData xInvoiceData,Image image_for_btn_exit)
        {
            InitializeComponent();
            m_image_for_btn_exit = image_for_btn_exit;
            this.m_InvoiceData = xInvoiceData;
            if (m_InvoiceData.IsDocInvoice)
            {
                this.paymentType = m_InvoiceData.AddOnDI.m_MethodOfPayment_DI.eType;
                this.sPaymentMethod = m_InvoiceData.AddOnDI.m_MethodOfPayment_DI.PaymentType;
                this.sAmountReceived = m_InvoiceData.AddOnDI.sCash_AmountReceived;
                this.sToReturn = m_InvoiceData.AddOnDI.sCash_ToReturn;
                this.issue_time = new DateTime_v(m_InvoiceData.AddOnDI.m_IssueDate.Date);
                lng.s_Print_DocInvoice.Text(this);
            }
            else if (m_InvoiceData.IsDocProformaInvoice)
            {
                this.paymentType = m_InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.eType;
                this.sPaymentMethod = m_InvoiceData.AddOnDPI.m_MethodOfPayment_DPI.PaymentType;
                this.issue_time = new DateTime_v(m_InvoiceData.AddOnDPI.m_IssueDate.Date);
                this.durationType = m_InvoiceData.AddOnDPI.m_Duration.type;
                this.duration = m_InvoiceData.AddOnDPI.m_Duration.length;
                lng.s_Print_DocProformaInvoice.Text(this);
            }
            btn_SaveTemplate.Visible = false;
            btn_Refresh.Visible = false;
            lng.s_btn_Refresh.Text(btn_Refresh);
            lng.s_btn_SaveHtmlTemplate.Text(btn_SaveTemplate);
            lng.s_chk_Edit_PrintTemplate.Text(chk_EditTemplate);
            splitContainer1.Panel2Collapsed = true;
            chk_EditTemplate.Checked = false;
            chk_EditTemplate.CheckedChanged += Chk_EditTemplate_CheckedChanged;
            if (image_for_btn_exit!=null)
            {
                btn_Exit.Image = image_for_btn_exit;
                btn_Exit.Text = "";
            }
            else
            {
                lng.ss_Exit.Text(btn_Exit);
            }

        }


        private void Form_SelectTemplate_Load(object sender, EventArgs e)
        {
            Init();
        }


        private void Init()
        {
            usrc_SelectPrintTemplate_Init();
        }

        private void Chk_EditTemplate_CheckedChanged(object sender, EventArgs e)
        {
            m_usrc_Invoice_Preview.btn_Tokens.Visible = false;
            if (chk_EditTemplate.Checked)
            {
                string AdministratorLockedPassword = null;
                if (fs.GetAdministratorPassword(ref AdministratorLockedPassword))
                {
                    if (Password.Password.Check(this,null, AdministratorLockedPassword))
                    {
                        splitContainer1.Panel2Collapsed = false;
                        m_usrc_Invoice_Preview.btn_Tokens.Visible = true;
                        btn_SaveTemplate.Visible = true;
                        btn_Refresh.Visible = true;

                    }
                    else
                    {
                        chk_EditTemplate.CheckedChanged -= Chk_EditTemplate_CheckedChanged;
                        chk_EditTemplate.Checked = false;
                        splitContainer1.Panel2Collapsed = true;
                        chk_EditTemplate.CheckedChanged += Chk_EditTemplate_CheckedChanged;
                        btn_SaveTemplate.Visible = false;
                        btn_Refresh.Visible = false;
                    }
                }
                else
                {
                    chk_EditTemplate.CheckedChanged -= Chk_EditTemplate_CheckedChanged;
                    chk_EditTemplate.Checked = false;
                    splitContainer1.Panel2Collapsed = true;
                    chk_EditTemplate.CheckedChanged += Chk_EditTemplate_CheckedChanged;
                    btn_SaveTemplate.Visible = false;
                    btn_Refresh.Visible = false;

                }
            }
            else
            {
                splitContainer1.Panel2Collapsed = true;
                btn_SaveTemplate.Visible = false;
                btn_Refresh.Visible = false;
            }
        }


        private void btn_Select_Template_Click(object sender, EventArgs e)
        {

        }




        private void usrc_SelectPrintTemplate_Init()
        {
            m_usrc_SelectPrintTemplate.SettingsChanged -= M_usrc_SelectPrintTemplate_SettingsChanged;
            switch (m_usrc_SelectPrintTemplate.Init(m_InvoiceData))
            {
                case f_doc.eGetPrintDocumentTemplateResult.OK:
                    m_usrc_Invoice_Preview.Init(m_usrc_SelectPrintTemplate.Doc_v.v, m_usrc_SelectPrintTemplate.SelectedPrinter, m_InvoiceData, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
                    this.textEditorControl1.Text = m_usrc_Invoice_Preview.html_doc_template_text;
                    btn_SaveTemplate.Visible = false;
                    btn_Refresh.Visible = false;
                    break;
                case f_doc.eGetPrintDocumentTemplateResult.PRINTER_NOT_SELECTED:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;

                case f_doc.eGetPrintDocumentTemplateResult.NO_DOCUMENT_TEMPLATE:
                    btn_SaveTemplate.Visible = false;
                    btn_Refresh.Visible = false;
                    ltext lMsg = lng.s_YouHaveNoDocumentTemplateFor;
                    string sMsg_paper = "";
                    //switch (m_usrc_SelectPrintTemplate.f_doc_PageType)
                    //{
                    //    case f_doc.StandardPages.A4:
                    //        sMsg_paper = lng.s_Paper_A4.s;
                    //        break;
                    //    case f_doc.StandardPages.ROLL_58:
                    //        sMsg_paper = lng.s_Paper_Roll58.s;
                    //        break;
                    //    case f_doc.StandardPages.ROLL_80:
                    //        sMsg_paper = lng.s_Paper_Roll80.s;
                    //        break;
                    //    default:
                    //        sMsg_paper = lng.s_PageType_NotDefined.s;
                    //        break;

                    //}
                    string sMsg = "";
                    //switch (m_usrc_SelectPrintTemplate.f_doc_PageOrientation)
                    //{
                    //    case f_doc.PageOreintation.PORTRAIT:
                    //        sMsg = lng.s_PageOrientation_PORTRAIT.s;
                    //        break;
                    //    case f_doc.PageOreintation.LANDSCAPE:
                    //        sMsg = lng.s_PageOrientation_LANDSCAPE.s;
                    //        break;
                    //}

                    string sDocMsg = "";
                    if (m_InvoiceData.DocInvoice.Equals("DocInvoice"))
                    {
                        sDocMsg = lng.s_DocInvoice.s;
                    }
                    else if (m_InvoiceData.DocInvoice.Equals("DocProformaInvoice"))
                    {
                        sDocMsg = lng.s_DocProformaInvoice.s;
                    }

                    XMessage.Box.Show(this, lMsg, "\r\n" + sMsg_paper + ",\r\n" + sDocMsg + ",\r\n" + sMsg, "!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    m_usrc_Invoice_Preview.Init(m_InvoiceData);
                    m_usrc_SelectPrintTemplate.doc_TemplateName = "";
                    break;

                case f_doc.eGetPrintDocumentTemplateResult.ERROR:
                    this.Close();
                    DialogResult = DialogResult.Abort;
                    break;
            }
            m_usrc_SelectPrintTemplate.SettingsChanged += M_usrc_SelectPrintTemplate_SettingsChanged;
        }

        private void M_usrc_SelectPrintTemplate_SettingsChanged()
        {
            m_usrc_Invoice_Preview.Init(m_usrc_SelectPrintTemplate.Doc_v.v, m_usrc_SelectPrintTemplate.SelectedPrinter, m_InvoiceData, paymentType, sPaymentMethod, sAmountReceived, sToReturn, issue_time);
            this.textEditorControl1.Text = m_usrc_Invoice_Preview.html_doc_template_text;
        }

        private void m_usrc_Invoice_Preview_Exit()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Cursor curs = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            this.m_usrc_Invoice_Preview.html_doc_template_text = this.textEditorControl1.Text;
            this.m_usrc_Invoice_Preview.ShowPreview(this.m_usrc_SelectPrintTemplate.SelectedPrinter,this.m_usrc_Invoice_Preview.html_doc_template_text);
            this.Cursor = curs;
        }




        private void textEditorControl1_DocumentChanged(object sender, DigitalRune.Windows.TextEditor.Document.DocumentEventArgs e)
        {

        }

        private void btn_SaveTemplate_Click(object sender, EventArgs e)
        {
            Cursor curs = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            SaveTemaplate();
            this.Cursor = curs;
        }

        private void SaveTemaplate()
        {
            long Doc_ID = -1;
            string_v desc_v = m_usrc_SelectPrintTemplate.doc_TemplateDescription;
            string template_description = "";
            if (desc_v!=null)
            {
                template_description = desc_v.v;
            }
            string s_Msg = "\r\n\r\n" + lng.s_doc_TemplateName.s + ":" + m_usrc_SelectPrintTemplate.doc_TemplateName + "\r\n" +
                                  lng.s_doc_TemplateDescription.s + ":" + template_description + "\r\n" +
                                  lng.s_doc_Type + ":" + Get_doc_Type_Name(this.m_usrc_SelectPrintTemplate.f_doc_DocType_ID_v) + "\r\n" +
                                  lng.s_doc_Page_Type + ":" + Get_doc_Page_Type(this.m_usrc_SelectPrintTemplate.Doc_Page_Type_ID_v) + "\r\n" +
                                  lng.s_doc_TemplateLanguage.s + ":" + Get_doc_TemplateLanguage(this.m_usrc_SelectPrintTemplate.Language_ID_v);

            switch (f_doc.Exists(m_usrc_SelectPrintTemplate.doc_TemplateName, GlobalData.doc_type_definitions.HTMLPrintTemplate_Invoice_doc_type_ID, ref Doc_ID))
            {
                case f_doc.ExistsResult.EXISTS:

                   

                    if (XMessage.Box.Show(this, lng.s_HTML_PrintDocument_Template_DocInvoice_Allready_Exists_SaveYesNo,s_Msg, "?", MessageBoxButtons.YesNo, SystemIcons.Question.Handle, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.m_usrc_Invoice_Preview.html_doc_template_text = this.textEditorControl1.Text;
                        m_usrc_SelectPrintTemplate.Doc_v.v = fs.ConvertToByteArray(this.m_usrc_Invoice_Preview.html_doc_template_text);
                        f_doc.Update(Doc_ID,
                                     m_usrc_SelectPrintTemplate.doc_TemplateName,
                                     m_usrc_SelectPrintTemplate.doc_TemplateDescription,
                                     m_usrc_SelectPrintTemplate.Doc_v.v,
                                     m_usrc_SelectPrintTemplate.f_doc_DocType_ID_v,
                                     this.m_usrc_SelectPrintTemplate.Doc_Page_Type_ID_v,
                                     this.m_usrc_SelectPrintTemplate.Language_ID_v,
                                     m_usrc_SelectPrintTemplate.f_doc_bCompressed,
                                     m_usrc_SelectPrintTemplate.f_doc_bActive,
                                     m_usrc_SelectPrintTemplate.f_doc_bDefault);

                    }
                    break;
                case f_doc.ExistsResult.NOT_FOUND:
                    if (XMessage.Box.Show(this, lng.s_HTML_PrintDocument_SaveYesNo, s_Msg,"?", MessageBoxButtons.YesNo, SystemIcons.Question.Handle, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.m_usrc_Invoice_Preview.html_doc_template_text = this.textEditorControl1.Text;
                        m_usrc_SelectPrintTemplate.Doc_v.v = fs.ConvertToByteArray(this.m_usrc_Invoice_Preview.html_doc_template_text);
                        if (f_doc.Get(m_usrc_SelectPrintTemplate.doc_TemplateName,
                                        m_usrc_SelectPrintTemplate.doc_TemplateDescription,
                                        m_usrc_SelectPrintTemplate.Doc_v.v,
                                        m_usrc_SelectPrintTemplate.f_doc_DocType_ID_v,
                                        this.m_usrc_SelectPrintTemplate.Doc_Page_Type_ID_v,
                                        this.m_usrc_SelectPrintTemplate.Language_ID_v,
                                        m_usrc_SelectPrintTemplate.f_doc_bCompressed,
                                        m_usrc_SelectPrintTemplate.f_doc_bActive,
                                        m_usrc_SelectPrintTemplate.f_doc_bDefault,
                                        true,
                                        ref Doc_ID))
                        {
                            switch (m_usrc_SelectPrintTemplate.Init())
                            {
                                case f_doc.eGetPrintDocumentTemplateResult.ERROR:
                                case f_doc.eGetPrintDocumentTemplateResult.PRINTER_NOT_SELECTED:
                                    this.Close();
                                    DialogResult = DialogResult.Cancel;
                                    return;
                            }
                        }
                    }
                    break;
            
            }
        }

        private string Get_doc_TemplateLanguage(long_v language_ID_v)
        {
            string template_language_name = "?";
            string_v Name_v = null;
            string_v Description_v = null;
            int_v Index_v = null;
            if (language_ID_v != null)
            {
                if (f_Language.Get(language_ID_v.v,ref Name_v, ref Description_v,ref Index_v))
                {
                    template_language_name = Name_v.v;
                }
            }
            return template_language_name;
        }

        private string Get_doc_Page_Type(long_v doc_Page_Type_ID_v)
        {
            string_v Name_v = null;
            string doc_page_type_name = "?";
            string_v Description_v = null;
            decimal_v Width_v = null;
            decimal_v Height_v = null;
            if (doc_Page_Type_ID_v != null)
            {
                if (f_doc_page_type.Get(doc_Page_Type_ID_v.v,ref Name_v,ref Description_v,ref Width_v,ref Height_v))
                {
                    if (Name_v!=null)
                    {
                        doc_page_type_name = Name_v.v;
                    }
                }
            }
            return doc_page_type_name;
        }

        private string Get_doc_Type_Name(long_v f_doc_DocType_ID_v)
        {
            string_v Name_v = null;
            string doc_type_name = "?";
            string_v Description_v = null;
            if (f_doc_DocType_ID_v != null)
            {
                if (f_doc_type.Get(f_doc_DocType_ID_v.v,ref Name_v,ref Description_v))
                {
                    doc_type_name = Name_v.v;
                }
            }
            return doc_type_name;
        }

        private void Form_PrintDocument_Shown(object sender, EventArgs e)
        {
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
