using System;
using System.Collections.Generic;
using System.Data;
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
            set
            {
                m_idnew = value;
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

        private DateTime m_ExecutionStart = DateTime.MinValue;

        public DateTime ExecutionStart
        {
            get
            {
                return m_ExecutionStart;
            }
        }

        private DateTime m_ExecutionEnd = DateTime.MinValue;

        public DateTime ExecutionEnd
        {
            get
            {
                return m_ExecutionEnd;
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


        public TransactionSQLCommand(string xSQLtext, List<SQL_Parameter> lpar, ID xidnew,DateTime executionStart,DateTime executionEnd, bool bResult, string xerr)
        {
            m_SQLtext = xSQLtext;
            m_idnew = xidnew;
            m_ExecutionStart = executionStart;
            m_ExecutionEnd = executionEnd;
            m_result = bResult;
            m_Error = xerr;
            if (lpar!=null)
            {
                foreach (SQL_Parameter par in lpar)
                {
                    switch (par.dbType)
                    {
                        case System.Data.SqlDbType.Int:
                            if (par.Value is int)
                            {
                                p_Int xp_Int = new p_Int((int)par.Value, par.Name);
                                if (p_Int_list == null)
                                {
                                    p_Int_list = new List<p_Int>();
                                }
                                p_Int_list.Add(xp_Int);
                            }
                            else if (par.Value is ID)
                            {
                                if (((ID)par.Value).V is int)
                                {
                                    p_Int xp_Int = new p_Int((int)((ID)par.Value).V, par.Name);
                                    if (p_Int_list == null)
                                    {
                                        p_Int_list = new List<p_Int>();
                                    }
                                    p_Int_list.Add(xp_Int);
                                }
                            }
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
                            p_DateTime xp_DateTime = new p_DateTime(par.Value, par.Name);
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
                            if (par.Value is long)
                            {
                                p_BigInt xp_BigInt = new p_BigInt((long)par.Value, par.Name);
                                if (p_BigInt_list == null)
                                {
                                    p_BigInt_list = new List<p_BigInt>();
                                }
                                p_BigInt_list.Add(xp_BigInt);
                            }
                            else if (par.Value is ID)
                            {
                                if (((ID)par.Value).V is long)
                                {
                                    p_BigInt xp_BigInt = new p_BigInt((long)((ID)par.Value).V, par.Name);
                                    if (p_BigInt_list == null)
                                    {
                                        p_BigInt_list = new List<p_BigInt>();
                                    }
                                    p_BigInt_list.Add(xp_BigInt);
                                }
                            }
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

            public bool Get(Transaction transaction,ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction,this.m_Name,ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_Int= "@par_V_Int";
                    SQL_Parameter par_V_Int = new SQL_Parameter(spar_V_Int,SQL_Parameter.eSQL_Parameter.Int,false, this.V_Int32);
                    lpar.Add(par_V_Int);
                    string sql = "insert into P_Int (SQLCommand_ID,ParameterName_ID,V_Int) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_Int + ")";
                    ID p_Int_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con,sql,lpar,ref p_Int_ID, ref err, "P_Int"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_Int:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
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

        private static bool GetParamterName_ID(Transaction transaction, string m_Name, ref ID paramterName_ID)
        {
            string err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Varchar, false, m_Name);
            lpar.Add(par_Name);
            string sql = "select ID from ParameterName where Name = " + spar_Name;
            DataTable dt = new DataTable();
            if (transaction.con.ReadDataTable(ref dt,sql, lpar,ref err))
            {
                if (dt.Rows.Count>0)
                {
                    paramterName_ID = new ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into ParameterName (Name) values (" + spar_Name+")";
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref paramterName_ID, ref err, "ParameterName"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:GetParamterName_ID:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:GetParamterName_ID:Error=" + err + "\r\nsql=" + sql);
                return false;
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

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_Decimal = "@par_V_Decimal";
                    SQL_Parameter par_V_Decimal = new SQL_Parameter(spar_V_Decimal, SQL_Parameter.eSQL_Parameter.Decimal, false, this.V_Decimal);
                    lpar.Add(par_V_Decimal);
                    string sql = "insert into P_Decimal (SQLCommand_ID,ParameterName_ID,V_Decimal) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_Decimal + ")";
                    ID p_Decimal_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_Decimal_ID, ref err, "P_Decimal"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_Decimal:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_Float = "@par_V_Float";
                    SQL_Parameter par_V_Float = new SQL_Parameter(spar_V_Float, SQL_Parameter.eSQL_Parameter.Float, false, this.V_Float);
                    lpar.Add(par_V_Float);
                    string sql = "insert into P_Float (SQLCommand_ID,ParameterName_ID,V_Float) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_Float + ")";
                    ID p_Float_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_Float_ID, ref err, "P_Float"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_Float:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_Bit = "@par_V_Bit";
                    SQL_Parameter par_V_Bit = new SQL_Parameter(spar_V_Bit, SQL_Parameter.eSQL_Parameter.Bit, false, this.V_bool);
                    lpar.Add(par_V_Bit);
                    string sql = "insert into P_Bit (SQLCommand_ID,ParameterName_ID,V_Bit) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_Bit + ")";
                    ID p_Bit_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_Bit_ID, ref err, "P_Bit"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_Bit:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
            public p_DateTime(object xdatetime, string xname)
            {
                if (xdatetime == null)
                {
                    m_V_DateTime = DateTime.MinValue;
                }
                else if (xdatetime is DateTime)
                {
                    m_V_DateTime = (DateTime)xdatetime;
                }
                else
                {
                    m_V_DateTime = DateTime.MinValue;
                }
                m_Name = xname;

            }

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string sval_V_DateTime = "null";
                    if (this.V_DateTime != DateTime.MinValue)
                    {
                        string spar_V_DateTime = "@par_V_DateTime";
                        SQL_Parameter par_V_DateTime = new SQL_Parameter(spar_V_DateTime, SQL_Parameter.eSQL_Parameter.Datetime, false, this.V_DateTime);
                        lpar.Add(par_V_DateTime);
                        sval_V_DateTime = spar_V_DateTime;
                    }
                    string sql = "insert into P_DateTime (SQLCommand_ID,ParameterName_ID,V_DateTime) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + sval_V_DateTime + ")";
                    ID p_DateTime_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_DateTime_ID, ref err, "P_DateTime"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_DateTime:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_NVarChar = "@par_V_NVarChar";
                    SQL_Parameter par_V_NVarChar = new SQL_Parameter(spar_V_NVarChar, SQL_Parameter.eSQL_Parameter.Nvarchar, false, this.V_NVarChar);
                    lpar.Add(par_V_NVarChar);
                    string sql = "insert into P_NVarChar (SQLCommand_ID,ParameterName_ID,V_varchar_max) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_NVarChar + ")";
                    ID p_NVarChar_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_NVarChar_ID, ref err, "P_NVarChar"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_NVarChar:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_VarChar = "@par_V_VarChar";
                    SQL_Parameter par_V_VarChar = new SQL_Parameter(spar_V_VarChar, SQL_Parameter.eSQL_Parameter.Varchar, false, this.V_VarChar);
                    lpar.Add(par_V_VarChar);
                    string sql = "insert into P_VarChar (SQLCommand_ID,ParameterName_ID,V_varchar_max) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_VarChar + ")";
                    ID p_VarChar_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_VarChar_ID, ref err, "P_VarChar"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_VarChar:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_NChar = "@par_V_NChar";
                    SQL_Parameter par_V_NChar = new SQL_Parameter(spar_V_NChar, SQL_Parameter.eSQL_Parameter.Nchar, false, this.V_NChar);
                    lpar.Add(par_V_NChar);
                    string sql = "insert into P_NChar (SQLCommand_ID,ParameterName_ID,V_varchar_max) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_NChar + ")";
                    ID p_NChar_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_NChar_ID, ref err, "P_NChar"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_NChar:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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


            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_BigInt = "@par_V_BigInt";
                    SQL_Parameter par_V_BigInt = new SQL_Parameter(spar_V_BigInt, SQL_Parameter.eSQL_Parameter.Bigint, false, this.V_BigInt);
                    lpar.Add(par_V_BigInt);
                    string sql = "insert into P_BigInt (SQLCommand_ID,ParameterName_ID,V_BigInt) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_BigInt + ")";
                    ID p_BigInt_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_BigInt_ID, ref err, "P_BigInt"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_BigInt:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public class p_SmallInt
        {
            private short m_V_SmallInt = 0;
            public short V_SmallInt
            {
                get
                {
                    return m_V_SmallInt;
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
                m_V_SmallInt = xi;
                m_Name = xname;

            }

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_SmallInt = "@par_V_SmallInt";
                    SQL_Parameter par_V_SmallInt = new SQL_Parameter(spar_V_SmallInt, SQL_Parameter.eSQL_Parameter.Smallint, false, this.V_SmallInt);
                    lpar.Add(par_V_SmallInt);
                    string sql = "insert into P_SmallInt (SQLCommand_ID,ParameterName_ID,V_SmallInt) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_SmallInt + ")";
                    ID p_SmallInt_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_SmallInt_ID, ref err, "P_SmallInt"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_SmallInt:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        public class p_VarBinary
        {
            private byte[] m_V_VarBinary;
            public byte[] V_VarBinary
            {
                get
                {
                    return m_V_VarBinary;
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
                m_V_VarBinary = xbytearray;
                m_Name = xname;
            }

            internal bool Get(Transaction transaction, ID sQLCommand_ID)
            {
                ID paramterName_ID = null;
                if (TransactionSQLCommand.GetParamterName_ID(transaction, this.m_Name, ref paramterName_ID))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                    string spar_sQLCommand_ID = "@par_sQLCommand_ID";
                    SQL_Parameter par_sQLCommand_ID = new SQL_Parameter(spar_sQLCommand_ID, false, sQLCommand_ID);
                    lpar.Add(par_sQLCommand_ID);

                    string spar_paramterName_ID = "@paramterName_ID";
                    SQL_Parameter par_paramterName_ID = new SQL_Parameter(spar_paramterName_ID, false, paramterName_ID);
                    lpar.Add(par_paramterName_ID);

                    string spar_V_VarBinary = "@par_V_VarBinary";
                    SQL_Parameter par_V_VarBinary = new SQL_Parameter(spar_V_VarBinary, SQL_Parameter.eSQL_Parameter.Varbinary, false, this.V_VarBinary);
                    lpar.Add(par_V_VarBinary);
                    string sql = "insert into P_VarBinary (SQLCommand_ID,ParameterName_ID,V_varbinary_max) values (" + spar_sQLCommand_ID + "," + spar_paramterName_ID + "," + spar_V_VarBinary + ")";
                    ID p_VarBinary_ID = null;
                    string err = null;
                    if (transaction.ExecuteNonQuerySQLReturnID(transaction.con, sql, lpar, ref p_VarBinary_ID, ref err, "P_VarBinary"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:TransactionSQLCommand:p_VarBinary:Get:Error=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Get(Transaction transaction,ID sQLCommand_ID)
        {
            if (p_Int_list != null)
            {
                foreach (TransactionSQLCommand.p_Int xp_Int in p_Int_list)
                {
                    if (xp_Int.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            if (p_VarBinary_list != null)
            {
                foreach (p_VarBinary xp_VarBinary in p_VarBinary_list)
                {
                    if (xp_VarBinary.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (p_Float_list != null)
            {
                foreach (p_Float xp_Float in p_Float_list)
                {
                    if (xp_Float.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            if (p_Bit_list != null)
            {
                foreach (p_Bit xp_Bit in p_Bit_list)
                {
                    if (xp_Bit.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (p_DateTime_list != null)
            {
                foreach (p_DateTime xp_DateTime in p_DateTime_list)
                {
                    if (xp_DateTime.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            if (p_NvarChar_list != null)
            {
                foreach (p_NVarChar xp_NvarChar in p_NvarChar_list)
                {
                    if (xp_NvarChar.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            if (p_VarChar_list != null)
            {
                foreach (p_VarChar xp_VarChar in p_VarChar_list)
                {
                    if (xp_VarChar.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            if (p_NChar_list != null)
            {
                foreach (p_NChar xp_NChar in p_NChar_list)
                {
                    if (xp_NChar.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            if (p_BigInt_list != null)
            {
                foreach (p_BigInt xp_BigInt in p_BigInt_list)
                {
                    if (xp_BigInt.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            if (p_SmallInt_list != null)
            {
                foreach (p_SmallInt xp_SmallInt in p_SmallInt_list)
                {
                    if (xp_SmallInt.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (p_VarBinary_list != null)
            {
                foreach (p_VarBinary xp_VarBinary in p_VarBinary_list)
                {
                    if (xp_VarBinary.Get(transaction,sQLCommand_ID))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
