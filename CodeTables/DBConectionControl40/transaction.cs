﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionControl40
{
    public class Transaction
    {
        private DBConnection con = null;

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
            return true;
        }

        public bool Commit()
        {
            if (con!=null)
            {
                if (id != null)
                {
                    if (con.CommitTransaction(id))
                    {
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
                    LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Commit():id==null!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Commit():con==null!");
                return false;
            }
        }
        public bool Rollback()
        {
            if (con != null)
            {
                if (id != null)
                {
                    if (con.RollbackTransaction(id))
                    {
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
                    LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Rollback():id==null!");
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:DBConnectionControl40:Transaction:Rollback():con==null!");
                return false;
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
    }
}
