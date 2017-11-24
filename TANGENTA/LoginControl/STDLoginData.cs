using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginControl
{
    public class STDLoginData
    {
        internal int m_LoginSession_id = -1;
        internal int m_LoginUsers_id = -1;
        internal string m_UserName = null;
        internal string m_FirstName = null;
        internal string m_LastName = null;
        internal string m_Identity = null;
        internal string m_Contact = null;
        internal bool m_PasswordNeverExpires = false;
        internal bool m_Active = false;
        internal bool m_NotActiveAfterPasswordExpires = false;
        internal int NumberOfDaysAfterPasswordExpires = -1;
        internal DateTime Time_When_UserSetsItsOwnPassword_LastTime = DateTime.MinValue;

        internal List<STDRole> m_STDRoles = new List<STDRole>();
        internal bool IsAdministrator
        {
            get
            {
                foreach (STDRole role in m_STDRoles)
                {
                    if (role.Name.Equals("Administrator"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        internal bool UserNameIsAdministrator
        {
            get
            {
                if (m_UserName != null)
                {
                    if (m_UserName.Equals("Administrator"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
