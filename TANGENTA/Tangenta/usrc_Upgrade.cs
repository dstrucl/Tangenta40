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
using DBConnectionControl40;
using LanguageControl;
using DBTypes;
using InvoiceDB;

namespace Tangenta
{
    public partial class usrc_Upgrade : UserControl
    {
        public delegate void delegate_Backup();
        public event delegate_Backup Backup;
        public enum eUpgrade {none,from_1_04_to_105};
        public Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05 =null;
        internal eUpgrade m_eUpgrade = eUpgrade.none;
        Database_Upgrade_WindowsForm_Thread wfp_ui_thread = null;
        List<TableDataItem> TableDataItem_List = new List<TableDataItem>();
        public usrc_Upgrade()
        {
            InitializeComponent();
        }
        internal bool UpgradeDB(string sOldDBVersion, string sNewDBVersion, ref string Err)
        {
            if (sOldDBVersion.Equals("1.0"))
            {
                if (UpgradeDB_1_0_to_1_01())
                {
                    if (UpgradeDB_1_01_to_1_02())
                    {
                        if (UpgradeDB_1_02_to_1_03())
                        {
                            if (UpgradeDB_1_03_to_1_04())
                            {
                                if (UpgradeDB_1_04_to_1_05())
                                {
                                    if (UpgradeDB_1_05_to_1_06())
                                    {
                                        if (UpgradeDB_1_06_to_1_07())
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                return true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (sOldDBVersion.Equals("1.01"))
                {
                    if (UpgradeDB_1_01_to_1_02())
                    {
                        if (UpgradeDB_1_02_to_1_03())
                        {
                            if (UpgradeDB_1_03_to_1_04())
                            {
                                if (UpgradeDB_1_04_to_1_05())
                                {
                                    if (UpgradeDB_1_05_to_1_06())
                                    {
                                        if (UpgradeDB_1_06_to_1_07())
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (sOldDBVersion.Equals("1.02"))
                    {
                        if (UpgradeDB_1_02_to_1_03())
                        {
                            if (UpgradeDB_1_03_to_1_04())
                            {
                                if (UpgradeDB_1_04_to_1_05())
                                {
                                    if (UpgradeDB_1_05_to_1_06())
                                    {
                                        if (UpgradeDB_1_06_to_1_07())
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (sOldDBVersion.Equals("1.03"))
                        {
                            if (UpgradeDB_1_03_to_1_04())
                            {
                                if (UpgradeDB_1_04_to_1_05())
                                {
                                    if (UpgradeDB_1_05_to_1_06())
                                    {
                                        if (UpgradeDB_1_06_to_1_07())
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (sOldDBVersion.Equals("1.04"))
                            {
                                if (UpgradeDB_1_04_to_1_05())
                                {
                                    if (UpgradeDB_1_05_to_1_06())
                                    {
                                        if (UpgradeDB_1_06_to_1_07())
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (sOldDBVersion.Equals("1.05"))
                                {
                                    if (UpgradeDB_1_05_to_1_06())
                                    {
                                        if (UpgradeDB_1_06_to_1_07())
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (sOldDBVersion.Equals("1.06"))
                                    {
                                        if (UpgradeDB_1_06_to_1_07())
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (sOldDBVersion.Equals("1.07"))
                                        {
                                            if (UpgradeDB_1_07_to_1_08())
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (sOldDBVersion.Equals("1.08"))
                                            {
                                                if (UpgradeDB_1_08_to_1_09())
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (sOldDBVersion.Equals("1.09"))
                                                {
                                                    if (UpgradeDB_1_09_to_1_10())
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (sOldDBVersion.Equals("1.10"))
                                                    {
                                                        if (UpgradeDB_1_10_to_1_11())
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (sOldDBVersion.Equals("1.11"))
                                                        {
                                                            if (UpgradeDB_1_11_to_1_12())
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (sOldDBVersion.Equals("1.12"))
                                                            {
                                                                if (UpgradeDB_1_12_to_1_13())
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (sOldDBVersion.Equals("1.13"))
                                                                {
                                                                    if (UpgradeDB_1_13_to_1_14())
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (sOldDBVersion.Equals("1.14"))
                                                                    {
                                                                        if (UpgradeDB_1_14_to_1_15())
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (sOldDBVersion.Equals("1.15"))
                                                                        {
                                                                            if (UpgradeDB_1_15_to_1_16())
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (sOldDBVersion.Equals("1.16"))
                                                                            {
                                                                                if (UpgradeDB_1_16_to_1_17())
                                                                                {
                                                                                    return true;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                MessageBox.Show("Nadgradnja iz verzije " + sOldDBVersion + " na verzijo " + sNewDBVersion + " ni programsko podprta !");
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool UpgradeDB_1_16_to_1_17()
        {
            string Err = null;
            string sql = null;
            if (DBSync.DBSync.Drop_VIEWs())
            {
                sql = @"
                        PRAGMA foreign_keys = OFF;
                        DROP TABLE cCountry_Person;
                        CREATE TABLE cCountry_Person
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                          'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                          'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                          'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                          )";

                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"INSERT INTO cCountry_Person (Country,
						 Country_ISO_3166_a2,
						Country_ISO_3166_a3,
						Country_ISO_3166_num)
						SELECT 
						State,
						State_ISO_3166_a2,
						State_ISO_3166_a3,
						State_ISO_3166_num
						FROM cState_Person";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {

                        sql = @"
                        PRAGMA foreign_keys = OFF;
                        DROP TABLE cCountry_Org;
                        CREATE TABLE cCountry_Org
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                          'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                          'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                          'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                          )";

                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = @"INSERT INTO cCountry_Org (Country,
						             Country_ISO_3166_a2,
						            Country_ISO_3166_a3,
						            Country_ISO_3166_num)
						            SELECT 
						            State,
						            State_ISO_3166_a2,
						            State_ISO_3166_a3,
						            State_ISO_3166_num
						            FROM cState_Org";
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                sql = @"
                                PRAGMA foreign_keys = OFF;
                                DROP TABLE Atom_cCountry_Person;
                                CREATE TABLE Atom_cCountry_Person
                                  (
                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                  'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                                  'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                                  'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                                  'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                                  )";

                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    sql = @"INSERT INTO Atom_cCountry_Person (Country,
						                             Country_ISO_3166_a2,
						                            Country_ISO_3166_a3,
						                            Country_ISO_3166_num)
						                            SELECT 
						                            State,
						                            State_ISO_3166_a2,
						                            State_ISO_3166_a3,
						                            State_ISO_3166_num
						                            FROM Atom_cState_Person";
                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                    {

                                        sql = @"
                                                    PRAGMA foreign_keys = OFF;
                                                    DROP TABLE Atom_cCountry_Org;
                                                    CREATE TABLE Atom_cCountry_Org
                                                      (
                                                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                                                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                                                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                                                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                                                      )";

                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                        {
                                            sql = @"INSERT INTO Atom_cCountry_Org (Country,
						                                    Country_ISO_3166_a2,
						                                    Country_ISO_3166_a3,
						                                    Country_ISO_3166_num)
						                                    SELECT 
						                                    State,
						                                    State_ISO_3166_a2,
						                                    State_ISO_3166_a3,
						                                    State_ISO_3166_num
						                                    FROM Atom_cState_Org";
                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                            {
                                                sql = @"Update caddress_person set cCountry_Person_ID = cState_Person_ID";
                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                {
                                                    sql = @"Update caddress_person set cState_Person_ID = null";
                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                    {
                                                        sql = @"Update caddress_org set cCountry_Org_ID = cState_Org_ID";
                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                        {
                                                            sql = @"Update caddress_org set cState_Org_ID = null";
                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                            {
                                                                sql = @"Update atom_caddress_person set Atom_cCountry_Person_ID = Atom_cState_Person_ID";
                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                {
                                                                    sql = @"Update atom_caddress_person set Atom_cState_Person_ID = null";
                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                    {
                                                                        sql = @"Update atom_caddress_org set atom_cCountry_Org_ID = atom_cState_Org_ID";
                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                        {
                                                                            sql = @"Update atom_caddress_org set atom_cState_Org_ID = null";
                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                            {
                                                                                sql = @"Update atom_caddress_org set atom_cState_Org_ID = null";
                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                {
                                                                                    sql = @"DROP TABLE cState_Person;
                                                                                            CREATE TABLE cState_Person
                                                                                              (
                                                                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                              'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                              )";
                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                    {
                                                                                        sql = @"DROP TABLE cState_Org;
                                                                                                CREATE TABLE cState_Org
                                                                                                  (
                                                                                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                  'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                  )";
                                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                        {

                                                                                            sql = @"DROP TABLE Atom_cState_Person;
                                                                                            CREATE TABLE Atom_cState_Person
                                                                                              (
                                                                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                              'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                              )";
                                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                            {
                                                                                                sql = @"DROP TABLE Atom_cState_Org;
                                                                                                CREATE TABLE Atom_cState_Org
                                                                                                  (
                                                                                                  'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                                                                  'State' varchar(264) UNIQUE  NOT NULL UNIQUE
                                                                                                  )";
                                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                {
                                                                                                    sql = @"PRAGMA foreign_keys = ON;";
                                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                    {


                                                                                                        if (DBSync.DBSync.Create_VIEWs())
                                                                                                        {
                                                                                                            Set_DatBase_Version("1.17");
                                                                                                            return true;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            return false;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                        return false;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                    return false;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                                return false;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                            return false;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                        return false;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                    return false;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                                return false;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                            return false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                        return false;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                        return false;
                                    }
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_16_to_1_17_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool UpgradeDB_1_15_to_1_16()
        {
            string Err = null;
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string sql = null;
                sql = @"
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_ID INTEGER NULL;
                    ALTER TABLE Invoice ADD COLUMN Invoice_Reference_Type varchar(25) NULL;
                    ";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.16");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_15_to_1_16:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }

        private bool UpgradeDB_1_14_to_1_15()
        {
            string Err = null;
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string sql = null;
                sql = @"
                        CREATE TABLE Stock_backup
                        (
                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                        'ImportTime' DATETIME NOT NULL,
                        'dQuantity' DECIMAL(10,5) NOT NULL,
                        'ExpiryDate' DATETIME NULL,
                        PurchasePrice_Item_ID  INTEGER  NOT NULL REFERENCES PurchasePrice_Item(ID),
                        Stock_AddressLevel1_ID  INTEGER  NULL REFERENCES Stock_AddressLevel1(ID),
                        'Description' varchar(2000) NULL
                        )
                ";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"INSERT INTO Stock_backup (ImportTime,
						 dQuantity,
						ExpiryDate,
						PurchasePrice_Item_ID,
						Stock_AddressLevel1_ID,
						Description)
						SELECT 
						ImportTime,
						 dQuantity,
						ExpiryDate,
						PurchasePrice_Item_ID,
						Stock_AddressLevel1_ID,
						Description 
						FROM Stock";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        sql = @"PRAGMA foreign_keys = OFF;
                        DROP TABLE Stock;
                        ALTER TABLE Stock_backup RENAME TO Stock;
                        PRAGMA foreign_keys = ON;";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            string[] new_tables = new string[] { "FVI_SLO_SalesBookInvoice"};
                            if (DBSync.DBSync.CreateTables(new_tables))
                            {
                                if (DBSync.DBSync.Create_VIEWs())
                                {
                                    Set_DatBase_Version("1.15");
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }
        private bool UpgradeDB_1_13_to_1_14()
        {
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string[] new_tables = new string[] {"Atom_ItemShopA", "Atom_ItemShopA_Image",  "Atom_ItemShopA_Price" };
                if (DBSync.DBSync.CreateTables(new_tables))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.14");
                        return true;
                    }
                }
            }
            return false;
        }


        private bool UpgradeDB_1_12_to_1_13()
        {
            string Err = null;
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string sql = null;
                string stbl = "FVI_SLO_Response";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"
                    DROP TABLE " + stbl + @";
                    CREATE TABLE FVI_SLO_Response
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       Invoice_ID  INTEGER  NOT NULL REFERENCES Invoice(ID),
                      'MessageID' varchar(45) NULL,
                      'UniqueInvoiceID' varchar(45) NULL,
                      'BarCodeValue' varchar(64) NULL,
                      'Response_DateTime' DATETIME NULL
                      )
                    ";
                }
                else
                {
                    sql = @"
                    CREATE TABLE FVI_SLO_Response
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                       Invoice_ID  INTEGER  NOT NULL REFERENCES Invoice(ID),
                      'MessageID' varchar(45) NULL,
                      'UniqueInvoiceID' varchar(45) NULL,
                      'BarCodeValue' varchar(64) NULL,
                      'Response_DateTime' DATETIME NULL
                      )
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.13");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

        private bool UpgradeDB_1_11_to_1_12()
        {
            string Err = null;
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string sql = null;
                string stbl = "ProformaInvoice_Notice";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Name' varchar(264) NOT NULL,
                          'NoticeText' TEXT NOT NULL,
                          'Description' varchar(2000) NULL
                      );

                    CREATE TABLE ProformaInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           ProformaInvoice_ID  INTEGER  NOT NULL REFERENCES ProformaInvoice(ID),
                           Notice_ID  INTEGER  NOT NULL REFERENCES Notice(ID),
                           ProformaInvoice_ImageLib_ID  INTEGER  NULL REFERENCES ProformaInvoice_ImageLib(ID)
                      );
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"
                    CREATE TABLE Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Name' varchar(264) NOT NULL,
                          'NoticeText' TEXT NOT NULL,
                          'Description' varchar(2000) NULL
                      );

                    CREATE TABLE ProformaInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           ProformaInvoice_ID  INTEGER  NOT NULL REFERENCES ProformaInvoice(ID),
                           Notice_ID  INTEGER  NOT NULL REFERENCES Notice(ID),
                           ProformaInvoice_ImageLib_ID  INTEGER  NULL REFERENCES ProformaInvoice_ImageLib(ID)
                      );
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.12");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

        private bool UpgradeDB_1_10_to_1_11()
        {
            string Err = null;
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string sql = null;
                string stbl = "ProformaInvoice_Image";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE ProformaInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           ProformaInvoice_ID  INTEGER  NOT NULL REFERENCES ProformaInvoice(ID),
                          'NoticeText' TEXT NULL,
                           ProformaInvoice_ImageLib_ID  INTEGER  NULL REFERENCES ProformaInvoice_ImageLib(ID)
                      );
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"
                    CREATE TABLE ProformaInvoice_Notice
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           ProformaInvoice_ID  INTEGER  NOT NULL REFERENCES ProformaInvoice(ID),
                          'NoticeText' TEXT NULL,
                           ProformaInvoice_ImageLib_ID  INTEGER  NULL REFERENCES ProformaInvoice_ImageLib(ID)
                          
                      );
                    ";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        Set_DatBase_Version("1.11");
                        return true;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }

            }
            return false;
        }

        private bool UpgradeDB_1_09_to_1_10()
        {
            string Err = null;
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string sql = null;
                string stbl = "Atom_myCompany_Person";
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {

                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE " + stbl + @";
                    CREATE TABLE " + stbl + @"
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'UserName' varchar(32) NOT NULL,
                           Atom_Person_ID  INTEGER  NOT NULL REFERENCES Atom_Person(ID),
                           Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                          'Job' varchar(264) NULL,
                          'Description' varchar(2000) NULL
                      );
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,1,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,2,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,3,'Direktor','Direktorica in lastnica podjetja');
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                      CREATE TABLE " + stbl + @"
                      (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'UserName' varchar(32) NOT NULL,
                           Atom_Person_ID  INTEGER  NOT NULL REFERENCES Atom_Person(ID),
                           Atom_Office_ID  INTEGER  NOT NULL REFERENCES Atom_Office(ID),
                          'Job' varchar(264) NULL,
                          'Description' varchar(2000) NULL
                      );
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,1,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,2,'Direktor','Direktorica in lastnica podjetja');
                    Insert into " + stbl + @" (UserName,Atom_Person_ID,Atom_Office_ID,Job,Description)values('marjetkah',1,3,'Direktor','Direktorica in lastnica podjetja');                    
                    PRAGMA foreign_keys = ON;";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    string[] new_tables = new string[] { "FVI_SLO_RealEstateBP", "FVI_SLO_Response", "Atom_FVI_SLO_RealEstateBP" };
                    if (DBSync.DBSync.CreateTables(new_tables))
                    {
                        if (DBSync.DBSync.Create_VIEWs())
                        {
                            Set_DatBase_Version("1.10");
                            return true;
                        }
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            return false;
        }



        private bool UpgradeDB_1_08_to_1_09()
        {
            string Err = null;
            string sql = null;
            string[] stables = new string[] { "Atom_cCountry_Org", "Atom_cCountry_Person", "cCountry_Org", "cCountry_Person" };
            foreach (string stbl in stables)
            {
                if (DBSync.DBSync.TableExists(stbl, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                    DROP TABLE "+ stbl + @";
                    CREATE TABLE "+ stbl + @"
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                      );
                    Insert into "+stbl+@" (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num)values('Slovenija','SI','SVN',705);
                    PRAGMA foreign_keys = ON;";
                }
                else
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                    CREATE TABLE "+ stbl + @"
                      (
                      'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                      'Country' varchar(264) UNIQUE  NOT NULL UNIQUE,
                      'Country_ISO_3166_a2' varchar(5)   NOT NULL UNIQUE,
                      'Country_ISO_3166_a3' varchar(5)  NOT NULL UNIQUE,
                      'Country_ISO_3166_num' smallint NOT NULL UNIQUE
                      );
                    Insert into "+ stbl + @" (Country,Country_ISO_3166_a2,Country_ISO_3166_a3,Country_ISO_3166_num)values('Slovenija','SI','SVN',705);
                    PRAGMA foreign_keys = ON;";
                }
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                   continue;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_08_to_1_09:sql = " + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            Set_DatBase_Version("1.09");
            return true;

        }

        private bool UpgradeDB_1_07_to_1_08()
        {
            if (UpgradeDB_1_07_to_1_08_Change_Table_Person())
            {
                if (UpgradeDB_1_07_to_1_08_Change_Table_Organisation())
                {
                    if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person())
                    {
                        if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation())
                        {
                            if (UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office())
                            {
                                Set_DatBase_Version("1.08");
                                return true;
                            }
                        }
                    }

                }
            }
            return false;
        }


        private bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office()
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Office_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                           Atom_myCompany_ID  INTEGER  NOT NULL REFERENCES Atom_myCompany(ID),
                          'Name' varchar(264) NOT NULL 
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Office_backup SELECT * FROM Atom_Office";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Office;
                            ALTER TABLE Atom_Office_backup RENAME TO Atom_Office;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Office:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }


        private bool UpgradeDB_1_07_to_1_08_Change_Table_Person()
        {
            string Err = null;
            string sql = @"CREATE TABLE Person_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Gender' BIT NOT NULL,
                           cFirstName_ID  INTEGER  NOT NULL REFERENCES cFirstName(ID),
                           cLastName_ID  INTEGER  NULL REFERENCES cLastName(ID),
                          'DateOfBirth' DATETIME NULL,
                          'Tax_ID' varchar(32) NULL,
                          'Registration_ID' varchar(50) NULL
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Person_backup SELECT * FROM Person";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Person;
                            ALTER TABLE Person_backup RENAME TO Person;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person()
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Person_backup
                          (
                          'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                          'Gender' BIT NOT NULL,
                           Atom_cFirstName_ID  INTEGER  NOT NULL REFERENCES Atom_cFirstName(ID),
                           Atom_cLastName_ID  INTEGER  NULL REFERENCES Atom_cLastName(ID),
                          'DateOfBirth' DATETIME NULL,
                          'Tax_ID'  varchar(32) NULL,
                          'Registration_ID' varchar(50) NULL,
                           Atom_cGsmNumber_Person_ID  INTEGER  NULL REFERENCES Atom_cGsmNumber_Person(ID),
                           Atom_cPhoneNumber_Person_ID  INTEGER  NULL REFERENCES Atom_cPhoneNumber_Person(ID),
                           Atom_cEmail_Person_ID  INTEGER  NULL REFERENCES Atom_cEmail_Person(ID),
                           Atom_cAddress_Person_ID  INTEGER  NULL REFERENCES Atom_cAddress_Person(ID),
                          'CardNumber' varchar(50) NULL,
                           Atom_cCardType_Person_ID  INTEGER  NULL REFERENCES Atom_cCardType_Person(ID),
                           Atom_PersonImage_ID  INTEGER  NULL REFERENCES Atom_PersonImage(ID)
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Person_backup SELECT * FROM Atom_Person";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Person;
                            ALTER TABLE Atom_Person_backup RENAME TO Atom_Person;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Person:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Person:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool UpgradeDB_1_07_to_1_08_Change_Table_Organisation()
        {
            string Err = null;
            string sql = @"CREATE TABLE Organisation_backup
                          (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            'Name' varchar(264) NOT NULL,
                            'Tax_ID' varchar(32) NOT NULL,
                            'Registration_ID' varchar(50) NULL
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Organisation_backup SELECT * FROM Organisation";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Organisation;
                            ALTER TABLE Organisation_backup RENAME TO Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Organisation:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }

        private bool UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation()
        {
            string Err = null;
            string sql = @"CREATE TABLE Atom_Organisation_backup
                          (
                            'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                            'Name' varchar(264) NOT NULL,
                            'Tax_ID' varchar(32) NOT NULL,
                            'Registration_ID' varchar(50) NULL
                          )
            ";
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
            {
                sql = @"INSERT INTO Atom_Organisation_backup SELECT * FROM Atom_Organisation";
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                {
                    sql = @"PRAGMA foreign_keys = OFF;
                            DROP TABLE Atom_Organisation;
                            ALTER TABLE Atom_Organisation_backup RENAME TO Atom_Organisation;
                            PRAGMA foreign_keys = ON;";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        return true;
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                        return false;
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_07_to_1_08_Change_Table_Atom_Organisation:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }

        }


        private bool UpgradeDB_1_06_to_1_07()
        {
            if (DBSync.DBSync.Drop_VIEWs())
            {
                string[] new_tables = new string[] { "doc_page_type", "Language", "doc_type", "doc", "JOURNAL_doc_Type", "JOURNAL_doc"};
                if (DBSync.DBSync.CreateTables(new_tables))
                {
                    if (DBSync.DBSync.Create_VIEWs())
                    {
                        if (f_doc.InsertDefault())
                        {
                            Set_DatBase_Version("1.07");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool UpgradeDB_1_05_to_1_06()
        {
            //DBSync.DBSync.DB_for_Blagajna
            if (DBSync.DBSync.Drop_VIEWs())
            {
                if (DBSync.DBSync.Create_VIEWs())
                {
                    Set_DatBase_Version("1.06");
                    return true;
                }
            }
            return false;
        }

        private bool UpgradeDB_1_02_to_1_03()
        {
            // correct taxation
            string Err = null;
            string sql = @"select apsi.ID,RetailSimpleItemPrice,Discount,iQuantity,RetailSimpleItemPriceWithDiscount,ExtraDiscount,Rate from atom_price_simpleitem apsi 
                            inner join atom_taxation at on apsi.atom_taxation_ID = at.ID";
            DataTable dt_atom_price_simpleitem1 = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem1, sql, ref Err))
            {
                if (dt_atom_price_simpleitem1.Rows.Count > 0)
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    foreach (DataRow dr in dt_atom_price_simpleitem1.Rows)
                    {
                        lpar.Clear();
                        long ID = (long)dr["ID"];
                        decimal RetailSimpleItemPrice = (decimal)dr["RetailSimpleItemPrice"];
                        decimal Discount = (decimal)dr["Discount"];
                        int iQuantity = (int)dr["iQuantity"];
                        decimal RetailSimpleItemPriceWithDiscount = (decimal)dr["RetailSimpleItemPriceWithDiscount"];
                        decimal ExtraDiscount = (decimal)dr["ExtraDiscount"];
                        decimal Taxation_Rate = (decimal)dr["Rate"];
                        decimal RetailSimpleItemPriceAll = RetailSimpleItemPrice * iQuantity;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated = RetailSimpleItemPrice * iQuantity;
                        decimal TaxPrice = 0;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax = 0;

                        int decimal_places = 2;
                        if (GlobalData.BaseCurrency != null)
                        {
                            decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                        }
                        //RetailSimpleItemPriceAll has allready price for all quantity so dQunatity = 1
                        StaticLib.Func.CalculatePrice(RetailSimpleItemPriceAll, 1, Discount, ExtraDiscount, Taxation_Rate, ref RetailSimpleItemPriceWithDiscount_Calculated, ref TaxPrice, ref RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax, decimal_places);
                        string spar_TaxPrice = "@par_TaxPrice";
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                        sql = " update atom_price_simpleitem set TaxPrice=" + spar_TaxPrice + " where ID = " + ID.ToString();
                        object ores = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                        {
                            continue;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }

                string Column_PrefixTable = "invoicetable_";
                sql = @" select 
                            pi.ID,
                            Atom_myCompany_Person_ID,
                            Draft,
                            DraftNumber,
                            FinancialYear,
                            NumberInFinancialYear,
                            ProformaInvoiceTime,
                            FirstPrintTime,
                            NetSum,
                            Discount,
                            EndSum,
                            TaxSum,
                            GrossSum,
                            Atom_Customer_Person_ID,
                            Atom_Customer_Org_ID,
                            WarrantyExist,
                            WarrantyConditions,
                            WarrantyDurationType,
                            WarrantyDuration,
                            ProformaInvoiceDuration,
                            ProformaInvoiceDurationType,
                            TermsOfPayment_ID,
                            Invoice_ID,
                            i.PaymentDeadline as " + Column_PrefixTable + @"PaymentDeadline,
                            i.MethodOfPayment_ID as " + Column_PrefixTable + @"MethodOfPayment_ID,
                            i.Paid as " + Column_PrefixTable + @"Paid,
                            i.Storno as " + Column_PrefixTable + @"Storno
                            from ProformaInvoice  pi
                            inner join Invoice i on i.ID = pi.Invoice_ID";
                DataTable dt_ProformaInvoice = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt_ProformaInvoice, sql, ref Err))
                {
                    if (dt_ProformaInvoice.Rows.Count > 0)
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        List<ProformaInvoice_Connection_Class> ProformaInvoice_con_List = new List<ProformaInvoice_Connection_Class>();
                        string sErrors = "";
                        foreach (DataRow dr in dt_ProformaInvoice.Rows)
                        {
                            lpar.Clear();
                            long proformainvoice_ID = (long)dr["ID"];
                            string sql_atom_price_simpleitem = "select * from atom_price_simpleitem where ProformaInvoice_ID = " + proformainvoice_ID.ToString();
                            ProformaInvoice_Connection_Class picc = new ProformaInvoice_Connection_Class();
                            picc.ID = proformainvoice_ID;
                            DataTable dt_atom_price_simpleitem2 = new DataTable();
                            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem2, sql_atom_price_simpleitem, ref Err))
                            {
                                if (dt_atom_price_simpleitem2.Rows.Count > 0)
                                {
                                    decimal TaxSum = 0;
                                    decimal NetSum = 0;
                                    decimal GrossSum = 0;
                                    foreach (DataRow dr_atom_price_simpleitem in dt_atom_price_simpleitem2.Rows)
                                    {
                                        GrossSum += (decimal)dr_atom_price_simpleitem["RetailSimpleItemPriceWithDiscount"];
                                        TaxSum += (decimal)dr_atom_price_simpleitem["TaxPrice"];
                                    }
                                    NetSum = GrossSum - TaxSum;
                                    string sNumber = ((int)dr["FinancialYear"]).ToString() + "/" + ((int)dr["NumberInFinancialYear"]).ToString();
                                    if ((decimal)dr["NetSum"] != NetSum)
                                    {
                                        sErrors += lngRPM.s_WrongNetSum.s + ((decimal)dr["NetSum"]).ToString() + lngRPM.s_ForProformaInvoiceNumber.s + sNumber + lngRPM.s_RealNetSumIs.s + NetSum.ToString() + "\r\n";
                                        dr["NetSum"] = NetSum;
                                    }
                                    if ((decimal)dr["TaxSum"] != TaxSum)
                                    {
                                        sErrors += lngRPM.s_WrongTaxSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForProformaInvoiceNumber.s + sNumber + lngRPM.s_RealTaxSumIs.s + TaxSum.ToString() + "\r\n";
                                        dr["TaxSum"] = TaxSum;
                                    }
                                    if ((decimal)dr["GrossSum"] != GrossSum)
                                    {
                                        sErrors += lngRPM.s_WrongGrossSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForProformaInvoiceNumber.s + sNumber + lngRPM.s_RealGrossSumIs.s + GrossSum.ToString() + "\r\n";
                                        dr["GrossSum"] = GrossSum;
                                    }
                                }
                                picc.dt_atom_price_simpleitem = dt_atom_price_simpleitem2;
                                string sql_journal_proformainvoice = "select * from journal_proformainvoice where ProformaInvoice_ID = " + proformainvoice_ID.ToString();
                                DataTable dt_journal_proformainvoice = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt_journal_proformainvoice, sql_journal_proformainvoice, ref Err))
                                {
                                    picc.dt_journal_proformainvoice = dt_journal_proformainvoice;
                                    ProformaInvoice_con_List.Add(picc);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        if (sErrors.Length > 0)
                        {
                            MessageBox.Show(this, sErrors, "Errors:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        //if (DeleteTable_And_ResetAutoincrement("journal_proformainvoice"))
                        //{
                        //    if (DeleteTable_And_ResetAutoincrement("atom_price_simpleitem"))
                        //    {
                        //        if (DeleteTable_And_ResetAutoincrement("ProformaInvoice"))
                        //        {
                        //            if (DeleteTable_And_ResetAutoincrement("Invoice"))
                        //            {

                        //                foreach (DataRow dr in dt_ProformaInvoice.Rows)
                        //                {
                        //                    long new_Invoice_id = -1;
                        //                    if (fs.WriteRow("Invoice", dr,  Column_PrefixTable, true, ref new_Invoice_id))
                        //                    {
                        //                        dr["Invoice_ID"] = new_Invoice_id;
                        //                        long new_ProformaInvoice_id = -1;
                        //                        if (fs.WriteRow("ProformaInvoice", dr, Column_PrefixTable, false, ref new_ProformaInvoice_id))
                        //                        {
                        //                            ProformaInvoice_Connection_Class xpicc = Get_ProformaInvoice_Connection_Class(ProformaInvoice_con_List,(long)dr["ID"]);
                        //                            if (xpicc !=null)
                        //                            {
                        //                                if (!xpicc.WriteNew(new_ProformaInvoice_id))
                        //                                {
                        //                                    return false;
                        //                                }
                        //                            }
                        //                        }
                        //                    }
                        //                }
                        if (Set_DatBase_Version("1.03"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        //            }
                        //        }
                        //    }
                        //}
                    }
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool UpgradeDB_1_03_to_1_04()
        {
            // correct taxation
            string Err = null;
            string sql = @"select apsi.ID,RetailSimpleItemPrice,Discount,iQuantity,RetailSimpleItemPriceWithDiscount,ExtraDiscount,Rate from atom_price_simpleitem apsi 
                            inner join atom_taxation at on apsi.atom_taxation_ID = at.ID";
            DataTable dt_atom_price_simpleitem1 = new DataTable();
            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem1, sql, ref Err))
            {
                if (dt_atom_price_simpleitem1.Rows.Count > 0)
                {
                    List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                    foreach (DataRow dr in dt_atom_price_simpleitem1.Rows)
                    {
                        lpar.Clear();
                        long ID = (long)dr["ID"];
                        decimal RetailSimpleItemPrice = (decimal)dr["RetailSimpleItemPrice"];
                        decimal Discount = (decimal)dr["Discount"];
                        int iQuantity = (int)dr["iQuantity"];
                        decimal RetailSimpleItemPriceWithDiscount = (decimal)dr["RetailSimpleItemPriceWithDiscount"];
                        decimal ExtraDiscount = (decimal)dr["ExtraDiscount"];
                        decimal Taxation_Rate = (decimal)dr["Rate"];
                        decimal RetailSimpleItemPriceAll = RetailSimpleItemPrice * iQuantity;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated = RetailSimpleItemPrice * iQuantity;
                        decimal TaxPrice = 0;
                        decimal RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax = 0;

                        int decimal_places = 2;
                        if (GlobalData.BaseCurrency != null)
                        {
                            decimal_places = GlobalData.BaseCurrency.DecimalPlaces;
                        }
                        decimal dQuantity = Convert.ToDecimal(iQuantity);
                        StaticLib.Func.CalculatePrice(RetailSimpleItemPriceAll, dQuantity,Discount, ExtraDiscount, Taxation_Rate, ref RetailSimpleItemPriceWithDiscount_Calculated, ref TaxPrice, ref RetailSimpleItemPriceWithDiscount_Calculated_WithoutTax, decimal_places);
                        string spar_TaxPrice = "@par_TaxPrice";
                        SQL_Parameter par_TaxPrice = new SQL_Parameter(spar_TaxPrice, SQL_Parameter.eSQL_Parameter.Decimal, false, TaxPrice);
                        lpar.Add(par_TaxPrice);
                        sql = " update atom_price_simpleitem set TaxPrice=" + spar_TaxPrice + " where ID = " + ID.ToString();
                        object ores = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQL(sql, lpar, ref ores, ref Err))
                        {
                            continue;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }

                string Column_PrefixTable = "invoicetable_";
                sql = @" select 
                            pi.ID,
                            Atom_myCompany_Person_ID,
                            Draft,
                            DraftNumber,
                            FinancialYear,
                            NumberInFinancialYear,
                            ProformaInvoiceTime,
                            FirstPrintTime,
                            NetSum,
                            Discount,
                            EndSum,
                            TaxSum,
                            GrossSum,
                            Atom_Customer_Person_ID,
                            Atom_Customer_Org_ID,
                            WarrantyExist,
                            WarrantyConditions,
                            WarrantyDurationType,
                            WarrantyDuration,
                            ProformaInvoiceDuration,
                            ProformaInvoiceDurationType,
                            TermsOfPayment_ID,
                            Invoice_ID,
                            i.PaymentDeadline as " + Column_PrefixTable + @"PaymentDeadline,
                            i.MethodOfPayment_ID as " + Column_PrefixTable + @"MethodOfPayment_ID,
                            i.Paid as " + Column_PrefixTable + @"Paid,
                            i.Storno as " + Column_PrefixTable + @"Storno
                            from ProformaInvoice  pi
                            inner join Invoice i on i.ID = pi.Invoice_ID";
                DataTable dt_ProformaInvoice = new DataTable();
                if (DBSync.DBSync.ReadDataTable(ref dt_ProformaInvoice, sql, ref Err))
                {
                    if (dt_ProformaInvoice.Rows.Count > 0)
                    {
                        List<SQL_Parameter> lpar = new List<SQL_Parameter>();
                        List<ProformaInvoice_Connection_Class> ProformaInvoice_con_List = new List<ProformaInvoice_Connection_Class>();
                        string sErrors = "";
                        foreach (DataRow dr in dt_ProformaInvoice.Rows)
                        {
                            lpar.Clear();
                            long proformainvoice_ID = (long)dr["ID"];
                            string sql_atom_price_simpleitem = "select * from atom_price_simpleitem where ProformaInvoice_ID = " + proformainvoice_ID.ToString();
                            ProformaInvoice_Connection_Class picc = new ProformaInvoice_Connection_Class();
                            picc.ID = proformainvoice_ID;
                            DataTable dt_atom_price_simpleitem2 = new DataTable();
                            if (DBSync.DBSync.ReadDataTable(ref dt_atom_price_simpleitem2, sql_atom_price_simpleitem, ref Err))
                            {
                                if (dt_atom_price_simpleitem2.Rows.Count > 0)
                                {
                                    decimal TaxSum = 0;
                                    decimal NetSum = 0;
                                    decimal GrossSum = 0;
                                    foreach (DataRow dr_atom_price_simpleitem in dt_atom_price_simpleitem2.Rows)
                                    {
                                        GrossSum += (decimal)dr_atom_price_simpleitem["RetailSimpleItemPriceWithDiscount"];
                                        TaxSum += (decimal)dr_atom_price_simpleitem["TaxPrice"];
                                    }
                                    NetSum = GrossSum - TaxSum;
                                    string sNumber = ((int)dr["FinancialYear"]).ToString() + "/" + ((int)dr["NumberInFinancialYear"]).ToString();
                                    if ((decimal)dr["NetSum"] != NetSum)
                                    {
                                        sErrors += lngRPM.s_WrongNetSum.s + ((decimal)dr["NetSum"]).ToString() + lngRPM.s_ForProformaInvoiceNumber.s + sNumber + lngRPM.s_RealNetSumIs.s + NetSum.ToString() + "\r\n";
                                        dr["NetSum"] = NetSum;
                                    }
                                    if ((decimal)dr["TaxSum"] != TaxSum)
                                    {
                                        sErrors += lngRPM.s_WrongTaxSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForProformaInvoiceNumber.s + sNumber + lngRPM.s_RealTaxSumIs.s + TaxSum.ToString() + "\r\n";
                                        dr["TaxSum"] = TaxSum;
                                    }
                                    if ((decimal)dr["GrossSum"] != GrossSum)
                                    {
                                        sErrors += lngRPM.s_WrongGrossSum.s + ((decimal)dr["TaxSum"]).ToString() + lngRPM.s_ForProformaInvoiceNumber.s + sNumber + lngRPM.s_RealGrossSumIs.s + GrossSum.ToString() + "\r\n";
                                        dr["GrossSum"] = GrossSum;
                                    }
                                }
                                picc.dt_atom_price_simpleitem = dt_atom_price_simpleitem2;
                                string sql_journal_proformainvoice = "select * from journal_proformainvoice where ProformaInvoice_ID = " + proformainvoice_ID.ToString();
                                DataTable dt_journal_proformainvoice = new DataTable();
                                if (DBSync.DBSync.ReadDataTable(ref dt_journal_proformainvoice, sql_journal_proformainvoice, ref Err))
                                {
                                    picc.dt_journal_proformainvoice = dt_journal_proformainvoice;
                                    ProformaInvoice_con_List.Add(picc);
                                }
                                else
                                {
                                    LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                    return false;
                                }
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Update:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        if (sErrors.Length > 0)
                        {
                            MessageBox.Show(this, sErrors, "Errors:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }


                        if (DeleteTable_And_ResetAutoincrement("journal_proformainvoice"))
                        {
                            if (DeleteTable_And_ResetAutoincrement("atom_price_simpleitem"))
                            {
                                if (DeleteTable_And_ResetAutoincrement("ProformaInvoice"))
                                {
                                    if (DeleteTable_And_ResetAutoincrement("Invoice"))
                                    {

                                        foreach (DataRow dr in dt_ProformaInvoice.Rows)
                                        {
                                            long new_Invoice_id = -1;
                                            if (fs.WriteRow("Invoice", dr, Column_PrefixTable, true, ref new_Invoice_id))
                                            {
                                                dr["Invoice_ID"] = new_Invoice_id;
                                                long new_ProformaInvoice_id = -1;
                                                if (fs.WriteRow("ProformaInvoice", dr, Column_PrefixTable, false, ref new_ProformaInvoice_id))
                                                {
                                                    ProformaInvoice_Connection_Class xpicc = Get_ProformaInvoice_Connection_Class(ProformaInvoice_con_List, (long)dr["ID"]);
                                                    if (xpicc != null)
                                                    {
                                                        if (!xpicc.WriteNew(new_ProformaInvoice_id))
                                                        {
                                                            return false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (Set_DatBase_Version("1.04"))
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
                        }
                    }
                    return false;
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_02_to_1_03:sql=" + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private ProformaInvoice_Connection_Class Get_ProformaInvoice_Connection_Class(List<ProformaInvoice_Connection_Class> ProformaInvoice_con_List, long ProformaInvoice_ID)
        {
            foreach (ProformaInvoice_Connection_Class picc in ProformaInvoice_con_List)
            {
                if (picc.ID == ProformaInvoice_ID)
                {
                    return picc;
                }
            }
            return null;
        }



        public bool DeleteTable_And_ResetAutoincrement(string tbl_name)
        {
            // now write
            string Err = null;
            object ores = null;
            string sql = "Delete from " + tbl_name;
            if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
            {
                sql = "UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = '" + tbl_name + "'";
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
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

        private bool UpgradeDB_1_04_to_1_05()
        {
            Check_DB_1_04();
            m_Old_tables_1_04_to_1_05 = new Old_tables_1_04_to_1_05();
            if (m_Old_tables_1_04_to_1_05.Read())
            {
                m_eUpgrade = eUpgrade.from_1_04_to_105;
                wfp_ui_thread = new Database_Upgrade_WindowsForm_Thread();
                wfp_ui_thread.Start();


                List<DataTable> dt_List = new List<DataTable>();
                string Err = null;
                string Message_Title = " 1.04 -> 1.05";

                SQLTable tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(PersonData));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                SQLTable xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_PersonData = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }

                TableDataItem_List.Add(dt_PersonData);


                Err = null;
                Message_Title = " 1.04 -> 1.05";
                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_myCompany = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_myCompany);

                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_myCompany));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_Atom_myCompany = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Atom_myCompany);

                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_Item));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_Price_Item = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Price_Item);

                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_SimpleItem));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_Price_SimpleItem = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Price_SimpleItem);

                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(OrganisationAccount));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_OrganisationAccount = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_OrganisationAccount);


                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Price_SimpleItem));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_Atom_Price_SimpleItem = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Atom_Price_SimpleItem);


                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_ProformaInvoice_Price_Item_Stock));
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_Atom_ProformaInvoice_Price_Item_Stock = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {
                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_Atom_ProformaInvoice_Price_Item_Stock);


                Err = null;
                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.DBSettings));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_DBSettings = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_DBSettings);

                Err = null;
                tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(BlagajnaTableClass.BaseCurrency));
                wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + Message_Title);
                wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
                xtbl = new SQLTable(tbl);
                xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
                TableDataItem dt_BaseCurrency = new TableDataItem(xtbl, ref dt_List, null, ref Err);
                if (Err != null)
                {

                    wfp_ui_thread.End();
                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                    return false;
                }
                TableDataItem_List.Add(dt_BaseCurrency);


                wfp_ui_thread.Message(lngRPM.s_BackupOfExistingDatabase.s + DBSync.DBSync.DataBase + " -> " + DBSync.DBSync.DataBase_BackupTemp);

                if (DBSync.DBSync.DB_for_Blagajna.DataBase_Make_BackupTemp())
                {
                    if (DBSync.DBSync.DB_for_Blagajna.DataBase_Delete())
                    {
                        if (DBSync.DBSync.DB_for_Blagajna.DataBase_Create())
                        {
                            wfp_ui_thread.Message(lngRPM.s_ImportData.s);
                            if (Write_TableDataItem_List(m_eUpgrade, m_Old_tables_1_04_to_1_05))
                            {
                                // Correct Item's Units
                                Set_DatBase_Version("1.05");
                                string sql = "update item set Unit_ID=1";
                                object ores = null;
                                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                                {
                                    wfp_ui_thread.End();
                                    return true;
                                }
                                else
                                {
                                    wfp_ui_thread.End();
                                    LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_04_to_1_05:TableName=" + tbl.TableName + ";Err=" + Err);
                                    return false;
                                }

                            }
                        }
                    }
                }
                wfp_ui_thread.End();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Check_DB_1_04()
        {
            string Err  = null;
            string sql = "select ID,FinancialYear,NumberInFinancialYear,NetSum,TaxSum,GrossSum from ProformaInvoice where Draft=0";
            DataTable dt_ProformaInvoice = new DataTable();
            DataTable dt_Atom_Price_SimpleItem = new DataTable();
            DataTable dt_Atom_ProformaInvoice_Price_Item_Stock = new DataTable();
            DataTable dt_Atom_Price_Item = new DataTable();
            string sErrMsg = "";
            if (DBSync.DBSync.ReadDataTable(ref dt_ProformaInvoice, sql, ref Err))
            {
                sql = "select ID,RetailSimpleItemPrice,iQuantity,TaxPrice,ProformaInvoice_ID from Atom_Price_SimpleItem";
                if (DBSync.DBSync.ReadDataTable(ref dt_Atom_Price_SimpleItem, sql, ref Err))
                {
                    sql = "select ID,RetailPriceWithDiscount,dQuantity,Atom_Price_Item_ID,ProformaInvoice_ID from Atom_ProformaInvoice_Price_Item_Stock";
                    if (DBSync.DBSync.ReadDataTable(ref dt_Atom_ProformaInvoice_Price_Item_Stock, sql, ref Err))
                    {
                        sql = "select ID,RetailPricePerUnit from Atom_Price_Item";
                        if (DBSync.DBSync.ReadDataTable(ref dt_Atom_Price_Item, sql, ref Err))
                        {
                            long ProformaInvoice_ID = -1;
                            int iFinancialYear = -1;
                            int iNumberInFinancialYear = -1;
                            decimal NetSum = -1;
                            decimal TaxSum = -1;
                            decimal GrossSum = -1;
                            decimal ItemsGrossSum = -1;
                            foreach (DataRow dr in dt_ProformaInvoice.Rows)
                            {
                                ProformaInvoice_ID = (long)dr["ID"];
                                iFinancialYear = (int)dr["FinancialYear"];
                                iNumberInFinancialYear = (int)dr["NumberInFinancialYear"];
                                NetSum = (decimal)dr["NetSum"];
                                TaxSum = (decimal)dr["TaxSum"];
                                GrossSum = (decimal)dr["GrossSum"];
                                List<long> Atom_Price_SimpleItem_ID_list = new List<long>();
                                long Atom_Price_SimpleItem_ID = -1;
                                GetItemsSum(ProformaInvoice_ID, dt_Atom_Price_SimpleItem, dt_Atom_ProformaInvoice_Price_Item_Stock, dt_Atom_Price_Item, ref ItemsGrossSum, ref Atom_Price_SimpleItem_ID);
                                if (ItemsGrossSum == GrossSum)
                                {
                                    continue;
                                }
                                else
                                {
                                    sErrMsg += "ERROR:Proforma_Invoice_ID = " + ProformaInvoice_ID.ToString() + " GrossSum=" + GrossSum.ToString() + " ItemsGrossSum = " + ItemsGrossSum.ToString() + "\r\n";
                                    if (((ProformaInvoice_ID == 45) || (ProformaInvoice_ID == 47) || (ProformaInvoice_ID == 89)) && (Atom_Price_SimpleItem_ID>=0))
                                    {
                                        string sql_update = "update Atom_Price_SimpleItem set iQuantity = 1 where ProformaInvoice_ID = " + ProformaInvoice_ID.ToString() + " and ID =" + Atom_Price_SimpleItem_ID.ToString();
                                        object ores=null;
                                        if (!DBSync.DBSync.ExecuteNonQuerySQL(sql_update,null,ref ores,ref Err))
                                        {
                                            LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                                            return false;
                                        }
                                    }
                                }
                            }
                            if (sErrMsg.Length > 0)
                            {
                                LogFile.Error.Show("Check_DB_1_04:Errors:\r\n" + sErrMsg);
                            }
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                            return false;

                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                        return false;

                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql=" + sql + "\r\nErr=" + Err);
                    return false;

                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Check_DB_1_04:sql="+sql+"\r\nErr="+Err);
                return false;

            }
        }

        private void GetItemsSum(long ProformaInvoice_ID,  DataTable dt_Atom_Price_SimpleItem, DataTable dt_Atom_ProformaInvoice_Price_Item_Stock, DataTable dt_Atom_Price_Item, ref decimal ItemsGrossSum, ref long Atom_Price_SimpleItem_ID)
        {
            decimal dsum = 0;
            DataRow[] drs_Atom_Price_SimpleItem = dt_Atom_Price_SimpleItem.Select("ProformaInvoice_ID=" + ProformaInvoice_ID.ToString());
            if (drs_Atom_Price_SimpleItem.Count()>0)
            {
                int iQuantity = -1;
                
                int icol_iQuantity = dt_Atom_Price_SimpleItem.Columns.IndexOf("iQuantity");
                int icol_RetailPriceWithDiscount = dt_Atom_Price_SimpleItem.Columns.IndexOf("RetailSimpleItemPrice");
                
                decimal dRetailPriceWithDiscount = -1;
                foreach (DataRow dr_Atom_Price_SimpleItem in drs_Atom_Price_SimpleItem)
                {
                    iQuantity = (int)dr_Atom_Price_SimpleItem[icol_iQuantity];
                    Atom_Price_SimpleItem_ID = (long)dr_Atom_Price_SimpleItem["ID"];
                    dRetailPriceWithDiscount =(decimal)dr_Atom_Price_SimpleItem[icol_RetailPriceWithDiscount];
                    dsum += dRetailPriceWithDiscount * iQuantity;
                }
            }

            DataRow[] drs_Atom_ProformaInvoice_Price_Item_Stock = dt_Atom_ProformaInvoice_Price_Item_Stock.Select("ProformaInvoice_ID=" + ProformaInvoice_ID.ToString());
            if (drs_Atom_ProformaInvoice_Price_Item_Stock.Count()>0)
            {
                decimal dQuantity = -1;
                int icol_iQuantity = dt_Atom_ProformaInvoice_Price_Item_Stock.Columns.IndexOf("dQuantity");
                int icol_Atom_Price_Item_ID = dt_Atom_ProformaInvoice_Price_Item_Stock.Columns.IndexOf("Atom_Price_Item_ID");

                decimal dRetailPricePerUnit = -1;
                
                foreach (DataRow dr_Atom_ProformaInvoice_Price_Item_Stock in drs_Atom_ProformaInvoice_Price_Item_Stock)
                {
                    dQuantity = (decimal)dr_Atom_ProformaInvoice_Price_Item_Stock[icol_iQuantity];
                    long Atom_Price_Item_ID = (long)dr_Atom_ProformaInvoice_Price_Item_Stock[icol_Atom_Price_Item_ID];
                    DataRow[] drs_Atom_Price_Item = dt_Atom_Price_Item.Select("ID="+Atom_Price_Item_ID.ToString());
                    if (drs_Atom_Price_Item.Count()==1)
                    {
                        dRetailPricePerUnit = (decimal)drs_Atom_Price_Item[0]["RetailPricePerUnit"];
                        dsum += decimal.Round(dQuantity * dRetailPricePerUnit,2);
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:GetItemsSum:drs_Atom_Price_Item.Count()!=1");
                    }
                }
            }
            ItemsGrossSum = dsum;
        }

        private bool UpgradeDB_1_0_to_1_01()
        {
            SQLTable tbl_Logo = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Logo));
            string Err = null;
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Logo.sql_CreateTable, null, ref Err))
            {
                SQLTable tbl_Atom_Logo = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_Logo));
                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_Logo.sql_CreateTable, null, ref Err))
                {
                    string sql = "alter table OrganisationData add column Logo_ID NULL references Logo(ID)";
                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                    {
                        sql = "alter table Atom_OrganisationData add column Atom_Logo_ID NULL references Atom_Logo(ID)";
                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                        {
                            sql = "DROP VIEW OrganisationData_VIEW";
                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                            {
                                sql = "DROP VIEW Atom_OrganisationData_VIEW";
                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                {
                                    SQLTable tbl_OrganisationData = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(OrganisationData));
                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_OrganisationData.sql_CreateView, null, ref Err))
                                    {
                                        SQLTable tbl_Atom_OrganisationData = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_OrganisationData));
                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_OrganisationData.sql_CreateView, null, ref Err))
                                        {

                                            sql = @"PRAGMA foreign_keys = OFF;
                                                    CREATE TABLE Atom_OrganisationData_tmp
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    Atom_Organisation_ID  INTEGER  NOT NULL REFERENCES Atom_Organisation(ID),
                                                    Atom_cAddress_Org_ID  INTEGER  NULL REFERENCES Atom_cAddress_Org(ID),
                                                    cPhoneNumber_Org_ID  INTEGER  NULL REFERENCES cPhoneNumber_Org(ID),
                                                    cFaxNumber_Org_ID  INTEGER  NULL REFERENCES cFaxNumber_Org(ID),
                                                    cEmail_Org_ID  INTEGER  NULL REFERENCES cEmail_Org(ID),
                                                    cHomePage_Org_ID  INTEGER  NULL REFERENCES cHomePage_Org(ID),
                                                    cOrgTYPE_ID  INTEGER  NULL REFERENCES cOrgTYPE(ID),
                                                    'BankName' varchar(264) NULL,
                                                    'TRR' varchar(264) NULL
                                                    , Atom_Logo_ID NULL references Atom_Logo(ID));

                                            INSERT INTO Atom_OrganisationData_tmp (id, Atom_Organisation_ID, Atom_cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,BankName,TRR,Atom_Logo_ID)
                                                SELECT id, Atom_Organisation_ID, Atom_cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,BankName,TRR,Atom_Logo_ID FROM Atom_OrganisationData;
                                            DROP TABLE Atom_OrganisationData;
                                            ALTER TABLE Atom_OrganisationData_tmp RENAME TO Atom_OrganisationData;

                                            CREATE TABLE OrganisationData_tmp
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    Organisation_ID  INTEGER  NOT NULL REFERENCES Organisation(ID),
                                                    cAddress_Org_ID  INTEGER  NULL REFERENCES cAddress_Org(ID),
                                                    cPhoneNumber_Org_ID  INTEGER  NULL REFERENCES cPhoneNumber_Org(ID),
                                                    cFaxNumber_Org_ID  INTEGER  NULL REFERENCES cFaxNumber_Org(ID),
                                                    cEmail_Org_ID  INTEGER  NULL REFERENCES cEmail_Org(ID),
                                                    cHomePage_Org_ID  INTEGER  NULL REFERENCES cHomePage_Org(ID),
                                                    cOrgTYPE_ID  INTEGER  NULL REFERENCES cOrgTYPE(ID),
                                                    Logo_ID NULL references Logo(ID));

                                            INSERT INTO OrganisationData_tmp (id, Organisation_ID, cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,Logo_ID)
                                                SELECT id, Organisation_ID, cAddress_Org_ID,cPhoneNumber_Org_ID,cFaxNumber_Org_ID,cEmail_Org_ID,cHomePage_Org_ID,cOrgTYPE_ID,Logo_ID FROM OrganisationData;
                                            DROP TABLE OrganisationData;
                                            ALTER TABLE OrganisationData_tmp RENAME TO OrganisationData;


                                            CREATE TABLE Atom_PriceList_tmp
                                              (
                                              'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                              'Name' varchar(264) UNIQUE  NOT NULL UNIQUE ,
                                              'Valid' BIT NOT NULL,
                                              'ValidFrom' DATETIME NULL,
                                              'ValidTo' DATETIME NULL,
                                              'Description' varchar(2000) NULL,
                                               Atom_Currency_ID  INTEGER  NOT NULL REFERENCES Atom_Currency(ID),
                                               Atom_myCompany_Person_ID  INTEGER  NOT NULL REFERENCES Atom_myCompany_Person(ID)
                                              );
                                            INSERT INTO Atom_PriceList_tmp (id, Name, Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID,Atom_myCompany_Person_ID)
                                                SELECT id, Name, Valid,ValidFrom,ValidTo,Description,Atom_Currency_ID,Atom_myCompany_Person_ID FROM Atom_PriceList;
                                            DROP TABLE Atom_PriceList;
                                            ALTER TABLE Atom_PriceList_tmp RENAME TO Atom_PriceList;

                                            PRAGMA foreign_keys = ON;";

                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                            {
                                                DataTable dt = new DataTable();
                                                sql = "select Organisation_ID from myCompany order by ID desc";
                                                long Organisation_ID = -1;
                                                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                {
                                                    if (dt.Rows.Count > 0)
                                                    {
                                                        Organisation_ID = (long)dt.Rows[0]["Organisation_ID"];
                                                    }
                                                }
                                                sql = @"PRAGMA foreign_keys = OFF;
                                                DROP TABLE myCompany;
                                                CREATE TABLE myCompany
                                                    (
                                                    'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    OrganisationData_ID  INTEGER  NOT NULL REFERENCES OrganisationData(ID) UNIQUE
                                                    );";
                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                {
                                                    if (Organisation_ID >= 0)
                                                    {
                                                        sql = "select ID  from OrganisationData where Organisation_ID = " + Organisation_ID.ToString() + " order by ID desc";
                                                        long OrganisationData_ID = -1;
                                                        dt.Clear();
                                                        if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                        {
                                                            if (dt.Rows.Count > 0)
                                                            {
                                                                OrganisationData_ID = (long)dt.Rows[0]["ID"];
                                                                sql = "insert into myCompany (OrganisationData_ID)values(" + OrganisationData_ID.ToString() + ");";
                                                                if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                {
                                                                    return false;
                                                                }
                                                            }
                                                        }
                                                    }

                                                    dt.Clear();
                                                    sql = "select Atom_Organisation_ID from Atom_myCompany order by ID desc";
                                                    long Atom_Organisation_ID = -1;
                                                    if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                    {
                                                        if (dt.Rows.Count > 0)
                                                        {
                                                            Atom_Organisation_ID = (long)dt.Rows[0]["Atom_Organisation_ID"];
                                                        }
                                                    }
                                                    sql = @"PRAGMA foreign_keys = OFF;
                                                    DROP TABLE Atom_myCompany;
                                                    CREATE TABLE Atom_myCompany
                                                        (
                                                        'ID' INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        Atom_OrganisationData_ID  INTEGER  NOT NULL REFERENCES Atom_OrganisationData(ID) UNIQUE
                                                        );";
                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                    {
                                                        if (Atom_Organisation_ID >= 0)
                                                        {
                                                            sql = "select ID  from Atom_OrganisationData where Atom_Organisation_ID = " + Atom_Organisation_ID.ToString() + " order by ID desc";
                                                            long Atom_OrganisationData_ID = -1;
                                                            dt.Clear();
                                                            if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                                                            {
                                                                if (dt.Rows.Count > 0)
                                                                {
                                                                    Atom_OrganisationData_ID = (long)dt.Rows[0]["ID"];
                                                                    sql = "insert into Atom_myCompany (Atom_OrganisationData_ID)values(" + Atom_OrganisationData_ID.ToString() + ");";
                                                                    if (!DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                    {
                                                                        return false;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        sql = "DROP VIEW myCompany_Person_VIEW";
                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                        {
                                                            SQLTable tbl_myCompany_Person = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany_Person));
                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_myCompany_Person.sql_CreateView, null, ref Err))
                                                            {
                                                                sql = "DROP VIEW myCompany_VIEW";
                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                {
                                                                    SQLTable tbl_myCompany = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myCompany));
                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_myCompany.sql_CreateView, null, ref Err))
                                                                    {
                                                                        sql = "DROP VIEW Atom_myCompany_Person_VIEW";
                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                        {
                                                                            SQLTable tbl_Atom_myCompany_Person = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_myCompany_Person));
                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_myCompany_Person.sql_CreateView, null, ref Err))
                                                                            {
                                                                                sql = "DROP VIEW Atom_myCompany_VIEW";
                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                {
                                                                                    SQLTable tbl_Atom_myCompany = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Atom_myCompany));
                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_Atom_myCompany.sql_CreateView, null, ref Err))
                                                                                    {

                                                                                        sql = "DROP VIEW ProformaInvoice_VIEW";
                                                                                        if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                        {
                                                                                            SQLTable tbl_ProformaInvoice = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(ProformaInvoice));
                                                                                            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_ProformaInvoice.sql_CreateView, null, ref Err))
                                                                                            {
                                                                                                sql = "DROP VIEW JOURNAL_ProformaInvoice_VIEW";
                                                                                                if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, null, ref Err))
                                                                                                {
                                                                                                    SQLTable tbl_JOURNAL_ProformaInvoice = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(JOURNAL_ProformaInvoice));
                                                                                                    if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(tbl_JOURNAL_ProformaInvoice.sql_CreateView, null, ref Err))
                                                                                                    {
                                                                                                        if (Set_DatBase_Version("1.01"))
                                                                                                        {
                                                                                                            return true;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            LogFile.Error.Show("ERROR:usrc_Invoice:UpgradeDB_1_0_to_1_01:Err=" + Err);
            return false;
        }

        private bool UpgradeDB_1_01_to_1_02()
        {
            wfp_ui_thread = new Database_Upgrade_WindowsForm_Thread();
            wfp_ui_thread.Start();


            List<DataTable> dt_List = new List<DataTable>();
            string Err = null;
            SQLTable tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_Item));
            wfp_ui_thread.Message("$$$" + lngRPM.s_UpgradeDatabase.s + " 1.01 -> 1.02");
            wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
            SQLTable xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
            TableDataItem dt_Price_Item = new TableDataItem(xtbl, ref dt_List,null, ref Err);
            if (Err != null)
            {

                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_Price_Item);

            tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Price_SimpleItem));
            wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
            xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
            TableDataItem dt_Price_SimpleItem = new TableDataItem(xtbl, ref dt_List,null, ref Err);
            if (Err != null)
            {
                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_Price_SimpleItem);

            tbl = DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(OrganisationAccount));
            wfp_ui_thread.Message(lngRPM.s_ReadTable.s + tbl.TableName);
            xtbl = new SQLTable(tbl);
            xtbl.CreateTableTree(DBSync.DBSync.DB_for_Blagajna.m_DBTables.items);
            TableDataItem dt_OrganisationAccount = new TableDataItem(xtbl, ref dt_List,null, ref Err);
            if (Err != null)
            {
                wfp_ui_thread.End();
                LogFile.Error.Show("ERROR:usrc_Upgrade:UpgradeDB_1_01_to_1_02:TableName=" + tbl.TableName + ";Err=" + Err);
                return false;
            }
            TableDataItem_List.Add(dt_OrganisationAccount);


            wfp_ui_thread.Message(lngRPM.s_BackupOfExistingDatabase.s + DBSync.DBSync.DataBase + " -> " + DBSync.DBSync.DataBase_BackupTemp);

            if (DBSync.DBSync.DB_for_Blagajna.DataBase_Make_BackupTemp())
            {
                if (DBSync.DBSync.DB_for_Blagajna.DataBase_Delete())
                {
                    if (DBSync.DBSync.DB_for_Blagajna.DataBase_Create())
                    {
                        wfp_ui_thread.Message(lngRPM.s_ImportData.s);
                        if (Write_TableDataItem_List(m_eUpgrade,m_Old_tables_1_04_to_1_05))
                        {
                            Set_DatBase_Version("1.02");
                        }
                    }
                }
            }
            wfp_ui_thread.End();
            return true;
        }

        private bool Set_DatBase_Version(string Version)
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
            if (DBSync.DBSync.ExecuteNonQuerySQL_NoMultiTrans(sql, lpar, ref Err))
            {
                return true;
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Set_DatBase_Version:sql = " + sql + "\r\nErr=" + Err);
                return false;
            }
        }

        private bool Write_TableDataItem_List(eUpgrade eUpgr,Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            foreach (TableDataItem tdi in TableDataItem_List)
            {
                if (!tdi.Write2DB(wfp_ui_thread, eUpgr, m_Old_tables_1_04_to_1_05))
                {
                    return false;
                }
            }
            return true;
        }

        private void btn_Upgrade_Click(object sender, EventArgs e)
        {
            if (Backup != null)
            {
                Backup();
            }
        }

    }

    public class TableDataItem
    {
        public SQLTable tbl = null;
        public DataTable dt = null;
        public List<TableDataItem> fkey_TableDataItem_List = new List<TableDataItem>();
        public TableDataItem prev = null;

        public TableDataItem(SQLTable xtbl, ref List<DataTable> dt_List,TableDataItem xprev, ref string Err)
        {
            // TODO: Complete member initialization
            tbl = xtbl;
            prev = xprev;
            foreach (Column col in xtbl.Column)
            {
                if (col.fKey != null)
                {
                    if (!col.fKey.fTable.TableName.Equals("Atom_WorkPeriod"))
                    {
                        TableDataItem tdi = new TableDataItem(col.fKey.fTable, ref dt_List, this, ref Err);
                        if (Err != null)
                        {
                            return;
                        }
                        fkey_TableDataItem_List.Add(tdi);
                    }
                }
            }
            if (Find_dt_List(ref dt, dt_List, tbl.TableName))
            {
                return;
            }
            else
            {
                string sql = "select * from " + xtbl.TableName;
                dt = new DataTable();
                dt.TableName = tbl.TableName;
                if (DBSync.DBSync.ReadDataTable(ref dt, sql, ref Err))
                {
                    dt.Columns.Add("old_ID", typeof(long));
                    dt_List.Add(dt);
                }
            }
        }

        internal bool Write2DB(Database_Upgrade_WindowsForm_Thread wfp_ui_thread,usrc_Upgrade.eUpgrade eUpgr,Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            string Err = null;
            foreach (TableDataItem xtdi in fkey_TableDataItem_List)
            {
                xtdi.Write2DB(wfp_ui_thread, eUpgr, m_Old_tables_1_04_to_1_05);
            }

            if (eUpgr == usrc_Upgrade.eUpgrade.from_1_04_to_105)
            {
                if (this.tbl.TableName.ToLower().Equals("pricelist"))
                {
                    if (GlobalData.Office_ID<0)
                    { 
                        string sql = "insert into Office (myCompany_ID,Name)values(1,'P1')";
                        object oret = null;
                        if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql,null,ref GlobalData.Office_ID,ref oret, ref Err,"Office"))
                        {
                            sql = "insert into myCompany_Person (UserName,Password,Job,Active,Description,Person_ID,Office_ID)values('marjetkah',null,'Direktor',1,'Direktorica in lastnica podjetja',1,1)";
                            long x_myCompany_Person_ID = -1;
                            if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref x_myCompany_Person_ID, ref oret, ref Err, "Office"))
                            {
                                
                            }
                            else
                            {
                                LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
                                return false;
                            }
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }
                }
                else if (this.tbl.TableName.ToLower().Equals("atom_pricelist"))
                {
                    string sql = null;
                    object oret = null;
                    if (GlobalData.Atom_Office_ID < 0)
                    {
                        sql = "insert into Atom_Office (Atom_myCompany_ID,Name)values(1,'P1')";
                        if (!DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql, null, ref GlobalData.Atom_Office_ID, ref oret, ref Err, "Atom_Office"))
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:sql=" + sql + "\r\nErr=" + Err);
                            return false;
                        }
                    }

                    DateTime dtStart = new DateTime(2015, 4, 29);
                    DateTime_v dtEnd_v = new DateTime_v();
                    dtEnd_v.v = DateTime.Now;
                    if (!GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04,null,dtStart,dtEnd_v, ref Err))
                    {
                        return false;
                    }


                }
                else if (this.tbl.TableName.ToLower().Equals("proformainvoice"))
                {
                    DateTime dtStart = new DateTime(2015, 4, 29);
                    DateTime_v dtEnd_v = new DateTime_v();
                    dtEnd_v.v = DateTime.Now;
                    GlobalData.GetWorkPeriod(f_Atom_WorkPeriod.sWorkPeriod_DB_ver_1_04, null, dtStart, dtEnd_v, ref Err);
                }
            }

            string tname = tbl.TableName;
            string sql_insert_columns = null;
            string sql_insert_values = null;
            List<SQL_Parameter> lpar = new List<SQL_Parameter>();
            bool bProformaInvoiceTime = false;
            bool bFirstPrintTime = false;
            bool bPaid = false;
            bool bStorno = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["old_id"] is System.DBNull)
                {
                    wfp_ui_thread.Message(lngRPM.s_ImportData.s + ":" + tname);
                    sql_insert_columns = null;
                    sql_insert_values = null;
                    lpar.Clear();
                    long old_id = (long)dr["id"];
                    DateTime_v InvoiceTime_v = null;
                    DateTime_v PaidTime_v = null;
                    DateTime_v StornoTime_v = null;
                    foreach (DataColumn dcol in dt.Columns)
                    {
                        if (dcol.ColumnName.ToUpper().Equals("ID") || dcol.ColumnName.ToUpper().Equals("OLD_ID"))
                        {
                            continue;
                        }
                        else
                        {
                            if (eUpgr == usrc_Upgrade.eUpgrade.from_1_04_to_105)
                            {
                                if (dcol.ColumnName.ToLower().Equals("mycompany_person_id"))
                                {
                                    continue;
                                }
                                if (this.tbl.TableName.ToLower().Equals("atom_pricelist"))
                                {
                                    if (dcol.ColumnName.ToLower().Equals("atom_mycompany_person_id"))
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    if (this.tbl.TableName.ToLower().Equals("proformainvoice"))
                                    {
                                        if (dcol.ColumnName.ToLower().Equals("atom_mycompany_person_id"))
                                        {
                                            continue;
                                        }
                                    }

                                }
                            }
                        }
                        object o = dr[dcol];
                        string sparname = null;
                        SQL_Parameter par = null;
                        if (new_SQL_Parameter(this, dr, dcol, ref sparname, o, ref par))
                        {
                            if (dcol.ColumnName.ToLower().Equals("paid"))
                            {
                                bPaid = true;
                            }
                            if (dcol.ColumnName.ToLower().Equals("storno"))
                            {
                                bStorno = true;
                            }

                            if (dcol.ColumnName.ToLower().Equals("firstprinttime"))
                            {
                                bFirstPrintTime = true;
                            }
                            else if (dcol.ColumnName.ToLower().Equals("proformainvoicetime"))
                            {
                                bProformaInvoiceTime = true;
                            }
                            else
                            {
                                if (par != null)
                                {
                                    lpar.Add(par);
                                }
                                if (sql_insert_columns == null)
                                {
                                    sql_insert_columns = dcol.ColumnName;
                                }
                                else
                                {
                                    sql_insert_columns += "," + dcol.ColumnName;
                                }
                                if (sql_insert_values == null)
                                {
                                    sql_insert_values = sparname;
                                }
                                else
                                {
                                    sql_insert_values += "," + sparname;
                                }

                            }
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (bProformaInvoiceTime)
                    { 
                        if (dr["proformainvoicetime"] is DateTime)
                        {
                            InvoiceTime_v = new DateTime_v();
                            InvoiceTime_v.v = (DateTime)dr["proformainvoicetime"];
                        }
                    }

                    if (bPaid)
                    {
                        if (dr["Paid"] is bool)
                        {
                            PaidTime_v = new DateTime_v();
                            PaidTime_v.v = GetProformaInvoiceTime(old_id,m_Old_tables_1_04_to_1_05);
                        }
                    }

                    if (bStorno)
                    {
                        if (dr["Storno"] is bool)
                        {
                            if ((bool)dr["Storno"])
                            {
                                StornoTime_v = new DateTime_v();
                                StornoTime_v.v = GetInvoiceStornoTime(old_id, m_Old_tables_1_04_to_1_05);
                            }
                            else
                            {
                                bStorno = false;
                            }
                        }
                    }

                    string sql_insert = " insert into " + tname + " (" + sql_insert_columns + ") values (" + sql_insert_values + ")";
                    long new_id = -1;
                    object ores = null;
                    if (DBSync.DBSync.ExecuteNonQuerySQLReturnID(sql_insert, lpar, ref new_id, ref ores, ref Err, tname))
                    {
                        dr["OLD_ID"] = old_id;
                        dr["id"] = new_id;
                        if (tname.ToLower().Equals("proformainvoice"))
                        { 
                            long Journal_ProformaInvoice_ID = -1;
                            f_Journal_ProformaInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.Name, GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceDraftTime.Description, InvoiceTime_v, ref Journal_ProformaInvoice_ID);
                            if (dr["Draft"] is bool)
                            {
                                if (!(bool)dr["Draft"])
                                { 
                                    f_Journal_ProformaInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceTime.Name, GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoiceTime.Description ,InvoiceTime_v, ref Journal_ProformaInvoice_ID);
                                    f_Journal_ProformaInvoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoicePaidTime.Name, GlobalData.JOURNAL_ProformaInvoice_Type_definitions.InvoicePaidTime.Description, InvoiceTime_v, ref Journal_ProformaInvoice_ID);
                                }
                            }
                        }
                        else if (tname.ToLower().Equals("invoice"))
                        {
                            long Journal_Invoice_ID = -1;
                            f_Journal_Invoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, "Paid", "Plačano", PaidTime_v, ref Journal_Invoice_ID);
                            if (bStorno)
                            { 
                                f_Journal_Invoice.Write(new_id, GlobalData.Atom_WorkPeriod_ID, "Storno*", "Napaka pri vnosu", StornoTime_v, ref Journal_Invoice_ID);
                            }
                        }
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Write2DB:Err=" + Err);
                        return false;
                    }
                }
            }
            return true;
        }

        private DateTime GetInvoiceStornoTime(long Invoice_id, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {
            DataRow[] drs = m_Old_tables_1_04_to_1_05.dt_Journal_Invoice.Select("invoice_id=" + Invoice_id.ToString());
            if (drs.Count() > 0)
            {
                return (DateTime)drs[0]["EventTime"];
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:GetInvoiceStornoTime:Err id =" + Invoice_id.ToString() + " not found in table ProformaInvoice!");
                return DateTime.Now;
            }
        }

        private DateTime GetProformaInvoiceTime(long id, Old_tables_1_04_to_1_05 m_Old_tables_1_04_to_1_05)
        {

            DataRow[] drs = m_Old_tables_1_04_to_1_05.dt_ProformaInvoice.Select("id=" + id.ToString());
            if (drs.Count()>0)
            {
                if (drs[0]["ProformaInvoiceTime"] is DateTime)
                { 
                    return (DateTime)drs[0]["ProformaInvoiceTime"];
                }
                else
                {
                    //LogFile.Error.Show("ERROR:usrc_Upgrade:GetProformaInvoiceTime:ProformaInvoiceTime type = " + drs[0]["ProformaInvoiceTime"].GetType().ToString());
                    return DateTime.Now;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:GetProformaInvoiceTime:Err id =" + id.ToString() + " not found in table ProformaInvoice!");
                return DateTime.Now;
            }
        }


        private bool Find_dt_List(ref DataTable dtchk, List<DataTable> dt_List, string tname)
        {
            foreach (DataTable xdt in dt_List)
            {
                if (xdt.TableName.Equals(tname))
                {
                    dtchk = xdt;
                    return true;
                }
            }
            return false;
        }

        private bool new_SQL_Parameter(TableDataItem tdi, DataRow dr, DataColumn dcol, ref string sparname, object o, ref SQL_Parameter par)
        {
            long new_ID = -1;
            sparname = "@par_" + dcol.ColumnName;
            //if (tdi.tbl.TableName.Equals("Atom_cAddress_Org"))
            //{
            //    MessageBox.Show("Atom_cAddress_Org");
            //}
            if (IsForeignKey(tdi, dr, dcol, ref new_ID))
            {
                o = new_ID;
            }
            if (o is string)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Nvarchar, false, o);
            }
            else if (o is bool)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bit, false, o);
            }
            else if (o is short)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, o);

            }
            else if (o is ushort)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Smallint, false, o);
            }
            else if (o is int)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Int, false, o);
            }
            else if (o is uint)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Int, false, o);

            }
            else if (o is long)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bigint, false, o);

            }
            else if (o is ulong)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Bigint, false, o);
            }
            else if (o is DateTime)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Datetime, false, o);
            }
            else if (o is byte[])
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Varbinary, false, o);
            }
            else if (o is decimal)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Decimal, false, o);
            }
            else if (o is float)
            {
                par = new SQL_Parameter(sparname, SQL_Parameter.eSQL_Parameter.Float, false, o);
            }
            else if (o is System.DBNull)
            {
                sparname = "null";
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:new_SQL_Parameter: type = " + o.GetType().ToString() + " not implemented !");
                return false;
            }
            return true;
        }

        private bool IsForeignKey(TableDataItem tdi, DataRow dr, DataColumn dcol, ref long new_ID)
        {
            foreach (Column col in tdi.tbl.Column)
            {
                if (col.fKey != null)
                {
                    if (col.Name.Equals(dcol.ColumnName))
                    {
                        foreach (TableDataItem xtdi in tdi.fkey_TableDataItem_List)
                        {
                            if (col.fKey.fTable.TableName.Equals(xtdi.tbl.TableName))
                            {
                                object o_Old_ID = dr[dcol.ColumnName];
                                if (o_Old_ID is long)
                                {
                                    DataRow[] drs = xtdi.dt.Select("old_ID = " + ((long)o_Old_ID).ToString());
                                    if (drs.Count() > 0)
                                    {
                                        new_ID = (long)drs[0]["ID"];
                                        return true;
                                    }
                                }
                           }
                        }
                    }
                }
            }
            return false;
        }
    }

    public class Old_tables_1_04_to_1_05
    {
        public DataTable dt_ProformaInvoice = new DataTable();
        public DataTable dt_Invoice = new DataTable();
        public DataTable dt_Journal_Invoice = new DataTable();
        public DataTable dt_Journal_Invoice_Type = new DataTable();
        public bool Read()
        {
            string Err = null;
            string sql = "select * from ProformaInvoice";
            if (DBSync.DBSync.ReadDataTable(ref dt_ProformaInvoice,sql, ref Err))
            {
                sql = "select * from Invoice";
                if (DBSync.DBSync.ReadDataTable(ref dt_Invoice,sql, ref Err))
                {
                    sql = "select * from JOURNAL_Invoice";
                    if (DBSync.DBSync.ReadDataTable(ref dt_Journal_Invoice,sql, ref Err))
                    {
                        sql = "select * from Journal_Invoice_Type";
                        if (DBSync.DBSync.ReadDataTable(ref dt_Journal_Invoice_Type,sql, ref Err))
                        {
                            return true;
                        }
                        else
                        {
                            LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                            return false;
                        }

                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                        return false;
                    }

                }
                else
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:Old_tables_1_04_to_1_05:Read:Err="+Err);
                return false;
            }

        }

    }
}
