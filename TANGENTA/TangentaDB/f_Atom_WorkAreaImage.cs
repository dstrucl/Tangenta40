#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public static class f_Atom_WorkAreaImage
    {
        public static bool Get(string_v WorkAreaImage_Hash_v, byte_array_v WorkAreaImage_v, string_v WorkAreaImage_Description_v, ref ID Atom_WorkAreaImage_ID)
        {
            string Err = null;
            if (WorkAreaImage_Hash_v == null)
            {
                Atom_WorkAreaImage_ID = null;
                return true;
            }
            if (Atom_WorkAreaImage_ID == null)
            {
                Atom_WorkAreaImage_ID = new ID();
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Image_Hash_Value = "null";
            string Image_Hash_cond = "Image_Hash is null";
            if (WorkAreaImage_Hash_v != null)
            {
                if (WorkAreaImage_Hash_v.v != null)
                {
                    Image_Hash_Value = "@par_Image_Hash";
                    Image_Hash_cond = "Image_Hash = " + Image_Hash_Value;
                    SQL_Parameter par_Image_Hash = new SQL_Parameter(Image_Hash_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, WorkAreaImage_Hash_v.v);
                    lpar.Add(par_Image_Hash);
                }
            }
            string Image_Data_Value = "null";
            if (WorkAreaImage_v != null)
            {
                if (WorkAreaImage_v.v != null)
                {
                    Image_Data_Value = "@par_Image_Data";

                    SQL_Parameter par_Image_Data = new SQL_Parameter(Image_Data_Value, SQL_Parameter.eSQL_Parameter.Varbinary, false, WorkAreaImage_v.v);
                    lpar.Add(par_Image_Data);
                }
            }
            string Description_Value = "null";
            string Description_cond = "Description is null";
            if (WorkAreaImage_Description_v != null)
            {
                if (WorkAreaImage_Description_v.v != null)
                {
                    Description_Value = "@par_Description";
                    Description_cond = "Description = " + Description_Value;
                    SQL_Parameter par_Description = new SQL_Parameter(Description_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, WorkAreaImage_Description_v.v);
                    lpar.Add(par_Description);
                }
            }
            string sql = " select ID, Image_Hash,Image_Data,Description from Atom_WorkAreaImage where " + Image_Hash_cond + " and " + Description_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_WorkAreaImage_ID = tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = " insert into Atom_WorkAreaImage (Image_Hash,Image_Data,Description) values (" + Image_Hash_Value + "," + Image_Data_Value + "," + Description_Value + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref Atom_WorkAreaImage_ID, ref Err, "Atom_WorkAreaImage"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_WorkAreaImage:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_WorkAreaImage:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
