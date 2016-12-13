using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class DocProformaInvoice_AddOn
    {
        private long m_DocDuration = -1;
        private long m_DocDurationType = -1;
        private long m_TermsOfPayment_ID = -1;
        private long m_MethodOfPayment_ID = -1;

        private DateTime m_IssueDate = DateTime.MinValue;
        public DateTime IssueDate
        {
            get { return m_IssueDate; }
            set { m_IssueDate = value; }
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

        public long DocDuration
        {
            get { return m_DocDuration; }
            set { m_DocDuration = value; }
        }

        public long DocDurationType
        {
            get { return m_DocDurationType; }
            set { m_DocDurationType = value; }
        }

        public long TermsOfPayment_ID
        {
            get { return m_TermsOfPayment_ID; }
            set { m_TermsOfPayment_ID = value; }
        }

        private string m_TermsOfPayment_Description = null;
        public string TermsOfPayment_Description
        {
            get { return m_TermsOfPayment_Description; }
            set { m_TermsOfPayment_Description = value; }
        }

        private string m_PaymentType = null;
        public string PaymentType
        {
            get { return m_PaymentType; }
            set { m_PaymentType = value; }
        }

        public long MethodOfPayment_ID
        {
            get { return m_MethodOfPayment_ID; }
            set { m_MethodOfPayment_ID = value; }
        }

        public string m_MethodOfPayment = null;
        public string MethodOfPayment
        {
            get { return m_MethodOfPayment; }
        }
        public string m_MethodOfPayment_BankAccount = null;
        public string MethodOfPayment_BankAccount
        {
            get { return m_MethodOfPayment_BankAccount; }
        }
        public string m_MethodOfPayment_BankName = null;
        public string MethodOfPayment_BankName
        {
            get { return m_MethodOfPayment_BankName; }
        }


        private void Clear()
        {
            m_DocDuration = -1;
            m_DocDurationType = -1;
            m_TermsOfPayment_ID = -1;
            m_MethodOfPayment_ID = -1;
            m_BankAccount_ID = -1;
            m_BankName = null;
            m_BankAccount = null;
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
                    object oIssueDate = dt.Rows[0]["IssueDate"];
                    if (oIssueDate is DateTime)
                    {
                        m_IssueDate = (DateTime)oIssueDate;
                    }

                    object oDocDuration = dt.Rows[0]["DocDuration"];
                    if (oDocDuration is long)
                    {
                        m_DocDuration = (long)oDocDuration;
                    }
                    object oDocDurationType = dt.Rows[0]["DocDurationType"];
                    if (oDocDurationType is int)
                    {
                        m_DocDurationType = (long)oDocDurationType;
                    }
                    object oTermsOfPayment_ID = dt.Rows[0]["TermsOfPayment_ID"];
                    if (oTermsOfPayment_ID is long)
                    {
                        m_TermsOfPayment_ID = (long)oTermsOfPayment_ID;
                    }
                    object oMethodOfPayment_ID = dt.Rows[0]["MethodOfPayment_ID"];
                    if (oMethodOfPayment_ID is long)
                    {
                        m_MethodOfPayment_ID = (long)oMethodOfPayment_ID;
                    }

                    object oTermsOfPayment_Description = dt.Rows[0]["TermsOfPayment_Description"];
                    if (oTermsOfPayment_Description is string)
                    {
                        m_TermsOfPayment_Description = (string)oTermsOfPayment_Description;
                    }

                    object oPaymentType = dt.Rows[0]["PaymentType"];
                    if (oPaymentType is string)
                    {
                        m_PaymentType = (string)oPaymentType;
                    }

                    object oMethodOfPayment_BankName = dt.Rows[0]["Name"];
                    if (oMethodOfPayment_BankName is string)
                    {
                        m_MethodOfPayment_BankName = (string)oMethodOfPayment_BankName;
                    }

                    object oMethodOfPayment_BankAccount = dt.Rows[0]["TRR"];
                    if (oMethodOfPayment_BankAccount is string)
                    {
                        m_MethodOfPayment_BankAccount = (string)oMethodOfPayment_BankAccount;
                    }

                    object oBankAccount_ID = dt.Rows[0]["Atom_BankAccount_ID"];
                    if (oBankAccount_ID is long)
                    {
                        m_BankAccount_ID = (long)oBankAccount_ID;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn:Get:sql="+sql+"\r\nErr="+Err);
                return false;
            }
        }
    }
}
