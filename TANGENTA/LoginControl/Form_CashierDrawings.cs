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
            if (f_CashierActivity.GetTable(ref dtCashierActivity, ref CashierActivity_List))
            {
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
            dgvx_CashierDrawings.DataSource = dtCashierActivity;
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

        private void btn_PrintMany_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvsrc = this.dgvx_CashierDrawings.SelectedRows;
            if (dgvsrc.Count > 0)
            {
                
                foreach (DataGridViewRow dgvr in dgvsrc)
                {
                    int idx = dgvr.Index;
                  //  CashierActivity_List[idx];
                }
            }
        }
    }
}
