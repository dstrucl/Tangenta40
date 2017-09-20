using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TangentaDB
{
    public class MyOrgBankAccountPayment
    {
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
    }
}
