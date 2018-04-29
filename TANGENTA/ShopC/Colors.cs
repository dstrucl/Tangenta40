using ColorSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopC
{
    public static class Colors
    {
        public static CtrlColors ShopC = new CtrlColors(lng.s_CtrlColor_ShopC.s, 6,Color.White, Color.Black);
        public static CtrlColors ItemFromFactory = new CtrlColors(lng.s_CtrlColor_ItemFromFactory.s, 8, Color.White, Color.Black);
        public static CtrlColors ItemFromStock = new CtrlColors(lng.s_CtrlColor_ItemFromProduction.s, 10, Color.White, Color.Black);
    }
}
