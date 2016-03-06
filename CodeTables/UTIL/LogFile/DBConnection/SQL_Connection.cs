#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.Data.Common;


namespace LogFile
{
    //public class Log_SQL_Parameter
    //{
    //    public string Name;
    //    public SqlDbType dbType;
    //    public int size;
    //    public Object Value;
    //}

    public class Log_SQL_Parameter
    {
        public bool IsOutputParameter = false;
        public string Name;
        public SqlParameter MS_SqlSqlParameter;
        public SQLiteParameter mySQLiteParameter;
        public SqlDbType dbType;
        public MySqlDbType MySQLdbType;
        public DbType SQLiteDbType;
        public int size;
        public Object Value;
        public Log_SQL_Parameter()
        {
        }
        public Log_SQL_Parameter(string xName, string db_type, bool IsOutput, object xval)
        {
            MS_SqlSqlParameter = null;
            mySQLiteParameter = null;
            IsOutputParameter = IsOutput;
            Name = xName;
            Value = xval;
            size = -1;
            if (db_type.Equals("int"))
            {
                dbType = SqlDbType.Int;
            }
            else if (db_type.Equals("bit"))
            {
                dbType = SqlDbType.Bit;
            }
            else if (db_type.Equals("datetime"))
            {
                dbType = SqlDbType.DateTime;
            }
            else if (db_type.Equals("nvarchar"))
            {
                dbType = SqlDbType.NVarChar;
            }
            else if (db_type.Equals("varchar"))
            {
                dbType = SqlDbType.VarChar;
            }
            else if (db_type.Equals("nchar"))
            {
                dbType = SqlDbType.NChar;
            }
            else if (db_type.Equals("bigint"))
            {
                dbType = SqlDbType.BigInt;
            }
            else if (db_type.Equals("smallint"))
            {
                dbType = SqlDbType.SmallInt;
            }
            else if (db_type.Equals("varbinary"))
            {
                dbType = SqlDbType.VarBinary;
                if (Value.GetType() == typeof(byte[]))
                {
                    size = ((byte[])Value).Length * sizeof(byte);
                }
                else if (Value.GetType() == typeof(Byte[]))
                {
                    size = ((Byte[])Value).Length * sizeof(Byte);
                }
                else if (Value.GetType() == typeof(char[]))
                {
                    size = ((char[])Value).Length * sizeof(char);
                }
                else if (Value.GetType() == typeof(int[]))
                {
                    size = ((int[])Value).Length * sizeof(int);
                }
                else if (Value.GetType() == typeof(long[]))
                {
                    size = ((int[])Value).Length * sizeof(long);
                }

            }
            else
            {
                MessageBox.Show(" Type not implemented=" + db_type, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }


    public class SQLReaderRow
    {
       public List<Object> column = new List<object>();
    }
    
    public class SQLReaderTable
    {
        public List<SQLReaderRow> row = new List<SQLReaderRow>();
    }

}
