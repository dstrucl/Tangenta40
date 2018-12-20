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
    public static class f_Atom_Unit
    {
        public static bool Get(string_v unit_Name_v,
                              string_v unit_Symbol_v,
                              int_v unit_DecimalPlaces_v,
                              bool_v unit_StorageOption_v,
                              string_v unit_Description_v,
                               ref ID Atom_Unit_ID)
        {
            string Err = null;
            string scond_Unit_Name = null;
            string sv_Unit_Name = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            if (unit_Name_v != null)
            {
                string spar_Unit_Name = "@par_Unit_Name";
                DBConnectionControl40.SQL_Parameter par_Unit_Name = new DBConnectionControl40.SQL_Parameter(spar_Unit_Name, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, unit_Name_v.v);
                lpar.Add(par_Unit_Name);
                scond_Unit_Name = "(Name = " + spar_Unit_Name + ")";
                sv_Unit_Name = spar_Unit_Name;
            }
            else
            {
                scond_Unit_Name = "(Name is null)";
                sv_Unit_Name = "null";
            }

            string scond_Unit_Symbol = null;
            string sv_Unit_Symbol = null;
            if (unit_Symbol_v != null)
            {
                string spar_Unit_Symbol = "@par_Unit_Symbol";
                DBConnectionControl40.SQL_Parameter par_Unit_Symbol = new DBConnectionControl40.SQL_Parameter(spar_Unit_Symbol, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, unit_Symbol_v.v);
                lpar.Add(par_Unit_Symbol);
                scond_Unit_Symbol = "(Symbol = " + spar_Unit_Symbol + ")";
                sv_Unit_Symbol = spar_Unit_Symbol;
            }
            else
            {
                scond_Unit_Symbol = "(Symbol is null)";
                sv_Unit_Symbol = "null";
            }

            string scond_Unit_DecimalPlaces = null;
            string sv_Unit_DecimalPlaces = null;
            if (unit_DecimalPlaces_v != null)
            {
                string spar_Unit_DecimalPlaces = "@par_Unit_DecimalPlaces";
                DBConnectionControl40.SQL_Parameter par_DiscardBeforeExpiryDateInDays = new DBConnectionControl40.SQL_Parameter(spar_Unit_DecimalPlaces, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, unit_DecimalPlaces_v.v);
                lpar.Add(par_DiscardBeforeExpiryDateInDays);
                scond_Unit_DecimalPlaces = "(DecimalPlaces = " + spar_Unit_DecimalPlaces + ")";
                sv_Unit_DecimalPlaces = spar_Unit_DecimalPlaces;
            }
            else
            {
                scond_Unit_DecimalPlaces = "(DecimalPlaces is null)";
                sv_Unit_DecimalPlaces = "null";
            }

            string scond_Unit_StorageOption = null;
            string sv_Unit_StorageOption = null;
            if (unit_StorageOption_v != null)
            {
                string spar_ExpiryDescription = "@par_StorageOption";
                DBConnectionControl40.SQL_Parameter par_ExpiryDescription = new DBConnectionControl40.SQL_Parameter(spar_ExpiryDescription, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Bit, false, unit_StorageOption_v.v);
                lpar.Add(par_ExpiryDescription);
                scond_Unit_StorageOption = "(StorageOption = " + spar_ExpiryDescription + ")";
                sv_Unit_StorageOption = spar_ExpiryDescription;
            }
            else
            {
                scond_Unit_StorageOption = "(StorageOption is null)";
                sv_Unit_StorageOption = "null";
            }

            string scond_Unit_Description = null;
            string sv_Unit_Description = null;
            if (unit_Description_v != null)
            {
                string spar_Unit_Description = "@par_Unit_Description";
                DBConnectionControl40.SQL_Parameter par_Unit_Description = new DBConnectionControl40.SQL_Parameter(spar_Unit_Description, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, unit_Description_v.v);
                lpar.Add(par_Unit_Description);
                scond_Unit_Description = "(Description = " + spar_Unit_Description + ")";
                sv_Unit_Description = spar_Unit_Description;
            }
            else
            {
                scond_Unit_Description = "(Description is null)";
                sv_Unit_Description = "null";
            }
            string sql_select_Atom_Unit_ID = @"select ID as Atom_Unit_ID from Atom_Unit where " + scond_Unit_Name + " and "
                                                                                                   + scond_Unit_Symbol + " and "
                                                                                                   + scond_Unit_DecimalPlaces + " and "
                                                                                                   + scond_Unit_StorageOption + " and "
                                                                                                   + scond_Unit_Description;



            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Unit_ID, lpar, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (Atom_Unit_ID == null)
                    {
                        Atom_Unit_ID = new ID();
                    }
                    Atom_Unit_ID.Set(dt.Rows[0]["Atom_Unit_ID"]);
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_Unit = @"insert into Atom_Unit (Name,
                                                                                             Symbol,
                                                                                             DecimalPlaces,
                                                                                             StorageOption,
                                                                                             Description
                                                                                            )
                                                                                            values
                                                                                            ("
                                                                                             + sv_Unit_Name + ","
                                                                                             + sv_Unit_Symbol + ","
                                                                                             + sv_Unit_DecimalPlaces + ","
                                                                                             + sv_Unit_StorageOption + ","
                                                                                             + sv_Unit_Description
                                                                                            + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql_Insert_Atom_Unit, lpar, ref Atom_Unit_ID, ref Err, "Atom_Unit"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Unit:Get:sql="+ sql_Insert_Atom_Unit + "\r\nErr=" + Err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Unit:Get:sql="+ sql_select_Atom_Unit_ID + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
