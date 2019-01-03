using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransactionLogDataBaseDef;
using DBTypes;
using DBConnectionControl40;

namespace TransactionLog
{
    public partial class usrc_TransactionLog : UserControl
    {
        internal MyDataBase_TransactionsLog myDataBase_TransactionsLog = null;
        internal DataTable dt_TransactionsLog = null;
        internal DataTable dt_SQLCommand = null;
        internal DataTable dt_SQL_Parameters = null;
        public usrc_TransactionLog()
        {
            InitializeComponent();
        }

        internal bool init()
        {
            string err = null;
            string sql = @"select Number,trn.Name as TransactionName,CreationTime,ActivationTime,CommitTime,RollBackTime, trl.ID from TransactionLog trl inner join TransactionName trn on trl.TransactionName_ID = trn.ID order by Number desc";
            this.dgvx_TransactionLog.DataSource = null;
            if (dt_TransactionsLog != null)
            {
                dt_TransactionsLog.Dispose();
                dt_TransactionsLog = null;
            }
            dt_TransactionsLog = new DataTable();
            if (myDataBase_TransactionsLog.m_DBTables.Con.ReadDataTable(ref dt_TransactionsLog, sql, ref err))
            {
                DataColumn dcol_TransactionTime = new DataColumn("TransactionTime in sec", typeof(decimal));
                dt_TransactionsLog.Columns.Add(dcol_TransactionTime);
                foreach (DataRow dr in dt_TransactionsLog.Rows)
                {
                    DateTime_v ActivationTime_v = DBTypes.tf.set_DateTime(dr["ActivationTime"]);
                    DateTime_v CommitTime_v = DBTypes.tf.set_DateTime(dr["CommitTime"]);
                    if ((ActivationTime_v != null) && (CommitTime_v != null))
                    {

                        dr["TransactionTime in sec"] = Convert.ToDecimal((CommitTime_v.v - ActivationTime_v.v).TotalSeconds);
                    }
                }


                this.dgvx_TransactionLog.DataSource = dt_TransactionsLog;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLog:Form_TransactionLog:init: err=" + err + "\r\nsql=" + sql);
                return false;
            }
        }

        private void dgvx_TransactionLog_SelectionChanged(object sender, EventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView dataGridView_Table = (DataGridView)sender;
                DataGridViewSelectedCellCollection dgvCellCollection = dataGridView_Table.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;

                    if (dgvCellCollection[0].OwningRow.Cells["TransactionName"].Value is string)
                    {
                        this.txt_TransactionName.Text = (string)dgvCellCollection[0].OwningRow.Cells["TransactionName"].Value;
                        if (dgvCellCollection[0].OwningRow.Cells["ID"].Value is long)
                        {
                            ID transaction_ID = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["ID"].Value);
                            ShowSQLCommands(transaction_ID);
                        }
                    }
                }
                else
                {
                    //lbl_test_sender_type.Text = "Num Selected cels = 0";
                }
            }
        }

        private bool ShowSQLCommands(ID transaction_ID)
        {
            string err = null;
            string sql = @"select cmdt.SQLText as CommandText, ExecutionStart, ExecutionEnd,Error, sqlcmd.ID from SQLCommand sqlcmd inner join CommandText cmdt on sqlcmd.CommandText_ID = cmdt.ID 
                           where TransactionLog_ID = " + transaction_ID.ToString()+ " order by ExecutionStart desc";
            this.dgvx_SQLCommand.DataSource = null;
            if (dt_SQLCommand != null)
            {
                dt_SQLCommand.Dispose();
                dt_SQLCommand = null;
            }
            dt_SQLCommand = new DataTable();
            if (myDataBase_TransactionsLog.m_DBTables.Con.ReadDataTable(ref dt_SQLCommand, sql, ref err))
            {
                DataColumn dcol_Execution_time = new DataColumn("ExecutionTime in sec", typeof(decimal));
                dt_SQLCommand.Columns.Add(dcol_Execution_time);
                foreach (DataRow dr in dt_SQLCommand.Rows)
                {
                    DateTime_v ExecutionEnd_v =   DBTypes.tf.set_DateTime(dr["ExecutionEnd"]);
                    DateTime_v ExecutionStart_v = DBTypes.tf.set_DateTime(dr["ExecutionStart"]);
                    if ((ExecutionEnd_v!=null)&&(ExecutionStart_v!=null))
                    {

                        dr["ExecutionTime in sec"] = Convert.ToDecimal((ExecutionEnd_v.v - ExecutionStart_v.v).TotalSeconds);
                    }
                }
                this.dgvx_SQLCommand.DataSource = dt_SQLCommand;
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLog:Form_TransactionLog:ShowSQLCommands: err=" + err + "\r\nsql=" + sql);
                return false;
            }
        }


        private void dgvx_SQLCommand_SelectionChanged(object sender, EventArgs e)
        {

            if (sender is DataGridView)
            {
                DataGridView dataGridView_Table = (DataGridView)sender;
                DataGridViewSelectedCellCollection dgvCellCollection = dataGridView_Table.SelectedCells;
                if (dgvCellCollection.Count >= 1)
                {
                    //lbl_test_sender_type.Text = "Count:" + dgvCellCollection.Count.ToString() + " CellType=" + dgvCellCollection[0].GetType().ToString() + " ValueType" + dgvCellCollection[0].Value.GetType().ToString() + " Value=" + dgvCellCollection[0].Value.ToString() + " Column Name = " + dgvCellCollection[0].OwningColumn.Name;

                    if (dgvCellCollection[0].OwningRow.Cells["CommandText"].Value is string)
                    {
                        this.tstxt_SQLCommand.Text = (string)dgvCellCollection[0].OwningRow.Cells["CommandText"].Value;
                        if (dgvCellCollection[0].OwningRow.Cells["ID"].Value is long)
                        {
                            ID sqlcommand_ID = tf.set_ID(dgvCellCollection[0].OwningRow.Cells["ID"].Value);
                            if (ShowSQL_Parameters(sqlcommand_ID))
                            {
                                this.splitContainer2.Panel2Collapsed = false;
                            }
                            else
                            {
                                this.splitContainer2.Panel2Collapsed = true;
                            }

                        }
                    }
                }
                else
                {
                    //lbl_test_sender_type.Text = "Num Selected cels = 0";
                }
            }
        }

        private bool ShowSQL_Parameters(ID sqlcommand_ID)
        {
            Clear_All_usrc_SQL_Parameter();
            string err = null;
            string sql = @"select
                       pnxBigint.Name as Name4_Bigint,
	                   pBigint.V_Bigint,
                       pnxsmallint.Name as Name4_smallint,
	                   psmallint.V_smallint,
                       pnxInt.Name as Name4_Int,
	                   pInt.V_Int,
                       pnxBit.Name as Name4_Bit,
	                   pBit.V_Bit,
                       pnxDecimal.Name as Name4_Decimal,
	                   pDecimal.V_Decimal,
                       pnxFloat.Name as Name4_Float,
	                   pFloat.V_Float,
                       pnxDateTime.Name as Name4_DateTime,
	                   pDateTime.V_DateTime,
                       pnxNVarchar.Name as Name4_NVarchar,
	                   pNVarchar.V_varchar_max as V_NVarchar,
                       pnxVarchar.Name as Name4_Varchar,
	                   pVarchar.V_varchar_max as V_Varchar,
                       pnxNchar.Name as Name4_Nchar,
	                   pNchar.V_varchar_max as V_Nchar,
                       pnxVarbinary.Name as Name4_Varbinary,
	                   pVarbinary.V_varbinary_max as V_Varbinary

                from SQLCommand sqlc
                left
                join P_Bigint pBigint on sqlc.ID = pBigint.SQLCommand_ID
                left
                join ParameterName pnxBigint on pnxBigint.ID = pBigint.ParameterName_ID
                left
                join P_smallint psmallint on sqlc.ID = psmallint.SQLCommand_ID
                left
                join ParameterName pnxsmallint on pnxsmallint.ID = psmallint.ParameterName_ID
                left
                join P_Bit pBit on sqlc.ID = pBit.SQLCommand_ID
                left
                join ParameterName pnxBit on pnxBit.ID = pBit.ParameterName_ID
                left
                join P_Int pInt on sqlc.ID = pInt.SQLCommand_ID
                left
                join ParameterName pnxInt on pnxInt.ID = pInt.ParameterName_ID
                left
                join P_Decimal pDecimal on sqlc.ID = pDecimal.SQLCommand_ID
                left
                join ParameterName pnxDecimal on pnxDecimal.ID = pDecimal.ParameterName_ID
                left
                join P_Float pFloat on sqlc.ID = pFloat.SQLCommand_ID
                left
                join ParameterName pnxFloat on pnxFloat.ID = pFloat.ParameterName_ID
                left
                join P_NVarchar pNVarchar on sqlc.ID = pNVarchar.SQLCommand_ID
                left
                join ParameterName pnxNVarchar on pnxNVarchar.ID = pNVarchar.ParameterName_ID
                left
                join P_Varchar pVarchar on sqlc.ID = pVarchar.SQLCommand_ID
                left
                join ParameterName pnxVarchar on pnxVarchar.ID = pVarchar.ParameterName_ID
                left
                join P_Nchar pNchar on sqlc.ID = pNchar.SQLCommand_ID
                left
                join ParameterName pnxNchar on pnxNchar.ID = pNchar.ParameterName_ID
                left
                join P_DateTime pDateTime on sqlc.ID = pDateTime.SQLCommand_ID
                left
                join ParameterName pnxDateTime on pnxDateTime.ID = pDateTime.ParameterName_ID
                left
                join P_Varbinary pVarbinary on sqlc.ID = pVarbinary.SQLCommand_ID
                left
                join ParameterName pnxVarbinary on pnxVarbinary.ID = pVarbinary.ParameterName_ID
                where sqlc.ID = " + sqlcommand_ID.ToString();

            if (dt_SQL_Parameters != null)
            {
                dt_SQL_Parameters.Dispose();
                dt_SQL_Parameters = null;
            }
            dt_SQL_Parameters = new DataTable();

            if (myDataBase_TransactionsLog.m_DBTables.Con.ReadDataTable(ref dt_SQL_Parameters, sql, ref err))
            {
                int iParameterNumber = 0;
                if (dt_SQL_Parameters.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_SQL_Parameters.Rows) 
                    {
                        AddParameters(ref iParameterNumber,dr);
                    }
                }
                return iParameterNumber > 0;
            }
            else
            {
                LogFile.Error.Show("ERROR:TransactionLog:Form_TransactionLog:ShowSQL_Parameters: err=" + err + "\r\nsql=" + sql);
                return false;
            }
        }

        private void Clear_All_usrc_SQL_Parameter()
        {
            foreach(Control ctrl in panel1.Controls)
            {
                if (ctrl is usrc_SQL_Parameter)
                {
                    panel1.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }
            panel1.Controls.Clear();
        }

        private void AddParameters(ref int parameter_number, DataRow dr)
        {
            string colname = "Name4_Bigint";
            string_v Name4_Bigint_v = tf.set_string(dr[colname]);
            if (Name4_Bigint_v != null)
            {
                long_v V_Bigint_v = tf.set_long(dr["V_Bigint"]);
                AddParameterControl(ref parameter_number,Name4_Bigint_v.v, getTypeToString(colname), tf.ConvertToString(V_Bigint_v));
            }

            colname = "Name4_smallint";
            string_v Name4_smallint_v = tf.set_string(dr[colname]);
            if (Name4_smallint_v != null)
            {
                short_v V_smallint_v = tf.set_short(dr["V_smallint"]);
                AddParameterControl(ref parameter_number, Name4_smallint_v.v, getTypeToString(colname), tf.ConvertToString(V_smallint_v));
            }

            colname = "Name4_Int";
            string_v Name4_Int_v = tf.set_string(dr[colname]);
            if (Name4_Int_v != null)
            {
                int_v V_Int_v = tf.set_int(dr["V_Int"]);
                AddParameterControl(ref parameter_number, Name4_Int_v.v, getTypeToString(colname), tf.ConvertToString(V_Int_v));
            }

            colname = "Name4_Bit";
            string_v Name4_Bit_v = tf.set_string(dr[colname]);
            if (Name4_Bit_v != null)
            {
                bool_v V_Bit_v = tf.set_bool(dr["V_Bit"]);
                AddParameterControl(ref parameter_number, Name4_Bit_v.v, getTypeToString(colname), tf.ConvertToString(V_Bit_v));
            }

            colname = "Name4_Decimal";
            string_v Name4_Decimal_v = tf.set_string(dr[colname]);
            if (Name4_Decimal_v != null)
            {
                bool_v V_Decimal_v = tf.set_bool(dr["V_Decimal"]);
                AddParameterControl(ref parameter_number, Name4_Decimal_v.v, getTypeToString(colname), tf.ConvertToString(V_Decimal_v));
            }

            colname = "Name4_Float";
            string_v Name4_Float_v = tf.set_string(dr[colname]);
            if (Name4_Float_v != null)
            {
                float_v V_Float_v = tf.set_float(dr["V_Float"]);
                AddParameterControl(ref parameter_number, Name4_Float_v.v, getTypeToString(colname), tf.ConvertToString(V_Float_v));
            }

            colname = "Name4_DateTime";
            string_v Name4_DateTime_v = tf.set_string(dr[colname]);
            if (Name4_DateTime_v != null)
            {
                DateTime_v V_DateTime_v = tf.set_DateTime(dr["V_DateTime"]);
                AddParameterControl(ref parameter_number, Name4_DateTime_v.v, getTypeToString(colname), tf.ConvertToString(V_DateTime_v));
            }

            colname = "Name4_NVarchar";
            string_v Name4_NVarchar_v = tf.set_string(dr[colname]);
            if (Name4_NVarchar_v != null)
            {
                string_v V_NVarchar_v = tf.set_string(dr["V_NVarchar"]);
                AddParameterControl(ref parameter_number, Name4_NVarchar_v.v, getTypeToString(colname), tf.ConvertToString(V_NVarchar_v));
            }

            colname = "Name4_Varchar";
            string_v Name4_Varchar_v = tf.set_string(dr[colname]);
            if (Name4_Varchar_v != null)
            {
                string_v V_Varchar_v = tf.set_string(dr["V_Varchar"]);
                AddParameterControl(ref parameter_number, Name4_Varchar_v.v, getTypeToString(colname), tf.ConvertToString(V_Varchar_v));
            }

            colname = "Name4_Nchar";
            string_v Name4_Nchar_v = tf.set_string(dr[colname]);
            if (Name4_Nchar_v != null)
            {
                string_v V_Nchar_v = tf.set_string(dr["V_Nchar"]);
                AddParameterControl(ref parameter_number, Name4_Nchar_v.v, getTypeToString(colname), tf.ConvertToString(V_Nchar_v));
            }

            colname = "Name4_Varbinary";
            string_v Name4_Varbinary_v = tf.set_string(dr[colname]);
            if (Name4_Nchar_v != null)
            {
                byte_array_v V_Varbinary_v = tf.set_byte_array(dr["V_Varbinary"]);
                AddParameterControl(ref parameter_number, Name4_Varbinary_v.v, getTypeToString(colname), tf.ConvertToString(V_Varbinary_v));
            }
        }

        private void AddParameterControl(ref int parameter_number,string sql_parameter_name, string sql_parameter_type, string sql_parameter_value)
        {
            usrc_SQL_Parameter xusrc_SQL_Parameter = new usrc_SQL_Parameter(parameter_number, sql_parameter_name, sql_parameter_type, sql_parameter_value);
            xusrc_SQL_Parameter.Top = parameter_number * xusrc_SQL_Parameter.Height;
            xusrc_SQL_Parameter.Left = 0;
            this.panel1.Controls.Add(xusrc_SQL_Parameter);
            xusrc_SQL_Parameter.Visible = true;
            parameter_number++;
        }

        private string getTypeToString(string colname)
        {
            if (colname.Length>6)
            {
                return colname.Substring(6);
            }
            else
            {
                return "???";
            }
        }
    }
}
