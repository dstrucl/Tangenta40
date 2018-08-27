using DBConnectionControl40;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TangentaDB
{
    public class CashierActivity
    {
        public class DocInvoiceData
        {
            private ID m_ID = null;
            public ID ID
            {
                get
                {
                    return m_ID;
                }
                private set
                {
                    m_ID = value;
                }
            }

            private string m_Atom_ElectronicDevice_Name = null;
            public string Atom_ElectronicDevice_Name
            {
                get
                {
                    return m_Atom_ElectronicDevice_Name;
                }
                private set
                {
                    m_Atom_ElectronicDevice_Name = value;
                }
            }

            private string m_Atom_Office_ShortName = null;
            public string Atom_Office_ShortName
            {
                get
                {
                    return m_Atom_Office_ShortName;
                }
                private set
                {
                    m_Atom_Office_ShortName = value;
                }
            }

            private DateTime m_IssueDate = DateTime.MaxValue;
            public DateTime IssueDate
            {
                get
                {
                    return m_IssueDate;
                }
                private set
                {
                    m_IssueDate = value;
                }
            }

            private DateTime m_IssueJustDate = DateTime.MaxValue;
            public DateTime IssueJustDate
            {
                get
                {
                    return m_IssueJustDate;
                }
                private set
                {
                    m_IssueJustDate = value;
                }
            }

            private int m_NumberInFinancialYear = -1;
            public int NumberInFinancialYear
            {
                get
                {
                    return m_NumberInFinancialYear;
                }
                private set
                {
                    m_NumberInFinancialYear = value;
                }
            }

            private int m_FinancialYear = -1;
            public int FinancialYear
            {
                get
                {
                    return m_FinancialYear;
                }
                private set
                {
                    m_FinancialYear = value;
                }
            }

            public DocInvoiceData(string xAtom_ElectronicDevice_Name,
                                  string xAtom_Office_ShortName,
                                  ID xID,
                                  DateTime xIssueDate,
                                  int xNumberInFinancialYear,
                                  int xFinancialYear)
            {
                this.Atom_ElectronicDevice_Name = xAtom_ElectronicDevice_Name;
                this.Atom_Office_ShortName = xAtom_Office_ShortName;
                this.ID = xID;
                this.IssueDate = xIssueDate;
                this.IssueJustDate = new DateTime(xIssueDate.Year, xIssueDate.Month, xIssueDate.Day);
                this.NumberInFinancialYear = xNumberInFinancialYear;
                this.FinancialYear = xFinancialYear;
            }
        }


        public List<DocInvoiceData> DocInvoice_ID_List = new List<DocInvoiceData>();

        public int NumberOfInvoices
        {
            get
            {
                return DocInvoice_ID_List.Count;
            }

        }
        private ID m_ID = null;
        public ID ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        public string CashierActivityOpened_Person(ID xCashierActivityOpened_ID)
        {
            string firstName = null;
            string lastName = null;

            if (f_CashierActivityOpened.GetPerson(xCashierActivityOpened_ID, ref firstName, ref lastName))
            {
                string sperson = "";
                if (firstName!=null)
                {
                    sperson = firstName;
                }
                if (lastName != null)
                {
                    sperson += " "+lastName;
                }
                return sperson;
            }
            else
            {
                return null;
            }
        }

        public string CashierActivityClosed_Person(ID xCashierActivityClosed_ID)
        {
            string firstName = null;
            string lastName = null;

            if (f_CashierActivityClosed.GetPerson(xCashierActivityClosed_ID, ref firstName, ref lastName))
            {
                string sperson = "";
                if (firstName != null)
                {
                    sperson = firstName;
                }
                if (lastName != null)
                {
                    sperson += " " + lastName;
                }
                return sperson;
            }
            else
            {
                return null;
            }
        }

        private ID m_CashierActivityOpened_ID = null;
        public ID CashierActivityOpened_ID
        {
            get
            {
                return m_CashierActivityOpened_ID;
            }
            set
            {
                m_CashierActivityOpened_ID = value;
            }
        }

        private ID m_CashierActivityClosed_ID = null;
        public ID CashierActivityClosed_ID
        {
            get
            {
                return m_CashierActivityClosed_ID;
            }
            set
            {
                m_CashierActivityClosed_ID = value;
            }
        }



        private ID m_First_Atom_WorkPeriod_ID = null;
        public ID First_Atom_WorkPeriod_ID
        {
            get
            {
                return m_First_Atom_WorkPeriod_ID;
            }
            set
            {
                m_First_Atom_WorkPeriod_ID = value;
            }
        }

        private ID m_Last_Atom_WorkPeriod_ID = null;
        public ID Last_Atom_WorkPeriod_ID
        {
            get
            {
                return m_Last_Atom_WorkPeriod_ID;
            }
            set
            {
                m_Last_Atom_WorkPeriod_ID = value;
            }
        }

        private DateTime m_FirstLogin = DateTime.MaxValue;
        public DateTime FirstLogin
        {
            get
            {
                return m_FirstLogin;
            }
            set
            {
                m_FirstLogin = value;
            }
        }

        private DateTime m_LastLogin = DateTime.MinValue;
        public DateTime LastLogin
        {
            get
            {
                return m_LastLogin;
            }
            set
            {
                m_LastLogin = value;
            }
        }


        public CashierActivity(DocInvoiceData xDocInvoiceData,
                               ID xFirstAtom_WorkPeriod_ID,
                               DateTime v1,
                               ID xLastAtom_WorkPeriod_ID,
                               DateTime v2)
        {
            this.Add(xDocInvoiceData);
            this.First_Atom_WorkPeriod_ID = xFirstAtom_WorkPeriod_ID;
            this.FirstLogin = v1;
            this.Last_Atom_WorkPeriod_ID = xLastAtom_WorkPeriod_ID;
            this.LastLogin = v2;
        }

        internal void Add(DocInvoiceData xDocInvoiceData)
        {
            foreach (DocInvoiceData id in DocInvoice_ID_List)
            {
                if (id.ID.Equals(xDocInvoiceData.ID))
                {
                    return;
                }
            }
            DocInvoice_ID_List.Add(xDocInvoiceData);
        }
    }
}
