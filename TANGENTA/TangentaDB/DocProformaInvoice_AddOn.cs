using System;
using System.Collections.Generic;
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

        private long m_OrganisationAccount_ID = 0;
        public long OrganisationAccount_ID
        {
            get { return m_OrganisationAccount_ID; }
            set { m_OrganisationAccount_ID = value; }
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
    }
}
