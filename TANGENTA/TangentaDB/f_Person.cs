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

namespace TangentaDB
{
    public class f_Person
    {
        public static bool Get(bool_v Person_Gender_v,
                                 string_v FirstName_v,
                                 string_v LastName_v,
                                 DateTime_v DateOfBirth_v,
                                 string_v Tax_ID_v,
                                 string_v Registration_ID_v,
                                 ref ID Person_ID,
                                 Transaction transaction
                                 )
        {
            string Err = null;
            string Gender_condition = null;
            string sGender_value = null;

            string cFirstName_ID_condition = null;
            string cLastName_ID_condition = null;

            string Tax_ID_condition = null;
            string Registration_ID_condition = null;
            string DateOfBirth_condition = null;

            string scFirstName_ID_value = null;
            string scLastName_ID_value = null;

            string sTaxID_value = null;
            string sRegistration_ID_value = null;
            string sDateOfBirth_value = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            ID cFirstName_ID = null;
            if (f_cFirstName.Get(FirstName_v, ref cFirstName_ID))
            {
                ID cLastName_ID = null;
                if (f_cLastName.Get(LastName_v, ref cLastName_ID))
                {

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

                    if (ID.Validate(cFirstName_ID))
                    {
                        string spar_cFirstName_ID = "@par_cFirstName_ID";
                        SQL_Parameter par_FirstName = new SQL_Parameter(spar_cFirstName_ID, false, cFirstName_ID);
                        lpar.Add(par_FirstName);
                        cFirstName_ID_condition = " cFirstName_ID = " + spar_cFirstName_ID + " ";
                        scFirstName_ID_value = spar_cFirstName_ID;
                    }
                    else
                    {
                        cFirstName_ID_condition = " cFirstName_ID is null ";
                        scFirstName_ID_value = "null";
                    }

                    if (ID.Validate(cLastName_ID))
                    {
                        string spar_cLastName_ID = "@par_cLastName_ID";
                        SQL_Parameter par_LastName = new SQL_Parameter(spar_cLastName_ID, false, cLastName_ID);
                        lpar.Add(par_LastName);
                        cLastName_ID_condition = " cLastName_ID = " + spar_cLastName_ID + " ";
                        scLastName_ID_value = spar_cLastName_ID;
                    }
                    else
                    {
                        cLastName_ID_condition = " cLastName_ID is null ";
                        scLastName_ID_value = "null";
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
                        string spar_DateOfBirth = "@par_DateOfBirth";
                        SQL_Parameter par_DateOfBirth = new SQL_Parameter(spar_DateOfBirth, SQL_Parameter.eSQL_Parameter.Datetime, false, DateOfBirth_v.v);
                        lpar.Add(par_DateOfBirth);
                        DateOfBirth_condition = " DateOfBirth = " + spar_DateOfBirth + " ";
                        sDateOfBirth_value = spar_DateOfBirth;
                    }
                    else
                    {
                        DateOfBirth_condition = " DateOfBirth is null ";
                        sDateOfBirth_value = "null";
                    }

                    string sql_select = "select ID from Person where " + Gender_condition + @" and 
                                                                    " + cFirstName_ID_condition + @" and 
                                                                     " + cLastName_ID_condition + @" and 
                                                                      " + DateOfBirth_condition + @" and 
                                                                     " + Tax_ID_condition + @" and  
                                                                     " + Registration_ID_condition;
                    DataTable dt = new DataTable();
                    if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (Person_ID == null)
                            {
                                Person_ID = new ID();
                            }
                            Person_ID.Set(dt.Rows[0]["ID"]);
                            return true;
                        }
                        else
                        {
                            if (!transaction.Get(DBSync.DBSync.Con))
                            {
                                return false;
                            }
                            string sql_insert = @" insert into Person  (Gender,
                                                                    cFirstName_ID,
                                                                    cLastName_ID,
                                                                    DateOfBirth,
                                                                    Tax_ID,
                                                                    Registration_ID) values (" + sGender_value + ","
                                                                                                  + scFirstName_ID_value + ","
                                                                                                  + scLastName_ID_value + ","
                                                                                                  + sDateOfBirth_value + ","
                                                                                                  + sTaxID_value + ","
                                                                                                  + sRegistration_ID_value + ")";
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref Person_ID, ref Err, "Person"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Person:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Person:Getn:sql=" + sql_select + "\r\nErr=" + Err);
                    }
                }
            }
            return false;
        }

        public static bool GetData(ID Person_ID,
                                   ref string_v FirstName_v,
                                   ref string_v LastName_v,
                                   ref DateTime_v DateOfBirth_v,
                                   ref string_v Tax_ID_v,
                                   ref string_v Registration_ID_v
                                   )
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select Person_$_cfn_$$FirstName,
                                  Person_$_cln_$$LastName,
                                  Person_$$DateOfBirth,
                                  Person_$$Tax_ID,
                                  Person_$$Registration_ID from Person_VIEW where ID = " + Person_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object oFirstName = dt.Rows[0]["Person_$_cfn_$$FirstName"];
                    if (oFirstName is string)
                    {
                        FirstName_v = new string_v((string)oFirstName);
                    }
                    else
                    {
                        FirstName_v = null;
                    }

                    object oLastName = dt.Rows[0]["Person_$_cln_$$LastName"];
                    if (oLastName is string)
                    {
                        LastName_v = new string_v((string)oLastName);
                    }
                    else
                    {
                        LastName_v = null;
                    }



                    object oDateOfBirth = dt.Rows[0]["Person_$$DateOfBirth"];
                    if (oDateOfBirth is DateTime)
                    {
                        DateOfBirth_v = new DateTime_v((DateTime)oDateOfBirth);
                    }
                    else
                    {
                        DateOfBirth_v = null;
                    }


                    object oTax_ID = dt.Rows[0]["Person_$$Tax_ID"];
                    if (oTax_ID is string)
                    {
                        Tax_ID_v = new string_v((string)oTax_ID);
                    }
                    else
                    {
                        Tax_ID_v = null;
                    }


                    object oRegistration_ID = dt.Rows[0]["Person_$$Registration_ID"];
                    if (oRegistration_ID is string)
                    {
                        Registration_ID_v = new string_v((string)oRegistration_ID);
                    }
                    else
                    {
                        Registration_ID_v = null;
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Person:GetData:sql=" + sql + "\r\n No Person data for Person_ID = "+ Person_ID.ToString());
                    return false;
                }
                
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Person:GetData:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }
        public static bool DeleteAll()
        {
            return fs.DeleteAll("Person");
        }
    }
}
