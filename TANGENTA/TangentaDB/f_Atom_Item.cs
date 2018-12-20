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
    public static class f_Atom_Item
    {
        public static bool Get(string uniqueName,
                              string_v item_Name_v,
                              string_v  item_barcode_v,
                              string_v  item_Description_v,
                              int_v     expiry_ExpectedShelfLifeInDays_v,
                              int_v     expiry_SaleBeforeExpiryDateInDays_v,
                              int_v     expiry_DiscardBeforeExpiryDateInDays_v,
                              string_v  expiry_ExpiryDescription_v,
                              short_v   warranty_DurationType_v,
                              int_v     warrantyDuration_v,
                              string_v  warrantyConditions_v,
                              string_v  unit_Name_v,
                              string_v  unit_Symbol_v,
                              int_v     unit_DecimalPlaces_v,
                              bool_v    unit_StorageOption_v,
                              string_v  unit_Description_v,
                               ref ID atom_Unit_ID,
                               ref ID atom_Expiry_ID,
                               ref ID atom_Warranty_ID,
                               ref ID atom_Item_ID,
                               Transaction transaction
                               )
        {
            string Err = null;
            ID Atom_Item_Name_ID = null;

            string scond_Atom_Item_Name_ID = "(Atom_Item_Name_ID is null)";
            string sv_Atom_Item_Name_ID = " null";

            List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();

            if (item_Name_v != null)
            {
                if (f_Atom_Item_Name.Get(item_Name_v, ref Atom_Item_Name_ID, transaction))
                {
                    if (ID.Validate(Atom_Item_Name_ID))
                    {
                        string spar_Atom_Item_Name_ID = "@par_Atom_Item_Name_ID";
                        DBConnectionControl40.SQL_Parameter par_Atom_Item_Name_ID = new DBConnectionControl40.SQL_Parameter(spar_Atom_Item_Name_ID, false, Atom_Item_Name_ID);
                        lpar.Add(par_Atom_Item_Name_ID);
                        scond_Atom_Item_Name_ID = "(Atom_Item_Name_ID = @par_Atom_Item_Name_ID)";
                        sv_Atom_Item_Name_ID = " @par_Atom_Item_Name_ID ";
                    }
                }
            }


            string sAtom_Unit_ID = null;

            if (f_Atom_Unit.Get(unit_Name_v,
                              unit_Symbol_v,
                              unit_DecimalPlaces_v,
                              unit_StorageOption_v,
                              unit_Description_v,
                              ref atom_Unit_ID,
                              transaction))
            {

                if (ID.Validate(atom_Unit_ID))
                {
                    string scond_UniqueName = null;
                    string sv_UniqueName = null;

                    string spar_UniqueName = "@par_UniqueName";
                    DBConnectionControl40.SQL_Parameter par_UniqueName = new DBConnectionControl40.SQL_Parameter(spar_UniqueName, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Nvarchar, false, uniqueName);
                    lpar.Add(par_UniqueName);
                    scond_UniqueName = "(UniqueName = @par_UniqueName)";
                    sv_UniqueName = spar_UniqueName;

                    sAtom_Unit_ID = atom_Unit_ID.ToString();
                    ID atom_Item_barcode_ID = null;
                    string scond_Atom_Item_barcode_ID = null;
                    string sv_Atom_Item_barcode_ID = null;
                    if (f_Atom_Item_barcode.Get(item_barcode_v, ref atom_Item_barcode_ID, ref Err, transaction))
                    {
                        if (ID.Validate(atom_Item_barcode_ID))
                        {
                            scond_Atom_Item_barcode_ID = "(Atom_Item_barcode_ID = " + atom_Item_barcode_ID.ToString() + ")";
                            sv_Atom_Item_barcode_ID = atom_Item_barcode_ID.ToString();
                        }
                        else
                        {
                            scond_Atom_Item_barcode_ID = "(Atom_Item_barcode_ID is null)";
                            sv_Atom_Item_barcode_ID = "null";
                        }
                    }
                    ID Atom_Item_Description_ID = null;
                    string scond_Atom_Item_Description_ID = null;
                    string sv_Atom_Item_Description_ID = null;
                    if (f_Atom_Item_Description.Get(item_Description_v, ref Atom_Item_Description_ID, ref Err, transaction))
                    {
                        if (ID.Validate(Atom_Item_Description_ID))
                        {
                            scond_Atom_Item_Description_ID = "(Atom_Item_Description_ID = " + Atom_Item_Description_ID.ToString() + ")";
                            sv_Atom_Item_Description_ID = Atom_Item_Description_ID.ToString();
                        }
                        else
                        {
                            scond_Atom_Item_Description_ID = "(Atom_Item_Description_ID is null)";
                            sv_Atom_Item_Description_ID = "null";
                        }
                    }

                    string scond_Atom_Expiry_ID = null;
                    string sv_Atom_Expiry_ID = null;
                    if (expiry_ExpectedShelfLifeInDays_v != null)
                    {
                        if (f_Atom_Expiry.Get(expiry_ExpectedShelfLifeInDays_v,
                                              expiry_SaleBeforeExpiryDateInDays_v,
                                              expiry_DiscardBeforeExpiryDateInDays_v,
                                               expiry_ExpiryDescription_v,
                                            ref atom_Expiry_ID, ref Err, transaction))
                        {
                            scond_Atom_Expiry_ID = "(Atom_Expiry_ID = " + atom_Expiry_ID.ToString() + ")";
                            sv_Atom_Expiry_ID = atom_Expiry_ID.ToString();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        scond_Atom_Expiry_ID = "(Atom_Expiry_ID is null)";
                        sv_Atom_Expiry_ID = "null";
                    }

                    string scond_Atom_Warranty_ID = null;
                    string sv_Atom_Warranty_ID = null;
                    if (warranty_DurationType_v!=null)
                    {
                        if (f_Atom_Warranty.Get(warranty_DurationType_v, warrantyDuration_v, warrantyConditions_v, ref atom_Warranty_ID, ref Err, transaction))
                        {
                            scond_Atom_Warranty_ID = "(Atom_Warranty_ID = " + atom_Warranty_ID.ToString() + ")";
                            sv_Atom_Warranty_ID = atom_Warranty_ID.ToString();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        scond_Atom_Warranty_ID = "(Atom_Warranty_ID is null)";
                        sv_Atom_Warranty_ID = "null";

                    }


                    string sql = @"select ID as Atom_Item_ID from Atom_Item 
                                                    where
                                                    " + scond_Atom_Item_Name_ID + @" and
                                                    " + scond_UniqueName + @" and
                                                    " + scond_Atom_Item_barcode_ID + @" and
                                                    " + scond_Atom_Item_Description_ID + @" and
                                                    " + scond_Atom_Warranty_ID + @" and
                                                    " + scond_Atom_Expiry_ID;



                    DataTable dt = new DataTable();

                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                    {
                        if (dt.Rows.Count > 0)
                        {
                            atom_Item_ID= tf.set_ID(dt.Rows[0]["Atom_Item_ID"]);
                            return true;
                        }
                        else
                        {
                            sql = @"insert into Atom_Item 
                                    (
                                        UniqueName,
                                        Atom_Item_Name_ID,
                                        Atom_Unit_ID,
                                        Atom_Item_barcode_ID,
                                        Atom_Item_Description_ID,
                                        Atom_Warranty_ID,
                                        Atom_Expiry_ID
                                    )   values("
                                    + sv_UniqueName + ",\r\n"
                                    + sv_Atom_Item_Name_ID + ",\r\n"
                                    + sAtom_Unit_ID + ",\r\n"
                                    + sv_Atom_Item_barcode_ID + ",\r\n"
                                    + sv_Atom_Item_Description_ID + ",\r\n"
                                    + sv_Atom_Warranty_ID + ",\r\n"
                                    + sv_Atom_Expiry_ID
                                    + ")";

                            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref atom_Item_ID, ref Err, "Atom_Item"))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:f_Atom__Item:Get:"+sql+"\r\nErr=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {

                        LogFile.Error.Show("ERROR:TangentaDB:f_Atom__Item:Get:" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Get_Atom_Item:Atom_Unit_ID not found!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
