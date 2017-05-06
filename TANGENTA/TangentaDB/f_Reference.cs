using DBConnectionControl40;
using DBTypes;
using StaticLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Reference
    {
        public static bool Get(string ReferenceNote,
                               Image Reference_Image,
                               ref long Reference_ID
                              )
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Err = null;

            if (ReferenceNote != null)
            {
                string spar_ReferenceNote = "@par_ReferenceNote";
                SQL_Parameter par_ReferenceNote = new SQL_Parameter(spar_ReferenceNote, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ReferenceNote);
                lpar.Add(par_ReferenceNote);
                string sql = @"select ID from Reference where ReferenceNote = " + spar_ReferenceNote;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        Reference_ID = (long)dt.Rows[0]["ID"];
                        return true;
                    }
                    else
                    {
                        string sval_Reference_Image_ID = "null";
                        if (Reference_Image != null)
                        {
                            string Image_Hash = null;
                            long_v Reference_Image_ID_v = null;
                            if (!f_Reference_Image.Get(Reference_Image, ref Image_Hash, ref Reference_Image_ID_v))
                            {
                                return false;
                            }
                            sval_Reference_Image_ID = Reference_Image_ID_v.v.ToString();
                        }
                        sql = @"insert into Reference (ReferenceNote,Reference_Image_ID)values(" + spar_ReferenceNote+","+ sval_Reference_Image_ID+");";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,lpar,ref Reference_ID,ref oret,ref Err, "Reference"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:f_Reference:Get:sql=" + sql + "\r\nErr=" + Err);
                            return false;

                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Reference:Get:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Reference:Get:ReferenceNote is null!");
                return false;
            }
        }

        public static bool GetData(long Reference_ID,
                                   ref string ReferenceNote,
                                   ref string ImageHash,
                                   ref Image img
                                   )
        {
            string Err = null;
            string sql = @"select Reference_$$ReferenceNote,
                                  Reference_$_refimg_$$Image_Hash,
                                  Reference_$_refimg_$$Image_Data from Reference_VIEW where ID = " + Reference_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object oReferenceNote = dt.Rows[0]["Reference_$$ReferenceNote"];
                    if (oReferenceNote is string)
                    {
                        ReferenceNote = (string)oReferenceNote;
                        object oImageHash = dt.Rows[0]["Reference_$_refimg_$$Image_Hash"];
                        if (oImageHash is string)
                        {
                            ImageHash = (string)oImageHash;
                            byte_array_v Image_Data_v = tf.set_byte_array(dt.Rows[0]["Reference_$_refimg_$$Image_Data"]);
                            if (Image_Data_v != null)
                            {
                                ImageConverter ic = new ImageConverter();
                                img = (Image)ic.ConvertFrom(Image_Data_v.v);
                            }
                            else
                            {
                                img = null;
                            }
                        }
                        else
                        {
                            ImageHash = null;
                            img = null;
                        }
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_Reference:GetDate: No ReferenceNote data for Reference ID=" + Reference_ID.ToString());
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaDB:f_Reference:GetDate: No Reference data for Reference ID=" + Reference_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Reference:GetDate:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }
    }
}
