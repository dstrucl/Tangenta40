using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class DocProformaInvoice_AddOn
    {

        public class IssueDate
        {
            private DateTime m_Date = DateTime.MinValue;
            public DateTime Date
            {
                get { return m_Date; }
                set { m_Date = value; }
            }

            internal static IssueDate Set(object o)
            {
                if (o is DateTime)
                {
                    IssueDate xIssueDate = new IssueDate();
                    xIssueDate.Date = (DateTime)o;
                    return xIssueDate;
                }
                else
                {
                    return null;
                }
            }
        }

        public class Duration
        {
            private long m_length = -1;
            private int m_type = -1;
            public long length
            {
                get { return m_length; }
                set { m_length = value; }
            }

            public int type
            {
                get { return m_type; }
                set { m_type = value; }
            }

            internal static Duration Set(object olength, object otype)
            {
                if ((olength is long) && (otype is int))
                {
                    Duration xDuration = new Duration();
                    xDuration.length = (long)olength;
                    xDuration.type = (int)otype;
                    return xDuration;
                }
                else
                {
                    return null;
                }
            }
        }

        public class TermsOfPayment
        {
            private long m_ID = -1;
            public long ID
            {
                get { return m_ID; }
                set { m_ID = value; }
            }

            private string m_Description = null;
            public string Description
            {
                get { return m_Description; }
                set { m_Description = value; }
            }

            internal static TermsOfPayment Set(object oID, object oDescription)
            {
                if ((oID is long) && (oDescription is string))
                {
                    TermsOfPayment xTermsOfPayment = new TermsOfPayment();
                    xTermsOfPayment.ID = (long)oID;
                    xTermsOfPayment.Description = (string)oDescription;
                    return xTermsOfPayment;
                }
                else
                {
                    return null;
                }

            }

            internal bool Set()
            {
                long_v TermsOfPayment_ID_v = null;
                if (f_TermsOfPayment.Get(Description,ref TermsOfPayment_ID_v))
                {
                    if (TermsOfPayment_ID_v != null)
                    {
                        ID = TermsOfPayment_ID_v.v;
                        return true;
                    }
                }
                return false;
            }
        }


        public class MethodOfPayment
        {
            private long m_ID = -1;
            public long ID
            {
                get { return m_ID; }
                set { m_ID = value; }
            }

            private long m_BankAccount_ID = -1;
            public long BankAccount_ID
            {
                get { return m_BankAccount_ID; }
                set { m_BankAccount_ID = value; }
            }

            private string m_BankName = null;
            public string BankName
            {
                get { return m_BankName; }
                set { m_BankName = value; }
            }

            private string m_Bank_Tax_ID = null;
            public string Bank_Tax_ID
            {
                get { return m_Bank_Tax_ID; }
                set { m_Bank_Tax_ID = value; }
            }

            private string m_Bank_Registration_ID = null;
            public string Bank_Registration_ID
            {
                get { return m_Bank_Registration_ID; }
                set { m_Bank_Registration_ID = value; }
            }

            private string m_BankAccount = null;
            public string BankAccount
            {
                get { return m_BankAccount; }
                set { m_BankAccount = value; }

            }

            private string m_Description = null;
            public string Description
            {
                get { return m_Description; }
                set { m_Description = value; }

            }

            public string PaymentType
            {
                get {
                    ltext l_v = GlobalData.Get_sPaymentType_ltext(m_eType);
                    if (l_v != null)
                    {
                        return l_v.s;
                    }
                    else
                    {
                        return GlobalData.Get_sPaymentType(m_eType);
                    }
                }
            }

            private GlobalData.ePaymentType m_eType = GlobalData.ePaymentType.NONE;
            public GlobalData.ePaymentType eType
            {
                get { return m_eType; }
                set
                {
                    m_eType = value;
                }
            }

            internal static MethodOfPayment Set(object oID, object oPaymentType, object oBankName,
                                                                                 object oBank_Tax_ID,
                                                                                 object oBank_Registration_ID,
                                                                                 object oBankAccount,
                                                                                 object oBankAccount_ID)
            {
                if ((oID is long) && (oPaymentType is string))
                {
                    MethodOfPayment xMethodOfPayment = new MethodOfPayment();
                    xMethodOfPayment.ID = (long)oID;
                    string xPaymentType = (string)oPaymentType;
                    string Err = null;
                    xMethodOfPayment.eType = GlobalData.Get_ePaymentType(xPaymentType, ref Err);
                    if (xMethodOfPayment.eType != GlobalData.ePaymentType.NONE)
                    {
                        if (xMethodOfPayment.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                        {
                            if ((oBankName is string)
                                && (oBank_Tax_ID is string)
                                && (oBankAccount is string) 
                                && (oBankAccount_ID is long))
                            {
                                xMethodOfPayment.BankName = (string)oBankName;
                                xMethodOfPayment.Bank_Tax_ID = (string)oBank_Tax_ID;
                                xMethodOfPayment.BankAccount = (string)oBankAccount;
                                xMethodOfPayment.BankAccount_ID = (long)oBankAccount_ID;
                                xMethodOfPayment.m_Bank_Registration_ID = null;
                                if (oBank_Registration_ID!=null)
                                {
                                    if (oBank_Registration_ID is string)
                                    {
                                        xMethodOfPayment.Bank_Registration_ID = (string)oBank_Registration_ID;
                                    }
                                }
                            }
                            else
                            {
                                if (!(oBankName is string))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn.MethodOfPayment:Set:oBankName is not string");
                                }
                                else if (!(oBank_Tax_ID is string))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn.MethodOfPayment:Set:oBank_Tax_ID is not string");
                                }
                                else if (!(oBankAccount is string))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn.MethodOfPayment:Set: oBankAccount is not string");
                                }
                                else if (!(oBankAccount_ID is long))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn.MethodOfPayment:Set: oBankAccount_ID is not long");
                                }
                                return null;
                            }
                        }
                        return xMethodOfPayment;
                    }
                }
                return null;
            }

            internal bool Set()
            {
                long_v Atom_BankAccount_ID_v = null;
                switch (eType)
                {
                    case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                        if (f_Atom_BankAccount.Get(this.BankName,
                                                   this.Bank_Tax_ID,
                                                   this.Bank_Registration_ID,
                                                   true,
                                                   this.BankAccount,
                                                   this.Description,
                                                   ref Atom_BankAccount_ID_v))
                        {
                            if (Atom_BankAccount_ID_v != null)
                            {
                                if (f_MethodOfPayment.Get(eType, Atom_BankAccount_ID_v, ref m_ID))
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
                    default:
                        if (f_MethodOfPayment.Get(eType, null, ref m_ID))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
            }
        }

        public bool Completed()
        {
            if (m_IssueDate != null)
            {
                if (m_MethodOfPayment != null)
                {
                    if (m_Duration != null)
                    {
                        if (m_TermsOfPayment != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public IssueDate m_IssueDate = null;
        public Duration m_Duration = null;
        public TermsOfPayment m_TermsOfPayment = null;
        public MethodOfPayment m_MethodOfPayment = null;

        private void Clear()
        {
            m_IssueDate = null;
            m_Duration = null;
            m_TermsOfPayment = null;
            m_MethodOfPayment = null;
        }

        public bool Get(long DocProformaInvoice_ID)
        {
            string Err = null;
            Clear();
            string sql = @"select 
                            dpi.IssueDate,
                            dpi.DocDuration,
                            dpi.DocDurationType,
                            dpi.TermsOfPayment_ID,
                            dpi.MethodOfPayment_ID,
                            mop.Atom_BankAccount_ID,
                            top.Description as TermsOfPayment_Description,
                            mop.PaymentType,
                            aba.TRR,
                            ao.Name,
                            ao.Tax_ID,
                            ao.Registration_ID
                            from DocProformaInvoice dpi
                            left join  TermsOfPayment top on dpi.TermsOfPayment_ID = top.ID
                            left join  MethodOfPayment mop on dpi.MethodOfPayment_ID = mop.ID
                            left join  Atom_BankAccount aba on mop.Atom_BankAccount_ID = aba.ID
                            left join  Atom_Bank ab on aba.Atom_Bank_ID = ab.ID
                            left join  Atom_Organisation ao on ab.Atom_Organisation_ID = ao.ID
                            where dpi.ID = " + DocProformaInvoice_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    m_IssueDate = DocProformaInvoice_AddOn.IssueDate.Set(dt.Rows[0]["IssueDate"]);
                    m_Duration = DocProformaInvoice_AddOn.Duration.Set(dt.Rows[0]["DocDuration"],
                                                                       dt.Rows[0]["DocDurationType"]);

                    m_TermsOfPayment = DocProformaInvoice_AddOn.TermsOfPayment.Set(dt.Rows[0]["TermsOfPayment_ID"],
                                                                                   dt.Rows[0]["TermsOfPayment_Description"]);

                    m_MethodOfPayment = DocProformaInvoice_AddOn.MethodOfPayment.Set(dt.Rows[0]["MethodOfPayment_ID"],
                                                                                     dt.Rows[0]["PaymentType"],
                                                                                     dt.Rows[0]["Name"],
                                                                                     dt.Rows[0]["Tax_ID"],
                                                                                     dt.Rows[0]["Registration_ID"],
                                                                                     dt.Rows[0]["TRR"],
                                                                                     dt.Rows[0]["Atom_BankAccount_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public bool Set(long DocProformaInvoice_ID, ref ltext ltMsg)
        {
            ltMsg = null;
            if (m_MethodOfPayment != null)
            {
                if (m_MethodOfPayment.Set())
                {
                    if (m_TermsOfPayment != null)
                    {
                        if (m_TermsOfPayment.Set())
                        {
                            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                            string spar_MethodOfPayment_ID = "@par_MethodOfPayment_ID";
                            SQL_Parameter par_MethodOfPayment_ID = new SQL_Parameter(spar_MethodOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, m_MethodOfPayment.ID);
                            lpar.Add(par_MethodOfPayment_ID);
                            string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
                            SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, m_TermsOfPayment.ID);
                            lpar.Add(par_TermsOfPayment_ID);
                            string spar_DocDuration = "@par_DocDuration";
                            SQL_Parameter par_DocDuration = new SQL_Parameter(spar_DocDuration, SQL_Parameter.eSQL_Parameter.Bigint, false, m_Duration.length);
                            lpar.Add(par_DocDuration);
                            string spar_DocDurationType = "@par_DocDurationType";
                            SQL_Parameter par_DocDurationType = new SQL_Parameter(spar_DocDurationType, SQL_Parameter.eSQL_Parameter.Int, false, m_Duration.type);
                            lpar.Add(par_DocDurationType);

                            string spar_IssueDate = "@par_IssueDate";
                            SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, m_IssueDate.Date);
                            lpar.Add(par_IssueDate);

                            string sql = "update DocProformaInvoice set MethodOfPayment_ID = " + spar_MethodOfPayment_ID
                                                                    + ", TermsOfPayment_ID = " + spar_TermsOfPayment_ID
                                                                    + ", DocDuration = " + spar_DocDuration
                                                                    + ", DocDurationType = " + spar_DocDurationType
                                                                    + ", IssueDate = " + spar_IssueDate
                                                                    + " where ID = " + DocProformaInvoice_ID.ToString();
                            object ores = null;
                            string Err = null;

                            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn:Set:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ltMsg = lngRPM.s_TermsOfPayment_are_not_defined;
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                ltMsg = lngRPM.s_MethodOfPayment_is_not_defined;
                return true;
            }
        }
    }
}
