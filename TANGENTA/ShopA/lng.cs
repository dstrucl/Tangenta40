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

        public static ltext s_ShopB_Items = new ltext( new string[]{"Shop B Items",
                                                   "Artikli/Storitve prodajalne B"});   // referenced in C:\Tangenta40\TANGENTA\ShopA\Form_ShopAItem_Edit.cs

        public static ltext s_Select_ShopA_Item = new ltext(new string[] { "Select Item", "Izberite Artikel" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\Form_Tool_SelectItem.cs

        public static ltext s_Item_name_must_be_defined = new ltext(new string[] { "Item name must be defined!", "Ime postavke mora biti določen!" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Name.cs

        public static ltext s_TaxRate_must_be_defined = new ltext(new string[] { "Tax rate name must be defined!", "Davčna stopnja mora biti določena!" });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Tax.cs

        public static ltext s_Price_for = new ltext(new string[] { "Price for", "Cena za " });   // referenced in C:\Tangenta40\TANGENTA\ShopA\usrc_Edit_Item_Unit.cs

    }
}
