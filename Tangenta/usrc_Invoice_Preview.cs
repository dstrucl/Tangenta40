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

namespace Tangenta
{
    public partial class usrc_Invoice_Preview : UserControl
    {
        private byte[] m_Doc = null;
        private usrc_Print m_usrc_Print;
        private usrc_Payment.ePaymentType m_paymentType;
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
                        char[] chars = Encoding.UTF8.GetChars(m_Doc);
                        string s = new string(chars);
                        return s;
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

        private usrc_InvoiceMan m_usrc_InvoiceMan = null;


        public usrc_Invoice_Preview()
        {
            InitializeComponent();

            //string html_doc = Properties.Resources.html_doc;

        }
        public bool Init(byte[] xdoc, usrc_Print xusrc_Print, usrc_Payment.ePaymentType xpaymentType, string sPaymentMethod, string sAmountReceived, string sToReturn, DateTime_v issue_time)
        {
            m_Doc = xdoc;
            m_usrc_Print = xusrc_Print;
            m_paymentType = xpaymentType;
            m_sPaymentMethod = sPaymentMethod;
            m_sAmountReceived = sAmountReceived;
            m_sToReturn = sToReturn;
            m_issue_time = issue_time;
            string s = CreateInvoiceFromTemplate(html_doc_text);

            this.m_webBrowser.DocumentText = s;
            this.m_webBrowser.Refresh();
            return true;
        }

        private string CreateInvoiceFromTemplate(string html_doc_text)
        {
            
            InvoiceCreateFromTemplate invt = new InvoiceCreateFromTemplate();
            return invt.Create(ref html_doc_text,
                               m_usrc_Print,
                               m_paymentType,
                               m_sPaymentMethod,
                               m_sAmountReceived,
                               m_sToReturn,
                               m_issue_time);
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
    }
}
