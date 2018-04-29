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

namespace ShopB
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_CtrlColor_ShopB = new ltext(new string[] { "Shop B colors", "Barvi prodajalne B" }); 

        public static ltext s_Shop_B = new ltext( new string[]{"B", "B"});   // referenced in C:\Tangenta40\TANGENTA\ShopB\Form_SimpleItem_Edit.cs

        public static ltext s_OnlyInOffer = new ltext(new string[] { "Only in offer", "Samo tiste v ponudbi" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\Form_SimpleItem_Edit.cs

        public static ltext s_AllItems = new ltext(new string[] { "All", "Vse" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\Form_SimpleItem_Edit.cs

        public static ltext s_OnlyNotInOffer = new ltext(new string[] { "Only those not in offer", "Samo tiste ki niso v ponudbi" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\Form_SimpleItem_Edit.cs

        public static ltext s_DataChangedSaveYourData = new ltext(new string[] { "You have changed data. Save your work?", "Vnesli ste podatke.\r\nShranim vnešene podatke?" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\Form_SimpleItem_Edit.cs

        public static ltext s_DataChangedDoYouWantToCloseYesNo = new ltext(new string[] { "You have changed data. Do you want to cancel edit?", "Vnesli ste podatke.\r\nŽelite prekiniti vnos?" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\Form_SimpleItem_Edit.cs

        public static ltext s_Items = new ltext(new string[]{"Items",
                                                "Artikli"});   // referenced in C:\Tangenta40\TANGENTA\ShopB\Form_SimpleItem_Edit.cs

        public static ltext s_lbl_SimpleItems = new ltext(new string[] { "Items B", "Trgovina B" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_lbl_SelectedSimpleItems = new ltext(new string[] { "Selected in Store B", "Izbrano iz B" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_SimpleItem_Abbreviation = new ltext(new string[] { "Abbreviation", "Oznaka" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_RetailSimpleItemPrice = new ltext(new string[] { "Price", "Cena" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_SimpleItem_Name = new ltext(new string[] { "Name", "Ime" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_Discount = new ltext(new string[] { "Discount", "Popust" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_PriceList_Name = new ltext(new string[] { "PriceList", "Cenik" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_Taxation_Name = new ltext(new string[] { "Taxation", "Davek" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_Taxation_Rate = new ltext(new string[] { "Taxation rate", "Davčna stopnja" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_SimpleItem_Code = new ltext(new string[] { "Code", "razvrst.št." });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_SimpleItem_Image_Image_Data = new ltext(new string[] { "Image", "Slika" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_s1_name = new ltext(new string[] { "Group 1", "Skupina 1" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_s2_name = new ltext(new string[] { "Group 2", "Skupina 2" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_dgv_SimpleItems_column_s3_name = new ltext(new string[] { "Group 3", "Skupina 3" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_ExtraDiscount = new ltext(new string[] { "Extra discount", "Dodaten popust" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_PriceListDiscount = new ltext(new string[] { "PriceList discount", "Popust po ceniku" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_TotalDiscount = new ltext(new string[] { "Total discount", "Ves popust" });   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

        public static ltext s_Discount = new ltext(new string[]{"Discount:",
                                                   "Popust:"});   // referenced in C:\Tangenta40\TANGENTA\ShopB\usrc_ShopB.cs

    }
}
