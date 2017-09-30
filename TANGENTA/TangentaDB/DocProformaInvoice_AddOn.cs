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
        public long_v DocProformaInvoice_ID_v = null;
        public long_v DocProformaInvoiceAddOn_ID_v = null;

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

            internal DateTime ValidUntil(DateTime v)
            {
                
                switch (type)
                {
                    case 0:
                        {
                            int ilength = Convert.ToInt32(length);
                            DateTime dt = v.AddMonths(ilength);
                            return dt;
                        }
                    default: // length is in days
                        {
                            int ilength = Convert.ToInt32(length);
                            DateTime dt = v.AddDays(ilength);
                            return dt;
                        }   
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


        public class MethodOfPayment_DPI
        {
            private long m_ID = -1;
            public long ID
            {
                get { return m_ID; }
                set { m_ID = value; }
            }

            public MyOrgBankAccountPayment m_MyOrgBankAccountPayment = null;

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

            internal static MethodOfPayment_DPI Set(object oID, object oPaymentType, object oBankName,
                                                                                 object oBank_Tax_ID,
                                                                                 object oBank_Registration_ID,
                                                                                 object oBank_TaxPayer,
                                                                                 object oBank_Comment1,
                                                                                 object oBankAccount,
                                                                                 object oBankAccount_ID)
            {
                if ((oID is long) && (oPaymentType is string))
                {
                    MethodOfPayment_DPI xMethodOfPayment = new MethodOfPayment_DPI();
                    xMethodOfPayment.ID = (long)oID;
                    string xPaymentType = (string)oPaymentType;
                    string Err = null;
                    xMethodOfPayment.eType = GlobalData.Get_ePaymentType(xPaymentType, ref Err);
                    if (xMethodOfPayment.eType != GlobalData.ePaymentType.ANY_TYPE)
                    {
                        if (xMethodOfPayment.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                        {
                           if (xMethodOfPayment.m_MyOrgBankAccountPayment == null)
                            {
                                xMethodOfPayment.m_MyOrgBankAccountPayment = new MyOrgBankAccountPayment();
                            }
                            if ((oBankName is string)
                                && (oBank_Tax_ID is string)
                                && (oBankAccount is string) 
                                && (oBankAccount_ID is long))
                            {
                                xMethodOfPayment.m_MyOrgBankAccountPayment.BankName = (string)oBankName;
                                xMethodOfPayment.m_MyOrgBankAccountPayment.Bank_Tax_ID = (string)oBank_Tax_ID;
                                xMethodOfPayment.m_MyOrgBankAccountPayment.BankAccount = (string)oBankAccount;
                                xMethodOfPayment.m_MyOrgBankAccountPayment.BankAccount_ID = (long)oBankAccount_ID;
                                xMethodOfPayment.m_MyOrgBankAccountPayment.Bank_Registration_ID = null;
                                if (oBank_Registration_ID!=null)
                                {
                                    if (oBank_Registration_ID is string)
                                    {
                                        xMethodOfPayment.m_MyOrgBankAccountPayment.Bank_Registration_ID = (string)oBank_Registration_ID;
                                    }
                                }

                                xMethodOfPayment.m_MyOrgBankAccountPayment.Bank_TaxPayer_v = tf.set_bool(oBank_TaxPayer);
                                xMethodOfPayment.m_MyOrgBankAccountPayment.Bank_Comment1_v = tf.set_string(oBank_Comment1);

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

            internal bool Get(ref long_v MethodOfPayment_DPI_ID_v)
            {
                long_v Atom_BankAccount_ID_v = null;
                long_v PaymentType_ID_v = null;
                string_v PaymentType_v = null;
                
                switch (eType)
                {
                    case GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER:
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
                                if (f_MethodOfPayment_DPI.Get(eType,
                                                             Atom_BankAccount_ID_v,
                                                             ref PaymentType_ID_v,
                                                             ref PaymentType_v,
                                                             ref MethodOfPayment_DPI_ID_v))
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
                        if (f_MethodOfPayment_DPI.Get(eType,
                                                             null,
                                                             ref PaymentType_ID_v,
                                                             ref PaymentType_v,
                                                             ref MethodOfPayment_DPI_ID_v))
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
        }

        public string m_NoticeText = null;

        public bool Completed(ref ltext ltMsg)
        {
            if (m_IssueDate != null)
            {
                if (m_Duration != null)
                {
                    if (m_TermsOfPayment != null)
                    {
                        if (m_MethodOfPayment_DPI != null)
                        {
                            if (m_MethodOfPayment_DPI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                            {
                                if (m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment != null)
                                {
                                    return true;
                                }
                            }
                            else if (m_MethodOfPayment_DPI.eType != GlobalData.ePaymentType.NOT_DEFINED)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            List<object> Complex_ltMsg = new List<object>();
            if (m_IssueDate == null)
            {
                Complex_ltMsg.Add(lngRPM.s_IssueDate_not_defined);
            }
            if (m_MethodOfPayment_DPI == null)
            {
                Complex_ltMsg.Add(lngRPM.s_MethodOfPayment_DPI_not_defined);
            }
            else
            {
                if (m_MethodOfPayment_DPI.eType == GlobalData.ePaymentType.BANK_ACCOUNT_TRANSFER)
                {
                    if (m_MethodOfPayment_DPI.m_MyOrgBankAccountPayment == null)
                    {
                        Complex_ltMsg.Add(lngRPM.s_MethodOfPayment_DI_BankAccount_not_defined);
                    }
                    if (m_Duration == null)
                    {
                        Complex_ltMsg.Add(lngRPM.s_MethodOfPayment_DPI_Duration_is_not_defined);
                    }
                }
                else if (m_MethodOfPayment_DPI.eType == GlobalData.ePaymentType.NOT_DEFINED)
                {
                    Complex_ltMsg.Add(lngRPM.s_MethodOfPayment_DPI_not_defined);
                }

            }
            if (m_TermsOfPayment == null)
            {
                Complex_ltMsg.Add(lngRPM.s_TermsOfPayment_are_not_defined);
            }
            
            if (Complex_ltMsg.Count > 0)
            {
                ltMsg = new ltext(Complex_ltMsg);
            }
            return false;
        }

        public IssueDate m_IssueDate = null;
        public Duration m_Duration = null;
        public TermsOfPayment m_TermsOfPayment = null;
        public MethodOfPayment_DPI m_MethodOfPayment_DPI = null;

        private void Clear()
        {
            m_IssueDate = null;
            m_Duration = null;
            m_TermsOfPayment = null;
            m_MethodOfPayment_DPI = null;
        }

        public bool Get(long DocProformaInvoice_ID)
        {
            string Err = null;
            Clear();
            string sql = @"select 
                            dpiao.IssueDate as IssueDate,
                            dpiao.DocDuration as DocDuration,
                            dpiao.DocDurationType as DocDurationType,
                            dpiao.TermsOfPayment_ID as TermsOfPayment_ID,
                            mop.ID as MethodOfPayment_DPI_ID,
                            mop.Atom_BankAccount_ID as Atom_BankAccount_ID,
                            top.Description as TermsOfPayment_Description,
                            pt.Identification as PaymentType_Identification,
                            aba.TRR as TRR,
                            ao.Name as AtomOrganisationName,
                            ao.Tax_ID as Tax_ID,
                            ao.Registration_ID as Registration_ID,
                            ao.TaxPayer as TaxPayer,
                            acmt1.Comment as Comment1,
                            an.NoticeText as NoticeText
                            from DocProformaInvoice dpi
                            left join  DocProformaInvoiceAddOn dpiao on dpiao.DocProformaInvoice_ID = dpi.ID
                            left join  TermsOfPayment top on dpiao.TermsOfPayment_ID = top.ID
                            left join  MethodOfPayment_DPI mop on dpiao.MethodOfPayment_DPI_ID = mop.ID
                            left join  PaymentType pt on mop.PaymentType_ID = pt.ID
                            left join  Atom_BankAccount aba on mop.Atom_BankAccount_ID = aba.ID
                            left join  Atom_Bank ab on aba.Atom_Bank_ID = ab.ID
                            left join  Atom_Organisation ao on ab.Atom_Organisation_ID = ao.ID
                            left join  Atom_Comment1 acmt1 on ao.Atom_Comment1_ID = acmt1.ID
                            left join  Atom_Notice an on dpiao.Atom_Notice_ID = an.ID
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

                    m_MethodOfPayment_DPI = DocProformaInvoice_AddOn.MethodOfPayment_DPI.Set(dt.Rows[0]["MethodOfPayment_DPI_ID"],
                                                                                     dt.Rows[0]["PaymentType_Identification"],
                                                                                     dt.Rows[0]["AtomOrganisationName"],
                                                                                     dt.Rows[0]["Tax_ID"],
                                                                                     dt.Rows[0]["Registration_ID"],
                                                                                     dt.Rows[0]["TaxPayer"],
                                                                                     dt.Rows[0]["Comment1"],
                                                                                     dt.Rows[0]["TRR"],
                                                                                     dt.Rows[0]["Atom_BankAccount_ID"]);
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
                LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public bool Set(long DocProformaInvoice_ID, ref ltext ltMsg)
        {

            if (DocProformaInvoice_ID_v == null)
            {
                DocProformaInvoice_ID_v = new long_v(DocProformaInvoice_ID);
            }
            else
            {
                DocProformaInvoice_ID_v.v = DocProformaInvoice_ID;

            }

            if (f_DocProformaInvoiceAddOn.Get(DocProformaInvoice_ID_v, ref DocProformaInvoiceAddOn_ID_v))
            {
                if (DocProformaInvoiceAddOn_ID_v != null)
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
            if (DocProformaInvoice_ID_v == null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:Insert:DocProformaInvoice_ID_v== null");
                return false;
            }
            ltext ltMsg = null;
            long_v MethodOfPayment_DPI_ID_v = null;
            if (m_MethodOfPayment_DPI.Get(ref MethodOfPayment_DPI_ID_v))
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



                        string spar_DocProformaInvoice_ID = "@par_DocProformaInvoice_ID";
                        SQL_Parameter par_DocProformaInvoice_ID = new SQL_Parameter(spar_DocProformaInvoice_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, DocProformaInvoice_ID_v.v);
                        lpar.Add(par_DocProformaInvoice_ID);

                        string spar_MethodOfPayment_DPI_ID = "@par_MethodOfPayment_DPI_ID";
                        SQL_Parameter par_MethodOfPayment_DPI_ID = new SQL_Parameter(spar_MethodOfPayment_DPI_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, MethodOfPayment_DPI_ID_v.v);
                        lpar.Add(par_MethodOfPayment_DPI_ID);

                        string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
                        SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, m_TermsOfPayment.ID);
                        lpar.Add(par_TermsOfPayment_ID);

                        string sval_DocDuration = " DocDuration = null ";
                        string sval_DocDurationType = " DocDurationType = null ";
                        string spar_DocDuration = " null ";
                        string spar_DocDurationType = " null ";
                        if (m_Duration != null)
                        {
                            long lDocDureationLength = m_Duration.length;
                            int iDocDureationType = m_Duration.type;
                            spar_DocDuration = "@par_DocDuration";
                            SQL_Parameter par_DocDuration = new SQL_Parameter(spar_DocDuration, SQL_Parameter.eSQL_Parameter.Bigint, false, lDocDureationLength);
                            lpar.Add(par_DocDuration);
                            sval_DocDuration = "DocDuration = " + spar_DocDuration;
                            spar_DocDurationType = "@par_DocDurationType";
                            SQL_Parameter par_DocDurationType = new SQL_Parameter(spar_DocDurationType, SQL_Parameter.eSQL_Parameter.Int, false, iDocDureationType);
                            lpar.Add(par_DocDurationType);
                            sval_DocDurationType = "DocDurationType = " + spar_DocDuration;
                        }



                        string spar_IssueDate = "@par_IssueDate";
                        SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, m_IssueDate.Date);
                        lpar.Add(par_IssueDate);



                        string sql = @"insert into DocProformaInvoiceAddOn (DocProformaInvoice_ID,
                                                                    IssueDate,
                                                                    MethodOfPayment_DPI_ID,
                                                                    TermsOfPayment_ID,
                                                                    DocDuration,
                                                                    DocDurationType,
                                                                    Atom_Notice_ID) values
                                                                   (" + spar_DocProformaInvoice_ID + ","
                                                                   + spar_IssueDate + ","
                                                                   + spar_MethodOfPayment_DPI_ID + ","
                                                                   + spar_TermsOfPayment_ID + "," +
                                                                   spar_DocDuration + ","+
                                                                   spar_DocDurationType + ","+
                                                                   sval_Atom_Notice_ID+")";

                        object ores = null;
                        string Err = null;
                        long ID = -1;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, lpar, ref ID, ref ores, ref Err, "DocProformaInvoiceAddOn"))
                        {
                            DocProformaInvoiceAddOn_ID_v = new long_v(ID);
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn:Insert:sql=" + sql + "\r\nErr=" + Err);
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

        private bool Update()
        {
            ltext ltMsg = null;
            long_v MethodOfPayment_DPI_ID_v = null;
            if (m_MethodOfPayment_DPI.Get(ref MethodOfPayment_DPI_ID_v))
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
                            sval_Atom_Notice_ID = " Atom_Notice_ID = " + spar_Atom_Notice_ID;
                        }

                        string spar_MethodOfPayment_DPI_ID = "@par_MethodOfPayment_DPI_ID";
                        SQL_Parameter par_MethodOfPayment_ID = new SQL_Parameter(spar_MethodOfPayment_DPI_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, MethodOfPayment_DPI_ID_v.v);
                        lpar.Add(par_MethodOfPayment_ID);

                        string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
                        SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID, SQL_Parameter.eSQL_Parameter.Bigint, false, m_TermsOfPayment.ID);
                        lpar.Add(par_TermsOfPayment_ID);

                        string sval_DocDuration = " DocDuration = null ";
                        string sval_DocDurationType = " DocDurationType = null ";
                        if (m_Duration != null)
                        {
                            long lDocDureationLength = m_Duration.length;
                            int iDocDureationType = m_Duration.type;
                            string spar_DocDuration = "@par_DocDuration";
                            SQL_Parameter par_DocDuration = new SQL_Parameter(spar_DocDuration, SQL_Parameter.eSQL_Parameter.Bigint, false, lDocDureationLength);
                            lpar.Add(par_DocDuration);
                            sval_DocDuration = "DocDuration = " + spar_DocDuration;
                            string spar_DocDurationType = "@par_DocDurationType";
                            SQL_Parameter par_DocDurationType = new SQL_Parameter(spar_DocDurationType, SQL_Parameter.eSQL_Parameter.Int, false, iDocDureationType);
                            lpar.Add(par_DocDurationType);
                            sval_DocDurationType = "DocDurationType = " + spar_DocDuration;
                        }



                        string spar_IssueDate = "@par_IssueDate";
                        SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, m_IssueDate.Date);
                        lpar.Add(par_IssueDate);



                        string sql = "update DocProformaInvoiceAddOn set IssueDate = " + spar_IssueDate
                                                                + ",MethodOfPayment_DPI_ID = " + spar_MethodOfPayment_DPI_ID
                                                                + ",TermsOfPayment_ID = " + spar_TermsOfPayment_ID
                                                                + "," + sval_DocDuration
                                                                 + "," + sval_DocDurationType
                                                                 + "," + sval_Atom_Notice_ID
                                                                + " where ID = " + DocProformaInvoiceAddOn_ID_v.v.ToString();
                        object ores = null;
                        string Err = null;

                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:TangentaDB:DocProformaInvoice_AddOn:Update:sql=" + sql + "\r\nErr=" + Err);
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

    }
}
