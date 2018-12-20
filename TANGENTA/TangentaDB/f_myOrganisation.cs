using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_myOrganisation
    {
        public static bool Get(ID OrganisationData_ID, ref ID myOrganisation_ID, Transaction transaction)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = "select ID,OrganisationData_ID from myOrganisation";
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (myOrganisation_ID==null)
                    {
                        myOrganisation_ID = new ID();
                    }
                    myOrganisation_ID.Set(dt.Rows[0]["ID"]);
                    if (OrganisationData_ID.Equals(new ID(dt.Rows[0]["OrganisationData_ID"])))
                    {
                        return true;
                    }
                    else
                    {
                        sql = "update myOrganisation set OrganisationData_ID = " + OrganisationData_ID.ToString() + " where ID = " + myOrganisation_ID.ToString();
                        if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_myOrganisation:Get: sql = " + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {

                    sql = "insert into myOrganisation (OrganisationData_ID)values(" + OrganisationData_ID.ToString() + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref myOrganisation_ID,  ref Err, "myOrganisation"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_myOrganisation:Get: sql = " + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_myOrganisation:Get: sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool DeleteAll(Transaction transaction)
        {
           return  fs.DeleteAll("myOrganisation", transaction);
        }
    }
}
