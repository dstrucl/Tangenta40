using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTypes
{
    public static class tf
    {
        //public static bool bShowTypeError = true;
        public static bool bShowSignedTypeError = true;

        public static bool bShowTypeError = true;

        public static void ShowSignedTypeError(string sErr)
        {
            if (bShowSignedTypeError)
            {
                LogFile.Error.Show(sErr);
            }
        }

        public static void ShowTypeError(string err_type, string target_type)
        {
            if (bShowTypeError)
            {
                LogFile.Error.Show("ERROR:DBTypes:set:type:"+ err_type+ " can not be assigned to " + target_type);
            }
        }

        public static bool_v set_bool(object p)
        {
            bool_v x = null;
            if (p == null) return null;
            if (p is bool)
            {
                x = new bool_v((bool)p);
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(), x.GetType().ToString());
            }
            return x;
        }

        public static short_v set_short(object p)
        {
            short_v x = null;
            if (p == null) return null;
            if (p is short)
            {
                x = new short_v((short)p);
            }
            else if (p.GetType() == typeof(ushort))
            {
                x = new short_v((ushort)p);
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(),x.GetType().ToString());
            }

            return x;
        }

        public static int_v set_int(object p)
        {
            int_v x = null;
            if (p == null) return null;
            if (p is int)
            {
                x = new int_v((int)p);
            }
            else if (p is uint)
            {
                x = new int_v((uint)p);
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(),x.GetType().ToString());
            }
            return x;
        }

        public static long_v set_long(object p)
        {
            long_v x = null;
            if (p == null) return null;
            if (p is long)
            {
                x = new long_v((long)p);
            }
            else if (p is ulong)
            {
                x = new long_v((ulong)p);
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(),x.GetType().ToString());
            }

            return x;
        }

        public static decimal_v set_decimal(object p)
        {
            decimal_v x = null;
            if (p == null) return null;
            if (p is decimal)
            {
                x = new decimal_v((decimal)p);
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(),x.GetType().ToString());
            }

            return x;

        }

        public static DateTime_v set_DateTime(object p)
        {
            DateTime_v x = null;
            if (p == null) return null;
            if (p.GetType() == typeof(DateTime))
            {
                x = new DateTime_v((DateTime)p);
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(), x.GetType().ToString());
            }

            return x;
        }


        public static string_v set_string(object p)
        {
            string_v x = null;
            if (p == null) return null;
            if (p is string)
            {
                x = new string_v((string)p);
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(), x.GetType().ToString());
            }
            return x;

        }

        public static string _set_string(object p)
        {
            string x = null;
            if (p == null) return null;
            if (p is string)
            {
                x = (string)p;
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(), x.GetType().ToString());
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

        public static Image _set_Image(object p)
        {
            Image x = null;
            if (p == null) return null;
            if (p is byte[])
            {
                try
                {
                    x = func.byteArrayToImage((byte[])p);
                }
                catch (Exception Ex)
                {
                    LogFile.Error.Show("ERROR:DBTypes:func:_set_Image:Exception ex = " + Ex.Message);
                    x = null;
                }
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(), x.GetType().ToString());
            }
            return x;
        }


        public static byte[] _set_byte_array(object p)
        {
            if (p == null) return null;
            if (p is byte[])
            {
                return (byte[])p;
            }
            else if (!(p is System.DBNull))
            {
                tf.ShowTypeError(p.GetType().ToString(), typeof(byte[]).ToString());
            }
            return null;
        }

        public static byte_array_v set_byte_array(object p)
        {
            byte_array_v x = null;
            if (p == null) return null;
            if (p is byte[])
            {
                x = new byte_array_v((byte[])p);
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
        public static object type_v_ret(object o)
        {
            if (o == null)
            {
                return System.DBNull.Value;
            }
            else
            {
                if (o is bool_v)
                {
                    return ((bool_v)o).v;
                }
                else if (o is short_v)
                {
                    return ((short_v)o).v;
                }
                else if (o is int_v)
                {
                    return ((int_v)o).v;
                }
                else if (o is long_v)
                {
                    return ((long_v)o).v;
                }
                else if (o is decimal_v)
                {
                    return ((decimal_v)o).v;
                }
                else if (o is DateTime_v)
                {
                    return ((DateTime_v)o).v;
                }
                else if (o is string_v)
                {
                    return ((string_v)o).v;
                }
                else if (o is byte_array_v)
                {
                    return ((byte_array_v)o).v;
                }
                else
                {
                    LogFile.Error.Show("ERROR:func:Copy:Not supported object type = " + o.GetType().ToString());
                    return null;
                }
            }
        }
    }
}
