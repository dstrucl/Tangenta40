using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace TangentaSampleDB
{
    public static class TangentaSampleDB
    {
        public static SampleDB sbd = null;
        public static Icon oIcon = null;
        public static bool Init_Sample_DB(ref bool bCanceled, SampleDB xsbd, NavigationButtons.Navigation xnav, Icon xoIcon, ref string Err)
        {
            oIcon = xoIcon;
            if (xnav.LastStartupDialog_TYPE.Equals("Tangenta.Form_Select_DefaultCurrency"))
            {
                sbd = xsbd;
                if (sbd.ShowDialog(ref bCanceled, xnav, oIcon))
                {
                    if (bCanceled)
                    {
                        return true;
                    }
                    bool bRes = sbd.Write();
                    return bRes;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (fs.Init_Default_DB(ref Err))
                {
                    sbd = xsbd;
                    if (sbd.ShowDialog(ref bCanceled, xnav, oIcon))
                    {
                        if (bCanceled)
                        {
                            return true;
                        }
                        bool bRes = sbd.Write();
                        return bRes;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show(Err);
                    return false;
                }
            }
        }

        public static bool Is_Sample_DB(ref string Err)
        {
            Err = null;
            string sql = null;
            if (DBSync.DBSync.m_DBType == DBConnectionControl40.DBConnection.eDBType.MSSQL)
            {
                sql = @"select top 1 myOrganisation_$_orgd_$_org_$$Name from  myOrganisation_VIEW";
            }
            else
            {
                sql = @"select myOrganisation_$_orgd_$_org_$$Name from  myOrganisation_VIEW limit 1";
            }
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    string sOrgName = (string)dt.Rows[0]["myOrganisation_$_orgd_$_org_$$Name"];
                    if (sOrgName.Equals(lngRPMS.s_MyOrg_Name_v.s))
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
