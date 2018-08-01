using DBTypes;
using TangentaDB;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FiscalVerificationOfInvoices_SLO
{
    public partial class Form_InvoiceNotConfirmed_Send : Form
    {
        private FVI_SLO m_FVI_SLO = null;
        List<InvoiceData> m_InvoiceData_List = null;
        private DataTable dt = new DataTable();

        public Form_InvoiceNotConfirmed_Send(FVI_SLO xFVI_SLO, List<InvoiceData> xInvoiceData_List)
        {
            InitializeComponent();
            m_FVI_SLO = xFVI_SLO;
            m_InvoiceData_List = xInvoiceData_List;
            lng.s_Invoice_UnsentMsg.Text(this.lbl_Invoice_UnsentMsg);
            lng.s_Invoice_UnsentMsg.Text(this);
            Init();
        }

        private void Init()
        {
            DataColumn dcol_FinancialYear = new DataColumn("FinancialYear", typeof(int));
            DataColumn dcol_InvoiceNumber = new DataColumn("InvoiceNumber", typeof(string));
            DataColumn dcol_IssueDate_v = new DataColumn("IssueDate_v", typeof(DateTime));
            DataColumn dcol_GrossSum = new DataColumn("GrossSum", typeof(decimal));
            DataColumn dcol_TaxSum = new DataColumn("TaxSum", typeof(decimal));
            DataColumn dcol_NetSum = new DataColumn("NetSum", typeof(decimal));
            DataColumn dcol_BarCodeValue = new DataColumn("BarCodeValue", typeof(string));
            DataColumn dcol_IssuerFirstName = new DataColumn("IssuerFirstName", typeof(string));
            DataColumn dcol_IssuerLastName = new DataColumn("IssuerLastName", typeof(string));

            dgvx_Invoice_Unsent.DataSource = null;
            dgvx_Invoice_Unsent.Columns.Clear();
            dt.Clear();
            dt.Columns.Clear();
            dt.Columns.Add(dcol_FinancialYear);
            dt.Columns.Add(dcol_InvoiceNumber);
            dt.Columns.Add(dcol_BarCodeValue);
            dt.Columns.Add(dcol_IssueDate_v);
            dt.Columns.Add(dcol_GrossSum);
            dt.Columns.Add(dcol_TaxSum);
            dt.Columns.Add(dcol_NetSum);
            dt.Columns.Add(dcol_IssuerFirstName);
            dt.Columns.Add(dcol_IssuerLastName);
            int i = 0;
            int iCount = m_InvoiceData_List.Count;

            for (i = 0; i < iCount; i++)
            {
                InvoiceData xinvd = m_InvoiceData_List[i];
                DataRow dr = dt.NewRow();
                dr["FinancialYear"] = xinvd.FinancialYear;
                dr["InvoiceNumber"] = xinvd.NumberInFinancialYear;
                dr["IssueDate_v"] = xinvd.IssueDate_v.v;
                dr["GrossSum"] = xinvd.GrossSum;
                dr["TaxSum"] = xinvd.taxsum;
                dr["NetSum"] = xinvd.NetSum;
                dr["IssuerFirstName"] = xinvd.Invoice_Author.FirstName;
                dr["IssuerLastName"] = xinvd.Invoice_Author.LastName;
                dt.Rows.Add(dr);
            }
            dgvx_Invoice_Unsent.DataSource = dt;
            dgvx_Invoice_Unsent.Columns["FinancialYear"].HeaderText = lng.s_FinancialYear.s;
            dgvx_Invoice_Unsent.Columns["InvoiceNumber"].HeaderText = lng.s_InvoiceNumber.s;
            dgvx_Invoice_Unsent.Columns["IssueDate_v"].HeaderText = lng.s_IssueDate.s;
            dgvx_Invoice_Unsent.Columns["GrossSum"].HeaderText = lng.s_GrossSum.s;
            dgvx_Invoice_Unsent.Columns["TaxSum"].HeaderText = lng.s_TaxSum.s;
            dgvx_Invoice_Unsent.Columns["NetSum"].HeaderText = lng.s_NetSum.s;
            dgvx_Invoice_Unsent.Columns["IssuerFirstName"].HeaderText = lng.s_Issuer_FirstName.s;
            dgvx_Invoice_Unsent.Columns["IssuerLastName"].HeaderText = lng.s_Issuer_LastName.s;
            DataGridViewDisableButtonColumn dgvbcol = new DataGridViewDisableButtonColumn();
            dgvbcol.Name = "Send";
            dgvbcol.HeaderText = lng.s_SendtoDurs.s;
            dgvbcol.Text = lng.s_SendtoDurs.s;
            dgvbcol.ValueType = typeof(string);
            dgvbcol.UseColumnTextForButtonValue = true;
            dgvx_Invoice_Unsent.Columns.Insert(0, dgvbcol);
            dgvx_Invoice_Unsent.CellContentClick += Dgvx_Invoice_Unsent_CellContentClick;
            dgvx_Invoice_Unsent.CellValueChanged += Dgvx_Invoice_Unsent_CellValueChanged;
            dgvx_Invoice_Unsent.CurrentCellDirtyStateChanged += Dgvx_Invoice_Unsent_CurrentCellDirtyStateChanged;

        }
        private void Set_FURS_InvoiceNotConfirmed_error(ref string fURS_SalesBookInvoice_error, InvoiceData xinvd, string serr)
        {
            if (fURS_SalesBookInvoice_error == null)
            {
                fURS_SalesBookInvoice_error = "ERROR:FiscalVerificationOfInvoices_SLO:Form_SalesBookInvoice_Send:";
            }
            fURS_SalesBookInvoice_error += "\r\n FiscalYear:"+ xinvd.FinancialYear.ToString()+",Number in financial year:" + xinvd.NumberInFinancialYear.ToString()+" Error:"+ serr;
        }

        private void Dgvx_Invoice_Unsent_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvx_Invoice_Unsent.IsCurrentCellDirty)
            {
                dgvx_Invoice_Unsent.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Dgvx_Invoice_Unsent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvx_Invoice_Unsent.Columns[e.ColumnIndex].Name == "Send")
            {
                DataGridViewDisableButtonCell buttonCell =
                    (DataGridViewDisableButtonCell)dgvx_Invoice_Unsent.
                    Rows[e.RowIndex].Cells["Send"];

                DataGridViewCheckBoxCell checkCell =
                    (DataGridViewCheckBoxCell)dgvx_Invoice_Unsent.
                    Rows[e.RowIndex].Cells["Send"];
                buttonCell.Enabled = !(Boolean)checkCell.Value;

                dgvx_Invoice_Unsent.Invalidate();
            }
        }

        private void Dgvx_Invoice_Unsent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewDisableButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewDisableButtonCell buttonCell =
                (DataGridViewDisableButtonCell)dgvx_Invoice_Unsent.Rows[e.RowIndex].Cells["Send"];
                if (buttonCell.Enabled)
                {
                 
                    InvoiceData xInvData = m_InvoiceData_List[e.RowIndex];
                    string furs_XML = DocInvoice_AddOn.FURS.Create_furs_InvoiceXML(false,
                                     Properties.Resources.FVI_SLO_Invoice,
                                     m_FVI_SLO.FursD_MyOrgTaxID,
                                     m_FVI_SLO.FursD_BussinesPremiseID,
                                     m_FVI_SLO.FursD_ElectronicDeviceID,
                                     m_FVI_SLO.FursD_InvoiceAuthorTaxID,
                                     "", "",
                                     xInvData.IssueDate_v,
                                     xInvData.NumberInFinancialYear,
                                     xInvData.GrossSum,
                                     xInvData.taxSum,
                                     xInvData.Invoice_Author //ToDo : Get real Invoice Autor here!
                                     );

                    Image img_QR = null;
                    string furs_UniqeMsgID = null;
                    string furs_UniqeInvID = null;
                    string furs_BarCodeValue = null;

                    FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post eres = m_FVI_SLO.Send_SingleInvoice(false, furs_XML, this.Parent, ref furs_UniqeMsgID, ref furs_UniqeInvID, ref furs_BarCodeValue, ref img_QR);
                    switch (eres)
                    {

                        case FiscalVerificationOfInvoices_SLO.Result_MessageBox_Post.OK:
                            xInvData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(furs_UniqeMsgID);
                            xInvData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(furs_UniqeInvID);
                            xInvData.AddOnDI.m_FURS.FURS_QR_v = new string_v(furs_BarCodeValue);
                            xInvData.AddOnDI.m_FURS.FURS_Image_QRcode = img_QR;
                            if(xInvData.AddOnDI.m_FURS.Update_FURS_Response_Data(xInvData.DocInvoice_ID, m_FVI_SLO.FursTESTEnvironment))
                            {
                                buttonCell.Enabled = false;
                                m_InvoiceData_List.RemoveAt(e.RowIndex);
                                Init();
                            }
                            break;
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void Form_SalesBookInvoice_Send_Load(object sender, EventArgs e)
        {

        }


        private void Set_FURS_Invoice_error(ref string fURS_SalesBookInvoice_error, InvoiceData xinvd, string serr)
        {
            if (fURS_SalesBookInvoice_error == null)
            {
                fURS_SalesBookInvoice_error = "ERROR:FiscalVerificationOfInvoices_SLO:Form_InvoiceNotConfirmed_Send:";
            }
            fURS_SalesBookInvoice_error += "\r\n FiscalYear:" + xinvd.FinancialYear.ToString() + ",Number in financial year:" + xinvd.NumberInFinancialYear.ToString() + " Error:" + serr;
        }
    }
}
