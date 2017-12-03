using DBConnectionControl40;
using DBTypes;
using LanguageControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TangentaDB
{
    public class DocInvoice_AddOn
    {
        public long_v DocInvoice_ID_v = null;
        public long_v DocInvoiceAddOn_ID_v = null;

        private decimal m_Cash_AmountReceived = 0;
        private decimal m_Cash_ToReturn = 0;


        public decimal Cash_AmountReceived
        {
            get { return m_Cash_AmountReceived; }
            set { m_Cash_AmountReceived = value; }
        }

        public string sCash_AmountReceived
        {
            get { return m_Cash_AmountReceived.ToString(); }
        }

        public decimal Cash_ToReturn
        {
            get { return m_Cash_ToReturn; }
            set { m_Cash_ToReturn = value; }
        }

        public string sCash_ToReturn
        {
            get { return m_Cash_ToReturn.ToString(); }
        }

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

        public class PaymentDeadline
        {
            private DateTime m_Date = DateTime.MinValue;
            public DateTime Date
            {
                get { return m_Date; }
                set { m_Date = value; }
            }

            internal static PaymentDeadline Set(object o)
            {
                if (o is DateTime)
                {
                    PaymentDeadline xPaymentDeadline = new PaymentDeadline();
                    xPaymentDeadline.Date = (DateTime)o;
                    return xPaymentDeadline;
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

            internal bool Get(ref long_v TermsOfPayment_ID_v)
            {
                
                if (f_TermsOfPayment.Get(Description, ref TermsOfPayment_ID_v))
                {
                    if (TermsOfPayment_ID_v != null)
                    {
                        ID = TermsOfPayment_ID_v.v;
                        return true;
                    }
                }
                return false;
            }

            public bool SetDefault()
            {
                string_v description_v = null;
                if (f_TermsOfPayment.Get(1, ref description_v))
                {
                    if (description_v != null)
                    {
                        ID = 1;
                        Description = description_v.v;
                        return true;
                    }
                }
                return false;
            }
        }


        public class MethodOfPayment_DI
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

            private GlobalData.ePaymentType m_eType = GlobalData.ePaymentType.ANY_TYPE;
            public GlobalData.ePaymentType eType
            {
                get { return m_eType; }
                set
                {
                    m_eType = value;
                }
            }

            public MyOrgBankAccountPayment m_MyOrgBankAccountPayment = null;



            internal static MethodOfPayment_DI Set(object oID, object oPaymentType_Identification, object oBankName,
                                                                                 object oBank_Tax_ID,
                                                                                 object oBank_Registration_ID,
                                                                                 object oBank_TaxPayer,
                                                                                 object oBank_Comment1,
                                                                                 object oBankAccount,
                                                                                 object oBankAccount_ID)
            {
                if ((oID is long) && (oPaymentType_Identification is string))
                {
                    MethodOfPayment_DI xMethodOfPayment_DI = new MethodOfPayment_DI();
                    xMethodOfPayment_DI.ID = (long)oID;
                    string xPaymentType = (string)oPaymentType_Identification;
                    string Err = null;
                    xMethodOfPayment_DI.eType = GlobalData.Get_ePaymentType(xPaymentType, ref Err);
                    if (xMethodOfPayment_DI.eType != GlobalData.ePaymentType.ANY_TYPE)
                    {
                        if (xMethodOfPayment_DI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                        {
                            if (xMethodOfPayment_DI.m_MyOrgBankAccountPayment == null)
                            {
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment = new MyOrgBankAccountPayment();
                            }
                            if ((oBankName is string)
                                && (oBank_Tax_ID is string)
                                && (oBankAccount is string)
                                && (oBankAccount_ID is long))
                            {
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankName = (string)oBankName;
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Tax_ID = (string)oBank_Tax_ID;
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount = (string)oBankAccount;
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment.BankAccount_ID = (long)oBankAccount_ID;
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Registration_ID = null;
                                if (oBank_Registration_ID != null)
                                {
                                    if (oBank_Registration_ID is string)
                                    {
                                        xMethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Registration_ID = (string)oBank_Registration_ID;
                                    }
                                }
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_TaxPayer_v = tf.set_bool(oBank_TaxPayer);
                                xMethodOfPayment_DI.m_MyOrgBankAccountPayment.Bank_Comment1_v = tf.set_string(oBank_Comment1);
                            }
                            else
                            {
                                if (!(oBankName is string))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocInvoice_AddOn.MethodOfPayment:Set:oBankName is not string");
                                }
                                else if (!(oBank_Tax_ID is string))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocInvoice_AddOn.MethodOfPayment:Set:oBank_Tax_ID is not string");
                                }
                                else if (!(oBankAccount is string))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocInvoice_AddOn.MethodOfPayment:Set: oBankAccount is not string");
                                }
                                else if (!(oBankAccount_ID is long))
                                {
                                    LogFile.Error.Show("ERROR:TangentaDB:DocInvoice_AddOn.MethodOfPayment:Set: oBankAccount_ID is not long");
                                }
                                return null;
                            }
                        }
                        return xMethodOfPayment_DI;
                    }
                }
                return null;
            }

            internal bool Get(ref long_v MethodOfPayment_DI_ID_v)
            {
                long_v Atom_BankAccount_ID_v = null;
                long_v PaymentType_ID_v = null;
                string_v PaymentType_v = null;

                
                switch (eType)
                {
                    case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
                        if (m_MyOrgBankAccountPayment==null)
                        {
                            m_MyOrgBankAccountPayment = new MyOrgBankAccountPayment();
                        }
                        if (f_Atom_BankAccount.Get(this.m_MyOrgBankAccountPayment.BankName,
                                                   this.m_MyOrgBankAccountPayment.Bank_Tax_ID,
                                                   this.m_MyOrgBankAccountPayment.Bank_Registration_ID,
                                                   this.m_MyOrgBankAccountPayment.Bank_TaxPayer_v,
                                                   this.m_MyOrgBankAccountPayment.Bank_Comment1_v,
                                                   true,
                                                   this.m_MyOrgBankAccountPayment.BankAccount,
                                                   this.Description,
                                                   ref Atom_BankAccount_ID_v))
                        {
                            if (Atom_BankAccount_ID_v != null)
                            {
                                if (f_MethodOfPayment_DI.Get(eType,
                                                             Atom_BankAccount_ID_v,
                                                             ref PaymentType_ID_v,
                                                             ref PaymentType_v,
                                                             ref MethodOfPayment_DI_ID_v))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        break;
                    default:
                        if (f_MethodOfPayment_DI.Get(  eType,
                                                             null,
                                                             ref PaymentType_ID_v,
                                                             ref PaymentType_v,
                                                             ref MethodOfPayment_DI_ID_v))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
                return false;
            }

            internal GlobalData.ePaymentType Set(object oPaymentType)
            {
                if (oPaymentType is string)
                {
                    return GlobalData.Get_ePaymentType((string)oPaymentType);
                }
                else
                {
                    return GlobalData.ePaymentType.ANY_TYPE;
                }
            }
        }

        public string m_NoticeText = null;

        public class CashHandling
        {
            public decimal m_AmountReceived = 0;
            public decimal m_ToReturn = 0;
        }

        public CashHandling m_CashHandling = null;

        public bool Completed(ref ltext ltMsg)
        {
            if (m_IssueDate != null)
            {
                if (m_MethodOfPayment_DI != null)
                {
                    if (m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                    {
                        if (m_MethodOfPayment_DI.m_MyOrgBankAccountPayment != null)
                        {
                            if (m_PaymentDeadline != null)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            List<object> Complex_ltMsg = new List<object>();
            if (m_IssueDate == null)
            {
                Complex_ltMsg.Add(lng.s_IssueDate_not_defined);
            }
            if (m_MethodOfPayment_DI == null)
            {
                Complex_ltMsg.Add(lng.s_MethodOfPayment_DI_not_defined);
            }
            else
            {
                if (m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                {
                    if (m_MethodOfPayment_DI.m_MyOrgBankAccountPayment == null)
                    {
                        Complex_ltMsg.Add(lng.s_MethodOfPayment_DI_BankAccount_not_defined);
                    }
                    if (m_PaymentDeadline == null)
                    {
                        Complex_ltMsg.Add(lng.s_MethodOfPayment_DI_PaymentDeadline_not_defined);
                    }
                }
            }
            if (m_TermsOfPayment == null)
            {
                Complex_ltMsg.Add(lng.s_TermsOfPayment_are_not_defined);
            }
            if (Complex_ltMsg.Count>0)
            {
                ltMsg = new ltext(Complex_ltMsg);
            }
                
            return false;
        }

        public IssueDate m_IssueDate = null;
        public TermsOfPayment m_TermsOfPayment = null;
        public MethodOfPayment_DI m_MethodOfPayment_DI = null;
        public PaymentDeadline m_PaymentDeadline = null;


        private void Clear()
        {
            m_IssueDate = null;
            m_TermsOfPayment = null;
            m_MethodOfPayment_DI = null;
            m_PaymentDeadline = null;
        }

        public bool Get(long DocInvoice_ID)
        {
            string Err = null;
            Clear();
            string sql = @"select 
                            diao.IssueDate,
                            diao.TermsOfPayment_ID,
                            mop.ID as MethodOfPayment_DI_ID,
                            diao.PaymentDeadline,
                            mop.Atom_BankAccount_ID,
                            topay.Description as TermsOfPayment_Description,
                            mop.PaymentType_ID,
                            pt.Identification as PaymentType_Identification,
                            aba.TRR,
                            ao.Name,
                            an.NoticeText as NoticeText,
                            ao.Tax_ID,
                            ao.Registration_ID,
                            ao.TaxPayer as TaxPayer,
                            acmt1.Comment as Comment1
                            from DocInvoice di
							inner join  DocInvoiceAddOn diao on diao.DocInvoice_ID = di.ID
                            left join  TermsOfPayment topay on diao.TermsOfPayment_ID = topay.ID
                            left join  MethodOfPayment_DI mop on diao.MethodOfPayment_DI_ID = mop.ID
                            left join  PaymentType pt on mop.PaymentType_ID = pt.ID
                            left join  Atom_BankAccount aba on mop.Atom_BankAccount_ID = aba.ID
                            left join  Atom_Bank ab on aba.Atom_Bank_ID = ab.ID
                            left join  Atom_Organisation ao on ab.Atom_Organisation_ID = ao.ID
                            left join  Atom_Comment1 acmt1 on acmt1.ID = ao.Atom_Comment1_ID
                            left join  Atom_Notice an on diao.Atom_Notice_ID = an.ID
                            where di.ID = " + DocInvoice_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    m_IssueDate = DocInvoice_AddOn.IssueDate.Set(dt.Rows[0]["IssueDate"]);

                    m_TermsOfPayment = DocInvoice_AddOn.TermsOfPayment.Set(dt.Rows[0]["TermsOfPayment_ID"],
                                                                                   dt.Rows[0]["TermsOfPayment_Description"]);

                    m_MethodOfPayment_DI = DocInvoice_AddOn.MethodOfPayment_DI.Set(dt.Rows[0]["MethodOfPayment_DI_ID"],
                                                                                     dt.Rows[0]["PaymentType_Identification"],
                                                                                     dt.Rows[0]["Name"],
                                                                                     dt.Rows[0]["Tax_ID"],
                                                                                     dt.Rows[0]["Registration_ID"],
                                                                                     dt.Rows[0]["TaxPayer"],
                                                                                     dt.Rows[0]["Comment1"],
                                                                                     dt.Rows[0]["TRR"],
                                                                                     dt.Rows[0]["Atom_BankAccount_ID"]);
                    m_PaymentDeadline = DocInvoice_AddOn.PaymentDeadline.Set(dt.Rows[0]["PaymentDeadline"]);
                    object oNoticeText = dt.Rows[0]["NoticeText"];
                    m_NoticeText = null;
                    if (oNoticeText is string)
                    {
                        m_NoticeText = (string)oNoticeText;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:DocInvoice_AddOn:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public bool Set(long DocInvoice_ID, ref ltext ltMsg)
        {
           
                if (DocInvoice_ID_v == null)
                {
                    DocInvoice_ID_v = new long_v(DocInvoice_ID);
                }
                else
                {
                    DocInvoice_ID_v.v = DocInvoice_ID;

                }

                if (f_DocInvoiceAddOn.Get(DocInvoice_ID_v, ref DocInvoiceAddOn_ID_v))
                {
                    if (DocInvoiceAddOn_ID_v != null)
                    {
                        return Update();
                    }
                    else
                    {
                        return Insert();
                    }
                }
                else
                {
                    return false;
                }
           
        }

        private bool Insert()
        {
            if (DocInvoice_ID_v== null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:Insert:DocInvoice_ID_v== null");
                return false;
            }
            ltext ltMsg = null;
            long_v MethodOfPayment_DI_ID_v = null;
            if (m_MethodOfPayment_DI.Get(ref MethodOfPayment_DI_ID_v))
            {
                if (m_TermsOfPayment != null)
                {
                    long_v TermsOfPayment_ID_v = null;
                    if (m_TermsOfPayment.Get(ref TermsOfPayment_ID_v))
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                        long_v Atom_Notice_ID_v = null;
                        long_v Notice_ID_v = null;

                        string sval_Atom_Notice_ID = "null";
                        if (m_NoticeText != null)
                        {
                            if (!f_Notice.Get(m_NoticeText, ref Notice_ID_v))
                            {
                                return false;
                            }
                            if (!f_Atom_Notice.Get(m_NoticeText, ref Atom_Notice_ID_v))
                            {
                                return false;
                            }
                            string notice_text = m_NoticeText;
                            string spar_Atom_Notice_ID = "@par_Atom_Notice_ID";
                            SQL_Parameter par_Atom_Notice_ID = new SQL_Parameter(spar_Atom_Notice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_Notice_ID_v.v);
                            lpar.Add(par_Atom_Notice_ID);
                            sval_Atom_Notice_ID = spar_Atom_Notice_ID;
                        }

                        string spar_DocInvoice_ID = "@par_DocInvoice_ID";
                        SQL_Parameter par_DocInvoice_ID = new SQL_Parameter(spar_DocInvoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocInvoice_ID_v.v);
                        lpar.Add(par_DocInvoice_ID);

                        string spar_MethodOfPayment_DI_ID = "@par_MethodOfPayment_DI_ID";
                        SQL_Parameter par_MethodOfPayment_DI_ID = new SQL_Parameter(spar_MethodOfPayment_DI_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, MethodOfPayment_DI_ID_v.v);
                        lpar.Add(par_MethodOfPayment_DI_ID);

                        string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
                        SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, m_TermsOfPayment.ID);
                        lpar.Add(par_TermsOfPayment_ID);

                        string sval_PaymentDeadline = "null";
                        if (m_PaymentDeadline != null)
                        {
                            string spar_PaymentDeadline = "@par_PaymentDeadline";
                            SQL_Parameter par_PaymentDeadline = new SQL_Parameter(spar_PaymentDeadline, SQL_Parameter.eSQL_Parameter.Datetime, false, m_PaymentDeadline.Date);
                            lpar.Add(par_PaymentDeadline);
                            sval_PaymentDeadline = spar_PaymentDeadline;
                        }



                        string spar_IssueDate = "@par_IssueDate";
                        SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, m_IssueDate.Date);
                        lpar.Add(par_IssueDate);

                        


                        string sql = @"insert into DocInvoiceAddOn (DocInvoice_ID,
                                                                    IssueDate,
                                                                    MethodOfPayment_DI_ID,
                                                                    TermsOfPayment_ID,
                                                                    PaymentDeadline,
                                                                    Atom_Notice_ID) values
                                                                   (" + spar_DocInvoice_ID + ","
                                                                   + spar_IssueDate +","
                                                                   + spar_MethodOfPayment_DI_ID + ","
                                                                   + spar_TermsOfPayment_ID + "," +
                                                                   sval_PaymentDeadline + ","+
                                                                   sval_Atom_Notice_ID+")";
                                                              
                        object ores = null;
                        string Err = null;
                        long ID = -1;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar,ref  ID, ref ores, ref Err, "DocInvoiceAddOn"))
                        {
                            DocInvoiceAddOn_ID_v = new long_v(ID);
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:DocInvoice_AddOn:Insert:sql=" + sql + "\r\nErr=" + Err);
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
                    ltMsg = lng.s_TermsOfPayment_are_not_defined;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool Update()
        {
            ltext ltMsg = null;   
            long_v MethodOfPayment_DI_ID_v = null;
            if (m_MethodOfPayment_DI.Get(ref MethodOfPayment_DI_ID_v))
            {
                if (m_TermsOfPayment != null)
                {
                    long_v TermsOfPayment_ID_v = null;
                    if (m_TermsOfPayment.Get(ref TermsOfPayment_ID_v))
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();

                        string sval_Atom_Notice_ID = " Atom_Notice_ID = null ";
                        long_v Atom_Notice_ID_v = null;
                        long_v Notice_ID_v = null;

                        if (m_NoticeText != null)
                        {
                            if (!f_Notice.Get(m_NoticeText, ref Notice_ID_v))
                            {
                                return false;
                            }
                            if (!f_Atom_Notice.Get(m_NoticeText, ref Atom_Notice_ID_v))
                            {
                                return false;
                            }
                            string notice_text = m_NoticeText;
                            string spar_Atom_Notice_ID = "@par_Atom_Notice_ID";
                            SQL_Parameter par_Atom_Notice_ID = new SQL_Parameter(spar_Atom_Notice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, Atom_Notice_ID_v.v);
                            lpar.Add(par_Atom_Notice_ID);
                            sval_Atom_Notice_ID = " Atom_Notice_ID = "+ spar_Atom_Notice_ID;
                        }

                        string spar_MethodOfPayment_ID = "@par_MethodOfPayment_ID";
                        SQL_Parameter par_MethodOfPayment_ID = new SQL_Parameter(spar_MethodOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, MethodOfPayment_DI_ID_v.v);
                        lpar.Add(par_MethodOfPayment_ID);

                        string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
                        SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, m_TermsOfPayment.ID);
                        lpar.Add(par_TermsOfPayment_ID);

                        string sval_PaymentDeadline = " PaymentDeadline = null ";
                        if (m_PaymentDeadline != null)
                        {
                            string spar_PaymentDeadline = "@par_PaymentDeadline";
                            SQL_Parameter par_PaymentDeadline = new SQL_Parameter(spar_PaymentDeadline, SQL_Parameter.eSQL_Parameter.Datetime, false, m_PaymentDeadline.Date);
                            lpar.Add(par_PaymentDeadline);
                            sval_PaymentDeadline = "PaymentDeadline = " + spar_PaymentDeadline;
                        }

                     


                        string spar_IssueDate = "@par_IssueDate";
                        SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, m_IssueDate.Date);
                        lpar.Add(par_IssueDate);



                        string sql = "update DocInvoiceAddOn set IssueDate = " + spar_IssueDate
                                                                + ",MethodOfPayment_DI_ID = " + spar_MethodOfPayment_ID
                                                                + ",TermsOfPayment_ID = " + spar_TermsOfPayment_ID
                                                                + "," + sval_PaymentDeadline
                                                                + "," + sval_Atom_Notice_ID
                                                                + " where ID = " + DocInvoiceAddOn_ID_v.v.ToString();
                        object ores = null;
                        string Err = null;

                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:DocInvoice_AddOn:Update:sql=" + sql + "\r\nErr=" + Err);
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
                    ltMsg = lng.s_TermsOfPayment_are_not_defined;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        public bool b_FVI_SLO = false;

        public class FURS
        {
            public string_v FURS_ZOI_v = null;
            public string_v FURS_EOR_v = null;
            public string sFURS_ZOI = "";
            public string sFURS_EOR = "";
            public string_v FURS_QR_v = null;
            public bool_v FURS_TestEnvironment_v = null;
            public Image FURS_Image_QRcode = null;

            public string_v FURS_SalesBookInvoice_InvoiceNumber_v = null;
            public string_v FURS_SalesBookInvoice_SetNumber_v = null;
            public string_v FURS_SalesBookInvoice_SerialNumber_v = null;



            public UniversalInvoice.FVI_SLO_RealEstateBP FVI_SLO_RealEstateBP = null;
            public UniversalInvoice.Invoice_FURS_Token Invoice_FURS_Token = null;


            public bool Write_FURS_Response_Data(long DocInvoice_ID,bool FursTESTEnvironment)
            {
                object oret = null;
                string Err = null;
                string sql = null;
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_Invoice_ID = "@par_Invoice_ID";
                SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_Invoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocInvoice_ID);
                lpar.Add(par_Invoice_ID);
                sql = "select ID from fvi_slo_response where DocInvoice_ID = " + spar_Invoice_ID;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        LogFile.Error.Show("ERROR:InvoiceData:Write_FURS_Response_Data:sql=" + sql + "\r\n Invoice was confirmed in the past: Invoice_ID" + DocInvoice_ID.ToString() + " fvi_slo_response.ID=" + ((long)dt.Rows[0]["ID"]).ToString());
                        return true;

                    }
                }
                string spar_MessageID = "@par_MessageID";
                SQL_Parameter par_MessageID = new SQL_Parameter(spar_MessageID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_ZOI_v.v);
                lpar.Add(par_MessageID);


                string sval_UniqueInvoiceID = " null ";

                if (FURS_EOR_v != null)
                {
                    if (FURS_EOR_v.v != null)
                    {
                        string spar_UniqueInvoiceID = "@par_UniqueInvoiceID";
                        SQL_Parameter par_UniqueInvoiceID = new SQL_Parameter(spar_UniqueInvoiceID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_EOR_v.v);
                        lpar.Add(par_UniqueInvoiceID);
                        sval_UniqueInvoiceID = spar_UniqueInvoiceID;
                    }
                }

                string spar_BarCodeValue = "@par_BarCodeValue";
                SQL_Parameter par_BarCodeValue = new SQL_Parameter(spar_BarCodeValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_QR_v.v);
                lpar.Add(par_BarCodeValue);

                DateTime resp_datetime = DateTime.Now;
                string spar_Response_DateTime = "@par_Response_DateTime";
                SQL_Parameter par_Response_DateTime = new SQL_Parameter(spar_Response_DateTime, SQL_Parameter.eSQL_Parameter.Datetime, false, resp_datetime);
                lpar.Add(par_Response_DateTime);

                
                string spar_TestEnvironment = "@par_TestEnvironment";
                SQL_Parameter par_TestEnvironment = new SQL_Parameter(spar_TestEnvironment, SQL_Parameter.eSQL_Parameter.Bit, false, FursTESTEnvironment);
                lpar.Add(par_TestEnvironment);

                sql = "insert into fvi_slo_response (DocInvoice_ID,MessageID,UniqueInvoiceID,BarCodeValue,Response_DateTime,TestEnvironment) values (" + spar_Invoice_ID + "," + spar_MessageID + "," + sval_UniqueInvoiceID + "," + spar_BarCodeValue + "," + spar_Response_DateTime + ","+ spar_TestEnvironment+")";
                long id = -1;
                if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref oret, ref Err, "fvi_slo_response"))
                {
                    Set_Invoice_Furs_Token();
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceData:Write_FURS_Response_Data:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }


            public bool Update_FURS_Response_Data(long DocInvoice_ID, bool FursTESTEnvironment)
            {
                object oret = null;
                string Err = null;
                string sql = null;
                List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                string spar_Invoice_ID = "@par_Invoice_ID";
                SQL_Parameter par_Invoice_ID = new SQL_Parameter(spar_Invoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocInvoice_ID);
                lpar.Add(par_Invoice_ID);
                sql = "select ID from fvi_slo_response where DocInvoice_ID = " + spar_Invoice_ID;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, lpar, ref Err))
                {
                    if (dt.Rows.Count == 0)
                    {
                        if (Write_FURS_Response_Data(DocInvoice_ID, FursTESTEnvironment))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                string spar_MessageID = "@par_MessageID";
                SQL_Parameter par_MessageID = new SQL_Parameter(spar_MessageID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_ZOI_v.v);
                lpar.Add(par_MessageID);


                string sval_UniqueInvoiceID = " null ";

                if (FURS_EOR_v != null)
                {
                    if (FURS_EOR_v.v != null)
                    {
                        string spar_UniqueInvoiceID = "@par_UniqueInvoiceID";
                        SQL_Parameter par_UniqueInvoiceID = new SQL_Parameter(spar_UniqueInvoiceID, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_EOR_v.v);
                        lpar.Add(par_UniqueInvoiceID);
                        sval_UniqueInvoiceID = spar_UniqueInvoiceID;
                    }
                }

                string spar_BarCodeValue = "@par_BarCodeValue";
                SQL_Parameter par_BarCodeValue = new SQL_Parameter(spar_BarCodeValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, FURS_QR_v.v);
                lpar.Add(par_BarCodeValue);

                DateTime resp_datetime = DateTime.Now;
                string spar_Response_DateTime = "@par_Response_DateTime";
                SQL_Parameter par_Response_DateTime = new SQL_Parameter(spar_Response_DateTime, SQL_Parameter.eSQL_Parameter.Datetime, false, resp_datetime);
                lpar.Add(par_Response_DateTime);


                string spar_TestEnvironment = "@par_TestEnvironment";
                SQL_Parameter par_TestEnvironment = new SQL_Parameter(spar_TestEnvironment, SQL_Parameter.eSQL_Parameter.Bit, false, FursTESTEnvironment);
                lpar.Add(par_TestEnvironment);

                sql = @"Update fvi_slo_response set MessageID = " + spar_MessageID +
                        ",UniqueInvoiceID = " + sval_UniqueInvoiceID +
                        ",BarCodeValue = " + spar_BarCodeValue +
                        ",Response_DateTime = " + spar_Response_DateTime +
                        ",TestEnvironment = " + spar_TestEnvironment +
                        " where DocInvoice_ID = " + spar_Invoice_ID;
                long id = -1;
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar,ref oret, ref Err))
                {
                    Set_Invoice_Furs_Token();
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceData:Update_FURS_Response_Data:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }


            public void Set_Invoice_Furs_Token()
            {
                if (Invoice_FURS_Token == null)
                {
                    Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
                }
                if (this.FURS_ZOI_v != null)
                {
                    sFURS_ZOI = this.FURS_ZOI_v.v;
                    if (this.FURS_TestEnvironment_v!=null)
                    {
                        if (this.FURS_TestEnvironment_v.v)
                        {
                            sFURS_ZOI = this.FURS_ZOI_v.v + " " + lng.s_FVI_done_in_test_environment.s;
                        }

                    }
                }
                if (this.FURS_EOR_v != null)
                {
                    sFURS_EOR = this.FURS_EOR_v.v;
                    if (this.FURS_TestEnvironment_v != null)
                    {
                        if (this.FURS_TestEnvironment_v.v)
                        {
                            sFURS_EOR = this.FURS_EOR_v.v + " " + lng.s_FVI_done_in_test_environment.s;
                        }
                    }
                }

                Invoice_FURS_Token.tUniqueMessageID.Set(sFURS_ZOI);
                Invoice_FURS_Token.tUniqueInvoiceID.Set(sFURS_EOR);

                if (this.FURS_Image_QRcode != null)
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        this.FURS_Image_QRcode.Save(m, this.FURS_Image_QRcode.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        Invoice_FURS_Token.tQR.Set(base64String);
                    }
                }
            }



            public bool Read_FURS_Response_Data(long DocInvoice_ID)
            {
                string sql = "select MessageID,UniqueInvoiceID,BarCodeValue from fvi_slo_response where DocInvoice_ID = " + DocInvoice_ID.ToString();
                string Err = null;
                DataTable dt = new DataTable();
                sFURS_ZOI = lng.s_FVI_not_done.s;
                sFURS_EOR = lng.s_FVI_not_done.s;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        FURS_ZOI_v = tf.set_string(dt.Rows[0]["MessageID"]);
                        FURS_EOR_v = tf.set_string(dt.Rows[0]["UniqueInvoiceID"]);
                        FURS_QR_v = tf.set_string(dt.Rows[0]["BarCodeValue"]);
                        FURS_TestEnvironment_v = tf.set_bool(dt.Rows[0]["TestEnvironment"]);
                        if (Invoice_FURS_Token == null)
                        {
                            Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
                        }

                        if (this.FURS_ZOI_v != null)
                        {
                            sFURS_ZOI = this.FURS_ZOI_v.v;
                            if (FURS_TestEnvironment_v!=null)
                            {
                                if (FURS_TestEnvironment_v.v)
                                {
                                    sFURS_ZOI = this.FURS_ZOI_v.v + lng.s_FVI_done_in_test_environment.s;
                                }
                            }
                        }
                        if (this.FURS_EOR_v != null)
                        {
                            sFURS_EOR = this.FURS_EOR_v.v;
                            if (FURS_TestEnvironment_v != null)
                            {
                                if (FURS_TestEnvironment_v.v)
                                {
                                    sFURS_EOR = this.FURS_EOR_v.v + lng.s_FVI_done_in_test_environment.s;
                                }
                            }
                        }

                        Invoice_FURS_Token.tUniqueMessageID.Set(sFURS_ZOI);
                        Invoice_FURS_Token.tUniqueInvoiceID.Set(sFURS_EOR);
                        Invoice_FURS_Token.tUniqueInvoiceID.Set(FURS_QR_v.v);
                        Invoice_FURS_Token.tQR.Set("");
                        this.FURS_Image_QRcode = null;
                    }
                    else
                    {
                        if (Invoice_FURS_Token == null)
                        {
                            Invoice_FURS_Token = new UniversalInvoice.Invoice_FURS_Token();
                        }
                        Invoice_FURS_Token.tUniqueMessageID.Set(sFURS_ZOI);
                        Invoice_FURS_Token.tUniqueInvoiceID.Set(sFURS_EOR);
                        Invoice_FURS_Token.tQR.Set("");
                    }
                    return true;

                }
                else
                {
                    LogFile.Error.Show("ERROR:InvoiceData:Read_FURS_Response_Data:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }

            public static string Create_furs_InvoiceXML(bool bStorno,
                                                string InvoiceXmlTemplate,
                                                string FursD_MyOrgTaxID,
                                                string FursD_BussinesPremiseID,
                                                string CasshierName,
                                                string FursD_InvoiceAuthorTaxID,
                                                string stornoReferenceInvoiceNumber,
                                                string stornoReferenceInvoiceIssueDateTime,
                                                DateTime_v IssueDate_v,
                                                long NumberInFinancialYear,
                                                decimal GrossSum,
                                                StaticLib.TaxSum taxSum,
                                                UniversalInvoice.Person Invoice_Author)
            {
                try
                {
                    //                string InvoiceXmlTemplate = Properties.Resources.FVI_SLO_Invoice;
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(InvoiceXmlTemplate);
                    XmlNodeList ndl_TaxNumber = xdoc.GetElementsByTagName("fu:TaxNumber");
                    //string sInnerText_MyOrgTaxID = Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; // "10329048";//MyOrganisation.Tax_ID;
                    ndl_TaxNumber.Item(0).InnerText = FursD_MyOrgTaxID;//Program.usrc_FVI_SLO1.FursD_MyOrgTaxID; //MyOrganisation.Tax_ID;
                    XmlNodeList ndl_IssueDateTime = xdoc.GetElementsByTagName("fu:IssueDateTime");
                    ndl_IssueDateTime.Item(0).InnerText = fs.GetFURS_Time_Formated(IssueDate_v.v);
                    XmlNodeList ndl_BusinessPremiseID = xdoc.GetElementsByTagName("fu:BusinessPremiseID");
                    //string sInnerText_FursD_BussinesPremiseID = Program.usrc_FVI_SLO1.FursD_BussinesPremiseID;
                    ndl_BusinessPremiseID.Item(0).InnerText = FursD_BussinesPremiseID;// Program.usrc_FVI_SLO1.FursD_BussinesPremiseID; // "36CF"; //MyOrganisation.Atom_Office_Name;
                    XmlNodeList ndl_ElectronicDeviceID = xdoc.GetElementsByTagName("fu:ElectronicDeviceID");
                    ndl_ElectronicDeviceID.Item(0).InnerText = CasshierName;//Properties.Settings.Default.CasshierName;
                    XmlNodeList ndl_InvoiceNumber = xdoc.GetElementsByTagName("fu:InvoiceNumber");
                    ndl_InvoiceNumber.Item(0).InnerText = NumberInFinancialYear.ToString();
                    XmlNodeList ndl_InvoiceAmount = xdoc.GetElementsByTagName("fu:InvoiceAmount");
                    ndl_InvoiceAmount.Item(0).InnerText = sStorno(bStorno) + fs.GetFursDecimalString(GrossSum);
                    XmlNodeList ndl_PaymentAmount = xdoc.GetElementsByTagName("fu:PaymentAmount");
                    ndl_PaymentAmount.Item(0).InnerText = sStorno(bStorno) + fs.GetFursDecimalString(GrossSum);

                    XmlNodeList ndl_TaxesPerSeller = xdoc.GetElementsByTagName("fu:TaxesPerSeller");
                    string s_innertext = "";
                    foreach (StaticLib.Tax tax in taxSum.TaxList)
                    {
                        string sVat = "<fu:VAT>\r\n" +
                                              "<fu:TaxRate>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.Rate * 100) + "</fu:TaxRate>\r\n" +
                                              "<fu:TaxableAmount>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.TaxableAmount) + "</fu:TaxableAmount>\r\n" +
                                              "<fu:TaxAmount>" + sStorno(bStorno) + fs.GetFursDecimalString(tax.TaxAmount) + "</fu:TaxAmount>\r\n" +
                                       "</fu:VAT>" + "\r\n";
                        s_innertext += sVat;
                    }
                    ndl_TaxesPerSeller.Item(0).InnerXml = s_innertext;

                    XmlNodeList ndl_OperatorTaxNumber = xdoc.GetElementsByTagName("fu:OperatorTaxNumber");

                    string sFursD_InvoiceAuthorTaxID = FursD_InvoiceAuthorTaxID;// Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;

                    //Invoice_Author.Tax_ID = "59729481";

                    Invoice_Author.Tax_ID = FursD_InvoiceAuthorTaxID;// Program.usrc_FVI_SLO1.FursD_InvoiceAuthorTaxID;


                    ndl_OperatorTaxNumber.Item(0).InnerText = Invoice_Author.Tax_ID;

                    //LK storno 
                    if (bStorno)
                    {
                        XmlNodeList Fu_Invoice = xdoc.GetElementsByTagName("fu:Invoice");
                        string ns = Fu_Invoice.Item(0).GetNamespaceOfPrefix("fu");

                        XmlNode xReferenceInvoice = xdoc.CreateNode("element", "ReferenceInvoice", ns);
                        XmlNode xReferenceInvoiceIdentifier = xdoc.CreateNode("element", "ReferenceInvoiceIdentifier", ns);
                        XmlNode xBusinessPremiseID = xdoc.CreateNode("element", "BusinessPremiseID", ns);
                        XmlNode xElectronicDeviceID = xdoc.CreateNode("element", "ElectronicDeviceID", ns);
                        XmlNode xInvoiceNumber = xdoc.CreateNode("element", "InvoiceNumber", ns);
                        XmlNode xReferenceInvoiceIssueDateTime = xdoc.CreateNode("element", "ReferenceInvoiceIssueDateTime", ns);
                        xReferenceInvoice.Prefix = "fu";
                        xReferenceInvoiceIdentifier.Prefix = "fu";
                        xBusinessPremiseID.Prefix = "fu";
                        xElectronicDeviceID.Prefix = "fu";
                        xInvoiceNumber.Prefix = "fu";
                        xReferenceInvoiceIssueDateTime.Prefix = "fu";


                        xBusinessPremiseID.InnerText = FursD_BussinesPremiseID;
                        xElectronicDeviceID.InnerText = CasshierName;
                        xInvoiceNumber.InnerText = stornoReferenceInvoiceNumber;
                        xReferenceInvoiceIssueDateTime.InnerText = stornoReferenceInvoiceIssueDateTime;

                        xReferenceInvoiceIdentifier.AppendChild(xBusinessPremiseID);
                        xReferenceInvoiceIdentifier.AppendChild(xElectronicDeviceID);
                        xReferenceInvoiceIdentifier.AppendChild(xInvoiceNumber);
                        xReferenceInvoice.AppendChild(xReferenceInvoiceIdentifier);
                        xReferenceInvoice.AppendChild(xReferenceInvoiceIssueDateTime);
                        Fu_Invoice.Item(0).AppendChild(xReferenceInvoice);

                        //<fu:ReferenceInvoice>
                        //  <fu:ReferenceInvoiceIdentifier >  
                        //    <fu:BusinessPremiseID > TRGOVINA1 </ fu:BusinessPremiseID >
                        //    <fu:ElectronicDeviceID > BLAG2 </ fu:ElectronicDeviceID >
                        //    <fu:InvoiceNumber > 145 </ fu:InvoiceNumber >
                        //  </fu:ReferenceInvoiceIdentifier >
                        //  <fu:ReferenceInvoiceIssueDateTime > 2015 - 09 - 07T12: 12:54 </ fu:ReferenceInvoiceIssueDateTime >
                        //</fu:ReferenceInvoice >
                    }

                    string InvoiceXml = XmlDcoumentToString(xdoc);
                    return InvoiceXml;
                }
                catch (Exception Ex)
                {
                    LogFile.Error.Show("ERROR:InvoiceData:Create_furs_InvoiceXML:Exception = " + Ex.Message);
                    return null;
                }

            }

            private static string XmlDcoumentToString(XmlDocument xmlDoc)
            {
                var settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = false;
                settings.Indent = true;
                settings.NewLineOnAttributes = true;

                var stringBuilder = new StringBuilder();
                using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
                {
                    xmlDoc.Save(xmlWriter);
                }

                return stringBuilder.ToString();
            }


            private static string sStorno(bool bStorno)
            {
                if (bStorno)
                {
                    return "";
                }
                else
                {
                    return "";
                }
            }


            public string Create_furs_SalesBookInvoiceXML(string InvoiceXmlTemplate,
                                                          string FursD_MyOrgTaxID,
                                                          string FursD_BussinesPremiseID,
                                                          string SalesBookSetNumber,
                                                          string SalesBookSerialNumber,
                                                          DateTime_v IssueDate_v,
                                                          long NumberInFinancialYear,
                                                          decimal GrossSum,
                                                          StaticLib.TaxSum taxSum)
            {
                try
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.LoadXml(InvoiceXmlTemplate);
                    XmlNodeList ndl_TaxNumber = xdoc.GetElementsByTagName("fu:TaxNumber");
                    ndl_TaxNumber.Item(0).InnerText = FursD_MyOrgTaxID;
                    XmlNodeList ndl_IssueDateTime = xdoc.GetElementsByTagName("fu:IssueDate");
                    ndl_IssueDateTime.Item(0).InnerText = IssueDate_v.v.ToString("yyyy-MM-dd");
                    XmlNodeList ndl_BusinessPremiseID = xdoc.GetElementsByTagName("fu:BusinessPremiseID");
                    ndl_BusinessPremiseID.Item(0).InnerText = FursD_BussinesPremiseID;
                    XmlNodeList ndl_InvoiceNumber = xdoc.GetElementsByTagName("fu:InvoiceNumber");
                    ndl_InvoiceNumber.Item(0).InnerText = NumberInFinancialYear.ToString();
                    XmlNodeList ndl_InvoiceAmount = xdoc.GetElementsByTagName("fu:InvoiceAmount");
                    ndl_InvoiceAmount.Item(0).InnerText = fs.GetFursDecimalString(GrossSum);
                    XmlNodeList ndl_PaymentAmount = xdoc.GetElementsByTagName("fu:PaymentAmount");
                    ndl_PaymentAmount.Item(0).InnerText = fs.GetFursDecimalString(GrossSum);

                    XmlNodeList ndl_TaxesPerSeller = xdoc.GetElementsByTagName("fu:TaxesPerSeller");
                    string s_innertext = "";
                    foreach (StaticLib.Tax tax in taxSum.TaxList)
                    {
                        string sVat = "<fu:VAT>\r\n" +
                                              "<fu:TaxRate>" + fs.GetFursDecimalString(tax.Rate * 100) + "</fu:TaxRate>\r\n" +
                                              "<fu:TaxableAmount>" + fs.GetFursDecimalString(tax.TaxableAmount) + "</fu:TaxableAmount>\r\n" +
                                              "<fu:TaxAmount>" + fs.GetFursDecimalString(tax.TaxAmount) + "</fu:TaxAmount>\r\n" +
                                       "</fu:VAT>" + "\r\n";
                        s_innertext += sVat;
                    }
                    ndl_TaxesPerSeller.Item(0).InnerXml = s_innertext;

                    // salesbook stuff
                    XmlNodeList ndl_SetNumber = xdoc.GetElementsByTagName("fu:SetNumber");
                    ndl_SetNumber.Item(0).InnerText = Convert.ToInt32(SalesBookSetNumber).ToString("D2");

                    XmlNodeList ndl_SerialNumber = xdoc.GetElementsByTagName("fu:SerialNumber");
                    ndl_SerialNumber.Item(0).InnerText = SalesBookSerialNumber;


                    string InvoiceXml = XmlDcoumentToString(xdoc);
                    return InvoiceXml;
                }
                catch (Exception Ex)
                {
                    LogFile.Error.Show("ERROR:InvoiceData:Create_furs_SalesBookInvoiceXML:Exception = " + Ex.Message);
                    return null;
                }

            }
        }

        public FURS m_FURS = new FURS();

        public bool IsCashPayment
        {
            get
            {
                if (m_MethodOfPayment_DI != null)
                {
                    return ((m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.CASH) || (m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.CASH_OR_CARD));
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsCardPayment
        {
            get
            {
                if (m_MethodOfPayment_DI != null)
                {
                    return ((m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.CARD) || (m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.CASH_OR_CARD));
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsPaymentOnBankAccount
        {
            get
            {
                if (m_MethodOfPayment_DI != null)
                {
                    return (m_MethodOfPayment_DI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER);
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
