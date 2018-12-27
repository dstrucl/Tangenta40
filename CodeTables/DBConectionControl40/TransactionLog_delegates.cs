using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionControl40
{
    public class TransactionLog_delegates
    {
        //public delegate bool delegate_WriteTransactionLog_BeginTransaction(Transaction transaction);

        //internal delegate_WriteTransactionLog_BeginTransaction m_delegate_WriteTransactionLog_BeginTransaction = null;

        //public delegate bool delegate_WriteTransactionLogExecute(Transaction transaction, string sql_command, List<SQL_Parameter> lpar, ID return_ID, bool bok, string error);

        //internal delegate_WriteTransactionLogExecute m_delegate_WriteTransactionLogExecute = null;

        public delegate bool delegate_WriteTransactionLog_Commit(Transaction transaction);

        internal delegate_WriteTransactionLog_Commit m_delegate_WriteTransactionLog_Commit = null;

        public delegate bool delegate_WriteTransactionLog_Rollback(Transaction transaction);

        internal delegate_WriteTransactionLog_Rollback m_delegate_WriteTransactionLog_Rollback = null;

        public TransactionLog_delegates(/*delegate_WriteTransactionLog_BeginTransaction xdelegate_WriteTransactionLog_BeginTransaction,
                                        delegate_WriteTransactionLogExecute xdelegate_WriteTransactionLogExecute,*/
                                        delegate_WriteTransactionLog_Commit xdelegate_WriteTransactionLog_Commit,
                                        delegate_WriteTransactionLog_Rollback xdelegate_WriteTransactionLog_RollBack)
        {
            //m_delegate_WriteTransactionLog_BeginTransaction = xdelegate_WriteTransactionLog_BeginTransaction;
            //m_delegate_WriteTransactionLogExecute = xdelegate_WriteTransactionLogExecute;
            m_delegate_WriteTransactionLog_Commit = xdelegate_WriteTransactionLog_Commit;
            m_delegate_WriteTransactionLog_Rollback = xdelegate_WriteTransactionLog_RollBack;
        }
    }
}
