using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace Password
{
    public partial class usrc_Password : UserControl
    {
        public delegate void delegate_Password_OK();
        public event delegate_Password_OK exit_OK = null;

        public delegate void delegate_Cancel();
        public event delegate_Cancel exit_Cancel = null;

        private string m_Password = null;

        public string MyPassword
        {
            set { m_Password = value; }
        }

        public bool NoPwdCheck
        {
            get
            {
                return chk_RememberPasswordInSession.Checked;
            }
        }

        public usrc_Password()
        {
            InitializeComponent();
            lngRPM.s_Enter_Administrator_Password.Text(lbl_EnterAdministratorPasword);
            lngRPM.s_Wrong_Password.Text(lbl_WrongPassword);
            lngRPM.s_OK.Text(btn_OK);
            lngRPM.s_Cancel.Text(btn_Cancel);
            lngRPM.s_RememberPasswordForSession.Text(chk_RememberPasswordInSession);
            this.Text = "";
            lbl_WrongPassword.Visible = false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (m_Password != null)
            {
                string unlocked_password = Password.UnlockPassword(m_Password);
                if (unlocked_password.Equals(txt_Password.Text))
                {
                    lbl_WrongPassword.Visible = false;
                    if (exit_OK!=null)
                    {
                        exit_OK();
                    }
                }
                else
                {
                    lbl_WrongPassword.Visible = true;
                }
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (exit_Cancel!=null)
            {
                exit_Cancel();
            }
        }

        private void btn_PasswordView_Click(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = false;
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            txt_Password.UseSystemPasswordChar = true;
        }
    }
}
