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
        public Form_OpenCashier()
        {
            InitializeComponent();
            lng.s_OpenCashierInfo.Text(lbl_CashierOpen_Info);
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
    }
}
