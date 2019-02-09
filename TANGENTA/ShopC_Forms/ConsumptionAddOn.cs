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
    public class ConsumptionAddOn
    {
        public ID ConsumptionReason_ID = null;
        public ID ConsumptionDescription_ID = null;
        public ID ConsumptionAddOn_ID = null;

        private DataTable m_dtConsumptionReason = null;
        public DataTable dtConsumptionReason
        {
            get
            {
                return m_dtConsumptionReason;
            }
        }

        private string reasonName = null;
        public string ReasonName
        {
            get
            {
                return reasonName;
            }
            set
            {
                reasonName = value;
            }
        }

        private string reasonDescription = null;
        public string ReasonDescription
        {
            get
            {
                return reasonDescription;
            }
            set
            {
                reasonDescription = value;
            }
        }


        private string descriptionName = null;
        public string DescriptionName
        {
            get
            {
                return descriptionName;
            }
            set
            {
                descriptionName = value;
            }
        }
        private string descriptionDescription = null;
        public string DescriptionDescription
        {
            get
            {
                return descriptionDescription;
            }
            set
            {
                descriptionDescription = value;
            }
        }

        private DataTable m_dtConsumptionDescription = null;
        public DataTable dtConsumptionDescription
        {
            get
            {
                return m_dtConsumptionDescription;
            }
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

        public bool GetReasonTable()
        {
            return f_ConsumptionReason.GetTable(ref m_dtConsumptionReason);
        }

        public bool GetDescriptionTable()
        {
            return f_ConsumptionReason.GetTable(ref m_dtConsumptionDescription);
        }


        public bool Completed(ref ltext ltMsg)
        {
                List<object> Complex_ltMsg = new List<object>();
            
                if (MyIssueDate == null)
                {
                    Complex_ltMsg.Add(lng.s_IssueDate_not_defined);
                    return false;
                }
                if (Complex_ltMsg.Count>0)
                {
                    ltMsg = new ltext(Complex_ltMsg);
                }
                return true;
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

        public bool Get(ID Consumption_ID)
        {
            string Err = null;
            Clear();
            string sql = @"SELECT ConsumptionAddOn.ID,
                                  ConsumptionAddOn.IssueDate AS ConsumptionAddOn_$$IssueDate,
                                  ConsumptionAddOn_$_cs.ID AS ConsumptionAddOn_$_cs_$$ID,
                                  ConsumptionAddOn_$_cs.Draft AS ConsumptionAddOn_$_cs_$$Draft,
                                  ConsumptionAddOn_$_cs.DraftNumber AS ConsumptionAddOn_$_cs_$$DraftNumber,
                                  ConsumptionAddOn_$_cs.FinancialYear AS ConsumptionAddOn_$_cs_$$FinancialYear,
                                  ConsumptionAddOn_$_cs.NumberInFinancialYear AS ConsumptionAddOn_$_cs_$$NumberInFinancialYear,
                                  ConsumptionAddOn_$_cs.NetSum AS ConsumptionAddOn_$_cs_$$NetSum,
                                  ConsumptionAddOn_$_cs.EndSum AS ConsumptionAddOn_$_cs_$$EndSum,
                                  ConsumptionAddOn_$_cs.TaxSum AS ConsumptionAddOn_$_cs_$$TaxSum,
                                  ConsumptionAddOn_$_cs.GrossSum AS ConsumptionAddOn_$_cs_$$GrossSum,
                                  ConsumptionAddOn_$_cs_$_acur.ID AS ConsumptionAddOn_$_cs_$_acur_$$ID,
                                  ConsumptionAddOn_$_cs_$_acur.Name AS ConsumptionAddOn_$_cs_$_acur_$$Name,
                                  ConsumptionAddOn_$_cs_$_acur.Abbreviation AS ConsumptionAddOn_$_cs_$_acur_$$Abbreviation,
                                  ConsumptionAddOn_$_cs_$_acur.Symbol AS ConsumptionAddOn_$_cs_$_acur_$$Symbol,
                                  ConsumptionAddOn_$_cs_$_acur.CurrencyCode AS ConsumptionAddOn_$_cs_$_acur_$$CurrencyCode,
                                  ConsumptionAddOn_$_cs_$_acur.DecimalPlaces AS ConsumptionAddOn_$_cs_$_acur_$$DecimalPlaces,
                                  ConsumptionAddOn_$_cs.Storno AS ConsumptionAddOn_$_cs_$$Storno,
                                  ConsumptionAddOn_$_cs.Consumption_Reference_ID AS ConsumptionAddOn_$_cs_$$Consumption_Reference_ID,
                                  ConsumptionAddOn_$_cs.Consumption_Reference_Type AS ConsumptionAddOn_$_cs_$$Consumption_Reference_Type,
                                  ConsumptionAddOn_$_cs_$_cst.ID AS ConsumptionAddOn_$_cs_$_cst_$$ID,
                                  ConsumptionAddOn_$_cs_$_cst.Name AS ConsumptionAddOn_$_cs_$_cst_$$Name,
                                  ConsumptionAddOn_$_cs_$_cst.Description AS
                                  ConsumptionAddOn_$_cs_$_cst_$$Description,
                                  ConsumptionAddOn_$_our.ID AS ConsumptionAddOn_$_our_$$ID,
                                  ConsumptionAddOn_$_our.Name AS ConsumptionAddOn_$_our_$$Name,
                                  ConsumptionAddOn_$_our.Description AS ConsumptionAddOn_$_our_$$Description,
                                  ConsumptionAddOn_$_oud.ID AS ConsumptionAddOn_$_oud_$$ID,
                                  ConsumptionAddOn_$_oud.Name AS ConsumptionAddOn_$_oud_$$Name,
                                  ConsumptionAddOn_$_oud.Description AS ConsumptionAddOn_$_oud_$$Description,
                                  ConsumptionAddOn_$_dimgl.ID AS ConsumptionAddOn_$_dimgl_$$ID,
                                  ConsumptionAddOn_$_dimgl.Image_Hash AS ConsumptionAddOn_$_dimgl_$$Image_Hash,
                                  ConsumptionAddOn_$_dimgl.Image_Data AS ConsumptionAddOn_$_dimgl_$$Image_Data,
                                  ConsumptionAddOn_$_dimgl.Description AS ConsumptionAddOn_$_dimgl_$$Description
                                  FROM ConsumptionAddOn INNER JOIN Consumption ConsumptionAddOn_$_cs ON ConsumptionAddOn.Consumption_ID = ConsumptionAddOn_$_cs.ID 
                                  INNER JOIN Atom_Currency ConsumptionAddOn_$_cs_$_acur ON ConsumptionAddOn_$_cs.Atom_Currency_ID = ConsumptionAddOn_$_cs_$_acur.ID 
                                  INNER JOIN ConsumptionType ConsumptionAddOn_$_cs_$_cst ON ConsumptionAddOn_$_cs.ConsumptionType_ID = ConsumptionAddOn_$_cs_$_cst.ID 
                                  INNER JOIN ConsumptionReason ConsumptionAddOn_$_our ON ConsumptionAddOn.ConsumptionReason_ID = ConsumptionAddOn_$_our.ID 
                                  INNER JOIN ConsumptionDescription ConsumptionAddOn_$_oud ON ConsumptionAddOn.ConsumptionDescription_ID = ConsumptionAddOn_$_oud.ID 
                                  INNER JOIN Doc_ImageLib ConsumptionAddOn_$_dimgl ON ConsumptionAddOn.Doc_ImageLib_ID = ConsumptionAddOn_$_dimgl.ID
                                  where  ConsumptionAddOn_$_cs.ID = " + Consumption_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    MyIssueDate = ConsumptionAddOn.IssueDate.Set(dt.Rows[0]["ConsumptionAddOn_$$IssueDate"]);
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TangentaDB:WriteOff_AddOn:Get:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        public bool Set(ID consumption_ID,Transaction transaction)

        {
            if (f_ConsumptionAddOn.Get(MyIssueDate.Date,
                                ReasonName,
                                reasonDescription,
                                descriptionName,
                                descriptionDescription,
                                consumption_ID,
                                ref ConsumptionDescription_ID,
                                ref ConsumptionReason_ID,
                                ref ConsumptionAddOn_ID,
                                transaction))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        //private bool Insert(Transaction transaction)
        //{
        //    if (Consumption_ID== null)
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:Insert:WriteOff_ID_v== null");
        //        return false;
        //    }
        //    ltext ltMsg = null;

        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

        //    ID Atom_Notice_ID = null;
        //    ID Notice_ID = null;


        //    string spar_WriteOff_ID = "@par_WriteOff_ID";
        //    SQL_Parameter par_WriteOff_ID = new SQL_Parameter(spar_WriteOff_ID, false, Consumption_ID);
        //    lpar.Add(par_WriteOff_ID);



        //    string spar_IssueDate = "@par_IssueDate";
        //    SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, MyIssueDate.Date);
        //    lpar.Add(par_IssueDate);

                        


        //    string sql = @"insert into WriteOffAddOn (WriteOff_ID,
        //                                                IssueDate) values
        //                                                (" + spar_WriteOff_ID + ","
        //                                                + spar_IssueDate +","
        //                                                +")";
                                                              
        //    string Err = null;
        //    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar,ref ConsumptionAddOn_ID, ref Err, "WriteOffAddOn"))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:WriteOff_AddOn:Insert:sql=" + sql + "\r\nErr=" + Err);
        //        return false;
        //    }
        //}

        //private bool Update(Transaction transaction)
        //{
        //    //ltext ltMsg = null;   
        //    //ID MethodOfPayment_DI_ID = null;
        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

        //    //string sval_Atom_Notice_ID = " Atom_Notice_ID = null ";
        //    //ID Atom_Notice_ID = null;
        //    //ID Notice_ID = null;

        //    //if (m_NoticeText != null)
        //    //{
        //    //    if (!f_Notice.Get(m_NoticeText, ref Notice_ID, transaction))
        //    //    {
        //    //        return false;
        //    //    }
        //    //    if (!f_Atom_Notice.Get(m_NoticeText, ref Atom_Notice_ID, transaction))
        //    //    {
        //    //        return false;
        //    //    }
        //    //    string notice_text = m_NoticeText;
        //    //    string spar_Atom_Notice_ID = "@par_Atom_Notice_ID";
        //    //    SQL_Parameter par_Atom_Notice_ID = new SQL_Parameter(spar_Atom_Notice_ID, false, Atom_Notice_ID);
        //    //    lpar.Add(par_Atom_Notice_ID);
        //    //    sval_Atom_Notice_ID = " Atom_Notice_ID = "+ spar_Atom_Notice_ID;
        //    //}

        //    //string spar_MethodOfPayment_ID = "@par_MethodOfPayment_ID";
        //    //SQL_Parameter par_MethodOfPayment_ID = new SQL_Parameter(spar_MethodOfPayment_ID,  false, MethodOfPayment_DI_ID);
        //    //lpar.Add(par_MethodOfPayment_ID);

        //    //string spar_TermsOfPayment_ID = "@par_TermsOfPayment_ID";
        //    //SQL_Parameter par_TermsOfPayment_ID = new SQL_Parameter(spar_TermsOfPayment_ID,  false, MyTermsOfPayment.ID);
        //    //lpar.Add(par_TermsOfPayment_ID);

        //    //string sval_PaymentDeadline = " PaymentDeadline = null ";
        //    //if (MyPaymentDeadline != null)
        //    //{
        //    //    string spar_PaymentDeadline = "@par_PaymentDeadline";
        //    //    SQL_Parameter par_PaymentDeadline = new SQL_Parameter(spar_PaymentDeadline, SQL_Parameter.eSQL_Parameter.Datetime, false, MyPaymentDeadline.Date);
        //    //    lpar.Add(par_PaymentDeadline);
        //    //    sval_PaymentDeadline = "PaymentDeadline = " + spar_PaymentDeadline;
        //    //}

                     


        //    string spar_IssueDate = "@par_IssueDate";
        //    SQL_Parameter par_IssueDate = new SQL_Parameter(spar_IssueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, MyIssueDate.Date);
        //    lpar.Add(par_IssueDate);


        //    string sql = "update WriteOffAddOn set IssueDate = " + spar_IssueDate /*
        //                                            + ",MethodOfPayment_DI_ID = " + spar_MethodOfPayment_ID
        //                                            + ",TermsOfPayment_ID = " + spar_TermsOfPayment_ID
        //                                            + "," + sval_PaymentDeadline
        //                                            + "," + sval_Atom_Notice_ID */
        //                                            + " where ID = " + ConsumptionAddOn_ID.ToString();
        //    string Err = null;

        //    if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, lpar,  ref Err))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:WriteOff_AddOn:Update:sql=" + sql + "\r\nErr=" + Err);
        //        return false;
        //    }
        //}
    }
}
