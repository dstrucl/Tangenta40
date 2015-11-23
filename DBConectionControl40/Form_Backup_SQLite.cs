using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnectionControl40
{
    public partial class Form_Backup_SQLite : Form
    {
        public string BackupFolder = "";
        public string DatabaseFileName = "";
        public string FullFileNamePath = "";
        public Form_Backup_SQLite(string xFullFileNamePath,string xDatabaseFileName, string xBackupFolder)
        {
            InitializeComponent();
            BackupFolder = xBackupFolder;
            FullFileNamePath = xFullFileNamePath;
            DatabaseFileName = xDatabaseFileName;
            DateTime dt = DateTime.Now;
            string s_time_extension = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + "_" + dt.Hour.ToString() + "-" + dt.Minute.ToString() + "-" + dt.Second.ToString() + "-" + dt.Millisecond.ToString();
            txt_BackupFileName.Text = xDatabaseFileName+ "_backup_" + s_time_extension;
            this.cmbR_FilePath.Text = BackupFolder;
        }

        private void btn_SelectFolder_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderDlg.ShowDialog(this) == DialogResult.OK)
            {
                this.cmbR_FilePath.Text = folderDlg.SelectedPath;
                if (!cmbR_FilePath.Text.EndsWith("\\"))
                {
                    cmbR_FilePath.Text += "\\";
                }
                BackupFolder = cmbR_FilePath.Text;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private bool MakeBackup()
        {
            this.Cursor = Cursors.WaitCursor;
            string DestinationFullFileNamePath = BackupFolder + txt_BackupFileName.Text;
            try
            {
                File.Copy(FullFileNamePath, DestinationFullFileNamePath);
                this.Cursor = Cursors.Arrow;
                return true;

            }
            catch (Exception Ex)
            {
                this.Cursor = Cursors.Arrow;
                LogFile.Error.Show("ERROR:Form_Backup_SQLite:DataBase_Make_BackupTemp_SQLite:Exception=" + Ex.Message);
                return false;
            }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (MakeBackup())
            { 
                Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Close();
                this.DialogResult = DialogResult.Abort;
            }
            
        }
    }
}
