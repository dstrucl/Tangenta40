using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class ShopC_Item
    {
        public string_v UniqueName_v = null;
        public string_v Name_v = null;
        public bool_v bToOffer_v = null;
        public Image Item_Image = null;
        public ID Item_Image_ID = null;
        public string_v Item_Image_Hash_v = null;
        public long_v Code_v = null;
        public string_v Unit_Name_v = null;
        public string_v Unit_Symbol_v = null;
        public int_v Unit_DecimalPlaces_v = null;
        public bool_v Unit_StorageOption_v = null;
        public string_v Unit_Description_v = null;
        public string_v barcode_v = null;
        public string_v Description_v = null;
        public ID Expiry_ID = null;
        public ID Warranty_ID = null;
        public f_Expiry.Expiry_v Expiry_v = null;
        public f_Warranty.Warranty_v Warranty_v = null;
        public ID Item_ParentGroup1_ID = null;
        public string_v Item_ParentGroup1_v = null;
        public ID Item_ParentGroup2_ID = null;
        public string_v Item_ParentGroup2_v = null;
        public ID Item_ParentGroup3_ID = null;
        public string_v Item_ParentGroup3_v = null;
        public ID Unit_ID = null;
        public ID Item_ID = null;
    }
}
