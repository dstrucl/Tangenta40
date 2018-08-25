using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangentaDB;

namespace TangentaPrint
{
    public class Report
    {
        public class PaymentType
        {
            private string m_Name = null;
            public string Name
            {
            get {
                    return m_Name;
                }
            internal set {
                        m_Name = value;
                }
            }

            private int m_Count = 0;
            public int Count
            {
                get
                {
                    return m_Count;
                }
                internal set
                {
                    m_Count = value;
                }
            }

            private decimal m_Net = 0;
            public decimal Net
            {
                get
                {
                    return m_Net;
                }
                internal set
                {
                    m_Net = value;
                }
            }

            private decimal m_TaxTotal = 0;
            public decimal TaxTotal
            {
                get
                {
                    return m_TaxTotal;
                }
                internal set
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
                internal set
                {
                    m_Total = value;
                }
            }
        }

        public class PaymentList
        {

            public List<PaymentType> items = new List<PaymentType>();

            private PaymentType FindItem(string name)
            {
                foreach (PaymentType pt in items)
                {
                    if (pt.Name.Equals(name))
                    {
                        return pt;
                    }
                }
                return null;
            }

            public void Add(string name, decimal xNet,decimal xTaxTotal,Decimal xTotal)
            {
                PaymentType pt = FindItem(name);
                if (pt != null)
                {
                    pt.Count = pt.Count + 1;
                    pt.Net = pt.Net + xNet;
                    pt.TaxTotal = pt.TaxTotal + xTaxTotal;
                    pt.Total = pt.Total + xTotal;
                }
                else
                {
                    pt = new PaymentType();
                    pt.Name = name;
                    pt.Net = xNet;
                    pt.TaxTotal = xTaxTotal;
                    pt.Total = xTotal;
                    pt.Count = 1;
                    items.Add(pt);
                }
            }

            public void Clear()
            {
               items.Clear();
            }
        }

        public class Head
        {
            private PaymentList m_PaymentTypeList = new PaymentList();
            public PaymentList PaymentTypeList
            {
                get
                {
                    return m_PaymentTypeList;
                }
            }
            private string m_OrganisationName = "";
            public string OrganisationName
            {
                get
                {
                    return m_OrganisationName;
                }
                set
                {
                    m_OrganisationName = value;
                }
            }

            private string m_OfficeName = "";
            public string OfficeName
            {
                get
                {
                    return m_OfficeName;
                }
                set
                {
                    m_OfficeName = value;
                }
            }

            private string m_ElectronicDevice = "";
            public string ElectronicDevice
            {
                get
                {
                    return m_ElectronicDevice;
                }
                set
                {
                    m_ElectronicDevice = value;
                }
            }

            private string m_TimeSpanName = "";
            public string TimeSpanName
            {
                get
                {
                    return m_TimeSpanName;
                }
                set
                {
                    m_TimeSpanName = value;
                }
            }

            private string m_From_To = "";

            public string From_To
            {
                get
                {
                    return m_From_To;
                }
                set
                {
                    m_From_To = value;
                }
            }

            private int m_NumberOfInvoices = 0;
            public int NumberOfInvoices
            {
                get
                {
                    return m_NumberOfInvoices;
                }
                set
                {
                    m_NumberOfInvoices = value;
                }
            }

            private int m_NumberOfCashInvoices = 0;
            public int NumberOfCashInvoices
            {
                get
                {
                    return m_NumberOfCashInvoices;
                }
                set
                {
                    m_NumberOfCashInvoices = value;
                }
            }

            private int m_NumberOfCardPaymentInvoices = 0;
            public int NumberOfCardPaymentInvoices
            {
                get
                {
                    return m_NumberOfCardPaymentInvoices;
                }
                set
                {
                    m_NumberOfCardPaymentInvoices = value;
                }
            }

            private StaticLib.TaxSum m_TaxSum = null;

            public StaticLib.TaxSum TaxSum
            {
                get
                {
                    return m_TaxSum;
                }
                internal set
                {
                    m_TaxSum = value;
                }

            }
            private decimal m_TaxTotal = 0;
            public decimal TaxTotal
            {
                get
                {
                    return m_TaxTotal;
                }
                internal set
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
                internal set
                {
                    m_Total = value;
                }
            }

            private decimal m_NetSum = 0;
            public decimal NetSum
            {
                get
                {
                    return m_NetSum;
                }
                internal set
                {
                    m_NetSum = value;
                }
            }
        }

        internal bool Get(DataTable m_dt_XInvoice)
        {
            if (m_dt_XInvoice != null)
            {
                int icount = m_dt_XInvoice.Rows.Count;
                HeadR.TaxTotal = 0;
                HeadR.NetSum = 0;
                HeadR.Total = 0;
                HeadR.NumberOfInvoices = icount;
                HeadR.NumberOfCashInvoices = 0;
                HeadR.NumberOfCardPaymentInvoices = 0;
                HeadR.PaymentTypeList.Clear();

                if (icount > 0)
                {

                    for (int i = icount - 1; i >= 0; i--)
                    {
                        StaticLib.TaxSum taxSum = null;
                        taxSum = new StaticLib.TaxSum();
                        DataRow dr = m_dt_XInvoice.Rows[i];
                        bool_v draft_v = tf.set_bool(dr["JOURNAL_DocInvoice_$_dinv_$$Draft"]);
                        if (draft_v == null)
                        {
                            LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: draft_v == null");
                            return false;
                        }
                        if (!draft_v.v)
                        {
                            ID DocInvoice_ID = tf.set_ID(dr["JOURNAL_DocInvoice_$_dinv_$$ID"]);

                            if (ID.Validate(DocInvoice_ID))
                            {
                                if (f_DocInvoice.GetTaxSum(DocInvoice_ID, taxSum))
                                {
                                    string sInvoiceNumber = null;
                                    string_v AtomOfficeShortName_v = tf.set_string(dr["JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aoffice_$$ShortName"]);
                                    if (AtomOfficeShortName_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: AtomOfficeShortName_v == null");
                                        return false;
                                    }
                                    string_v AtomElectronicDeviceName_v = tf.set_string(dr["JOURNAL_DocInvoice_$_awperiod_$_aed_$$Name"]);
                                    if (AtomElectronicDeviceName_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: AtomElectronicDeviceName_v == null");
                                        return false;
                                    }
                                    int_v iNumberInFinancialYear_v = tf.set_int(dr["JOURNAL_DocInvoice_$_dinv_$$NumberInFinancialYear"]);
                                    if (iNumberInFinancialYear_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: iNumberInFinancialYear_v == null");
                                        return false;
                                    }

                                    int_v iFinancialYear_v = tf.set_int(dr["JOURNAL_DocInvoice_$_dinv_$$FinancialYear"]);
                                    if (iFinancialYear_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: iFinancialYear_v == null");
                                        return false;
                                    }
                                    bool_v bStorno_v = tf.set_bool(dr["JOURNAL_DocInvoice_$_dinv_$$Storno"]);
                                    if (bStorno_v != null)
                                    {
                                        sInvoiceNumber = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(AtomOfficeShortName_v.v,
                                                                                                        AtomElectronicDeviceName_v.v,
                                                                                                        iNumberInFinancialYear_v.v,
                                                                                                        iFinancialYear_v.v,
                                                                                                        bStorno_v.v,
                                                                                                        lng.s_StornoInvoice.s
                                                                                                        );

                                    }
                                    else
                                    {
                                        sInvoiceNumber = Tangenta_DefaultPrintTemplates.TemplatesLoader.SetInvoiceNumber(AtomOfficeShortName_v.v,
                                                                                                        AtomElectronicDeviceName_v.v,
                                                                                                        iNumberInFinancialYear_v.v,
                                                                                                        iFinancialYear_v.v,
                                                                                                        false,
                                                                                                        ""
                                                                                                        );
                                    }

                                    DateTime_v IssueDate_v = tf.set_DateTime(dr["IssueDate"]);
                                    if (IssueDate_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: IssueDate_v == null");
                                        return false;
                                    }

                                    string sIssueTime = LanguageControl.DynSettings.SetLanguageDateTimeString(IssueDate_v.v);

                                    string_v sPaymentType_Name_v = tf.set_string(dr["PaymentType_Name"]);
                                    if (sPaymentType_Name_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: sPaymentType_Name_v == null");
                                        return false;
                                    }


                                    decimal_v dTotal_v = tf.set_decimal(dr["JOURNAL_DocInvoice_$_dinv_$$GrossSum"]);
                                    if (dTotal_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: dTotal_v == null");
                                        return false;
                                    }

                                    decimal_v dNetSum_v = tf.set_decimal(dr["JOURNAL_DocInvoice_$_dinv_$$NetSum"]);
                                    if (dNetSum_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: dNetSum_v == null");
                                        return false;
                                    }

                                    decimal_v dTaxSum_v = tf.set_decimal(dr["JOURNAL_DocInvoice_$_dinv_$$TaxSum"]);
                                    if (dTaxSum_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: dTaxSum_v == null");
                                        return false;
                                    }

                                    HeadR.PaymentTypeList.Add(sPaymentType_Name_v.v, dNetSum_v.v, dTaxSum_v.v, dTotal_v.v);


                                    string_v Issuer_FirstName_v = tf.set_string(dr["JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acfn_$$FirstName"]);
                                    if (Issuer_FirstName_v == null)
                                    {
                                        LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: Issuer_FirstName_v == null");
                                        return false;
                                    }

                                    string sIsuerPerson = Issuer_FirstName_v.v;

                                    string_v Issuer_LastName_v = tf.set_string(dr["JOURNAL_DocInvoice_$_awperiod_$_amcper_$_aper_$_acln_$$LastName"]);
                                    if (Issuer_LastName_v != null)
                                    {
                                        sIsuerPerson += " " + Issuer_LastName_v.v;
                                    }

                                    Report.Item reportitem = new Report.Item(sInvoiceNumber,
                                                                             sIssueTime,
                                                                             sPaymentType_Name_v.v,
                                                                             sIsuerPerson,
                                                                             taxSum,
                                                                             dTaxSum_v.v,
                                                                             dTotal_v.v,
                                                                             dNetSum_v.v);

                                    foreach (StaticLib.Tax tax in taxSum.TaxList)
                                    {
                                        HeadR.TaxSum.Add(tax.TaxAmount, 0, tax.Name, tax.Rate);
                                    }

                                    HeadR.TaxTotal += dTaxSum_v.v;
                                    HeadR.NetSum += dNetSum_v.v;
                                    HeadR.Total += dTotal_v.v;
                                    Add(reportitem);
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: DocInvoice_ID is not valid");
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: m_dt_XInvoice.Rows.Count == 0");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaPrint:Report:Print: m_dt_XInvoice == null");
                return false;
            }
        }

        public class Item
        {

            public Item(string x_InvoiceNumber,
                        string x_IssueTime,
                        string x_MethodOfPayment,
                        string x_IssuerPerson,
                        StaticLib.TaxSum x_TaxSum,
                        decimal x_TaxTotal,
                        decimal x_Total,
                        decimal x_NetSum)
            {
                InvoiceNumber = x_InvoiceNumber;
                IssueTime = x_IssueTime;
                MethodOfPayment = x_MethodOfPayment;
                IssuerPerson = x_IssuerPerson;
                TaxSum = x_TaxSum;
                TaxTotal = x_TaxTotal;
                Total = x_Total;
                NetSum = x_NetSum;
            }

            private string m_InvoiceNumber = "";
            public string InvoiceNumber
            {
                get
                {
                    return m_InvoiceNumber;
                }
                private set
                {
                    m_InvoiceNumber = value;
                }
            }

            private string m_IssueTime = "";
            public string IssueTime
            {
                get
                {
                    return m_IssueTime;
                }
                private set
                {
                    m_IssueTime = value;
                }
            }

            private string m_MethodOfPayment = "";
            public string MethodOfPayment
            {
                get
                {
                    return m_MethodOfPayment;
                }
                private set
                {
                    m_MethodOfPayment = value;
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

            private decimal m_NetSum = 0;
            public decimal NetSum
            {
                get
                {
                    return m_NetSum;
                }
                private set
                {
                    m_NetSum = value;
                }
            }

            private string m_IssuerPerson = "";
            public string IssuerPerson
            {
                get
                {
                    return m_IssuerPerson;
                }
                private set
                {
                    m_IssuerPerson = value;
                }
            }


        }

        public Head HeadR = null;
        public List<Item> ItemList = new List<Item>();
        private string sTimeSpan;
        private DateTime_v dt1_v;
        private DateTime_v dt2_v;

        public Report(string xsTimeSpan, DateTime_v xdt1_v, DateTime_v xdt2_v)
        {
            HeadR = new Head();
            this.sTimeSpan = xsTimeSpan;
            this.dt1_v = xdt1_v;
            this.dt2_v = xdt2_v;
            string sfromto = xsTimeSpan;
            if (this.dt1_v!=null)
            {
                sfromto += " "+LanguageControl.DynSettings.SetLanguageDateString(this.dt1_v.v);
            }
            if (this.dt2_v != null)
            {
                sfromto +=  " "+lng.s_To.s+ " "+LanguageControl.DynSettings.SetLanguageDateString(this.dt2_v.v);
            }

            HeadR.From_To = sfromto;
            string sorgname = "";
            if (myOrg.Name_v!=null)
            {
                sorgname = myOrg.Name_v.v;
            }

            string sofficename = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office.Name_v != null)
                {
                    sofficename = myOrg.m_myOrg_Office.Name_v.v;
                }
            }

            string selectronicdevice = "";
            if (myOrg.m_myOrg_Office != null)
            {
                if (myOrg.m_myOrg_Office != null)
                {
                    if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice != null)
                    {
                        if (myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name != null)
                        {
                            selectronicdevice = myOrg.m_myOrg_Office.m_myOrg_Office_ElectronicDevice.ElectronicDevice_Name;
                        }
                    }
                }
            }

            HeadR.OrganisationName = sorgname;
            HeadR.OfficeName = sofficename;
            HeadR.ElectronicDevice = selectronicdevice;
            HeadR.TaxSum = new StaticLib.TaxSum();



        }

        public void Add(Item item)
        {
            ItemList.Add(item);
        }

        public void ClearItemList()
        {
            ItemList.Clear();
        }
    }
}
