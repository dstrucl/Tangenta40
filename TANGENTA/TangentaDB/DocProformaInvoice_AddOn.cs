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
                if ((olength is long)&&(otype is int))
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
                if ((oID is long)&&(oDescription is string))
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

            private string m_BankAccount = null;
            public string BankAccount
            {
                get { return m_BankAccount; }
                set { m_BankAccount = value; }

            }

            private string m_PaymentType = null;
            public string PaymentType
            {
                get { return m_PaymentType; }
                set { m_PaymentType = value;
                    }
            }

            private GlobalData.ePaymentType m_eType = GlobalData.ePaymentType.NONE;
            public GlobalData.ePaymentType eType
            {
                get { return m_eType; }
                set { m_eType = value;
                      PaymentType = GlobalData.Get_sPaymentType(m_eType);
                    }
            }

            internal static MethodOfPayment Set(object oID, object oPaymentType, object oBankName, object oBankAccount, object oBankAccount_ID)
            {
                if ((oID is long)&&(oPaymentType is string))
                {
                    MethodOfPayment xMethodOfPayment = new MethodOfPayment();
                    xMethodOfPayment.ID = (long)oID;
                    string xPaymentType = (string)oPaymentType;
                    string Err = null;
                    xMethodOfPayment.eType = GlobalData.Get_ePaymentType(xPaymentType, ref Err);
                    if (xMethodOfPayment.eType!=GlobalData.ePaymentType.NONE)
                    {
                        xMethodOfPayment.PaymentType = GlobalData.Get_sPaymentType(xMethodOfPayment.eType);
                        if (xMethodOfPayment.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                        {
                            if ((oBankName is string)&& (oBankAccount is string)&&(oBankAccount_ID is long))
                            {
                                xMethodOfPayment.BankName = (string)oBankName;
                                xMethodOfPayment.BankAccount = (string)oBankAccount;
                                xMethodOfPayment.BankAccount_ID = (long)oBankAccount_ID;
                            }
                            else
                            {
                                if (!(oBankName is string))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn.MethodOfPayment:Set:oBankName is not string");
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
                            ao.Name
                            from DocProformaInvoice dpi
                            left join  TermsOfPayment top on dpi.TermsOfPayment_ID = top.ID
                            left join  MethodOfPayment mop on dpi.MethodOfPayment_ID = mop.ID
                            left join  Atom_BankAccount aba on mop.Atom_BankAccount_ID = aba.ID
                            left join  Atom_Bank ab on aba.Atom_Bank_ID = ab.ID
                            left join  Atom_Organisation ao on ab.Atom_Organisation_ID = ao.ID
                            where dpi.ID = " + DocProformaInvoice_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql,ref Err))
            {
                if (dt.Rows.Count>0)
                {
                    m_IssueDate = DocProformaInvoice_AddOn.IssueDate.Set(dt.Rows[0]["IssueDate"]);
                    m_Duration = DocProformaInvoice_AddOn.Duration.Set(dt.Rows[0]["DocDuration"],
                                                                       dt.Rows[0]["DocDurationType"]);

                    m_TermsOfPayment = DocProformaInvoice_AddOn.TermsOfPayment.Set(dt.Rows[0]["TermsOfPayment_ID"],
                                                                                   dt.Rows[0]["TermsOfPayment_Description"]);

                    m_MethodOfPayment = DocProformaInvoice_AddOn.MethodOfPayment.Set(dt.Rows[0]["MethodOfPayment_ID"],
                                                                                     dt.Rows[0]["PaymentType"],
                                                                                     dt.Rows[0]["Name"],
                                                                                     dt.Rows[0]["TRR"],
                                                                                     dt.Rows[0]["Atom_BankAccount_ID"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn:Get:sql="+sql+"\r\nErr="+Err);
                return false;
            }
        }

        public bool Set(long DocProformaInvoice_ID)
        {

        }
}
