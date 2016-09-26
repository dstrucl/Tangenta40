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

namespace TangentaDB
{
    public static class f_Atom_WorkPeriod
    {
        public static string sWorkPeriod_DB_ver_1_04 = "Work period of Database ver 1_04";
        public static string sWorkPeriod = "Work period";

        public static bool Get(string Atom_WorkPeriod_Type_Name,
                                 string Atom_WorkPeriod_Type_Description,
                                 long   Atom_myOrganisation_Person_ID,
                                 long   Atom_WorkingPlace_ID,
                                 long   Atom_Computer_ID,
                                 long   Atom_ElectronicDevice_ID,
                                 DateTime Login_time,
                                 DBTypes.DateTime_v Logout_time_v,
                                 ref long Atom_WorkPeriod_ID)
        {

            long Atom_WorkPeriod_Type_ID = -1;
            if (f_Atom_WorkPeriod_Type.Get(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, ref Atom_WorkPeriod_Type_ID))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string scond_Atom_WorkPeriod_Type_ID = null;
                string sval_Atom_WorkPeriod_Type_ID = "null";
                if (Atom_WorkPeriod_Type_ID >= 0)
                {
                    string spar_Atom_WorkPeriod_Type_ID = "@par_Atom_WorkPeriod_Type_ID";
                    SQL_Parameter par_Atom_WorkPeriod_Type_ID = new SQL_Parameter(spar_Atom_WorkPeriod_Type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_WorkPeriod_Type_ID);
                    lpar.Add(par_Atom_WorkPeriod_Type_ID);
                    scond_Atom_WorkPeriod_Type_ID = "Atom_WorkPeriod_Type_ID = " + spar_Atom_WorkPeriod_Type_ID;
                    sval_Atom_WorkPeriod_Type_ID = spar_Atom_WorkPeriod_Type_ID;
                }
                else
                {
                    scond_Atom_WorkPeriod_Type_ID = "Atom_WorkPeriod_Type_ID is null";
                    sval_Atom_WorkPeriod_Type_ID = "null";
                }

                string scond_Atom_myOrganisation_Person_ID = null;
                string sval_Atom_myOrganisation_Person_ID = "null";
                if (Atom_myOrganisation_Person_ID >= 0)
                {
                    string spar_Atom_myOrganisation_Person_ID = "@par_Atom_myOrganisation_Person_ID";
                    SQL_Parameter par_Atom_myOrganisation_Person_ID = new SQL_Parameter(spar_Atom_myOrganisation_Person_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_myOrganisation_Person_ID);
                    lpar.Add(par_Atom_myOrganisation_Person_ID);
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID = " + spar_Atom_myOrganisation_Person_ID;
                    sval_Atom_myOrganisation_Person_ID = spar_Atom_myOrganisation_Person_ID;
                }
                else
                {
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID is null";
                    sval_Atom_myOrganisation_Person_ID = "null";
                }

                string scond_Atom_WorkingPlace_ID = null;
                string sval_Atom_WorkingPlace_ID = "null";
                if (Atom_WorkingPlace_ID >= 0)
                {
                    string spar_Atom_WorkingPlace_ID = "@par_Atom_WorkingPlace_ID";
                    SQL_Parameter par_Atom_WorkingPlace_ID = new SQL_Parameter(spar_Atom_WorkingPlace_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_WorkingPlace_ID);
                    lpar.Add(par_Atom_WorkingPlace_ID);
                    scond_Atom_WorkingPlace_ID = "Atom_WorkingPlace_ID = " + spar_Atom_WorkingPlace_ID;
                    sval_Atom_WorkingPlace_ID = spar_Atom_WorkingPlace_ID;
                }
                else
                {
                    scond_Atom_WorkingPlace_ID = "Atom_WorkingPlace_ID is null";
                    sval_Atom_WorkingPlace_ID = "null";
                }

                string scond_Atom_Computer_ID = null;
                string sval_Atom_Computer_ID = "null";
                if (Atom_Computer_ID >= 0)
                {
                    string spar_Atom_Computer_ID = "@par_Atom_Computer_ID";
                    SQL_Parameter par_Atom_Computer_ID = new SQL_Parameter(spar_Atom_Computer_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_Computer_ID);
                    lpar.Add(par_Atom_Computer_ID);
                    scond_Atom_Computer_ID = "Atom_Computer_ID = " + spar_Atom_Computer_ID;
                    sval_Atom_Computer_ID = spar_Atom_Computer_ID;
                }
                else
                {
                    scond_Atom_Computer_ID = "Atom_Computer_ID is null";
                    sval_Atom_Computer_ID = "null";
                }

                string scond_Atom_ElectronicDevice_ID = null;
                string sval_Atom_ElectronicDevice_ID = "null";
                if (Atom_ElectronicDevice_ID >= 0)
                {
                    string spar_Atom_ElectronicDevice_ID = "@par_Atom_ElectronicDevice_ID";
                    SQL_Parameter par_Atom_ElectronicDevice_ID = new SQL_Parameter(spar_Atom_ElectronicDevice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_ElectronicDevice_ID);
                    lpar.Add(par_Atom_ElectronicDevice_ID);
                    scond_Atom_ElectronicDevice_ID = "Atom_ElectronicDevice_ID = " + spar_Atom_ElectronicDevice_ID;
                    sval_Atom_ElectronicDevice_ID = spar_Atom_ElectronicDevice_ID;
                }
                else
                {
                    scond_Atom_ElectronicDevice_ID = "Atom_ElectronicDevice_ID is null";
                    sval_Atom_ElectronicDevice_ID = "null";
                }

                string scond_Login_time = null;
                string sval_Login_time = "null";
                if (Login_time >= DateTime.MinValue)
                {
                    string spar_Login_time = "@par_LoginTime";
                    SQL_Parameter par_Login_time = new SQL_Parameter(spar_Login_time, SQL_Parameter.eSQL_Parameter.Datetime, false, Login_time);
                    lpar.Add(par_Login_time);
                    scond_Login_time = "LoginTime = " + spar_Login_time;
                    sval_Login_time = spar_Login_time;
                }
                else
                {
                    scond_Login_time = "LoginTime is null";
                    sval_Login_time = "null";
                }

                string scond_Logout_time = null;
                string sval_Logout_time = "null";
                if (Logout_time_v !=null)
                {
                    string spar_Logout_time = "@par_LogoutTime";
                    SQL_Parameter par_Logout_time = new SQL_Parameter(spar_Logout_time, SQL_Parameter.eSQL_Parameter.Datetime, false, Logout_time_v.v);
                    lpar.Add(par_Logout_time);
                    scond_Logout_time = "LogoutTime = " + spar_Logout_time;
                    sval_Logout_time = spar_Logout_time;
                }
                else
                {
                    scond_Logout_time = "LogoutTime is null";
                    sval_Logout_time = "null";
                }

                string Err = null;
                DataTable dt = new DataTable();

                string sql = @"select ID from Atom_WorkPeriod
                                            where (" + scond_Atom_WorkPeriod_Type_ID 
                                            + ") and (" + scond_Atom_myOrganisation_Person_ID 
                                            + ") and (" + scond_Atom_WorkingPlace_ID 
                                            + ") and (" + scond_Atom_Computer_ID
                                            + ") and (" + scond_Atom_ElectronicDevice_ID
                                            + ") and (" + scond_Login_time 
                                            + ") and (" + scond_Logout_time + ")";

                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        Atom_WorkPeriod_ID = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_WorkPeriod (Atom_WorkPeriod_TYPE_ID,
                                                               Atom_myOrganisation_Person_ID,
                                                               Atom_WorkingPlace_ID,
                                                               Atom_Computer_ID,
                                                               Atom_ElectronicDevice_ID,
                                                               LoginTime,
                                                               LogoutTime) values ("
                                                                + sval_Atom_WorkPeriod_Type_ID +","
                                                                + sval_Atom_myOrganisation_Person_ID +","
                                                                + sval_Atom_WorkingPlace_ID +","
                                                                + sval_Atom_Computer_ID +","
                                                                + sval_Atom_ElectronicDevice_ID + ","
                                                                + sval_Login_time +","
                                                                + sval_Logout_time +
                                                                ")";
                        object objretx = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_WorkPeriod_ID, ref objretx, ref Err, "Atom_WorkPeriod"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:Get:" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool GetOld(string Atom_WorkPeriod_Type_Name,
                                 string Atom_WorkPeriod_Type_Description,
                                 long Atom_myOrganisation_Person_ID,
                                 long Atom_WorkingPlace_ID,
                                 long Atom_Computer_ID,
                                 DateTime Login_time,
                                 DBTypes.DateTime_v Logout_time_v,
                                 ref long Atom_WorkPeriod_ID)
        {

            long Atom_WorkPeriod_Type_ID = -1;
            if (f_Atom_WorkPeriod_Type.Get(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, ref Atom_WorkPeriod_Type_ID))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string scond_Atom_WorkPeriod_Type_ID = null;
                string sval_Atom_WorkPeriod_Type_ID = "null";
                if (Atom_WorkPeriod_Type_ID >= 0)
                {
                    string spar_Atom_WorkPeriod_Type_ID = "@par_Atom_WorkPeriod_Type_ID";
                    SQL_Parameter par_Atom_WorkPeriod_Type_ID = new SQL_Parameter(spar_Atom_WorkPeriod_Type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_WorkPeriod_Type_ID);
                    lpar.Add(par_Atom_WorkPeriod_Type_ID);
                    scond_Atom_WorkPeriod_Type_ID = "Atom_WorkPeriod_Type_ID = " + spar_Atom_WorkPeriod_Type_ID;
                    sval_Atom_WorkPeriod_Type_ID = spar_Atom_WorkPeriod_Type_ID;
                }
                else
                {
                    scond_Atom_WorkPeriod_Type_ID = "Atom_WorkPeriod_Type_ID is null";
                    sval_Atom_WorkPeriod_Type_ID = "null";
                }

                string scond_Atom_myOrganisation_Person_ID = null;
                string sval_Atom_myOrganisation_Person_ID = "null";
                if (Atom_myOrganisation_Person_ID >= 0)
                {
                    string spar_Atom_myOrganisation_Person_ID = "@par_Atom_myOrganisation_Person_ID";
                    SQL_Parameter par_Atom_myOrganisation_Person_ID = new SQL_Parameter(spar_Atom_myOrganisation_Person_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_myOrganisation_Person_ID);
                    lpar.Add(par_Atom_myOrganisation_Person_ID);
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID = " + spar_Atom_myOrganisation_Person_ID;
                    sval_Atom_myOrganisation_Person_ID = spar_Atom_myOrganisation_Person_ID;
                }
                else
                {
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID is null";
                    sval_Atom_myOrganisation_Person_ID = "null";
                }

                string scond_Atom_WorkingPlace_ID = null;
                string sval_Atom_WorkingPlace_ID = "null";
                if (Atom_WorkingPlace_ID >= 0)
                {
                    string spar_Atom_WorkingPlace_ID = "@par_Atom_WorkingPlace_ID";
                    SQL_Parameter par_Atom_WorkingPlace_ID = new SQL_Parameter(spar_Atom_WorkingPlace_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_WorkingPlace_ID);
                    lpar.Add(par_Atom_WorkingPlace_ID);
                    scond_Atom_WorkingPlace_ID = "Atom_WorkingPlace_ID = " + spar_Atom_WorkingPlace_ID;
                    sval_Atom_WorkingPlace_ID = spar_Atom_WorkingPlace_ID;
                }
                else
                {
                    scond_Atom_WorkingPlace_ID = "Atom_WorkingPlace_ID is null";
                    sval_Atom_WorkingPlace_ID = "null";
                }

                string scond_Atom_Computer_ID = null;
                string sval_Atom_Computer_ID = "null";
                if (Atom_Computer_ID >= 0)
                {
                    string spar_Atom_Computer_ID = "@par_Atom_Computer_ID";
                    SQL_Parameter par_Atom_Computer_ID = new SQL_Parameter(spar_Atom_Computer_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_Computer_ID);
                    lpar.Add(par_Atom_Computer_ID);
                    scond_Atom_Computer_ID = "Atom_Computer_ID = " + spar_Atom_Computer_ID;
                    sval_Atom_Computer_ID = spar_Atom_Computer_ID;
                }
                else
                {
                    scond_Atom_Computer_ID = "Atom_Computer_ID is null";
                    sval_Atom_Computer_ID = "null";
                }

                string scond_Login_time = null;
                string sval_Login_time = "null";
                if (Login_time >= DateTime.MinValue)
                {
                    string spar_Login_time = "@par_LoginTime";
                    SQL_Parameter par_Login_time = new SQL_Parameter(spar_Login_time, SQL_Parameter.eSQL_Parameter.Datetime, false, Login_time);
                    lpar.Add(par_Login_time);
                    scond_Login_time = "LoginTime = " + spar_Login_time;
                    sval_Login_time = spar_Login_time;
                }
                else
                {
                    scond_Login_time = "LoginTime is null";
                    sval_Login_time = "null";
                }

                string scond_Logout_time = null;
                string sval_Logout_time = "null";
                if (Logout_time_v != null)
                {
                    string spar_Logout_time = "@par_LogoutTime";
                    SQL_Parameter par_Logout_time = new SQL_Parameter(spar_Logout_time, SQL_Parameter.eSQL_Parameter.Datetime, false, Logout_time_v.v);
                    lpar.Add(par_Logout_time);
                    scond_Logout_time = "LogoutTime = " + spar_Logout_time;
                    sval_Logout_time = spar_Logout_time;
                }
                else
                {
                    scond_Logout_time = "LogoutTime is null";
                    sval_Logout_time = "null";
                }

                string Err = null;
                DataTable dt = new DataTable();

                string sql = @"select ID from Atom_WorkPeriod
                                            where (" + scond_Atom_WorkPeriod_Type_ID
                                            + ") and (" + scond_Atom_myOrganisation_Person_ID
                                            + ") and (" + scond_Atom_WorkingPlace_ID
                                            + ") and (" + scond_Atom_Computer_ID
                                            + ") and (" + scond_Login_time
                                            + ") and (" + scond_Logout_time + ")";

                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        Atom_WorkPeriod_ID = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_WorkPeriod (Atom_WorkPeriod_TYPE_ID,
                                                               Atom_myOrganisation_Person_ID,
                                                               Atom_WorkingPlace_ID,
                                                               Atom_Computer_ID,
                                                               LoginTime,
                                                               LogoutTime) values ("
                                                                + sval_Atom_WorkPeriod_Type_ID + ","
                                                                + sval_Atom_myOrganisation_Person_ID + ","
                                                                + sval_Atom_WorkingPlace_ID + ","
                                                                + sval_Atom_Computer_ID + ","
                                                                + sval_Login_time + ","
                                                                + sval_Logout_time +
                                                                ")";
                        object objretx = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_WorkPeriod_ID, ref objretx, ref Err, "Atom_WorkPeriod"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:Get:" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:Get:" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool End(long Atom_WorkPeriod_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            DateTime dtWorkPeriodEnd = DateTime.Now;
            string spar_WorkPeriodEnd = "@par_WorkPeriodEnd";
            SQL_Parameter par_PeriodEnd = new SQL_Parameter(spar_WorkPeriodEnd,SQL_Parameter.eSQL_Parameter.Datetime,false,dtWorkPeriodEnd);
            lpar.Add(par_PeriodEnd);


            string sql = "update Atom_WorkPeriod set LogoutTime = " + spar_WorkPeriodEnd + " where ID = " + Atom_WorkPeriod_ID.ToString();
            object ores = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql,lpar,ref ores,ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:End:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
