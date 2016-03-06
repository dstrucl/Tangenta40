#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTypes
{
    public class bool_v
    {
        private bool pv = false;
        public bool v
        {
            get
            {
                return pv;
            }
            set
            {
                pv = value;
            }
        }

        public bool_v()
        {

        }
        public bool_v(bool b)
        {
            pv = b;
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
        private bool bUnsigned = false;
        private short v_;
        private ushort uv_;

        public bool Unsigned
        {
            get { return bUnsigned; }
        }


        public short v
        {
            get
            {
                if (bUnsigned)
                {
                    tf.ShowSignedTypeError("ERROR:DBTypes:func:v.get" + this.GetType().ToString() + " value is unsigned!");
                }
                return v_;
            }
            set
            {
                bUnsigned = false;
                v_ = value;
            }
        }

        public ushort uv
        {
            get
            {
                if (!bUnsigned)
                {
                    tf.ShowSignedTypeError("ERROR:DBTypes:func:" + this.GetType().ToString() + " value is signed!");
                }
                return uv_;
            }
            set
            {
                bUnsigned = true;
                uv_ = value;
            }
        }

        public short_v()
        {
        }

        public short_v(short smallint)
        {
            bUnsigned = false;
            v_ = smallint;
        }

        public short_v(ushort usmallint)
        {
            bUnsigned = true;
            uv_ = usmallint;
        }

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
            o_v.bUnsigned = this.bUnsigned;
            o_v.v = this.v_;
            o_v.uv = this.uv_;
            return o_v;
        }
    }

    public class int_v
    {
        private bool bUnsigned = false;
        private int v_;
        private uint uv_;

        public bool Unsigned
        {
            get { return bUnsigned; }
        }

        public int v
        {
            get
            {
                if (bUnsigned)
                {
                    tf.ShowSignedTypeError("ERROR:DBTypes:func:v.get" + this.GetType().ToString() + " value is unsigned!");
                }
                return v_;
            }
            set
            {
                bUnsigned = false;
                v_ = value;
            }
        }

        public uint uv
        {
            get
            {
                if (!bUnsigned)
                {
                    tf.ShowSignedTypeError("ERROR:DBTypes:func:" + this.GetType().ToString() + " value is signed!");
                }
                return uv_;
            }
            set
            {
                bUnsigned = true;
                uv_ = value;
            }
        }

        public int_v()
        {
        }

        public int_v(int i)
        {
            bUnsigned = false;
            v_ = i;
        }

        public int_v(uint ui)
        {
            bUnsigned = true;
            uv_ = ui;
        }

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
            int_v i_v = new int_v();
            i_v.bUnsigned = this.bUnsigned;
            i_v.v_ = this.v_;
            i_v.uv_ = this.uv_;
            return i_v;
        }
    }

    public class long_v
    {
        private bool bUnsigned = false;
        public long v_;
        private ulong uv_;

        public long_v()
        {
        }

        public long_v(long l)
        {
            bUnsigned = false;
            v_ = l;
        }

        public long_v(ulong ul)
        {
            bUnsigned = true;
            uv_ = ul;
        }

        public long v
        {
            get
            {
                if (bUnsigned)
                {
                    tf.ShowSignedTypeError("ERROR:DBTypes:func:v.get" + this.GetType().ToString() + " value is unsigned!");
                }
                return v_;
            }
            set
            {
                bUnsigned = false;
                v_ = value;
            }
        }

        public ulong uv
        {
            get
            {
                if (!bUnsigned)
                {
                    tf.ShowSignedTypeError("ERROR:DBTypes:func:" + this.GetType().ToString() + " value is signed!");
                }
                return uv_;
            }
            set
            {
                bUnsigned = true;
                uv_ = value;
            }
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
            l_v.bUnsigned = this.bUnsigned;
            l_v.v_ = this.v_;
            l_v.uv_ = this.uv_;
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
            get
            {
                if (v == null)
                {
                    return "";
                }
                else
                {
                    return v;
                }
            }
        }

        public string_v()
        {
        }

        public string_v(string s)
        {
            v = s;
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

        public byte_array_v()
        {
        }

        public byte_array_v(byte[] barr)
        {
            v = barr;
        }


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

            o_v.v = (byte[])this.v.Clone();
            return o_v;
        }


    }

    public class DateTime_v
    {
        public DateTime v;

        public DateTime_v()
        {
        }

        public DateTime_v(DateTime dtime)
        {
            v = dtime;
        }

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
}
