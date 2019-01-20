﻿using DBConnectionControl40;
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
        public ID OwnUseReason_ID = null;
        public ID OwnUseDescription_ID = null;
        public ID OwnUseAddOn_ID = null;

        private DataTable m_dtOwnUseReason = null;
        public DataTable dtOwnUseReason
        {
            get
            {
                return m_dtOwnUseReason;
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

        private DataTable m_dtOwnUseDescription = null;
        public DataTable dtOwnUseDescription
        {
            get
            {
                return m_dtOwnUseDescription;
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
            return f_OwnUseReason.GetTable(ref m_dtOwnUseReason);
        }

        public bool GetDescriptionTable()
        {
            return f_OwnUseReason.GetTable(ref m_dtOwnUseDescription);
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
            string sql = @"SELECT OwnUseAddOn.ID,
                                  OwnUseAddOn.IssueDate AS OwnUseAddOn_$$IssueDate,
                                  OwnUseAddOn_$_cs.ID AS OwnUseAddOn_$_cs_$$ID,
                                  OwnUseAddOn_$_cs.Draft AS OwnUseAddOn_$_cs_$$Draft,
                                  OwnUseAddOn_$_cs.DraftNumber AS OwnUseAddOn_$_cs_$$DraftNumber,
                                  OwnUseAddOn_$_cs.FinancialYear AS OwnUseAddOn_$_cs_$$FinancialYear,
                                  OwnUseAddOn_$_cs.NumberInFinancialYear AS OwnUseAddOn_$_cs_$$NumberInFinancialYear,
                                  OwnUseAddOn_$_cs.NetSum AS OwnUseAddOn_$_cs_$$NetSum,
                                  OwnUseAddOn_$_cs.EndSum AS OwnUseAddOn_$_cs_$$EndSum,
                                  OwnUseAddOn_$_cs.TaxSum AS OwnUseAddOn_$_cs_$$TaxSum,
                                  OwnUseAddOn_$_cs.GrossSum AS OwnUseAddOn_$_cs_$$GrossSum,
                                  OwnUseAddOn_$_cs_$_acur.ID AS OwnUseAddOn_$_cs_$_acur_$$ID,
                                  OwnUseAddOn_$_cs_$_acur.Name AS OwnUseAddOn_$_cs_$_acur_$$Name,
                                  OwnUseAddOn_$_cs_$_acur.Abbreviation AS OwnUseAddOn_$_cs_$_acur_$$Abbreviation,
                                  OwnUseAddOn_$_cs_$_acur.Symbol AS OwnUseAddOn_$_cs_$_acur_$$Symbol,
                                  OwnUseAddOn_$_cs_$_acur.CurrencyCode AS OwnUseAddOn_$_cs_$_acur_$$CurrencyCode,
                                  OwnUseAddOn_$_cs_$_acur.DecimalPlaces AS OwnUseAddOn_$_cs_$_acur_$$DecimalPlaces,
                                  OwnUseAddOn_$_cs.Storno AS OwnUseAddOn_$_cs_$$Storno,
                                  OwnUseAddOn_$_cs.Consumption_Reference_ID AS OwnUseAddOn_$_cs_$$Consumption_Reference_ID,
                                  OwnUseAddOn_$_cs.Consumption_Reference_Type AS OwnUseAddOn_$_cs_$$Consumption_Reference_Type,
                                  OwnUseAddOn_$_cs_$_cst.ID AS OwnUseAddOn_$_cs_$_cst_$$ID,
                                  OwnUseAddOn_$_cs_$_cst.Name AS OwnUseAddOn_$_cs_$_cst_$$Name,
                                  OwnUseAddOn_$_cs_$_cst.Description AS
                                  OwnUseAddOn_$_cs_$_cst_$$Description,
                                  OwnUseAddOn_$_our.ID AS OwnUseAddOn_$_our_$$ID,
                                  OwnUseAddOn_$_our.Name AS OwnUseAddOn_$_our_$$Name,
                                  OwnUseAddOn_$_our.Description AS OwnUseAddOn_$_our_$$Description,
                                  OwnUseAddOn_$_oud.ID AS OwnUseAddOn_$_oud_$$ID,
                                  OwnUseAddOn_$_oud.Name AS OwnUseAddOn_$_oud_$$Name,
                                  OwnUseAddOn_$_oud.Description AS OwnUseAddOn_$_oud_$$Description,
                                  OwnUseAddOn_$_dimgl.ID AS OwnUseAddOn_$_dimgl_$$ID,
                                  OwnUseAddOn_$_dimgl.Image_Hash AS OwnUseAddOn_$_dimgl_$$Image_Hash,
                                  OwnUseAddOn_$_dimgl.Image_Data AS OwnUseAddOn_$_dimgl_$$Image_Data,
                                  OwnUseAddOn_$_dimgl.Description AS OwnUseAddOn_$_dimgl_$$Description
                                  FROM OwnUseAddOn INNER JOIN Consumption OwnUseAddOn_$_cs ON OwnUseAddOn.Consumption_ID = OwnUseAddOn_$_cs.ID 
                                  INNER JOIN Atom_Currency OwnUseAddOn_$_cs_$_acur ON OwnUseAddOn_$_cs.Atom_Currency_ID = OwnUseAddOn_$_cs_$_acur.ID 
                                  INNER JOIN ConsumptionType OwnUseAddOn_$_cs_$_cst ON OwnUseAddOn_$_cs.ConsumptionType_ID = OwnUseAddOn_$_cs_$_cst.ID 
                                  INNER JOIN OwnUseReason OwnUseAddOn_$_our ON OwnUseAddOn.OwnUseReason_ID = OwnUseAddOn_$_our.ID 
                                  INNER JOIN OwnUseDescription OwnUseAddOn_$_oud ON OwnUseAddOn.OwnUseDescription_ID = OwnUseAddOn_$_oud.ID 
                                  INNER JOIN Doc_ImageLib OwnUseAddOn_$_dimgl ON OwnUseAddOn.Doc_ImageLib_ID = OwnUseAddOn_$_dimgl.ID
                                  where  OwnUseAddOn_$_cs.ID = " + Consumption_ID.ToString();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                if (dt.Rows.Count > 0)
                {
                    MyIssueDate = OwnUseAddOn.IssueDate.Set(dt.Rows[0]["OwnUseAddOn_$$IssueDate"]);
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
            if (f_OwnUseAddOn.Get(MyIssueDate.Date,
                                ReasonName,
                                reasonDescription,
                                descriptionName,
                                descriptionDescription,
                                consumption_ID,
                                ref OwnUseDescription_ID,
                                ref OwnUseReason_ID,
                                ref OwnUseAddOn_ID,
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
        //    if (OwnUse_ID== null)
        //    {
        //        LogFile.Error.Show("ERROR:TangentaDB:Insert:WriteOff_ID_v== null");
        //        return false;
        //    }
        //    ltext ltMsg = null;

        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();

        //    ID Atom_Notice_ID = null;
        //    ID Notice_ID = null;


        //    string spar_WriteOff_ID = "@par_WriteOff_ID";
        //    SQL_Parameter par_WriteOff_ID = new SQL_Parameter(spar_WriteOff_ID, false, OwnUse_ID);
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
        //    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, lpar,ref OwnUseAddOn_ID, ref Err, "WriteOffAddOn"))
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
        //                                            + " where ID = " + OwnUseAddOn_ID.ToString();
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
