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
        public enum ExistsResult { EXISTS, NOT_FOUND, ERROR };
        public enum StandardPages { A4, ROLL_80, ROLL_58 };
        public enum PageOreintation { PORTRAIT, LANDSCAPE };

        public const int A4_PORTRAIT_WIDTH = 210;
        public const int A4_PORTRAIT_HEIGHT = 297;
        public const int A4_LANDSCAPE_WIDTH = 297;
        public const int A4_LANDSCAPE_HEIGHT = 210;
        public const int Roll80_WIDTH = 80;
        public const int Roll80_HEIGHT = 99999;
        public const int Roll58_WIDTH = 58;
        public const int Roll58_HEIGHT = 99999;

        public enum eGetPrintDocumentTemplateResult { OK, ERROR, NO_DOCUMENT_TEMPLATE,PRINTER_NOT_SELECTED };


        public static long doc_Html_Invoice_Template_A4_ID = 0;

        public static bool InsertDefault()
        {

            Tangenta_DefaultPrintTemplates.TemplatesLoader.Init();
            foreach (HtmlTemplate ht in Tangenta_DefaultPrintTemplates.TemplatesLoader.Templates)
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
                string ilang = ht.Name.Substring(0, 3);
                if (ilang[2] == '_')
                {
                    ilang = ht.Name.Substring(0, 2);
                }
                try
                {
                    i = Convert.ToInt32(ilang);
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:DefaultPrintTemplate name should start with number (example: 000_ENG_...)\r\n" + ex.Message);
                    return false;
                }

                ID doc_ID = null;
                ID doc_type_ID = new ID(GlobalData.doc_type_definitions.doc_type_list[j].ID);
                ID doc_page_type_ID = null;
                if (ht.Name.Contains("A4"))
                {
                    doc_page_type_ID = new ID(GlobalData.doc_page_type_definitions.A4_Portrait_description.ID);
                }
                else if (ht.Name.Contains("Roll80"))
                {
                    doc_page_type_ID = new ID(GlobalData.doc_page_type_definitions.Roll_80_mm.ID);
                }
                else if (ht.Name.Contains("Roll58"))
                {
                    doc_page_type_ID = new ID(GlobalData.doc_page_type_definitions.Roll_58_mm.ID);
                }
                else
                {
                    doc_page_type_ID = new ID(GlobalData.doc_page_type_definitions.A4_Portrait_description.ID);
                }

                ID xLanguage_ID = new ID(GlobalData.language_definitions.Language_list[i].ID);

                string doc_Name = ht.Name;
                if (Exists(ht.Name, doc_type_ID, ref doc_ID) == ExistsResult.EXISTS)
                {
                    continue;
                }

                if (!Get(doc_Name,
                          null,
                          xDoc,
                          doc_type_ID,
                          doc_page_type_ID,
                          xLanguage_ID,
                            true,
                            true,
                            true,
                            true,
                            ref doc_ID
                            ))
                {
                    return false;
                }
            }

            return true;
        }

        public static ExistsResult Exists(string Name, ID doc_type_ID, ref ID doc_ID)
        {
            doc_ID = null;
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);
            string scond_Name = " Name = " + spar_Name + " ";


            string sval_doc_type_ID = "null";
            string scond_doc_type_ID = " doc_type_ID is null ";
            if (ID.Validate(doc_type_ID))
            {
                string spar_doc_type_ID = "@par_doc_type_ID";

                SQL_Parameter par_doc_type_ID = new SQL_Parameter(spar_doc_type_ID, false, doc_type_ID);
                lpar.Add(par_doc_type_ID);
                sval_doc_type_ID = spar_doc_type_ID;
                scond_doc_type_ID = " doc_type_ID = " + spar_doc_type_ID + " ";
            }


            string sql = "select ID from doc where " + scond_Name
                                                            + " and " + scond_doc_type_ID;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (doc_ID==null)
                    {
                        doc_ID = new ID();
                    }
                    doc_ID.Set(dt.Rows[0]["ID"]);
                    return ExistsResult.EXISTS;
                }
                return ExistsResult.NOT_FOUND;
            }
            else
            {

                LogFile.Error.Show("ERROR:f_doc:Exists:sql=" + sql + "\r\nErr=" + Err);
                return ExistsResult.ERROR;
            }
        }

        public static eGetPrintDocumentTemplateResult GetTemplate(ID doc_ID,
                                                                  ref string_v xName_v,
                                                                  ref string_v xDescription_v,
                                                                  ref byte_array_v xDoc_v,
                                                                  ref string_v xDoc_Hash_v,
                                                                  ref ID doc_type_ID,
                                                                  ref ID doc_page_type_ID,
                                                                  ref ID Language_ID,
                                                                  ref bool_v bCompressed_v)

        {

            string Err = null;
            
            DataTable     dt= new DataTable();
            string sql = "select Name,Description,xDocument,xDocument_Hash,doc_type_ID,doc_page_type_ID,Language_ID,Compressed from doc where ID =" + doc_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    xDoc_v = null;
                    xName_v = tf.set_string(dt.Rows[0]["Name"]);
                    xDescription_v = tf.set_string(dt.Rows[0]["Description"]);
                    xDoc_Hash_v = tf.set_string(dt.Rows[0]["xDocument_Hash"]);
                    if (doc_type_ID==null)
                    {
                        doc_type_ID = new ID();
                    }
                    doc_type_ID.Set(dt.Rows[0]["doc_type_ID"]);

                    if (doc_page_type_ID==null)
                    {
                        doc_page_type_ID = new ID();
                    }
                    doc_page_type_ID.Set(dt.Rows[0]["doc_page_type_ID"]);

                    if (Language_ID==null)
                    {
                        Language_ID = new ID();
                    }
                    Language_ID.Set(dt.Rows[0]["Language_ID"]);

                    bCompressed_v = tf.set_bool(dt.Rows[0]["Compressed"]);
                    if (bCompressed_v!=null)
                    {
                        if (bCompressed_v.v)
                        {
                           object oxDoc = dt.Rows[0]["xDocument"];
                           if (oxDoc is byte[])
                            {
                                xDoc_v = tf.set_byte_array(fs.Decompress((byte[])oxDoc));
                            }
                        }
                    }
                    return eGetPrintDocumentTemplateResult.OK;
                }
                else
                {
                    xDoc_v = null;
                    xName_v = null;
                    xDescription_v = null;
                    xDoc_Hash_v = null;
                    doc_type_ID = null;
                    doc_page_type_ID = null;
                    Language_ID = null;
                    bCompressed_v = null;
                    return eGetPrintDocumentTemplateResult.NO_DOCUMENT_TEMPLATE;
                }
            }
            else
            {
                xDoc_v = null;
                xName_v = null;
                xDescription_v = null;
                xDoc_Hash_v = null;
                doc_type_ID = null;
                doc_page_type_ID = null;
                Language_ID = null;
                bCompressed_v = null;
                LogFile.Error.Show("ERROR:TangentaDB:f_doc:GetTemplate:\r\nsql=" + sql + "\r\nErr=" + Err);
                return eGetPrintDocumentTemplateResult.ERROR;
            }

        }
        public static eGetPrintDocumentTemplateResult GetTemplates(ref DataTable dtTemplates,
                                        ID doc_type_ID,
                                        ID doc_page_type_ID,
                                        ID Language_ID
                                        )

        {
            string Err = null;
            if (dtTemplates == null)
            {
                dtTemplates = new DataTable();
            }
            else
            {
                dtTemplates.Clear();
                dtTemplates.Columns.Clear();
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string sval_doc_type_ID = "null";
            string scond_doc_type_ID = " doc_type_ID is null ";
            if (ID.Validate(doc_type_ID))
            {
                string spar_doc_type_ID = "@par_doc_type_ID";

                SQL_Parameter par_doc_type_ID = new SQL_Parameter(spar_doc_type_ID, false, doc_type_ID);
                lpar.Add(par_doc_type_ID);
                sval_doc_type_ID = spar_doc_type_ID;
                scond_doc_type_ID = " doc_type_ID = " + spar_doc_type_ID + " ";
            }

          


            string sval_Language_ID = "null";
            string scond_Language_ID = " Language_ID is null ";

            if (ID.Validate(Language_ID))
            {
                string spar_Language_ID = "@par_Language_ID";

                SQL_Parameter par_Language_ID = new SQL_Parameter(spar_Language_ID, false, Language_ID);
                lpar.Add(par_Language_ID);
                sval_Language_ID = spar_Language_ID;
                scond_Language_ID = " Language_ID = " + spar_Language_ID + " ";
            }

            string sql = "select Name,Description,bDefault,ID from doc where " + scond_doc_type_ID
                                                          + " and " + scond_Language_ID
                                                          + " and Active = 1";
            string sval_doc_page_type_ID = null;
            string scond_doc_page_type_ID = null;
            if (ID.Validate(doc_page_type_ID))
            {
                string spar_doc_page_type_ID = "@par_doc_page_type_ID";
                SQL_Parameter par_doc_page_type_ID = new SQL_Parameter(spar_doc_page_type_ID,  false, doc_page_type_ID);
                lpar.Add(par_doc_page_type_ID);
                sval_doc_page_type_ID = spar_doc_page_type_ID;
                scond_doc_page_type_ID = " doc_page_type_ID = " + spar_doc_page_type_ID + " ";

                sql = "select Name,Description,bDefault,ID from doc where " + scond_doc_type_ID
                                                          + " and " + scond_doc_page_type_ID
                                                          + " and " + scond_Language_ID
                                                          + " and Active = 1";
            }

            if (DBSync.DBSync.ReadDataTable(ref dtTemplates, sql, lpar, ref Err))
            {
                if (dtTemplates.Rows.Count > 0)
                {
                  return eGetPrintDocumentTemplateResult.OK;
                }
                else
                {
                    return eGetPrintDocumentTemplateResult.NO_DOCUMENT_TEMPLATE;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_doc:GetTemplates:\r\nsql=" + sql + "\r\nErr=" + Err);
                return eGetPrintDocumentTemplateResult.ERROR;
            }
        }

        public static bool Get(string Name, 
                                string_v Description_v,
                                byte[] xDocument, 
                                ID doc_type_ID,
                                ID doc_page_type_ID,
                                ID Language_ID,
                                bool commpressed,
                                bool Active,
                                bool Default,
                                bool bOverwriteIfNameAndTypesAreTheSame,
                                ref ID doc_ID)
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
                string scond_Name = " Name = "+ spar_Name + " ";

                string sval_Description = "null";
                string scond_Description = " Description is null ";
                if (Description_v != null)
                {
                    string spar_Description = "@par_Description";

                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description_v.v);
                    lpar.Add(par_Description);
                    sval_Description = spar_Description;
                    scond_Description = " Description = "+ spar_Description + " ";
                }


                string sval_doc_type_ID = "null";
                string scond_doc_type_ID = " doc_type_ID is null ";
                if (ID.Validate(doc_type_ID))
                {
                    string spar_doc_type_ID = "@par_doc_type_ID";

                    SQL_Parameter par_doc_type_ID = new SQL_Parameter(spar_doc_type_ID, false, doc_type_ID);
                    lpar.Add(par_doc_type_ID);
                    sval_doc_type_ID = spar_doc_type_ID;
                    scond_doc_type_ID = " doc_type_ID = " + spar_doc_type_ID + " ";
                }

                string sval_doc_page_type_ID = "null";
                string scond_doc_page_type_ID = " doc_page_type_ID is null";
                if (ID.Validate(doc_page_type_ID))
                {
                    string spar_doc_page_type_ID = "@par_doc_page_type_ID";

                    SQL_Parameter par_doc_page_type_ID = new SQL_Parameter(spar_doc_page_type_ID, false, doc_page_type_ID);
                    lpar.Add(par_doc_page_type_ID);
                    sval_doc_page_type_ID = spar_doc_page_type_ID;
                    scond_doc_page_type_ID = " doc_page_type_ID = "+ spar_doc_page_type_ID+" ";
                }


                string sval_Language_ID = "null";
                string scond_Language_ID = " Language_ID is null ";

                if (ID.Validate(Language_ID))
                {
                    string spar_Language_ID = "@par_Language_ID";

                    SQL_Parameter par_Language_ID = new SQL_Parameter(spar_Language_ID, false, Language_ID);
                    lpar.Add(par_Language_ID);
                    sval_Language_ID = spar_Language_ID;
                    scond_Language_ID = " Language_ID = "+ spar_Language_ID + " ";
                }

                
                xDocument_HASH = DBtypesFunc.GetHash_SHA1(xDocument);
                string spar_xDocument_HASH = "@par_xDocument_HASH";
                SQL_Parameter par_xDocument_HASH = new SQL_Parameter(spar_xDocument_HASH, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xDocument_HASH);
                lpar.Add(par_xDocument_HASH);
                string scond_xDocument_HASH = " xDocument_HASH = " + spar_xDocument_HASH + " ";

                string sql = "select ID from doc where "+scond_Name 
                                                                + " and " + scond_Description 
                                                                + " and " + scond_doc_type_ID
                                                                + " and " + scond_doc_page_type_ID
                                                                + " and " + scond_Language_ID
                                                                + " and " + scond_xDocument_HASH;

                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (doc_ID==null)
                        {
                            doc_ID = new ID();
                        }
                        doc_ID.Set(dt.Rows[0]["ID"]);
                        return true;
                    }
                    else
                    {
                        if (bOverwriteIfNameAndTypesAreTheSame)
                        {
                            sql = "select ID from doc where " + scond_Name
                                                                                            + " and " + scond_doc_type_ID
                                                                                            + " and " + scond_doc_page_type_ID
                                                                                            + " and " + scond_Language_ID;
                            dt.Clear();
                            dt.Columns.Clear();
                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    ID doc_id = new ID(dt.Rows[0]["ID"]);

                                    if (Update(doc_id,
                                           Name,
                                           Description_v,
                                           xDocument,
                                           doc_type_ID,
                                           doc_page_type_ID,
                                           Language_ID,
                                           commpressed,
                                           Active,
                                           Default))
                                    {
                                        doc_ID = doc_id;
                                        return true;
                                    }
                                    else
                                    {
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


                        if (Default)
                        {
                            sql = @"update doc set bDefault = 0 where doc_type_ID = " + sval_doc_type_ID + " and doc_page_type_ID = " + sval_doc_page_type_ID + " and Language_ID = " + sval_Language_ID;
                            if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar,  ref Err))
                            {
                                LogFile.Error.Show("ERROR:f_doc:Get:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
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
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref doc_ID,  ref Err, "doc"))
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


        public static bool Update(ID doc_ID,
                                string Name,
                                string_v Description_v,
                                byte[] xDocument,
                                ID doc_type_ID,
                                ID doc_page_type_ID,
                                ID Language_ID,
                                bool commpressed,
                                bool Active,
                                bool Default)
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
                string scond_Name = " Name = " + spar_Name + " ";

                string sval_Description = "null";
                string scond_Description = " Description is null ";
                if (Description_v != null)
                {
                    string spar_Description = "@par_Description";

                    SQL_Parameter par_Description = new SQL_Parameter(spar_Description, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Description_v.v);
                    lpar.Add(par_Description);
                    sval_Description = spar_Description;
                    scond_Description = " Description = " + spar_Description + " ";
                }


                string sval_doc_type_ID = "null";
                string scond_doc_type_ID = " doc_type_ID is null ";
                if (ID.Validate(doc_type_ID))
                {
                    string spar_doc_type_ID = "@par_doc_type_ID";

                    SQL_Parameter par_doc_type_ID = new SQL_Parameter(spar_doc_type_ID, false, doc_type_ID);
                    lpar.Add(par_doc_type_ID);
                    sval_doc_type_ID = spar_doc_type_ID;
                    scond_doc_type_ID = " doc_type_ID = " + spar_doc_type_ID + " ";
                }

                string sval_doc_page_type_ID = "null";
                string scond_doc_page_type_ID = " doc_page_type_ID is null";
                if (ID.Validate(doc_page_type_ID))
                {
                    string spar_doc_page_type_ID = "@par_doc_page_type_ID";

                    SQL_Parameter par_doc_page_type_ID = new SQL_Parameter(spar_doc_page_type_ID, false, doc_page_type_ID);
                    lpar.Add(par_doc_page_type_ID);
                    sval_doc_page_type_ID = spar_doc_page_type_ID;
                    scond_doc_page_type_ID = " doc_page_type_ID = " + spar_doc_page_type_ID + " ";
                }


                string sval_Language_ID = "null";
                string scond_Language_ID = " Language_ID is null ";

                if (ID.Validate(Language_ID))
                {
                    string spar_Language_ID = "@par_Language_ID";

                    SQL_Parameter par_Language_ID = new SQL_Parameter(spar_Language_ID, false, Language_ID);
                    lpar.Add(par_Language_ID);
                    sval_Language_ID = spar_Language_ID;
                    scond_Language_ID = " Language_ID = " + spar_Language_ID + " ";
                }


                xDocument_HASH = DBtypesFunc.GetHash_SHA1(xDocument);
                string spar_xDocument_HASH = "@par_xDocument_HASH";
                SQL_Parameter par_xDocument_HASH = new SQL_Parameter(spar_xDocument_HASH, SQL_Parameter.eSQL_Parameter.Nvarchar, false, xDocument_HASH);
                lpar.Add(par_xDocument_HASH);
                string scond_xDocument_HASH = " xDocument_HASH = " + spar_xDocument_HASH + " ";

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

                string sql = @"Update doc set Name = " + spar_Name
                                            + ", Description = " + sval_Description
                                            + ", xDocument = " + spar_xDocument
                                            + ", xDocument_Hash = " + spar_xDocument_HASH
                                            + ", doc_type_ID = " + sval_doc_type_ID
                                            + ", doc_page_type_ID = " + sval_doc_page_type_ID
                                            + ", Language_ID = " + sval_Language_ID
                                            + ", Compressed = " + sCompressed
                                            + ", Active =1,bDefault = " + spar_bDefault + " where ID = " + doc_ID.ToString();
                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref doc_ID, ref Err, "doc"))
                {
                    return true;
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

        public static bool SetDefault(ID id)
        {
            string Err = null;
            string sql = "update doc set bDefault = 0";
            if (DBSync.DBSync.Con.ExecuteNonQuerySQL(sql, null,  ref Err))
            {
                sql = "update doc set bDefault = 1 where id = " + id.ToString();
 
                if (DBSync.DBSync.Con.ExecuteNonQuerySQL(sql, null,  ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_doc:SetDefault:sql=" + sql + "\r\nErr" + Err);
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_doc:SetDefault:sql=" + sql + "\r\nErr" + Err);
            }
            return false;
        }


        public static bool GetTemplate(ID id, ref string doc_Name, ref byte[] xDocument, ref bool bCommpressed)
        {
            bool Commpressed = false;
            string Err = null;
            string sql = "select doc_$$Name,doc_$$xDocument,doc_$$Compressed from doc_VIEW where ID = " + id.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.Con.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object o_doc_name = dt.Rows[0]["doc_$$Name"];
                    if (o_doc_name is string)
                    {
                        doc_Name = (string)o_doc_name;
                    }
                    object o_Compressed = dt.Rows[0]["doc_$$Compressed"];
                    if (o_Compressed is bool)
                    {
                        Commpressed = (bool)o_Compressed;
                        bCommpressed = Commpressed;
                    }

                    object o_doc = dt.Rows[0]["doc_$$xDocument"];
                    if (o_doc is byte[])
                    {
                        if (Commpressed)
                        {
                            xDocument = fs.Decompress((byte[])((byte[])o_doc).Clone());
                        }
                        else
                        {
                            xDocument = (byte[])((byte[])o_doc).Clone();
                        }

                        //private usrc_Print usrc_Print;
                        //private usrc_Payment.ePaymentType paymentType;
                        //private string sPaymentMethod;
                        //private string sAmountReceived;
                        //private string sToReturn;
                        //private DateTime_v issue_time;
                        return true;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_doc:GetTemplateName:sql=" + sql + "\r\nErr" + Err);
            }
            doc_Name = "";
            return false;
        }


        public static eGetPrintDocumentTemplateResult GetDefaultTemplate(ref long id,
                                        ref string doc_Name,
                                        ref byte[] xDocument,
                                        ref bool bCommpressed,
                                        int iLang,
                                        string DocType,
                                        f_doc.StandardPages PageType,
                                        f_doc.PageOreintation PageOrientation
                                        )
        {
            string Err = null;
            bool Commpressed = false;
//            int iLang = m_usrc_SelectPrintTemplate.SelectedLangugage;
            int iLang_ID = iLang + 1;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string scond_Language_ID = null;
            string sval_Language_ID = null;
            string scond_doc_type_ID = null;
            string sval_doc_type_ID = null;
            string scond_page_name = null;
            string sval_page_name = null;
            string scond_page_width = null;
            string scond_page_height = null;
            string sval_page_width = null;
            string sval_page_height = null;

            if (!fs.Add_lpar(lpar, "doc_$_lng_$$ID", iLang_ID, ref scond_Language_ID, ref sval_Language_ID))
            {
                return eGetPrintDocumentTemplateResult.ERROR;
            }
            if (fs.IsDocInvoice(DocType))
            {
                if (!fs.Add_lpar(lpar, "doc_$_doctype_$$ID", GlobalData.doc_type_definitions.HTMLPrintTemplate_Invoice.ID, ref scond_doc_type_ID, ref sval_doc_type_ID))
                {
                    return eGetPrintDocumentTemplateResult.ERROR;
                }
            }
            else if (fs.IsDocProformaInvoice(DocType))
            {
                if (!fs.Add_lpar(lpar, "doc_$_doctype_$$ID", GlobalData.doc_type_definitions.HTMLPrintTemplate_ProformaInvoice.ID, ref scond_doc_type_ID, ref sval_doc_type_ID))
                {
                    return eGetPrintDocumentTemplateResult.ERROR;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaPrint:Form_SelectTemplate:GetDefaultTemplate:Unknown document type!");
                return eGetPrintDocumentTemplateResult.ERROR;
            }

            if ((PageType == f_doc.StandardPages.A4)
                && (PageOrientation == f_doc.PageOreintation.PORTRAIT))
            {
                if (fs.Add_lpar(lpar, "doc_$_pgt_$$Name", "A4 Portrait", ref scond_page_name, ref sval_page_name))
                {
                    if (fs.Add_lpar(lpar, "doc_$_pgt_$$Width", f_doc.A4_PORTRAIT_WIDTH, ref scond_page_width, ref sval_page_width))
                    {
                        if (fs.Add_lpar(lpar, "doc_$_pgt_$$Height", f_doc.A4_PORTRAIT_HEIGHT, ref scond_page_height, ref sval_page_height))
                        {

                        }
                        else
                        {
                            return eGetPrintDocumentTemplateResult.ERROR;
                        }
                    }
                    else
                    {
                        return eGetPrintDocumentTemplateResult.ERROR;
                    }
                }
                else
                {
                    return eGetPrintDocumentTemplateResult.ERROR;
                }
            }
            else if ((PageType == f_doc.StandardPages.A4)
                && (PageOrientation == f_doc.PageOreintation.LANDSCAPE))
            {
                if (fs.Add_lpar(lpar, "doc_$_pgt_$$Name", "A4 Landscape", ref scond_page_name, ref sval_page_name))
                {
                    if (fs.Add_lpar(lpar, "doc_$_pgt_$$Width", f_doc.A4_LANDSCAPE_WIDTH, ref scond_page_width, ref sval_page_width))
                    {
                        if (fs.Add_lpar(lpar, "doc_$_pgt_$$Height", f_doc.A4_LANDSCAPE_HEIGHT, ref scond_page_height, ref sval_page_height))
                        {

                        }
                        else
                        {
                            return eGetPrintDocumentTemplateResult.ERROR;
                        }
                    }
                    else
                    {
                        return eGetPrintDocumentTemplateResult.ERROR;
                    }
                }
                else
                {
                    return eGetPrintDocumentTemplateResult.ERROR;
                }
            }
            else if (PageType == f_doc.StandardPages.ROLL_80)
            {
                if (fs.Add_lpar(lpar, "doc_$_pgt_$$Name", "Roll paper 80mm", ref scond_page_name, ref sval_page_name))
                {
                    if (fs.Add_lpar(lpar, "doc_$_pgt_$$Width", f_doc.Roll80_WIDTH, ref scond_page_width, ref sval_page_width))
                    {
                        if (fs.Add_lpar(lpar, "doc_$_pgt_$$Height", f_doc.Roll80_HEIGHT, ref scond_page_height, ref sval_page_height))
                        {

                        }
                        else
                        {
                            return eGetPrintDocumentTemplateResult.ERROR;
                        }
                    }
                    else
                    {
                        return eGetPrintDocumentTemplateResult.ERROR;
                    }

                }
                else
                {
                    return eGetPrintDocumentTemplateResult.ERROR;
                }
            }
            else if (PageType == f_doc.StandardPages.ROLL_58)
            {
                if (fs.Add_lpar(lpar, "doc_$_pgt_$$Name", "Roll paper 80mm", ref scond_page_name, ref sval_page_name))
                {
                    if (fs.Add_lpar(lpar, "doc_$_pgt_$$Width", f_doc.Roll58_WIDTH, ref scond_page_width, ref sval_page_width))
                    {
                        if (fs.Add_lpar(lpar, "doc_$_pgt_$$Height", f_doc.Roll58_HEIGHT, ref scond_page_height, ref sval_page_height))
                        {

                        }
                        else
                        {
                            return eGetPrintDocumentTemplateResult.ERROR;
                        }
                    }
                    else
                    {
                        return eGetPrintDocumentTemplateResult.ERROR;
                    }

                }
                else
                {
                    return eGetPrintDocumentTemplateResult.ERROR;
                }
            }


            string sql = "select id,doc_$$Name,doc_$$xDocument,doc_$$Compressed from doc_VIEW where doc_$$Active = 1 "
                          + " and " + scond_Language_ID
                          + " and " + scond_doc_type_ID
                          + " and " + scond_page_name
                          + " and " + scond_page_width
                          + " and " + scond_page_height
                          + " order by doc_$$bDefault desc;";
            DataTable dt = new DataTable();
            if (DBSync.DBSync.Con.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object o_doc_name = dt.Rows[0]["doc_$$Name"];
                    if (o_doc_name is string)
                    {
                        doc_Name = (string)o_doc_name;
                    }
                    object o_id = dt.Rows[0]["id"];
                    if (o_id is long)
                    {
                        id = (long)o_id;
                    }
                    object o_Compressed = dt.Rows[0]["doc_$$Compressed"];
                    if (o_Compressed is bool)
                    {
                        Commpressed = (bool)o_Compressed;
                        bCommpressed = Commpressed;
                    }
                    object o_doc = dt.Rows[0]["doc_$$xDocument"];
                    if (o_doc is byte[])
                    {
                        if (Commpressed)
                        {
                            xDocument = fs.Decompress((byte[])((byte[])o_doc).Clone());
                        }
                        else
                        {
                            xDocument = (byte[])((byte[])o_doc).Clone();
                        }
                        return eGetPrintDocumentTemplateResult.OK;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_doc:GetTemplateName:sql=" + sql + "\r\ndoc_$$xDocument is not of type byte[]");
                        return eGetPrintDocumentTemplateResult.ERROR;
                    }
                }
                else
                {
                    return eGetPrintDocumentTemplateResult.NO_DOCUMENT_TEMPLATE;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Form_SelectTemplate:GetTemplateName:sql=" + sql + "\r\nErr" + Err);
            }
            doc_Name = "";
            return eGetPrintDocumentTemplateResult.ERROR;
        }

    }
}
