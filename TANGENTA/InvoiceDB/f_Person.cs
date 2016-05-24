#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public class f_Person
    {
        public static bool Get(bool_v Person_Gender_v,
                                 string_v FirstName_v,
                                 string_v LastName_v,
                                 DateTime_v DateOfBirth_v,
                                 string_v Tax_ID_v,
                                 string_v Registration_ID_v,
                                 ref long_v Person_ID_v)
        {
            string Err = null;
            string Gender_condition = null;
            string sGender_value = null;

            string FirstName_condition = null;
            string LastName_condition = null;

            string Tax_ID_condition = null;
            string Registration_ID_condition = null;
            string DateOfBirth_condition = null;

            string sFirstName_value = null;
            string sLastName_value = null;

            string sTaxID_value = null;
            string sRegistration_ID_value = null;
            string sDateOfBirth_value = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            if (Person_Gender_v != null)
            {
                string spar_Gender = "@par_Gender";
                SQL_Parameter par_Gender = new SQL_Parameter(spar_Gender, SQL_Parameter.eSQL_Parameter.Bit, false, Person_Gender_v.v);
                lpar.Add(par_Gender);
                Gender_condition = " Gender = " + spar_Gender + " ";
                sGender_value = spar_Gender;
            }
            else
            {
                Gender_condition = " Gender is null ";
                sGender_value = "null";
            }

            if (FirstName_v != null)
            {
                string spar_FirstName = "@par_FirstName";
                SQL_Parameter par_FirstName = new SQL_Parameter(spar_FirstName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FirstName_v.v);
                lpar.Add(par_FirstName);
                FirstName_condition = " FirstName = " + spar_FirstName + " ";
                sFirstName_value = spar_FirstName;
            }
            else
            {
                FirstName_condition = " FirstName is null ";
                sFirstName_value = "null";
            }


            if (LastName_v != null)
            {
                string spar_LastName = "@par_LastName";
                SQL_Parameter par_LastName = new SQL_Parameter(spar_LastName, SQL_Parameter.eSQL_Parameter.Nvarchar, false, LastName_v.v);
                lpar.Add(par_LastName);
                LastName_condition = " LastName = " + spar_LastName + " ";
                sLastName_value = spar_LastName;
            }
            else
            {
                LastName_condition = " LastName is null ";
                sLastName_value = "null";
            }

            if (Tax_ID_v != null)
            {
                SQL_Parameter par_Tax_ID = new SQL_Parameter("@par_Tax_ID", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Tax_ID_v.v);
                lpar.Add(par_Tax_ID);
                Tax_ID_condition = " Tax_ID = " + par_Tax_ID.Name + " ";
                sTaxID_value = "@par_Tax_ID";
            }
            else
            {
                Tax_ID_condition = " Tax_ID  is null ";
                sTaxID_value = "null";
            }
            if (Registration_ID_v != null)
            {
                SQL_Parameter par_Registration_ID = new SQL_Parameter("@par_Registration_ID", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Registration_ID_v.v);
                lpar.Add(par_Registration_ID);
                Registration_ID_condition = " Registration_id = " + par_Registration_ID.Name + " ";
                sRegistration_ID_value = "@par_Registration_ID";
            }
            else
            {
                Registration_ID_condition = " Registration_ID is null ";
                sRegistration_ID_value = "null";
            }

            if (DateOfBirth_v != null)
            {
                string spar_DateOfBirth = "@par_DateOfBirth_ID";
                SQL_Parameter par_DateOfBirth_ID = new SQL_Parameter(spar_DateOfBirth, SQL_Parameter.eSQL_Parameter.Datetime, false, DateOfBirth_v.v);
                lpar.Add(par_DateOfBirth_ID);
                DateOfBirth_condition = " DateOfBirth_id = " + spar_DateOfBirth + " ";
                sDateOfBirth_value = spar_DateOfBirth;
            }
            else
            {
                DateOfBirth_condition = " DateOfBirth_ID is null ";
                sDateOfBirth_value = "null";
            }

            string sql_select = "select ID from Person where " + Gender_condition + @" and 
                                                            " + FirstName_condition + @" and 
                                                             " + LastName_condition + @" and 
                                                              "+ DateOfBirth_condition+ @" and 
                                                             " + Tax_ID_condition + @" and  
                                                             " + Registration_ID_condition;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Person_ID_v == null)
                    {
                        Person_ID_v = new long_v();
                    }
                    Person_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string sql_insert = @" insert into Person  (Gender,
                                                                FirstName,
                                                                LastName,
                                                                DateOfBirth,
                                                                Tax_ID,
                                                                Registration_ID) values ("+ sGender_value+"," 
                                                                                          + sFirstName_value + ","
                                                                                          + sLastName_value + ","
                                                                                          + sDateOfBirth_value + ","
                                                                                          + sTaxID_value + "," 
                                                                                          + sRegistration_ID_value + ")";
                    object oret = null;
                    long Person_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref Person_ID, ref oret, ref Err, "Atom_Person"))
                    {
                        if (Person_ID_v == null)
                        {
                            Person_ID_v = new long_v();
                        }
                        Person_ID_v.v = Person_ID;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Person:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Person:Getn:sql=" + sql_select + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
