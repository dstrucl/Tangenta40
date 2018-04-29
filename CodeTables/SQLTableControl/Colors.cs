using ColorSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTables
{
    public static class Colors
    {
        public static CtrlColors EditTable = new CtrlColors(lng.s_CtrlColor_EditTable.s, 0, Properties.Settings.Default.Color_0, Color.Black);
        public static CtrlColors EditSubTable = new CtrlColors(lng.s_CtrlColor_EditSubTable.s, 1, Properties.Settings.Default.Color_1, Color.Black);
        public static CtrlColors EditSubSubTable = new CtrlColors(lng.s_CtrlColor_EditSubSubTable.s, 2, Properties.Settings.Default.Color_2, Color.Black);
        public static CtrlColors EditSubSubSubTable = new CtrlColors(lng.s_CtrlColor_EditSubSubSubTable.s, 3, Properties.Settings.Default.Color_3, Color.Black);
    }
}
