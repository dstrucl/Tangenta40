using DBConnectionControl40;
using DBTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TangentaDB;

namespace UpgradeDB
{
   

    public class CashierActivityList
    {
        public List<CashierActivity> Items = new List<CashierActivity>();

        public void Add(CashierActivity.DocInvoiceData xDocInvoiceData)
        {
            ID xFirstAtom_WorkPeriod_ID = null;
            DateTime_v FirstAtomWorkPeriodLoginTimeCoveringIssueDate_v = null;
            if (FindFirstAtomWorkPeriodTimeCoveringIssueDate(xDocInvoiceData,
                                                            ref FirstAtomWorkPeriodLoginTimeCoveringIssueDate_v,
                                                            ref xFirstAtom_WorkPeriod_ID))
            {
                ID xLastAtom_WorkPeriod_ID = null;
                DateTime_v LastAtomWorkPeriodLoginTimeCoveringIssueDate_v = null;
                if (FindLastAtomWorkPeriodTimeCoveringIssueDate(xDocInvoiceData,
                        ref LastAtomWorkPeriodLoginTimeCoveringIssueDate_v,
                        ref xLastAtom_WorkPeriod_ID))
                {
                    CashierActivity itm = FindCashierActivity(
                                                    xDocInvoiceData,
                                                    FirstAtomWorkPeriodLoginTimeCoveringIssueDate_v.v,
                                                    xFirstAtom_WorkPeriod_ID,
                                                    LastAtomWorkPeriodLoginTimeCoveringIssueDate_v.v,
                                                    xLastAtom_WorkPeriod_ID);
                    if (itm == null)
                    {
                        itm = new CashierActivity(xDocInvoiceData,
                                                  Items.Count + 1,
                                                  xFirstAtom_WorkPeriod_ID,
                                                  FirstAtomWorkPeriodLoginTimeCoveringIssueDate_v.v,
                                                  xLastAtom_WorkPeriod_ID,
                                                  LastAtomWorkPeriodLoginTimeCoveringIssueDate_v.v
                                                );
                        Items.Add(itm);
                    }
                }
            }
        }


        private CashierActivity FindCashierActivity(CashierActivity.DocInvoiceData xDocInvoiceData,
                                               DateTime xFirstAtomWorkPeriodLoginTimeCoveringIssueDateID,
                                               ID xFirstAtom_WorkPeriod_ID,
                                               DateTime xLastAtomWorkPeriodLoginTimeCoveringIssueDateID,
                                               ID xLastAtom_WorkPeriod_ID)
        {
            //check extending before
            foreach (CashierActivity ca in Items)
            {
                bool bFound = false;
                if (IsInTimeBetween(xFirstAtomWorkPeriodLoginTimeCoveringIssueDateID,
                                   ca.FirstLogin,
                                   xLastAtomWorkPeriodLoginTimeCoveringIssueDateID))
                {
                    ca.FirstLogin = xFirstAtomWorkPeriodLoginTimeCoveringIssueDateID;
                    ca.First_Atom_WorkPeriod_ID = xFirstAtom_WorkPeriod_ID;
                    bFound = true;

                }
                if (IsInTimeBetween(xFirstAtomWorkPeriodLoginTimeCoveringIssueDateID,
                                   ca.LastLogin,
                                   xLastAtomWorkPeriodLoginTimeCoveringIssueDateID))
                {
                    ca.LastLogin = xLastAtomWorkPeriodLoginTimeCoveringIssueDateID;
                    ca.Last_Atom_WorkPeriod_ID = xLastAtom_WorkPeriod_ID;
                    bFound = true;
                }
                if (bFound)
                {
                    ca.Add(xDocInvoiceData);
                    return ca;
                }
                else
                {
                    foreach (CashierActivity.DocInvoiceData did in ca.DocInvoice_ID_List)
                    {
                        DateTime caIssueDate = new DateTime(did.IssueJustDate.Year, did.IssueJustDate.Month, did.IssueJustDate.Day);
                        if (did.IssueDate.Hour > 2)
                        {
                            DateTime dtAfterMidnight = xDocInvoiceData.IssueDate.AddHours(-2);

                            DateTime xIssueJustDate_AfterMidnight = new DateTime(dtAfterMidnight.Year, dtAfterMidnight.Month, dtAfterMidnight.Day);
                            DateTime xIssueJustDate = new DateTime(xDocInvoiceData.IssueDate.Year, xDocInvoiceData.IssueDate.Month, xDocInvoiceData.IssueDate.Day);

                            if ((caIssueDate == xIssueJustDate) || (caIssueDate == xIssueJustDate_AfterMidnight))
                            {
                                if (ca.FirstLogin > xFirstAtomWorkPeriodLoginTimeCoveringIssueDateID)
                                {
                                    ca.FirstLogin = xFirstAtomWorkPeriodLoginTimeCoveringIssueDateID;
                                    ca.First_Atom_WorkPeriod_ID = xFirstAtom_WorkPeriod_ID;
                                }

                                if (ca.LastLogin < xLastAtomWorkPeriodLoginTimeCoveringIssueDateID)
                                {
                                    ca.LastLogin = xLastAtomWorkPeriodLoginTimeCoveringIssueDateID;
                                    ca.Last_Atom_WorkPeriod_ID = xLastAtom_WorkPeriod_ID;
                                }
                                ca.Add(xDocInvoiceData);
                                return ca;
                            }
                        }
                    }
                    if (IsInTimeBetween(ca.FirstLogin,
                                        xDocInvoiceData.IssueDate,
                                        ca.LastLogin))
                    {
                        ca.Add(xDocInvoiceData);
                        return ca;
                    }
                }
            }
            return null;
        }

        private bool IsInTimeBetween(DateTime xTimeStart, DateTime TimeInBetween, DateTime xTimeEnd)
        {
            return ((TimeInBetween >= xTimeStart) && (TimeInBetween < xTimeEnd));
        }

        internal static string svillabelacorrection = " awp.ID<> 140 and ";

        private bool FindFirstAtomWorkPeriodTimeCoveringIssueDate(CashierActivity.DocInvoiceData xDocInvoiceData,
                                                                 ref DateTime_v xFirstAtomWorkPeriodLoginTimeCoveringIssueDate_v,
                                                                 ref ID xFirstAtom_WorkPeriod_ID)
        {
            xFirstAtomWorkPeriodLoginTimeCoveringIssueDate_v = null;
            xFirstAtom_WorkPeriod_ID = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_issueDate = "@par_IssueDate";
            SQL_Parameter par_issueDate = new SQL_Parameter(spar_issueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, xDocInvoiceData.IssueDate);
            lpar.Add(par_issueDate);
            string sql = @"select awp.ID as Atom_WorkPeriod_ID,
                            awp.Atom_myOrganisation_Person_ID as Atom_myOrganisation_Person_ID,
                            aed.Name as Atom_ElectronicDevice_Name,
                            aed.Description as Atom_ElectronicDevice_Description,
                            awp.LoginTime as LoginTime,
                            awp.LogoutTime as LogoutTime,
                            awpt.Name as Atom_WorkPeriod_TYPE_Name,
                            awpt.Description as Atom_WorkPeriod_TYPE_Description
                            from Atom_WorkPeriod awp
                            INNER JOIN Atom_ElectronicDevice aed ON aed.ID = awp.Atom_ElectronicDevice_ID
                            LEFT JOIN Atom_WorkPeriod_TYPE awpt on awpt.ID = awp.Atom_WorkPeriod_TYPE_ID 
							 where "+ CashierActivityList.svillabelacorrection + " " + spar_issueDate + @" > awp.LoginTime
						     and  " + spar_issueDate + " < awp.LogoutTime order by awp.LoginTime asc";

            DataTable dtAWP = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtAWP, sql, lpar, ref Err))
            {
                int iCount = dtAWP.Rows.Count;

                if (iCount > 0)
                {
                    xFirstAtomWorkPeriodLoginTimeCoveringIssueDate_v = tf.set_DateTime(dtAWP.Rows[0]["LoginTime"]);
                    xFirstAtom_WorkPeriod_ID = tf.set_ID(dtAWP.Rows[0]["Atom_WorkPeriod_ID"]);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:UpgradeDB:CashierActivityList:FindFirstAtomWorkPeriodTimeCoveringIssueDate: No LoginTime found !");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:UpgradeDB:CashierActivityList:FindFirstAtomWorkPeriodTimeCoveringIssueDate:sql" + sql + "\r\nErr" + Err);
                return false;

            }
        }

        private bool FindLastAtomWorkPeriodTimeCoveringIssueDate(CashierActivity.DocInvoiceData xDocInvoiceData,
                                                                ref DateTime_v xLastAtomWorkPeriodLoginTimeCoveringIssueDate_v,
                                                                 ref ID xLastAtom_WorkPeriod_ID)
        {
            xLastAtomWorkPeriodLoginTimeCoveringIssueDate_v = null;
            xLastAtom_WorkPeriod_ID = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_issueDate = "@par_IssueDate";
            SQL_Parameter par_issueDate = new SQL_Parameter(spar_issueDate, SQL_Parameter.eSQL_Parameter.Datetime, false, xDocInvoiceData.IssueDate);
            lpar.Add(par_issueDate);
            string sql = @"select awp.ID as Atom_WorkPeriod_ID,
                            awp.Atom_myOrganisation_Person_ID as Atom_myOrganisation_Person_ID,
                            aed.Name as Atom_ElectronicDevice_Name,
                            aed.Description as Atom_ElectronicDevice_Description,
                            awp.LoginTime as LoginTime,
                            awp.LogoutTime as LogoutTime,
                            awpt.Name as Atom_WorkPeriod_TYPE_Name,
                            awpt.Description as Atom_WorkPeriod_TYPE_Description
                            from Atom_WorkPeriod awp
                            INNER JOIN Atom_ElectronicDevice aed ON aed.ID = awp.Atom_ElectronicDevice_ID
                            LEFT JOIN Atom_WorkPeriod_TYPE awpt on awpt.ID = awp.Atom_WorkPeriod_TYPE_ID 
							 where awp.LogoutTime is not null and "+ CashierActivityList.svillabelacorrection + @"
                            " + spar_issueDate + @" > awp.LoginTime
						     and  " + spar_issueDate + " < awp.LogoutTime order by awp.LogoutTime asc";

            DataTable dtAWP = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dtAWP, sql, lpar, ref Err))
            {
                int iCount = dtAWP.Rows.Count;

                if (iCount > 0)
                {
                    xLastAtomWorkPeriodLoginTimeCoveringIssueDate_v = tf.set_DateTime(dtAWP.Rows[0]["LogoutTime"]);
                    xLastAtom_WorkPeriod_ID = tf.set_ID(dtAWP.Rows[0]["Atom_WorkPeriod_ID"]);
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:UpgradeDB:CashierActivityList:FindLastAtomWorkPeriodTimeCoveringIssueDate: No LogoutTime found !");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:UpgradeDB:CashierActivityList:FindLastAtomWorkPeriodTimeCoveringIssueDate:sql" + sql + "\r\nErr" + Err);
                return false;
            }
        }

        internal void Clear()
        {
            Items.Clear();
        }
    }


    internal static class Upgrade_1_26_to_1_27
    {
        private static CashierActivityList cashierActivityList = new CashierActivityList();

        internal static object UpgradeDB_1_26_to_1_27(object obj, ref string Err)
        {

            Transaction transaction_UpgradeDB_1_26_to_1_27 = new Transaction("UpgradeDB_1_26_to_1_27");
            cashierActivityList.Clear();
            if (DBSync.DBSync.Drop_VIEWs(ref Err))
            {
                //change Atom_myOrganisation_Person
                //change myOrganisation_Person
                string[] new_tables = new string[] {
                                        "CashierActivityOpened",
                                        "CashierActivityClosed",
                                        "CashierActivity",
                                        "CashierActivity_DocInvoice"
                                    };

                if (!DBSync.DBSync.CreateTables(new_tables, ref Err))
                {
                    return false;
                }

                string sql = @"
                    alter table Reference add column 'ReferenceDate'  DATETIME NULL;
                    ";
                if (!transaction_UpgradeDB_1_26_to_1_27.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    transaction_UpgradeDB_1_26_to_1_27.Rollback();
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_26_to_1_27:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }

                //if (!set_stocktake_numbers())
                //{
                //    return false;
                //}

                //if (!correct_vilabella_atomWorkPeriodsBug())
                //{
                //    return false;
                //}

                //if (!Create_DailyCashierActivityFromAtomWorkPeriod())
                //{
                //    return false;
                //}

                if (DBSync.DBSync.Create_VIEWs())
                {

                    if (UpgradeDB_inThread.Set_DataBase_Version("1.27", transaction_UpgradeDB_1_26_to_1_27))
                    {
                        transaction_UpgradeDB_1_26_to_1_27.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    transaction_UpgradeDB_1_26_to_1_27.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_UpgradeDB_1_26_to_1_27.Rollback();
                return false;
            }
        }

        private static bool correct_vilabella_atomWorkPeriodsBug(Transaction transaction)
        {
            if (DBSync.DBSync.DataBase.Contains("Bella") && (DBSync.DBSync.DataBase.Contains("Vil")))
            {
                string sql = @"select 
	                               awp.ID as ID,
	                               acfn.FirstName,
	                               awp.LoginTime as LoginTime,
                                   awp.LogoutTime as LogoutTime
	                               from Atom_WorkPeriod awp
	                               inner join Atom_myOrganisation_Person amop on  awp.Atom_myOrganisation_Person_ID = amop.ID
	                               inner join Atom_Person aper on  amop.Atom_Person_ID = aper.ID
	                               inner join Atom_cFirstName acfn on  aper.Atom_cFirstName_ID = acfn.ID
	                               where awp.ID <> 140 and acfn.FirstName='Rok'";
                string Err = null;
                DataTable dt = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt, sql,ref Err))
                {
                    int i = 0;
                    int icount = dt.Rows.Count;
                    for (i=0;i<icount;i++)
                    {
                        int inext = i + 1;
                        
                        if (inext<icount)
                        {
                            ID id = tf.set_ID(dt.Rows[i]["ID"]);
                            DateTime_v dt_lout_v = tf.set_DateTime(dt.Rows[i]["LogoutTime"]);
                            DateTime_v dt_nlin_v = tf.set_DateTime(dt.Rows[inext]["LoginTime"]);
                            if (dt_lout_v!=null)
                            {
                                if (dt_nlin_v.v != null)
                                {
                                    if (dt_lout_v.v > dt_nlin_v.v)
                                    {
                                        //correct 
                                        DateTime dtcorr = dt_nlin_v.v.AddMinutes(-30);

                                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                                        string spar_Logout = "@spar_LogoutTime";
                                        SQL_Parameter par_Logout = new SQL_Parameter(spar_Logout, SQL_Parameter.eSQL_Parameter.Datetime, false, dtcorr);
                                        lpar.Add(par_Logout);
                                        sql = "update Atom_WorkPeriod set LogoutTime = " + spar_Logout + " where ID = " + id.ToString();
                                        if (!transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql,lpar,ref Err))
                                        {
                                            LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_26_to_1_27:correct_vilabella_atomWorkPeriodsBug:\r\nsql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_26_to_1_27:correct_vilabella_atomWorkPeriodsBug:\r\nsql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                CashierActivityList.svillabelacorrection = "";
                return true;
            }
        }

        private static bool set_stocktake_numbers(Transaction transaction)
        {
            string sql = "select ID,Draft,StockTakeNum from StockTake";
            DataTable dt = new DataTable();
            string Err = null;
            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
            {
                int i = 0;
                int iCount = dt.Rows.Count;
                long j = 1;
                for (i=0;i<iCount;i++)
                {
                    DataRow dr = dt.Rows[i];
                    bool bdraft = true;
                    bool_v bDraft_v = tf.set_bool(dr["Draft"]);
                    if (bDraft_v!=null)
                    {
                        bdraft = bDraft_v.v;
                    }

                    if (!bdraft)
                    {
                        long_v sStockTakeNum_v = tf.set_long(dr["StockTakeNum"]);
                        if (sStockTakeNum_v==null)
                        {
                            ID id = tf.set_ID(dr["ID"]);
                            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                            string spar_StockTakeNum = "@par_StockTakeNum";
                            SQL_Parameter par_StockTakeNum = new SQL_Parameter(spar_StockTakeNum, SQL_Parameter.eSQL_Parameter.Bigint, false, j);
                            lpar.Add(par_StockTakeNum);
                            sql = "update StockTake set StockTakeNum = " + spar_StockTakeNum + " where ID = " + id.ToString();
                            if (!transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql,lpar, ref Err))
                            {
                                return false;
                            }
                        }
                        j++;
                    }
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_26_to_1_27:set_stocktake_numbers:\r\nsql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private static bool Create_DailyCashierActivityFromAtomWorkPeriod(Transaction transaction)
        {
            string sql = @"select di.ID as DocInvoice_ID,
								  di.NumberInFinancialYear,
								  di.FinancialYear,
                                  di.Storno,
                                  di.NetSum,
                                  di.TaxSum,
                                  di.GrossSum,
								  pt.Name as PaymentTypeName,
								  jdit.Name,
								  jdi.JOURNAL_DocInvoice_TYPE_ID,
								  diao.IssueDate,
                                  awp.LoginTime as LoginTime,
                                  awp.LogoutTime as LogoutTime,
                                  awp.ID as Atom_WorkPeriod_ID,
                                  aed.Name as Atom_ElectronicDevice_Name,
                                  ao.ShortName as Atom_Office_ShortName
								  from DocInvoice di 
								  inner join DocInvoiceAddOn diao  on diao.DocInvoice_ID = di.ID
                                  inner join MethodOfPayment_DI mopdi on mopdi.ID = diao.MethodOfPayment_DI_ID
                                  inner join PaymentType pt on pt.ID = mopdi.PaymentType_ID
								  inner join JOURNAL_DocInvoice jdi on jdi.DocInvoice_ID = di.ID
								  inner join JOURNAL_DocInvoice_TYPE jdit on jdi.JOURNAL_DocInvoice_TYPE_ID = jdit.ID and jdi.JOURNAL_DocInvoice_TYPE_ID=2
                                  inner join Atom_WorkPeriod awp on jdi.Atom_WorkPeriod_ID = awp.ID
                                  INNER JOIN Atom_ElectronicDevice aed ON aed.ID = awp.Atom_ElectronicDevice_ID
                                  INNER JOIN Atom_Office ao ON aed.Atom_Office_ID = ao.ID
                                  INNER JOIN Atom_myOrganisation_Person amop ON amop.ID = awp.Atom_myOrganisation_Person_ID
                                  LEFT JOIN Atom_WorkPeriod_TYPE awpt on awpt.ID = awp.Atom_WorkPeriod_TYPE_ID 
								  where di.Draft = 0 
								  order by di.FinancialYear  asc, di.NumberInFinancialYear  asc
                                ";
            DataTable dtInvoices = new DataTable();
            string Err = null;
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
                                if (xNumberInFinancialYear_v!=null)
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
                                bool_v Storno_v= tf.set_bool(dr["Storno"]);
                                if (Storno_v!=null)
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
                                if (xPaymentTypeName_v!=null)
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
                                    Upgrade_1_26_to_1_27.cashierActivityList.Add(docinvdata);
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_26_to_1_27:Create_DailyCashierActivityFromAtomWorkPeriod:IssueTime_v == null");
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_26_to_1_27:Create_DailyCashierActivityFromAtomWorkPeriod:xDocument_ID is not valid!");
                            return false;
                        }
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_26_to_1_27:Create_DailyCashierActivityFromAtomWorkPeriod:\r\nsql="+sql+"\r\nErr=" +Err);
                return false;
            }

            int jcount = Upgrade_1_26_to_1_27.cashierActivityList.Items.Count;
            for (int j=0;j<jcount;j++)
            {
                CashierActivity ca = Upgrade_1_26_to_1_27.cashierActivityList.Items[j];
                if (ca.DocInvoice_ID_List.Count>0)
                {
                    ID xCashierActivityOpened_ID = null;
                    ID xCashierActivity_ID = null;
                    int iCashierActivityNumber = -1;
                    bool bAlreadyOpened = false;
                    DateTime loginTime = DateTime.MaxValue;
                    if (f_CashierActivity.Open(ca.DocInvoice_ID_List[0].Atom_ElectronicDevice_Name,
                                           ca.DocInvoice_ID_List[0].Atom_Office_ShortName,
                                           ca.First_Atom_WorkPeriod_ID,
                                           ref xCashierActivityOpened_ID,
                                           ref iCashierActivityNumber,
                                           ref loginTime,
                                           ref xCashierActivity_ID,
                                           ref bAlreadyOpened,
                                           transaction
                                           ))
                    {
                        if (bAlreadyOpened)
                        {
                            LogFile.Error.Show("ERROR:UpgradeDB:UpgradeDB_1_26_to_1_27:Create_DailyCashierActivityFromAtomWorkPeriod:CashierActivity already opened!");
                            return false;
                        }
                        int kcount = ca.DocInvoice_ID_List.Count;
                        for (int k=0;k<kcount;k++)
                        {
                            CashierActivity.DocInvoiceData did = ca.DocInvoice_ID_List[k];
                            ID xCashierActivity_DocInvoice_ID = null;
                            if (!f_CashierActivity_DocInvoice.Insert(xCashierActivity_ID, did.ID, ref xCashierActivity_DocInvoice_ID))
                            {
                                return false;
                            }
                        }
                        if (!f_CashierActivity.Close(xCashierActivity_ID,
                                               ca.Last_Atom_WorkPeriod_ID,
                                               transaction
                                               ))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
