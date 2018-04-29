using ColorSettings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup
{
    public static class Colors
    {
        public static CtrlColors usrc_startup_step = new CtrlColors(lng.s_CtrlColors_StartupStep.s, 9, Color.White,Color.Brown);
        public static CtrlColors usrc_startup = new CtrlColors(lng.s_CtrlColors_Startup.s, 9, Color.White, Color.Brown);
    }
}
