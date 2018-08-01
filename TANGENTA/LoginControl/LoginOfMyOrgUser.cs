using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace LoginControl
{
    public class LoginOfMyOrgUser
    {
        internal usrc_LoginOfMyOrgUser m_usrc_LoginOfMyOrgUser = null;

        public ID Last_DocInvoice_ID = null;
        public ID Last_DocProformaInvoice_ID = null;
        public object oSettings = null;
        public object m_usrc_DocumentMan = null;
        internal AWPLoginData awpld = new AWPLoginData();
        internal int_v PIN_v = null;
        public string m_UserName = null;
        public ID LoginUsers_ID = null;
        public ID LoginSession_ID = null;

        public ID Atom_myOrganisation_Person_ID = null;
        public ID Atom_WorkPeriod_ID = null;

        public bool m_LoggedIn = false;

        public LoginOfMyOrgUser(usrc_LoginOfMyOrgUser x_usrc_LoginOfMyOrgUser)
        {
            m_usrc_LoginOfMyOrgUser = x_usrc_LoginOfMyOrgUser;
        }

        public bool IsUserManager
        {
            get
            {
                if (awpld != null)
                {
                    foreach (AWPRole r in awpld.m_AWP_UserRoles)
                    {
                        if (r.Role.Equals(AWP.ROLE_Administrator) || r.Role.Equals(AWP.ROLE_UserManagement))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public bool IsAdministrator
        {
            get
            {
                if (awpld != null)
                {
                    foreach (AWPRole r in awpld.m_AWP_UserRoles)
                    {
                        if (r.Role.Equals(AWP.ROLE_Administrator))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public ID LoginSession_id
        {
            get
            {
                return awpld.LoginSession_id;
            }
        }


        public ID myOrganisation_Person_ID
        {
            get { 
                    if (awpld != null)
                    {
                        return awpld.myOrganisation_Person_ID;
                    }
                    else
                    {
                        return null;
                    }
                }
        }

        public ID LoginUsers_id
        {
            get
            {
                return awpld.ID;
            }
        }

        public string UserName
        {
            get
            {
                return awpld.UserName;
            }
        }

        public string FirstName
        {
            get
            {
                return awpld.myOrganisation_Person__per__cfn_FirstName;
            }
        }

        public bool HasLoginControlRole(string[] oenofpossiblerequestedrole)
        {
            foreach (string rolepossible in oenofpossiblerequestedrole)
            {
                foreach (string usrrole in UserRoles)
                {
                    if (usrrole.Equals(rolepossible))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string LastName
        {
            get
            {
                return awpld.myOrganisation_Person__per__cln_LastName;
            }
        }

        public string Identity
        {
            get
            {
                return awpld.myOrganisation_Person__per_Registration_ID;
            }
        }

        public string Email
        {
            get
            {
                return awpld.PersonData__cemailper_Email;
            }
        }

        public List<AWPRole> LoginAWP_AllRoles
        {
            get
            {
                return awpld.m_AWPRoles;
            }
        }

        public List<string> AllRoles
        {
            get
            {
                List<string> roles = new List<string>();
                foreach (AWPRole r in awpld.m_AWPRoles)
                {
                    roles.Add(r.Role);
                }
                return roles;
            }
        }

        public List<string> UserRoles
        {
            get
            {
                List<string> roles = new List<string>();
                foreach (AWPRole r in awpld.m_AWP_UserRoles)
                {
                    roles.Add(r.Role);
                }
                return roles;
            }
        }

        public bool PasswordNeverExpires
        {
            get
            {
                return awpld.PasswordNeverExpires;
            }
        }

        public bool NotActiveAfterPasswordExpires
        {
            get
            {
                return awpld.NotActiveAfterPasswordExpires;
            }
        }

        public bool bPasswordExpiresInNumberOfDays
        {
            get
            {
                if ((!awpld.PasswordNeverExpires) && (!awpld.NotActiveAfterPasswordExpires))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int PasswordExpiresInNumberOfDays
        {
            get
            {
                if (!awpld.PasswordNeverExpires)
                {
                    TimeSpan tspan = new TimeSpan();
                    if (awpld.Time_When_UserSetsItsOwnPassword_LastTime != DateTime.MinValue)
                    {
                        tspan = DateTime.Now - awpld.Time_When_UserSetsItsOwnPassword_LastTime;
                        return tspan.Days;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        public int Maximum_password_age_in_days
        {
            get
            {
                return awpld.Maximum_password_age_in_days;
            }
        }

        public DateTime LastUserPasswordDefinitionTime
        {
            get
            {
                return awpld.Time_When_UserSetsItsOwnPassword_LastTime;
            }
        }



        internal bool LoggedIn
        {
            get
            {
                return m_LoggedIn;
            }
            set
            {
                m_LoggedIn = value;
                if (m_LoggedIn)
                {
                    if (m_usrc_LoginOfMyOrgUser != null)
                    {
                        lng.s_Logout.Text(m_usrc_LoginOfMyOrgUser.btn_LoginLogout);
                        m_usrc_LoginOfMyOrgUser.btn_LoginLogout.BackColor = ColorSettings.Sheme.Current().Colorpair[4].BackColor;
                        m_usrc_LoginOfMyOrgUser.btn_GetAccess.Visible = true;
                    }
                }
                else
                {
                    if (m_usrc_LoginOfMyOrgUser != null)
                    {
                        lng.s_Login.Text(m_usrc_LoginOfMyOrgUser.btn_LoginLogout);
                        m_usrc_LoginOfMyOrgUser.btn_LoginLogout.BackColor = ColorSettings.Sheme.Current().Colorpair[0].BackColor;
                        m_usrc_LoginOfMyOrgUser.btn_GetAccess.Visible = false;
                    }
                }
            }
        }

        internal void SetData(DataRow dr)
        {
            m_UserName = tf._set_string(dr["UserName"]);
            LoginUsers_ID = tf.set_ID(dr["ID"]);
            if (AWP_func.AWPRoles_GetUserRoles(LoginUsers_ID, ref awpld.m_AWP_UserRoles))
            {
                if (IsAdministrator)
                {
                    if (m_usrc_LoginOfMyOrgUser != null)
                    {
                        m_usrc_LoginOfMyOrgUser.pic_administrator.Image = Properties.Resources.Login.ToBitmap();
                        m_usrc_LoginOfMyOrgUser.pic_administrator.Visible = true;
                    }
                }
                else
                {
                    m_usrc_LoginOfMyOrgUser.pic_administrator.Visible = false;
                }

                if (IsUserManager)
                {
                    m_usrc_LoginOfMyOrgUser.pic_UserManager.Image = Properties.Resources.RoleManager.ToBitmap();
                    m_usrc_LoginOfMyOrgUser.pic_UserManager.Visible = true;
                }
                else
                {
                    m_usrc_LoginOfMyOrgUser.pic_UserManager.Visible = false;
                }
            }

            ID xmyOrganisation_Person_ID = tf.set_ID(dr["myOrganisation_Person_ID"]);
            if (!ID.Validate(xmyOrganisation_Person_ID))
            {
                LogFile.Error.Show("ERROR:LoginControl:usrc_LoginOfMyOrguser:SetData:xmyOrganisation_Person_ID is not valid.");
            }

            string_v office_name_v = null;
            if (!f_Atom_myOrganisation_Person.Get(xmyOrganisation_Person_ID, ref Atom_myOrganisation_Person_ID, ref office_name_v))
            {
                LogFile.Error.Show("ERROR:LoginControl:usrc_LoginOfMyOrguser:SetData:_Atom_myOrganisation_Person.Get failed!");
            }
            byte_array_v imagebytes_v = tf.set_byte_array(dr["PersonData_$_perimg_$$Image_Data"]);
            PIN_v = tf.set_int(dr["PersonData_$$PIN"]);
            if (imagebytes_v != null)
            {
                if (m_usrc_LoginOfMyOrgUser != null)
                {
                    m_usrc_LoginOfMyOrgUser.pictureBox1.Image = DBTypes.func.byteArrayToImage(imagebytes_v.v);
                }
            }
            else
            {

            }
            if (m_usrc_LoginOfMyOrgUser != null)
            {
                m_usrc_LoginOfMyOrgUser.lbl_User.Text = m_UserName;
            }
            LoginSession_ID = null;
            LoggedIn = AWP_func.IsUserLoggedIn(LoginUsers_ID, ref LoginSession_ID);
        }

        public bool GetLast_Doc_ID()
        {
            throw new NotImplementedException();
        }
    }
}
