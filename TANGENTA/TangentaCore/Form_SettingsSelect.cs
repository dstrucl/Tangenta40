using DocumentManager;
using Startup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentManager
{
    public partial class Form_SettingsSelect : Form
    {
        private SettingsUserValues m_SettingsUserValues = null;
        private Form Main_Form = null;
        private object m_usrc_DocumentManX = null;

        public Form_SettingsSelect(Form xMain_Form, object xusrc_DocumentManX, SettingsUserValues xSettingsUserValues)
        {
            InitializeComponent();
            Main_Form = xMain_Form;
            m_usrc_DocumentManX = xusrc_DocumentManX;
            m_SettingsUserValues = xSettingsUserValues;
            lng.s_Settings.Text(this);
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            string sDBType = Properties.Settings.Default.DBType;
            DBConnectionControl40.DBConnection.eDBType org_eDBType = DBSync.DBSync.m_DBType;
            NavigationButtons.Navigation nav = new NavigationButtons.Navigation(null);
            nav.btn3_Visible = true;
            nav.btn3_Text = "";
            nav.btn3_Image = Properties.Resources.Exit;
            string xCodeTables_IniFileFolder = null;
            string Err = null;
            if (Global.f.SetApplicationDataSubFolder(ref xCodeTables_IniFileFolder, DocumentMan.TANGENTA_SETTINGS_SUB_FOLDER, ref Err))
            {
                string xSQLitebackupFolder = Properties.Settings.Default.SQLiteBackupFolder;
                if (xSQLitebackupFolder.Length == 0)
                {
                    if (Global.f.SetApplicationDataSubFolder(ref xSQLitebackupFolder, DocumentMan.TANGENTA_SQLITEBACKUP_SUB_FOLDER, ref Err))
                    {
                    }
                }
                DBSync.DBSync.DBMan(Main_Form, Reset2FactorySettings.DBConnectionControlXX_EXE, DocumentMan.m_XmlFileName, xCodeTables_IniFileFolder, ref sDBType, ref xSQLitebackupFolder, nav);
                Properties.Settings.Default.SQLiteBackupFolder = xSQLitebackupFolder;
                Properties.Settings.Default.DBType = sDBType;
                Properties.Settings.Default.Save();
            }

        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            NavigationButtons.Navigation nav_Form_ProgramSettings = new NavigationButtons.Navigation(null);
            nav_Form_ProgramSettings.bDoModal = true;
            nav_Form_ProgramSettings.m_eButtons = NavigationButtons.Navigation.eButtons.OkCancel;
            Form_ProgramSettings edt_Form = null;
            edt_Form = new Form_ProgramSettings(m_usrc_DocumentManX, nav_Form_ProgramSettings, m_SettingsUserValues);
            edt_Form.ShowDialog(this);
            edt_Form.Dispose();
        }

        private void btn_CodeTables_Click(object sender, EventArgs e)
        {
            Form_CodeTables fct_dlg = new Form_CodeTables(m_usrc_DocumentManX);
            fct_dlg.ShowDialog(this);

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
