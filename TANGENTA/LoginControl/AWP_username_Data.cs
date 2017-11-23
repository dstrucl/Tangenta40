using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginControl
{
   public class AWP_username_Data
    {
        public bool bChangePasswordOnFirstLogin;
        public bool bPasswordNeverExpires;
        public bool bNotActiveAfterPasswordExpires;
        public int iMaxPasswordAge;
        public string username;
        public string password;
        public bool password_changed;
        public string FirstName;
        public string LastName;
        public string IdentityNumber;
        public string Contact;
        public List<AWPRole> m_Roles = new List<AWPRole>();
    }
}
