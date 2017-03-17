#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using TangentaDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageControl;
using Tangenta_DefaultPrintTemplates;

namespace TangentaDB
{
    public static class f_doc
    {
        public static long doc_Html_Invoice_Template_A4_ID = 0;

        public static bool InsertDefault()
        {
            
            Tangenta_DefaultPrintTemplates.TemplatesLoader.Init();
            foreach(HtmlTemplate ht in Tangenta_DefaultPrintTemplates.TemplatesLoader.Templates)
            {
                byte[] xDoc = null;
                int i = 0;
                int j = 0;
                byte[] bytes = null;
                bytes = Encoding.UTF8.GetBytes(ht.Html);
                string myString = Encoding.UTF8.GetString(bytes);
                xDoc = fs.GetBytes(myString);

                if (ht.Name.ToLower().Contains("_pinvoice") || (ht.Name.ToLower().Contains("_proformainvoice")))
                {
                    j = 1;
                }
                else if (ht.Name.ToLower().Contains("_invoice"))
                {
                    j = 0;
                }
                string ilang  = ht.Name.Substring(0, 3);
                if (ilang[2]=='_')
                {
                    ilang = ht.Name.Substring(0, 2);
                }
                try
                {
                    i = Convert.ToInt32(ilang);
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:DefaultPrintTemplate name should start with number (example: 000_ENG_...)\r\n"+ex.Message);
                    return false;
                }

                long doc_ID = 0;
                long_v doc_type_ID_v = new long_v(GlobalData.doc_type_definitions.doc_type_list[j].ID);
                long_v doc_page_type_ID_v = new long_v(GlobalData.doc_page_type_definitions.A4_Portrait_description.ID);
                long_v xLanguage_ID_v = new long_v(GlobalData.language_definitions.Language_list[i].ID);
            
                if (!Get(ht.Name,
                          null,
                          xDoc,
                          doc_type_ID_v,
                          doc_page_type_ID_v,
                          xLanguage_ID_v,
                            true,
                            true,
                            true,
                            ref doc_ID
                            )
                    )
                {
                    return false;
                }
            }
  
            return true;
        }



        public static bool Get(string Name, 
                                string_v Description_v,
                                byte[] xDocument, 
                                long_v doc_type_ID_v,
                                long_v doc_page_type_ID_v,
                                long_v Language_ID_v,
                                bool commpressed,
                                bool Active,
                                bool Default,
                                ref long doc_ID)
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

                string sval_doc_page_type_ID = "null";

                if (doc_page_type_ID_v != null)
                {
                    string spar_doc_page_type_ID = "@par_doc_page_type_ID";

                    SQL_Parameter par_doc_page_type_ID = new SQL_Parameter(spar_doc_page_type_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, doc_page_type_ID_v.v);
                    lpar.Add(par_doc_page_type_ID);
                    sval_doc_page_type_ID = spar_doc_page_type_ID;
                }


                string sval_Language_ID = "null";

                if (Language_ID_v != null)
                {
                    string spar_Language_ID = "@par_Language_ID";

                    SQL_Parameter par_Language_ID = new SQL_Parameter(spar_Language_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Language_ID_v.v);
                    lpar.Add(par_Language_ID);
                    sval_Language_ID = spar_Language_ID;
                }


                xDocument_HASH = DBtypesFunc.GetHash_SHA1(xDocument);
                string spar_xDocument_HASH = "@par_xDocument_HASH";
                SQL_Parameter par_xDocument_HASH = new SQL_Parameter(spar_xDocument_HASH, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xDocument_HASH);
                lpar.Add(par_xDocument_HASH);


                string sql = "select ID from doc where Name = " + spar_Name 
                                                                + " and Description = " + sval_Description 
                                                                + " and doc_type_ID = " + sval_doc_type_ID
                                                                + " and doc_page_type_ID = " + sval_doc_page_type_ID
                                                                + " and Language_ID = " + sval_Language_ID
                                                                + " and xDocument_HASH = " + spar_xDocument_HASH;

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

                        string spar_bDefault = "@par_bDefault";
                        SQL_Parameter par_bDefault = new SQL_Parameter(spar_bDefault, SQL_Parameter.eSQL_Parameter.Bit, false, Default);
                        lpar.Add(par_bDefault);

                        sql = @"insert into doc (Name,
                                                 Description,
                                                 xDocument,
                                                 xDocument_Hash,
                                                 doc_type_ID,
                                                 doc_page_type_ID,
                                                 Language_ID,
                                                 Compressed,
                                                 Active,
                                                 bDefault)
                                                 values("
                                                  + spar_Name + "," 
                                                  + sval_Description + "," 
                                                  + spar_xDocument + ","
                                                  + spar_xDocument_HASH + ","
                                                  + sval_doc_type_ID + ","
                                                  + sval_doc_page_type_ID + ","
                                                  + sval_Language_ID + ","
                                                  + sCompressed +@",
                                                  1,"+ spar_bDefault + ")";
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
