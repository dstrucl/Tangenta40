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
        public bool NoPwdCheck
        {
            get { return this.usrc_Password1.NoPwdCheck; }
        }

        public Form_AskForPassword(Form parent,Icon form_icon,string Password)
        {
            InitializeComponent();
            this.usrc_Password1.MyPassword = Password;
        }

        private void usrc_Password1_exit_OK()
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }


        private void usrc_Password1_exit_Cancel()
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
