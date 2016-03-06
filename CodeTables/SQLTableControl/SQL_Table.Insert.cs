#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBConnectionControl40;
using DBTypes;
using System.Data;

namespace CodeTables
{
    partial class SQLTable
    {
        public bool Insert(ref long ID, DBTableControl dbTables)
        {
            switch (dbTables.m_con.DBType)
            {
                case DBConnectionControl40.DBConnection.eDBType.SQLITE:
                    return Insert_SQL(ref ID, dbTables,-1);
                case DBConnectionControl40.DBConnection.eDBType.MSSQL:
                    return Insert_SQL(ref ID, dbTables,-1);
                case DBConnectionControl40.DBConnection.eDBType.MYSQL:
                    return Insert_SQL(ref ID, dbTables,-1);
            }
            return false;
        }

        private bool Insert_MYSQL(ref long ID, DBTableControl dbTables)
        {
            throw new NotImplementedException();
        }

        private bool Insert_MSSQL(ref long ID, DBTableControl dbTables, int iSQLFormatedTabsWithLineBreaks)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string sql_insert = " insert into " + this.TableName;


            string sql_insert_columns = "";
            string sql_insert_values = "";
            string crlf = "\r\n";

            if (iSQLFormatedTabsWithLineBreaks >= 0)
            {
                sql_insert += crlf + "(" + crlf;
            }
            else
            {
                sql_insert += "(";
            }


            int i = 0;
            foreach (Column col in Column)
            {
                if (!col.IsIdentity)
                {
                    SQL_Parameter par = null;
                    string Insert_into_value_parameter = null;
                    if (col.get_SQL_Parameter(ref par, ref Insert_into_value_parameter, dbTables, iSQLFormatedTabsWithLineBreaks))
                    {
                        if (par != null)
                        {
                            if (i == 0)
                            {
                                sql_insert_columns += col.Name;
                                sql_insert_values += Insert_into_value_parameter;
                                i = 1;
                            }
                            else
                            {
                                if (iSQLFormatedTabsWithLineBreaks >= 0)
                                {
                                    sql_insert_columns += "," + crlf + col.Name;
                                    sql_insert_values += "," + crlf + Insert_into_value_parameter;
                                }
                                else
                                {
                                    sql_insert_columns += "," + col.Name;
                                    sql_insert_values += "," + Insert_into_value_parameter;
                                }
                            }
                            lpar.Add(par);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (iSQLFormatedTabsWithLineBreaks >= 0)
            {
                sql_insert += sql_insert_columns + crlf + ")" + crlf + "values" + crlf + "(" + crlf + sql_insert_values + crlf + ")";
            }
            else
            {
                sql_insert += sql_insert_columns + ")values(" + sql_insert_values + ")";
            }
            object objret = null;
            string Err = null;
            if (dbTables.m_con.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref ID, ref objret, ref Err, this.TableName))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:SQLTable:Insert_SQLite:Err=" + Err);
                return false;
            }
        }

        internal bool Insert_SQL(ref long ID, DBTableControl dbTables, int iSQLFormatedTabsWithLineBreaks)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string sql_insert = " insert into " + this.TableName;


            string sql_insert_columns = "";
            string sql_insert_values = "";
            string crlf = "\r\n";

            if (iSQLFormatedTabsWithLineBreaks>=0)
            {
                sql_insert += crlf + "(" + crlf;
            }
            else
            {
                sql_insert += "(";
            }


            int i = 0;
            foreach (Column col in Column)
            {
                if (!col.IsIdentity)
                {
                    SQL_Parameter par = null;
                    string Insert_into_value_parameter = null;
                    if (col.get_SQL_Parameter(ref par, ref Insert_into_value_parameter,dbTables, iSQLFormatedTabsWithLineBreaks))
                    {
                        if (par != null)
                        {
                            if (i == 0)
                            {
                                sql_insert_columns += col.Name;
                                sql_insert_values += Insert_into_value_parameter;
                                i = 1;
                            }
                            else
                            {
                                if (iSQLFormatedTabsWithLineBreaks>=0)
                                {
                                    sql_insert_columns += "," + crlf + col.Name;
                                    sql_insert_values += "," + crlf + Insert_into_value_parameter;
                                }
                                else
                                {
                                    sql_insert_columns += "," + col.Name;
                                    sql_insert_values += "," + Insert_into_value_parameter;
                                }
                            }
                            lpar.Add(par);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (iSQLFormatedTabsWithLineBreaks>=0)
            {
                sql_insert += sql_insert_columns +crlf+ ")"+crlf+"values"+ crlf +"(" +crlf+ sql_insert_values + crlf+ ")";
            }
            else
            {
                sql_insert += sql_insert_columns + ")values(" + sql_insert_values + ")";
            }
            object objret = null;
            string Err = null;
            if (dbTables.m_con.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref ID, ref objret, ref Err, this.TableName))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("Error:SQLTable:Insert_SQLite:Err=" + Err);
                return false;
            }
        }

        internal bool Insert_SQLite_Get_Select_Unique_ID(ref long_v id_v,DBTableControl dbTables, int iSQLFormatedTabsWithLineBreaks)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string sql_select = " select id from " + this.TableName + " where ";
            string sql_compare_values = "";
            string sql_InsertColumns = "";
            string sql_InsertValues = "";
            int i = 0;
            foreach (Column col in Column)
            {
                if (!col.IsIdentity)
                {
                    if ((col.flags & CodeTables.Column.Flags.UNIQUE) != 0)
                    {
                        string compare_value_parameter = null;
                        SQL_Parameter par = null;
                        if (col.get_SQL_Parameter(ref par, ref compare_value_parameter,dbTables, iSQLFormatedTabsWithLineBreaks))
                        {
                            if (i == 0)
                            {
                                if (iSQLFormatedTabsWithLineBreaks < 0)
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += col.Name + " is null ";
                                        sql_InsertValues += "null";
                                    }
                                    else
                                    {
                                        sql_compare_values += col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += compare_value_parameter;
                                        lpar.Add(par);
                                    }
                                    sql_InsertColumns += col.Name;
                                }
                                else
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += "\r\n" + col.Name + " is null ";
                                        sql_InsertValues += "\r\nnull";
                                    }
                                    else
                                    {
                                        sql_compare_values += "\r\n" + col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += "\r\n" + compare_value_parameter;
                                        lpar.Add(par);

                                    }
                                    sql_InsertColumns += "\r\n" + col.Name;
                                }
                                i = 1;
                            }
                            else
                            {
                                if (iSQLFormatedTabsWithLineBreaks < 0)
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += " or " + col.Name + " is null ";
                                        sql_InsertValues += ",null";
                                    }
                                    else
                                    {
                                        sql_compare_values += " or " + col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += "," + compare_value_parameter;
                                        lpar.Add(par);
                                    }
                                    sql_InsertColumns += "," + col.Name;
                                }
                                else
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += "\r\n or " + col.Name + " is null ";
                                        sql_InsertValues += "\r\n,null";
                                    }
                                    else
                                    {
                                        sql_compare_values += "\r\n or " + col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += "\r\n," + compare_value_parameter;
                                        lpar.Add(par);
                                    }
                                    sql_InsertColumns += "\r\n," + col.Name;
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
                        string compare_value_parameter = null;
                        SQL_Parameter par = null;
                        if (col.get_SQL_Parameter(ref par, ref compare_value_parameter, dbTables, iSQLFormatedTabsWithLineBreaks))
                        {
                            if (i == 0)
                            {
                                if (iSQLFormatedTabsWithLineBreaks < 0)
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += col.Name + " is null ";
                                        sql_InsertValues += "null";
                                    }
                                    else
                                    {
                                        sql_compare_values += col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += compare_value_parameter;
                                        lpar.Add(par);
                                    }
                                    sql_InsertColumns += col.Name;
                                }
                                else
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += "\r\n" + col.Name + " is null ";
                                        sql_InsertValues += "\r\nnull";
                                    }
                                    else
                                    {
                                        sql_compare_values += "\r\n" + col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += "\r\n" + compare_value_parameter;
                                        lpar.Add(par);

                                    }
                                    sql_InsertColumns += "\r\n" + col.Name;
                                }
                                i = 1;
                            }
                            else
                            {
                                if (iSQLFormatedTabsWithLineBreaks < 0)
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += " and " + col.Name + " is null ";
                                        sql_InsertValues += ",null";
                                    }
                                    else
                                    {
                                        sql_compare_values += " and " + col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += "," + compare_value_parameter;
                                        lpar.Add(par);
                                    }
                                    sql_InsertColumns += "," + col.Name;
                                }
                                else
                                {
                                    if (compare_value_parameter.Equals("null"))
                                    {
                                        sql_compare_values += "\r\n and " + col.Name + " is null ";
                                        sql_InsertValues += "\r\n,null";
                                    }
                                    else
                                    {
                                        sql_compare_values += "\r\n and " + col.Name + " = " + compare_value_parameter;
                                        sql_InsertValues += "\r\n," + compare_value_parameter;
                                        lpar.Add(par);
                                    }
                                    sql_InsertColumns += "\r\n," + col.Name;
                                }

                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            if (sql_compare_values.Length > 0)
            {
                sql_select += sql_compare_values;
                DataTable dt = new DataTable();
                string Err = null;
                if (dbTables.m_con.ReadDataTable(ref dt, sql_select, lpar, ref Err))
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (id_v == null)
                        {
                            id_v = new long_v();
                        }
                        id_v.v = (long)dt.Rows[0]["id"];
                        return true;
                    }
                    else
                    {
                        string sql_Insert = " insert into " + this.TableName + "(" + sql_InsertColumns + ")values(" + sql_InsertValues + ")";
                        object oret = null;
                        long id = -1;
                        if (dbTables.m_con.ExecuteNonQuerySQLReturnID(sql_Insert, lpar, ref id, ref oret, ref Err, this.TableName))
                        {
                            if (id_v == null)
                            {
                                id_v = new long_v();
                            }
                            id_v.v = id;
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Insert_SQLite_Get_Select_Unique_ID:sql=" + sql_select + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:Insert_SQLite_Get_Select_Unique_ID:sql=" + sql_select + "\r\nErr=" + Err);
                    return false;
                }
            }
            return true;
        }

        internal bool Insert_SQL_Get_Select_ID(ref long_v id_v, DBTableControl dbTables, int iSQLFormatedTabsWithLineBreaks)
        {
            if (Insert_SQLite_Get_Select_Unique_ID(ref id_v, dbTables, iSQLFormatedTabsWithLineBreaks))
            {
                if (id_v != null)
                {
                    return true;
                }
                else
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    string sql_select = " select id from " + this.TableName + " where ";
                    string sql_compare_values = "";
                    string sql_InsertColumns = "";
                    string sql_InsertValues = "";
                    int i = 0;
                    foreach (Column col in Column)
                    {
                        if (!col.IsIdentity)
                        {
                            string compare_value_parameter = null;
                            SQL_Parameter par = null;
                            if (col.get_SQL_Parameter(ref par, ref compare_value_parameter, dbTables, iSQLFormatedTabsWithLineBreaks))
                            {
                                if (i == 0)
                                {
                                    if (iSQLFormatedTabsWithLineBreaks < 0)
                                    {
                                        if (compare_value_parameter.Equals("null"))
                                        {
                                            sql_compare_values += col.Name + " is null ";
                                            sql_InsertValues += "null";
                                        }
                                        else
                                        {
                                            sql_compare_values += col.Name + " = " + compare_value_parameter;
                                            sql_InsertValues += compare_value_parameter;
                                            lpar.Add(par);
                                        }
                                        
                                    }
                                    else
                                    {
                                        if (compare_value_parameter.Equals("null"))
                                        {
                                            sql_compare_values += "\r\n" + col.Name + " is null ";
                                            sql_InsertValues += "\r\nnull";
                                        }
                                        else
                                        {
                                            sql_compare_values += "\r\n" + col.Name + " = " + compare_value_parameter;
                                            sql_InsertValues += "\r\n" + compare_value_parameter;
                                            lpar.Add(par);

                                        }
                                    }
                                    sql_InsertColumns += col.Name;
                                    i = 1;
                                }
                                else
                                {
                                    if (iSQLFormatedTabsWithLineBreaks < 0)
                                    {
                                        if (compare_value_parameter.Equals("null"))
                                        {
                                            sql_compare_values += " and " + col.Name + " is null ";
                                            sql_InsertValues += ",null";
                                        }
                                        else
                                        {
                                            sql_compare_values += " and " + col.Name + " = " + compare_value_parameter;
                                            sql_InsertValues += "," + compare_value_parameter;
                                            lpar.Add(par);
                                        }
                                    }
                                    else
                                    {
                                        if (compare_value_parameter.Equals("null"))
                                        {
                                            sql_compare_values += "\r\n and " + col.Name + " is null ";
                                            sql_InsertValues += "\r\n,null";
                                        }
                                        else
                                        {
                                            sql_compare_values += "\r\n and " + col.Name + " = " + compare_value_parameter;
                                            sql_InsertValues += "\r\n," + compare_value_parameter;
                                            lpar.Add(par);
                                        }
                                    }
                                    sql_InsertColumns += ","+col.Name;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    if (sql_compare_values.Length > 0)
                    {
                        sql_select += sql_compare_values;
                        DataTable dt = new DataTable();
                        string Err = null;
                        if (dbTables.m_con.ReadDataTable(ref dt, sql_select, lpar, ref Err))
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (id_v == null)
                                {
                                    id_v = new long_v();
                                }
                                id_v.v = (long)dt.Rows[0]["id"];
                                return true;
                            }
                            else
                            {
                                string sql_insert = "insert into " + this.TableName + "(" + sql_InsertColumns+")Values("+sql_InsertValues+")";            // row not found
                                long id = -1;
                                object oret = null;
                                if (dbTables.m_con.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref id, ref oret, ref Err, this.TableName))
                                {
                                    if (id_v == null)
                                    {
                                        id_v = new long_v();
                                    }
                                    id_v.v = id;
                                    return true;
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:Insert_SQLite_Get_Select_ID:sql=" + sql_select + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:Insert_SQLite_Get_Select_ID:sql=" + sql_select + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }



        internal bool Insert_SQL_Get_ID(ref long_v id_v,DBTableControl dbTables, int iSQLFormatedTabsWithLineBreaks)
        {
            if (myGroupBox != null)
            {
                bool bOneInputControlChanged = this.AtLeastOneInputControlChanged();
                if (!bOneInputControlChanged && myGroupBox.Get_ID(ref id_v))
                {
                    return true;
                }
                else
                {
                    if (Insert_SQL_Get_Select_ID(ref id_v, dbTables, iSQLFormatedTabsWithLineBreaks))
                    {
                        if (id_v != null)
                        {
                            return true;
                        }
                        else
                        {
                            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                            string sql_insert = " insert into " + this.TableName;


                            string sql_insert_columns = "";
                            string sql_insert_values = "";
                            string crlf = "\r\n";

                            if (iSQLFormatedTabsWithLineBreaks >= 0)
                            {
                                sql_insert += crlf + "(" + crlf;
                            }
                            else
                            {
                                sql_insert += "(";
                            }


                            int i = 0;
                            foreach (Column col in Column)
                            {
                                if (!col.IsIdentity)
                                {
                                    SQL_Parameter par = null;
                                    string Insert_into_value_parameter = null;
                                    if (col.get_SQL_Parameter(ref par, ref Insert_into_value_parameter, dbTables, iSQLFormatedTabsWithLineBreaks))
                                    {
                                        if (par != null)
                                        {
                                            if (i == 0)
                                            {
                                                sql_insert_columns += col.Name;
                                                sql_insert_values += Insert_into_value_parameter;
                                                i = 1;
                                            }
                                            else
                                            {
                                                if (iSQLFormatedTabsWithLineBreaks >= 0)
                                                {
                                                    sql_insert_columns += "," + crlf + col.Name;
                                                    sql_insert_values += "," + crlf + Insert_into_value_parameter;
                                                }
                                                else
                                                {
                                                    sql_insert_columns += "," + col.Name;
                                                    sql_insert_values += "," + Insert_into_value_parameter;
                                                }
                                            }
                                            lpar.Add(par);
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                            }
                            if (iSQLFormatedTabsWithLineBreaks >= 0)
                            {
                                sql_insert += sql_insert_columns + crlf + ")" + crlf + "values" + crlf + "(" + crlf + sql_insert_values + crlf + ")";
                            }
                            else
                            {
                                sql_insert += sql_insert_columns + ")values(" + sql_insert_values + ")";
                            }
                            object objret = null;
                            string Err = null;
                            long ID = -1;
                            if (dbTables.m_con.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref ID, ref objret, ref Err, this.TableName))
                            {
                                id_v = new long_v();
                                id_v.v = ID;
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("Error:SQLTable:Insert_SQLite:Err=" + Err);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                LogFile.Error.Show("Error:SQLTable:Insert_SQLite:myGroupBox==null");
                return false;
            }
        }

    }
}
