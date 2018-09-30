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

namespace TangentaDB
{
    public class Basket
    {
        public delegate bool delegate_Select_ShopC_Item_in_Stock(string DocTyp,
                                                                  DataTable dt_ShopC_Item_in_Stock,
                                                                  Atom_DocInvoice_ShopC_Item_Price_Stock_Data xShopC_Data_Item,
                                                                  decimal dStockQuantity,
                                                                  decimal dFromFactoryQuantity,
                                                                  ref decimal dQuantitySelected, 
                                                                  ref bool bOK);
        public delegate void delegate_Item_Not_InOffer(ShopC_Item shopC_Item);

        public List<object> m_DocInvoice_ShopC_Item_Data_LIST = new List<object>();
        public DataTable dtDraft_DocInvoice_Atom_Item_Stock = new DataTable();


        public void Empty(ID xAtom_WorkPeriod_ID,string DocTyp,ShopShelf xShopShelf)
        {
            while (m_DocInvoice_ShopC_Item_Data_LIST.Count > 0)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)m_DocInvoice_ShopC_Item_Data_LIST[0];
                if (appisd.dQuantity_FromStock > 0)
                {
                    Remove_and_put_back_to_ShopShelf(xAtom_WorkPeriod_ID,DocTyp, appisd, xShopShelf);
                }
                if (appisd.dQuantity_FromFactory > 0)
                {
                    RemoveFactory(DocTyp,appisd);
                }
                m_DocInvoice_ShopC_Item_Data_LIST.Remove(appisd);
            }
        }

        /// <summary>
        /// Gets ShopC Items of DocInvoice_ID
        /// </summary>
        /// <param name="xDocTyp">prefix string of DocInvoice or DocProformaInvoice table (can be:"DocInvoice" and "DocProformaInvoice")</param>
        /// <param name="Doc_ID">ID of row in DocInvoice or DocProformaInvoice table)</param>
        /// <param name="xDocInvoice_ShopC_Item_Data_LIST">output list of  item objects</param>
        /// <returns>Return true if no DB error
        ///</returns>
        public bool Read_ShopC_Price_Item_Stock_Table(string xDocTyp,ID xDoc_ID, ref List<object> xDocInvoice_ShopC_Item_Data_LIST)
        {
            string Err = null;
            string sql_select_DocInvoice_Atom_Item_Stock = null;
            if (xDocTyp.Equals(GlobalData.const_DocInvoice))
            {
                sql_select_DocInvoice_Atom_Item_Stock =
                @"
                SELECT 
                DocInvoice_ShopC_Item.ID as DocInvoice_ShopC_Item_ID,
                DocInvoice_ShopC_Item.DocInvoice_ID,
                DocInvoice_ShopC_Item.Stock_ID,
                DocInvoice_ShopC_Item.Atom_Price_Item_ID,
                Atom_Item.ID as Atom_Item_ID,
                itm.ID as Item_ID,
                Atom_Price_Item.RetailPricePerUnit,
                Atom_Price_Item.Discount,
                DocInvoice_ShopC_Item.RetailPriceWithDiscount,
                DocInvoice_ShopC_Item.TaxPrice,
                DocInvoice_ShopC_Item.ExtraDiscount,
                DocInvoice_ShopC_Item.dQuantity,
                DocInvoice_ShopC_Item.ExpiryDate,
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
                puitms.Item_ID AS Stock_Item_ID,
                Stock.ImportTime AS Stock_ImportTime,
                Stock.dQuantity AS Stock_dQuantity,
                Stock.ExpiryDate AS Stock_ExpiryDate,
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
                FROM DocInvoice_ShopC_Item 
                INNER JOIN  Atom_Price_Item on DocInvoice_ShopC_Item.Atom_Price_Item_ID = Atom_Price_Item.ID
                INNER JOIN  Atom_PriceList on Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID
                inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                INNER JOIN  Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                INNER JOIN  Atom_Taxation on Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID
                INNER JOIN  DocInvoice ON DocInvoice_ShopC_Item.DocInvoice_ID = DocInvoice.ID 
                INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
                INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
                INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
                LEFT JOIN  Item itm ON Atom_Item.UniqueName = itm.UniqueName
                LEFT JOIN  Atom_Item_Image aii ON aii.Atom_Item_ID = Atom_Item.ID
                LEFT JOIN  Atom_Item_ImageLib aiil ON aiil.ID = aii.Atom_Item_ImageLib_ID
                LEFT JOIN  Stock ON DocInvoice_ShopC_Item.Stock_ID = Stock.ID 
                LEFT JOIN  PurchasePrice_Item puitms ON Stock.PurchasePrice_Item_ID = puitms.ID 
                LEFT JOIN  Item_ParentGroup1 itm_g1 ON itm.Item_ParentGroup1_ID = itm_g1.ID 
                LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
                LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
                LEFT JOIN  Atom_Item_barcode ON Atom_Item.Atom_Item_barcode_ID = Atom_Item_barcode.ID 
                LEFT JOIN  Atom_Item_Description ON Atom_Item.Atom_Item_Description_ID = Atom_Item_Description.ID 
                LEFT JOIN  Atom_Warranty ON Atom_Item.Atom_Warranty_ID = Atom_Warranty.ID 
                LEFT JOIN  Atom_Expiry ON Atom_Item.Atom_Expiry_ID = Atom_Expiry.ID 
                LEFT JOIN  Item_Image ON itm.Item_Image_ID = Item_Image.ID 
                where DocInvoice_ShopC_Item.DocInvoice_ID = " + xDoc_ID.ToString();
            }
            else if (xDocTyp.Equals("DocProformaInvoice"))
            {
                sql_select_DocInvoice_Atom_Item_Stock =
                @"
                SELECT 
                DocProformaInvoice_ShopC_Item.ID as DocProformaInvoice_ShopC_Item_ID,
                DocProformaInvoice_ShopC_Item.DocProformaInvoice_ID,
                DocProformaInvoice_ShopC_Item.Stock_ID,
                DocProformaInvoice_ShopC_Item.Atom_Price_Item_ID,
                Atom_Item.ID as Atom_Item_ID,
                itm.ID as Item_ID,
                Atom_Price_Item.RetailPricePerUnit,
                Atom_Price_Item.Discount,
                DocProformaInvoice_ShopC_Item.RetailPriceWithDiscount,
                DocProformaInvoice_ShopC_Item.TaxPrice,
                DocProformaInvoice_ShopC_Item.ExtraDiscount,
                DocProformaInvoice_ShopC_Item.dQuantity,
                DocProformaInvoice_ShopC_Item.ExpiryDate,
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
                puitms.Item_ID AS Stock_Item_ID,
                Stock.ID AS Stock_ID,
                Stock.ImportTime AS Stock_ImportTime,
                Stock.dQuantity AS Stock_dQuantity,
                Stock.ExpiryDate AS Stock_ExpiryDate,
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
                FROM DocProformaInvoice_ShopC_Item 
                INNER JOIN  Atom_Price_Item on DocProformaInvoice_ShopC_Item.Atom_Price_Item_ID = Atom_Price_Item.ID
                INNER JOIN  Atom_PriceList on Atom_Price_Item.Atom_PriceList_ID = Atom_PriceList.ID
                inner join Atom_PriceList_Name on Atom_PriceList.Atom_PriceList_Name_ID = Atom_PriceList_Name.ID
                INNER JOIN  Atom_Currency on Atom_PriceList.Atom_Currency_ID = Atom_Currency.ID
                INNER JOIN  Atom_Taxation on Atom_Price_Item.Atom_Taxation_ID = Atom_Taxation.ID
                INNER JOIN  DocProformaInvoice ON DocProformaInvoice_ShopC_Item.DocProformaInvoice_ID = DocProformaInvoice.ID 
                INNER JOIN  Atom_Item ON Atom_Price_Item.Atom_Item_ID = Atom_Item.ID 
                INNER JOIN  Atom_Item_Name ON Atom_Item.Atom_Item_Name_ID = Atom_Item_Name.ID 
                INNER JOIN  Atom_Unit ON Atom_Item.Atom_Unit_ID = Atom_Unit.ID 
                LEFT JOIN  Item itm ON Atom_Item.UniqueName = itm.UniqueName
                LEFT JOIN  Atom_Item_Image aii ON aii.Atom_Item_ID = Atom_Item.ID
                LEFT JOIN  Atom_Item_ImageLib aiil ON aiil.ID = aii.Atom_Item_ImageLib_ID
                LEFT JOIN  Stock ON DocProformaInvoice_ShopC_Item.Stock_ID = Stock.ID 
                LEFT JOIN  PurchasePrice_Item puitms ON Stock.PurchasePrice_Item_ID = puitms.ID 
                LEFT JOIN  Item_ParentGroup1 itm_g1 ON itm.Item_ParentGroup1_ID = itm_g1.ID 
                LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
                LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
                LEFT JOIN  Atom_Item_barcode ON Atom_Item.Atom_Item_barcode_ID = Atom_Item_barcode.ID 
                LEFT JOIN  Atom_Item_Description ON Atom_Item.Atom_Item_Description_ID = Atom_Item_Description.ID 
                LEFT JOIN  Atom_Warranty ON Atom_Item.Atom_Warranty_ID = Atom_Warranty.ID 
                LEFT JOIN  Atom_Expiry ON Atom_Item.Atom_Expiry_ID = Atom_Expiry.ID 
                LEFT JOIN  Item_Image ON itm.Item_Image_ID = Item_Image.ID 
                where DocProformaInvoice_ShopC_Item.DocProformaInvoice_ID = " + xDoc_ID.ToString();
            }
            else
            {
                LogFile.Error.Show("ERROR:DocInvoice_ShopC_Item:xDocTyp=" + xDocTyp+" not implemented.");
                return false;
            }
            m_DocInvoice_ShopC_Item_Data_LIST.Clear();
            dtDraft_DocInvoice_Atom_Item_Stock.Clear();
            dtDraft_DocInvoice_Atom_Item_Stock.Columns.Clear();
            dtDraft_DocInvoice_Atom_Item_Stock.Rows.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dtDraft_DocInvoice_Atom_Item_Stock, sql_select_DocInvoice_Atom_Item_Stock, ref Err))
            {
                xDocInvoice_ShopC_Item_Data_LIST.Clear();
                Parse_Atom_DocInvoice_Item_Stock(xDocTyp,this.dtDraft_DocInvoice_Atom_Item_Stock, ref xDocInvoice_ShopC_Item_Data_LIST);
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:DocInvoice_ShopC_Item:sql="+ sql_select_DocInvoice_Atom_Item_Stock + ":\r\n Err=" + Err);
                return false;
            }
        }

  
        public bool IsInBasket(string item_UniqueName)
        {
            if (this.m_DocInvoice_ShopC_Item_Data_LIST != null)
            {
                if (this.m_DocInvoice_ShopC_Item_Data_LIST.Count > 0)
                {
                    foreach (object o in this.m_DocInvoice_ShopC_Item_Data_LIST)
                    {
                        if (((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Atom_Item_UniqueName.v.Equals(item_UniqueName))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        public Atom_DocInvoice_ShopC_Item_Price_Stock_Data Find(string item_UniqueName)
        {
            if (this.m_DocInvoice_ShopC_Item_Data_LIST != null)
            {
                if (this.m_DocInvoice_ShopC_Item_Data_LIST.Count > 0)
                {
                    foreach (object o in this.m_DocInvoice_ShopC_Item_Data_LIST)
                    {
                        if (((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Atom_Item_UniqueName.v.Equals(item_UniqueName))
                        {
                            return (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Gets ShopC Items of DocInvoice_ID
        /// </summary>
        /// <param name="xDocTyp">prefix string of DocInvoice or DocProformaInvoice table (can be:"DocInvoice" and "DocProformaInvoice")</param>
        /// <param name="xdtDraft_DocInvoice_Atom_Item_Stock">table of ShopC Items for particular DocInvoice_ID </param>
        /// <param name="xDocInvoice_ShopC_Item_Data_LIST">output list of  item objects</param>
        /// <returns>void
        ///</returns>
        public void Parse_Atom_DocInvoice_Item_Stock(string xDocTyp,DataTable xdtDraft_DocInvoice_Atom_Item_Stock, ref List<object> xDocInvoice_ShopC_Item_Data_LIST)
        {
            int i = 0;
            int iCount = xdtDraft_DocInvoice_Atom_Item_Stock.Rows.Count;
            for (i = 0; i < iCount; i++)
            {
                Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd = new Atom_DocInvoice_ShopC_Item_Price_Stock_Data();
                appisd.Set(xDocTyp, xdtDraft_DocInvoice_Atom_Item_Stock.Rows[i],ref xDocInvoice_ShopC_Item_Data_LIST);
            }
        }

        public enum eCopy_ShopC_Price_Item_Stock_Table_Result { OK,ERROR_NO_ITEM_IN_DB,ERROR_DB};
        public eCopy_ShopC_Price_Item_Stock_Table_Result Copy_ShopC_Price_Item_Stock_Table(string docInvoice,
                                                      CurrentDoc xCurrentDoc,
                                                      List<object> xShopC_Data_Item_List,
                                                      bool bSelectItemsFromStockInDialog,
                                                      delegate_Select_ShopC_Item_in_Stock proc_Select_ShopC_Item_in_Stock,
                                                      delegate_Item_Not_InOffer proc_Item_Not_InOffer
                                                      )
        {
            foreach (object oxShopC_Data_Item in xShopC_Data_Item_List)
            {
                if (oxShopC_Data_Item is Atom_DocInvoice_ShopC_Item_Price_Stock_Data)
                {
                    Atom_DocInvoice_ShopC_Item_Price_Stock_Data xShopC_Data_Item = (Atom_DocInvoice_ShopC_Item_Price_Stock_Data)oxShopC_Data_Item;
                    ShopC_Item shopC_Item = new ShopC_Item();
                    if (!f_Item.Get(xShopC_Data_Item.Atom_Item_UniqueName.v,
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
                        return eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_DB;
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
                        return eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_NO_ITEM_IN_DB;
                    }
                    decimal dStockCount = 0;
                    decimal dFromFactoryCount = 0;
                    int iStockDataListCount = 0;
                    if (xShopC_Data_Item.m_ShopShelf_Source != null)
                    {
                        if (xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List != null)
                        {
                            iStockDataListCount = xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List.Count;
                            for (int i=0;i< iStockDataListCount;i++)
                            {
                                if (xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List[i].dQuantity_from_stock != null)
                                {
                                    dStockCount += xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List[i].dQuantity_from_stock.v;
                                }
                                if (xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List[i].dQuantity_from_factory != null)
                                {
                                    dFromFactoryCount += xShopC_Data_Item.m_ShopShelf_Source.Stock_Data_List[i].dQuantity_from_factory.v;
                                }
                            }
                        }
                    }
                    if (dStockCount > 0)
                    {
                        //this item was taken from stock
                    }
                    else
                    {
                        //this item was taken directly from factory
                    }

                    decimal dQuantitySelected = 0;
                    if (!CopyShopCItemInNewDocInvoice(docInvoice, xCurrentDoc.Doc_ID, xShopC_Data_Item,shopC_Item, dStockCount, dFromFactoryCount, ref dQuantitySelected, bSelectItemsFromStockInDialog, proc_Select_ShopC_Item_in_Stock))
                    {
                        return eCopy_ShopC_Price_Item_Stock_Table_Result.ERROR_DB;
                    }

                }
            }
            return eCopy_ShopC_Price_Item_Stock_Table_Result.OK;
        }


        private bool CopyShopCItemInNewDocInvoice(string docInvoice, 
                                                  ID doc_ID,
                                                  Atom_DocInvoice_ShopC_Item_Price_Stock_Data xShopC_Data_Item,
                                                  ShopC_Item shopC_Item,
                                                  decimal dStockCount,
                                                  decimal dFromFactoryCount,
                                                  ref decimal dQuantitySelected,
                                                  bool bAutomaticSelectItemsFromStock,
                                                  delegate_Select_ShopC_Item_in_Stock proc_Select_ShopC_Item_in_Stock)
        {
          DataTable dt_ShopC_Item_In_Stock = null;
          if (f_Stock.GetItemInStock(shopC_Item.Item_ID,ref dt_ShopC_Item_In_Stock))
          {
                bool bDialogOk = false;
                return proc_Select_ShopC_Item_in_Stock(docInvoice,dt_ShopC_Item_In_Stock, xShopC_Data_Item,dStockCount, dFromFactoryCount, ref dQuantitySelected, ref bDialogOk);
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

        public bool RemoveFactory(string xDocTyp,Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            string sql = null;

            if (xDocTyp==null)
            {
                LogFile.Error.Show("ERROR:Basket.cs:Basket:RemoveFactory:xDocTyp = null not implemented.");
                return false;
            }
            else if (xDocTyp.Equals(GlobalData.const_DocInvoice))
            {
                sql = @"select appis.ID from DocInvoice_ShopC_Item  appis
                                  inner join Atom_price_item api on api.ID = appis.Atom_price_item_ID
                                  inner join Atom_Item ai on ai.ID = api.Atom_Item_ID
                                  inner join Item i on i.UniqueName = ai.UniqueName
                                  where  (DocInvoice_ID = " + appisd.DocInvoice_ID.ToString() + ") and (i.ID=" + appisd.Item_ID.ToString() + ") and Stock_ID is null";
            }
            else if (xDocTyp.Equals(GlobalData.const_DocProformaInvoice))
            {
                sql = @"select appis.ID from DocProformaInvoice_ShopC_Item  appis
                                  inner join Atom_price_item api on api.ID = appis.Atom_price_item_ID
                                  inner join Atom_Item ai on ai.ID = api.Atom_Item_ID
                                  inner join Item i on i.UniqueName = ai.UniqueName
                                  where  (DocProformaInvoice_ID = " + appisd.DocInvoice_ID.ToString() + ") and (i.ID=" + appisd.Item_ID.ToString() + ") and Stock_ID is null";
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

                    string sql_Delete_DocInvoice_Atom_Item_Stock = null;
                    if (xDocTyp.Equals(GlobalData.const_DocInvoice))
                    {
                        sql_Delete_DocInvoice_Atom_Item_Stock = "delete from DocInvoice_ShopC_Item where Stock_ID is null and (DocInvoice_ID = " + appisd.DocInvoice_ID.ToString()
                                                                        + ") and DocInvoice_ShopC_Item.ID in " + s_in_ID_list;
                    }
                    else if (xDocTyp.Equals(GlobalData.const_DocProformaInvoice))
                    {
                        sql_Delete_DocInvoice_Atom_Item_Stock = "delete from DocProformaInvoice_ShopC_Item where Stock_ID is null and (DocProformaInvoice_ID = " + appisd.DocInvoice_ID.ToString()
                                                                        + ") and DocProformaInvoice_ShopC_Item.ID in " + s_in_ID_list;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Basket.cs:Basket:RemoveFactory:xDocTyp=" + xDocTyp + " not implemented.");
                        return false;
                    }

                    object objret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_DocInvoice_Atom_Item_Stock, null, ref objret, ref Err))
                    {
                        string sql_Delete_Atom_Price_Item = "delete from Atom_Price_Item where ID not in  (select Atom_Price_Item_ID from DocInvoice_ShopC_Item UNION select Atom_Price_Item_ID from DocProformaInvoice_ShopC_Item)";
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Price_Item, null, ref objret, ref Err))
                        {
                            string sql_Delete_Atom_Item_Image = "delete from Atom_Item_Image where Atom_Item_Image.Atom_Item_ID not in (select Atom_Item_ID from Atom_Price_Item)";
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_Image, null, ref objret, ref Err))
                            {
                                string sql_Delete_Atom_Item_ImageLib = "delete from Atom_Item_ImageLib where ID not in (select Atom_Item_ImageLib_ID from Atom_Item_Image)";
                                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_ImageLib, null, ref objret, ref Err))
                                {
                                    RemoveFactory_from_list(appisd);
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
                        LogFile.Error.Show("ERROR:Basket:delete from DocInvoice_ShopC_Item:Err=" + Err);
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


        public bool RemoveAll(string xDocTyp, Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {

            string sql = null;

            if (xDocTyp == null)
            {
                LogFile.Error.Show("ERROR:Basket.cs:Basket:RemoveFactory:xDocTyp = null not implemented.");
                return false;
            }
            else if (xDocTyp.Equals(GlobalData.const_DocInvoice))
            {
                sql = @"select appis.ID from DocInvoice_ShopC_Item  appis
                                  inner join Atom_price_item api on api.ID = appis.Atom_price_item_ID
                                  inner join Atom_Item ai on ai.ID = api.Atom_Item_ID
                                  inner join Item i on i.UniqueName = ai.UniqueName
                                  where  (DocInvoice_ID = " + appisd.DocInvoice_ID.ToString() + ") and (i.ID=" + appisd.Item_ID.ToString() + ")";
            }
            else if (xDocTyp.Equals(GlobalData.const_DocProformaInvoice))
            {
                sql = @"select appis.ID from DocProformaInvoice_ShopC_Item  appis
                                  inner join Atom_price_item api on api.ID = appis.Atom_price_item_ID
                                  inner join Atom_Item ai on ai.ID = api.Atom_Item_ID
                                  inner join Item i on i.UniqueName = ai.UniqueName
                                  where  (DocProformaInvoice_ID = " + appisd.DocInvoice_ID.ToString() + ") and (i.ID=" + appisd.Item_ID.ToString() + ")";
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

                    string sql_Delete_DocInvoice_Atom_Item_Stock = null;
                    if (xDocTyp.Equals(GlobalData.const_DocInvoice))
                    {
                        sql_Delete_DocInvoice_Atom_Item_Stock = "delete from DocInvoice_ShopC_Item where (DocInvoice_ID = " + appisd.DocInvoice_ID.ToString()
                                                                        + ") and DocInvoice_ShopC_Item.ID in " + s_in_ID_list;
                    }
                    else if (xDocTyp.Equals(GlobalData.const_DocProformaInvoice))
                    {
                        sql_Delete_DocInvoice_Atom_Item_Stock = "delete from DocProformaInvoice_ShopC_Item where (DocProformaInvoice_ID = " + appisd.DocInvoice_ID.ToString()
                                                                        + ") and DocProformaInvoice_ShopC_Item.ID in " + s_in_ID_list;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:Basket.cs:Basket:RemoveFactory:xDocTyp=" + xDocTyp + " not implemented.");
                        return false;
                    }

                    object objret = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_DocInvoice_Atom_Item_Stock, null, ref objret, ref Err))
                    {
                        string sql_Delete_Atom_Price_Item = "delete from Atom_Price_Item where ID not in  (select Atom_Price_Item_ID from DocInvoice_ShopC_Item UNION select Atom_Price_Item_ID from DocProformaInvoice_ShopC_Item)";
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Price_Item, null, ref objret, ref Err))
                        {
                            string sql_Delete_Atom_Item_Image = "delete from Atom_Item_Image where Atom_Item_Image.Atom_Item_ID not in (select Atom_Item_ID from Atom_Price_Item)";
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_Image, null, ref objret, ref Err))
                            {
                                string sql_Delete_Atom_Item_ImageLib = "delete from Atom_Item_ImageLib where ID not in (select Atom_Item_ImageLib_ID from Atom_Item_Image)";
                                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_ImageLib, null, ref objret, ref Err))
                                {
                                    Remove_from_list(appisd);
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
                        LogFile.Error.Show("ERROR:Basket:delete from DocInvoice_ShopC_Item:Err=" + Err);
                        return false;
                    }
                }
                else
                {
//                    LogFile.Error.Show("ERROR:Basket:dt1.Rows.Count == 0 !");
                    // nothing to delete
                    return true;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:Basket:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private void Remove_from_list(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
             this.m_DocInvoice_ShopC_Item_Data_LIST.Remove(appisd);
        }

        private void RemoveFactory_from_list(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            List<Stock_Data> Stock_Data_to_remove_List = new List<Stock_Data>();
            foreach (Stock_Data sd in appisd.m_ShopShelf_Source.Stock_Data_List)
            {
                if (sd.Stock_ID == null)
                {
                    Stock_Data_to_remove_List.Add(sd);
                }
            }

            foreach (Stock_Data sd in Stock_Data_to_remove_List)
            {
                appisd.m_ShopShelf_Source.Stock_Data_List.Remove(sd);
            }

            if (appisd.m_ShopShelf_Source.Stock_Data_List.Count == 0)
            {
                this.m_DocInvoice_ShopC_Item_Data_LIST.Remove(appisd);
            }

        }
        private void RemoveStock_from_list(Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd)
        {
            List<Stock_Data> Stock_Data_to_remove_List = new List<Stock_Data>();
            foreach (Stock_Data sd in appisd.m_ShopShelf_Source.Stock_Data_List)
            {
                if (sd.Stock_ID != null)
                {
                    Stock_Data_to_remove_List.Add(sd);
                }
            }

            foreach (Stock_Data sd in Stock_Data_to_remove_List)
            {
                appisd.m_ShopShelf_Source.Stock_Data_List.Remove(sd);
            }

            if (appisd.m_ShopShelf_Source.Stock_Data_List.Count == 0)
            {
                this.m_DocInvoice_ShopC_Item_Data_LIST.Remove(appisd);
            }
        }


        private bool UpdateStock(ID xAtom_WorkPeriod_ID,List<Return_to_shop_shelf_data> Return_to_basket_data_List, List<SQL_Parameter> lpar)
        {
            string Err = null;
            object objret = null;
            DateTime EventTime = DateTime.Now;
            foreach (Return_to_shop_shelf_data rtb in Return_to_basket_data_List)
            {
                if (DBSync.DBSync.ExecuteNonQuerySQL(rtb.sql_update_stock, lpar, ref objret, ref Err))
                {
                    ID JOURNAL_Stock_ID = null;
                    if (f_JOURNAL_Stock.Get(rtb.stock_id, f_JOURNAL_Stock.JOURNAL_Stock_Type_ID_from_basket_to_stock,xAtom_WorkPeriod_ID, EventTime, rtb.dQuantity_from_basket_to_stock, ref JOURNAL_Stock_ID))
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


        public bool Remove_and_put_back_to_ShopShelf(ID xAtom_WorkPeriod_ID,string xDocTyp,Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, ShopShelf shopShelf)
        {
            if (xDocTyp==null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:Basket.cs:Basket:Remove_and_put_back_to_ShopShelf: xDocTyp==null.");
                return false;
            }
            string sql = @"select appis.ID,
                                  s.ID as Stock_ID,
                                  appis.dQuantity,
                                  s.dQuantity as Stock_dQuantity
                                  from "+xDocTyp+@"_ShopC_Item  appis
                                  inner join Stock s on appis.Stock_ID = s.ID
                                  inner join Atom_price_item api on api.ID = appis.Atom_price_item_ID
                                  inner join Atom_Item ai on ai.ID = api.Atom_Item_ID
                                  inner join Item i on i.UniqueName = ai.UniqueName
                                  where  ("+xDocTyp+@"_ID = " + appisd.DocInvoice_ID.ToString() + ") and (i.ID=" + appisd.Item_ID.ToString() + ")";
            DataTable dt1 = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt1, sql, ref Err))
            {
                string s_in_ID_list = null;
                if (dt1.Rows.Count > 0)
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    List<Return_to_shop_shelf_data> Return_to_basket_data_List = new List<Return_to_shop_shelf_data>();
                    int i = 0;
                    foreach (DataRow dr in dt1.Rows)
                    {
                        decimal dQuantity_stock = (decimal)dr["Stock_dQuantity"];
                        decimal dQuantity_New_InStock = (decimal)dr["dQuantity"] + dQuantity_stock;
                        decimal dQuantity_diff = dQuantity_New_InStock - dQuantity_stock;

                        string spar_dQuantity_New_InStock = "@par_dQuantity_New_InStock" + i.ToString();
                        ID stock_id = new ID(dr["Stock_ID"]);
                        SQL_Parameter par_dQuantity_New_InStock = new SQL_Parameter(spar_dQuantity_New_InStock, SQL_Parameter.eSQL_Parameter.Decimal, false, dQuantity_New_InStock);
                        lpar.Add(par_dQuantity_New_InStock);
                        Return_to_shop_shelf_data rtb = new Return_to_shop_shelf_data("update stock set dQuantity = " + spar_dQuantity_New_InStock + " where ID = " + stock_id.ToString(), stock_id, dQuantity_diff);
                        Return_to_basket_data_List.Add(rtb);
                        ID id = tf.set_ID(dr["ID"]);
                        if (s_in_ID_list == null)
                        {
                            s_in_ID_list += "(" + id.ToString();
                        }
                        else
                        {
                            s_in_ID_list += "," + id.ToString();
                        }
                        i++;
                        shopShelf.Set_dQuantity_New_InStock(stock_id, dQuantity_New_InStock);
                    }
                    s_in_ID_list += ")";
                    object objret = null;
                    if (UpdateStock(xAtom_WorkPeriod_ID, Return_to_basket_data_List, lpar))
                    {

                        string sql_Delete_DocInvoice_Atom_Item_Stock = "delete from "+xDocTyp+@"_ShopC_Item where Stock_ID is not null and ("+xDocTyp+@"_ID = " + appisd.DocInvoice_ID.ToString()
                                                                            + ") and "+xDocTyp+@"_ShopC_Item.ID in " + s_in_ID_list;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_DocInvoice_Atom_Item_Stock, null, ref objret, ref Err))
                        {
                            string sql_Delete_Atom_Price_Item = "delete from Atom_Price_Item where ID not in  (select Atom_Price_Item_ID from DocInvoice_ShopC_Item UNION select Atom_Price_Item_ID from DocProformaInvoice_ShopC_Item)";
                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Price_Item, null, ref objret, ref Err))
                            {
                                string sql_Delete_Atom_Item_Image = "delete from Atom_Item_Image where Atom_Item_Image.Atom_Item_ID not in (select Atom_Item_ID from Atom_Price_Item)";
                                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_Image, null, ref objret, ref Err))
                                {
                                    string sql_Delete_Atom_Item_ImageLib = "delete from Atom_Item_ImageLib where ID not in (select Atom_Item_ImageLib_ID from Atom_Item_Image)";
                                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_Delete_Atom_Item_ImageLib, null, ref objret, ref Err))
                                    {
                                        RemoveStock_from_list(appisd);
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
                            LogFile.Error.Show("ERROR:Basket:delete from "+xDocTyp+"_ShopC_Item:Err=" + Err);
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



        public Atom_DocInvoice_ShopC_Item_Price_Stock_Data Contains(Item_Data m_Item_Data)
        {
            foreach (object o in this.m_DocInvoice_ShopC_Item_Data_LIST)
            {
                if (((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Atom_Item_UniqueName.v.Equals(m_Item_Data.Item_UniqueName.v))
                {
                    return ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o);
                }
            }
            return null;
        }

        public void GetPriceSum(ref decimal dsum_GrossSum_Basket, ref decimal dsum_TaxSum_Basket, ref decimal dsum_NetSum, ref StaticLib.TaxSum TaxSum)
        {
            foreach (object o in this.m_DocInvoice_ShopC_Item_Data_LIST)
            {
                decimal dQuantity = ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).dQuantity_FromFactory + ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).dQuantity_FromStock;
                decimal RetailPriceWithDisount = 0;
                decimal tax_price = 0;
                decimal net_price = 0;
                StaticLib.Func.CalculatePrice(((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).RetailPricePerUnit.v,
                                        dQuantity,
                                        ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Discount.v,
                                        ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).ExtraDiscount.v,
                                        ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Atom_Taxation_Rate.v,
                                        ref RetailPriceWithDisount,
                                        ref tax_price,
                                        ref net_price,
                                        ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Atom_Currency_DecimalPlaces.v);

                TaxSum.Add(tax_price, net_price, ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Atom_Taxation_Name.v, ((Atom_DocInvoice_ShopC_Item_Price_Stock_Data)o).Atom_Taxation_Rate.v);

                dsum_GrossSum_Basket += RetailPriceWithDisount;
                dsum_TaxSum_Basket += tax_price;
                dsum_NetSum += net_price;
            }
        }

        public void Add(ID xDocInvoice_ID,ID doc_ShopC_Item_ID,Item_Data xItemData,decimal xFactoryQuantity, decimal xStockQuantity,  ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, bool b_from_factory)
        {
            foreach (Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisdx in m_DocInvoice_ShopC_Item_Data_LIST)
            {
                if (appisdx.Item_ID.Equals(xItemData.Item_ID))
                {
                    appisdx.m_ShopShelf_Source.Add_Stock_Data(xItemData, doc_ShopC_Item_ID, xFactoryQuantity, xStockQuantity, b_from_factory);
                    appisd = appisdx;
                    return;
                }
            }
            appisd = new Atom_DocInvoice_ShopC_Item_Price_Stock_Data();
            appisd.Set( xItemData, xDocInvoice_ID, xFactoryQuantity, xStockQuantity, doc_ShopC_Item_ID, b_from_factory);
            m_DocInvoice_ShopC_Item_Data_LIST.Add(appisd);

        }

        public void Add_WithNoTakeForItemData(ID xDocInvoice_ID, ID doc_ShopC_Item_ID, Item_Data xItemData, decimal xFactoryQuantity, decimal xStockQuantity, ref Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisd, bool b_from_factory)
        {
            foreach (Atom_DocInvoice_ShopC_Item_Price_Stock_Data appisdx in m_DocInvoice_ShopC_Item_Data_LIST)
            {
                if (appisdx.Item_ID.Equals(xItemData.Item_ID))
                {
                    appisdx.m_ShopShelf_Source.Add_Stock_Data(xItemData, doc_ShopC_Item_ID, xFactoryQuantity, xStockQuantity, b_from_factory);
                    appisd = appisdx;
                    return;
                }
            }
            appisd = new Atom_DocInvoice_ShopC_Item_Price_Stock_Data();
            appisd.Set_WithNoTakeForItemData(xItemData, xDocInvoice_ID, xFactoryQuantity, xStockQuantity, doc_ShopC_Item_ID, b_from_factory);
            m_DocInvoice_ShopC_Item_Data_LIST.Add(appisd);

        }

    }
}
