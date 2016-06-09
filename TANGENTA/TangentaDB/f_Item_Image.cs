﻿using DBConnectionControl40;
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
    public static class f_Item_Image
    {
        public static bool Get(string Image_Hash, byte[] Image_Data, ref long Item_Image_ID)
        {
            DataTable dt = new DataTable();
            string Err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Image_Hash = "@par_Image_Hash";
            SQL_Parameter par_Image_Hash = new SQL_Parameter(spar_Image_Hash, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Image_Hash);
            lpar.Add(par_Image_Hash);
            string sql = "select ID from Item_Image where Image_Hash = " + spar_Image_Hash;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Item_Image_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    string spar_Image_Data = "@par_Image_Data";
                    SQL_Parameter par_Image_Data = new SQL_Parameter(spar_Image_Hash, SQL_Parameter.eSQL_Parameter.Varbinary, false, Image_Data);
                    lpar.Add(par_Image_Data);

                    sql = "insert into Item_Image (Image_Hash,Image_Data)values(" + spar_Image_Hash + "," + spar_Image_Data + ")";
                    object oret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Item_Image_ID, ref oret, ref Err, "Item_Image"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Item_Image:Get:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Item_Image:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
        public static bool Get(Image Item_Image, ref long Item_Image_ID)
        {
            byte[] byteArrayImage = DBtypesFunc.imageToByteArray(Item_Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            string Image_Hash = DBtypesFunc.GetHash_SHA1(byteArrayImage);
            if (Get(Image_Hash, byteArrayImage, ref Item_Image_ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
