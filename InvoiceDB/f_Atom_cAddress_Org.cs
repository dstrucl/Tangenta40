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
    public static class f_Atom_cAddress_Org
    {
        public static bool Get(string_v StreetName_v, string_v HouseNumber_v, string_v ZIP_v, string_v City_v, string_v State_v, string_v Country_v, ref long_v Atom_cAddress_Org_ID_v)
        {
            if ((StreetName_v == null) || (HouseNumber_v == null) || (ZIP_v == null) || (City_v == null) || (State_v == null))
            {
                Atom_cAddress_Org_ID_v = null;
                return true;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            long_v Atom_cStreetName_Org_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cStreetName_Org", "StreetName", StreetName_v, ref Atom_cStreetName_Org_ID_v))
            {
                return false;
            }
            string Atom_cStreetName_Org_ID_cond = null;
            string Atom_cStreetName_Org_ID_value = null;
            if (!fs.AddPar("Atom_cStreetName_Org_ID", ref lpar, Atom_cStreetName_Org_ID_v, ref Atom_cStreetName_Org_ID_cond, ref Atom_cStreetName_Org_ID_value))
            {
                return false;
            }
            long_v Atom_cHouseNumber_Org_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cHouseNumber_Org", "HouseNumber", HouseNumber_v, ref Atom_cHouseNumber_Org_ID_v))
            {
                return false;
            }
            string Atom_cHouseNumber_Org_ID_cond = null;
            string Atom_cHouseNumber_Org_ID_value = null;
            if (!fs.AddPar("Atom_cHouseNumber_Org_ID", ref lpar, Atom_cHouseNumber_Org_ID_v, ref Atom_cHouseNumber_Org_ID_cond, ref Atom_cHouseNumber_Org_ID_value))
            {
                return false;
            }
            long_v Atom_cZIP_Org_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cZIP_Org", "ZIP", ZIP_v, ref Atom_cZIP_Org_ID_v))
            {
                return false;
            }
            string Atom_cZIP_Org_ID_cond = null;
            string Atom_cZIP_Org_ID_value = null;
            if (!fs.AddPar("Atom_cZIP_Org_ID", ref lpar, Atom_cZIP_Org_ID_v, ref Atom_cZIP_Org_ID_cond, ref Atom_cZIP_Org_ID_value))
            {
                return false;
            }
            long_v Atom_cCity_Org_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cCity_Org", "City", City_v, ref Atom_cCity_Org_ID_v))
            {
                return false;
            }
            string Atom_cCity_Org_ID_cond = null;
            string Atom_cCity_Org_ID_value = null;
            if (!fs.AddPar("Atom_cCity_Org_ID", ref lpar, Atom_cCity_Org_ID_v, ref Atom_cCity_Org_ID_cond, ref Atom_cCity_Org_ID_value))
            {
                return false;
            }
            long_v Atom_cState_Org_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cState_Org", "State", State_v, ref Atom_cState_Org_ID_v))
            {
                return false;
            }
            string Atom_cState_Org_ID_cond = null;
            string Atom_cState_Org_ID_value = null;
            if (!fs.AddPar("Atom_cState_Org_ID", ref lpar, Atom_cState_Org_ID_v, ref Atom_cState_Org_ID_cond, ref Atom_cState_Org_ID_value))
            {
                return false;
            }
            long_v Atom_cCountry_Org_ID_v = null;
            if (!fs.Get_string_table_ID("Atom_cCountry_Org", "Country", Country_v, ref Atom_cCountry_Org_ID_v))
            {
                return false;
            }
            string Atom_cCountry_Org_ID_cond = null;
            string Atom_cCountry_Org_ID_value = null;
            if (!fs.AddPar("Atom_cCountry_Org_ID", ref lpar, Atom_cCountry_Org_ID_v, ref Atom_cCountry_Org_ID_cond, ref Atom_cCountry_Org_ID_value))
            {
                return false;
            }

            string sql = "select ID from Atom_cAddress_Org where " + Atom_cStreetName_Org_ID_cond
                                                                     + " and " + Atom_cHouseNumber_Org_ID_cond
                                                                     + " and " + Atom_cZIP_Org_ID_cond
                                                                     + " and " + Atom_cCity_Org_ID_cond
                                                                     + " and " + Atom_cState_Org_ID_cond
                                                                     + " and " + Atom_cCountry_Org_ID_cond + " order by ID desc";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_cAddress_Org_ID_v == null)
                    {
                        Atom_cAddress_Org_ID_v = new long_v();
                    }
                    Atom_cAddress_Org_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = " insert into Atom_cAddress_Org (Atom_cStreetName_Org_ID,Atom_cHouseNumber_Org_ID,Atom_cZIP_Org_ID,Atom_cCity_Org_ID,Atom_cState_Org_ID,Atom_cCountry_Org_ID)values(" + Atom_cStreetName_Org_ID_value + "," + Atom_cHouseNumber_Org_ID_value + "," + Atom_cZIP_Org_ID_value + "," + Atom_cCity_Org_ID_value + "," + Atom_cState_Org_ID_value + "," + Atom_cCountry_Org_ID_value + ")";
                    long id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref ores, ref Err, "Atom_cAddress_Org"))
                    {
                        if (Atom_cAddress_Org_ID_v == null)
                        {
                            Atom_cAddress_Org_ID_v = new long_v();
                        }
                        Atom_cAddress_Org_ID_v.v = id;
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

        public static bool Get(long cAddress_Org_ID, ref long Atom_cAddress_Org_ID)
        {
            long cStreetName_Org_ID = -1;
            long cHouseNumber_Org_ID = -1;
            long cCity_Org_ID = -1;
            long cZIP_Org_ID = -1;
            long cState_Org_ID = -1;
            long cCountry_Org_ID = -1;
            string sql = @"select 
                            cAorg.cStreetName_Org_ID,
                            cAorg.cHouseNumber_Org_ID,
                            cAorg.cZIP_Org_ID,
                            cAorg.cCity_Org_ID,
                            cAorg.cState_Org_ID,
                            cAorg.cState_Org_ID,
                            cAorg.cCountry_Org_ID
                            from cAddress_Org cAorg
                            where cAorg.ID = " + cAddress_Org_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    cStreetName_Org_ID = (long)dt.Rows[0]["cStreetName_Org_ID"];
                    cHouseNumber_Org_ID = (long)dt.Rows[0]["cHouseNumber_Org_ID"];
                    cZIP_Org_ID = (long)dt.Rows[0]["cZIP_Org_ID"];
                    cCity_Org_ID = (long)dt.Rows[0]["cCity_Org_ID"];
                    cState_Org_ID = (long)dt.Rows[0]["cState_Org_ID"];
                    object o_cCountry_Org_ID = dt.Rows[0]["cCountry_Org_ID"];

                    string sCountryCond = null;
                    string sCountryVal = null;
                    if (o_cCountry_Org_ID is long)
                    {
                        cCountry_Org_ID = (long)o_cCountry_Org_ID;
                        sCountryCond = "Atom_cCountry_Org_ID = " + cCountry_Org_ID.ToString();
                        sCountryVal = cCountry_Org_ID.ToString();
                    }
                    else
                    {
                        o_cCountry_Org_ID = null;
                        sCountryCond = "Atom_cCountry_Org_ID is null";
                        sCountryVal = "null";
                    }
                    long Atom_cStreetName_Org_ID = -1;
                    long Atom_cHouseNumber_Org_ID = -1;
                    long Atom_cCity_Org_ID = -1;
                    long Atom_cZIP_Org_ID = -1;
                    long Atom_cState_Org_ID = -1;
                    if (f_Atom_cStreetName_Org.Get(cStreetName_Org_ID, ref Atom_cStreetName_Org_ID))
                    {
                        if (f_Atom_cHouseNumber_Org.Get(cHouseNumber_Org_ID, ref Atom_cHouseNumber_Org_ID))
                        {
                            if (f_Atom_cCity_Org.Get(cCity_Org_ID, ref Atom_cCity_Org_ID))
                            {
                                if (f_Atom_cZIP_Org.Get(cZIP_Org_ID, ref Atom_cZIP_Org_ID))
                                {
                                    if (f_Atom_cState_Org.Get(cState_Org_ID, ref Atom_cState_Org_ID))
                                    {
                                        sql = @"select
                                                    ID
                                                from Atom_cAddress_Org where Atom_cStreetName_Org_ID = " + Atom_cStreetName_Org_ID.ToString() + @"
                                                and Atom_cHouseNumber_Org_ID = " + Atom_cHouseNumber_Org_ID.ToString() + @"
                                                and Atom_cCity_Org_ID = " + Atom_cCity_Org_ID.ToString() + @"
                                                and Atom_cZIP_Org_ID = " + Atom_cZIP_Org_ID.ToString() + @"
                                                and Atom_cState_Org_ID = " + Atom_cState_Org_ID.ToString() + @"
                                                and " + sCountryCond;
                                        dt.Clear();
                                        dt.Columns.Clear();
                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                Atom_cAddress_Org_ID = (long)dt.Rows[0]["ID"];
                                                return true;
                                            }
                                            else
                                            {
                                                sql = @"insert into Atom_cAddress_Org
                                                        (Atom_cStreetName_Org_ID,Atom_cHouseNumber_Org_ID,Atom_cZIP_Org_ID,Atom_cCity_Org_ID,Atom_cState_Org_ID,Atom_cCountry_Org_ID) values
                                                        (" + Atom_cStreetName_Org_ID.ToString() + "," + Atom_cHouseNumber_Org_ID.ToString() + "," + Atom_cZIP_Org_ID.ToString() + "," + Atom_cCity_Org_ID.ToString() + "," + Atom_cState_Org_ID.ToString() + "," + sCountryVal + ")";
                                                object objretx = null;
                                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_cAddress_Org_ID, ref objretx, ref Err, "Atom_cAddress_Org"))
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
