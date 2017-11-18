#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LanguageControl;

namespace TangentaSampleDB
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_Form_EditMyOrgSampleData = new ltext(new string[] { "Sample data for organisation name Company1. You can change them to your organisation data.", "Vzorčni podatki organizacije z imenom Podjetje1, ki jih lahko spremenite v tem dialogu v podatke vaše organizacije." });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_EditMyOrgSampleData.cs

        public static ltext s_YouHaveChangedSomeDataButNotAllSampleData_YouShouldChangeAllSampleDataToYourRealData = new ltext(new string[] { "You have only changed some of sample data!\r\nIf you want to run this application with your real data, press OK and then change all sample data to your real organisation data.If you want to run this application with your modified sample data press Cancel", "Spremenili ste samo nekatere vzorčne podatke.\r\nČe želite, da bo program uporabljal prave podatke pritisnite gumb \"V redu\" in spremenite vse vzorčne podatke v prave podatke.\r\nČe želite, da bo program uporabljal spremenjene vzorčne podatke in tekel kot demo aplikacija pritisnite gumb \"Prekini\"" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_EditMyOrgSampleData.cs

        public static ltext s_IfYouAreRunningThisApplicationOnlyForDemoOrTestPurposesPressYes = new ltext(new string[]{"If you are running this application only for demo or test pruposes select Yes, otherwise press No ?",
                                                                                                            "V kolikor sta zagnali to aplikacijo zgolj z namenom preizkusa ali testiranja izberite Da sicer izberite Ne ?"});   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_NumberOfItemsToInsert = new ltext(new string[] { "Number of items to insert ", "Število artiklov za vpis " });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_lbl_Number_Of_Items_per_group = new ltext(new string[] { "Number of items in group", "Število artiklov ali storitev v skupini" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_lbl_Number_Of_Groups_in_Level1 = new ltext(new string[] { "Number of groups in Level 1", "Število skupin artiklov ali storitev nivoja 1" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_lbl_Number_Of_Groups_in_Level2 = new ltext(new string[] { "Number of groups in Level 2", "Število skupin artiklov ali storitev nivoja 2" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_lbl_Number_Of_Groups_in_Level3 = new ltext(new string[] { "Number of groups in Level 3", "Število skupin artiklov ali storitev nivoja 3" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_lbl_ItemAbbreviationPrefix = new ltext(new string[] { "Item name abbreviation prefix", "Predpona za skrajšano ime artikla ali storitve" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_lbl_ItemNamePrefix = new ltext(new string[] { "Item name prefix", "Predpona za ime artikla ali storitve" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_GeneratorOfSampleItems = new ltext(new string[] { "Generator of sample items", "Generator vzorčnih (demo) artiklov oziroma storitev" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_rdb_AutoGenerateDemoItems = new ltext(new string[] { "Auto generate demo items", "Atomatsko generiraj vzorčne artikle oziroma storitve" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_rdb_InsertItemsManualy = new ltext(new string[] { "Insert Manually", "Ročni vnos artiklov/storitev" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_InsertSampleItems_for_shop = new ltext(new string[] { "Select items insertion for shop", "Izberite vnos artiklov/storitev za prodajalno " });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext ShopB_Item_Name_Item = new ltext(new string[] { "BItem", "BArtikel" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext ShopB_Item_Abbreviation_SB = new ltext(new string[] { "BItm", "BArt" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext ShopC_Item_Name_Item = new ltext(new string[] { "CItem", "CArtikel" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext ShopC_Item_Abbreviation_SB = new ltext(new string[] { "CItm", "CArt" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_Shop_B = new ltext(new string[] { "B", "B" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_Question = new ltext(new string[] { "?", "?" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\Form_Items_Samples.cs

        public static ltext s_JobInPercentDone = new ltext(new string[] { "Job done:", "Količina opravljenaga dela v odstotkih:" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_WriteItemsToDatabase = new ltext(new string[] { "Number of items to write:", "Število artiklov za vpis:" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_ItemsWrittenToDB = new ltext(new string[] { "Number of items inserted to database:", "Število artiklov vpisanih v podatkovno bazo:" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Piece = new ltext(new string[] { "Piece", "Komad" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_PieceAbr = new ltext(new string[] { "Pcs", "Kom." });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_SelectCountryWhereYouPayTaxes = new ltext(new string[] { "Country of tax residency", "Država katere ste davčni zavezanec" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext PriceList_Description = new ltext(new string[] { "Price list for usual customers.", "Cenik za stalne stranke." });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Comment1 = new ltext(new string[] { "Comment 1", "Komentar 1" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_BankAccount = new ltext(new string[] { "Bank Account", "Bančni račun" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Shop_C = new ltext(new string[] { "C", "C" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_MyOrganisation = new ltext(new string[]{"My organisation",
                                                    "Moja oragnizacija"});   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Office = new ltext(new string[]{"Office",
                                                    "Poslovna enota"});   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Description = new ltext(new string[] { "Description", "opis" });   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Person = new ltext(new string[]{"Person",
                                          "Oseba"});   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Address = new ltext(new string[]{"Address",
                                           "Naslov"});   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Country = new ltext(new string[]{"Country",
                                         "Država"});   // referenced in C:\Tangenta40\TANGENTA\TangentaSampleDB\SampleDB.cs

        public static ltext s_Bank = new ltext(new string[] { "Bank", "Banka" });

        public static ltext PriceList_Name = new ltext(new string[] { "PRICE LIST CUSTOMERS", "CENIK STRANKE" });

        public static ltext ShopB_Item_ParentGroup = new ltext(new string[]{"ShopBGroup", "ProdajalnaBSkupina"});

        public static ltext ShopC_Item_UniquName_UniqueItemName1 = new ltext(new string[]{"UniqueItemName1", "UnikatnoImeArtikla1"});

        public static ltext ShopC_Item_Name_ItemName1 = new ltext(new string[]{"ItemName1", "ImeArtikla1"});

        public static ltext ShopC_Item_ParentGroup1 = new ltext(new string[]{"ShopCGroup1", "ProdajalnaCSkupina1"});

    }
}
