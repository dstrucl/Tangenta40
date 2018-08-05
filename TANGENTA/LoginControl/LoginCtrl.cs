﻿using System;
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
using TangentaDB;

namespace LoginControl
{
    public partial class LoginCtrl : Component
    {
        public usrc_LoginCtrl m_usrc_LoginCtrl = null;

        public Form m_parent_form = null;

        public enum eExitReason { NORMAL, LOGIN_CONTROL };

        public enum eAuthentificationType { NONE, PASSWORD, PIN, RFID };

        public delegate void delegate_UserLoggedIn(LMOUser xLMOUser);

        public event delegate_UserLoggedIn UserLoggedIn = null;

        public delegate void delegate_UserLoggedOut(LMOUser xLMOUser);

        public event delegate_UserLoggedOut UserLoggedOut = null;

        public delegate void delegate_ActivateDocumentMan(LMOUser xLMOUser);

        public event delegate_ActivateDocumentMan ActivateDocumentMan = null;


        public delegate void delegate_EndProgram(eExitReason eReason);

        public event delegate_EndProgram EndProgram=null;


        public delegate bool delegate_Edit_myOrganisationPerson(Form parentform, ID myOrganisation_Person_ID, ref bool Changed, ref ID myOrganisation_Person_ID_new);

        public event delegate_Edit_myOrganisationPerson Edit_myOrganisationPerson = null;



        public enum eDataTableCreationMode {/*STAND_ALONE*/STD,/*Atom_WorkPeriod*/ AWP };
        internal eDataTableCreationMode m_eDataTableCreationMode = eDataTableCreationMode.STD;

        public AWP awp = null;
        internal STD std = null;


        private eAuthentificationType m_AuthentificationType = eAuthentificationType.PASSWORD;

        public eAuthentificationType AuthentificationType
        {
            get
            {
                return m_AuthentificationType;
            }
            set
            {
                m_AuthentificationType = value;
            }
        }


        internal static int m_MinPasswordLength = 5;

        private bool m_Login_MultipleUsers = false;

        public bool Login_MultipleUsers
        {
            get
            {
                return m_Login_MultipleUsers;
            }
        }

        
        public bool ShowAdministrators
        {
            get
            {
                if (awp != null)
                {
                    if (awp.m_usrc_MultipleUsers != null)
                    {
                        return awp.m_usrc_MultipleUsers.chk_ShowAdministrators.Checked;
                    }
                }
                return false;
            }
            set
            {
                if (awp != null)
                {
                    if (awp.m_usrc_MultipleUsers != null)
                    {
                        awp.m_usrc_MultipleUsers.chk_ShowAdministrators.Checked= value;
                    }
                }
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



        internal void Trigger_EventUserLoggedIn(LMOUser xLMOUser)
        {
            if (UserLoggedIn!=null)
            {
                UserLoggedIn(xLMOUser);
            }
        }

        internal void Trigger_EventUserLoggedOut(LMOUser xLMOUser)
        {
            if (UserLoggedOut != null)
            {
                UserLoggedOut(xLMOUser);
            }
        }



        internal void Trigger_EventUserActivateDocumentMan(LMOUser xLMOUser)
        {
            if (ActivateDocumentMan!=null)
            {
                ActivateDocumentMan(xLMOUser);
                if (awp.m_usrc_MultipleUsers!=null)
                {
                    awp.m_usrc_MultipleUsers.Visible = false;
                }
            }
        }

        public int PasswordExpiresInNumberOfDays
        {
            get
            {
                if (m_eDataTableCreationMode == eDataTableCreationMode.AWP)
                {
                    return awp.LMOUser_Single.PasswordExpiresInNumberOfDays;
                }
                else
                {
                    return std.PasswordExpiresInNumberOfDays;
                }
            }
        }



        public static int MinPasswordLength
        {
            get { return m_MinPasswordLength; }
            set
            {
                m_MinPasswordLength = value;
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

        public LoginCtrl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Init(Form parent_form,
                 eDataTableCreationMode xeDataTableCreationMode,
                 DBConnection xcon,
                 object DBParam, int Language_id, ref bool bCancel)
        {
            m_eDataTableCreationMode = xeDataTableCreationMode;
            m_parent_form = parent_form;
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    if (awp == null)
                    {
                        awp = new AWP();
                    }
                    awp.Init(parent_form, this, xcon);
                    break;
                case eDataTableCreationMode.STD:
                    if (std == null)
                    {
                        std = new STD();
                    }
                    string Err = null;
                    std.Init(m_parent_form, this, xcon, DBParam, Language_id, ref bCancel, ref Err);
                    break;
            }
        }

        internal bool Trigger_EventGetWorkPeriod(ID myOrganisation_Person__per_ID, ref ID atom_WorkPeriod_ID)
        {
            throw new NotImplementedException();
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



        internal static bool PasswordMatch(byte[] encrypted_password, string password)
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


        public bool Login_SingleUser(Navigation xnav)
        {
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    return awp.LoginSingleUser(xnav);
                case eDataTableCreationMode.STD:
                    return std.STD_Login();
            }
            LogFile.Error.Show("ERROR:LoginControl:Login:m_eDataTableCreationMode=" + m_eDataTableCreationMode.ToString() + " not implemented!");
            return false;
        }

        public bool Login_MultipleUsers_ShowControlAtStartup(Navigation xnav,
                                                            bool bShowAdministratorUsers)
        {
            Close_Opened_Atom_WorkingPeriods();
            m_Login_MultipleUsers = true;
            switch (m_eDataTableCreationMode)
            {
                case eDataTableCreationMode.AWP:
                    return awp.Login_MultipleUsers_ShowControlAtStartup(xnav, bShowAdministratorUsers);
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
                    frmawpclose.ShowDialog(m_parent_form);
                }
            }
        }

        public void Login_MultipleUsers_ShowControl()
        {
            awp.Login_MultipleUsers_ShowControl();
        }

        internal static bool getWorkPeriod(ID myOrganisation_Person_ID,ref ID xAtom_myOrganisation_Person_ID, ref ID xAtom_WorkPeriod_ID)
        {
            string Err = null;
            if (GlobalData.GetWorkPeriod(myOrganisation_Person_ID, f_Atom_WorkPeriod.sWorkPeriod, lng.s_WorkPeriod.s, DateTime.Now, null,ref xAtom_myOrganisation_Person_ID, ref xAtom_WorkPeriod_ID, ref Err))
            {
                return true;
            }
            else
            {
                xAtom_WorkPeriod_ID = null;
                return false;
            }
        }

        internal void DoEndProgram(eExitReason exitReason)
        {
            if (EndProgram!=null)
            {
                EndProgram(exitReason);
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

        internal void TriggerEvent_Edit_myOrganisationPerson(AWP_UserManager aWP_UserManager, ID myOrganisation_Person_ID, ref bool bChanged, ref ID new_myOrganisation_Person_ID)
        {
            if (Edit_myOrganisationPerson!=null)
            {
                Edit_myOrganisationPerson(aWP_UserManager, myOrganisation_Person_ID, ref bChanged, ref new_myOrganisation_Person_ID);
            }
        }
    }
}
