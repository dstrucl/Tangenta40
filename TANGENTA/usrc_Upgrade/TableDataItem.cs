using CodeTables;
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
    public class TableDataItem
    {
        public SQLTable tbl = null;
        public DataTable dt = null;
        public List<TableDataItem> fkey_TableDataItem_List = new List<TableDataItem>();
        public TableDataItem prev = null;

        public TableDataItem(SQLTable xtbl, ref List<DataTable> dt_List, TableDataItem xprev, ref string Err)
        {
            // TODO: Complete member initialization
            tbl = xtbl;
            prev = xprev;
            foreach (Column col in xtbl.Column)
            {
                if (col.fKey != null)
                {
                    if (!col.fKey.fTable.TableName.Equals("Atom_WorkPeriod"))
                    {
                        TableDataItem tdi = new TableDataItem(col.fKey.fTable, ref dt_List, this, ref Err);
                        if (Err != null)
                        {
                            return;
                        }
                        fkey_TableDataItem_List.Add(tdi);
                    }
                }
            }
            if (Find_dt_List(ref dt, dt_List, tbl.TableName))
            {
                return;
            }
            else
            {
                string sql = "select * from " + xtbl.TableName;
                dt = new DataTable();
                dt.TableName = tbl.TableName;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    dt.Columns.Add("old_ID", typeof(long));
                    dt_List.Add(dt);
                }
            }
        }

        //internal bool Write2DB(Database_Upgrade_WindowsForm_Thread wfp_ui_thread, UpgradeDB_inThread.eUpgrade eUpgr, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        //{
        //    string Err = null;
        //    foreach (TableDataItem xtdi in fkey_TableDataItem_List)
        //    {
        //        xtdi.Write2DB(wfp_ui_thread, eUpgr, m_Old_tables_1_04_to_1_05);
        //    }

        //    if (eUpgr == UpgradeDB_inThread.eUpgrade.from_1_04_to_105)
        //    {
        //        if (this.tbl.TableName.ToLower().Equals("pricelist"))
        //        {
        //            if (!ID.Validate(GlobalData.Office_ID))
        //            {
        //                string sql = "insert into Office (myOrganisation_ID,Name)values(1,'P1')";
        //                if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref GlobalData.Office_ID,  ref Err, "Office"))
        //                {
        //                    sql = "insert into myOrganisation_Person (UserName,Password,Job,Active,Description,Person_ID,Office_ID)values('marjetkah',null,'Direktor',1,'Direktorica in lastnica podjetja',1,1)";
        //                    ID x_myOrganisation_Person_ID = null;
        //                    if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref x_myOrganisation_Person_ID, ref Err, "Office"))
        //                    {

        //                    }
        //                    else
        //                    {
        //                        LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
        //                        return false;
        //                    }
        //                }
        //                else
        //                {
        //                    LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
        //                    return false;
        //                }
        //            }
        //        }
        //        else if (this.tbl.TableName.ToLower().Equals("atom_pricelist"))
        //        {
        //            string sql = null;
        //            if (!ID.Validate(GlobalData.Atom_Office_ID))
        //            {
        //                sql = "insert into Atom_Office (Atom_myOrganisation_ID,Name)values(1,'P1')";
        //                if (!transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql, null, ref GlobalData.Atom_Office_ID, ref Err, "Atom_Office"))
        //                {
        //                    LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
        //                    return false;
        //                }
        //            }

        //            DateTime dtStart = new DateTime(2015, 4, 29);
        //            DateTime_v dtEnd_v = new DateTime_v();
        //            dtEnd_v.v = DateTime.Now;
        //            if (!GlobalData.GetWorkPeriodOld(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04, null, dtStart, dtEnd_v, ref Err))
        //            {
        //                return false;
        //            }


        //        }
        //        else if (this.tbl.TableName.ToLower().Equals("docinvoice"))
        //        {
        //            DateTime dtStart = new DateTime(2015, 4, 29);
        //            DateTime_v dtEnd_v = new DateTime_v();
        //            dtEnd_v.v = DateTime.Now;
        //            GlobalData.GetWorkPeriodOld(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04, null, dtStart, dtEnd_v, ref Err);
        //        }
        //    }

        //    string tname = tbl.TableName;
        //    string sql_insert_columns = null;
        //    string sql_insert_values = null;
        //    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
        //    bool bDocInvoiceTime = false;
        //    bool bPaid = false;
        //    bool bStorno = false;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr["old_id"] is System.DBNull)
        //        {
        //            wfp_ui_thread.Message(lng.s_ImportData.s + ":" + tname);
        //            sql_insert_columns = null;
        //            sql_insert_values = null;
        //            lpar.Clear();
        //            ID old_id = tf.set_ID(dr["id"]);
        //            DateTime_v InvoiceTime_v = null;
        //            DateTime_v PaidTime_v = null;
        //            DateTime_v StornoTime_v = null;
        //            foreach (DataColumn dcol in dt.Columns)
        //            {
        //                if (dcol.ColumnName.ToUpper().Equals("ID") || dcol.ColumnName.ToUpper().Equals("OLD_ID"))
        //                {
        //                    continue;
        //                }
        //                else
        //                {
        //                    if (eUpgr == UpgradeDB_inThread.eUpgrade.from_1_04_to_105)
        //                    {
        //                        if (dcol.ColumnName.ToLower().Equals("myorganisation_person_id"))
        //                        {
        //                            continue;
        //                        }
        //                        if (this.tbl.TableName.ToLower().Equals("atom_pricelist"))
        //                        {
        //                            if (dcol.ColumnName.ToLower().Equals("atom_myorganisation_person_id"))
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (this.tbl.TableName.ToLower().Equals("docinvoice"))
        //                            {
        //                                if (dcol.ColumnName.ToLower().Equals("atom_myorganisation_person_id"))
        //                                {
        //                                    continue;
        //                                }
        //                            }

        //                        }
        //                    }
        //                }
        //                object o = dr[dcol];
        //                string sparname = null;
        //                SQL_Parameter par = null;
        //                if (new_SQL_Parameter(this, dr, dcol, ref sparname, o, ref par))
        //                {
        //                    if (dcol.ColumnName.ToLower().Equals("paid"))
        //                    {
        //                        bPaid = true;
        //                    }
        //                    if (dcol.ColumnName.ToLower().Equals("storno"))
        //                    {
        //                        bStorno = true;
        //                    }

        //                    if (dcol.ColumnName.ToLower().Equals("firstprinttime"))
        //                    {
        //                        //bFirstPrintTime = true;
        //                    }
        //                    else if (dcol.ColumnName.ToLower().Equals("docinvoicetime"))
        //                    {
        //                        bDocInvoiceTime = true;
        //                    }
        //                    else
        //                    {
        //                        if (par != null)
        //                        {
        //                            lpar.Add(par);
        //                        }
        //                        if (sql_insert_columns == null)
        //                        {
        //                            sql_insert_columns = dcol.ColumnName;
        //                        }
        //                        else
        //                        {
        //                            sql_insert_columns += "," + dcol.ColumnName;
        //                        }
        //                        if (sql_insert_values == null)
        //                        {
        //                            sql_insert_values = sparname;
        //                        }
        //                        else
        //                        {
        //                            sql_insert_values += "," + sparname;
        //                        }

        //                    }
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }

        //            if (bDocInvoiceTime)
        //            {
        //                if (dr["docinvoicetime"] is DateTime)
        //                {
        //                    InvoiceTime_v = new DateTime_v();
        //                    InvoiceTime_v.v = (DateTime)dr["docinvoicetime"];
        //                }
        //            }

        //            if (bPaid)
        //            {
        //                if (dr["Paid"] is bool)
        //                {
        //                    PaidTime_v = new DateTime_v();
        //                    PaidTime_v.v = GetDocInvoiceTime(old_id, m_Old_tables_1_04_to_1_05);
        //                }
        //            }

        //            if (bStorno)
        //            {
        //                if (dr["Storno"] is bool)
        //                {
        //                    if ((bool)dr["Storno"])
        //                    {
        //                        StornoTime_v = new DateTime_v();
        //                        StornoTime_v.v = GetInvoiceStornoTime(old_id, m_Old_tables_1_04_to_1_05);
        //                    }
        //                    else
        //                    {
        //                        bStorno = false;
        //                    }
        //                }
        //            }

        //            string sql_insert = " insert into " + tname + " (" + sql_insert_columns + ") values (" + sql_insert_values + ")";
        //            ID new_id = null;
        //            if (transaction.ExecuteNonQuerySQLReturnID(DBSync.DBSync.Con,sql_insert, lpar, ref new_id,  ref Err, tname))
        //            {
        //                dr["OLD_ID"] = old_id.V;
        //                dr["id"] = new_id.V;
        //                if (tname.ToLower().Equals("docinvoice"))
        //                {
        //                    ID Journal_DocInvoice_ID = null;
        //                    f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.Name, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceDraftTime.Description, InvoiceTime_v, ref Journal_DocInvoice_ID);
        //                    if (dr["Draft"] is bool)
        //                    {
        //                        if (!(bool)dr["Draft"])
        //                        {
        //                            f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.Name, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoiceTime.Description, InvoiceTime_v, ref Journal_DocInvoice_ID);
        //                            f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoicePaidTime.Name, GlobalData.JOURNAL_DocInvoice_Type_definitions.InvoicePaidTime.Description, InvoiceTime_v, ref Journal_DocInvoice_ID);
        //                        }
        //                    }
        //                }
        //                else if (tname.ToLower().Equals("invoice"))
        //                {
        //                    ID Journal_Invoice_ID = null;
        //                    f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, "Paid", "Plačano", PaidTime_v, ref Journal_Invoice_ID);
        //                    if (bStorno)
        //                    {
        //                        f_Journal_DocInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, "Storno*", "Napaka pri vnosu", StornoTime_v, ref Journal_Invoice_ID);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:Err=" + Err);
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        private DateTime GetInvoiceStornoTime(ID Invoice_id, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            DataRow[] drs = m_Old_tables_1_04_to_1_05.dt_Journal_Invoice.Select("invoice_id=" + Invoice_id.ToString());
            if (drs.Count() > 0)
            {
                return (DateTime)drs[0]["EventTime"];
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:GetInvoiceStornoTime:Err id =" + Invoice_id.ToString() + " not found in table DocInvoice!");
                return DateTime.Now;
            }
        }

        private DateTime GetDocInvoiceTime(ID id, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {

            DataRow[] drs = m_Old_tables_1_04_to_1_05.dt_DocInvoice.Select("id=" + id.ToString());
            if (drs.Count() > 0)
            {
                if (drs[0]["DocInvoiceTime"] is DateTime)
                {
                    return (DateTime)drs[0]["DocInvoiceTime"];
                }
                else
                {
                    //LogFile.Error.Show("ERROR:usrc_Upgrade:GetDocInvoiceTime:DocInvoiceTime type = " + drs[0]["DocInvoiceTime"].GetType().ToString());
                    return DateTime.Now;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:GetDocInvoiceTime:Err id =" + id.ToString() + " not found in table DocInvoice!");
                return DateTime.Now;
            }
        }


        private bool Find_dt_List(ref DataTable dtchk, List<DataTable> dt_List, string tname)
        {
            foreach (DataTable xdt in dt_List)
            {
                if (xdt.TableName.Equals(tname))
                {
                    dtchk = xdt;
                    return true;
                }
            }
            return false;
        }

        private bool new_SQL_Parameter(TableDataItem tdi, DataRow dr, DataColumn dcol, ref string sparname, object o, ref SQL_Parameter par)
        {
            ID new_ID = null;
            sparname = "@par_" + dcol.ColumnName;
            //if (tdi.tbl.TableName.Equals("Atom_cAddress_Org"))
            //{
            //    MessageBox.Show("Atom_cAddress_Org");
            //}
            if (IsForeignKey(tdi, dr, dcol, ref new_ID))
            {
                o = new_ID;
            }
            if (o is string)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Nvarchar, false, o);
            }
            else if (o is bool)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bit, false, o);
            }
            else if (o is short)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, o);

            }
            else if (o is ushort)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, o);
            }
            else if (o is int)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Int, false, o);
            }
            else if (o is uint)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Int, false, o);

            }
            else if (o is long)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bigint, false, o);

            }
            else if (o is ulong)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bigint, false, o);
            }
            else if (o is DateTime)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Datetime, false, o);
            }
            else if (o is byte[])
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Varbinary, false, o);
            }
            else if (o is decimal)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Decimal, false, o);
            }
            else if (o is float)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Float, false, o);
            }
            else if (o is System.DBNull)
            {
                sparname = "null";
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:new_SQL_Parameter: type = " + o.GetType().ToString() + " not implemented !");
                return false;
            }
            return true;
        }

        private bool IsForeignKey(TableDataItem tdi, DataRow dr, DataColumn dcol, ref ID new_ID)
        {
            foreach (Column col in tdi.tbl.Column)
            {
                if (col.fKey != null)
                {
                    if (col.Name.Equals(dcol.ColumnName))
                    {
                        foreach (TableDataItem xtdi in tdi.fkey_TableDataItem_List)
                        {
                            if (col.fKey.fTable.TableName.Equals(xtdi.tbl.TableName))
                            {
                                object o_Old_ID = dr[dcol.ColumnName];
                                if (o_Old_ID is long)
                                {
                                    DataRow[] drs = xtdi.dt.Select("old_ID = " + ((long)o_Old_ID).ToString());
                                    if (drs.Count() > 0)
                                    {
                                        new_ID = tf.set_ID(drs[0]["ID"]);
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    }

}
