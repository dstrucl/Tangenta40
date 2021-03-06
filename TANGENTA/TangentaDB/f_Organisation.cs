﻿#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using CodeTables;
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
    public class f_Organisation
    {
        public static bool Get(string_v Organisation_Name_v,
                                 string_v Tax_ID_v,
                                 string_v Registration_ID_v,
                                 bool_v TaxPayer_v,
                                 string_v Comment1_v,
                                 string_v OrganisationTYPE_v,
                                 PostAddress_v Address_v,
                                 string_v PhoneNumber_v,
                                 string_v FaxNumber_v,
                                 string_v Email_v,
                                 string_v HomePage_v,
                                 long_v BankAccount_ID_v,
                                 string_v Organisation_BankAccount_Description_v,
                                 string_v Image_Hash_v,
                                 byte_array_v Image_Data_v,
                                 string_v Image_Description_v,
                                 ref ID_v cAdressAtom_Org_iD_v,
                                 ref long_v Organisation_ID_v,
                                 ref long_v OrganisationData_ID_v,
                                 ref long_v OrganisationAccount_ID_v)
        {
            string Err = null;
            string Name_condition = null;
            string Tax_ID_condition = null;
            string Registration_ID_condition = null;

            string sName_value = null;
            string sTaxID_value = null;
            string sRegistration_ID_value = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            if (Tax_ID_v != null)
            {
                SQL_Parameter par_Tax_ID = new SQL_Parameter("@par_Tax_ID", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Tax_ID_v.v);
                lpar.Add(par_Tax_ID);
                Tax_ID_condition = " Tax_ID = " + par_Tax_ID.Name + " ";
                sTaxID_value = "@par_Tax_ID";
            }
            else
            {
                Tax_ID_condition = " Tax_ID is null ";
                sTaxID_value = "null";
            }

            if (Organisation_Name_v != null)
            {
                SQL_Parameter par_Name = new SQL_Parameter("@par_Name", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Organisation_Name_v.v);
                lpar.Add(par_Name);
                Name_condition = " Name = " + par_Name.Name + " ";
                sName_value = "@par_Name";
            }
            else
            {
                Name_condition = " Name is null ";
                sName_value = "null";
            }

            string TaxPayer_condition = null;
            string TaxPayer_value = null;
            SQL_Parameter par_TaxPayer = null;
            if (TaxPayer_v != null)
            {
                par_TaxPayer = new SQL_Parameter("@par_TaxPayer", SQL_Parameter.eSQL_Parameter.Bit, false, TaxPayer_v.v);
                lpar.Add(par_TaxPayer);
                TaxPayer_condition = " TaxPayer = " + par_TaxPayer.Name + " ";
                TaxPayer_value = "@par_TaxPayer";
            }
            else
            {
                TaxPayer_condition = " TaxPayer  is null ";
                TaxPayer_value = "null";
            }

            long_v Comment1_ID_v = null;
            string Comment1_ID_condition = " Comment1_ID  is null ";
            string Comment1_ID_value = "null";
            SQL_Parameter par_Comment1_ID = null;
            if (Comment1_v != null)
            {
                if (f_Comment1.Get(Comment1_v.v, ref Comment1_ID_v))
                {
                    par_Comment1_ID = new SQL_Parameter("@par_Comment1_ID", SQL_Parameter.eSQL_Parameter.Bigint, false, Comment1_ID_v.v);
                    lpar.Add(par_Comment1_ID);
                    Comment1_ID_condition = " Comment1_ID = " + par_Comment1_ID.Name + " ";
                    Comment1_ID_value = "@par_Comment1_ID";
                }
                else
                {
                    return false;
                }
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


            string sql_select = "select ID,Registration_ID from Organisation where " + Name_condition + @" and 
                                                                                   " + Tax_ID_condition + @" and 
                                                                                   " + TaxPayer_condition + @" and 
                                                                                   " + Comment1_ID_condition;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Organisation_ID_v == null)
                    {
                        Organisation_ID_v = new long_v();
                    }
                    Organisation_ID_v.v = (long)dt.Rows[0]["ID"];

                    object oRegistration_ID = dt.Rows[0]["Registration_ID"];
                    if (oRegistration_ID is string)
                    {
                        string registration_ID = (string)oRegistration_ID;
                        if (Registration_ID_v == null)
                        {
                            List<SQL_Parameter> lpar1 = new List<SQL_Parameter>();
                            if (par_TaxPayer != null)
                            {
                                lpar1.Add(par_TaxPayer);
                            }
                            if (par_Comment1_ID != null)
                            {
                                lpar1.Add(par_Comment1_ID);
                            }
                            string sql = "update Organisation set Registration_ID = null"
                                 +", TaxPayer = " + TaxPayer_value
                                             + ", Comment1_ID = " + Comment1_ID_value
                                + " where ID = " + Organisation_ID_v.v.ToString();
                            object ores = null;
                            if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar1, ref ores, ref Err))
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_Organisation:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            if (!(Registration_ID_v.v.Equals(registration_ID)))
                            {
                                List<SQL_Parameter> lpar1 = new List<SQL_Parameter>();
                                string spar_Registration_ID = "@par_Registration_ID";
                                SQL_Parameter par_Registration_ID = new SQL_Parameter(spar_Registration_ID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Registration_ID_v.v);
                                lpar1.Add(par_Registration_ID);
                                if  (par_TaxPayer!=null)
                                {
                                    lpar1.Add(par_TaxPayer);
                                }
                                if (par_Comment1_ID!=null)
                                {
                                    lpar1.Add(par_Comment1_ID);
                                }
                                string sql = "update Organisation set Registration_ID = " + spar_Registration_ID 
                                             + ", TaxPayer = " + TaxPayer_value
                                             + ", Comment1_ID = " + Comment1_ID_value
                                             + " where ID = " + Organisation_ID_v.v.ToString();
                                object ores = null;
                                if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar1, ref ores, ref Err))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:f_Organisation:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Registration_ID_v != null)
                        {
                            List<SQL_Parameter> lpar1 = new List<SQL_Parameter>();
                            string spar_Registration_ID = "@par_Registration_ID";
                            SQL_Parameter par_Registration_ID = new SQL_Parameter(spar_Registration_ID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Registration_ID_v.v);
                            lpar1.Add(par_Registration_ID);


                            if (par_TaxPayer != null)
                            {
                                lpar1.Add(par_TaxPayer);
                            }
                            if (par_Comment1_ID != null)
                            {
                                lpar1.Add(par_Comment1_ID);
                            }
                            string sql = "update Organisation set Registration_ID = " + spar_Registration_ID
                                         + ", TaxPayer = " + TaxPayer_value
                                         + ", Comment1_ID = " + Comment1_ID_value
                                         + " where ID = " + Organisation_ID_v.v.ToString();
                            object ores = null;
                            if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar1, ref ores, ref Err))
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_Organisation:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }

                    if (f_OrganisationData.Get(Organisation_ID_v.v,
                                                       OrganisationTYPE_v,
                                                       Address_v,
                                                       PhoneNumber_v,
                                                       FaxNumber_v,
                                                       Email_v,
                                                       HomePage_v,
                                                       Image_Hash_v,
                                                       Image_Data_v,
                                                       Image_Description_v,
                                                       ref cAdressAtom_Org_iD_v,
                                                       ref OrganisationData_ID_v))
                    {
                        if (BankAccount_ID_v != null)
                        {
                            return f_OrganisationAccount.Get(BankAccount_ID_v,
                                                      Organisation_ID_v,
                                                      Organisation_BankAccount_Description_v,
                                                      ref OrganisationAccount_ID_v);
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    string sql_insert = " insert into Organisation  (Name,Tax_ID,Registration_ID,TaxPayer,Comment1_ID) values (" + sName_value + "," + sTaxID_value + "," + sRegistration_ID_value + "," + TaxPayer_value + "," + Comment1_ID_value +")";
                    object oret = null;
                    long Organisation_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref Organisation_ID, ref oret, ref Err, "Organisation"))
                    {
                        if (Organisation_ID_v == null)
                        {
                            Organisation_ID_v = new long_v();
                        }
                        Organisation_ID_v.v = Organisation_ID;
                        if (f_OrganisationData.Get(Organisation_ID_v.v,
                                                                               OrganisationTYPE_v,
                                                                               Address_v,
                                                                               PhoneNumber_v,
                                                                               FaxNumber_v,
                                                                               Email_v,
                                                                               HomePage_v,
                                                                               Image_Hash_v,
                                                                               Image_Data_v,
                                                                               Image_Description_v,
                                                                                ref cAdressAtom_Org_iD_v,
                                                                               ref OrganisationData_ID_v))
                        {
                            if (BankAccount_ID_v != null)
                            {
                                return f_OrganisationAccount.Get(BankAccount_ID_v,
                                                          Organisation_ID_v,
                                                          Organisation_BankAccount_Description_v,
                                                          ref OrganisationAccount_ID_v);
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Organisation:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Organisation:Get:sql=" + sql_select + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(string_v Organisation_Name_v,
                                 string_v Tax_ID_v,
                                 string_v Registration_ID_v,
                                 ref long_v Organisation_ID_v
                                 )
        {
            string Err = null;
            string Name_condition = null;
            string Tax_ID_condition = null;
            string Registration_ID_condition = null;

            string sName_value = null;
            string sTaxID_value = null;
            string sRegistration_ID_value = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            if (Organisation_Name_v != null)
            {
                SQL_Parameter par_Name = new SQL_Parameter("@par_Name", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Organisation_Name_v.v);
                lpar.Add(par_Name);
                Name_condition = " Name = " + par_Name.Name + " ";
                sName_value = "@par_Name";
            }
            else
            {
                Name_condition = " Name is null ";
                sName_value = "null";
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


            string sql_select = "select ID from Organisation where " + Name_condition + @" and 
                                                                        " + Tax_ID_condition + @" and  
                                                                        " + Registration_ID_condition;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Organisation_ID_v == null)
                    {
                        Organisation_ID_v = new long_v();
                    }
                    Organisation_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string sql_insert = " insert into Organisation  (Name,Tax_ID,Registration_ID) values (" + sName_value + "," + sTaxID_value + "," + sRegistration_ID_value + ")";
                    object oret = null;
                    long Organisation_ID = -1;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref Organisation_ID, ref oret, ref Err, "Organisation"))
                    {
                        if (Organisation_ID_v == null)
                        {
                            Organisation_ID_v = new long_v();
                        }
                        Organisation_ID_v.v = Organisation_ID;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Organisation:Get:sql=" + sql_insert + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Organisation:Get:sql=" + sql_select + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool DeleteAll()
        {
            return fs.DeleteAll("Organisation");
        }
    }
}
