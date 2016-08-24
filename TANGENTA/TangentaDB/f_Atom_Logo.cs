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
    public static class f_Atom_Logo
    {
        public static bool Get(string_v Logo_Hash_v, byte_array_v Logo_v, string_v Logo_Description_v, ref long_v Atom_Logo_ID_v)
        {
            string Err = null;
            if (Logo_Hash_v == null)
            {
                Atom_Logo_ID_v = null;
                return true;
            }
            if (Atom_Logo_ID_v == null)
            {
                Atom_Logo_ID_v = new long_v();
            }
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string Image_Hash_Value = "null";
            string Image_Hash_cond = "Image_Hash is null";
            if (Logo_Hash_v != null)
            {
                if (Logo_Hash_v.v != null)
                {
                    Image_Hash_Value = "@par_Image_Hash";
                    Image_Hash_cond = "Image_Hash = " + Image_Hash_Value;
                    SQL_Parameter par_Image_Hash = new SQL_Parameter(Image_Hash_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Logo_Hash_v.v);
                    lpar.Add(par_Image_Hash);
                }
            }
            string Image_Data_Value = "null";
            if (Logo_v != null)
            {
                if (Logo_v.v != null)
                {
                    Image_Data_Value = "@par_Image_Data";

                    SQL_Parameter par_Image_Data = new SQL_Parameter(Image_Data_Value, SQL_Parameter.eSQL_Parameter.Varbinary, false, Logo_v.v);
                    lpar.Add(par_Image_Data);
                }
            }
            string Description_Value = "null";
            string Description_cond = "Description is null";
            if (Logo_Description_v != null)
            {
                if (Logo_Description_v.v != null)
                {
                    Description_Value = "@par_Description";
                    Description_cond = "Description = " + Description_Value;
                    SQL_Parameter par_Description = new SQL_Parameter(Description_Value, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Logo_Description_v.v);
                    lpar.Add(par_Description);
                }
            }
            string sql = " select ID, Image_Hash,Image_Data,Description from Atom_Logo where " + Image_Hash_cond + " and " + Description_cond;
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    Atom_Logo_ID_v.v = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                {
                    sql = " insert into Atom_Logo (Image_Hash,Image_Data,Description) values (" + Image_Hash_Value + "," + Image_Data_Value + "," + Description_Value + ")";
                    object oRet = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref Atom_Logo_ID_v.v_, ref oRet, ref Err, "Atom_Logo"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Logo:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Logo:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
