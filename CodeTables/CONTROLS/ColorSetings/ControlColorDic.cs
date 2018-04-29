using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSettings
{
    public static class ControlColorDic
    {
        public static Image ImageCancel = null;

        public static string sColorIndex = "Colors index ";
        public static string sColorOfIndex = "Colors of index ";
        public static string sOfColorPallete = " of  color pallete ";
        public static string sIsUsedOnTheseControls = " is used on following controls:";

        public static List<string>[] dic = new List<string>[16];

        public static void Add(int index, string xcontrolname)
        {
            if (dic[index]==null)
            {
                dic[index] = new List<string>();
            }
            dic[index].Add(xcontrolname);
        }

        internal static string GetControlNames(int i)
        {
            if (dic[i] != null)
            {
                string sControls = "";
                foreach (string s in dic[i])
                {
                    if (sControls.Length==0)
                    {
                        sControls += s;
                    }
                    else
                    {
                        sControls += ",\r\n"+s;
                    }
                }
                return sControls;
            }
            else
            {
                return "";
            }
        }
    }
}
