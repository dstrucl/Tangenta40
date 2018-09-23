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
using DBTypes;

namespace TangentaDB
{
    public static class f_Atom_Taxation
    {
        public static bool Get(ID Taxation_ID, ref ID Atom_Taxation_ID)
        {
            string Err = null;
            DataTable dt = new DataTable();
            string sql = @"select Atom_Taxation.ID
                                                    from Atom_Taxation
                                                    inner join Taxation on Taxation.Name = Atom_Taxation.Name
                                                                           and Taxation.Rate = Atom_Taxation.Rate
                                                    where Taxation.ID = " + Taxation_ID.ToString();

            if (DBSync.DBSync.ReadDataTable(ref dt, sql, null, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Taxation_ID==null)
                    {
                        Atom_Taxation_ID = new ID();
                    }
                    Atom_Taxation_ID.Set(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = @"insert into Atom_Taxation (Name,Rate) select Name,Rate from Taxation where ID = " + Taxation_ID.ToString();
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref Atom_Taxation_ID,  ref Err, "Atom_Taxation"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:f_Atom_Taxation:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:f_Atom_Taxation:Get:" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public static bool Get(string_v Taxation_Name, decimal_v Taxation_Rate, ref ID Atom_Taxation_ID)
        {
            string Err = null;
            if ((Taxation_Name != null) && (Taxation_Rate != null))
            {
                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
                string spar_Taxation_Name = "@par_Taxation_Name";
                DBConnectionControl40.SQL_Parameter par_Taxation_Name = new DBConnectionControl40.SQL_Parameter(spar_Taxation_Name, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, Taxation_Name.v);
                lpar.Add(par_Taxation_Name);
                string spar_Taxation_Rate = "@par_Taxation_Rate";
                DBConnectionControl40.SQL_Parameter par_Taxation_Rate = new DBConnectionControl40.SQL_Parameter(spar_Taxation_Rate, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, Taxation_Rate.v);
                lpar.Add(par_Taxation_Rate);
                string sql_select_Atom_Item_barcode_ID = @"select ID as Atom_Taxation_ID from Atom_Taxation where Name = " + spar_Taxation_Name + " and Rate = " + spar_Taxation_Rate;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Item_barcode_ID, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (Atom_Taxation_ID == null)
                        {
                            Atom_Taxation_ID = new ID();
                        }
                        Atom_Taxation_ID.Set(dt.Rows[0]["Atom_Taxation_ID"]);
                        return true;
                    }
                    else
                    {
                        string sql_Insert_Atom_Item_Taxation = @"insert into Atom_Taxation (Name,Rate)values(" + spar_Taxation_Name + "," + spar_Taxation_Rate + ")";
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_Taxation, lpar, ref Atom_Taxation_ID, ref Err, "Atom_Taxation"))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Get_Atom_Item_Taxation:insert into Atom_Taxation failed!\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Get_Atom_Item_Taxation:select ID as Atom_Taxation_ID from Atom_Taxation failed!\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                Err = "ERROR:Get_Atom_Item_Taxation:Taxation_Name can not be null!";
                LogFile.Error.Show(Err);
                return false;
            }
        }
    }
}
