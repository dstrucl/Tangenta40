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
    public static class f_Current_Doc_ID
    {
        public static bool GetLast(
                              string doctype,
                              string xDBSource,
                              ID xmyOrganisation_Person_ID,
                              ID xElectronicDevice_ID,
                              ref ID xDoc_ID,
                              ref ID xCurrent_Doc_ID)
        {

            xDoc_ID = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_DBSource = null;
            string sval_DBSource = "null";
            if (xDBSource!=null)
            {
                string spar_DBSource = "@par_DBSource";
                SQL_Parameter par_DBSource = new SQL_Parameter(spar_DBSource,SQL_Parameter.eSQL_Parameter.Nvarchar, false, xDBSource);
                lpar.Add(par_DBSource);
                scond_DBSource = "DBSource = " + spar_DBSource;
                sval_DBSource = spar_DBSource;
            }
            else
            {
                scond_DBSource = "DBSource is null";
                sval_DBSource = "null";
            }

            string scond_myOrganisation_Person_ID = null;
            string sval_myOrganisation_Person_ID = "null";
            if (ID.Validate(xmyOrganisation_Person_ID))
            {
                string spar_myOrganisation_Person_ID = "@par_myOrganisation_Person_ID";
                SQL_Parameter par_myOrganisation_Person_ID = new SQL_Parameter(spar_myOrganisation_Person_ID, false, xmyOrganisation_Person_ID);
                lpar.Add(par_myOrganisation_Person_ID);
                scond_myOrganisation_Person_ID = "myOrganisation_Person_ID = " + spar_myOrganisation_Person_ID;
                sval_myOrganisation_Person_ID = spar_myOrganisation_Person_ID;
            }
            else
            {
                scond_myOrganisation_Person_ID = "myOrganisation_Person_ID is null";
                sval_myOrganisation_Person_ID = "null";
            }



            string scond_ElectronicDevice_ID = null;
            string sval_ElectronicDevice_ID = "null";
            if (ID.Validate(xElectronicDevice_ID))
            {
                string spar_ElectronicDevice_ID = "@par_ElectronicDevice_ID";
                SQL_Parameter par_ElectronicDevice_ID = new SQL_Parameter(spar_ElectronicDevice_ID, false, xElectronicDevice_ID);
                lpar.Add(par_ElectronicDevice_ID);
                scond_ElectronicDevice_ID = "ElectronicDevice_ID = " + spar_ElectronicDevice_ID;
                sval_ElectronicDevice_ID = spar_ElectronicDevice_ID;
            }
            else
            {
                scond_ElectronicDevice_ID = "ElectronicDevice_ID is null";
                sval_ElectronicDevice_ID = "null";
            }

     

            string sql = @"select ID," + doctype + "_ID from Current_" + doctype + @"_ID
                                        where (" + scond_DBSource
                                        + ") and (" + scond_myOrganisation_Person_ID
                                        + ") and (" + scond_ElectronicDevice_ID
                                        + ")";

            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    xCurrent_Doc_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    xDoc_ID = tf.set_ID(dt.Rows[0][doctype + "_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Current_Doc_ID:GetLast:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool SetLast(
                             string doctype,
                             ID xDoc_ID,
                             string xDBSource,
                             ID xmyOrganisation_Person_ID,
                             ID xElectronicDevice_ID,
                             ref ID xLast_Current_Doc_ID)
        {

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_DBSource = null;
            string sval_DBSource = "null";
            if (xDBSource != null)
            {
                string spar_DBSource = "@par_DBSource";
                SQL_Parameter par_DBSource = new SQL_Parameter(spar_DBSource, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xDBSource);
                lpar.Add(par_DBSource);
                scond_DBSource = "DBSource = " + spar_DBSource;
                sval_DBSource = spar_DBSource;
            }
            else
            {
                scond_DBSource = "DBSource is null";
                sval_DBSource = "null";
            }

            string scond_Doc_ID = null;
            string sval_Doc_ID = "null";
            if (ID.Validate(xDoc_ID))
            {
                string spar_Doc_ID = "@par_"+doctype+"_ID";
                SQL_Parameter par_Doc_ID = new SQL_Parameter(spar_Doc_ID, false, xDoc_ID);
                lpar.Add(par_Doc_ID);
                scond_Doc_ID = doctype+"_ID = " + spar_Doc_ID;
                sval_Doc_ID = spar_Doc_ID;
            }
            else
            {
                scond_Doc_ID = doctype+" is null";
                sval_Doc_ID = "null";
            }

            string scond_myOrganisation_Person_ID = null;
            string sval_myOrganisation_Person_ID = "null";
            if (ID.Validate(xmyOrganisation_Person_ID))
            {
                string spar_myOrganisation_Person_ID = "@par_myOrganisation_Person_ID";
                SQL_Parameter par_myOrganisation_Person_ID = new SQL_Parameter(spar_myOrganisation_Person_ID, false, xmyOrganisation_Person_ID);
                lpar.Add(par_myOrganisation_Person_ID);
                scond_myOrganisation_Person_ID = "myOrganisation_Person_ID = " + spar_myOrganisation_Person_ID;
                sval_myOrganisation_Person_ID = spar_myOrganisation_Person_ID;
            }
            else
            {
                scond_myOrganisation_Person_ID = "myOrganisation_Person_ID is null";
                sval_myOrganisation_Person_ID = "null";
            }

            string scond_ElectronicDevice_ID = null;
            string sval_ElectronicDevice_ID = "null";
            if (ID.Validate(xElectronicDevice_ID))
            {
                string spar_ElectronicDevice_ID = "@par_ElectronicDevice_ID";
                SQL_Parameter par_ElectronicDevice_ID = new SQL_Parameter(spar_ElectronicDevice_ID, false, xElectronicDevice_ID);
                lpar.Add(par_ElectronicDevice_ID);
                scond_ElectronicDevice_ID = "ElectronicDevice_ID = " + spar_ElectronicDevice_ID;
                sval_ElectronicDevice_ID = spar_ElectronicDevice_ID;
            }
            else
            {
                scond_ElectronicDevice_ID = "ElectronicDevice_ID is null";
                sval_ElectronicDevice_ID = "null";
            }



            ID xLast_DocInnvoice_ID = null;

            string Err = null;

            if (GetLast(doctype,xDBSource,xmyOrganisation_Person_ID,xElectronicDevice_ID,ref xLast_DocInnvoice_ID, ref xLast_Current_Doc_ID))
            {
                if (ID.Validate(xLast_Current_Doc_ID))
                {

                    string scond_Current_Doc_ID = null;
                    string sval_Current_Doc_ID = "null";
                    if (ID.Validate(xLast_Current_Doc_ID))
                    {
                        string spar_Current_Doc_ID = "@par_Current_" + doctype + "_ID";
                        SQL_Parameter par_Current_Doc_ID = new SQL_Parameter(spar_Current_Doc_ID, false, xLast_Current_Doc_ID);
                        lpar.Add(par_Current_Doc_ID);
                        scond_Current_Doc_ID = "Current_" + doctype + "_ID = " + spar_Current_Doc_ID;
                        sval_Current_Doc_ID = spar_Current_Doc_ID;
                    }
                    else
                    {
                        scond_Current_Doc_ID = "Current_" + doctype + "_ID is null";
                        sval_Current_Doc_ID = "null";
                    }

                    string sql = @"update Current_" + doctype + "_ID set " + doctype + "_ID = " + sval_Doc_ID +
                                " where " + scond_Current_Doc_ID;

                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Current_Doc_ID:SetLast:" + sql + "\r\nErr=" + Err);
                        return false;
                    }

                }
                else
                {
                    // insert
                    string sql = @"insert into Current_" + doctype + @"_ID (
                                  DBSource,
                                  " + doctype + @"_ID,
                                  myOrganisation_Person_ID,
                                  ElectronicDevice_ID)
                                  values(" + sval_DBSource
                                  + "," + sval_Doc_ID
                                  + "," + sval_myOrganisation_Person_ID
                                  + "," + sval_ElectronicDevice_ID + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref xLast_Current_Doc_ID, ref Err, "Current_" + doctype + "_ID"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Current_Doc_ID:SetLast:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
