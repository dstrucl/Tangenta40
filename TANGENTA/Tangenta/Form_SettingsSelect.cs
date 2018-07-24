using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tangenta
{
    public partial class Form_SettingsSelect : Form
    {
        private Form Main_Form = null;
        private usrc_DocumentMan m_usrc_DocumentMan = null;
        public Form_SettingsSelect(Form xMain_Form,usrc_DocumentMan xusrc_DocumentMan)
        {
            InitializeComponent();
            Main_Form = xMain_Form;
            m_usrc_DocumentMan = xusrc_DocumentMan;
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
            if (StaticLib.Func.SetApplicationDataSubFolder(ref xCodeTables_IniFileFolder, Program.TANGENTA_SETTINGS_SUB_FOLDER, ref Err))
            {
                string xSQLitebackupFolder = Properties.Settings.Default.SQLiteBackupFolder;
                if (xSQLitebackupFolder.Length == 0)
                {
                    if (StaticLib.Func.SetApplicationDataSubFolder(ref xSQLitebackupFolder, Program.TANGENTA_SQLITEBACKUP_SUB_FOLDER, ref Err))
                    {
                    }
                }
                DBSync.DBSync.DBMan(Main_Form, Program.Reset2FactorySettings.DBConnectionControlXX_EXE, ((Form_Document)Main_Form).m_XmlFileName, xCodeTables_IniFileFolder, ref sDBType, ref xSQLitebackupFolder, nav);
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
            Form_ProgramSettings edt_Form = new Form_ProgramSettings(m_usrc_DocumentMan, nav_Form_ProgramSettings);
            edt_Form.ShowDialog(this);
            edt_Form.Dispose();
        }

        private void btn_CodeTables_Click(object sender, EventArgs e)
        {
            Form_CodeTables fct_dlg = new Form_CodeTables();
            fct_dlg.ShowDialog(this);

        }
    }
}
