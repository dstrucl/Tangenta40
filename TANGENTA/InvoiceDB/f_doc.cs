#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using InvoiceDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDB
{
    public static class f_doc
    {
        public static long doc_Html_Invoice_Template_A4_ID = 0;

        public static bool InsertDefault()
        {
            string[] language_Names = new string[] { "English", "Slovene" };
            string[] language_Descriptions = new string[] { "English", "Slovensko" };



            string[] doc_page_type_A4_Name = new string[] { "A4", "A4" };
            string[] doc_page_type_A4_Description = new string[] { "A4", "A4" };

            string[] doc_page_type_Roll_80_Name = new string[] { "Roll 80mm", "Rola 80mm" };
            string[] doc_page_type_Roll_80_Description = new string[] { "Roll 80mm", "Rola 80mm" };

            string[] doc_page_type_Roll_58_Name = new string[] { "Roll 58mm", "Rola 58mm" };
            string[] doc_page_type_Roll_58_Description = new string[] { "Roll 58mm", "Rola 58mm" };


            string[] doc_type_Html_Invoice_Template_A4_Name = new string[] { "HTML Template Invoice A4", "HTML predloga računi A4" };
            string[] doc_type_Html_Invoice_Template_A4_Description = new string[] { "HTML Template Invoice A4", "HTML predloga računi A4" };

            string[] doc_type_Html_Proforma_Invoice_Template_A4_Name = new string[] { "HTML Template Proforma Invoice A4", "HTML predloga predračuni" };
            string[] doc_type_Html_Proforma_Invoice_Template_A4_Description = new string[] { "HTML Template Proforma Invoice", "HTML predloga predračuni" };

            string[] doc_Html_Invoice_Template_A4_Name = new string[] { "English HTML Template Invoice A4", "Slovenska HTML predloga računi A4" };
            string[] doc_Html_Invoice_Template_A4_Description = new string[] { "English HTML Template Invoice", "Slovenska HTML predloga računi A4" };

            string[] doc_Html_Proforma_Invoice_Template_A4_Name = new string[] { "English HTML Template Proforma Invoice A4", "Slovenska HTML predloga pred računi A4"};
            string[] doc_Html_Proforma_Invoice_Template_A4_Description = new string[] { "English HTML Template Proforma Invoice A4", "Slovenska HTML predloga pred računi A4"};


            string[] doc_type_Html_Invoice_Template_Roll58_Name = new string[] { "HTML Template Invoice Roll58", "HTML predloga računi Roll58" };
            string[] doc_type_Html_Invoice_Template_Roll58_Description = new string[] { "HTML Template Invoice Roll58", "HTML predloga računi Roll58" };

            string[] doc_type_Html_Proforma_Invoice_Template_Roll58_Name = new string[] { "HTML Template Proforma Invoice Roll58", "HTML predloga predračuni" };
            string[] doc_type_Html_Proforma_Invoice_Template_Roll58_Description = new string[] { "HTML Template Proforma Invoice", "HTML predloga predračuni" };

            string[] doc_Html_Invoice_Template_Roll58_Name = new string[] { "English HTML Template Invoice Roll58", "Slovenska HTML predloga računi Roll58" };
            string[] doc_Html_Invoice_Template_Roll58_Description = new string[] { "English HTML Template Invoice", "Slovenska HTML predloga računi Roll58" };

            string[] doc_Html_Proforma_Invoice_Template_Roll58_Name = new string[] { "English HTML Template Proforma Invoice Roll58", "Slovenska HTML predloga pred računi Roll58" };
            string[] doc_Html_Proforma_Invoice_Template_Roll58_Description = new string[] { "English HTML Template Proforma Invoice Roll58", "Slovenska HTML predloga pred računi Roll58" };



            string[] doc_type_Html_Invoice_Template_Roll80_Name = new string[] { "HTML Template Invoice Roll80", "HTML predloga računi Roll80" };
            string[] doc_type_Html_Invoice_Template_Roll80_Description = new string[] { "HTML Template Invoice Roll80", "HTML predloga računi Roll80" };

            string[] doc_type_Html_Proforma_Invoice_Template_Roll80_Name = new string[] { "HTML Template Proforma Invoice Roll80", "HTML predloga predračuni" };
            string[] doc_type_Html_Proforma_Invoice_Template_Roll80_Description = new string[] { "HTML Template Proforma Invoice", "HTML predloga predračuni" };

            string[] doc_Html_Invoice_Template_Roll80_Name = new string[] { "English HTML Template Invoice Roll80", "Slovenska HTML predloga računi Roll80" };
            string[] doc_Html_Invoice_Template_Roll80_Description = new string[] { "English HTML Template Invoice", "Slovenska HTML predloga računi Roll80" };

            string[] doc_Html_Proforma_Invoice_Template_Roll80_Name = new string[] { "English HTML Template Proforma Invoice Roll80", "Slovenska HTML predloga pred računi Roll80" };
            string[] doc_Html_Proforma_Invoice_Template_Roll80_Description = new string[] { "English HTML Template Proforma Invoice Roll80", "Slovenska HTML predloga pred računi Roll80" };



            long[] doc_type_A4_ID = new long[2];
            long[] doc_ID_inv = new long[2];
            long[] doc_ID_pinv = new long[2];

            long[] languageID = new long[2];
            long[] doc_page_type_A4_ID = new long[2];

            int i =0;
            for (i = 0; i < language_Names.Count(); i++)
            {
                string_v Description_v = new string_v(language_Descriptions[i]);
                if (f_Language.Get(language_Names[i], Description_v, ref languageID[i]))
                {
                    long_v Language_ID_v = new long_v(languageID[i]);
                    byte[] xDoc = null;
                    if (i == 0)
                    {
                        xDoc = fs.GetBytes(Properties.Resources.htmlt_ENG_inv1_A4);
                    }
                    else
                    {
                        xDoc = fs.GetBytes(Properties.Resources.htmlt_SLO_inv1_A4);
                    }
                    long doc_page_type_ID = 0;
                    long doc_type_ID = 0;
                    long doc_ID = 0;
                    if (!Get(Language_ID_v,
                             doc_page_type_A4_Name[i],
                             doc_page_type_A4_Description[i],
                               210,
                               297,
                               ref doc_page_type_ID,
                               doc_type_Html_Invoice_Template_A4_Name[i],
                               doc_type_Html_Invoice_Template_A4_Description[i],
                               ref doc_type_ID,
                               doc_Html_Invoice_Template_A4_Name[i],
                               doc_Html_Invoice_Template_A4_Description[i],
                               xDoc,
                               true,
                               true,
                               false,
                               ref doc_ID
                               )
                        )
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Get(long_v Language_ID_v,
                               string doc_page_type_Name,
                               string doc_page_type_Description,
                               decimal Page_Width,
                               decimal Page_Height,
                               ref long doc_page_type_ID,
                               string doc_type_Name,
                               string doc_type_Description,
                               ref long doc_type_ID,
                               string doc_Name,
                               string doc_Description,
                               byte[] doc,
                               bool Compressed,
                               bool Active,
                               bool Default,
                               ref long doc_ID
                               )
        {
            string_v doc_page_type_Description_v = new string_v(doc_page_type_Description);
            decimal_v Width_v = new decimal_v(Page_Width);
            decimal_v Height_v = new decimal_v(Page_Height);
            if (f_doc_page_type.Get(doc_page_type_Name, doc_page_type_Description_v, Width_v, Height_v, ref doc_page_type_ID))
            {
                string_v doc_type_Description_v = new string_v(doc_type_Description);
                long_v doc_page_type_ID_v = new long_v(doc_page_type_ID);
                if (f_doc_type.Get(doc_type_Name, doc_type_Description_v, Language_ID_v, doc_page_type_ID_v, ref doc_type_ID))
                {
                    long_v doc_type_ID_v = new long_v(doc_type_ID);
                    string_v doc_Description_v = new string_v(doc_Description);
                    if (Get(doc_Name, doc_Description_v, doc, doc_type_ID_v, Compressed, Active, Default, ref doc_ID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool Get(string Name, string_v Description_v, byte[] xDocument, long_v doc_type_ID_v,bool commpressed,bool Active,bool Default, ref long doc_ID)
        {
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            //Table doc_page_type
            if (xDocument != null)
            {
                string xDocument_HASH = DBtypesFunc.GetHash_SHA1(xDocument);

                string spar_Name = "@par_Name";
                SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
                lpar.Add(par_Name);


                string sval_Description = "null";

                if (Description_v != null)
                {
                    string spar_Description = "@par_Description";

                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description_v.v);
                    lpar.Add(par_Description);
                    sval_Description = spar_Description;
                }


                string sval_doc_type_ID = "null";

                if (doc_type_ID_v != null)
                {
                    string spar_doc_type_ID = "@par_doc_type_ID";

                    SQL_Parameter par_doc_type_ID = new SQL_Parameter(spar_doc_type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, doc_type_ID_v.v);
                    lpar.Add(par_doc_type_ID);
                    sval_doc_type_ID = spar_doc_type_ID;
                }


                xDocument_HASH = DBtypesFunc.GetHash_SHA1(xDocument);
                string spar_xDocument_HASH = "@par_xDocument_HASH";
                SQL_Parameter par_xDocument_HASH = new SQL_Parameter(spar_xDocument_HASH, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xDocument_HASH);
                lpar.Add(par_xDocument_HASH);


                string sql = "select ID from doc where Name = " + spar_Name + " and Description = " + sval_Description + " and doc_type_ID = " + sval_doc_type_ID + " and xDocument_HASH = " + spar_xDocument_HASH;

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        doc_ID = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        byte[] byte_data = xDocument;
                        string sCompressed = "0";
                        if (commpressed)
                        {
                            sCompressed = "1";
                            byte_data = fs.Compress(xDocument);
                        }

                        string spar_xDocument = "@par_xDocument";
                        SQL_Parameter par_xDocument = new SQL_Parameter(spar_xDocument, SQL_Parameter.eSQL_Parameter.Varbinary, false, byte_data);
                        lpar.Add(par_xDocument);

                        sql = @"insert into doc (Name,
                                                 Description,
                                                 xDocument,
                                                 xDocument_Hash,
                                                 doc_type_ID,
                                                 Compressed,
                                                 Active,
                                                 bDefault)
                                                 values("
                                                  + spar_Name + "," 
                                                  + sval_Description + "," 
                                                  + spar_xDocument + ","
                                                  + spar_xDocument_HASH + ","
                                                  + sval_doc_type_ID + ","
                                                  + sCompressed +@",
                                                  1,0)";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref doc_ID, ref oret, ref Err, "doc"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:f_doc:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_doc:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_doc:Get:Error xDocument may not be null!");
                return false;
            }
        }
    }
}
