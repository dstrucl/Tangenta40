using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DBConnectionControl35;
using LanguageControl;
using LogFile;
using System.Security.Cryptography;

namespace LoginControl
{
    public partial class LoginControl : UserControl
    {
        public enum eDataTableCreationMode { NONE, KIG_PLATES };
        LoginDB_DataSet.Login_VIEW m_Login_VIEW = null;
        LoginDB_DataSet.LoginDB_DataSet_Procedures m_LoginDB_DataSet_Procedures = null;

        internal LoginData m_LoginData = new LoginData();
        internal DBConnection Login_con;

        internal int m_MinPasswordLength = 3;

        private eDataTableCreationMode m_eDataTableCreationMode = eDataTableCreationMode.NONE; 

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

        public bool IsAdministrator
        {
            get { return m_LoginData.IsAdministrator; }
        }

        public bool UserNameIsAdministrator
        {
            get { return m_LoginData.UserNameIsAdministrator; }
        }

        public int LoginSession_id
        {
            get { return m_LoginData.m_LoginSession_id; }
        }

        public int LoginUsers_id
        {
            get { return m_LoginData.m_LoginUsers_id; }
        }

        public string UserName
        {
            get { return m_LoginData.m_UserName; }
        }

        public string FirstName
        {
            get { return m_LoginData.m_FirstName; }
        }

        public string LastName
        {
            get { return m_LoginData.m_LastName; }
        }

        public string Identity
        {
            get { return m_LoginData.m_Identity; }
        }

        public string Contact
        {
            get { return m_LoginData.m_Contact; }
        }

        public List<Role> LoginRoles
        {
            get { return m_LoginData.m_Roles; }
        }

        public bool PasswordNeverExpires
        {
            get { return m_LoginData.m_PasswordNeverExpires; }
        }

        public bool NotActiveAfterPasswordExpires
        {
            get { return m_LoginData.m_NotActiveAfterPasswordExpires; }
        }

        public bool bPasswordExpiresInNumberOfDays
        {
            get
            {
                if ((!m_LoginData.m_PasswordNeverExpires) && (!m_LoginData.m_NotActiveAfterPasswordExpires))
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
                if (!m_LoginData.m_PasswordNeverExpires)
                {
                    TimeSpan tspan = new TimeSpan();
                    if (m_LoginData.Time_When_UserSetsItsOwnPassword_LastTime != DateTime.MinValue)
                    {
                        tspan = DateTime.Now - m_LoginData.Time_When_UserSetsItsOwnPassword_LastTime;
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

        public int NumberOfDaysAfterPasswordExpires
        {
            get { return m_LoginData.NumberOfDaysAfterPasswordExpires; }
        }

        public DateTime LastUserPasswordDefinitionTime
        {
            get { return m_LoginData.Time_When_UserSetsItsOwnPassword_LastTime; }
        }

        public int MinPasswordLength
        {
            get { return m_MinPasswordLength;  }
            set {m_MinPasswordLength = value;
                    if (m_MinPasswordLength < 3)
                    {
                        MessageBox.Show(lngRPM.s_YouCanNotSetMinumumPasswordLengthLessThan3.s);
                    }
                }
        }

        public LoginControl()
        {
            InitializeComponent();
        }
        public bool CheckConnection(Form pParentForm)
        {
            return Login_con.CheckDataBaseConnection(pParentForm, lngRPM.s_LoginConnection.s);
        }


        public byte[] CalculateSHA256(string InputString)
        {
            //encrypt password
            byte[] encryptedPass;
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed shaTranscode = new SHA256Managed();
            encryptedPass = shaTranscode.ComputeHash(encoder.GetBytes(InputString));
            return encryptedPass;
        }

        public bool GetTables(ref string Err)
        {
            
            if (Read_Login_VIEW(ref Err))
            {
                return true;
            }
            else
            {
                switch (m_eDataTableCreationMode)
                {
                    case eDataTableCreationMode.NONE:
                        if (MessageBox.Show(lngRPM.s_CreateLoginTablesQuestion.s, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (CreateTables())
                            {
                                if (Read_Login_VIEW(ref Err))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:Reading Login Tables !");
                                    return false;
                                }

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
                        break;

                    case eDataTableCreationMode.KIG_PLATES:
                        {
                            if (CreateTables())
                            {
                                if (Read_Login_VIEW(ref Err))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:Reading Login Tables !");
                                    return false;
                                }

                            }
                            else
                            {
                                return false;
                            }
                        }

                    default:
                        return false;

                }
            }
        }

        public bool DropConstraints(DBConnection db_con)
        {
            switch (db_con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    string sql_DropConstraints = @"
                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginUsersAndLoginRoles') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginUsersAndLoginRoles_LoginUsers_id'))) ALTER TABLE LoginUsersAndLoginRoles DROP CONSTRAINT fkLoginUsersAndLoginRoles_LoginUsers_id;     

                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginUsersAndLoginRoles') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginUsersAndLoginRoles_LoginRoles_id'))) ALTER TABLE LoginUsersAndLoginRoles DROP CONSTRAINT fkLoginUsersAndLoginRoles_LoginRoles_id;     

                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginSession') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginSession_LoginUsers_id'))) ALTER TABLE LoginSession DROP CONSTRAINT fkLoginSession_LoginUsers_id;     

                     
                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginSession') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginSession_LoginComputer_id'))) ALTER TABLE LoginSession DROP CONSTRAINT fkLoginSession_LoginComputer_id;     

                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginSession') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginSession_LoginComputerUser_id'))) ALTER TABLE LoginSession DROP CONSTRAINT fkLoginSession_LoginComputerUser_id;     

                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginFailed') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginFailed_LoginComputer_id'))) ALTER TABLE LoginFailed DROP CONSTRAINT fkLoginFailed_LoginComputer_id;     

                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginFailed') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginFailed_LoginComputerUser_id'))) ALTER TABLE LoginFailed DROP CONSTRAINT fkLoginFailed_LoginComputerUser_id;     

                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginManagerJournal') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginManagerJournal_LoginUsers_id'))) ALTER TABLE LoginManagerJournal DROP CONSTRAINT fkLoginManagerJournal_LoginUsers_id;     
					 
                     IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE ((TABLE_NAME = 'LoginManagerJournal') 
                                                                                        AND (CONSTRAINT_NAME = 'fkLoginManagerJournal_LoginManagerEvent_id'))) ALTER TABLE LoginManagerJournal DROP CONSTRAINT fkLoginManagerJournal_LoginManagerEvent_id;     
                ";
                    object Result = null;
                    string Err = null;
                    if (db_con.ExecuteNonQuerySQL(sql_DropConstraints, null, ref Result, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("Error:LoginControl:DropConstraints:Err = " + Err);
                        return false;
                    }

                default:
                    LogFile.Error.Show("Error:LoginControl:DropConstraints:Login_con.DBType not of type DBConnection.eDBType.MSSQL!");
                    return false;
            }
        }

        private bool DropTables(DBConnection db_con)
        {
            switch (db_con.DBType)
            {
                case DBConnection.eDBType.MSSQL:
                    string sql_DropTables = @"
                 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginUsersAndLoginRoles') DROP TABLE LoginUsersAndLoginRoles; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginUsers') DROP TABLE LoginUsers; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginRoles') DROP TABLE LoginRoles; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginSession') DROP TABLE LoginSession; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginFailed') DROP TABLE LoginFailed; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginComputer') DROP TABLE LoginComputer; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginComputerUser') DROP TABLE LoginComputerUser; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginManagerJournal') DROP TABLE LoginManagerJournal; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 

				 IF EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LoginManagerEvent') DROP TABLE LoginManagerEvent; 
                 SET ANSI_NULLS ON; SET QUOTED_IDENTIFIER ON; 
            ";
                    object Result = null;
                    string Err = null;
                    if (db_con.ExecuteNonQuerySQL(sql_DropTables, null, ref Result, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("Error:LoginControl:DropTables:Err = " + Err);
                        return false;
                    }

                default:
                    LogFile.Error.Show("Error:LoginControl:DropTables:Login_con.DBType not of type DBConnection.eDBType.MSSQL!");
                    return false;
            }
        }

        private bool CreateTables()
        {
            string sCreateLoginTables = null;
            if (DropConstraints(Login_con))
            {
                if (DropTables(Login_con))
                {
                    switch (Login_con.DBType)
                    {
                        case DBConnection.eDBType.MSSQL:


                            sCreateLoginTables = @"
    				 
                     CREATE TABLE [dbo].[LoginUsers]
				     (
                     [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
				     [first_name] [nvarchar](250)  NULL,
				     [last_name] [nvarchar](250)  NULL,
				     [Identity][nvarchar](4000) NULL,
				     [Contact][nvarchar](1000) NULL,
				     [username] [nvarchar](250)  NOT NULL UNIQUE,
				     [password] [varbinary](max) NULL,
				     [enabled] bit NOT NULL,
				     ChangePasswordOnFirstLogin [bit] NOT NULL,
				     Time_When_AdministratorSetsPassword datetime NULL,
                     Administrator_LoginUsers_id int NULL,
                     Time_When_UserSetsItsOwnPassword_FirstTime datetime NULL,
                     Time_When_UserSetsItsOwnPassword_LastTime datetime NULL,
				     PasswordNeverExpires bit NOT NULL,
				     Maximum_password_age_in_days int NULL,
                     NotActiveAfterPasswordExpires bit NOT NULL
				     )

                     CREATE TABLE [dbo].[LoginRoles]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
					     Name  nvarchar(250) NOT NULL UNIQUE,
                         PrivilegesLevel int NOT NULL UNIQUE,
					     [description] nvarchar(2000),
				     )

                     CREATE TABLE [dbo].[LoginUsersAndLoginRoles]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
					     LoginUsers_id int NOT NULL,
					     LoginRoles_id int NOT NULL
				     )
                    
                     CREATE TABLE [dbo].[LoginComputer]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                         ComputerName nvarchar(260) NULL
                     )

                     CREATE TABLE [dbo].[LoginComputerUser]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                         ComputerUserName nvarchar(260) NULL
                     )
                        

                     CREATE TABLE [dbo].[LoginSession]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
					     LoginUsers_id int NOT NULL,
					     Login_time datetime NOT NULL,
                         Logout_time datetime NULL,
                         LoginComputer_id int NULL,
                         LoginComputerUser_id int NULL,
                         Logout_Type int NULL
				     )


                     CREATE TABLE [dbo].[LoginFailed]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
					     [username] [nvarchar](250)  NOT NULL,
					     [AttemptTime] datetime NOT NULL,
                         [username_does_not_exist] bit NOT NULL,
                         [password_wrong] bit NULL,
                         [LoginComputer_id] int NULL,
                         LoginComputerUser_id int NULL
				     )

                     CREATE TABLE [dbo].[LoginManagerEvent]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                         [Name] nvarchar(1000) NOT NULL UNIQUE
				     )

                     CREATE TABLE [dbo].[LoginManagerJournal]
				     (
                         [id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
					     [LoginUsers_id] int NOT NULL,
					     [LoginManagerEvent_id] int NOT NULL,
                         [Time] datetime NOT NULL
				     )

                     ALTER TABLE [dbo].LoginManagerJournal
				     ADD CONSTRAINT fkLoginManagerJournal_LoginUsers_id
				     FOREIGN KEY (LoginUsers_id) REFERENCES [dbo].LoginUsers(id);

                     ALTER TABLE [dbo].LoginManagerJournal
				     ADD CONSTRAINT fkLoginManagerJournal_LoginManagerEvent_id
				     FOREIGN KEY (LoginManagerEvent_id) REFERENCES [dbo].LoginManagerEvent(id);

				     ALTER TABLE [dbo].LoginUsersAndLoginRoles
				     ADD CONSTRAINT fkLoginUsersAndLoginRoles_LoginUsers_id
				     FOREIGN KEY (LoginUsers_id) REFERENCES [dbo].LoginUsers(id);


				     ALTER TABLE [dbo].LoginUsersAndLoginRoles
				     ADD CONSTRAINT fkLoginUsersAndLoginRoles_LoginRoles_id
				     FOREIGN KEY (LoginRoles_id) REFERENCES [dbo].LoginRoles(id);

				     ALTER TABLE [dbo].LoginSession
				     ADD CONSTRAINT fkLoginSession_LoginUsers_id
				     FOREIGN KEY (LoginUsers_id) REFERENCES [dbo].LoginUsers(id);

				     ALTER TABLE [dbo].LoginSession
				     ADD CONSTRAINT fkLoginSession_LoginComputer_id
				     FOREIGN KEY (LoginComputer_id) REFERENCES [dbo].LoginComputer(id);

				     ALTER TABLE [dbo].LoginSession
				     ADD CONSTRAINT fkLoginSession_LoginComputerUser_id
				     FOREIGN KEY (LoginComputerUser_id) REFERENCES [dbo].LoginComputerUser(id);

				     ALTER TABLE [dbo].LoginFailed
				     ADD CONSTRAINT fkLoginFailed_LoginComputer_id
				     FOREIGN KEY (LoginComputer_id) REFERENCES [dbo].LoginComputer(id);

				     ALTER TABLE [dbo].LoginFailed
				     ADD CONSTRAINT fkLoginFailed_LoginComputerUser_id
				     FOREIGN KEY (LoginComputerUser_id) REFERENCES [dbo].LoginComputerUser(id);

				     declare @LoginRoles_id int
				     declare @LoginUsers_id int

				     Insert Into LoginRoles
				     (
				     Name,
                     PrivilegesLevel,
				     [description]
				     )
				     values
				     (
				     'Administrator',
                     1,
				     'Administrator ima vse pravice !'
				     )

				     set @LoginRoles_id = IDENT_CURRENT('LoginRoles')

				     Insert Into LoginUsers
				     (
				     [first_name],
				     [last_name],
				     [Identity],
                     [Contact],
				     [username],
				     [password],
				     [enabled],
				     ChangePasswordOnFirstLogin,
				     Time_When_UserSetsItsOwnPassword_FirstTime,
				     Time_When_UserSetsItsOwnPassword_LastTime,
				     PasswordNeverExpires,
				     Maximum_password_age_in_days,
                     NotActiveAfterPasswordExpires
				     )
				     values
				     (
				     null, 
				     null,
				     null,
				     null,
				     'Administrator',
				     null,
				     1,
				     0,
				     null,
                     null,
				     1,
				     90,
                     0
				     )

				     set @LoginUsers_id = IDENT_CURRENT('LoginUsers')

				    insert into  LoginUsersAndLoginRoles
				    (
					     LoginUsers_id,
					     LoginRoles_id
				     )
				     values
				     (
					     @LoginUsers_id,
					     @LoginRoles_id
				     )

                         ";
                            break;
                        case DBConnection.eDBType.MYSQL:
                            LogFile.Error.Show("ERROR:LoginControl does not support MySQL database yet.");
                            return false;

                        case DBConnection.eDBType.SQLITE:
                            LogFile.Error.Show("ERROR:LoginControl does not support SQLITE database yet.");
                            return false;
                        default:
                            LogFile.Error.Show("ERROR:LoginControl does not support ??? database yet.");
                            return false;
                    }
                    object Result = null;
                    string Err = null;
                    if (Login_con.ExecuteNonQuerySQL(sCreateLoginTables, null, ref Result, ref Err))
                    {
                        string drop_view = @"
                IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
                    WHERE TABLE_NAME = 'Login_VIEW')
                BEGIN
                DROP VIEW Login_VIEW
                END;";
                        if (Login_con.ExecuteNonQuerySQL(drop_view, null, ref Result, ref Err))
                        {
                            string create_VIEW = @"Create View Login_VIEW as 
                    select 
                    usr.id as Users_id,
                    usr.first_name,
                    usr.last_name,
                    usr.[Identity],
                    usr.[Contact],
                    usr.username,
                    usr.[password],
                    usr.PasswordNeverExpires,
                    usr.[enabled],
                    usr.Maximum_password_age_in_days,
                    usr.NotActiveAfterPasswordExpires,
                    usr.Time_When_UserSetsItsOwnPassword_FirstTime,
                    usr.Time_When_UserSetsItsOwnPassword_LastTime,
                    usr.ChangePasswordOnFirstLogin,
                    rol.id as Role_id,
                    rol.Name as Role_Name,
                    rol.PrivilegesLevel as Role_PrivilegesLevel,
                    rol.[description] as Role_description
                    from LoginUsersAndLoginRoles usr_rol
                    inner join LoginUsers usr on usr.id = usr_rol.LoginUsers_id
                    inner join LoginRoles rol on rol.id = usr_rol.LoginRoles_id
                    ";

                            if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(create_VIEW, null, ref Err))
                            {
                                string drop_view_LoginManagerJournal_VIEW = @"
                        IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
                            WHERE TABLE_NAME = 'LoginManagerJournal_VIEW')
                        BEGIN
                        DROP VIEW LoginManagerJournal_VIEW
                        END;";
                                if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(drop_view_LoginManagerJournal_VIEW, null, ref Err))
                                {

                                    string sql_LoginManagerJournal_VIEW = @"
                                        create view  LoginManagerJournal_VIEW as
                                        select lmj.[Time],
                                               lme.id as LoginManagerEvent_id,
                                               lme.Name as LoginManagerEvent_Message,
                                               lu.id as LoginUsers_id,
                                               lu.username  
                                              from LoginManagerJournal lmj 
                                        inner join dbo.LoginUsers lu on lu.id = lmj.LoginUsers_id
                                        inner join dbo.LoginManagerEvent lme on lme.id = lmj.LoginManagerEvent_id
                                            ";
                                    if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginManagerJournal_VIEW, null, ref Err))
                                    {
                                        string drop_view_LoginSession_VIEW = @"
                                    IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
                                        WHERE TABLE_NAME = 'LoginSession_VIEW')
                                    BEGIN
                                    DROP VIEW LoginSession_VIEW
                                    END;";

                                        if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(drop_view_LoginSession_VIEW, null, ref Err))
                                        {
                                            string sql_LoginSession_VIEW = @"
									    create view  LoginSession_VIEW as
                                        select
                                              ls.id as LoginSession_id,
                                              ls.LoginUsers_id as LoginUsers_id,
                                              lu.username,
                                              lu.first_name,
										      lu.last_name,
										      lu.[Identity],
										      lu.Contact,
                                              ls.Login_time,
                                              ls.Logout_time,
                                              ls.LoginComputer_id,
                                              lc.ComputerName,
                                              ls.LoginComputerUser_id,
                                              lcu.ComputerUserName,
                                              ls.Logout_Type
                                              from dbo.LoginSession ls
                                        inner join dbo.LoginUsers lu on lu.id = ls.LoginUsers_id
                                        inner join dbo.LoginComputer lc on lc.id = ls.LoginComputer_id
                                        inner join dbo.LoginComputerUser lcu on lcu.id = ls.LoginComputerUser_id
                                        ";

                                            if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginSession_VIEW, null, ref Err))
                                            {
                                                string sql_drop_procedures_and_functions = @"
                                 IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginSession_Start'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginSession_Start
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginSession_End'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginSession_End
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_ChangeData'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_ChangeData
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_ChangeData'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_ChangeData
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_UserChangeItsOwnPassword'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_UserChangeItsOwnPassword
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_Administrator_ChangePassword'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_Administrator_ChangePassword
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_Administrator_ChangePasswordParameters'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_Administrator_ChangePasswordParameters
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_Administrator_AddUser'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_Administrator_AddUser
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_Administrator_DeleteUser'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_Administrator_DeleteUser
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginManager_AddJournal'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginManager_AddJournal
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsers_Administrator_AddRole'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsers_Administrator_AddRole
                                            END
                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'LoginUsersAndLoginRoles_Add'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'PROCEDURE'
                                            )
                                            BEGIN
                                            DROP PROCEDURE dbo.LoginUsersAndLoginRoles_Add
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'Login_Server_GetDate'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'FUNCTION'
                                            )
                                            BEGIN
                                            DROP FUNCTION dbo.Login_Server_GetDate
                                            END

                                IF EXISTS (
                                            SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES
                                            WHERE ROUTINE_NAME = 'Login_PasswordExpired'
                                            AND ROUTINE_SCHEMA = 'dbo'
                                            AND ROUTINE_TYPE = 'FUNCTION'
                                            )
                                            BEGIN
                                            DROP FUNCTION dbo.Login_PasswordExpired
                                            END
                                ";

                                                if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_drop_procedures_and_functions, null, ref Err))
                                                {

                                                    string sql_Login_Server_GetDate = @"
                                     CREATE FUNCTION [dbo].[Login_Server_GetDate]()
                                        RETURNS datetime
                                        WITH EXECUTE AS CALLER
                                        AS
                                        begin
                                            return GetDate()
                                        end
                                        ";
                                                    if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_Login_Server_GetDate, null, ref Err))
                                                    {
                                                        string sql_Login_PasswordExpired = @"
                                        CREATE FUNCTION [dbo].[Login_PasswordExpired](@LoginUsers_id int)
                                            RETURNS bit
                                            --RETURNS @Debug Table(dbg_print nvarchar(100),field_id int)
                                            WITH EXECUTE AS CALLER
                                            AS
                                            begin
	                                            declare @res bit
	                                            declare @last_password_definition datetime
	                                            declare @password_never_expires bit
	                                            declare @NumberOfDays int
	                                            declare @PastDays int
	                                            set @last_password_definition = null;
	                                            select @last_password_definition = lu.Time_When_UserSetsItsOwnPassword_LastTime,
		                                               @NumberOfDays = lu.Maximum_password_age_in_days,
		                                               @password_never_expires = lu.PasswordNeverExpires
	  	                                               from dbo.LoginUsers lu where lu.id = @LoginUsers_id
                                                if (@password_never_expires = 1)
	                                            begin
		                                            set @res  = 0
	                                            end
	                                            else
	                                            begin
		                                            set @PastDays = DATEDIFF(day, @last_password_definition, GETDATE())
		                                            if (@PastDays > @NumberOfDays)
		                                            begin
			                                            set @res  = 1
		                                            end
		                                            else
		                                            begin
			                                            set @res  = 0
		                                            end
	                                            end
	                                            return @res
                                            end
                                    ";
                                                        if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_Login_PasswordExpired, null, ref Err))
                                                        {
                                                            string sql_LoginManager_AddJournal = @"
                                                            CREATE PROCEDURE [dbo].[LoginManager_AddJournal] 
                                                            (
                                                            @LoginUsers_id int,
                                                            @EventMsg nvarchar(1000),
                                                            @Res nvarchar(2000) OUT
                                                            )
                                                            WITH EXECUTE AS CALLER
                                                            AS
                                                            begin
                                                                begin try
                                                                if (LEN(@EventMsg)>0)
	                                                                begin
	                                                                declare @LoginUsers_id_count int
	                                                                set @LoginUsers_id_count = 0
	                                                                select @LoginUsers_id_count = count(*) from dbo.LoginUsers lu where lu.id = @LoginUsers_id
	                                                                if (@LoginUsers_id_count = 1)
	                                                                begin
		                                                                declare @LoginManagerEvent_id int
		                                                                set @LoginManagerEvent_id = null
		                                                                select @LoginManagerEvent_id = le.id from dbo.LoginManagerEvent le where le.Name = @EventMsg
		                                                                if (@LoginManagerEvent_id is null)
		                                                                begin
			                                                                insert into dbo.LoginManagerEvent 
			                                                                (
			                                                                Name
			                                                                )
			                                                                values
			                                                                (
			                                                                @EventMsg
			                                                                )
			                                                                set @LoginManagerEvent_id = IDENT_CURRENT('LoginManagerEvent')
		                                                                end
		                                                                insert into dbo.LoginManagerJournal
		                                                                (
		                                                                LoginUsers_id,
		                                                                LoginManagerEvent_id,
                                                                        [Time]
		                                                                )
		                                                                values
		                                                                (
			                                                                @LoginUsers_id,
			                                                                @LoginManagerEvent_id,
                                                                            GetDate()
		                                                                )
		                                                                set @Res = 'OK'
	                                                                end
	                                                                else
	                                                                begin 
		                                                                set  @Res = 'ERROR 110:LoginManager_AddJournal:User with LoginUsers_id = ' + cast(@LoginUsers_id as nvarchar(20)) + ' not found!'
	                                                                end
                                                                end
                                                                else
                                                                begin
		                                                                set  @Res = 'ERROR 111:LoginManager_AddJournal: Length of string @EventMsg must be > 0 !'
                                                                end
                                                                end try
                                                                begin catch
                                                                    set @Res = 'ERROR 112:LoginManager_AddJournal:' + ERROR_MESSAGE();
                                                                end catch
                                                            end     
                                                            ";

                                                            if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginManager_AddJournal, null, ref Err))
                                                            {
                                                                string sql_LoginSession_Start = @"
    CREATE PROCEDURE [dbo].[LoginSession_Start] (@LoginUsers_id int,@ComputerName nvarchar(260),@ComputerUserName nvarchar(260), @LoginSession_id int OUT, @Res nvarchar(2000) OUT)
                                        WITH EXECUTE AS CALLER
                                        AS
                                        begin
                                            begin try
						                    declare @LoginComputer_id int
						                    declare @LoginComputerUser_id int
						                    set @LoginComputer_id = null
						                    set @LoginComputerUser_id = null
						                    select @LoginComputer_id = lcn.id from dbo.LoginComputer lcn where ComputerName = @ComputerName
						                    if (@LoginComputer_id is null)
						                    begin
							                    insert into dbo.LoginComputer (ComputerName) 
							                    values (@ComputerName)
							                    set @LoginComputer_id = IDENT_CURRENT('LoginComputer')
						                    end

						                    select @LoginComputerUser_id = lcun.id from dbo.LoginComputerUser lcun where ComputerUserName = @ComputerUserName
						                    if (@LoginComputerUser_id is null)
						                    begin
							                    insert into dbo.LoginComputerUser (ComputerUserName) 
							                    values (@ComputerUserName)
							                    set @LoginComputerUser_id = IDENT_CURRENT('LoginComputerUser')
						                    end
										      -- close all opened sessions of this user on target computer
										      declare @DateTimeNow datetime
										      set  @DateTimeNow = GetDate()

										      UPDATE dbo.LoginSession 
										      set Logout_time = @DateTimeNow,
                                                  Logout_Type = 2
										      where (Logout_time is null) and (LoginUsers_id = @LoginUsers_id) and (LoginComputer_id = @LoginComputer_id) and (LoginComputerUser_id = @LoginComputerUser_id)

                                              INSERT INTO dbo.LoginSession
                                              (
                                              LoginUsers_id,
                                              Login_time,
						                      LoginComputer_id,
						                      LoginComputerUser_id
                                              )
                                              Values
                                              (
                                              @LoginUsers_id,
                                              @DateTimeNow,
						                      @LoginComputer_id,
						                      @LoginComputerUser_id
                                              )
                                              set @LoginSession_id = IDENT_CURRENT('LoginSession')
                                              set  @Res = 'OK'
                                            end try
                                            begin catch
                                              set @Res = 'ERROR:' + ERROR_MESSAGE();
                                            end catch
                                        end                                        ";

                                                                if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginSession_Start, null, ref Err))
                                                                {
                                                                    string sql_LoginSession_End = @"
                                          CREATE PROCEDURE [dbo].[LoginSession_End] (@LoginSession_id int, @Res nvarchar(2000) OUT)
                                          WITH EXECUTE AS CALLER
                                          AS
                                          begin
                                                begin try
                                                  UPDATE LoginSession
                                                  set Logout_time = GetDate(),
                                                      Logout_Type = 1
					                              where id = @LoginSession_id
                                                  set  @Res = 'OK'
                                                end try
                                                begin catch
                                                  set @Res = 'ERROR:' + ERROR_MESSAGE();
                                                end catch
                                          end
                                          ";

                                                                    if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginSession_End, null, ref Err))
                                                                    {
                                                                        string sql_LoginUsers_ChangeData = @"
                                             CREATE PROCEDURE [dbo].[LoginUsers_ChangeData] (@LoginUsers_id int,
									                        @first_name nvarchar(250),
									                        @last_name nvarchar(250),
									                        @Identity nvarchar(4000),
										                    @Contact nvarchar(1000),
									                        @Res nvarchar(2000) OUT)

                                                WITH EXECUTE AS CALLER
                                                AS
                                                begin
                                                    begin try

							                            Update [dbo].[LoginUsers]
							                            set [first_name] = @first_name
								                            ,[last_name] = @last_name
								                            ,[Identity] = @Identity
								                            ,[Contact] = @Contact
							                            where  id = @LoginUsers_id

									                    declare @event_msg nvarchar(1000)
									                    declare @myRes nvarchar (1000)
									                    declare @first_nameMsg nvarchar(250)
									                    declare @last_nameMsg nvarchar(250)
									                    declare @IdentityMsg nvarchar(1000)
									                    declare @ContactMsg  nvarchar(250)
									                    set @first_nameMsg = @first_name  if (@first_nameMsg is null) begin	set @first_nameMsg = 'null'	end 
									                    set @last_nameMsg = @last_name  if (@last_nameMsg is null) begin	set @last_nameMsg = 'null'	end 
									                    set @IdentityMsg = @Identity  if (@IdentityMsg is null) begin	set @IdentityMsg = 'null'	end 
									                    set @ContactMsg = @Contact  if (@ContactMsg is null) begin	set @ContactMsg = 'null'	end 
									                    set @event_msg = 'LoginUsers_ChangeData to: first_name = [' +@first_nameMsg + '], last_name = [' + @last_nameMsg + '], Identity = ['+@IdentityMsg + '], Contact = ['+@ContactMsg
									                    exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id,@EventMsg=@event_msg,@Res = @MyRes OUT
                                                        set  @Res = 'OK'
                                                    end try
                                                    begin catch
                                                      set @Res = 'ERROR:' + ERROR_MESSAGE();
                                                    end catch
                                                end
                                             ";
                                                                        if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsers_ChangeData, null, ref Err))
                                                                        {
                                                                            string sql_LoginUsers_UserChangeItsOwnPassword =
                                                                           @"
                                                     CREATE PROCEDURE [dbo].[LoginUsers_UserChangeItsOwnPassword] 
                                                        (
                                                        @LoginUsers_id int,
                                                        @password varbinary(max),
                                                        @Res nvarchar(2000) OUT
                                                        )
                                                    WITH EXECUTE AS CALLER
                                                    AS
                                                    begin
                                                        begin try
                                                            declare @UserName nvarchar(250)
                                                            set @UserName = null
                                                            select @UserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id
                                                            if (@UserName is null)
                                                            begin
	                                                            set @Res = 'Error: UserName for LoginUsers_id = ' + cast(@LoginUsers_id as nvarchar(20))+' not found!'
                                                            end
                                                            else
                                                            begin 
										                        declare @FirstTimePassSet datetime
											                    set @FirstTimePassSet = null;
											                    select @FirstTimePassSet = lu.Time_When_UserSetsItsOwnPassword_FirstTime from [dbo].[LoginUsers] lu where id = @LoginUsers_id
											                    if (@FirstTimePassSet is null)
											                    begin
		                                                            Update [dbo].[LoginUsers]
													                    set [password] = @password,
														                    [Time_When_UserSetsItsOwnPassword_FirstTime] = GetDate()
													                    where  id = @LoginUsers_id
											                    end
	                                                            Update [dbo].[LoginUsers]
		                                                        set [password] = @password,
			                                                        [Time_When_UserSetsItsOwnPassword_LastTime] = GetDate()
		                                                        where  id = @LoginUsers_id
                                                                declare @MyRes nvarchar(1000)
                                                                exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id,@EventMsg='LoginUsers_UserChangeItsOwnPassword',@Res = @MyRes OUT
	                                                            set  @Res = 'OK'
                                                            end
                                                        end try
                                                        begin catch
                                                            set @Res = 'ERROR:' + ERROR_MESSAGE();
                                                        end catch
                                                    end                    
                                                 ";
                                                                            if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsers_UserChangeItsOwnPassword, null, ref Err))
                                                                            {

                                                                                string sql_LoginUsers_Administrator_ChangePassword =
                                                                                @"
                                                CREATE PROCEDURE [dbo].[LoginUsers_Administrator_ChangePassword] 
                                                                                        (
                                                                                        @LoginUsers_id int,
															                            @password varbinary(max),
															                            @LoginUsers_id_Administrator_that_is_changing_password int,
															                            @Res nvarchar(2000) OUT
                                                                                        )


                                                WITH EXECUTE AS CALLER
                                                AS
                                                begin
                                                    begin try
									                declare @MyEventMsg nvarchar(1000)
						                            declare @RoleName nvarchar(250)
						                            declare @UserName nvarchar(250)
						                            set @UserName = null
						                            select @UserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id_Administrator_that_is_changing_password
					                                if (@UserName is null)
						                            begin
							                            set @Res = 'Error: UserName for LoginUsers_id = ' + cast(@LoginUsers_id_Administrator_that_is_changing_password as nvarchar(20))+' not found!'
						                            end
                                                    else
                                                    begin 
                                                        declare @MyRes nvarchar(1000)

						                                set @RoleName = null
						                                select @RoleName = rl.Name from dbo.LoginUsersAndLoginRoles  lur
						                                inner join dbo.LoginRoles rl on  rl.id = lur.LoginRoles_id 
						                                inner join dbo.LoginUsers ru on  ru.id = lur.LoginUsers_id
						                                where (rl.PrivilegesLevel <= 2) and (ru.id = @LoginUsers_id_Administrator_that_is_changing_password)
						                                if (@RoleName is not null)
						                                begin
							                                --'Administrator'
							                                Update [dbo].[LoginUsers]
							                                set [password] = @password,
								                                [Time_When_AdministratorSetsPassword] = GetDate(),
								                                [Administrator_LoginUsers_id] = @LoginUsers_id_Administrator_that_is_changing_password
							                                where  id = @LoginUsers_id
											                set @MyEventMsg = 'LoginUsers_Administrator_ChangePassword for LoginUsers_id = ' + cast(@LoginUsers_id as nvarchar(20))
                                                            exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg=@MyEventMsg,@Res = @MyRes OUT
                                                            set  @Res = 'OK'
						                                end
						                                else
						                                begin
						                                    if (@UserName is not null)
							                                begin
								                                set @Res = 'WARNING: UserName = [' + @UserName + '] has no privileges to change password';
												                set @MyEventMsg = 'LoginUsers_Administrator_ChangePassword:'+@Res
                                                                exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg=@MyEventMsg,@Res = @MyRes OUT
							                                end
						                                end
                                                    end
                                                     
                                                    end try
                                                    begin catch
                                                      set @Res = 'ERROR:' + ERROR_MESSAGE();
                                                    end catch
                                                end                                                            
                                                ";
                                                                                if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsers_Administrator_ChangePassword, null, ref Err))
                                                                                {
                                                                                    string sql_LoginUsers_Administrator_ChangePasswordParameters =
                                                                                    @"

                                                        CREATE PROCEDURE [dbo].[LoginUsers_Administrator_ChangePasswordParameters] 
                                                        (
                                                        @LoginUsers_id int,
						                                @LoginUsers_id_Administrator_that_is_changing_password int,
                                                        @enabled bit,
						                                @PasswordNeverExpires bit,
						                                @ChangePasswordOnFirstLogin bit,
						                                @Maximum_password_age_in_days int,
                                                        @NotActiveAfterPasswordExpires bit,
						                                @Res nvarchar(2000) OUT
                                                        )


                                                    WITH EXECUTE AS CALLER
                                                    AS
                                                    begin
                                                        begin try
										                declare @MyEventMsg nvarchar(1000)
						                                declare @RoleName nvarchar(250)
						                                declare @UserName nvarchar(250)
						                                set @UserName = null
						                                select @UserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id_Administrator_that_is_changing_password
					                                    if (@UserName is null)
						                                begin
							                                set @Res = 'Error: UserName for LoginUsers_id = ' + cast(@LoginUsers_id_Administrator_that_is_changing_password as nvarchar(20))+' not found!'
						                                end
                                                        else
                                                        begin 
                                                            declare @MyRes nvarchar(1000)
						                                    set @RoleName = null
						                                    select @RoleName = rl.Name from dbo.LoginUsersAndLoginRoles  lur
						                                    inner join dbo.LoginRoles rl on  rl.id = lur.LoginRoles_id 
						                                    inner join dbo.LoginUsers ru on  ru.id = lur.LoginUsers_id
						                                    where (rl.PrivilegesLevel <= 2) and (ru.id = @LoginUsers_id_Administrator_that_is_changing_password)
						                                    if (@RoleName is not null)
						                                    begin
							                                    --'Administrator'
							                                    Update [dbo].[LoginUsers]
							                                    set [enabled] = enabled,
                                                                    [PasswordNeverExpires] = @PasswordNeverExpires,
								                                    [ChangePasswordOnFirstLogin] = @ChangePasswordOnFirstLogin,
								                                    [Maximum_password_age_in_days] = @Maximum_password_age_in_days,
                                                                    [NotActiveAfterPasswordExpires] = @NotActiveAfterPasswordExpires
							                                    where  id = @LoginUsers_id
                                                                declare @enabledMsg nvarchar(20)
                                                                declare @PasswordNeverExpiresMsg nvarchar(20)
                                                                declare @NotActiveAfterPasswordExpiresMsg nvarchar(20)
                                                                declare @Maximum_password_age_in_daysMsg nvarchar(20)
                                                                set @Maximum_password_age_in_daysMsg = cast(@Maximum_password_age_in_days as nvarchar(20))
                                                                if @enabled = 1 begin set @enabledMsg = '1' end else begin set @enabledMsg = '0' end
                                                                if @PasswordNeverExpires = 1 begin set @PasswordNeverExpiresMsg = '1' end else begin set @PasswordNeverExpiresMsg = '0' end
                                                                if @NotActiveAfterPasswordExpires = 1 begin set @NotActiveAfterPasswordExpiresMsg = '1' end else begin set @NotActiveAfterPasswordExpiresMsg = '0' end
        										
                                                                set @MyEventMsg = 'LoginUsers_Administrator_ChangePasswordParameters for LoginUsers_id = ' + cast(@LoginUsers_id as nvarchar(20))+ ', enabled = '+ @enabledMsg + ', PasswordNeverExpires = ' + @PasswordNeverExpiresMsg + ', NotActiveAfterPasswordExpiresMsg = ' + @NotActiveAfterPasswordExpiresMsg + ', Maximum_password_age = '+ @Maximum_password_age_in_daysMsg 

                                                                exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg=@MyEventMsg,@Res = @MyRes OUT
                                                                set  @Res = 'OK'
						                                    end
						                                    else
						                                    begin
						                                        if (@UserName is not null)
							                                    begin
								                                    set @Res = 'WARNING: UserName = [' + @UserName + '] has no privileges to change password';
													                set @MyEventMsg = 'LoginUsers_Administrator_ChangePassword:'+ @Res
                                                                    exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg=@MyEventMsg,@Res = @MyRes OUT
							                                    end
						                                    end
                                                        end
                                                         
                                                        end try
                                                        begin catch
                                                          set @Res = 'ERROR:' + ERROR_MESSAGE();
                                                        end catch
                                                    end                                                            
                                                    ";
                                                                                    if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsers_Administrator_ChangePasswordParameters, null, ref Err))
                                                                                    {
                                                                                        string sql_LoginUsers_Administrator_AddUser =
                                                                                         @"
                                                    CREATE PROCEDURE [dbo].[LoginUsers_Administrator_AddUser] 
                                                    (
									                    @username nvarchar(250),
									                    @password varbinary(Max),
									                    @enabled bit,
									                    @first_name nvarchar(250),
									                    @last_name nvarchar(250),
									                    @Identity nvarchar(4000),
									                    @Contact nvarchar(1000),
									                    @LoginUsers_id_Administrator_that_is_changing_password int,
									                    @PasswordNeverExpires bit,
									                    @ChangePasswordOnFirstLogin bit,
									                    @Maximum_password_age_in_days int,
                                                        @NotActiveAfterPasswordExpires bit,
									                    @LoginUsers_id int OUT,
									                    @Res nvarchar(2000) OUT
                                                    )


                                                    WITH EXECUTE AS CALLER
                                                    AS
                                                    begin
                                                        begin try
										                declare @MyEventMsg nvarchar(1000)
                                                        declare @MyRes nvarchar(1000)
									                    set @LoginUsers_id = -1
						                                declare @RoleName nvarchar(250)
						                                declare @AdministratorUserName nvarchar(250)
						                                set @AdministratorUserName = null
						                                select @AdministratorUserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id_Administrator_that_is_changing_password
					                                    if (@AdministratorUserName is null)
						                                begin
							                                set @Res = 'Error 100: UserName for LoginUsers_id = ' + cast(@LoginUsers_id_Administrator_that_is_changing_password as nvarchar(20))+' not found!'
						                                end
                                                        else
                                                        begin 

						                                    set @RoleName = null
						                                    select @RoleName = rl.Name from dbo.LoginUsersAndLoginRoles  lur
						                                    inner join dbo.LoginRoles rl on  rl.id = lur.LoginRoles_id 
						                                    inner join dbo.LoginUsers ru on  ru.id = lur.LoginUsers_id
						                                    where (rl.PrivilegesLevel <= 2) and (ru.id = @LoginUsers_id_Administrator_that_is_changing_password)
						                                    if (@RoleName is not null)
						                                    begin
							                                    --'Administrator'
											                    INSERT INTO [dbo].[LoginUsers]
													                       (
													                       [first_name]
													                       ,[last_name]
													                       ,[Identity]
													                       ,[Contact]
													                       ,[username]
													                       ,[password]
													                       ,[enabled]
													                       ,[ChangePasswordOnFirstLogin]
													                       ,[Time_When_AdministratorSetsPassword]
													                       ,[Administrator_LoginUsers_id]
													                       ,[Time_When_UserSetsItsOwnPassword_FirstTime]
													                       ,[Time_When_UserSetsItsOwnPassword_LastTime]
													                       ,[PasswordNeverExpires]
													                       ,[Maximum_password_age_in_days]
                                                                           ,[NotActiveAfterPasswordExpires]
													                       )
												                     VALUES
													                       (@first_name,
													                       @last_name,
													                       @Identity,
													                       @Contact,
													                       @username,
													                       @password,
													                       @enabled,
													                       @ChangePasswordOnFirstLogin,
													                       GetDate(),
													                       @LoginUsers_id_Administrator_that_is_changing_password,
													                       null,
													                       null,
													                       @PasswordNeverExpires,
													                       @Maximum_password_age_in_days,
                                                                           @NotActiveAfterPasswordExpires
													                       )
											                    set @LoginUsers_id  = IDENT_CURRENT('LoginUsers')
												                set @MyEventMsg = 'LoginUsers_Administrator_AddUser: username = ' + @username
                                                                exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg=@MyEventMsg,@Res = @MyRes OUT

                                                                set  @Res = 'OK'
						                                    end
						                                    else
						                                    begin
						                                        if (@UserName is not null)
							                                    begin
								                                    set @Res = 'WARNING 100: UserName = [' + @AdministratorUserName + '] has no privileges to add user';
													                set @MyEventMsg = 'LoginUsers_Administrator_AddUser:'+@Res
                                                                    exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg= @MyEventMsg,@Res = @MyRes OUT
							                                    end
						                                    end
                                                        end
                                                         
                                                        end try
                                                        begin catch
                                                          set @Res = 'ERROR 101:' + ERROR_MESSAGE();
                                                        end catch
                                                    end                                                            
                                                            ";
                                                                                        if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsers_Administrator_AddUser, null, ref Err))
                                                                                        {
                                                                                            string sql_LoginUsers_Administrator_DeleteUser =
                                                                                           @"

                                                            CREATE PROCEDURE [dbo].[LoginUsers_Administrator_DeleteUser] 
                                                            (
									                          @LoginUsers_id int,
									                          @LoginUsers_id_Administrator_that_is_changing_password int,
									                          @Res nvarchar(2000) OUT
                                                            )

                                                        WITH EXECUTE AS CALLER
                                                        AS
                                                        begin
                                                            begin try
                                                            declare @MyEventMsg nvarchar(1000)
                                                            declare @MyRes nvarchar(1000)
						                                    declare @RoleName nvarchar(250)
						                                    declare @AdministratorUserName nvarchar(250)
						                                    set @AdministratorUserName = null
						                                    select @AdministratorUserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id_Administrator_that_is_changing_password
					                                        if (@AdministratorUserName is null)
						                                    begin
							                                    set @Res = 'Error 102: UserName for LoginUsers_id = ' + cast(@LoginUsers_id_Administrator_that_is_changing_password as nvarchar(20))+' not found!'
						                                    end
                                                            else
                                                            begin 

						                                        set @RoleName = null
						                                        select @RoleName = rl.Name from dbo.LoginUsersAndLoginRoles  lur
						                                        inner join dbo.LoginRoles rl on  rl.id = lur.LoginRoles_id 
						                                        inner join dbo.LoginUsers ru on  ru.id = lur.LoginUsers_id
						                                        where (rl.PrivilegesLevel <= 2) and (ru.id = @LoginUsers_id_Administrator_that_is_changing_password)
						                                        if (@RoleName is not null)
						                                        begin
							                                        --'Administrator'
                                                                    declare @username nvarchar(250)
                                                                    select @username = username from dbo.LoginUsers where id = @LoginUsers_id
                                                                    if (@username is null) begin set @username = null end
                                                                    
											                        delete dbo.LoginUsers  where id = @LoginUsers_id
                                                                    set @MyEventMsg = 'LoginUsers_Administrator_DeleteUser: username ='+@username
                                                                    exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg=@MyEventMsg,@Res = @MyRes OUT

                                                                    set  @Res = 'OK'
						                                        end
						                                        else
						                                        begin
						                                            if (@AdministratorUserName is not null)
							                                        begin
								                                        set @Res = 'WARNING 101: UserName = [' + @AdministratorUserName + '] has no privileges to delete user';
                                                                        set @MyEventMsg = 'LoginUsers_Administrator_DeleteUser:'+@Res
                                                                        exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator_that_is_changing_password,@EventMsg=@MyEventMsg,@Res = @MyRes OUT
							                                        end
						                                        end
                                                            end
                                                             
                                                            end try
                                                            begin catch
                                                              set @Res = 'ERROR 103:' + ERROR_MESSAGE();
                                                            end catch
                                                            end
                                                            ";
                                                                                            if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsers_Administrator_DeleteUser, null, ref Err))
                                                                                            {
                                                                                                string sql_LoginUsers_Administrator_AddRole = @"
                                                                                                CREATE PROCEDURE [dbo].[LoginUsers_Administrator_AddRole] 
                                                                                                (
		                                                                                            @NewRoleName nvarchar(250),
		                                                                                            @PrivilegesLeveL int,
		                                                                                            @description nvarchar(2000),
		                                                                                            @LoginUsers_id_Administrator int,
		                                                                                            @LoginRole_id int OUT,
		                                                                                            @Res nvarchar(2000) OUT
                                                                                                )


                                                                                                WITH EXECUTE AS CALLER
                                                                                                AS
                                                                                                begin
                                                                                                    begin try
		                                                                                            declare @NewLoginRole_id int
		                                                                                            declare @MyEventMsg nvarchar(1000)
                                                                                                    declare @MyRes nvarchar(1000)
		                                                                                            declare @RoleName nvarchar(250)
		                                                                                            set @LoginRole_id = -1
		                                                                                            declare @AdministratorUserName nvarchar(250)
		                                                                                            set @AdministratorUserName = null
		                                                                                            select @AdministratorUserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id_Administrator
		                                                                                            if (@AdministratorUserName is null)
		                                                                                            begin
			                                                                                            set @Res = 'Error 120:LoginUsers_Administrator_AddRole:UserName for LoginUsers_id = ' + cast(@LoginUsers_id_Administrator as nvarchar(20))+' not found!'
		                                                                                            end
                                                                                                    else
                                                                                                    begin 

			                                                                                            set @RoleName = null
			                                                                                            select @RoleName = rl.Name from dbo.LoginUsersAndLoginRoles  lur
			                                                                                            inner join dbo.LoginRoles rl on  rl.id = lur.LoginRoles_id 
			                                                                                            inner join dbo.LoginUsers ru on  ru.id = lur.LoginUsers_id
			                                                                                            where (rl.PrivilegesLevel <= 2) and (ru.id = @LoginUsers_id_Administrator)
			                                                                                            if (@RoleName is not null)
			                                                                                            begin
				                                                                                            --'Administrator'
				                                                                                            set @NewLoginRole_id = null
				                                                                                            select @NewLoginRole_id  = lr.id from dbo.LoginRoles lr where lr.Name = @NewRoleName
				                                                                                            if (@NewLoginRole_id is not null)
				                                                                                            begin
					                                                                                            set @LoginRole_id = @NewLoginRole_id
					                                                                                            set @Res = 'Error 121:LoginUsers_Administrator_AddRole:RoleName = ' + @NewRoleName + ' allready exist int LoginRole_id = ' +  cast(@LoginRole_id as nvarchar(20))
					                                                                                            set @MyEventMsg = 'LoginUsers_Administrator_AddRole:'+@Res
                                                                                                                exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator,@EventMsg= @MyEventMsg,@Res = @MyRes OUT
				                                                                                            end
				                                                                                            else
				                                                                                            begin

					                                                                                            INSERT INTO [dbo].[LoginRoles]
								                                                                                            (
								                                                                                            [Name]
								                                                                                            ,[PrivilegesLevel]
								                                                                                            ,[description]
								                                                                                            )
							                                                                                            VALUES
								                                                                                            (@NewRoleName,
								                                                                                            @PrivilegesLeveL,
								                                                                                            @description
								                                                                                            )
					                                                                                            set @LoginRole_id  = IDENT_CURRENT('LoginRoles')
					                                                                                            set @MyEventMsg = 'LoginUsers_Administrator_AddRoles: LoginRoles.Name = ' + @NewRoleName
					                                                                                            exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator,@EventMsg=@MyEventMsg,@Res = @MyRes OUT

					                                                                                            set  @Res = 'OK'
				                                                                                            end 
			                                                                                            end
			                                                                                            else
			                                                                                            begin
				                                                                                            if (@AdministratorUserName is not null)
				                                                                                            begin
					                                                                                            set @Res = 'WARNING 122:LoginUsers_Administrator_AddRole: UserName = [' + @AdministratorUserName + '] has no privileges to add user';
					                                                                                            set @MyEventMsg = 'LoginUsers_Administrator_AddUser:'+@Res
                                                                                                                exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator,@EventMsg= @MyEventMsg,@Res = @MyRes OUT
				                                                                                            end
			                                                                                            end
                                                                                                    end
                                                                                                                                                     
                                                                                                    end try
                                                                                                    begin catch
                                                                                                        set @Res = 'ERROR 123:LoginUsers_Administrator_AddRole:' + ERROR_MESSAGE();
                                                                                                    end catch
                                                                                                end                                                            
                                                                                                  ";
                                                                                                if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsers_Administrator_AddRole, null, ref Err))
                                                                                                {
                                                                                                    string sql_LoginUsersAndLoginRoles_Add = @"
                                                                                                        CREATE PROCEDURE [dbo].[LoginUsersAndLoginRoles_Add] 
                                                                                                        (
		                                                                                                    @LoginUsers_id int,
		                                                                                                    @LoginRoles_id int,
		                                                                                                    @LoginUsers_id_Administrator int,
		                                                                                                    @LoginUsersAndLoginRoles_id int OUT,
		                                                                                                    @Res nvarchar(2000) OUT
                                                                                                        )


                                                                                                        WITH EXECUTE AS CALLER
                                                                                                        AS
                                                                                                        begin
                                                                                                            begin try
		                                                                                                    declare @NewoginUsersAndLoginRoles_id int
		                                                                                                    declare @MyEventMsg nvarchar(1000)
                                                                                                            declare @MyRes nvarchar(1000)
		                                                                                                    declare @RoleNameAdministrator nvarchar(250)
		                                                                                                    declare @RoleName nvarchar(250)
		                                                                                                    declare @UserName nvarchar(250)
		                                                                                                    set @UserName = null
		                                                                                                    set @LoginUsersAndLoginRoles_id = -1
		                                                                                                    declare @AdministratorUserName nvarchar(250)
		                                                                                                    set @AdministratorUserName = null
		                                                                                                    set @RoleName = null
		                                                                                                    select @AdministratorUserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id_Administrator
		                                                                                                    if (@AdministratorUserName is null)
		                                                                                                    begin
			                                                                                                    set @Res = 'Error 130:LoginUsersAndLoginRoles_Add:UserName for LoginUsers_id = ' + cast(@LoginUsers_id_Administrator as nvarchar(20))+' not found!'
		                                                                                                    end
                                                                                                            else
                                                                                                            begin 

			                                                                                                    set @RoleNameAdministrator = null
			                                                                                                    select @RoleNameAdministrator = rl.Name from dbo.LoginUsersAndLoginRoles  lur
			                                                                                                    inner join dbo.LoginRoles rl on  rl.id = lur.LoginRoles_id 
			                                                                                                    inner join dbo.LoginUsers ru on  ru.id = lur.LoginUsers_id
			                                                                                                    where (rl.PrivilegesLevel <= 2) and (ru.id = @LoginUsers_id_Administrator)
			                                                                                                    if (@RoleNameAdministrator is not null)
			                                                                                                    begin
				                                                                                                    --'Administrator'
				                                                                                                    select @UserName = lu.username from dbo.LoginUsers lu where lu.id = @LoginUsers_id
				                                                                                                    if (@UserName is not null)
				                                                                                                    begin

					                                                                                                    set @NewoginUsersAndLoginRoles_id = null
					                                                                                                    select @NewoginUsersAndLoginRoles_id  = lur.id,
						                                                                                                       @RoleName = lr.Name
					                                                                                                    from dbo.LoginUsersAndLoginRoles lur 
					                                                                                                    inner join dbo.LoginRoles lr on lr.id = lur.LoginRoles_id
					                                                                                                    where (lur.LoginUsers_id = @LoginUsers_id) and  (lur.LoginRoles_id = @LoginRoles_id)

					                                                                                                    if (@NewoginUsersAndLoginRoles_id is not null)
					                                                                                                    begin
						                                                                                                    set @LoginUsersAndLoginRoles_id = @NewoginUsersAndLoginRoles_id
						                                                                                                    set @Res = 'WARNING 131:LoginUsersAndLoginRoles_Add: Access right  = [' + @RoleName + '] allready exist for username = ' +  @UserName
						                                                                                                    set @MyEventMsg = @Res
						                                                                                                    exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator,@EventMsg= @MyEventMsg,@Res = @MyRes OUT
					                                                                                                    end
					                                                                                                    else
					                                                                                                    begin

						                                                                                                    INSERT INTO [dbo].[LoginUsersAndLoginRoles]
									                                                                                                    (
									                                                                                                    [LoginUsers_id]
									                                                                                                    ,[LoginRoles_id]
									                                                                                                    )
								                                                                                                    VALUES
									                                                                                                    (
									                                                                                                    @LoginUsers_id,
									                                                                                                    @LoginRoles_id
									                                                                                                    )
						                                                                                                    set @LoginUsersAndLoginRoles_id  = IDENT_CURRENT('LoginUsersAndLoginRoles')
						                                                                                                    set @MyEventMsg = 'LoginUsersAndLoginRoles_Add: Access rigtht = [' + @RoleName + '] for user ['+@UserName+'] added OK.'
						                                                                                                    exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator,@EventMsg=@MyEventMsg,@Res = @MyRes OUT

						                                                                                                    set  @Res = 'OK'
					                                                                                                    end 
				                                                                                                    end
				                                                                                                    else
				                                                                                                    begin
				                                                                                                    -- username is null
		                                                                                                                set @Res = 'ERROR 133:LoginUsersAndLoginRoles_Add: No username for LoginUsers_id = ' + cast(@LoginUsers_id as nvarchar(20));
				                                                                                                    end
			                                                                                                    end
			                                                                                                    else
			                                                                                                    begin
				                                                                                                    if (@AdministratorUserName is not null)
				                                                                                                    begin
					                                                                                                    set @Res = 'WARNING 132:LoginUsersAndLoginRoles_Add: UserName = [' + @AdministratorUserName + '] has no privileges to add user';
					                                                                                                    set @MyEventMsg = 'LoginUsersAndLoginRoles_Add:'+@Res
                                                                                                                        exec LoginManager_AddJournal @LoginUsers_id = @LoginUsers_id_Administrator,@EventMsg= @MyEventMsg,@Res = @MyRes OUT
				                                                                                                    end
			                                                                                                    end
                                                                                                            end
                                                                                                                                                             
                                                                                                            end try
                                                                                                            begin catch
                                                                                                                set @Res = 'ERROR 134:LoginUsersAndLoginRoles_Add:' + ERROR_MESSAGE();
                                                                                                            end catch
                                                                                                        end                                                            
                                                                                                    ";
                                                                                                    if (Login_con.ExecuteNonQuerySQL_NoMultiTrans(sql_LoginUsersAndLoginRoles_Add, null, ref Err))
                                                                                                    {

                                                                                                        return true;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        LogFile.Error.Show("ERROR:LoginControl sql_LoginUsersAndLoginRoles_Add :" + Err);
                                                                                                        return false;
                                                                                                    }

                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_AddRole :" + Err);
                                                                                                    return false;
                                                                                                }

                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_DeleteUser :" + Err);
                                                                                                return false;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_AddUser :" + Err);
                                                                                            return false;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_ChangePasswordParameters :" + Err);
                                                                                        return false;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_Administrator_ChangePassword :" + Err);
                                                                                    return false;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_ChangePassword :" + Err);
                                                                                return false;
                                                                            }

                                                                        }
                                                                        else
                                                                        {
                                                                            LogFile.Error.Show("ERROR:LoginControl sql_LoginUsers_ChangeData :" + Err);
                                                                            return false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        LogFile.Error.Show("ERROR:LoginControl sql_LoginSession_End :" + Err);
                                                                        return false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    LogFile.Error.Show("ERROR:LoginControl sql_LoginSession_Start :" + Err);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginManager_AddJournal :" + Err);
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:LoginControl sql_Login_PasswordExpired :" + Err);
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:LoginControl sql_Login_Server_GetDate :" + Err);
                                                        return false;
                                                    }

                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:LoginControl sql_drop_procedures_and_functions :" + Err);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:LoginControl sql_LoginSession_VIEW :" + Err);
                                                return false;

                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:LoginControl drop_view_LoginSession_VIEW :" + Err);
                                            return false;

                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:LoginControl create_view_LoginManagerJournal_VIEW :" + Err);
                                        return false;

                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:LoginControl drop_view_LoginManagerJournal_VIEW :" + Err);
                                    return false;

                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:LoginControl create_View :" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:LoginControl drop_view :" + Err);
                            return false;

                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:LoginControl:" + Err);
                        return false;
                    }
                }
                else
                {
                    return false; // Drop Tables failed
                }
            }
            else
            {
                return false; // Drop Constraints failed
            }
   }




        internal bool Read_Login_VIEW(ref string Err)
        {
            if (m_Login_VIEW == null)
            {
                m_Login_VIEW = new LoginDB_DataSet.Login_VIEW(Login_con);
            }
            m_Login_VIEW.Clear();
            m_Login_VIEW.select.all(true);
            if (m_Login_VIEW.Read(ref Err))
            {
                if (m_Login_VIEW.dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    Err = "ERROR: Some Login Tables are empty !";
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public bool Init(Form pParentForm, DBConnection con,object DBParam,int Language_id, ref string Err )
        {
            LoginDB_DataSet.DynSettings.LanguageID = Language_id;
            Login_con = con;
            if (CheckConnection(pParentForm))
            {
                if (this.DataTableCreationMode == eDataTableCreationMode.NONE)
                {
                    return GetTables(ref Err);
                }
                else
                {
                    if (DropConstraints(Login_con))
                    {
                        if (DropTables(Login_con))
                        {
                            return GetTables(ref  Err);
                        }
                    }
                    return false;
                }
                
            }
            else
            {
                if (Login_con.MakeDataBaseConnection(pParentForm, DBParam))
                {
                    return GetTables(ref Err);
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Login()
        {
            string Err = null;
            if (Read_Login_VIEW(ref Err))
            {
                if (dtLogin_Vaild(ref Err))
                {
                    return DoLogin();
                }
                else
                {
                    // Login as SuperAdministrator to edit Login Tables !
                    LoginSuperAdministratorForm lgsForm = new LoginSuperAdministratorForm();
                    if (lgsForm.ShowDialog() == DialogResult.OK)
                    {
                        DataRow[] dr = m_Login_VIEW.dt.Select(LoginDB_DataSet.Login_VIEW.username.name + " = 'Administrator'");
                        if (dr != null)
                        {
                            m_LoginData.m_LoginUsers_id = (int) dr[0][LoginDB_DataSet.Login_VIEW.Users_id.name];

                            UserManager edtLogin = new UserManager(null,this);
                            if (edtLogin.ShowDialog() == DialogResult.OK)
                            {
                                if (Read_Login_VIEW(ref Err))
                                {
                                    if (dtLogin_Vaild(ref Err))
                                    {
                                        return DoLogin();
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:LoginControl:Login: Read Login data Tables are not valid:" + Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:LoginControl:Login: Read Login_VIEW Err=:" + Err);
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
                return false;
            }
            else
            {
                LogFile.Error.Show("ERROR LOGIN !: Read Login Tables :" + Err);
                return false;
            }
        }



        private bool DoLogin()
        {
            LoginForm loginf = new LoginForm(this);
            if (loginf.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Logout()
        {
            return DoLogout();
        }

        private bool DoLogout()
        {
            string Err = null;
            if (m_LoginData.m_LoginSession_id >= 0)
            {
                if (m_LoginData.m_LoginUsers_id >= 0)
                {
                    string Res = null;
                    LoginDB_DataSet.LoginDB_DataSet_Procedures logProc = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
                    logProc.LoginSession_End(m_LoginData.m_LoginSession_id, ref Res, ref Err);
                    if (Res.Equals("OK"))
                    {
                        return true;
                    }
                    else
                    {
                        if (Err == null)
                        {
                            Err = "null";
                        }
                        LogFile.Error.Show("Error:DoLogout:LoginSession_End:Res=" + Res + ", Err=" + Err);
                    }
                }
            }
            return false;
        }

        private bool dtLogin_Vaild(ref string Err)
        {

            if (m_Login_VIEW.dt.Rows.Count > 0)
            {
                if (m_Login_VIEW.dt.Rows[0]["password"].GetType() != typeof(DBNull))
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
                Err = "Error : dtLogin Table is empty (dtLogin.Rows.Count = 0)!";
                return false;
            }
        }




        internal bool PasswordMatch(byte[] encrypted_password, string password)
        {
            byte[] encrypted_password2 = CalculateSHA256(password);

            if ((encrypted_password.Length == encrypted_password2.Length))
            {
                bool passwordMatch = true;
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



        internal bool LoginRoles_Get(int LoginUser_id,List<Role> roles, ref string Err)
        {
            LoginDB_DataSet.Login_VIEW xLogin_VIEW = new LoginDB_DataSet.Login_VIEW(Login_con);
            xLogin_VIEW.Clear();
            xLogin_VIEW.select.all(false);
            xLogin_VIEW.select.Role_id = true;
            xLogin_VIEW.select.Role_Name = true;
            xLogin_VIEW.select.Role_PrivilegesLevel = true;
            xLogin_VIEW.select.Role_description = true;
            xLogin_VIEW.where.all(false);
            xLogin_VIEW.where.Users_id = true;
            xLogin_VIEW.where.Users_id_Expression(" = " + LoginUser_id.ToString());
            if (xLogin_VIEW.Read(ref Err))
            {
                roles.Clear();
                foreach (DataRow dr in xLogin_VIEW.dt.Rows)
                {
                    int LoginRole_id = -1;
                    string LoginRole_Name = null;
                    int LoginRole_PrivilegesLevel = -1;
                    string LoginRole_description = "";
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_id.name].GetType()== typeof(int))
                    {
                        LoginRole_id = (int)dr[LoginDB_DataSet.Login_VIEW.Role_id.name];
                    }
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_Name.name].GetType() == typeof(string))
                    {
                        LoginRole_Name = (string)dr[LoginDB_DataSet.Login_VIEW.Role_Name.name];
                    }
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_PrivilegesLevel.name].GetType() == typeof(int))
                    {
                        LoginRole_PrivilegesLevel = (int)dr[LoginDB_DataSet.Login_VIEW.Role_PrivilegesLevel.name];
                    }
                    if (dr[LoginDB_DataSet.Login_VIEW.Role_description.name].GetType() == typeof(string))
                    {
                        LoginRole_description = (string)dr[LoginDB_DataSet.Login_VIEW.Role_description.name];
                    }

                    if ((LoginRole_Name != null) && (LoginRole_PrivilegesLevel >= 0))
                    {
                        Role role = new Role();
                        role.id = LoginRole_id;
                        role.Name = LoginRole_Name;
                        role.PrivilegesLevel = LoginRole_PrivilegesLevel;
                        role.description = LoginRole_description;
                        roles.Add(role);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_UserManager_Click(object sender, EventArgs e)
        {
            UserManager usr_mangaer = new UserManager(this.ParentForm, this);
            usr_mangaer.ShowDialog();
        }

        private void btn_UserInfo_Click(object sender, EventArgs e)
        {
            UserInfoForm usrinfo = new UserInfoForm(this);
            usrinfo.ShowDialog();
        }

        internal bool LoginData_Get(LoginDB_DataSet.LoginUsers LoginUsers, ref string Err)
        {
            m_LoginData.m_LoginUsers_id = LoginUsers.o_id.id_;
            m_LoginData.m_UserName = LoginUsers.o_username.username_;
            m_LoginData.m_FirstName = LoginUsers.o_first_name.first_name_;
            m_LoginData.m_LastName = LoginUsers.o_last_name.last_name_;
            m_LoginData.m_Identity = LoginUsers.o_Identity.Identity_;
            m_LoginData.m_Contact = m_LoginData.m_Contact;

            m_LoginData.m_PasswordNeverExpires = LoginUsers.o_PasswordNeverExpires.PasswordNeverExpires_;
            m_LoginData.m_NotActiveAfterPasswordExpires = LoginUsers.o_NotActiveAfterPasswordExpires.NotActiveAfterPasswordExpires_;
            m_LoginData.NumberOfDaysAfterPasswordExpires = LoginUsers.o_Maximum_password_age_in_days.Maximum_password_age_in_days_;

            lbl_username.Text = lngRPM.s_UserName.s + ":" + m_LoginData.m_UserName;

            try
            {
                m_LoginData.Time_When_UserSetsItsOwnPassword_LastTime = LoginUsers.o_Time_When_UserSetsItsOwnPassword_LastTime.Time_When_UserSetsItsOwnPassword_LastTime_;
            }
            catch
            {
                m_LoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.MinValue;
            }
            
            if (LoginRoles_Get(LoginUsers.o_id.id_,m_LoginData.m_Roles, ref Err))
            {
                if (IsAdministrator)
                {
                    btn_UserManager.Visible = true;
                }
                else
                {
                    btn_UserManager.Visible = false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool my_AddRole(string LoginRole_Name, int LoginRole_PrivilegesLevel, string LoginRole_description, ref int LoginRole_id)
        {
            if (m_LoginDB_DataSet_Procedures == null)
            {
                m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            }

            string Res = null;
            string Err = null;
            m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_AddRole(LoginRole_Name, LoginRole_PrivilegesLevel, LoginRole_description,1, ref LoginRole_id,ref Res, ref Err);
            if (Res.Equals("OK"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:my_AddRole:LoginUsers_Administrator_AddRole:Res="+Res);
            }
            return false;
        }

        public bool AddRole(string LoginRole_Name, int LoginRole_PrivilegesLevel, string LoginRole_description, ref int LoginRole_id)
        {
            if (m_eDataTableCreationMode != eDataTableCreationMode.NONE)
            {
                return my_AddRole(LoginRole_Name,LoginRole_PrivilegesLevel, LoginRole_description, ref LoginRole_id);

            }
            else
            {
                if (IsAdministrator)
                {
                    return my_AddRole(LoginRole_Name, LoginRole_PrivilegesLevel, LoginRole_description, ref LoginRole_id);
                }
                else
                {
                    LogFile.Error.Show("WARNING:LoginControl:AddRole: You can not add roles if DataTableCreationMode property is NONE  or Administrator is not logged in !");
                    return false;
                }
            }
        }

        public bool AddUser(string username, string frist_name, string last_name, string Identity, string Contact, bool enabled, bool PasswordNeverExpires, bool NotActiveAfterPasswordExpires, int NumberOfDaysPasswordIsValid, ref int LoginUsers_id)
        {
            if (m_LoginDB_DataSet_Procedures == null)
            {
                m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            }

            string Res = null;
            string Err = null;
            byte[] pass = CalculateSHA256("123");
            m_LoginDB_DataSet_Procedures.LoginUsers_Administrator_AddUser(username, pass, true, frist_name, last_name, Identity, Contact, 1, true, true, 90, false, ref LoginUsers_id, ref Res, ref Err);
            if (Res.Equals("OK"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AddUser:LoginUsers_Administrator_AddUser:Res=" + Res);
            }
            return false;
        }

        public bool LoginUsersAndLoginRoles_Add(int LoginUsers_id, int LoginRoles_id, ref int LoginUsersAndLoginRoles_id)
        {
            if (m_LoginDB_DataSet_Procedures == null)
            {
                m_LoginDB_DataSet_Procedures = new LoginDB_DataSet.LoginDB_DataSet_Procedures(Login_con);
            }

            string Res = null;
            string Err = null;
            m_LoginDB_DataSet_Procedures.LoginUsersAndLoginRoles_Add(LoginUsers_id, LoginRoles_id, 1, ref LoginUsersAndLoginRoles_id, ref Res, ref Err);
            if (Res.Equals("OK"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:LoginUsersAndLoginRoles_Add:LoginUsersAndLoginRoles_Add:Res=" + Res);
            }
            return false;
        }

        public bool ContainsRole(string RoleName)
        {
            foreach (Role role in m_LoginData.m_Roles)
            {
                if (RoleName.Equals(role.Name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsRoles(string[] sroles)
        {
            foreach (Role role in m_LoginData.m_Roles)
            {
                foreach (string s in sroles)
                {
                    if (s.Equals(role.Name))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class Role
    {
        public int id;
        public string Name;
        public int PrivilegesLevel;
        public string description;
    }

    public class LoginData
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

        internal List<Role> m_Roles = new List<Role>();
        internal bool IsAdministrator
        {
            get
            {
                foreach (Role role in m_Roles)
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
