using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
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

        public static bool FindColumn(DataGridView dgv, string column_name)
        {
            foreach (DataGridViewColumn dgvcol in dgv.Columns)
            {
                if (dgvcol.Name.Equals(column_name))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetApplicationDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public static bool SetApplicationDataSubFolder(ref string folder, string subFolder, ref string Err)
        {
            Err = null;
            string xFolder = GetApplicationDataFolder() + subFolder;
            try
            {
                if (!Directory.Exists(xFolder))
                {
                    Directory.CreateDirectory(xFolder);
                }
                GrantFolderAccess(xFolder);
                folder = xFolder;
                return true;
            }
            catch (Exception Ex)
            {
                Err = Ex.Message + "\r\n" + Ex.StackTrace;
            }
            folder = null;
            return false;
        }

        public static void GrantFolderAccess(string Folder)
        {
            bool exists = System.IO.Directory.Exists(Folder);
            if (!exists)
            {
                try
                {

                    DirectoryInfo di = System.IO.Directory.CreateDirectory(Folder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not create folder:" + Folder + "\r\nException:" + ex.Message);
                }

            }
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(Folder);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not set FullControl permision to folder:\"" + Folder + "\"!\r\nException:" + ex.Message + "\r\n\r\nSolution:Run program as administrator.");
            }

        }

        public static string GetStringDate(DateTime firstLogin)
        {
            return firstLogin.Day.ToString() + "." + firstLogin.Month.ToString() + "." + firstLogin.Year.ToString();
        }

        public static string GetStringTime(DateTime firstLogin)
        {
            string shour = firstLogin.Hour.ToString();
            if (shour.Length == 1)
            {
                shour = '0' + shour;
            }
            string sminute = firstLogin.Minute.ToString();
            if (sminute.Length == 1)
            {
                sminute = '0' + sminute;
            }

            return shour + ":" + sminute;
        }

        public static string GetPercent(decimal v,int idecimalplaces)
        {
            decimal d = decimal.Round(v * 100, idecimalplaces);
            return d.ToString();

        }
    }
}
