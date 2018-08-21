using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        private static string m_slng_ThisTextIsToDemostrateColorPairOnLabelForFontFamily = "This text si to demonstrate ForeColor and BackColor for font family:";

        public static string slng_ThisTextIsToDemostrateColorPairOnLabelForFontFamily
        {
            get
            {
                return m_slng_ThisTextIsToDemostrateColorPairOnLabelForFontFamily;
            }
            set
            {
                m_slng_ThisTextIsToDemostrateColorPairOnLabelForFontFamily = value;
            }
        }

        private static string m_slng_AndFontSize = " and font size = ";

        public static string slng_AndFontSize
        {
            get
            {
                return m_slng_AndFontSize;
            }
            set
            {
                m_slng_AndFontSize = value;
            }
        }

        private static string m_slng_ForeColor = "ForeColor";

        public static string slng_ForeColor
        {
            get
            {
                return m_slng_ForeColor;
            }
            set
            {
                m_slng_ForeColor = value;
            }
        }

        private static string m_slng_BackColor = "BackColor";

        public static string slng_BackColor
        {
            get
            {
                return m_slng_BackColor;
            }
            set
            {
                m_slng_BackColor = value;
            }
        }


        
        private static string m_slng_Form_ColorPicker_Caption = "Select color pair";

        public static string slng_Form_ColorPicker_Caption
        {
            get
            {
                return m_slng_Form_ColorPicker_Caption;
            }
            set
            {
                m_slng_Form_ColorPicker_Caption = value;
            }
        }

        private static string m_slng_Form_FCTB_Editor_Caption = "Default ShemeList.cs Editor";

        public static string slng_Form_FCTB_Editor_Caption
        {
            get
            {
                return m_slng_Form_FCTB_Editor_Caption;
            }
            set
            {
                m_slng_Form_FCTB_Editor_Caption = value;
            }
        }
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
                    DataRow[] drs_colorsfore = dtcolors.Select("Sheme_ID = " + idsheme.ToString()+" and Type = 'fore'");
                    int icolorsforelength = drs_colorsfore.Length;
                    DataRow[] drs_colorsback = dtcolors.Select("Sheme_ID = " + idsheme.ToString() + " and Type = 'back'");
                    int icolorsbacklength = drs_colorsback.Length;
                    if (icolorsforelength > 0)
                    {
                        if (icolorsbacklength > 0)
                        {
                            colorsheme.Colorpair = new ColorPair[ShemeList.ColorPairsCount];
                            for (int j = 0; j < ShemeList.ColorPairsCount; j++)
                            {
                                string hexcolorfore = (string)drs_colorsfore[0]["Color" + j.ToString()];
                                string hexcolorback = (string)drs_colorsback[0]["Color" + j.ToString()];
                                colorsheme.Colorpair[j] = new ColorPair(System.Drawing.ColorTranslator.FromHtml(hexcolorfore),
                                                                      System.Drawing.ColorTranslator.FromHtml(hexcolorback));
                            }
                            return colorsheme;
                        }
                        else
                        {
                            MessageBox.Show("ERROR:!(icolorsbacklength > 0) for Select(\"Sheme_ID = " + idsheme.ToString() + " and Type = 'back'\")");
                            return null;
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("ERROR:!(icolorsforelength > 0) for Select(\"Sheme_ID = " + idsheme.ToString() + " and Type = 'fore'\")");
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
                DataRow[] drcolorsfore = dtcolors.Select("Sheme_ID=" + idsheme.ToString()+" and Type='fore'");
                int drcolorsforelength = drcolorsfore.Length;
                DataRow[] drcolorsback = dtcolors.Select("Sheme_ID=" + idsheme.ToString() + " and Type='back'");
                int drcolorsbacklength = drcolorsfore.Length;
                if (drcolorsforelength>0)
                {
                    if (drcolorsbacklength > 0)
                    {
                        for (int j = 0; j < ShemeList.ColorPairsCount; j++)
                        {
                            drcolorsfore[0]["Color" + j.ToString()] = System.Drawing.ColorTranslator.ToHtml(csheme.Colorpair[j].ForeColor);
                            drcolorsback[0]["Color" + j.ToString()] = System.Drawing.ColorTranslator.ToHtml(csheme.Colorpair[j].BackColor);
                        }
                        string Err = null;
                        Write(ref Err);
                    }
                    else
                    {
                        MessageBox.Show("ERROR:!(drcolorsbacklength > 0) for Select(\"Sheme_ID = " + idsheme.ToString() + " and Type = 'back'\")");
                    }
                }
                else
                {
                        MessageBox.Show("ERROR:!(drcolorsforelength > 0) for Select(\"Sheme_ID = " + idsheme.ToString() + " and Type = 'fore'\")");
                }
            }
        }

        public static ColorSheme Current()
        {
            DataTable sheme = dsColorSheme.Tables["Sheme"];
            if (sheme != null)
            {
                int iCount = sheme.Rows.Count;
                if (iCount > 0)
                {
                    if ((Properties.Settings.Default.CurrentColorsIndex >= 0)
                        && (Properties.Settings.Default.CurrentColorsIndex < iCount))
                    {
                        DataRow drsheme = sheme.Rows[Properties.Settings.Default.CurrentColorsIndex];

                        int idsheme = (int)drsheme["ID"];
                        string shemeName = (string)drsheme["Name"];
                        bool bReadOnly = (bool)drsheme["ReadOnly"];
                        DataTable colors = dsColorSheme.Tables["Colors"];
                        DataRow[] drscolorsfore = colors.Select("Sheme_ID = " + idsheme.ToString() + " and Type='fore'");
                        DataRow[] drscolorsback = colors.Select("Sheme_ID = " + idsheme.ToString() + " and Type='back'");
                        ColorShemeCurrent.Name = shemeName;
                        ColorShemeCurrent.ReadOnly = bReadOnly;
                        int icolorsforelength = drscolorsfore.Length;
                        int icolorsbacklength = drscolorsback.Length;
                        if (icolorsforelength > 0)
                        {
                            if (icolorsbacklength > 0)
                            {
                                ColorShemeCurrent.Colorpair = new ColorPair[ShemeList.ColorPairsCount];
                                for (int j = 0; j < ShemeList.ColorPairsCount; j++)
                                {
                                    ColorShemeCurrent.Colorpair[j] = new ColorPair(ColorTranslator.FromHtml((string)drscolorsfore[0]["Color" + j.ToString()]),
                                                                                   ColorTranslator.FromHtml((string)drscolorsback[0]["Color" + j.ToString()]));
                                }
                            }
                            else
                            {
                                ColorShemeCurrent.Colorpair = null;
                                MessageBox.Show("ERROR:!(icolorsforelength > 0) for Select(\"Sheme_ID = " + idsheme.ToString() + " and Type = 'fore'\")");
                            }
                        }
                        else
                        {
                            ColorShemeCurrent.Colorpair = null;
                            MessageBox.Show("ERROR:!(icolorsforelength > 0) for Select(\"Sheme_ID = " + idsheme.ToString() + " and Type = 'fore'\")");
                        }
                        return ColorShemeCurrent;
                    }
                }
            }
            return null;
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
                catch 
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
using System.Drawing;


namespace ColorSettings
{
    public static class ShemeList
    {
		public static readonly int ColorPairsCount = 16;
		
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
                    source.Append(@", new ColorPair[]
        {");
                    DataTable dtColors = dsColorSheme.Tables["Colors"];
                    DataRow[] drcolorsfore = dtColors.Select("Sheme_ID=" + idsheme.ToString()+" and Type = 'fore'");
                    int drcolorsforelength = drcolorsfore.Length;
                    DataRow[] drcolorsback = dtColors.Select("Sheme_ID=" + idsheme.ToString() + " and Type = 'back'");
                    int drcolorsbacklength = drcolorsback.Length;
                    if (drcolorsforelength > 0)
                    {
                        if (drcolorsbacklength > 0)
                        {
                            for (int j = 0; j < ShemeList.ColorPairsCount; j++)
                            {
                                string shtmlColorfore = (string)drcolorsfore[0]["Color" + j.ToString()];
                                string shtmlColorback = (string)drcolorsback[0]["Color" + j.ToString()];

                                source.Append("\r\n new ColorPair(ColorTranslator.FromHtml(\"");
                                source.Append(shtmlColorfore);
                                source.Append("\"),\r\n                 ColorTranslator.FromHtml(\"");
                                source.Append(shtmlColorback);
                                if (j < ShemeList.ColorPairsCount-1)
                                {
                                    source.Append("\")),  // Color"+j.ToString());
                                }
                                else
                                {
                                    source.Append("\"))  // Color"+j.ToString());
                                }
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
                drColorValue[""Type""] = ""fore"";
                for (int i = 0; i < ColorPairsCount; i++)
                {
                    if (sheme.Colorpair.Length > i)
                    {
                        drColorValue[""Color"" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(sheme.Colorpair[i].ForeColor);
                    }
                    else
                    {
                        int grv = (i * 20) % 256;
                        drColorValue[""Color"" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(grv, grv, grv));
                    }
                }
                Colors.Rows.Add(drColorValue);

                drColorValue = Colors.NewRow();
                drColorValue[""Sheme_ID""] = id;
                drColorValue[""Type""] = ""back"";
                for (int i = 0; i < ColorPairsCount; i++)
                {
                    if (sheme.Colorpair.Length > i)
                    {
                        drColorValue[""Color"" + i.ToString()] = System.Drawing.ColorTranslator.ToHtml(sheme.Colorpair[i].BackColor);
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
                    MessageBox.Show("File:\"" + filename + "\" not written. Exception="+ ex.Message);
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
