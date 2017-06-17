using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBTypes;

namespace TangentaDB
{
    public class doc_page_type_definitions
    {
        public class doc_page_type
        {
            public long ID = -1;
            public string Name = null;
            public string Description = null;
            public decimal Width = 0;
            public decimal Height = 0;
            public doc_page_type(string Page_Type_Name, string Page_Type_Description, decimal xWidth, decimal xHeight)
            {
                Name = Page_Type_Name;
                Description = Page_Type_Description;
                Width = xWidth;
                Height = xHeight;
            }
        }

        public doc_page_type A4_Portrait_description = null;
        public doc_page_type A4_Landscape_description = null;
        public doc_page_type Roll_80_mm = null;
        public doc_page_type Roll_58_mm = null;



        public List<doc_page_type> doc_page_type_list = new List<doc_page_type>();

        public long_v HTML_doc_page_type_A4_Portrait_ID_v
        {
            get
            {
                return new long_v(doc_page_type_list[0].ID);
            }
        }
        public long_v HTML_doc_page_type_A4_Landscape_ID_v 
        {
            get
            {
                return new long_v(doc_page_type_list[1].ID);
            }
        }

        public long_v HTML_doc_page_type_Roll_80_mm_ID_v
        {
            get
            {
                return new long_v(doc_page_type_list[2].ID);
            }
        }

        public long_v HTML_doc_page_type_Roll_58_mm_ID_v
        {
            get
            {
                return new long_v(doc_page_type_list[3].ID);
            }
        }

        public doc_page_type_definitions()
        {

            //Proforma Invoice
            A4_Portrait_description = new doc_page_type("A4 Portrait", lngRPM.s_A4_Portrait_description.s,210,297); 
            A4_Landscape_description = new doc_page_type("A4 Landscape", lngRPM.s_A4_Portrait_description.s, 297,210 );
            Roll_80_mm = new doc_page_type("Roll paper 80mm", lngRPM.s_A4_Portrait_description.s, 80,-1);
            Roll_58_mm = new doc_page_type("Roll paper 58mm", lngRPM.s_A4_Portrait_description.s, 58,-1);

            doc_page_type_list.Add(A4_Portrait_description);
            doc_page_type_list.Add(A4_Landscape_description);
            doc_page_type_list.Add(Roll_80_mm);
            doc_page_type_list.Add(Roll_58_mm);

        }


        public  bool Read()
        {
            string Err = null;
            string sql = "select ID,Name, Description,Width,Height from doc_page_type";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {

                foreach (doc_page_type dpt in doc_page_type_list)
                {
                    if (Get(dpt, dt))
                    {
                        continue;
                    }
                    else
                    {
                        Set(dpt);
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc_page_type:Read:Err=" + Err);
                return false;
            }
        }

        private bool Get(doc_page_type dpt, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Name"] is string)
                {
                    string sName = (string)dr["Name"];
                    if (dpt.Name.Equals(sName))
                    {
                        dpt.ID = (long)dr["ID"];
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Set(doc_page_type dpt)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, dpt.Name);
            string sval_Name = spar_Name;
            lpar.Add(par_Name);

            string sval_Description = "null";
            if (dpt.Description != null)
            {
                if (dpt.Description.Length > 0)
                {
                    string spar_Description = "@par_Description";
                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, dpt.Description);
                    sval_Description = spar_Description;
                    lpar.Add(par_Description);
                }
            }

            string spar_Width = "@par_Width";
            SQL_Parameter par_Width = new SQL_Parameter(spar_Width, SQL_Parameter.eSQL_Parameter.Decimal, false, dpt.Width);
            string sval_Width = spar_Width;
            lpar.Add(par_Width);

            string spar_Height = "@par_Height";
            SQL_Parameter par_Height = new SQL_Parameter(spar_Height, SQL_Parameter.eSQL_Parameter.Decimal, false, dpt.Height);
            string sval_Height = spar_Height;
            lpar.Add(par_Height);

            string sql = "insert into doc_page_type (Name,Description,Width,Height) values (" + sval_Name + "," + sval_Description + "," + sval_Width + "," + sval_Height+ ")";
            long dpt_id = -1;
            object oret = null;
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref dpt_id, ref oret, ref Err, "doc_page_type"))
            {
                dpt.ID = dpt_id;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc_page_type:Set:Err= " + Err);
                return false;
            }
        }
    }
}
