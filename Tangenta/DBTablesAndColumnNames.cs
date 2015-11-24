using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlagajnaTableClass;
using SQLTableControl;
using System.Windows.Forms.VisualStyles;
using LanguageControl;
using DBTypes;

namespace Tangenta
{
    public class DBTablesAndColumnNames
    {
        public string stbl_Atom_myCompany_Person_TableName = null;
        public string stbl_Atom_myCompany_TableName = null;
        public string stbl_myCompany_TableName = null;
        public string stbl_myCompany_Person_TableName = null;
        public string stbl_myCompany_PersonData_TableName = null;

        public string stbl_cStreetName_Org_TableName = null;
        public string stbl_cHouseNumber_Org_TableName = null;
        public string stbl_cZIP_Org_TableName = null;
        public string stbl_cCity_Org_TableName = null;
        public string stbl_cState_Org_TableName = null;
        public string stbl_cCountry_Org_TableName = null;

        public string stbl_cAddress_Org_TableName = null;

        public string stbl_BuyerAtom_Person_TableName = null;
        public string stbl_BuyerCompanyAtom_TableName = null;
        public string stbl_TermsOfPayment_TableName = null;
        public string stbl_Invoice_TableName = null;
        public string stbl_Taxation_TableName = null;
        public string stbl_ProformaInvoice_TableName = null;

        public string stbl_SimpleItem_TableName = null;
        public string stbl_SimpleItem_Image_TableName = null;

        public string stbl_Atom_SimpleItem_TableName = null;
        public string stbl_Atom_SimpleItem_Name_TableName = null;
        public string stbl_Atom_SimpleItem_Image_TableName = null;

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

        public string stbl_ProformaInvoice_Atom_Item_Stock_TableName = null;

        public string col_Invoice_ID; 
        public string col_FinancialYear;
        public string col_NumberInFinancialYear;


        public string colSimpleItem_ID = "ID";
        public string colSimpleItemName = "SimpleItem_Name";
        public string colSimpleItemAbbreviation = "SimpleItem_Abbreviation";
        public string colSimpleItemMinimumSimpleItemPrice = "SimpleItem_MinimumSimpleItemPrice";
        public string colPriceSimpleItemRetailSimpleItemPrice = "RetailSimpleItemPrice";
        public string colSimpleItemTaxation_Name = "Taxation_Name";
        public string colSimpleItemTaxation_Rate = "Taxation_Rate";
        public string colSimpleItem_SimpleItem_Image_Image_Hash = "SimpleItem_Image_Image_Hash";
        public string colSimpleItem_SimpleItem_Image_Image_Data = "SimpleItem_Image_Image_Data";
        public string colSimpleItem_Code = "SimpleItem_Code";

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
        public string colStockVIEW_PurchaseCompany_Name = "PurchaseCompany_Name";
        public string colStockVIEW_PurchaseCompany_Address = "PurchaseCompany_Address";
        public string colStockVIEW_Taxation_Rate = "Taxation_Rate";
        public string colStockVIEW_Stock_PurchasePricePerUnit = "Stock_PurchasePricePerUnit";
        public string colStockVIEW_Stock_RetailPricePerUnit = "Stock_RetailPricePerUnit";
        public string colStockVIEW_Stock_Quantity = "Stock_Quantity";
        public string colStockVIEW_Stock_ExpiryDate = "Stock_ExpiryDate";

        public string column_SelectedSimpleItem_dt_SimpleItem_Index = "SelectedSimpleItem_dt_SimpleItem_Index";
        public Type column_SelectedSimpleItem_dt_SimpleItem_Index_TYPE = typeof(int);

        public string column_Selected_Atom_Price_SimpleItem_ID = "Selected_Atom_Price_SimpleItem_ID";
        public Type column_Selected_Atom_Price_SimpleItem_ID_TYPE = typeof(long);

        public string column_SelectedSimpleItemName = "SelectedSimpleItemName";
        public Type column_SelectedSimpleItemName_TYPE = typeof(string);
        public string column_SelectedSimpleItemPrice = "SelectedSimpleItemPrice";
        public Type column_SelectedSimpleItemPrice_TYPE = typeof(decimal);

        public string column_SelectedSimpleItemPriceTax = "SelectedSimpleItemPriceTax";
        public Type column_SelectedSimpleItemPriceTax_TYPE = typeof(decimal);

        public string column_SelectedSimpleItem_TaxName = "SelectedSimpleItem_TaxName";
        public Type column_SelectedSimpleItem_TaxName_TYPE = typeof(string);

        public string column_SelectedSimpleItem_TaxRate = "SelectedSimpleItem_TaxRate";
        public Type column_SelectedSimpleItem_TaxRate_TYPE = typeof(decimal);


        public string column_SelectedSimpleItemPriceWithoutTax = "SelectedSimpleItemPriceWithoutTax";
        public Type column_SelectedSimpleItemPriceWithoutTax_TYPE = typeof(decimal);
        public string column_SelectedSimpleItemPriceDiscount = "SelectedSimpleItemPriceDiscount";
        public Type column_SelectedSimpleItemPriceDiscount_TYPE = typeof(decimal);
        public string column_SelectedSimpleItem_SimpleItem_ID = "SelectedSimpleItem_SimpleItem_ID";
        public Type column_SelectedSimpleItem_SimpleItem_ID_TYPE = typeof(long);
        public string column_SelectedSimpleItem_Count = "SelectedSimpleItem_Count";
        public Type column_SelectedSimpleItem_Count_TYPE = typeof(int);

        public string column_SelectedSimpleItem_ExtraDiscount = "SelectedSimpleItem_ExtraDiscount";
        public Type column_SelectedSimpleItem_ExtraDiscount_TYPE = typeof(decimal);


        public string colmyCompany_ID;
        public string colmyCompany_as_ID;


        public string col_cAddress_Org_cStreetName_Org_ID;
        public string col_cAddress_Org_cHouseNumber_Org_ID;
        public string col_cAddress_Org_cZIP_Org_ID;
        public string col_cAddress_Org_cCity_Org_ID;
        public string col_cAddress_Org_cState_Org_ID;
        public string col_cAddress_Org_cCountry_Org_ID;



        public string colmyCompany_Person_as_company_Person_ID;
        public string colmyCompany_Person_as_Office_ID;

        public string colmyCompany_Person_ID;

        public string colAtom_myCompany_Person_Atom_myCompany_ID;
        public string colAtom_myCompany_Person_as_Atom_myCompany_ID;
        public string colAtom_myCompany_Person_FirstName;
        public string colAtom_myCompany_Person_LastName;
        public string colAtom_myCompany_Person_Job;
        public string colAtom_myCompany_Person_UserName;
        public string colAtom_myCompany_Person_Description;

        public string colAtom_myCompany_ID;
        public string colAtom_myCompany_as_ID;
        public string colAtom_myCompany_Name;
        public string colAtom_myCompany_Atom_cAddress_Org;
        public string colAtom_myCompany_TaxID;
        public string colAtom_myCompany_as_TaxID;
        public string colAtom_myCompany_Company_id;
        public string colAtom_myCompany_PhoneNumber;
        public string colAtom_myCompany_Email;
        public string colAtom_myCompany_HomePage;


        public string colmyCompany_Person_Office_ID;

        public string colmyCompany_Name;



        public string colmyCompany_TaxID;
        public string colmyCompany_as_TaxID;
        public string colmyCompany_Company_id;
        public string colmyCompany_PhoneNumber;
        public string colmyCompany_Email;
        public string colmyCompany_HomePage;
        public string colmyCompany_BankName;
        public string colmyCompany_TRR;

        public string colProformaInvoice_ID;
        public string colProformaInvoice_as_ID;

        public string colProformaInvoice_myCompany_Person_ID;
        public string colProformaInvoice_as_myCompany_Person_ID;

        public string colProformaInvoice_Atom_myCompany_Person_ID;
        public string colProformaInvoice_as_Atom_myCompany_Person_ID;

        public string colProformaInvoice_myCompany_ID;
        public string colProformaInvoice_as_myCompany_ID;

        public string colProformaInvoice_FinancialYear;
        public string colProformaInvoice_as_FinancialYear;
        public string colProformaInvoice_NumberInFinancialYear;
        public string colProformaInvoice_as_NumberInFinancialYear;
        public string colProformaInvoice_Draft;
        public string colProformaInvoice_PrintTime;
        public string colProformaInvoice_as_PrintTime;
        public string colProformaInvoice_NetSum;
        public string colProformaInvoice_Discount;
        public string colProformaInvoice_EndSum;
        public string colProformaInvoice_TaxSum;
        public string colProformaInvoice_GrossSum;
        public string colProformaInvoice_BuyerAtom_Person_ID;
        public string colProformaInvoice_BuyerCompanyAtom_ID;
        public string colProformaInvoice_WarrantyExists;
        public string colProformaInvoice_WarrantyDurationType;
        public string colProformaInvoice_WarrantyDuration;
        public string colProformaInvoice_WarrantyConditions;
        public string colProformaInvoice_ProformaInvoiceDuration;
        public string colProformaInvoice_ProformaInvoiceDurationType;
        public string colProformaInvoice_TermsOfPayment_ID;
        public string colProformaInvoice_Invoice_ID;

        public string colInvoice_ID;
        public string colInvoice_InvoiceTime;
        public string colInvoice_PaymentDeadline;
        public string colInvoice_m_MethodOfPayment;
        public string colInvoice_Paid;
        public string colInvoice_Storno;


        public DBTablesAndColumnNames()
        {
            BlagajnaTableClass.SQL_Database_Tables_Definition td = DBSync.DBSync.DB_for_Blagajna.mt;


            SQLTable tbl_myCompany = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany));
            SQLTable tbl_myCompany_Person = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany_Person));
            SQLTable tbl_Person = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Person));
            SQLTable tbl_Atom_myCompany = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_myCompany));
            SQLTable tbl_Atom_myCompany_Person = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_myCompany_Person));
            SQLTable tbl_ProformaInvoice = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(ProformaInvoice));
            SQLTable tbl_Atom_Customer_Person = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Customer_Person));
            SQLTable tbl_Atom_Customer_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Customer_Org));
            SQLTable tbl_TermsOfPayment = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(TermsOfPayment));
            SQLTable tbl_Invoice = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Invoice));
            SQLTable tbl_Taxation = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Taxation));
            SQLTable tbl_SimpleItem = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(SimpleItem));
            SQLTable tbl_SimpleItem_Image = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(SimpleItem_Image));
            SQLTable tbl_Atom_SimpleItem = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_SimpleItem));
            SQLTable tbl_Atom_SimpleItem_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_SimpleItem_Name));
            SQLTable tbl_Atom_SimpleItem_Image = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_SimpleItem_Image));
            SQLTable tbl_Atom_Taxation = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Taxation));

            SQLTable tbl_cStreetName_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(cStreetName_Org));
            SQLTable tbl_cHouseNumber_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(cHouseNumber_Org));
            SQLTable tbl_cZIP_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(cZIP_Org));
            SQLTable tbl_cCity_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(cCity_Org));
            SQLTable tbl_cState_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(cState_Org));
            SQLTable tbl_cCountry_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(cCountry_Org));

            SQLTable tbl_cAddress_Org = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(cAddress_Org));
        
            SQLTable tbl_Atom_Item_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Item_Name));
            SQLTable tbl_Atom_Item_barcode = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Item_barcode));
            SQLTable tbl_Atom_Item_Description = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Item_Description));
            SQLTable tbl_Atom_Item_Image = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Item_Image));
            SQLTable tbl_Atom_Item_ImageLib = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Item_ImageLib));
            SQLTable tbl_Atom_Warranty = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Warranty));
            SQLTable tbl_Atom_Item = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Item));
            SQLTable tbl_Atom_Expiry = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Expiry));
            SQLTable tbl_ProformaInvoice_Atom_Item_Stock = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_ProformaInvoice_Price_Item_Stock));

            stbl_myCompany_TableName = tbl_myCompany.TableName;

            stbl_cStreetName_Org_TableName = tbl_cStreetName_Org.TableName;
            stbl_cHouseNumber_Org_TableName = tbl_cHouseNumber_Org.TableName;
            stbl_cZIP_Org_TableName = tbl_cZIP_Org.TableName;
            stbl_cCity_Org_TableName = tbl_cCity_Org.TableName;
            stbl_cState_Org_TableName = tbl_cState_Org.TableName;
            stbl_cCountry_Org_TableName = tbl_cCountry_Org.TableName;

            stbl_Atom_Item_Name_TableName = tbl_Atom_Item_Name.TableName;
            stbl_Atom_Item_barcode_TableName = tbl_Atom_Item_barcode.TableName;
            stbl_Atom_Item_Description_TableName = tbl_Atom_Item_Description.TableName;
            stbl_Atom_Item_Image_TableName = tbl_Atom_Item_Image.TableName;
            stbl_Atom_Item_ImageLib_TableName = tbl_Atom_Item_ImageLib.TableName;
            stbl_Atom_Taxation_TableName = tbl_Atom_Taxation.TableName;
            stbl_Atom_Item_WarrantyConditions_TableName = tbl_Atom_Warranty.TableName;
            stbl_Atom_Item_TableName = tbl_Atom_Item.TableName;
            stbl_ProformaInvoice_Atom_Item_Stock_TableName = tbl_ProformaInvoice_Atom_Item_Stock.TableName;

            stbl_Atom_Item_ExpiryDescription_TableName = tbl_Atom_Expiry.TableName;

            stbl_Atom_myCompany_TableName = tbl_Atom_myCompany.TableName;
            stbl_Atom_myCompany_Person_TableName = tbl_Atom_myCompany_Person.TableName;


            stbl_myCompany_Person_TableName = tbl_myCompany_Person.TableName;
            stbl_myCompany_PersonData_TableName = tbl_Person.TableName;
            stbl_BuyerAtom_Person_TableName = tbl_Atom_Customer_Person.TableName;

            stbl_BuyerCompanyAtom_TableName = tbl_Atom_Customer_Org.TableName;
            stbl_TermsOfPayment_TableName = tbl_TermsOfPayment.TableName;

            stbl_ProformaInvoice_TableName = tbl_ProformaInvoice.TableName;

            stbl_Invoice_TableName = tbl_Invoice.TableName;

            stbl_Taxation_TableName = tbl_Taxation.TableName;


            stbl_SimpleItem_TableName = tbl_SimpleItem.TableName;
            stbl_SimpleItem_Image_TableName = tbl_SimpleItem_Image.TableName;

            stbl_Atom_SimpleItem_TableName = tbl_Atom_SimpleItem.TableName;
            stbl_Atom_SimpleItem_Name_TableName = tbl_Atom_SimpleItem_Name.TableName;
            stbl_Atom_SimpleItem_Image_TableName = tbl_Atom_SimpleItem_Image.TableName;

            stbl_Atom_Warranty_TableName = tbl_Atom_Warranty.TableName;

            col_Invoice_ID = stbl_Invoice_TableName + "_" + GetName(td.m_Invoice.ID.GetType());
            col_FinancialYear = GetName(td.m_ProformaInvoice.FinancialYear.GetType());
            col_NumberInFinancialYear = GetName(td.m_ProformaInvoice.NumberInFinancialYear.GetType());

            colmyCompany_Person_ID = stbl_myCompany_Person_TableName + "." + GetName(td.m_myCompany_Person.ID.GetType());
            colmyCompany_ID = stbl_myCompany_TableName + "." + GetName(td.m_myCompany.ID.GetType());

            col_cAddress_Org_cHouseNumber_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cHouseNumber_Org.GetType()) + "_ID";
            col_cAddress_Org_cZIP_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cZIP_Org.GetType()) + "_ID";
            col_cAddress_Org_cCity_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cCity_Org.GetType()) + "_ID";
            col_cAddress_Org_cState_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cState_Org.GetType()) + "_ID";
            col_cAddress_Org_cCountry_Org_ID = stbl_cAddress_Org_TableName + "." + GetName(td.m_cAddress_Org.m_cCountry_Org.GetType()) + "_ID";




             colmyCompany_Person_as_company_Person_ID = stbl_myCompany_Person_TableName + "_" + GetName(td.m_myCompany_Person.ID.GetType());
             colmyCompany_Person_ID = stbl_myCompany_Person_TableName + "."+ GetName(td.m_myCompany_Person.ID.GetType());
             colmyCompany_ID = stbl_myCompany_TableName + "." + GetName(td.m_myCompany.ID.GetType());
             colmyCompany_as_ID = stbl_myCompany_TableName + "_" + GetName(td.m_myCompany.ID.GetType());

             colmyCompany_Person_Office_ID = stbl_myCompany_Person_TableName + "." + GetName(td.m_myCompany_Person.m_Office.ID.GetType());
             colmyCompany_Person_as_Office_ID = stbl_myCompany_Person_TableName + "_" + GetName(td.m_myCompany_Person.m_Office.ID.GetType());

             colAtom_myCompany_Person_Atom_myCompany_ID = stbl_Atom_myCompany_Person_TableName + "." + GetName(td.m_Atom_myCompany_Person.m_Atom_Office.ID.GetType());
             colAtom_myCompany_Person_as_Atom_myCompany_ID = stbl_Atom_myCompany_Person_TableName + "_" + GetName(td.m_Atom_myCompany_Person.m_Atom_Office.ID.GetType());
             colAtom_myCompany_Person_FirstName = stbl_Atom_myCompany_Person_TableName + "." + GetName(td.m_Atom_myCompany_Person.FirstName.GetType());
             colAtom_myCompany_Person_LastName = stbl_Atom_myCompany_Person_TableName + "." + GetName(td.m_Atom_myCompany_Person.LastName.GetType());
             colAtom_myCompany_Person_Job = stbl_Atom_myCompany_Person_TableName + "." + GetName(td.m_Atom_myCompany_Person.Job.GetType());
             colAtom_myCompany_Person_UserName = stbl_Atom_myCompany_Person_TableName + "." + GetName(td.m_Atom_myCompany_Person.UserName.GetType());
             colAtom_myCompany_Person_Description = stbl_Atom_myCompany_Person_TableName + "." + GetName(td.m_Atom_myCompany_Person.Description.GetType());

             colAtom_myCompany_ID = stbl_Atom_myCompany_TableName + "." + GetName(td.m_Atom_myCompany.ID.GetType());
             colAtom_myCompany_as_ID = stbl_Atom_myCompany_TableName + "_" + GetName(td.m_Atom_myCompany.ID.GetType());


             //colmyCompany_cStreetName_Org_ID = GetName(td.m_myCompany.m_cStreetName_Org.GetType());
             //colmyCompany_cHouseNumber_Org_ID = GetName(td.m_myCompany.m_cHouseNumber_Org.GetType());
             //colmyCompany_cCity_Org_ID = GetName(td.m_myCompany.m_cCity_Org.GetType());
             //colmyCompany_cState_Org_ID = GetName(td.m_myCompany.m_cState_Org.GetType());
             //colmyCompany_cCountry_Org_ID = GetName(td.m_myCompany.m_cCountry_Org.GetType());
             //colmyCompany_cZIP_Org_ID = GetName(td.m_myCompany.m_cZIP_Org.GetType());




            colProformaInvoice_ID = stbl_ProformaInvoice_TableName + "." + GetName(td.m_ProformaInvoice.ID.GetType());
            colProformaInvoice_as_ID = stbl_ProformaInvoice_TableName + "_" + GetName(td.m_ProformaInvoice.ID.GetType());

            colProformaInvoice_myCompany_Person_ID = stbl_myCompany_Person_TableName+"."+GetName(td.m_Atom_myCompany_Person.ID.GetType());
            colProformaInvoice_as_myCompany_Person_ID = stbl_Atom_myCompany_Person_TableName + "_" + GetName(td.m_Atom_myCompany_Person.ID.GetType());

            colProformaInvoice_Atom_myCompany_Person_ID = stbl_Atom_myCompany_Person_TableName + "." + GetName(td.m_Atom_myCompany_Person.ID.GetType());
            colProformaInvoice_as_Atom_myCompany_Person_ID = stbl_Atom_myCompany_Person_TableName + "_" + GetName(td.m_Atom_myCompany_Person.ID.GetType());

            colProformaInvoice_myCompany_ID = stbl_myCompany_TableName+"." +GetName(td.m_myCompany.ID.GetType());
            colProformaInvoice_as_myCompany_ID = stbl_myCompany_TableName + "_" + GetName(td.m_myCompany.ID.GetType());

            colProformaInvoice_FinancialYear = GetName(td.m_ProformaInvoice.FinancialYear.GetType());
            colProformaInvoice_NumberInFinancialYear = GetName(td.m_ProformaInvoice.NumberInFinancialYear.GetType());

            colProformaInvoice_Draft = GetName(td.m_ProformaInvoice.Draft.GetType());
            colProformaInvoice_NetSum = GetName(td.m_ProformaInvoice.NetSum.GetType()); 
            colProformaInvoice_Discount =  GetName(td.m_ProformaInvoice.Discount.GetType());
            colProformaInvoice_EndSum = GetName(td.m_ProformaInvoice.EndSum.GetType());
            colProformaInvoice_TaxSum = GetName(td.m_ProformaInvoice.TaxSum.GetType());
            colProformaInvoice_GrossSum = GetName(td.m_ProformaInvoice.GrossSum.GetType()); ;
            colProformaInvoice_BuyerAtom_Person_ID = stbl_BuyerAtom_Person_TableName + "_" + GetName(td.m_BuyerAtom_Person.ID.GetType());
            colProformaInvoice_BuyerCompanyAtom_ID = stbl_BuyerCompanyAtom_TableName + "_" + GetName(td.m_Atom_Organisation.ID.GetType());
            colProformaInvoice_WarrantyExists = GetName(td.m_ProformaInvoice.WarrantyExist.GetType());
            colProformaInvoice_WarrantyDurationType = GetName(td.m_ProformaInvoice.WarrantyDurationType.GetType());
            colProformaInvoice_WarrantyDuration = GetName(td.m_ProformaInvoice.WarrantyDuration.GetType());
            colProformaInvoice_WarrantyConditions = GetName(td.m_ProformaInvoice.WarrantyConditions.GetType());
            colProformaInvoice_ProformaInvoiceDuration = GetName(td.m_ProformaInvoice.ProformaInvoiceDuration.GetType());
            colProformaInvoice_ProformaInvoiceDurationType = GetName(td.m_ProformaInvoice.ProformaInvoiceDurationType.GetType());
            colProformaInvoice_TermsOfPayment_ID = stbl_TermsOfPayment_TableName + "_"+GetName(td.m_TermsOfPayment.ID.GetType());
            colProformaInvoice_FinancialYear = stbl_ProformaInvoice_TableName + "." + GetName(td.m_ProformaInvoice.FinancialYear.GetType());
            colProformaInvoice_as_FinancialYear = stbl_ProformaInvoice_TableName + "_" + GetName(td.m_ProformaInvoice.FinancialYear.GetType());
            colProformaInvoice_NumberInFinancialYear = stbl_ProformaInvoice_TableName + "." + GetName(td.m_ProformaInvoice.NumberInFinancialYear.GetType());
            colProformaInvoice_as_NumberInFinancialYear = stbl_ProformaInvoice_TableName + "_" + GetName(td.m_ProformaInvoice.NumberInFinancialYear.GetType());
            colProformaInvoice_Invoice_ID = stbl_ProformaInvoice_TableName + "." + stbl_Invoice_TableName + "_" + GetName(td.m_Invoice.ID.GetType());

            colInvoice_ID = stbl_Invoice_TableName + "." + GetName(td.m_Invoice.ID.GetType());
            colInvoice_PaymentDeadline = stbl_Invoice_TableName + "." + GetName(td.m_Invoice.PaymentDeadline.GetType());
            colInvoice_m_MethodOfPayment = stbl_Invoice_TableName + "." + GetName(td.m_Invoice.m_MethodOfPayment.GetType())+"_ID";
            colInvoice_Paid = stbl_Invoice_TableName + "." + GetName(td.m_Invoice.Paid.GetType());
            colInvoice_Storno = stbl_Invoice_TableName + "." + GetName(td.m_Invoice.Storno.GetType()); ;


        }

        public  string GetName(Type type)
        {
            string str = type.ToString();
            int i = str.LastIndexOf('.');
            str = str.Substring(i + 1);
            return str;
        }

    }
}
