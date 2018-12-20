#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogFile;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_ShopBItem_Image
    {
        public static bool Get(ID SimpleItem_Image_ID, ref ID Atom_SimpleItem_Image_ID)
        {
            string Err=null;
            DataTable dt = new DataTable();
            string sql = @"select Atom_SimpleItem_Image.ID
                                                    from Atom_SimpleItem_Image
                                                    inner join SimpleItem_Image on SimpleItem_Image.Image_Hash = Atom_SimpleItem_Image.Image_Hash
                                                    where SimpleItem_Image.ID = " + SimpleItem_Image_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_SimpleItem_Image_ID==null)
                    {
                        Atom_SimpleItem_Image_ID = new ID();
                    }
                    Atom_SimpleItem_Image_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_SimpleItem_Image (Image_Hash,Image_Data) select Image_Hash,Image_Data from SimpleItem_Image where ID = "+SimpleItem_Image_ID.ToString();
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref Atom_SimpleItem_Image_ID, ref Err, "Atom_SimpleItem_Image"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_SimpleItem_Image:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_SimpleItem_Image:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
