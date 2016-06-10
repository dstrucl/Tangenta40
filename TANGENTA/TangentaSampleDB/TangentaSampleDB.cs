using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace TangentaSampleDB
{
    public static class TangentaSampleDB
    {
        public static bool Init_Sample_DB(ref string Err)
        {
            if (fs.Init_Default_DB(ref Err))
            {
                SampleDB sbd = new SampleDB();
                bool bRes = sbd.Write();
                return bRes;
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        public static bool Is_Sample_DB(ref string Err)
        {
            Err = null;
            string sql = @"select myOrganisation_$_orgd_$_org_$$Name from  myOrganisation_VIEW limit 1";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    string sOrgName = (string)dt.Rows[0]["myOrganisation_$_orgd_$_org_$$Name"];
                    if (sOrgName.Equals(lngRPMS.s_MyOrg_Organisation_Name_v.s))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    Err = "ERROR:TangentaDB:fs:Is_Sample_DB:sql=" + sql + "\r\nErr= No data in myOrgainisation_VIEW!";
                    LogFile.Error.Show(Err);
                    return false;
                }
            }
            else
            {
                Err = "ERROR:TangentaDB:fs:Is_Sample_DB:sql=" + sql + "\r\nErr=" + Err;
                LogFile.Error.Show(Err);
                return false;
            }
        }
    }
}
