﻿using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LoginControl
{
    public class AWPLoginData
    {
        internal string t_FirstName = "(*FirstName*)";
        internal string t_LastName = "(*LastName*)";
        internal string t_OfficeName = "(*OfficeName*)";
        internal string t_OfficeShortName = "(*OfficeShortName*)";
        internal string t_PersonImage = "(*PersonImage*)";
        internal string t_Job = "(*Job*)";
        internal string t_DateOfBirth = "(*DateOfBirth*)";
        internal string t_Tax_ID = "(*Tax_ID*)";
        internal string t_Registration_ID = "(*Registration_ID*)";
        internal string t_Street = "(*Street*)";
        internal string t_HouseNumber = "(*HouseNumber*)";
        internal string t_ZIP = "(*ZIP*)";
        internal string t_City = "(*City*)";
        internal string t_Country = "(*Country*)";
        internal string t_UserName = "(*UserName*)";
        internal string t_AccessRight = "(*AccessRight*)";

        internal enum eGetDateResult {USER_NOT_FOUND, DUPLICATE_USER_FOUND, USER_HAS_NO_RULES,OK, ERROR }



        internal int LoginSession_id = -1;


        internal long ID = -1;
        internal bool Enabled;
        internal DateTime Time_When_AdministratorSetsPassword;
        internal DateTime Time_When_UserSetsItsOwnPassword_FirstTime;
        internal DateTime Time_When_UserSetsItsOwnPassword_LastTime;
        internal long Administrator_LoginUsers_ID;
        internal bool ChangePasswordOnFirstLogin;
        internal int Maximum_password_age_in_days;
        internal bool NotActiveAfterPasswordExpires;
        internal bool PasswordNeverExpires;
        internal long myOrganisation_Person_ID;
        internal string UserName;
        internal byte[] Password;
        internal string myOrganisation_Person_Job;
        internal bool myOrganisation_Person_Active;
        internal string myOrganisation_Person_Description;
        internal long myOrganisation_Person__per_ID;
        internal bool myOrganisation_Person__per_Gender;
        internal long myOrganisation_Person__per__cfn_ID;
        internal string myOrganisation_Person__per__cfn_FirstName;
        internal long myOrganisation_Person__per__cln_ID;
        internal string myOrganisation_Person__per__cln_LastName;
        internal DateTime myOrganisation_Person__per_DateOfBirth;
        internal string myOrganisation_Person__per_Tax_ID;
        internal string myOrganisation_Person__per_Registration_ID;
        internal long myOrganisation_Person__office_ID;
        internal string myOrganisation_Person__office_Name;
        internal string myOrganisation_Person__office_ShortName;
        internal long PersonData_ID;
        internal string PersonData_CardNumber;
        internal string PersonData_Description;
        internal string PersonData__cgsmnper_GsmNumber;
        internal long PersonData__cphnnper_ID;
        internal string PersonData__cphnnper_PhoneNumber;
        internal long PersonData__cemailper_ID;
        internal string PersonData__cemailper_Email;
        internal long PersonData__cadrper_ID;
        internal long PersonData__cadrper__cstrnper_ID;
        internal string PersonData__cadrper__cstrnper_StreetName;
        internal long PersonData__cadrper__chounper_ID;
        internal string PersonData__cadrper__chounper_HouseNumber;
        internal long PersonData__cadrper__ccitper_ID;
        internal string PersonData__cadrper__ccitper_City;
        internal long PersonData__cadrper__zipper_ID;
        internal string PersonData__cadrper__zipper_ZIP;
        internal long PersonData__cadrper__cstper_ID;
        internal string PersonData__cadrper__cstper_Country;
        internal string PersonData__cadrper__cstper_Country_ISO_3166_a2;
        internal string PersonData__cadrper__cstper_Country_ISO_3166_a3;
        internal string PersonData__cadrper__cstper_Country_ISO_3166_num;
        internal long PersonData__cadrper__ccouper_ID;
        internal string PersonData__cadrper__ccouper_State;
        internal long PersonData__cardtper_ID;
        internal string PersonData__cardtper_CardType;
        internal long PersonData__perimg_ID;
        internal string PersonData__perimg_Image_Hash;
        internal byte[] PersonData__perimg_Image_Data;



        public List<AWPRole> m_AWPRoles = new List<AWPRole>();

        internal DataTable dt_AWP_UserRoles = new DataTable();
        public List<AWPRole> m_AWP_UserRoles = new List<AWPRole>();
        internal DataTable dt_AWP_MissingUserRoles = new DataTable();
        public List<AWPRole> m_AWP_MissingUserRoles = new List<AWPRole>();

        internal bool IsAdministrator
        {
            get
            {
                foreach (AWPRole role in m_AWP_UserRoles)
                {
                    if (role.Name.Equals(AWP.ROLE_Administrator))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public long LoginUsers_ID {
            get
            {
                return ID;
            }
            }

        private bool m_Changed = false;
        internal bool Changed
        {
            get { return m_Changed; }
            set { m_Changed = value; }
        }

        internal bool GetUserRoles()
        {
            if (dt_AWP_UserRoles.Columns.Count!=1)
            {
                DataColumn dcol_Role = new DataColumn("Role",typeof(string));
                dt_AWP_UserRoles.Columns.Add(dcol_Role);
            }
            dt_AWP_UserRoles.Rows.Clear();

            if (dt_AWP_MissingUserRoles.Columns.Count != 1)
            {
                DataColumn dcol_Role = new DataColumn("Role", typeof(string));
                dt_AWP_MissingUserRoles.Columns.Add(dcol_Role);
            }
            dt_AWP_MissingUserRoles.Rows.Clear();

            if (AWP_func.AWPRoles_GetUserRoles(ID,ref m_AWP_UserRoles))
            {
                if (AWP_func.AWPRoles_GetRoles_User_Does_Not_Have(ID, ref m_AWP_MissingUserRoles))
                {
                    foreach (AWPRole r in m_AWP_UserRoles)
                    {
                        DataRow dr = dt_AWP_UserRoles.NewRow();
                        dr["Role"] = AWP_func.RoleInLanguage(r.Role);
                        dt_AWP_UserRoles.Rows.Add(dr);
                    }
                    foreach (AWPRole r in m_AWP_MissingUserRoles)
                    {
                        DataRow dr = dt_AWP_MissingUserRoles.NewRow();
                        dr["Role"] = AWP_func.RoleInLanguage(r.Role);
                        dt_AWP_MissingUserRoles.Rows.Add(dr);
                    }
                    return true;
                }
            }
            return false;
        }


        internal  eGetDateResult GetData(ref DataTable dt,string username, AWPBindingData awpb)
        {
            List<SQL_Parameter> lpar = null;
            string where_condition = "";
            if (username != null)
            {
                if (username.Length > 0)
                {
                    lpar = new List<SQL_Parameter>();
                    string spar_UserName = "@par_UserName";
                    SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, username);
                    lpar.Add(par_UserName);
                    where_condition = " where UserName = " + spar_UserName;
                }
            }
            if (AWP_func.Read_Login_VIEW(ref dt, where_condition, lpar))
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    ID = f.glong(dr[awpb.mcn_ID.ColumnName]);
                    Enabled = f.gbool(dr[awpb.mcn_Enabled.ColumnName]);
                    PasswordNeverExpires = f.gbool(dr[awpb.mcn_PasswordNeverExpires.ColumnName]);
                    Time_When_AdministratorSetsPassword = f.gDateTime(dr[awpb.mcn_Time_When_AdministratorSetsPassword.ColumnName]);
                    Time_When_UserSetsItsOwnPassword_FirstTime = f.gDateTime(dr[awpb.mcn_Time_When_UserSetsItsOwnPassword_FirstTime.ColumnName]);
                    Time_When_UserSetsItsOwnPassword_LastTime = f.gDateTime(dr[awpb.mcn_Time_When_UserSetsItsOwnPassword_LastTime.ColumnName]);
                    Administrator_LoginUsers_ID = f.glong(dr[awpb.mcn_Administrator_LoginUsers_ID.ColumnName]);
                    ChangePasswordOnFirstLogin = f.gbool(dr[awpb.mcn_ChangePasswordOnFirstLogin.ColumnName]);
                    Maximum_password_age_in_days = f.gint(dr[awpb.mcn_Maximum_password_age_in_days.ColumnName]);
                    NotActiveAfterPasswordExpires = f.gbool(dr[awpb.mcn_NotActiveAfterPasswordExpires.ColumnName]);
                    myOrganisation_Person_ID = f.glong(dr[awpb.mcn_myOrganisation_Person_ID.ColumnName]);
                    UserName = f.gstring(dr[awpb.mcn_UserName.ColumnName]);
                    Password = f.gbytearray(dr[awpb.mcn_Password.ColumnName]);
                    myOrganisation_Person_Job = f.gstring(dr[awpb.mcn_myOrganisation_Person_Job.ColumnName]);
                    myOrganisation_Person_Active = f.gbool(dr[awpb.mcn_myOrganisation_Person_Active.ColumnName]);
                    myOrganisation_Person_Description = f.gstring(dr[awpb.mcn_myOrganisation_Person_Description.ColumnName]);
                    myOrganisation_Person__per_ID = f.glong(dr[awpb.mcn_myOrganisation_Person__per_ID.ColumnName]);
                    myOrganisation_Person__per_Gender = f.gbool(dr[awpb.mcn_myOrganisation_Person__per_Gender.ColumnName]);
                    myOrganisation_Person__per__cfn_ID = f.glong(dr[awpb.mcn_myOrganisation_Person__per__cfn_ID.ColumnName]);
                    myOrganisation_Person__per__cfn_FirstName = f.gstring(dr[awpb.mcn_myOrganisation_Person__per__cfn_FirstName.ColumnName]);
                    myOrganisation_Person__per__cln_ID = f.glong(dr[awpb.mcn_myOrganisation_Person__per__cln_ID.ColumnName]);
                    myOrganisation_Person__per__cln_LastName = f.gstring(dr[awpb.mcn_myOrganisation_Person__per__cln_LastName.ColumnName]);
                    myOrganisation_Person__per_DateOfBirth = f.gDateTime(dr[awpb.mcn_myOrganisation_Person__per_DateOfBirth.ColumnName]);
                    myOrganisation_Person__per_Tax_ID = f.gstring(dr[awpb.mcn_myOrganisation_Person__per_Tax_ID.ColumnName]);
                    myOrganisation_Person__per_Registration_ID = f.gstring(dr[awpb.mcn_myOrganisation_Person__per_Registration_ID.ColumnName]);
                    myOrganisation_Person__office_ID = f.glong(dr[awpb.mcn_myOrganisation_Person__office_ID.ColumnName]);
                    myOrganisation_Person__office_Name = f.gstring(dr[awpb.mcn_myOrganisation_Person__office_Name.ColumnName]);
                    myOrganisation_Person__office_ShortName = f.gstring(dr[awpb.mcn_myOrganisation_Person__office_ShortName.ColumnName]);
                    PersonData_ID = f.glong(dr[awpb.mcn_PersonData_ID.ColumnName]);
                    PersonData_CardNumber = f.gstring(dr[awpb.mcn_PersonData_CardNumber.ColumnName]);
                    PersonData_Description = f.gstring(dr[awpb.mcn_PersonData_Description.ColumnName]);
                    PersonData__cgsmnper_GsmNumber = f.gstring(dr[awpb.mcn_PersonData__cgsmnper_GsmNumber.ColumnName]);
                    PersonData__cphnnper_ID = f.glong(dr[awpb.mcn_PersonData__cphnnper_ID.ColumnName]);
                    PersonData__cphnnper_PhoneNumber = f.gstring(dr[awpb.mcn_PersonData__cphnnper_PhoneNumber.ColumnName]);
                    PersonData__cemailper_ID = f.glong(dr[awpb.mcn_PersonData__cemailper_ID.ColumnName]);
                    PersonData__cemailper_Email = f.gstring(dr[awpb.mcn_PersonData__cemailper_Email.ColumnName]);
                    PersonData__cadrper_ID = f.glong(dr[awpb.mcn_PersonData__cadrper_ID.ColumnName]);
                    PersonData__cadrper__cstrnper_ID = f.glong(dr[awpb.mcn_PersonData__cadrper__cstrnper_ID.ColumnName]);
                    PersonData__cadrper__cstrnper_StreetName = f.gstring(dr[awpb.mcn_PersonData__cadrper__cstrnper_StreetName.ColumnName]);
                    PersonData__cadrper__chounper_ID = f.glong(dr[awpb.mcn_PersonData__cadrper__chounper_ID.ColumnName]);
                    PersonData__cadrper__chounper_HouseNumber = f.gstring(dr[awpb.mcn_PersonData__cadrper__chounper_HouseNumber.ColumnName]);
                    PersonData__cadrper__ccitper_ID = f.glong(dr[awpb.mcn_PersonData__cadrper__ccitper_ID.ColumnName]);
                    PersonData__cadrper__ccitper_City = f.gstring(dr[awpb.mcn_PersonData__cadrper__ccitper_City.ColumnName]);
                    PersonData__cadrper__zipper_ID = f.glong(dr[awpb.mcn_PersonData__cadrper__zipper_ID.ColumnName]);
                    PersonData__cadrper__zipper_ZIP = f.gstring(dr[awpb.mcn_PersonData__cadrper__zipper_ZIP.ColumnName]);
                    PersonData__cadrper__cstper_ID = f.glong(dr[awpb.mcn_PersonData__cadrper__cstper_ID.ColumnName]);
                    PersonData__cadrper__cstper_Country = f.gstring(dr[awpb.mcn_PersonData__cadrper__cstper_Country.ColumnName]);
                    PersonData__cadrper__cstper_Country_ISO_3166_a2 = f.gstring(dr[awpb.mcn_PersonData__cadrper__cstper_Country_ISO_3166_a2.ColumnName]);
                    PersonData__cadrper__cstper_Country_ISO_3166_a3 = f.gstring(dr[awpb.mcn_PersonData__cadrper__cstper_Country_ISO_3166_a3.ColumnName]);
                    PersonData__cadrper__cstper_Country_ISO_3166_num = f.gstring(dr[awpb.mcn_PersonData__cadrper__ccouper_ID.ColumnName]);
                    PersonData__cadrper__ccouper_ID = f.glong(dr[awpb.mcn_PersonData__cadrper__ccouper_ID.ColumnName]);
                    PersonData__cadrper__ccouper_State = f.gstring(dr[awpb.mcn_PersonData__cadrper__ccouper_State.ColumnName]);
                    PersonData__cardtper_ID = f.glong(dr[awpb.mcn_PersonData__cardtper_ID.ColumnName]);
                    PersonData__cardtper_CardType = f.gstring(dr[awpb.mcn_PersonData__cardtper_CardType.ColumnName]);
                    PersonData__perimg_ID = f.glong(dr[awpb.mcn_PersonData__perimg_ID.ColumnName]);
                    PersonData__perimg_Image_Hash = f.gstring(dr[awpb.mcn_PersonData__perimg_Image_Hash.ColumnName]);
                    PersonData__perimg_Image_Data = f.gbytearray(dr[awpb.mcn_PersonData__perimg_Image_Data.ColumnName]);
                    
                    if (GetUserRoles())
                    {
                        if (m_AWP_UserRoles.Count>0)
                        {
                            return eGetDateResult.OK;
                        }
                        else
                        {
                            return eGetDateResult.USER_HAS_NO_RULES;
                        }
                    }
                }
                else
                {
                    if (dt.Rows.Count == 0)
                    {
                        return eGetDateResult.USER_NOT_FOUND;
                    }
                    else
                    {
                        return eGetDateResult.DUPLICATE_USER_FOUND;
                    }
                }
            }
            return eGetDateResult.ERROR;
        }

        internal string GetHtml()
        {
            int iLanguage = LanguageControl.DynSettings.LanguageID;
            foreach (HtmlTemplate ht in TemplatesLoader.Templates)
            {
                if (iLanguage == 0)
                {
                    if (ht.Name.Equals("00_ENG_myOrganisation_Person"))
                    {
                        return FillData(ht.Html);
                    }
                }
                else if (iLanguage == 1)
                {
                    if (ht.Name.Equals("01_SLO_myOrganisation_Person"))
                    {
                        return FillData(ht.Html);
                    }
                }
                else
                {
                    return "<p>ERROR:LoginControl:AWPLoginData:GetHtml:Language index = " + iLanguage.ToString() + " not implemented!</p>";
                }
            }
            return "<p>ERROR:LoginControl:AWPLoginData:GetHtml:Template not found!</p>";
        }

        private string FillData(string html)
        {
            StringBuilder sb = new StringBuilder(html);
            sb = Replace(sb, ref t_FirstName, ref myOrganisation_Person__per__cfn_FirstName);
            sb = Replace(sb, ref t_LastName, ref myOrganisation_Person__per__cln_LastName);
            sb = Replace(sb, ref t_OfficeName, ref myOrganisation_Person__office_Name);
            sb = Replace(sb, ref t_OfficeShortName, ref myOrganisation_Person__office_ShortName);
            sb = Replace(sb, ref t_OfficeName, ref myOrganisation_Person__office_ShortName);
            bool bHasImage = false;
            if (PersonData__perimg_Image_Data is byte[])
            {
                if (PersonData__perimg_Image_Data != null)
                {
                    string sBase64image = Convert.ToBase64String(PersonData__perimg_Image_Data);
                    sb = Replace(sb, ref t_PersonImage, ref sBase64image);
                    bHasImage = true;
                }
            }
            if (!bHasImage)
            {
                string t = "<img width=\"128\" height=\"156\" src=\"data:image/png;base64,(*PersonImage*)\">";
                string s = "";
                sb = Replace(sb, ref t, ref s);
            }

            sb = Replace(sb, ref t_Job, ref myOrganisation_Person_Job);
            string sDate = null;
            if (myOrganisation_Person__per_DateOfBirth != null)
            {
                if (LanguageControl.DynSettings.LanguageID == LanguageControl.DynSettings.Slovensko_ID)
                {
                    sDate = myOrganisation_Person__per_DateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("sl-SI"));
                }
                else
                {
                    sDate = myOrganisation_Person__per_DateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
                }
                if (sDate != null)
                {
                    sb = Replace(sb, ref t_DateOfBirth, ref sDate);
                }
            }
            if (sDate == null)
            {
                string r = "";
                sb = Replace(sb, ref t_DateOfBirth, ref r);
            }
            sb = Replace(sb, ref t_Tax_ID, ref myOrganisation_Person__per_Tax_ID);
            sb = Replace(sb, ref t_Registration_ID, ref myOrganisation_Person__per_Registration_ID);
            sb = Replace(sb, ref t_Street, ref PersonData__cadrper__cstrnper_StreetName);
            sb = Replace(sb, ref t_HouseNumber, ref PersonData__cadrper__chounper_HouseNumber);
            sb = Replace(sb, ref t_ZIP, ref PersonData__cadrper__zipper_ZIP);
            sb = Replace(sb, ref t_City, ref PersonData__cadrper__ccitper_City);
            sb = Replace(sb, ref t_Country, ref PersonData__cadrper__cstper_Country);
            sb = Replace(sb, ref t_UserName,ref UserName);
            return sb.ToString();
    }

        private StringBuilder Replace(StringBuilder sb, ref string t_token, ref string svalue)
        {
            if (svalue==null)
            {
                return sb.Replace(t_token, "");
            }
            else 
            {
                return sb.Replace(t_token, svalue);
            }
        }

        internal void RemoveRole(int Index)
        {
            AWP_func.RemoveRole(ID, m_AWP_UserRoles[Index].ID);

        }

        internal void AddRole(int Index)
        {
            long LoginUsersAndLoginRoles_ID = -1;

            AWP_func.AddRole(ID, m_AWP_MissingUserRoles[Index].ID,ref LoginUsersAndLoginRoles_ID);
        }
    }
}
