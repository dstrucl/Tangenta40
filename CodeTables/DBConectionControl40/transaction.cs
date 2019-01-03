using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public class Transaction
    {
        public delegate UserControl delegate_AddTransactionLogUserControl(Panel ownepnl);
        public delegate bool delegate_InitTransactionLogUserControl(object oursc_TransactionLog);

        private bool m_FirstExecutionDone = false;
        public bool FirstExecutionDone
        {
            get
            {
                return m_FirstExecutionDone;
            }
            set
            {
                m_FirstExecutionDone = value;
            }
        }

        private static object myDataBase_TransactionsLog = null;
        public static object MyDataBase_TransactionsLog
        {
            get
            {
                return myDataBase_TransactionsLog;
            }
            set
            {
                myDataBase_TransactionsLog = value;
            }
        }

        private static delegate_AddTransactionLogUserControl m_delegate_AddTransactionLogUserControl = null;
        public static delegate_AddTransactionLogUserControl Delegate_AddTransactionLogUserControl
        {
            get
            {
                return m_delegate_AddTransactionLogUserControl;
            }
            set
            {
                m_delegate_AddTransactionLogUserControl = value;
            }
        }

        private static delegate_InitTransactionLogUserControl m_delegate_InitTransactionLogUserControl = null;
        public static delegate_InitTransactionLogUserControl Delegate_InitTransactionLogUserControl
        {
            get
            {
                return m_delegate_InitTransactionLogUserControl;
            }
            set
            {
                m_delegate_InitTransactionLogUserControl = value;
            }
        }
        private static bool bBreakOnTransactionDialog = false;

        public static bool BreakOnTransactionDialog
        {
            get
            {
                return bBreakOnTransactionDialog;
            }
            set
            {
                bBreakOnTransactionDialog = value;
            }

        }

        public delegate void delegate_SetState(eConnectionState eConnectionState);

        public enum eConnectionState { CONNECTED, CONNECTED_TRANSACTION_ACTIVE, CONNECTED_TRANSACTION_COMMITED, CONNECTED_TRANSACTION_ROLLBACKED, DICSONNECTED };


        internal ID Transaction_ID = null;

        public List<TransactionSQLCommand> TransactionSQLCommandList = null;

        private TransactionLog_delegates m_TransactionLog_delegates = null;

        private DBConnection mcon = null;

        public DBConnection con
        {
            get
            {
                return mcon;
            }
            set
            {
                mcon = value;
            }
        }

        private bool m_Active = false;


        private string name = null;
        public string Name

        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private DateTime m_CreationTime = DateTime.Now;

        public DateTime CreationTime
        {
            get
            {
                return m_CreationTime;
            }
        }

        private DateTime m_ActivationTime = DateTime.MinValue;

        public DateTime ActivationTime
        {
            get
            {
                return m_ActivationTime;
            }
        }

        private DateTime m_CommitTime = DateTime.MinValue;

        public DateTime CommitTime
        {
            get
            {
                return m_CommitTime;
            }
        }

        private DateTime m_RollBackTime = DateTime.MinValue;

        public DateTime RollBackTime
        {
            get
            {
                return m_RollBackTime;
            }
        }

        private string identity = null;
        public string Idenity
        {
            get
            {
                return identity;
            }
            set
            {
                identity = value;
            }
        }

        public Transaction(TransactionLog_delegates xTransactionLog_delegates,string xname)
        {
            name = xname;
            m_TransactionLog_delegates = xTransactionLog_delegates;
        }

        public bool Executed
        {
            get
            {
                return identity != null;
            }
        }

        public bool GetTransaction(DBConnection m_con)
        {
            if (identity == null)
            {
                con = m_con;
                if (con.BeginTransaction(name, ref identity))
                {
                    if (!con.DBTransactionsLogConnection)
                    {
                      
                        if (DBConnection.Delegate_SetState !=null)
                        {
                            DBConnection.Delegate_SetState(eConnectionState.CONNECTED_TRANSACTION_ACTIVE);
                        }
                       
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (con == null)
                {
                    con = m_con;
                }
            }
            m_Active = true;
            return true;
        }

        private void Show_TransactionActivateDialog(Transaction transaction)
        {
            Form_TransactionBreakDialog_Activate frm_TransactionBreakDialog_Activate = new Form_TransactionBreakDialog_Activate(transaction);
            FormCollection frm_collection = Application.OpenForms;
            Form frm_parent = null;
            if (frm_collection.Count>0)
            {
                frm_parent = frm_collection[0];
                frm_TransactionBreakDialog_Activate.TopMost = false;
            }
            else
            {
                frm_TransactionBreakDialog_Activate.TopMost = true;
            }
        
            frm_TransactionBreakDialog_Activate.ShowDialog(frm_parent);
        }

        public bool Commit()
        {
            if (m_Active)
            {
                if (identity != null)
                {
                    if (con != null)
                    {
                        if (con.CommitTransaction(identity))
                        {
                            if (con.DBTransactionsLogConnection)
                            {
                                identity = null;
                                m_Active = false;
                            }
                            else
                            {
                                m_CommitTime = DateTime.Now;
                                identity = null;
                                m_Active = false;
                                if (m_TransactionLog_delegates != null)
                                {
                                    m_TransactionLog_delegates.m_delegate_WriteTransactionLog_Commit(this);
                                }
                                if (DBConnection.Delegate_SetState != null)
                                {
                                    DBConnection.Delegate_SetState(eConnectionState.CONNECTED_TRANSACTION_COMMITED);
                                }
                                if (bBreakOnTransactionDialog)
                                {
                                    Show_TransactionCommitDialog(this);
                                }
                            }
                            return true;
                        }
                        else
                        {
                            identity = null;
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Commit():con==null!");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Commit():con==null!");
                    return false;
                }
            }
            else
            {
                // transaction not active
                return true;
            }
        }


        private void Show_TransactionCommitDialog(Transaction transaction)
        {
            Form_TransactionBreakDialog_Commit frm_TransactionBreakDialog_Commit = new Form_TransactionBreakDialog_Commit(transaction);
            FormCollection frm_collection = Application.OpenForms;
            Form frm_parent = null;
            if (frm_collection.Count > 0)
            {
                frm_parent = frm_collection[0];
                frm_TransactionBreakDialog_Commit.TopMost = false;
            }
            else
            {
                frm_TransactionBreakDialog_Commit.TopMost = true;
            }

            frm_TransactionBreakDialog_Commit.ShowDialog(frm_parent);
        }
        public bool Rollback()
        {
            if (m_Active)
            {
                if (identity != null)
                {
                    if (con != null)
                    {
                        if (con.RollbackTransaction(identity))
                        {
                            if (con.DBTransactionsLogConnection)
                            {
                                m_Active = false;
                                identity = null;
                            }
                            else
                            {
                                m_RollBackTime = DateTime.Now;
                                m_Active = false;
                                identity = null;
                                if (m_TransactionLog_delegates != null)
                                {
                                    m_TransactionLog_delegates.m_delegate_WriteTransactionLog_Rollback(this);
                                }
                                if (DBConnection.Delegate_SetState != null)
                                {
                                    DBConnection.Delegate_SetState(eConnectionState.CONNECTED_TRANSACTION_ROLLBACKED);
                                }
                            }
                            return true;
                        }
                        else
                        {
                            identity = null;
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Rollback():con==null!");
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Rollback():id==null!");
                    return false;
                }
            }
            else
            {
                // transaction not started
                return true;
            }
        }

        public bool ExecuteNonQuerySQL_NoMultiTrans(DBConnection con, string sql, List<SQL_Parameter> lpar, ref string err)
        {
            if (GetTransaction(con))
            {
                if (con.DBTransactionsLogConnection)
                {
                    return con.ExecuteNonQuerySQL(sql, lpar, ref err);
                }
                else
                {
                    DateTime executionStart = DateTime.Now;
                    bool bresult = con.ExecuteNonQuerySQL(sql, lpar, ref err);
                    DateTime executionEnd = DateTime.Now;
                    writeTransactionLogExecute(sql, lpar, bresult, null, executionStart, executionEnd, true, err);
                    return bresult;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ExecuteNonQuerySQLReturnID(DBConnection con, string sql, List<SQL_Parameter> lpar, ref ID id, ref string err, string table_name)
        {
            if (GetTransaction(con))
            {
                if (con.DBTransactionsLogConnection)
                {
                    return con.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref err, table_name);
                }
                else
                {
                    DateTime executionStart = DateTime.Now;
                    bool bresult = con.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref err, table_name);
                    DateTime executionEnd = DateTime.Now;
                    writeTransactionLogExecute(sql, lpar, bresult, id, executionStart, executionEnd, true, err);

                    return bresult;
                }
            }
            else
            {
                return false;
            }

        }

        private void writeTransactionLogExecute(string sql, List<SQL_Parameter> lpar, bool bresult, ID id,DateTime executionStart,DateTime executionEnd, bool result, string err)
        {
            TransactionSQLCommand xTransactionSQLCommand = new TransactionSQLCommand(sql, lpar, id, executionStart, executionEnd, result, err);
            if (TransactionSQLCommandList==null)
            {
                TransactionSQLCommandList = new List<TransactionSQLCommand>();
            }
            TransactionSQLCommandList.Add(xTransactionSQLCommand);
            if (bBreakOnTransactionDialog)
            {
                if (!FirstExecutionDone)
                {
                    FirstExecutionDone = true;
                    Show_TransactionActivateDialog(this);
                    m_ActivationTime = DateTime.Now;
                }
            }
            else
            {
                if (!FirstExecutionDone)
                {
                    FirstExecutionDone = true;
                    m_ActivationTime = DateTime.Now;
                }
            }
        }

        public bool ExecuteNonQuerySQL(DBConnection con, string sql, List<SQL_Parameter> lpar, ref string err)
        {
            if (GetTransaction(con))
            {
                if (con.DBTransactionsLogConnection)
                {
                    return con.ExecuteNonQuerySQL(sql, lpar, ref err);
                }
                else
                {
                    DateTime executionStart = DateTime.Now;
                    bool bresult = con.ExecuteNonQuerySQL(sql, lpar, ref err);
                    DateTime executionEnd = DateTime.Now;
                    writeTransactionLogExecute(sql, lpar, bresult, null, executionStart, executionEnd, true, err);
                    return bresult;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ExecuteScalaraReturnID(DBConnection m_con,
                                           StringBuilder sbsqlUpdate,
                                           List<SQL_Parameter> sqlParamList,
                                           ref ID newID,
                                           ref string csError,
                                           string tableName)
        {
            if (GetTransaction(m_con))
            {
                if (con.DBTransactionsLogConnection)
                {
                    return m_con.ExecuteScalarReturnID(sbsqlUpdate, sqlParamList, ref newID, ref csError, tableName);
                }
                else
                {
                    DateTime ExecutionStart = DateTime.Now;
                    bool bresult = m_con.ExecuteScalarReturnID(sbsqlUpdate, sqlParamList, ref newID, ref csError, tableName);
                    DateTime ExecutionEnd = DateTime.Now;
                    writeTransactionLogExecute(sbsqlUpdate.ToString(), sqlParamList, bresult, newID, ExecutionStart, ExecutionEnd, true, csError);
                    return bresult;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
