
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
        public bool WriteTransactionLog_BeginTransaction(string transaction_name, ref ID Transaction_ID)
        {
            return false;
        }


        public bool WriteTransactionLogExecute(ID Transaction_ID, string sql_command, List<SQL_Parameter> lpar, ID return_ID, bool bok, string error)
        {
            return false;
        }


        public bool WriteTransactionLog_Commit(ID Transaction_ID)
        {
            return false;
        }


        public bool WriteTransactionLog_Rollback(ID Transaction_ID)
        {
            return false;
        }

    }
}