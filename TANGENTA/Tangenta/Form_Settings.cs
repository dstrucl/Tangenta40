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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLTableControl;
using BlagajnaTableClass;
using LanguageControl;
using InvoiceDB;

namespace Tangenta
{
    public partial class Form_Settings : Form
    {
        private int default_language_ID = -1;
        private int newLanguage = -1;
        private usrc_Main m_usrc_Main;

        public Form_Settings()
        {

        }

        public Form_Settings(usrc_Main usrc_Main)
        {
            InitializeComponent();
            lngRPM.s_LogFile.Text(btn_LogFile);
            lngRPM.s_Language.Text(lbl_Language);
            lngRPM.s_FullScreen.Text(chk_FullScreen);
            lngRPM.s_Shops_In_Use.Text(btn_Shops_in_use);
            default_language_ID = DynSettings.LanguageID;
            newLanguage = default_language_ID;
            cmb_Language.DataSource = DynSettings.s_language.sTextArr;
            cmb_Language.SelectedIndex = DynSettings.LanguageID;
            cmb_Language.SelectedIndexChanged += cmb_Language_SelectedIndexChanged;

            DynSettings.AllowToEditText = Properties.Settings.Default.AllowToEditLanguageText;
            chk_AllowToEditText.Checked = DynSettings.AllowToEditText;
            chk_AllowToEditText.CheckedChanged += chk_AllowToEditText_CheckedChanged;
            chk_FullScreen.Checked = Properties.Settings.Default.FullScreen;
            chk_FullScreen.CheckedChanged += Chk_FullScreen_CheckedChanged;
            m_usrc_Main = usrc_Main;
        }

        private void Chk_FullScreen_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FullScreen = chk_FullScreen.Checked;
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.FullScreen)
            {
                Program.MainForm.WindowState = FormWindowState.Maximized;
                Program.MainForm.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                Program.MainForm.FormBorderStyle = FormBorderStyle.Sizable;
            }

        }

        void chk_AllowToEditText_CheckedChanged(object sender, EventArgs e)
        {
            DynSettings.AllowToEditText = chk_AllowToEditText.Checked;
            Properties.Settings.Default.AllowToEditLanguageText = DynSettings.AllowToEditText;
            Properties.Settings.Default.Save();

        }

        private void MenuMain_Stock_Click(object sender, EventArgs e)
        {
           
        }

        private void CreateTableDockingForm(SQLTable sQLTable)
        {
            TableDockingForm TableDockingDlg = new TableDockingForm(this, DBSync.DBSync.DB_for_Blagajna.m_DBTables, sQLTable);
            TableDockingDlg.ShowDialog();
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            CreateTableDockingForm(new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Stock))));

        }

        private void btn_MyCompany_Click(object sender, EventArgs e)
        {
            CreateTableDockingForm(new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(myOrg))));
        }

        private void btn_SimpleItems_Click(object sender, EventArgs e)
        {
            CreateTableDockingForm(new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(SimpleItem))));
        }

        private void btn_BuyerCompany_Click(object sender, EventArgs e)
        {
            CreateTableDockingForm(new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Customer_Org))));

        }

        private void btn_Stranke_Click(object sender, EventArgs e)
        {
            CreateTableDockingForm(new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Person))));
        }

        private void btn_Taxations_Click(object sender, EventArgs e)
        {
            CreateTableDockingForm(new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Taxation))));
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            CreateTableDockingForm(new SQLTable(DBSync.DBSync.DB_for_Blagajna.m_DBTables.GetTable(typeof(Item))));
        }

        private void btn_DataBaseConnection_Click(object sender, EventArgs e)
        {
            string BackupFolder = Properties.Settings.Default.BackupFolder;
            DBSync.DBSync.DB_for_Blagajna.CreateNewConnection(this, DBSync.DBSync.LocalDB_data_SQLite, ref BackupFolder);
            Properties.Settings.Default.BackupFolder = BackupFolder;
            Properties.Settings.Default.Save();
        }

        private void btn_DeleteInvoices_Click(object sender, EventArgs e)
        {
            string[] table = new string[] {"JOURNAL_ProformaInvoice",
                           "Atom_ProformaInvoice_Price_Item_Stock",
                           "Atom_Price_Item",
                           "Atom_Price_SimpleItem",
                           "ProformaInvoice",
                           "Invoice",
                           "Atom_PriceList",
                           "Atom_Item",
                           "Atom_SimpleItem",
                           "Atom_Customer_Org",
                           "Atom_myCompany_Person",
                           "Atom_myCompany",
                           "Atom_OrganisationData",
                           "Atom_Organisation",
                           "Atom_Logo",
                           "Atom_cAddress_Org",
                           "Atom_cStreetName_Org",
                           "Atom_cHouseNumber_Org",
                           "Atom_cZip_Org",
                           "Atom_cCity_Org",
                           "Atom_cState_Org",
                           "Atom_cCountry_Org",
                           "Atom_Currency",
                           "Atom_Unit",
                           "Atom_Customer_Person",
                           "Atom_Person",
                           "Atom_cAddress_Person",
                           "Atom_cStreetName_Person",
                           "Atom_cHouseNumber_Person",
                           "Atom_cZip_Person",
                           "Atom_cCity_Person",
                           "Atom_cState_Person",
                           "Atom_cCountry_Person",
                           "Atom_cFirstName",
                           "Atom_cLastName",
                           "Atom_cGsmNumber_Person",
                           "Atom_cPhoneNumber_Person",
                           "Atom_cEmail_Person",
                           "Atom_PersonImage",
                           "Atom_cCardType_Person",
                           "Atom_Expiry",
                           "Atom_Taxation",
                           "Atom_Warranty",
                            };
                            
            string Err = null;
            object ores = null;
            foreach (string tbl in table)
            {
                string sql = "delete from " + tbl + ";";
                if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                {
                    sql = "UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = '" + tbl + "'";
                    if (DBSync.DBSync.ExecuteNonQuerySQL(sql, null, ref ores, ref Err))
                    {
                    }
                    else
                    {
                        LogFile.Error.Show("ERROR:btn_DeleteInvoices_Click:sql = " + sql + "\r\nErr=" + Err);
                    }
                }
                else
                {
                    LogFile.Error.Show("ERROR:btn_DeleteInvoices_Click:sql = " + sql + "\r\nErr=" + Err);
                }

            }
            MessageBox.Show(this,lngRPM.s_AllInvoiceDataAndArchiveAreDeleted.s);
        }

        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            newLanguage = cmb_Language.SelectedIndex;
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newLanguage != default_language_ID)
            {
                Properties.Settings.Default.LanguageID = newLanguage;
                Properties.Settings.Default.Save();
                XMessage.Box.Show(this, lngRPM.s_YouHaveChangedLanguageYouMustRestartProgramToUseNewLanguage, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_Shops_in_use_Click(object sender, EventArgs e)
        {
            Form_ShopsInUse frm_shops_in_use = new Form_ShopsInUse(m_usrc_Main);
            frm_shops_in_use.ShowDialog();
        }

        private void btn_LogFile_Click(object sender, EventArgs e)
        {
            LogFile.LogFile.LogManager();
        }
    }
}
