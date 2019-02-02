using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutManager
{
    public static class BookmarkDic
    {
        private static DataTable dic = null;
        private static DataColumn dcol_ControlUniqueName = null;
        private static DataColumn dcol_ID = null;
        private static string dicXMLfile = null;
        private static Form_ViewImageFileResults frmvbkdic = null;

        public static void Init(string xdicXMLfile)
        {
            dicXMLfile = xdicXMLfile;
            dcol_ControlUniqueName = new DataColumn("ControlUniqueName", typeof(string));
            dcol_ID = new DataColumn("ID", typeof(string));

            try
            {
                if (dic == null)
                {
                    dic = new DataTable();
                }
                else
                {
                    dic.Rows.Clear();
                    dic.Columns.Clear();
                    dic.Dispose();
                    dic = new DataTable();
                }
                dic.TableName = "BookmarkDic";
                dic.ReadXml(dicXMLfile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("WARNING:XML file \"" + dicXMLfile + "\" not loaded!\r\nException=" + ex.Message);
                dic.Columns.Clear();
                dic.Columns.Add(dcol_ControlUniqueName);
                dic.Columns.Add(dcol_ID);
            }
        }

        private static bool Find(string xControlUniqueName,ref string xID)
        {
            foreach(DataRow dr in dic.Rows)
            {
                string colname = dcol_ControlUniqueName.ColumnName;
                string controluniquename = (string)dr[colname];

                if (controluniquename.Equals(xControlUniqueName))
                {
                    colname = dcol_ID.ColumnName;
                    xID = (string)dr[colname]; 
                    return true;
                }
            }
            return false;
        }
        public static string GetBookmark(string xControlUniqueName)
        {
            string xID = null;
            if (Find(xControlUniqueName, ref xID))
            {
                return xID;
            }
            else
            {
                int iCount = dic.Rows.Count;
                DataRow dr = dic.NewRow();
                string colname = dcol_ControlUniqueName.ColumnName;
                dr[colname] = xControlUniqueName;
                string sID = "#b" + iCount.ToString();
                colname = dcol_ID.ColumnName;
                dr[colname] = sID;
                dic.Rows.Add(dr);
                SaveXML(dic);
                return sID;
            }
        }

        private static void SaveXML(DataTable dic)
        {
            try
            {
                dic.WriteXml(dicXMLfile, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR:XML file \"" + dicXMLfile + "\" not saved!\r\nException=" + ex.Message);
            }
        }

        public static void ShowBookmarkDic(Form pOwner)
        {
            if (frmvbkdic != null)
            {
                if (frmvbkdic.IsDisposed)
                {
                    frmvbkdic = null;
                }
            }
            if (frmvbkdic == null)
            {
                frmvbkdic = new Form_ViewImageFileResults(dic);
                frmvbkdic.Owner = pOwner;
            }
            frmvbkdic.Show();
        }

        public static void CloseBookmarkDic()
        {
            if (frmvbkdic != null)
            {
                if (frmvbkdic.IsDisposed)
                {
                    frmvbkdic = null;
                }
            }
            if (frmvbkdic != null)
            {
                frmvbkdic.Close();
                frmvbkdic.Dispose();
                frmvbkdic = null;
            }
        }
    }
}
