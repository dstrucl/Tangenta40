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

namespace InvoiceDB
{
    public static class f_cAddress_Org
    {
        public static bool Get(string_v StreetName_v, 
                               string_v HouseNumber_v, 
                               string_v ZIP_v, 
                               string_v City_v, 
                               string_v Country_v,
                               string_v Country_ISO_3166_a2_v,
                               string_v Country_ISO_3166_a3_v,
                               short_v Country_ISO_3166_num_v,
                               string_v State_v, 
                               ref long_v cAddress_Org_ID_v)
        {
            if ((StreetName_v == null) || (HouseNumber_v == null) || (ZIP_v == null) || (City_v == null) || (Country_v == null))
            {
                cAddress_Org_ID_v = null;
                return true;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            long_v cStreetName_Org_ID_v = null;
            if (!f_cStreetName_Org.Get(StreetName_v,ref cStreetName_Org_ID_v))
            {
                return false;
            }
            string cStreetName_Org_ID_cond = null;
            string cStreetName_Org_ID_value = null;
            if (!fs.AddPar("cStreetName_Org_ID", ref lpar, cStreetName_Org_ID_v, ref cStreetName_Org_ID_cond, ref cStreetName_Org_ID_value))
            {
                return false;
            }
            long_v cHouseNumber_Org_ID_v = null;
            if (!f_cHouseNumber_Org.Get(HouseNumber_v, ref cHouseNumber_Org_ID_v))
            {
                return false;
            }
            string cHouseNumber_Org_ID_cond = null;
            string cHouseNumber_Org_ID_value = null;
            if (!fs.AddPar("cHouseNumber_Org_ID", ref lpar, cHouseNumber_Org_ID_v, ref cHouseNumber_Org_ID_cond, ref cHouseNumber_Org_ID_value))
            {
                return false;
            }
            long_v cZIP_Org_ID_v = null;
            if (!f_cZIP_Org.Get(ZIP_v, ref cZIP_Org_ID_v))
            {
                return false;
            }
            string cZIP_Org_ID_cond = null;
            string cZIP_Org_ID_value = null;
            if (!fs.AddPar("cZIP_Org_ID", ref lpar, cZIP_Org_ID_v, ref cZIP_Org_ID_cond, ref cZIP_Org_ID_value))
            {
                return false;
            }
            long_v cCity_Org_ID_v = null;
            if (!f_cCity_Org.Get(City_v, ref cCity_Org_ID_v))
            {
                return false;
            }
            string cCity_Org_ID_cond = null;
            string cCity_Org_ID_value = null;
            if (!fs.AddPar("cCity_Org_ID", ref lpar, cCity_Org_ID_v, ref cCity_Org_ID_cond, ref cCity_Org_ID_value))
            {
                return false;
            }
            long_v cCountry_Org_ID_v = null;
            if (!f_cCountry_Org.Get(Country_v,Country_ISO_3166_a2_v, Country_ISO_3166_a3_v, Country_ISO_3166_num_v, ref cCountry_Org_ID_v))
            {
                return false;
            }
            string cCountry_Org_ID_cond = null;
            string cCountry_Org_ID_value = null;
            if (!fs.AddPar("cCountry_Org_ID", ref lpar, cCountry_Org_ID_v, ref cCountry_Org_ID_cond, ref cCountry_Org_ID_value))
            {
                return false;
            }
            long_v cState_Org_ID_v = null;
            if (!f_cState_Org.Get(State_v, ref cState_Org_ID_v))
            {
                return false;
            }
            string cState_Org_ID_cond = null;
            string cState_Org_ID_value = null;
            if (!fs.AddPar("cState_Org_ID", ref lpar, cState_Org_ID_v, ref cState_Org_ID_cond, ref cState_Org_ID_value))
            {
                return false;
            }

            string sql = "select ID from cAddress_Org where " + cStreetName_Org_ID_cond
                                                                     + " and " + cHouseNumber_Org_ID_cond
                                                                     + " and " + cZIP_Org_ID_cond
                                                                     + " and " + cCity_Org_ID_cond
                                                                     + " and " + cCountry_Org_ID_cond
                                                                     + " and " + cState_Org_ID_cond + " order by ID desc";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (cAddress_Org_ID_v == null)
                    {
                        cAddress_Org_ID_v = new long_v();
                    }
                    cAddress_Org_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = " insert into cAddress_Org (cStreetName_Org_ID,cHouseNumber_Org_ID,cZIP_Org_ID,cCity_Org_ID,cCountry_Org_ID,cState_Org_ID)values(" + cStreetName_Org_ID_value + "," + cHouseNumber_Org_ID_value + "," + cZIP_Org_ID_value + "," + cCity_Org_ID_value + "," + cCountry_Org_ID_value + "," + cState_Org_ID_value + ")";
                    long id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref ores, ref Err, "cAddress_Org"))
                    {
                        if (cAddress_Org_ID_v == null)
                        {
                            cAddress_Org_ID_v = new long_v();
                        }
                        cAddress_Org_ID_v.v = id;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Customer_Org:Get_cAddress_Org_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Customer_Org:Get_cAddress_Org_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(PostAddress_v address_v, ref ID_v cAdressOrg_iD_v)
        {
            string Err = null;
            long_v cStreetName_Org_ID_v = null;
            long_v cHouseNumber_Org_ID_v = null;
            long_v cCity_Org_ID_v = null;
            long_v cZIP_Org_ID_v = null;
            long_v cCountry_Org_ID_v = null;
            long_v cState_Org_ID_v = null;

            if (f_cStreetName_Org.Get(address_v.StreetName_v, ref cStreetName_Org_ID_v))
            {
                if (f_cHouseNumber_Org.Get(address_v.HouseNumber_v, ref cHouseNumber_Org_ID_v))
                {
                    if (f_cCity_Org.Get(address_v.City_v, ref cCity_Org_ID_v))
                    {
                        if (f_cZIP_Org.Get(address_v.ZIP_v, ref cZIP_Org_ID_v))
                        {
                            if (f_cCountry_Org.Get(address_v.Country_v,
                                                      address_v.Country_ISO_3166_a2_v,
                                                      address_v.Country_ISO_3166_a3_v,
                                                      address_v.Country_ISO_3166_num_v,
                                                      ref cCountry_Org_ID_v))
                            {
                                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                                string scond_cStreetName_Org_ID_v = " cStreetName_Org_ID is null ";
                                string sval_cStreetName_Org_ID_v = "null";

                                if (cStreetName_Org_ID_v != null)
                                {
                                    string spar_cStreetName_Org_ID_v = "@par_cStreetName_Org_ID_v";
                                    SQL_Parameter par_cStreetName_Org_ID_v = new SQL_Parameter(spar_cStreetName_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, cStreetName_Org_ID_v.v);
                                    lpar.Add(par_cStreetName_Org_ID_v);
                                    scond_cStreetName_Org_ID_v = " cStreetName_Org_ID = " + spar_cStreetName_Org_ID_v;
                                    sval_cStreetName_Org_ID_v = spar_cStreetName_Org_ID_v;
                                }



                                string scond_cHouseNumber_Org_ID_v = " cHouseNumber_Org_ID is null ";
                                string sval_cHouseNumber_Org_ID_v = "null";
                                if (cHouseNumber_Org_ID_v != null)
                                {
                                    string spar_cHouseNumber_Org_ID_v = "@par_cHouseNumber_Org_ID_v";
                                    SQL_Parameter par_cHouseNumber_Org_ID_v = new SQL_Parameter(spar_cHouseNumber_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, cHouseNumber_Org_ID_v.v);
                                    lpar.Add(par_cHouseNumber_Org_ID_v);
                                    scond_cHouseNumber_Org_ID_v = " cHouseNumber_Org_ID = " + spar_cHouseNumber_Org_ID_v;
                                    sval_cHouseNumber_Org_ID_v = spar_cHouseNumber_Org_ID_v;
                                }

                                string scond_cCity_Org_ID_v = " cCity_Org_ID is null ";
                                string sval_cCity_Org_ID_v = "null";
                                if (cCity_Org_ID_v != null)
                                {
                                    string spar_cCity_Org_ID_v = "@par_cCity_Org_ID_v";
                                    SQL_Parameter par_cCity_Org_ID_v = new SQL_Parameter(spar_cCity_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, cCity_Org_ID_v.v);
                                    lpar.Add(par_cCity_Org_ID_v);
                                    scond_cCity_Org_ID_v = " cCity_Org_ID = " + spar_cCity_Org_ID_v;
                                    sval_cCity_Org_ID_v = spar_cCity_Org_ID_v;
                                }

                                string scond_cZIP_Org_ID_v = " cZIP_Org_ID is null ";
                                string sval_cZIP_Org_ID_v = "null";
                                if (cZIP_Org_ID_v != null)
                                {
                                    string spar_cZIP_Org_ID_v = "@par_cZIP_Org_ID_v";
                                    SQL_Parameter par_cZIP_Org_ID_v = new SQL_Parameter(spar_cZIP_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, cZIP_Org_ID_v.v);
                                    lpar.Add(par_cZIP_Org_ID_v);
                                    scond_cZIP_Org_ID_v = " cZIP_Org_ID = " + spar_cZIP_Org_ID_v;
                                    sval_cZIP_Org_ID_v = spar_cZIP_Org_ID_v;
                                }

                                string scond_cCountry_Org_ID_v = " cCountry_Org_ID is null ";
                                string sval_cCountry_Org_ID_v = "null";
                                if (cCountry_Org_ID_v != null)
                                {
                                    string spar_cCountry_Org_ID_v = "@par_cCountry_Org_ID_v";
                                    SQL_Parameter par_cCountry_Org_ID_v = new SQL_Parameter(spar_cCountry_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, cCountry_Org_ID_v.v);
                                    lpar.Add(par_cCountry_Org_ID_v);
                                    scond_cCountry_Org_ID_v = " cCountry_Org_ID = " + spar_cCountry_Org_ID_v;
                                    sval_cCountry_Org_ID_v = spar_cCountry_Org_ID_v;
                                }

                                string scond_cState_Org_ID_v = " cState_Org_ID is null ";
                                string sval_cState_Org_ID_v = "null";
                                if (cState_Org_ID_v != null)
                                {
                                    string spar_cState_Org_ID_v = "@par_cState_Org_ID_v";
                                    SQL_Parameter par_cState_Org_ID_v = new SQL_Parameter(spar_cState_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, cState_Org_ID_v.v);
                                    lpar.Add(par_cState_Org_ID_v);
                                    scond_cState_Org_ID_v = " cState_Org_ID = " + spar_cState_Org_ID_v;
                                    sval_cState_Org_ID_v = spar_cState_Org_ID_v;
                                }
                                string sql = "select ID from cAddress_Org where " + scond_cStreetName_Org_ID_v + " and "
                                                                                       + scond_cHouseNumber_Org_ID_v + " and "
                                                                                       + scond_cCity_Org_ID_v + " and "
                                                                                       + scond_cZIP_Org_ID_v + " and "
                                                                                       + scond_cCountry_Org_ID_v + " and "
                                                                                       + scond_cState_Org_ID_v;

                                DataTable dt = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (cAdressOrg_iD_v == null)
                                        {
                                            cAdressOrg_iD_v = new ID_v();
                                        }
                                        cAdressOrg_iD_v.v = (long)dt.Rows[0]["ID"];
                                        return true;
                                    }
                                    else
                                    {
                                        sql = "insert into cAddress_Org (cStreetName_Org_ID,cHouseNumber_Org_ID,cCity_Org_ID,cZIP_Org_ID,cCountry_Org_ID,cState_Org_ID) values ("
                                                + sval_cStreetName_Org_ID_v + ","
                                                + sval_cHouseNumber_Org_ID_v + ","
                                                + sval_cCity_Org_ID_v + ","
                                                + sval_cZIP_Org_ID_v + ","
                                                + sval_cCountry_Org_ID_v + ","
                                                + sval_cState_Org_ID_v + ")";
                                        long cAddress_Org_ID = -1;
                                        object oret = null;
                                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref cAddress_Org_ID, ref oret, ref Err, "cAddress_Org"))
                                        {
                                            if (cAdressOrg_iD_v == null)
                                            {
                                                cAdressOrg_iD_v = new ID_v();
                                            }
                                            cAdressOrg_iD_v.v = cAddress_Org_ID;
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(ItemShopA m_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(ItemShopA m_ItemShopA, ref long atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
