
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



    public class LoginRoles_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginRoles",/*table name in languages:*/"LoginRoles","LoginRoles");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext Name_collangname = new ltext(/*column name:*/"Name",/*column name in languages:*/"Name","Name");

                    public ltext description_collangname = new ltext(/*column name:*/"description",/*column name in languages:*/"description","description");

        public LoginRoles_lang()
        {
        
                    col_headers.Add(id_collangname);

                    col_headers.Add(Name_collangname);

                    col_headers.Add(description_collangname);

               }
          }

    public class LoginUsers_lang
    {
        public List<ltext> col_headers = new List<ltext>();
        public ltext s_TableName = new ltext(/*table name:*/"LoginUsers",/*table name in languages:*/"LoginUsers","LoginUsers");
                    public ltext id_collangname = new ltext(/*column name:*/"id",/*column name in languages:*/"id","id");

                    public ltext first_name_collangname = new ltext(/*column name:*/"first_name",/*column name in languages:*/"first_name","first_name");

                    public ltext last_name_collangname = new ltext(/*column name:*/"last_name",/*column name in languages:*/"last_name","last_name");

                    public ltext Identity_collangname = new ltext(/*column name:*/"Identity",/*column name in languages:*/"Identity","Identity");

                    public ltext Contact_collangname = new ltext(/*column name:*/"Contact",/*column name in languages:*/"Contact","Contact");

                    public ltext username_collangname = new ltext(/*column name:*/"username",/*column name in languages:*/"username","username");

                    public ltext password_collangname = new ltext(/*column name:*/"password",/*column name in languages:*/"password","password");

                    public ltext enabled_collangname = new ltext(/*column name:*/"enabled",/*column name in languages:*/"enabled","enabled");

                    public ltext ChangePasswordOnFirstLogin_collangname = new ltext(/*column name:*/"ChangePasswordOnFirstLogin",/*column name in languages:*/"ChangePasswordOnFirstLogin","ChangePasswordOnFirstLogin");

                    public ltext Time_When_UserSetsItsOwnPassword_collangname = new ltext(/*column name:*/"Time_When_UserSetsItsOwnPassword",/*column name in languages:*/"Time_When_UserSetsItsOwnPassword","Time_When_UserSetsItsOwnPassword");

                    public ltext PasswordNeverExpires_collangname = new ltext(/*column name:*/"PasswordNeverExpires",/*column name in languages:*/"PasswordNeverExpires","PasswordNeverExpires");

                    public ltext Maximum_password_age_in_days_collangname = new ltext(/*column name:*/"Maximum_password_age_in_days",/*column name in languages:*/"Maximum_password_age_in_days","Maximum_password_age_in_days");

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

                    col_headers.Add(Time_When_UserSetsItsOwnPassword_collangname);

                    col_headers.Add(PasswordNeverExpires_collangname);

                    col_headers.Add(Maximum_password_age_in_days_collangname);

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
