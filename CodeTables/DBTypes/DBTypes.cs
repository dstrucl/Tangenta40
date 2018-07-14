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
using System.Reflection;
using LanguageControl;
using LogFile;
using System.IO;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using DBConnectionControl40;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace DBTypes
{
    public class SqlPar
    {
        public string cond;
        public string value;
        public void setsqlp(object type_v, ref List<SQL_Parameter> lpar, string column_name, ref string xcond, ref string xvalue)
        {
            string spar_name = null;
            SQL_Parameter par = null;
            spar_name = "@par_" + column_name;
            if (type_v == null)
            {
                cond = " " + column_name + " is null ";
                value = " null ";
                xcond = cond;
                xvalue = value;
            }
            else
            {
                if (type_v is bool_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Bit, false, ((bool_v)type_v).v);
                }
                else if (type_v is short_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Smallint, false, ((short_v)type_v).v);
                }
                else if (type_v is int_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Int, false, ((int_v)type_v).v);
                }
                else if (type_v is long_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Bigint, false, ((long_v)type_v).v);
                }
                else if (type_v is decimal_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Decimal, false, ((decimal_v)type_v).v);
                }
                else if (type_v is string_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, ((string_v)type_v).v);
                }
                else if (type_v is byte_array_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Varbinary, false, ((byte_array_v)type_v).v);
                }
                else if (type_v is DateTime_v)
                {
                    par = new SQL_Parameter(spar_name, SQL_Parameter.eSQL_Parameter.Datetime, false, ((DateTime_v)type_v).v);
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBTypes:SqlPar:setsqlp:unsuported type=" + type_v.GetType().ToString());
                    return;
                }
                cond = " " + column_name + " = " + spar_name + " ";
                value = spar_name;
                xcond = cond;
                xvalue = value;
                lpar.Add(par);
            }
        }
    }
    public class ValSet : SqlPar
    {
        public bool defined = false;
    }


    public class DB_Int64 : ValSet
    {
        private long m_val = 0;


        public long val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }

        public long_v type_v = null;

        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }


        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is long)
            {
                this.type_v = new long_v((long)o);
            }
            else if (o is ulong)
            {
                this.type_v = new long_v((ulong)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_Int32 : ValSet
    {
        private int m_val = 0;
        public int val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }

        public int_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is int)
            {
                this.type_v = new int_v((int)o);
            }
            else if (o is uint)
            {
                this.type_v = new int_v((uint)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }

        }
    }

    public class DB_varchar_max : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }

        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varchar_2000 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;

            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }

        }
    }

    public class DB_varchar_264 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }
    }

    public class DB_varchar_250 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varchar_50 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varchar_64 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }

        }

    }

    public class DB_varchar_45 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varchar_32 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varchar_25 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varchar_10 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varchar_5 : ValSet
    {
        private string m_val = "";
        public string val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public string_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is string)
            {
                this.type_v = new string_v((string)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }


    public class DB_DateTime : ValSet
    {
        private DateTime m_val = DateTime.MinValue;
        public DateTime val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public DateTime_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is DateTime)
            {
                this.type_v = new DateTime_v((DateTime)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_smallInt : ValSet
    {
        private short m_val = 0;
        public short val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }

        public short_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is short)
            {
                this.type_v = new short_v((short)o);
            }
            else if (o is ushort)
            {
                this.type_v = new short_v((ushort)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_bit : ValSet
    {
        private bool m_val = false;
        public bool val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public bool_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is bool)
            {
                this.type_v = new bool_v((bool)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_varbinary_max : ValSet
    {
        private Byte[] m_val = new Byte[1] { 0 };
        public Byte[] val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public byte_array_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is byte[])
            {
                this.type_v = new byte_array_v((byte[])o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }

        }

    }

    public class DB_Money : ValSet
    {
        private decimal m_val = new decimal();
        public decimal val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public decimal_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is decimal)
            {
                this.type_v = new decimal_v((decimal)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }

        }

    }

    public class DB_decimal2 : ValSet
    {
        private decimal m_val = new decimal();
        public decimal val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public decimal_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is decimal)
            {
                this.type_v = new decimal_v((decimal)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_Percent : ValSet
    {
        private decimal m_val = new decimal();
        public decimal val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public decimal_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is decimal)
            {
                this.type_v = new decimal_v((decimal)o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }

    }

    public class DB_Document : ValSet
    {
        private Byte[] m_val = new Byte[1] { 0 };
        public Byte[] val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public byte_array_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is byte[])
            {
                this.type_v = new byte_array_v((byte[])o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }
    }

    public class DB_Image : ValSet
    {
        private Byte[] m_val = new Byte[1] { 0 };
        public Byte[] val
        {
            get { return m_val; }

            set
            {
                m_val = value;
                this.defined = true;
            }
        }
        public byte_array_v type_v = null;
        public void setsqlp(ref List<SQL_Parameter> lpar, string column_name, ref string cond, ref string value)
        {
            setsqlp(type_v, ref lpar, column_name, ref cond, ref value);
        }

        public void set(object o)
        {
            this.type_v = null;
            if (o == null) return;
            if (o is byte[])
            {
                this.type_v = new byte_array_v((byte[])o);
            }
            else if (o is System.DBNull)
            {
                return;
            }
            else
            {
                LogFile.Error.Show("ERROR:DB_Types:set:WRONG TYPE:" + o.GetType().ToString() + " should be " + this.GetType().ToString());
            }
        }
    }






    public class DBtypes
    {
        public DB_Int32 DB_Int32 = new DB_Int32();
        public DB_Int64 DB_Int64 = new DB_Int64();
        public DB_varchar_max DB_varchar_max = new DB_varchar_max();
        public DB_varchar_2000 DB_varchar_2000 = new DB_varchar_2000();
        public DB_varchar_264 DB_varchar_264 = new DB_varchar_264();
        public DB_varchar_250 DB_varchar_250 = new DB_varchar_250();
        public DB_varchar_64 DB_varchar_64 = new DB_varchar_64();
        public DB_varchar_50 DB_varchar_50 = new DB_varchar_50();
        public DB_varchar_45 DB_varchar_45 = new DB_varchar_45();
        public DB_varchar_32 DB_varchar_32 = new DB_varchar_32();
        public DB_varchar_25 DB_varchar_25 = new DB_varchar_25();
        public DB_varchar_10 DB_varchar_10 = new DB_varchar_10();
        public DB_varchar_5 DB_varchar_5 = new DB_varchar_5();
        public DB_DateTime DB_DateTime = new DB_DateTime();
        public DB_smallInt DB_smallInt = new DB_smallInt();
        public DB_bit DB_bit = new DB_bit();
        public DB_varbinary_max DB_varbinary_max = new DB_varbinary_max();
        public DB_Money DB_Money = new DB_Money();
        public DB_decimal2 DB_decimal = new DB_decimal2();
        public DB_Percent DB_Percent = new DB_Percent();
        public DB_Document DB_Document = new DB_Document();
        public DB_Image DB_Image = new DB_Image();
    }

    public class DBm_col_name_and_param
    {
        public string col_name;
        public string Par_col_name;

        public DBm_col_name_and_param(string x_col_name, string x_Par_col_name)
        {
            // TODO: Complete member initialization
            this.col_name = x_col_name;
            this.Par_col_name = x_Par_col_name;
        }
    }


    public static class DBtypesFunc
    {

        public const string ImageStoreName = "Func.ImageStore";
        public static ImageStore ImageStore = new ImageStore();
        public static DataStore DataStore = new DataStore();
        public static DocumentStore DocumentStore = new DocumentStore();

        
        private static SHA1CryptoServiceProvider my_SHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();

        public static string GetHash_SHA1(byte[] byteArray)
        {
            string hash = "";
            hash = Convert.ToBase64String(my_SHA1CryptoServiceProvider.ComputeHash(byteArray));
            return hash;
        }


        public static string GetBasicTypeMSSQL(object obj)
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            Type baseType = objType.BaseType;
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (baseType != null)
            {
                FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
                int i;
                int iCount = DBTypesInfo.Count();
                for (i = 0; i < iCount; i++)
                {
                    if (DBTypesInfo[i].FieldType == baseType)
                    {
                        if (baseType == typeof(DB_Int32))
                        {
                            return "[int]";
                        }
                        else if (baseType == typeof(DB_Int64))
                        {
                            return "[bigint]";
                        }
                        else if (baseType == typeof(DB_Money))
                        {
                            return "[money]";
                        }
                        else if (baseType == typeof(DB_decimal2))
                        {
                            return "[decimal](18,5)";
                        }
                        else if (baseType == typeof(DB_Percent))
                        {
                            return "[decimal](18,5)";
                        }
                        else if (baseType == typeof(DB_smallInt))
                        {
                            return "[int]";
                        }
                        else if (baseType == typeof(DB_bit))
                        {
                            return "[bit]";
                        }
                        else if (baseType == typeof(DB_DateTime))
                        {
                            return "[datetime]";
                        }
                        else if (baseType == typeof(DBTypes.DB_varbinary_max))
                        {
                            return "[varbinary](MAX)";
                        }
                        else if (baseType == typeof(DB_varchar_max))
                        {
                            return "[nvarchar](MAX)";
                        }
                        else if (baseType == typeof(DB_varchar_2000))
                        {
                            return "[nvarchar](2000)";
                        }
                        else if (baseType == typeof(DB_varchar_264))
                        {
                            return "[nvarchar](264)";
                        }
                        else if (baseType == typeof(DB_varchar_250))
                        {
                            return "[nvarchar](250)";
                        }
                        else if (baseType == typeof(DB_varchar_64))
                        {
                            return "[nvarchar](64)";
                        }
                        else if (baseType == typeof(DB_varchar_50))
                        {
                            return "[nvarchar](50)";
                        }
                        else if (baseType == typeof(DB_varchar_45))
                        {
                            return "[nvarchar](45)";
                        }
                        else if (baseType == typeof(DB_varchar_32))
                        {
                            return "[nvarchar](32)";
                        }
                        else if (baseType == typeof(DB_varchar_25))
                        {
                            return "[nvarchar](25)";
                        }
                        else if (baseType == typeof(DB_varchar_10))
                        {
                            return "[nvarchar](10)";
                        }
                        else if (baseType == typeof(DB_varchar_5))
                        {
                            return "[nvarchar](5)";
                        }
                        else if (baseType == typeof(DB_Image))
                        {
                            return "[varbinary](MAX)";
                        }
                        else if (baseType == typeof(DB_Document))
                        {
                            return "[varbinary](MAX)";
                        }
                        else
                        {
                            return "!! NOT BASIC TYPE !!";
                        }
                    }
                }
                string tableName = objType.ToString();
                int ij = tableName.IndexOf('.');
                if (ij >= 0)
                {
                    tableName = tableName.Substring(ij + 1);
                }

                string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
                Error.Show(csError, "Program Error!");
                return csError;
            }
            else
            {
                return "ERROR !!! NO base Type !!!";
            }
        }

        public static bool IsBasicType(object obj)
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            Type baseType = objType.BaseType;
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (baseType != null)
            {
                FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
                int i;
                int iCount = DBTypesInfo.Count();
                for (i = 0; i < iCount; i++)
                {
                    if (DBTypesInfo[i].FieldType == baseType)
                    {
                        if (baseType == typeof(DB_Int32))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_Int64))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_Money))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_decimal2))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_Percent))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_smallInt))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_bit))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_DateTime))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DBTypes.DB_varbinary_max))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_max))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_2000))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_264))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_250))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_64))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_50))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_45))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_32))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_25))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_10))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_varchar_5))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_Image))
                        {
                            return true;
                        }
                        else if (baseType == typeof(DB_Document))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
                //string tableName = objType.ToString();
                //int ij = tableName.IndexOf('.');
                //if (ij >= 0)
                //{
                //    tableName = tableName.Substring(ij + 1);
                //}

                //string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
                //Error.Show(csError, "Program Error!");
                //return false;
            }
            else
            {
                //string csError = "ERROR !!! NO base Type !!!";
                //Error.Show(csError, "Program Error!");
                return false;
            }
        }

        public static int GetBasicTypeLengthMySQL(object obj)
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            Type baseType = objType.BaseType;
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (baseType != null)
            {
                FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
                int i;
                int iCount = DBTypesInfo.Count();
                for (i = 0; i < iCount; i++)
                {
                    if (DBTypesInfo[i].FieldType == baseType)
                    {
                        if (baseType == typeof(DB_Int32))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DB_Int64))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DB_Money))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DB_decimal2))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DB_Percent))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DB_smallInt))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DB_bit))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DB_DateTime))
                        {
                            return -1;
                        }
                        else if (baseType == typeof(DBTypes.DB_varbinary_max))
                        {
                            return 200;
                        }
                        else if (baseType == typeof(DB_varchar_max))
                        {
                            return 200;
                        }
                        else if (baseType == typeof(DB_varchar_2000))
                        {
                            return 200;
                        }
                        else if (baseType == typeof(DB_varchar_264))
                        {
                            return 200;
                        }
                        else if (baseType == typeof(DB_varchar_250))
                        {
                            return 250;
                        }
                        else if (baseType == typeof(DB_varchar_64))
                        {
                            return 64;
                        }
                        else if (baseType == typeof(DB_varchar_50))
                        {
                            return 50;
                        }
                        else if (baseType == typeof(DB_varchar_45))
                        {
                            return 45;
                        }
                        else if (baseType == typeof(DB_varchar_32))
                        {
                            return 32;
                        }
                        else if (baseType == typeof(DB_varchar_25))
                        {
                            return 25;
                        }
                        else if (baseType == typeof(DB_varchar_10))
                        {
                            return 10;
                        }
                        else if (baseType == typeof(DB_varchar_5))
                        {
                            return 5;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                //string tableName = objType.ToString();
                //int ij = tableName.IndexOf('.');
                //if (ij >= 0)
                //{
                //    tableName = tableName.Substring(ij + 1);
                //}

                //string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
                //Error.Show(csError, "Program Error!");
                return -1;
            }
            else
            {
                return -1;
            }
        }

        public static string GetBasicTypeMySQL(object obj)
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            Type baseType = objType.BaseType;
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (baseType != null)
            {
                FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
                int i;
                int iCount = DBTypesInfo.Count();
                for (i = 0; i < iCount; i++)
                {
                    if (DBTypesInfo[i].FieldType == baseType)
                    {
                        if (baseType == typeof(DB_Int32))
                        {
                            return "int(11)";
                        }
                        else if (baseType == typeof(DB_Int64))
                        {
                            return "bigint(20)";
                        }
                        else if (baseType == typeof(DB_Money))
                        {
                            return "DECIMAL(18,5)";
                        }
                        else if (baseType == typeof(DB_decimal2))
                        {
                            return "DECIMAL(18,5)";
                        }
                        else if (baseType == typeof(DB_Percent))
                        {
                            return "DECIMAL(18,5)";
                        }
                        else if (baseType == typeof(DB_smallInt))
                        {
                            return "smallint(6)";
                        }
                        else if (baseType == typeof(DB_bit))
                        {
                            return "tinyint(1)";
                        }
                        else if (baseType == typeof(DB_DateTime))
                        {
                            return "datetime";
                        }
                        else if (baseType == typeof(DBTypes.DB_varbinary_max))
                        {
                            return "LONGBLOB";
                        }
                        else if (baseType == typeof(DB_varchar_max))
                        {
                            return "varchar(21000)  ";
                        }
                        else if (baseType == typeof(DB_varchar_2000))
                        {
                            return "varchar(2000)  CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_264))
                        {
                            return "varchar(264) CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_250))
                        {
                            return "varchar(250) CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_64))
                        {
                            return "varchar(64)  CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_50))
                        {
                            return "varchar(50)  CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_45))
                        {
                            return "varchar(45) CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_32))
                        {
                            return "varchar(32) CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_25))
                        {
                            return "varchar(25) CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_10))
                        {
                            return "varchar(10) CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_varchar_5))
                        {
                            return "varchar(5) CHARSET utf8";
                        }
                        else if (baseType == typeof(DB_Image))
                        {
                            return "LONGBLOB";
                        }
                        else if (baseType == typeof(DB_Document))
                        {
                            return "LONGBLOB";
                        }
                        else
                        {
                            return "!! NOT BASIC TYPE !!";
                        }
                    }
                }
                string tableName = objType.ToString();
                int ij = tableName.IndexOf('.');
                if (ij >= 0)
                {
                    tableName = tableName.Substring(ij + 1);
                }

                string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
                Error.Show(csError, "Program Error!");
                return csError;
            }
            else
            {
                return "ERROR !!! NO base Type !!!";
            }
        }
        public static string GetBasicTypeSQLite(Object obj)
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            Type baseType = objType.BaseType;
            DBtypes DBtypes = new DBtypes();
            Type myDBTypes = DBtypes.GetType();

            if (obj.GetType() == typeof(DBm_Image))
            {
                return "DBm_Image";
            }

            if (baseType != null)
            {
                FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
                int i;
                int iCount = DBTypesInfo.Count();
                for (i = 0; i < iCount; i++)
                {
                    if (DBTypesInfo[i].FieldType == baseType)
                    {
                        if (baseType == typeof(DB_Int32))
                        {
                            return "INT";
                        }
                        else if (baseType == typeof(DB_Int64))
                        {
                            return "INTEGER";
                        }
                        else if (baseType == typeof(DB_Money))
                        {
                            return "DECIMAL(18,5)";
                        }
                        else if (baseType == typeof(DB_decimal2))
                        {
                            return "DECIMAL(18,5)";
                        }
                        else if (baseType == typeof(DB_Percent))
                        {
                            return "DECIMAL(18,5)";
                        }
                        else if (baseType == typeof(DB_smallInt))
                        {
                            return "INT";
                        }
                        else if (baseType == typeof(DB_bit))
                        {
                            return "BIT";
                        }
                        else if (baseType == typeof(DB_DateTime))
                        {
                            return "DATETIME";
                        }
                        else if (baseType == typeof(DBTypes.DB_varbinary_max))
                        {
                            return "BLOB";
                        }
                        else if (baseType == typeof(DB_varchar_max))
                        {
                            return "TEXT";
                        }
                        else if (baseType == typeof(DB_varchar_2000))
                        {
                            return "varchar(2000)";
                        }
                        else if (baseType == typeof(DB_varchar_264))
                        {
                            return "varchar(264)";
                        }
                        else if (baseType == typeof(DB_varchar_250))
                        {
                            return "varchar(250)";
                        }
                        else if (baseType == typeof(DB_varchar_64))
                        {
                            return "varchar(64)";
                        }
                        else if (baseType == typeof(DB_varchar_50))
                        {
                            return "varchar(50)";
                        }
                        else if (baseType == typeof(DB_varchar_45))
                        {
                            return "varchar(45)";
                        }
                        else if (baseType == typeof(DB_varchar_32))
                        {
                            return "varchar(32)";
                        }
                        else if (baseType == typeof(DB_varchar_25))
                        {
                            return "varchar(25)";
                        }
                        else if (baseType == typeof(DB_varchar_10))
                        {
                            return "varchar(10)";
                        }
                        else if (baseType == typeof(DB_varchar_5))
                        {
                            return "varchar(5)";
                        }
                        else if (baseType == typeof(DB_Image))
                        {
                            return "BLOB";
                        }
                        else if (baseType == typeof(DB_Document))
                        {
                            return "BLOB";
                        }
                        else
                        {
                            return "!! NOT BASIC TYPE !!";
                        }
                    }
                }
                string tableName = objType.ToString();
                int ij = tableName.IndexOf('.');
                if (ij >= 0)
                {
                    tableName = tableName.Substring(ij + 1);
                }

                string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
                LogFile.Error.Show(csError, "Program Error!");
                return csError;
            }
            else
            {
                return "ERROR !!! NO base Type !!!";
            }
        }


        public static Type BasicType(Type baseType, Type myDBTypes, ref string csError)
        {
            FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
            int i;
            int iCount = DBTypesInfo.Count();
            for (i = 0; i < iCount; i++)
            {
                if (DBTypesInfo[i].FieldType == baseType)
                {
                    if (baseType == typeof(DB_Int32))
                    {
                        return typeof(DB_Int32);
                    }
                    else if (baseType == typeof(DB_Int64))
                    {
                        return typeof(DB_Int64);
                    }
                    else if (baseType == typeof(DB_smallInt))
                    {
                        return typeof(DB_smallInt);
                    }
                    else if (baseType == typeof(DB_bit))
                    {
                        return typeof(DB_bit);
                    }
                    else if (baseType == typeof(DB_DateTime))
                    {
                        return typeof(DB_DateTime);
                    }
                    else if (baseType == typeof(DBTypes.DB_varbinary_max))
                    {
                        return typeof(DBTypes.DB_varbinary_max);
                    }
                    else if (baseType == typeof(DB_varchar_264))
                    {
                        return typeof(DB_varchar_264);
                    }
                    else if (baseType == typeof(DB_varchar_250))
                    {
                        return typeof(DB_varchar_250);
                    }
                    else if (baseType == typeof(DB_varchar_64))
                    {
                        return typeof(DB_varchar_64);
                    }
                    else if (baseType == typeof(DB_varchar_50))
                    {
                        return typeof(DB_varchar_50);
                    }
                    else if (baseType == typeof(DB_varchar_45))
                    {
                        return typeof(DB_varchar_45);
                    }
                    else if (baseType == typeof(DB_varchar_32))
                    {
                        return typeof(DB_varchar_32);
                    }
                    else if (baseType == typeof(DB_varchar_25))
                    {
                        return typeof(DB_varchar_25);
                    }
                    else if (baseType == typeof(DB_varchar_10))
                    {
                        return typeof(DB_varchar_10);
                    }
                    else if (baseType == typeof(DB_varchar_5))
                    {
                        return typeof(DB_varchar_5);
                    }
                    else if (baseType == typeof(DB_varchar_2000))
                    {
                        return typeof(DB_varchar_2000);
                    }
                    else if (baseType == typeof(DB_varchar_max))
                    {
                        return typeof(DB_varchar_max);
                    }
                    else if (baseType == typeof(DB_Money))
                    {
                        return typeof(DB_Money);
                    }
                    else if (baseType == typeof(DB_decimal2))
                    {
                        return typeof(DB_decimal2);
                    }
                    else if (baseType == typeof(DB_Percent))
                    {
                        return typeof(DB_Percent);
                    }
                    else if (baseType == typeof(DB_Document))
                    {
                        return typeof(DB_Document);
                    }
                    else if (baseType == typeof(DB_Image))
                    {
                        return typeof(DB_Image);
                    }
                    else
                    {
                        csError = "Basic type " + baseType.ToString() + " is not implemented in function DBTypes.BasicType(Type baseType, Type myDBTypes, ref string csError)";
                        return null;
                    }
                }
            }
            csError = "Basic type " + baseType.ToString() + " is not type (field) in DBTypes class!";
            return null;
        }

        public static int GetMaxColumnStringLength(Type baseType)
        {
            int len = -1;
            string stype = baseType.ToString();
            string stoken_DB_varchar = "DB_varchar_";
            int index_of_DB_varchar = stype.IndexOf(stoken_DB_varchar);
            if (index_of_DB_varchar>=0)
            {
                int indexoflength = index_of_DB_varchar + stoken_DB_varchar.Length;
                string slength = stype.Substring(indexoflength);
                if (slength.Equals("max"))
                {
                    len = Int32.MaxValue;
                }
                else
                {
                    try
                    {
                        len = Convert.ToInt32(slength);
                    }
                    catch
                    {
                        len = -1;
                    }
                }
            }
            return len;
        }

        public static bool IsNumber(Type baseType, Type myDBTypes, ref string csError)
        {
            FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
            int i;
            int iCount = DBTypesInfo.Count();
            for (i = 0; i < iCount; i++)
            {
                if (DBTypesInfo[i].FieldType == baseType)
                {
                    if (baseType == typeof(DB_Int32))
                    {
                        return true;
                    }
                    else if (baseType == typeof(DB_Int64))
                    {
                        return true;
                    }
                    else if (baseType == typeof(DB_smallInt))
                    {
                        return true;
                    }
                    else if (baseType == typeof(DB_bit))
                    {
                        return true;
                    }
                    else if (baseType == typeof(DB_Money))
                    {
                        return true;
                    }
                    else if (baseType == typeof(DB_decimal2))
                    {
                        return true;
                    }
                    else if (baseType == typeof(DB_Percent))
                    {
                        return true;
                    }
                    else if (baseType == typeof(DB_DateTime))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DBTypes.DB_varbinary_max))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_264))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_250))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_64))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_50))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_45))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_32))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_25))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_10))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_5))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_2000))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_varchar_max))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_Document))
                    {
                        return false;
                    }
                    else if (baseType == typeof(DB_Image))
                    {
                        return false;
                    }
                    else
                    {
                        csError = "Basic type " + baseType.ToString() + " not implemented in function DBTypes.IsNumberIsNumber(Type baseType, Type myDBTypes, ref string csError)";
                        return false;
                    }
                }
            }
            csError = "Basic type " + baseType.ToString() + " is not type (field) in DBTypes class!";
            return false;
        }



        public static bool SetObjValue(ref object obj, Type type, ref string sAction, string Value, ref string csError)
        {
            try
            {
                if (type == typeof(DB_Int32))
                {
                    sAction = "DB_Int32";

                    DB_Int32 xDBInt = (DB_Int32)obj;
                    xDBInt.val = Convert.ToInt32(Value);
                    return true;
                }
                else if (type == typeof(DB_Int64))
                {
                    sAction = "DB_Int64";

                    DB_Int64 xDBlong = (DB_Int64)obj;
                    xDBlong.val = Convert.ToInt64(Value);
                    return true;
                }
                else if (type == typeof(DB_Money))
                {
                    sAction = "DB_Money";
                    DB_Money xDB_Money = (DB_Money)obj;
                    xDB_Money.val = Convert.ToDecimal(Value, new CultureInfo("en-US"));
                    return true;
                }
                else if (type == typeof(DB_decimal2))
                {
                    sAction = "DB_decimal";
                    DB_decimal2 xDB_decimal = (DB_decimal2)obj;
                    xDB_decimal.val = Convert.ToDecimal(Value, new CultureInfo("en-US"));
                    return true;
                }
                else if (type == typeof(DB_Percent))
                {
                    sAction = "DB_Percent";
                    DB_Percent xDB_Percent = (DB_Percent)obj;
                    xDB_Percent.val = Convert.ToDecimal(Value, new CultureInfo("en-US"));
                    return true;
                }
                else if (type == typeof(DB_smallInt))
                {
                    sAction = "DB_smallInt";
                    DB_smallInt xDB_smallInt = (DB_smallInt)obj;
                    xDB_smallInt.val = Convert.ToInt16(Value);
                    return true;
                }
                else if (type == typeof(DB_bit))
                {
                    sAction = "DB_bit";
                    if (Value.Length == 1)
                    {
                        if (Value[0] == 'M')
                        {
                            Value = "true";
                        }
                        else if (Value[0] == 'Ž')
                        {
                            Value = "false";
                        }
                        else if (Value[0] == 'F')
                        {
                            Value = "false";
                        }
                        else if (Value[0] == '1')
                        {
                            Value = "true";
                        }
                        else if (Value[0] == '0')
                        {
                            Value = "false";
                        }
                    }
                    DB_bit xDB_bit = (DB_bit)obj;
                    xDB_bit.val = Convert.ToBoolean(Value);
                    return true;
                }
                else if (type == typeof(DB_DateTime))
                {
                    sAction = "DB_DateTime";
                    DB_DateTime xDB_DateTime = (DB_DateTime)obj;
                    //if (Value.Length == 0)
                    //{
                    //    this.SetType = ValueSetTYPE.SET_NOTHING;
                    //    return true;
                    //}

                    xDB_DateTime.val = Convert.ToDateTime(Value);
                    return true;
                }
                else if (type == typeof(DB_varbinary_max))
                {
                    sAction = "DB_varbinary_max";
                    DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)obj;
                    if (ImageStore.IsName(Value))
                    {
                        if (ImageStore != null)
                        {
                            xDB_varbinary_max.val = imageToByteArray(ImageStore.Get(Value));
                            return true;
                        }

                        csError = lng.s_ErrorNoImage.s;
                        return false;
                    }
                    else
                    {
                        if (File.Exists(Value))
                        {
                            xDB_varbinary_max.val = File.ReadAllBytes(Value);
                            return true;
                        }
                        else
                        {
                            xDB_varbinary_max.val = null;
                            //sTxt.ShowParseError(lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            csError = lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s;
                            return false;
                        }
                    }
                }
                else if (type == typeof(DB_varchar_264))
                {
                    sAction = "DB_varchar_264";
                    DB_varchar_264 xDB_varchar_264 = (DB_varchar_264)obj;
                    xDB_varchar_264.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_250))
                {
                    sAction = "DB_varchar_250";
                    DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)obj;
                    xDB_varchar_250.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_64))
                {
                    sAction = "DB_varchar_64";
                    DB_varchar_64 xDB_varchar_64 = (DB_varchar_64)obj;
                    xDB_varchar_64.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_50))
                {
                    sAction = "DB_varchar_50";
                    DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)obj;
                    xDB_varchar_50.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_45))
                {
                    sAction = "DB_varchar_45";
                    DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)obj;
                    xDB_varchar_45.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_32))
                {
                    sAction = "DB_varchar_32";
                    DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)obj;
                    xDB_varchar_32.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_25))
                {
                    sAction = "DB_varchar_25";
                    DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)obj;
                    xDB_varchar_25.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_10))
                {
                    sAction = "DB_varchar_10";
                    DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)obj;
                    xDB_varchar_10.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_5))
                {
                    sAction = "DB_varchar_5";
                    DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)obj;
                    xDB_varchar_5.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_2000))
                {
                    sAction = "DB_varchar_2000";
                    DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)obj;
                    xDB_varchar_2000.val = Value;
                    return true;
                }
                else if (type == typeof(DB_varchar_max))
                {

                    sAction = "DB_varchar_max";
                    DB_varchar_max xDB_varchar_max = (DB_varchar_max)obj;
                    xDB_varchar_max.val = Value;
                    return true;
                }
                else if (type == typeof(DB_Document))
                {
                    sAction = "DB_varbinary_max";
                    DB_Document xDB_Document = (DB_Document)obj;
                    if (ImageStore.IsName(Value))
                    {
                        if (ImageStore != null)
                        {
                            xDB_Document.val = imageToByteArray(ImageStore.Get(Value));
                            return true;
                        }

                        csError = lng.s_ErrorNoImage.s;
                        return false;
                    }
                    else
                    {
                        if (File.Exists(Value))
                        {
                            xDB_Document.val = File.ReadAllBytes(Value);
                            return true;
                        }
                        else
                        {
                            xDB_Document.val = null;
                            //sTxt.ShowParseError(lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            csError = lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s;
                            return false;
                        }
                    }
                }
                else if (type == typeof(DB_Image))
                {
                    sAction = "DB_Image";
                    DB_Image xDB_Image = (DB_Image)obj;
                    if (ImageStore.IsName(Value))
                    {
                        if (ImageStore != null)
                        {
                            xDB_Image.val = imageToByteArray(ImageStore.Get(Value));
                            return true;
                        }

                        csError = lng.s_ErrorNoImage.s;
                        return false;
                    }
                    else
                    {
                        if (Convert.ToString(Value).Equals("DBm_Image_is_DB_null"))
                        {
                            xDB_Image.val = null;
                            return true;
                        }
                        else
                        {
                            if (File.Exists(Value))
                            {
                                xDB_Image.val = File.ReadAllBytes(Value);
                                return true;
                            }
                            else
                            {
                                xDB_Image.val = null;
                                //sTxt.ShowParseError(lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                csError = lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s;
                                return false;
                            }
                        }
                    }
                }

                else
                {
                    //sTxt.ShowParseError(lng.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    csError = lng.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value;
                    return false;
                }
            }
            catch (Exception ex)
            {
                //sTxt.ShowParseError(lng.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                csError = lng.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message;
                return false;
            }

        }

        public static bool SaveImageInFormat(Image img, MemoryStream ms)
        {
            try
            {
                if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Emf.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Emf);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Exif.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Exif);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Icon.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Icon);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.MemoryBmp.Guid)
                {
                    if (MessageBox.Show(lng.s_MemoryBmpPictureFormatNotAllowed_SaveInJpg.s, lng.s_SaveInJpgQuestion.s, System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff);
                else if (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Wmf.Guid)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Wmf);
                else
                {
                    if (MessageBox.Show(lng.s_UnknownPictureFormatSaveInJpg.s, lng.s_SaveInJpgQuestion.s, System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error in SaveImageInFormat =" + Ex.Message);
                return false;
            }
            return true;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn, System.Drawing.Imaging.ImageFormat imgformat)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imgformat);
            //SaveImageInFormat(imageIn, ms);
            return ms.ToArray();
        }

        public static int GetObjectSize(object TestObject)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] Array;
            bf.Serialize(ms, TestObject);
            Array = ms.ToArray();
            return Array.Length;
        }


        public static bool SetValue(ref object col_obj, object Value, ref string csError)
        {
            ValSet vs = null;
            try
            {
                Type type = col_obj.GetType().BaseType;

                vs = (ValSet)col_obj;
                if (Value.GetType() == typeof(System.DBNull))
                {
                    vs.defined = false;
                    return true;
                }
                else
                {
                    if (type == typeof(DB_Int32))
                    {
                        ((DB_Int32)col_obj).val = Convert.ToInt32(Value);
                        return true;
                    }
                    else if (type == typeof(DB_Int64))
                    {
                        ((DB_Int64)col_obj).val = Convert.ToInt64(Value);
                        return true;
                    }
                    else if (type == typeof(DB_Money))
                    {
                        ((DB_Money)col_obj).val = Convert.ToDecimal(Value);
                        return true;
                    }
                    else if (type == typeof(DB_decimal2))
                    {
                        ((DB_decimal2)col_obj).val = Convert.ToDecimal(Value);
                        return true;
                    }
                    else if (type == typeof(DB_Percent))
                    {
                        ((DB_Percent)col_obj).val = Convert.ToDecimal(Value);
                        return true;
                    }
                    else if (type == typeof(DB_smallInt))
                    {
                        ((DB_smallInt)col_obj).val = Convert.ToInt16(Value);
                        return true;
                    }
                    else if (type == typeof(DB_bit))
                    {
                        ((DB_bit)col_obj).val = Convert.ToBoolean(Value);
                        return true;
                    }
                    else if (type == typeof(DB_DateTime))
                    {
                        ((DB_DateTime)col_obj).val = Convert.ToDateTime(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varbinary_max))
                    {
                        ((DB_varbinary_max)col_obj).val = (byte[])Value;
                        return true;
                    }
                    else if (type == typeof(DB_varchar_264))
                    {
                        ((DB_varchar_264)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_250))
                    {
                        ((DB_varchar_250)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_64))
                    {
                        ((DB_varchar_64)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_50))
                    {
                        ((DB_varchar_50)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_45))
                    {
                        ((DB_varchar_45)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_32))
                    {
                        ((DB_varchar_32)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_25))
                    {
                        ((DB_varchar_25)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_10))
                    {
                        ((DB_varchar_10)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_5))
                    {
                        ((DB_varchar_5)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_2000))
                    {
                        ((DB_varchar_2000)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_varchar_max))
                    {
                        ((DB_varchar_max)col_obj).val = Convert.ToString(Value);
                        return true;
                    }
                    else if (type == typeof(DB_Document))
                    {
                        ((DB_Document)col_obj).val = (byte[])Value;
                        return true;
                    }
                    else if (type == typeof(DB_Image))
                    {
                        ((DB_Image)col_obj).val = (byte[])Value;
                        return true;
                    }
                    else
                    {
                        //sTxt.ShowParseError(lng.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        csError = lng.s_UnsuportedType.s + " " + col_obj.GetType().ToString() + " : " + Value;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {


                //sTxt.ShowParseError(lng.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Value.GetType() == typeof(DBNull))
                {
                    try
                    {
                        vs.defined = false;
                        return true;
                    }
                    catch
                    {
                    }
                    return true;
                }
                csError = lng.s_Illegal_format_for.s + " : " + Value + "\r\n " + ex.Message;
                return false;
            }

        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static bool Is_DBm_Type(Object obj)
        {
            //MemberInfo[] myMemberInfo;
            Type objType = obj.GetType();
            DBTypes.SQL_Database_Tables_Definition DBm_types = new DBTypes.SQL_Database_Tables_Definition();
            Type my_DBm_Types = DBm_types.GetType();

            FieldInfo[] DBTypesInfo = my_DBm_Types.GetFields();
            int i;
            int iCount = DBTypesInfo.Count();
            for (i = 0; i < iCount; i++)
            {
                if (DBTypesInfo[i].FieldType == objType)
                {
                    return true;
                }
            }
            return false;
        }


        public static string DbValueForSql(ref Object obj, Type baseType, string sThisVar, ref List<SQL_Parameter> lsqlPar, string Name)
        {
            if (baseType == typeof(DB_Int32))
            {
                DB_Int32 xDB_int = (DB_Int32)obj;
                return xDB_int.val.ToString();
            }
            else if (baseType == typeof(DB_Int64))
            {
                DB_Int64 xDB_long = (DB_Int64)obj;
                return xDB_long.val.ToString();
            }
            else if (baseType == typeof(DB_Money))
            {
                DB_Money xDB_Money = (DB_Money)obj;
                return xDB_Money.val.ToString(new CultureInfo("en-US"));
            }
            else if (baseType == typeof(DB_decimal2))
            {
                DB_decimal2 xDB_decimal = (DB_decimal2)obj;
                return xDB_decimal.val.ToString(new CultureInfo("en-US"));
            }
            else if (baseType == typeof(DB_Percent))
            {
                DB_Percent xDB_Percent = (DB_Percent)obj;
                return xDB_Percent.val.ToString(new CultureInfo("en-US"));
            }
            else if (baseType == typeof(DB_smallInt))
            {
                DB_smallInt xDB_smallInt = (DB_smallInt)obj;
                return xDB_smallInt.val.ToString();
            }
            else if (baseType == typeof(DB_bit))
            {
                DB_bit xDB_bit = (DB_bit)obj;
                if (xDB_bit.val)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
                //return xDB_bit.val.ToString();
            }
            else if (baseType == typeof(DB_DateTime))
            {
                DB_DateTime xDB_DateTime = (DB_DateTime)obj;
                SQL_Parameter sqlPar = new SQL_Parameter();
                sqlPar.dbType = System.Data.SqlDbType.DateTime;
                sqlPar.SQLiteDbType = DbType.DateTime;
                string sPar = "@Par_" + sThisVar + "_" + Name;
                sqlPar.Name = sPar;
                sqlPar.size = -1;
                sqlPar.Value = xDB_DateTime.val;
                lsqlPar.Add(sqlPar);
                return sPar;

            }
            else if (baseType == typeof(DB_varbinary_max))
            {
                DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)obj;
                if (xDB_varbinary_max.val != null)
                {
                    string sPar = "@Par_" + sThisVar + "_" + Name;
                    SQL_Parameter sqlPar = new SQL_Parameter();
                    sqlPar.dbType = System.Data.SqlDbType.VarBinary;
                    sqlPar.Name = sPar;
                    sqlPar.size = xDB_varbinary_max.val.Count();
                    sqlPar.Value = xDB_varbinary_max.val;
                    lsqlPar.Add(sqlPar);
                    return sPar;
                }
                else
                {
                    return "NULL";
                }
            }
            else if (baseType == typeof(DB_varchar_264))
            {
                DB_varchar_264 xDB_varchar_264 = (DB_varchar_264)obj;

                return SetParString(xDB_varchar_264.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_250))
            {
                DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)obj;
                return SetParString(xDB_varchar_250.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_64))
            {
                DB_varchar_64 xDB_varchar_64 = (DB_varchar_64)obj;
                return SetParString(xDB_varchar_64.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_50))
            {
                DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)obj;
                return SetParString(xDB_varchar_50.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_45))
            {
                DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)obj;
                return SetParString(xDB_varchar_45.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_32))
            {
                DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)obj;
                return SetParString(xDB_varchar_32.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_25))
            {
                DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)obj;
                return SetParString(xDB_varchar_25.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_10))
            {
                DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)obj;
                return SetParString(xDB_varchar_10.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_5))
            {
                DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)obj;
                return SetParString(xDB_varchar_5.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_2000))
            {
                DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)obj;
                return SetParString(xDB_varchar_2000.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_varchar_max))
            {
                DB_varchar_max xDB_varchar_max = (DB_varchar_max)obj;
                return SetParString(xDB_varchar_max.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
            }
            else if (baseType == typeof(DB_Document))
            {
                DB_Document xDB_Document = (DB_Document)obj;
                if (xDB_Document.val != null)
                {
                    string sPar = "@Par_" + sThisVar + "_" + Name;
                    SQL_Parameter sqlPar = new SQL_Parameter();
                    sqlPar.dbType = System.Data.SqlDbType.VarBinary;
                    sqlPar.Name = sPar;
                    sqlPar.size = xDB_Document.val.Count();
                    sqlPar.Value = xDB_Document.val;
                    lsqlPar.Add(sqlPar);
                    return sPar;
                }
                else
                {
                    return "NULL";
                }
            }
            else if (baseType == typeof(DB_Image))
            {
                DB_Image xDB_Image = (DB_Image)obj;
                if (xDB_Image.val != null)
                {
                    string sPar = "@Par_" + sThisVar + "_" + Name;
                    SQL_Parameter sqlPar = new SQL_Parameter();
                    sqlPar.dbType = System.Data.SqlDbType.VarBinary;
                    sqlPar.SQLiteDbType = DbType.Binary;
                    sqlPar.Name = sPar;
                    sqlPar.size = xDB_Image.val.Count();
                    sqlPar.Value = xDB_Image.val;
                    lsqlPar.Add(sqlPar);
                    return sPar;
                }
                else
                {
                    return "NULL";
                }
            }
            else
            {
                return "ERROR in DbValueForSql ";
            }
        }

        private static string Bin2Hex(byte[] binary)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (byte num in binary)
            {
                i++;
                builder.Append(i.ToString() + ":");
                if (num > 15)
                {
                    builder.AppendFormat("{0:X}", num);
                    builder.Append(",\r\n");

                }
                else
                {
                    builder.AppendFormat("0{0:X}", num);/////// 大于 15 就多加个 0
                    builder.Append(",\r\n");
                }
            }
            return builder.ToString();
        }

        private static void SaveSqlPar(SQL_Parameter sqlPar, string FileName)
        {
            if (sqlPar.SQLiteDbType == DbType.Object)
            {
                if (System.Windows.Forms.MessageBox.Show("Save sqlPar of DbType.Object:" + sqlPar.Value.GetType().ToString() + " Size=" + sqlPar.size.ToString() + " ?", "Save sqlPar?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    //saveDialog.InitialDirectory = SaveSqlParDirectory;
                    saveDialog.FileName = FileName;
                    saveDialog.DefaultExt = "*.txt";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        byte[] bin = (byte[])sqlPar.Value;
                        string sHexFile = Bin2Hex(bin);
                        File.WriteAllText(saveDialog.FileName, sHexFile);
                        //SaveSqlParDirectory = Path.GetDirectoryName(saveDialog.FileName);
                    }
                }
            }
        }

        public static void SaveBin(byte[] bin, string FileName)
        {
            if (System.Windows.Forms.MessageBox.Show("Save byte array of type byte[]:" + bin.GetType().ToString() + " Size=" + bin.Length.ToString() + " ?", "Save sqlPar?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                //saveDialog.InitialDirectory = SaveSqlParDirectory;
                saveDialog.FileName = FileName;
                saveDialog.DefaultExt = "*.txt";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string sHexFile = Bin2Hex(bin);
                    File.WriteAllText(saveDialog.FileName, sHexFile);
                    //SaveSqlParDirectory = Path.GetDirectoryName(saveDialog.FileName);
                }
            }
        }

        private static string SetParString(string sValue, List<SQL_Parameter> lsqlPar, string sPar)
        {
            SQL_Parameter sqlPar = new SQL_Parameter();
            sqlPar.dbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Name = sPar;
            sqlPar.size = -1;
            sqlPar.Value = sValue;
            lsqlPar.Add(sqlPar);
            return sPar;
        }

        internal static bool IsMyBaseType(Type baseType)
        {
            return ((baseType == typeof(DB_Int32)) ||
                    (baseType == typeof(DB_Int64)) ||
                    (baseType == typeof(DB_Money)) ||
                    (baseType == typeof(DB_decimal2)) ||
                    (baseType == typeof(DB_Percent)) ||
                    (baseType == typeof(DB_smallInt)) ||
                    (baseType == typeof(DB_bit)) ||
                    (baseType == typeof(DB_DateTime)) ||
                    (baseType == typeof(DB_varbinary_max)) ||
                    (baseType == typeof(DB_varchar_264)) ||
                    (baseType == typeof(DB_varchar_250)) ||
                    (baseType == typeof(DB_varchar_64)) ||
                    (baseType == typeof(DB_varchar_50)) ||
                    (baseType == typeof(DB_varchar_45)) ||
                    (baseType == typeof(DB_varchar_32)) ||
                    (baseType == typeof(DB_varchar_25)) ||
                    (baseType == typeof(DB_varchar_10)) ||
                    (baseType == typeof(DB_varchar_5)) ||
                    (baseType == typeof(DB_varchar_2000)) ||
                    (baseType == typeof(DB_varchar_max)) ||
                    (baseType == typeof(DB_Document)) ||
                    (baseType == typeof(DB_Image))
                    );

        }

        public static bool IsValueDefined(object obj)
        {
            Type baseType = obj.GetType().BaseType;
            if (IsMyBaseType(baseType))
            {
                ValSet vs = (ValSet)obj;
                return vs.defined;
            }
            else
            {

                return false;
            }
        }

        //public static string SaveSqlParDirectory
        //{
        //    get
        //    {
        //        m_SaveSqlParDirectory = Settings.SaveFileFolder;
        //        if (m_SaveSqlParDirectory == null)
        //        {
        //            m_SaveSqlParDirectory = Application.CommonAppDataPath;
        //            Settings.SaveFileFolder = m_SaveSqlParDirectory;
        //            Settings.Save();
        //        }
        //        else if (m_SaveSqlParDirectory.Length == 0)
        //        {
        //            m_SaveSqlParDirectory = Application.CommonAppDataPath;
        //            Settings.SaveFileFolder = m_SaveSqlParDirectory;
        //            Settings.Save();
        //        }
        //        return m_SaveSqlParDirectory;
        //    }
        //    set
        //    {
        //        m_SaveSqlParDirectory = value;
        //        Settings.SaveFileFolder = m_SaveSqlParDirectory;
        //        Settings.Save();
        //    }
        //}
        public static byte[] DocumentToByteArray(DB_Document doc)
        {
            MemoryStream ms = new MemoryStream();
            return ms.ToArray();
        }

        public static void ID_Is_Defined(object obj)
        {
            if (obj is ID)
            {
                ((ID)obj).Defined=true;
            }
            else
            {
                Type baseType = obj.GetType().BaseType;
                if (IsMyBaseType(baseType))
                {
                    ValSet vs = (ValSet)obj;
                    vs.defined = true;
                }
            }
        }


        public static string GetValueToString(string sPar, List<SQL_Parameter> lsqlPar)
        {
            foreach (SQL_Parameter par in lsqlPar)
            {
                if (par.Name.Equals(sPar))
                {
                    if (par.Value.GetType() == typeof(string))
                    {
                        return (string)par.Value;
                    }
                    else if (par.Value.GetType() == typeof(int))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(uint))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(long))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(ulong))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(short))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(ushort))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(float))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(decimal))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(double))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(byte))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(char))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else if (par.Value.GetType() == typeof(sbyte))
                    {
                        return Convert.ToString(par.Value);
                    }
                    else
                    {
                        return "(Type:" + par.Value.GetType().ToString() + " can not be converted to string)";
                    }
                }
            }
            return "Error GetValueToString,spar=" + sPar + " not found in List<SQL_Parameter> !";
        }




        public static string DBm_sql_Insert_fkey_column(string RootTableName, Type type, Type col_type, object objValue, List<SQL_Parameter> lsqlPar, System.Data.SqlDbType dbType, bool is_output, int size, List<DBm_col_name_and_param> lPar_DBm_col_name_and_param)
        {
            string sql_DBm_Image_fkey_Insert = "";
            string tbl_name = null;
            string col_name = null;
            string Par_DBm_Image_fkey_ID = null;
            string Par_col_name = null;
            string stype = type.ToString();
            int iLast = stype.LastIndexOf('.');
            int iLen = stype.Length;
            string stype_col_name = col_type.ToString();
            int iLen_col_name = stype_col_name.Length;
            int iLen_col_name_Last = stype_col_name.LastIndexOf('.');

            if (iLast > 0)
            {
                tbl_name = RootTableName + "_" + stype.Substring(iLast + 1, iLen - iLast + 1);
            }
            else
            {
                tbl_name = RootTableName + "_" + stype;
            }

            if (iLen_col_name_Last > 0)
            {
                col_name = stype_col_name.Substring(iLen_col_name_Last + 1, iLen_col_name - iLen_col_name_Last + 1);
            }
            else
            {
                col_name = stype_col_name;
            }

            Par_col_name = "@Par_" + col_name;
            Par_DBm_Image_fkey_ID = "@Par_" + tbl_name + "_" + col_name + "_ID";

            SQL_Parameter SQL_Par = new SQL_Parameter();
            SQL_Par.dbType = dbType;
            SQL_Par.IsOutputParameter = is_output;
            SQL_Par.Name = Par_col_name;
            SQL_Par.size = size;
            SQL_Par.Value = objValue;
            lsqlPar.Add(SQL_Par);

            sql_DBm_Image_fkey_Insert += "declare " + Par_DBm_Image_fkey_ID + " bigint \r\n";
            sql_DBm_Image_fkey_Insert += "select " + Par_DBm_Image_fkey_ID + " = ID from " + tbl_name + " where " + col_name + " = " + Par_col_name + " \r\n";
            sql_DBm_Image_fkey_Insert += @"if (" + Par_DBm_Image_fkey_ID + @" is null)
                                                              begin
                                                                 insert into " + tbl_name + @"
                                                                 (
                                                                    " + col_name + @"
                                                                 )
                                                                 values
                                                                 (
                                                                    " + Par_col_name + @"
                                                                 )
                                                                 set " + Par_DBm_Image_fkey_ID + @" = SCOPE_IDENTITY()
                                                              end
                                                            ";
            DBm_col_name_and_param xDBm_col_name_and_param = new DBm_col_name_and_param(tbl_name + "_ID", Par_DBm_Image_fkey_ID);
            lPar_DBm_col_name_and_param.Add(xDBm_col_name_and_param);
            return sql_DBm_Image_fkey_Insert;

        }

        public static void Add_DBm_col_name_and_param(string RootTableName, Type type, object objValue, System.Data.SqlDbType dbType, int size, List<SQL_Parameter> lsqlPar, List<DBm_col_name_and_param> lPar_DBm_col_name_and_param)
        {
            string Par_col_name = null;
            string col_name = null;
            string stype_col_name = type.ToString();
            int iLen_col_name = stype_col_name.Length;
            int iLen_col_name_Last = stype_col_name.LastIndexOf('.');
            if (iLen_col_name_Last > 0)
            {
                col_name = stype_col_name.Substring(iLen_col_name_Last + 1, iLen_col_name - iLen_col_name_Last + 1);
            }
            else
            {
                col_name = stype_col_name;
            }

            Par_col_name = "@Par_" + col_name;

            SQL_Parameter SQL_Par = new SQL_Parameter();
            SQL_Par.dbType = dbType;
            SQL_Par.IsOutputParameter = false;
            SQL_Par.Name = Par_col_name;
            SQL_Par.size = size;
            SQL_Par.Value = objValue;
            lsqlPar.Add(SQL_Par);

            DBm_col_name_and_param xDBm_col_name_and_param = new DBm_col_name_and_param(col_name, Par_col_name);
            lPar_DBm_col_name_and_param.Add(xDBm_col_name_and_param);

        }

        public static object GetOutputParameterValue(string Par_DBm_ID, List<SQL_Parameter> lsqlPar)
        {
            object obj = null;
            foreach (SQL_Parameter par in lsqlPar)
            {
                if (par.Name.Equals(Par_DBm_ID))
                {
                    obj = par.MS_SqlSqlParameter.Value;
                }
            }
            return obj;
        }

    }


    public class ImageItem
    {
        public string name;
        public Image Image;
    }

    public class ImageStore
    {
        const string const_IMAGE_STORE_ = "IMAGE_STORE_";
        public List<ImageItem> items = new List<ImageItem>();

        public string Insert(Image xImage)
        {
            string newname = UniqueNames.GetName(this, const_IMAGE_STORE_);
            ImageItem e3pi = new ImageItem();
            e3pi.name = newname;
            e3pi.Image = xImage;
            items.Add(e3pi);
            return newname;
        }

        public Image Get(string xName)
        {
            int i = 0;
            int iCount;
            iCount = items.Count;
            for (i = 0; i < iCount; i++)
            {
                ImageItem e3pi = items[i];
                if (e3pi.name.Equals(xName))
                {
                    Image Img = (Image)e3pi.Image.Clone();
                    items.RemoveAt(i);
                    return Img;
                }
            }
            return null;
        }


        public bool IsName(string Value)
        {
            if (Value.Contains(const_IMAGE_STORE_))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class DataItem
    {
        public string name;
        public Byte[] Data;
    }

    public class DataStore
    {
        const string const_DATA_STORE_ = "DATA_STORE_";
        public List<DataItem> items = new List<DataItem>();

        public string Insert(Byte[] xData)
        {
            string newname = UniqueNames.GetName(this, const_DATA_STORE_);
            DataItem dataitem = new DataItem();
            dataitem.Data = xData;
            dataitem.name = newname;
            items.Add(dataitem);
            return newname;
        }

        public Byte[] Get(string xName)
        {
            int i = 0;
            int iCount;
            iCount = items.Count;
            for (i = 0; i < iCount; i++)
            {
                DataItem dataitem = items[i];
                if (dataitem.name.Equals(xName))
                {
                    Byte[] data = (Byte[])dataitem.Data.Clone();
                    items.RemoveAt(i);
                    return data;
                }
            }
            return null;
        }


        public bool IsName(string Value)
        {
            if (Value.Contains(const_DATA_STORE_))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class DocumentItem
    {
        public string name;
        public Byte[] Data;
    }

    public class DocumentStore
    {
        const string const_DOCUMENT_STORE_ = "DOCUMENT_STORE_";
        public List<DocumentItem> items = new List<DocumentItem>();

        public string Insert(Byte[] xData)
        {
            string newname = UniqueNames.GetName(this, const_DOCUMENT_STORE_);
            DocumentItem document_item = new DocumentItem();
            document_item.Data = xData;
            document_item.name = newname;
            items.Add(document_item);
            return newname;
        }

        public Byte[] Get(string xName)
        {
            int i = 0;
            int iCount;
            iCount = items.Count;
            for (i = 0; i < iCount; i++)
            {
                DocumentItem document_item = items[i];
                if (document_item.name.Equals(xName))
                {
                    Byte[] data = (Byte[])document_item.Data.Clone();
                    items.RemoveAt(i);
                    return data;
                }
            }
            return null;
        }


        public bool IsName(string Value)
        {
            if (Value.Contains(const_DOCUMENT_STORE_))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }


    public class Image_Name : DB_varchar_264
    {
    }

    public class Image_Author : DB_varchar_264
    {
    }

    public class Image_CaptureLocation : DB_varchar_264
    {
    }

    public class Image_FileName : DB_varchar_264
    {
    }

    public class Image_Ext : DB_varchar_32
    {
    }

    public class Image_Folder : DB_varchar_264
    {
    }

    public class Image_Computer : DB_varchar_264
    {
    }

    public class Image_ComputerUserName : DB_varchar_264
    {

    }

    public class Image_DateCreated : DB_DateTime
    {

    }

    public class Image_Size : DB_Int64
    {

    }

    public class Image_Width : DB_Int32
    {

    }

    public class Image_Height : DB_Int32
    {

    }

    public class Image_Hash : DB_varchar_32
    {

    }

    public class Image_Data : DB_Image
    {
        public Image Image = null;
    }

    public class DBm_Image_Name
    {
        public ID ID = new ID();
        public Image_Name Image_Name = new Image_Name();
    }

    public class DBm_Image_Author
    {
        public ID ID = new ID();
        public Image_Author Image_Author = new Image_Author();
    }

    public class DBm_Image_CaptureLocation
    {
        public ID ID = new ID();
        public Image_CaptureLocation Image_CaptureLocation = new Image_CaptureLocation();
    }

    public class DBm_Image_FileName
    {
        public ID ID = new ID();
        public Image_FileName Image_FileName = new Image_FileName();
    }


    public class DBm_Image_Ext
    {
        public ID ID = new ID();
        public Image_Ext Image_Ext = new Image_Ext();
    }

    public class DBm_Image_Folder
    {
        public ID ID = new ID();
        public Image_Folder Image_Folder = new Image_Folder();
    }

    public class DBm_Image_Computer
    {
        public ID ID = new ID();
        public Image_Computer Image_Computer = new Image_Computer();
    }

    public class DBm_Image_ComputerUserName
    {
        public ID ID = new ID();
        public Image_ComputerUserName Image_ComputerUserName = new Image_ComputerUserName();
    }



    public class DBm_Image
    {
        public ID ID = new ID();
        public DBm_Image_Name m_DBm_Image_Name = new DBm_Image_Name();
        public DBm_Image_Author m_DBm_Image_Author = new DBm_Image_Author();
        public DBm_Image_CaptureLocation m_DBm_Image_CaptureLocation = new DBm_Image_CaptureLocation();
        public DBm_Image_FileName m_DBm_Image_FileName = new DBm_Image_FileName();
        public DBm_Image_Ext m_DBm_Image_Ext = new DBm_Image_Ext();
        public DBm_Image_Folder m_DBm_Image_Folder = new DBm_Image_Folder();
        public DBm_Image_Computer m_DBm_Image_Computer = new DBm_Image_Computer();
        public DBm_Image_ComputerUserName m_DBm_Image_ComputerUserName = new DBm_Image_ComputerUserName();
        public Image_DateCreated Image_DateCreated = new Image_DateCreated();
        public Image_Size Image_Size = new Image_Size();
        public Image_Width Image_Width = new Image_Width();
        public Image_Height Image_Height = new Image_Height();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
    }

    public class DBm_SImage
    {
        public ID ID = new ID();
        public Image_Hash Image_Hash = new Image_Hash();
        public Image_Data Image_Data = new Image_Data();
    }


    public class Document_Name : DB_varchar_264
    {
    }

    public class Document_Author : DB_varchar_264
    {
    }

    public class Document_FileName : DB_varchar_264
    {
    }

    public class Document_Ext : DB_varchar_32
    {
    }

    public class Document_Folder : DB_varchar_264
    {
    }

    public class Document_Computer : DB_varchar_264
    {
    }

    public class Document_ComputerUserName : DB_varchar_264
    {

    }

    public class Document_DateCreated : DB_DateTime
    {

    }

    public class Document_Data : DB_Document
    {

    }

    public class DBm_Document_Name
    {
        public ID ID = new ID();
        public Document_Name Document_Name = new Document_Name();
    }

    public class DBm_Document_Author
    {
        public ID ID = new ID();
        public Document_Author Document_Author = new Document_Author();
    }

    public class DBm_Document_FileName
    {
        public ID ID = new ID();
        public Document_FileName Document_FileName = new Document_FileName();
    }


    public class DBm_Document_Ext
    {
        public ID ID = new ID();
        public Document_Ext Document_Ext = new Document_Ext();
    }

    public class DBm_Document_Folder
    {
        public ID ID = new ID();
        public Document_Folder Document_Folder = new Document_Folder();
    }

    public class DBm_Document_Computer
    {
        public ID ID = new ID();
        public Document_Computer Document_Computer = new Document_Computer();
    }

    public class DBm_Document_ComputerUserName
    {
        public ID ID = new ID();
        public Document_ComputerUserName Document_ComputerUserName = new Document_ComputerUserName();
    }



    public class DBm_Document
    {
        public ID ID = new ID();
        public DBm_Document_Name m_DBm_Document_Name = new DBm_Document_Name();
        public DBm_Document_Author m_DBm_Document_Author = new DBm_Document_Author();
        public DBm_Document_FileName m_DBm_Document_FileName = new DBm_Document_FileName();
        public DBm_Document_Ext m_DBm_Document_Ext = new DBm_Document_Ext();
        public DBm_Document_Folder m_DBm_Document_Folder = new DBm_Document_Folder();
        public DBm_Document_Computer m_DBm_Document_Computer = new DBm_Document_Computer();
        public DBm_Document_ComputerUserName m_DBm_Document_ComputerUserName = new DBm_Document_ComputerUserName();
        public Document_DateCreated Document_DateCreated = new Document_DateCreated();
        public Document_Data Document_Data = new Document_Data();
    }





    public class SQL_Database_Tables_Definition
    {
        /* 1 */
        public DBm_Image_Name m_DBm_Image_Name = new DBm_Image_Name();
        /* 2 */
        public DBm_Image_Author m_DBm_Image_Author = new DBm_Image_Author();
        /* 3 */
        public DBm_Image_CaptureLocation m_DBm_Image_CaptureLocation = new DBm_Image_CaptureLocation();
        /* 4 */
        public DBm_Image_FileName m_DBm_Image_FileName = new DBm_Image_FileName();
        /* 5 */
        public DBm_Image_Ext m_DBm_Image_Ext = new DBm_Image_Ext();
        /* 6 */
        public DBm_Image_Folder m_DBm_Image_Folder = new DBm_Image_Folder();
        /* 7 */
        public DBm_Image_Computer m_DBm_Image_Computer = new DBm_Image_Computer();
        /* 8 */
        public DBm_Image_ComputerUserName m_DBm_Image_ComputerUserName = new DBm_Image_ComputerUserName();
        /* 9 */
        public DBm_Image m_DBm_Image = new DBm_Image();

        /* 10 */
        public DBm_Document_Name m_DBm_Document_Name = new DBm_Document_Name();
        /* 11 */
        public DBm_Document_Author m_DBm_Document_Author = new DBm_Document_Author();
        /* 12 */
        public DBm_Document_FileName m_DBm_Document_FileName = new DBm_Document_FileName();
        /* 13 */
        public DBm_Document_Ext m_DBm_Document_Ext = new DBm_Document_Ext();
        /* 14 */
        public DBm_Document_Folder m_DBm_Document_Folder = new DBm_Document_Folder();
        /* 15 */
        public DBm_Document_Computer m_DBm_Document_Computer = new DBm_Document_Computer();
        /* 16 */
        public DBm_Document_ComputerUserName m_DBm_Document_ComputerUserName = new DBm_Document_ComputerUserName();
        /* 17 */
        public DBm_Document m_DBm_Document = new DBm_Document();

        /* 18 */
        public DBm_SImage m_DBm_SImage = new DBm_SImage();
    }

    //public class ValSet
    //{
    //    public bool  defined = false;
    //}

    //public class DB_Int64 : ValSet
    //{
    //    private long m_val = 0;
    //    public long val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_Int32 : ValSet
    //{
    //    private int m_val = 0;
    //    public int val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_max : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_2000 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_264 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_250 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_50 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_45 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_32 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_25 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_10 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varchar_5 : ValSet
    //{
    //    private string m_val = "";
    //    public string val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    
    //public class DB_DateTime : ValSet
    //{
    //    private DateTime m_val = DateTime.MinValue;
    //    public DateTime val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_smallInt : ValSet
    //{
    //    private short m_val = 0;
    //    public short val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_bit : ValSet
    //{
    //    private bool m_val = false;
    //    public bool val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_varbinary_max : ValSet
    //{
    //    private Byte[] m_val = new Byte[1] { 0 };
    //    public Byte[] val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class DB_Money : ValSet
    //{
    //    private decimal m_val = new decimal();
    //    public decimal val
    //    {
    //        get { return m_val; }

    //        set
    //        {
    //            m_val = value;
    //            this.defined = true;
    //        }
    //    }
    //}

    //public class ID : DB_Int64
    //{
    //}

    //public class DBtypes 
    //{
    //    public DB_Int32 DB_Int32 = new DB_Int32();
    //    public DB_Int64 DB_Int64 = new DB_Int64();
    //    public DB_varchar_max DB_varchar_max = new DB_varchar_max();
    //    public DB_varchar_2000 DB_varchar_2000 = new DB_varchar_2000();
    //    public DB_varchar_264 DB_varchar_264 = new DB_varchar_264();
    //    public DB_varchar_250 DB_varchar_250 = new DB_varchar_250();
    //    public DB_varchar_50 DB_varchar_50 = new DB_varchar_50();
    //    public DB_varchar_45 DB_varchar_45 = new DB_varchar_45();
    //    public DB_varchar_32 DB_varchar_32 = new DB_varchar_32();
    //    public DB_varchar_25 DB_varchar_25 = new DB_varchar_25();
    //    public DB_varchar_10 DB_varchar_10 = new DB_varchar_10();
    //    public DB_varchar_5 DB_varchar_5 = new DB_varchar_5();
    //    public DB_DateTime DB_DateTime = new DB_DateTime();
    //    public DB_smallInt DB_smallInt = new DB_smallInt();
    //    public DB_bit DB_bit = new DB_bit();
    //    public DB_varbinary_max DB_varbinary_max = new DB_varbinary_max();
    //    public DB_Money DB_Money = new DB_Money();
    //}
    //public static class DBtypesFunc
    //{

    //    public const string ImageStoreName = "Func.ImageStore";
    //    public static ImageStore ImageStore = new ImageStore();

    //    public static bool MSSQL_DataBaseType(ref string sMSSQL_type, Type objType, Type baseType, Type myDBTypes, ref string csError)
    //    {
    //        FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //        int i;
    //        int iCount = DBTypesInfo.Count();
    //        for (i = 0; i < iCount; i++)
    //        {

    //            if (DBTypesInfo[i].FieldType == baseType)
    //            {
    //                if (baseType == typeof(DB_Int32))
    //                {
    //                    sMSSQL_type = "[int]";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_Int64))
    //                {
    //                    sMSSQL_type = "[bigint]";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_smallInt))
    //                {
    //                    sMSSQL_type = "[int]";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_bit))
    //                {
    //                    sMSSQL_type = "[bit]";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_DateTime))
    //                {
    //                    sMSSQL_type = "[datetime]";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                {
    //                    sMSSQL_type = "[varbinary](MAX)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_264))
    //                {
    //                    sMSSQL_type = "[nvarchar](264)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_50))
    //                {
    //                    sMSSQL_type = "[nvarchar](50)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_45))
    //                {
    //                    sMSSQL_type = "[nvarchar](45)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_32))
    //                {
    //                    sMSSQL_type = "[nvarchar](32)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_25))
    //                {
    //                    sMSSQL_type = "[nvarchar](25)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_10))
    //                {
    //                    sMSSQL_type = "[nvarchar](10)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_5))
    //                {
    //                    sMSSQL_type = "[nvarchar](5)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_2000))
    //                {
    //                    sMSSQL_type = "[nvarchar](2000)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_varchar_max))
    //                {
    //                    sMSSQL_type = "[nvarchar](MAX)";
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_Money))
    //                {
    //                    sMSSQL_type = "[money]";
    //                    return true;
    //                }
    //                else
    //                {
    //                    sMSSQL_type = "!! ERROR NOT IMPLEMENTED BASIC TYPE IN FUNCTION bool DBTypes.MSSQL_DataBaseType(ref string sMSSQL_type, Type objType, Type baseType,Type myDBTypes, ref string csError)!!";
    //                    csError = sMSSQL_type + " type = " + baseType.ToString();
    //                    return false;
    //                }
    //            }
    //        }
    //        string tableName = objType.ToString();
    //        int ij = tableName.IndexOf('.');
    //        if (ij >= 0)
    //        {
    //            tableName = tableName.Substring(ij + 1);
    //        }
    //        csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")" +
    //                  "\r\n or basic type " + baseType.ToString() + " is not type (field) in DBTypes class!";
    //        return false;
    //    }

    //    public static string GetBasicType(object obj)
    //    {
    //        //MemberInfo[] myMemberInfo;
    //        Type objType = obj.GetType();
    //        Type baseType = objType.BaseType;
    //        DBtypes DBtypes = new DBtypes();
    //        Type myDBTypes = DBtypes.GetType();

    //        if (baseType != null)
    //        {
    //            FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //            int i;
    //            int iCount = DBTypesInfo.Count();
    //            for (i = 0; i < iCount; i++)
    //            {
    //                if (DBTypesInfo[i].FieldType == baseType)
    //                {
    //                    if (baseType == typeof(DB_Int32))
    //                    {
    //                        return "[int]";
    //                    }
    //                    else if (baseType == typeof(DB_Int64))
    //                    {
    //                        return "[bigint]";
    //                    }
    //                    else if (baseType == typeof(DB_Money))
    //                    {
    //                        return "[money]";
    //                    }
    //                    else if (baseType == typeof(DB_smallInt))
    //                    {
    //                        return "[int]";
    //                    }
    //                    else if (baseType == typeof(DB_bit))
    //                    {
    //                        return "[bit]";
    //                    }
    //                    else if (baseType == typeof(DB_DateTime))
    //                    {
    //                        return "[datetime]";
    //                    }
    //                    else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                    {
    //                        return "[varbinary](MAX)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_max))
    //                    {
    //                        return "[nvarchar](MAX)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_2000))
    //                    {
    //                        return "[nvarchar](2000)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_264))
    //                    {
    //                        return "[nvarchar](264)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_250))
    //                    {
    //                        return "[nvarchar](250)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_50))
    //                    {
    //                        return "[nvarchar](50)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_45))
    //                    {
    //                        return "[nvarchar](45)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_32))
    //                    {
    //                        return "[nvarchar](32)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_25))
    //                    {
    //                        return "[nvarchar](25)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_10))
    //                    {
    //                        return "[nvarchar](10)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_5))
    //                    {
    //                        return "[nvarchar](5)";
    //                    }
    //                    else
    //                    {
    //                        return "!! NOT BASIC TYPE !!";
    //                    }
    //                }
    //            }
    //            string tableName = objType.ToString();
    //            int ij = tableName.IndexOf('.');
    //            if (ij >= 0)
    //            {
    //                tableName = tableName.Substring(ij + 1);
    //            }

    //            string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
    //            Error.Show(csError, "Program Error!");
    //            return csError;
    //        }
    //        else
    //        {
    //            return "ERROR !!! NO base Type !!!";
    //        }
    //    }

    //    public static bool IsBasicType(object obj)
    //    {
    //        //MemberInfo[] myMemberInfo;
    //        Type objType = obj.GetType();
    //        Type baseType = objType.BaseType;
    //        DBtypes DBtypes = new DBtypes();
    //        Type myDBTypes = DBtypes.GetType();

    //        if (baseType != null)
    //        {
    //            FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //            int i;
    //            int iCount = DBTypesInfo.Count();
    //            for (i = 0; i < iCount; i++)
    //            {
    //                if (DBTypesInfo[i].FieldType == baseType)
    //                {
    //                    if (baseType == typeof(DB_Int32))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_Int64))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_Money))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_smallInt))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_bit))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_DateTime))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_max))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_2000))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_250))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_50))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_45))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_32))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_25))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_10))
    //                    {
    //                        return true;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_5))
    //                    {
    //                        return true;
    //                    }
    //                    else
    //                    {
    //                        return false;
    //                    }
    //                }
    //            }
    //            return false;
    //            //string tableName = objType.ToString();
    //            //int ij = tableName.IndexOf('.');
    //            //if (ij >= 0)
    //            //{
    //            //    tableName = tableName.Substring(ij + 1);
    //            //}

    //            //string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
    //            //Error.Show(csError, "Program Error!");
    //            //return false;
    //        }
    //        else
    //        {
    //            //string csError = "ERROR !!! NO base Type !!!";
    //            //Error.Show(csError, "Program Error!");
    //            return false;
    //        }
    //    }

    //    public static int GetBasicTypeLengthMySQL(object obj)
    //    {
    //        //MemberInfo[] myMemberInfo;
    //        Type objType = obj.GetType();
    //        Type baseType = objType.BaseType;
    //        DBtypes DBtypes = new DBtypes();
    //        Type myDBTypes = DBtypes.GetType();

    //        if (baseType != null)
    //        {
    //            FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //            int i;
    //            int iCount = DBTypesInfo.Count();
    //            for (i = 0; i < iCount; i++)
    //            {
    //                if (DBTypesInfo[i].FieldType == baseType)
    //                {
    //                    if (baseType == typeof(DB_Int32))
    //                    {
    //                        return -1;
    //                    }
    //                    else if (baseType == typeof(DB_Int64))
    //                    {
    //                        return -1;
    //                    }
    //                    else if (baseType == typeof(DB_Money))
    //                    {
    //                        return -1;
    //                    }
    //                    else if (baseType == typeof(DB_smallInt))
    //                    {
    //                        return -1;
    //                    }
    //                    else if (baseType == typeof(DB_bit))
    //                    {
    //                        return -1;
    //                    }
    //                    else if (baseType == typeof(DB_DateTime))
    //                    {
    //                        return -1;
    //                    }
    //                    else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                    {
    //                        return 200;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_max))
    //                    {
    //                        return 200;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_2000))
    //                    {
    //                        return 200;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_264))
    //                    {
    //                        return 200;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_250))
    //                    {
    //                        return 250;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_50))
    //                    {
    //                        return 50;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_45))
    //                    {
    //                        return 45;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_32))
    //                    {
    //                        return 32;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_25))
    //                    {
    //                        return 25;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_10))
    //                    {
    //                        return 10;
    //                    }
    //                    else if (baseType == typeof(DB_varchar_5))
    //                    {
    //                        return 5;
    //                    }
    //                    else
    //                    {
    //                        return -1;
    //                    }
    //                }
    //            }
    //            //string tableName = objType.ToString();
    //            //int ij = tableName.IndexOf('.');
    //            //if (ij >= 0)
    //            //{
    //            //    tableName = tableName.Substring(ij + 1);
    //            //}

    //            //string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
    //            //Error.Show(csError, "Program Error!");
    //            return -1;
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }

    //    public static string GetBasicTypeMySQL(object obj)
    //    {
    //        //MemberInfo[] myMemberInfo;
    //        Type objType = obj.GetType();
    //        Type baseType = objType.BaseType;
    //        DBtypes DBtypes = new DBtypes();
    //        Type myDBTypes = DBtypes.GetType();

    //        if (baseType != null)
    //        {
    //            FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //            int i;
    //            int iCount = DBTypesInfo.Count();
    //            for (i = 0; i < iCount; i++)
    //            {
    //                if (DBTypesInfo[i].FieldType == baseType)
    //                {
    //                    if (baseType == typeof(DB_Int32))
    //                    {
    //                        return "int(11)";
    //                    }
    //                    else if (baseType == typeof(DB_Int64))
    //                    {
    //                        return "bigint(20)";
    //                    }
    //                    else if (baseType == typeof(DB_Money))
    //                    {
    //                        return "DECIMAL(13,2)";
    //                    }
    //                    else if (baseType == typeof(DB_smallInt))
    //                    {
    //                        return "smallint(6)";
    //                    }
    //                    else if (baseType == typeof(DB_bit))
    //                    {
    //                        return "tinyint(1)";
    //                    }
    //                    else if (baseType == typeof(DB_DateTime))
    //                    {
    //                        return "datetime";
    //                    }
    //                    else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                    {
    //                        return "LONGBLOB";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_max))
    //                    {
    //                        return "varchar(21000)  ";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_2000))
    //                    {
    //                        return "varchar(2000)  CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_264))
    //                    {
    //                        return "varchar(264) CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_250))
    //                    {
    //                        return "varchar(250) CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_50))
    //                    {
    //                        return "varchar(50)  CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_45))
    //                    {
    //                        return "varchar(45) CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_32))
    //                    {
    //                        return "varchar(32) CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_25))
    //                    {
    //                        return "varchar(25) CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_10))
    //                    {
    //                        return "varchar(10) CHARSET utf8";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_5))
    //                    {
    //                        return "varchar(5) CHARSET utf8";
    //                    }
    //                    else
    //                    {
    //                        return "!! NOT BASIC TYPE !!";
    //                    }
    //                }
    //            }
    //            string tableName = objType.ToString();
    //            int ij = tableName.IndexOf('.');
    //            if (ij >= 0)
    //            {
    //                tableName = tableName.Substring(ij + 1);
    //            }

    //            string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
    //            Error.Show(csError, "Program Error!");
    //            return csError;
    //        }
    //        else
    //        {
    //            return "ERROR !!! NO base Type !!!";
    //        }
    //    }
    //    public static string GetBasicTypeSQLite(Object obj)
    //    {
    //        //MemberInfo[] myMemberInfo;
    //        Type objType = obj.GetType();
    //        Type baseType = objType.BaseType;
    //        DBtypes DBtypes = new DBtypes();
    //        Type myDBTypes = DBtypes.GetType();

    //        if (baseType != null)
    //        {
    //            FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //            int i;
    //            int iCount = DBTypesInfo.Count();
    //            for (i = 0; i < iCount; i++)
    //            {
    //                if (DBTypesInfo[i].FieldType == baseType)
    //                {
    //                    if (baseType == typeof(DB_Int32))
    //                    {
    //                        return "INT";
    //                    }
    //                    else if (baseType == typeof(DB_Int64))
    //                    {
    //                        return "INTEGER";
    //                    }
    //                    else if (baseType == typeof(DB_Money))
    //                    {
    //                        return "DECIMAL(10,5)";
    //                    }
    //                    else if (baseType == typeof(DB_smallInt))
    //                    {
    //                        return "INT";
    //                    }
    //                    else if (baseType == typeof(DB_bit))
    //                    {
    //                        return "BIT";
    //                    }
    //                    else if (baseType == typeof(DB_DateTime))
    //                    {
    //                        return "DATETIME";
    //                    }
    //                    else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                    {
    //                        return "BLOB";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_max))
    //                    {
    //                        return "TEXT";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_2000))
    //                    {
    //                        return "varchar(2000)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_264))
    //                    {
    //                        return "varchar(264)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_250))
    //                    {
    //                        return "varchar(250)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_50))
    //                    {
    //                        return "varchar(50)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_45))
    //                    {
    //                        return "varchar(45)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_32))
    //                    {
    //                        return "varchar(32)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_25))
    //                    {
    //                        return "varchar(25)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_10))
    //                    {
    //                        return "varchar(10)";
    //                    }
    //                    else if (baseType == typeof(DB_varchar_5))
    //                    {
    //                        return "varchar(5)";
    //                    }
    //                    else
    //                    {
    //                        return "!! NOT BASIC TYPE !!";
    //                    }
    //                }
    //            }
    //            string tableName = objType.ToString();
    //            int ij = tableName.IndexOf('.');
    //            if (ij >= 0)
    //            {
    //                tableName = tableName.Substring(ij + 1);
    //            }

    //            string csError = "Program Error !!! NO DB Basic Types Found !!!\n Posible cause of this error is  that table of type:" + objType.ToString() + " is not added to m_DBTables.items.\n There is no source line in \"MyDataBase.TableDefinitions.cs\"\n with :m_DBTables.items.Add(tbl_" + tableName + ")";
    //            LogFile.Error.Show(csError, "Program Error!");
    //            return csError;
    //        }
    //        else
    //        {
    //            return "ERROR !!! NO base Type !!!";
    //        }
    //    }


    //    public static Type BasicType(Type baseType, Type myDBTypes, ref string csError)
    //    {
    //        FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //        int i;
    //        int iCount = DBTypesInfo.Count();
    //        for (i = 0; i < iCount; i++)
    //        {
    //            if (DBTypesInfo[i].FieldType == baseType)
    //            {
    //                if (baseType == typeof(DB_Int32))
    //                {
    //                    return typeof(DB_Int32);
    //                }
    //                else if (baseType == typeof(DB_Int64))
    //                {
    //                    return typeof(DB_Int64);
    //                }
    //                else if (baseType == typeof(DB_smallInt))
    //                {
    //                    return typeof(DB_smallInt);
    //                }
    //                else if (baseType == typeof(DB_bit))
    //                {
    //                    return typeof(DB_bit);
    //                }
    //                else if (baseType == typeof(DB_DateTime))
    //                {
    //                    return typeof(DB_DateTime);
    //                }
    //                else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                {
    //                    return typeof(DBTypes.DB_varbinary_max);
    //                }
    //                else if (baseType == typeof(DB_varchar_264))
    //                {
    //                    return typeof(DB_varchar_264);
    //                }
    //                else if (baseType == typeof(DB_varchar_250))
    //                {
    //                    return typeof(DB_varchar_250);
    //                }
    //                else if (baseType == typeof(DB_varchar_50))
    //                {
    //                    return typeof(DB_varchar_50);
    //                }
    //                else if (baseType == typeof(DB_varchar_45))
    //                {
    //                    return typeof(DB_varchar_45);
    //                }
    //                else if (baseType == typeof(DB_varchar_32))
    //                {
    //                    return typeof(DB_varchar_32);
    //                }
    //                else if (baseType == typeof(DB_varchar_25))
    //                {
    //                    return typeof(DB_varchar_25);
    //                }
    //                else if (baseType == typeof(DB_varchar_10))
    //                {
    //                    return typeof(DB_varchar_10);
    //                }
    //                else if (baseType == typeof(DB_varchar_5))
    //                {
    //                    return typeof(DB_varchar_5);
    //                }
    //                else if (baseType == typeof(DB_varchar_2000))
    //                {
    //                    return typeof(DB_varchar_2000);
    //                }
    //                else if (baseType == typeof(DB_varchar_max))
    //                {
    //                    return typeof(DB_varchar_max);
    //                }
    //                else if (baseType == typeof(DB_Money))
    //                {
    //                    return typeof(DB_Money);
    //                }
    //                else
    //                {
    //                    csError = "Basic type " + baseType.ToString() + " is not implemented in function DBTypes.BasicType(Type baseType, Type myDBTypes, ref string csError)";
    //                    return null;
    //                }
    //            }
    //        }
    //        csError = "Basic type " + baseType.ToString() + " is not type (field) in DBTypes class!";
    //        return null;
    //    }

    //    public static bool IsNumber(Type baseType, Type myDBTypes, ref string csError)
    //    {
    //        FieldInfo[] DBTypesInfo = myDBTypes.GetFields();
    //        int i;
    //        int iCount = DBTypesInfo.Count();
    //        for (i = 0; i < iCount; i++)
    //        {
    //            if (DBTypesInfo[i].FieldType == baseType)
    //            {
    //                if (baseType == typeof(DB_Int32))
    //                {
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_Int64))
    //                {
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_smallInt))
    //                {
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_bit))
    //                {
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_Money))
    //                {
    //                    return true;
    //                }
    //                else if (baseType == typeof(DB_DateTime))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DBTypes.DB_varbinary_max))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_264))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_50))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_45))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_32))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_25))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_10))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_5))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_2000))
    //                {
    //                    return false;
    //                }
    //                else if (baseType == typeof(DB_varchar_max))
    //                {
    //                    return false;
    //                }
    //                else
    //                {
    //                    csError = "Basic type " + baseType.ToString() + " not implemented in function DBTypes.IsNumberIsNumber(Type baseType, Type myDBTypes, ref string csError)";
    //                    return false;
    //                }
    //            }
    //        }
    //        csError = "Basic type " + baseType.ToString() + " is not type (field) in DBTypes class!";
    //        return false;
    //    }



    //    public static bool SetObjValue(ref object obj, Type type, ref string sAction, string Value, ref string csError)
    //    {
    //        try
    //        {
    //            if (type == typeof(DB_Int32))
    //            {
    //                sAction = "DB_Int32";

    //                DB_Int32 xDBInt = (DB_Int32)obj;
    //                xDBInt.val = Convert.ToInt32(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_Int64))
    //            {
    //                sAction = "DB_Int64";

    //                DB_Int64 xDBlong = (DB_Int64)obj;
    //                xDBlong.val = Convert.ToInt64(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_Money))
    //            {
    //                sAction = "DB_Money";
    //                DB_Money xDB_Money = (DB_Money)obj;
    //                xDB_Money.val = Convert.ToDecimal(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_smallInt))
    //            {
    //                sAction = "DB_smallInt";
    //                DB_smallInt xDB_smallInt = (DB_smallInt)obj;
    //                xDB_smallInt.val = Convert.ToInt16(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_bit))
    //            {
    //                sAction = "DB_bit";
    //                if (Value.Length == 1)
    //                {
    //                    if (Value[0] == 'M')
    //                    {
    //                        Value = "true";
    //                    }
    //                    else if (Value[0] == 'Ž')
    //                    {
    //                        Value = "false";
    //                    }
    //                    else if (Value[0] == 'F')
    //                    {
    //                        Value = "false";
    //                    }
    //                    else if (Value[0] == '1')
    //                    {
    //                        Value = "true";
    //                    }
    //                    else if (Value[0] == '0')
    //                    {
    //                        Value = "false";
    //                    }
    //                }
    //                DB_bit xDB_bit = (DB_bit)obj;
    //                xDB_bit.val = Convert.ToBoolean(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_DateTime))
    //            {
    //                sAction = "DB_DateTime";
    //                DB_DateTime xDB_DateTime = (DB_DateTime)obj;
    //                //if (Value.Length == 0)
    //                //{
    //                //    this.SetType = ValueSetTYPE.SET_NOTHING;
    //                //    return true;
    //                //}

    //                xDB_DateTime.val = Convert.ToDateTime(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varbinary_max))
    //            {
    //                sAction = "DB_varbinary_max";
    //                DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)obj;
    //                if (ImageStore.IsName(Value))
    //                {
    //                    if (ImageStore != null)
    //                    {
    //                        xDB_varbinary_max.val = imageToByteArray(ImageStore.Get(Value));
    //                        return true;
    //                    }

    //                    csError = lng.s_ErrorNoImage.s;
    //                    return false;
    //                }
    //                else
    //                {
    //                    if (File.Exists(Value))
    //                    {
    //                        xDB_varbinary_max.val = File.ReadAllBytes(Value);
    //                        return true;
    //                    }
    //                    else
    //                    {
    //                        xDB_varbinary_max.val = null;
    //                        //sTxt.ShowParseError(lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                        csError = lng.s_File.s + ":\"" + Value + "\"" + lng.s_File_does_not_exist.s;
    //                        return false;
    //                    }
    //                }
    //            }
    //            else if (type == typeof(DB_varchar_264))
    //            {
    //                sAction = "DB_varchar_264";
    //                DB_varchar_264 xDB_varchar_264 = (DB_varchar_264)obj;
    //                xDB_varchar_264.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_50))
    //            {
    //                sAction = "DB_varchar_50";
    //                DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)obj;
    //                xDB_varchar_50.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_45))
    //            {
    //                sAction = "DB_varchar_45";
    //                DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)obj;
    //                xDB_varchar_45.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_32))
    //            {
    //                sAction = "DB_varchar_32";
    //                DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)obj;
    //                xDB_varchar_32.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_25))
    //            {
    //                sAction = "DB_varchar_25";
    //                DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)obj;
    //                xDB_varchar_25.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_10))
    //            {
    //                sAction = "DB_varchar_10";
    //                DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)obj;
    //                xDB_varchar_10.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_5))
    //            {
    //                sAction = "DB_varchar_5";
    //                DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)obj;
    //                xDB_varchar_5.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_2000))
    //            {
    //                sAction = "DB_varchar_2000";
    //                DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)obj;
    //                xDB_varchar_2000.val = Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_max))
    //            {

    //                sAction = "DB_varchar_max";
    //                DB_varchar_max xDB_varchar_max = (DB_varchar_max)obj;
    //                xDB_varchar_max.val = Value;
    //                return true;
    //            }
    //            else
    //            {
    //                //sTxt.ShowParseError(lng.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                csError = lng.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value;
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            //sTxt.ShowParseError(lng.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            csError = lng.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message;
    //            return false;
    //        }

    //    }

    //    public static bool SetValue(ref object col_obj, object Value, ref string csError)
    //    {
    //        try
    //        {
    //            Type type = col_obj.GetType().BaseType;

    //            if (type == typeof(DB_Int32))
    //            {
    //                ((DB_Int32)col_obj).val = Convert.ToInt32(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_Int64))
    //            {
    //                ((DB_Int64)col_obj).val = Convert.ToInt64(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_Money))
    //            {
    //                ((DB_Money)col_obj).val = Convert.ToDecimal(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_smallInt))
    //            {
    //                ((DB_smallInt)col_obj).val = Convert.ToInt16(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_bit))
    //            {
    //                ((DB_bit)col_obj).val = Convert.ToBoolean(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_DateTime))
    //            {
    //                ((DB_DateTime)col_obj).val = Convert.ToDateTime(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varbinary_max))
    //            {
    //                ((DB_varbinary_max)col_obj).val = (byte[]) Value;
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_264))
    //            {
    //                ((DB_varchar_264)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_250))
    //            {
    //                ((DB_varchar_250)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_50))
    //            {
    //                ((DB_varchar_50)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_45))
    //            {
    //                ((DB_varchar_45)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_32))
    //            {
    //                ((DB_varchar_32)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_25))
    //            {
    //                ((DB_varchar_25)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_10))
    //            {
    //                ((DB_varchar_10)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_5))
    //            {
    //                ((DB_varchar_5)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_2000))
    //            {
    //                ((DB_varchar_2000)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else if (type == typeof(DB_varchar_max))
    //            {
    //                ((DB_varchar_max)col_obj).val = Convert.ToString(Value);
    //                return true;
    //            }
    //            else
    //            {
    //                //sTxt.ShowParseError(lng.s_UnsuportedType.s + " " + obj.GetType().ToString() + " : " + Value, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                csError = lng.s_UnsuportedType.s + " " + col_obj.GetType().ToString() + " : " + Value;
    //                return false;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            //sTxt.ShowParseError(lng.s_Illegal_format_for.s + " " + sAction + ": " + Value + "\r\n " + ex.Message, lng.s_Error.s, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            csError = lng.s_Illegal_format_for.s + " : " + Value + "\r\n " + ex.Message;
    //            return false;
    //        }

    //    }

    //    public static byte[] imageToByteArray(System.Drawing.Image imageIn)
    //    {
    //        MemoryStream ms = new MemoryStream();
    //        imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
    //        return ms.ToArray();
    //    }


    //    public static string DbValueForSql(ref Object obj, Type baseType, string sThisVar, ref List<SQL_Parameter> lsqlPar, string Name)
    //    {
    //        if (baseType == typeof(DB_Int32))
    //        {
    //            DB_Int32 xDB_int = (DB_Int32)obj;
    //            return xDB_int.val.ToString();
    //        }
    //        else if (baseType == typeof(DB_Int64))
    //        {
    //            DB_Int64 xDB_long = (DB_Int64)obj;
    //            return xDB_long.val.ToString();
    //        }
    //        else if (baseType == typeof(DB_Money))
    //        {
    //            DB_Money xDB_Money = (DB_Money)obj;
    //            return xDB_Money.val.ToString();
    //        }
    //        else if (baseType == typeof(DB_smallInt))
    //        {
    //            DB_smallInt xDB_smallInt = (DB_smallInt)obj;
    //            return xDB_smallInt.val.ToString();
    //        }
    //        else if (baseType == typeof(DB_bit))
    //        {
    //            DB_bit xDB_bit = (DB_bit)obj;
    //            if (xDB_bit.val)
    //            {
    //                return "1";
    //            }
    //            else
    //            {
    //                return "0";
    //            }
    //            //return xDB_bit.val.ToString();
    //        }
    //        else if (baseType == typeof(DB_DateTime))
    //        {
    //            DB_DateTime xDB_DateTime = (DB_DateTime)obj;
    //            SQL_Parameter sqlPar = new SQL_Parameter();
    //            sqlPar.dbType = System.Data.SqlDbType.DateTime;
    //            string sPar = "@Par_" + sThisVar + "_" + Name;
    //            sqlPar.Name = sPar;
    //            sqlPar.size = -1;
    //            sqlPar.Value = xDB_DateTime.val;
    //            lsqlPar.Add(sqlPar);
    //            return sPar;

    //        }
    //        else if (baseType == typeof(DB_varbinary_max))
    //        {
    //            DB_varbinary_max xDB_varbinary_max = (DB_varbinary_max)obj;
    //            if (xDB_varbinary_max.val != null)
    //            {
    //                string sPar = "@Par_" + sThisVar + "_" + Name;
    //                SQL_Parameter sqlPar = new SQL_Parameter();
    //                sqlPar.dbType = System.Data.SqlDbType.VarBinary;
    //                sqlPar.Name = sPar;
    //                sqlPar.size = xDB_varbinary_max.val.Count();
    //                sqlPar.Value = xDB_varbinary_max.val;
    //                lsqlPar.Add(sqlPar);
    //                return sPar;
    //            }
    //            else
    //            {
    //                return "NULL";
    //            }
    //        }
    //        else if (baseType == typeof(DB_varchar_264))
    //        {
    //            DB_varchar_264 xDB_varchar_264 = (DB_varchar_264)obj;

    //            return SetParString(xDB_varchar_264.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_250))
    //        {
    //            DB_varchar_250 xDB_varchar_250 = (DB_varchar_250)obj;
    //            return SetParString(xDB_varchar_250.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_50))
    //        {
    //            DB_varchar_50 xDB_varchar_50 = (DB_varchar_50)obj;
    //            return SetParString(xDB_varchar_50.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_45))
    //        {
    //            DB_varchar_45 xDB_varchar_45 = (DB_varchar_45)obj;
    //            return SetParString(xDB_varchar_45.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_32))
    //        {
    //            DB_varchar_32 xDB_varchar_32 = (DB_varchar_32)obj;
    //            return SetParString(xDB_varchar_32.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_25))
    //        {
    //            DB_varchar_25 xDB_varchar_25 = (DB_varchar_25)obj;
    //            return SetParString(xDB_varchar_25.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_10))
    //        {
    //            DB_varchar_10 xDB_varchar_10 = (DB_varchar_10)obj;
    //            return SetParString(xDB_varchar_10.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_5))
    //        {
    //            DB_varchar_5 xDB_varchar_5 = (DB_varchar_5)obj;
    //            return SetParString(xDB_varchar_5.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_2000))
    //        {
    //            DB_varchar_2000 xDB_varchar_2000 = (DB_varchar_2000)obj;
    //            return SetParString(xDB_varchar_2000.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else if (baseType == typeof(DB_varchar_max))
    //        {
    //            DB_varchar_max xDB_varchar_max = (DB_varchar_max)obj;
    //            return SetParString(xDB_varchar_max.val, lsqlPar, "@Par_" + sThisVar + "_" + Name);
    //        }
    //        else
    //        {
    //            return "ERROR in DbValueForSql ";
    //        }
    //    }

    //    private static string SetParString(string sValue, List<SQL_Parameter> lsqlPar, string sPar)
    //    {
    //        SQL_Parameter sqlPar = new SQL_Parameter();
    //        sqlPar.dbType = System.Data.SqlDbType.NVarChar;
    //        sqlPar.Name = sPar;
    //        sqlPar.size = -1;
    //        sqlPar.Value = sValue;
    //        lsqlPar.Add(sqlPar);
    //        return sPar;
    //    }

    //    internal static bool IsMyBaseType(Type baseType)
    //    {
    //        return ((baseType == typeof(DB_Int32))||
    //                (baseType == typeof(DB_Int64))||
    //                (baseType == typeof(DB_Money))||
    //                (baseType == typeof(DB_smallInt))||
    //                (baseType == typeof(DB_bit))||
    //                (baseType == typeof(DB_DateTime))||
    //                (baseType == typeof(DB_varbinary_max))||
    //                (baseType == typeof(DB_varchar_264))||
    //                (baseType == typeof(DB_varchar_250))||
    //                (baseType == typeof(DB_varchar_50))||
    //                (baseType == typeof(DB_varchar_45))||
    //                (baseType == typeof(DB_varchar_32))||
    //                (baseType == typeof(DB_varchar_25))||
    //                (baseType == typeof(DB_varchar_10))||
    //                (baseType == typeof(DB_varchar_5))||
    //                (baseType == typeof(DB_varchar_2000))||
    //                (baseType == typeof(DB_varchar_max)));

    //    }

    //    public static bool IsValueDefined(object obj)
    //    {
    //        Type baseType = obj.GetType().BaseType;
    //        if (IsMyBaseType(baseType))
    //        {
    //            ValSet vs = (ValSet)obj;
    //            return vs.defined;
    //        }
    //        else
    //        {

    //            return false;
    //        }
    //    }

    //    public static void ID_Is_Defined(object obj)
    //    {
    //        Type baseType = obj.GetType().BaseType;
    //        if (IsMyBaseType(baseType))
    //        {
    //            ValSet vs = (ValSet)obj;
    //            vs.defined = true;
    //        }
    //    }

    //}

    //public class e3pImage
    //{
    //    public string Name;
    //    public Image Image;
    //}

    //public class ImageStore
    //{
    //    const string const_IMAGE_STORE_ = "IMAGE_STORE_";
    //    public List<e3pImage> items = new List<e3pImage>();

    //    public string Insert(Image xImage)
    //    {
    //        string newname = UniqueNames.GetName(this, const_IMAGE_STORE_);
    //        e3pImage e3pi = new e3pImage();
    //        e3pi.Name = newname;
    //        e3pi.Image = xImage;
    //        items.Add(e3pi);
    //        return newname;
    //    }

    //    public Image Get(string xName)
    //    {
    //        int i = 0;
    //        int iCount;
    //        iCount = items.Count;
    //        for (i = 0; i < iCount; i++)
    //        {
    //            e3pImage e3pi = items[i];
    //            if (e3pi.Name.Equals(xName))
    //            {
    //                Image Img = (Image)e3pi.Image.Clone();
    //                items.RemoveAt(i);
    //                return Img;
    //            }
    //        }
    //        return null;
    //    }


    //    public bool IsName(string Value)
    //    {
    //        if (Value.Contains(const_IMAGE_STORE_))
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}
}






