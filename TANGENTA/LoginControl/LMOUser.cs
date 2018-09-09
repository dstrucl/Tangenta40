﻿using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TangentaDB;

namespace LoginControl
{
    public class LMOUser
    {
        internal usrc_LMOUser m_usrc_LMOUser = null;
        public Form Form_settingsuser = null;
        public ID Last_DocInvoice_ID = null;
        public ID Last_DocProformaInvoice_ID = null;
        public object oSettings = null;
        public object m_usrc_DocumentMan = null;
        internal AWPLoginData m_awpld = new AWPLoginData();
        internal AWPLoginData awpld
        {
            get
            {
                return m_awpld;
            }
            set
            {
                m_awpld = value;
            }
        }
        internal int_v PIN_v = null;
        public string m_UserName = null;
        public ID LoginUsers_ID = null;
        public ID LoginSession_ID = null;

        public ID Atom_myOrganisation_Person_ID = null;

        internal string m_Atom_myOrganisation_Person_Tax_ID = null;
        public string Atom_myOrganisation_Person_Tax_ID
        {
            get
            {
                return m_Atom_myOrganisation_Person_Tax_ID;
            }
            set
            {
                m_Atom_myOrganisation_Person_Tax_ID = value;
            }
        }


        internal string m_Atom_myOrganisation_Person_Atom_Office_ShortName = null;
        public string Atom_myOrganisation_Person_Atom_Office_ShortName
        {
            get
            {
                return m_Atom_myOrganisation_Person_Atom_Office_ShortName;
            }
            set
            {
                m_Atom_myOrganisation_Person_Atom_Office_ShortName = value;
            }
        }

        internal string m_Atom_ElectronicDevice_Atom_Office_ShortName = null;
        public string Atom_ElectronicDevice_Atom_Office_ShortName
        {
            get
            {
                return m_Atom_ElectronicDevice_Atom_Office_ShortName;
            }
            set
            {
                m_Atom_ElectronicDevice_Atom_Office_ShortName = value;
            }
        }

        internal string m_Atom_ElectronicDevice_Name = null;
        public string Atom_ElectronicDevice_Name
        {
            get
            {
                return m_Atom_ElectronicDevice_Name;
            }
            set
            {
                m_Atom_ElectronicDevice_Name = value;
            }
        }

        private ID m_Atom_WorkPeriod_ID = null;
        public ID Atom_WorkPeriod_ID
        {
            get
            {
                return m_Atom_WorkPeriod_ID;
            }
            set
            {
                m_Atom_WorkPeriod_ID = value;
            }
        }


        public bool m_LoggedIn = false;

        public LMOUser(usrc_LMOUser x_usrc_LMOUser)
        {
            m_usrc_LMOUser = x_usrc_LMOUser;
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
            set
            {
                if (awpld != null)
                {
                    awpld.myOrganisation_Person_ID = value;
                    awpld.myOrganisation_Person__per_ID = value;
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
                    if (m_usrc_LMOUser != null)
                    {
                        lng.s_Logout.Text(m_usrc_LMOUser.btn_LoginLogout);
                        m_usrc_LMOUser.btn_LoginLogout.BackColor = ColorSettings.Sheme.Current().Colorpair[4].BackColor;
                        m_usrc_LMOUser.btn_GetAccess.Visible = true;
                        if (m_usrc_LMOUser.m_LMOUser.HasLoginControlRole(new string[] { AWP.ROLE_UserManagement,AWP.ROLE_Administrator }))
                        {
                            m_usrc_LMOUser.btn_CashierDrawings.Visible = true;
                        }
                        else
                        {
                            m_usrc_LMOUser.btn_CashierDrawings.Visible = false;
                        }
                    }
                }
                else
                {
                    if (m_usrc_LMOUser != null)
                    {
                        lng.s_Login.Text(m_usrc_LMOUser.btn_LoginLogout);
                        m_usrc_LMOUser.btn_LoginLogout.BackColor = ColorSettings.Sheme.Current().Colorpair[0].BackColor;
                        m_usrc_LMOUser.btn_GetAccess.Visible = false;
                        m_usrc_LMOUser.btn_CashierDrawings.Visible = false;
                    }
                }
            }
        }

        private bool m_ReloadRequest = false;
        public bool ReloadRequest
        {
            get
            { 
                return m_ReloadRequest;
            }
            set
            {
                    m_ReloadRequest = value;
            }
        }

        internal void SetData(DataRow dr)
        {
            m_UserName = tf._set_string(dr["UserName"]);
            LoginUsers_ID = tf.set_ID(dr["ID"]);
            if (awpld==null)
            {
                awpld = new AWPLoginData();
            }
            if (AWP_func.AWPRoles_GetUserRoles(LoginUsers_ID, ref awpld.m_AWP_UserRoles))
            {
                if (IsAdministrator)
                {
                    if (m_usrc_LMOUser != null)
                    {
                        m_usrc_LMOUser.pic_administrator.Image = Properties.Resources.Login.ToBitmap();
                        m_usrc_LMOUser.pic_administrator.Visible = true;
                    }
                }
                else
                {
                    m_usrc_LMOUser.pic_administrator.Visible = false;
                }

                if (IsUserManager)
                {
                    m_usrc_LMOUser.pic_UserManager.Image = Properties.Resources.RoleManager.ToBitmap();
                    m_usrc_LMOUser.pic_UserManager.Visible = true;
                }
                else
                {
                    m_usrc_LMOUser.pic_UserManager.Visible = false;
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
                if (m_usrc_LMOUser != null)
                {
                    m_usrc_LMOUser.pictureBox1.Image = DBTypes.func.byteArrayToImage(imagebytes_v.v);
                }
            }
            else
            {

            }
            if (m_usrc_LMOUser != null)
            {
                m_usrc_LMOUser.txt_User.Text = m_UserName;
            }
            LoginSession_ID = null;
            LoggedIn = AWP_func.IsUserLoggedIn(LoginUsers_ID, ref LoginSession_ID);
        }

        public bool GetLast_Doc_ID()
        {
            throw new NotImplementedException();
        }

        public void ReloadAdministratorsAndUserManagers()
        {
            if (m_usrc_LMOUser!=null)
            {
                if (m_usrc_LMOUser.m_usrc_MultipleUsers!=null)
                {
                    m_usrc_LMOUser.m_usrc_MultipleUsers.ReloadAdministratorsAndUserManagers();
                }
            }
        }
    }
}
