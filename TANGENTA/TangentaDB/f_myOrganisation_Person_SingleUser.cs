﻿using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_myOrganisation_Person_SingleUser
    {
        public static bool Get(ID Office_ID, ID myOrganisation_Person_ID, ref ID myOrganisation_Person_SingleUser_ID, Transaction transaction)
        {
            string Err = null;
            string sql = null;

            if (ID.Validate(Office_ID))
            {
                ID xElectronicDevice_ID = null;
                ID xAtom_Computer_ID = null;
                if (f_ElectronicDevice.Get(Office_ID, ref xElectronicDevice_ID, ref xAtom_Computer_ID, transaction))
                {
                    if (ID.Validate(xElectronicDevice_ID))
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        string scond_myOrganisation_Person_ID = null;
                        string sval_myOrganisation_Person_ID = "null";
                        if (ID.Validate(myOrganisation_Person_ID))
                        {
                            string spar_myOrganisation_Person_ID = "@par_myOrganisation_Person_ID";
                            SQL_Parameter par_myOrganisation_Person_ID = new SQL_Parameter(spar_myOrganisation_Person_ID, false, myOrganisation_Person_ID);
                            lpar.Add(par_myOrganisation_Person_ID);
                            scond_myOrganisation_Person_ID = "myOrganisation_Person_ID = " + spar_myOrganisation_Person_ID;
                            sval_myOrganisation_Person_ID = spar_myOrganisation_Person_ID;
                        }
                        else
                        {
                            scond_myOrganisation_Person_ID = "myOrganisation_Person_ID is null";
                            sval_myOrganisation_Person_ID = "null";
                        }

                        string scond_x_ElectronicDevice_ID = null;
                        string sval_x_ElectronicDevice_ID = "null";
                        if (ID.Validate(xElectronicDevice_ID))
                        {
                            string spar_xAtom_ElectronicDevice_ID = "@par_ElectronicDevice_ID";
                            SQL_Parameter par_xAtom_ElectronicDevice_ID = new SQL_Parameter(spar_xAtom_ElectronicDevice_ID, false, xElectronicDevice_ID);
                            lpar.Add(par_xAtom_ElectronicDevice_ID);
                            scond_x_ElectronicDevice_ID = "ElectronicDevice_ID = " + spar_xAtom_ElectronicDevice_ID;
                            sval_x_ElectronicDevice_ID = spar_xAtom_ElectronicDevice_ID;
                        }
                        else
                        {
                            scond_x_ElectronicDevice_ID = "ElectronicDevice_ID is null";
                            sval_x_ElectronicDevice_ID = "null";
                        }

                        DataTable dt = new DataTable();
                        dt.Columns.Clear();
                        dt.Clear();
                        sql = @"select ID from myOrganisation_Person_SingleUser where " + scond_myOrganisation_Person_ID + " and " + scond_x_ElectronicDevice_ID;
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (myOrganisation_Person_SingleUser_ID == null)
                                {
                                    myOrganisation_Person_SingleUser_ID = new ID();
                                }
                                myOrganisation_Person_SingleUser_ID.Set(dt.Rows[0]["ID"]);
                                return true;
                            }
                            else
                            {
                                if (!transaction.Get(DBSync.DBSync.Con))
                                {
                                    return false;
                                }
                                sql = @"insert into myOrganisation_Person_SingleUser (myOrganisation_Person_ID,ElectronicDevice_ID) values (" + sval_myOrganisation_Person_ID + "," + sval_x_ElectronicDevice_ID + ")";
                                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref myOrganisation_Person_SingleUser_ID, ref Err, "myOrganisation_Person_SingleUser"))
                                {
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:f_myOrganisation_Person_SingleUser:Get:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_myOrganisation_Person_SingleUser:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_myOrganisation_Person_SingleUser:Get:xAtom_ElectronicDevice_ID is not valid");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_myOrganisation_Person_SingleUser:Get:Electronic device not found!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_myOrganisation_Person_SingleUser:Get:Office_ID is not valid");
                return false;
            }
        }
    }
}
