using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_OwnUseAddOn
    {

        public static bool Get(
                             ID OwnUse_ID,
                             ref ID OwnUseAddOn_ID)
        {

            if (OwnUse_ID == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_OwnUseAddOn:OwnUse_ID_v==null");
                return false;
            }

            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_OwnUse_ID = "@par_OwnUse_ID";
            SQL_Parameter par_OwnUse_ID = new SQL_Parameter(spar_OwnUse_ID, false, OwnUse_ID);
            lpar.Add(par_OwnUse_ID);
            string sql = "select ID from OwnUseAddOn where OwnUse_ID = " + spar_OwnUse_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, lpar,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    if (OwnUseAddOn_ID==null)
                    {
                        OwnUseAddOn_ID = new ID();
                    }
                    OwnUseAddOn_ID.Set(dt.Rows[0]["ID"]);
                }
                else
                {
                    OwnUseAddOn_ID = null;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_OwnUseAddOn:Get: sql= " + sql + "\r\nErr=" + Err);
            }
            return false;
        }
    }
}