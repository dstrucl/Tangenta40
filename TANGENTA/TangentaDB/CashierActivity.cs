using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
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

        public string GetFirstInvoiceNumber()
        {
            if (this.DocInvoice_ID_List.Count > 0)
            {
                DocInvoiceData di = this.DocInvoice_ID_List[0];
                return Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(di.Atom_Office_ShortName,
                                                                                       di.Atom_ElectronicDevice_Name,
                                                                                       di.NumberInFinancialYear,
                                                                                       di.FinancialYear,
                                                                                       di.Storno,
                                                                                        lng.s_STORNO.s
                                                                                        );
            }
            else
            {
                return null;
            }
        }

        public string GetLastInvoiceNumber()
        {
            if (this.DocInvoice_ID_List.Count > 0)
            {
                DocInvoiceData di = this.DocInvoice_ID_List[this.DocInvoice_ID_List.Count-1];
                return Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(di.Atom_Office_ShortName,
                                                                                       di.Atom_ElectronicDevice_Name,
                                                                                       di.NumberInFinancialYear,
                                                                                       di.FinancialYear,
                                                                                       di.Storno,
                                                                                        lng.s_STORNO.s
                                                                                        );
            }
            else
            {
                return null;
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
            set
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
            set
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

        public bool GetDocInvoices()
        {
            //List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            //string spar_CharirtyActivity_ID = "@spar_CharityActivity_ID";
            //SQL_Parameter par_CharirtyActivity_ID = new SQL_Parameter(spar_CharirtyActivity_ID, false, ID);
            //lpar.Add(par_CharirtyActivity_ID);

            string sql = @"select
              di.ID as DocInvoice_ID,
	          di.NumberInFinancialYear as NumberInFinancialYear,
	          di.FinancialYear as FinancialYear,
	          di.Storno as Storno,
	          di.NetSum as NetSum,
	          di.TaxSum as TaxSum,
	          di.GrossSum as GrossSum,
	          pt.Name as PaymentTypeName,
	          jdit.Name as Name,
	          jdi.JOURNAL_DocInvoice_TYPE_ID as JOURNAL_DocInvoice_TYPE_ID,
	          diao.IssueDate as IssueDate,
	          awp.LoginTime as LoginTime,
	          awp.LogoutTime as LogoutTime,
	          awp.ID as Atom_WorkPeriod_ID,
	          aed.Name as Atom_ElectronicDevice_Name,
	          ao.ShortName as Atom_Office_ShortName
              from CashierActivity ca
              inner join CashierActivity_DocInvoice cadi on cadi.CashierActivity_ID = ca.ID
              inner join DocInvoice di on cadi.DocInvoice_ID = di.ID
              inner join DocInvoiceAddOn diao  on diao.DocInvoice_ID = di.ID
              inner join MethodOfPayment_DI mopdi on mopdi.ID = diao.MethodOfPayment_DI_ID
              inner join PaymentType pt on pt.ID = mopdi.PaymentType_ID
              inner join JOURNAL_DocInvoice jdi on jdi.DocInvoice_ID = di.ID
              inner join JOURNAL_DocInvoice_TYPE jdit on jdi.JOURNAL_DocInvoice_TYPE_ID = jdit.ID and jdi.JOURNAL_DocInvoice_TYPE_ID = " + GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.ID.ToString() + @"
              inner join Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID
              INNER JOIN Atom_ElectronicDevice aed ON aed.ID = awp.Atom_ElectronicDevice_ID
              INNER JOIN Atom_Office ao ON aed.Atom_Office_ID = ao.ID
              INNER JOIN Atom_myOrganisation_Person amop ON amop.ID = awp.Atom_myOrganisation_Person_ID
              LEFT JOIN Atom_WorkPeriod_TYPE awpt on awpt.ID = awp.Atom_WorkPeriod_TYPE_ID
              where di.Draft = 0 and ca.ID = "+this.ID.ToString()+ @"
              order by ca.CashierActivityNumber desc, di.NumberInFinancialYear asc";

            DataTable dtInvoices = new DataTable();
            string Err = null;
            this.DocInvoice_ID_List.Clear();
            if (DBSync.DBSync.ReadDataTable(ref dtInvoices, sql, ref Err))
            {
                int iCount = dtInvoices.Rows.Count;
                if (iCount > 0)
                {
                    foreach (DataRow dr in dtInvoices.Rows)
                    {
                        ID xDocument_ID = tf.set_ID(dr["DocInvoice_ID"]);
                        if (ID.Validate(xDocument_ID))
                        {
                            DateTime_v IssueTime_v = tf.set_DateTime(dr["IssueDate"]);
                            if (IssueTime_v != null)
                            {
                                int NumberInFinancialYear = -1;
                                int_v xNumberInFinancialYear_v = tf.set_int(dr["NumberInFinancialYear"]);
                                if (xNumberInFinancialYear_v != null)
                                {
                                    NumberInFinancialYear = xNumberInFinancialYear_v.v;
                                }
                                int FinancialYear = -1;
                                int_v xFinancialYear_v = tf.set_int(dr["FinancialYear"]);
                                if (xFinancialYear_v != null)
                                {
                                    FinancialYear = xFinancialYear_v.v;
                                }


                                string_v xAtom_ElectronicDevice_Name_v = tf.set_string(dr["Atom_ElectronicDevice_Name"]);
                                string_v xAtom_Office_ShortName_v = tf.set_string(dr["Atom_Office_ShortName"]);

                                bool bStorno = false;
                                bool_v Storno_v = tf.set_bool(dr["Storno"]);
                                if (Storno_v != null)
                                {
                                    bStorno = Storno_v.v;
                                }

                                decimal xnetSum = 0;
                                decimal_v xnetSum_v = tf.set_decimal(dr["NetSum"]);
                                if (xnetSum_v != null)
                                {
                                    xnetSum = xnetSum_v.v;
                                }

                                decimal xtaxSum = 0;
                                decimal_v xtaxSum_v = tf.set_decimal(dr["TaxSum"]);
                                if (xtaxSum_v != null)
                                {
                                    xtaxSum = xtaxSum_v.v;
                                }

                                decimal xgrossSum = 0;
                                decimal_v xgrossSum_v = tf.set_decimal(dr["GrossSum"]);
                                if (xgrossSum_v != null)
                                {
                                    xgrossSum = xgrossSum_v.v;
                                }

                                string xPaymentTypeName = lng.s_Undefined.s;
                                string_v xPaymentTypeName_v = tf.set_string(dr["PaymentTypeName"]);
                                if (xPaymentTypeName_v != null)
                                {
                                    xPaymentTypeName = xPaymentTypeName_v.v;
                                }


                                StaticLib.TaxSum taxSum = new StaticLib.TaxSum();
                                if (f_DocInvoice.GetTaxSum(xDocument_ID, taxSum))
                                {
                                    CashierActivity.DocInvoiceData docinvdata = new CashierActivity.DocInvoiceData(xAtom_ElectronicDevice_Name_v.v,
                                                                                                                  xAtom_Office_ShortName_v.v,
                                                                                                                  xDocument_ID,
                                                                                                                  IssueTime_v.v,
                                                                                                                  NumberInFinancialYear,
                                                                                                                  FinancialYear,
                                                                                                                  bStorno,
                                                                                                                  xnetSum,
                                                                                                                  xtaxSum,
                                                                                                                  xgrossSum,
                                                                                                                  taxSum,
                                                                                                                  xPaymentTypeName);
                                    this.DocInvoice_ID_List.Add(docinvdata);
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaDB:CashierActivity:GetDocInvoices:IssueTime_v == null");
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:CashierActivity:GetDocInvoices::xDocument_ID is not valid!");
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:CashierActivity:GetDocInvoices:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
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


        public CashierActivity(int xCashierActivityNumber,
                               ID xFirstAtom_WorkPeriod_ID,
                               DateTime v1,
                               ID xLastAtom_WorkPeriod_ID,
                               DateTime v2)
        {
            CashierActivityNumber = xCashierActivityNumber;
            this.First_Atom_WorkPeriod_ID = xFirstAtom_WorkPeriod_ID;
            this.FirstLogin = v1;
            this.Last_Atom_WorkPeriod_ID = xLastAtom_WorkPeriod_ID;
            this.LastLogin = v2;
        }


        public CashierActivity()
        {
        }


       

        public bool Open(ID xAtom_WorkPeriod_ID, Transaction transaction)
        {

            if (f_Atom_WorkPeriod.Get(xAtom_WorkPeriod_ID, ref m_Atom_ElectronicDevice_Name, ref m_Atom_Office_ShortName))
            {
                if (ID.Validate(this.CashierActivityOpened_ID))
                {
                    LogFile.Error.Show("ERROR:LoginControl:CashierActivity:Open:CashierActivity already opened!");
                    return false;
                }
                ID xCashierActivityOpened_ID = null;
                ID xCashierActivity_ID = null;
                int iCashierActivityNumber = -1;
                bool balreadyopened = false;
                DateTime loginTime = DateTime.MaxValue;
                if (f_CashierActivity.Open(m_Atom_ElectronicDevice_Name,
                                            m_Atom_Office_ShortName,
                                            xAtom_WorkPeriod_ID,
                                            ref xCashierActivityOpened_ID,
                                            ref iCashierActivityNumber,
                                            ref loginTime,
                                            ref xCashierActivity_ID,
                                            ref balreadyopened,
                                            transaction

                    ))
                {
                    this.FirstLogin = loginTime;
                    this.CashierActivityOpened_ID = xCashierActivityOpened_ID;
                    this.ID = xCashierActivity_ID;
                    this.CashierActivityNumber = iCashierActivityNumber;
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

        public bool Close(ID xAtom_WorkPeriod_ID, Transaction transaction)
        {
            if (!ID.Validate(xAtom_WorkPeriod_ID))
            {
                LogFile.Error.Show("ERROR:LoginControl:CashierActivity:Close:xAtom_WorkPeriod_ID is not valid!");
                return false;
            }
            ID xCashierActivityClosed_ID = null;
            if (f_CashierActivityClosed.Get(xAtom_WorkPeriod_ID, ref xCashierActivityClosed_ID, transaction))
            {
                this.CashierActivityClosed_ID = xCashierActivityClosed_ID;
                if (f_CashierActivity.Close(this.ID, xAtom_WorkPeriod_ID, transaction))
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

        internal bool Add(ID xDocInvoice_ID, Transaction transaction)
        {
            ID xCashierActivity_DocInvoice_ID = null;
            return f_CashierActivity_DocInvoice.Insert(this.ID, xDocInvoice_ID, ref xCashierActivity_DocInvoice_ID, transaction);
        }
    }
}
