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
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnectionControl40;
using LanguageControl;
using TangentaDB;

namespace TangentaCore
{
    public partial class Form_Storno : Form
    {

        public const string const_Storno = "Storno";
        public const string const_Storno_with_description = "Storno*";
        private DataTable dt_journal_invoice_type = new DataTable();
        private ID m_Invoice_ID = null;
        public string m_sInvoiceToStorno = null;
        public string m_Reason = null;

        public string m_InvoiceTime = ""; 


        public Form_Storno(ID Invoice_ID)
        {
            InitializeComponent();
            m_Invoice_ID = Invoice_ID;
            this.Text = lng.s_Storno.s;
            
        }

        private void Form_Storno_Load(object sender, EventArgs e)
        {
            string sql = @"select EventTime as InvoiceTime,
                                  pi.FinancialYear,
                                  pi.NumberInFinancialYear,
                                  pi.GrossSum 
                                  from JOURNAL_DocInvoice jpi 
                                  inner join JOURNAL_DocInvoice_Type jpit on jpit.ID = jpi.JOURNAL_DocInvoice_Type_id and jpit.Name = 'InvoiceTime'
                                  inner join DocInvoice pi on pi.ID=jpi.DocInvoice_ID 
                                  where pi.ID = " + m_Invoice_ID.ToString();

            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count==1)
                {
                    string InvoiceNumber = DocumentMan.GetInvoiceNumber(false, (int)dt.Rows[0]["FinancialYear"], (int)dt.Rows[0]["NumberInFinancialYear"], 0);
                    DateTime InvoiceTime = (DateTime)dt.Rows[0]["InvoiceTime"];
                    decimal GrossSum = (decimal)dt.Rows[0]["GrossSum"];
                    string s_GrossSum = fs.Decimal2String(GrossSum,2);

                   
                    m_InvoiceTime = fs.GetString(InvoiceTime.Year , 4) + "-"  //0000 - 00 - 00T00: 00:00
                                                    + fs.GetString(InvoiceTime.Month, 2) + "-"
                                                    + fs.GetString(InvoiceTime.Day, 2) + "T"
                                                    + fs.GetString(InvoiceTime.Hour, 2) + ":"
                                                    + fs.GetString(InvoiceTime.Minute , 2) + ":"
                                                    + fs.GetString(InvoiceTime.Second , 2);

                    m_sInvoiceToStorno = lng.s_Invoice.s + ":" + InvoiceNumber + " " + lng.s_Invoice.s + " " + lng.s_Time.s + " = " + fs.DateTime2String(InvoiceTime) + "," + lng.s_Price.s + " = " + s_GrossSum;
                    lbl_StornoMessage.Text = m_sInvoiceToStorno+ "\r\n" + lng.s_Storno_Instruction.s;


                    sql = @"select Name from StornoName";



                    lbl_SelectExistingReason.Text = lng.s_SelectObligatoryWriteReasonForStorno.s + ":";
                    lbl_WriteReason.Text = lng.s_ObligatoryWriteReasonForStorno.s + ":";
                    if (DBSync.DBSync.ReadDataTable(ref dt_journal_invoice_type,sql,ref Err))
                    {
                        if (dt_journal_invoice_type.Rows.Count>0)
                        {
                            cmb_StornoReason.DataSource = dt_journal_invoice_type;
                            cmb_StornoReason.DisplayMember = "Name";
                            cmb_StornoReason.ValueMember = "Name";
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
                MessageBox.Show(this, lng.s_WriteReasonForStorno.s, "!",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
