using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestPassword
{
    public partial class Form1 : Form
    {
        Password.usrc_Password usrc_pass = null;
        public Form1()
        {
            InitializeComponent();
            usrc_pass = new Password.usrc_Password();
        }

        private void btn_Lock_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = usrc_pass.LockPassword(this.textBox1.Text);
        }

        private void btn_Unlock_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = usrc_pass.UnlockPassword(this.textBox2.Text);

        }
    }
}
