using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionControl40
{
    public class Transaction
    {
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

        private string id = null;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Transaction(string xname)
        {
            name = xname;
        }

        public bool Executed
        {
            get
            {
                return id != null;
            }
        }

        public bool GetTransaction(DBConnection m_con)
        {
            if (id == null)
            {
                con = m_con;
                if (!con.BeginTransaction(name, ref id))
                {
                    return false;
                }
            }
            else
            {
                if (con==null)
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
                if (id != null)
                {
                    if (con != null)
                    {
                        if (con.CommitTransaction(id))
                        {
                            id = null;
                            m_Active = false;
                            return true;
                        }
                        else
                        {
                            id = null;
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
                if (id != null)
                {
                    if (con != null)
                    {
                        if (con.RollbackTransaction(id))
                        {
                            m_Active = false;
                            id = null;
                            return true;
                        }
                        else
                        {
                            id = null;
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
                return con.ExecuteNonQuerySQL(sql, lpar, ref err);
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
                return con.ExecuteNonQuerySQLReturnID(sql, lpar, ref id, ref err, table_name);
            }
            else
            {
                return false;
            }

        }

        public bool ExecuteNonQuerySQL(DBConnection con, string sql, List<SQL_Parameter> lpar, ref string err)
        {
            if (GetTransaction(con))
            {
                return con.ExecuteNonQuerySQL(sql, lpar, ref err);
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
                return m_con.ExecuteScalarReturnID(sbsqlUpdate, sqlParamList, ref newID, ref csError, tableName);
            }
            else
            {
                return false;
            }

        }
    }
}
