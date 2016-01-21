using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageControl;
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_Storno : Form
    {

        public const string const_Storno = "Storno";
        public const string const_Storno_with_description = "Storno*";
        DataTable dt_journal_invoice_type = new DataTable();
        long m_Invoice_ID = -1;
        public string m_sInvoiceToStorno = null;
        public string m_Reason = null;
        public Form_Storno(long Invoice_ID)
        {
            InitializeComponent();
            m_Invoice_ID = Invoice_ID;
            this.Text = lngRPM.s_Storno.s;
            
        }

        private void Form_Storno_Load(object sender, EventArgs e)
        {
            string sql = @"select EventTime as InvoiceTime,
                                  pi.FinancialYear,
                                  pi.NumberInFinancialYear,
                                  pi.GrossSum 
                                  from JOURNAL_ProformaInvoice jpi 
                                  inner join JOURNAL_ProformaInvoice_Type jpit on jpit.ID = jpi.JOURNAL_ProformaInvoice_Type_id and jpit.Name = 'InvoiceTime'
                                  inner join ProformaInvoice pi on pi.ID=jpi.ProformaInvoice_ID 
                                  where pi.Invoice_ID = " + m_Invoice_ID.ToString();

            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count==1)
                {
                    string InvoiceNumber = Program.GetInvoiceNumber(false, (int)dt.Rows[0]["FinancialYear"], (int)dt.Rows[0]["NumberInFinancialYear"], 0);
                    DateTime InvoiceTime = (DateTime)dt.Rows[0]["InvoiceTime"];
                    decimal GrossSum = (decimal)dt.Rows[0]["GrossSum"];
                    string s_GrossSum = fs.Decimal2String(GrossSum,2);

                    m_sInvoiceToStorno = lngRPM.s_Invoice.s + ":" + InvoiceNumber + " " + lngRPM.s_Invoice.s + " " + lngRPM.s_Time.s + " = " + fs.DateTime2String(InvoiceTime) + "," + lngRPM.s_Price.s + " = " + s_GrossSum;
                    lbl_StornoMessage.Text = m_sInvoiceToStorno+ "\r\n" + lngRPM.s_Storno_Instruction.s;
                    sql = @"select Name,Description from journal_invoice_type jit where jit.Name='" + const_Storno_with_description + "'";
                    lbl_SelectExistingReason.Text = lngRPM.s_SelectObligatoryWriteReasonForStorno.s + ":";
                    lbl_WriteReason.Text = lngRPM.s_ObligatoryWriteReasonForStorno.s + ":";
                    if (DBSync.DBSync.ReadDataTable(ref dt_journal_invoice_type,sql,ref Err))
                    {
                        if (dt_journal_invoice_type.Rows.Count>0)
                        {
                            cmb_StornoReason.DataSource = dt_journal_invoice_type;
                            cmb_StornoReason.DisplayMember = "Description";
                            cmb_StornoReason.ValueMember = "Description";
                        }
                        this.cmb_StornoReason.SelectedValueChanged += new System.EventHandler(this.cmb_StornoReason_SelectedValueChanged);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Form_Storno:Form_Storno_Load:sql=" + sql + "\r\n No Invoice data found for Invoice_ID = " + m_Invoice_ID.ToString());
                    this.Close();
                    DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_Storno:Form_Storno_Load:sql=" + sql + "\r\nErr=" + Err);
                this.Close();
                DialogResult = DialogResult.Abort;
            }
        }

        private void btn_Storno_Click(object sender, EventArgs e)
        {
            if (txt_StornoReason.Text.Length>2)
            {
                m_Reason = txt_StornoReason.Text;
                DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                MessageBox.Show(this, lngRPM.s_WriteReasonForStorno.s, "!",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmb_StornoReason_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cmb_StornoReason_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_StornoReason.SelectedValue is string)
            {
                txt_StornoReason.Text = (string)cmb_StornoReason.SelectedValue;
            }
        }

    }
}
