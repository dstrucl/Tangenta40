#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CodeTables;
using TangentaTableClass;
using DBConnectionControl40;
using LanguageControl;
using DBTypes;
using TangentaDB;
using ThreadProcessor;
using System.ComponentModel;
using System.IO;
//using Startup;
using System.Drawing;

namespace UpgradeDB
{
    public class UpgradeDB_inThread
    {
        public const string UPGRADEBACKUP = "UpgradeBackup_";

        public class Upgrade
        {
            public string DBVersion = null;
            public ThreadP_Message.delegate_Procedure procedure;
            public Upgrade(string DBVer, ThreadP_Message.delegate_Procedure proc)
            {
                DBVersion = DBVer;
                procedure = proc;
            }
        }


        internal static Control m_parent_ctrl = null;
        public string m_Full_backup_filename = null;

        public delegate void delegate_Backup();
        public event delegate_Backup Backup;
        public enum eUpgrade { none, from_1_04_to_105 };



        public Upgrade[] UpgradeArray = null;

        public UpgradeDB_inThread(Control xparent_ctrl )
        {
            m_parent_ctrl = xparent_ctrl;
            UpgradeArray = new Upgrade[]
            {
                new Upgrade("1.0",Upgrade_1_00_to_1_01.UpgradeDB_1_00_to_1_01),
                new Upgrade("1.01",Upgrade_1_01_to_1_02.UpgradeDB_1_01_to_1_02),
                new Upgrade("1.02",Upgrade_1_02_to_1_03.UpgradeDB_1_02_to_1_03),
                new Upgrade("1.03",Upgrade_1_03_to_1_04.UpgradeDB_1_03_to_1_04),
                new Upgrade("1.04",Upgrade_1_04_to_1_05.UpgradeDB_1_04_to_1_05),
                new Upgrade("1.05",Upgrade_1_05_to_1_06.UpgradeDB_1_05_to_1_06),
                new Upgrade("1.06",Upgrade_1_06_to_1_07.UpgradeDB_1_06_to_1_07),
                new Upgrade("1.07",Upgrade_1_07_to_1_08.UpgradeDB_1_07_to_1_08),
                new Upgrade("1.08",Upgrade_1_08_to_1_09.UpgradeDB_1_08_to_1_09),
                new Upgrade("1.09",Upgrade_1_09_to_1_10.UpgradeDB_1_09_to_1_10),
                new Upgrade("1.10",Upgrade_1_10_to_1_11.UpgradeDB_1_10_to_1_11),
                new Upgrade("1.11",Upgrade_1_11_to_1_12.UpgradeDB_1_11_to_1_12),
                new Upgrade("1.12",Upgrade_1_12_to_1_13.UpgradeDB_1_12_to_1_13),
                new Upgrade("1.13",Upgrade_1_13_to_1_14.UpgradeDB_1_13_to_1_14),
                new Upgrade("1.14",Upgrade_1_14_to_1_15.UpgradeDB_1_14_to_1_15),
                new Upgrade("1.15",Upgrade_1_15_to_1_16.UpgradeDB_1_15_to_1_16),
                new Upgrade("1.16",Upgrade_1_16_to_1_17.UpgradeDB_1_16_to_1_17),
                new Upgrade("1.17",Upgrade_1_17_to_1_18.UpgradeDB_1_17_to_1_18),
                new Upgrade("1.18",Upgrade_1_18_to_1_19.UpgradeDB_1_18_to_1_19),
                new Upgrade("1.19",Upgrade_1_19_to_1_20.UpgradeDB_1_19_to_1_20),
                new Upgrade("1.20",Upgrade_1_20_to_1_21.UpgradeDB_1_20_to_1_21),
                new Upgrade("1.21",Upgrade_1_21_to_1_22.UpgradeDB_1_21_to_1_22),
                new Upgrade("1.22",Upgrade_1_22_to_1_23.UpgradeDB_1_22_to_1_23),
                new Upgrade("1.23",Upgrade_1_23_to_1_24.UpgradeDB_1_23_to_1_24),
                new Upgrade("1.24",Upgrade_1_24_to_1_25.UpgradeDB_1_24_to_1_25),
                new Upgrade("1.25",Upgrade_1_25_to_1_26.UpgradeDB_1_25_to_1_26),
                new Upgrade("1.26",Upgrade_1_26_to_1_27.UpgradeDB_1_26_to_1_27),
                new Upgrade("1.27",Upgrade_1_27_to_1_28.UpgradeDB_1_27_to_1_28),
                new Upgrade("1.28",Upgrade_1_28_to_1_29.UpgradeDB_1_28_to_1_29)
            };
        }

        public bool UpgradeDB(string sOldDBVersion, string sNewDBVersion, ref string Err)
        {
            int i = 0;
            int iCount = UpgradeArray.Length;
            if (m_Full_backup_filename==null)
            {
                m_Full_backup_filename = Get_m_Full_backup_filename();
            }
            for (i = 0; i < iCount; i++)
            {
                if (UpgradeArray[i].DBVersion.Equals(sOldDBVersion))
                {
                    int j = i;
                    Form_Upgrade_inThread frm_upgr = new Form_Upgrade_inThread(this, UpgradeArray, j, this.m_Full_backup_filename);
                    frm_upgr.Owner = Global.f.GetParentForm(m_parent_ctrl);
                    frm_upgr.ShowDialog(frm_upgr.Owner);
                }
            }
            CheckDataBaseTables(ref Err);
            return true;
        }

        private string Get_m_Full_backup_filename()
        {
            string sdbfilepath = DBSync.DBSync.Con.DataBaseFilePath;
            string sdbfilename = DBSync.DBSync.Con.DataBaseFile;
            return sdbfilepath+UPGRADEBACKUP+ sdbfilename;

        }

        private bool CheckDataBaseTables(ref string Err)
        {
            string sql = "SELECT name FROM sqlite_master WHERE type='table';";
            List<string> missing_table_list = new List<string>();
            DataTable dt = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt,sql, ref Err))
            {
                string exsist_in_m_DBTables_items = "exsist_in_m_DBTables_items";
                dt.Columns.Add(new DataColumn(exsist_in_m_DBTables_items, typeof(bool)));
                foreach (DataRow dr in dt.Rows)
                {
                    dr[exsist_in_m_DBTables_items] = false;
                }
                int iCount_items = DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items.Count;
                int i;
                for (i=0;i< iCount_items; i++)
                {
                    string table_name = DBSync.DBSync.DB_for_Tangenta.m_DBTables.DBT.items[i].TableName;
                    DataRow[] drs =  dt.Select("name = '" + table_name + "'");
                    if (drs.Count() > 0)
                    {
                        foreach (DataRow dr in drs)
                        {
                            dr[exsist_in_m_DBTables_items] = true;
                        }
                        continue;
                    }
                    else
                    {
                        missing_table_list.Add(table_name);
                    }
                }
                Err = null;
                DataRow[] drs2 = dt.Select(exsist_in_m_DBTables_items + "= false");
                if (drs2.Count()>0)
                {
                    string slist = "";
                    foreach (DataRow dr in drs2)
                    {
                        if (((string)dr["name"]).Equals("sqlite_sequence"))
                        {
                            continue;
                        }
                        else
                        {
                            slist += "\r\n'" + (string)dr["name"] + "',";
                        }
                    }
                    if (slist.Length>0)
                    {
                        Err = "ERROR:There are tables in DataBase " + DBSync.DBSync.Con.DataSource + " which are not used in program:" + slist;
                    }
                }
                if (missing_table_list.Count > 0)
                {
                    if (Err == null)
                    {
                        Err = "ERROR:Tables:";
                    }
                    else
                    {
                        Err += "\r\n\r\nERROR:Tables:";
                    }

                    iCount_items = missing_table_list.Count;
                    i = 0;
                    for (;;)
                    {
                        if (i < iCount_items)
                        {
                            Err += "\r\n'" + missing_table_list[i] + "'";
                        }
                        i++;
                        if (i == iCount_items)
                        {
                            break;
                        }
                        else
                        {
                            Err += ",";
                        }
                    }
                    Err += "\r\n are not defined in DataBase '" + DBSync.DBSync.Con.DataSource + "'";
                }
                if (Err == null)
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
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_19_to_1_20:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        internal static bool DeleteTable_And_ResetAutoincrement(string tbl_name, Transaction transaction)
        {
            // now write
            string Err = null;
            string sql = "Delete from " + tbl_name;
            if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
            {
                sql = "UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = '" + tbl_name + "'";
                if (transaction.ExecuteNonQuerySQL(DBSync.DBSync.Con,sql, null, ref Err))
                {
                    return true;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:DeleteTable_And_ResetAutoincrement:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:DeleteTable_And_ResetAutoincrement:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        public static bool Set_DataBase_Version(string Version, Transaction transaction)
        {
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            string spar_TextValue = "@par_TextValue";
            SQL_Parameter par_TextValue = new SQL_Parameter(spar_TextValue, SQL_Parameter.eSQL_Parameter.Nvarchar, false, Version);
            lpar.Add(par_TextValue);
            string sql = null;
            if (DBSync.DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                sql = @"update DBSettings set TextValue = " + spar_TextValue + @" where Name = 'Version';
                                           PRAGMA foreign_keys = ON;";
            }
            else
            {
                sql = @"update DBSettings set TextValue = " + spar_TextValue + @" where Name = 'Version';";
            }
            string Err = null;
            if (transaction.ExecuteNonQuerySQL_NoMultiTrans(DBSync.DBSync.Con,sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_inThread.Set_DataBase_Version:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private void btn_Upgrade_Click(object sender, EventArgs e)
        {
            if (Backup != null)
            {
                Backup();
            }
        }

        public static fs.enum_GetDBSettings Read_DBSettings_Version(ref string xCurrentDataBaseVersionTextValue,
                                                                    ref string xFull_backup_filename,
                                                                    ref string Err)
        {
            bool xReadOnly = false;
            Restore_if_UpgradeBackupFileExists(ref xFull_backup_filename);
            return fs.GetDBSettings(DBSync.DBSync.DB_for_Tangenta.Settings.Version.Name,
                                   ref xCurrentDataBaseVersionTextValue,
                                   ref xReadOnly,
                                   ref Err);
        }

        private static bool Restore_if_UpgradeBackupFileExists(ref string full_backup_filename)
        {

            if (DBSync.DBSync.m_DBType == DBConnection.eDBType.SQLITE)
            {
                string full_backup_folder = DBSync.DBSync.Con.DataBaseFilePath;
                string DB_Name = DBSync.DBSync.Con.DataBaseFile;
                full_backup_filename = null;
                if (full_backup_folder != null)
                {
                    if (full_backup_folder.Length > 0)
                    {
                        if (full_backup_folder[full_backup_folder.Length - 1] != '\\')
                        {
                            full_backup_folder += '\\';
                        }
                        full_backup_filename = full_backup_folder + UPGRADEBACKUP + DB_Name;
                        if (File.Exists(full_backup_filename))
                        {
                            string stext = lng.s_UpgradeBackupFileExist_restore_old_Database.s.Replace("%s", full_backup_filename);
                            if (MessageBox.Show(stext, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                try
                                {
                                    string sOrgDBFile = DBSync.DBSync.Con.SQLiteDataBaseFile;
                                    File.Copy(full_backup_filename, sOrgDBFile, true);
                                    File.Delete(full_backup_filename);
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    LogFile.Error.Show("ERROR:UpgradeDB_inThread:Restore_if_BackupFileExist:Backup file=\"" + full_backup_filename + "\"\r\nException=" + ex.Message);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                LogFile.Error.Show("ERROR:usrc_Upgrade:Form_Upgrade_Load:Backup file=\"" + full_backup_filename + "\" not created!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }  
}
