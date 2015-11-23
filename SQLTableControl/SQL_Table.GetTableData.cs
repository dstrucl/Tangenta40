using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBConnectionControl40;

namespace SQLTableControl
{
    partial class SQLTable
    {
        public bool FillDataTable(DBConnection m_SQL_connection, String SqlCmd,List<SQL_Parameter> lSQL_Parameter, ref DataTable dt, ref String csError)
        {
            dt.TableName = TableName;

            if (m_SQL_connection.FillDataTable(ref dt, SqlCmd, lSQL_Parameter,ref  csError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetTableData(DBConnection m_SQL_connection, ref DataTable dt, ref String csError, int iLimit, string sWhere)
        {

            string sxWhere;
            if (sWhere == null)
            {
                sxWhere = "";
            }
            else
            {
                sxWhere = sWhere;
            }
            String SqlCmd ="";
            if (iLimit > 0)
            {
                switch (m_SQL_connection.DBType)
                {
                    case DBConnection.eDBType.MYSQL:
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @";
                                  SELECT *
                                  FROM 
                                  " + TableName + sxWhere + " order by  ID LIMIT " + iLimit.ToString()+";";
                        break;
                    case DBConnection.eDBType.MSSQL:
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                  SELECT top " + iLimit.ToString()+ @" *
                                  FROM 
                                  " + TableName + sxWhere + " order by " + TableName + ".ID desc;";
                        break;

                    case DBConnection.eDBType.SQLITE:
                        SqlCmd = @"
                                  SELECT *
                                  FROM 
                                  " + TableName + sxWhere + " order by " + TableName + ".ID desc LIMIT " + iLimit.ToString();
                        break;
                }
            }
            else
            {
                switch (m_SQL_connection.DBType)
                {
                    case DBConnection.eDBType.MYSQL:
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @";
                                  SELECT *
                                  FROM 
                                  " + TableName + sxWhere;
                        break;
                    case DBConnection.eDBType.MSSQL:
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                  SELECT *
                                  FROM 
                                  " + TableName + sxWhere;
                        break;

                    case DBConnection.eDBType.SQLITE:
                        SqlCmd = @"
                                  SELECT *
                                  FROM 
                                  " + TableName + sxWhere;
                        break;
                }
            }


            dt.TableName = TableName;

            if (m_SQL_connection.ReadDataTable(ref dt, SqlCmd, ref  csError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetTableView(DBConnection m_SQL_connection, ref DataTable dt, ref String csError, int iTopAmount)
        {

            String SqlCmd;
            if (m_SQL_connection.DBType == DBConnection.eDBType.SQLITE)
            {
                if (iTopAmount > 0)
                {
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = @"    SELECT *
                                      FROM 
                                      " + ViewName + " LIMIT " + iTopAmount.ToString() + ";"; // +" order by ID desc;"; top " + iTopAmount.ToString() + @"
                    }
                    else
                    {
                        SqlCmd = @"
                                SELECT *
                                FROM 
                                " + TableName + " order by " + TableName + ".ID asc LIMIT " + iTopAmount.ToString() + ";";
                    }
                }
                else
                {
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = "    SELECT  * FROM " + ViewName;// +" order by ID desc;";
                    }
                    else
                    {
                        SqlCmd = "    SELECT  * FROM " + TableName + " order by " + TableName + ".ID asc;";
                    }
                }
            }
            else
            {
                if (iTopAmount > 0)
                {
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT top " + iTopAmount.ToString() + @" *
                                      FROM 
                                      " + ViewName;// +" order by ID desc;";
                    }
                    else
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT top " + iTopAmount.ToString() + @" *
                                      FROM 
                                      " + TableName + " order by " + TableName + ".ID desc;";
                    }
                }
                else
                {
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT *
                                      FROM 
                                      " + ViewName;// +" order by ID desc;";
                    }
                    else
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT *
                                      FROM 
                                      " + TableName + " order by " + TableName + ".ID desc;";
                    }
                }
            }
            dt.TableName = TableName;

            if (m_SQL_connection.ReadDataTable(ref dt, SqlCmd, ref  csError))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool GetTableView(DBConnection m_SQL_connection, ref DataTable dt, ref String csError,int iTopAmount, string sColumns ,string sWhere )
        {

            String SqlCmd = null;
            if (m_SQL_connection.DBType==DBConnection.eDBType.SQLITE)
            {
                string sOrderBy;
                if ((sColumns.Equals("*")) || sColumns.Contains("[ID]"))
                {
                    sOrderBy = " order by [" + TableName + ".ID] desc;";
                    if (sColumns.Contains("[ID]"))
                    {
                        sColumns.Replace("[ID]", "[" + TableName + ".ID]");
                    }
                }
                else
                {
                    sOrderBy = "";
                }
                

                if (iTopAmount > 0)
                {
                    string sLimit = " LIMIT " + iTopAmount.ToString() + ";";
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = "    SELECT " +sColumns +@"
                                      FROM 
                                      " + ViewName +" " + sWhere + sLimit;
                    }
                    else
                    {
                        SqlCmd = @"
                                SELECT " + sColumns +@"
                                FROM 
                                " + TableName + " " + sWhere + sOrderBy +  sLimit;
                    }
                }
                else
                {
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = "    SELECT  " + sColumns + " FROM " + ViewName + " " + sWhere;// +" order by ID desc;";
                    }
                    else
                    {
                        SqlCmd = "    SELECT  " + sColumns + " FROM " + TableName + " " + sWhere + sOrderBy;
                    }
                }
            }
            else 
            {
                if (iTopAmount > 0)
                {
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT top " + iTopAmount.ToString() + " " + sColumns + @"
                                      FROM 
                                      " + ViewName + " " + sWhere;// +" order by ID desc;";
                    }
                    else
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT top " + iTopAmount.ToString() + " " + sColumns + @"
                                      FROM 
                                      " + TableName + " " + sWhere + " order by " + TableName + ".ID desc;";
                    }
                }
                else
                {
                    if (dt == null)
                    {
                        LogFile.Error.Show("Error in GetTableView(..) ref DataTable dt may not be null!");
                    }
                    if (this.m_Fkey.Count > 0)
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT " + sColumns + @"
                                      FROM 
                                      " + " " + sWhere + ViewName;// +" order by ID desc;";
                    }
                    else
                    {
                        SqlCmd = "USE " + m_SQL_connection.DataBase + @"
                                      SELECT " + sColumns + @"
                                      FROM 
                                      " + TableName + " " + sWhere + " order by " + TableName + ".ID desc;";
                    }
                }
            }

            dt.TableName = TableName;

            if (m_SQL_connection.ReadDataTable(ref dt, SqlCmd, ref  csError))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
