using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorSettings
{
    public static class Sheme
    {

        private static ColorSheme ColorShemeCurrent = new ColorSheme();
        private static ColorSheme ColorShemeTemp = new ColorSheme();

        public static dsColorSheme dsColorSheme = new dsColorSheme();


        public static int Count
        {
            get
            {
                if (dsColorSheme!=null)
                {
                    DataTable dtsheme = dsColorSheme.Tables["Sheme"];
                    if (dtsheme!=null)
                    {
                        return dtsheme.Rows.Count;
                    }
                }
                return 0;
            }
        }

        public static ColorSheme Get(string Name, bool bNew)
        {
            if (Sheme.Count > 0)
            {
                DataTable dtsheme = dsColorSheme.Tables["Sheme"];
                DataRow[] drs_sheme = dtsheme.Select("Name = '" + Name + "'");
                if (drs_sheme.Length > 0)
                {
                    ColorSheme colorsheme = null;
                    if (bNew)
                    {
                        colorsheme = new ColorSheme();
                    }
                    else
                    {
                        colorsheme = ColorShemeTemp;
                    }
                    colorsheme.Name = (string)drs_sheme[0]["Name"];
                    colorsheme.ReadOnly = (bool)drs_sheme[0]["ReadOnly"];
                    int idsheme = (int)drs_sheme[0]["ID"];
                    DataTable dtcolors = dsColorSheme.Tables["Colors"];
                    DataRow[] drs_colors = dtcolors.Select("Sheme_ID = " + idsheme.ToString());
                    int icolorslength = drs_colors.Length;
                    if (icolorslength > 0)
                    {
                        colorsheme.color = new System.Drawing.Color[10];
                        for (int j = 0; j < 10; j++)
                        {
                            string hexcolor = (string)drs_colors[0]["Color" + j.ToString()];
                            colorsheme.color[j] = System.Drawing.ColorTranslator.FromHtml(hexcolor);
                        }
                        return colorsheme;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        internal static void Save(ColorSheme csheme)
        {
            DataTable dtsheme = dsColorSheme.Tables["Sheme"];
            DataRow[] drsheme = dtsheme.Select("Name='" + csheme.Name + "'");
            int drshemelength = drsheme.Length;
            if (drshemelength>0)
            {
                int idsheme = (int)drsheme[0]["ID"];
                DataTable dtcolors = dsColorSheme.Tables["Colors"];
                DataRow[] drcolors = dtcolors.Select("Sheme_ID=" + idsheme.ToString());
                int drcolorslength = drcolors.Length;
                if (drcolorslength>0)
                {
                    for (int j=0;j<10;j++)
                    {
                        drcolors[0]["Color" + j.ToString()] = System.Drawing.ColorTranslator.ToHtml(csheme.color[j]);
                    }
                    string Err = null;
                    Write(ref Err);
                }
            }
        }

        public static ColorSheme Current()
        {
            DataTable sheme = dsColorSheme.Tables["Sheme"];
            DataRow drsheme = sheme.Rows[Properties.Settings.Default.CurrentColorsIndex];
            int idsheme = (int) drsheme["ID"];
            string shemeName = (string)drsheme["Name"];
            bool bReadOnly = (bool)drsheme["ReadOnly"];
            DataTable colors = dsColorSheme.Tables["Colors"];
            DataRow[] drscolors = colors.Select("Sheme_ID = " + idsheme.ToString());
            ColorShemeCurrent.Name = shemeName;
            ColorShemeCurrent.ReadOnly = bReadOnly;
            int icolorslength = drscolors.Length;
            if (icolorslength > 0)
            {
                ColorShemeCurrent.color = new System.Drawing.Color[10];
                for (int j = 0; j < 10; j++)
                {
                    ColorShemeCurrent.color[j] = System.Drawing.ColorTranslator.FromHtml((string)drscolors[0]["Color" + j.ToString()]);
                }
            }
            else
            {
                ColorShemeCurrent.color = null;
            }
            return ColorShemeCurrent;
        }


        public static void SetDeafult()
        {
            ShemeList.SetDefault();
        }

        public static bool Load(ref string Err)
        {

            string folder = null;
            string err = null;
            if (SetApplicationDataSubFolder(ref folder, "Colors", ref err))
            {
                if (folder.Length>0)
                {
                    if (folder[folder.Length-1]!='\\')
                    {
                        folder += "\\";
                    }
                }
                string filename = folder+"Colors.xml";

                try
                {
                    dsColorSheme.ReadXml(filename);
                    SetShemeList();
                    return true;
                }
                catch (Exception ex)
                {
                    SetDeafult();
                }
                try
                {
                    dsColorSheme.WriteXml(filename);
                    return true;
                }
                catch (Exception ex)
                {
                    Err= "Can not write (dsColorSheme.WriteXml) file:\r\n" + filename + "\"!\r\n Exception = " + ex.Message;
                    return false;
                }
            }
            else
            {
                Err= "Can not Set Application Data Sub Folder!\r\nError=" + err;
                return false;
            }
        }

        public static bool Write(ref string Err)
        {

            string folder = null;
            string err = null;
            if (SetApplicationDataSubFolder(ref folder, "Colors", ref err))
            {
                if (folder.Length > 0)
                {
                    if (folder[folder.Length - 1] != '\\')
                    {
                        folder += "\\";
                    }
                }
                string filename = folder + "Colors.xml";

                try
                {
                    dsColorSheme.WriteXml(filename);
                    return true;
                }
                catch (Exception ex)
                {
                    Err = "Can not write (dsColorSheme.WriteXml) file:\r\n" + filename + "\"!\r\n Exception = " + ex.Message;
                    return false;
                }
            }
            else
            {
                Err = "Can not Set Application Data Sub Folder!\r\nError=" + err;
                return false;
            }
        }

        private static void SetShemeList()
        {
            ShemeList.SetShemeList();
        }

        private static void GrantFolderAccess(string Folder)
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
            DirectoryInfo dInfo = new DirectoryInfo(Folder);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);

        }

        private static bool SetApplicationDataSubFolder(ref string folder, string subFolder, ref string Err)
        {
            Err = null;
            string xFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + subFolder;
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

        public static void ResetSettings()
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            string folder = null;
            string err = null;
            if (SetApplicationDataSubFolder(ref folder, "Colors", ref err))
            {
                if (folder.Length > 0)
                {
                    if (folder[folder.Length - 1] != '\\')
                    {
                        folder += "\\";
                    }
                }
                string filename = folder + "Colors.xml";
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:Sheme:ResetSettings() file not deleted:\"" + filename + "\"!\r\nException = " + ex.Message);
                    }
                }
            }
        }

        internal static bool CreateSourceFile(ref string filename)
        {
            string folder = null;
            string err = null;
            if (SetApplicationDataSubFolder(ref folder, "Colors", ref err))
            {
                if (folder.Length > 0)
                {
                    if (folder[folder.Length - 1] != '\\')
                    {
                        folder += "\\";
                    }
                }
                filename = folder + "ShemeList.cs";
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:Sheme:ResetSettings() file not deleted:\"" + filename + "\"!\r\nException = " + ex.Message);
                    }
                }

                StringBuilder source = new StringBuilder(15000);
                string TopPart = @"
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSettings
{
    public static class ShemeList
    {
        public static List<ColorSheme> items = new List<ColorSheme>();

";
                source.Append(TopPart);

                DataTable dtSheme = dsColorSheme.Tables["Sheme"];
                foreach (DataRow drsheme in dtSheme.Rows)
                {
                    source.Append("\r\n      public static ColorSheme ");
                    int idsheme = (int)drsheme["ID"];
                    string name = (string)drsheme["Name"];
                    bool read_only = (bool)drsheme["ReadOnly"];
                    string sreadonly = "false";
                    if (read_only)
                    {
                        sreadonly = "true";
                    }
                    source.Append(name);
                    source.Append(" = new ColorSettings.ColorSheme(");
                    source.Append(sreadonly);
                    source.Append(", \"");
                    source.Append(name);
                    source.Append("\"");
                    source.Append(@", new System.Drawing.Color[]
        {");
                    DataTable dtColors = dsColorSheme.Tables["Colors"];
                    DataRow[] drcolors = dtColors.Select("Sheme_ID=" + idsheme.ToString());
                    int drcolorslength = drcolors.Length;
                    if (drcolorslength>0)
                    {
                        for(int j=0;j<10;j++)
                        {
                           string shtmlColor = (string) drcolors[0]["Color" + j.ToString()];
                            source.Append("\r\n    System.Drawing.ColorTranslator.FromHtml(\"");
                            source.Append(shtmlColor);
                            if (j < 9)
                            {
                                source.Append("\"),");
                            }
                            else
                            {
                                source.Append("\")");
                            }
                        }
                    }
                    source.Append("\r\n        });");
                }
                string BottomPart = @"
        internal static void SetDefault()
        {
            items.Clear();
            items.Add(Nature);
            items.Add(Techno);
            items.Add(SunSet);
            items.Add(Retro);
            items.Add(Shimmering);
            items.Add(MediterraneanDark);
            items.Add(MagentasAndYelows);
            items.Add(Custom);
            foreach (ColorSheme sheme in items)
            {
                CreateSheme(sheme, false);
            }
        }

        private static void CreateSheme(ColorSheme sheme, bool read_only)
        {
            DataTable Sheme = ColorSettings.Sheme.dsColorSheme.Tables[""Sheme""];
            DataRow drColorSheme = Sheme.NewRow();
                drColorSheme[""Name""] = sheme.Name;
                drColorSheme[""ReadOnly""] = read_only;
                int id = (int)drColorSheme[""ID""];
                Sheme.Rows.Add(drColorSheme);
                DataTable Colors = ColorSettings.Sheme.dsColorSheme.Tables[""Colors""];
                DataRow drColorValue = Colors.NewRow();
                drColorValue[""Sheme_ID""] = id;
                for (int i = 0; i < 10; i++)
                {
                    if (sheme.color.Length > i)
                    {
                        drColorValue[""Color"" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(sheme.color[i]);
                    }
                    else
                    {
                        int grv = (i * 20) % 256;
                        drColorValue[""Color"" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(grv, grv, grv));
                    }
                }
                Colors.Rows.Add(drColorValue);
            }

            internal static void SetShemeList()
            {
                items.Clear();
                DataTable dtSheme = ColorSettings.Sheme.dsColorSheme.Tables[""Sheme""];
                foreach (DataRow drsheme in dtSheme.Rows)
                {
                    string name = (string)drsheme[""Name""];
                    ColorSheme colorsheme = ColorSettings.Sheme.Get(name, true);
                    if (colorsheme != null)
                    {
                        items.Add(colorsheme);
                    }
                }
            }
        }
    }
";
                source.Append(BottomPart);

                try
                {
                    File.WriteAllText(filename, source.ToString());
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File:\"" + filename + "\" not written");
                }
                return false;
            }
            else
            {
                MessageBox.Show("Can not set SetApplicationDataSubFolder! in Sheme:CreateSourceFile(..)!");
                return false;
            }
        }
    }
}
