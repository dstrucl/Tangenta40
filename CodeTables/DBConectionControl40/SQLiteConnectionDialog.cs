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

        public string DataBaseFile_path = null;
        public string DataBaseFile_name = null;


        public string BackupFolder = null;

        private conData_SQLITE m_conData_SQLITE;

        private NavigationButtons.Navigation nav = null;


        public SQLiteConnectionDialog(conData_SQLITE xconData_SQLite,string recent_items_folder, string xBackupFolder, NavigationButtons.Navigation xnav, string myConnectionName)
        {
            m_conData_SQLITE = xconData_SQLite;

            BackupFolder = xBackupFolder;
            m_ParentForm = xnav.parentForm;
            this.Owner = xnav.parentForm;
            InitializeComponent();
            nav = xnav;
            nav.ShowHelp(this.GetType().ToString());
            if (nav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
            {
                btn_Backup.Visible = false;
            }
            usrc_NavigationButtons1.Init(nav);
            cmbR_FilePath.RecentItemsFolder = recent_items_folder;
            cmbR_FileName.RecentItemsFolder = recent_items_folder;

            if (m_conData_SQLITE.IsValidDataBaseFile())
            {
                cmbR_FilePath.Text = Path.GetDirectoryName(m_conData_SQLITE.DataBaseFile);
                if (!cmbR_FilePath.Text.EndsWith("\\"))
                {
                    cmbR_FilePath.Text += "\\";
                }
                DataBaseFile_name = Path.GetFileName(m_conData_SQLITE.DataBaseFile);
                cmbR_FileName.Text = DataBaseFile_name;
                
                if (!System.IO.File.Exists(xconData_SQLite.DataBaseFile))
                {
                    if (!m_conData_SQLITE.SQLite_AllwaysCreateNew)
                    {
                        MessageBox.Show(lng.s_File_does_not_exist.s + m_conData_SQLITE.DataBaseFile);
                    }
                }
            }
            else
            {
                //txtFilePath.Text = Application.CommonAppDataPath;
                if (myConnectionName != null)
                {
                    cmbR_FilePath.Text = "C:\\" + myConnectionName + "\\";
                    DataBaseFile_name = myConnectionName + ".sqlite";
                }
                else
                {
                    cmbR_FilePath.Text = "C:\\";
                    DataBaseFile_name = "LocalDB.sqlite";

                }
                cmbR_FileName.Text = DataBaseFile_name;
            }

            this.lbl_FileName.Text = lng.s_FileName.s + ":";
            this.btn_SelectFile.Text = lng.s_FileName.s;
            this.btn_SelectFolder.Text = lng.s_Folder.s;
            this.lbl_Folder.Text = lng.s_Folder.s + ":";
            this.Text = lng.s_SelectSQLiteDataBaseFileName.s;
        }


        private void btn_OK_Click(object sender, EventArgs e)
        {
            Do_OK();
        }

        private void Do_OK()
        {
            m_conData_SQLITE.DataBaseFilePath = this.cmbR_FilePath.Text;
            string DirPath = m_conData_SQLITE.DataBaseFilePath;
            string username = System.Environment.UserDomainName + "\\" + System.Environment.UserName;
            if (Directory.Exists(DirPath))
            {
                System.Security.AccessControl.DirectorySecurity myDirectorySecurity = Directory.GetAccessControl(DirPath);
                myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(username, System.Security.AccessControl.FileSystemRights.FullControl, AccessControlType.Allow));
                //Directory.SetAccessControl(DirPath, myDirectorySecurity);
            }
            else
            {
                DirectoryInfo drinfo = Directory.CreateDirectory(m_conData_SQLITE.DataBaseFilePath);
                if (drinfo != null)
                {
                    System.Security.AccessControl.DirectorySecurity myDirectorySecurity = drinfo.GetAccessControl();

                    myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(username, System.Security.AccessControl.FileSystemRights.FullControl, AccessControlType.Allow));
                    drinfo.SetAccessControl(myDirectorySecurity);
                }
            }
            m_conData_SQLITE.DataBaseFileName = this.cmbR_FileName.Text;
            if (m_conData_SQLITE.IsValidDataBaseFile())
            {
                DataBaseFile_path = cmbR_FilePath.Text;
                this.cmbR_FilePath.Set(DataBaseFile_path);
                DataBaseFile_name = cmbR_FileName.Text;
                this.cmbR_FileName.Set(DataBaseFile_name);
                
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(lng.s_Error.s + ":" + lng.s_FileName.s + ":" + m_conData_SQLITE.DataBaseFile + " " + lng.s_IsNotValid.s + ".");
            }
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
            string sDirectory = cmbR_FilePath.Text;
            string sFileName = null;
            if (Directory.Exists(sDirectory))
            {
                fdlg.InitialDirectory = sDirectory;
            }
            if (fdlg.ShowDialog(this) == DialogResult.OK)
            {
                sFileName = Path.GetFileName(fdlg.FileName);
                this.cmbR_FileName.Text = sFileName;
                string sPath = Path.GetFullPath(fdlg.FileName);
                int i = sPath.LastIndexOf(sFileName);
                if (i>=0)
                {
                    sPath = sPath.Substring(0, i);
                }
                this.cmbR_FilePath.Text = sPath;
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
            if (nav.m_eButtons == NavigationButtons.Navigation.eButtons.PrevNextExit)
            {
                SQLite_info_frm.TopMost = true;
            }
            SQLite_info_frm.ShowDialog(this);
        }

        private void cmbR_FilePath_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl_Folder_Click(object sender, EventArgs e)
        {

        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            Form_Backup_SQLite frm_backup = new Form_Backup_SQLite(m_conData_SQLITE.DataBaseFile,DataBaseFile_name, BackupFolder);
            if (frm_backup.ShowDialog()== DialogResult.OK)
            {
                BackupFolder = frm_backup.BackupFolder;
            }
        }

        private void usrc_NavigationButtons1_ButtonPressed(NavigationButtons.Navigation.eEvent evt)
        {
            nav.eExitResult = evt;
            switch (nav.m_eButtons)
            {
                case NavigationButtons.Navigation.eButtons.OkCancel:
                    switch(evt)
                    {
                        case NavigationButtons.Navigation.eEvent.OK:
                            Do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.CANCEL:
                            DialogResult = DialogResult.Cancel;
                            Close();
                            break;
                    }
                    break;
                case NavigationButtons.Navigation.eButtons.PrevNextExit:
                    switch (evt)
                    {
                        case NavigationButtons.Navigation.eEvent.PREV:
                            DialogResult = DialogResult.Abort;
                            Close();
                            break;
                        case NavigationButtons.Navigation.eEvent.NEXT:
                            Do_OK();
                            break;
                        case NavigationButtons.Navigation.eEvent.EXIT:
                            DialogResult = DialogResult.Cancel;
                            Close();
                            break;
                    }
                    break;
            }

        }
    }
}
