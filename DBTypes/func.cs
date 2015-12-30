using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace DBTypes
{
    public class bool_v
    {
        private bool pv = false;
        public bool v
        {
            get {
                return pv; 
                }
            set { 
                pv = value; 
                }
        }

        public static bool_v Copy(bool_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }

        public bool_v Clone()
        {
            bool_v o_v = new bool_v();
            o_v.v = this.v;
            return o_v;
        }
    }

    public class short_v
    {
        public short v;

        public static short_v Copy(short_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }

        public short_v Clone()
        {
            short_v o_v = new short_v();
            o_v.v = this.v;
            return o_v;
        }
    }

    public class int_v
    {
        public int v;

        public static int_v Copy(int_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }


        public int_v Clone()
        {
            int_v o_v = new int_v();
            o_v.v = this.v;
            return o_v;
        }
    }

    public class long_v
    {
        public long v;

        public long_v()
        {
        }

        public long_v(long l)
        {
            v = l;
        }
        public static long_v Copy(long_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }

        public long_v Clone()
        {
            long_v l_v = new long_v();
            l_v.v = this.v;
            return l_v;
        }
    }

    public class decimal_v
    {
        public decimal v;

        public decimal_v()
        {
        }

        public decimal_v(decimal d)
        {
            v = d;
        }


        public static decimal_v Copy(decimal_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }


        public decimal_v Clone()
        {
            decimal_v o_v = new decimal_v();
            o_v.v = this.v;
            return o_v;
        }
    }

    public class string_v
    {
        public string v;

        public string vs
        {
            get {
                    if (v==null)
                    {
                        return "";
                    }
                    else
                    {
                        return v;
                    }
                }
        }

        public string_v(string s)
        {
            v = s;
        }

        public string_v()
        {
        }

        public static string_v Copy(string_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }

        public string_v Clone()
        {
            string_v o_v = new string_v();
            o_v.v = this.v;
            return o_v;
        }
    }

    public class byte_array_v
    {
        public byte[] v;

        public static byte_array_v Copy(byte_array_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }

        public byte_array_v Clone()
        {
            byte_array_v o_v = new byte_array_v();
            
            o_v.v =(byte[]) this.v.Clone();
            return o_v;
        }


    }

    public class DateTime_v
    {
        public DateTime v;

        public static DateTime_v Copy(DateTime_v o_v)
        {
            if (o_v != null)
            {
                return o_v.Clone();
            }
            else
            {
                return null;
            }
        }

        public DateTime_v Clone()
        {
            DateTime_v o_v = new DateTime_v();
            o_v.v = this.v;
            return o_v;
        }
    }

    public static class func
    {

        public static bool_v set_bool(object p)
        {
            bool_v x = null;
            if (p.GetType() == typeof(bool))
            {
                x = new bool_v();
                x.v = (bool)p;
            }
            return x;
        }

        public static short_v set_short(object p)
        {
            short_v x = null;
            if (p.GetType() == typeof(short))
            {
                x = new short_v();
                x.v = (short)p;
            }
            return x;
        }

        public static int_v set_int(object p)
        {
            int_v x = null;
            if (p.GetType() == typeof(int))
            {
                x = new int_v();
                x.v = (int)p;
            }
            return x;
        }

        public static long_v set_long(object p)
        {
            long_v x = null;
            if (p.GetType() == typeof(long))
            {
                x = new long_v();
                x.v = (long)p;
            }
            return x;
        }

        public static decimal_v set_decimal(object p)
        {
            decimal_v x = null;
            if (p.GetType() == typeof(decimal))
            {
                x = new decimal_v();
                x.v = (decimal)p;
            }
            return x;

        }

        public static DateTime_v set_DateTime(object p)
        {
            DateTime_v x = null;
            if (p.GetType() == typeof(DateTime))
            {
                x = new DateTime_v();
                x.v = (DateTime)p;
            }
            return x;
        }


        public static string_v set_string(object p)
        {
            string_v x = null;
            if (p.GetType() == typeof(string))
            {
                x = new string_v();
                x.v = (string)p;
            }
            return x;
            
        }

        public static string _set_string(object p)
        {
            string x = null;
            if (p is string)
            {
                x = (string)p;
            }
            return x;
        }

        public static DateTime _set_DateTime(object p)
        {
            
            if (p is DateTime)
            {
                return (DateTime)p;
            }
            return DateTime.MinValue;
        }

        public static bool _set_bool(object p)
        {
            if (p is bool)
            {
                return (bool)p;
            }
            return false;
        }

        public static decimal _set_decimal(object p)
        {
            decimal x = -1;
            if (p is decimal)
            {
                x = (decimal)p;
            }
            return x;
        }

        public static int _set_int(object p)
        {
            int x = -1;
            if (p is int)
            {
                x = (int)p;
            }
            return x;
        }

        public static long _set_long(object p)
        {
            if (p is long)
            {
                return (long)p;
            }
            return -1;
        }


        public static byte[] _set_byte_array(object p)
        {
            if (p is byte[])
            {
                return (byte[])p;
            }
            return null;
        }

        public static Image _set_Image(object p)
        {
            Image x = null;
            if (p is byte[])
            {
                try
                {
                    x = byteArrayToImage((byte[])p);
                }
                catch (Exception Ex)
                {
                    LogFile.Error.Show("ERROR:DBTypes:func:_set_Image:Exception ex = "+Ex.Message);
                    x = null;
                }
            }
            return x;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        public static byte_array_v set_byte_array(object p)
        {
            byte_array_v x = null;
            if (p.GetType() == typeof(byte[]))
            {
                x = new byte_array_v();
                x.v = (byte[])p;
            }
            return x;
        }


        public static object Copy(object o)
        {
            if (o == null)
            {
                return null;
            }
            else
            {
                if (o is bool_v)
                {
                    return ((bool_v)o).Clone();
                }
                else if (o is short_v)
                {
                    return ((short_v)o).Clone();
                }
                else if (o is int_v)
                {
                    return ((int_v)o).Clone();
                }
                else if (o is long_v)
                {
                    return ((long_v)o).Clone();
                }
                else if (o is decimal_v)
                {
                    return ((decimal_v)o).Clone();
                }
                else if (o is DateTime_v)
                {
                    return ((DateTime_v)o).Clone();
                }
                else if (o is string_v)
                {
                    return ((string_v)o).Clone();
                }
                else if (o is byte_array_v)
                {
                    return ((byte_array_v)o).Clone();
                }
                else
                {
                    LogFile.Error.Show("ERROR:func:Copy:Not supported object type = " + o.GetType().ToString());
                    return null;
                }
            }
        }

        public static string GenderAsString(bool gender)
        {
            if (gender)
            {
                return LanguageControl.lngRPM.s_Man.s;
            }
            else
            {
                return LanguageControl.lngRPM.s_Woman.s;
            }
        }

        public static string int_to_string(int i, int len)
        {
            string s;
            s = i.ToString();
            while (s.Length < len)
            {
                s = '0' + s;
            }
            return s;
        }

        public static string Get_DATE_dd_mm_yyyy(DateTime xdate)
        {
            return int_to_string(xdate.Day, 2) + "." + int_to_string(xdate.Month, 2) + "." + int_to_string(xdate.Year,4);
        }
    }
}
