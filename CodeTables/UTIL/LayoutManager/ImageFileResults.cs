using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayoutManager
{
    public static class ImageFileResults
    {
        public enum eResult {SAVED,EXIST};

        public static DataTable dtImageFileFound = null;
        private static Form_ViewImageFileResults frmvImageFileResults = null;

        public static void Init()
        {
            if (dtImageFileFound!=null)
            {
                dtImageFileFound.Dispose();
                dtImageFileFound = null;
            }
            dtImageFileFound = new DataTable();
            DataColumn dcol_ControlUniqueName = new DataColumn("ControlUniqueName", typeof(string));
            DataColumn dcol_ImageFile = new DataColumn("ImageFile", typeof(string));
            DataColumn dcol_SavedFirstTime = new DataColumn("SavedFirstTime", typeof(DateTime));
            DataColumn dcol_Found = new DataColumn("Found", typeof(int));
            DataColumn dcol_Comment = new DataColumn("Comment", typeof(string));
            dtImageFileFound.Columns.Add(dcol_ControlUniqueName);
            dtImageFileFound.Columns.Add(dcol_ImageFile);
            dtImageFileFound.Columns.Add(dcol_SavedFirstTime);
            dtImageFileFound.Columns.Add(dcol_Found);
            dtImageFileFound.Columns.Add(dcol_Comment);
        }

        public static void Add(string xControlUniqueName,string ImageFile, eResult result)
        {
            if (result == eResult.SAVED)
            {
                DataRow dr = dtImageFileFound.NewRow();
                dr["ControlUniqueName"] = xControlUniqueName;
                dr["ImageFile"] = ImageFile;
                dr["SavedFirstTime"] = DateTime.Now;
                dr["Found"] = 0;
                dr["Comment"] = "Saved";
                dtImageFileFound.Rows.Add(dr);
            }
            else
            {
                int idx_file_found = Find(ImageFile);
                if (idx_file_found >= 0)
                {
                    int ic = (int)dtImageFileFound.Rows[idx_file_found]["Found"];
                    ic++;
                    dtImageFileFound.Rows[idx_file_found]["Found"] = ic;
                    dtImageFileFound.Rows[idx_file_found]["Comment"] = "Found many times";
                }
                else
                {
                    DataRow dr = dtImageFileFound.NewRow();
                    dr["ControlUniqueName"] = xControlUniqueName;
                    dr["ImageFile"] = ImageFile;
                    dr["SavedFirstTime"] = DateTime.Now;
                    dr["Found"] = 0;
                    dr["Comment"] = "ERROR:was saved but not found !";
                    dtImageFileFound.Rows.Add(dr);
                }
            }
        }

        private static int Find(string imageFile)
        {
            int iCount = dtImageFileFound.Rows.Count;
            for (int i=0;i<iCount;i++)
            {
                if (imageFile.Equals((string)dtImageFileFound.Rows[i]["ImageFile"]))
                {
                    return i;
                }
            }
            return -1;

        }

        public static void ShowImageFileResults(Form pOwner)
        {
            if (frmvImageFileResults != null)
            {
                if (frmvImageFileResults.IsDisposed)
                {
                    frmvImageFileResults = null;
                }
            }
            if (frmvImageFileResults == null)
            {
                frmvImageFileResults = new Form_ViewImageFileResults(dtImageFileFound);
                frmvImageFileResults.Owner = pOwner;
            }
            frmvImageFileResults.Show();
        }

        public static void CloseImageFileResults()
        {
            if (frmvImageFileResults != null)
            {
                if (frmvImageFileResults.IsDisposed)
                {
                    frmvImageFileResults = null;
                }
            }
            if (frmvImageFileResults != null)
            {
                frmvImageFileResults.Close();
                frmvImageFileResults.Dispose();
                frmvImageFileResults = null;
            }
        }

    }
}
