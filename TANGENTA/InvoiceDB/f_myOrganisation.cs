using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class f_myOrganisation
    {
        public static bool Get(long OrganisationData_ID, ref long myOrganisation_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = "select ID,OrganisationData_ID from myOrganisation";
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    myOrganisation_ID = (long)dt.Rows[0]["ID"];
                    if (OrganisationData_ID == (long)dt.Rows[0]["OrganisationData_ID"])
                    {
                        return true;
                    }
                    else
                    {
                        sql = "update myOrganisation set OrganisationData_ID = " + OrganisationData_ID.ToString() + " where ID = " + myOrganisation_ID.ToString();
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
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
                    object oret = null;

                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref myOrganisation_ID, ref oret, ref Err, "myOrganisation"))
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
    }
}
