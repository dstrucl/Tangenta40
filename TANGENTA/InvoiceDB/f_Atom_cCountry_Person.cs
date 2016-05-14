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
    public static class f_Atom_cCountry_Person
    {
        public static bool Get(long cCountry_Person_ID, ref long Atom_cCountry_Person_ID)
        {
            string Err = null;
            string sql = @"select Country, Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num from cCountry_Person where ID = " + cCountry_Person_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {

                    object o_Country = dt.Rows[0]["Country"];
                    if (o_Country is string)
                    {
                        string Country = (string)o_Country;
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                        string spar_Country = "@par_Country";
                        SQL_Parameter par_Country = new SQL_Parameter(spar_Country, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Country);
                        lpar.Add(par_Country);

                        string Country_ISO_3166_a2 = (string)dt.Rows[0]["Country_ISO_3166_a2"];
                        string spar_Country_ISO_3166_a2 = "@par_Country_ISO_3166_a2";
                        SQL_Parameter par_Country_ISO_3166_a2 = new SQL_Parameter(spar_Country_ISO_3166_a2, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Country_ISO_3166_a2);
                        lpar.Add(par_Country_ISO_3166_a2);

                        string Country_ISO_3166_a3 = (string)dt.Rows[0]["Country_ISO_3166_a3"];
                        string spar_Country_ISO_3166_a3 = "@par_Country_ISO_3166_a3";
                        SQL_Parameter par_Country_ISO_3166_a3 = new SQL_Parameter(spar_Country_ISO_3166_a3, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Country_ISO_3166_a3);
                        lpar.Add(par_Country_ISO_3166_a3);

                        short Country_ISO_3166_num = Convert.ToInt16(dt.Rows[0]["Country_ISO_3166_num"]);
                        string spar_Country_ISO_3166_num = "@par_Country_ISO_3166_num";
                        SQL_Parameter par_Country_ISO_3166_num = new SQL_Parameter(spar_Country_ISO_3166_num, SQL_Parameter.eSQL_Parameter.Smallint, false, Country_ISO_3166_num);
                        lpar.Add(par_Country_ISO_3166_num);



                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from Atom_cCountry_Person where Country= " + spar_Country + " and  Country_ISO_3166_a2 = " + spar_Country_ISO_3166_a2 + " and Country_ISO_3166_a3 = " + spar_Country_ISO_3166_a3 + " and Country_ISO_3166_num = " + spar_Country_ISO_3166_num;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                Atom_cCountry_Person_ID = (long)dt.Rows[0]["ID"];
                                return true;
                            }
                            else
                            {
                                sql = @"insert into Atom_cCountry_Person (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num) values (" + spar_Country + "," + spar_Country_ISO_3166_a2 + "," + spar_Country_ISO_3166_a3 + "," + spar_Country_ISO_3166_num + ")";
                                object objretx = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cCountry_Person_ID, ref objretx, ref Err, "Atom_cCountry_Person"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_Atom_cCountry_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_cCountry_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_cCountry_Person:Get:1:No Country for cCountry_Person_ID =" + cCountry_Person_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cCountry_Person:Get:2:No Country for cCountry_Person_ID =" + cCountry_Person_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cCountry_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(string_v country_v, string_v country_ISO_3166_a2_v, string_v country_ISO_3166_a3_v, short_v country_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)
        {
            if ((country_v != null) && (country_ISO_3166_a2_v != null) && (country_ISO_3166_a3_v != null) && (country_ISO_3166_num_v != null))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_country_v = "@par_country_v";
                SQL_Parameter par_country_v = new SQL_Parameter(spar_country_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, country_v.v);
                lpar.Add(par_country_v);
                string spar_country_ISO_3166_a2_v = "@par_country_ISO_3166_a2_v";
                SQL_Parameter par_country_ISO_3166_a2_v = new SQL_Parameter(spar_country_ISO_3166_a2_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, country_ISO_3166_a2_v.v);
                lpar.Add(par_country_ISO_3166_a2_v);
                string spar_country_ISO_3166_a3_v = "@par_country_ISO_3166_a3_v";
                SQL_Parameter par_country_ISO_3166_a3_v = new SQL_Parameter(spar_country_ISO_3166_a3_v, SQL_Parameter.eSQL_Parameter.Nvarchar, false, country_ISO_3166_a3_v.v);
                lpar.Add(par_country_ISO_3166_a3_v);

                string spar_country_ISO_3166_num_v = "@par_country_ISO_3166_num_v";
                SQL_Parameter par_country_ISO_3166_num_v = new SQL_Parameter(spar_country_ISO_3166_num_v, SQL_Parameter.eSQL_Parameter.Smallint, false, country_ISO_3166_num_v.v);
                lpar.Add(par_country_ISO_3166_num_v);


                string sql = @"select ID from Atom_cCountry_Person where Country= " + spar_country_v
                                                                            + " and Country_ISO_3166_a2 = " + spar_country_ISO_3166_a2_v
                                                                            + " and Country_ISO_3166_a3 =" + spar_country_ISO_3166_a3_v
                                                                            + " and Country_ISO_3166_num =" + spar_country_ISO_3166_num_v;
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
                        sql = @"insert into Atom_cCountry_Person (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num) values (" + spar_country_v + ","
                                                                                                                                    + spar_country_ISO_3166_a2_v + ","
                                                                                                                                    + spar_country_ISO_3166_a3_v + ","
                                                                                                                                    + spar_country_ISO_3166_num_v + ")";
                        long Atom_cCountry_Person_ID = -1;
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cCountry_Person_ID, ref oret, ref Err, "Atom_cCountry_Person"))
                        {
                            if (atom_cCountry_Person_ID_v == null)
                            {
                                atom_cCountry_Person_ID_v = new long_v();
                            }
                            atom_cCountry_Person_ID_v.v = Atom_cCountry_Person_ID;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cCountry_Person:Get(string_v country_v, string_v country_ISO_3166_a2_v, string_v country_ISO_3166_a3_v, short_v country_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)\r\nsql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cCountry_Person:Get(string_v country_v, string_v country_ISO_3166_a2_v, string_v country_ISO_3166_a3_v, short_v country_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)\r\nsql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:InvoiceDB:f_Atom_cCountry_Person:Get(string_v country_v, string_v country_ISO_3166_a2_v, string_v country_ISO_3166_a3_v, short_v country_ISO_3166_num_v, ref long_v atom_cCountry_Person_ID_v)\r\n country_v may not be null!");
                return false;
            }
        }
    }
}
