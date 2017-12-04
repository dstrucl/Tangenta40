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
    public partial class usrc_PasswordDefinition : UserControl
    {
        public delegate void delegate_TextChanged(object sender, EventArgs e);
        public event delegate_TextChanged PasswordTextChanged = null;
        public new event EventHandler GotFocus = null;

        public bool m_Locked = true;

        public bool PasswordLocked
        {
            get { return m_Locked; }
            set { m_Locked = value; }
            
        }

        private int m_MinPasswordLength = 5;
        public int MinPasswordLength
        {
            get { return m_MinPasswordLength; }
            set { m_MinPasswordLength = value; }
        }
        private int m_MaxLength = 5;
        public int MaxLength
        {
            get { return m_MaxLength; }
            set { m_MaxLength = value;
                txt_Password.MaxLength = m_MaxLength;
                txt_Password_Retyped.MaxLength = m_MaxLength;
                }
        }
        public new string Text
        {
            get { if (this.txt_Password.Text.Length>= m_MinPasswordLength)
                  {
                    if (this.txt_Password.Text.Equals(this.txt_Password_Retyped.Text))
                    {
                        if (PasswordLocked)
                        {
                            return Password.LockPassword(txt_Password.Text);
                        }
                        else
                        {
                            return txt_Password.Text;
                        }
                    }
                    else
                    {
                        return null;
                    }
                  }
                  else
                  {
                    return null;
                  }
                }
            set
            {
                string s = value;
                this.txt_Password.TextChanged -= new System.EventHandler(this.txt_Password_TextChanged);
                if (PasswordLocked)
                {
                   
                    string s_unlocked = Password.UnlockPassword(s);
                    txt_Password.Text = s_unlocked;
                    txt_Password_Retyped.Text = s_unlocked;
                }
                else
                {
                    txt_Password.Text = s;
                    txt_Password_Retyped.Text = s;
                }
                this.txt_Password.TextChanged += new System.EventHandler(this.txt_Password_TextChanged);
            }
        }

        public bool ReadOnly
        {
            get { return txt_Password.ReadOnly; }
            set
            {
                bool b = value;
                txt_Password.ReadOnly = b;
                txt_Password_Retyped.ReadOnly = b;
            }
        }

        public bool Match()
        {
            if (txt_Password.Text.Length >= MinPasswordLength)
            {
                if (txt_Password.Text.Equals(txt_Password_Retyped.Text))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, lng.s_Password_does_not_match.s + MinPasswordLength.ToString());
                    return false;
                }
            }
            else
            {
                MessageBox.Show(this, lng.s_Minimum_Password_Length_is.s + MinPasswordLength.ToString());
                return false;
            }
        }

 

        public bool Defined()
        {
            if (txt_Password.Text.Length >= MinPasswordLength)
            {
                if (txt_Password.Text.Equals(txt_Password_Retyped.Text))
                {
                        return true;
                }
                else
                {
                    MessageBox.Show(this, lng.s_Password_does_not_match.s + MinPasswordLength.ToString());
                    return false;
                }
            }
            else
            {
                MessageBox.Show(this, lng.s_Minimum_Password_Length_is.s + MinPasswordLength.ToString());
                return false;
            }
        }

        public usrc_PasswordDefinition()
        {
            InitializeComponent();
            lbl_Retype_Password.Text = lng.s_RetypePassword.s;
            txt_Password.Text = "";
            this.txt_Password.TextChanged += new System.EventHandler(this.txt_Password_TextChanged);
            txt_Password.GotFocus += Txt_Password_GotFocus;
        }

        private void Txt_Password_GotFocus(object sender, EventArgs e)
        {
            if (GotFocus!=null)
            {
                GotFocus(sender, e);
            }
        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTextChanged!=null)
            {
                PasswordTextChanged(sender,e);
            }
        }

        private void btn_PasswordView_Click(object sender, EventArgs e)
        {
            txt_Password.UseSystemPasswordChar = false;
            txt_Password_Retyped.UseSystemPasswordChar = false;
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            txt_Password.UseSystemPasswordChar = true;
            txt_Password_Retyped.UseSystemPasswordChar = true;
        }
    }
}
