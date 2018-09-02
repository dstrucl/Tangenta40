using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;
using TangentaPrint;
using static TangentaDB.Report;

namespace LoginControl
{
    public partial class Form_CashierDrawings : Form
    {
        private List<CashierActivity> CashierActivity_List = new List<CashierActivity>();
        private DataTable dtCashierActivity = null;

        private CashierActivity m_ca = null;

        public Form_CashierDrawings()
        {
            InitializeComponent();
            lng.s_Form_CloseDrawings.Text(this);
            btn_Exit.Text = "";
            lng.s_btn_Print.Text(btn_PrintSingle);
            lng.s_btn_PrintSelection.Text(btn_PrintMultipleSelection);
            btn_PrintMultipleSelection.Visible = false;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool Init()
        {
            if (dtCashierActivity!=null)
            {
                dtCashierActivity.Clear();
                dtCashierActivity.Columns.Clear();
            }

            if (f_CashierActivity.GetTable(ref dtCashierActivity, ref CashierActivity_List))
            {
                List<string> paymenttype_columns = new List<string>();
                List<string> VAT_columns = new List<string>();
                string scol_from_invoice = "FromInvoice";
                string scol_to_invoice = "ToInvoice";
                string scol_NumberOfInvoices = "NumberOfInvoices";
                string scol_InvoicesTotal = "InvoicesTotal";
                DataColumn dcol_FromInvoice = new DataColumn(scol_from_invoice, typeof(string));
                DataColumn dcol_ToInvoice = new DataColumn(scol_to_invoice, typeof(string));
                DataColumn dcol_NumberOfInvoices = new DataColumn(scol_NumberOfInvoices, typeof(int));
                DataColumn dcol_InvoicesTotal = new DataColumn(scol_InvoicesTotal, typeof(decimal));
                dtCashierActivity.Columns.Add(dcol_FromInvoice);
                dtCashierActivity.Columns.Add(dcol_ToInvoice);
                dtCashierActivity.Columns.Add(dcol_NumberOfInvoices);
                dtCashierActivity.Columns.Add(dcol_InvoicesTotal);
                int i = 0;
                int icount = dtCashierActivity.Rows.Count;

                //set neccesary PaymentType columns first
                for (i = 0; i < icount; i++)
                {
                    CashierActivity cai = CashierActivity_List[i];

                    foreach (PaymentType pt in cai.PaymentList.items)
                    {
                        int iPaymentTypeName = dtCashierActivity.Columns.IndexOf(pt.Name);
                        if (iPaymentTypeName < 0)
                        {
                            dtCashierActivity.Columns.Add(new DataColumn(pt.Name, typeof(decimal)));
                            if (!paymenttype_columns.Contains(pt.Name))
                            {
                                paymenttype_columns.Add(pt.Name);
                            }
                        }
                    }
                }

                //set neccesary VAT columns next
                for (i = 0; i < icount; i++)
                {
                    CashierActivity cai = CashierActivity_List[i];

                    foreach (StaticLib.Tax tax in cai.TaxSum.TaxList)
                    {
                        int iTaxName = dtCashierActivity.Columns.IndexOf(tax.Name);
                        if (iTaxName < 0)
                        {
                            dtCashierActivity.Columns.Add(new DataColumn(tax.Name, typeof(decimal)));
                            if (!VAT_columns.Contains(tax.Name))
                            {
                                paymenttype_columns.Add(tax.Name);
                            }
                        }
                    }
                }

                for (i=0;i<icount;i++)
                {
                    CashierActivity cai = CashierActivity_List[i];

                    DataRow drCashierActivity = dtCashierActivity.Rows[i];

                    foreach (PaymentType pt in cai.PaymentList.items)
                    {
                        int iPaymentTypeName = dtCashierActivity.Columns.IndexOf(pt.Name);
                        if (iPaymentTypeName >= 0)
                        {
                            drCashierActivity[iPaymentTypeName] = pt.Total;
                        }
                    }

                    foreach (StaticLib.Tax tax in cai.TaxSum.TaxList)
                    {
                        int itax = dtCashierActivity.Columns.IndexOf(tax.Name);
                        if (itax >= 0)
                        {
                            drCashierActivity[itax] = tax.TaxAmount;
                        }
                    }

                    int j = 0;
                    int jcount = cai.DocInvoice_ID_List.Count;
                    if (jcount>0)
                    {
                        string sfirst_invoice_number = cai.GetFirstInvoiceNumber();
                        string slast_invoice_number = cai.GetLastInvoiceNumber();
                        drCashierActivity[scol_from_invoice] = sfirst_invoice_number;
                        drCashierActivity[scol_to_invoice] = slast_invoice_number;
                    }
                    drCashierActivity[scol_NumberOfInvoices] = jcount;
                    drCashierActivity[scol_InvoicesTotal] = cai.Total;

                }


                dgvx_CashierDrawings.DataSource = dtCashierActivity;

                int idx = 0;
                dgvx_CashierDrawings.Columns["CashierActivityNumber"].HeaderText = lng.dvgx_CashierActivityNumber.s;
                dgvx_CashierDrawings.Columns["CashierActivityNumber"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns[scol_NumberOfInvoices].HeaderText = lng.dgvx_NumberOfInvoices.s;
                dgvx_CashierDrawings.Columns[scol_NumberOfInvoices].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns[scol_from_invoice].HeaderText = lng.dgvx_FromInvoice.s;
                dgvx_CashierDrawings.Columns[scol_from_invoice].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns[scol_to_invoice].HeaderText = lng.dgvx_ToInvoice.s;
                dgvx_CashierDrawings.Columns[scol_to_invoice].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["LoginTime"].HeaderText = lng.dgvx_LoginTime.s;
                dgvx_CashierDrawings.Columns["LoginTime"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["LogoutTime"].HeaderText = lng.dgvx_LogoutTime.s;
                dgvx_CashierDrawings.Columns["LogoutTime"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns[scol_InvoicesTotal].HeaderText = lng.dgvx_Total.s;
                dgvx_CashierDrawings.Columns[scol_InvoicesTotal].DisplayIndex = idx++;

                foreach (string spt in paymenttype_columns)
                {
                    dgvx_CashierDrawings.Columns[spt].DisplayIndex = idx++;
                }

                foreach (string svat in VAT_columns)
                {
                    dgvx_CashierDrawings.Columns[svat].DisplayIndex = idx++;
                }


                dgvx_CashierDrawings.Columns["Atom_Office_Name"].HeaderText = lng.dgvx_Atom_Office_Name.s;
                dgvx_CashierDrawings.Columns["Atom_Office_Name"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["Atom_Office_ShortName"].HeaderText = lng.dgvx_Atom_Office_ShortName.s;
                dgvx_CashierDrawings.Columns["Atom_Office_ShortName"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["Atom_ElectronicDevice_Name"].HeaderText = lng.dgvx_Atom_ElectronicDevice_Name.s;
                dgvx_CashierDrawings.Columns["Atom_ElectronicDevice_Name"].DisplayIndex = idx++;


                dgvx_CashierDrawings.Columns["Person_LoggedIn_FirstName"].HeaderText = lng.dgvx_Person_LoggedIn_FirstName.s;
                dgvx_CashierDrawings.Columns["Person_LoggedIn_FirstName"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["Person_LoggedIn_LastName"].HeaderText = lng.dgvx_Person_LoggedIn_LastName.s;
                dgvx_CashierDrawings.Columns["Person_LoggedIn_LastName"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["Person_LoggedIn_TaxID"].HeaderText = lng.dgvx_Person_LoggedIn_TaxID.s;
                dgvx_CashierDrawings.Columns["Person_LoggedIn_TaxID"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["Person_LoggedOut_FirstName"].HeaderText = lng.dgvx_Person_LoggedOut_FirstName.s;
                dgvx_CashierDrawings.Columns["Person_LoggedOut_FirstName"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["Person_LoggedOut_LastName"].HeaderText = lng.dgvx_Person_LoggedOut_LastName.s;
                dgvx_CashierDrawings.Columns["Person_LoggedOut_LastName"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["Person_LoggedOut_TaxID"].HeaderText = lng.dgvx_Person_LoggedOut_TaxID.s;
                dgvx_CashierDrawings.Columns["Person_LoggedOut_TaxID"].DisplayIndex = idx++;

                dgvx_CashierDrawings.Columns["CashierActivity_ID"].HeaderText = lng.dgvx_CashierActivity_ID.s;
                dgvx_CashierDrawings.Columns["CashierActivityOpened_ID"].HeaderText = lng.dgvx_CashierActivityOpened_ID.s;
                dgvx_CashierDrawings.Columns["Login_Atom_WorkPeriod_ID"].HeaderText = lng.dgvx_Login_Atom_WorkPeriod_ID.s;
                dgvx_CashierDrawings.Columns["CashierActivityClosed_ID"].HeaderText = lng.dgvx_CashierActivityClosed_ID.s;
                dgvx_CashierDrawings.Columns["Logout_Atom_WorkPeriod_ID"].HeaderText = lng.dgvx_Logout_Atom_WorkPeriod_ID.s;



                return true;
            }
            return false;
        }

        private void Form_CashierDrawings_Load(object sender, EventArgs e)
        {
            if (!Init())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
                return;
            }
            if (CashierActivity_List.Count > 0)
            {
                this.usrc_CashierActivity1.Init(CashierActivity_List[0]);
                this.dgvx_CashierDrawings.Rows[0].Selected = true;
            }
            this.dgvx_CashierDrawings.SelectionChanged += new System.EventHandler(this.dgvx_CashierDrawings_SelectionChanged);
        }

        private void dgvx_CashierDrawings_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = this.dgvx_CashierDrawings.SelectedRows;
            if (dgvsrc.Count>0)
            {
                DataGridViewRow dgvr = dgvsrc[0];
                int idx = dgvr.Index;
                this.usrc_CashierActivity1.Init(CashierActivity_List[idx]);
                if (dgvsrc.Count > 1)
                {
                    btn_PrintMultipleSelection.Visible = true;
                }
                else
                {
                    btn_PrintMultipleSelection.Visible = false;
                }
            }
        }

        private void btn_PrintSingle_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = this.dgvx_CashierDrawings.SelectedRows;
            if (dgvsrc.Count > 0)
            {
                DataGridViewRow dgvr = dgvsrc[0];
                int idx = dgvr.Index;
                PrintCashierActivity printCashierActivity = new PrintCashierActivity(CashierActivity_List[idx]);
                printCashierActivity.Print();
            }
        }

        private void btn_PrintMultipleSelection_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = this.dgvx_CashierDrawings.SelectedRows;
            if (dgvsrc.Count > 0)
            {
                
                foreach (DataGridViewRow dgvr in dgvsrc)
                {
                    int idx = dgvr.Index;
                    PrintCashierActivity printCashierActivity = new PrintCashierActivity(CashierActivity_List[idx]);
                    printCashierActivity.Print();
                }
            }
        }
    }
}
