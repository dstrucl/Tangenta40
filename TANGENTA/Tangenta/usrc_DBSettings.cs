#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLTableControl;
using BlagajnaTableClass;
using InvoiceDB;
using usrc_Upgrade;

namespace Tangenta
{
    public partial class usrc_DBSettings : UserControl
    {
        public delegate void delegate_Backup();
        public event delegate_Backup Backup;

        public delegate void delegate_Settings_Click();
        public event delegate_Settings_Click Settings_Click;


        public enum enum_GetDBSettings
        {
            DBSettings_OK,
            No_Data_Rows,
            No_ReadOnly,
            No_TextValue,
            Error_Load_DBSettings
        };

        public usrc_DBSettings()
        {
            InitializeComponent();
        }


        public enum_GetDBSettings GetDBSettings(string Name, ref string TextValue, ref bool bReadOnly, ref string Err)
        {
            SQLTable tbl_DBSettings = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(DBSettings));
            DataTable dt_DBSettings = new DataTable();
            string colName = "Name";
            string colTextValue = "TextValue";
            string colReadOnly = "ReadOnly";



            string sql_DBSettings = "Select "
                                              + colName + ","
                                              + colTextValue + ","
                                              + colReadOnly + " from DBSettings where Name = '" + Name + "'";

            if (DBSync.DBSync.ReadDataTable(ref dt_DBSettings, sql_DBSettings, ref Err))
            {
                if (dt_DBSettings.Rows.Count > 0)
                {
                    if (dt_DBSettings.Rows[0][colTextValue].GetType() == typeof(string))
                    {
                        TextValue = (string)dt_DBSettings.Rows[0][colTextValue];
                        if (dt_DBSettings.Rows[0][colReadOnly].GetType() == typeof(bool))
                        {
                            bReadOnly = (bool)dt_DBSettings.Rows[0][colReadOnly];
                            return enum_GetDBSettings.DBSettings_OK;
                        }
                        else
                        {
                            return enum_GetDBSettings.No_ReadOnly;
                        }
                    }
                    else
                    {
                        return enum_GetDBSettings.No_TextValue;
                    }
                }
                else
                {
                    return enum_GetDBSettings.No_Data_Rows;
                }
            }
            else
            {
                return enum_GetDBSettings.Error_Load_DBSettings;
            }

        }

        

        internal bool Read_DBSettings(ref bool bUpgradeDone)
        {
            string Err = null;
            if (Read_DBSettings_Version(ref bUpgradeDone,ref Err))
            {
                if (GlobalData.JOURNAL_ProformaInvoice_Type_definitions.Read())
                { 
                    if (Read_DBSettings_LastInvoiceType(bUpgradeDone,ref Err))
                    {
                        if (Read_DBSettings_StockCheckAtStartup(bUpgradeDone, ref Err))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        private bool Init_Default_DB(ref string Err)
        {
            string s_DBSettings_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).TableName;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_DBSettings.Name.GetType()).Name;
            string s_col_TextValue = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_DBSettings.TextValue.GetType()).Name;
            string s_col_ReadOnly = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_DBSettings.ReadOnly.GetType()).Name;

            string sql_DB_Version = "insert into " + s_DBSettings_table_name + " ( " + s_col_Name + "," + s_col_TextValue + "," + s_col_ReadOnly + " ) values ('" + DBSync.DBSync.DB_for_Blagajna.Settings.Version.Name + "','" + DBSync.DBSync.DB_for_Blagajna.Settings.Version.TextValue + "'," + Convert.ToInt32(DBSync.DBSync.DB_for_Blagajna.Settings.Version.ReadOnly).ToString() + ")";
            string sql_DB_LastInvoiceType = "insert into " + s_DBSettings_table_name + " ( " + s_col_Name + "," + s_col_TextValue + "," + s_col_ReadOnly + " ) values ('LastInvoiceType','Invoice',0)";
            string sql_DB_StockCheckAtStartup = "insert into " + s_DBSettings_table_name + " ( " + s_col_Name + "," + s_col_TextValue + "," + s_col_ReadOnly + " ) values ('StockCheckAtStartup','1',0)";
            object Result = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_Version, null, ref Result, ref Err))
            {
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_LastInvoiceType, null, ref Result, ref Err))
                {
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_StockCheckAtStartup, null, ref Result, ref Err))
                    {
                        if (Init_Currency_Table(ref Err))
                        {
                            if (Init_Unit_Table(ref Err))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool Init_Currency_Table(ref string Err)
        {
            string s_Currency_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).TableName;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.Name.GetType()).Name;
            string s_col_Abbreviation = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.Abbreviation.GetType()).Name;
            string s_col_Symbol = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.Symbol.GetType()).Name;
            string s_col_CurrencyCode = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.CurrencyCode.GetType()).Name;
            string s_col_DecimalPlaces = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Currency)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Currency.DecimalPlaces.GetType()).Name;

            xCurrencyList xCurrencyList = new xCurrencyList();

            DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.BatchOpen = true;
            string sql_Currency = "insert into " + s_Currency_table_name + " ( " + s_col_Name + "," + s_col_Abbreviation + "," + s_col_Symbol + "," + s_col_CurrencyCode + "," + s_col_DecimalPlaces + " ) values (";
            foreach (xCurrency currency in xCurrencyList.m_CurrencyList)
            {
                string sValues = "'" + currency.Name + "','" + currency.Abbreviation + "','" + currency.Symbol + "'," + currency.CurrencyCode.ToString() + "," + currency.DecimalPlaces.ToString();
                string sql = sql_Currency + sValues + ")";
                object Result = null;
                if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref Result, ref Err))
                {
                    Err = "ERROR:usrc_Invoice:Init_Currency_Table:Err=" + Err;
                    DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.Disconnect();
                    DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.BatchOpen = false;
                    return false;
                }
            }
            DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.Disconnect();
            DBSync.DBSync.DB_for_Blagajna.m_DBTables.m_con.BatchOpen = false;
            return true;
        }

        private bool Init_Unit_Table(ref string Err)
        {
            string s_Unit_table_name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).TableName;
            string s_col_Name = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.Name.GetType()).Name;
            string s_col_Symbol = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.Symbol.GetType()).Name;
            string s_col_DecimalPlaces = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.DecimalPlaces.GetType()).Name;
            string s_col_StorageOption = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.StorageOption.GetType()).Name;
            string s_col_Description = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.Unit)).FindColumn(DBSync.DBSync.DB_for_Blagajna.mt.m_Unit.Description.GetType()).Name;

            xUnitList xUnitList = new xUnitList();

            string sql_Unit = "insert into " + s_Unit_table_name + " ( " + s_col_Name + "," + s_col_Symbol + "," + s_col_DecimalPlaces + "," + s_col_StorageOption + "," + s_col_Description + " ) values (";
            foreach (xUnit unit in xUnitList.m_DefaltUnitList)
            {
                string sStorageOptionValue = null;
                if (unit.StorageOption)
                {
                    sStorageOptionValue = "1";
                }
                else
                {
                    sStorageOptionValue = "0";
                }
                string sValues = "'" + unit.Name + "','" + unit.Symbol + "'," + unit.DecimalPlaces.ToString() + "," + sStorageOptionValue + ",'" + unit.Description + "'";
                string sql = sql_Unit + sValues + ")";
                object Result = null;
                if (!DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref Result, ref Err))
                {
                    Err = "ERROR:usrc_Invoice:Init_Unit_Table:Err=" + Err;
                    return false;
                }
            }
            return true;
        }

        private bool Init_Sample_DB(ref string Err)
        {
            if (Init_Default_DB(ref Err))
            {
                return SampleDB_Data.InitData(ref Err);
            }
            else
            {
                LogFile.Error.Show(Err);
                return false;
            }
        }

        private bool Read_DBSettings_StockCheckAtStartup(bool bUpgradeDone, ref string Err)
        {
            string xTextValue = null;
            bool xReadOnly = false;
            switch (this.GetDBSettings(DBSync.DBSync.DB_for_Blagajna.Settings.StockCheckAtStartup.Name,
                                   ref xTextValue,
                                   ref xReadOnly,
                                   ref Err))
            {
                case enum_GetDBSettings.DBSettings_OK:
                    if (!xReadOnly)
                    {
                        DBSync.DBSync.DB_for_Blagajna.Settings.StockCheckAtStartup.TextValue = xTextValue;
                    }
                    return true;


                case enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    return false;

                case enum_GetDBSettings.No_Data_Rows:
                    string sql_DB_StockCheckAtStartup = "insert into DBSettings ( name,textvalue,readonly ) values ('StockCheckAtStartup','1',0)";
                    object Result = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql_DB_StockCheckAtStartup, null, ref Result, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_DBSettings:Read_DBSettings_StockCheckAtStartup:sql="+sql_DB_StockCheckAtStartup+"\r\nErr="+Err);
                    }
                    return true;
                //break;

                case enum_GetDBSettings.No_TextValue:
                    return false;

                case enum_GetDBSettings.No_ReadOnly:
                    return false;
                default:
                    Err = "ERROR enum_GetDBSettings not handled!";
                    return false;

            }

        }

        private bool Read_DBSettings_LastInvoiceType(bool bUpgradeDone,ref string Err)
        {
            string xTextValue = null;
            bool xReadOnly = false;
            switch (this.GetDBSettings(DBSync.DBSync.DB_for_Blagajna.Settings.LastInvoiceType.Name,
                                   ref xTextValue,
                                   ref xReadOnly,
                                   ref Err))
            {
                case enum_GetDBSettings.DBSettings_OK:
                    if (!xReadOnly)
                    {
                        DBSync.DBSync.DB_for_Blagajna.Settings.LastInvoiceType.TextValue = xTextValue;
                    }
                    return true;


                case enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    return false;

                case enum_GetDBSettings.No_Data_Rows:
                    if (MessageBox.Show(this, "Podatkovna baza je prazna!\r\nVstavim vzorčne podatke studia Marjetka?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        if (Init_Sample_DB(ref Err))
                        {
                            return false;
                            //$$$
                            //if (Get_BaseCurrency(ref Err))
                            //{
                            //    return true;
                            //}
                            //else
                            //{
                            //    LogFile.Error.Show("ERROR:1:enum_GetDBSettings.No_Data_Rows:Get_BaseCurrency:Err = " + Err);
                            //    return false;
                            //}
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }
                    else
                    {
                        if (bUpgradeDone)
                        {
                            return true;
                        }
                        else
                        { 
                            if (Init_Default_DB(ref Err))
                            {
                                return true;
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_DBSettings:Init_Default_DB:Err="+Err);
                                return false;
                            }
                        }
                    }
                    //break;

                case enum_GetDBSettings.No_TextValue:
                    return false;

                case enum_GetDBSettings.No_ReadOnly:
                    return false;
                default:
                    Err = "ERROR enum_GetDBSettings not handled!";
                    return false;

            }

        }
        internal bool Read_DBSettings_Version(ref bool bUpgradeDone,ref string Err)
        {
            string xTextValue = null;
            bool xReadOnly = false;
            bUpgradeDone = false;
            switch (this.GetDBSettings(DBSync.DBSync.DB_for_Blagajna.Settings.Version.Name,
                                   ref xTextValue,
                                   ref xReadOnly,
                                   ref Err))
            {
                case enum_GetDBSettings.DBSettings_OK:
                    if (xTextValue.Equals(DBSync.DBSync.DB_for_Blagajna.Settings.Version.TextValue))
                    {
                        return true;
                    }
                    else
                    {
                        if (MessageBox.Show(this, "Podatkovna baza je verzije:" + xTextValue + "\r\nTa program dela lahko dela le z verzijo podatkovne baze:" + DBSync.DBSync.DB_for_Blagajna.Settings.Version.TextValue + "\r\nNadgradim podatkovno bazo na novo verzijo?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            bUpgradeDone = m_usrc_Upgrade.UpgradeDB(xTextValue, DBSync.DBSync.DB_for_Blagajna.Settings.Version.TextValue, ref Err);
                            return true;
                        }
                        else
                        {
                            Err = "Podatkovna baza je verzije:" + xTextValue + "\r\nTa program dela lahko dela le z verzijo podatkovne baze:" + DBSync.DBSync.DB_for_Blagajna.Settings.Version.TextValue;
                            return false;
                        }
                    }


                case enum_GetDBSettings.Error_Load_DBSettings:
                    LogFile.Error.Show(Err);
                    return false;

                case enum_GetDBSettings.No_Data_Rows:
                    if (CheckDemo())
                    {
                        if (Init_Sample_DB(ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }
                    else
                    {
                        if (Init_Default_DB(ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show(Err);
                            return false;
                        }
                    }

                case enum_GetDBSettings.No_TextValue:
                    return false;

                case enum_GetDBSettings.No_ReadOnly:
                    return false;
                default:
                    Err = "ERROR enum_GetDBSettings not handled!";
                    return false;

            }

        }

        private bool CheckDemo()
        {
            if (Program.bDemo)
            {
                if (MessageBox.Show(this, "Podatkovna baza je prazna!\r\nVstavim vzorčne podatke studia Marjetka?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void m_usrc_Upgrade_Backup()
        {
            if (Backup!=null)
            {
                Backup();
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            if (Settings_Click!=null)
            {
                Settings_Click();
            }
        }

        private void m_usrc_Upgrade_Load(object sender, EventArgs e)
        {

        }

    }
}
