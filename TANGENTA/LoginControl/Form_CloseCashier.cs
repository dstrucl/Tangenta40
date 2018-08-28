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
            m_ca = ca;
            lbl_CashierActivityNumber_Value.Text = ca.CashierActivityNumber.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_YES_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
