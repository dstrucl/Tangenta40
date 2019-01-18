#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using TangentaTableClass;
using CodeTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class DBTablesAndColumnNamesOfConsumption
    {
        public string stbl_Atom_myOrganisation_Person_TableName = null;
        public string stbl_Atom_myOrganisation_TableName = null;
        public string stbl_myOrganisation_TableName = null;
        public string stbl_myOrganisation_Person_TableName = null;
        public string stbl_myOrganisation_PersonData_TableName = null;

        public string stbl_cStreetName_Org_TableName = null;
        public string stbl_cHouseNumber_Org_TableName = null;
        public string stbl_cZIP_Org_TableName = null;
        public string stbl_cCity_Org_TableName = null;
        public string stbl_cCountry_Org_TableName = null;
        public string stbl_cState_Org_TableName = null;

        public string stbl_cAddress_Org_TableName = null;

        public string stbl_BuyerAtom_Person_TableName = null;
        public string stbl_BuyerOrganisationAtom_TableName = null;
        public string stbl_TermsOfPayment_TableName = null;
        public string stbl_Consumption_TableName = null;
        public string stbl_Taxation_TableName = null;

        public string stbl_ShopBItem_TableName = null;
        public string stbl_ShopBItem_Image_TableName = null;

        public string stbl_Atom_ShopBItem_TableName = null;
        public string stbl_Atom_ShopBItem_Name_TableName = null;
        public string stbl_Atom_ShopBItem_Image_TableName = null;

        public string stbl_Atom_Item_Name_TableName = null;
        public string stbl_Atom_Item_barcode_TableName = null;
        public string stbl_Atom_Item_Description_TableName = null;
        public string stbl_Atom_Item_Image_TableName = null;
        public string stbl_Atom_Item_ImageLib_TableName = null;
        public string stbl_Atom_Taxation_TableName = null;
        public string stbl_Atom_Item_WarrantyConditions_TableName = null;
        public string stbl_Atom_Item_TableName = null;
        public string stbl_Atom_Item_ExpiryDescription_TableName = null;
        public string stbl_Atom_Warranty_TableName = null;

        public string stbl_Consumption_Atom_Item_Stock_TableName = null;

        public string col_FinancialYear;
        public string col_NumberInFinancialYear;


        public string colShopBItem_ID = "ID";
        public string colShopBItemName = "SimpleItem_Name";
        public string colShopBItemAbbreviation = "SimpleItem_Abbreviation";
        public string colShopBItemMinimumShopBItemPrice = "SimpleItem_MinimumSimpleItemPrice";
        public string colPriceShopBItemRetailShopBItemPrice = "RetailSimpleItemPrice";
        public string colShopBItemTaxation_Name = "Taxation_Name";
        public string colShopBItemTaxation_Rate = "Taxation_Rate";
        public string colShopBItem_ShopBItem_Image_Image_Hash = "SimpleItem_Image_Image_Hash";
        public string colShopBItem_ShopBItem_Image_Image_Data = "SimpleItem_Image_Image_Data";
        public string colShopBItem_Code = "SimpleItem_Code";

        public string colStockVIEW_ID = "ID";
        public string colStockVIEW_Item_Name = "Item_Name";
        public string colStockVIEW_Item_ItemImage = "Item_ItemImage";
        public string colStockVIEW_Item_barcode = "Item_barcode";
        public string colStockVIEW_Item_ExpectedShelfLifeInDays = "Item_ExpectedShelfLifeInDays";
        public string colStockVIEW_Item_SaleBeforeExpiryDateInDays = "Item_SaleBeforeExpiryDateInDays";
        public string colStockVIEW_Item_DiscardBeforeExpiryDateInDays = "Item_DiscardBeforeExpiryDateInDays";
        public string colStockVIEW_Item_NeverExpires = "Item_NeverExpires";
        public string colStockVIEW_Item_ExpiryDescription = "Item_ExpiryDescription";
        public string colStockVIEW_Item_ToOffer = "Item_ToOffer";
        public string colStockVIEW_PurchaseOrganisation_Name = "PurchaseOrganisation_Name";
        public string colStockVIEW_PurchaseOrganisation_Address = "PurchaseOrganisation_Address";
        public string colStockVIEW_Taxation_Rate = "Taxation_Rate";
        public string colStockVIEW_Stock_PurchasePricePerUnit = "Stock_PurchasePricePerUnit";
        public string colStockVIEW_Stock_RetailPricePerUnit = "Stock_RetailPricePerUnit";
        public string colStockVIEW_Stock_Quantity = "Stock_Quantity";
        public string colStockVIEW_Stock_ExpiryDate = "Stock_ExpiryDate";

        //SelectedSimpleItem

        public string column_Selected_Atom_Price_ShopBItem_ID = "Selected_Consumption_ShopB_Item_ID";
        public Type column_Selected_Atom_Price_ShopBItem_ID_TYPE = typeof(long);

        public string column_SelectedShopBItem_btn_discount = "btn_discount";
        public  string column_SelectedShopBItem_btn_deselect = "btn_deselect";
        public string column_total_discount = "total_discount";
        public string btn_Select_Name = "btn_Select";


        public string column_SelectedShopBItemName = "SelectedSimpleItemName";
        public Type column_SelectedShopBItemName_TYPE = typeof(string);
        public string column_SelectedShopBItemPrice = "SelectedSimpleItemPrice";
        public Type column_SelectedShopBItemPrice_TYPE = typeof(decimal);

        public string column_SelectedShopBItemRetailPricePerUnit = "SelectedSimpleItemRetailPricePerUnit";
        public Type column_SelectedShopBItemRetailPricePerUnit_TYPE = typeof(decimal);

        public string column_SelectedShopBItemPriceTax = "SelectedSimpleItemPriceTax";
        public Type column_SelectedShopBItemPriceTax_TYPE = typeof(decimal);

        public string column_SelectedShopBItem_TaxName = "SelectedSimpleItem_TaxName";
        public Type column_SelectedShopBItem_TaxName_TYPE = typeof(string);

        public string column_SelectedShopBItem_TaxRate = "SelectedSimpleItem_TaxRate";
        public Type column_SelectedShopBItem_TaxRate_TYPE = typeof(decimal);


        public string column_SelectedShopBItemPriceWithoutTax = "SelectedSimpleItemPriceWithoutTax";
        public Type column_SelectedShopBItemPriceWithoutTax_TYPE = typeof(decimal);
        public string column_SelectedShopBItemPriceDiscount = "SelectedSimpleItemPriceDiscount";
        public Type column_SelectedShopBItemPriceDiscount_TYPE = typeof(decimal);
        public string column_SelectedShopBItem_ShopBItem_ID = "SelectedSimpleItem_SimpleItem_ID";
        public Type column_SelectedShopBItem_ShopBItem_ID_TYPE = typeof(long);
        public string column_SelectedShopBItem_Count = "SelectedSimpleItem_Count";
        public Type column_SelectedShopBItem_Count_TYPE = typeof(int);

        public string column_SelectedShopBItem_ExtraDiscount = "SelectedSimpleItem_ExtraDiscount";
        public Type column_SelectedShopBItem_ExtraDiscount_TYPE = typeof(decimal);


        public string colmyOrganisation_ID;
        public string colmyOrganisation_as_ID;


        public string col_cAddress_Org_cStreetName_Org_ID;
        public string col_cAddress_Org_cHouseNumber_Org_ID;
        public string col_cAddress_Org_cZIP_Org_ID;
        public string col_cAddress_Org_cCity_Org_ID;
        public string col_cAddress_Org_cCountry_Org_ID;
        public string col_cAddress_Org_cState_Org_ID;



        public string colmyOrganisation_Person_as_company_Person_ID;
        public string colmyOrganisation_Person_as_Office_ID;

        public string colmyOrganisation_Person_ID;

        public string colAtom_myOrganisation_Person_Atom_myOrganisation_ID;
        public string colAtom_myOrganisation_Person_as_Atom_myOrganisation_ID;
        public string colAtom_myOrganisation_Person_as_Atom_Person_ID;
        public string colAtom_myOrganisation_Person_Job;
        public string colAtom_myOrganisation_Person_Description;

        public string colAtom_myOrganisation_ID;
        public string colAtom_myOrganisation_as_ID;
        public string colAtom_myOrganisation_Name;
        public string colAtom_myOrganisation_Atom_cAddress_Org;
        public string colAtom_myOrganisation_TaxID;
        public string colAtom_myOrganisation_as_TaxID;
        public string colAtom_myOrganisation_Organisation_id;
        public string colAtom_myOrganisation_PhoneNumber;
        public string colAtom_myOrganisation_Email;
        public string colAtom_myOrganisation_HomePage;


        public string colmyOrganisation_Person_Office_ID;

        public string colmyOrganisation_Name;



        public string colmyOrganisation_TaxID;
        public string colmyOrganisation_as_TaxID;
        public string colmyOrganisation_Organisation_id;
        public string colmyOrganisation_PhoneNumber;
        public string colmyOrganisation_Email;
        public string colmyOrganisation_HomePage;
        public string colmyOrganisation_BankName;
        public string colmyOrganisation_TRR;

        public string colConsumption_ID;
        public string colConsumption_as_ID;

        public string colConsumption_myOrganisation_Person_ID;
        public string colConsumption_as_myOrganisation_Person_ID;

        public string colConsumption_Atom_myOrganisation_Person_ID;
        public string colConsumption_as_Atom_myOrganisation_Person_ID;

        public string colConsumption_myOrganisation_ID;
        public string colConsumption_as_myOrganisation_ID;

        public string colConsumption_FinancialYear;
        public string colConsumption_as_FinancialYear;
        public string colConsumption_NumberInFinancialYear;
        public string colConsumption_as_NumberInFinancialYear;
        public string colConsumption_Draft;
        public string colConsumption_PrintTime;
        public string colConsumption_as_PrintTime;
        public string colConsumption_NetSum;
        public string colConsumption_Discount;
        public string colConsumption_EndSum;
        public string colConsumption_TaxSum;
        public string colConsumption_GrossSum;
        public string colConsumption_BuyerAtom_Person_ID;
        public string colConsumption_BuyerOrganisationAtom_ID;
        //public string colConsumption_WarrantyExists;
        //public string colConsumption_WarrantyDurationType;
        //public string colConsumption_WarrantyDuration;
        //public string colConsumption_WarrantyConditions;
        //public string colConsumption_DocDuration;
        //public string colConsumption_DocDurationType;
        //public string colConsumption_TermsOfPayment_ID;
        public string colConsumption_Invoice_ID;

        public string colInvoice_ID;
        public string colInvoice_InvoiceTime;
        //public string colInvoice_PaymentDeadline;
        public string colInvoice_Paid;
        public string colInvoice_Storno;


        public DBTablesAndColumnNamesOfConsumption()
        {
            TangentaTableClass.SQL_Database_Tables_Definition td = null;
            if (DBSync.DBSync.DB_for_Tangenta != null)
            {
                td = DBSync.DBSync.DB_for_Tangenta.mt;


                SQLTable tbl_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.myOrganisation));
                SQLTable tbl_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.myOrganisation_Person));
                SQLTable tbl_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Person));
                SQLTable tbl_Atom_myOrganisation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_myOrganisation));
                SQLTable tbl_Atom_myOrganisation_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_myOrganisation_Person));
                SQLTable tbl_Consumption = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Consumption));
                SQLTable tbl_Atom_Customer_Person = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Customer_Person));
                SQLTable tbl_Atom_Customer_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Customer_Org));
                SQLTable tbl_TermsOfPayment = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.TermsOfPayment));
                SQLTable tbl_Taxation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Taxation));
                SQLTable tbl_ShopBItem = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.SimpleItem));
                SQLTable tbl_ShopBItem_Image = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.SimpleItem_Image));
                SQLTable tbl_Atom_ShopBItem = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_SimpleItem));
                SQLTable tbl_Atom_ShopBItem_Name = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_SimpleItem_Name));
                SQLTable tbl_Atom_ShopBItem_Image = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_SimpleItem_Image));
                SQLTable tbl_Atom_Taxation = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Taxation));

                SQLTable tbl_cStreetName_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.cStreetName_Org));
                SQLTable tbl_cHouseNumber_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.cHouseNumber_Org));
                SQLTable tbl_cZIP_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.cZIP_Org));
                SQLTable tbl_cCity_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.cCity_Org));
                SQLTable tbl_cCountry_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.cCountry_Org));
                SQLTable tbl_cState_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.cState_Org));

                SQLTable tbl_cAddress_Org = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.cAddress_Org));

                SQLTable tbl_Atom_Item_Name = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Item_Name));
                SQLTable tbl_Atom_Item_barcode = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Item_barcode));
                SQLTable tbl_Atom_Item_Description = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Item_Description));
                SQLTable tbl_Atom_Item_Image = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Item_Image));
                SQLTable tbl_Atom_Item_ImageLib = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Item_ImageLib));
                SQLTable tbl_Atom_Warranty = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Warranty));
                SQLTable tbl_Atom_Item = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Item));
                SQLTable tbl_Atom_Expiry = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Atom_Expiry));
                SQLTable tbl_Consumption_Atom_Item_Stock = DBSync.DBSync.DB_for_Tangenta.m_DBTables.GetTable(typeof(TangentaTableClass.Consumption_ShopC_Item));

                stbl_myOrganisation_TableName = tbl_myOrganisation.TableName;

                stbl_cStreetName_Org_TableName = tbl_cStreetName_Org.TableName;
                stbl_cHouseNumber_Org_TableName = tbl_cHouseNumber_Org.TableName;
                stbl_cZIP_Org_TableName = tbl_cZIP_Org.TableName;
                stbl_cCity_Org_TableName = tbl_cCity_Org.TableName;
                stbl_cCountry_Org_TableName = tbl_cCountry_Org.TableName;
                stbl_cState_Org_TableName = tbl_cState_Org.TableName;

                stbl_Atom_Item_Name_TableName = tbl_Atom_Item_Name.TableName;
                stbl_Atom_Item_barcode_TableName = tbl_Atom_Item_barcode.TableName;
                stbl_Atom_Item_Description_TableName = tbl_Atom_Item_Description.TableName;
                stbl_Atom_Item_Image_TableName = tbl_Atom_Item_Image.TableName;
                stbl_Atom_Item_ImageLib_TableName = tbl_Atom_Item_ImageLib.TableName;
                stbl_Atom_Taxation_TableName = tbl_Atom_Taxation.TableName;
                stbl_Atom_Item_WarrantyConditions_TableName = tbl_Atom_Warranty.TableName;
                stbl_Atom_Item_TableName = tbl_Atom_Item.TableName;
                stbl_Consumption_Atom_Item_Stock_TableName = tbl_Consumption_Atom_Item_Stock.TableName;

                stbl_Atom_Item_ExpiryDescription_TableName = tbl_Atom_Expiry.TableName;

                stbl_Atom_myOrganisation_TableName = tbl_Atom_myOrganisation.TableName;
                stbl_Atom_myOrganisation_Person_TableName = tbl_Atom_myOrganisation_Person.TableName;


                stbl_myOrganisation_Person_TableName = tbl_myOrganisation_Person.TableName;
                stbl_myOrganisation_PersonData_TableName = tbl_Person.TableName;
                stbl_BuyerAtom_Person_TableName = tbl_Atom_Customer_Person.TableName;

                stbl_BuyerOrganisationAtom_TableName = tbl_Atom_Customer_Org.TableName;
                stbl_TermsOfPayment_TableName = tbl_TermsOfPayment.TableName;

                stbl_Consumption_TableName = tbl_Consumption.TableName;

                stbl_Taxation_TableName = tbl_Taxation.TableName;


                stbl_ShopBItem_TableName = tbl_ShopBItem.TableName;
                stbl_ShopBItem_Image_TableName = tbl_ShopBItem_Image.TableName;

                stbl_Atom_ShopBItem_TableName = tbl_Atom_ShopBItem.TableName;
                stbl_Atom_ShopBItem_Name_TableName = tbl_Atom_ShopBItem_Name.TableName;
                stbl_Atom_ShopBItem_Image_TableName = tbl_Atom_ShopBItem_Image.TableName;

                stbl_Atom_Warranty_TableName = tbl_Atom_Warranty.TableName;

                col_FinancialYear = GetName(td.m_Consumption.FinancialYear.GetType());
                col_NumberInFinancialYear = GetName(td.m_Consumption.NumberInFinancialYear.GetType());

                colmyOrganisation_Person_ID = stbl_myOrganisation_Person_TableName + "." + GetName(td.m_myOrganisation_Person.ID.GetType());
                colmyOrganisation_ID = stbl_myOrganisation_TableName + "." + GetName(td.m_myOrganisation.ID.GetType());

                col_cAddress_Org_cHouseNumber_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cHouseNumber_Org.GetType()) + "_ID";
                col_cAddress_Org_cZIP_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cZIP_Org.GetType()) + "_ID";
                col_cAddress_Org_cCity_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cCity_Org.GetType()) + "_ID";
                col_cAddress_Org_cCountry_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cCountry_Org.GetType()) + "_ID";
                col_cAddress_Org_cState_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cState_Org.GetType()) + "_ID";




                colmyOrganisation_Person_as_company_Person_ID = stbl_myOrganisation_Person_TableName + "_" + GetName(td.m_myOrganisation_Person.ID.GetType());
                colmyOrganisation_Person_ID = stbl_myOrganisation_Person_TableName + "." + GetName(td.m_myOrganisation_Person.ID.GetType());
                colmyOrganisation_ID = stbl_myOrganisation_TableName + "." + GetName(td.m_myOrganisation.ID.GetType());
                colmyOrganisation_as_ID = stbl_myOrganisation_TableName + "_" + GetName(td.m_myOrganisation.ID.GetType());

                colmyOrganisation_Person_Office_ID = stbl_myOrganisation_Person_TableName + "." + GetName(td.m_myOrganisation_Person.m_Office.ID.GetType());
                colmyOrganisation_Person_as_Office_ID = stbl_myOrganisation_Person_TableName + "_" + GetName(td.m_myOrganisation_Person.m_Office.ID.GetType());

                colAtom_myOrganisation_Person_Atom_myOrganisation_ID = stbl_Atom_myOrganisation_Person_TableName + "." + GetName(td.m_Atom_myOrganisation_Person.m_Atom_Office.ID.GetType());
                colAtom_myOrganisation_Person_as_Atom_myOrganisation_ID = stbl_Atom_myOrganisation_Person_TableName + "_" + GetName(td.m_Atom_myOrganisation_Person.m_Atom_Office.ID.GetType());
                colAtom_myOrganisation_Person_as_Atom_Person_ID = stbl_Atom_myOrganisation_Person_TableName + "." + GetName(td.m_Atom_myOrganisation_Person.m_Atom_Person.ID.GetType());
                colAtom_myOrganisation_Person_Job = stbl_Atom_myOrganisation_Person_TableName + "." + GetName(td.m_Atom_myOrganisation_Person.Job.GetType());
                colAtom_myOrganisation_Person_Description = stbl_Atom_myOrganisation_Person_TableName + "." + GetName(td.m_Atom_myOrganisation_Person.Description.GetType());

                colAtom_myOrganisation_ID = stbl_Atom_myOrganisation_TableName + "." + GetName(td.m_Atom_myOrganisation.ID.GetType());
                colAtom_myOrganisation_as_ID = stbl_Atom_myOrganisation_TableName + "_" + GetName(td.m_Atom_myOrganisation.ID.GetType());


                //colmyOrganisation_cStreetName_Org_ID = GetName(td.m_myOrganisation.m_cStreetName_Org.GetType());
                //colmyOrganisation_cHouseNumber_Org_ID = GetName(td.m_myOrganisation.m_cHouseNumber_Org.GetType());
                //colmyOrganisation_cCity_Org_ID = GetName(td.m_myOrganisation.m_cCity_Org.GetType());
                //colmyOrganisation_cCountry_Org_ID = GetName(td.m_myOrganisation.m_cCountry_Org.GetType());
                //colmyOrganisation_cState_Org_ID = GetName(td.m_myOrganisation.m_cState_Org.GetType());
                //colmyOrganisation_cZIP_Org_ID = GetName(td.m_myOrganisation.m_cZIP_Org.GetType());




                colConsumption_ID = stbl_Consumption_TableName + "." + GetName(td.m_Consumption.ID.GetType());
                colConsumption_as_ID = stbl_Consumption_TableName + "_" + GetName(td.m_Consumption.ID.GetType());

                colConsumption_myOrganisation_Person_ID = stbl_myOrganisation_Person_TableName + "." + GetName(td.m_Atom_myOrganisation_Person.ID.GetType());
                colConsumption_as_myOrganisation_Person_ID = stbl_Atom_myOrganisation_Person_TableName + "_" + GetName(td.m_Atom_myOrganisation_Person.ID.GetType());

                colConsumption_Atom_myOrganisation_Person_ID = stbl_Atom_myOrganisation_Person_TableName + "." + GetName(td.m_Atom_myOrganisation_Person.ID.GetType());
                colConsumption_as_Atom_myOrganisation_Person_ID = stbl_Atom_myOrganisation_Person_TableName + "_" + GetName(td.m_Atom_myOrganisation_Person.ID.GetType());

                colConsumption_myOrganisation_ID = stbl_myOrganisation_TableName + "." + GetName(td.m_myOrganisation.ID.GetType());
                colConsumption_as_myOrganisation_ID = stbl_myOrganisation_TableName + "_" + GetName(td.m_myOrganisation.ID.GetType());

                colConsumption_FinancialYear = GetName(td.m_Consumption.FinancialYear.GetType());
                colConsumption_NumberInFinancialYear = GetName(td.m_Consumption.NumberInFinancialYear.GetType());

                colConsumption_Draft = GetName(td.m_Consumption.Draft.GetType());
                colConsumption_NetSum = GetName(td.m_Consumption.NetSum.GetType());
                colConsumption_EndSum = GetName(td.m_Consumption.EndSum.GetType());
                colConsumption_TaxSum = GetName(td.m_Consumption.TaxSum.GetType());
                colConsumption_GrossSum = GetName(td.m_Consumption.GrossSum.GetType()); ;
                colConsumption_BuyerAtom_Person_ID = stbl_BuyerAtom_Person_TableName + "_" + GetName(td.m_BuyerAtom_Person.ID.GetType());
                colConsumption_BuyerOrganisationAtom_ID = stbl_BuyerOrganisationAtom_TableName + "_" + GetName(td.m_Atom_Organisation.ID.GetType());
                //colConsumption_WarrantyExists = GetName(td.m_Consumption.WarrantyExist.GetType());
                //colConsumption_WarrantyDurationType = GetName(td.m_Consumption.WarrantyDurationType.GetType());
                //colConsumption_WarrantyDuration = GetName(td.m_Consumption.WarrantyDuration.GetType());
                //colConsumption_WarrantyConditions = GetName(td.m_Consumption.WarrantyConditions.GetType());
                //colConsumption_TermsOfPayment_ID = stbl_TermsOfPayment_TableName + "_" + GetName(td.m_TermsOfPayment.ID.GetType());
                colConsumption_FinancialYear = stbl_Consumption_TableName + "." + GetName(td.m_Consumption.FinancialYear.GetType());
                colConsumption_as_FinancialYear = stbl_Consumption_TableName + "_" + GetName(td.m_Consumption.FinancialYear.GetType());
                colConsumption_NumberInFinancialYear = stbl_Consumption_TableName + "." + GetName(td.m_Consumption.NumberInFinancialYear.GetType());
                colConsumption_as_NumberInFinancialYear = stbl_Consumption_TableName + "_" + GetName(td.m_Consumption.NumberInFinancialYear.GetType());
                colConsumption_Invoice_ID = stbl_Consumption_TableName + "." + stbl_Consumption_TableName + "_" + GetName(td.m_Consumption.ID.GetType());

                //colInvoice_PaymentDeadline = stbl_Consumption_TableName + "." + GetName(td.m_Consumption.PaymentDeadline.GetType());
                colInvoice_Storno = stbl_Consumption_TableName + "." + GetName(td.m_Consumption.Storno.GetType()); ;

            }
        }

        public string GetName(Type type)
        {
            string str = type.ToString();
            int i = str.LastIndexOf('.');
            str = str.Substring(i + 1);
            return str;
        }

    }
}
