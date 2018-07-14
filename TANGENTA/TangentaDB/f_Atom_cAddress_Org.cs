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
    public static class f_Atom_cAddress_Org
    {
        public static bool Get(string_v StreetName_v, string_v HouseNumber_v, string_v ZIP_v, string_v City_v, string_v Country_v, string_v State_v, ref ID Atom_cAddress_Org_ID)
        {
            if ((StreetName_v == null) || (HouseNumber_v == null) || (ZIP_v == null) || (City_v == null) || (Country_v == null))
            {
                Atom_cAddress_Org_ID = null;
                return true;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            ID Atom_cStreetName_Org_ID = null;
            if (!fs.Get_string_table_ID("Atom_cStreetName_Org", "StreetName", StreetName_v, ref Atom_cStreetName_Org_ID))
            {
                return false;
            }
            string Atom_cStreetName_Org_ID_cond = null;
            string Atom_cStreetName_Org_ID_value = null;
            if (!fs.AddPar("Atom_cStreetName_Org_ID", ref lpar, Atom_cStreetName_Org_ID, ref Atom_cStreetName_Org_ID_cond, ref Atom_cStreetName_Org_ID_value))
            {
                return false;
            }
            ID xAtom_cHouseNumber_Org_ID = null;
            if (!fs.Get_string_table_ID("Atom_cHouseNumber_Org", "HouseNumber", HouseNumber_v, ref xAtom_cHouseNumber_Org_ID))
            {
                return false;
            }
            string Atom_cHouseNumber_Org_ID_cond = null;
            string Atom_cHouseNumber_Org_ID_value = null;
            if (!fs.AddPar("Atom_cHouseNumber_Org_ID", ref lpar, xAtom_cHouseNumber_Org_ID, ref Atom_cHouseNumber_Org_ID_cond, ref Atom_cHouseNumber_Org_ID_value))
            {
                return false;
            }
            ID xAtom_cZIP_Org_ID = null;
            if (!fs.Get_string_table_ID("Atom_cZIP_Org", "ZIP", ZIP_v, ref xAtom_cZIP_Org_ID))
            {
                return false;
            }
            string Atom_cZIP_Org_ID_cond = null;
            string Atom_cZIP_Org_ID_value = null;
            if (!fs.AddPar("Atom_cZIP_Org_ID", ref lpar, xAtom_cZIP_Org_ID, ref Atom_cZIP_Org_ID_cond, ref Atom_cZIP_Org_ID_value))
            {
                return false;
            }
            ID xAtom_cCity_Org_ID = null;
            if (!fs.Get_string_table_ID("Atom_cCity_Org", "City", City_v, ref xAtom_cCity_Org_ID))
            {
                return false;
            }
            string Atom_cCity_Org_ID_cond = null;
            string Atom_cCity_Org_ID_value = null;
            if (!fs.AddPar("Atom_cCity_Org_ID", ref lpar, xAtom_cCity_Org_ID, ref Atom_cCity_Org_ID_cond, ref Atom_cCity_Org_ID_value))
            {
                return false;
            }
            ID xAtom_cCountry_Org_ID = null;
            if (!fs.Get_string_table_ID("Atom_cCountry_Org", "Country", Country_v, ref xAtom_cCountry_Org_ID))
            {
                return false;
            }
            string Atom_cCountry_Org_ID_cond = null;
            string Atom_cCountry_Org_ID_value = null;
            if (!fs.AddPar("Atom_cCountry_Org_ID", ref lpar, xAtom_cCountry_Org_ID, ref Atom_cCountry_Org_ID_cond, ref Atom_cCountry_Org_ID_value))
            {
                return false;
            }

            ID xAtom_cState_Org_ID = null;
            if (!fs.Get_string_table_ID("Atom_cState_Org", "State", State_v, ref xAtom_cState_Org_ID))
            {
                return false;
            }
            string Atom_cState_Org_ID_cond = null;
            string Atom_cState_Org_ID_value = null;
            if (!fs.AddPar("Atom_cState_Org_ID", ref lpar, xAtom_cState_Org_ID, ref Atom_cState_Org_ID_cond, ref Atom_cState_Org_ID_value))
            {
                return false;
            }

            string sql = "select ID from Atom_cAddress_Org where " + Atom_cStreetName_Org_ID_cond
                                                                     + " and " + Atom_cHouseNumber_Org_ID_cond
                                                                     + " and " + Atom_cZIP_Org_ID_cond
                                                                     + " and " + Atom_cCity_Org_ID_cond
                                                                     + " and " + Atom_cCountry_Org_ID_cond
                                                                     + " and " + Atom_cState_Org_ID_cond + " order by ID desc";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_cAddress_Org_ID == null)
                    {
                        Atom_cAddress_Org_ID = new ID();
                    }
                    Atom_cAddress_Org_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = " insert into Atom_cAddress_Org (Atom_cStreetName_Org_ID,Atom_cHouseNumber_Org_ID,Atom_cZIP_Org_ID,Atom_cCity_Org_ID,Atom_cCountry_Org_ID,Atom_cState_Org_ID)values(" + Atom_cStreetName_Org_ID_value + "," + Atom_cHouseNumber_Org_ID_value + "," + Atom_cZIP_Org_ID_value + "," + Atom_cCity_Org_ID_value + "," + Atom_cCountry_Org_ID_value + "," + Atom_cState_Org_ID_value + ")";
                    ID id = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref Err, "Atom_cAddress_Org"))
                    {
                        if (Atom_cAddress_Org_ID == null)
                        {
                            Atom_cAddress_Org_ID = new ID();
                        }
                        Atom_cAddress_Org_ID.Set(id);
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Get_Atom_cAddress_Org_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Customer_Org:Get_Atom_cAddress_Org_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(PostAddress_v address_v, ref ID cAdressAtom_Org_iD)
        {
            string Err = null;
            ID xAtom_cStreetName_Org_ID = null;
            ID xAtom_cHouseNumber_Org_ID = null;
            ID xAtom_cCity_Org_ID = null;
            ID xAtom_cZIP_Org_ID = null;
            ID xAtom_cCountry_Org_ID = null;
            ID xAtom_cState_Org_ID = null;

            if (f_Atom_cStreetName_Org.Get(address_v.StreetName_v, ref xAtom_cStreetName_Org_ID))
            {
                if (f_Atom_cHouseNumber_Org.Get(address_v.HouseNumber_v, ref xAtom_cHouseNumber_Org_ID))
                {
                    if (f_Atom_cCity_Org.Get(address_v.City_v, ref xAtom_cCity_Org_ID))
                    {
                        if (f_Atom_cZIP_Org.Get(address_v.ZIP_v, ref xAtom_cZIP_Org_ID))
                        {
                            if (f_Atom_cCountry_Org.Get(address_v.Country_v,
                                                      address_v.Country_ISO_3166_a2_v,
                                                      address_v.Country_ISO_3166_a3_v,
                                                      address_v.Country_ISO_3166_num_v,
                                                      ref xAtom_cCountry_Org_ID))
                            {
                                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                                string scond_Atom_cStreetName_Org_ID_v = " Atom_cStreetName_Org_ID is null ";
                                string sval_Atom_cStreetName_Org_ID_v = "null";

                                if (xAtom_cStreetName_Org_ID != null)
                                {
                                    string spar_Atom_cStreetName_Org_ID_v = "@par_Atom_cStreetName_Org_ID_v";
                                    SQL_Parameter par_Atom_cStreetName_Org_ID_v = new SQL_Parameter(spar_Atom_cStreetName_Org_ID_v,SQL_Parameter.eSQL_Parameter.Bigint,false, xAtom_cStreetName_Org_ID.V);
                                    lpar.Add(par_Atom_cStreetName_Org_ID_v);
                                    scond_Atom_cStreetName_Org_ID_v = " Atom_cStreetName_Org_ID = " + spar_Atom_cStreetName_Org_ID_v;
                                    sval_Atom_cStreetName_Org_ID_v = spar_Atom_cStreetName_Org_ID_v;
                                }



                                string scond_Atom_cHouseNumber_Org_ID_v = " Atom_cHouseNumber_Org_ID is null ";
                                string sval_Atom_cHouseNumber_Org_ID_v = "null";
                                if (xAtom_cHouseNumber_Org_ID != null)
                                {
                                    string spar_Atom_cHouseNumber_Org_ID_v = "@par_Atom_cHouseNumber_Org_ID_v";
                                    SQL_Parameter par_Atom_cHouseNumber_Org_ID_v = new SQL_Parameter(spar_Atom_cHouseNumber_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, xAtom_cHouseNumber_Org_ID.V);
                                    lpar.Add(par_Atom_cHouseNumber_Org_ID_v);
                                    scond_Atom_cHouseNumber_Org_ID_v = " Atom_cHouseNumber_Org_ID = " + spar_Atom_cHouseNumber_Org_ID_v;
                                    sval_Atom_cHouseNumber_Org_ID_v = spar_Atom_cHouseNumber_Org_ID_v;
                                }

                                string scond_Atom_cCity_Org_ID_v = " Atom_cCity_Org_ID is null ";
                                string sval_Atom_cCity_Org_ID_v = "null";
                                if (xAtom_cCity_Org_ID != null)
                                {
                                    string spar_Atom_cCity_Org_ID_v = "@par_Atom_cCity_Org_ID_v";
                                    SQL_Parameter par_Atom_cCity_Org_ID_v = new SQL_Parameter(spar_Atom_cCity_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, xAtom_cCity_Org_ID.V);
                                    lpar.Add(par_Atom_cCity_Org_ID_v);
                                    scond_Atom_cCity_Org_ID_v = " Atom_cCity_Org_ID = " + spar_Atom_cCity_Org_ID_v;
                                    sval_Atom_cCity_Org_ID_v = spar_Atom_cCity_Org_ID_v;
                                }

                                string scond_Atom_cZIP_Org_ID_v = " Atom_cZIP_Org_ID is null ";
                                string sval_Atom_cZIP_Org_ID_v = "null";
                                if (xAtom_cZIP_Org_ID != null)
                                {
                                    string spar_Atom_cZIP_Org_ID_v = "@par_Atom_cZIP_Org_ID_v";
                                    SQL_Parameter par_Atom_cZIP_Org_ID_v = new SQL_Parameter(spar_Atom_cZIP_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, xAtom_cZIP_Org_ID.V);
                                    lpar.Add(par_Atom_cZIP_Org_ID_v);
                                    scond_Atom_cZIP_Org_ID_v = " Atom_cZIP_Org_ID = " + spar_Atom_cZIP_Org_ID_v;
                                    sval_Atom_cZIP_Org_ID_v = spar_Atom_cZIP_Org_ID_v;
                                }

                                string scond_Atom_cCountry_Org_ID_v = " Atom_cCountry_Org_ID is null ";
                                string sval_Atom_cCountry_Org_ID_v = "null";
                                if (xAtom_cCountry_Org_ID != null)
                                {
                                    string spar_Atom_cCountry_Org_ID_v = "@par_Atom_cCountry_Org_ID_v";
                                    SQL_Parameter par_Atom_cCountry_Org_ID_v = new SQL_Parameter(spar_Atom_cCountry_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, xAtom_cCountry_Org_ID.V);
                                    lpar.Add(par_Atom_cCountry_Org_ID_v);
                                    scond_Atom_cCountry_Org_ID_v = " Atom_cCountry_Org_ID = " + spar_Atom_cCountry_Org_ID_v;
                                    sval_Atom_cCountry_Org_ID_v = spar_Atom_cCountry_Org_ID_v;
                                }

                                string scond_Atom_cState_Org_ID_v = " Atom_cState_Org_ID is null ";
                                string sval_Atom_cState_Org_ID_v = "null";
                                if (xAtom_cState_Org_ID != null)
                                {
                                    string spar_Atom_cState_Org_ID_v = "@par_Atom_cState_Org_ID_v";
                                    SQL_Parameter par_Atom_cState_Org_ID_v = new SQL_Parameter(spar_Atom_cState_Org_ID_v, SQL_Parameter.eSQL_Parameter.Bigint, false, xAtom_cState_Org_ID.V);
                                    lpar.Add(par_Atom_cState_Org_ID_v);
                                    scond_Atom_cState_Org_ID_v = " Atom_cState_Org_ID = " + spar_Atom_cState_Org_ID_v;
                                    sval_Atom_cState_Org_ID_v = spar_Atom_cState_Org_ID_v;
                                }
                                string sql = "select ID from Atom_cAddress_Org where " + scond_Atom_cStreetName_Org_ID_v + " and "
                                                                                       + scond_Atom_cHouseNumber_Org_ID_v + " and "
                                                                                       + scond_Atom_cCity_Org_ID_v + " and "
                                                                                       + scond_Atom_cZIP_Org_ID_v + " and "
                                                                                       + scond_Atom_cCountry_Org_ID_v + " and "
                                                                                       + scond_Atom_cState_Org_ID_v;

                                DataTable dt = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (cAdressAtom_Org_iD==null)
                                        {
                                            cAdressAtom_Org_iD = new ID();
                                        }
                                        cAdressAtom_Org_iD.Set(dt.Rows[0]["ID"]);
                                        return true;
                                    }
                                    else
                                    {
                                        sql = "insert into Atom_cAddress_Org (Atom_cStreetName_Org_ID,Atom_cHouseNumber_Org_ID,Atom_cCity_Org_ID,Atom_cZIP_Org_ID,Atom_cCountry_Org_ID,Atom_cState_Org_ID) values ("
                                                + sval_Atom_cStreetName_Org_ID_v + ","
                                                + sval_Atom_cHouseNumber_Org_ID_v + ","
                                                + sval_Atom_cCity_Org_ID_v + ","
                                                + sval_Atom_cZIP_Org_ID_v + ","
                                                + sval_Atom_cCountry_Org_ID_v + ","
                                                + sval_Atom_cState_Org_ID_v + ")";
                                        ID xAtom_cAddress_Org_ID = null;
                                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref xAtom_cAddress_Org_ID,  ref Err, "Atom_cAddress_Org"))
                                        {
                                            if (cAdressAtom_Org_iD == null)
                                            {
                                                cAdressAtom_Org_iD = new ID();
                                            }
                                            cAdressAtom_Org_iD.Set(xAtom_cAddress_Org_ID);
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(Atom_ItemShopA m_Atom_ItemShopA, ref ID atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:ShopA_dbfunc:dbfunc:get(Atom_ItemShopA m_Atom_ItemShopA, ref ID atom_ItemShopA_ID) sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool Get(ID cAddress_Org_ID, ref ID Atom_cAddress_Org_ID)
        {
            ID cStreetName_Org_ID = new ID();
            ID cHouseNumber_Org_ID = new ID();
            ID cCity_Org_ID = new ID();
            ID cZIP_Org_ID = new ID();
            ID cCountry_Org_ID = new ID();
            ID cState_Org_ID = new ID();
            string sql = @"select 
                            cAorg.cStreetName_Org_ID,
                            cAorg.cHouseNumber_Org_ID,
                            cAorg.cZIP_Org_ID,
                            cAorg.cCity_Org_ID,
                            cAorg.cCountry_Org_ID,
                            cAorg.cCountry_Org_ID,
                            cAorg.cState_Org_ID
                            from cAddress_Org cAorg
                            where cAorg.ID = " + cAddress_Org_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    cStreetName_Org_ID.Set(dt.Rows[0]["cStreetName_Org_ID"]);
                    cHouseNumber_Org_ID.Set(dt.Rows[0]["cHouseNumber_Org_ID"]);
                    cZIP_Org_ID.Set(dt.Rows[0]["cZIP_Org_ID"]);
                    cCity_Org_ID.Set(dt.Rows[0]["cCity_Org_ID"]);
                    cCountry_Org_ID.Set(dt.Rows[0]["cCountry_Org_ID"]);
                    object o_cState_Org_ID = dt.Rows[0]["cState_Org_ID"];

                    string sStateCond = null;
                    string sStateVal = null;
                    if (o_cState_Org_ID is long)
                    {
                        cState_Org_ID.Set(o_cState_Org_ID);
                        sStateCond = "Atom_cState_Org_ID = " + cState_Org_ID.ToString();
                        sStateVal = cState_Org_ID.ToString();
                    }
                    else
                    {
                        o_cState_Org_ID = null;
                        sStateCond = "Atom_cState_Org_ID is null";
                        sStateVal = "null";
                    }
                    ID xAtom_cStreetName_Org_ID = null;
                    ID xAtom_cHouseNumber_Org_ID = null;
                    ID xAtom_cCity_Org_ID = null;
                    ID xAtom_cZIP_Org_ID = null;
                    ID xAtom_cCountry_Org_ID = null;
                    if (f_Atom_cStreetName_Org.Get(cStreetName_Org_ID, ref xAtom_cStreetName_Org_ID))
                    {
                        if (f_Atom_cHouseNumber_Org.Get(cHouseNumber_Org_ID, ref xAtom_cHouseNumber_Org_ID))
                        {
                            if (f_Atom_cCity_Org.Get(cCity_Org_ID, ref xAtom_cCity_Org_ID))
                            {
                                if (f_Atom_cZIP_Org.Get(cZIP_Org_ID, ref xAtom_cZIP_Org_ID))
                                {
                                    if (f_Atom_cCountry_Org.Get(cCountry_Org_ID, ref xAtom_cCountry_Org_ID))
                                    {
                                        sql = @"select
                                                    ID
                                                from Atom_cAddress_Org where Atom_cStreetName_Org_ID = " + xAtom_cStreetName_Org_ID.ToString() + @"
                                                and Atom_cHouseNumber_Org_ID = " + xAtom_cHouseNumber_Org_ID.ToString() + @"
                                                and Atom_cCity_Org_ID = " + xAtom_cCity_Org_ID.ToString() + @"
                                                and Atom_cZIP_Org_ID = " + xAtom_cZIP_Org_ID.ToString() + @"
                                                and Atom_cCountry_Org_ID = " + xAtom_cCountry_Org_ID.ToString() + @"
                                                and " + sStateCond;
                                        dt.Clear();
                                        dt.Columns.Clear();
                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                if (Atom_cAddress_Org_ID==null)
                                                {
                                                    Atom_cAddress_Org_ID = new ID();
                                                }
                                                Atom_cAddress_Org_ID.Set(dt.Rows[0]["ID"]);
                                                return true;
                                            }
                                            else
                                            {
                                                sql = @"insert into Atom_cAddress_Org
                                                        (Atom_cStreetName_Org_ID,Atom_cHouseNumber_Org_ID,Atom_cZIP_Org_ID,Atom_cCity_Org_ID,Atom_cCountry_Org_ID,Atom_cState_Org_ID) values
                                                        (" + xAtom_cStreetName_Org_ID.ToString() + "," + xAtom_cHouseNumber_Org_ID.ToString() + "," + xAtom_cZIP_Org_ID.ToString() + "," + xAtom_cCity_Org_ID.ToString() + "," + xAtom_cCountry_Org_ID.ToString() + "," + sStateVal + ")";
                                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_cAddress_Org_ID,  ref Err, "Atom_cAddress_Org"))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:f_Atom_cAddress_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:f_Atom_cAddress_Org:Get:sql=" + sql + "\r\nErr=" + Err);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_cAddress_Org:Get:No cAdddress_Org for cAddress_Org_ID = " + cAddress_Org_ID.ToString());
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_cAddress_Org:Get:sql=" + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}
