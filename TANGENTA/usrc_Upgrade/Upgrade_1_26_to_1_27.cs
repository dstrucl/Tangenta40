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
                        DateTime xIssueJustDate = new DateTime(xDocInvoiceData.IssueDate.Year, xDocInvoiceData.IssueDate.Month, xDocInvoiceData.IssueDate.Day);
                        if (caIssueDate == xIssueJustDate)
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
            }
            return null;
        }

        private bool IsInTimeBetween(DateTime xTimeStart, DateTime TimeInBetween, DateTime xTimeEnd)
        {
            return ((TimeInBetween >= xTimeStart) && (TimeInBetween < xTimeEnd));
        }

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
							 where " + spar_issueDate + @" > awp.LoginTime
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
							 where " + spar_issueDate + @" > awp.LoginTime
						     and  " + spar_issueDate + " < awp.LogoutTime order by awp.LogoutTime desc";

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

                if (!Create_DailyCashierActivityFromAtomWorkPeriod())
                {
                    return false;
                }

                if (DBSync.DBSync.Create_VIEWs())
                {
                    return UpgradeDB_inThread.Set_DataBase_Version("1.27");
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

        private static bool Create_DailyCashierActivityFromAtomWorkPeriod()
        {
            string sql = @"select 
								  di.ID as DocInvoice_ID,
								  di.NumberInFinancialYear,
								  di.FinancialYear,
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
                int i = 1;
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
                                CashierActivity.DocInvoiceData docinvdata = new CashierActivity.DocInvoiceData(xAtom_ElectronicDevice_Name_v.v, xAtom_Office_ShortName_v.v, xDocument_ID, IssueTime_v.v, NumberInFinancialYear, FinancialYear);

                                Upgrade_1_26_to_1_27.cashierActivityList.Add(docinvdata);
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
                    if (f_CashierActivity.Open(ca.DocInvoice_ID_List[0].Atom_ElectronicDevice_Name,
                                           ca.DocInvoice_ID_List[0].Atom_Office_ShortName,
                                           ca.First_Atom_WorkPeriod_ID,
                                           ref xCashierActivityOpened_ID,
                                           ref iCashierActivityNumber,
                                           ref xCashierActivity_ID,
                                           ref bAlreadyOpened
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
                                               ca.Last_Atom_WorkPeriod_ID
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
