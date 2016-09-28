using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;

namespace CodeTables
{
    public partial class usrc_Password : UserControl
    {
        public event EventHandler TextChanged = null;
        public event EventHandler GotFocus = null;
        

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
        public string Text
        {
            get { if (this.txt_Password.Text.Length>= m_MinPasswordLength)
                  {
                    if (this.txt_Password.Text.Equals(this.txt_Password_Retyped.Text))
                    {
                        return txt_Password.Text;
                    }
                    else
                    {
                        MessageBox.Show(this,lngRPM.s_Password_does_not_match.s);
                        return null;
                    }
                  }
                  else
                  {
                    MessageBox.Show(this, lngRPM.s_Minimum_Password_Length_is.s + MinPasswordLength.ToString());
                    return null;
                  }
                }
            set
            {
                string s = value;
                txt_Password.Text = s;
                txt_Password_Retyped.Text = s;
            }
        }

        public bool Defined { get
                              {
                                if (txt_Password.Text.Length >= MinPasswordLength)
                                {
                                    if (txt_Password.Text.Equals(txt_Password_Retyped.Text))
                                    {
                                         return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, lngRPM.s_Password_does_not_match.s + MinPasswordLength.ToString());
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, lngRPM.s_Minimum_Password_Length_is.s + MinPasswordLength.ToString());
                                    return false;
                                }
                              }
                            }

        public usrc_Password()
        {
            InitializeComponent();
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
            if (TextChanged!=null)
            {
                TextChanged(sender,e);
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
