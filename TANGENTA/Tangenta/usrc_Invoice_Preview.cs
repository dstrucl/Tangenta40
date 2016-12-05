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
using System.Windows.Forms;
using LanguageControl;
using System.Runtime.InteropServices;
using DBConnectionControl40;
using DBTypes;
using TangentaDB;

namespace Tangenta
{
    public partial class usrc_Invoice_Preview : UserControl
    {
        public delegate void delegate_OK();
        public event delegate_OK OK;

        public InvoiceData m_InvoiceData = null;
        private byte[] m_Doc = null;
        private usrc_PrinterSettings m_usrc_Print;
        private GlobalData.ePaymentType m_paymentType;
        private string m_sPaymentMethod;
        private string m_sAmountReceived;
        private string m_sToReturn;
        private DateTime_v m_issue_time;

        public string html_doc_text
        {
            get
            {
                if (m_Doc != null)
                {
                    try
                    {
                        //char[] chars = Encoding.UTF8.GetChars(m_Doc);
                        //string s = new string(chars);
                        char[] chars2 = Encoding.Unicode.GetChars(m_Doc);
                        string s2 = new string(chars2);
                        //char[] charsASCII = Encoding.ASCII.GetChars(m_Doc);
                        //string scharsASCII = new string(charsASCII);
                        //char[] charsBigEndianUnicode = Encoding.BigEndianUnicode.GetChars(m_Doc);
                        //string scharsBigEndianUnicode = new string(charsBigEndianUnicode);
                        return s2;
                    }
                    catch
                    {
                        return "Error can not decode template!";
                    }
                }
                else
                {
                    return "Document Template not set";
                }
            }

            set
            {
                try
                {
                    m_Doc = System.Text.Encoding.UTF8.GetBytes(value);
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:usrc_Invoice_Preview:propertiy:html_doc_text:Exception=" + ex.Message);
                }
            }
        }



        public usrc_Invoice_Preview()
        {
            InitializeComponent();
            lngRPM.s_btn_Tokens.Text(btn_Tokens);
            //string html_doc = Properties.Resources.html_doc;

        }
        public bool Init(byte[] xdoc, InvoiceData xInvoiceData, GlobalData.ePaymentType xpaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            m_InvoiceData = xInvoiceData;
            m_Doc = xdoc;
            m_paymentType = xpaymentType;
            m_sPaymentMethod = sPaymentMethod;
            m_sAmountReceived = sAmountReceived;
            m_sToReturn = sToReturn;
            m_issue_time = issue_time;
            string shtml_doc_text = html_doc_text;
            string s = m_InvoiceData.CreateHTML_Invoice(ref shtml_doc_text);
            this.m_webBrowser.DocumentText = s;
            this.m_webBrowser.Refresh();
            this.btn_Print.Enabled = true;
            return true;
        }

        public bool Init(InvoiceData xInvoiceData)
        {
            m_InvoiceData = xInvoiceData;
            this.m_webBrowser.DocumentText = "HTML Predloga ni določena, brez nje pa ne morete tiskati računa.";
            this.m_webBrowser.Refresh();
            this.btn_Print.Enabled = false;
            return true;
        }


    private void btn_Print_Click(object sender, EventArgs e)
        {
            m_webBrowser.ShowPrintDialog();
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dres = sfd.ShowDialog();
            if (dres == DialogResult.OK)
            {
                string sFileName = sfd.FileName;
                System.IO.File.WriteAllText(sFileName, this.m_webBrowser.DocumentText, Encoding.UTF8);
            }
        }

        private void btn_Tokens_Click(object sender, EventArgs e)
        {
            Form_TemplateTokens frm_tokens = new Form_TemplateTokens(m_InvoiceData);
            frm_tokens.ShowDialog();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (OK != null)
            {
                OK();
            }
        }
    }
}
