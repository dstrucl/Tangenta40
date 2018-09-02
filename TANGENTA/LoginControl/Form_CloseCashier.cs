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
    public partial class Form_CloseCashier : Form
    {
        private CashierActivity m_ca = null;
        private LMOUser m_LMOUser = null;
        public Form_CloseCashier()
        {
            InitializeComponent();
        }

        public Form_CloseCashier(CashierActivity ca,LMOUser x_LMOUser)
        {
            InitializeComponent();
            lng.s_Form_CloseCashier.Text(this);
            lng.s_lbl_CashierClose_Question.Text(lbl_CashierClose_Question);
            lng.s_btn_NO.Text(btn_NO);
            lng.s_btn_YES.Text(btn_YES);
            lng.s_btn_YesPrint.Text(btn_YesPrint);
            m_ca = ca;
            m_LMOUser = x_LMOUser;
        }

        private void Form_CloseCashier_Load(object sender, EventArgs e)
        {
            if (!m_ca.GetDocInvoices())
            {
                this.Close();
                DialogResult = DialogResult.Abort;
                return;
            }
            DateTime logoutTime = DateTime.MinValue;
            if (!f_Atom_WorkPeriod.GetLogoutTime(m_LMOUser.Atom_WorkPeriod_ID,ref logoutTime))
            {
                this.Close();
                DialogResult = DialogResult.Abort;
                return;
            }
            m_ca.LastLogin = logoutTime;
            this.usrc_CashierActivity1.Init(m_ca);
        }

        private void btn_NO_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btn_YES_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btn_YesPrint_Click(object sender, EventArgs e)
        {
            //do print
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
