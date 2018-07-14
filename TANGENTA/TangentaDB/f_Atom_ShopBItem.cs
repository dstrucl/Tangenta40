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
using DBTypes;
using DBConnectionControl40;

namespace TangentaDB
{
    public static class f_Atom_ShopBItem
    {
        public static bool Get(ID SimpleItem_ID, ref ID Atom_SimpleItem_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select Atom_SimpleItem.ID
                            from Atom_SimpleItem
                            inner join Atom_SimpleItem_Name on Atom_SimpleItem.Atom_SimpleItem_Name_ID = Atom_SimpleItem_Name.ID
                            inner join SimpleItem on Atom_SimpleItem_Name.Abbreviation = SimpleItem.Abbreviation and
                                                  Atom_SimpleItem_Name.Name = SimpleItem.Name
                            left join SimpleItem_Image on SimpleItem.SimpleItem_Image_ID = SimpleItem_Image.ID
                            left join Atom_SimpleItem_Image on Atom_SimpleItem.Atom_SimpleItem_Image_ID = Atom_SimpleItem_Image.ID
                            where SimpleItem_Image.Image_Hash = Atom_SimpleItem_Image.Image_Hash and
                                  SimpleItem.ID = " + SimpleItem_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_SimpleItem_ID==null)
                    {
                        Atom_SimpleItem_ID = new ID();
                    }
                    Atom_SimpleItem_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                { 
                    ID SimpleItem_Image_id = null;
                    string s_Atom_SimpleItem_Image_id = "null";
                    string SimpleItem_Name = null;
                    string SimpleItem_Abbreviation = null;
                    long_v code_v = null;
                    if (Find_Name_Abbreviation_Code_ShopBItem_Image(SimpleItem_ID,ref SimpleItem_Name,ref SimpleItem_Abbreviation,ref code_v, ref SimpleItem_Image_id))
                    {
                        

                        if (ID.Validate(SimpleItem_Image_id))
                        {
                            ID Atom_SimpleItem_Image_id = null;
                            if (f_Atom_ShopBItem_Image.Get(SimpleItem_Image_id,ref Atom_SimpleItem_Image_id))
                            {
                                s_Atom_SimpleItem_Image_id = Atom_SimpleItem_Image_id.ToString();
                            }
                            else
                            {
                                return false;
                            }
                        }

                        ID Atom_SimpleItem_Name_ID = null;
                        if (f_Atom_ShopBItem_Name.Get(SimpleItem_Name, SimpleItem_Abbreviation, ref Atom_SimpleItem_Name_ID))
                        {

                            if (code_v == null)
                            {

                                sql = @"insert into Atom_SimpleItem (      SimpleItem_ID,
                                                                    Atom_SimpleItem_Name_ID,
                                                                    Atom_SimpleItem_Image_ID,
                                                                    Code
                                                                    ) 
                                                                    values
                                                                    (
                                                                     " + SimpleItem_ID.ToString() + @",
                                                                       " + Atom_SimpleItem_Name_ID.ToString() + @",
                                                                       " + s_Atom_SimpleItem_Image_id + @",
                                                                       null
                                                                      )";
                            }
                            else
                            {

                                sql = @"insert into Atom_SimpleItem (      SimpleItem_ID,
                                                                    Atom_SimpleItem_Name_ID,
                                                                    Atom_SimpleItem_Image_ID,
                                                                    Code
                                                                    ) 
                                                                    values
                                                                    (
                                                                     " + SimpleItem_ID.ToString() + @",
                                                                       " + Atom_SimpleItem_Name_ID.ToString() + @",
                                                                       " + s_Atom_SimpleItem_Image_id + @",
                                                                       " + code_v.v.ToString()+ @"
                                                                      )";
                            }


                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_SimpleItem_ID, ref Err, "Atom_SimpleItem"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:f_Atom_SimpleItem:Get:" + sql + "\r\nErr=" + Err);
                                return false;
                            }
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
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_SimpleItem:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        private static bool Find_Name_Abbreviation_Code_ShopBItem_Image(ID SimpleItem_ID, ref string Name,ref string Abbreviation,ref long_v code_v, ref ID SimpleItem_Image_id)
        {
            string Err = null;
            DataTable dt = new DataTable();
            code_v = null;
            string sql = "select Name,Abbreviation,Code,SimpleItem_Image_ID from SimpleItem where ID = " + SimpleItem_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    SimpleItem_Image_id.Set(dt.Rows[0]["SimpleItem_Image_ID"]);
                    Name = (string)dt.Rows[0]["Name"];
                    Abbreviation = (string)dt.Rows[0]["Abbreviation"];
                    if (dt.Rows[0]["Code"] is long)
                    {
                        code_v = new long_v((long)dt.Rows[0]["Code"]);
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:f_Atom_SimpleItem:Find_SimpleItem_Image:No SimpleItem_Image Data for SimpleItem.ID = " + SimpleItem_ID.ToString());
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_SimpleItem:Find_SimpleItem_Image:Err = " + Err);
                return false;
            }
        }
    }
}
