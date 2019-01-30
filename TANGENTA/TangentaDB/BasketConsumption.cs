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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TangentaDB
{
    public class BasketConsumption
    {
        public enum eCopy_Consumption_ShopC_Item_Result { OK, ERROR_NO_ITEM_IN_DB, ERROR_DB };

        public delegate bool deleagate_Select_Items_From_Stock_Dialog(DataTable xdt_ShopC_Item_In_Stock,
                                                                    decimal dQuantityToTake,
                                                                    ref List<CStock_Data> taken_form_stock,
                                                                    ref decimal dQuantitySelected);

        public delegate bool delegate_Select_ShopC_Item_in_Stock(string DocTyp,
                                                                  DataTable dt_ShopC_Item_in_Stock,
                                                                  Consumption_ShopC_Item xdsci,
                                                                  ref decimal dQuantitySelected, 
                                                                  ref bool bOK);

        public delegate void delegate_Item_Not_InOffer(ShopC_Item shopC_Item);

        public List<Consumption_ShopC_Item> Basket_Consumption_ShopC_Item_LIST = null;
        public DataTable dtDraft_Doc_Consumption_ShopC_Item = null;

        public BasketConsumption()
        {
            Basket_Consumption_ShopC_Item_LIST = new List<Consumption_ShopC_Item>();
            dtDraft_Doc_Consumption_ShopC_Item = new DataTable();
        }

        public bool Empty(ID doc_ID,string DocTyp,ShopShelfConsumption xShopShelf, Transaction transaction)
        {
            while (Basket_Consumption_ShopC_Item_LIST.Count > 0)
            {
                Consumption_ShopC_Item xdsci = (Consumption_ShopC_Item)Basket_Consumption_ShopC_Item_LIST[0];
                if (xdsci.dQuantity_FromStock > 0)
                {
                    CItem_Data xData = xShopShelf.Get_Item_Data(xdsci);
                    if (xData != null)
                    {
                        if (!RemoveFromBasket_And_put_back_to_Stock(DocTyp, doc_ID, xdsci.dQuantity_FromStock, xData,transaction))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:Basket:Empty: Item_Data == null!");
                        return false;
                    }
                    //Remove_and_put_back_to_ShopShelf(xAtom_WorkPeriod_ID,DocTyp, xdsci, xShopShelf);
                }
                if (xdsci.dQuantity_FromFactory > 0)
                {
                    if (!RemoveFactory(DocTyp, xdsci, transaction))
                    {
                        return false;
                    }
                }
                Basket_Consumption_ShopC_Item_LIST.Remove(xdsci);
            }
            return true;
        }

        /// <summary>
        /// Gets ShopC Items of Consumption_ID
        /// </summary>
        /// <param name="xDocTyp">prefix string of Consumption or DocProformaInvoice table (can be:"Consumption" and "DocProformaInvoice")</param>
        /// <param name="Doc_ID">ID of row in Consumption or DocProformaInvoice table)</param>
        /// <param name="xConsumption_ShopC_Item_LIST">output list of  item objects</param>
        /// <returns>Return true if no DB error
        ///</returns>
        public bool Read_Consumption_ShopC_Item_Table(string xDocTyp,ID xDoc_ID, ref List<Consumption_ShopC_Item> xConsumption_ShopC_Item_LIST, Transaction transaction)
        {
            string Err = null;
            string sql_select_Consumption_ShopC_Item = null;
            if (xDocTyp.Equals(GlobalData.const_ConsumptionAll))
            {
                sql_select_Consumption_ShopC_Item =
                //@"
                //SELECT 
                //disi.ID as Consumption_ShopC_Item_ID,
                //disi.Consumption_ID,
                //disi.Atom_Price_Item_ID,       
                //disis.Stock_ID,
                //Atom_Item.ID as Atom_Item_ID,
                //itm.ID as Item_ID,
                //Atom_Price_Item.RetailPricePerUnit,
                //Atom_Price_Item.Discount,
                //disis.RetailPriceWithDiscount,
                //disis.TaxPrice,
                //disis.ExtraDiscount,
                //disis.dQuantity,
                //disis.ExpiryDate,
                //Atom_Item.UniqueName AS Atom_Item_UniqueName,
                //Atom_Item_Name.Name AS Atom_Item_Name_Name,
                //Atom_Item_barcode.barcode AS Atom_Item_barcode_barcode,
                //Atom_Taxation.Name AS Atom_Taxation_Name,
                //Atom_Taxation.Rate AS Atom_Taxation_Rate,
                //Atom_Item_Description.Description AS Atom_Item_Description_Description,
                //Atom_Item.Atom_Warranty_ID,
                //Atom_Warranty.WarrantyDurationType AS Atom_Warranty_WarrantyDurationType,
                //Atom_Warranty.WarrantyDuration AS Atom_Warranty_WarrantyDuration,
                //Atom_Warranty.WarrantyConditions AS Atom_Warranty_WarrantyConditions,
                //Atom_Item.Atom_Expiry_ID,
                //Atom_Expiry.ExpectedShelfLifeInDays AS Atom_Expiry_ExpectedShelfLifeInDays,
                //Atom_Expiry.SaleBeforeExpiryDateInDays AS Atom_Expiry_SaleBeforeExpiryDateInDays,
                //Atom_Expiry.DiscardBeforeExpiryDateInDays AS Atom_Expiry_DiscardBeforeExpiryDateInDays,
                //Atom_Expiry.ExpiryDescription AS Atom_Expiry_ExpiryDescription,
                //puitms.Item_ID AS Stock_Item_ID,
                //Stock.ImportTime AS Stock_ImportTime,
                //Stock.dQuantity AS Stock_dQuantity,
                //Stock.ExpiryDate AS Stock_ExpiryDate,
                //Atom_Unit.Name AS Atom_Unit_Name,
                //Atom_Unit.Symbol AS Atom_Unit_Symbol,
                //Atom_Unit.DecimalPlaces AS Atom_Unit_DecimalPlaces,
                //Atom_Unit.Description AS Atom_Unit_Description,
                //Atom_Unit.StorageOption AS Atom_Unit_StorageOption,
                //Atom_PriceList_Name.Name AS Atom_PriceList_Name,
                //Atom_Currency.Name AS Atom_Currency_Name,
                //Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                //Atom_Currency.Symbol AS Atom_Currency_Symbol,
                //Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces,
                //aiil.Image_Hash as Atom_Item_Image_Hash,
                //aiil.Image_Data as Atom_Item_Image_Data,
                //itm_g1.Name as s1_name,
                //itm_g2.Name as s2_name, 
                //itm_g3.Name as s3_name
                //FROM Consumption_ShopC_Item  disi
                //INNER JOIN Consumption_ShopC_Item_Source disis on disis.Consumption_ShopC_Item_ID = disi.ID
                //INNER JOIN  Atom_Price_Item on disi.Atom_Price_Item_ID = Atom_Price_Item.ID
                //INNER JOIN  Atom_PriceList on Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID
                //inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                //INNER JOIN  Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                //INNER JOIN  Atom_Taxation on Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID
                //INNER JOIN  Consumption ON disi.Consumption_ID = Consumption.ID 
                //INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
                //INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
                //INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
                //LEFT JOIN  Item itm ON Atom_Item.UniqueName = itm.UniqueName
                //LEFT JOIN  Atom_Item_Image aii ON aii.Atom_Item_ID = Atom_Item.ID
                //LEFT JOIN  Atom_Item_ImageLib aiil ON aiil.ID = aii.Atom_Item_ImageLib_ID
                //LEFT JOIN  Stock ON disis.Stock_ID = Stock.ID 
                //LEFT JOIN  PurchasePrice_Item puitms ON Stock.PurchasePrice_Item_ID = puitms.ID 
                //LEFT JOIN  Item_ParentGroup1 itm_g1 ON itm.Item_ParentGroup1_ID = itm_g1.ID 
                //LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
                //LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
                //LEFT JOIN  Atom_Item_barcode ON Atom_Item.Atom_Item_barcode_ID = Atom_Item_barcode.ID 
                //LEFT JOIN  Atom_Item_Description ON Atom_Item.Atom_Item_Description_ID = Atom_Item_Description.ID 
                //LEFT JOIN  Atom_Warranty ON Atom_Item.Atom_Warranty_ID = Atom_Warranty.ID 
                //LEFT JOIN  Atom_Expiry ON Atom_Item.Atom_Expiry_ID = Atom_Expiry.ID 
                //LEFT JOIN  Item_Image ON itm.Item_Image_ID = Item_Image.ID 
                //where disi.Consumption_ID = " + xDoc_ID.ToString();

              @"
                SELECT 
                disi.ID as Consumption_ShopC_Item_ID,
                disi.Consumption_ID,
                disi.Atom_Price_Item_ID,
                disi.ExtraDiscount,
                Atom_Item.ID as Atom_Item_ID,
                itm.ID as Item_ID,
                Atom_Price_Item.RetailPricePerUnit,
                Atom_Price_Item.Discount,
                Atom_Item.UniqueName AS Atom_Item_UniqueName,
                Atom_Item_Name.Name AS Atom_Item_Name_Name,
                Atom_Item_barcode.barcode AS Atom_Item_barcode_barcode,
                Atom_Taxation.Name AS Atom_Taxation_Name,
                Atom_Taxation.Rate AS Atom_Taxation_Rate,
                Atom_Item_Description.Description AS Atom_Item_Description_Description,
                Atom_Item.Atom_Warranty_ID,
                Atom_Warranty.WarrantyDurationType AS Atom_Warranty_WarrantyDurationType,
                Atom_Warranty.WarrantyDuration AS Atom_Warranty_WarrantyDuration,
                Atom_Warranty.WarrantyConditions AS Atom_Warranty_WarrantyConditions,
                Atom_Item.Atom_Expiry_ID,
                Atom_Expiry.ExpectedShelfLifeInDays AS Atom_Expiry_ExpectedShelfLifeInDays,
                Atom_Expiry.SaleBeforeExpiryDateInDays AS Atom_Expiry_SaleBeforeExpiryDateInDays,
                Atom_Expiry.DiscardBeforeExpiryDateInDays AS Atom_Expiry_DiscardBeforeExpiryDateInDays,
                Atom_Expiry.ExpiryDescription AS Atom_Expiry_ExpiryDescription,
                Atom_Unit.Name AS Atom_Unit_Name,
                Atom_Unit.Symbol AS Atom_Unit_Symbol,
                Atom_Unit.DecimalPlaces AS Atom_Unit_DecimalPlaces,
                Atom_Unit.Description AS Atom_Unit_Description,
                Atom_Unit.StorageOption AS Atom_Unit_StorageOption,
                Atom_PriceList_Name.Name AS Atom_PriceList_Name,
                Atom_Currency.Name AS Atom_Currency_Name,
                Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                Atom_Currency.Symbol AS Atom_Currency_Symbol,
                Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces,
                aiil.Image_Hash as Atom_Item_Image_Hash,
                aiil.Image_Data as Atom_Item_Image_Data,
                itm_g1.Name as s1_name,
                itm_g2.Name as s2_name, 
                itm_g3.Name as s3_name
                FROM Consumption_ShopC_Item  disi
                INNER JOIN  Atom_Price_Item on disi.Atom_Price_Item_ID = Atom_Price_Item.ID
                INNER JOIN  Atom_PriceList on Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID
                inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                INNER JOIN  Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                INNER JOIN  Atom_Taxation on Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID
                INNER JOIN  Consumption ON disi.Consumption_ID = Consumption.ID 
                INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
                INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
                INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
                LEFT JOIN  Item itm ON Atom_Item.UniqueName = itm.UniqueName
				LEFT JOIN  Item_ParentGroup1 itm_g1 ON itm.Item_ParentGroup1_ID = itm_g1.ID 
                LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
                LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
				LEFT JOIN  Atom_Item_barcode ON Atom_Item.Atom_Item_barcode_ID = Atom_Item_barcode.ID 
                LEFT JOIN  Atom_Item_Description ON Atom_Item.Atom_Item_Description_ID = Atom_Item_Description.ID 
                LEFT JOIN  Atom_Warranty ON Atom_Item.Atom_Warranty_ID = Atom_Warranty.ID 
                LEFT JOIN  Atom_Expiry ON Atom_Item.Atom_Expiry_ID = Atom_Expiry.ID 
                LEFT JOIN  Atom_Item_Image aii ON aii.Atom_Item_ID = Atom_Item.ID
                LEFT JOIN  Atom_Item_ImageLib aiil ON aiil.ID = aii.Atom_Item_ImageLib_ID
                LEFT JOIN  Item_Image ON itm.Item_Image_ID = Item_Image.ID 
                where disi.Consumption_ID = " + xDoc_ID.ToString();
            }
            else if (xDocTyp.Equals("DocProformaInvoice"))
            {
                sql_select_Consumption_ShopC_Item =
    //            @"
    //           SELECT 
    //            dpisi.ID as DocProformaInvoice_ShopC_Item_ID,
    //            dpisi.DocProformaInvoice_ID,
    //            dpisis.Stock_ID,
    //            dpisi.Atom_Price_Item_ID,
    //            Atom_Item.ID as Atom_Item_ID,
    //            itm.ID as Item_ID,
    //            Atom_Price_Item.RetailPricePerUnit,
    //            Atom_Price_Item.Discount,
    //            dpisis.RetailPriceWithDiscount,
    //            dpisis.TaxPrice,
    //            dpisis.ExtraDiscount,
    //            dpisis.dQuantity,
    //            dpisis.ExpiryDate,
    //            Atom_Item.UniqueName AS Atom_Item_UniqueName,
    //            Atom_Item_Name.Name AS Atom_Item_Name_Name,
    //            Atom_Item_barcode.barcode AS Atom_Item_barcode_barcode,
    //            Atom_Taxation.Name AS Atom_Taxation_Name,
    //            Atom_Taxation.Rate AS Atom_Taxation_Rate,
    //            Atom_Item_Description.Description AS Atom_Item_Description_Description,
    //            Atom_Item.Atom_Warranty_ID,
    //            Atom_Warranty.WarrantyDurationType AS Atom_Warranty_WarrantyDurationType,
    //            Atom_Warranty.WarrantyDuration AS Atom_Warranty_WarrantyDuration,
    //            Atom_Warranty.WarrantyConditions AS Atom_Warranty_WarrantyConditions,
    //            Atom_Item.Atom_Expiry_ID,
    //            Atom_Expiry.ExpectedShelfLifeInDays AS Atom_Expiry_ExpectedShelfLifeInDays,
    //            Atom_Expiry.SaleBeforeExpiryDateInDays AS Atom_Expiry_SaleBeforeExpiryDateInDays,
    //            Atom_Expiry.DiscardBeforeExpiryDateInDays AS Atom_Expiry_DiscardBeforeExpiryDateInDays,
    //            Atom_Expiry.ExpiryDescription AS Atom_Expiry_ExpiryDescription,
    //            puitms.Item_ID AS Stock_Item_ID,
    //            Stock.ID AS Stock_ID,
    //            Stock.ImportTime AS Stock_ImportTime,
    //            Stock.dQuantity AS Stock_dQuantity,
    //            Stock.ExpiryDate AS Stock_ExpiryDate,
    //            Atom_Unit.Name AS Atom_Unit_Name,
    //            Atom_Unit.Symbol AS Atom_Unit_Symbol,
    //            Atom_Unit.DecimalPlaces AS Atom_Unit_DecimalPlaces,
    //            Atom_Unit.Description AS Atom_Unit_Description,
    //            Atom_Unit.StorageOption AS Atom_Unit_StorageOption,
    //            Atom_PriceList_Name.Name AS Atom_PriceList_Name,
    //            Atom_Currency.Name AS Atom_Currency_Name,
    //            Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
    //            Atom_Currency.Symbol AS Atom_Currency_Symbol,
    //            Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces,
    //            aiil.Image_Hash as Atom_Item_Image_Hash,
    //            aiil.Image_Data as Atom_Item_Image_Data,
    //            itm_g1.Name as s1_name,
    //            itm_g2.Name as s2_name, 
    //            itm_g3.Name as s3_name
    //            FROM DocProformaInvoice_ShopC_Item dpisi
    //INNER JOIN DocProformaInvoice_ShopC_Item_Source dpisis on dpisis.DocProformaInvoice_ShopC_Item_ID = dpisi.ID
    //            INNER JOIN  Atom_Price_Item on dpisi.Atom_Price_Item_ID = Atom_Price_Item.ID
    //            INNER JOIN  Atom_PriceList on Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID
    //            inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
    //            INNER JOIN  Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
    //            INNER JOIN  Atom_Taxation on Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID
    //            INNER JOIN  DocProformaInvoice ON dpisi.DocProformaInvoice_ID = DocProformaInvoice.ID 
    //            INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
    //            INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
    //            INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
    //            LEFT JOIN  Item itm ON Atom_Item.UniqueName = itm.UniqueName
    //            LEFT JOIN  Atom_Item_Image aii ON aii.Atom_Item_ID = Atom_Item.ID
    //            LEFT JOIN  Atom_Item_ImageLib aiil ON aiil.ID = aii.Atom_Item_ImageLib_ID
    //            LEFT JOIN  Stock ON dpisis.Stock_ID = Stock.ID 
    //            LEFT JOIN  PurchasePrice_Item puitms ON Stock.PurchasePrice_Item_ID = puitms.ID 
    //            LEFT JOIN  Item_ParentGroup1 itm_g1 ON itm.Item_ParentGroup1_ID = itm_g1.ID 
    //            LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
    //            LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
    //            LEFT JOIN  Atom_Item_barcode ON Atom_Item.Atom_Item_barcode_ID = Atom_Item_barcode.ID 
    //            LEFT JOIN  Atom_Item_Description ON Atom_Item.Atom_Item_Description_ID = Atom_Item_Description.ID 
    //            LEFT JOIN  Atom_Warranty ON Atom_Item.Atom_Warranty_ID = Atom_Warranty.ID 
    //            LEFT JOIN  Atom_Expiry ON Atom_Item.Atom_Expiry_ID = Atom_Expiry.ID 
    //            LEFT JOIN  Item_Image ON itm.Item_Image_ID = Item_Image.ID 
    //            where dpisi.DocProformaInvoice_ID = " + xDoc_ID.ToString();
    @"
               SELECT 
                dpisi.ID as DocProformaInvoice_ShopC_Item_ID,
                dpisi.DocProformaInvoice_ID,
                dpisi.Atom_Price_Item_ID,
                dpisi.ExtraDiscount,
                Atom_Item.ID as Atom_Item_ID,
                itm.ID as Item_ID,
                Atom_Price_Item.RetailPricePerUnit,
                Atom_Price_Item.Discount,
                Atom_Item.UniqueName AS Atom_Item_UniqueName,
                Atom_Item_Name.Name AS Atom_Item_Name_Name,
                Atom_Item_barcode.barcode AS Atom_Item_barcode_barcode,
                Atom_Taxation.Name AS Atom_Taxation_Name,
                Atom_Taxation.Rate AS Atom_Taxation_Rate,
                Atom_Item_Description.Description AS Atom_Item_Description_Description,
                Atom_Item.Atom_Warranty_ID,
                Atom_Warranty.WarrantyDurationType AS Atom_Warranty_WarrantyDurationType,
                Atom_Warranty.WarrantyDuration AS Atom_Warranty_WarrantyDuration,
                Atom_Warranty.WarrantyConditions AS Atom_Warranty_WarrantyConditions,
                Atom_Item.Atom_Expiry_ID,
                Atom_Expiry.ExpectedShelfLifeInDays AS Atom_Expiry_ExpectedShelfLifeInDays,
                Atom_Expiry.SaleBeforeExpiryDateInDays AS Atom_Expiry_SaleBeforeExpiryDateInDays,
                Atom_Expiry.DiscardBeforeExpiryDateInDays AS Atom_Expiry_DiscardBeforeExpiryDateInDays,
                Atom_Expiry.ExpiryDescription AS Atom_Expiry_ExpiryDescription,
                Atom_Unit.Name AS Atom_Unit_Name,
                Atom_Unit.Symbol AS Atom_Unit_Symbol,
                Atom_Unit.DecimalPlaces AS Atom_Unit_DecimalPlaces,
                Atom_Unit.Description AS Atom_Unit_Description,
                Atom_Unit.StorageOption AS Atom_Unit_StorageOption,
                Atom_PriceList_Name.Name AS Atom_PriceList_Name,
                Atom_Currency.Name AS Atom_Currency_Name,
                Atom_Currency.Abbreviation AS Atom_Currency_Abbreviation,
                Atom_Currency.Symbol AS Atom_Currency_Symbol,
                Atom_Currency.DecimalPlaces AS Atom_Currency_DecimalPlaces,
                aiil.Image_Hash as Atom_Item_Image_Hash,
                aiil.Image_Data as Atom_Item_Image_Data,
                itm_g1.Name as s1_name,
                itm_g2.Name as s2_name, 
                itm_g3.Name as s3_name
                FROM DocProformaInvoice_ShopC_Item dpisi
                INNER JOIN  Atom_Price_Item on dpisi.Atom_Price_Item_ID = Atom_Price_Item.ID
                INNER JOIN  Atom_PriceList on Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID
                inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                INNER JOIN  Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                INNER JOIN  Atom_Taxation on Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID
                INNER JOIN  DocProformaInvoice ON dpisi.DocProformaInvoice_ID = DocProformaInvoice.ID 
                INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
                INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
                INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
                LEFT JOIN  Item itm ON Atom_Item.UniqueName = itm.UniqueName
                LEFT JOIN  Atom_Item_Image aii ON aii.Atom_Item_ID = Atom_Item.ID
                LEFT JOIN  Atom_Item_ImageLib aiil ON aiil.ID = aii.Atom_Item_ImageLib_ID
                LEFT JOIN  Item_ParentGroup1 itm_g1 ON itm.Item_ParentGroup1_ID = itm_g1.ID 
                LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
                LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
                LEFT JOIN  Atom_Item_barcode ON Atom_Item.Atom_Item_barcode_ID = Atom_Item_barcode.ID 
                LEFT JOIN  Atom_Item_Description ON Atom_Item.Atom_Item_Description_ID = Atom_Item_Description.ID 
                LEFT JOIN  Atom_Warranty ON Atom_Item.Atom_Warranty_ID = Atom_Warranty.ID 
                LEFT JOIN  Atom_Expiry ON Atom_Item.Atom_Expiry_ID = Atom_Expiry.ID 
                LEFT JOIN  Item_Image ON itm.Item_Image_ID = Item_Image.ID 
                where dpisi.DocProformaInvoice_ID = " + xDoc_ID.ToString();
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Basket:Read_Consumption_ShopC_Item_Table:xDocTyp=" + xDocTyp+" not implemented.");
                return false;
            }
            Basket_Consumption_ShopC_Item_LIST.Clear();
            dtDraft_Doc_Consumption_ShopC_Item.Clear();
            dtDraft_Doc_Consumption_ShopC_Item.Columns.Clear();
            dtDraft_Doc_Consumption_ShopC_Item.Rows.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dtDraft_Doc_Consumption_ShopC_Item, sql_select_Consumption_ShopC_Item, ref Err))
            {
                xConsumption_ShopC_Item_LIST.Clear();
                Parse_Consumption_ShopC_Item(xDocTyp,this.dtDraft_Doc_Consumption_ShopC_Item, ref xConsumption_ShopC_Item_LIST);
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Basket:Read_Consumption_ShopC_Item_Table:sql=" + sql_select_Consumption_ShopC_Item + ":\r\n Err=" + Err);
                return false;
            }
        }

        //public bool SetFactory(string docTyp, ID doc_ID, decimal dToTakeFromFactory, CItem_Data xData, Transaction transaction)
        //{
        //    Consumption_ShopC_Item dsci = Find(xData.Item_UniqueName_v.v);
        //    if (dsci != null)
        //    {
        //        return dsci.SetFactory(docTyp, doc_ID, xData, dToTakeFromFactory, transaction);
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:Basket:SetFactory: Consumption_ShopC_Item dsci == null!");
        //        return false;
        //    }
        //}




        //public bool Add2BasketFromFactory(ref Consumption_ShopC_Item dsci,string docTyp, ID doc_ID, decimal xquantity2add, CItem_Data xData, Transaction transaction)
        //{
        //    dsci = Find(xData.Item_UniqueName_v.v);
        //    if (dsci == null)
        //    {
        //        dsci = new Consumption_ShopC_Item();
        //        if (dsci.SetNew(docTyp, doc_ID, xData, null, xquantity2add, transaction))
        //        {
        //            this.Basket_Consumption_ShopC_Item_LIST.Add(dsci);
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        if (dsci.AddFactory(docTyp, doc_ID, xData, xquantity2add, transaction))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}


        public bool Add2Basket(ref Consumption_ShopC_Item dsci,string docTyp,ID doc_ID,decimal xquantity2add, CItem_Data xData, deleagate_Select_Items_From_Stock_Dialog delegate_Select_Items_From_Stock_Dialog)
        {

            dsci = Find(xData.Item_UniqueName_v.v);

            decimal dQuantitySelectedFromStock = 0;

            DataTable xdt_ShopC_Item_In_Stock = null;
            if (f_Stock.GetItemInStock(xData.Item_ID, ref xdt_ShopC_Item_In_Stock))
            {
                List<CStock_Data> taken_from_Stock_List = new List<CStock_Data>();

                if (delegate_Select_Items_From_Stock_Dialog!=null)
                {
                    delegate_Select_Items_From_Stock_Dialog(xdt_ShopC_Item_In_Stock, xquantity2add, ref taken_from_Stock_List, ref dQuantitySelectedFromStock);
                }
                else
                {
                    AutoSelect_Items_From_Stock(xdt_ShopC_Item_In_Stock, xquantity2add, ref taken_from_Stock_List, ref dQuantitySelectedFromStock);
                }
                Transaction transaction_Basket_Add2Basket_WriteItemStockTransferInDataBase = DBSync.DBSync.NewTransaction("Basket.Add2Basket.WriteItemStockTransferInDataBase");

                if (WriteItemStockTransferInDataBase(docTyp,
                                                    doc_ID,
                                                    xData,
                                                    ref dsci,
                                                    taken_from_Stock_List,
                                                    transaction_Basket_Add2Basket_WriteItemStockTransferInDataBase))
                {
                    if (transaction_Basket_Add2Basket_WriteItemStockTransferInDataBase.Commit())
                    {
                        return true;
                    }
                }
                else
                {
                    transaction_Basket_Add2Basket_WriteItemStockTransferInDataBase.Rollback();
                }
            }
            return false;
        }


        private void AutoSelect_Items_From_Stock(DataTable xdt_ShopC_Item_In_Stock, decimal xquantity2add, ref List<CStock_Data> taken_from_stock, ref decimal dQuantitySelectedFromStock)
        {
            if (!xdt_ShopC_Item_In_Stock.Columns.Contains("TakeFromStock"))
            {
                xdt_ShopC_Item_In_Stock.Columns.Add(new DataColumn("TakeFromStock", typeof(decimal)));
            }

            if (taken_from_stock == null)
            {
                taken_from_stock = new List<CStock_Data>();
            }
            else
            {
                taken_from_stock.Clear();
            }
            dQuantitySelectedFromStock = 0;
            foreach (DataRow dr in xdt_ShopC_Item_In_Stock.Rows)
            {
                decimal dQinStock = (decimal)dr["Stock_dQuantity"];
                if (dQinStock > 0)
                {
                    if (dQinStock >= xquantity2add)
                    {
                        dr["Stock_dQuantity"] = dQinStock - xquantity2add;
                        dr["TakeFromStock"] = xquantity2add;
                        dQuantitySelectedFromStock += xquantity2add;

                        CStock_Data xstd = new CStock_Data();
                        xstd.dQuantity_Taken_v = new decimal_v(((decimal)dr["TakeFromStock"]));
                        xstd.dQuantity_v = new decimal_v(dQinStock);
                        xstd.Stock_ID = tf.set_ID(dr["Stock_ID"]);
                        taken_from_stock.Add(xstd);

                        return;
                    }
                    else
                    {
                        // take all
                        dr["TakeFromStock"] = dQinStock;
                        dr["Stock_dQuantity"] = 0;
                        dQuantitySelectedFromStock += dQinStock;
                        xquantity2add -= dQinStock;

                        CStock_Data xstd = new CStock_Data();
                        xstd.dQuantity_Taken_v = new decimal_v(((decimal)dr["TakeFromStock"]));
                        xstd.dQuantity_v = new decimal_v(dQinStock);
                        xstd.Stock_ID = tf.set_ID(dr["Stock_ID"]);
                        taken_from_stock.Add(xstd);

                    }
                }
            }
        }


        public bool WriteItemStockTransferInDataBase(string doc_type,ID doc_ID, CItem_Data xData, ref Consumption_ShopC_Item dsci, List<CStock_Data> taken_from_Stock_List, Transaction transaction)
        {
            if (dsci == null)
            {
                // Consumption_ShopC_Item does not exist create new
                dsci = new Consumption_ShopC_Item();
                if (dsci.SetNew(doc_type, doc_ID, xData, taken_from_Stock_List, transaction))
                {
                    this.Basket_Consumption_ShopC_Item_LIST.Add(dsci);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // Consumption_ShopC_Item allready exist
                // set stock
                foreach (CStock_Data stdtaken in taken_from_Stock_List)
                {
                    CStock_Data std = xData.Find_Stock_Data(stdtaken);
                    if (std != null)
                    {
                        std.dQuantity_v.v = std.dQuantity_v.v - stdtaken.dQuantity_Taken_v.v;

                        if (!f_Stock.UpdateQuantity(std.Stock_ID, std.dQuantity_v.v,transaction))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TangentaDB:Basket:WriteItemStockTransferInDataBase Stock_Data taken from stock not found in  Item_Data Stock_Data_List !");
                        return false;
                    }
                }

                // set basket
                if (taken_from_Stock_List.Count > 0)
                {
                    dsci.Set(doc_type, doc_ID, xData, taken_from_Stock_List, transaction);
                }

             
                return true;
            }
        }


        public bool RemoveFromBasket_And_put_back_to_Stock(string docTyp, ID consumption_ID, decimal xquantity2Remove, CItem_Data xData, Transaction transaction)
        {

            Consumption_ShopC_Item dsci = Find(xData.Item_UniqueName_v.v);
            if (dsci!=null)
            {

                if (dsci.dsciS_List.RemoveStockSources(docTyp, xData, xquantity2Remove, transaction))
                {
                    
                    if (dsci.dQuantity_all==0)
                    {
                        if (docTyp.Equals(GlobalData.const_ConsumptionAll))
                        {
                            if (!f_Consumption_ShopC_Item.Delete(dsci.Consumption_ShopC_Item_ID, transaction))
                            {
                                return false;
                            }
                        }
                        this.Basket_Consumption_ShopC_Item_LIST.Remove(dsci);
                        
                        
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:Basket:RemoveFromBasket_And_put_back_to_Stock:Consumption_ShopC_Item is null!");
            }

            return false;
        }

        public bool RemoveItem(string docTyp, Consumption_ShopC_Item dsci,CItem_Data xdata, Transaction transaction)
        {
           if (dsci.RemoveSources(docTyp, xdata, transaction))
            {
                this.Basket_Consumption_ShopC_Item_LIST.Remove(dsci);
                return true;
            }
            return false;

        }

        public void Remove(ID doc_ShopC_Item_ID)
        {
            foreach (Consumption_ShopC_Item dscix in this.Basket_Consumption_ShopC_Item_LIST)
            {
                if (dscix.Consumption_ShopC_Item_ID.Equals(doc_ShopC_Item_ID))
                {
                    this.Basket_Consumption_ShopC_Item_LIST.Remove(dscix);
                    return;
                }
            }
        }

        public bool IsInBasket(string item_UniqueName)
        {
            if (this.Basket_Consumption_ShopC_Item_LIST != null)
            {
                if (this.Basket_Consumption_ShopC_Item_LIST.Count > 0)
                {
                    foreach (object o in this.Basket_Consumption_ShopC_Item_LIST)
                    {
                        if (((Consumption_ShopC_Item)o).Atom_Item_UniqueName_v.v.Equals(item_UniqueName))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        public Consumption_ShopC_Item Find(string item_UniqueName)
        {
            if (this.Basket_Consumption_ShopC_Item_LIST != null)
            {
                if (this.Basket_Consumption_ShopC_Item_LIST.Count > 0)
                {
                    foreach (object o in this.Basket_Consumption_ShopC_Item_LIST)
                    {
                        if (((Consumption_ShopC_Item)o).Atom_Item_UniqueName_v.v.Equals(item_UniqueName))
                        {
                            return (Consumption_ShopC_Item)o;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Gets ShopC Items of Consumption_ID
        /// </summary>
        /// <param name="xDocTyp">prefix string of Consumption or DocProformaInvoice table (can be:"Consumption" and "DocProformaInvoice")</param>
        /// <param name="xdtDraft_Consumption_Atom_Item_Stock">table of ShopC Items for particular Consumption_ID </param>
        /// <param name="xConsumption_ShopC_Item_Data_LIST">output list of  item objects</param>
        /// <returns>void
        ///</returns>
        public void Parse_Consumption_ShopC_Item(string xDocTyp,DataTable xdtDraft_Consumption_Atom_Item_Stock, ref List<Consumption_ShopC_Item> xConsumption_ShopC_Item_Data_LIST)
        {
            int i = 0;
            int iCount = xdtDraft_Consumption_Atom_Item_Stock.Rows.Count;
            for (i = 0; i < iCount; i++)
            {
                Consumption_ShopC_Item xdsci = new Consumption_ShopC_Item();
                xdsci.Set(xDocTyp, xdtDraft_Consumption_Atom_Item_Stock.Rows[i],ref xConsumption_ShopC_Item_Data_LIST);
            }
        }

   
        public eCopy_Consumption_ShopC_Item_Result Copy_Consumption_ShopC_Item(string docInvoice,
                                                      CurrentDoc xCurrentDoc,
                                                      List<Consumption_ShopC_Item> xdsci_List,
                                                      bool bSelectItemsFromStockInDialog,
                                                      delegate_Select_ShopC_Item_in_Stock proc_Select_ShopC_Item_in_Stock,
                                                      delegate_Item_Not_InOffer proc_Item_Not_InOffer
                                                      )
        {
            foreach (Consumption_ShopC_Item dscix in xdsci_List)
            {
                if (dscix is Consumption_ShopC_Item)
                {
                   
                    ShopC_Item shopC_Item = new ShopC_Item();
                    if (!f_Item.Get(dscix.Atom_Item_UniqueName_v.v,
                                   ref shopC_Item.UniqueName_v,
                                   ref shopC_Item.Name_v,
                                   ref shopC_Item.bToOffer_v,
                                   ref shopC_Item.Item_Image,
                                   ref shopC_Item.Item_Image_ID,
                                   ref shopC_Item.Item_Image_Hash_v,
                                   ref shopC_Item.Code_v,
                                   ref shopC_Item.Unit_Name_v,
                                   ref shopC_Item.Unit_Symbol_v,
                                   ref shopC_Item.Unit_DecimalPlaces_v,
                                   ref shopC_Item.Unit_StorageOption_v,
                                   ref shopC_Item.Unit_Description_v,
                                   ref shopC_Item.barcode_v,
                                   ref shopC_Item.Description_v,
                                   ref shopC_Item.Expiry_ID,
                                   ref shopC_Item.Warranty_ID,
                                   ref shopC_Item.Expiry_v,
                                   ref shopC_Item.Warranty_v,
                                   ref shopC_Item.Item_ParentGroup1_ID,
                                   ref shopC_Item.Item_ParentGroup1_v,
                                   ref shopC_Item.Item_ParentGroup2_ID,
                                   ref shopC_Item.Item_ParentGroup2_v,
                                   ref shopC_Item.Item_ParentGroup3_ID,
                                   ref shopC_Item.Item_ParentGroup3_v,
                                   ref shopC_Item.Unit_ID,
                                   ref shopC_Item.Item_ID))
                    {
                        return eCopy_Consumption_ShopC_Item_Result.ERROR_DB;
                    }



                    if (ID.Validate(shopC_Item.Item_ID))
                    {
                        if (!InOffer(shopC_Item.bToOffer_v))
                        {
                            if (proc_Item_Not_InOffer!=null)
                            {
                                proc_Item_Not_InOffer(shopC_Item);
                            }
                        }
                    }
                    else
                    {
                        // No item found in offer !!
                        return eCopy_Consumption_ShopC_Item_Result.ERROR_NO_ITEM_IN_DB;
                    }
                    
                    
                    decimal dQuantitySelected = 0;
                    //if (!CopyShopCItemInNewConsumption(docInvoice, xCurrentDoc.Doc_ID, shopC_Item,  ref dQuantitySelected, bSelectItemsFromStockInDialog, proc_Select_ShopC_Item_in_Stock))
                    //{
                    //    return eCopy_Consumption_ShopC_Item_Result.ERROR_DB;
                    //}

                }
            }
            return eCopy_Consumption_ShopC_Item_Result.OK;
        }


        private bool CopyShopCItemInNewConsumption(string docInvoice, 
                                                  ID doc_ID,
                                                  Consumption_ShopC_Item xdsci,
                                                  ShopC_Item shopC_Item,
                                                  ref decimal dQuantitySelected,
                                                  bool bAutomaticSelectItemsFromStock,
                                                  delegate_Select_ShopC_Item_in_Stock proc_Select_ShopC_Item_in_Stock)
        {
          DataTable dt_ShopC_Item_In_Stock = null;
          if (f_Stock.GetItemInStock(shopC_Item.Item_ID,ref dt_ShopC_Item_In_Stock))
          {
                bool bDialogOk = false;
                return proc_Select_ShopC_Item_in_Stock(docInvoice,dt_ShopC_Item_In_Stock, xdsci,  ref dQuantitySelected, ref bDialogOk);
          }
          else
          {
                return false;
          }
        }

        public bool AutomaticSelectItems(DataTable dt_ShopC_Item_In_Stock,decimal dQuantity,ref decimal dQuantitySelected, ref string UnitSymbol)
        {
            if (!dt_ShopC_Item_In_Stock.Columns.Contains("Supplier"))
            {
                dt_ShopC_Item_In_Stock.Columns.Add(new DataColumn("Supplier", typeof(string)));
            }
            if (!dt_ShopC_Item_In_Stock.Columns.Contains("TakeFromStock"))
            {
                dt_ShopC_Item_In_Stock.Columns.Add(new DataColumn("TakeFromStock", typeof(decimal)));
            }

            decimal dQuantityToTake = dQuantity;

            foreach (DataRow dr in dt_ShopC_Item_In_Stock.Rows)
            {
                if (UnitSymbol == null)
                {
                    UnitSymbol = (string)dr["UnitSymbol"];
                }
                object oSupplierOrg = dr["Supplier_Organisation_Name"];
                if (oSupplierOrg is string)
                {
                    dr["Supplier"] = (string)oSupplierOrg;
                }
                else
                {
                    string Supplier_Person_FirstName = "";
                    string Supplier_Person_LastName = "";
                    string Supplier_Person_GsmNumber = "";
                    string Supplier_Person_Email = "";
                    object oSupplierPerson = dr["Supplier_Person_FirstName"];
                    if (oSupplierPerson is string)

                    {
                        Supplier_Person_FirstName = (string)oSupplierPerson;
                    }
                    oSupplierPerson = dr["Supplier_Person_LastName"];
                    if (oSupplierPerson is string)
                    {
                        Supplier_Person_LastName = (string)oSupplierPerson;
                    }
                    oSupplierPerson = dr["Supplier_Person_GsmNumber"];
                    if (oSupplierPerson is string)
                    {
                        Supplier_Person_GsmNumber = (string)oSupplierPerson;
                    }
                    oSupplierPerson = dr["Supplier_Person_Email"];
                    if (oSupplierPerson is string)
                    {
                        Supplier_Person_Email = (string)oSupplierPerson;
                    }
                    dr["Supplier"] = Supplier_Person_FirstName + " " + Supplier_Person_LastName + " gsm:" + Supplier_Person_GsmNumber + " email:" + Supplier_Person_Email;
                }
            }

            foreach (DataRow dr in dt_ShopC_Item_In_Stock.Rows)
            {
                if (dQuantityToTake > 0)
                {
                    decimal dq = (decimal)dr["Stock_dQuantity"];
                    if (dQuantityToTake >= dq)
                    {
                        dr["TakeFromStock"] = dq;
                        dQuantityToTake -= dq;
                    }
                    else
                    {
                        dr["TakeFromStock"] = dQuantityToTake;
                        dQuantityToTake = 0;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            dQuantitySelected = dQuantity - dQuantityToTake;
            return (dQuantityToTake == 0);
        }

        private bool InOffer(bool_v bToOffer_v)
        {
            if (bToOffer_v!=null)
            {
                return bToOffer_v.v;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveFactory(string xDocTyp,Consumption_ShopC_Item xdsci, Transaction transaction)
        {
            string sql = null;

            ID item_ID = xdsci.Find_Item_ID();
            if (xDocTyp==null)
            {
                LogFile.Error.Show("ERROR:Basket.cs:Basket:RemoveFactory:xDocTyp = null not implemented.");
                return false;
            }
            else if (xDocTyp.Equals(GlobalData.const_ConsumptionAll))
            {
                sql = @"select dsci.ID from Consumption_ShopC_Item  dsci
                                  inner join Consumption_ShopC_Item_Source dsciS on dsciS.Consumption_ShopC_Item_ID = dsci.ID
                                  inner join Atom_price_item api on api.ID = dsci.Atom_price_item_ID
                                  inner join Atom_Item ai on ai.ID = api.Atom_Item_ID
                                  inner join Item i on i.UniqueName = ai.UniqueName
                                  where  (Consumption_ID = " + xdsci.Consumption_ID.ToString() + ") and (i.ID=" + item_ID.ToString() + ") and dsciS.Stock_ID is null";
            }
            else if (xDocTyp.Equals(GlobalData.const_DocProformaInvoice))
            {
                sql = @"select dsci.ID from DocProformaInvoice_ShopC_Item  dsci
                                  inner join DocProformaInvoice_ShopC_Item_Source dsciS on dsciS.DocProformaInvoice_ShopC_Item_ID = dsci.ID
                                  inner join Atom_price_item api on api.ID = dsci.Atom_price_item_ID
                                  inner join Atom_Item ai on ai.ID = api.Atom_Item_ID
                                  inner join Item i on i.UniqueName = ai.UniqueName
                                  where  (DocProformaInvoice_ID = " + xdsci.Consumption_ID.ToString() + ") and (i.ID=" + item_ID.ToString() + ") and dsciS.Stock_ID is null";
            }
            else
            {
                LogFile.Error.Show("ERROR:Basket.cs:Basket:RemoveFactory:xDocTyp=" + xDocTyp + " not implemented.");
                return false;
            }

            DataTable dt1 = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt1, sql, ref Err))
            {
                string s_in_ID_list = null;
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        ID id = tf.set_ID(dr["ID"]);
                        if (s_in_ID_list == null)
                        {
                            s_in_ID_list += "(" + id.ToString();
                        }
                        else
                        {
                            s_in_ID_list += "," + id.ToString();
                        }
                    }
                    if (s_in_ID_list != null)
                    {
                        s_in_ID_list += ")"; // close ID_List!
                    }

                    string sql_Delete_Consumption_Atom_Item_Stock = null;
                    if (xDocTyp.Equals(GlobalData.const_ConsumptionAll))
                    {
                        sql_Delete_Consumption_Atom_Item_Stock = "delete from Consumption_ShopC_Item_Source where Stock_ID is null and  Consumption_ShopC_Item_ID in " + s_in_ID_list;
                    }
                    else if (xDocTyp.Equals(GlobalData.const_DocProformaInvoice))
                    {
                        sql_Delete_Consumption_Atom_Item_Stock = "delete from DocProformaInvoice_ShopC_Item_Source where Stock_ID is null and  DocProformaInvoice_ShopC_Item_ID in " + s_in_ID_list;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Basket.cs:Basket:RemoveFactory:xDocTyp=" + xDocTyp + " not implemented.");
                        return false;
                    }

                    if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Consumption_Atom_Item_Stock, null,  ref Err))
                    {
                        string sql_Delete_Atom_Price_Item = "delete from Atom_Price_Item where ID not in  (select Atom_Price_Item_ID from Consumption_ShopC_Item UNION select Atom_Price_Item_ID from DocProformaInvoice_ShopC_Item)";
                        if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Atom_Price_Item, null, ref Err))
                        {
                            string sql_Delete_Atom_Item_Image = "delete from Atom_Item_Image where Atom_Item_Image.Atom_Item_ID not in (select Atom_Item_ID from Atom_Price_Item)";
                            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Atom_Item_Image, null,  ref Err))
                            {
                                string sql_Delete_Atom_Item_ImageLib = "delete from Atom_Item_ImageLib where ID not in (select Atom_Item_ImageLib_ID from Atom_Item_Image)";
                                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql_Delete_Atom_Item_ImageLib, null, ref Err))
                                {
                                    RemoveFactory_from_list(xdsci);
                                    if (xdsci.dQuantity_all==0)
                                    {
                                        if (xDocTyp.Equals(GlobalData.const_ConsumptionAll))
                                        {
                                            if (f_Consumption_ShopC_Item.Delete(xdsci.Consumption_ShopC_Item_ID, transaction))
                                            {
                                                this.Basket_Consumption_ShopC_Item_LIST.Remove(xdsci);
                                                return true; 
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        }
                                        else if (xDocTyp.Equals(GlobalData.const_DocProformaInvoice))
                                        {
                                            if (f_DocProformaInvoice_ShopC_Item.Delete(xdsci.Consumption_ShopC_Item_ID, transaction))
                                            {
                                                this.Basket_Consumption_ShopC_Item_LIST.Remove(xdsci);
                                                return true; 
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:TangentaDB:Basket:RemoveFactory:unsuported xDocTyp =" + xDocTyp);
                                            return false;
                                        }
                                    }
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:Basket:sql=" + sql_Delete_Atom_Item_ImageLib + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:Basket:delete from Atom_Item:Err=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Basket:sql=" + sql_Delete_Atom_Price_Item + "\r\nErr=" + Err);
                            return false;
                        }

                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Basket:delete from Consumption_ShopC_Item:Err=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Basket:dt1.Rows.Count == 0 !");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Basket:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        private void Remove_from_list(Consumption_ShopC_Item xdsci)
        {
             this.Basket_Consumption_ShopC_Item_LIST.Remove(xdsci);
        }

        private void RemoveFactory_from_list(Consumption_ShopC_Item xdsci)
        {
            xdsci.dsciS_List.RemoveFactory_from_list();

        }
        private void RemoveStock_from_list(Consumption_ShopC_Item xdsci)
        {
            xdsci.dsciS_List.RemoveStock_from_list();
        }


        private bool UpdateStock(ID xAtom_WorkPeriod_ID,List<Return_to_shop_shelf_data> Return_to_basket_data_List, List<SQL_Parameter> lpar, Transaction transaction)
        {
            string Err = null;
            DateTime EventTime = DateTime.Now;
            foreach (Return_to_shop_shelf_data rtb in Return_to_basket_data_List)
            {
                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,rtb.sql_update_stock, lpar, ref Err))
                {
                    ID JOURNAL_Stock_ID = null;
                    if (f_JOURNAL_Stock.Get(rtb.stock_id, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_from_basket_to_stock,xAtom_WorkPeriod_ID, EventTime, rtb.dQuantity_from_basket_to_stock, ref JOURNAL_Stock_ID, transaction))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Basket:UpdateStock:sql=" + rtb.sql_update_stock + "\r\nErr=" + Err);
                    return false;
                }
            }
            return true;
        }



        public Consumption_ShopC_Item Contains(Item_Data m_Item_Data)
        {
            foreach (object o in this.Basket_Consumption_ShopC_Item_LIST)
            {
                if (((Consumption_ShopC_Item)o).Atom_Item_UniqueName_v.v.Equals(m_Item_Data.Item_UniqueName_v.v))
                {
                    return ((Consumption_ShopC_Item)o);
                }
            }
            return null;
        }

        public void GetPriceSum(ref decimal dsum_GrossSum_Basket, ref decimal dsum_TaxSum_Basket, ref decimal dsum_NetSum, ref StaticLib.TaxSum TaxSum)
        {
            foreach (Consumption_ShopC_Item dscix in this.Basket_Consumption_ShopC_Item_LIST)
            {
               
                decimal RetailPriceWithDisount = 0;
                decimal tax_price = 0;
                decimal net_price = 0;
                StaticLib.Func.CalculatePrice(dscix.RetailPricePerUnit,
                                        dscix.dQuantity_all,
                                        dscix.Discount,
                                        dscix.ExtraDiscount,
                                        dscix.TaxationRate,
                                        ref RetailPriceWithDisount,
                                        ref tax_price,
                                        ref net_price,
                                        dscix.Atom_Currency_DecimalPlaces_v.v);

                TaxSum.Add(tax_price, net_price, dscix.Atom_Taxation_Name_v.v, dscix.Atom_Taxation_Rate_v.v);

                dsum_GrossSum_Basket += RetailPriceWithDisount;
                dsum_TaxSum_Basket += tax_price;
                dsum_NetSum += net_price;
            }
        }
    }
}
