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
    public static class f_Atom_Price_Item
    {
        public static bool Get(string item_uniqueName,
                        string_v item_Name_v,
                        string_v item_barcode_v,
                        string_v item_Description_v,
                        int_v expiry_ExpectedShelfLifeInDays_v,
                        int_v expiry_SaleBeforeExpiryDateInDays_v,
                        int_v expiry_DiscardBeforeExpiryDateInDays_v,
                        string_v expiry_ExpiryDescription_v,
                        short_v warranty_DurationType_v,
                        int_v warrantyDuration_v,
                        string_v warrantyConditions_v,
                        string_v unit_Name_v,
                        string_v unit_Symbol_v,
                        int_v unit_DecimalPlaces_v,
                        bool_v unit_StorageOption_v,
                        string_v unit_Description_v,
                        string_v priceListName_v,
                        string_v currencyAbbreviation_v,
                        string_v currencyName_v,
                        string_v item_Image_Hash_v,
                        byte_array_v item_Image_Data_v,
                        decimal_v retailPricePerUnit_v,
                        decimal_v discunt_v,
                        string_v taxationName_v,
                        decimal_v taxationRate_v,
                        ref ID atom_Taxation_ID,
                        ref ID atom_Item_ID,
                        ref ID atom_Price_Item_ID)
        {


            if (f_Atom_Taxation.Get(taxationName_v, taxationRate_v, ref atom_Taxation_ID))
            {
                if (ID.Validate(atom_Taxation_ID))
                {
                    string scond_Atom_Taxation_ID = " Atom_Taxation_ID = " + atom_Taxation_ID.ToString();
                    ID atom_Unit_ID = null;
                    ID atom_Expiry_ID = null;
                    ID atom_Warranty_ID = null;

                    if (f_Atom_Item.Get(item_uniqueName,
                                        item_Name_v,
                                        item_barcode_v,
                                        item_Description_v,
                                        expiry_ExpectedShelfLifeInDays_v,
                                        expiry_SaleBeforeExpiryDateInDays_v,
                                        expiry_DiscardBeforeExpiryDateInDays_v,
                                        expiry_ExpiryDescription_v,
                                        warranty_DurationType_v,
                                        warrantyDuration_v,
                                        warrantyConditions_v,
                                        unit_Name_v,
                                        unit_Symbol_v,
                                        unit_DecimalPlaces_v,
                                        unit_StorageOption_v,
                                        unit_Description_v,
                                        ref  atom_Unit_ID,
                                        ref  atom_Expiry_ID,
                                        ref  atom_Warranty_ID,
                                        ref  atom_Item_ID
                                        ))
                    {
                        string scond_Atom_Item_ID = " Atom_Item_ID = " + atom_Item_ID.ToString();
                        ID atom_PriceList_ID = null;
                        if (f_Atom_PriceList.Get(priceListName_v,
                                                currencyAbbreviation_v,
                                                currencyName_v,
                                                ref atom_PriceList_ID))
                        {
                            if (ID.Validate(atom_PriceList_ID))
                            {
                                ID atom_Item_Image_ID = null;
                                f_Atom_Item_Image.Get(atom_Item_ID, item_Image_Hash_v, item_Image_Data_v, ref atom_Item_Image_ID);


                                string scond_Atom_PriceList_ID = " Atom_PriceList_ID = " + atom_PriceList_ID.ToString();

                                List<DBConnectionControl40.SQL_Parameter> lpar = new List<DBConnectionControl40.SQL_Parameter>();


                                string spar_RetailPricePerUnit = "@par_RetailPricePerUnit";
                                DBConnectionControl40.SQL_Parameter par_RetailPricePerUnit = new DBConnectionControl40.SQL_Parameter(spar_RetailPricePerUnit, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, retailPricePerUnit_v.v);
                                lpar.Add(par_RetailPricePerUnit);

                                string spar_Discount = "@par_Discount";
                                DBConnectionControl40.SQL_Parameter par_Discount = new DBConnectionControl40.SQL_Parameter(spar_Discount, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Decimal, false, discunt_v.v);
                                lpar.Add(par_Discount);


                                string sql = @"select ID as Atom_Price_Item_ID 
                                                      from Atom_Price_Item 
                                                            where
                                                           RetailPricePerUnit = " + spar_RetailPricePerUnit + @" and
                                                           Discount = " + spar_Discount + @" and
                                                           " + scond_Atom_Taxation_ID + @" and
                                                           " + scond_Atom_Item_ID + @" and
                                                           " + scond_Atom_PriceList_ID;



                                DataTable dt = new DataTable();
                                string Err = null;
                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        atom_Price_Item_ID = tf.set_ID(dt.Rows[0]["Atom_Price_Item_ID"]);
                                        return true;
                                    }
                                    else
                                    {

                                        sql = @"insert into Atom_Price_Item 
                                                                (RetailPricePerUnit,
                                                                 Discount,
                                                                 Atom_Taxation_ID,
                                                                 Atom_Item_ID, 
                                                                 Atom_PriceList_ID
                                                                )   values("
                                                                              + spar_RetailPricePerUnit + ",\r\n"
                                                                              + spar_Discount + ",\r\n"
                                                                              + atom_Taxation_ID.ToString() + ",\r\n"
                                                                              + atom_Item_ID.ToString() + ",\r\n"
                                                                              + atom_PriceList_ID.ToString()
                                                                              + ")";



                                        if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar, ref atom_Price_Item_ID, ref Err, "Atom_Price_Item"))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }


                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:No Atom_PriceList_ID is not defined !");
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
                else
                {
                    LogFile.Error.Show("ERROR:CurrentInvoice:Get_Atom_Price_Item:No Atom_Item_Taxation_ID is not defined !");
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
