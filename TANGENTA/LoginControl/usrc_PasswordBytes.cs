using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class usrc_PasswordBytes : UserControl
    {
        public delegate void delegate_PasswordChanged();
        public event delegate_PasswordChanged PasswordChanged = null;

        private const string TEXT_PASSWORD_WILDCARDS = "***********";

        private bool m_Changed = false;
        private int m_MinPasswordLength = 5;
        public int MinPasswordLength
        {
            get { return m_MinPasswordLength; }
            set { m_MinPasswordLength = value; }
        }

        public bool Changed
        {
            get { return m_Changed; }
        }

        private byte[] m_Password = null;

        public void SetPassword(byte[] xPassword, int xMinPasswordLength)
        {
            this.RemoveHandlers();
            m_Changed = false;
            m_Password = xPassword;
            if (m_Password == null)
            {
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                
            }
            else
            {
                txtPassword.Text = TEXT_PASSWORD_WILDCARDS;
                txtConfirmPassword.Text = "";
                txtConfirmPassword.Enabled = true;

            }
            m_MinPasswordLength = xMinPasswordLength;

            this.AddHandlers();
        }

        public bool GetPassword(ref byte[] xPassword)
        {
            if (m_Changed)
            {
                if (PasswordConfirmed())
                {
                    m_Password = LoginCtrl.CalculateSHA256(txtPassword.Text);
                    xPassword = m_Password;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (m_Password==null)
            {
                XMessage.Box.Show(this,lng.s_PasswordIsNotDefined_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers1,MessageBoxIcon.Information);
                return false;
            }
            else
            {
                xPassword = m_Password;
                return true;
            }
        }
        public usrc_PasswordBytes()
        {
            InitializeComponent();
            lng.s_lblConfirmPassword_UserManager.Text(this.lbl_ConfirmPasword);
            lng.s_lblPassword.Text(this.lblPassword);
        }


        private bool PasswordConfirmed()
        {
            if (txtPassword.Text.Length >= m_MinPasswordLength)
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    return true;
                }
                else
                {
                    XMessage.Box.Show(this,lng.s_Password_does_not_match,MessageBoxIcon.Information);
                }
            }
            else
            {
                XMessage.Box.Show(this,lng.s_YouMustDefinePasswordThatHasAtLeastXCharactersOrNumbers," " + MinPasswordLength.ToString(),"",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            return false;
        }


        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                txtConfirmPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                {
                    e.Handled = true;
                }
                else
                {
                    XMessage.Box.Show(this,lng.s_Password_does_not_match,"", lng.s_Warning.s, MessageBoxButtons.OK, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                    e.Handled = true;
                }
            }
        }

        public void AddHandlers()
        {
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);

        }

        public void RemoveHandlers()
        {
            this.txtPassword.TextChanged -= new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter -= new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtConfirmPassword.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            m_Changed = true;
            if (txtPassword.Text.Length > 0)
            {
                this.lbl_ConfirmPasword.Enabled = true;
                this.txtConfirmPassword.Enabled = true;
            }
            else
            {
                this.txtConfirmPassword.Text = "";
                this.txtConfirmPassword.Enabled = false;
                this.lbl_ConfirmPasword.Enabled = false;
            }
            if (PasswordChanged!=null)
            {
                PasswordChanged();
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }
    }
}
