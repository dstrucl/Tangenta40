﻿using System;
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
                    long num = (long)dt.Rows[]["Number"];
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

        public bool WriteTransactionLog_Commit(Transaction transaction)
        {
            string err = null;
            Transaction transaction_commit = new Transaction(null, "WriteTransactionLog_Commit");

            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_Name = "@par_Name";
            SQL_Parameter par_Name = new SQL_Parameter(spar_Name, SQL_Parameter.eSQL_Parameter.Nvarchar, false, transaction.Name);
            lpar.Add(par_Name);
            string sql = "insert into TransactionName (Name)values("+ spar_Name + ")";
            ID transactionName_ID = null;

            if (transaction_commit.ExecuteNonQuerySQLReturnID(m_DBTables.Con, sql, lpar, ref transactionName_ID, ref err, "TransactionName"))
            {
                long Number = 0;
                if (GetNextTransactionLogNumber(ref Number))
                {
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

                    string spar_ActivationTime = "@par_ActivationTime";
                    SQL_Parameter par_ActivationTime = new SQL_Parameter(spar_ActivationTime, SQL_Parameter.eSQL_Parameter.Datetime, false, transaction.ActivationTime);
                    lpar.Add(par_ActivationTime);

                    string spar_CommitTime = "@par_CommitTime";
                    SQL_Parameter par_CommitTime = new SQL_Parameter(spar_CommitTime, SQL_Parameter.eSQL_Parameter.Datetime, false, transaction.CommitTime);
                    lpar.Add(par_CommitTime);

                    string spar_RollBackTime = "@par_RollBackTime";
                    SQL_Parameter par_RollBackTime = new SQL_Parameter(spar_RollBackTime, SQL_Parameter.eSQL_Parameter.Datetime, false, transaction.RollBackTime);
                    lpar.Add(par_RollBackTime);

                    sql = "insert into TransactionLog (transactionName_ID,Number,CreationTime,ActivationTim,CommitTime,RollBackTime)values(" + spar_transactionName_ID + ","
                        + spar_Number + ","
                        + spar_CreationTime + ","
                        + spar_ActivationTime + ","
                        + spar_CommitTime + ","
                        + spar_RollBackTime + ")";
                    ID transactionLog_ID = null;
                    if (transaction_commit.ExecuteNonQuerySQLReturnID(m_DBTables.Con, sql, lpar, ref transactionLog_ID, ref err, "TransactionLog"))
                    {
                        if (transaction.TransactionSQLCommandList != null)
                        {
                            foreach (TransactionSQLCommand tsql in transaction.TransactionSQLCommandList)
                            {
                                lpar.Clear();
                                {
                                    tsql
                                }
                            }
                        }
                    }
                    else
                    {
                        transaction_commit.Rollback();
                        LogFile.Error.Show("ERROR:TransactionLogDataBaseDef:MyDataBase_TransactionsLog:WriteTransactionLog_Commit:Error=" + err + "\r\nSql=" + sql);
                        return false;
                    }
                    {
                        transaction_commit.Rollback();
                    }
                }
                else
                {
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


        public bool WriteTransactionLog_Rollback(Transaction transaction)
        {
            return false;
        }

    }
}