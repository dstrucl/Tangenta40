using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TangentaDB;

namespace LoginControl
{
    public static class AWP_func
    {
        internal static DBConnection con = null;


        internal static bool Read_LoginSession_VIEW(ref DataTable dt, string where_condition, List<SQL_Parameter> lpar)
        {
            string err = null;
            if (where_condition == null)
            {
                where_condition = "";
            }
            string sql = @"
SELECT LoginSession.ID,
 LoginSession_$_lusr.UserName AS LoginSession_$_lusr_$$UserName,
 LoginSession_$_awperiod_$_amcper_$_aper_$_acfn.FirstName AS LoginSession_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName,
 LoginSession_$_awperiod_$_amcper_$_aper_$_acln.LastName AS LoginSession_$_awperiod_$_amcper_$_aper_$_acln_$$LastName,
 LoginSession_$_awperiod.LoginTime AS LoginSession_$_awperiod_$$LoginTime,
 LoginSession_$_awperiod.LogoutTime AS LoginSession_$_awperiod_$$LogoutTime,
 LoginSession_$_awperiod_$_awperiodt.Name AS LoginSession_$_awperiod_$_awperiodt_$$Name,
 LoginSession_$_awperiod_$_awperiodt.Description AS LoginSession_$_awperiod_$_awperiodt_$$Description,
 LoginSession_$_awperiod_$_aipa.IP_address,
 LoginSession_$_lusr.Time_When_UserSetsItsOwnPassword_FirstTime AS LoginSession_$_lusr_$$Time_When_UserSetsItsOwnPassword_FirstTime,
 LoginSession_$_lusr.Time_When_UserSetsItsOwnPassword_LastTime AS LoginSession_$_lusr_$$Time_When_UserSetsItsOwnPassword_LastTime,
 LoginSession_$_lusr.Enabled AS LoginSession_$_lusr_$$Enabled,
 LoginSession_$_lusr.Maximum_password_age_in_days AS LoginSession_$_lusr_$$Maximum_password_age_in_days,
 LoginSession_$_lusr.NotActiveAfterPasswordExpires AS LoginSession_$_lusr_$$NotActiveAfterPasswordExpires,
 LoginSession_$_lusr.PasswordNeverExpires AS LoginSession_$_lusr_$$PasswordNeverExpires,
 LoginSession_$_lusr.Time_When_AdministratorSetsPassword AS LoginSession_$_lusr_$$Time_When_AdministratorSetsPassword,
 LoginSession_$_lusr.ChangePasswordOnFirstLogin AS LoginSession_$_lusr_$$ChangePasswordOnFirstLogin,
 LoginSession_$_lusr_$_lupg1.Name AS LoginSession_$_lusr_$_lupg1_$$Name,
 LoginSession_$_lusr_$_lupg1_$_lupg2.Name AS LoginSession_$_lusr_$_lupg1_$_lupg2_$$Name,
 LoginSession_$_lusr_$_lupg1_$_lupg2_$_lupg3.Name AS LoginSession_$_lusr_$_lupg1_$_lupg2_$_lupg3_$$Name,
 LoginSession_$_awperiod_$_amcper_$_aper.Gender AS LoginSession_$_awperiod_$_amcper_$_aper_$$Gender,
 LoginSession_$_awperiod_$_amcper_$_aper.DateOfBirth AS LoginSession_$_awperiod_$_amcper_$_aper_$$DateOfBirth,
 LoginSession_$_awperiod_$_amcper_$_aper.Tax_ID AS LoginSession_$_awperiod_$_amcper_$_aper_$$Tax_ID,
 LoginSession_$_awperiod_$_amcper_$_aper.Registration_ID AS LoginSession_$_awperiod_$_amcper_$_aper_$$Registration_ID,
 LoginSession_$_awperiod_$_amcper_$_aper_$_agsmnper.GsmNumber AS LoginSession_$_awperiod_$_amcper_$_aper_$_agsmnper_$$GsmNumber,
 LoginSession_$_awperiod_$_amcper_$_aper_$_aphnnper.PhoneNumber AS LoginSession_$_awperiod_$_amcper_$_aper_$_aphnnper_$$PhoneNumber,
 LoginSession_$_awperiod_$_amcper_$_aper_$_aemailper.Email AS LoginSession_$_awperiod_$_amcper_$_aper_$_aemailper_$$Email,
 LoginSession_$_awperiod_$_amcper_$_aper_$_aperimg.Image_Data AS LoginSession_$_awperiod_$_amcper_$_aper_$_aperimg_$$Image_Data,
 LoginSession_$_awperiod_$_amcper_$_aoffice.Name AS LoginSession_$_awperiod_$_amcper_$_aoffice_$$Name,
 LoginSession_$_awperiod_$_amcper_$_aoffice.ShortName AS LoginSession_$_awperiod_$_amcper_$_aoffice_$$ShortName,
 LoginSession_$_awperiod_$_amcper.Job AS LoginSession_$_awperiod_$_amcper_$$Job,
 LoginSession_$_awperiod_$_amcper.Description AS LoginSession_$_awperiod_$_amcper_$$Description,
 LoginSession_$_awperiod_$_aed.Name AS LoginSession_$_awperiod_$_aed_$$Name,
 LoginSession_$_awperiod_$_aed_$_acomp_$_acn.Name AS LoginSession_$_awperiod_$_aed_$_acomp_$_acn_$$Name,
 LoginSession_$_awperiod_$_aed_$_acomp_$_acn.Description AS LoginSession_$_awperiod_$_aed_$_acomp_$_acn_$$Description,
 LoginSession_$_awperiod_$_aed_$_acomp_$_amac.MAC_address AS LoginSession_$_awperiod_$_aed_$_acomp_$_amac_$$MAC_address,
 LoginSession_$_awperiod_$_aed_$_acomp_$_amac.Description AS LoginSession_$_awperiod_$_aed_$_acomp_$_amac_$$Description,
 LoginSession_$_awperiod_$_aed_$_acomp_$_acun.UserName AS LoginSession_$_awperiod_$_aed_$_acomp_$_acun_$$UserName,
 LoginSession_$_awperiod_$_aed_$_acomp_$_acun.Description AS LoginSession_$_awperiod_$_aed_$_acomp_$_acun_$$Description,
 LoginSession_$_awperiod_$_aipa.IP_address AS LoginSession_$_awperiod_$_aipa_$$IP_address,
 LoginSession_$_awperiod_$_aipa.Description AS LoginSession_$_awperiod_$_aipa_$$Description,
 LoginSession_$_awperiod_$_aed_$_aoffice.Name AS LoginSession_$_awperiod_$_aed_$_aoffice_$$Name,
 LoginSession_$_awperiod_$_aed_$_aoffice.ShortName AS LoginSession_$_awperiod_$_aed_$_aoffice_$$ShortName,
 LoginSession_$_awperiod_$_aed.Description AS LoginSession_$_awperiod_$_aed_$$Description,
 LoginSession_$_lusr.ID AS LoginSession_$_lusr_$$ID,
 LoginSession_$_awperiod.ID AS LoginSession_$_awperiod_$$ID,
 LoginSession_$_awperiod_$_amcper.ID AS LoginSession_$_awperiod_$_amcper_$$ID,
 LoginSession_$_awperiod_$_amcper_$_aper.ID AS LoginSession_$_awperiod_$_amcper_$_aper_$$ID,
 LoginSession_$_awperiod_$_awperiodt.ID AS LoginSession_$_awperiod_$_awperiodt_$$ID
 FROM LoginSession 
 INNER JOIN LoginUsers LoginSession_$_lusr ON LoginSession.LoginUsers_ID = LoginSession_$_lusr.ID 
 LEFT JOIN LoginUsers_ParentGroup1 LoginSession_$_lusr_$_lupg1 ON LoginSession_$_lusr.LoginUsers_ParentGroup1_ID = LoginSession_$_lusr_$_lupg1.ID 
 LEFT JOIN LoginUsers_ParentGroup2 LoginSession_$_lusr_$_lupg1_$_lupg2 ON LoginSession_$_lusr_$_lupg1.LoginUsers_ParentGroup2_ID = LoginSession_$_lusr_$_lupg1_$_lupg2.ID 
 LEFT JOIN LoginUsers_ParentGroup3 LoginSession_$_lusr_$_lupg1_$_lupg2_$_lupg3 ON LoginSession_$_lusr_$_lupg1_$_lupg2.LoginUsers_ParentGroup3_ID = LoginSession_$_lusr_$_lupg1_$_lupg2_$_lupg3.ID 
 INNER JOIN Atom_WorkPeriod LoginSession_$_awperiod ON LoginSession.Atom_WorkPeriod_ID = LoginSession_$_awperiod.ID 
 INNER JOIN Atom_myOrganisation_Person LoginSession_$_awperiod_$_amcper ON LoginSession_$_awperiod.Atom_myOrganisation_Person_ID = LoginSession_$_awperiod_$_amcper.ID 
 INNER JOIN Atom_Person LoginSession_$_awperiod_$_amcper_$_aper ON LoginSession_$_awperiod_$_amcper.Atom_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper.ID 
 INNER JOIN Atom_cFirstName LoginSession_$_awperiod_$_amcper_$_aper_$_acfn ON LoginSession_$_awperiod_$_amcper_$_aper.Atom_cFirstName_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acfn.ID 
 LEFT JOIN Atom_cLastName LoginSession_$_awperiod_$_amcper_$_aper_$_acln ON LoginSession_$_awperiod_$_amcper_$_aper.Atom_cLastName_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acln.ID 
 LEFT JOIN Atom_cGsmNumber_Person LoginSession_$_awperiod_$_amcper_$_aper_$_agsmnper ON LoginSession_$_awperiod_$_amcper_$_aper.Atom_cGsmNumber_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_agsmnper.ID 
 LEFT JOIN Atom_cPhoneNumber_Person LoginSession_$_awperiod_$_amcper_$_aper_$_aphnnper ON LoginSession_$_awperiod_$_amcper_$_aper.Atom_cPhoneNumber_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_aphnnper.ID 
 LEFT JOIN Atom_cEmail_Person LoginSession_$_awperiod_$_amcper_$_aper_$_aemailper ON LoginSession_$_awperiod_$_amcper_$_aper.Atom_cEmail_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_aemailper.ID 
 LEFT JOIN Atom_cAddress_Person LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper ON LoginSession_$_awperiod_$_amcper_$_aper.Atom_cAddress_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper.ID 
 LEFT JOIN Atom_cStreetName_Person LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper ON LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cStreetName_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_astrnper.ID 
 LEFT JOIN Atom_cHouseNumber_Person LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper ON LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cHouseNumber_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_ahounper.ID 
 LEFT JOIN Atom_cCity_Person LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper ON LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cCity_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_acitper.ID 
 LEFT JOIN Atom_cZIP_Person LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper ON LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cZIP_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_azipper.ID 
 LEFT JOIN Atom_cCountry_Person LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper ON LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cCountry_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_astper.ID 
 LEFT JOIN Atom_cState_Person LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper ON LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper.Atom_cState_Person_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_acadrper_$_acouper.ID 
 LEFT JOIN Atom_PersonImage LoginSession_$_awperiod_$_amcper_$_aper_$_aperimg ON LoginSession_$_awperiod_$_amcper_$_aper.Atom_PersonImage_ID = LoginSession_$_awperiod_$_amcper_$_aper_$_aperimg.ID 
 INNER JOIN Atom_Office LoginSession_$_awperiod_$_amcper_$_aoffice ON LoginSession_$_awperiod_$_amcper.Atom_Office_ID = LoginSession_$_awperiod_$_amcper_$_aoffice.ID 
 INNER JOIN Atom_ElectronicDevice LoginSession_$_awperiod_$_aed ON LoginSession_$_awperiod.Atom_ElectronicDevice_ID = LoginSession_$_awperiod_$_aed.ID 
 INNER JOIN Atom_Computer LoginSession_$_awperiod_$_aed_$_acomp ON LoginSession_$_awperiod_$_aed.Atom_Computer_ID = LoginSession_$_awperiod_$_aed_$_acomp.ID 
 INNER JOIN Atom_ComputerName LoginSession_$_awperiod_$_aed_$_acomp_$_acn ON LoginSession_$_awperiod_$_aed_$_acomp.Atom_ComputerName_ID = LoginSession_$_awperiod_$_aed_$_acomp_$_acn.ID 
 LEFT JOIN Atom_MAC_address LoginSession_$_awperiod_$_aed_$_acomp_$_amac ON LoginSession_$_awperiod_$_aed_$_acomp.Atom_MAC_address_ID = LoginSession_$_awperiod_$_aed_$_acomp_$_amac.ID 
 LEFT JOIN Atom_ComputerUserName LoginSession_$_awperiod_$_aed_$_acomp_$_acun ON LoginSession_$_awperiod_$_aed_$_acomp.Atom_ComputerUserName_ID = LoginSession_$_awperiod_$_aed_$_acomp_$_acun.ID 
 LEFT JOIN Atom_IP_address LoginSession_$_awperiod_$_aipa ON LoginSession_$_awperiod.Atom_IP_address_ID = LoginSession_$_awperiod_$_aipa.ID 
 INNER JOIN Atom_Office LoginSession_$_awperiod_$_aed_$_aoffice ON LoginSession_$_awperiod_$_aed.Atom_Office_ID = LoginSession_$_awperiod_$_aed_$_aoffice.ID 
 INNER JOIN Atom_myOrganisation LoginSession_$_awperiod_$_aed_$_aoffice_$_amc ON LoginSession_$_awperiod_$_aed_$_aoffice.Atom_myOrganisation_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc.ID 
 INNER JOIN Atom_OrganisationData LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc.Atom_OrganisationData_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.ID 
 INNER JOIN Atom_Organisation LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_aorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_aorg.ID 
 LEFT JOIN Atom_Comment1 LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_aorg_$_acmt1 ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_aorg.Atom_Comment1_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_aorg_$_acmt1.ID 
 LEFT JOIN Atom_cAddress_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.Atom_cAddress_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg.ID 
 LEFT JOIN Atom_cStreetName_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cStreetName_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astrnorg.ID 
 LEFT JOIN Atom_cHouseNumber_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cHouseNumber_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_ahounorg.ID 
 LEFT JOIN Atom_cCity_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cCity_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acitorg.ID 
 LEFT JOIN Atom_cZIP_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cZIP_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_aziporg.ID 
 LEFT JOIN Atom_cCountry_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cCountry_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_astorg.ID 
 LEFT JOIN Atom_cState_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg.Atom_cState_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_acadrorg_$_acouorg.ID 
 LEFT JOIN cPhoneNumber_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_cphnnorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.cPhoneNumber_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_cphnnorg.ID 
 LEFT JOIN cFaxNumber_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_cfaxnorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.cFaxNumber_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_cfaxnorg.ID 
 LEFT JOIN cEmail_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_cemailorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.cEmail_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_cemailorg.ID 
 LEFT JOIN cHomePage_Org LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_chomepgorg ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.cHomePage_Org_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_chomepgorg.ID 
 LEFT JOIN cOrgTYPE LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_orgt ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.cOrgTYPE_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_orgt.ID 
 LEFT JOIN Atom_Logo LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_alogo ON LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd.Atom_Logo_ID = LoginSession_$_awperiod_$_aed_$_aoffice_$_amc_$_aorgd_$_alogo.ID 
 LEFT JOIN Atom_WorkPeriod_TYPE LoginSession_$_awperiod_$_awperiodt ON LoginSession_$_awperiod.Atom_WorkPeriod_TYPE_ID = LoginSession_$_awperiod_$_awperiodt.ID          
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
            if (con.ReadDataTable(ref dt, sql, lpar, ref err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:Read_Login_VIEW:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        internal static bool IsUserLoggedIn(ID loginUsers_ID, ref ID LoginSession_ID)
        {
            string err = null;
            string sql = @"SELECT LoginSession.ID as ID
            FROM LoginSession 
            INNER JOIN Atom_WorkPeriod LoginSession_$_awperiod ON LoginSession.Atom_WorkPeriod_ID = LoginSession_$_awperiod.ID 
            where LoginSession_$_awperiod.LogoutTime is null and LoginUsers_ID = " + loginUsers_ID.ToString();
            DataTable dt = new DataTable();
            LoginSession_ID = null;
            if (con.ReadDataTable(ref dt, sql, null, ref err))
            {
                if (dt.Rows.Count == 1)
                {
                    LoginSession_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:LoginControl:AWP_func:IsUserLoggedIn:User with LoginUsers_ID =" + loginUsers_ID.ToString() + " is loggedin several times:" + dt.Rows.Count.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:IsUserLoggedIn:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        internal static bool Read_Login_VIEW(ref DataTable dt, string where_condition, List<SQL_Parameter> lpar)
        {
            string err = null;
            if (where_condition == null)
            {
                where_condition = "";
            }
            string sql = @"
SELECT 
			LoginUsers.ID, 
			LoginUsers.PasswordNeverExpires AS PasswordNeverExpires,
            LoginUsers.Enabled AS Enabled,
			LoginUsers.UserName AS UserName,
			LoginUsers.Password AS Password,
			LoginUsers.Time_When_AdministratorSetsPassword AS Time_When_AdministratorSetsPassword,
			LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime AS Time_When_UserSetsItsOwnPassword_FirstTime,
			LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime AS Time_When_UserSetsItsOwnPassword_LastTime,
			LoginUsers.Administrator_LoginUsers_ID AS Administrator_LoginUsers_ID,
			LoginUsers.ChangePasswordOnFirstLogin AS ChangePasswordOnFirstLogin,
			LoginUsers.Maximum_password_age_in_days AS Maximum_password_age_in_days,
			LoginUsers.NotActiveAfterPasswordExpires AS NotActiveAfterPasswordExpires, 
			LoginUsers_$_mcomper.ID AS myOrganisation_Person_ID, 
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
            PersonData.PIN AS PersonData_$$PIN,
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
            lupg1.Name AS s1_name,
            lupg2.Name AS s2_name,
            lupg3.Name AS s3_name
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
            LEFT JOIN LoginUsers_ParentGroup1 lupg1 ON LoginUsers.LoginUsers_ParentGroup1_ID = lupg1.ID
            LEFT JOIN LoginUsers_ParentGroup2 lupg2 ON lupg1.LoginUsers_ParentGroup2_ID = lupg2.ID
            LEFT JOIN LoginUsers_ParentGroup3 lupg3 ON lupg2.LoginUsers_ParentGroup3_ID = lupg3.ID
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
            if (con.ReadDataTable(ref dt, sql, lpar, ref err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:Read_Login_VIEW:sql=" + sql + "\r\nErr=" + err);
                return false;
            }

        }


        public static bool GetGroupsTable(ref DataTable dtLoginUsersGroup)
        {
            string sql = @"select 
              s1.Name as s1_name,
              s2.Name as s2_name,
              s3.Name as s3_name
              FROM LoginUsers 
              LEFT JOIN LoginUsers_ParentGroup1 s1 ON LoginUsers.LoginUsers_ParentGroup1_ID = s1.ID
              LEFT JOIN LoginUsers_ParentGroup2 s2 ON s1.LoginUsers_ParentGroup2_ID = s2.ID
              LEFT JOIN LoginUsers_ParentGroup3 s3 ON s2.LoginUsers_ParentGroup3_ID = s3.ID
		      group by s1.Name,s2.Name,s3.Name";
            if (dtLoginUsersGroup == null)
            {
                dtLoginUsersGroup = new DataTable();
            }
            else
            {
                dtLoginUsersGroup.Clear();
                dtLoginUsersGroup.Rows.Clear();
                dtLoginUsersGroup.Columns.Clear();
            }
            string Err = null;
            if (con.ReadDataTable(ref dtLoginUsersGroup, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:GetGroupsTable:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool GetWorkingPeriod(ref DataTable dtWorkingPeriod,DateTime dateFrom,DateTime dateTo, string userName)
        {
            ID myOrganisation_Person_ID = null;
            if (Get_myOrganisation_Person_ID(userName, ref myOrganisation_Person_ID))
            {
                List<ID> Atom_myOrganisation_Person_ID_List = new List<ID>();
                if (f_Atom_myOrganisation_Person.Get(myOrganisation_Person_ID, ref Atom_myOrganisation_Person_ID_List))
                {
                    if (Atom_myOrganisation_Person_ID_List.Count == 0)
                    {
                        if (dtWorkingPeriod==null)
                        {
                            dtWorkingPeriod = new DataTable();
                        }
                        else
                        {
                            dtWorkingPeriod.Clear();
                        }
                        return false;
                    }

                    if (dtWorkingPeriod == null)
                    {
                        dtWorkingPeriod = new DataTable();
                    }
                    else
                    {
                        dtWorkingPeriod.Rows.Clear();
                        dtWorkingPeriod.Columns.Clear();
                    }

                    string sInCondition = null;
                    foreach (ID idl in Atom_myOrganisation_Person_ID_List)
                    {
                        if (sInCondition==null)
                        {
                            sInCondition = "("+idl.ToString();
                        }
                        else
                        {
                            sInCondition += "," + idl.ToString();
                        }
                    }
                    if (sInCondition!=null)
                    {
                        sInCondition += ")"; 
                    }

                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    DateTime xdateFrom = new DateTime(dateFrom.Year, dateFrom.Month, dateFrom.Day);
                    DateTime xdateTo = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day);


                    string spar_dateFrom = "@par_dateFrom";
                    SQL_Parameter par_dateFrom = new SQL_Parameter(spar_dateFrom, SQL_Parameter.eSQL_Parameter.Datetime, false, xdateFrom);
                    lpar.Add(par_dateFrom);

                    string spar_dateTo = "@par_dateTo";
                    SQL_Parameter par_dateTo = new SQL_Parameter(spar_dateTo, SQL_Parameter.eSQL_Parameter.Datetime, false, xdateTo);
                    lpar.Add(par_dateTo);

                    string sql = @"  SELECT 

                    Atom_WorkPeriod.LoginTime AS Atom_WorkPeriod_$$LoginTime, 
                    Atom_WorkPeriod.LogoutTime AS Atom_WorkPeriod_$$LogoutTime,
                    Atom_WorkPeriod_$_aed.Name AS Atom_WorkPeriod_$_aed_$$Name,
                    Atom_WorkPeriod_$_amcper_$_aoffice.Name AS Atom_WorkPeriod_$_amcper_$_aoffice_$$Name,
                    Atom_WorkPeriod_$_amcper_$_aoffice.ShortName AS Atom_WorkPeriod_$_amcper_$_aoffice_$$ShortName,
                    Atom_WorkPeriod_$_acomp_$_acn.Name AS Atom_WorkPeriod_$_acomp_$_acn_$$Name,
                    Atom_WorkPeriod_$_acomp_$_acun.UserName AS Atom_WorkPeriod_$_acomp_$_acun_$$UserName,
                    Atom_WorkPeriod_$_acomp_$_amac.MAC_address AS Atom_WorkPeriod_$_acomp_$_amac_$$Mac_address,
                    Atom_WorkPeriod_$_aipa.IP_address AS Atom_WorkPeriod_$_aipa_$$IP_address,
                    Atom_WorkPeriod_$_amcper_$_aper_$_acfn.FirstName AS Atom_WorkPeriod_$_amcper_$_aper_$_acfn_$$FirstName,
                    Atom_WorkPeriod_$_amcper_$_aper_$_acln.LastName AS Atom_WorkPeriod_$_amcper_$_aper_$_acln_$$LastName,
                    Atom_WorkPeriod_$_awperiodt.Name AS Atom_WorkPeriod_$_awperiodt_$$Name,
                    Atom_WorkPeriod_$_awperiodt.Description AS Atom_WorkPeriod_$_awperiodt_$$Description
                    FROM Atom_WorkPeriod 
                    INNER JOIN Atom_myOrganisation_Person Atom_WorkPeriod_$_amcper ON Atom_WorkPeriod.Atom_myOrganisation_Person_ID = Atom_WorkPeriod_$_amcper.ID 
                    INNER JOIN Atom_Person Atom_WorkPeriod_$_amcper_$_aper ON Atom_WorkPeriod_$_amcper.Atom_Person_ID = Atom_WorkPeriod_$_amcper_$_aper.ID 
                    INNER JOIN Atom_cFirstName Atom_WorkPeriod_$_amcper_$_aper_$_acfn ON Atom_WorkPeriod_$_amcper_$_aper.Atom_cFirstName_ID = Atom_WorkPeriod_$_amcper_$_aper_$_acfn.ID 
                    LEFT JOIN Atom_cLastName Atom_WorkPeriod_$_amcper_$_aper_$_acln ON Atom_WorkPeriod_$_amcper_$_aper.Atom_cLastName_ID = Atom_WorkPeriod_$_amcper_$_aper_$_acln.ID 
                    INNER JOIN Atom_Office Atom_WorkPeriod_$_amcper_$_aoffice ON Atom_WorkPeriod_$_amcper.Atom_Office_ID = Atom_WorkPeriod_$_amcper_$_aoffice.ID 
                    INNER JOIN Atom_myOrganisation Atom_WorkPeriod_$_amcper_$_aoffice_$_amc ON Atom_WorkPeriod_$_amcper_$_aoffice.Atom_myOrganisation_ID = Atom_WorkPeriod_$_amcper_$_aoffice_$_amc.ID 
                    INNER JOIN Atom_OrganisationData Atom_WorkPeriod_$_amcper_$_aoffice_$_amc_$_aorgd ON Atom_WorkPeriod_$_amcper_$_aoffice_$_amc.Atom_OrganisationData_ID = Atom_WorkPeriod_$_amcper_$_aoffice_$_amc_$_aorgd.ID 
                    INNER JOIN Atom_Organisation Atom_WorkPeriod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg ON Atom_WorkPeriod_$_amcper_$_aoffice_$_amc_$_aorgd.Atom_Organisation_ID = Atom_WorkPeriod_$_amcper_$_aoffice_$_amc_$_aorgd_$_aorg.ID
                    INNER JOIN Atom_Computer Atom_WorkPeriod_$_acomp ON Atom_WorkPeriod.Atom_Computer_ID = Atom_WorkPeriod_$_acomp.ID 
                    LEFT JOIN Atom_ComputerName Atom_WorkPeriod_$_acomp_$_acn ON Atom_WorkPeriod_$_acomp.Atom_ComputerName_ID = Atom_WorkPeriod_$_acomp_$_acn.ID 
                    LEFT JOIN Atom_ComputerUsername Atom_WorkPeriod_$_acomp_$_acun ON Atom_WorkPeriod_$_acomp.Atom_ComputerUsername_ID = Atom_WorkPeriod_$_acomp_$_acun.ID 
                    LEFT JOIN Atom_MAC_address Atom_WorkPeriod_$_acomp_$_amac ON Atom_WorkPeriod_$_acomp.Atom_MAC_address_ID = Atom_WorkPeriod_$_acomp_$_amac.ID 
                    INNER JOIN ElectronicDevice Atom_WorkPeriod_$_aed ON Atom_WorkPeriod.Atom_ElectronicDevice_ID = Atom_WorkPeriod_$_aed.ID 
                    LEFT JOIN Atom_WorkPeriod_TYPE Atom_WorkPeriod_$_awperiodt ON Atom_WorkPeriod.Atom_WorkPeriod_TYPE_ID = Atom_WorkPeriod_$_awperiodt.ID
                    LEFT JOIN Atom_IP_address Atom_WorkPeriod_$_aipa ON Atom_WorkPeriod.Atom_IP_address_ID = Atom_WorkPeriod_$_aipa.ID 
                    where Atom_WorkPeriod_$_amcper.ID in " + sInCondition + " and Atom_WorkPeriod.LoginTime > "+ spar_dateFrom + " and Atom_WorkPeriod.LoginTime < "+ spar_dateTo + " order by Atom_WorkPeriod.LoginTime desc ";

                    string err = null;
                    if (con.ReadDataTable(ref dtWorkingPeriod, sql, lpar, ref err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:LoginControl:AWP_func:GetWorkingPeriod:sql=" + sql + "\r\nErr=" + err);
                        return false;
                    }
                }
            }
            return false;
        }

        internal static bool Get_myOrganisation_Person_ID(string userName, ref ID myOrganisation_Person_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_UserName = "@par_UserName";
            SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, userName);
            lpar.Add(par_UserName);
            string sql = @" 
              SELECT 
	
		    LoginUsers_$_mcomper.ID AS myOrganisation_Person_ID 
			
            FROM LoginUsers 
            INNER JOIN myOrganisation_Person LoginUsers_$_mcomper ON LoginUsers.myOrganisation_Person_ID = LoginUsers_$_mcomper.ID 
           
            where LoginUsers.UserName = " + spar_UserName;
            DataTable dt = new DataTable();
            string err = null;
            if (con.ReadDataTable(ref dt, sql, lpar, ref err))
            {
                if (dt.Rows.Count>0)
                {
                    myOrganisation_Person_ID = tf.set_ID(dt.Rows[0]["myOrganisation_Person_ID"]);
                    return true;
                }
                return false;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:Get_myOrganisation_Person_ID:sql=" + sql + "\r\nErr=" + err);
                return false;
            }

        }
    
        internal static string RoleInLanguage(string role)
        {
            if (role.Equals(AWP.ROLE_Administrator))
            {
                return lng.cn_Role_Administrator.s;
            }
            else if (role.Equals(AWP.ROLE_UserManagement))
            {
                return lng.cn_Role_UserManagement.s;
            }
            else if (role.Equals(AWP.ROLE_PriceListManagement))
            {
                return lng.cn_Role_PriceListManagement.s;
            }
            else if (role.Equals(AWP.ROLE_StockTakeManagement))
            {
                return lng.cn_Role_StockTakeManagemenent.s;
            }
            else if (role.Equals(AWP.ROLE_WriteInvoice))
            {
                return lng.cn_Role_WriteInvoice.s;
            }
            else if (role.Equals(AWP.ROLE_WriteProformaInvoice))
            {
                return lng.cn_Role_WriteProformaInvoice.s;
            }

            //else if (role.Equals(AWP.ROLE_ViewAndExport))
            //{
            //    return lng.cn_Role_ViewAndExport.s;
            //}
            //else if (role.Equals(AWP.ROLE_WorkInShopA))
            //{
            //    return lng.cn_Role_WorkInShopA.s;
            //}
            //else if (role.Equals(AWP.ROLE_WorkInShopB))
            //{
            //    return lng.cn_Role_WorkInShopB.s;
            //}
            //else if (role.Equals(AWP.ROLE_WorkInShopC))
            //{
            //    return lng.cn_Role_WorkInShopC.s;
            //}
            //else if (role.Equals(AWP.ROLE_WriteInvoice))
            //{
            //    return lng.cn_Role_WriteInvoice.s;
            //}
            //else if (role.Equals(AWP.ROLE_WriteProformainvoice))
            //{
            //    return lng.cn_Role_WriteProformaInvoice.s;
            //}
            else
            {
                LogFile.Error.Show("ERROR:AWP_func:RoleInLanguage:Role=" + role + " not implemented!");
                return "ERROR";
            }
        }

        internal static bool InsertNewDefaultLoginUsersRow(ID myOrganisation_Person_ID, string uniqueUserName, ref ID LoginUsers_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_myOrganisation_Person_ID = "@par_myOrganisation_Person_ID";
            SQL_Parameter par_myOrganisation_Person_ID = new SQL_Parameter(spar_myOrganisation_Person_ID, false, myOrganisation_Person_ID);
            lpar.Add(par_myOrganisation_Person_ID);

            string spar_UniqueUserName = "@par_UniqueUserName";
            SQL_Parameter par_UniqueUserName = new SQL_Parameter(spar_UniqueUserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, uniqueUserName);
            lpar.Add(par_UniqueUserName);
            string sql = @"insert into LoginUsers (myOrganisation_Person_ID
                                                    ,Enabled
                                                    ,UserName
                                                     ,PasswordNeverExpires
                                                     ,ChangePasswordOnFirstLogin
                                                     ,Maximum_password_age_in_days
                                                     ,NotActiveAfterPasswordExpires) values
                                                     (" + spar_myOrganisation_Person_ID
                                                     + ",1"
                                                     + "," + spar_UniqueUserName
                                                     + @",1
                                                         ,1
                                                         ,30
                                                         ,0
                                                         )";
            string Err = null;
            if (con.ExecuteNonQuerySQLReturnID(sql,lpar,ref LoginUsers_ID,ref Err, "LoginUsers"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AWP_func:InsertNewDefaultLoginUsersRow:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static string GetUniqueUserName(string firstName)
        {
            string purged_firstName = firstName.Replace(" ", "");
            purged_firstName = purged_firstName.Replace("\t", "");
            string usrname = purged_firstName;
            string Err = null;
            int i = 1;
            for (;;)
            {
                if (AWP_func.UserNameExist(usrname))
                {
                    usrname = purged_firstName + i.ToString();
                    i++;
                }
                else
                {
                    if (Err == null)
                    {
                        return usrname;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        internal static bool WriteLoginSession(ID loginUsers_ID, ID atom_WorkPeriod_ID, ref ID loginSession_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, false, loginUsers_ID);
            lpar.Add(par_LoginUsers_ID);
            string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
            SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, false, atom_WorkPeriod_ID);
            lpar.Add(par_Atom_WorkPeriod_ID);
            string sql = "insert into LoginSession (LoginUsers_ID,Atom_WorkPeriod_ID)values(" + spar_LoginUsers_ID + "," + spar_Atom_WorkPeriod_ID + ")";
            string Err = null;

            if (con.ExecuteNonQuerySQLReturnID(sql,lpar,ref loginSession_ID, ref Err, "LoginSession"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AWP_func:WriteLoginSession:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool GetMyOrgPerNotInLoginUsers(ref DataTable dt_myOrgPerNotInLoginUsers)
        {
            string sql = @"select cfn.FirstName,cln.LastName,p.Tax_ID,p.Registration_ID,p.DateOfBirth,mop.ID from myOrganisation_Person mop
                           inner join Person p on p.ID = mop.Person_ID
                           inner join cFirstName cfn on cfn.ID = p.cFirstName_ID
                           left join cLastName cln on cln.ID = p.cLastName_ID
                           where mop.ID not in (select myOrganisation_Person_ID from LoginUsers)";
            string Err = null;
            if (con.ReadDataTable(ref dt_myOrgPerNotInLoginUsers,sql,ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AWP_func:GetMyOrgPerNotInLoginUsers:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool GetMyOrgPerThatExistsInLoginUsers(ref DataTable dt_myOrgPerNotInLoginUsers)
        {
            string sql = @"select cfn.FirstName,cln.LastName,p.Tax_ID,p.Registration_ID,p.DateOfBirth,mop.ID from myOrganisation_Person mop
                           inner join Person p on p.ID = mop.Person_ID
                           inner join cFirstName cfn on cfn.ID = p.cFirstName_ID
                           left join cLastName cln on cln.ID = p.cLastName_ID
                           where mop.ID in (select myOrganisation_Person_ID from LoginUsers)";
            string Err = null;
            if (con.ReadDataTable(ref dt_myOrgPerNotInLoginUsers, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AWP_func:GetMyOrgPerThatExistsInLoginUsers:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Remove_ChangePasswordOnFirstLogin(AWPLoginData awpld)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, awpld.ID);
            lpar.Add(par_LoginUsers_ID);
            string sql = "UPDATE LoginUsers SET  ChangePasswordOnFirstLogin  = 0  where id = " + spar_LoginUsers_ID;
            string Err = null;
            if (con.ExecuteNonQuerySQL(sql,lpar,ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AWP_func:Remove_ChangePasswordOnFirstLogin:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool LoginUsers_UserChangeItsOwnPassword(AWPLoginData awpld, byte[] xpsw)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, awpld.ID);
            lpar.Add(par_LoginUsers_ID);

            DateTime xTime_When_UserSetsItsOwnPassword_LastTime = DateTime.Now;

            string spar_Time_When_UserSetsItsOwnPassword_LastTime = "@par_TWUsrSetsOwnPass_LastTime";
            SQL_Parameter par_Time_When_UserSetsItsOwnPassword_LastTime = new SQL_Parameter(spar_Time_When_UserSetsItsOwnPassword_LastTime, SQL_Parameter.eSQL_Parameter.Datetime, false, xTime_When_UserSetsItsOwnPassword_LastTime);
            lpar.Add(par_Time_When_UserSetsItsOwnPassword_LastTime);

            string spar_Pssword = "@par_Pssword";
            SQL_Parameter par_Pssword = new SQL_Parameter(spar_Pssword, SQL_Parameter.eSQL_Parameter.Varbinary, false, xpsw);
            lpar.Add(par_Pssword);

            string sql = "UPDATE LoginUsers SET ChangePasswordOnFirstLogin = 0, Time_When_UserSetsItsOwnPassword_LastTime = " + spar_Time_When_UserSetsItsOwnPassword_LastTime +
                                                 ",Password = " + spar_Pssword + " where id = " + spar_LoginUsers_ID;
            string Err = null;

            if (con.ExecuteNonQuerySQL(sql, lpar,  ref Err))
            {
                awpld.Time_When_UserSetsItsOwnPassword_LastTime = xTime_When_UserSetsItsOwnPassword_LastTime;
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AWP_func:LoginUsers_UserChangeItsOwnPassword:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool DeactivateUserName(ID iD)
        {
            string sql_change_enabled = "UPDATE LoginUsers SET enabled = 0 where id = " + iD.ToString();
            string Err = null;
            if (con.ExecuteNonQuerySQL(sql_change_enabled, null, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:LoginControl:AWP_func:DeactivateUserName:sql=" + sql_change_enabled + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool GetLoginSession(ID LoginUsers_ID, ID Atom_WorkPeriod_ID, ref ID loginSession_id)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID,  false, LoginUsers_ID);
            lpar.Add(par_LoginUsers_ID);

            string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
            SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID,  false, Atom_WorkPeriod_ID);
            lpar.Add(par_Atom_WorkPeriod_ID);


            string sql = @"insert into LoginSession (LoginUsers_ID,Atom_WorkPeriod_ID) values (" + spar_LoginUsers_ID + "," + spar_Atom_WorkPeriod_ID + ")";
            string err = null;
            if (con.ExecuteNonQuerySQLReturnID(sql, lpar, ref loginSession_id,  ref err, "LoginSession"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:GetLoginSession:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        internal static bool Read_myOrganisation_Person_VIEW(ref DataTable dt, ref string Err)
        {
            string sql = @"
            SELECT 
             myOrganisation_Person.ID, 
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

        internal static bool RemoveRole(ID LoginUsers_ID, ID LoginRoles_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, false, LoginUsers_ID);
            lpar.Add(par_LoginUsers_ID);

            string spar_LoginRoles_ID = "@par_LoginRoles_ID";
            SQL_Parameter par_LoginRoles_ID = new SQL_Parameter(spar_LoginRoles_ID,  false, LoginRoles_ID);
            lpar.Add(par_LoginRoles_ID);

            string sql = "DELETE FROM LoginUsersAndLoginRoles where LoginUsers_ID = " + spar_LoginUsers_ID + " and LoginRoles_ID = " + spar_LoginRoles_ID;
            string err = null;
            if (con.ExecuteNonQuerySQL(sql, lpar, ref err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:RemoveRole:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        internal static bool AddRole(ID LoginUsers_ID, ID LoginRoles_ID, ref ID LoginUsersAndLoginRoles_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, false, LoginUsers_ID);
            lpar.Add(par_LoginUsers_ID);

            string spar_LoginRoles_ID = "@par_LoginRoles_ID";
            SQL_Parameter par_LoginRoles_ID = new SQL_Parameter(spar_LoginRoles_ID, false, LoginRoles_ID);
            lpar.Add(par_LoginRoles_ID);

            string sql = "Insert into LoginUsersAndLoginRoles (LoginUsers_ID,LoginRoles_ID) values (" + spar_LoginUsers_ID + "," + spar_LoginRoles_ID+")";
            string err = null;

            if (con.ExecuteNonQuerySQLReturnID(sql, lpar, ref LoginUsersAndLoginRoles_ID, ref err, "LoginUsersAndLoginRoles"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:AddRole:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        internal static bool UpdateRoles(List<AWPRole> allRoles)
        {
            foreach (AWPRole r in allRoles)
            {
                if (!UpdateRole(r))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool UpdateRole(AWPRole r)
        {
            string sql = "select id from LoginRoles where role = '" + r.Role + "'";
            DataTable dt = new DataTable();
            string err = null;
            if (con.ReadDataTable(ref dt, sql, ref err))
            {
                if (dt.Rows.Count > 0)
                {
                    r.ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into LoginRoles (role) values ('" + r.Role + "')";
                    ID LoginRoles_ID = null;
                    if (con.ExecuteNonQuerySQLReturnID(sql, null, ref LoginRoles_ID,  ref err, "LoginRoles"))
                    {
                        r.ID = LoginRoles_ID;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:LoginControl:AWP_func:UpdateRole:sql=" + sql + "\r\nErr=" + err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:UpdateRole:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        internal static bool Read_myOrganisation_Person_not_in_LoginUsers(ref DataTable dt, ref string Err)
        {
            string sql = @"
            SELECT 
             myOrganisation_Person_$_office.Name AS myOrganisation_Person_$_office_$$Name,
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
             where myOrganisation_Person.ID not in (select myOrganisation_Person_ID from LoginUsers) and  myOrganisation_Person.Active =1
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

        internal static bool UserNameExist(string UserName)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_UserName = "@par_UserName";
            SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, UserName);
            lpar.Add(par_UserName);
            string sql = "select ID from LoginUsers where UserName = " + spar_UserName;
            DataTable dt = new DataTable();
            string Err = null;
            if (con.ReadDataTable(ref dt, sql,lpar, ref Err))
            {
                return dt.Rows.Count > 0;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:UserNameExist:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool UserNameExist(string UserName, ref ID LoginUsers_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_UserName = "@par_UserName";
            SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, UserName);
            lpar.Add(par_UserName);
            string sql = "select ID from LoginUsers where UserName = " + spar_UserName;
            DataTable dt = new DataTable();
            string Err = null;
            if (con.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    LoginUsers_ID = tf.set_ID(dt.Rows[0]["ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:UserNameExist:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Update_LoginUsers_ID(AWPLoginData m_AWPLoginData, bool PasswordChanged)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, m_AWPLoginData.ID);
            lpar.Add(par_LoginUsers_ID);


            string sql = null;
            string Err = null;

            string spar_UserName = "@par_UserName";
            SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, m_AWPLoginData.UserName);
            lpar.Add(par_UserName);

            string spar_Password = "@par_Password";
            SQL_Parameter par_Password = new SQL_Parameter(spar_Password, SQL_Parameter.eSQL_Parameter.Varbinary, false, m_AWPLoginData.Password);
            lpar.Add(par_Password);


            string spar_PasswordNeverExpires = "@par_PasswordNeverExpires";
            SQL_Parameter par_PasswordNeverExpires = new SQL_Parameter(spar_PasswordNeverExpires, SQL_Parameter.eSQL_Parameter.Bit, false, m_AWPLoginData.PasswordNeverExpires);
            lpar.Add(par_PasswordNeverExpires);

            string spar_Enabled = "@par_Enabled";
            SQL_Parameter par_Enabled = new SQL_Parameter(spar_Enabled, SQL_Parameter.eSQL_Parameter.Bit, false, m_AWPLoginData.Enabled);
            lpar.Add(par_Enabled);

            string spar_ChangePasswordOnFirstLogin = "@par_ChangePasswordOnFirstLogin";
            SQL_Parameter par_ChangePasswordOnFirstLogin = new SQL_Parameter(spar_ChangePasswordOnFirstLogin, SQL_Parameter.eSQL_Parameter.Bit, false, m_AWPLoginData.ChangePasswordOnFirstLogin);
            lpar.Add(par_ChangePasswordOnFirstLogin);


            string spar_Maximum_password_age_in_days = "@par_Maximum_password_age_in_days";
            SQL_Parameter par_Maximum_password_age_in_days = new SQL_Parameter(spar_Maximum_password_age_in_days, SQL_Parameter.eSQL_Parameter.Int, false, m_AWPLoginData.Maximum_password_age_in_days);
            lpar.Add(par_Maximum_password_age_in_days);

            string spar_NotActiveAfterPasswordExpires = "@par_NotActiveAfterPasswordExpires";
            SQL_Parameter par_NotActiveAfterPasswordExpires = new SQL_Parameter(spar_NotActiveAfterPasswordExpires, SQL_Parameter.eSQL_Parameter.Bit, false, m_AWPLoginData.NotActiveAfterPasswordExpires);
            lpar.Add(par_NotActiveAfterPasswordExpires);


            if (PasswordChanged)
            {
                if (IsAdministrator(m_AWPLoginData.ID))
                {
                    if (IsFirstTime(m_AWPLoginData.ID))
                    {
                        m_AWPLoginData.Time_When_AdministratorSetsPassword = DateTime.Now;
                        string spar_Time_When_AdministratorSetsPassword = "@par_Time_When_AdministratorSetsPassword";
                        SQL_Parameter par_Time_When_AdministratorSetsPassword = new SQL_Parameter(spar_Time_When_AdministratorSetsPassword, SQL_Parameter.eSQL_Parameter.Datetime, false, m_AWPLoginData.Time_When_AdministratorSetsPassword);
                        lpar.Add(par_Time_When_AdministratorSetsPassword);

                        string spar_Administrator_LoginUsers_ID = "@par_Administrator_LoginUsers_ID";
                        SQL_Parameter par_Administrator_LoginUsers_ID = new SQL_Parameter(spar_Administrator_LoginUsers_ID, SQL_Parameter.eSQL_Parameter.Datetime, false, m_AWPLoginData.Administrator_LoginUsers_ID);
                        lpar.Add(par_Administrator_LoginUsers_ID);

                        sql = @"update LoginUsers 
                                                    set UserName = " + spar_UserName +
                                                ", Password = " + spar_Password +
                                                ",Enabled = " + spar_Enabled +
                                                ",PasswordNeverExpires = " + spar_PasswordNeverExpires +
                                                ",Time_When_AdministratorSetsPassword = " + spar_Time_When_AdministratorSetsPassword +
                                                ",Time_When_UserSetsItsOwnPassword_FirstTime = " + spar_Time_When_AdministratorSetsPassword+
                                                ",Time_When_UserSetsItsOwnPassword_LastTime = " + spar_Time_When_AdministratorSetsPassword+
                                                ",Administrator_LoginUsers_ID = " + spar_Administrator_LoginUsers_ID +
                                                ",ChangePasswordOnFirstLogin = " + spar_ChangePasswordOnFirstLogin +
                                                ",Maximum_password_age_in_days = " + spar_Maximum_password_age_in_days +
                                                ",NotActiveAfterPasswordExpires = " + spar_NotActiveAfterPasswordExpires +
                                                " where ID = " + spar_LoginUsers_ID;
                    }
                    else
                    {
                        m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.Now;
                        string spar_Time_When_UserSetsItsOwnPassword_LastTime = "@par_Time_When_UserSetsItsOwnPassword_LastTime";
                        SQL_Parameter par_Time_When_UserSetsItsOwnPassword_LastTime = new SQL_Parameter(spar_Time_When_UserSetsItsOwnPassword_LastTime, SQL_Parameter.eSQL_Parameter.Datetime, false, m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime);
                        lpar.Add(par_Time_When_UserSetsItsOwnPassword_LastTime);

                        sql = @"update LoginUsers 
                                                    set UserName = " + spar_UserName +
                                                   ", Password = " + spar_Password +
                                                    ",Enabled = " + spar_Enabled +
                                                    ",PasswordNeverExpires = " + spar_PasswordNeverExpires +
                                                    ",Time_When_UserSetsItsOwnPassword_LastTime = " + spar_Time_When_UserSetsItsOwnPassword_LastTime +
                                                    ",ChangePasswordOnFirstLogin = " + spar_ChangePasswordOnFirstLogin +
                                                    ",Maximum_password_age_in_days = " + spar_Maximum_password_age_in_days +
                                                    ",NotActiveAfterPasswordExpires = " + spar_NotActiveAfterPasswordExpires +
                                                    " where ID = " + spar_LoginUsers_ID;

                    }
                }
                else
                {
                    if (IsFirstTime(m_AWPLoginData.ID))
                    {
                        m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.Now;
                        string spar_Time_When_UserSetsItsOwnPassword_LastTime = "@par_Time_When_UserSetsItsOwnPassword_LastTime";
                        SQL_Parameter par_Time_When_UserSetsItsOwnPassword_LastTime = new SQL_Parameter(spar_Time_When_UserSetsItsOwnPassword_LastTime, SQL_Parameter.eSQL_Parameter.Datetime, false, m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime);
                        lpar.Add(par_Time_When_UserSetsItsOwnPassword_LastTime);
                        sql = @"update LoginUsers 
                                                set UserName = " + spar_UserName +
                                               ", Password = " + spar_Password +
                                                ",Enabled = " + spar_Enabled +
                                                ",PasswordNeverExpires = " + spar_PasswordNeverExpires +
                                                ",Time_When_UserSetsItsOwnPassword_FirstTime = " + spar_Time_When_UserSetsItsOwnPassword_LastTime +
                                                ",Time_When_UserSetsItsOwnPassword_LastTime = " + spar_Time_When_UserSetsItsOwnPassword_LastTime +
                                                ",ChangePasswordOnFirstLogin = " + spar_ChangePasswordOnFirstLogin +
                                                ",Maximum_password_age_in_days = " + spar_Maximum_password_age_in_days +
                                                ",NotActiveAfterPasswordExpires = " + spar_NotActiveAfterPasswordExpires +
                                                " where ID = " + spar_LoginUsers_ID;
                    }
                    else
                    {
                        m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime = DateTime.Now;
                        string spar_Time_When_UserSetsItsOwnPassword_LastTime = "@par_Time_When_UserSetsItsOwnPassword_LastTime";
                        SQL_Parameter par_Time_When_UserSetsItsOwnPassword_LastTime = new SQL_Parameter(spar_Time_When_UserSetsItsOwnPassword_LastTime, SQL_Parameter.eSQL_Parameter.Datetime, false, m_AWPLoginData.Time_When_UserSetsItsOwnPassword_LastTime);
                        lpar.Add(par_Time_When_UserSetsItsOwnPassword_LastTime);
                        sql = @"update LoginUsers 
                                                set UserName = " + spar_UserName +
                                               ", Password = " + spar_Password +
                                                ",Enabled = " + spar_Enabled +
                                                ",PasswordNeverExpires = " + spar_PasswordNeverExpires +
                                                ",Time_When_UserSetsItsOwnPassword_LastTime = " + spar_Time_When_UserSetsItsOwnPassword_LastTime +
                                                ",ChangePasswordOnFirstLogin = " + spar_ChangePasswordOnFirstLogin +
                                                ",Maximum_password_age_in_days = " + spar_Maximum_password_age_in_days +
                                                ",NotActiveAfterPasswordExpires = " + spar_NotActiveAfterPasswordExpires +
                                                " where ID = " + spar_LoginUsers_ID;

                    }

                }
            }
            else
            {
                sql = @"update LoginUsers 
                                         set UserName = " + spar_UserName +
                                        ",Enabled = " + spar_Enabled +
                                        ",PasswordNeverExpires = " + spar_PasswordNeverExpires +
                                        ",ChangePasswordOnFirstLogin = " + spar_ChangePasswordOnFirstLogin +
                                        ",Maximum_password_age_in_days = " + spar_Maximum_password_age_in_days +
                                        ",NotActiveAfterPasswordExpires = " + spar_NotActiveAfterPasswordExpires +
                                        " where ID = " + spar_LoginUsers_ID;
            }

            if (sql==null)
            {
                LogFile.Error.Show("ERROR: LoginControl:AWP_func: Update_LoginUsers_ID:sql = null\r\nErr = " + Err);
                return false; 
            }

            if (con.ExecuteNonQuerySQL(sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:Import_myOrganisationPerson:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        private static bool IsFirstTime(ID LoginUsers_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, false, LoginUsers_ID);
            lpar.Add(par_LoginUsers_ID);

            string sql = @"select Time_When_UserSetsItsOwnPassword_FirstTime  from LoginUsers
                          where Time_When_UserSetsItsOwnPassword_FirstTime  is null and ID = "+ spar_LoginUsers_ID;
            DataTable dt = new DataTable();
            string Err = null;
            if (con.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
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
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:IsAdministrator:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static bool IsAdministrator(ID iD)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, false, iD);
            lpar.Add(par_LoginUsers_ID);

            string spar_Role = "@par_Role";
            string Role = AWP.ROLE_Administrator;
            SQL_Parameter par_Role = new SQL_Parameter(spar_Role, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Role);
            lpar.Add(par_Role);

            string sql = @"select lualr.ID from LoginUsersAndLoginRoles lualr
                          inner join LoginRoles lr on lr.ID = lualr.LoginRoles_ID
                          inner join LoginUsers lu on lu.ID = lualr.LoginUsers_ID
                            where lualr.LoginUsers_ID = " + spar_LoginUsers_ID + " and lr.Role = "+ spar_Role;
            DataTable dt = new DataTable();
            string Err = null;
            if (con.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
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
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:IsAdministrator:sql=" + sql + "\r\nErr=" + Err);
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


        internal static bool Import_myOrganisationPerson(AWPBindingData awpd, DataRow[] drsImportAdministrator, DataRow[] drsImportOthers)
        {
            int iAdminNr = 1;
            foreach (DataRow dr in drsImportAdministrator)
            {
                ID myOrganisation_Person_ID = tf.set_ID(dr[awpd.mcn_myOrganisation_Person_ID.ColumnName]);

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
                    string Administrator_UserName = "admin" + iAdminNr.ToString();
                    string spar_UserName = "@par_UserName";
                    SQL_Parameter par_UserName = new SQL_Parameter(spar_UserName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Administrator_UserName);
                    lpar.Add(par_UserName);

                    iAdminNr++;

                    bool PasswordNeverExpires = true;
                    string spar_PasswordNeverExpires = "@par_PasswordNeverExpires";
                    SQL_Parameter par_PasswordNeverExpires = new SQL_Parameter(spar_PasswordNeverExpires, SQL_Parameter.eSQL_Parameter.Bit, false, PasswordNeverExpires);
                    lpar.Add(par_PasswordNeverExpires);

                    bool Enabled = true;
                    string spar_Enabled = "@par_Enabled";
                    SQL_Parameter par_Enabled = new SQL_Parameter(spar_Enabled, SQL_Parameter.eSQL_Parameter.Bit, false, Enabled);
                    lpar.Add(par_Enabled);

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
                                                   UserName,
                                                   Enabled,
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
                                                   "," + spar_UserName +
                                                   "," + spar_Enabled +
                                                   "," + spar_PasswordNeverExpires +
                                                   ",null" + //Time_When_AdministratorSetsPassword
                                                   ",null" + //Time_When_UserSetsItsOwnPassword_FirstTime
                                                   ",null" + //Time_When_UserSetsItsOwnPassword_LastTime
                                                   ",null" + //Administrator_LoginUsers_ID
                                                   "," + spar_ChangePasswordOnFirstLogin +
                                                   "," + spar_Maximum_password_age_in_days +
                                                   "," + spar_NotActiveAfterPasswordExpires +
                                                   ")";
                    ID LoginUsers_ID =null;

                    if (con.ExecuteNonQuerySQLReturnID(sql, lpar, ref LoginUsers_ID,  ref Err, "LoginUsers"))
                    {
                        ID LoginRoles_ID = null;
                        if (AWP_func.Get_LoginRoles_ID(AWP.ROLE_Administrator, ref LoginRoles_ID))
                        {
                            if (ID.Validate(LoginRoles_ID))
                            {
                                List<SQL_Parameter> lpar1 = new List<SQL_Parameter>();

                                string spar_LoginUsers_ID = "@par_LoginUsers_ID";
                                SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, LoginUsers_ID);
                                lpar1.Add(par_LoginUsers_ID);

                                string spar_LoginRoles_ID = "@par_LoginRoles_ID";
                                SQL_Parameter par_LoginRoles_ID = new SQL_Parameter(spar_LoginRoles_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, LoginRoles_ID);
                                lpar1.Add(par_LoginRoles_ID);

                                sql = @"Insert into LoginUsersAndLoginRoles(LoginUsers_ID,
                                                                    LoginRoles_ID
                                                                   )
                                                   values ("
                                                                + spar_LoginUsers_ID +
                                                               "," + spar_LoginRoles_ID +
                                                           ")";
                                ID LoginUsersAndLoginRoles_ID = null;
                                if (con.ExecuteNonQuerySQLReturnID(sql, lpar1, ref LoginUsersAndLoginRoles_ID, ref Err, "LoginUsersAndLoginRoles"))
                                {
                                    continue;
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

        private static bool Get_LoginRoles_ID(string Role, ref ID loginRoles_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Role = "@par_Role";
            SQL_Parameter par_Role = new SQL_Parameter(spar_Role, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Role);
            lpar.Add(par_Role);

            string sql = @"select ID from LoginRoles where Role = "+ spar_Role;
            string err = null;
            DataTable dt = new DataTable();
            if (con.ReadDataTable(ref dt, sql,lpar, ref err))
            {
                if (dt.Rows.Count>0)
                {
                    loginRoles_ID = tf.set_ID(dt.Rows[0]["ID"]);
                }
                else
                {
                    loginRoles_ID =  null;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:Get_LoginRoles_ID:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }


        internal static bool AWPRoles_GetAll(ref List<AWPRole> AllAWPRoles)
        {
            string sql = @"select ID,Role from LoginRoles";
            string err = null;
            DataTable dt = new DataTable();
            if (AllAWPRoles == null)
            {
                AllAWPRoles = new List<AWPRole>();
            }
            else
            {
                AllAWPRoles.Clear();
            }

            if (con.ReadDataTable(ref dt, sql, ref err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AllAWPRoles.Add(new AWPRole(new ID(dr["ID"]), (string)dr["Role"]));
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:AWPRoles_GetAll:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        private static bool remove_WriteInvoiceAndProformaInvoice()
        {
            string err = null;
            string sql = "delete from LoginRoles where Role = 'WriteInvoiceAndProformaInvoice'";
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null,  ref err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:remove_WriteInvoiceAndProformaInvoice:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        private static bool Check_Role_WriteInvoice(ID id_WriteInvoiceAndProformaInvoice)
        {
            if (ID.Validate(id_WriteInvoiceAndProformaInvoice))
            {
                ID id_WriteInvoice = null;
                if (Get_LoginRoles_ID("WriteInvoice", ref id_WriteInvoice))
                {
                    if (ID.Validate(id_WriteInvoice))
                    {
                        return remove_WriteInvoiceAndProformaInvoice();
                    }
                    else
                    {
                        string sql = "update LoginRoles set Role = 'WriteInvoice' where ID = "+ id_WriteInvoiceAndProformaInvoice.ToString();
                        string err = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref err))
                        {
                            return remove_WriteInvoiceAndProformaInvoice();
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:LoginControl:AWP_func:Check_Role_WriteInvoice:sql=" + sql + "\r\nErr=" + err);
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                ID id_WriteInvoice = null;
                if (Get_LoginRoles_ID("WriteInvoice", ref id_WriteInvoice))
                {
                    if (ID.Validate(id_WriteInvoice))
                    {
                        return remove_WriteInvoiceAndProformaInvoice();
                    }
                    else
                    {
                        string sql = "insert into LoginRoles (Role)values('WriteInvoice')";
                        string err = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref err))
                        {
                            return remove_WriteInvoiceAndProformaInvoice();
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:LoginControl:AWP_func:Check_Role_WriteInvoice:sql=" + sql + "\r\nErr=" + err);
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private static bool Correct_Roles(ID id_WriteInvoiceAndProformaInvoice)
        {
            string sql = null;
            if (ID.Validate(id_WriteInvoiceAndProformaInvoice))
            { 
                ID id_WriteProformaInvoice = null;
                if (Get_LoginRoles_ID("WriteProformaInvoice", ref id_WriteProformaInvoice))
                {
                    if (ID.Validate(id_WriteProformaInvoice))
                    {
                        return Check_Role_WriteInvoice(id_WriteInvoiceAndProformaInvoice);
                    }
                    else
                    {
                        string err = null;
                        sql = "update LoginRoles set Role = 'WriteProformaInvoice' where ID = " + id_WriteInvoiceAndProformaInvoice.ToString();
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref err))
                        {
                            return Check_Role_WriteInvoice(null);
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:LoginControl:AWP_func:AWPRoles_GetUserRoles:sql=" + sql + "\r\nErr=" + err);
                            return false;
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        internal static bool AWPRoles_GetUserRoles(ID LoginUsers_ID, ref List<AWPRole> AWPRoles)
        {
AWPRoles_GetUserRoles_start:

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, false, LoginUsers_ID);
            lpar.Add(par_LoginUsers_ID);
            string sql = @"select 
                           lr.ID as ID,
                           lr.Role as Role
                           from LoginUsersAndLoginRoles lualr
                           inner join LoginUsers lu on lualr.LoginUsers_ID = lu.ID
                           inner join LoginRoles lr on lualr.LoginRoles_ID = lr.ID
                           where lualr.LoginUsers_ID = "+ spar_LoginUsers_ID;
            string err = null;
            DataTable dt = new DataTable();
            if (AWPRoles==null)
            {
                AWPRoles = new List<AWPRole>();
            }
            else
            {
                AWPRoles.Clear();
            }

            if (con.ReadDataTable(ref dt,sql,lpar, ref err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string srole = tf._set_string(dr["Role"]);

                    if (srole.Equals("WriteInvoiceAndProformaInvoice"))
                    {
                        ID id_WriteInvoiceAndProformaInvoice = tf.set_ID(dr["ID"]);
                        if (Correct_Roles(id_WriteInvoiceAndProformaInvoice))
                        {
                            goto AWPRoles_GetUserRoles_start;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    AWPRoles.Add(new AWPRole(new ID(dr["ID"]), srole));
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:GetUserRoles:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }

        internal static bool AWPRoles_GetRoles_User_Does_Not_Have(ID LoginUsers_ID, ref List<AWPRole> AWPRoles)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_LoginUsers_ID = "@par_LoginUsers_ID";
            SQL_Parameter par_LoginUsers_ID = new SQL_Parameter(spar_LoginUsers_ID, false, LoginUsers_ID);
            lpar.Add(par_LoginUsers_ID);
            string sql = @"select ID,Role from LoginRoles where ID not in (select 
                           lr.ID
                           from LoginUsersAndLoginRoles lualr
                           inner join LoginUsers lu on lualr.LoginUsers_ID = lu.ID
                           inner join LoginRoles lr on lualr.LoginRoles_ID = lr.ID
                           where lualr.LoginUsers_ID = " + spar_LoginUsers_ID +")";
            string err = null;
            DataTable dt = new DataTable();
            if (AWPRoles == null)
            {
                AWPRoles = new List<AWPRole>();
            }
            else
            {
                AWPRoles.Clear();
            }
            if (con.ReadDataTable(ref dt, sql, lpar, ref err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string xrl = null;
                    string rl = null;
                    object orl = dr["Role"];
                    if (orl is string)
                    {
                        rl = (string)orl;
                        if (rl != null)
                        {
                            if (rl.Length > 0)
                            {
                                xrl = rl;
                            }
                        }
                    }
                    if (xrl != null)
                    {
                        AWPRoles.Add(new AWPRole(new ID(dr["ID"]), xrl));
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:LoginControl:AWP_func:AWPRoles_GetRoles_User_Does_Not_Have:sql=" + sql + "\r\nErr=" + err);
                return false;
            }
        }
    }
}
