using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnectionControl40;
using LanguageControl;
using LogFile;
using System.Security.Cryptography;
using NavigationButtons;

namespace LoginControl
{
    public partial class LoginCtrl : UserControl
    {
        public delegate bool delegate_Get_Atom_WorkPeriod(ID myOrganisation_Person_ID, ref ID Atom_WordPeriod_ID);
        public delegate bool delegate_Edit_myOrganisationPerson(Form parentform, ID myOrganisation_Person_ID, ref bool Changed, ref ID myOrganisation_Person_ID_new);



        public enum eDataTableCreationMode {/*STAND_ALONE*/STD,/*Atom_WorkPeriod*/ AWP };
        private eDataTableCreationMode m_eDataTableCreationMode = eDataTableCreationMode.STD;

        AWP awp = null;
        STD std = null;




        internal int m_MinPasswordLength = 5;


        public eDataTableCreationMode DataTableCreationMode
        {
            get { return m_eDataTableCreationMode; }
            set { m_eDataTableCreationMode = value; }
        }

        private string m_RecentItemsFolder = "";
        
        public string RecentItemsFolder
        {
            get { return m_RecentItemsFolder; }
            set { m_RecentItemsFolder = value; }
        }

        public bool IsUserManager
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.IsUserManager;
                }
                else
                {
                    return std.IsUserManager;
                }
            }
        }

        public bool IsAdministrator
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    if (awp != null)
                    {
                        return awp.IsAdministrator;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return std.IsAdministrator;
                }
            }
        }

        public ID LoginSession_id
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.LoginSession_id;
                }
                else
                {

                  return new ID(std.LoginSession_id);
                }
            }
        }

        public ID LoginUsers_id
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.LoginUsers_id;
                }
                else
                {
                    return new ID(std.LoginUsers_id);
                }
            }
        }

        public ID myOrganisation_Person_ID
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.myOrganisation_Person_ID;
                }
                else
                {
                    return new ID(std.LoginUsers_id);
                }
            }
        }

        public bool HasLoginControlRole(string[] roles)
        {
            if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
            {
                return awp.HasLoginControlRole(roles);
            }
            else
            {
                return true;
            }
        }

        public string UserName
        {
            get {
                    if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                    {
                        return awp.UserName;
                    }
                    else
                    {
                        return std.UserName;
                    }
                }
        }

        public string FirstName
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.FirstName;
                }
                else
                {
                    return std.FirstName;
                }
            }
        }

        public string LastName
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.LastName;
                }
                else
                {
                    return std.LastName;
                }
            }
        }

        public string Identity
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.Identity;
                }
                else
                {
                    return std.Identity;
                }
            }
        }

        public string Email
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.Email;
                }
                else
                {
                    return std.Email;
                }
            }
        }


        public List<string> AllRoles
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.AllRoles;
                }
                else
                {
                    return null;
                }
            }
        }


        internal List<string> UserRoles
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.UserRoles;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool PasswordNeverExpires
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.PasswordNeverExpires;
                }
                else
                {
                    return std.PasswordNeverExpires;
                }
            }
        }

        public bool NotActiveAfterPasswordExpires
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.NotActiveAfterPasswordExpires;
                }
                else
                {
                    return std.NotActiveAfterPasswordExpires;
                }
            }
        }

        public bool bPasswordExpiresInNumberOfDays
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.bPasswordExpiresInNumberOfDays;
                }
                else
                {
                    return std.bPasswordExpiresInNumberOfDays;
                }
            }
        }

        public int PasswordExpiresInNumberOfDays
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                   return awp.PasswordExpiresInNumberOfDays;
                }
                else
                {
                    return std.PasswordExpiresInNumberOfDays;
                }
            }
        }

        public int Maximum_password_age_in_days
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.Maximum_password_age_in_days;
                }
                else
                {
                    return std.Maximum_password_age_in_days;
                }
            }
        }

        public DateTime LastUserPasswordDefinitionTime
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.LastUserPasswordDefinitionTime;
                }
                else
                {
                    return std.LastUserPasswordDefinitionTime;
                }
            }
        }

        public int MinPasswordLength
        {
            get { return m_MinPasswordLength;  }
            set {m_MinPasswordLength = value;
                    if (m_MinPasswordLength < 5)
                    {
                        MessageBox.Show(lng.s_YouCanNotSetMinumumPasswordLengthLessThan5.s);
                    }
                }
        }

        public LoginCtrl()
        {
            InitializeComponent();
        }

        public void Init(eDataTableCreationMode xeDataTableCreationMode,
                         DBConnection xcon,
                         delegate_Get_Atom_WorkPeriod xdelegate_Get_Atom_WorkPeriod,
                         delegate_Edit_myOrganisationPerson xdelegate_Edit_myOrganisationPerson,
                         object DBParam, int Language_id, ref bool bCancel)
        {
            m_eDataTableCreationMode = xeDataTableCreationMode;
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    if (awp==null)
                    {
                        awp = new AWP();
                    }
                    awp.Init(Global.f.GetParentForm(this), this, xcon, xdelegate_Edit_myOrganisationPerson);
                    break;
                case eDataTableCreationMode.STD:
                    if (std == null)
                    {
                        std = new STD();
                    }
                    string Err = null;
                    std.Init(Global.f.GetParentForm(this), this,xcon,DBParam,Language_id, ref bCancel,ref Err);
                    break;
            }
        }

        public bool CheckConnection(Form pParentForm)
        {
            if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
            {
                return awp.CheckConnection(pParentForm);
            }
            else
            {
                return std.CheckConnection(pParentForm); 
            }
        }


        public static byte[] CalculateSHA256(string InputString)
        {
            //encrypt password
            byte[] encryptedPass;
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed shaTranscode = new SHA256Managed();
            encryptedPass = shaTranscode.ComputeHash(encoder.GetBytes(InputString));
            return encryptedPass;
        }

 

        internal bool PasswordMatch(byte[] encrypted_password, string password)
        {
            byte[] encrypted_password2 = LoginCtrl.CalculateSHA256(password);

            if ((encrypted_password.Length == encrypted_password2.Length))
            {
                for (int i = 0; i < encrypted_password.Length; i++)
                {
                    if (encrypted_password[i] != encrypted_password2[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public bool Login(Navigation xnav,delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod,UserControl xusrc_DocumentMan)
        {
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    return awp.Login(xnav,call_Get_Atom_WorkPeriod, xusrc_DocumentMan);
                case eDataTableCreationMode.STD:
                    return std.STD_Login();
            }
            LogFile.Error.Show("ERROR:LoginControl:Login:m_eDataTableCreationMode=" + m_eDataTableCreationMode.ToString() + " not implemented!");
            return false;
        }
   

 

        private void btn_UserManager_Click(object sender, EventArgs e)
        {
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    Navigation xnav = new Navigation(null);
                    xnav.m_eButtons = Navigation.eButtons.OkCancel;
                    AWP_UserManager AWP_usr_mangaer = new AWP_UserManager(xnav,this.ParentForm, awp);
                    AWP_usr_mangaer.ShowDialog(Global.f.GetParentForm(this));
                    break;

                case eDataTableCreationMode.STD:
                    STD_UserManager STD_usr_mangaer = new STD_UserManager(this.ParentForm, std);
                    STD_usr_mangaer.ShowDialog(Global.f.GetParentForm(this));
                    break;
            }
        }

        private void btn_UserInfo_Click(object sender, EventArgs e)
        {
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    Form pForm = Global.f.GetParentForm(this);
                    AWP_UserInfo_Form awp_usr_info = new AWP_UserInfo_Form(pForm, UserName, awp);
                    awp_usr_info.ShowDialog(pForm);
                    break;
                case eDataTableCreationMode.STD:
                    STDUserInfoForm usrinfo = new STDUserInfoForm(std);
                    usrinfo.ShowDialog();
                    break;
            }
        }
    }
}
