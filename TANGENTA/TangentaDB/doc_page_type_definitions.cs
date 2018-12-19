using DBConnectionControl40;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBTypes;
using System.Drawing.Printing;

namespace TangentaDB
{
    public class doc_page_type_definitions
    {
        public class doc_page_type
        {
            public ID ID = null;
            public string Name = null;
            public string Description = null;

            public decimal m_Width_in_mm = 0;
            public decimal m_Height_in_mm = 0;

            public decimal Width_in_mm
            {
                get {
                    return m_Width_in_mm;
                }
                set
                {
                    m_Width_in_mm = value;
                }
            }

            public decimal Height_in_mm
            {
                get
                {
                    return m_Height_in_mm;
                }
                set
                {
                    m_Height_in_mm = value;
                }
            }

            public decimal Width_in_inch
            {
                get { return Convert_mm_to_inch(Width_in_mm); }
                set { Width_in_mm = Convert_inch_to_mm(value); }
            }

            public decimal Height_in_inch
            {
                get { return Convert_mm_to_inch(Height_in_mm); }
                set { Height_in_mm = Convert_inch_to_mm(value); }
            }

            public static decimal Convert_mm_to_inch(decimal l_in_mm)
            {
                return l_in_mm * 0.03937007874m; 
            }

            public static decimal Convert_inch_to_mm(decimal l_in_inch)
            {
                return l_in_inch * 25.4m; 
            }

            public doc_page_type(string Page_Type_Name, string Page_Type_Description, decimal xWidth, decimal xHeight_in_mm)
            {
                Name = Page_Type_Name;
                Description = Page_Type_Description;
                Width_in_mm = xWidth;
                Height_in_mm = xHeight_in_mm;
            }
        }

        public doc_page_type A4_Portrait_description = null;
        public doc_page_type A4_Landscape_description = null;
        public doc_page_type Roll_80_mm = null;
        public doc_page_type Roll_58_mm = null;



        public List<doc_page_type> doc_page_type_list = new List<doc_page_type>();

        public ID HTML_doc_page_type_A4_Portrait_ID
        {
            get
            {
                return new ID(doc_page_type_list[0].ID);
            }
        }
        public ID HTML_doc_page_type_A4_Landscape_ID 
        {
            get
            {
                return new ID(doc_page_type_list[1].ID);
            }
        }

        public ID HTML_doc_page_type_Roll_80_mm_ID
        {
            get
            {
                return new ID(doc_page_type_list[2].ID);
            }
        }

        public ID HTML_doc_page_type_Roll_58_mm_ID
        {
            get
            {
                return new ID(doc_page_type_list[3].ID);
            }
        }

        public doc_page_type_definitions()
        {

            //Proforma Invoice
            A4_Portrait_description = new doc_page_type("A4 Portrait", lng.s_A4_Portrait_description.s,210,297); 
            A4_Landscape_description = new doc_page_type("A4 Landscape", lng.s_A4_Landscape_description.s, 297,210 );
            Roll_80_mm = new doc_page_type("Roll paper 80mm", lng.s_Roll_paper_80_mm_description.s, 80,-1);
            Roll_58_mm = new doc_page_type("Roll paper 58mm", lng.s_Roll_paper_58_mm_description.s, 58,-1);

            doc_page_type_list.Add(A4_Portrait_description);
            doc_page_type_list.Add(A4_Landscape_description);
            doc_page_type_list.Add(Roll_80_mm);
            doc_page_type_list.Add(Roll_58_mm);
        }

        public bool FindMatching_page_type(string unit, decimal width, decimal tolerance, ref ID doc_page_type_ID)
        {
            decimal width_in_mm = 0;
            decimal tolerance_in_mm = 0;
            foreach (doc_page_type dpt in doc_page_type_list)
            {
                if (unit.ToLower().Equals("mm"))
                {
                    width_in_mm = width;
                    tolerance_in_mm = tolerance;
                }
                else if (unit.ToLower().Equals("inch"))
                {
                    width_in_mm = doc_page_type.Convert_inch_to_mm(width);
                    tolerance_in_mm = doc_page_type.Convert_inch_to_mm(tolerance);
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:doc_page_type_definitions:FindMatching_page_type: parameter unit:\"" + unit + "\"not implemented!");
                    return false;
                }

                if ((width_in_mm + tolerance_in_mm >= dpt.Width_in_mm) && (width_in_mm - tolerance_in_mm <= dpt.Width_in_mm))
                {
                    if (ID.Validate(dpt.ID))
                    {
                        doc_page_type_ID = new ID(dpt.ID);
                    }
                    else
                    {
                        doc_page_type_ID = null;
                    }
                    return true;
                }
            }
            return false;
        }




        public  bool Read()
        {
            string Err = null;
            string sql = "select ID,Name, Description,Width,Height from doc_page_type";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                const string TRANSACTION_doc_page_type_definitions_Set = "doc_page_type_definitions_Set";
                string transaction__doc_page_type_definitions_Set_id = null;
                foreach (doc_page_type dpt in doc_page_type_list)
                {
                    if (Get(dpt, dt))
                    {
                        continue;
                    }
                    else
                    {
                        if (transaction__doc_page_type_definitions_Set_id==null)
                        {
                            if (!DBSync.DBSync.DB_for_Tangenta.BeginTransaction(TRANSACTION_doc_page_type_definitions_Set, ref transaction__doc_page_type_definitions_Set_id))
                            {
                                return false;
                            }
                        }
                        if (!Set(dpt))
                        {
                            DBSync.DBSync.DB_for_Tangenta.RollbackTransaction(transaction__doc_page_type_definitions_Set_id);
                            return false;
                        }
                    }
                }
                if (transaction__doc_page_type_definitions_Set_id != null)
                {
                    if (!DBSync.DBSync.DB_for_Tangenta.CommitTransaction(transaction__doc_page_type_definitions_Set_id))
                    {
                        return false;
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
                        if (dpt.ID==null)
                        {
                            dpt.ID = new ID();
                        }
                        dpt.ID.Set(dr["ID"]);
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
            SQL_Parameter par_Width = new SQL_Parameter(spar_Width, SQL_Parameter.eSQL_Parameter.Decimal, false, dpt.Width_in_mm);
            string sval_Width = spar_Width;
            lpar.Add(par_Width);

            string spar_Height = "@par_Height";
            SQL_Parameter par_Height = new SQL_Parameter(spar_Height, SQL_Parameter.eSQL_Parameter.Decimal, false, dpt.Height_in_mm);
            string sval_Height = spar_Height;
            lpar.Add(par_Height);

            string sql = "insert into doc_page_type (Name,Description,Width,Height) values (" + sval_Name + "," + sval_Description + "," + sval_Width + "," + sval_Height+ ")";
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref dpt.ID, ref Err, "doc_page_type"))
            {
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
