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

            private bool m_Storno = false;
            public bool Storno
            {
                get
                {
                    return m_Storno;
                }
                private set
                {
                    m_Storno = value;
                }
            }

            private StaticLib.TaxSum m_TaxSum = null;

            public StaticLib.TaxSum TaxSum
            {
                get
                {
                    return m_TaxSum;
                }
                private set
                {
                    m_TaxSum = value;
                }
            }

            private decimal m_NetTotal = 0;
            public decimal NetTotal 
            {
                get
                {
                    return m_NetTotal;
                }
                private set
                {
                    m_NetTotal = value;
                }
            }

            private decimal m_TaxTotal = 0;
            public decimal TaxTotal
            {
                get
                {
                    return m_TaxTotal;
                }
                private set
                {
                    m_TaxTotal = value;
                }
            }

            private decimal m_Total = 0;
            public decimal Total
            {
                get
                {
                    return m_Total;
                }
                private set
                {
                    m_Total = value;
                }
            }

            private string m_PaymentTypeName = "";
            public string PaymentTypeName
            {
                get
                {
                    return m_PaymentTypeName;
                }
                private set
                {
                    m_PaymentTypeName = value;
                }
            }

            public DocInvoiceData(string xAtom_ElectronicDevice_Name,
                                  string xAtom_Office_ShortName,
                                  ID xID,
                                  DateTime xIssueDate,
                                  int xNumberInFinancialYear,
                                  int xFinancialYear,
                                  bool xStorno,
                                  decimal xNetSum,
                                  decimal xTaxSum,
                                  decimal xGrossSum,
                                  StaticLib.TaxSum xtaxSum,
                                  string xPaymentTypeName)
            {
                this.Atom_ElectronicDevice_Name = xAtom_ElectronicDevice_Name;
                this.Atom_Office_ShortName = xAtom_Office_ShortName;
                this.ID = xID;
                this.IssueDate = xIssueDate;
                this.IssueJustDate = new DateTime(xIssueDate.Year, xIssueDate.Month, xIssueDate.Day);
                this.NumberInFinancialYear = xNumberInFinancialYear;
                this.FinancialYear = xFinancialYear;
                this.Storno = xStorno;
                this.NetTotal = xNetSum;
                this.TaxTotal = xTaxSum;
                this.Total = xGrossSum;
                this.TaxSum = xtaxSum;
                this.PaymentTypeName = xPaymentTypeName;
            }
        }


        public List<DocInvoiceData> DocInvoice_ID_List = new List<DocInvoiceData>();

        public enum eCashierState { OPENED, CLOSED };
        private eCashierState m_CashierState = eCashierState.CLOSED;
        public eCashierState CashierState
        {
            get
            {
                return m_CashierState;
            }
            set
            {
                m_CashierState = value;
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



        private int m_CashierActivityNumber = -1;
        public int CashierActivityNumber
        {
            get
            {
                return m_CashierActivityNumber;
            }
            set
            {
                m_CashierActivityNumber = value;
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

        public decimal NetTotal
        {
            get
            {
                decimal nettotal = 0;
                foreach (DocInvoiceData di in this.DocInvoice_ID_List)
                {
                    nettotal += di.NetTotal;
                }
                return nettotal;
            }
        }

        public decimal TaxTotal
        {
            get
            {
                decimal taxtotal = 0;
                foreach (DocInvoiceData di in this.DocInvoice_ID_List)
                {
                    taxtotal += di.TaxTotal;
                }
                return taxtotal;
            }
        }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (DocInvoiceData di in this.DocInvoice_ID_List)
                {
                    total += di.Total;
                }
                return total;
            }
        }

        private StaticLib.TaxSum m_TaxSum = new StaticLib.TaxSum();
        public StaticLib.TaxSum TaxSum
        {
            get
            {
                m_TaxSum.Clear();
                foreach (DocInvoiceData di in DocInvoice_ID_List)
                {
                    foreach (StaticLib.Tax tax in di.TaxSum.TaxList)
                    {
                        m_TaxSum.Add(tax.TaxAmount, tax.TaxableAmount, tax.Name, tax.Rate);
                    }
                }
                return m_TaxSum;
            }
        }


        private Report.PaymentList m_PaymentList = new Report.PaymentList();
        public Report.PaymentList PaymentList
        {
            get
            {
                m_PaymentList.Clear();
                foreach (DocInvoiceData di in DocInvoice_ID_List)
                {
                    m_PaymentList.Add(di.PaymentTypeName, di.NetTotal, di.TaxTotal, di.Total);
                }
                return m_PaymentList;
            }
        }

        public CashierActivity(CashierActivity.DocInvoiceData xDocInvoiceData,
                               int xCashierActivityNumber,
                               ID xFirstAtom_WorkPeriod_ID,
                               DateTime v1,
                               ID xLastAtom_WorkPeriod_ID,
                               DateTime v2)
        {
            this.Add(xDocInvoiceData);
            CashierActivityNumber = xCashierActivityNumber;
            this.First_Atom_WorkPeriod_ID = xFirstAtom_WorkPeriod_ID;
            this.FirstLogin = v1;
            this.Last_Atom_WorkPeriod_ID = xLastAtom_WorkPeriod_ID;
            this.LastLogin = v2;
        }

       

        public CashierActivity()
        {
        }


       

        public bool Open(ID xAtom_WorkPeriod_ID)
        {

            if (f_Atom_WorkPeriod.Get(xAtom_WorkPeriod_ID, ref m_Atom_ElectronicDevice_Name, ref m_Atom_Office_ShortName))
            {
                if (ID.Validate(this.CashierActivityOpened_ID))
                {
                    LogFile.Error.Show("ERROR:LoginControl:CashierActivity:Open:CashierActivity already opened!");
                    return false;
                }
                ID xCashierActivityOpened_ID = null;
                if (f_CashierActivityOpened.Get(xAtom_WorkPeriod_ID, ref xCashierActivityOpened_ID))
                {
                    this.CashierActivityOpened_ID = xCashierActivityOpened_ID;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Close(ID xAtom_WorkPeriod_ID)
        {
            if (ID.Validate(xAtom_WorkPeriod_ID))
            {
                LogFile.Error.Show("ERROR:LoginControl:CashierActivity:Close:xAtom_WorkPeriod_ID is not valid!");
                return false;
            }
            ID xCashierActivityClosed_ID = null;
            if (f_CashierActivityClosed.Get(xAtom_WorkPeriod_ID, ref xCashierActivityClosed_ID))
            {
                this.CashierActivityClosed_ID = xCashierActivityClosed_ID;
                if (f_CashierActivity.Close(this.ID, xAtom_WorkPeriod_ID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public string CashierActivityOpened_Person(ID xCashierActivityOpened_ID)
        {
            string firstName = null;
            string lastName = null;

            if (f_CashierActivityOpened.GetPerson(xCashierActivityOpened_ID, ref firstName, ref lastName))
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

        public void Add(CashierActivity.DocInvoiceData xDocInvoiceData)
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
