using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalVerificationOfInvoices_SLO_TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            usrc_FVI_SLO1.Start();
        }


        private void btn_End_Click(object sender, EventArgs e)
        {
            usrc_FVI_SLO1.End();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            usrc_FVI_SLO1.End();
        }
    }
}
