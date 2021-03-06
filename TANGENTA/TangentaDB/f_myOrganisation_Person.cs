﻿using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_myOrganisation_Person
    {
        public static bool Get(string_v Job_v,
                               bool_v Active_v,
                               string_v Description_v,
                               long_v Person_ID_v,
                               long_v Office_ID_v,
                               ref long_v myOrganisation_Person_v)
        {
            string Err = null;
            DataTable dt = new DataTable();
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string Job_cond = null;
            string Job_value = null;
            string spar_Job = "Job";
            fs.AddPar(spar_Job, ref lpar, Job_v, ref Job_cond, ref Job_value);

            string Active_cond = null;
            string Active_value = null;
            string spar_Active = "Active";
            fs.AddPar(spar_Active, ref lpar, Active_v, ref Active_cond, ref Active_value);

            string Description_cond = null;
            string Description_value = null;
            string spar_Description = "Description";
            fs.AddPar(spar_Description, ref lpar, Description_v, ref Description_cond, ref Description_value);

            string Person_ID_cond = null;
            string Person_ID_value = null;
            string spar_Person_ID = "Person_ID";
            fs.AddPar(spar_Person_ID, ref lpar, Person_ID_v, ref Person_ID_cond, ref Person_ID_value);

            string Office_ID_cond = null;
            string Office_ID_value = null;
            string spar_Office_ID = "Office_ID";
            fs.AddPar(spar_Office_ID, ref lpar, Office_ID_v, ref Office_ID_cond, ref Office_ID_value);

            string sql = "select ID from myOrganisation_Person where " + Job_cond + " and "
                                                                       + Active_cond + " and "
                                                                       + Description_cond + " and "
                                                                       + Person_ID_cond + " and "
                                                                       + Office_ID_cond;

 
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (myOrganisation_Person_v == null)
                    {
                        myOrganisation_Person_v = new long_v();
                    }
                    myOrganisation_Person_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = @"insert into myOrganisation_Person ( Job,
                                                                Active,
                                                                Description,
                                                                Person_ID,
                                                                Office_ID
                                                                ) values
                                                                ("
                                                            + Job_value + @",
                                                        " + Active_value + @",
                                                        " + Description_value + @",
                                                        " + Person_ID_value + @",
                                                        " + Office_ID_value + @")";
                    long myOrganisation_Person_ID = -1;
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref myOrganisation_Person_ID, ref oret, ref Err, "myOrganisation_Person"))
                    {
                        if (myOrganisation_Person_v == null)
                        {
                            myOrganisation_Person_v = new long_v();
                        }
                        myOrganisation_Person_v.v = myOrganisation_Person_ID;
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_myOrganisation_Person:Get: sql = " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_myOrganisation_Person:Get: sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool DeleteAll()
        {
            return fs.DeleteAll("myOrganisation_Person");
        }

        public static long First_ID()
        {
            string sql = null;
            switch (DBSync.DBSync.m_DBType)
            {
                case DBConnection.eDBType.SQLITE:
                    sql = "select ID from myOrganisation_Person order by ID asc limit 1";
                    break;
                case DBConnection.eDBType.MSSQL:
                    sql = "select top 1 ID from myOrganisation_Person order by ID asc";
                    break;

                default:
                    LogFile.Error.Show("ERROR:TangentaDB:f_myOrganisation_Person:First_ID:DBSync.DBSync.m_DBType = " + DBSync.DBSync.m_DBType.ToString() + " not implemented!");
                    return -1;
            }
            DataTable dt = new DataTable();
            string err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref err))
            {
                if (dt.Rows.Count>0)
                {
                    return (long)dt.Rows[0]["ID"];
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_myOrganisation_Person:First_ID:sql=" + sql + "\r\nErr="+err);
                return -1;
            }
        }
    }
}
