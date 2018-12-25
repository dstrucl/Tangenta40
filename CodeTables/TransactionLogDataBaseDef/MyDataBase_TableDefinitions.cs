
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
        public SQLTable t_TransactionLog = null;

        /* 2 */
        public SQLTable t_SQLCommand = null;

        /* 3 */
        public SQLTable t_P_Int32 = null;

        /* 4 */
        public SQLTable t_P_Int64 = null;

        /* 5 */
        public SQLTable t_P_Money = null;

        /* 6 */
        public SQLTable t_P_Decimal = null;

        /* 7 */
        public SQLTable t_P_Percent = null;

        /* 8 */
        public SQLTable t_P_smallInt = null;

        /* 9 */
        public SQLTable t_P_bit = null;

        /* 10 */
        public SQLTable t_P_DateTime = null;

        /* 11 */
        public SQLTable t_P_varbinary_max = null;

        /* 12 */
        public SQLTable t_P_varchar_264 = null;

        /* 13 */
        public SQLTable t_P_varchar_250 = null;

        /* 14 */
        public SQLTable t_P_varchar_64 = null;

        /* 15 */
        public SQLTable t_P_varchar_50 = null;

        /* 16 */
        public SQLTable t_P_varchar_45 = null;

        /* 17 */
        public SQLTable t_P_varchar_32 = null;

        /* 18 */
        public SQLTable t_P_varchar_25 = null;

        /* 19 */
        public SQLTable t_P_varchar_10 = null;

        /* 20 */
        public SQLTable t_P_varchar_5 = null;

        /* 21 */
        public SQLTable t_P_varchar_2000 = null;

        /* 22 */
        public SQLTable t_P_varchar_max = null;

        /* 23 */
        public SQLTable t_P_Document = null;

        /* 24 */
        public SQLTable t_P_Image = null;

        public void Define_SQL_Database_Tables() // constructor;
        {
            Settings = new Settings(VERSION);
            m_DBTables.items.Clear();
            TableNames.list.Clear();


            /* 1 */
            t_TransactionLog = new SQLTable((Object)new TransactionLog(), "trn", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_TransactionLog);
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.TextBox_ReadOnly, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.Number, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.NumericUpDown, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.CreationTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.ActivationTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.CommitTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            t_TransactionLog.AddColumn((Object)mt.m_TransactionLog.RollBackTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.DateTimePicker, new ltext("Name", "Ime"));
            m_DBTables.items.Add(t_TransactionLog);

            /* 2 */
            t_SQLCommand = new SQLTable((Object)new SQLCommand(), "sqlcmd", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_SQLCommand);
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.m_TransactionLog, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("TransactionLog ID", "TransactionLog ID"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.CommandText, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL", "SQL"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.ExecutionStart, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Execution start", "Začetek"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.ExecutionEnd, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Execution end", "Konec"));
            t_SQLCommand.AddColumn((Object)mt.m_SQLCommand.Error, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("Error", "Napaka"));
            m_DBTables.items.Add(t_SQLCommand);

            /* 3 */
            t_P_Int32 = new SQLTable((Object)new P_Int32(), "P_Int32", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Int32);
            t_P_Int32.AddColumn((Object)mt.m_P_Int32.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Int32.AddColumn((Object)mt.m_P_Int32.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Int32.AddColumn((Object)mt.m_P_Int32.V_Int32, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_Int32.AddColumn((Object)mt.m_P_Int32.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_Int32);

            /* 4 */
            t_P_Int64 = new SQLTable((Object)new P_Int64(), "P_Int64", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Int64);
            t_P_Int64.AddColumn((Object)mt.m_P_Int64.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Int64.AddColumn((Object)mt.m_P_Int64.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Int64.AddColumn((Object)mt.m_P_Int64.V_Int64, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_Int64.AddColumn((Object)mt.m_P_Int64.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_Int64);

            /* 5 */
            t_P_Money = new SQLTable((Object)new P_Money(), "P_Money", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Money);
            t_P_Money.AddColumn((Object)mt.m_P_Money.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Money.AddColumn((Object)mt.m_P_Money.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Money.AddColumn((Object)mt.m_P_Money.V_Money, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_Money.AddColumn((Object)mt.m_P_Money.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_Money);

            /* 6 */
            t_P_Decimal = new SQLTable((Object)new P_Decimal(), "P_Decimal", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Decimal);
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.V_Decimal, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_Decimal.AddColumn((Object)mt.m_P_Decimal.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_Decimal);

            /* 7 */
            t_P_Percent = new SQLTable((Object)new P_Percent(), "P_Percent", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Percent);
            t_P_Percent.AddColumn((Object)mt.m_P_Percent.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Percent.AddColumn((Object)mt.m_P_Percent.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Percent.AddColumn((Object)mt.m_P_Percent.V_Percent, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_Percent.AddColumn((Object)mt.m_P_Percent.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_Percent);


            /* 8 */
            t_P_smallInt = new SQLTable((Object)new P_smallInt(), "P_smallInt", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_smallInt);
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.V_smallInt, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_smallInt.AddColumn((Object)mt.m_P_smallInt.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_smallInt);

            /* 9 */
            t_P_bit = new SQLTable((Object)new P_bit(), "P_bit", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_bit);
            t_P_bit.AddColumn((Object)mt.m_P_bit.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_bit.AddColumn((Object)mt.m_P_bit.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_bit.AddColumn((Object)mt.m_P_bit.V_bit, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_bit.AddColumn((Object)mt.m_P_bit.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_bit);

            /* 10 */
            t_P_DateTime = new SQLTable((Object)new P_DateTime(), "P_DateTime", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_DateTime);
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.V_DateTime, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_DateTime.AddColumn((Object)mt.m_P_DateTime.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_DateTime);

            /* 11 */
            t_P_varbinary_max = new SQLTable((Object)new P_varbinary_max(), "P_varbinary_max", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varbinary_max);
            t_P_varbinary_max.AddColumn((Object)mt.m_P_varbinary_max.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varbinary_max.AddColumn((Object)mt.m_P_varbinary_max.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varbinary_max.AddColumn((Object)mt.m_P_varbinary_max.V_varbinary_max, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varbinary_max.AddColumn((Object)mt.m_P_varbinary_max.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varbinary_max);


            /* 12 */
            t_P_varchar_264 = new SQLTable((Object)new P_varchar_264(), "P_varchar_264", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_264);
            t_P_varchar_264.AddColumn((Object)mt.m_P_varchar_264.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_264.AddColumn((Object)mt.m_P_varchar_264.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_264.AddColumn((Object)mt.m_P_varchar_264.V_varchar_264, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_264.AddColumn((Object)mt.m_P_varchar_264.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_264);

            /* 13 */
            t_P_varchar_250 = new SQLTable((Object)new P_varchar_250(), "P_varchar_250", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_250);
            t_P_varchar_250.AddColumn((Object)mt.m_P_varchar_250.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_250.AddColumn((Object)mt.m_P_varchar_250.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_250.AddColumn((Object)mt.m_P_varchar_250.V_varchar_250, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_250.AddColumn((Object)mt.m_P_varchar_250.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_250);


            /* 14 */
            t_P_varchar_64 = new SQLTable((Object)new P_varchar_64(), "P_varchar_64", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_64);
            t_P_varchar_64.AddColumn((Object)mt.m_P_varchar_64.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_64.AddColumn((Object)mt.m_P_varchar_64.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_64.AddColumn((Object)mt.m_P_varchar_64.V_varchar_64, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_64.AddColumn((Object)mt.m_P_varchar_64.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_64);

            /* 15 */
            t_P_varchar_50 = new SQLTable((Object)new P_varchar_50(), "P_varchar_50", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_50);
            t_P_varchar_50.AddColumn((Object)mt.m_P_varchar_50.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_50.AddColumn((Object)mt.m_P_varchar_50.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_50.AddColumn((Object)mt.m_P_varchar_50.V_varchar_50, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_50.AddColumn((Object)mt.m_P_varchar_50.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_50);

            /* 16 */
            t_P_varchar_45 = new SQLTable((Object)new P_varchar_45(), "P_varchar_45", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_45);
            t_P_varchar_45.AddColumn((Object)mt.m_P_varchar_45.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_45.AddColumn((Object)mt.m_P_varchar_45.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_45.AddColumn((Object)mt.m_P_varchar_45.V_varchar_45, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_45.AddColumn((Object)mt.m_P_varchar_45.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_45);

            /* 17 */
            t_P_varchar_32 = new SQLTable((Object)new P_varchar_32(), "P_varchar_32", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_32);
            t_P_varchar_32.AddColumn((Object)mt.m_P_varchar_32.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_32.AddColumn((Object)mt.m_P_varchar_32.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_32.AddColumn((Object)mt.m_P_varchar_32.V_varchar_32, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_32.AddColumn((Object)mt.m_P_varchar_32.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_32);

            /* 18 */
            t_P_varchar_25 = new SQLTable((Object)new P_varchar_25(), "P_varchar_25", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_25);
            t_P_varchar_25.AddColumn((Object)mt.m_P_varchar_25.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_25.AddColumn((Object)mt.m_P_varchar_25.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_25.AddColumn((Object)mt.m_P_varchar_25.V_varchar_25, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_25.AddColumn((Object)mt.m_P_varchar_25.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_25);

            /* 19 */
            t_P_varchar_10 = new SQLTable((Object)new P_varchar_10(), "P_varchar_10", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_10);
            t_P_varchar_10.AddColumn((Object)mt.m_P_varchar_10.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_10.AddColumn((Object)mt.m_P_varchar_10.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_10.AddColumn((Object)mt.m_P_varchar_10.V_varchar_10, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_10.AddColumn((Object)mt.m_P_varchar_10.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_10);

            /* 20 */
            t_P_varchar_5 = new SQLTable((Object)new P_varchar_5(), "P_varchar_5", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_5);
            t_P_varchar_5.AddColumn((Object)mt.m_P_varchar_5.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_5.AddColumn((Object)mt.m_P_varchar_5.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_5.AddColumn((Object)mt.m_P_varchar_5.V_varchar_5, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_5.AddColumn((Object)mt.m_P_varchar_5.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_5);

            /* 21 */
            t_P_varchar_2000 = new SQLTable((Object)new P_varchar_2000(), "P_varchar_2000", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_2000);
            t_P_varchar_2000.AddColumn((Object)mt.m_P_varchar_2000.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_2000.AddColumn((Object)mt.m_P_varchar_2000.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_2000.AddColumn((Object)mt.m_P_varchar_2000.V_varchar_2000, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_2000.AddColumn((Object)mt.m_P_varchar_2000.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_2000);

            /* 22 */
            t_P_varchar_max = new SQLTable((Object)new P_varchar_max(), "P_varchar_max", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_varchar_max);
            t_P_varchar_max.AddColumn((Object)mt.m_P_varchar_max.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_varchar_max.AddColumn((Object)mt.m_P_varchar_max.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_varchar_max.AddColumn((Object)mt.m_P_varchar_max.V_varchar_max, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_varchar_max.AddColumn((Object)mt.m_P_varchar_max.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_varchar_max);

            /* 23 */
            t_P_Document = new SQLTable((Object)new P_Document(), "P_Document", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Document);
            t_P_Document.AddColumn((Object)mt.m_P_Document.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Document.AddColumn((Object)mt.m_P_Document.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Document.AddColumn((Object)mt.m_P_Document.V_Document, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_Document.AddColumn((Object)mt.m_P_Document.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_Document);

            /* 24 */
            t_P_Image = new SQLTable((Object)new P_Image(), "P_Image", Column.Flags.FILTER_AND_UNIQUE, lng.lngt_P_Image);
            t_P_Image.AddColumn((Object)mt.m_P_Image.ID, Column.nullTYPE.NOT_NULL, Column.Flags.UNIQUE, Column.eStyle.none, new ltext("ID", "ID"));
            t_P_Image.AddColumn((Object)mt.m_P_Image.m_SQLCommand, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER, Column.eStyle.none, new ltext("SQL command ID", "SQL ukaz ID"));
            t_P_Image.AddColumn((Object)mt.m_P_Image.V_Image, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("Value", "Vrednost"));
            t_P_Image.AddColumn((Object)mt.m_P_Image.Name, Column.nullTYPE.NOT_NULL, Column.Flags.FILTER_AND_UNIQUE, Column.eStyle.none, new ltext("SQLCommand ID", "Name"));
            m_DBTables.items.Add(t_P_Image);
        }
    }
}
