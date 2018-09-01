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

namespace LoginControl
{
    public partial class Form_CloseCashier : Form
    {
        private CashierActivity m_ca = null;
        public Form_CloseCashier()
        {
            InitializeComponent();
        }

        public Form_CloseCashier(CashierActivity ca)
        {
            InitializeComponent();
            lng.s_Form_CloseCashier.Text(this);
            lng.s_lbl_CashierOpen_Question.Text(lbl_CashierOpen_Question);
            lng.s_btn_NO.Text(btn_NO);
            lng.s_btn_YES.Text(btn_YES);
            lng.s_btn_YesPrint.Text(btn_YesPrint);
            m_ca = ca;
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
