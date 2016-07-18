#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion
using LanguageControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnectionControl40;

namespace DBSync
{
    public partial class Form_DBmanager : Form
    {
        public bool bNewDataBaseCreated = false;
        public string m_BackupFolder = null;
        public enum eResult { DATA_BASE_CHANGED, CANCEL, BACKUP_DONE };
        public eResult m_Result = eResult.CANCEL;
        public DBConnection.eDBType m_DBType = DBConnection.eDBType.SQLITE;
        public Form m_parent_form = null;
        public string m_XmlFileName = null;
        public string m_IniFileFolder = null;
        public string m_DataBaseType = null;
        private bool m_bReset = false;
        private string m_sDataBaseVersion = null;
        private Image m_Image_Cancel = null;

        public Form_DBmanager(Form xparent_form,bool bxReset, string xm_XmlFileName, string xIniFileFolder, string xDataBaseType, string xBackupFolder, string sDataBaseVersion,Image xImage_Cancel)
        {
            InitializeComponent();
            m_parent_form = xparent_form;
            m_XmlFileName = xm_XmlFileName;
            m_IniFileFolder = xIniFileFolder;
            m_DataBaseType = xDataBaseType;
            m_BackupFolder = xBackupFolder;
            m_bReset = bxReset;
            m_sDataBaseVersion = sDataBaseVersion;
            m_Image_Cancel = xImage_Cancel;
            Init();
        }

        private void Init()
        {
            btn_Backup.Visible = false;
            lngRPM.s_Database.Text(this);
            lngRPM.s_SelectDatabase.Text(btn_Change);
            string database_info = "\r\n" + DBSync.ServerType + "\r\n" + lngConn.s_Server.s + ":" + DBSync.DataSource + "\r\n" + lngConn.s_DataBase.s + ":" + DBSync.DataBase +"\r\n"+ lngRPM.s_DataBaseVersion.s +":" + m_sDataBaseVersion;
            lngRPM.s_DatabaseInfo.Text(lbl_DataBaseInfo, database_info);
            if (m_DataBaseType != null)
            {
                if (m_DataBaseType.Equals("SQLITE"))
                {
                    m_DBType = DBConnection.eDBType.SQLITE;
                    btn_Backup.Visible = true;
                }
                else if (m_DataBaseType.Equals("MSSQL"))
                {
                    m_DBType = DBConnection.eDBType.MSSQL;
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
            m_Result = eResult.CANCEL;
        }

        private void btn_Change_Click(object sender, EventArgs e)
        {
            bNewDataBaseCreated = false;
            bool bCanceled = false;
            DBSync.Init(m_parent_form, m_bReset, m_XmlFileName, m_IniFileFolder, ref m_DataBaseType, true,true, m_Image_Cancel, ref bNewDataBaseCreated, ref bCanceled);
            if (bCanceled)
            {
                return;
            }
            Init();
        }

        private void btn_Backup_Click(object sender, EventArgs e)
        {

            DBSync.DB_for_Tangenta.Backup(m_parent_form, DBSync.LocalDB_data_SQLite, ref m_BackupFolder);
        }
    }
}
