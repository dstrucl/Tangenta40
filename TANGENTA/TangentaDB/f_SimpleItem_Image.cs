using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_SimpleItem_Image
    {
        public static bool Get(string Image_Hash, byte[] Image_Data, ref ID SimpleItem_Image_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Image_Hash = "@par_Image_Hash";
            SQL_Parameter par_Image_Hash = new SQL_Parameter(spar_Image_Hash, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Image_Hash);
            lpar.Add(par_Image_Hash);
            string sql = "select ID from SimpleItem_Image where Image_Hash = " + spar_Image_Hash;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (SimpleItem_Image_ID==null)
                    {
                        SimpleItem_Image_ID = new ID();
                    }
                    SimpleItem_Image_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    string spar_Image_Data = "@par_Image_Data";
                    SQL_Parameter par_Image_Data = new SQL_Parameter(spar_Image_Data, SQL_Parameter.eSQL_Parameter.Varbinary, false, Image_Data);
                    lpar.Add(par_Image_Data);

                    sql = "insert into SimpleItem_Image (Image_Hash,Image_Data)values(" + spar_Image_Hash + "," + spar_Image_Data + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref SimpleItem_Image_ID, ref Err, "SimpleItem_Image"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_SimpleItem_Image:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SimpleItem_Image:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
        public static bool Get(Image SimpleItem_Image, ref ID SimpleItem_Image_ID)
        {
            byte[] byteArrayImage = DBtypesFunc.imageToByteArray(SimpleItem_Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string Image_Hash = DBtypesFunc.GetHash_SHA1(byteArrayImage);
            if (Get(Image_Hash, byteArrayImage, ref SimpleItem_Image_ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        internal static bool Get(ID SimpleItem_Image_ID, ref Image simpleItem_Image, ref string simpleItem_Image_Hash)
        {
            DataTable dt = new DataTable();
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_ID = "@par_ID";
            SQL_Parameter par_ID = new SQL_Parameter(spar_ID, false, SimpleItem_Image_ID);
            lpar.Add(par_ID);
            string sql = "select Image_Data,Image_Hash from SimpleItem_Image where ID = " + spar_ID;
            simpleItem_Image = null;
            simpleItem_Image_Hash = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    byte_array_v image_bytes_v = tf.set_byte_array(dt.Rows[0]["Image_Data"]);
                    simpleItem_Image = DBTypes.func.byteArrayToImage(image_bytes_v.v);
                    simpleItem_Image_Hash = tf._set_string(dt.Rows[0]["Image_Hash"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:f_SimpleItem_Image:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
