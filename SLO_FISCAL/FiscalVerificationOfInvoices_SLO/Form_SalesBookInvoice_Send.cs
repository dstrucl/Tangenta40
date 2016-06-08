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
            lngRPM.s_SalesBookInvoice_UnsentMsg.Text(this.lbl_SalesBookInvoice_UnsentMsg);
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
            for (i = 0; i < iCount; i++)
            {
                InvoiceData xinvd = xInvoiceData_List[i];
                DataRow dr = dt.NewRow();
                dr["FinancialYear"] = xinvd.FinancialYear;
                dr["InvoiceNumber"] = xinvd.FURS_SalesBookInvoice_InvoiceNumber_v.v;
                dr["SalesBookInvoice_SerialNumber"] = xinvd.FURS_SalesBookInvoice_SetNumber_v.v;
                dr["SalesBookInvoice_SetNumber"] = xinvd.FURS_SalesBookInvoice_SetNumber_v.v;
                dr["IssueDate_v"] = xinvd.IssueDate_v.v;
                dr["GrossSum"] = xinvd.GrossSum;
                dr["TaxSum"] = xinvd.taxsum;
                dr["NetSum"] = xinvd.NetSum;
                dr["IssuerFirstName"] = xinvd.Invoice_Author.FirstName;
                dr["IssuerLastName"] = xinvd.Invoice_Author.LastName;
                dt.Rows.Add(dr);
            }
            dgvx_SalesBookInvoice_Unsent.DataSource = dt;
            dgvx_SalesBookInvoice_Unsent.Columns["FinancialYear"].HeaderText = lngRPM.s_FinancialYear.s;
            dgvx_SalesBookInvoice_Unsent.Columns["InvoiceNumber"].HeaderText = lngRPM.s_InvoiceNumber.s;
            dgvx_SalesBookInvoice_Unsent.Columns["SalesBookInvoice_SerialNumber"].HeaderText = lngRPM.s_SalesBook_SerialNumber.s; ;
            dgvx_SalesBookInvoice_Unsent.Columns["SalesBookInvoice_SetNumber"].HeaderText = lngRPM.s_SalesBook_SetNumber.s;
            dgvx_SalesBookInvoice_Unsent.Columns["IssueDate_v"].HeaderText = lngRPM.s_IssueDate.s;
            dgvx_SalesBookInvoice_Unsent.Columns["GrossSum"].HeaderText = lngRPM.s_GrossSum.s;
            dgvx_SalesBookInvoice_Unsent.Columns["TaxSum"].HeaderText = lngRPM.s_TaxSum.s;
            dgvx_SalesBookInvoice_Unsent.Columns["NetSum"].HeaderText = lngRPM.s_NetSum.s;
            dgvx_SalesBookInvoice_Unsent.Columns["IssuerFirstName"].HeaderText = lngRPM.s_Issuer_FirstName.s;
            dgvx_SalesBookInvoice_Unsent.Columns["IssuerLastName"].HeaderText = lngRPM.s_Issuer_LastName.s;
            DataGridViewDisableButtonColumn dgvbcol = new DataGridViewDisableButtonColumn();
            dgvbcol.Name = "Send";
            dgvbcol.HeaderText = lngRPM.s_SendtoDurs.s;
            dgvbcol.Text = lngRPM.s_SendtoDurs.s;
            dgvbcol.ValueType = typeof(string);
            dgvbcol.UseColumnTextForButtonValue = true;
            dgvx_SalesBookInvoice_Unsent.Columns.Insert(0, dgvbcol);
            dgvx_SalesBookInvoice_Unsent.CellContentClick += Dgvx_SalesBookInvoice_Unsent_CellContentClick;
            dgvx_SalesBookInvoice_Unsent.CellValueChanged += Dgvx_SalesBookInvoice_Unsent_CellValueChanged;
            dgvx_SalesBookInvoice_Unsent.CurrentCellDirtyStateChanged += Dgvx_SalesBookInvoice_Unsent_CurrentCellDirtyStateChanged;

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
                        xInvData.FURS_ZOI_v = new string_v(ZOI);
                        xInvData.FURS_EOR_v = new string_v(EOR);
                        xInvData.FURS_QR_v = new string_v(BarCodeValue);
                        xInvData.Write_FURS_Response_Data();
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

    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,  
            // background, and disabled button for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text. 
                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class 
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
