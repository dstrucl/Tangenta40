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
    public static class f_Atom_Expiry
    {
        public static bool Get(int_v expiry_ExpectedShelfLifeInDays,
                            int_v expiry_SaleBeforeExpiryDateInDays,
                            int_v expiry_DiscardBeforeExpiryDateInDays,
                            string_v expiry_ExpiryDescription,
                            ref ID atom_Expiry_ID, ref string err)
        {
            string scond_ExpectedShelfLifeInDays = null;
            string sv_ExpectedShelfLifeInDays = null;
            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();
            if (expiry_ExpectedShelfLifeInDays != null)
            {
                string spar_ExpectedShelfLifeInDays = "@par_ExpectedShelfLifeInDays";
                DBConnectionControl40.SQL_Parameter par_ExpectedShelfLifeInDays = new DBConnectionControl40.SQL_Parameter(spar_ExpectedShelfLifeInDays, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, expiry_ExpectedShelfLifeInDays.v);
                lpar.Add(par_ExpectedShelfLifeInDays);
                scond_ExpectedShelfLifeInDays = "(ExpectedShelfLifeInDays = " + spar_ExpectedShelfLifeInDays + ")";
                sv_ExpectedShelfLifeInDays = spar_ExpectedShelfLifeInDays;
            }
            else
            {
                scond_ExpectedShelfLifeInDays = "(ExpectedShelfLifeInDays is null)";
                sv_ExpectedShelfLifeInDays = "null";
            }
            string scond_Expiry_SaleBeforeExpiryDateInDays = null;
            string sv_Expiry_SaleBeforeExpiryDateInDays = null;
            if (expiry_SaleBeforeExpiryDateInDays != null)
            {
                string spar_SaleBeforeExpiryDateInDays = "@par_SaleBeforeExpiryDateInDays";
                DBConnectionControl40.SQL_Parameter par_SaleBeforeExpiryDateInDays = new DBConnectionControl40.SQL_Parameter(spar_SaleBeforeExpiryDateInDays, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, expiry_SaleBeforeExpiryDateInDays.v);
                lpar.Add(par_SaleBeforeExpiryDateInDays);
                scond_Expiry_SaleBeforeExpiryDateInDays = "(SaleBeforeExpiryDateInDays = " + spar_SaleBeforeExpiryDateInDays + ")";
                sv_Expiry_SaleBeforeExpiryDateInDays = spar_SaleBeforeExpiryDateInDays;
            }
            else
            {
                scond_Expiry_SaleBeforeExpiryDateInDays = "(SaleBeforeExpiryDateInDays is null)";
                sv_Expiry_SaleBeforeExpiryDateInDays = "null";
            }

            string scond_Expiry_DiscardBeforeExpiryDateInDays = null;
            string sv_Expiry_DiscardBeforeExpiryDateInDays = null;
            if (expiry_DiscardBeforeExpiryDateInDays != null)
            {
                string spar_DiscardBeforeExpiryDateInDays = "@par_DiscardBeforeExpiryDateInDays";
                DBConnectionControl40.SQL_Parameter par_DiscardBeforeExpiryDateInDays = new DBConnectionControl40.SQL_Parameter(spar_DiscardBeforeExpiryDateInDays, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Int, false, expiry_DiscardBeforeExpiryDateInDays.v);
                lpar.Add(par_DiscardBeforeExpiryDateInDays);
                scond_Expiry_DiscardBeforeExpiryDateInDays = "(DiscardBeforeExpiryDateInDays = " + spar_DiscardBeforeExpiryDateInDays + ")";
                sv_Expiry_DiscardBeforeExpiryDateInDays = spar_DiscardBeforeExpiryDateInDays;
            }
            else
            {
                scond_Expiry_DiscardBeforeExpiryDateInDays = "(DiscardBeforeExpiryDateInDays is null)";
                sv_Expiry_DiscardBeforeExpiryDateInDays = "null";
            }

            string scond_Expiry_ExpiryDescription = null;
            string sv_Expiry_ExpiryDescription = null;
            if (expiry_ExpiryDescription != null)
            {
                string spar_ExpiryDescription = "@par_ExpiryDescription";
                DBConnectionControl40.SQL_Parameter par_ExpiryDescription = new DBConnectionControl40.SQL_Parameter(spar_ExpiryDescription, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varchar, false, expiry_ExpiryDescription.v);
                lpar.Add(par_ExpiryDescription);
                scond_Expiry_ExpiryDescription = "(ExpiryDescription = " + spar_ExpiryDescription + ")";
                sv_Expiry_ExpiryDescription = spar_ExpiryDescription;
            }
            else
            {
                scond_Expiry_ExpiryDescription = "(ExpiryDescription is null)";
                sv_Expiry_ExpiryDescription = "null";
            }

            string sql_select_Atom_Expiry_ID = @"select ID as Atom_Expiry_ID from Atom_Expiry where " + scond_ExpectedShelfLifeInDays + " and "
                                                                                                   + scond_Expiry_SaleBeforeExpiryDateInDays + " and "
                                                                                                   + scond_Expiry_DiscardBeforeExpiryDateInDays + " and "
                                                                                                   + scond_Expiry_ExpiryDescription;



            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql_select_Atom_Expiry_ID, lpar, ref err))
            {
                if (dt.Rows.Count > 0)
                {
                    if (atom_Expiry_ID == null)
                    {
                        atom_Expiry_ID = new ID();
                    }
                    atom_Expiry_ID.Set(dt.Rows[0]["Atom_Expiry_ID"]);
                    return true;
                }
                else
                {
                    string sql_Insert_Atom_Item_ExpiryDescription = @"insert into Atom_Expiry (ExpectedShelfLifeInDays,
                                                                                             SaleBeforeExpiryDateInDays,
                                                                                             DiscardBeforeExpiryDateInDays,
                                                                                             ExpiryDescription)values("
                                                                                             + sv_ExpectedShelfLifeInDays + ","
                                                                                             + sv_Expiry_SaleBeforeExpiryDateInDays + ","
                                                                                             + sv_Expiry_DiscardBeforeExpiryDateInDays + ","
                                                                                             + sv_Expiry_ExpiryDescription
                                                                                            + ")";
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_Insert_Atom_Item_ExpiryDescription, lpar, ref atom_Expiry_ID, ref err, "Atom_Expiry"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Expiry:Get:sql="+ sql_Insert_Atom_Item_ExpiryDescription + "\r\nErr=" + err);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:f_Atom_Expiry:Get:sql=" + sql_select_Atom_Expiry_ID + "\r\nErr=" + err);
                return false;
            }
        }
    }
}
