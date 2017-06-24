using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdministratorPassword
{
    public static class Password
    {
        public static bool Get(Form parent,Icon ico, string password)
        {
            Form_AskForPassword frm_passwrd = new Form_AskForPassword(parent, ico, password);
            if (frm_passwrd.ShowDialog()==DialogResult.OK)
            {
                return true;
            }
            return false;
        }
    }
}
