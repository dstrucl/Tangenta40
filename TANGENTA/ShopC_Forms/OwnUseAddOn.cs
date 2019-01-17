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
using TangentaDB;

namespace ShopC_Forms
{
    public class OwnUseAddOn
    {
        public ID WriteOff_ID = null;
        public ID WriteOffAddOn_ID = null;

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


        public string m_NoticeText = null;


        public bool Completed(ref ltext ltMsg)
        {
            if (MyIssueDate != null)
            {
            }
            List<object> Complex_ltMsg = new List<object>();
            if (MyIssueDate == null)
            {
                Complex_ltMsg.Add(lng.s_IssueDate_not_defined);
            }
            if (Complex_ltMsg.Count>0)
            {
                ltMsg = new ltext(Complex_ltMsg);
            }
                
            return false;
        }

        private IssueDate m_IssueDate = null;

        public IssueDate MyIssueDate
        {
            get
            {
                return m_IssueDate;
            }
            set
            {
                m_IssueDate = value;
            }
        }


        private void Clear()
        {
            MyIssueDate = null;
        }

        public bool Get(ID WriteOff_ID)
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
                            from WriteOff di
							inner join  WriteOffAddOn diao on diao.WriteOff_ID = di.ID
                            left join  TermsOfPayment topay on diao.TermsOfPayment_ID = topay.ID
                            left join  MethodOfPayment_DI mop on diao.MethodOfPayment_DI_ID = mop.ID
                            left join  PaymentType pt on mop.PaymentType_ID = pt.ID
                            left join  Atom_BankAccount aba on mop.Atom_BankAccount_ID = aba.ID
                            left join  Atom_Bank ab on aba.Atom_Bank_ID = ab.ID
                            left join  Atom_Organisation ao on ab.Atom_Organisation_ID = ao.ID
                            left join  Atom_Comment1 acmt1 on acmt1.ID = ao.Atom_Comment1_ID
                            left join  Atom_Notice an on diao.Atom_Notice_ID = an.ID
                            where di.ID = " + WriteOff_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    MyIssueDate = OwnUseAddOn.IssueDate.Set(dt.Rows[0]["IssueDate"]);

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
                LogFile.Error.Show("ERROR:TangentaDB:WriteOff_AddOn:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public bool Set(ID WriteOff_ID, Transaction transaction)
        {
           
                if (this.WriteOff_ID == null)
                {
                    this.WriteOff_ID = new ID(WriteOff_ID);
                }
                else
                {
                    this.WriteOff_ID = WriteOff_ID;
                }

                if (f_WriteOffAddOn.Get(this.WriteOff_ID, ref WriteOffAddOn_ID))
                {
                    if (ID.Validate(WriteOffAddOn_ID))
                    {
                        return Update(transaction);
                    }
                    else
                    {
                        return Insert(transaction);
                    }
                }
                else
                {
                    return false;
                }
           
        }

        private bool Insert(Transaction transaction)
        {
            if (WriteOff_ID== null)
            {
                LogFile.Error.Show("ERROR:TangentaDB:Insert:WriteOff_ID_v== null");
                return false;
            }
            ltext ltMsg = null;

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            ID Atom_Notice_ID = null;
            ID Notice_ID = null;


            string spar_WriteOff_ID = "@par_WriteOff_ID";
            SQL_Parameter par_WriteOff_ID = new SQL_Parameter(spar_WriteOff_ID, false, WriteOff_ID);
            lpar.Add(par_WriteOff_ID);



            string spar_IssueDate = "@par_IssueDate";
            SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, MyIssueDate.Date);
            lpar.Add(par_IssueDate);

                        


            string sql = @"insert into WriteOffAddOn (WriteOff_ID,
                                                        IssueDate) values
                                                        (" + spar_WriteOff_ID + ","
                                                        + spar_IssueDate +","
                                                        +")";
                                                              
            string Err = null;
            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar,ref WriteOffAddOn_ID, ref Err, "WriteOffAddOn"))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:WriteOff_AddOn:Insert:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool Update(Transaction transaction)
        {
            //ltext ltMsg = null;   
            //ID MethodOfPayment_DI_ID = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();

            //string sval_Atom_Notice_ID = " Atom_Notice_ID = null ";
            //ID Atom_Notice_ID = null;
            //ID Notice_ID = null;

            //if (m_NoticeText != null)
            //{
            //    if (!f_Notice.Get(m_NoticeText, ref Notice_ID, transaction))
            //    {
            //        return false;
            //    }
            //    if (!f_Atom_Notice.Get(m_NoticeText, ref Atom_Notice_ID, transaction))
            //    {
            //        return false;
            //    }
            //    string notice_text = m_NoticeText;
            //    string spar_Atom_Notice_ID = "@par_Atom_Notice_ID";
            //    SQL_Parameter par_Atom_Notice_ID = new SQL_Parameter(spar_Atom_Notice_ID, false, Atom_Notice_ID);
            //    lpar.Add(par_Atom_Notice_ID);
            //    sval_Atom_Notice_ID = " Atom_Notice_ID = "+ spar_Atom_Notice_ID;
            //}

            //string spar_MethodOfPayment_ID = "@par_MethodOfPayment_ID";
            //SQL_Parameter par_MethodOfPayment_ID = new SQL_Parameter(spar_MethodOfPayment_ID,  false, MethodOfPayment_DI_ID);
            //lpar.Add(par_MethodOfPayment_ID);

            //string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
            //SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID,  false, MyTermsOfPayment.ID);
            //lpar.Add(par_TermsOfPayment_ID);

            //string sval_PaymentDeadline = " PaymentDeadline = null ";
            //if (MyPaymentDeadline != null)
            //{
            //    string spar_PaymentDeadline = "@par_PaymentDeadline";
            //    SQL_Parameter par_PaymentDeadline = new SQL_Parameter(spar_PaymentDeadline, SQL_Parameter.eSQL_Parameter.Datetime, false, MyPaymentDeadline.Date);
            //    lpar.Add(par_PaymentDeadline);
            //    sval_PaymentDeadline = "PaymentDeadline = " + spar_PaymentDeadline;
            //}

                     


            string spar_IssueDate = "@par_IssueDate";
            SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, MyIssueDate.Date);
            lpar.Add(par_IssueDate);


            string sql = "update WriteOffAddOn set IssueDate = " + spar_IssueDate /*
                                                    + ",MethodOfPayment_DI_ID = " + spar_MethodOfPayment_ID
                                                    + ",TermsOfPayment_ID = " + spar_TermsOfPayment_ID
                                                    + "," + sval_PaymentDeadline
                                                    + "," + sval_Atom_Notice_ID */
                                                    + " where ID = " + WriteOffAddOn_ID.ToString();
            string Err = null;

            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar,  ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:WriteOff_AddOn:Update:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }
    }
}
