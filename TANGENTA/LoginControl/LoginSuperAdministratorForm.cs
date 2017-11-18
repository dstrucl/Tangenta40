using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace LoginControl
{
    public partial class LoginSuperAdministratorForm : Form
    {
        public LoginSuperAdministratorForm()
        {
            InitializeComponent();
            this.lbl_LoginAsSuperadministrator.Text = lng.s_LoginSuperAdministrator.s;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string sPassword = null;
            sPassword += (DateTime.Now.Day + 1).ToString();
            sPassword += (DateTime.Now.Month + 2).ToString();
            sPassword += (DateTime.Now.Year + 3).ToString();
            sPassword += (DateTime.Now.Hour + 4).ToString();

            if (txt_Password.Text.Equals(sPassword))
            {
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show(lng.s_Password_Wrong.s);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
            return;
        }

        private void LoginSuperAdministratorForm_Load(object sender, EventArgs e)
        {
            #if DEBUG
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            #endif

        }
    }
}
