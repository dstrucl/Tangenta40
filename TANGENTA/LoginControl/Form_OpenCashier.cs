using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class Form_OpenCashier : Form
    {
        private usrc_LMOUser m_usrc_LMOUser = null;
        public Form_OpenCashier()
        {
            InitializeComponent();
        }

        public Form_OpenCashier(usrc_LMOUser xusrc_LMOUser)
        {
            InitializeComponent();
            m_usrc_LMOUser = xusrc_LMOUser;
            lng.s_Form_OpenCashier.Text(this);
            lng.s_OpenCashierInfo.Text(lbl_CashierOpen_Info);
            lng.s_btn_YES.Text(btn_YES);
            lng.s_btn_NO.Text(btn_NO);
            if (m_usrc_LMOUser.m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_Administrator, AWP.ROLE_UserManagement }))
            {
                lng.s_btn_CashierDrawings.Text(btn_CashierDrawings);
                btn_CashierDrawings.Visible = true;
            }
            else
            {
                btn_CashierDrawings.Visible = false;
            }


        }

        private void btn_YES_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Yes;
        }

        private void btn_NO_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.No;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.No;
        }

        private void btn_CashierDrawings_Click(object sender, EventArgs e)
        {
            Form_CashierDrawings frm_cashierDrawings = new Form_CashierDrawings();
            frm_cashierDrawings.ShowDialog(this);
        }
    }
}
