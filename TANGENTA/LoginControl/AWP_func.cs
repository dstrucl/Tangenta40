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
        internal static bool Read_Login_VIEW(DBConnection Login_con,ref DataTable dt, ref string Err)
        {
            string sql = @"
            SELECT 
            LoginUsers.ID, 
            LoginUsers.PasswordNeverExpires AS LoginUsers_$$PasswordNeverExpires,
            LoginUsers.Time_When_AdministratorSetsPassword AS LoginUsers_$$Time_When_AdministratorSetsPassword,
            LoginUsers.Time_When_UserSetsItsOwnPassword_FirstTime AS LoginUsers_$$Time_When_UserSetsItsOwnPassword_FirstTime,
            LoginUsers.Time_When_UserSetsItsOwnPassword_LastTime AS LoginUsers_$$Time_When_UserSetsItsOwnPassword_LastTime,
            LoginUsers.Administrator_LoginUsers_ID AS LoginUsers_$$Administrator_LoginUsers_ID,
            LoginUsers.ChangePasswordOnFirstLogin AS LoginUsers_$$ChangePasswordOnFirstLogin,
            LoginUsers.Maximum_password_age_in_days AS LoginUsers_$$Maximum_password_age_in_days,
            LoginUsers.NotActiveAfterPasswordExpires AS LoginUsers_$$NotActiveAfterPasswordExpires, 
            LoginUsers_$_mcomper.ID AS LoginUsers_$_mcomper_$$ID, 
            LoginUsers_$_mcomper.UserName AS username,
            LoginUsers_$_mcomper.Password AS password,
            LoginUsers_$_mcomper.Job AS LoginUsers_$_mcomper_$$Job,
            LoginUsers_$_mcomper.Active AS LoginUsers_$_mcomper_$$Active,
            LoginUsers_$_mcomper.Description AS LoginUsers_$_mcomper_$$Description,
            LoginUsers_$_mcomper_$_per.ID AS LoginUsers_$_mcomper_$_per_$$ID,
            LoginUsers_$_mcomper_$_per.Gender AS LoginUsers_$_mcomper_$_per_$$Gender,
            LoginUsers_$_mcomper_$_per_$_cfn.ID AS LoginUsers_$_mcomper_$_per_$_cfn_$$ID,
            LoginUsers_$_mcomper_$_per_$_cfn.FirstName AS LoginUsers_$_mcomper_$_per_$_cfn_$$FirstName,
            LoginUsers_$_mcomper_$_per_$_cln.ID AS LoginUsers_$_mcomper_$_per_$_cln_$$ID,
            LoginUsers_$_mcomper_$_per_$_cln.LastName AS LoginUsers_$_mcomper_$_per_$_cln_$$LastName,
            LoginUsers_$_mcomper_$_per.DateOfBirth AS LoginUsers_$_mcomper_$_per_$$DateOfBirth,
            LoginUsers_$_mcomper_$_per.Tax_ID AS LoginUsers_$_mcomper_$_per_$$Tax_ID,
            LoginUsers_$_mcomper_$_per.Registration_ID AS LoginUsers_$_mcomper_$_per_$$Registration_ID,
            LoginUsers_$_mcomper_$_office.ID AS LoginUsers_$_mcomper_$_office_$$ID,
            LoginUsers_$_mcomper_$_office.Name AS LoginUsers_$_mcomper_$_office_$$Name,
            LoginUsers_$_mcomper_$_office.ShortName AS LoginUsers_$_mcomper_$_office_$$ShortName
            FROM LoginUsers 
            INNER JOIN myOrganisation_Person LoginUsers_$_mcomper ON LoginUsers.myOrganisation_Person_ID = LoginUsers_$_mcomper.ID 
            INNER JOIN Person LoginUsers_$_mcomper_$_per ON LoginUsers_$_mcomper.Person_ID = LoginUsers_$_mcomper_$_per.ID 
            INNER JOIN cFirstName LoginUsers_$_mcomper_$_per_$_cfn ON LoginUsers_$_mcomper_$_per.cFirstName_ID = LoginUsers_$_mcomper_$_per_$_cfn.ID 
            LEFT JOIN cLastName LoginUsers_$_mcomper_$_per_$_cln ON LoginUsers_$_mcomper_$_per.cLastName_ID = LoginUsers_$_mcomper_$_per_$_cln.ID 
            INNER JOIN Office LoginUsers_$_mcomper_$_office ON LoginUsers_$_mcomper.Office_ID = LoginUsers_$_mcomper_$_office.ID 
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
            if (Login_con.ReadDataTable(ref dt, sql,ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
