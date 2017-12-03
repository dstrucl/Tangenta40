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
    public partial class Form_SalesBookInvoice_Send : Form
    {
        private usrc_FVI_SLO m_usrc_FVI_SLO = null;
        private List<InvoiceData> m_InvoiceData_List = null;
        private DataTable dt = new DataTable();

        public Form_SalesBookInvoice_Send(usrc_FVI_SLO xusrc_FVI_SLO, List<InvoiceData> xInvoiceData_List)
        {
            InitializeComponent();
            m_usrc_FVI_SLO = xusrc_FVI_SLO;
            m_InvoiceData_List = xInvoiceData_List;
            lng.s_SalesBookInvoice_UnsentMsg.Text(this.lbl_SalesBookInvoice_UnsentMsg);
            DataColumn dcol_FinancialYear = new DataColumn("FinancialYear", typeof(int));
            DataColumn dcol_InvoiceNumber = new DataColumn("InvoiceNumber", typeof(string));
            DataColumn dcol_IssueDate_v = new DataColumn("IssueDate_v", typeof(DateTime));
            DataColumn dcol_SalesBookInvoice_SerialNumber = new DataColumn("SalesBookInvoice_SerialNumber", typeof(string));
            DataColumn dcol_SalesBookInvoice_SetNumber = new DataColumn("SalesBookInvoice_SetNumber", typeof(string));
            DataColumn dcol_GrossSum = new DataColumn("GrossSum", typeof(decimal));
            DataColumn dcol_TaxSum = new DataColumn("TaxSum", typeof(decimal));
            DataColumn dcol_NetSum = new DataColumn("NetSum", typeof(decimal));
            DataColumn dcol_BarCodeValue = new DataColumn("BarCodeValue", typeof(string));
            DataColumn dcol_IssuerFirstName = new DataColumn("IssuerFirstName", typeof(string));
            DataColumn dcol_IssuerLastName = new DataColumn("IssuerLastName", typeof(string));

            dt.Columns.Add(dcol_FinancialYear);
            dt.Columns.Add(dcol_InvoiceNumber);
            dt.Columns.Add(dcol_BarCodeValue);
            dt.Columns.Add(dcol_SalesBookInvoice_SerialNumber);
            dt.Columns.Add(dcol_SalesBookInvoice_SetNumber);
            dt.Columns.Add(dcol_IssueDate_v);
            dt.Columns.Add(dcol_GrossSum);
            dt.Columns.Add(dcol_TaxSum);
            dt.Columns.Add(dcol_NetSum);
            dt.Columns.Add(dcol_IssuerFirstName);
            dt.Columns.Add(dcol_IssuerLastName);
            int i = 0;
            int iCount = xInvoiceData_List.Count;
            string FURS_SalesBookInvoice_error = null;
            for (i = 0; i < iCount; i++)
            {
                InvoiceData xinvd = xInvoiceData_List[i];
                DataRow dr = dt.NewRow();
                dr["FinancialYear"] = xinvd.FinancialYear;
                dr["InvoiceNumber"] = xinvd.NumberInFinancialYear;
                if (xinvd.AddOnDI.m_FURS.FURS_SalesBookInvoice_InvoiceNumber_v != null)
                {
                    dr["InvoiceNumber"] = xinvd.AddOnDI.m_FURS.FURS_SalesBookInvoice_InvoiceNumber_v.v;
                }
                else
                {
                    Set_FURS_SalesBookInvoice_error(ref FURS_SalesBookInvoice_error, xinvd, "No SalesBookInvoice InvoiceNumber");
                }
                if (xinvd.AddOnDI.m_FURS.FURS_SalesBookInvoice_SerialNumber_v != null)
                {
                    dr["SalesBookInvoice_SerialNumber"] = xinvd.AddOnDI.m_FURS.FURS_SalesBookInvoice_SetNumber_v.v;
                }
                else
                {
                    Set_FURS_SalesBookInvoice_error(ref FURS_SalesBookInvoice_error, xinvd, "No SalesBookInvoice SerialNumber");
                }
                if (xinvd.AddOnDI.m_FURS.FURS_SalesBookInvoice_SetNumber_v != null)
                {
                    dr["SalesBookInvoice_SetNumber"] = xinvd.AddOnDI.m_FURS.FURS_SalesBookInvoice_SetNumber_v.v;
                }
                else
                {
                    Set_FURS_SalesBookInvoice_error(ref FURS_SalesBookInvoice_error, xinvd, "No SalesBookInvoice SetNumber");
                }
                
                dr["IssueDate_v"] = xinvd.IssueDate_v.v;
                dr["GrossSum"] = xinvd.GrossSum;
                dr["TaxSum"] = xinvd.taxsum;
                dr["NetSum"] = xinvd.NetSum;
                dr["IssuerFirstName"] = xinvd.Invoice_Author.FirstName;
                dr["IssuerLastName"] = xinvd.Invoice_Author.LastName;
                dt.Rows.Add(dr);
            }
            if (FURS_SalesBookInvoice_error != null)
            {
                LogFile.Error.Show(FURS_SalesBookInvoice_error);
            }
            dgvx_SalesBookInvoice_Unsent.DataSource = dt;
            dgvx_SalesBookInvoice_Unsent.Columns["FinancialYear"].HeaderText = lng.s_FinancialYear.s;
            dgvx_SalesBookInvoice_Unsent.Columns["InvoiceNumber"].HeaderText = lng.s_InvoiceNumber.s;
            dgvx_SalesBookInvoice_Unsent.Columns["SalesBookInvoice_SerialNumber"].HeaderText = lng.s_SalesBook_SerialNumber.s; ;
            dgvx_SalesBookInvoice_Unsent.Columns["SalesBookInvoice_SetNumber"].HeaderText = lng.s_SalesBook_SetNumber.s;
            dgvx_SalesBookInvoice_Unsent.Columns["IssueDate_v"].HeaderText = lng.s_IssueDate.s;
            dgvx_SalesBookInvoice_Unsent.Columns["GrossSum"].HeaderText = lng.s_GrossSum.s;
            dgvx_SalesBookInvoice_Unsent.Columns["TaxSum"].HeaderText = lng.s_TaxSum.s;
            dgvx_SalesBookInvoice_Unsent.Columns["NetSum"].HeaderText = lng.s_NetSum.s;
            dgvx_SalesBookInvoice_Unsent.Columns["IssuerFirstName"].HeaderText = lng.s_Issuer_FirstName.s;
            dgvx_SalesBookInvoice_Unsent.Columns["IssuerLastName"].HeaderText = lng.s_Issuer_LastName.s;
            DataGridViewDisableButtonColumn dgvbcol = new DataGridViewDisableButtonColumn();
            dgvbcol.Name = "Send";
            dgvbcol.HeaderText = lng.s_SendtoDurs.s;
            dgvbcol.Text = lng.s_SendtoDurs.s;
            dgvbcol.ValueType = typeof(string);
            dgvbcol.UseColumnTextForButtonValue = true;
            dgvx_SalesBookInvoice_Unsent.Columns.Insert(0, dgvbcol);
            dgvx_SalesBookInvoice_Unsent.CellContentClick += Dgvx_SalesBookInvoice_Unsent_CellContentClick;
            dgvx_SalesBookInvoice_Unsent.CellValueChanged += Dgvx_SalesBookInvoice_Unsent_CellValueChanged;
            dgvx_SalesBookInvoice_Unsent.CurrentCellDirtyStateChanged += Dgvx_SalesBookInvoice_Unsent_CurrentCellDirtyStateChanged;

        }

        private void Set_FURS_SalesBookInvoice_error(ref string fURS_SalesBookInvoice_error, InvoiceData xinvd, string serr)
        {
            if (fURS_SalesBookInvoice_error == null)
            {
                fURS_SalesBookInvoice_error = "ERROR:FiscalVerificationOfInvoices_SLO:Form_SalesBookInvoice_Send:";
            }
            fURS_SalesBookInvoice_error += "\r\n FiscalYear:"+ xinvd.FinancialYear.ToString()+",Number in financial year:" + xinvd.NumberInFinancialYear.ToString()+" Error:"+ serr;
        }

        private void Dgvx_SalesBookInvoice_Unsent_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvx_SalesBookInvoice_Unsent.IsCurrentCellDirty)
            {
                dgvx_SalesBookInvoice_Unsent.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Dgvx_SalesBookInvoice_Unsent_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvx_SalesBookInvoice_Unsent.Columns[e.ColumnIndex].Name == "Send")
            {
                DataGridViewDisableButtonCell buttonCell =
                    (DataGridViewDisableButtonCell)dgvx_SalesBookInvoice_Unsent.
                    Rows[e.RowIndex].Cells["Send"];

                DataGridViewCheckBoxCell checkCell =
                    (DataGridViewCheckBoxCell)dgvx_SalesBookInvoice_Unsent.
                    Rows[e.RowIndex].Cells["Send"];
                buttonCell.Enabled = !(Boolean)checkCell.Value;

                dgvx_SalesBookInvoice_Unsent.Invalidate();
            }
        }

        private void Dgvx_SalesBookInvoice_Unsent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewDisableButtonColumn && e.RowIndex >= 0)
            {
                string BarCodeValue = null;
                DataGridViewDisableButtonCell buttonCell =
                (DataGridViewDisableButtonCell)dgvx_SalesBookInvoice_Unsent.Rows[e.RowIndex].Cells["Send"];
                if (buttonCell.Enabled)
                {
                    string ZOI = null;
                    string EOR = null;
                    Image img_QR = null;
                    InvoiceData xInvData = m_InvoiceData_List[e.RowIndex];
                    if (m_usrc_FVI_SLO.Send_SalesBookInvoice(this, xInvData, ref ZOI,ref EOR, ref BarCodeValue, ref img_QR))
                    {
                        buttonCell.Enabled = false;
                        dt.Rows[e.RowIndex]["BarCodeValue"] = BarCodeValue;
                        xInvData.AddOnDI.m_FURS.FURS_ZOI_v = new string_v(ZOI);
                        xInvData.AddOnDI.m_FURS.FURS_EOR_v = new string_v(EOR);
                        xInvData.AddOnDI.m_FURS.FURS_QR_v = new string_v(BarCodeValue);
                        xInvData.AddOnDI.m_FURS.Write_FURS_Response_Data(xInvData.DocInvoice_ID,this.m_usrc_FVI_SLO.FursTESTEnvironment);
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
    }
}
