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
        Password.usrc_PasswordDefinition usrc_pass = null;
        public Form1()
        {
            InitializeComponent();
            usrc_pass = new Password.usrc_PasswordDefinition();
        }

        private void btn_Lock_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = Password.Password.LockPassword(this.textBox1.Text);
        }

        private void btn_Unlock_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = Password.Password.UnlockPassword(this.textBox2.Text);

        }
    }
}
