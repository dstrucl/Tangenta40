using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Password
{
    public partial class Form_AskForPassword : Form
    {
        private string m_Password = null;
        public Form_AskForPassword(Form parent,Icon form_icon,string Password)
        {
            InitializeComponent();
            m_Password = Password;
            this.Parent = parent;
            if (form_icon!=null)
            {
                this.Icon = form_icon;
            }
            lngRPM.s_Enter_Administrator_Password.Text(lbl_EnterAdministratorPasword);
            lngRPM.s_Wrong_Password.Text(lbl_WrongPassword);
            lngRPM.s_OK.Text(btn_OK);
            lngRPM.s_Cancel.Text(btn_Cancel);
            this.Text = "";
            lbl_WrongPassword.Visible = false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (m_Password!=null)
            {
                string unlocked_password = usrc_Password.UnlockPassword(m_Password);
                if (unlocked_password.Equals(txt_Password.Text))
                {
                    lbl_WrongPassword.Visible = false;
                    this.Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    lbl_WrongPassword.Visible = true;
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
