using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LoginControl
{
    public static class AWP_func
    {
        internal static DBConnection con = null;


        internal static bool Read_Login_VIEW(ref DataTable dt,string where_condition, ref string Err)
        {
            if (where_condition==null)
            {
                where_condition = "";
            }
            string sql = @"
SELECT 
			LoginUsers.ID, 
			LoginUsers.PasswordNeverExpires AS PasswordNeverExpires,
            LoginUsers.Enabled AS Enabled,
			LoginUsers.Time_When_AdministratorSetsPassword AS Time_When_AdministratorSetsPassword,
			LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime AS Time_When_UserSetsItsOwnPassword_FirstTime,
			LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime AS Time_When_UserSetsItsOwnPassword_LastTime,
			LoginUsers.Administrator_LoginUsers_ID AS Administrator_LoginUsers_ID,
			LoginUsers.ChangePasswordOnFirstLogin AS ChangePasswordOnFirstLogin,
			LoginUsers.Maximum_password_age_in_days AS Maximum_password_age_in_days,
			LoginUsers.NotActiveAfterPasswordExpires AS NotActiveAfterPasswordExpires, 
			LoginUsers_$_mcomper.ID AS myOrganisation_Person_ID, 
			LoginUsers_$_mcomper.UserName AS myOrganisation_Person_$$UserName,
			LoginUsers_$_mcomper.Password AS myOrganisation_Person_$$Password,
			LoginUsers_$_mcomper.Job AS myOrganisation_Person_$$Job,
			LoginUsers_$_mcomper.Active AS myOrganisation_Person_$$Active,
			LoginUsers_$_mcomper.Description AS myOrganisation_Person_$$Description,
			LoginUsers_$_mcomper_$_per.ID AS myOrganisation_Person_$_per_$$ID,
			LoginUsers_$_mcomper_$_per.Gender AS myOrganisation_Person_$_per_$$Gender,
			LoginUsers_$_mcomper_$_per_$_cfn.ID AS myOrganisation_Person_$_per_$_cfn_$$ID,
			LoginUsers_$_mcomper_$_per_$_cfn.FirstName AS myOrganisation_Person_$_per_$_cfn_$$FirstName,
			LoginUsers_$_mcomper_$_per_$_cln.ID AS myOrganisation_Person_$_per_$_cln_$$ID,
			LoginUsers_$_mcomper_$_per_$_cln.LastName AS myOrganisation_Person_$_per_$_cln_$$LastName,
			LoginUsers_$_mcomper_$_per.DateOfBirth AS myOrganisation_Person_$_per_$$DateOfBirth,
			LoginUsers_$_mcomper_$_per.Tax_ID AS myOrganisation_Person_$_per_$$Tax_ID,
			LoginUsers_$_mcomper_$_per.Registration_ID AS myOrganisation_Person_$_per_$$Registration_ID,
			LoginUsers_$_mcomper_$_office.ID AS myOrganisation_Person_$_office_$$ID,
			LoginUsers_$_mcomper_$_office.Name AS myOrganisation_Person_$_office_$$Name,
			LoginUsers_$_mcomper_$_office.ShortName AS myOrganisation_Person_$_office_$$ShortName,
			PersonData.ID AS PersonData_$$ID,
			PersonData.CardNumber AS PersonData_$$CardNumber,
			PersonData.Description AS PersonData_$$Description,
			PersonData_$_cgsmnper.GsmNumber AS PersonData_$_cgsmnper_$$GsmNumber,
			PersonData_$_cphnnper.ID AS PersonData_$_cphnnper_$$ID,
			PersonData_$_cphnnper.PhoneNumber AS PersonData_$_cphnnper_$$PhoneNumber,
			PersonData_$_cemailper.ID AS PersonData_$_cemailper_$$ID,
			PersonData_$_cemailper.Email AS PersonData_$_cemailper_$$Email,
			PersonData_$_cadrper.ID AS PersonData_$_cadrper_$$ID,
			PersonData_$_cadrper_$_cstrnper.ID AS PersonData_$_cadrper_$_cstrnper_$$ID,
			PersonData_$_cadrper_$_cstrnper.StreetName AS PersonData_$_cadrper_$_cstrnper_$$StreetName,
			PersonData_$_cadrper_$_chounper.ID AS PersonData_$_cadrper_$_chounper_$$ID,
			PersonData_$_cadrper_$_chounper.HouseNumber AS PersonData_$_cadrper_$_chounper_$$HouseNumber,
			PersonData_$_cadrper_$_ccitper.ID AS PersonData_$_cadrper_$_ccitper_$$ID,
			PersonData_$_cadrper_$_ccitper.City AS PersonData_$_cadrper_$_ccitper_$$City,
			PersonData_$_cadrper_$_zipper.ID AS PersonData_$_cadrper_$_zipper_$$ID,
			PersonData_$_cadrper_$_zipper.ZIP AS PersonData_$_cadrper_$_zipper_$$ZIP,
			PersonData_$_cadrper_$_cstper.ID AS PersonData_$_cadrper_$_cstper_$$ID,
			PersonData_$_cadrper_$_cstper.Country AS PersonData_$_cadrper_$_cstper_$$Country,
			PersonData_$_cadrper_$_cstper.Country_ISO_3166_a2 AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a2,
			PersonData_$_cadrper_$_cstper.Country_ISO_3166_a3 AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a3,
			PersonData_$_cadrper_$_cstper.Country_ISO_3166_num AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_num,
			PersonData_$_cadrper_$_ccouper.ID AS PersonData_$_cadrper_$_ccouper_$$ID,
			PersonData_$_cadrper_$_ccouper.State AS PersonData_$_cadrper_$_ccouper_$$State,
			PersonData_$_cardtper.ID AS PersonData_$_cardtper_$$ID,
			PersonData_$_cardtper.CardType AS PersonData_$_cardtper_$$CardType,
			PersonData_$_perimg.ID AS PersonData_$_perimg_$$ID,
			PersonData_$_perimg.Image_Hash AS PersonData_$_perimg_$$Image_Hash,
			PersonData_$_perimg.Image_Data AS PersonData_$_perimg_$$Image_Data
            FROM LoginUsers 
            INNER JOIN myOrganisation_Person LoginUsers_$_mcomper ON LoginUsers.myOrganisation_Person_ID = LoginUsers_$_mcomper.ID 
            INNER JOIN Person LoginUsers_$_mcomper_$_per ON LoginUsers_$_mcomper.Person_ID = LoginUsers_$_mcomper_$_per.ID 
            INNER JOIN cFirstName LoginUsers_$_mcomper_$_per_$_cfn ON LoginUsers_$_mcomper_$_per.cFirstName_ID = LoginUsers_$_mcomper_$_per_$_cfn.ID 
            LEFT JOIN cLastName LoginUsers_$_mcomper_$_per_$_cln ON LoginUsers_$_mcomper_$_per.cLastName_ID = LoginUsers_$_mcomper_$_per_$_cln.ID 
            INNER JOIN Office LoginUsers_$_mcomper_$_office ON LoginUsers_$_mcomper.Office_ID = LoginUsers_$_mcomper_$_office.ID 
			LEFT JOIN PersonData ON PersonData.Person_ID = LoginUsers_$_mcomper_$_per.ID 
			LEFT JOIN cGsmNumber_Person PersonData_$_cgsmnper ON PersonData.cGsmNumber_Person_ID = PersonData_$_cgsmnper.ID 
			LEFT JOIN cPhoneNumber_Person PersonData_$_cphnnper ON PersonData.cPhoneNumber_Person_ID = PersonData_$_cphnnper.ID 
			LEFT JOIN cEmail_Person PersonData_$_cemailper ON PersonData.cEmail_Person_ID = PersonData_$_cemailper.ID 
			LEFT JOIN cAddress_Person PersonData_$_cadrper ON PersonData.cAddress_Person_ID = PersonData_$_cadrper.ID 
			LEFT JOIN cStreetName_Person PersonData_$_cadrper_$_cstrnper ON PersonData_$_cadrper.cStreetName_Person_ID = PersonData_$_cadrper_$_cstrnper.ID 
			LEFT JOIN cHouseNumber_Person PersonData_$_cadrper_$_chounper ON PersonData_$_cadrper.cHouseNumber_Person_ID = PersonData_$_cadrper_$_chounper.ID 
			LEFT JOIN cCity_Person PersonData_$_cadrper_$_ccitper ON PersonData_$_cadrper.cCity_Person_ID = PersonData_$_cadrper_$_ccitper.ID 
			LEFT JOIN cZIP_Person PersonData_$_cadrper_$_zipper ON PersonData_$_cadrper.cZIP_Person_ID = PersonData_$_cadrper_$_zipper.ID 
			LEFT JOIN cCountry_Person PersonData_$_cadrper_$_cstper ON PersonData_$_cadrper.cCountry_Person_ID = PersonData_$_cadrper_$_cstper.ID 
			LEFT JOIN cState_Person PersonData_$_cadrper_$_ccouper ON PersonData_$_cadrper.cState_Person_ID = PersonData_$_cadrper_$_ccouper.ID 
			LEFT JOIN cCardType_Person PersonData_$_cardtper ON PersonData.cCardType_Person_ID = PersonData_$_cardtper.ID 
			LEFT JOIN PersonImage PersonData_$_perimg ON PersonData.PersonImage_ID = PersonData_$_perimg.ID
            " + where_condition;
            if (dt == null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            if (con.ReadDataTable(ref dt, sql,ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        internal static bool Read_myOrganisation_Person_VIEW(ref DataTable dt, ref string Err)
        {
            string sql = @"
            SELECT 
             myOrganisation_Person.ID, 
             myOrganisation_Person.UserName AS myOrganisation_Person_$$UserName,
             myOrganisation_Person.Password AS myOrganisation_Person_$$Password,
             myOrganisation_Person.Job AS myOrganisation_Person_$$Job,
             myOrganisation_Person.Active AS myOrganisation_Person_$$Active,
             myOrganisation_Person.Description AS myOrganisation_Person_$$Description,
             myOrganisation_Person_$_per.ID AS myOrganisation_Person_$_per_$$ID,
             myOrganisation_Person_$_per.Gender AS myOrganisation_Person_$_per_$$Gender,
             myOrganisation_Person_$_per_$_cfn.ID AS myOrganisation_Person_$_per_$_cfn_$$ID,
             myOrganisation_Person_$_per_$_cfn.FirstName AS myOrganisation_Person_$_per_$_cfn_$$FirstName,
             myOrganisation_Person_$_per_$_cln.ID AS myOrganisation_Person_$_per_$_cln_$$ID,
             myOrganisation_Person_$_per_$_cln.LastName AS myOrganisation_Person_$_per_$_cln_$$LastName,
             myOrganisation_Person_$_per.DateOfBirth AS myOrganisation_Person_$_per_$$DateOfBirth,
             myOrganisation_Person_$_per.Tax_ID AS myOrganisation_Person_$_per_$$Tax_ID,
             myOrganisation_Person_$_per.Registration_ID AS myOrganisation_Person_$_per_$$Registration_ID,
             PersonData_$_cgsmnper.ID AS PersonData_$_cgsmnper_$$ID,
             PersonData.ID AS PersonData_$$ID,
             PersonData.CardNumber AS PersonData_$$CardNumber,
             PersonData.Description AS PersonData_$$Description,
             PersonData_$_cgsmnper.GsmNumber AS PersonData_$_cgsmnper_$$GsmNumber,
             PersonData_$_cphnnper.ID AS PersonData_$_cphnnper_$$ID,
             PersonData_$_cphnnper.PhoneNumber AS PersonData_$_cphnnper_$$PhoneNumber,
             PersonData_$_cemailper.ID AS PersonData_$_cemailper_$$ID,
             PersonData_$_cemailper.Email AS PersonData_$_cemailper_$$Email,
             PersonData_$_cadrper.ID AS PersonData_$_cadrper_$$ID,
             PersonData_$_cadrper_$_cstrnper.ID AS PersonData_$_cadrper_$_cstrnper_$$ID,
             PersonData_$_cadrper_$_cstrnper.StreetName AS PersonData_$_cadrper_$_cstrnper_$$StreetName,
             PersonData_$_cadrper_$_chounper.ID AS PersonData_$_cadrper_$_chounper_$$ID,
             PersonData_$_cadrper_$_chounper.HouseNumber AS PersonData_$_cadrper_$_chounper_$$HouseNumber,
             PersonData_$_cadrper_$_ccitper.ID AS PersonData_$_cadrper_$_ccitper_$$ID,
             PersonData_$_cadrper_$_ccitper.City AS PersonData_$_cadrper_$_ccitper_$$City,
             PersonData_$_cadrper_$_zipper.ID AS PersonData_$_cadrper_$_zipper_$$ID,
             PersonData_$_cadrper_$_zipper.ZIP AS PersonData_$_cadrper_$_zipper_$$ZIP,
             PersonData_$_cadrper_$_cstper.ID AS PersonData_$_cadrper_$_cstper_$$ID,
             PersonData_$_cadrper_$_cstper.Country AS PersonData_$_cadrper_$_cstper_$$Country,
             PersonData_$_cadrper_$_cstper.Country_ISO_3166_a2 AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a2,
             PersonData_$_cadrper_$_cstper.Country_ISO_3166_a3 AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a3,
             PersonData_$_cadrper_$_cstper.Country_ISO_3166_num AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_num,
             PersonData_$_cadrper_$_ccouper.ID AS PersonData_$_cadrper_$_ccouper_$$ID,
             PersonData_$_cadrper_$_ccouper.State AS PersonData_$_cadrper_$_ccouper_$$State,
             PersonData_$_cardtper.ID AS PersonData_$_cardtper_$$ID,
             PersonData_$_cardtper.CardType AS PersonData_$_cardtper_$$CardType,
             PersonData_$_perimg.ID AS PersonData_$_perimg_$$ID,
             PersonData_$_perimg.Image_Hash AS PersonData_$_perimg_$$Image_Hash,
             PersonData_$_perimg.Image_Data AS PersonData_$_perimg_$$Image_Data,
             myOrganisation_Person_$_office.ID AS myOrganisation_Person_$_office_$$ID,
             myOrganisation_Person_$_office.Name AS myOrganisation_Person_$_office_$$Name,
             myOrganisation_Person_$_office.ShortName AS myOrganisation_Person_$_office_$$ShortName
             FROM myOrganisation_Person 
             INNER JOIN Person myOrganisation_Person_$_per ON myOrganisation_Person.Person_ID = myOrganisation_Person_$_per.ID 
             INNER JOIN cFirstName myOrganisation_Person_$_per_$_cfn ON myOrganisation_Person_$_per.cFirstName_ID = myOrganisation_Person_$_per_$_cfn.ID 
             LEFT JOIN cLastName myOrganisation_Person_$_per_$_cln ON myOrganisation_Person_$_per.cLastName_ID = myOrganisation_Person_$_per_$_cln.ID 
             INNER JOIN Office myOrganisation_Person_$_office ON myOrganisation_Person.Office_ID = myOrganisation_Person_$_office.ID 
             LEFT JOIN PersonData ON PersonData.Person_ID = myOrganisation_Person_$_per.ID 
             LEFT JOIN cGsmNumber_Person PersonData_$_cgsmnper ON PersonData.cGsmNumber_Person_ID = PersonData_$_cgsmnper.ID 
             LEFT JOIN cPhoneNumber_Person PersonData_$_cphnnper ON PersonData.cPhoneNumber_Person_ID = PersonData_$_cphnnper.ID 
             LEFT JOIN cEmail_Person PersonData_$_cemailper ON PersonData.cEmail_Person_ID = PersonData_$_cemailper.ID 
             LEFT JOIN cAddress_Person PersonData_$_cadrper ON PersonData.cAddress_Person_ID = PersonData_$_cadrper.ID 
             LEFT JOIN cStreetName_Person PersonData_$_cadrper_$_cstrnper ON PersonData_$_cadrper.cStreetName_Person_ID = PersonData_$_cadrper_$_cstrnper.ID 
             LEFT JOIN cHouseNumber_Person PersonData_$_cadrper_$_chounper ON PersonData_$_cadrper.cHouseNumber_Person_ID = PersonData_$_cadrper_$_chounper.ID 
             LEFT JOIN cCity_Person PersonData_$_cadrper_$_ccitper ON PersonData_$_cadrper.cCity_Person_ID = PersonData_$_cadrper_$_ccitper.ID 
             LEFT JOIN cZIP_Person PersonData_$_cadrper_$_zipper ON PersonData_$_cadrper.cZIP_Person_ID = PersonData_$_cadrper_$_zipper.ID 
             LEFT JOIN cCountry_Person PersonData_$_cadrper_$_cstper ON PersonData_$_cadrper.cCountry_Person_ID = PersonData_$_cadrper_$_cstper.ID 
             LEFT JOIN cState_Person PersonData_$_cadrper_$_ccouper ON PersonData_$_cadrper.cState_Person_ID = PersonData_$_cadrper_$_ccouper.ID 
             LEFT JOIN cCardType_Person PersonData_$_cardtper ON PersonData.cCardType_Person_ID = PersonData_$_cardtper.ID 
             LEFT JOIN PersonImage PersonData_$_perimg ON PersonData.PersonImage_ID = PersonData_$_perimg.ID
";
            if (dt == null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            if (con.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        internal static bool Read_myOrganisation_Person_not_in_LoginUsers(ref DataTable dt, ref string Err)
        {
            string sql = @"
            SELECT 
             myOrganisation_Person_$_office.Name AS myOrganisation_Person_$_office_$$Name,
             myOrganisation_Person.UserName AS myOrganisation_Person_$$UserName,
             myOrganisation_Person.Active AS myOrganisation_Person_$$Active,
             myOrganisation_Person_$_per_$_cfn.FirstName AS myOrganisation_Person_$_per_$_cfn_$$FirstName,
             myOrganisation_Person_$_per_$_cln.LastName AS myOrganisation_Person_$_per_$_cln_$$LastName,
             myOrganisation_Person.Job AS myOrganisation_Person_$$Job,
             myOrganisation_Person_$_per.Tax_ID AS myOrganisation_Person_$_per_$$Tax_ID,
             myOrganisation_Person_$_per.Registration_ID AS myOrganisation_Person_$_per_$$Registration_ID,
             myOrganisation_Person.Description AS myOrganisation_Person_$$Description,
             myOrganisation_Person_$_per.DateOfBirth AS myOrganisation_Person_$_per_$$DateOfBirth,
             myOrganisation_Person_$_per.Gender AS myOrganisation_Person_$_per_$$Gender,
             PersonData_$_cemailper.Email AS PersonData_$_cemailper_$$Email,
             PersonData_$_cgsmnper.GsmNumber AS PersonData_$_cgsmnper_$$GsmNumber,
             PersonData_$_cphnnper.PhoneNumber AS PersonData_$_cphnnper_$$PhoneNumber,
             PersonData_$_cadrper_$_cstrnper.StreetName AS PersonData_$_cadrper_$_cstrnper_$$StreetName,
             PersonData_$_cadrper_$_chounper.HouseNumber AS PersonData_$_cadrper_$_chounper_$$HouseNumber,
             PersonData_$_cadrper_$_zipper.ZIP AS PersonData_$_cadrper_$_zipper_$$ZIP,
             PersonData_$_cadrper_$_ccitper.City AS PersonData_$_cadrper_$_ccitper_$$City,
             PersonData_$_cadrper_$_cstper.Country AS PersonData_$_cadrper_$_cstper_$$Country,
             PersonData_$_cadrper_$_ccouper.State AS PersonData_$_cadrper_$_ccouper_$$State,
             PersonData.Description AS PersonData_$$Description,
             PersonData_$_cardtper.CardType AS PersonData_$_cardtper_$$CardType,
             PersonData.CardNumber AS PersonData_$$CardNumber,
             myOrganisation_Person_$_office.ShortName AS myOrganisation_Person_$_office_$$ShortName,
             PersonData_$_cadrper_$_cstper.Country_ISO_3166_a2 AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a2,
             PersonData_$_cadrper_$_cstper.Country_ISO_3166_a3 AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_a3,
             PersonData_$_cadrper_$_cstper.Country_ISO_3166_num AS PersonData_$_cadrper_$_cstper_$$Country_ISO_3166_num,


             PersonData_$_perimg.Image_Hash AS PersonData_$_perimg_$$Image_Hash,
             PersonData_$_perimg.Image_Data AS PersonData_$_perimg_$$Image_Data,

             myOrganisation_Person.Password AS myOrganisation_Person_$$Password,

             myOrganisation_Person.ID as myOrganisation_Person_ID, 
             myOrganisation_Person_$_per.ID AS myOrganisation_Person_$_per_$$ID,
             myOrganisation_Person_$_per_$_cfn.ID AS myOrganisation_Person_$_per_$_cfn_$$ID,
             myOrganisation_Person_$_per_$_cln.ID AS myOrganisation_Person_$_per_$_cln_$$ID,
             PersonData_$_cgsmnper.ID AS PersonData_$_cgsmnper_$$ID,
             PersonData.ID AS PersonData_$$ID,
             PersonData_$_cphnnper.ID AS PersonData_$_cphnnper_$$ID,
             PersonData_$_cemailper.ID AS PersonData_$_cemailper_$$ID,
             PersonData_$_cadrper.ID AS PersonData_$_cadrper_$$ID,
             PersonData_$_cadrper_$_cstrnper.ID AS PersonData_$_cadrper_$_cstrnper_$$ID,
             PersonData_$_cadrper_$_chounper.ID AS PersonData_$_cadrper_$_chounper_$$ID,
             PersonData_$_cadrper_$_ccitper.ID AS PersonData_$_cadrper_$_ccitper_$$ID,
             PersonData_$_cadrper_$_zipper.ID AS PersonData_$_cadrper_$_zipper_$$ID,
             PersonData_$_cadrper_$_cstper.ID AS PersonData_$_cadrper_$_cstper_$$ID,
             PersonData_$_cadrper_$_ccouper.ID AS PersonData_$_cadrper_$_ccouper_$$ID,
             PersonData_$_cardtper.ID AS PersonData_$_cardtper_$$ID,
             PersonData_$_perimg.ID AS PersonData_$_perimg_$$ID,
             myOrganisation_Person_$_office.ID AS myOrganisation_Person_$_office_$$ID

             FROM myOrganisation_Person 
             INNER JOIN Person myOrganisation_Person_$_per ON myOrganisation_Person.Person_ID = myOrganisation_Person_$_per.ID 
             INNER JOIN cFirstName myOrganisation_Person_$_per_$_cfn ON myOrganisation_Person_$_per.cFirstName_ID = myOrganisation_Person_$_per_$_cfn.ID 
             LEFT JOIN cLastName myOrganisation_Person_$_per_$_cln ON myOrganisation_Person_$_per.cLastName_ID = myOrganisation_Person_$_per_$_cln.ID 
             INNER JOIN Office myOrganisation_Person_$_office ON myOrganisation_Person.Office_ID = myOrganisation_Person_$_office.ID 
             LEFT JOIN PersonData ON PersonData.Person_ID = myOrganisation_Person_$_per.ID 
             LEFT JOIN cGsmNumber_Person PersonData_$_cgsmnper ON PersonData.cGsmNumber_Person_ID = PersonData_$_cgsmnper.ID 
             LEFT JOIN cPhoneNumber_Person PersonData_$_cphnnper ON PersonData.cPhoneNumber_Person_ID = PersonData_$_cphnnper.ID 
             LEFT JOIN cEmail_Person PersonData_$_cemailper ON PersonData.cEmail_Person_ID = PersonData_$_cemailper.ID 
             LEFT JOIN cAddress_Person PersonData_$_cadrper ON PersonData.cAddress_Person_ID = PersonData_$_cadrper.ID 
             LEFT JOIN cStreetName_Person PersonData_$_cadrper_$_cstrnper ON PersonData_$_cadrper.cStreetName_Person_ID = PersonData_$_cadrper_$_cstrnper.ID 
             LEFT JOIN cHouseNumber_Person PersonData_$_cadrper_$_chounper ON PersonData_$_cadrper.cHouseNumber_Person_ID = PersonData_$_cadrper_$_chounper.ID 
             LEFT JOIN cCity_Person PersonData_$_cadrper_$_ccitper ON PersonData_$_cadrper.cCity_Person_ID = PersonData_$_cadrper_$_ccitper.ID 
             LEFT JOIN cZIP_Person PersonData_$_cadrper_$_zipper ON PersonData_$_cadrper.cZIP_Person_ID = PersonData_$_cadrper_$_zipper.ID 
             LEFT JOIN cCountry_Person PersonData_$_cadrper_$_cstper ON PersonData_$_cadrper.cCountry_Person_ID = PersonData_$_cadrper_$_cstper.ID 
             LEFT JOIN cState_Person PersonData_$_cadrper_$_ccouper ON PersonData_$_cadrper.cState_Person_ID = PersonData_$_cadrper_$_ccouper.ID 
             LEFT JOIN cCardType_Person PersonData_$_cardtper ON PersonData.cCardType_Person_ID = PersonData_$_cardtper.ID 
             LEFT JOIN PersonImage PersonData_$_perimg ON PersonData.PersonImage_ID = PersonData_$_perimg.ID
             where myOrganisation_Person_ID not in (select myOrganisation_Person_ID from LoginUsers) and  myOrganisation_Person.Active =1
";
            if (dt == null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            if (con.ReadDataTable(ref dt, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:Read_myOrganisation_Person_not_in_LoginUsers sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }
        private static bool AllreadyImported(ref DataTable dt, string sql, List<SQL_Parameter> lpar, ref string Err)
        {
            if (con.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count>0)
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
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:AllreadyImported:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Import_myOrganisationPerson(AWPData awpd, DataRow[] drsImportAdministrator, DataRow[] drsImportOthers)
        {
            foreach (DataRow dr in drsImportAdministrator)
            {
                long myOrganisation_Person_ID = (long)dr[awpd.mcn_myOrganisation_Person_ID.ColumnName];

                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_myOrganisation_Person_ID = "@par_myOrganisation_Person_ID";
                SQL_Parameter par_myOrganisation_Person_ID = new SQL_Parameter(spar_myOrganisation_Person_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, myOrganisation_Person_ID);
                lpar.Add(par_myOrganisation_Person_ID);

                string sql = "Select ID from LoginUsers where myOrganisation_Person_ID = " + spar_myOrganisation_Person_ID;
                DataTable dt = new DataTable();
                string Err = null;
                if (AllreadyImported(ref dt, sql, lpar, ref Err))
                {
                    //Already Imported
                    return true;
                }
                else
                {
                    bool PasswordNeverExpires = true;
                    string spar_PasswordNeverExpires = "@par_PasswordNeverExpires";
                    SQL_Parameter par_PasswordNeverExpires = new SQL_Parameter(spar_PasswordNeverExpires, SQL_Parameter.eSQL_Parameter.Bit, false, PasswordNeverExpires);
                    lpar.Add(par_PasswordNeverExpires);

                    bool ChangePasswordOnFirstLogin = true;
                    string spar_ChangePasswordOnFirstLogin = "@par_ChangePasswordOnFirstLogin";
                    SQL_Parameter par_ChangePasswordOnFirstLogin = new SQL_Parameter(spar_ChangePasswordOnFirstLogin, SQL_Parameter.eSQL_Parameter.Bit, false, ChangePasswordOnFirstLogin);
                    lpar.Add(par_ChangePasswordOnFirstLogin);


                    int Maximum_password_age_in_days = 30;
                    string spar_Maximum_password_age_in_days = "@par_Maximum_password_age_in_days";
                    SQL_Parameter par_Maximum_password_age_in_days = new SQL_Parameter(spar_Maximum_password_age_in_days, SQL_Parameter.eSQL_Parameter.Int, false, Maximum_password_age_in_days);
                    lpar.Add(par_Maximum_password_age_in_days);

                    bool NotActiveAfterPasswordExpires = false;
                    string spar_NotActiveAfterPasswordExpires = "@par_NotActiveAfterPasswordExpires";
                    SQL_Parameter par_NotActiveAfterPasswordExpires = new SQL_Parameter(spar_NotActiveAfterPasswordExpires, SQL_Parameter.eSQL_Parameter.Bit, false, NotActiveAfterPasswordExpires);
                    lpar.Add(par_NotActiveAfterPasswordExpires);

                    sql = @"Insert into LoginUsers(myOrganisation_Person_ID,
                                                   PasswordNeverExpires,
                                                   Time_When_AdministratorSetsPassword,
                                                   Time_When_UserSetsItsOwnPassword_FirstTime,
                                                   Time_When_UserSetsItsOwnPassword_LastTime,
                                                   Administrator_LoginUsers_ID,
                                                   ChangePasswordOnFirstLogin,
                                                   Maximum_password_age_in_days,
                                                   NotActiveAfterPasswordExpires)
                                                   values ("
                                                   + spar_myOrganisation_Person_ID +
                                                   "," + spar_PasswordNeverExpires +
                                                   ",null" + //Time_When_AdministratorSetsPassword
                                                   ",null" + //Time_When_UserSetsItsOwnPassword_FirstTime
                                                   ",null" + //Time_When_UserSetsItsOwnPassword_LastTime
                                                   ",null" + //Administrator_LoginUsers_ID
                                                   "," + spar_ChangePasswordOnFirstLogin +
                                                   "," + spar_Maximum_password_age_in_days +
                                                   "," + spar_NotActiveAfterPasswordExpires +
                                                   ")";
                    long LoginUsers_ID = -1;
                    object oret = null;

                    if (con.ExecuteNonQuerySQLReturnID(sql, lpar, ref LoginUsers_ID, ref oret, ref Err, "LoginUsers"))
                    {
                        continue;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:LoginControl:AWP_func:Import_myOrganisationPerson:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
