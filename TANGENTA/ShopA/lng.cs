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

namespace ShopA
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_ShopA_Name = new ltext(new string[]{"Shop A","Prodajalna A"});   

        public static ltext s_CtrlColor_ShopA = new ltext(new string[]{"Shop A colors",
                                                   "Barvi prodajalne A"});   // referenced in C:\Tangenta40\TANGENTA\ShopA\Form_ShopAItem_Edit.cs

        public static ltext s_ShopA_Items = new ltext( new string[]{"Shop A Items",
                                                   "Artikli/Storitve prodajalne A"});   // referenced in C:\Tangenta40\TANGENTA\ShopA\Form_ShopAItem_Edit.cs

        public static ltext s_Select_ShopA_Item = new ltext(new string[] { "Select Item", "Izberite Artikel" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\Form_Tool_SelectItem.cs

        public static ltext s_Item_name_must_be_defined = new ltext(new string[] { "Item name must be defined!", "Ime postavke mora biti določen!" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Name.cs

        public static ltext s_TaxRate_must_be_defined = new ltext(new string[] { "Tax rate name must be defined!", "Davčna stopnja mora biti določena!" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Tax.cs

        public static ltext s_Price_for = new ltext(new string[] { "Price for", "Cena za " });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Unit.cs

        public static ltext s_btn_AddNewLine = new ltext(new string[] { "Add new line", "Vpiši v novo vrstico" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Editor.cs

        public static ltext s_lbl_EndNetPrice = new ltext(new string[] { "Net price", "Neto cena" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Editor.cs

        public static ltext s_lbl_EndPriceWidthDisocunt = new ltext(new string[] { "End price with discount", "Končna cena z davkom in popustom" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Editor.cs

        public static ltext s_lbl_Tax = new ltext(new string[] { "Tax", "Davek" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Editor.cs

        public static ltext s_chk_PriceWithTax = new ltext(new string[] { "Write price with tax", "Vnos cen z davkom" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Editor.cs

        public static ltext s_btn_Discount = new ltext(new string[] { "Discount", "Popust" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Editor.cs

        public static ltext s_chk_Unit = new ltext(new string[] { "Unit", "Merska enota" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Unit.cs

        public static ltext s_lbl_PricePerUnit = new ltext(new string[] { "Price per unit", "Cena na enoto" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Unit.cs

        public static ltext s_lbl_Quantity = new ltext(new string[] { "Quantity", "Količina" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Unit.cs

        public static ltext s_lbl_Item_Unit = new ltext(new string[] { "Unit", "Merska enota" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Unit.cs

        public static ltext s_lbl_Item_TaxRate = new ltext(new string[] { "Tax rate", "Davek" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Tax.cs

        public static ltext s_lbl_Item_Price = new ltext(new string[] { "Price", "Cena" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Price.cs
        
        public static ltext s_lbl_ItemName = new ltext(new string[] { "Item name", "Ime postavke" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Name.cs

        public static ltext s_lbl_Item_Description = new ltext(new string[] { "Description", "Opis" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Description.cs
        
    }
}
