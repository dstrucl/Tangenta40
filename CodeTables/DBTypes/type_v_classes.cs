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

    public class dbool_v : bool_v
    {
        private bool m_defined = false;

        public bool defined
        {
            get {return m_defined;}
            set {m_defined = value; }
        }

        public dbool_v()
        {
        }

        public dbool_v(bool b)
        {
            v = b;
        }

        public static dbool_v Copy(dbool_v o_v)
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

        public dbool_v Clone()
        {
            dbool_v o_v = new dbool_v();
            o_v.v = this.v;
            return o_v;
        }
    }


    public class short_v
    {
        protected bool bUnsigned = false;
        protected short v_;
        protected ushort uv_;

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

    public class dshort_v:short_v
    {
        public dshort_v()
        {
        }

        public dshort_v(short smallint) : base(smallint)
        {
        }

        public dshort_v(ushort usmallint):base(usmallint)
        {
        
        }

        public static dshort_v Copy(dshort_v o_v)
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

        public dshort_v Clone()
        {
            dshort_v o_v = new dshort_v();
            
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

    public class dstring_v : string_v
    {
        private bool m_defined = false;
        public bool defined
        {
            get { return m_defined; }
            set { m_defined = false; }
        }

        public dstring_v()
        {
        }

        public dstring_v(string s)
        {
            v = s;
            m_defined = true;
        }

        public static dstring_v Copy(dstring_v o_v)
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

        public dstring_v Clone()
        {
            dstring_v o_v = new dstring_v();
            o_v.v = this.v;
            o_v.defined = this.m_defined;
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

    public class dDateTime_v: DateTime_v
    {
        private bool m_defined = false;
        public bool defined
        {
            get { return m_defined; }
            set { m_defined = false; }
        }

        public dDateTime_v()
        {
        }

        public dDateTime_v(DateTime dtime)
        {
            v = dtime;
            m_defined = true;
        }

        public static dDateTime_v Copy(dDateTime_v o_v)
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

        public dDateTime_v Clone()
        {
            dDateTime_v o_v = new dDateTime_v();
            o_v.v = this.v;
            return o_v;
        }
    }

}
