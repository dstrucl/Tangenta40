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
        public static CtrlColors ColorLevel0 = new CtrlColors("ColorLevel0",0, 9, Properties.Settings.Default.Color_0, Color.Black);
        public static CtrlColors ColorLevel1 = new CtrlColors("ColorLevel1", 1, 9, Properties.Settings.Default.Color_1, Color.Black);
        public static CtrlColors ColorLevel2 = new CtrlColors("ColorLevel2", 2, 9, Properties.Settings.Default.Color_2, Color.Black);
        public static CtrlColors ColorLevel3 = new CtrlColors("ColorLevel3", 3, 9, Properties.Settings.Default.Color_3, Color.Black);
        public static CtrlColors ColorLevel4 = new CtrlColors("ColorLevel4", 0, 9, Properties.Settings.Default.Color_0, Color.Black);
        public static CtrlColors ColorLevel5 = new CtrlColors("ColorLevel5", 1, 9, Properties.Settings.Default.Color_1, Color.Black);
        public static CtrlColors ColorLevel6 = new CtrlColors("ColorLevel6", 2, 9, Properties.Settings.Default.Color_2, Color.Black);
        public static CtrlColors ColorLevel7 = new CtrlColors("ColorLevel7", 3, 9, Properties.Settings.Default.Color_2, Color.Black);
        public static CtrlColors ColorLevel8 = new CtrlColors("ColorLevel8", 0, 9, Properties.Settings.Default.Color_2, Color.Black);
        public static CtrlColors ColorLevel9 = new CtrlColors("ColorLevel9", 1, 9, Properties.Settings.Default.Color_2, Color.Black);

    }
}
