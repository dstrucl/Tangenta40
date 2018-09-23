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
    public static class f_Atom_Item_Image
    {
        public static bool Get(ID Atom_Item_ID, string_v Atom_Item_Image_Hash, byte_array_v Atom_Item_Image_Data, ref ID Atom_Item_Image_ID)
        {
            string Err = null;
            if (Atom_Item_Image_Hash != null)
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_Item_Image_Hash = "@par_Item_Image_Image_Hash";
                DBConnectionControl40.SQL_Parameter par_Item_Image_Hash = new DBConnectionControl40.SQL_Parameter(spar_Item_Image_Hash, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Atom_Item_Image_Hash.v);
                lpar.Add(par_Item_Image_Hash);
                string sql_select_Atom_Item_Item_Image_Hash_ID = @"select Atom_Item_Image.ID as Atom_Item_Image_ID from Atom_Item_Image inner join Atom_Item_ImageLib on Atom_Item_ImageLib.ID = Atom_Item_Image.Atom_Item_ImageLib_ID where (Atom_Item_ImageLib.Image_Hash = " + spar_Item_Image_Hash + ") and (Atom_Item_Image.Atom_Item_ID = " + Atom_Item_ID.ToString() + ")";
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_Item_Image_Hash_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_Item_Image_ID == null)
                        {
                            Atom_Item_Image_ID = new ID();
                        }
                        Atom_Item_Image_ID.Set(dt.Rows[0]["Atom_Item_Image_ID"]);
                        return true;
                    }
                    else
                    {
                        ID Atom_Item_ImageLib_ID = null;
                        string sql_select_Atom_Item_ImageLib_ID = @"select ID as Atom_Item_ImageLib_ID from Atom_Item_ImageLib where Atom_Item_ImageLib.Image_Hash = " + spar_Item_Image_Hash;
                        DataTable dt2 = new DataTable();
                        if (DBSync.DBSync.ReadDataTable(ref dt2, sql_select_Atom_Item_ImageLib_ID, lpar, ref Err))
                        {
                            if (dt2.Rows.Count > 0)
                            {
                                if (Atom_Item_ImageLib_ID == null)
                                {
                                    Atom_Item_ImageLib_ID = new ID();
                                }
                                Atom_Item_ImageLib_ID.Set(dt2.Rows[0]["Atom_Item_ImageLib_ID"]);
                            }
                            else
                            {
                                string spar_Item_Image_Data = "@par_Item_Image_Image_Data";
                                DBConnectionControl40.SQL_Parameter par_Item_Image_Data = new DBConnectionControl40.SQL_Parameter(spar_Item_Image_Data, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varbinary, false, Atom_Item_Image_Data.v);
                                lpar.Add(par_Item_Image_Data);
                                string sql_Insert_Atom_Item_Item_Image_Hash = @"insert into Atom_Item_ImageLib (Image_Hash,Image_Data)values(" + spar_Item_Image_Hash + "," + spar_Item_Image_Data + ")";
                                if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Item_Image_Hash, lpar, ref Atom_Item_ImageLib_ID, ref Err, "Atom_Item_ImageLib"))
                                {
                                    LogFile.Error.Show("ERROR:Get_Atom_Item_Image:insert into Atom_Item_ImageLib failed!\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_Image:select ID as Atom_Item_ImageLib_ID from Atom_Item_ImageLib failed!\r\nErr=" + Err);
                            return false;
                        }
                        string sql_Insert_Atom_Item_Image = @"insert into Atom_Item_Image (Atom_Item_ID,Atom_Item_ImageLib_ID)values(" + Atom_Item_ID.ToString() + "," + Atom_Item_ImageLib_ID.ToString() + ")";
                        if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Image, null, ref Atom_Item_Image_ID, ref Err, "Atom_Item_Image"))
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_Image:insert into Atom_Item_ImageLib failed!\r\nErr=" + Err);
                            return false;
                        }
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Get_Atom_Item_Image:select ID as Atom_Item_Image_ID from Atom_Item_Image failed!\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
