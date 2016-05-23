#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTypes;

namespace InvoiceDB
{
    public static class f_cCountry_Person
    {
        public static bool Get(string Country,
            string Country_ISO_3166_a2,
            string Country_ISO_3166_a3,
            short Country_ISO_3166_num,
            ref long cCountry_Person_ID)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_Country = "@par_Country";
            SQL_Parameter par_Country = new SQL_Parameter(spar_Country, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Country);
            lpar.Add(par_Country);


            string spar_Country_ISO_3166_a2 = "@par_Country_ISO_3166_a2";
            SQL_Parameter par_Country_ISO_3166_a2 = new SQL_Parameter(spar_Country_ISO_3166_a2, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Country_ISO_3166_a2);
            lpar.Add(par_Country_ISO_3166_a2);


            string spar_Country_ISO_3166_a3 = "@par_Country_ISO_3166_a3";
            SQL_Parameter par_Country_ISO_3166_a3 = new SQL_Parameter(spar_Country_ISO_3166_a3, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Country_ISO_3166_a3);
            lpar.Add(par_Country_ISO_3166_a3);


            string spar_Country_ISO_3166_num = "@par_Country_ISO_3166_num";
            SQL_Parameter par_Country_ISO_3166_num = new SQL_Parameter(spar_Country_ISO_3166_num, SQL_Parameter.eSQL_Parameter.Smallint, false, Country_ISO_3166_num);
            lpar.Add(par_Country_ISO_3166_num);

            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select ID from cCountry_Person where Country= " + spar_Country + " and  Country_ISO_3166_a2 = " + spar_Country_ISO_3166_a2 + " and Country_ISO_3166_a3 = " + spar_Country_ISO_3166_a3 + " and Country_ISO_3166_num = " + spar_Country_ISO_3166_num;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    cCountry_Person_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into cCountry_Person (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num) values (" + spar_Country + "," + spar_Country_ISO_3166_a2 + "," + spar_Country_ISO_3166_a3 + "," + spar_Country_ISO_3166_num + ")";
                    object objretx = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cCountry_Person_ID, ref objretx, ref Err, "cCountry_Person"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_cCountry_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_cCountry_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)
        {
            if ((state_v != null) && (state_ISO_3166_a2_v != null) && (state_ISO_3166_a3_v != null) && (state_ISO_3166_num_v != null))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_state_v = "@par_state_v";
                SQL_Parameter par_state_v = new SQL_Parameter(spar_state_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, state_v.v);
                lpar.Add(par_state_v);
                string spar_state_ISO_3166_a2_v = "@par_state_ISO_3166_a2_v";
                SQL_Parameter par_state_ISO_3166_a2_v = new SQL_Parameter(spar_state_ISO_3166_a2_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, state_ISO_3166_a2_v.v);
                lpar.Add(par_state_ISO_3166_a2_v);
                string spar_state_ISO_3166_a3_v = "@par_state_ISO_3166_a3_v";
                SQL_Parameter par_state_ISO_3166_a3_v = new SQL_Parameter(spar_state_ISO_3166_a3_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, state_ISO_3166_a3_v.v);
                lpar.Add(par_state_ISO_3166_a3_v);

                string spar_state_ISO_3166_num_v = "@par_state_ISO_3166_num_v";
                SQL_Parameter par_state_ISO_3166_num_v = new SQL_Parameter(spar_state_ISO_3166_num_v, SQL_Parameter.eSQL_Parameter.Smallint, false, state_ISO_3166_num_v.v);
                lpar.Add(par_state_ISO_3166_num_v);


                string sql = @"select ID from cCountry_Person where Country= " + spar_state_v
                                                                            + " and Country_ISO_3166_a2 = " + spar_state_ISO_3166_a2_v
                                                                            + " and Country_ISO_3166_a3 =" + spar_state_ISO_3166_a3_v
                                                                            + " and Country_ISO_3166_num =" + spar_state_ISO_3166_num_v;
                DataTable dt = new DataTable();
                string Err = null;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (atom_cCountry_Person_ID_v == null)
                        {
                            atom_cCountry_Person_ID_v = new long_v();
                        }
                        atom_cCountry_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into cCountry_Person (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num) values (" + spar_state_v + ","
                                                                                                                                    + spar_state_ISO_3166_a2_v + ","
                                                                                                                                    + spar_state_ISO_3166_a3_v + ","
                                                                                                                                    + spar_state_ISO_3166_num_v + ")";
                        long cCountry_Person_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cCountry_Person_ID, ref oret, ref Err, "cCountry_Person"))
                        {
                            if (atom_cCountry_Person_ID_v == null)
                            {
                                atom_cCountry_Person_ID_v = new long_v();
                            }
                            atom_cCountry_Person_ID_v.v = cCountry_Person_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:InvoiceDB:f_cCountry_Person:Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)\r\nsql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceDB:f_cCountry_Person:Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)\r\nsql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceDB:f_cCountry_Person:Get(string_v state_v, string_v state_ISO_3166_a2_v, string_v state_ISO_3166_a3_v, short_v state_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)\r\n state_v may not be null!");
                return false;
            }
        }
    }
}
