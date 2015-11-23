
using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using LoginaDatasetCommonClasses;
namespace LoginDB_DataSet
{
        public static class DynSettings 
        {
            public static int LanguageID=0;
        }

        public static class HeaderText
        {
            public static void Set(DataGridView dgv, List<ltext> col_headers)
            {
                foreach (ltext lt in col_headers)
                {
                    try
                    {
                        dgv.Columns[lt.name].HeaderText = lt.s;
                    }
                    catch
                    {
                    }
                }
            }
        }

        public class ltext
        {
            string m_name = "";
            string[] sText = {"", ""};

            public string name
            {
                get
                {
                    return m_name;
                }
            }
            
            public string s
            {
                get
                {
                    return sText[DynSettings.LanguageID];
                }
            }
            public ltext(string xname, string Lang1, string Lang2)
            {
                m_name = xname;
                sText[0] = Lang1;
                sText[1] = Lang2;
            }
        }



    public class LoginComputer_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginComputer",/*table name in languages:*/"LoginComputer","LoginComputer");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext ComputerName_collangname = new ltext(/*column name:*/"ComputerName",/*column name in languages:*/"ComputerName","ComputerName");

        public LoginComputer_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(ComputerName_collangname);

               }
          }

    public class LoginComputerUser_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginComputerUser",/*table name in languages:*/"LoginComputerUser","LoginComputerUser");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext ComputerUserName_collangname = new ltext(/*column name:*/"ComputerUserName",/*column name in languages:*/"ComputerUserName","ComputerUserName");

        public LoginComputerUser_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(ComputerUserName_collangname);

               }
          }

    public class LoginFailed_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginFailed",/*table name in languages:*/"LoginFailed","LoginFailed");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext username_collangname = new ltext(/*column name:*/"username",/*column name in languages:*/"username","username");

                    public ltext AttemptTime_collangname = new ltext(/*column name:*/"AttemptTime",/*column name in languages:*/"AttemptTime","AttemptTime");

                    public ltext username_does_not_exist_collangname = new ltext(/*column name:*/"username_does_not_exist",/*column name in languages:*/"username_does_not_exist","username_does_not_exist");

                    public ltext password_wrong_collangname = new ltext(/*column name:*/"password_wrong",/*column name in languages:*/"password_wrong","password_wrong");

                    public ltext LoginComputer_id_collangname = new ltext(/*column name:*/"LoginComputer_id",/*column name in languages:*/"LoginComputer_id","LoginComputer_id");

                    public ltext LoginComputerUser_id_collangname = new ltext(/*column name:*/"LoginComputerUser_id",/*column name in languages:*/"LoginComputerUser_id","LoginComputerUser_id");

        public LoginFailed_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(username_collangname);

                    col_headers.Add(AttemptTime_collangname);

                    col_headers.Add(username_does_not_exist_collangname);

                    col_headers.Add(password_wrong_collangname);

                    col_headers.Add(LoginComputer_id_collangname);

                    col_headers.Add(LoginComputerUser_id_collangname);

               }
          }

    public class LoginManagerEvent_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginManagerEvent",/*table name in languages:*/"LoginManagerEvent","LoginManagerEvent");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext Name_collangname = new ltext(/*column name:*/"Name",/*column name in languages:*/"Name","Name");

        public LoginManagerEvent_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(Name_collangname);

               }
          }

    public class LoginManagerJournal_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginManagerJournal",/*table name in languages:*/"LoginManagerJournal","LoginManagerJournal");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext LoginUsers_id_collangname = new ltext(/*column name:*/"LoginUsers_id",/*column name in languages:*/"LoginUsers_id","LoginUsers_id");

                    public ltext LoginManagerEvent_id_collangname = new ltext(/*column name:*/"LoginManagerEvent_id",/*column name in languages:*/"LoginManagerEvent_id","LoginManagerEvent_id");

                    public ltext Time_collangname = new ltext(/*column name:*/"Time",/*column name in languages:*/"Time","Time");

        public LoginManagerJournal_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(LoginUsers_id_collangname);

                    col_headers.Add(LoginManagerEvent_id_collangname);

                    col_headers.Add(Time_collangname);

               }
          }

    public class LoginRoles_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginRoles",/*table name in languages:*/"LoginRoles","LoginRoles");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext Name_collangname = new ltext(/*column name:*/"Name",/*column name in languages:*/"Role","Vloga");

                    public ltext PrivilegesLevel_collangname = new ltext(/*column name:*/"PrivilegesLevel",/*column name in languages:*/"Privileges Level","Nivo pravic");

                    public ltext description_collangname = new ltext(/*column name:*/"description",/*column name in languages:*/"Description","Opis");


        public LoginRoles_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(Name_collangname);

                    col_headers.Add(PrivilegesLevel_collangname);

                    col_headers.Add(description_collangname);

               }
          }

    public class LoginSession_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginSession",/*table name in languages:*/"LoginSession","LoginSession");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext LoginUsers_id_collangname = new ltext(/*column name:*/"LoginUsers_id",/*column name in languages:*/"LoginUsers_id","LoginUsers_id");

                    public ltext Login_time_collangname = new ltext(/*column name:*/"Login_time",/*column name in languages:*/"Login_time","Login_time");

                    public ltext Logout_time_collangname = new ltext(/*column name:*/"Logout_time",/*column name in languages:*/"Logout_time","Logout_time");

                    public ltext LoginComputer_id_collangname = new ltext(/*column name:*/"LoginComputer_id",/*column name in languages:*/"LoginComputer_id","LoginComputer_id");

                    public ltext LoginComputerUser_id_collangname = new ltext(/*column name:*/"LoginComputerUser_id",/*column name in languages:*/"LoginComputerUser_id","LoginComputerUser_id");

        public LoginSession_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(LoginUsers_id_collangname);

                    col_headers.Add(Login_time_collangname);

                    col_headers.Add(Logout_time_collangname);

                    col_headers.Add(LoginComputer_id_collangname);

                    col_headers.Add(LoginComputerUser_id_collangname);

               }
          }


    public class LoginUsers_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginUsers",/*table name in languages:*/"LoginUsers","LoginUsers");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext first_name_collangname = new ltext(/*column name:*/"first_name",/*column name in languages:*/"First Name","Ime");

                    public ltext last_name_collangname = new ltext(/*column name:*/"last_name",/*column name in languages:*/"Last Name","Priimek");

                    public ltext Identity_collangname = new ltext(/*column name:*/"Identity",/*column name in languages:*/"Identity","Identiteta");

                    public ltext Contact_collangname = new ltext(/*column name:*/"Contact",/*column name in languages:*/"Contact","Kontakt");

                    public ltext username_collangname = new ltext(/*column name:*/"username",/*column name in languages:*/"Username","Uporabniško Ime");

                    public ltext password_collangname = new ltext(/*column name:*/"password",/*column name in languages:*/"Password","Geslo");

                    public ltext enabled_collangname = new ltext(/*column name:*/"enabled",/*column name in languages:*/"Active","Aktivno");

                    public ltext ChangePasswordOnFirstLogin_collangname = new ltext(/*column name:*/"ChangePasswordOnFirstLogin",/*column name in languages:*/"Change Password On First Login","Zamenjaj geslo ob prvi prijavi");

                    public ltext Time_When_AdministratorSetsPassword_collangname = new ltext(/*column name:*/"Time_When_AdministratorSetsPassword",/*column name in languages:*/"Administrator Setttings Time","Čas Administratorske nastavitve");

                    public ltext Administrator_LoginUsers_id_collangname = new ltext(/*column name:*/"Administrator_LoginUsers_id",/*column name in languages:*/"Administrator id","Administrator id");

                    public ltext Time_When_UserSetsItsOwnPassword_FirstTime_collangname = new ltext(/*column name:*/"Time_When_UserSetsItsOwnPassword_FirstTime",/*column name in languages:*/"Password First Time", "Čas prve nastavitve gesla");

                    public ltext Time_When_UserSetsItsOwnPassword_LastTime_collangname = new ltext(/*column name:*/"Time_When_UserSetsItsOwnPassword_LastTime",/*column name in languages:*/"Password last Time", "Čas zadnje nastavitve gesla");

                    public ltext PasswordNeverExpires_collangname = new ltext(/*column name:*/"PasswordNeverExpires",/*column name in languages:*/"Password Never Expires","Geslo nikoli ne poteče");

                    public ltext Maximum_password_age_in_days_collangname = new ltext(/*column name:*/"Maximum_password_age_in_days",/*column name in languages:*/"Password expired in ","Čas,ko geslo poteče");

                    public ltext NotActiveAfterPasswordExpires_collangname = new ltext(/*column name:*/"NotActiveAfterPasswordExpires",/*column name in languages:*/"NotActiveAfterPasswordExpires","Neveljavno po poteku gesla");


        public LoginUsers_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(first_name_collangname);

                    col_headers.Add(last_name_collangname);

                    col_headers.Add(Identity_collangname);

                    col_headers.Add(Contact_collangname);

                    col_headers.Add(username_collangname);

                    col_headers.Add(password_collangname);

                    col_headers.Add(enabled_collangname);

                    col_headers.Add(ChangePasswordOnFirstLogin_collangname);

                    col_headers.Add(Time_When_AdministratorSetsPassword_collangname);

                    col_headers.Add(Administrator_LoginUsers_id_collangname);

                    col_headers.Add(Time_When_UserSetsItsOwnPassword_FirstTime_collangname);

                    col_headers.Add(Time_When_UserSetsItsOwnPassword_LastTime_collangname);

                    col_headers.Add(PasswordNeverExpires_collangname);

                    col_headers.Add(Maximum_password_age_in_days_collangname);

                    col_headers.Add(NotActiveAfterPasswordExpires_collangname);

               }
          }

    public class LoginUsersAndLoginRoles_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginUsersAndLoginRoles",/*table name in languages:*/"LoginUsersAndLoginRoles","LoginUsersAndLoginRoles");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext LoginUsers_id_collangname = new ltext(/*column name:*/"LoginUsers_id",/*column name in languages:*/"LoginUsers_id","LoginUsers_id");

                    public ltext LoginRoles_id_collangname = new ltext(/*column name:*/"LoginRoles_id",/*column name in languages:*/"LoginRoles_id","LoginRoles_id");

        public LoginUsersAndLoginRoles_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(LoginUsers_id_collangname);

                    col_headers.Add(LoginRoles_id_collangname);

               }
          }

}
