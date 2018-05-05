using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            for (int i = 0; i < 200; i++)
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
            MessageBox.Show("ERROR:More than 200 parent controls are not supported in Global:f:GetParentForm(Control xctrl) (file Global.cs)");
            return null;
        }

        public static string GetAssemblyVersion(int build, int major, short majorRevision, int minor, short minorRevision)
        {
            string sAssemblyVersion = "V" + major.ToString() + "_" + majorRevision.ToString() + "_" + minor.ToString() + "_" + minorRevision.ToString();
            return sAssemblyVersion;
        }

        private static SHA1CryptoServiceProvider my_SHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();

        public static string GetHash_SHA1(byte[] byteArray)
        {
            string hash = "";
            hash = Convert.ToBase64String(my_SHA1CryptoServiceProvider.ComputeHash(byteArray));
            return hash;
        }
        public static string GetHash_UrlTokenEncode(byte[] byteArray)
        {
            string hash = "";
            hash = System.Web.HttpServerUtility.UrlTokenEncode(my_SHA1CryptoServiceProvider.ComputeHash(byteArray));
            return hash;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static bool StringDefined(string accessibleName)
        {
            if (accessibleName == null)
            {
                return false;
            }
            else if (accessibleName.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
