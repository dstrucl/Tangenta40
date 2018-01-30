using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Global
{
    public static class f
    {
        public static Form GetParentForm(Control xctrl)
        {
            Control ctrlParent = xctrl.Parent;
            for (int i = 0; i < 20; i++)
            {
                if (ctrlParent != null)
                {
                    if (ctrlParent is Form)
                    {
                        return (Form)ctrlParent;
                    }
                    else
                    {
                        ctrlParent = ctrlParent.Parent;
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public static string GetAssemblyVersion(int build, int major, short majorRevision, int minor, short minorRevision)
        {
            string sAssemblyVersion = "V" + major.ToString() + "_" + majorRevision.ToString() + "_" + minor.ToString() + "_" + minorRevision.ToString();
            return sAssemblyVersion;
        }
    }
}
