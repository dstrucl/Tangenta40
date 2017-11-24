using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginControl
{
    internal static class f
    {
        internal static int gint(object v)
        {
            if (v is int)
            {
                return (int)v;
            }
            else
            {
                return 0;
            }
        }

        internal static byte[] gbytearray(object v)
        {
            if (v is byte[])
            {
                return (byte[])v;
            }
            else
            {
                return null;
            }
        }

        internal static bool gbool(object v)
        {
            if (v is bool)
            {
                return (bool)v;
            }
            else
            {
                return false;
            }
        }

        internal static string gstring(object v)
        {
            if (v is string)
            {
                return (string)v;
            }
            else
            {
                return null;
            }
        }


        internal static long glong(object v)
        {
            if (v is long)
            {
                return (long)v;
            }
            else
            {
                return -1;
            }
        }

        internal static DateTime gDateTime(object v)
        {
            if (v is DateTime)
            {
                return (DateTime)v;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        
    }
}
