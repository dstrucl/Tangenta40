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
    public static class f_cAddress_Person
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
                               ref ID cAddress_Person_ID,
                               Transaction transaction)
        {
            if ((StreetName_v == null) || (HouseNumber_v == null) || (ZIP_v == null) || (City_v == null) || (Country_v == null))
            {
                cAddress_Person_ID = null;
                return true;
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            ID cStreetName_Person_ID = null;
            if (!f_cStreetName_Person.Get(StreetName_v, ref cStreetName_Person_ID, transaction))
            {
                return false;
            }
            string cStreetName_Person_ID_cond = null;
            string cStreetName_Person_ID_value = null;
            if (!fs.AddPar("cStreetName_Person_ID", ref lpar, cStreetName_Person_ID, ref cStreetName_Person_ID_cond, ref cStreetName_Person_ID_value))
            {
                return false;
            }

            ID cHouseNumber_Person_ID = null;
            if (!f_cHouseNumber_Person.Get(HouseNumber_v, ref cHouseNumber_Person_ID,transaction))
            {
                return false;
            }
            string cHouseNumber_Person_ID_cond = null;
            string cHouseNumber_Person_ID_value = null;
            if (!fs.AddPar("cHouseNumber_Person_ID", ref lpar, cHouseNumber_Person_ID, ref cHouseNumber_Person_ID_cond, ref cHouseNumber_Person_ID_value))
            {
                return false;
            }

            ID cZIP_Person_ID = null;
            if (!f_cZIP_Person.Get(ZIP_v, ref cZIP_Person_ID,transaction))
            {
                return false;
            }
            string cZIP_Person_ID_cond = null;
            string cZIP_Person_ID_value = null;
            if (!fs.AddPar("cZIP_Person_ID", ref lpar, cZIP_Person_ID, ref cZIP_Person_ID_cond, ref cZIP_Person_ID_value))
            {
                return false;
            }

            ID cCity_Person_ID = null;
            if (!f_cCity_Person.Get(City_v, ref cCity_Person_ID, transaction))
            {
                return false;
            }
            string cCity_Person_ID_cond = null;
            string cCity_Person_ID_value = null;
            if (!fs.AddPar("cCity_Person_ID", ref lpar, cCity_Person_ID, ref cCity_Person_ID_cond, ref cCity_Person_ID_value))
            {
                return false;
            }

            ID cCountry_Person_ID = null;
            if (!f_cCountry_Person.Get(Country_v, Country_ISO_3166_a2_v, Country_ISO_3166_a3_v, Country_ISO_3166_num_v, ref cCountry_Person_ID, transaction))
            {
                return false;
            }
            string cCountry_Person_ID_cond = null;
            string cCountry_Person_ID_value = null;
            if (!fs.AddPar("cCountry_Person_ID", ref lpar, cCountry_Person_ID, ref cCountry_Person_ID_cond, ref cCountry_Person_ID_value))
            {
                return false;
            }

            ID cState_Person_ID = null;
            if (!f_cState_Person.Get(State_v, ref cState_Person_ID, transaction))
            {
                return false;
            }
            string cState_Person_ID_cond = null;
            string cState_Person_ID_value = null;
            if (!fs.AddPar("cState_Person_ID", ref lpar, cState_Person_ID, ref cState_Person_ID_cond, ref cState_Person_ID_value))
            {
                return false;
            }

            string sql = "select ID from cAddress_Person where " + cStreetName_Person_ID_cond
                                                                     + " and " + cHouseNumber_Person_ID_cond
                                                                     + " and " + cZIP_Person_ID_cond
                                                                     + " and " + cCity_Person_ID_cond
                                                                     + " and " + cCountry_Person_ID_cond
                                                                     + " and " + cState_Person_ID_cond + " order by ID desc";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (cAddress_Person_ID == null)
                    {
                        cAddress_Person_ID = new ID();
                    }
                    cAddress_Person_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = " insert into cAddress_Person (cStreetName_Person_ID,cHouseNumber_Person_ID,cZIP_Person_ID,cCity_Person_ID,cCountry_Person_ID,cState_Person_ID)values(" + cStreetName_Person_ID_value + "," + cHouseNumber_Person_ID_value + "," + cZIP_Person_ID_value + "," + cCity_Person_ID_value + "," + cCountry_Person_ID_value + "," + cState_Person_ID_value + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cAddress_Person_ID, ref Err, "cAddress_Person"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Customer_Person:Get_cAddress_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Customer_Person:Get_cAddress_Person_ID:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        internal static bool Get(PostAddress_v address_v, ref ID cAdress_Person_iD, Transaction transaction)
        {
            string Err = null;
            ID xcStreetName_Person_ID = null;
            ID xcHouseNumber_Person_ID = null;
            ID xcCity_Person_ID = null;
            ID xcZIP_Person_ID = null;
            ID xcCountry_Person_ID = null;
            ID xcState_Person_ID = null;

            if (f_cStreetName_Person.Get(address_v.StreetName_v, ref xcStreetName_Person_ID, transaction))
            {
                if (f_cHouseNumber_Person.Get(address_v.HouseNumber_v, ref xcHouseNumber_Person_ID, transaction))
                {
                    if (f_cCity_Person.Get(address_v.City_v, ref xcCity_Person_ID, transaction))
                    {
                        if (f_cZIP_Person.Get(address_v.ZIP_v, ref xcZIP_Person_ID, transaction))
                        {
                            if (f_cCountry_Person.Get(address_v.Country_v,
                                                      address_v.Country_ISO_3166_a2_v,
                                                      address_v.Country_ISO_3166_a3_v,
                                                      address_v.Country_ISO_3166_num_v,
                                                      ref xcCountry_Person_ID, transaction))
                            {
                                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                                string scond_cStreetName_Person_ID_v = " cStreetName_Person_ID is null ";
                                string sval_cStreetName_Person_ID_v = "null";

                                if (ID.Validate(xcStreetName_Person_ID))
                                {
                                    string spar_cStreetName_Person_ID_v = "@par_cStreetName_Person_ID_v";
                                    SQL_Parameter par_cStreetName_Person_ID_v = new SQL_Parameter(spar_cStreetName_Person_ID_v, false, xcStreetName_Person_ID);
                                    lpar.Add(par_cStreetName_Person_ID_v);
                                    scond_cStreetName_Person_ID_v = " cStreetName_Person_ID = " + spar_cStreetName_Person_ID_v;
                                    sval_cStreetName_Person_ID_v = spar_cStreetName_Person_ID_v;
                                }



                                string scond_cHouseNumber_Person_ID_v = " cHouseNumber_Person_ID is null ";
                                string sval_cHouseNumber_Person_ID_v = "null";
                                if (ID.Validate(xcHouseNumber_Person_ID))
                                {
                                    string spar_cHouseNumber_Person_ID_v = "@par_cHouseNumber_Person_ID_v";
                                    SQL_Parameter par_cHouseNumber_Person_ID_v = new SQL_Parameter(spar_cHouseNumber_Person_ID_v,  false, xcHouseNumber_Person_ID);
                                    lpar.Add(par_cHouseNumber_Person_ID_v);
                                    scond_cHouseNumber_Person_ID_v = " cHouseNumber_Person_ID = " + spar_cHouseNumber_Person_ID_v;
                                    sval_cHouseNumber_Person_ID_v = spar_cHouseNumber_Person_ID_v;
                                }

                                string scond_cCity_Person_ID_v = " cCity_Person_ID is null ";
                                string sval_cCity_Person_ID_v = "null";
                                if (ID.Validate(xcCity_Person_ID))
                                {
                                    string spar_cCity_Person_ID_v = "@par_cCity_Person_ID_v";
                                    SQL_Parameter par_cCity_Person_ID_v = new SQL_Parameter(spar_cCity_Person_ID_v, false, xcCity_Person_ID);
                                    lpar.Add(par_cCity_Person_ID_v);
                                    scond_cCity_Person_ID_v = " cCity_Person_ID = " + spar_cCity_Person_ID_v;
                                    sval_cCity_Person_ID_v = spar_cCity_Person_ID_v;
                                }

                                string scond_cZIP_Person_ID_v = " cZIP_Person_ID is null ";
                                string sval_cZIP_Person_ID_v = "null";
                                if (ID.Validate(xcZIP_Person_ID))
                                {
                                    string spar_cZIP_Person_ID_v = "@par_cZIP_Person_ID_v";
                                    SQL_Parameter par_cZIP_Person_ID_v = new SQL_Parameter(spar_cZIP_Person_ID_v, false, xcZIP_Person_ID);
                                    lpar.Add(par_cZIP_Person_ID_v);
                                    scond_cZIP_Person_ID_v = " cZIP_Person_ID = " + spar_cZIP_Person_ID_v;
                                    sval_cZIP_Person_ID_v = spar_cZIP_Person_ID_v;
                                }

                                string scond_cCountry_Person_ID_v = " cCountry_Person_ID is null ";
                                string sval_cCountry_Person_ID_v = "null";
                                if (ID.Validate(xcCountry_Person_ID))
                                {
                                    string spar_cCountry_Person_ID_v = "@par_cCountry_Person_ID_v";
                                    SQL_Parameter par_cCountry_Person_ID_v = new SQL_Parameter(spar_cCountry_Person_ID_v, false, xcCountry_Person_ID);
                                    lpar.Add(par_cCountry_Person_ID_v);
                                    scond_cCountry_Person_ID_v = " cCountry_Person_ID = " + spar_cCountry_Person_ID_v;
                                    sval_cCountry_Person_ID_v = spar_cCountry_Person_ID_v;
                                }

                                string scond_cState_Person_ID_v = " cState_Person_ID is null ";
                                string sval_cState_Person_ID_v = "null";
                                if (ID.Validate(xcState_Person_ID))
                                {
                                    string spar_cState_Person_ID_v = "@par_cState_Person_ID_v";
                                    SQL_Parameter par_cState_Person_ID_v = new SQL_Parameter(spar_cState_Person_ID_v, false, xcState_Person_ID);
                                    lpar.Add(par_cState_Person_ID_v);
                                    scond_cState_Person_ID_v = " cState_Person_ID = " + spar_cState_Person_ID_v;
                                    sval_cState_Person_ID_v = spar_cState_Person_ID_v;
                                }
                                string sql = "select ID from cAddress_Person where " + scond_cStreetName_Person_ID_v + " and "
                                                                                       + scond_cHouseNumber_Person_ID_v + " and "
                                                                                       + scond_cCity_Person_ID_v + " and "
                                                                                       + scond_cZIP_Person_ID_v + " and "
                                                                                       + scond_cCountry_Person_ID_v + " and "
                                                                                       + scond_cState_Person_ID_v;

                                DataTable dt = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (cAdress_Person_iD == null)
                                        {
                                            cAdress_Person_iD = new ID();
                                        }
                                        cAdress_Person_iD.Set(dt.Rows[0]["ID"]);
                                        return true;
                                    }
                                    else
                                    {
                                        sql = "insert into cAddress_Person (cStreetName_Person_ID,cHouseNumber_Person_ID,cCity_Person_ID,cZIP_Person_ID,cCountry_Person_ID,cState_Person_ID) values ("
                                                + sval_cStreetName_Person_ID_v + ","
                                                + sval_cHouseNumber_Person_ID_v + ","
                                                + sval_cCity_Person_ID_v + ","
                                                + sval_cZIP_Person_ID_v + ","
                                                + sval_cCountry_Person_ID_v + ","
                                                + sval_cState_Person_ID_v + ")";
                                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref cAdress_Person_iD,  ref Err, "cAddress_Person"))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:TangentaDB:f_cAddress_Person:Get(PostAddress_v address_v, ref ID cAdress_Person_iD) sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR::TangentaDB:f_cAddress_Person:Get(PostAddress_v address_v, ref ID cAdress_Person_iD) sql=" + sql + "\r\nErr=" + Err);
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
