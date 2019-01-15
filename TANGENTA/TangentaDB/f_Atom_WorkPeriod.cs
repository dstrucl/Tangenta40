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
    public static class f_Atom_WorkPeriod
    {
        public static string sWorkPeriod_DB_ver_1_04 = "Work period of Database ver 1_04";
        public static string sWorkPeriod = "Work period";

        public static bool Get(string Atom_WorkPeriod_Type_Name,
                                 string Atom_WorkPeriod_Type_Description,
                                 ID   Atom_myOrganisation_Person_ID,
                                 ID   Atom_ElectronicDevice_ID,
                                 ID   Atom_IP_address_ID,
                                 DateTime Login_time,
                                 DBTypes.DateTime_v Logout_time_v,
                                 ref ID Atom_WorkPeriod_ID,
                                 Transaction transaction)
        {

            ID Atom_WorkPeriod_Type_ID = null;
            if (f_Atom_WorkPeriod_Type.Get(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, ref Atom_WorkPeriod_Type_ID, transaction))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string scond_Atom_WorkPeriod_Type_ID = null;
                string sval_Atom_WorkPeriod_Type_ID = "null";
                if (ID.Validate(Atom_WorkPeriod_Type_ID))
                {
                    string spar_Atom_WorkPeriod_Type_ID = "@par_Atom_WorkPeriod_Type_ID";
                    SQL_Parameter par_Atom_WorkPeriod_Type_ID = new SQL_Parameter(spar_Atom_WorkPeriod_Type_ID, false, Atom_WorkPeriod_Type_ID);
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
                if (ID.Validate(Atom_myOrganisation_Person_ID))
                {
                    string spar_Atom_myOrganisation_Person_ID = "@par_Atom_myOrganisation_Person_ID";
                    SQL_Parameter par_Atom_myOrganisation_Person_ID = new SQL_Parameter(spar_Atom_myOrganisation_Person_ID, false, Atom_myOrganisation_Person_ID);
                    lpar.Add(par_Atom_myOrganisation_Person_ID);
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID = " + spar_Atom_myOrganisation_Person_ID;
                    sval_Atom_myOrganisation_Person_ID = spar_Atom_myOrganisation_Person_ID;
                }
                else
                {
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID is null";
                    sval_Atom_myOrganisation_Person_ID = "null";
                }



                string scond_Atom_ElectronicDevice_ID = null;
                string sval_Atom_ElectronicDevice_ID = "null";
                if (ID.Validate(Atom_ElectronicDevice_ID))
                {
                    string spar_Atom_ElectronicDevice_ID = "@par_Atom_ElectronicDevice_ID";
                    SQL_Parameter par_Atom_ElectronicDevice_ID = new SQL_Parameter(spar_Atom_ElectronicDevice_ID, false, Atom_ElectronicDevice_ID);
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
                                            + ") and (" + scond_Atom_ElectronicDevice_ID
                                            + ") and (" + scond_Login_time 
                                            + ") and (" + scond_Logout_time + ")";

                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_WorkPeriod_ID==null)
                        {
                            Atom_WorkPeriod_ID = new ID();
                        }
                        Atom_WorkPeriod_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        if (f_Atom_IP_address.Get(ref Atom_IP_address_ID, transaction))
                        {
                            string sval_Atom_IP_address_ID = "null";
                            if (ID.Validate(Atom_IP_address_ID))
                            {
                                string spar_Atom_IP_address_ID = "@par_Atom_IP_address_ID";
                                SQL_Parameter par_Atom_IP_address_ID = new SQL_Parameter(spar_Atom_IP_address_ID, false, Atom_IP_address_ID);
                                lpar.Add(par_Atom_IP_address_ID);
                                sval_Atom_IP_address_ID = spar_Atom_IP_address_ID;
                            }
                            else
                            {
                                sval_Atom_IP_address_ID = "null";
                            }

                            sql = @"insert into Atom_WorkPeriod (Atom_WorkPeriod_TYPE_ID,
                                                               Atom_myOrganisation_Person_ID,
                                                               Atom_ElectronicDevice_ID,
                                                               LoginTime,
                                                               LogoutTime,
                                                               Atom_IP_address_ID) values ("
                                                                + sval_Atom_WorkPeriod_Type_ID + ","
                                                                + sval_Atom_myOrganisation_Person_ID + ","
                                                                + sval_Atom_ElectronicDevice_ID + ","
                                                                + sval_Login_time + ","
                                                                + sval_Logout_time + ","
                                                                + sval_Atom_IP_address_ID +
                                                                ")";
                            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_WorkPeriod_ID, ref Err, "Atom_WorkPeriod"))
                            {
                                return true;
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

        public static bool GetLogoutTime(ID atom_WorkPeriod_ID, ref DateTime logoutTime)
        {
            string Err = null;
            logoutTime = DateTime.MinValue;
            string sql = @"select LogoutTime from Atom_WorkPeriod where ID = " + atom_WorkPeriod_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    DateTime_v logoutTime_v = tf.set_DateTime(dt.Rows[0]["LogoutTime"]);
                    if (logoutTime_v != null)
                    {
                        logoutTime = logoutTime_v.v;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:GetLogoutTime:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetLoginTime(ID xAtom_WorkPeriod_ID, ref DateTime loginTime)
        {
            string Err = null;
            loginTime = DateTime.MaxValue;
            string sql = @"select LoginTime from Atom_WorkPeriod where ID = " + xAtom_WorkPeriod_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    DateTime_v loginTime_v = tf.set_DateTime(dt.Rows[0]["LoginTime"]);
                    if (loginTime_v!=null)
                    {
                        loginTime = loginTime_v.v;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:GetLoginTime:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Insert_into_Atom_WorkPeriod_Temp(
                               ID  Atom_WorkPeriod_ID,
                              string Atom_WorkPeriod_Type_Name,
                              string Atom_WorkPeriod_Type_Description,
                              ID Atom_myOrganisation_Person_ID,
                              ID Atom_ElectronicDevice_ID,
                              DateTime Login_time,
                              DBTypes.DateTime_v Logout_time_v,
                              Transaction transaction
                              )
        {

            ID Atom_WorkPeriod_Type_ID = null;
            if (f_Atom_WorkPeriod_Type.Get(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, ref Atom_WorkPeriod_Type_ID, transaction))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string scond_Atom_WorkPeriod_ID = null;
                string sval_Atom_WorkPeriod_ID = "null";
                if (ID.Validate(Atom_WorkPeriod_ID))
                {
                    string spar_Atom_WorkPeriod_ID = "@par_Atom_WorkPeriod_ID";
                    SQL_Parameter par_Atom_WorkPeriod_ID = new SQL_Parameter(spar_Atom_WorkPeriod_ID, false, Atom_WorkPeriod_ID);
                    lpar.Add(par_Atom_WorkPeriod_ID);
                    scond_Atom_WorkPeriod_ID = "Atom_WorkPeriod_ID = " + spar_Atom_WorkPeriod_ID;
                    sval_Atom_WorkPeriod_ID = spar_Atom_WorkPeriod_ID;
                }
                else
                {
                    scond_Atom_WorkPeriod_ID = "Atom_WorkPeriod_ID is null";
                    sval_Atom_WorkPeriod_ID = "null";
                }

           
                string scond_Atom_WorkPeriod_Type_ID = null;
                string sval_Atom_WorkPeriod_Type_ID = "null";
                if (ID.Validate(Atom_WorkPeriod_Type_ID))
                {
                    string spar_Atom_WorkPeriod_Type_ID = "@par_Atom_WorkPeriod_Type_ID";
                    SQL_Parameter par_Atom_WorkPeriod_Type_ID = new SQL_Parameter(spar_Atom_WorkPeriod_Type_ID, false, Atom_WorkPeriod_Type_ID);
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
                if (ID.Validate(Atom_myOrganisation_Person_ID))
                {
                    string spar_Atom_myOrganisation_Person_ID = "@par_Atom_myOrganisation_Person_ID";
                    SQL_Parameter par_Atom_myOrganisation_Person_ID = new SQL_Parameter(spar_Atom_myOrganisation_Person_ID, false, Atom_myOrganisation_Person_ID);
                    lpar.Add(par_Atom_myOrganisation_Person_ID);
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID = " + spar_Atom_myOrganisation_Person_ID;
                    sval_Atom_myOrganisation_Person_ID = spar_Atom_myOrganisation_Person_ID;
                }
                else
                {
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID is null";
                    sval_Atom_myOrganisation_Person_ID = "null";
                }



                string scond_Atom_ElectronicDevice_ID = null;
                string sval_Atom_ElectronicDevice_ID = "null";
                if (ID.Validate(Atom_ElectronicDevice_ID))
                {
                    string spar_Atom_ElectronicDevice_ID = "@par_Atom_ElectronicDevice_Temp_ID";
                    SQL_Parameter par_Atom_ElectronicDevice_ID = new SQL_Parameter(spar_Atom_ElectronicDevice_ID, false, Atom_ElectronicDevice_ID);
                    lpar.Add(par_Atom_ElectronicDevice_ID);
                    scond_Atom_ElectronicDevice_ID = "Atom_ElectronicDevice_Temp_ID = " + spar_Atom_ElectronicDevice_ID;
                    sval_Atom_ElectronicDevice_ID = spar_Atom_ElectronicDevice_ID;
                }
                else
                {
                    scond_Atom_ElectronicDevice_ID = "Atom_ElectronicDevice_Temp_ID is null";
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

                string    sql = @"insert into Atom_WorkPeriod_Temp (ID,
                                                               Atom_WorkPeriod_TYPE_ID,
                                                               Atom_myOrganisation_Person_ID,
                                                               Atom_ElectronicDevice_Temp_ID,
                                                               LoginTime,
                                                               LogoutTime) values ("
                                                                + sval_Atom_WorkPeriod_ID + ","
                                                                + sval_Atom_WorkPeriod_Type_ID + ","
                                                                + sval_Atom_myOrganisation_Person_ID + ","
                                                                + sval_Atom_ElectronicDevice_ID + ","
                                                                + sval_Login_time + ","
                                                                + sval_Logout_time +
                                                                ")";
                ID xAtom_WorkPeriod_ID = null;
                if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref xAtom_WorkPeriod_ID, ref Err, "Atom_WorkPeriod"))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:Insert_into_Atom_WorkPeriod_Temp:" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Get(ID xAtom_WorkPeriod_ID, ref string xElectronicDeviceName, ref string xAtomOfficeShortName)
        {
            xElectronicDeviceName = null;
            xAtomOfficeShortName = null;
            string sql = @"select  aed.Name as Atom_ElectronicDevice_Name,
	                        ao.ShortName as Atom_Office_ShortName 
	                       from Atom_WorkPeriod awp
                        inner join Atom_ElectronicDevice aed on awp.Atom_ElectronicDevice_ID = aed.ID
                        inner join Atom_Office ao on aed.Atom_Office_ID = ao.ID 
                        where awp.ID = " + xAtom_WorkPeriod_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                int iCount = dt.Rows.Count;
                if (iCount > 0)
                {
                    xElectronicDeviceName = tf._set_string(dt.Rows[0]["Atom_ElectronicDevice_Name"]);
                    xAtomOfficeShortName = tf._set_string(dt.Rows[0]["Atom_Office_ShortName"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:Get:" + sql + "\r\n:Err=" + Err);
                return false;
            }
        }

        public static bool Get_Temp(ID xAtom_WorkPeriod_ID, ref string xElectronicDeviceName, ref string xAtomOfficeShortName)
        {
            xElectronicDeviceName = null;
            xAtomOfficeShortName = null;
            string sql = @"select  aed.Name as Atom_ElectronicDevice_Name,
	                        ao.ShortName as Atom_Office_ShortName 
	                       from Atom_WorkPeriod awp
                        inner join Atom_ElectronicDevice_Temp aedt on awp.Atom_ElectronicDevice_Temp_ID = aedt.ID
                        inner join Atom_Office ao on aedt.Atom_Office_ID = ao.ID 
                        where awp.ID = " + xAtom_WorkPeriod_ID.ToString();
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                int iCount = dt.Rows.Count;
                if (iCount > 0)
                {
                    xElectronicDeviceName = tf._set_string(dt.Rows[0]["Atom_ElectronicDevice_Name"]);
                    xAtomOfficeShortName = tf._set_string(dt.Rows[0]["Atom_Office_ShortName"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:Get:" + sql + "\r\n:Err=" + Err);
                return false;
            }
        }
        public static bool GetOld(string Atom_WorkPeriod_Type_Name,
                                 string Atom_WorkPeriod_Type_Description,
                                 ID Atom_myOrganisation_Person_ID,
                                 ID Atom_Computer_ID,
                                 DateTime Login_time,
                                 DBTypes.DateTime_v Logout_time_v,
                                 ref ID Atom_WorkPeriod_ID,
                                 Transaction transaction)
        {

            ID Atom_WorkPeriod_Type_ID = null;
            if (f_Atom_WorkPeriod_Type.Get(Atom_WorkPeriod_Type_Name, Atom_WorkPeriod_Type_Description, ref Atom_WorkPeriod_Type_ID, transaction))
            {
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                string scond_Atom_WorkPeriod_Type_ID = null;
                string sval_Atom_WorkPeriod_Type_ID = "null";
                if (ID.Validate(Atom_WorkPeriod_Type_ID))
                {
                    string spar_Atom_WorkPeriod_Type_ID = "@par_Atom_WorkPeriod_Type_ID";
                    SQL_Parameter par_Atom_WorkPeriod_Type_ID = new SQL_Parameter(spar_Atom_WorkPeriod_Type_ID,  false, Atom_WorkPeriod_Type_ID);
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
                if (ID.Validate(Atom_myOrganisation_Person_ID))
                {
                    string spar_Atom_myOrganisation_Person_ID = "@par_Atom_myOrganisation_Person_ID";
                    SQL_Parameter par_Atom_myOrganisation_Person_ID = new SQL_Parameter(spar_Atom_myOrganisation_Person_ID, false, Atom_myOrganisation_Person_ID);
                    lpar.Add(par_Atom_myOrganisation_Person_ID);
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID = " + spar_Atom_myOrganisation_Person_ID;
                    sval_Atom_myOrganisation_Person_ID = spar_Atom_myOrganisation_Person_ID;
                }
                else
                {
                    scond_Atom_myOrganisation_Person_ID = "Atom_myOrganisation_Person_ID is null";
                    sval_Atom_myOrganisation_Person_ID = "null";
                }

                string scond_Atom_Computer_ID = null;
                string sval_Atom_Computer_ID = "null";
                if (ID.Validate(Atom_Computer_ID))
                {
                    string spar_Atom_Computer_ID = "@par_Atom_Computer_ID";
                    SQL_Parameter par_Atom_Computer_ID = new SQL_Parameter(spar_Atom_Computer_ID,  false, Atom_Computer_ID);
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
                                            + ") and (" + scond_Atom_Computer_ID
                                            + ") and (" + scond_Login_time
                                            + ") and (" + scond_Logout_time + ")";

                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_WorkPeriod_ID==null)
                        {
                            Atom_WorkPeriod_ID = new ID();
                        }
                        Atom_WorkPeriod_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        sql = @"insert into Atom_WorkPeriod (Atom_WorkPeriod_TYPE_ID,
                                                               Atom_myOrganisation_Person_ID,
                                                               Atom_Computer_ID,
                                                               LoginTime,
                                                               LogoutTime) values ("
                                                                + sval_Atom_WorkPeriod_Type_ID + ","
                                                                + sval_Atom_myOrganisation_Person_ID + ","
                                                                + sval_Atom_Computer_ID + ","
                                                                + sval_Login_time + ","
                                                                + sval_Logout_time +
                                                                ")";
                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_WorkPeriod_ID,  ref Err, "Atom_WorkPeriod"))
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

        public static bool End(ID Atom_WorkPeriod_ID, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            DateTime dtWorkPeriodEnd = DateTime.Now;
            string spar_WorkPeriodEnd = "@par_WorkPeriodEnd";
            SQL_Parameter par_PeriodEnd = new SQL_Parameter(spar_WorkPeriodEnd,SQL_Parameter.eSQL_Parameter.Datetime,false,dtWorkPeriodEnd);
            lpar.Add(par_PeriodEnd);


            string sql = "update Atom_WorkPeriod set LogoutTime = " + spar_WorkPeriodEnd + " where ID = " + Atom_WorkPeriod_ID.ToString();
            string Err = null;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql,lpar,ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:End:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool End(ID xAtom_WorkPeriod_ID, ID JOURNAL_Atom_WorkPeriod_TYPE_ID, Transaction transaction)
        {
            if (End(xAtom_WorkPeriod_ID,transaction))
            {
                ID xJOURNAL_Atom_WorkPeriod = null;
                DateTime dtnow = DateTime.Now;
                f_JOURNAL_Atom_WorkPeriod.Get(
                    f_JOURNAL_Atom_WorkPeriod_TYPE.JOURNAL_Atom_WorkPeriod_TYPE_ID_WorkPeriodNotClosedInPreviousSession,
                    xAtom_WorkPeriod_ID,
                    dtnow,
                    ref xJOURNAL_Atom_WorkPeriod,
                    transaction);
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkPeriod:End failed !");
                return false;
            }
        }
    }
}
