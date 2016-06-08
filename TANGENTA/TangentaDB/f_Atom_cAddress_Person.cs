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
using CodeTables;
using TangentaTableClass;

namespace TangentaDB
{
    public static class f_Atom_cAddress_Person
    {
        public static bool Get(string_v StreetName_v, string_v HouseNumber_v, string_v ZIP_v, string_v City_v, string_v Country_v, string_v State_v, ref long_v Atom_cAddress_Person_ID_v)
        {
            if ((StreetName_v == null) || (HouseNumber_v == null) || (ZIP_v == null) || (City_v == null) || (Country_v == null))
            {
                Atom_cAddress_Person_ID_v = null;
                return true;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            long_v Atom_cStreetName_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cStreetName_Person", "StreetName", StreetName_v, ref Atom_cStreetName_Person_ID_v))
            {
                return false;
            }
            string Atom_cStreetName_Person_ID_cond = null;
            string Atom_cStreetName_Person_ID_value = null;
            if (!fs.AddPar("Atom_cStreetName_Person_ID", ref lpar, Atom_cStreetName_Person_ID_v, ref Atom_cStreetName_Person_ID_cond, ref Atom_cStreetName_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cHouseNumber_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cHouseNumber_Person", "HouseNumber", HouseNumber_v, ref Atom_cHouseNumber_Person_ID_v))
            {
                return false;
            }
            string Atom_cHouseNumber_Person_ID_cond = null;
            string Atom_cHouseNumber_Person_ID_value = null;
            if (!fs.AddPar("Atom_cHouseNumber_Person_ID", ref lpar, Atom_cHouseNumber_Person_ID_v, ref Atom_cHouseNumber_Person_ID_cond, ref Atom_cHouseNumber_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cZIP_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cZIP_Person", "ZIP", ZIP_v, ref Atom_cZIP_Person_ID_v))
            {
                return false;
            }
            string Atom_cZIP_Person_ID_cond = null;
            string Atom_cZIP_Person_ID_value = null;
            if (!fs.AddPar("Atom_cZIP_Person_ID", ref lpar, Atom_cZIP_Person_ID_v, ref Atom_cZIP_Person_ID_cond, ref Atom_cZIP_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cCity_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cCity_Person", "City", City_v, ref Atom_cCity_Person_ID_v))
            {
                return false;
            }
            string Atom_cCity_Person_ID_cond = null;
            string Atom_cCity_Person_ID_value = null;
            if (!fs.AddPar("Atom_cCity_Person_ID", ref lpar, Atom_cCity_Person_ID_v, ref Atom_cCity_Person_ID_cond, ref Atom_cCity_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cCountry_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cCountry_Person", "Country", Country_v, ref Atom_cCountry_Person_ID_v))
            {
                return false;
            }
            string Atom_cCountry_Person_ID_cond = null;
            string Atom_cCountry_Person_ID_value = null;
            if (!fs.AddPar("Atom_cCountry_Person_ID", ref lpar, Atom_cCountry_Person_ID_v, ref Atom_cCountry_Person_ID_cond, ref Atom_cCountry_Person_ID_value))
            {
                return false;
            }
            long_v Atom_cState_Person_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cState_Person", "State", State_v, ref Atom_cState_Person_ID_v))
            {
                return false;
            }
            string Atom_cState_Person_ID_cond = null;
            string Atom_cState_Person_ID_value = null;
            if (!fs.AddPar("Atom_cState_Person_ID", ref lpar, Atom_cState_Person_ID_v, ref Atom_cState_Person_ID_cond, ref Atom_cState_Person_ID_value))
            {
                return false;
            }

            string sql = "select ID from Atom_cAddress_Person where " + Atom_cStreetName_Person_ID_cond
                                                                     + " and " + Atom_cHouseNumber_Person_ID_cond
                                                                     + " and " + Atom_cZIP_Person_ID_cond
                                                                     + " and " + Atom_cCity_Person_ID_cond
                                                                     + " and " + Atom_cCountry_Person_ID_cond
                                                                     + " and " + Atom_cState_Person_ID_cond + " order by ID desc";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_cAddress_Person_ID_v == null)
                    {
                        Atom_cAddress_Person_ID_v = new long_v();
                    }
                    Atom_cAddress_Person_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = " insert into Atom_cAddress_Person (Atom_cStreetName_Person_ID,Atom_cHouseNumber_Person_ID,Atom_cZIP_Person_ID,Atom_cCity_Person_ID,Atom_cCountry_Person_ID,Atom_cState_Person_ID)values(" + Atom_cStreetName_Person_ID_value + "," + Atom_cHouseNumber_Person_ID_value + "," + Atom_cZIP_Person_ID_value + "," + Atom_cCity_Person_ID_value + "," + Atom_cCountry_Person_ID_value + "," + Atom_cState_Person_ID_value + ")";
                    long id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref ores, ref Err, "Atom_cAddress_Person"))
                    {
                        if (Atom_cAddress_Person_ID_v == null)
                        {
                            Atom_cAddress_Person_ID_v = new long_v();
                        }
                        Atom_cAddress_Person_ID_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_cAddress_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Person:Get_Atom_cAddress_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(PostAddress_v address_v, ref ID_v cAdressAtom_Person_iD_v)
        {
            string Err = null;
            long_v Atom_cStreetName_Person_ID_v = null;
            long_v Atom_cHouseNumber_Person_ID_v = null;
            long_v Atom_cCity_Person_ID_v = null;
            long_v Atom_cZIP_Person_ID_v = null;
            long_v Atom_cCountry_Person_ID_v = null;
            long_v Atom_cState_Person_ID_v = null;

            if (f_Atom_cStreetName_Person.Get(address_v.StreetName_v, ref Atom_cStreetName_Person_ID_v))
            {
                if (f_Atom_cHouseNumber_Person.Get(address_v.HouseNumber_v, ref Atom_cHouseNumber_Person_ID_v))
                {
                    if (f_Atom_cCity_Person.Get(address_v.City_v, ref Atom_cCity_Person_ID_v))
                    {
                        if (f_Atom_cZIP_Person.Get(address_v.ZIP_v, ref Atom_cZIP_Person_ID_v))
                        {
                            if (f_Atom_cCountry_Person.Get(address_v.Country_v,
                                                      address_v.Country_ISO_3166_a2_v,
                                                      address_v.Country_ISO_3166_a3_v,
                                                      address_v.Country_ISO_3166_num_v,
                                                      ref Atom_cCountry_Person_ID_v))
                            {
                                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                                string scond_Atom_cStreetName_Person_ID_v = " Atom_cStreetName_Person_ID is null ";
                                string sval_Atom_cStreetName_Person_ID_v = "null";

                                if (Atom_cStreetName_Person_ID_v != null)
                                {
                                    string spar_Atom_cStreetName_Person_ID_v = "@par_Atom_cStreetName_Person_ID_v";
                                    SQL_Parameter par_Atom_cStreetName_Person_ID_v = new SQL_Parameter(spar_Atom_cStreetName_Person_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_cStreetName_Person_ID_v.v);
                                    lpar.Add(par_Atom_cStreetName_Person_ID_v);
                                    scond_Atom_cStreetName_Person_ID_v = " Atom_cStreetName_Person_ID = " + spar_Atom_cStreetName_Person_ID_v;
                                    sval_Atom_cStreetName_Person_ID_v = spar_Atom_cStreetName_Person_ID_v;
                                }



                                string scond_Atom_cHouseNumber_Person_ID_v = " Atom_cHouseNumber_Person_ID is null ";
                                string sval_Atom_cHouseNumber_Person_ID_v = "null";
                                if (Atom_cHouseNumber_Person_ID_v != null)
                                {
                                    string spar_Atom_cHouseNumber_Person_ID_v = "@par_Atom_cHouseNumber_Person_ID_v";
                                    SQL_Parameter par_Atom_cHouseNumber_Person_ID_v = new SQL_Parameter(spar_Atom_cHouseNumber_Person_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_cHouseNumber_Person_ID_v.v);
                                    lpar.Add(par_Atom_cHouseNumber_Person_ID_v);
                                    scond_Atom_cHouseNumber_Person_ID_v = " Atom_cHouseNumber_Person_ID = " + spar_Atom_cHouseNumber_Person_ID_v;
                                    sval_Atom_cHouseNumber_Person_ID_v = spar_Atom_cHouseNumber_Person_ID_v;
                                }

                                string scond_Atom_cCity_Person_ID_v = " Atom_cCity_Person_ID is null ";
                                string sval_Atom_cCity_Person_ID_v = "null";
                                if (Atom_cCity_Person_ID_v != null)
                                {
                                    string spar_Atom_cCity_Person_ID_v = "@par_Atom_cCity_Person_ID_v";
                                    SQL_Parameter par_Atom_cCity_Person_ID_v = new SQL_Parameter(spar_Atom_cCity_Person_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_cCity_Person_ID_v.v);
                                    lpar.Add(par_Atom_cCity_Person_ID_v);
                                    scond_Atom_cCity_Person_ID_v = " Atom_cCity_Person_ID = " + spar_Atom_cCity_Person_ID_v;
                                    sval_Atom_cCity_Person_ID_v = spar_Atom_cCity_Person_ID_v;
                                }

                                string scond_Atom_cZIP_Person_ID_v = " Atom_cZIP_Person_ID is null ";
                                string sval_Atom_cZIP_Person_ID_v = "null";
                                if (Atom_cZIP_Person_ID_v != null)
                                {
                                    string spar_Atom_cZIP_Person_ID_v = "@par_Atom_cZIP_Person_ID_v";
                                    SQL_Parameter par_Atom_cZIP_Person_ID_v = new SQL_Parameter(spar_Atom_cZIP_Person_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_cZIP_Person_ID_v.v);
                                    lpar.Add(par_Atom_cZIP_Person_ID_v);
                                    scond_Atom_cZIP_Person_ID_v = " Atom_cZIP_Person_ID = " + spar_Atom_cZIP_Person_ID_v;
                                    sval_Atom_cZIP_Person_ID_v = spar_Atom_cZIP_Person_ID_v;
                                }

                                string scond_Atom_cCountry_Person_ID_v = " Atom_cCountry_Person_ID is null ";
                                string sval_Atom_cCountry_Person_ID_v = "null";
                                if (Atom_cCountry_Person_ID_v != null)
                                {
                                    string spar_Atom_cCountry_Person_ID_v = "@par_Atom_cCountry_Person_ID_v";
                                    SQL_Parameter par_Atom_cCountry_Person_ID_v = new SQL_Parameter(spar_Atom_cCountry_Person_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_cCountry_Person_ID_v.v);
                                    lpar.Add(par_Atom_cCountry_Person_ID_v);
                                    scond_Atom_cCountry_Person_ID_v = " Atom_cCountry_Person_ID = " + spar_Atom_cCountry_Person_ID_v;
                                    sval_Atom_cCountry_Person_ID_v = spar_Atom_cCountry_Person_ID_v;
                                }

                                string scond_Atom_cState_Person_ID_v = " Atom_cState_Person_ID is null ";
                                string sval_Atom_cState_Person_ID_v = "null";
                                if (Atom_cState_Person_ID_v != null)
                                {
                                    string spar_Atom_cState_Person_ID_v = "@par_Atom_cState_Person_ID_v";
                                    SQL_Parameter par_Atom_cState_Person_ID_v = new SQL_Parameter(spar_Atom_cState_Person_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_cState_Person_ID_v.v);
                                    lpar.Add(par_Atom_cState_Person_ID_v);
                                    scond_Atom_cState_Person_ID_v = " Atom_cState_Person_ID = " + spar_Atom_cState_Person_ID_v;
                                    sval_Atom_cState_Person_ID_v = spar_Atom_cState_Person_ID_v;
                                }
                                string sql = "select ID from Atom_cAddress_Person where " + scond_Atom_cStreetName_Person_ID_v + " and "
                                                                                       + scond_Atom_cHouseNumber_Person_ID_v + " and "
                                                                                       + scond_Atom_cCity_Person_ID_v + " and "
                                                                                       + scond_Atom_cZIP_Person_ID_v + " and "
                                                                                       + scond_Atom_cCountry_Person_ID_v + " and "
                                                                                       + scond_Atom_cState_Person_ID_v;

                                DataTable dt = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (cAdressAtom_Person_iD_v == null)
                                        {
                                            cAdressAtom_Person_iD_v = new ID_v();
                                        }
                                        cAdressAtom_Person_iD_v.v = (long)dt.Rows[0]["ID"];
                                        return true;
                                    }
                                    else
                                    {
                                        sql = "insert into Atom_cAddress_Person (Atom_cStreetName_Person_ID,Atom_cHouseNumber_Person_ID,Atom_cCity_Person_ID,Atom_cZIP_Person_ID,Atom_cCountry_Person_ID,Atom_cState_Person_ID) values ("
                                                + sval_Atom_cStreetName_Person_ID_v + ","
                                                + sval_Atom_cHouseNumber_Person_ID_v + ","
                                                + sval_Atom_cCity_Person_ID_v + ","
                                                + sval_Atom_cZIP_Person_ID_v + ","
                                                + sval_Atom_cCountry_Person_ID_v + ","
                                                + sval_Atom_cState_Person_ID_v + ")";
                                        long Atom_cAddress_Person_ID = -1;
                                        object oret = null;
                                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_cAddress_Person_ID, ref oret, ref Err, "Atom_cAddress_Person"))
                                        {
                                            if (cAdressAtom_Person_iD_v == null)
                                            {
                                                cAdressAtom_Person_iD_v = new ID_v();
                                            }
                                            cAdressAtom_Person_iD_v.v = Atom_cAddress_Person_ID;
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(Atom_ItemShopA m_Atom_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(Atom_ItemShopA m_Atom_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool Get(long cAddress_Person_ID, ref long Atom_cAddress_Person_ID)
        {
            long cStreetName_Person_ID = -1;
            long cHouseNumber_Person_ID = -1;
            long cCity_Person_ID = -1;
            long cZIP_Person_ID = -1;
            long cCountry_Person_ID = -1;
            long cState_Person_ID = -1;
            string sql = @"select 
                            cAorg.cStreetName_Person_ID,
                            cAorg.cHouseNumber_Person_ID,
                            cAorg.cZIP_Person_ID,
                            cAorg.cCity_Person_ID,
                            cAorg.cCountry_Person_ID,
                            cAorg.cCountry_Person_ID,
                            cAorg.cState_Person_ID
                            from cAddress_Person cAorg
                            where cAorg.ID = " + cAddress_Person_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    cStreetName_Person_ID = (long)dt.Rows[0]["cStreetName_Person_ID"];
                    cHouseNumber_Person_ID = (long)dt.Rows[0]["cHouseNumber_Person_ID"];
                    cZIP_Person_ID = (long)dt.Rows[0]["cZIP_Person_ID"];
                    cCity_Person_ID = (long)dt.Rows[0]["cCity_Person_ID"];
                    cCountry_Person_ID = (long)dt.Rows[0]["cCountry_Person_ID"];
                    object o_cState_Person_ID = dt.Rows[0]["cState_Person_ID"];

                    string sStateCond = null;
                    string sStateVal = null;
                    if (o_cState_Person_ID is long)
                    {
                        cState_Person_ID = (long)o_cState_Person_ID;
                        sStateCond = "Atom_cState_Person_ID = " + cState_Person_ID.ToString();
                        sStateVal = cState_Person_ID.ToString();
                    }
                    else
                    {
                        o_cState_Person_ID = null;
                        sStateCond = "Atom_cState_Person_ID is null";
                        sStateVal = "null";
                    }
                    long Atom_cStreetName_Person_ID = -1;
                    long Atom_cHouseNumber_Person_ID = -1;
                    long Atom_cCity_Person_ID = -1;
                    long Atom_cZIP_Person_ID = -1;
                    long Atom_cCountry_Person_ID = -1;
                    if (f_Atom_cStreetName_Person.Get(cStreetName_Person_ID, ref Atom_cStreetName_Person_ID))
                    {
                        if (f_Atom_cHouseNumber_Person.Get(cHouseNumber_Person_ID, ref Atom_cHouseNumber_Person_ID))
                        {
                            if (f_Atom_cCity_Person.Get(cCity_Person_ID, ref Atom_cCity_Person_ID))
                            {
                                if (f_Atom_cZIP_Person.Get(cZIP_Person_ID, ref Atom_cZIP_Person_ID))
                                {
                                    if (f_Atom_cCountry_Person.Get(cCountry_Person_ID, ref Atom_cCountry_Person_ID))
                                    {
                                        sql = @"select
                                                    ID
                                                from Atom_cAddress_Person where Atom_cStreetName_Person_ID = " + Atom_cStreetName_Person_ID.ToString() + @"
                                                and Atom_cHouseNumber_Person_ID = " + Atom_cHouseNumber_Person_ID.ToString() + @"
                                                and Atom_cCity_Person_ID = " + Atom_cCity_Person_ID.ToString() + @"
                                                and Atom_cZIP_Person_ID = " + Atom_cZIP_Person_ID.ToString() + @"
                                                and Atom_cCountry_Person_ID = " + Atom_cCountry_Person_ID.ToString() + @"
                                                and " + sStateCond;
                                        dt.Clear();
                                        dt.Columns.Clear();
                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                Atom_cAddress_Person_ID = (long)dt.Rows[0]["ID"];
                                                return true;
                                            }
                                            else
                                            {
                                                sql = @"insert into Atom_cAddress_Person
                                                        (Atom_cStreetName_Person_ID,Atom_cHouseNumber_Person_ID,Atom_cZIP_Person_ID,Atom_cCity_Person_ID,Atom_cCountry_Person_ID,Atom_cState_Person_ID) values
                                                        (" + Atom_cStreetName_Person_ID.ToString() + "," + Atom_cHouseNumber_Person_ID.ToString() + "," + Atom_cZIP_Person_ID.ToString() + "," + Atom_cCity_Person_ID.ToString() + "," + Atom_cCountry_Person_ID.ToString() + "," + sStateVal + ")";
                                                object objretx = null;
                                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_cAddress_Person_ID, ref objretx, ref Err, "Atom_cAddress_Person"))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:f_Atom_cAddress_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:f_Atom_cAddress_Person:Get:sql=" + sql + "\r\nErr=" + Err);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cAddress_Person:Get:No cAdddress_Person for cAddress_Person_ID = " + cAddress_Person_ID.ToString());
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cAddress_Person:Get:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}
