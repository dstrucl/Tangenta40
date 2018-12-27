using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionControl40
{
    public class Transaction
    {
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
                    m_ActivationTime = DateTime.Now;
                    //if (m_TransactionLog_delegates!=null)
                    //{
                    //    m_TransactionLog_delegates.m_delegate_WriteTransactionLog_BeginTransaction(this);
                    //}
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
                            m_CommitTime = DateTime.Now;
                            identity = null;
                            m_Active = false;
                            if (m_TransactionLog_delegates!=null)
                            {
                                m_TransactionLog_delegates.m_delegate_WriteTransactionLog_Commit(this);
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
                            m_RollBackTime = DateTime.Now;
                            m_Active = false;
                            identity = null;
                            if (m_TransactionLog_delegates != null)
                            {
                                m_TransactionLog_delegates.m_delegate_WriteTransactionLog_Rollback(this);
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
                bool bresult = con.ExecuteNonQuerySQL(sql, lpar, ref err);
                writeTransactionLogExecute(sql, lpar, bresult, null, true, err);
                return bresult;
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
                bool bresult = con.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref err, table_name);
                writeTransactionLogExecute(sql, lpar, bresult, id, true, err);

                return bresult;
            }
            else
            {
                return false;
            }

        }

        private void writeTransactionLogExecute(string sql, List<SQL_Parameter> lpar, bool bresult, ID id, bool result, string err)
        {
            TransactionSQLCommand xTransactionSQLCommand = new TransactionSQLCommand(sql, lpar, id, result, err);
            if (TransactionSQLCommandList==null)
            {
                TransactionSQLCommandList = new List<TransactionSQLCommand>();
            }
            TransactionSQLCommandList.Add(xTransactionSQLCommand);

            //if (m_TransactionLog_delegates != null)
            //{
                
            //    if (ID.Validate(Transaction_ID))
            //    {
            //        m_TransactionLog_delegates.m_delegate_WriteTransactionLogExecute(this, sql, lpar, id, bresult, err);
            //    }
            //}
        }

        public bool ExecuteNonQuerySQL(DBConnection con, string sql, List<SQL_Parameter> lpar, ref string err)
        {
            if (GetTransaction(con))
            {
                bool bresult = con.ExecuteNonQuerySQL(sql, lpar, ref err);
                writeTransactionLogExecute(sql, lpar, bresult, null, true, err);
                return bresult;
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
                bool bresult =  m_con.ExecuteScalarReturnID(sbsqlUpdate, sqlParamList, ref newID, ref csError, tableName);
                writeTransactionLogExecute(sbsqlUpdate.ToString(), sqlParamList, bresult, newID, true, csError);
                return bresult;
            }
            else
            {
                return false;
            }

        }
    }
}
