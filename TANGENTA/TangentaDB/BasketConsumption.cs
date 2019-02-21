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
            sql_select_Consumption_ShopC_Item =


              @"
                SELECT 
                csci.ID as Consumption_ShopC_Item_ID,
                csci.Consumption_ID,
                csci.Item_ID,
                i.ID as Item_ID,
                s.PurchasePrice_Item_ID as PurchasePrice_Item_ID,
                pp.PurchasePricePerUnit as PurchasePricePerUnit,
                pp.Discount as PurchasePricePerUnit_Discount,
                i.UniqueName AS Item_UniqueName,
                i.Name AS Item_Name,
                i.barcode AS Item_barcode,
                t.Name AS Taxation_Name,
                t.Rate AS Taxation_Rate,
                i.Description AS Item_Description,
                i.Warranty_ID as Warranty_ID,
                w.WarrantyDurationType AS WarrantyDurationType,
                w.WarrantyDuration AS WarrantyDuration,
                w.WarrantyConditions AS WarrantyConditions,
                i.Expiry_ID as Expiry_ID,
                e.ExpectedShelfLifeInDays AS Expiry_ExpectedShelfLifeInDays,
                e.SaleBeforeExpiryDateInDays AS Expiry_SaleBeforeExpiryDateInDays,
                e.DiscardBeforeExpiryDateInDays AS Expiry_DiscardBeforeExpiryDateInDays,
                e.ExpiryDescription AS Expiry_ExpiryDescription,
                u.Name AS Unit_Name,
                u.Symbol AS Unit_Symbol,
                u.DecimalPlaces AS Unit_DecimalPlaces,
                u.Description AS Unit_Description,
                u.StorageOption AS Unit_StorageOption,
               c.Name AS Currency_Name,
                c.Abbreviation AS Currency_Abbreviation,
                c.Symbol AS Currency_Symbol,
                c.DecimalPlaces AS Currency_DecimalPlaces,
                ii.Image_Hash as Image_Hash,
                ii.Image_Data as Image_Data,
                itm_g1.Name as s1_name,
                itm_g2.Name as s2_name, 
                itm_g3.Name as s3_name
                FROM Consumption_ShopC_Item  csci
				inner join Item itm on csci.Item_ID = itm.id
				inner join Consumption_ShopC_Item_Source cscis on  cscis.Consumption_ShopC_Item_ID = csci.ID
				inner join Stock s on cscis.Stock_ID = s.ID
				INNER JOIN  PurchasePrice_Item  ppi on s.PurchasePrice_Item_ID = ppi.ID
                inner join StockTake st on ppi.StockTake_ID = st.ID
                left  join Supplier sup on st.Supplier_ID = sup.ID
                left  join Contact ct on sup.Contact_ID = ct.ID
                left  join OrganisationData orgd on ct.OrganisationData_ID = orgd.ID
                left  join Organisation org on orgd.Organisation_ID = org.ID
				left  join cAddress_Org aorg on orgd.cAddress_Org_ID = aorg.ID
				left  join cStreetName_Org csnorg on aorg.cStreetName_Org_ID = csnorg.ID
				left  join cHouseNumber_Org chnorg  on aorg.cHouseNumber_Org_ID = chnorg.ID
				left  join cCity_Org citorg  on aorg.cCity_Org_ID = citorg.ID
		        left  join cZIP_Org cziporg  on aorg.cZIP_Org_ID = cziporg.ID
				left  join cCountry_Org ccorg  on aorg.cCountry_Org_ID = ccorg.ID
				left  join cState_Org cstorg  on aorg.cState_Org_ID = cstorg.ID
				
				left  join Person per on ct.Person_ID = per.ID
				left  join cFirstName cfn on per.cFirstName_ID = cfn.ID
				left  join cLastName cln on per.cLastName_ID = cln.ID
				left  join PersonData perd on perd.Person_ID = per.ID
				
				INNER JOIN  Item i on ppi.Item_ID = i.ID and itm.UniqueName = i.UniqueName
                INNER JOIN  PurchasePrice pp on ppi.PurchasePrice_ID = pp.ID
                INNER JOIN  Taxation t on pp.Taxation_ID = t.ID
				INNER JOIN  Currency c on pp.Currency_ID = c.ID
                INNER JOIN  Consumption cons ON csci.Consumption_ID = cons.ID 
                INNER JOIN  Unit u ON i.Unit_ID = u.ID 
				LEFT JOIN  Item_ParentGroup1 itm_g1 ON i.Item_ParentGroup1_ID = itm_g1.ID 
                LEFT JOIN  Item_ParentGroup2 itm_g2 ON itm_g1.Item_ParentGroup2_ID = itm_g2.ID 
                LEFT JOIN  Item_ParentGroup3 itm_g3 ON itm_g2.Item_ParentGroup3_ID = itm_g3.ID 
                LEFT JOIN  Warranty w ON i.Warranty_ID = w.ID 
                LEFT JOIN  Expiry e ON i.Expiry_ID = e.ID 
                LEFT JOIN  Item_Image ii ON i.Item_Image_ID = ii.ID
                where csci.Consumption_ID =" + xDoc_ID.ToString();
           
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
                        if (((Consumption_ShopC_Item)o).Item_UniqueName_v.v.Equals(item_UniqueName))
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
                        if (((Consumption_ShopC_Item)o).Item_UniqueName_v.v.Equals(item_UniqueName))
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
                    if (!f_Item.Get(dscix.Item_UniqueName_v.v,
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

       
        //}


        private void Remove_from_list(Consumption_ShopC_Item xdsci)
        {
             this.Basket_Consumption_ShopC_Item_LIST.Remove(xdsci);
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
                if (((Consumption_ShopC_Item)o).Item_UniqueName_v.v.Equals(m_Item_Data.Item_UniqueName_v.v))
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
               
                decimal PurchasePriceWithDisount = 0;
                decimal tax_price = 0;
                decimal net_price = 0;
                StaticLib.Func.CalculatePrice(dscix.PurchasePricePerUnit,
                                        dscix.dQuantity_all,
                                        dscix.PurchasePricePerUnit_Discount,
                                        0,
                                        dscix.TaxationRate,
                                        ref PurchasePriceWithDisount,
                                        ref tax_price,
                                        ref net_price,
                                        dscix.Atom_Currency_DecimalPlaces_v.v);

                TaxSum.Add(tax_price, net_price, dscix.Taxation_Name_v.v, dscix.Taxation_Rate_v.v);

                dsum_GrossSum_Basket += PurchasePriceWithDisount;
                dsum_TaxSum_Basket += tax_price;
                dsum_NetSum += net_price;
            }
        }
    }
}
