using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DBConnectionControl40;
using TransactionLogTableClass;
using CodeTables;
using LanguageControl;
using DBConnectionControl40;
using static TransactionLogTableClass.TransactionLogTableClass;

namespace TransactionLogDataBaseDef
{
    partial class MyDataBase_TransactionsLog
    {
        //public bool WriteTransactionLog_BeginTransaction(Transaction transaction)
        //{
        //    return false;
        //}


        //public bool WriteTransactionLogExecute(Transaction transaction, string sql_command, List<SQL_Parameter> lpar, ID return_ID, bool bok, string error)
        //{
        //    return false;
        //}

        private bool GetNextTransactionLogNumber(ref long number)
        {
            string sql = "select Number from TransactionLog order by Number desc limit 1";
            DataTable dt = new DataTable();
            string err = null;
            if (m_DBTables.Con.ReadDataTable(ref dt,sql,ref err ))
            {
                if (dt.Rows.Count > 0)
                {
                    long num = (long)dt.Rows[0]["Number"];
                    number = num + 1;
                }
                else
                {
                    number = 1;
                }
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog:GetNextTransactionLogNumber:Error=" + err + "\r\nSql=" + sql);
                return false;
            }

        }

        private bool GetTransactionName(Transaction logtransaction, string name,ref ID transactionName_ID)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, name);
            lpar.Add(par_Name);

            string sql = "select ID from TransactionName where Name = " + spar_Name;
            DataTable dt = new DataTable();
            string err = null;
            if (m_DBTables.Con.ReadDataTable(ref dt, sql, lpar, ref err))
            {
                if (dt.Rows.Count > 0)
                {
                    transactionName_ID = DBTypes.tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into TransactionName (Name)values(" + spar_Name + ")";
                    if (logtransaction.ExecuteNonQuerySQLReturnID(m_DBTables.Con, sql, lpar, ref transactionName_ID, ref err, "TransactionName"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog_delegates:GetTransactionName:Error=" + err + "\r\nSql=" + sql);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog_delegates:GetTransactionName:Error=" + err + "\r\nSql=" + sql);
                return false;
            }
        }

        public bool WriteTransactionLog_Commit(Transaction transaction)
        {
            string err = null;
            Transaction transaction_commit = new Transaction(null, "WriteTransactionLog_Commit");

            ID transactionName_ID = null;

            if (GetTransactionName(transaction_commit, transaction.Name,ref transactionName_ID))
            {
                string sql = null;
                long Number = 0;
                if (GetNextTransactionLogNumber(ref Number))
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    lpar.Clear();
                    string spar_transactionName_ID = "@par_transactionName_ID";
                    SQL_Parameter par_transactionName_ID = new SQL_Parameter(spar_transactionName_ID, false, transactionName_ID);
                    lpar.Add(par_transactionName_ID);

                    string spar_Number = "@par_Number";
                    SQL_Parameter par_Number = new SQL_Parameter(spar_Number, SQL_Parameter.eSQL_Parameter.Bigint, false, Number);
                    lpar.Add(par_Number);

                    string spar_CreationTime = "@par_CreationTime";
                    SQL_Parameter par_CreationTime = new SQL_Parameter(spar_CreationTime, SQL_Parameter.eSQL_Parameter.Datetime, false, transaction.CreationTime);
                    lpar.Add(par_CreationTime);

                    string sval_ActivationTime = "null";
                    if (transaction.ActivationTime != DateTime.MinValue)
                    {
                        string spar_ActivationTime = "@par_ActivationTime";
                        SQL_Parameter par_ActivationTime = new SQL_Parameter(spar_ActivationTime, SQL_Parameter.eSQL_Parameter.Datetime, false, transaction.ActivationTime);
                        lpar.Add(par_ActivationTime);
                        sval_ActivationTime = spar_ActivationTime;
                    }

                    string sval_CommitTime = "null";
                    if (transaction.CommitTime != DateTime.MinValue)
                    {
                        string spar_CommitTime = "@par_CommitTime";
                        SQL_Parameter par_CommitTime = new SQL_Parameter(spar_CommitTime, SQL_Parameter.eSQL_Parameter.Datetime, false, transaction.CommitTime);
                        lpar.Add(par_CommitTime);
                        sval_CommitTime = spar_CommitTime;
                    }

                    string sval_RollBackTime = "null";
                    if (transaction.RollBackTime != DateTime.MinValue)
                    {
                        string spar_RollBackTime = "@par_RollBackTime";
                        SQL_Parameter par_RollBackTime = new SQL_Parameter(spar_RollBackTime, SQL_Parameter.eSQL_Parameter.Datetime, false, transaction.RollBackTime);
                        lpar.Add(par_RollBackTime);
                        sval_RollBackTime = spar_RollBackTime;
                    }

                    sql = "insert into TransactionLog (transactionName_ID,Number,CreationTime,ActivationTime,CommitTime,RollBackTime)values(" + spar_transactionName_ID + ","
                        + spar_Number + ","
                        + spar_CreationTime + ","
                        + sval_ActivationTime + ","
                        + sval_CommitTime + ","
                        + sval_RollBackTime + ")";
                    ID transactionLog_ID = null;
                    if (transaction_commit.ExecuteNonQuerySQLReturnID(m_DBTables.Con, sql, lpar, ref transactionLog_ID, ref err, "TransactionLog"))
                    {
                        if (transaction.TransactionSQLCommandList != null)
                        {
                            foreach (TransactionSQLCommand tsql in transaction.TransactionSQLCommandList)
                            {
                                ID commandText_ID = null;
                                if (GetCommandTextID(transaction_commit,tsql.SQLtext,ref commandText_ID))
                                {
                                    tsql.IDnew = commandText_ID;
                                    lpar.Clear();
                                    string spar_transactionLog_ID = "@par_transactionLog_ID";
                                    SQL_Parameter par_transactionLog_ID = new SQL_Parameter(spar_transactionLog_ID, false, transactionLog_ID);
                                    lpar.Add(par_transactionLog_ID);


                                    string spar_CommandText_ID = "@par_CommandText_ID";
                                    SQL_Parameter par_CommandText_ID = new SQL_Parameter(spar_CommandText_ID, false, commandText_ID);
                                    lpar.Add(par_CommandText_ID);

                                    string spar_ExecutionStart = "@par_ExecutionStart";
                                    SQL_Parameter par_ExecutionStart = new SQL_Parameter(spar_ExecutionStart, SQL_Parameter.eSQL_Parameter.Datetime, false, tsql.ExecutionStart);
                                    lpar.Add(par_ExecutionStart);

                                    string spar_ExecutionEnd = "@par_ExecutionEnd";
                                    SQL_Parameter par_ExecutionEnd = new SQL_Parameter(spar_ExecutionEnd, SQL_Parameter.eSQL_Parameter.Datetime, false, tsql.ExecutionEnd);
                                    lpar.Add(par_ExecutionEnd);
                                    ID sQLCommand_ID = null;
                                    sql = "insert into SQLCommand (TransactionLog_ID,CommandText_ID,ExecutionStart,ExecutionEnd,Error)values(" + spar_transactionLog_ID + ","
                                        + spar_CommandText_ID + ","
                                        + spar_ExecutionStart + ","
                                        + spar_ExecutionEnd + ",null)";
                                    if (transaction_commit.ExecuteNonQuerySQLReturnID(m_DBTables.Con, sql, lpar, ref sQLCommand_ID, ref err, "SQLCommand"))
                                    {
                                        if (tsql.Get(transaction_commit, sQLCommand_ID))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            transaction_commit.Rollback();
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        transaction_commit.Rollback();
                                        LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog:WriteTransactionLog_Commit:Error=" + err + "\r\nSql=" + sql);
                                        return false;
                                    }
                                }
                            }
                            transaction_commit.Commit();
                            return true;
                        }
                    }
                    else
                    {
                        transaction_commit.Rollback();
                        LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog:WriteTransactionLog_Commit:Error=" + err + "\r\nSql=" + sql);
                        return false;
                    }
                }
                else
                {
                    transaction_commit.Rollback();
                    return false;
                }
            }
            else
            {
                transaction_commit.Rollback();
                return false;
            }
            return false;
        }

        private bool GetCommandTextID(Transaction transaction,string sQLtext,ref ID commandText_ID)
        {
            string err = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_SQLText = "@par_SQLText";
            SQL_Parameter par_SQLText = new SQL_Parameter(spar_SQLText, SQL_Parameter.eSQL_Parameter.Varchar, false, sQLtext);
            lpar.Add(par_SQLText);

            string sql = "select ID from CommandText where SQLText = " + spar_SQLText;
            DataTable dt = new DataTable();
            if (m_DBTables.Con.ReadDataTable(ref dt, sql,lpar, ref err))
            {
                if (dt.Rows.Count>0)
                {
                    commandText_ID = DBTypes.tf.set_ID(dt.Rows[0]["ID"]);
                    return true;
                }
                else
                {
                    sql = "insert into CommandText (SQLText)values(" + spar_SQLText + ")";
                    if (transaction.ExecuteNonQuerySQLReturnID(m_DBTables.Con,sql,lpar,ref commandText_ID,ref err, "CommandText"))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog:GetCommandTextID: err=" + err + "\r\nsql=" + sql);
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog:GetCommandTextID: err=" + err + "\r\nsql=" + sql);
                return false;
            }
        }

        public bool WriteTransactionLog_Rollback(Transaction transaction)
        {
            return false;
        }

    }
}