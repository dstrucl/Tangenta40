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


namespace DBConnectionControl40
{
    //public class SQL_Parameter
    //{
    //    public string Name;
    //    public SqlDbType dbType;
    //    public int size;
    //    public Object Value;
    //}

    public class SQL_Parameter
    {
        public enum eSQL_Parameter {
                                    Int,
                                    Decimal,
                                    Float,
                                    Bit,
                                    Datetime,
                                    Nvarchar,
                                    Varchar,
                                    Nchar,
                                    Bigint,
                                    Smallint,
                                    Varbinary}
        public bool IsOutputParameter = false;
        public string Name;
        public SqlParameter MS_SqlSqlParameter;
        public SQLiteParameter mySQLiteParameter;
        public SqlDbType dbType;
        public MySqlDbType MySQLdbType;
        public DbType SQLiteDbType;
        public int size;
        public Object Value;

        public SQL_Parameter()
        {
        }


        public SQL_Parameter(string xName, eSQL_Parameter db_type, bool IsOutput, object xval)
        {
            MS_SqlSqlParameter = null;
            mySQLiteParameter = null;
            IsOutputParameter = IsOutput;
            Name = xName;
            Value = xval;
            size = -1;
            switch (db_type)
            {
                case eSQL_Parameter.Int:
                    dbType = SqlDbType.Int;
                    //                SQLiteDbType = DbType.Int32;
                    break;
                case eSQL_Parameter.Decimal:
                    dbType = SqlDbType.Decimal;
                    //                SQLiteDbType = DbType.Decimal;
                    break;
                case eSQL_Parameter.Float:
                     dbType = SqlDbType.Float;
                    //                SQLiteDbType = DbType.Decimal;
                    break;
            
                case eSQL_Parameter.Bit:
                    dbType = SqlDbType.Bit;
                    //                SQLiteDbType = DbType.Boolean;
                    break;
                case eSQL_Parameter.Datetime:
                    dbType = SqlDbType.DateTime;
                    //                SQLiteDbType = DbType.DateTime;
                    break;

                case eSQL_Parameter.Nvarchar:
                    dbType = SqlDbType.NVarChar;
                    //                SQLiteDbType = DbType.String;
                    break;

                case eSQL_Parameter.Varchar:
                    dbType = SqlDbType.VarChar;
                    //                SQLiteDbType = DbType.String;
                    break;
                case eSQL_Parameter.Nchar:
                    dbType = SqlDbType.NChar;
                    //                SQLiteDbType = DbType.String;
                    break;
                case eSQL_Parameter.Bigint:
                    dbType = SqlDbType.BigInt;
                    //                SQLiteDbType = DbType.Int64;
                    break;
                case eSQL_Parameter.Smallint:
                    dbType = SqlDbType.SmallInt;
                    //                SQLiteDbType = DbType.Int16;
                    break;
                case eSQL_Parameter.Varbinary:
                    dbType = SqlDbType.VarBinary;
                    SQLiteDbType = DbType.Binary;
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
                    break;
                default:
                    MessageBox.Show(" Type not implemented=" + db_type, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
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
