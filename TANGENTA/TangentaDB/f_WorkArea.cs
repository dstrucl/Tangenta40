using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_WorkArea
    {
        public static bool Read_WorkArea_VIEW(ref DataTable dt, string where_condition, List<SQL_Parameter> lpar)
        {
            string err = null;
            if (where_condition == null)
            {
                where_condition = " where WorkArea.Active = 1 ";
            }
            string sql = @"
                            SELECT 
                            WorkArea.Name AS WorkArea_$$Name,
                            WorkArea.Description AS WorkArea_$$Description,
                            WorkArea.Active AS WorkArea_$$Active,
                            WorkArea_$_wai.Image_Data AS WorkArea_$_wai_$$Image_Data,
                            WorkArea_$_wai.Image_Hash AS WorkArea_$_wai_$$Image_Hash,
                            WorkArea_$_wai.Description AS WorkArea_$_wai_$$Description,
                            s1.Name as s1_name,
                            s2.Name as s2_name,
                            s3.Name as s3_name
                            FROM WorkArea 
                            LEFT JOIN WorkAreaImage WorkArea_$_wai ON WorkArea.WorkAreaImage_ID = WorkArea_$_wai.ID 
                            LEFT JOIN WorkArea_ParentGroup1 s1 ON WorkArea.WorkArea_ParentGroup1_ID = s1.ID 
                            LEFT JOIN WorkArea_ParentGroup2 s2 ON s1.WorkArea_ParentGroup2_ID = s2.ID 
                            LEFT JOIN WorkArea_ParentGroup3 s3 ON s2.WorkArea_ParentGroup3_ID = s3.ID " 
                            + where_condition;
            if (dt == null)
            {
                dt = new DataTable();
            }
            else
            {
                dt.Clear();
                dt.Columns.Clear();
            }
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:f_WorkArea:Read_WorkArea_VIEW:sql=" + sql + "\r\nErr=" + err);
                return false;
            }

        }


        public static bool GetGroupsTable(ref DataTable dtWorkAreaGroup)
        {
            string sql = @"select 
              s1.Name as s1_name,
              s2.Name as s2_name,
              s3.Name as s3_name
              FROM WorkArea 
              LEFT JOIN WorkArea_ParentGroup1 s1 ON WorkArea.WorkArea_ParentGroup1_ID = s1.ID
              LEFT JOIN WorkArea_ParentGroup2 s2 ON s1.WorkArea_ParentGroup2_ID = s2.ID
              LEFT JOIN WorkArea_ParentGroup3 s3 ON s2.WorkArea_ParentGroup3_ID = s3.ID
		      group by s1.Name,s2.Name,s3.Name";
            if (dtWorkAreaGroup == null)
            {
                dtWorkAreaGroup = new DataTable();
            }
            else
            {
                dtWorkAreaGroup.Clear();
                dtWorkAreaGroup.Rows.Clear();
                dtWorkAreaGroup.Columns.Clear();
            }
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtWorkAreaGroup, sql, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:f_WorkArea:GetGroupsTable:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool GetWorkAreas(ref DataTable xdtWorkAreaAll, ref int xcount)
        {

            xcount = 0;
            if (xdtWorkAreaAll != null)
            {
                xdtWorkAreaAll.Dispose();
                xdtWorkAreaAll = null;
            }
            xdtWorkAreaAll = new DataTable();
            if (f_WorkArea.Read_WorkArea_VIEW(ref xdtWorkAreaAll, null, null))
            {
                xcount = xdtWorkAreaAll.Rows.Count;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
