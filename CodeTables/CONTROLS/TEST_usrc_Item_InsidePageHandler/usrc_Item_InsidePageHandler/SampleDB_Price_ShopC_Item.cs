using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usrc_Item_InsidePageHandler
{
    public class SampleDB_Price_ShopC_Item
    {


        public string ShopC_Item_Name = null;

        public string ShopC_Item_ParentGroup1 = null;
        public string ShopC_Item_ParentGroup2 = null;
        public string ShopC_Item_ParentGroup3 = null;



        public SampleDB_Price_ShopC_Item(   string xShopC_Item_Name,
                                            string xShopC_Item_ParentGroup1,
                                            string xShopC_Item_ParentGroup2,
                                            string xShopC_Item_ParentGroup3
                                            )
        {

            ShopC_Item_Name = xShopC_Item_Name;
            ShopC_Item_ParentGroup1 = xShopC_Item_ParentGroup1;
            ShopC_Item_ParentGroup2 = xShopC_Item_ParentGroup2;
            ShopC_Item_ParentGroup3 = xShopC_Item_ParentGroup3;
        }
    }
}
