using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    partial class ConnectionSQLITE
    {

        private bool CanDoTransaction(string func_name, ref string ErrorMsg)
        {
            if (TransactionIsActive)
            {
                if (cmd != null)
                {
                    return true;
                }
                else
                {
                    ErrorMsg = "Error " + func_name + ":CanDoTransaction : SQLite Command is not created!";
                    return false;
                }
            }
            else
            {
                ErrorMsg = "Error " + func_name + ":CanDoTransaction : Transaction is not active!";
                return false;
            }

        }

        private bool CanDoRead(string func_name, ref string ErrorMsg)
        {
            if (cmd != null)
            {
                return true;
            }
            else
            {
                ErrorMsg = "Error " + func_name + ":CanDoRead : SQLite Command is not created!";
                return false;
            }
        }


        public bool ExecuteNonQuerySQL(string sql, List<SQL_Parameter> lSQL_Parameter,  ref string ErrorMsg)
        {
            if (TransactionsOnly)
            {
                if (CanDoTransaction("ExecuteNonQuerySQL", ref ErrorMsg))
                {
                    try
                    {
                        cmd.CommandText = sql.ToString();
                        cmd.Parameters.Clear();
                        if (lSQL_Parameter != null)
                        {
                            foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                            {
                                if (sqlPar.size > 0)
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    cmd.Parameters.Add(mySQLiteParameter);
                                }
                                else
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                    cmd.Parameters.Add(mySQLiteParameter);
                                }
                            }
                        }
                        cmd.CommandTimeout = 20000;
                        cmd.ExecuteNonQuery();
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                        return true;
                    }
                    catch (System.Exception ex)
                    {
                        ErrorMsg = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ExecuteNonQuerySQL:Exception=" + ex.Message+"\r\n", sql, cmd.Parameters);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    string sError = "";
                    if (Connect_Batch(ref sError))
                    {
                        if (cmd == null)
                        {
                            cmd = Con.CreateCommand();
                        }
                        cmd.CommandText = sql.ToString();

                        cmd.Parameters.Clear();
                        if (lSQL_Parameter != null)
                        {
                            foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                            {

                                if (sqlPar.size > 0)
                                {
                                    sqlPar.mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                    sqlPar.mySQLiteParameter.Value = sqlPar.Value;

                                }
                                else
                                {
                                    sqlPar.mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                    sqlPar.mySQLiteParameter.Value = sqlPar.Value;
                                }
                                cmd.Parameters.Add(sqlPar.mySQLiteParameter);

                            }
                        }
                        cmd.CommandTimeout = 20000;
                        cmd.ExecuteNonQuery();
                        Disconnect_Batch();
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show(sError);
                        return false;
                    }
                }
                catch (System.Exception ex)
                {
                    ErrorMsg = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ExecuteNonQuerySQL:Exception=" + ex.Message+"\r\n", sql, cmd.Parameters);
                    return false;
                }
            }
        }


        public bool ExecuteNonQueryReturnID(string sql, List<SQL_Parameter> lSQL_Parameter, ref ID newID, ref string ErrorMsg, string SQlite_table_name)
        {
            if (TransactionsOnly)
            {
                if (CanDoTransaction("ExecuteNonQuerySQL", ref ErrorMsg))
                {
                    try
                    {
                        cmd.CommandText = sql.ToString();
                        cmd.Parameters.Clear();
                        if (lSQL_Parameter != null)
                        {
                            foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                            {
                                if (sqlPar.size > 0)
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    cmd.Parameters.Add(mySQLiteParameter);

                                }
                                else
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    cmd.Parameters.Add(mySQLiteParameter);
                                }
                            }
                        }
                        cmd.CommandTimeout = 200000;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "SELECT last_insert_rowid() from " + SQlite_table_name;
                        newID = new ID(cmd.ExecuteScalar());
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorMsg = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ExecuteNonQueryReturnID:Exception=" + ex.Message+ "\r\n", sql, cmd.Parameters);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (Connect_Batch(ref ErrorMsg))
                {
                    try
                    {
                        SQLiteCommand command;
                        command = new SQLiteCommand(sql.ToString(), Con);
                        if (lSQL_Parameter != null)
                        {
                            foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                            {
                                if (sqlPar.size > 0)
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    command.Parameters.Add(mySQLiteParameter);

                                }
                                else
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    command.Parameters.Add(mySQLiteParameter);
                                }
                            }
                        }
                        command.CommandTimeout = 200000;
                        command.ExecuteNonQuery();
                        SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, Con);
                        newID = new ID(cmd.ExecuteScalar());
                        Disconnect_Batch();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorMsg = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ExecuteNonQueryReturnID:Exception=" + ex.Message+"\r\n", sql, cmd.Parameters);
                        return false;
                    }
                }
                else
                {                  
                    return false;
                }
            }
        }

        public bool ExecuteScalarReturnID(string sql, List<SQL_Parameter> lSQL_Parameter, ref ID id_new, ref string csError, string SQlite_table_name)
        {

            id_new = null;
            //SqlConnection Conn = new SqlConnection(xString);
            if (TransactionsOnly)
            {
                if (CanDoTransaction("ExecuteNonQuerySQL", ref csError))
                {
                    try
                    {
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = 200000;
                        cmd.Parameters.Clear();
                        if (lSQL_Parameter != null)
                        {
                            foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                            {
                                if (sqlPar.size > 0)
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    cmd.Parameters.Add(mySQLiteParameter);
                                }
                                else
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                    cmd.Parameters.Add(mySQLiteParameter);
                                }
                            }
                        }

                        Object ReturnObject = cmd.ExecuteScalar();
                        cmd.CommandText = "SELECT last_insert_rowid() from " + SQlite_table_name;
                        id_new = new ID(cmd.ExecuteScalar());
                        if (ReturnObject == null)
                        {
                            //SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() AS ID" , m_con_SQLite);
                            // On different Sqlite.dll runs different !
                            //                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, m_con_SQLite);
                            cmd = new SQLiteCommand("SELECT last_insert_rowid()", Con);
                            // Bepaal de nieuwe ID en sla deze op in het juiste veld
                            if (Connect_Batch(ref csError))
                            {
                                object nieuweID = cmd.ExecuteScalar();
                                id_new = new ID(nieuweID);
                                Disconnect_Batch();
                            }
                            else
                            {
                                LogFile.Error.Show(csError);
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                                return false;
                            }
                        }
                        else
                        {
                            if (ReturnObject.GetType() == typeof(string))
                            {
                                string s;
                                s = (string)ReturnObject;
                                if (DBConnection.IsNumber(s))
                                {
                                    id_new = new ID(ReturnObject);
                                }
                            }
                            else if (ReturnObject.GetType() == typeof(long))
                            {
                                id_new = new ID(ReturnObject);
                            }
                            else if (ReturnObject.GetType() == typeof(Int32))
                            {
                                id_new = new ID(ReturnObject);
                            }
                            else if (ReturnObject.GetType() == typeof(Int64))
                            {
                                id_new = new ID(ReturnObject);
                            }
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ExecuteScalarReturnID:Exception=" + ex.Message + "\r\n", sql, cmd.Parameters);
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    if (Connect_Batch(ref csError))
                    {
                        SQLiteCommand command = new SQLiteCommand(sql.ToString(), Con);
                        command.CommandTimeout = 200000;
                        if (lSQL_Parameter != null)
                        {
                            foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                            {
                                if (sqlPar.size > 0)
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    command.Parameters.Add(mySQLiteParameter);
                                }
                                else
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                    command.Parameters.Add(mySQLiteParameter);
                                }
                            }
                        }

                        Object ReturnObject = command.ExecuteScalar();
                        Disconnect_Batch();
                        if (ReturnObject == null)
                        {
                            //SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() AS ID" , m_con_SQLite);
                            // On different Sqlite.dll runs different !
                            //                                    SQLiteCommand cmd = new SQLiteCommand("SELECT last_insert_rowid() from " + SQlite_table_name, m_con_SQLite);
                            SQLiteCommand cmdx = new SQLiteCommand("SELECT last_insert_rowid()", Con);
                            // Bepaal de nieuwe ID en sla deze op in het juiste veld
                            if (Connect_Batch(ref csError))
                            {
                                object nieuweID = cmd.ExecuteScalar();
                                id_new = new ID(nieuweID);
                                Disconnect_Batch();
                            }
                            else
                            {
                                LogFile.Error.Show(csError);
                                ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                                return false;
                            }
                        }
                        else
                        {
                            if (ReturnObject.GetType() == typeof(string))
                            {
                                string s;
                                s = (string)ReturnObject;
                                if (DBConnection.IsNumber(s))
                                {
                                    id_new = new ID(ReturnObject);
                                }
                            }
                            else if (ReturnObject.GetType() == typeof(long))
                            {
                                id_new = new ID(ReturnObject);
                            }
                            else if (ReturnObject.GetType() == typeof(Int32))
                            {
                                id_new = new ID(ReturnObject);
                            }
                            else if (ReturnObject.GetType() == typeof(Int64))
                            {
                                id_new = new ID(ReturnObject);
                            }
                        }
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END", null);
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show(csError);
                        ProgramDiagnostic.Diagnostic.Meassure("ExecuteQuerySQL END ERROR", null);
                        return false;
                    }
                }
                catch (System.Exception ex)
                {
                    csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ExecuteNonQueryReturnID:Exception="+ex.Message+"\r\n", sql, cmd.Parameters);
                    return false;
                }
            }
        }

        public bool ReadDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, ref string csError)
        {
            if (TransactionsOnly)
            {
                try
                {
                    if (Connect_Batch(ref csError))
                    {
                        if (cmd==null)
                        {
                            cmd = Con.CreateCommand();
                        }
                        cmd.CommandText = sqlGetColumnsNamesAndTypes;
                        if (this.adapter == null)
                        {
                            adapter = new SQLiteDataAdapter(cmd);
                        }
                        adapter.Fill(dt);
                    }
                    else
                    {
                        MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ReadDataTable:Exception="+ex.Message+"\r\n", sqlGetColumnsNamesAndTypes, cmd.Parameters);
                    return false;
                }
            }
            else
            {
                SQLiteDataAdapter adapterx = new SQLiteDataAdapter();

                if (Connect_Batch(ref csError))
                {
                    try
                    {
                        SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, Con);
                        adapterx.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                        adapterx.Fill(dt);
                        adapterx.Dispose();
                        SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                        Disconnect_Batch();
                    }
                    catch (Exception ex)
                    {
                        csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ReadDataTable:Exception=" + ex.Message + "\r\n", sqlGetColumnsNamesAndTypes, cmd.Parameters);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            return true;
        }

        public bool ReadDataTable(ref DataTable dt, string sqlGetColumnsNamesAndTypes, List<SQL_Parameter> lSQL_Parameter, ref string csError)
        {
            ProgramDiagnostic.Diagnostic.Meassure("ReadDataTable START", sqlGetColumnsNamesAndTypes);
            if (TransactionsOnly)
            {
                try
                {
                    if (Connect_Batch(ref csError))
                    {
                        if (cmd == null)
                        {
                            cmd = Con.CreateCommand();
                        }
                        cmd.CommandText = sqlGetColumnsNamesAndTypes;
                        if (lSQL_Parameter != null)
                        {
                            foreach (SQL_Parameter sqlPar in lSQL_Parameter)
                            {
                                if (sqlPar.size > 0)
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.SQLiteDbType, sqlPar.size);
                                    mySQLiteParameter.Value = sqlPar.Value;
                                    cmd.Parameters.Add(mySQLiteParameter);
                                }
                                else
                                {
                                    SQLiteParameter mySQLiteParameter = new SQLiteParameter(sqlPar.Name, sqlPar.Value);
                                    cmd.Parameters.Add(mySQLiteParameter);
                                }
                            }
                        }
                        if (this.adapter == null)
                        {
                            this.adapter = new SQLiteDataAdapter(cmd);
                        }
                        adapter.SelectCommand = cmd;
                        adapter.Fill(dt);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ReadDataTable with lpar:Exception=" + ex.Message + "\r\n", sqlGetColumnsNamesAndTypes, cmd.Parameters);
                    return false;
                }
            }
            else
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();

                if (Connect_Batch(ref csError))
                {
                    try
                    {
                        SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, Con);
                        adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                        adapter.Fill(dt);
                        adapter.Dispose();
                        SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                        Disconnect_Batch();
                    }
                    catch (Exception ex)
                    {
                        csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ReadDataTable with lpar:Exception=" + ex.Message + "\r\n", sqlGetColumnsNamesAndTypes, cmd.Parameters);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(csError, "ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            return true;
        }

        public bool ReadDataSet(ref DataSet ds, string sqlGetColumnsNamesAndTypes, ref string csError)
        {

            //SqlConnection Conn = new SqlConnection("Data Source=razvoj1;Initial Catalog=NOS_BIH;Persist Security Info=True;User ID=sa;Password=sa;");
            if (TransactionsOnly)
            {
                try
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                    string sError = "";
                    if (Connect_Batch(ref sError))
                    {
                        if (cmd == null)
                        {
                            cmd = Con.CreateCommand();
                        }
                        cmd.CommandText = sqlGetColumnsNamesAndTypes;
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ReadDataSet:Exception=" + ex.Message + "\r\n", sqlGetColumnsNamesAndTypes, cmd.Parameters);
                    return false;
                }
            }
            else
            {
                try
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                    string sError = "";
                    if (Connect_Batch(ref sError))
                    {
                        SQLiteCommand SqlCommandcommandGetColumnsNamesAndTypes = new SQLiteCommand(sqlGetColumnsNamesAndTypes, Con);
                        adapter.SelectCommand = SqlCommandcommandGetColumnsNamesAndTypes;
                        adapter.Fill(ds);
                        adapter.Dispose();
                        SqlCommandcommandGetColumnsNamesAndTypes.Dispose();
                        Disconnect_Batch();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    csError = SetError("ERROR:DBConnectionControl40:ConnectionSQLIte:ReadDataSet:Exception=" + ex.Message + "\r\n", sqlGetColumnsNamesAndTypes, cmd.Parameters);
                    return false;
                }
            }
        }
    }
}
