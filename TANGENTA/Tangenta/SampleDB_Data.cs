using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data;
using DBTypes;
using DBConnectionControl40;
using InvoiceDB;

namespace Tangenta
{


    public static class SampleDB_Data
    {
        public static BlagajnaTableClass.Taxation m_Taxation = new BlagajnaTableClass.Taxation();

        public static BlagajnaTableClass.cStreetName_Org m_cStreetName_Org = new BlagajnaTableClass.cStreetName_Org();
        public static BlagajnaTableClass.cHouseNumber_Org m_cHouseNumber_Org = new BlagajnaTableClass.cHouseNumber_Org();
        public static BlagajnaTableClass.cCity_Org m_cCity_Org = new BlagajnaTableClass.cCity_Org();
        public static BlagajnaTableClass.cZIP_Org m_cZIP_Org = new BlagajnaTableClass.cZIP_Org();
        public static BlagajnaTableClass.cState_Org m_cState_Org = new BlagajnaTableClass.cState_Org();
        public static BlagajnaTableClass.cCountry_Org m_cCountry_Org = new BlagajnaTableClass.cCountry_Org();

        public static BlagajnaTableClass.myCompany m_myCompany = new BlagajnaTableClass.myCompany();

        public static BlagajnaTableClass.OrganisationData m_OrganisationData = new BlagajnaTableClass.OrganisationData();

        public static BlagajnaTableClass.cAddress_Org m_cAddress_Org = new BlagajnaTableClass.cAddress_Org();

        public static BlagajnaTableClass.cOrgTYPE m_cOrgTYPE = new BlagajnaTableClass.cOrgTYPE();

        public static List<BlagajnaTableClass.Person> m_List_Person = new List<BlagajnaTableClass.Person>();
        public static List<BlagajnaTableClass.myCompany_Person> m_List_myCompany_Person = new List<BlagajnaTableClass.myCompany_Person>();


        public static List<BlagajnaTableClass.Price_SimpleItem> m_List_Price_SimpleItem = new List<BlagajnaTableClass.Price_SimpleItem>();

        public static List<BlagajnaTableClass.Expiry> m_List_Expiry = new List<BlagajnaTableClass.Expiry>();

        public static List<BlagajnaTableClass.Item> m_List_Item = new List<BlagajnaTableClass.Item>();

        public static List<BlagajnaTableClass.Item_Image> m_List_Item_Image = new List<BlagajnaTableClass.Item_Image>();

        public static List<BlagajnaTableClass.OrganisationData> m_List_OrganisationData_Supplier = new List<BlagajnaTableClass.OrganisationData>();

        public static List<BlagajnaTableClass.Supplier> m_List_Supplier = new List<BlagajnaTableClass.Supplier>();

        public static List<BlagajnaTableClass.PurchasePrice_Item> m_List_PurchasePrice_Item = new List<BlagajnaTableClass.PurchasePrice_Item>();

        public static List<BlagajnaTableClass.Stock> m_List_Stock = new List<BlagajnaTableClass.Stock>();

        public static long myCompany_Person_id = -1;
        public static long myCompany_PersonAccount_id = -1;
        public static  long myCompany_ID = -1;

        public static void Init_SimpleItem()
        {
            BlagajnaTableClass.Price_SimpleItem PriceList_SimpleItem = new BlagajnaTableClass.Price_SimpleItem();

            PriceList_SimpleItem.m_Taxation.ID.val = 1;
            PriceList_SimpleItem.m_SimpleItem.Name.val = "Pedikira";
            PriceList_SimpleItem.m_SimpleItem.Code.val = 1;
            PriceList_SimpleItem.m_SimpleItem.Abbreviation.val = "PED";
            PriceList_SimpleItem.RetailSimpleItemPrice.val = 40;

            m_List_Price_SimpleItem.Add(PriceList_SimpleItem);

            PriceList_SimpleItem = new BlagajnaTableClass.Price_SimpleItem();

            PriceList_SimpleItem.m_Taxation.ID.val = 1;
            PriceList_SimpleItem.m_SimpleItem.Name.val = "Manikura";
            PriceList_SimpleItem.m_SimpleItem.Code.val = 1;
            PriceList_SimpleItem.m_SimpleItem.Abbreviation.val = "MAN";
            PriceList_SimpleItem.RetailSimpleItemPrice.val = 35;

            m_List_Price_SimpleItem.Add(PriceList_SimpleItem);

            PriceList_SimpleItem = new BlagajnaTableClass.Price_SimpleItem();

            PriceList_SimpleItem.m_Taxation.ID.val = 1;
            PriceList_SimpleItem.m_SimpleItem.Name.val = "Nega obraza";
            PriceList_SimpleItem.m_SimpleItem.Code.val = 3;
            PriceList_SimpleItem.m_SimpleItem.Abbreviation.val = "NOB";
            PriceList_SimpleItem.RetailSimpleItemPrice.val = 45;

            m_List_Price_SimpleItem.Add(PriceList_SimpleItem);

        }

        private static void Init_Item()
        {
            BlagajnaTableClass.Item_Image Item_Image_VITAMIN_PACKUNG  = new BlagajnaTableClass.Item_Image();
            Item_Image_VITAMIN_PACKUNG.Image_Data.val = ImageToByte2(Properties.Resources.VITAMIN_PACKUNG);
            Item_Image_VITAMIN_PACKUNG.Image_Hash.val = DBtypesFunc.GetHash_SHA1(Item_Image_VITAMIN_PACKUNG.Image_Data.val);
            m_List_Item_Image.Add(Item_Image_VITAMIN_PACKUNG);

            BlagajnaTableClass.Item_Image Item_Image_VITAMIN_SUPREME = new BlagajnaTableClass.Item_Image();
            Item_Image_VITAMIN_SUPREME.Image_Data.val = ImageToByte2(Properties.Resources.VITAMIN_SUPREME);
            Item_Image_VITAMIN_SUPREME.Image_Hash.val = DBtypesFunc.GetHash_SHA1(Item_Image_VITAMIN_SUPREME.Image_Data.val);
            m_List_Item_Image.Add(Item_Image_VITAMIN_SUPREME);

            BlagajnaTableClass.Item_Image Item_Image_Active_Concentrate_Repair_Complex = new BlagajnaTableClass.Item_Image();
            Item_Image_Active_Concentrate_Repair_Complex.Image_Data.val = ImageToByte2(Properties.Resources.Active_Concentrate_Repair_Complex);
            Item_Image_Active_Concentrate_Repair_Complex.Image_Hash.val = DBtypesFunc.GetHash_SHA1(Item_Image_Active_Concentrate_Repair_Complex.Image_Data.val);
            m_List_Item_Image.Add(Item_Image_Active_Concentrate_Repair_Complex);

            BlagajnaTableClass.Item_Image Item_Image_Beautipharm_Self_Bronzer = new BlagajnaTableClass.Item_Image();
            Item_Image_Beautipharm_Self_Bronzer.Image_Data.val = ImageToByte2(Properties.Resources.Beautipharm_Self_Bronzer);
            Item_Image_Beautipharm_Self_Bronzer.Image_Hash.val = DBtypesFunc.GetHash_SHA1(Item_Image_Beautipharm_Self_Bronzer.Image_Data.val);
            m_List_Item_Image.Add(Item_Image_Beautipharm_Self_Bronzer);


            BlagajnaTableClass.Item_Image Item_Image_Beautipharm_Sun_Milk_SPF_30_High = new BlagajnaTableClass.Item_Image();
            Item_Image_Beautipharm_Sun_Milk_SPF_30_High.Image_Data.val = ImageToByte2(Properties.Resources.BEAUTIPHARM_SUN_MILK_SPF_30_HIGH);
            Item_Image_Beautipharm_Sun_Milk_SPF_30_High.Image_Hash.val = DBtypesFunc.GetHash_SHA1(Item_Image_Beautipharm_Sun_Milk_SPF_30_High.Image_Data.val);
            m_List_Item_Image.Add(Item_Image_Beautipharm_Sun_Milk_SPF_30_High);


            BlagajnaTableClass.Item_Image Item_Image_Beautipharm_Sun_Milk_SPF_20_Medium = new BlagajnaTableClass.Item_Image();
            Item_Image_Beautipharm_Sun_Milk_SPF_20_Medium.Image_Data.val = ImageToByte2(Properties.Resources.BEAUTIPHARM_SUN_MILK_SPF_20_MEDIUM);
            Item_Image_Beautipharm_Sun_Milk_SPF_20_Medium.Image_Hash.val = DBtypesFunc.GetHash_SHA1(Item_Image_Beautipharm_Sun_Milk_SPF_20_Medium.Image_Data.val);
            m_List_Item_Image.Add(Item_Image_Beautipharm_Sun_Milk_SPF_20_Medium);

            
            BlagajnaTableClass.Item_Image Item_Image_Beautipharm_Sun_Milk_SPF_12_Basic = new BlagajnaTableClass.Item_Image();
            Item_Image_Beautipharm_Sun_Milk_SPF_12_Basic.Image_Data.val = ImageToByte2(Properties.Resources.BEAUTIPHARM_SUN_MILK_SPF_12_BASIC);
            Item_Image_Beautipharm_Sun_Milk_SPF_12_Basic.Image_Hash.val = DBtypesFunc.GetHash_SHA1(Item_Image_Beautipharm_Sun_Milk_SPF_12_Basic.Image_Data.val);
            m_List_Item_Image.Add(Item_Image_Beautipharm_Sun_Milk_SPF_12_Basic);

            BlagajnaTableClass.Expiry Expiry1 = new BlagajnaTableClass.Expiry();
            Expiry1.ExpectedShelfLifeInDays.val = 60;
            Expiry1.SaleBeforeExpiryDateInDays.val = 30;
            Expiry1.DiscardBeforeExpiryDateInDays.val = 15;
            Expiry1.ExpiryDescription.val = @"";
            m_List_Expiry.Add(Expiry1);

            BlagajnaTableClass.Expiry Expiry2 = new BlagajnaTableClass.Expiry();
            Expiry2.ExpectedShelfLifeInDays.val = 70;
            Expiry2.SaleBeforeExpiryDateInDays.val = 25;
            Expiry2.DiscardBeforeExpiryDateInDays.val = 14;
            Expiry2.ExpiryDescription.val = @"";
            m_List_Expiry.Add(Expiry2);

            BlagajnaTableClass.Expiry Expiry3 = new BlagajnaTableClass.Expiry();
            Expiry3.ExpectedShelfLifeInDays.val = 90;
            Expiry3.SaleBeforeExpiryDateInDays.val = 40;
            Expiry3.DiscardBeforeExpiryDateInDays.val = 30;
            Expiry3.ExpiryDescription.val = @"";
            m_List_Expiry.Add(Expiry3);





            BlagajnaTableClass.Item Item = new BlagajnaTableClass.Item();
            Item.UniqueName.val = "VITAMIN PACKUNG ver 1";
            Item.Name.val = "VITAMIN PACKUNG";
            Item.Code.val = 1;
            Item.Description.val = @"Universal facial pack suitable for all skin conditions.
Apply VITAMIN PACKUNG, sparing the eyes, and leave on the skin for approx. 15-20 minutes. Then remove with moist, lukewarm compresses. The application of VITAMIN PACKUNG is recommended once or twice a week.
Tip: Leave on for 20 minutes, and evening full massage.
            ";
            Item.m_Item_Image = Item_Image_VITAMIN_PACKUNG;

            Item.m_Expiry.ID.val = 1;

            m_List_Item.Add(Item);

            Item = new BlagajnaTableClass.Item();
            Item.UniqueName.val = "VITAMIN SUPREME ver 1";
            Item.Name.val = "VITAMIN SUPREME";
            Item.Code.val = 2;
            Item.Description.val = @"Protecting night cream for all skin conditions. Enriched with a powerful vitamin complex it protects from the damaging effects of weather, climate, and environmental causes of premature skin aging.
                                     Contains vitamins A and E, high quality lanolin, beeswax and the provitamin beta-carotene
                                     Apply VITAMIN SUPREME in the evening to a clean, dry skin. Pour a sufficient amount of the cream in the palm of the hand and apply evenly. Let the cream absorb completely or massage in gently. VITAMIN SUPREME is well suited for massages. 
                                    ";
            Item.m_Expiry.ExpiryDescription.val = @"";
            Item.m_Item_Image = Item_Image_VITAMIN_SUPREME;
            Item.m_Expiry.ID.val = 2;

            m_List_Item.Add(Item);

            Item = new BlagajnaTableClass.Item();

            Item.UniqueName.val = "ACTIVE CONCENTRATE REPAIR COMPLEX ver 1";
            Item.Name.val = "ACTIVE CONCENTRATE REPAIR COMPLEX";
            Item.Code.val = 3;
            Item.Description.val = @"Rich, essential concentrate for mature or sun stressed skin conditions. High concentrated active ingredients help to energize and revitalize the skin’s natural functions. Continuously used, it helps to minimize the appearance of fine lines and wrinkles.
Contains soy extract, antioxidant, oligopeptides and vitamins. No artificial color or fragrance.
application:
Apply ACTIVE CONCENTRATE REPAIR COMPLEX to a clean, dry skin before using day- or night-cream. Pour a sufficient amount of the complex in the palm of the hand, apply and let it absorb completely or massage in gently. For local use, small amounts of concentrate are applied to demanding skin areas whenever necessary. 
                                    ";
            Item.m_Item_Image = Item_Image_Active_Concentrate_Repair_Complex;
            Item.m_Expiry.ID.val = 3;
            m_List_Item.Add(Item);

            Item = new BlagajnaTableClass.Item();

            Item.UniqueName.val = "Beautipharm® Self Bronzer ver 2";
            Item.Name.val = "Beautipharm® Self Bronzer";
            Item.Code.val = 4;
            Item.Description.val = @"Self bronzing cream for face and body for an individual tan without sun. Active tanning agents create an even, long lasting, natural looking tan. An innovative combination of physiological ingredients and precious oils smooth and moisturize the skin.
Provides no UV sun protection
Contains a combination of physiological dihydroxyacetone (DHA) and natural erythrulose. Free of essential oils, colors and alcohol.

application:
Apply BEAUTIPHARM® SELF BRONZER to a clean, dry skin. Pour a sufficient amount of in the palm of the hand, apply evenly and let it absorb completely or massage in gently. Repeat application to intensify tan. Avoid contact with clothing and wash hands thoroughly after use. 
                                    ";
            Item.m_Item_Image = Item_Image_Beautipharm_Self_Bronzer;
            Item.m_Expiry.ID.val = 1;

            m_List_Item.Add(Item);


            Item = new BlagajnaTableClass.Item();

            Item.UniqueName.val = "Lavolind ver 3";
            Item.Name.val = "Lavolind";
            Item.Code.val = 5;
            Item.Description.val = @"Liquid gel cleanser for oily, impure and combination skin conditions. Deep-cleanses the skin and removes the daily build-up of dirt and environmental pollutants.
Contains mild cleansing agents, lavender and orange oils. 
application:
Apply BEAUTIPHARM® SELF BRONZER to a clean, dry skin. Pour a sufficient amount of in the palm of the hand, apply evenly and let it absorb completely or massage in gently. Repeat application to intensify tan. Avoid contact with clothing and wash hands thoroughly after use. 
                                    ";
            Item.m_Item_Image = null;
            Item.m_Expiry.ID.val = 2;
            m_List_Item.Add(Item);

            Item = new BlagajnaTableClass.Item();
            Item.UniqueName.val = "Beautipharm® Sun Milk SPF 30 High ver 1.0";
            Item.Name.val = "Beautipharm® Sun Milk SPF 30 High";
            Item.Code.val = 6;
            Item.Description.val = @"Moisturizing sun milk for face and body. Provides medium UVA and UVB sun protection.";
            Item.m_Item_Image = Item_Image_Beautipharm_Sun_Milk_SPF_30_High;
            Item.m_Expiry = null;
            m_List_Item.Add(Item);

            
            Item = new BlagajnaTableClass.Item();
            Item.UniqueName.val = "Beautipharm® Sun Milk SPF 20 Medium ver 1.0";
            Item.Name.val = "Beautipharm® Sun Milk SPF 20 Medium";
            Item.Code.val = 7;
            Item.Description.val = @"Moisturizing sun milk for face and body. Provides medium UVA and UVB sun protection.";
            Item.m_Item_Image = Item_Image_Beautipharm_Sun_Milk_SPF_20_Medium;
            Item.m_Expiry = null;
            m_List_Item.Add(Item);

             
            Item = new BlagajnaTableClass.Item();
            Item.UniqueName.val = "Beautipharm® Sun Milk SPF 12 Basic ver 1.0";
            Item.Name.val = "Beautipharm® Sun Milk SPF 12 Basic";
            Item.Code.val = 8;
            Item.Description.val = @"Moisturizing sun milk for face and body. Provides basic UVA and UVB sun protection.";
            Item.m_Item_Image = Item_Image_Beautipharm_Sun_Milk_SPF_12_Basic;
            Item.m_Expiry.ID.val = 1;
            m_List_Item.Add(Item);

        }

        public static void Init_PurchaseCompany()
        {

            BlagajnaTableClass.Organisation org = new BlagajnaTableClass.Organisation();
            BlagajnaTableClass.OrganisationData orgdata = new BlagajnaTableClass.OrganisationData();
            BlagajnaTableClass.Supplier supplier = new BlagajnaTableClass.Supplier();

            org.Name.val = "Linde Eckstein GmbH + CO.KG";
            orgdata.m_Organisation = org;
            orgdata.m_cAddress_Org.m_cStreetName_Org.StreetName.val = "Flurstraße";
            orgdata.m_cAddress_Org.m_cHouseNumber_Org.HouseNumber.val = "27 a – 35";
            orgdata.m_cAddress_Org.m_cCity_Org.City.val = "Oberasbach";
            orgdata.m_cAddress_Org.m_cZIP_Org.ZIP.val = "90522";
            orgdata.m_cAddress_Org.m_cState_Org.State.val = "Deutschland";

            supplier.m_Organisation = org;

            m_List_OrganisationData_Supplier.Add(orgdata);

            

        }

        private static void Init_myCompany_Person()
        {
            BlagajnaTableClass.Person Person1 = new BlagajnaTableClass.Person();
            BlagajnaTableClass.myCompany_Person myCompany_Person1 = new BlagajnaTableClass.myCompany_Person();
            Person1.m_cFirstName.FirstName.val = "Marjetka";
            Person1.m_cLastName.LastName.val = "Hrnčič-Štrucl";
            m_List_Person.Add(Person1);

            myCompany_Person1.m_Person = Person1;
            myCompany_Person1.UserName.val = "marjetka";
            myCompany_Person1.Active.val = true;
            myCompany_Person1.Job.val = "direktor";
            myCompany_Person1.Password.val="1234";
            m_List_myCompany_Person.Add(myCompany_Person1);

            BlagajnaTableClass.Person Person2 = new BlagajnaTableClass.Person();
            BlagajnaTableClass.myCompany_Person myCompany_Person2 = new BlagajnaTableClass.myCompany_Person();
            Person2.m_cFirstName.FirstName.val = "Damjan";
            Person2.m_cLastName.LastName.val = "Štrucl-Hrnčič";
            m_List_Person.Add(Person2);

            myCompany_Person2.m_Person = Person2;
            myCompany_Person2.UserName.val = "damjan";
            myCompany_Person2.Active.val = true;
            myCompany_Person2.Job.val = "zunanji sodelavec";
            myCompany_Person2.Password.val = "1234";
            m_List_myCompany_Person.Add(myCompany_Person2);


        }
        private static void Init_Stock()
        {
            BlagajnaTableClass.Stock Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 1;
            Stock.ImportTime.val = DateTime.Now;
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(60);
            Stock.dQuantity.val = 10;
            //Stock.PurchasePricePerUnit.val = 31;
            //Stock.RetailPricePerUnit.val = 45;
            

            m_List_Stock.Add(Stock);

            Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 2;
            Stock.ImportTime.val = DateTime.Now.AddDays(-3);
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(90);
            Stock.dQuantity.val = 15;

            m_List_Stock.Add(Stock);

            Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 2;
            Stock.ImportTime.val = DateTime.Now.AddDays(-2);
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(90);
            Stock.dQuantity.val = 7;

            m_List_Stock.Add(Stock);

            Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 2;
            Stock.ImportTime.val = DateTime.Now;
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(90);
            Stock.dQuantity.val = 10;

            m_List_Stock.Add(Stock);

            Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 2;
            Stock.ImportTime.val = DateTime.Now;
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(90);
            Stock.dQuantity.val = 10;

            m_List_Stock.Add(Stock);

            Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 3;
            Stock.ImportTime.val = DateTime.Now;
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(60);
            Stock.dQuantity.val = 20;

            m_List_Stock.Add(Stock);

            Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 4;
            Stock.ImportTime.val = DateTime.Now;
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(70);
            Stock.dQuantity.val = 5;

            m_List_Stock.Add(Stock);


            Stock = new BlagajnaTableClass.Stock();
            Stock.m_PurchasePrice_Item.ID.val = 5;
            Stock.ImportTime.val = DateTime.Now;
            Stock.ExpiryDate.val = Stock.ImportTime.val.AddDays(30);
            Stock.dQuantity.val = 6;

            m_List_Stock.Add(Stock);


        }



        public static bool InitData(ref string Err)
        {
            // Taxation
            m_Taxation.Name.val = "DDV 22%";
            m_Taxation.Rate.val = 0.22M;

            // SimpleItem
            Init_SimpleItem();

            // Item
            Init_Item();

            Init_PurchaseCompany();
            // Stock

            Init_Stock();
            return Init_DB(ref Err);

        }




        public static bool Init_DB_Taxation(ref string Err)
        {
            string s_Taxation_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Taxation)).TableName;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Taxation)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Taxation.Name.GetType()).Name;
            string s_col_Rate = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Taxation)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Taxation.Rate.GetType()).Name;
            string s_Rate = m_Taxation.Rate.val.ToString();
            s_Rate = s_Rate.Replace(",", ".");
            long id = -1;
            if (fs.GetID(s_Taxation_table_name,new string[]{s_col_Name,s_col_Rate},new string[]{"'" + m_Taxation.Name.val + "'",s_Rate},null,ref id,ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public static bool Init_DB_myCompany(ref string Err)
        {
            
            long_v Tax_ID = new long_v();
            Tax_ID.v = 19300808;
            string_v Registration_ID = new string_v();
            Registration_ID.v = "3802809000";

            long_v Bank_Tax_ID = new long_v();
            Bank_Tax_ID.v = 41561767;
            string_v Bank_Registration_ID = new string_v();
            Bank_Registration_ID.v = "5496527";
            string_v TRR = new string_v();
            TRR.v = "SI56 3000 0001 3135 582";
            string_v AccountDescription = new string_v();
            AccountDescription.v = "Tekoči račun";
            long Organisation_id = -1;
            long OrganisationAccount_id = -1;
            long OrganisationData_id = -1;
            if (fs.Get_OrganisationData_ID("Studio Marjetka d.o.o.",
                                        "Kunaverjeva",
                                        "6",
                                        "1000",
                                        "Ljubljana",
                                        "Slovenija",
                                         TRR,Tax_ID,
                                         Registration_ID,
                                         "SBERBANK",
                                         Bank_Tax_ID,
                                         Bank_Registration_ID,
                                         AccountDescription,
                                         "d.o.o.",
                                         "www.studio-mp.net",
                                         "info@studio-mp.net",
                                         "01 518 42 52 ali 040 433 667",
                                         "01 518 42 53",
                                         ref Organisation_id,
                                         ref OrganisationAccount_id,
                                         ref OrganisationData_id, 
                                         ref Err))
            {
                if (fs.GetID("myCompany", new string[] { "Organisation_ID" }, new string[] { Organisation_id.ToString() }, null, ref myCompany_ID, ref Err))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool Init_DB_myCompany_Person(ref string Err)
        {
            DateTime DateOfBirth = DateTime.Parse("20/04/1996");
            long_v TaxID = new long_v();
            TaxID.v = 19300808;
            string_v Registration_ID = new string_v();
            Registration_ID.v = "3802809000";
            long_v Bank_TaxID = new long_v();
            Bank_TaxID.v = 41561767;
            string_v Bank_Registration_ID = new string_v();
            Bank_Registration_ID.v = "5496527";
            string_v TRR = new string_v();
            TRR.v = "SI56 3000 0001 1747 415";
            string_v AccountDescription = new string_v();
            AccountDescription.v = "Osebni račun Marjetke";
            long Person_id = -1;
            if (fs.Get_Person_ID_and_PersonAccount_ID("Marjetka",
                                                   "Hrnčič-Štrucl",
                                                   DateOfBirth,
                                                   TaxID,
                                                  Registration_ID,
                                                  "SBERBANK",
                                                  Bank_TaxID,
                                                  Bank_Registration_ID,
                                                  TRR,
                                                  AccountDescription,
                                                  true,
                                                  ref Person_id,
                                                  ref myCompany_PersonAccount_id,
                                                  ref Err))
            {
                if (fs.GetID("myCompany_Person", new string[] { "UserName", "Password", "Job","Active", "Person_ID", "myCompany_ID" }, new string[] { "'marjetkah'", "'1234'", "'direktor in lastnik'","1", Person_id.ToString(), myCompany_ID.ToString() }, null, ref myCompany_Person_id, ref Err))
                {
                    return true;
                }
            }
            return false;
        }


        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }



        public static bool Init_DB_SimpleItem(ref string Err)
        {
            DBTablesAndColumnNames DBtcn = new DBTablesAndColumnNames();
            string s_SimpleItem_Image_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem_Image)).TableName;
            string s_SimpleItem_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem)).TableName;
            string s_Image_Hash = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem_Image)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_SimpleItem_Image.Image_Hash.GetType()).Name;
            string s_Image_Data = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem_Image)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_SimpleItem_Image.Image_Data.GetType()).Name;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_SimpleItem.Name.GetType()).Name;
            string s_col_Code = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_SimpleItem.Code.GetType()).Name;
            string s_col_Abbreviation = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_SimpleItem.Abbreviation.GetType()).Name;
            string s_col_SimpleItemImage_ID = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_SimpleItem.m_SimpleItem_Image.GetType()).Name;
            string s_col_ToOffer = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.SimpleItem)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_SimpleItem.ToOffer.GetType()).Name;

            foreach (BlagajnaTableClass.Price_SimpleItem pl_SimpleItem in m_List_Price_SimpleItem)
            {
                List<DBConnectionControl40.SQL_Parameter> lsql_par = null;
                Byte[] Image_Data = null;
                string Image_Hash = "null";
                if (pl_SimpleItem.m_SimpleItem.Abbreviation.val.Equals("PED"))
                {
                    lsql_par = new List<DBConnectionControl40.SQL_Parameter>();
                    Image_Data = ImageToByte2(Properties.Resources.Pedikira);
                    Image_Hash = DBtypesFunc.GetHash_SHA1(Image_Data);
                    DBConnectionControl40.SQL_Parameter sql_par = new DBConnectionControl40.SQL_Parameter("@image", SQL_Parameter.eSQL_Parameter.Varbinary, false, Image_Data);
                    sql_par.SQLiteDbType = System.Data.DbType.Binary;
                    DBConnectionControl40.SQL_Parameter sql_par_hash = new DBConnectionControl40.SQL_Parameter("@hash", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Image_Hash);
                    sql_par_hash.SQLiteDbType = System.Data.DbType.AnsiString;
                    lsql_par.Add(sql_par);
                    lsql_par.Add(sql_par_hash);
                }
                else if (pl_SimpleItem.m_SimpleItem.Abbreviation.val.Equals("MAN"))
                {
                    lsql_par = new List<DBConnectionControl40.SQL_Parameter>();
                    Image_Data = ImageToByte2(Properties.Resources.Manikira);
                    Image_Hash = DBtypesFunc.GetHash_SHA1(Image_Data);
                    DBConnectionControl40.SQL_Parameter sql_par = new DBConnectionControl40.SQL_Parameter("@image", SQL_Parameter.eSQL_Parameter.Varbinary, false, ImageToByte2(Properties.Resources.Manikira));
                    sql_par.SQLiteDbType = System.Data.DbType.Binary;
                    DBConnectionControl40.SQL_Parameter sql_par_hash = new DBConnectionControl40.SQL_Parameter("@hash", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Image_Hash);
                    sql_par_hash.SQLiteDbType = System.Data.DbType.AnsiString;
                    lsql_par.Add(sql_par);
                    lsql_par.Add(sql_par_hash);
                }
                else if (pl_SimpleItem.m_SimpleItem.Abbreviation.val.Equals("NOB"))
                {
                    lsql_par = new List<DBConnectionControl40.SQL_Parameter>();
                    Image_Data = ImageToByte2(Properties.Resources.Nega_Obraza);
                    Image_Hash = DBtypesFunc.GetHash_SHA1(Image_Data);
                    DBConnectionControl40.SQL_Parameter sql_par = new DBConnectionControl40.SQL_Parameter("@image", SQL_Parameter.eSQL_Parameter.Varbinary, false, Image_Data);
                    DBConnectionControl40.SQL_Parameter sql_par_hash = new DBConnectionControl40.SQL_Parameter("@hash", SQL_Parameter.eSQL_Parameter.Nvarchar, false, Image_Hash);
                    sql_par_hash.SQLiteDbType = System.Data.DbType.AnsiString;
                    sql_par.SQLiteDbType = System.Data.DbType.Binary;
                    lsql_par.Add(sql_par);
                    lsql_par.Add(sql_par_hash);
                }

                string[] sColumn = null;
                string[] sValue = null;
                if (lsql_par != null)
                {
                    long SimpleItem_Image_ID = -1;

                    if (!fs.GetID(s_SimpleItem_Image_table_name,new string[]{s_Image_Hash,s_Image_Data},new string[]{"@hash","@image"},lsql_par,ref SimpleItem_Image_ID,ref Err))
                    {
                        LogFile.Error.Show("ERROR:Init_DB_SimpleItem:insert into  SimpleItem_Image:Err=" + Err);
                        return false;
                    }

                    sColumn = new string[] { s_col_Name, s_col_Code, s_col_Abbreviation, s_col_SimpleItemImage_ID, s_col_ToOffer };
                    sValue = new string[] { "'" + pl_SimpleItem.m_SimpleItem.Name.val + "'",
                                                     pl_SimpleItem.m_SimpleItem.Code.val.ToString(),
                                                     "'"+ pl_SimpleItem.m_SimpleItem.Abbreviation.val + "'",
                                                     SimpleItem_Image_ID.ToString(),
                                                     "1"
                                                    };

                }
                else
                {
                    sColumn = new string[] { s_col_Name, s_col_Code, s_col_Abbreviation,  s_col_ToOffer };
                    sValue = new string[] { "'" + pl_SimpleItem.m_SimpleItem.Name.val + "'",
                                                     pl_SimpleItem.m_SimpleItem.Code.val.ToString(),
                                                     "'"+ pl_SimpleItem.m_SimpleItem.Abbreviation.val + "'",
                                                     "1"
                                                    };
                }
                long id = -1;

                if (fs.GetID(s_SimpleItem_table_name,sColumn,sValue,lsql_par,ref id,ref Err))
                {
                    pl_SimpleItem.m_SimpleItem.ID.val = id;
                    pl_SimpleItem.m_Taxation.ID.val = 1;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }

        public static bool Init_DB_Expiry(ref string Err)
        {
            string s_Expiry_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Expiry)).TableName;
            string s_col_ExpectedShelfLifeInDays = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Expiry)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Expiry.ExpectedShelfLifeInDays.GetType()).Name;
            string s_col_SaleBeforeExpiryDateInDays = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Expiry)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Expiry.SaleBeforeExpiryDateInDays.GetType()).Name;
            string s_col_DiscardBeforeExpiryDateInDays = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Expiry)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Expiry.DiscardBeforeExpiryDateInDays.GetType()).Name;
            string s_col_ExpiryDescription = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Expiry)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Expiry.ExpiryDescription.GetType()).Name;

            //            string s_col_Warranty = Program.LocalDB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Expiry)).FindColumn(Program.LocalDB_for_Blagajna.mt.m_Expiry.Warranty.GetType()).Name;
            //            string s_col_NeverExpires = Program.LocalDB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Expiry)).FindColumn(Program.LocalDB_for_Blagajna.mt.m_Expiry.NeverExpires.GetType()).Name;


            foreach (BlagajnaTableClass.Expiry Expiry in m_List_Expiry)
            {
                


              
                long Expiry_id = -1;
                if (fs.GetID(s_Expiry_table_name, new string[] { s_col_ExpectedShelfLifeInDays,
                                                                 s_col_SaleBeforeExpiryDateInDays,
                                                                 s_col_DiscardBeforeExpiryDateInDays,
                                                                 s_col_ExpiryDescription },
                                                 new string[] { Expiry.ExpectedShelfLifeInDays.val.ToString(),
                                                                Expiry.SaleBeforeExpiryDateInDays.val.ToString(),
                                                                Expiry.DiscardBeforeExpiryDateInDays.val.ToString(),
                                                                "'"+Expiry.ExpiryDescription.val+"'"
                                                                }, null, ref Expiry_id,ref Err))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }


        public static bool Init_DB_Item(ref string Err)
        {

            string s_Item_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).TableName;
            string s_col_UniqueName = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Item.UniqueName.GetType()).Name;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Item.Name.GetType()).Name;
            string s_col_Code = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Item.Code.GetType()).Name;
            string s_col_barcode = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Item.barcode.GetType()).Name;
            string s_col_Description = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Item.Description.GetType()).Name;

            string s_col_Item_Image_ID = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item_Image)).TableName + "_"+ DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item_Image)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Item_Image.ID.GetType()).Name;


//            string s_col_Warranty = Program.LocalDB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(Program.LocalDB_for_Blagajna.mt.m_Item.Warranty.GetType()).Name;
//            string s_col_NeverExpires = Program.LocalDB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(Program.LocalDB_for_Blagajna.mt.m_Item.NeverExpires.GetType()).Name;

            string s_col_ToOffer = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Item)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Item.ToOffer.GetType()).Name;

            foreach (BlagajnaTableClass.Item item in m_List_Item)
            {
                List<DBConnectionControl40.SQL_Parameter> lsql_par = null;
                lsql_par = new List<DBConnectionControl40.SQL_Parameter>();

                long m_Item_Image_ID = -1;
                DBConnectionControl40.SQL_Parameter sql_par = null;
                string s_val_Expiry_ID = null;
                if (item.m_Expiry == null)
                {
                    s_val_Expiry_ID = "null";
                }
                else
                {
                    s_val_Expiry_ID = item.m_Expiry.ID.val.ToString();
                }

                if (item.m_Item_Image!=null)
                {
                    sql_par = new DBConnectionControl40.SQL_Parameter("@image", DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Varbinary, false, item.m_Item_Image.Image_Data.val);
                    //sql_par.SQLiteDbType = System.Data.DbType.Binary;
                    lsql_par.Add(sql_par);
                    if (!fs.GetID("Item_Image",new string[]{"Image_Hash","Image_Data"},new string[]{"'"+item.m_Item_Image.Image_Hash.val + "'","@image"},lsql_par,ref m_Item_Image_ID,ref Err))
                    {
                      return false;
                    }
                }
                string[] sColumn = null;
                string[] sValue = null;

                if (sql_par != null)
                {
                    sColumn = new string[]{s_col_UniqueName,
                                           s_col_Name,
                                           s_col_Code,
                                           s_col_barcode,
                                           s_col_Description,
                                           s_col_Item_Image_ID,
                                           "Expiry_ID",
                                           "Warranty_ID",
                                           "Unit_ID",
                                           s_col_ToOffer
                                           };
                    sValue = new string[]{"'" + item.UniqueName.val + "'",
                                          "'" + item.Name.val + "'",
                                          item.Code.val.ToString(),
                                          "'" + item.barcode.val + "'",
                                          "'" + item.Description.val + "'",
                                          m_Item_Image_ID.ToString(),
                                          s_val_Expiry_ID,
                                          "null",
                                          "1",
                                          "1"
                                          };
                }
                else
                {
                    sColumn = new string[]{s_col_UniqueName,
                                           s_col_Name,
                                           s_col_Code,
                                           s_col_barcode,
                                           s_col_Description,
                                           "Expiry_ID",
                                           "Warranty_ID",
                                           "Unit_ID",
                                           s_col_ToOffer
                                           };
                    sValue = new string[]{"'" + item.UniqueName.val + "'",
                                          "'" + item.Name.val + "'",
                                          item.Code.val.ToString(),
                                          "'" + item.barcode.val + "'",
                                          "'" + item.Description.val + "'",
                                          s_val_Expiry_ID,
                                          "null",
                                          "1",
                                          "1"
                                          };
                }
                long Item_ID = -1;
                if (fs.GetID(s_Item_table_name, sColumn, sValue, lsql_par, ref Item_ID,ref Err))
                {
                    Random rnd = new Random();
                    decimal dprice = 20 + rnd.Next(30);
                    List<DBConnectionControl40.SQL_Parameter> lpar = new  List<DBConnectionControl40.SQL_Parameter>();
                    lpar.Clear();
                    string spar_PurchasePricePerUnit = "@par_PurchasePricePerUnit";
                    SQL_Parameter par_PurchasePricePerUnit = new SQL_Parameter(spar_PurchasePricePerUnit, SQL_Parameter.eSQL_Parameter.Decimal, false, dprice);
                    lpar.Add(par_PurchasePricePerUnit);
                    string spar_PurchasePriceDate = "@par_PurchasePriceDate";
                    DateTime dtNow = DateTime.Now;
                    SQL_Parameter par_PurchasePriceDate = new SQL_Parameter(spar_PurchasePriceDate, SQL_Parameter.eSQL_Parameter.Datetime, false, dtNow);
                    lpar.Add(par_PurchasePriceDate);

//                    string sql_PurchasePrice_Item = @"insert into PurchasePrice_Item (PurchasePricePerUnit,PurchasePriceDate,Currency_ID,Taxation_ID,PurchaseCompany_ID,Item_ID,ReferenceNote) values 
//                                                                  (@par_PurchasePricePerUnit,@par_PurchasePriceDate,1,1,1," + Item_ID.ToString() + ",null)";
                    long PurchasePrice_ID = -1;
                    if (fs.GetID("PurchasePrice",new string[] {"PurchasePricePerUnit",
                                                        "PurchasePriceDate",
                                                        "Currency_ID",
                                                        "Taxation_ID",
                                                        "Supplier_ID"
                                                        }, 
                                                      new string[] {"@par_PurchasePricePerUnit",
                                                                    "@par_PurchasePriceDate",
                                                                    "1",
                                                                    "1",
                                                                    "1"
                                                      }, lpar, ref PurchasePrice_ID, ref Err))
                    {
                        if (fs.GetID("PurchasePrice_Item",new string[] {"PurchasePrice_ID",
                                                            "Item_ID"
                                                            }, 
                                                          new string[] {PurchasePrice_ID.ToString(),
                                                                        Item_ID.ToString()
                                                          }, null, ref PurchasePrice_ID, ref Err))
                        {
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
                    return false;
                }
            }

            return true;

        }

        public static bool Init_DB_Supplier(ref string Err)
        {
            foreach (BlagajnaTableClass.OrganisationData Supplier_OrganisationData in m_List_OrganisationData_Supplier)
            {
                long Organisation_id = -1;
                long OrganisationAccount_id = -1;
                long OrganisationData_id = -1;
                if (fs.Get_OrganisationData_ID(Supplier_OrganisationData.m_Organisation.Name.val,
                                               Supplier_OrganisationData.m_cAddress_Org.m_cStreetName_Org.StreetName.val,
                                               Supplier_OrganisationData.m_cAddress_Org.m_cHouseNumber_Org.HouseNumber.val,
                                               Supplier_OrganisationData.m_cAddress_Org.m_cZIP_Org.ZIP.val,
                                               Supplier_OrganisationData.m_cAddress_Org.m_cCity_Org.City.val,
                                               Supplier_OrganisationData.m_cAddress_Org.m_cState_Org.State.val,
                                               null,
                                               null,
                                               null,
                                               null,
                                               null,
                                               null,
                                               null,
                                               "Gmbh",
                                               Supplier_OrganisationData.m_cHomePage_Org.HomePage.val,
                                               Supplier_OrganisationData.m_cEmail_Org.Email.val,
                                               Supplier_OrganisationData.m_cPhoneNumber_Org.PhoneNumber.val,
                                               Supplier_OrganisationData.m_cFaxNumber_Org.FaxNumber.val,
                                               ref Organisation_id,
                                               ref OrganisationAccount_id,
                                               ref OrganisationData_id,
                                               ref Err))
                {
                    long Supplier_id = -1;
                    if (fs.GetID("Supplier", new string[] { "Organisation_ID" }, new string[] { Organisation_id.ToString() }, null, ref Supplier_id, ref Err))
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
                    return false;
                }
            }
            return true;
        }

        public static bool Init_DB_PriceList_Item(ref string Err)
        {
            //string s_col_Taxation_ID = Program.LocalDB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Price_Item)).FindColumn(Program.LocalDB_for_Blagajna.mt.m_PriceList_Item.m_Taxation.GetType()).Name;
            //string s_col_PurchasePricePerUnit = Program.LocalDB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Price_Item)).FindColumn(Program.LocalDB_for_Blagajna.mt.m_PriceList_Item.PurchasePricePerUnit.GetType()).Name;
            //string s_col_RetailPricePerUnit = Program.LocalDB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Price_Item)).FindColumn(Program.LocalDB_for_Blagajna.mt.m_PriceList_Item.RetailPricePerUnit.GetType()).Name;
            return false;
        }

        public static bool Init_DB_Stock(ref string Err)
        {
            string s_Stock_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Stock)).TableName;
            string s_col_PurchasePrice_Item_ID = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Stock)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Stock.m_PurchasePrice_Item.GetType()).Name;
            string s_col_ImportTime = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Stock)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Stock.ImportTime.GetType()).Name;
            string s_col_ExpiryDate = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Stock)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Stock.ExpiryDate.GetType()).Name;
            string s_col_Quantity = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Stock)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Stock.dQuantity.GetType()).Name;

            foreach (BlagajnaTableClass.Stock Stock in m_List_Stock)
            {
                List<DBConnectionControl40.SQL_Parameter> lsql_par = null;

                lsql_par = new List<DBConnectionControl40.SQL_Parameter>();
                DBConnectionControl40.SQL_Parameter sql_par = new DBConnectionControl40.SQL_Parameter("@Par_" + s_col_ImportTime,DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Datetime, false, Stock.ImportTime.val);
                sql_par.SQLiteDbType = System.Data.DbType.DateTime;
                lsql_par.Add(sql_par);

                sql_par = new DBConnectionControl40.SQL_Parameter("@Par_" + s_col_ExpiryDate, DBConnectionControl40.SQL_Parameter.eSQL_Parameter.Datetime, false, Stock.ExpiryDate.val);
                sql_par.SQLiteDbType = System.Data.DbType.DateTime;
                lsql_par.Add(sql_par);


                long Stock_id = -1;
                if (fs.GetID(s_Stock_table_name,new string[]{s_col_PurchasePrice_Item_ID,
                                                             s_col_ImportTime,
                                                             s_col_ExpiryDate,
                                                             s_col_Quantity
                                                            },
                                               new string[]{Stock.m_PurchasePrice_Item.ID.val.ToString(),
                                                            "@Par_" + s_col_ImportTime,
                                                            "@Par_" + s_col_ExpiryDate,
                                                            Stock.dQuantity.val.ToString()
                                               },lsql_par,ref Stock_id,ref Err))
                {
                }
                else
                {
                    return false;
                }
            }
            return true;

        }

        private static bool Init_DB(ref string Err)
        {
            if (Init_DB_Taxation(ref Err))
            {
                if (Init_DB_myCompany(ref Err))
                {
                    if (Init_DB_myCompany_Person(ref Err))
                    {
                        if (Init_DB_SimpleItem(ref Err))
                        {
                            if (Init_DB_Expiry(ref Err))
                            {
                                if (Init_DB_Supplier(ref Err))
                                {
                                    if (Init_DB_Item(ref Err))
                                    {
                                        if (Init_DB_Stock(ref Err))
                                        {
                                            if (Init_DB_PriceList(ref Err))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                LogFile.Error.Show(Err);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show(Err);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show(Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show(Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show(Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show(Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show(Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }


        private static bool Init_DB_PriceList(ref string Err)
        {

            Random rnd = new Random(-1);
            if (InsertPriceList("Stranke", DateTime.Now,rnd, ref Err))
            {
                if (InsertPriceList("Nadaljna prodaja", DateTime.Now,rnd, ref Err))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool InsertPriceList(string Name,DateTime CreationTime,Random rnd, ref string Err)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Name);
            lpar.Add(par_Name);

            string spar_CreationDate = "@par_CreationDate";
            SQL_Parameter par_CreationDate = new SQL_Parameter(spar_CreationDate, SQL_Parameter.eSQL_Parameter.Datetime, false, CreationTime);
            lpar.Add(par_CreationDate);

            long PriceList_id = -1;
            object ores = null;

            if (fs.GetID("PriceList",new string[]{"Currency_ID",
                                                  "Name",
                                                  "Valid",
                                                  "ValidFrom",
                                                  "ValidTo",
                                                  "CreationDate",
                                                  "Description",
                                                  "myCompany_Person_ID",
                                                  },
                                  new string[]{"1",
                                                  spar_Name,
                                                  "1",
                                                  "null",
                                                  "null",
                                                  spar_CreationDate,
                                                  "'Prvi cenik za stranke.'",
                                                  "1"
                                                  }, lpar, ref PriceList_id,ref Err))
            {
                    string sql = @" insert into Price_SimpleItem (SimpleItem_ID,PriceList_ID,Taxation_ID,RetailSimpleItemPrice,Discount) 
                                    select id," + PriceList_id.ToString() + ",1,-1,0 from SimpleItem where ToOffer = 1";

                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                    {
                        DataTable dt = new DataTable();
                        sql = "select ID from Price_SimpleItem where PriceList_ID = "+PriceList_id.ToString();
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                        {
                            
                            
                            foreach (DataRow dr in dt.Rows)
                            {
                                long ID = (long)dr[0];
                                decimal dprice = 30 + rnd.Next(30);
                                lpar.Clear();
                                string spar_RetailSimpleItemPrice = "@par_RetailSimpleItemPrice";
                                SQL_Parameter par_RetailSimpleItemPrice = new SQL_Parameter(spar_RetailSimpleItemPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, dprice);
                                lpar.Add(par_RetailSimpleItemPrice);
                                decimal x = rnd.Next(40);
                                decimal discount = x/100;

                                string spar_Discount = "@par_Discount";
                                SQL_Parameter par_Discount = new SQL_Parameter(spar_Discount, SQL_Parameter.eSQL_Parameter.Decimal, false, discount);
                                lpar.Add(par_Discount);

                                sql = "update Price_SimpleItem set RetailSimpleItemPrice = " + spar_RetailSimpleItemPrice + ",Discount = " + spar_Discount + " where id = " + ID.ToString();
                                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                                {
                                }
                                else
                                {
                                    return false;
                                }
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

                    sql = @" insert into Price_Item (RetailPricePerUnit,Discount,Taxation_ID,Item_ID,PriceList_ID) 
                                    select -1,0,1,id," + PriceList_id.ToString() + " from Item where ToOffer = 1";
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                    {
                        DataTable dt = new DataTable();
                        sql = "select ID from Price_Item where PriceList_ID = " + PriceList_id.ToString();
                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                long ID = (long)dr[0];
                                decimal dprice = 80 + rnd.Next(30);
                                lpar.Clear();
                                string spar_RetailPricePerUnit = "@par_RetailPricePerUnit";
                                SQL_Parameter par_RetailPricePerUnit = new SQL_Parameter(spar_RetailPricePerUnit, SQL_Parameter.eSQL_Parameter.Decimal, false, dprice);
                                lpar.Add(par_RetailPricePerUnit);
                                decimal x = rnd.Next(50);
                                decimal discount = x / 100;

                                string spar_Discount = "@par_Discount";
                                SQL_Parameter par_Discount = new SQL_Parameter(spar_Discount, SQL_Parameter.eSQL_Parameter.Decimal, false, discount);
                                lpar.Add(par_Discount);

                                sql = "update Price_Item set RetailPricePerUnit = " + spar_RetailPricePerUnit + ",Discount = " + spar_Discount + " where id = " + ID.ToString();
                                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                                {
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
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
                return false;
            }
        }
    }
}
