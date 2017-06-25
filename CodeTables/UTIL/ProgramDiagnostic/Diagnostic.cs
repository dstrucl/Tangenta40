using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProgramDiagnostic
{
    public static class Diagnostic
    {
        public static DataTable dt_Diagnostic = new DataTable();
        public static bool bRun = false;
        public static bool Enabled = false;
        public static void Init()
        {
            if (Enabled)
            {
                dt_Diagnostic.Clear();
                dt_Diagnostic.Columns.Clear();
                dt_Diagnostic.Columns.Add("Name", typeof(string));
                dt_Diagnostic.Columns.Add("Time", typeof(DateTime));
                dt_Diagnostic.Columns.Add("Elapsed in mili seconds", typeof(decimal));
                dt_Diagnostic.Columns.Add("Param", typeof(string));
                bRun = true;
            }
        }
        public static void Meassure(string Name,string Param)
        {
            if (Enabled)
            {
                if (!bRun)
                {
                    Init();
                }
                if (bRun)
                {
                    DataRow dr = dt_Diagnostic.NewRow();
                    dr[0] = Name;
                    dr[1] = DateTime.Now;
                    if (Param != null)
                    {
                        dr[3] = Param;
                    }
                    dt_Diagnostic.Rows.Add(dr);
                }
            }
        }
        public static void ShowResults()
        {
            if (Enabled)
            {
                Results_Form resfrm = new Results_Form(dt_Diagnostic);
                resfrm.ShowDialog();
            }
        }

        public static void Clear()
        {
            dt_Diagnostic.Rows.Clear();
        }
    }
}
