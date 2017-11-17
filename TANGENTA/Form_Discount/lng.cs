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

namespace Form_Discount
{
    public static class lng
    {
        public static void SetDictionary()
        {
            LanguageControl.DynSettings.AddLanguageLibrary(typeof(lng).GetFields(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        public static ltext s_PurchasePriceInfoText = new ltext( new string[]{"Item:%s1  Purchase Price  = %s2", "Artikel/Storitev:%s1 Nabavna cena = %s2"});   // referenced in C:\Tangenta40\TANGENTA\Form_Discount\Form_Discount.cs

        public static ltext s_btn_PurchasePriceInfo = new ltext(new string[] { "Purchase Price Info", "Informacija o nabavni ceni" });   // referenced in C:\Tangenta40\TANGENTA\Form_Discount\Form_Discount.cs

        public static ltext s_ExtraDiscountMakesLowerPriceThan_PurchasePrice = new ltext(new string[] { "Retail price %s1 with discount %s2 is %s3 and is smaller or equal to purchase price %s4. Do you agree ?", "Cena %s1 s popustom %s2 znaša %s3 in je manjša ali enaka nabavni ceni %s4. Soglašate ?" });   // referenced in C:\Tangenta40\TANGENTA\Form_Discount\Form_Discount.cs

        public static ltext s_rdb_EndPrice = new ltext(new string[] { "End price:", "Končna cena:" });   // referenced in C:\Tangenta40\TANGENTA\Form_Discount\Form_Discount.cs

        public static ltext s_rdb_CustomDiscount = new ltext(new string[] { "Discount:", "Popust:" });   // referenced in C:\Tangenta40\TANGENTA\Form_Discount\Form_Discount.cs

        public static ltext s_Price = new ltext(new string[] { "Price", "Cena" });   // referenced in C:\Tangenta40\TANGENTA\Form_Discount\Form_Discount.cs

    }
}
