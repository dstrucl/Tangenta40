
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DBConnectionControl40;
using TransactionLogTableClass;
using CodeTables;
using LanguageControl;
using DBConnectionControl40;
using static TransactionLogTableClass.TransactionLogTableClass;

namespace TransactionLogDataBaseDef
{
    public class Settings_Item
    {
        private string m_Name;

        public string Name
        {
            get { return m_Name; }
        }


        public string TextValue;
        public bool ReadOnly;
        public Settings_Item(string xName, string xTextValue, bool xReadOnly)
        {
            m_Name = xName;
            TextValue = xTextValue;
            ReadOnly = xReadOnly;
        }
    }

    public class Settings
    {
        public Settings_Item Version = null;

        public Settings(string Ver)
        {
            Version = new Settings_Item("Version", Ver, true);
        }

    }
    partial class MyDataBase_TransactionsLog
    {
        public const string VERSION = "1.29";
        public Settings Settings = null;

        /* 1 */
        public SQLTable t_TransactionName = null;

        /* 2 */
        public SQLTable t_TransactionLog = null;

        /* 3 */
        public SQLTable t_CommandText = null;

        /* 4 */
        public SQLTable t_SQLCommand = null;

        /* 5 */
        public SQLTable t_ParameterName = null;

        /* 6 */
        public SQLTable t_P_Int = null;

        /* 7 */
        public SQLTable t_P_Decimal = null;

        /* 8 */
        public SQLTable t_P_Float = null;

        /* 9 */
        public SQLTable t_P_bit = null;

        /* 10 */
        public SQLTable t_P_DateTime = null;

        /* 11 */
        public SQLTable t_P_Nvarchar = null;

        /* 12 */
        public SQLTable t_P_Varchar = null;

        /* 13 */
        public SQLTable t_P_Nchar = null;

        /* 14 */
        public SQLTable t_P_Bigint = null;

        /* 15 */
        public SQLTable t_P_smallInt = null;

        /* 16 */
        public SQLTable t_P_Varbinary = null;


        public void Define_SQL_Database_Tables() // constructor;
        {
            Settings = new Settings(VERSION);
            m_DBTables.items.Clear();
            TableNames.list.Clear();

            /* 1 */
            t_TransactionName = new SQLTable((Object)new TransactionName(), "trnname", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_TransactionName);
            t_TransactionName.AddColumn((Object)mt.m_TransactionName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_TransactionName.AddColumn((Object)mt.m_TransactionName.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Name", "Ime"));
            m_DBTables.items.Add(t_TransactionName);

            /* 2 */
            t_TransactionLog = new SQLTable((Object)new TransactionLog(), "trn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_TransactionLog);
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.m_TransactionName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox_ReadOnly, new ltext("Name ID", "Ime ID"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.Number, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.NumericUpDown, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.CreationTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.ActivationTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.CommitTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.RollBackTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            m_DBTables.items.Add(t_TransactionLog);

            /* 3 */
            t_CommandText = new SQLTable((Object)new CommandText(), "cmdtext", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_CommandText);
            t_CommandText.AddColumn((Object)mt.m_CommandText.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_CommandText.AddColumn((Object)mt.m_CommandText.SQLText, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("SQL text", "SQL stavek"));
            m_DBTables.items.Add(t_CommandText);

            /* 4 */
            t_SQLCommand = new SQLTable((Object)new SQLCommand(), "sqlcmd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_SQLCommand);
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.m_TransactionLog, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("TransactionLog ID", "TransactionLog ID"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.m_CommandText, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL ID", "SQL ID"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.ExecutionStart, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Execution start", "Začetek"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.ExecutionEnd, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Execution end", "Konec"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.Error, Column.nullTYPE.NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Error", "Napaka"));
            m_DBTables.items.Add(t_SQLCommand);

            /* 5 */
            t_ParameterName = new SQLTable((Object)new ParameterName(), "pn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_ParameterName);
            t_ParameterName.AddColumn((Object)mt.m_ParameterName.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_ParameterName.AddColumn((Object)mt.m_ParameterName.Name, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("Name", "Ime"));
            m_DBTables.items.Add(t_ParameterName);

            /* 6 */
            t_P_Int = new SQLTable((Object)new P_Int(), "P_Int", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Int);
            t_P_Int.AddColumn((Object)mt.m_P_Int.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Int.AddColumn((Object)mt.m_P_Int.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Int.AddColumn((Object)mt.m_P_Int.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime pramatra ID"));
            t_P_Int.AddColumn((Object)mt.m_P_Int.V_Int, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_Int);

            /* 7 */
            t_P_Decimal = new SQLTable((Object)new P_Decimal(), "P_Decimal", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Decimal);
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.V_Decimal, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_Decimal);

            /* 8 */
            t_P_Float = new SQLTable((Object)new P_Float(), "P_Float", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Float);
            t_P_Float.AddColumn((Object)mt.m_P_Float.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Float.AddColumn((Object)mt.m_P_Float.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Float.AddColumn((Object)mt.m_P_Float.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_Float.AddColumn((Object)mt.m_P_Float.V_Float, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_Float);

            /* 9 */
            t_P_bit = new SQLTable((Object)new P_bit(), "P_bit", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_bit);
            t_P_bit.AddColumn((Object)mt.m_P_bit.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_bit.AddColumn((Object)mt.m_P_bit.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_bit.AddColumn((Object)mt.m_P_bit.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_bit.AddColumn((Object)mt.m_P_bit.V_bit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_bit);

            /* 10 */
            t_P_DateTime = new SQLTable((Object)new P_DateTime(), "P_DateTime", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_DateTime);
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.V_DateTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_DateTime);

            /* 11 */
            t_P_Nvarchar = new SQLTable((Object)new P_Nvarchar(), "P_Nvarchar", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Nvarchar);
            t_P_Nvarchar.AddColumn((Object)mt.m_P_Nvarchar.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Nvarchar.AddColumn((Object)mt.m_P_Nvarchar.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Nvarchar.AddColumn((Object)mt.m_P_Nvarchar.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_Nvarchar.AddColumn((Object)mt.m_P_Nvarchar.V_varchar_max, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_Nvarchar);

            /* 12 */
            t_P_Varchar = new SQLTable((Object)new P_Varchar(), "P_Varchar", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Varchar);
            t_P_Varchar.AddColumn((Object)mt.m_P_Varchar.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Varchar.AddColumn((Object)mt.m_P_Varchar.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Varchar.AddColumn((Object)mt.m_P_Varchar.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_Varchar.AddColumn((Object)mt.m_P_Varchar.V_varchar_max, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_Varchar);

            /* 13 */
            t_P_Nchar = new SQLTable((Object)new P_Nchar(), "P_Nchar", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Nchar);
            t_P_Nchar.AddColumn((Object)mt.m_P_Nchar.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Nchar.AddColumn((Object)mt.m_P_Nchar.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Nchar.AddColumn((Object)mt.m_P_Nchar.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_Nchar.AddColumn((Object)mt.m_P_Nchar.V_varchar_max, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_Nchar);


            /* 14 */
            t_P_Bigint = new SQLTable((Object)new P_Bigint(), "P_Bigint", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Bigint);
            t_P_Bigint.AddColumn((Object)mt.m_P_smallInt.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Bigint.AddColumn((Object)mt.m_P_smallInt.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Bigint.AddColumn((Object)mt.m_P_smallInt.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_Bigint.AddColumn((Object)mt.m_P_smallInt.V_smallInt, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_smallInt);


            /* 15 */
            t_P_smallInt = new SQLTable((Object)new P_smallInt(), "P_smallInt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_smallInt);
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.V_smallInt, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_smallInt);

            /* 16 */
            t_P_Varbinary = new SQLTable((Object)new P_Varbinary(), "P_Varbinary", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Varbinary);
            t_P_Varbinary.AddColumn((Object)mt.m_P_Varbinary.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Varbinary.AddColumn((Object)mt.m_P_Varbinary.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Varbinary.AddColumn((Object)mt.m_P_Varbinary.m_ParameterName, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Parameter Name ID", "Ime parametra ID"));
            t_P_Varbinary.AddColumn((Object)mt.m_P_Varbinary.V_varbinary_max, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Value", "Vrednost"));
            m_DBTables.items.Add(t_P_Varbinary);

        }
    }
}
