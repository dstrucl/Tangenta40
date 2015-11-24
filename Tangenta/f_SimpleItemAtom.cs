using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogFile;
using DBTypes;

namespace Tangenta
{
    public static class f_Atom_SimpleItem
    {
        internal static bool Get(long SimpleItem_ID, ref long Atom_SimpleItem_ID)
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
                    Atom_SimpleItem_ID = (long)dt.Rows[0]["ID"];
                    return true;
                }
                else
                { 
                    long_v SimpleItem_Image_id = null;
                    string s_Atom_SimpleItem_Image_id = "null";
                    string SimpleItem_Name = null;
                    string SimpleItem_Abbreviation = null;
                    if (Find_Name_Abbreviation_SimpleItem_Image(SimpleItem_ID,ref SimpleItem_Name,ref SimpleItem_Abbreviation,ref SimpleItem_Image_id))
                    {
                        

                        if (SimpleItem_Image_id!=null)
                        {
                            long Atom_SimpleItem_Image_id = -1;
                            if (f_Atom_SimpleItem_Image.Get(SimpleItem_Image_id.v,ref Atom_SimpleItem_Image_id))
                            {
                                s_Atom_SimpleItem_Image_id = Atom_SimpleItem_Image_id.ToString();
                            }
                            else
                            {
                                return false;
                            }
                        }

                        long Atom_SimpleItem_Name_ID = -1;
                        if (f_Atom_SimpleItem_Name.Get(SimpleItem_Name, SimpleItem_Abbreviation, ref Atom_SimpleItem_Name_ID))
                        {


                            sql = @"insert into Atom_SimpleItem (      SimpleItem_ID,
                                                                    Atom_SimpleItem_Name_ID,
                                                                    Atom_SimpleItem_Image_ID
                                                                    ) 
                                                                    values
                                                                    (
                                                                     "  +SimpleItem_ID.ToString() +@",
                                                                       " +Atom_SimpleItem_Name_ID.ToString()+@",
                                                                       " +s_Atom_SimpleItem_Image_id + @"
                                                                      )";
                                                                    



                            object objretx = null;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_SimpleItem_ID, ref objretx, ref Err, "Atom_SimpleItem"))
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


        private static bool Find_Name_Abbreviation_SimpleItem_Image(long SimpleItem_ID, ref string Name,ref string Abbreviation, ref long_v SimpleItem_Image_id)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = "select Name,Abbreviation,SimpleItem_Image_ID from SimpleItem where ID = " + SimpleItem_ID.ToString();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    object oAtom_SimpleItem_ID = dt.Rows[0]["SimpleItem_Image_ID"];
                    if (oAtom_SimpleItem_ID.GetType() == typeof(long))
                    {
                        SimpleItem_Image_id = new long_v();
                        SimpleItem_Image_id.v = (long)oAtom_SimpleItem_ID;
                    }
                    Name = (string)dt.Rows[0]["Name"];
                    Abbreviation = (string)dt.Rows[0]["Abbreviation"];
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
