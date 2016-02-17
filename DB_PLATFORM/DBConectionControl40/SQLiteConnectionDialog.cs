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
using LanguageControl;
using System.IO;
using System.Security.AccessControl;
namespace DBConnectionControl40
{
    public partial class SQLiteConnectionDialog : Form
    {
        private Form m_ParentForm = null;

        public string DatabaseFileName = null;

        public string BackupFolder = null;

        private conData_SQLITE m_conData_SQLITE;

        public SQLiteConnectionDialog(Form pParentForm,conData_SQLITE xconData_SQLite,string recent_items_folder, string xBackupFolder)
        {
            m_conData_SQLITE = xconData_SQLite;

            BackupFolder = xBackupFolder;
            m_ParentForm = pParentForm;
            this.Owner = pParentForm;
            InitializeComponent();

            cmbR_FilePath.RecentItemsFolder = recent_items_folder;
            cmbR_FileName.RecentItemsFolder = recent_items_folder;

            if (m_conData_SQLITE.IsValidDataBaseFile())
            {
                cmbR_FilePath.Text = Path.GetDirectoryName(m_conData_SQLITE.DataBaseFile);
                if (!cmbR_FilePath.Text.EndsWith("\\"))
                {
                    cmbR_FilePath.Text += "\\";
                }
                DatabaseFileName = Path.GetFileName(m_conData_SQLITE.DataBaseFile);
                cmbR_FileName.Text = DatabaseFileName;
                
                if (!System.IO.File.Exists(xconData_SQLite.DataBaseFile))
                {
                    if (!m_conData_SQLITE.SQLite_AllwaysCreateNew)
                    {
                        MessageBox.Show(lngRPM.s_File_does_not_exist.s + m_conData_SQLITE.DataBaseFile);
                    }
                }
            }
            else
            {
                //txtFilePath.Text = Application.CommonAppDataPath;
                cmbR_FilePath.Text = "C:\\";
                DatabaseFileName = "LocalDB.sqlite";
                cmbR_FileName.Text = DatabaseFileName;
            }


            this.btn_OK.Text = lngConn.s_Ok.s;
            this.btn_Cancel.Text = lngConn.s_Cancel.s;
            this.lbl_FileName.Text = lngConn.s_FileName.s + ":";
            this.btn_SelectFile.Text = lngConn.s_FileName.s;
            this.btn_SelectFolder.Text = lngConn.s_Folder.s;
            this.lbl_Folder.Text = lngConn.s_Folder.s + ":";
            this.Text = lngConn.s_SelectSQLiteDataBaseFileName.s;
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            Do_OK();
        }

        private void Do_OK()
        {
            m_conData_SQLITE.m_DataBaseFilePath = this.cmbR_FilePath.Text;
            string DirPath = m_conData_SQLITE.m_DataBaseFilePath;
            string username = System.Environment.UserDomainName + "\\" + System.Environment.UserName;
            if (Directory.Exists(DirPath))
            {
                System.Security.AccessControl.DirectorySecurity myDirectorySecurity = Directory.GetAccessControl(DirPath);
                myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(username, System.Security.AccessControl.FileSystemRights.FullControl, AccessControlType.Allow));
                //Directory.SetAccessControl(DirPath, myDirectorySecurity);
            }
            else
            {
                DirectoryInfo drinfo = Directory.CreateDirectory(m_conData_SQLITE.m_DataBaseFilePath);
                if (drinfo != null)
                {
                    System.Security.AccessControl.DirectorySecurity myDirectorySecurity = drinfo.GetAccessControl();

                    myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(username, System.Security.AccessControl.FileSystemRights.FullControl, AccessControlType.Allow));
                    drinfo.SetAccessControl(myDirectorySecurity);
                }
            }
            m_conData_SQLITE.m_DataBaseFileName = this.cmbR_FileName.Text;
            if (m_conData_SQLITE.IsValidDataBaseFile())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(lngConn.s_Error.s + ":" + lngConn.s_FileName.s + ":" + m_conData_SQLITE.DataBaseFile + " " + lngConn.s_IsNotValid.s + ".");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
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
            }
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog(this) == DialogResult.OK)
            {
                this.cmbR_FileName.Text = Path.GetFileName(fdlg.FileName);
            }
        }

        private void SQLiteConnectionDialog_Load(object sender, EventArgs e)
        {
            if (m_conData_SQLITE.SQLite_AllwaysCreateNew)
            {
                Do_OK();
            }
        }

        private void btn_SQLiteInfo_Click(object sender, EventArgs e)
        {
            SQLiteInfo_Form SQLite_info_frm = new SQLiteInfo_Form();
            SQLite_info_frm.ShowDialog();
        }

        private void cmbR_FilePath_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Folder_Click(object sender, EventArgs e)
        {

        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            Form_Backup_SQLite frm_backup = new Form_Backup_SQLite(m_conData_SQLITE.DataBaseFile,DatabaseFileName, BackupFolder);
            if (frm_backup.ShowDialog()== DialogResult.OK)
            {
                BackupFolder = frm_backup.BackupFolder;
            }
        }
    }
}
