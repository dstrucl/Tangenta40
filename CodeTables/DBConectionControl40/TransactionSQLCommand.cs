using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionControl40
{
    public class TransactionSQLCommand
    {
        private string m_SQLtext = null;
        public string SQLtext
        {
            get
            {
                return m_SQLtext;
            }
            set
            {
                m_SQLtext = value;
            }
        }

        private ID m_idnew = null;

        public ID IDnew
        {
            get
            {
                return m_idnew;
            }
        }

        private bool m_result = false;
        public bool Result
        {
            get
            {
                return m_result;
            }
        }

        private string m_Error = null;
        public string Error
        {
            get
            {
                return m_Error;
            }
        }


        public List<p_Int> p_Int_list = null;
        public List<p_Decimal> p_Decimal_list = null;
        public List<p_Float> p_Float_list = null;
        public List<p_Bit> p_Bit_list = null;
        public List<p_DateTime> p_DateTime_list = null;
        public List<p_NVarChar> p_NvarChar_list = null;
        public List<p_VarChar> p_VarChar_list = null;
        public List<p_NChar> p_NChar_list = null;
        public List<p_BigInt> p_BigInt_list = null;
        public List<p_SmallInt> p_SmallInt_list = null;
        public List<p_VarBinary> p_VarBinary_list = null;


        public TransactionSQLCommand(string xSQLtext, List<SQL_Parameter> lpar, ID xidnew, bool bResult, string xerr)
        {
            m_SQLtext = xSQLtext;
            m_idnew = xidnew;
            m_result = bResult;
            m_Error = xerr;
            if (lpar!=null)
            {
                foreach (SQL_Parameter par in lpar)
                {
                    switch (par.dbType)
                    {
                        case System.Data.SqlDbType.Int:
                            p_Int xp_Int = new p_Int((int)par.Value, par.Name);
                            if (p_Int_list == null)
                            {
                                p_Int_list = new List<p_Int>();
                            }
                            p_Int_list.Add(xp_Int);
                            break;

                        case System.Data.SqlDbType.Decimal:
                            p_Decimal xp_Decimal = new p_Decimal((decimal)par.Value, par.Name);
                            if (p_Decimal_list == null)
                            {
                                p_Decimal_list = new List<p_Decimal>();
                            }
                            p_Decimal_list.Add(xp_Decimal);
                            break;

                        case System.Data.SqlDbType.Float:
                            p_Float xp_Float = new p_Float((float)par.Value, par.Name);
                            if (p_Float_list == null)
                            {
                                p_Float_list = new List<p_Float>();
                            }
                            p_Float_list.Add(xp_Float);
                            break;

                        case System.Data.SqlDbType.Bit:
                            p_Bit xp_Bit = new p_Bit((bool)par.Value, par.Name);
                            if (p_Bit_list == null)
                            {
                                p_Bit_list = new List<p_Bit>();
                            }
                            p_Bit_list.Add(xp_Bit);
                            break;

                        case System.Data.SqlDbType.DateTime:
                            p_DateTime xp_DateTime = new p_DateTime((DateTime)par.Value, par.Name);
                            if (p_DateTime_list == null)
                            {
                                p_DateTime_list = new List<p_DateTime>();
                            }
                            p_DateTime_list.Add(xp_DateTime);
                            break;

                        case System.Data.SqlDbType.NVarChar:
                            p_NVarChar xp_NVarChar = new p_NVarChar((string)par.Value, par.Name);
                            if (p_NvarChar_list == null)
                            {
                                p_NvarChar_list = new List<p_NVarChar>();
                            }
                            p_NvarChar_list.Add(xp_NVarChar);
                            break;

                        case System.Data.SqlDbType.VarChar:
                            p_VarChar xp_VarChar = new p_VarChar((string)par.Value, par.Name);
                            if (p_VarChar_list == null)
                            {
                                p_VarChar_list = new List<p_VarChar>();
                            }
                            p_VarChar_list.Add(xp_VarChar);
                            break;

                        case System.Data.SqlDbType.NChar:
                            p_NChar xp_NChar = new p_NChar((string)par.Value, par.Name);
                            if (p_NChar_list == null)
                            {
                                p_NChar_list = new List<p_NChar>();
                            }
                            p_NChar_list.Add(xp_NChar);
                            break;

                        case System.Data.SqlDbType.BigInt:
                            p_BigInt xp_BigInt = new p_BigInt((long)par.Value, par.Name);
                            if (p_BigInt_list == null)
                            {
                                p_BigInt_list = new List<p_BigInt>();
                            }
                            p_BigInt_list.Add(xp_BigInt);
                            break;

                        case System.Data.SqlDbType.SmallInt:
                            p_SmallInt xp_SmallInt = new p_SmallInt((short)par.Value, par.Name);
                            if (p_SmallInt_list == null)
                            {
                                p_SmallInt_list = new List<p_SmallInt>();
                            }
                            p_SmallInt_list.Add(xp_SmallInt);
                            break;

                        case System.Data.SqlDbType.VarBinary:
                            p_VarBinary xp_VarBinary = new p_VarBinary((byte[])par.Value, par.Name);
                            if (p_VarBinary_list == null)
                            {
                                p_VarBinary_list = new List<p_VarBinary>();
                            }
                            p_VarBinary_list.Add(xp_VarBinary);
                            break;
                    }
                }
            }
        }

        public class p_Int
        {
            private int m_V_Int32 = 0;
            public int V_Int32
            {
                get
                {
                    return m_V_Int32;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_Int(int xi, string xname)
            {
                m_V_Int32 = xi;
                m_Name = xname;

            }
        }

        public class p_Decimal
        {
            private decimal m_V_Decimal = 0;
            public decimal V_Decimal
            {
                get
                {
                    return m_V_Decimal;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_Decimal(decimal xmoney, string xname)
            {
                m_V_Decimal = xmoney;
                m_Name = xname;

            }
        }

        public class p_Float
        {
            private float m_V_Float = 0;
            public float V_Float
            {
                get
                {
                    return m_V_Float;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_Float(float xFloat, string xname)
            {
                m_V_Float = xFloat;
                m_Name = xname;

            }
        }

        public class p_Bit
        {
            private bool m_V_bool = false;
            public bool V_bool
            {
                get
                {
                    return m_V_bool;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_Bit(bool xi, string xname)
            {
                m_V_bool = xi;
                m_Name = xname;

            }
        }

        public class p_DateTime
        {
            private DateTime m_V_DateTime;
            public DateTime V_DateTime
            {
                get
                {
                    return m_V_DateTime;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_DateTime(DateTime xdatetime, string xname)
            {
                m_V_DateTime = xdatetime;
                m_Name = xname;

            }
        }

        public class p_NVarChar
        {
            private string m_V_NVarChar = null;
            public string V_NVarChar
            {
                get
                {
                    return m_V_NVarChar;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_NVarChar(string xNVarChar, string xname)
            {
                m_V_NVarChar = xNVarChar;
                m_Name = xname;

            }
        }

        public class p_VarChar
        {
            private string m_V_VarChar = null;
            public string V_VarChar
            {
                get
                {
                    return m_V_VarChar;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_VarChar(string xVarChar, string xname)
            {
                m_V_VarChar = xVarChar;
                m_Name = xname;

            }
        }

        public class p_NChar
        {
            private string m_V_NChar = null;
            public string V_NChar
            {
                get
                {
                    return m_V_NChar;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_NChar(string xNChar, string xname)
            {
                m_V_NChar = xNChar;
                m_Name = xname;

            }
        }

        public class p_BigInt
        {
            private long m_V_BigInt = 0;
            public long V_BigInt
            {
                get
                {
                    return m_V_BigInt;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_BigInt(long xi, string xname)
            {
                m_V_BigInt = xi;
                m_Name = xname;

            }
        }

        public class p_SmallInt
        {
            private short m_V_Int16 = 0;
            public short V_Int16
            {
                get
                {
                    return m_V_Int16;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_SmallInt(short xi, string xname)
            {
                m_V_Int16 = xi;
                m_Name = xname;

            }
        }


        public class p_VarBinary
        {
            private byte[] m_V_varbinary_max;
            public byte[] V_varbinary_max
            {
                get
                {
                    return m_V_varbinary_max;
                }
            }
            private string m_Name = null;
            public string Name
            {
                get
                {
                    return m_Name;
                }
            }
            public p_VarBinary(byte[] xbytearray, string xname)
            {
                m_V_varbinary_max = xbytearray;
                m_Name = xname;
            }
        }
    }
}
