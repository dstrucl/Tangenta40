using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LanguageControl;
using System.Runtime.InteropServices;
using DBConnectionControl40;
using DBTypes;

namespace LoginControl
{
    internal partial class AWPLoginForm_AuthentificatePIN : Form
    {
        
        private AWPLoginForm_OneFromMultipleUsers.LoginType m_loginType = AWPLoginForm_OneFromMultipleUsers.LoginType.LOGIN;

        LMOUser m_LMOUser = null;

        internal ID LoginSession_id = null;
        internal ID Atom_WorkPeriod_ID = null;


        private int_v m_PIN_v = null;


        public AWPLoginForm_AuthentificatePIN(LMOUser xLMOUser)
        {

            InitializeComponent();
            m_LMOUser = xLMOUser;

            txt_UserName.Text = m_LMOUser.UserName;
            m_PIN_v = m_LMOUser.PIN_v;
            this.Text = lng.s_Login.s;
            this.btn_OK.Text = lng.s_Login.s;

            this.btn_Cancel.Text = lng.s_Cancel.s;
            lng.s_UserName.Text(lbl_UserName,":");
            lng.s_PIN.Text(lbl_PIN,":");
            lng.s_Clear.Text(btn_Clear);
        }

        private void DoPINAuthenticate()
        {

            if (m_PIN_v != null)
            {
                try
                {
                    int pin = Convert.ToInt32(txt_PIN.Text);
                    if (pin == m_PIN_v.v)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                        return;
                    }
                    else
                    {
                        XMessage.Box.Show(this, lng.s_WrongPIN, MessageBoxIcon.Information);
                        DialogResult = DialogResult.Cancel;
                        Close();
                        return;
                    }

                }
                catch
                {
                    XMessage.Box.Show(this, lng.s_WrongPIN, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
            }
            else
            {
                XMessage.Box.Show(this, lng.s_ThisOrgansiationPersonHasNoPIN_please_define_PIN, MessageBoxIcon.Information);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }
        }

     
        private void btn_OK_Click(object sender, EventArgs e)
        {
            DoPINAuthenticate();
        }



        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AWPLoginForm_AuthentificatePIN_Shown(object sender, EventArgs e)
        {
            txt_PIN.Focus();
        }


        private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
               
                e.Handled = true;
                DoPINAuthenticate();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text = "";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "6";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "7";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "8";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.txt_PIN.Text += "9";
        }
    }
}
