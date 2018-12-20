using DBConnectionControl40;
using DBTypes;
using LogFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public static class f_Reference_Image
    {
        public static bool Get(byte_array_v Image_Data_v, string_v Image_Hash_v,  ref ID Reference_Image_ID)
        {
            string Err = null;
            if (Image_Hash_v == null)
            {
                Reference_Image_ID = null;
                return true;
            }
            if (Reference_Image_ID == null)
            {
                Reference_Image_ID = new ID();
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Image_Hash_Value = "null";
            string Image_Hash_cond = "Image_Hash is null";
            if (Image_Hash_v != null)
            {
                if (Image_Hash_v.v != null)
                {
                    Image_Hash_Value = "@par_Image_Hash";
                    Image_Hash_cond = "Image_Hash = " + Image_Hash_Value;
                    SQL_Parameter par_Image_Hash = new SQL_Parameter(Image_Hash_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Image_Hash_v.v);
                    lpar.Add(par_Image_Hash);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            string Image_Data_Value = "null";
            if (Image_Data_v != null)
            {
                if (Image_Data_v.v != null)
                {
                    Image_Data_Value = "@par_Image_Data";
                    SQL_Parameter par_Image_Data = new SQL_Parameter(Image_Data_Value, SQL_Parameter.eSQL_Parameter.Varbinary, false, Image_Data_v.v);
                    lpar.Add(par_Image_Data);
                }
            }

            string sql = " select ID, Image_Hash,Image_Data from Reference_Image where " + Image_Hash_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Reference_Image_ID==null)
                    {
                        Reference_Image_ID = new ID();
                    }
                    Reference_Image_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = " insert into Reference_Image (Image_Hash,Image_Data) values (" + Image_Hash_Value + "," + Image_Data_Value+ ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Reference_Image_ID, ref Err, "Reference_Image"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Reference_Image:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Reference_Image:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(Image Reference_Image,ref string Image_Hash, ref ID Reference_Image_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            Image_Hash = null;
            byte_array_v Image_Data_v = null;
            string_v Image_Hash_v = null;
            if (Reference_Image != null)
            {
                Image_Data_v = new byte_array_v();
                Image_Data_v.v = StaticLib.Func.imageToByteArray(Reference_Image, Reference_Image.RawFormat);
                Image_Hash_v = new string_v();
                Image_Hash_v.v = StaticLib.Func.GetHash_SHA1(Image_Data_v.v);
                Image_Hash = Image_Hash_v.v;
                if (f_Reference_Image.Get(Image_Data_v, Image_Hash_v, ref Reference_Image_ID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Reference_Image:Get(Image Reference_Image, ref long_v Reference_Image_ID_v):Reference_Image is null!");
                return false;
            }
        }
    }
}
