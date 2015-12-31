using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace LogFile
{
    public static class Settings
    {


        public const string const_Settings_Project = "Kig_Programski_Paket";
        public const string const_Settings_Project_Version = "1.0";
        public const string const_Settings_Module = "Settings_LogFile";
        public const string const_Settings_Device = "Default";
        public const string const_Settings_Config = "Default";
        public enum eType { Properties_Settings_Default, IniFile_Settings };
        public static eType m_eType = eType.Properties_Settings_Default;



        public const string const_Section_LogFile = "LogFile";

        public static eType TYPE
        {
            get
            {
                return m_eType;
            }
            set
            {
                m_eType = value;
            }
        }



        private static object GetFrom_OtherSource(eType m_eType, string param, Type type)
        {
            object o = new object();
            switch (m_eType)
            {

                case eType.IniFile_Settings:
                    if (type == typeof(string))
                    {
                        return (string)Settings_List.Get(param);
                    }
                    else if (type == typeof(int))
                    {
                        return (int)Settings_List.Get(param);
                    }
                    else
                    {
                        MessageBox.Show("ERROR:LogFile:Settings." + param + ":type = "+type.ToString()+" not implemented !");
                        return null;
                    }

                default:
                    MessageBox.Show("ERROR:LogFile.Settings." + param + ":get m_eType not implemented !");
                    if (type == typeof(int))
                    {
                        o = (int)0;
                    }
                    else if (type == typeof(long))
                    {
                        o = (long)0;

                    }
                    else if (type == typeof(decimal))
                    {
                        o = (decimal)0;

                    }
                    else if (type == typeof(float))
                    {
                        o = (float)0;

                    }
                    else if (type == typeof(short))
                    {
                        o = (short)0;

                    }
                    else if (type == typeof(uint))
                    {
                        o = (uint)0;

                    }
                    else if (type == typeof(bool))
                    {
                        o = (bool)false;

                    }
                    else if (type == typeof(DateTime))
                    {
                        o = DateTime.MinValue;
                    }
                    else if (type == typeof(System.Drawing.Color))
                    {
                        o = System.Drawing.Color.Black;
                    }
                    else
                    {
                        return null;
                    }
                    return o;
            }
        }

        private static void SetInto_OtherSource(string param, object value)
        {
            switch (m_eType)
            {
                case eType.IniFile_Settings:
                    Settings_List.Set(param, value);
                    break;

                default:
                    MessageBox.Show("ERROR:LogFile.Settings.SetInto_OtherSource: m_eType not implemented!");
                    break;

            }
        }


        public static int LogLevel
        {
            get
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        return Settings.LogLevel;
                    default:
                        return (int)GetFrom_OtherSource(m_eType, Settings_List.pconst_LogLevel, typeof(int));
                }


            }
            set
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        Settings.LogLevel = value;
                        break;
                    default:
                        SetInto_OtherSource(Settings_List.pconst_LogLevel, value);
                        break;
                }
            }
        }

        public static string LogFile
        {
            get
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        return Settings.LogFile;
                    default:
                        return (string)GetFrom_OtherSource(m_eType, Settings_List.pconst_LogFile, typeof(string));
                }


            }
            set
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        Settings.LogFile = value;
                        break;
                    default:
                        SetInto_OtherSource(Settings_List.pconst_LogFile, value);
                        break;
                }
            }
        }

        public static string LogFolder
        {
            get
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        return Settings.LogFolder;
                    default:
                        return (string)GetFrom_OtherSource(m_eType, Settings_List.pconst_LogFolder, typeof(string));
                }


            }
            set
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        Settings.LogFolder = value;
                        break;
                    default:
                        SetInto_OtherSource(Settings_List.pconst_LogFolder, value);
                        break;
                }
            }
        }

        public static int MutexTimeout
        {
            get
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        return Settings.MutexTimeout;
                    default:
                        return (int)GetFrom_OtherSource(m_eType, Settings_List.pconst_MutexTimeout, typeof(int));
                }


            }
            set
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        Settings.MutexTimeout = value;
                        break;
                    default:
                        SetInto_OtherSource(Settings_List.pconst_MutexTimeout, value);
                        break;
                }
            }
        }

        public static int Log2DB_flags
        {
            get
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        return Settings.Log2DB_flags;
                    default:
                        return (int)GetFrom_OtherSource(m_eType, Settings_List.pconst_Log2DB, typeof(int));
                }


            }
            set
            {
                switch (m_eType)
                {
                    case eType.Properties_Settings_Default:
                        Settings.Log2DB_flags = value;
                        break;
                    default:
                        SetInto_OtherSource(Settings_List.pconst_Log2DB, value);
                        break;
                }
            }
        }




        public static void Save()
        {
            Settings_List.Save();
        }

        public static void Reset()
        {
            throw new NotImplementedException();
        }

        public static bool IniDataExsits(string IniFilePath)
        {
            if (File.Exists(IniFilePath))
            {
                string sIni = File.ReadAllText(IniFilePath);
                if (sIni.IndexOf(Settings_List.pconst_LogFile) > 0)
                {
                    if (sIni.IndexOf(Settings_List.pconst_LogFolder) > 0)
                    {
                        if (sIni.IndexOf(Settings_List.pconst_LogLevel) > 0)
                        {
                            if (sIni.IndexOf(Settings_List.pconst_MutexTimeout) > 0)
                            {
                                if (sIni.IndexOf(Settings_List.pconst_Log2DB) > 0)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool Load(string IniFilePath, ref string Err)
        {
            Settings_List.Init();
            Settings_List.Init_Default();
            IniFile.IniFile.path = IniFilePath;
            if (!IniDataExsits(IniFilePath))
            {
                Settings_List.CreateDefaultFile();
            }
            if (Settings_List.Load(ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public static class Settings_List
    {
        public static List<Settings_Item> Items = null;

        public const string pconst_LogLevel = "LogLevel";
        public const string pconst_LogFile = "LogFile";
        public const string pconst_LogFolder = "LogFolder";
        public const string pconst_MutexTimeout = "MutexTimeout";
        public const string pconst_Log2DB= "Log2DB_flags";

        public static void Init()
        {
            Items = new List<Settings_Item>();
            Items.Add(new Settings_Item(typeof(int), pconst_LogLevel));
            Items.Add(new Settings_Item(typeof(string), pconst_LogFile));
            Items.Add(new Settings_Item(typeof(string), pconst_LogFolder));
            Items.Add(new Settings_Item(typeof(int), pconst_MutexTimeout));
            Items.Add(new Settings_Item(typeof(int), pconst_Log2DB));
        }

        private static void SetItem(string ItemName, object Value)
        {
            Settings_Item item = (Settings_Item)Items.Find(x => x.Name.Equals(ItemName));
            if (item != null)
            {
                if (Value.GetType() == typeof(System.Drawing.Color))
                {
                    System.Drawing.Color col = (System.Drawing.Color)Value;
                    item.Value = col.ToArgb();
                }
                else
                {
                    item.Value = Value;
                }
            }
            else
            {
                MessageBox.Show("ERROR:Settings.SetItem:ItemName='" + ItemName + "' not fund in List<Settings_Item> Items !");
            }
        }

        private static void SetItemDefault(string ItemName, object Value, Type type)
        {
            Settings_Item item = (Settings_Item)Items.Find(x => x.Name.Equals(ItemName));
            if (item != null)
            {
                if (type == typeof(System.Drawing.Color))
                {
                    if (Value.GetType() == typeof(int))
                    {
                        System.Drawing.Color col = Color.FromArgb((int)Value);
                        item.Value = col.ToArgb();
                    }
                    else
                    {
                        System.Drawing.Color col = (System.Drawing.Color)Value;
                        item.Value = col.ToArgb();
                    }
                }
                else if (type == typeof(DateTime))
                {
                    if (Value.GetType() == typeof(string))
                    {
                        DateTime dt = Convert.ToDateTime((string)Value);
                        item.Value = dt;
                    }
                    else
                    {
                        item.Value = (DateTime)Value;
                    }
                }
                else
                {
                    item.Value = Value;
                }
            }
            else
            {
                MessageBox.Show("ERROR:Settings.SetItem2:ItemName='" + ItemName + "' not fund in List<Settings_Item> Items !");
            }
        }


        public static void InitFrom_Properties_Settings_Default()
        {

            SetItem(pconst_LogLevel, Settings.LogLevel);
            SetItem(pconst_LogFile, Settings.LogFile);
            SetItem(pconst_LogFolder, Settings.LogFolder);
            SetItem(pconst_MutexTimeout, Settings.MutexTimeout);
            SetItem(pconst_Log2DB, Settings.Log2DB_flags);

        }

        public static void Init_Default()
        {
            SetItemDefault(pconst_LogLevel,0,typeof(int));
            SetItemDefault(pconst_LogFile,"log.txt",typeof(string));
            SetItemDefault(pconst_LogFolder,"C:\\",typeof(int));
            SetItemDefault(pconst_MutexTimeout,2000,typeof(int));
            SetItemDefault(pconst_Log2DB, 0, typeof(int));
        }

        public static bool Load(ref string Err)
        {
            foreach (Settings_Item item in Items)
            {
                string sValue = null;
                if (IniFile.IniFile.IniReadValue(Settings.const_Section_LogFile, item.Name, ref sValue, ref Err))
                {
                    if (item.TYPE == typeof(string))
                    {
                        item.Value = sValue;
                    }
                    else if (item.TYPE == typeof(int))
                    {
                        try
                        {
                            item.Value = Convert.ToInt32(sValue);
                        }
                        catch (Exception ex)
                        {
                            string serr = "ERROR:Settings_List:Load:item.TYPE = " + item.TYPE.ToString() + " Convert To Int32 failed! Exception = " + ex.Message;
                            Err = serr;
                            MessageBox.Show(serr);
                            return false;
                        }
                    }
                    else
                    {
                        string serr = "ERROR:Settings_List:Load:item.TYPE = " + item.TYPE.ToString() + " not implemenmted!";
                        Err = serr;
                        MessageBox.Show(serr);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(Err);
                    return false;
                }
            }
            return true;
        }

        public static bool Save()
        {
            foreach (Settings_Item item in Items)
            {
                string sValue = "";
                try
                {
                   sValue = Convert.ToString(item.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:Settings_List:Save:item.TYPE = " + item.TYPE.ToString() + " Convert ToString failed! Exception = " + ex.Message);
                    return false;
                }
                try
                {
                    string Err = null;
                    if (!IniFile.IniFile.IniWriteValue(Settings.const_Section_LogFile, item.Name, sValue, ref Err))
                    {
                        MessageBox.Show(Err);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:Settings_List:Save:item.TYPE = " + item.TYPE.ToString() + " IniWriteValue Exception="+ex.Message);
                    return false;
                }
            }
            return true;
        }



        internal static object Get(string param)
        {
            Settings_Item item = (Settings_Item)Items.Find(x => x.Name.Equals(param));
            if (item != null)
            {
                return item.Value;
            }
            else
            {
                MessageBox.Show("ERROR:Settings.Get:ItemName='" + param + "' not fund in List<Settings_Item> Items !");
                return null;
            }
        }

        internal static void Set(string param,object value)
        {
            Settings_Item item = (Settings_Item)Items.Find(x => x.Name.Equals(param));
            if (item != null)
            {
                item.Value = value;
            }
            else
            {
                MessageBox.Show("ERROR:Settings.Set:ItemName='" + param + "' not fund in List<Settings_Item> Items !");
            }
        }



        internal static void CreateDefaultFile()
        {
            Save();
        }
    }

    public class Settings_Item
    {
        private string m_Name;
        private object o_Value = null;
        private Type m_type;

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public object Value
        {
            get
            {
                return o_Value;
            }
            set
            {
                o_Value = value;
            }
        }

        public Type TYPE
        {
            get
            {
                return m_type;
            }
            set
            {
                m_type = value;
            }
        }

        public Settings_Item(Type xtype, string xName)
        {
            m_Name = xName;
            m_type = xtype;
        }

        public Settings_Item(Type xtype, string xName, object oValue)
        {
            m_Name = xName;
            m_type = xtype;
            Value = oValue;
        }

    }

}


