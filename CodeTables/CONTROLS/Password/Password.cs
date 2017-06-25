using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Password
{
    public static class Password
    {
        public static bool pwdchk = true;

        public static string UnlockPassword(string s)
        {
            string sunLocked = "";
            if (s != null)
            {
                int iLen = s.Length;
                if (iLen > 0)
                {
                    int i = 0;
                    for (i = 0; i < iLen; i++)
                    {
                        int ichar = char.ConvertToUtf32(s, i);
                        int ichar_unlocked = (ichar - (i + 1) * 2) / 2;
                        string sl = char.ConvertFromUtf32(ichar_unlocked);
                        sunLocked += sl;
                    }
                }
            }
            return sunLocked;
        }

        public static string LockPassword(string s)
        {
            string sLocked = "";
            if (s != null)
            {
                int iLen = s.Length;
                if (iLen > 0)
                {
                    int i = 0;
                    for (i = 0; i < iLen; i++)
                    {
                        int ichar = char.ConvertToUtf32(s, i);
                        int ichar_locked = ichar * 2 + (i + 1) * 2;
                        string sl = char.ConvertFromUtf32(ichar_locked);
                        sLocked += sl;
                    }
                }
            }
            return sLocked;
        }
        public static bool Check(Form parent, Icon ico, string password)
        {
            if (pwdchk)
            {
                Form_AskForPassword frm_passwrd = new Form_AskForPassword(parent, ico, password);
                if (frm_passwrd.ShowDialog() == DialogResult.OK)
                {
                    if (frm_passwrd.NoPwdCheck)
                    {
                        pwdchk = false;
                    }
                    return true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
