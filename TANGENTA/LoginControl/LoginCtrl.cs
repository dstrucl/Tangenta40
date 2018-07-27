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
using System.Runtime.InteropServices;

namespace LoginControl
{
    public partial class LoginCtrl : UserControl
    {
        public enum eExitReason { NORMAL, LOGIN_CONTROL };

        public enum eAuthentificationType { NONE,PASSWORD,PIN,RFID};


        public delegate void delegate_Activate_usrc_DocumentMan(usrc_MultipleUsers xm_usrc_MultipleUsers);

        public delegate void delegate_EndProgram(eExitReason eReason);


        public delegate bool delegate_Get_Atom_WorkPeriod(ID myOrganisation_Person_ID, ref ID Atom_WordPeriod_ID);
        public delegate bool delegate_Edit_myOrganisationPerson(Form parentform, ID myOrganisation_Person_ID, ref bool Changed, ref ID myOrganisation_Person_ID_new);



        public enum eDataTableCreationMode {/*STAND_ALONE*/STD,/*Atom_WorkPeriod*/ AWP };
        private eDataTableCreationMode m_eDataTableCreationMode = eDataTableCreationMode.STD;

        AWP awp = null;
        STD std = null;

        internal delegate_EndProgram EndProgram = null;

        private eAuthentificationType m_AuthentificationType = eAuthentificationType.PASSWORD;

        public eAuthentificationType AuthentificationType
        {
            get {
                return m_AuthentificationType;
                }
            set
            {
                m_AuthentificationType = value;
            }
        }


        internal int m_MinPasswordLength = 5;

        private bool m_Login_MultipleUsers = false;

        public bool Login_MultipleUsers
        {
            get
            {
                return m_Login_MultipleUsers;
            }
        }

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

        public void SetAccessAuthentification(int accessAuthentication)
        {
            switch (accessAuthentication)
            {
                case 0:
                    AuthentificationType = eAuthentificationType.NONE;
                    break;
                case 1:
                    AuthentificationType = eAuthentificationType.PASSWORD;
                    break;
                case 2:
                    AuthentificationType = eAuthentificationType.PIN;
                    break;
                case 3:
                    AuthentificationType = eAuthentificationType.RFID;
                    break;
                default:
                    LogFile.Error.Show("ERROR:LoginControl:LoginCtrl:SetAccessAuthentification:accessAuthentication not implemented for value=" + accessAuthentication.ToString());
                    break;
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
                         delegate_EndProgram xEndProgram,
                         object DBParam, int Language_id, ref bool bCancel)
        {
            m_eDataTableCreationMode = xeDataTableCreationMode;
            EndProgram = xEndProgram;
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


        public bool Login(Navigation xnav,delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod)
        {
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    return awp.Login(xnav,call_Get_Atom_WorkPeriod);
                case eDataTableCreationMode.STD:
                    return std.STD_Login();
            }
            LogFile.Error.Show("ERROR:LoginControl:Login:m_eDataTableCreationMode=" + m_eDataTableCreationMode.ToString() + " not implemented!");
            return false;
        }

        public bool Login_MultipleUsers_ShowControlAtStartup(Navigation xnav, 
                                                            delegate_Get_Atom_WorkPeriod call_Get_Atom_WorkPeriod,
                                                            delegate_Activate_usrc_DocumentMan call_Activate_usrc_DocumentMan,
                                                            UserControl xusrc_DocumentMan)
        {
            Close_Opened_Atom_WorkingPeriods();
            m_Login_MultipleUsers = true;
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    return awp.Login_MultipleUsers_ShowControlAtStartup(xnav, call_Get_Atom_WorkPeriod, call_Activate_usrc_DocumentMan, xusrc_DocumentMan);
                case eDataTableCreationMode.STD:
                    return std.STD_Login();
            }
            LogFile.Error.Show("ERROR:LoginControl:Login:m_eDataTableCreationMode=" + m_eDataTableCreationMode.ToString() + " not implemented!");
            return false;
        }


        private void Close_Opened_Atom_WorkingPeriods()
        {
            string where_condition = " where LoginSession_$_awperiod_$$LogoutTime is null";
            DataTable dtOpened_Atom_WorkingPeriods = new DataTable();
            if (AWP_func.Read_LoginSession_VIEW(ref dtOpened_Atom_WorkingPeriods, where_condition, null))
            {
                if (dtOpened_Atom_WorkingPeriods.Rows.Count > 0)
                {
                    AWPForm_Close_Opened_Atom_WorkingPeriods frmawpclose = new AWPForm_Close_Opened_Atom_WorkingPeriods(dtOpened_Atom_WorkingPeriods);
                    frmawpclose.ShowDialog(this);
                }
            }
        }

        public void Login_MultipleUsers_ShowControl()
        {
            awp.Login_MultipleUsers_ShowControl();
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


        public struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Millisecond;
        };

        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime sysTime);

        public static bool SetThisComputerSystemTime(DateTime TimeOnServer, ref string Err)
        {
            try
            {
                SystemTime updatedTime = new SystemTime();
                updatedTime.Year = Convert.ToUInt16(TimeOnServer.Year);
                updatedTime.Month = Convert.ToUInt16(TimeOnServer.Month);
                updatedTime.Day = Convert.ToUInt16(TimeOnServer.Day);
                updatedTime.Hour = Convert.ToUInt16(TimeOnServer.Hour);
                updatedTime.Minute = Convert.ToUInt16(TimeOnServer.Minute);
                updatedTime.Second = Convert.ToUInt16(TimeOnServer.Second);
                updatedTime.Millisecond = Convert.ToUInt16(TimeOnServer.Millisecond);
                // Call the unmanaged function that sets the new date and time instantly
                Win32SetSystemTime(ref updatedTime);
                return true;
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
        }
        internal static bool Logout(ID xAtom_WorkPeriod_ID)
        {
            DateTime TimeOnServer = new DateTime();
            if (AWP_func.con.DBType == DBConnectionControl40.DBConnection.eDBType.MSSQL)
            {
                // Get time from server
                //TimeOnServer = m_LoginDB_DataSet_ScalarFunctions.Login_Server_GetDate(ref Err);
                string Err = null;
                if (SetThisComputerSystemTime(TimeOnServer, ref Err))
                {
                }
            }

            if (ID.Validate(xAtom_WorkPeriod_ID))
            {
                if (TangentaDB.f_Atom_WorkPeriod.End(xAtom_WorkPeriod_ID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
