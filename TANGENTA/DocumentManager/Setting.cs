using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManager
{
    public class Setting
    {
        private string m_Name = null;
        private ID m_PropertiesSettings_ID = null;

        public ID PropertiesSettings_ID
        {
            get
            {
                return m_PropertiesSettings_ID;
            }
            set
            {
                m_PropertiesSettings_ID = value;
            }
        }


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

        private string m_value = null;
        public string Value
        {
            get
            {
                return m_value;
            }
        }

        private Type m_type = null;
        public Type Type
        {
            get
            {
                return m_type;
            }
        }

        public Setting(string xname)
        {
            m_Name = xname;
        }

        public bool Set(string xname, string xtype, string xval)
        {
            if (m_Name.Equals(xname))
            {
                m_type = parsetype(xtype);
                m_value = xval;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Type parsetype(string xtype)
        {
            if (xtype.Equals(typeof(int).ToString()))
            {
                return typeof(int);
            }
            else if (xtype.Equals(typeof(bool).ToString()))
            {
                return typeof(bool);
            }
            else if (xtype.Equals(typeof(string).ToString()))
            {
                return typeof(string);
            }
            else if (xtype.Equals(typeof(System.Drawing.Color).ToString()))
            {
                return typeof(System.Drawing.Color);
            }
            else
            {
                LogFile.Error.Show("ERROR:Tangenta:Settings:parsetype:xtype not implemented xtype=" + xtype);
                return null;
            }
        }

        internal object get_object()
        {
            try
            {
                if (Type.Equals(typeof(int)))
                {
                    return Convert.ToInt32(Value);
                }
                else if (Type.Equals(typeof(bool)))
                {
                    return Convert.ToBoolean(Value);
                }
                else if (Type.Equals(typeof(string)))
                {
                    return Value;
                }
                else if (Type.Equals(typeof(System.Drawing.Color)))
                {
                    int idx = Value.IndexOf(';');
                    if (idx >= 0)
                    {
                        string[] s = Value.Split(new char[] { ';' });
                        int red = Convert.ToInt32(s[0]);
                        int green = Convert.ToInt32(s[1]);
                        int blue = Convert.ToInt32(s[2]);
                        System.Drawing.Color color = System.Drawing.Color.FromArgb(red, green, blue);
                        return color;
                    }
                    else
                    {
                        System.Drawing.Color color = System.Drawing.Color.FromName(Value);
                        return color;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Tangenta:Settings:get_object:xtype not implemented xtype=" + Type.ToString());
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFile.Error.Show("ERROR:Tangenta:Settings:get_object:Conversion error :"+ex.Message+"\r\n for property name =" + Name);
                return null;
            }
        }
    }
}
