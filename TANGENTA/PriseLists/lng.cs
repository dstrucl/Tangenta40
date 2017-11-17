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

namespace PriseLists
{
    public static class lng
    {
 public static ltext s_PriceListType = new ltext( new string[]{"Price List Type", "Ceniki"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_Edit.cs

 public static ltext s_PriceList = new ltext( new string[]{"Price List", "Cenik"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_UniqueName = new ltext( new string[]{"Unique name", "Unikatno ime"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_Name = new ltext( new string[]{"name", "ime"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_Pricelist_is_not_complete = new ltext( new string[]{"Pricelist is not complete", "Cenik je nepopoln"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_SimpleItem_Not_in_PriceList = new ltext( new string[]{"SimpleItem not in pricelist:", "V ceniku manjkajo sledeče storitve:"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_Item_Not_in_PriceList = new ltext( new string[]{"Item not in pricelist:", "V ceniku manjkajo sledeči artikli:"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_OK = new ltext( new string[]{"OK",
                                                 "V redu"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_Cancel = new ltext( new string[]{"Cancel",
                                          "Prekini"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\Form_PriceList_NotComplete.cs

 public static ltext s_NoPriceList_AskToCreatePriceList = new ltext( new string[]{"No Price List, Write Price List?", "Ni cenikov.\r\nVnesi cenike ?"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList.cs

 public static ltext s_Shop_B = new ltext( new string[]{"B", "B"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_Shop_C = new ltext( new string[]{"C", "C"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_If_you_want_to_change_the_tax_only_to_the_selected_article___ = new ltext( new string[]{"If you want to change the tax only to the selected article (service), click (No).\r\nIf you want to change the tax to all trade items click the button (Yes).",
                                                                                         "Če želite spremeniti davek samo izbranemu artiklu (storitvi) kliknite gumb (Ne).\r\nČe želite spremeniti davek vsem artiklom kliknite gumb (Da)."});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_belongs_to_many_other_trade_items_and_services = new ltext( new string[]{"belongs to many other trade items and services."," pripada tudi mnogim drugim artiklom in storitvam."});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_Tax_with_name = new ltext( new string[]{"Tax whose name is ", "Davek katerega ime je "});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_OnlyValidPriceList = new ltext( new string[]{"Only valid pricelists", "Samo veljavni Ceniki"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_AllPriceList = new ltext( new string[]{"All PriceLists", "Vsi Ceniki"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_OnlyUnvalid = new ltext( new string[]{"Only unvalid pricelists", "samo neveljavni Ceniki"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext s_Manage_PriceLists = new ltext( new string[]{"Manage PRICE LISTS", "UREJANJE CENIKOV"});   // referenced in C:\Tangenta40\TANGENTA\PriseLists\usrc_PriceList_Edit.cs

 public static ltext PriceList_Name = new ltext(new string[] { "PRICE LIST CUSTOMERS", "CENIK STRANKE" });

    }
}
