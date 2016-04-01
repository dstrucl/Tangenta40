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

namespace UpgradeDB
{
    public partial class Form_Upgrade_inThread : Form
    {
        private int m_j;
        private UpgradeDB_inThread m_Upgrade_inThread = null;
        private UpgradeDB_inThread.Upgrade[] upgradeArray;
        ThreadProcessor.ThreadP thread = null;
        decimal dverOld = 0;
        decimal dverNew = 0;
        string sVerOld = null;
        string sVerNew = null;
        string sItem = null;
        long MessageID = 0;
        ThreadProcessor.ThreadP_Message m_ThreadP_Message = null;
        ThreadProcessor.ThreadP2Ctrl_Message m_ThreadP2Ctrl_Message = null;
        int m_iCurrentItem = -1;
        private bool bError = false;
        private string m_BackupFileName = null;

        public Form_Upgrade_inThread(UpgradeDB_inThread xUpgrade_inThread, UpgradeDB_inThread.Upgrade[] upgradeArray, int j, string xBackupFileName)
        {
            InitializeComponent();
            m_Upgrade_inThread = xUpgrade_inThread;
            this.upgradeArray = upgradeArray;
            this.m_j = j;
            m_BackupFileName = xBackupFileName;
            thread = new ThreadProcessor.ThreadP();
        }

        private bool DB_Backup()
        {
            return DBSync.DBSync.DB_for_Tangenta.Backup(m_BackupFileName);
        }

        private bool DB_Restore()
        {
            if (File.Exists(m_BackupFileName))
            {
                return DBSync.DBSync.DB_for_Tangenta.Restore(m_BackupFileName);
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:DB_Restore:Backup file=\"" + m_BackupFileName + "\" not exists!");
                return false;
            }
        }

        private bool DB_Backup_delete()
        {
            if (File.Exists(m_BackupFileName))
            {
                try
                {
                    File.Delete(m_BackupFileName);
                    return true;
                }
                catch (Exception ex)
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:DB_Backup_delete:Can not delete backup file=\"" + m_BackupFileName + "\"\r\nException="+ex.Message);
                    return false;
                }
            }
            else
            {
                LogFile.Error.Show("ERROR:usrc_Upgrade:DB_Backup_delete:Backup file=\"" + m_BackupFileName + "\" not exists!");
                return false;
            }
        }

        private void Form_Upgrade_Load(object sender, EventArgs e)
        {
            if (DB_Backup())
            {
                string Err = null;
                if (!thread.Start(100, null, null, 200, ref Err))
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Form_Upgrade_Load:thread not started!");
                    this.Close();
                    DialogResult = DialogResult.Abort;
                }
                timer_GetMessage.Enabled = true;
                SetVersionItem();
                m_iCurrentItem = this.listBox1.Items.Add(sItem);
                m_ThreadP_Message = new ThreadProcessor.ThreadP_Message(MessageID, ThreadProcessor.ThreadP_Message.eMessage.TASK, upgradeArray[m_j].procedure, null);
                thread.message_box.Post(m_ThreadP_Message);
                timer_GetMessage.Enabled = true;
            }
            else
            {
                this.Close();
                DialogResult = DialogResult.Abort;
            }

        }

        private void SetVersionItem()
        {
            string sver = upgradeArray[m_j].DBVersion;
            sver = sver.Replace(".", "");
            try
            {
                dverOld = Convert.ToDecimal(sver)/100.0M;
            }
            catch
            {
                sver = upgradeArray[m_j].DBVersion.Replace('.', ',');
                try
                {
                    dverOld = Convert.ToDecimal(sver);
                }
                catch
                {
                    LogFile.Error.Show("ERROR:usrc_Upgrade:Form_Upgrade_Load:Wrong format for:'" + upgradeArray[m_j].DBVersion + "' Version format: ##.##");
                    this.Close();
                    DialogResult = DialogResult.Abort;
                }
            }
            dverNew = dverOld + 0.01M;
            sVerOld = dverOld.ToString("0.##");
            sVerNew = dverNew.ToString("0.##");
            sItem = "Posodobljam bazo iz verzije " + sVerOld + " na verzijo " + sVerNew;

        }
        private void timer_GetMessage_Tick(object sender, EventArgs e)
        {
            if (m_ThreadP2Ctrl_Message == null)
            {
                m_ThreadP2Ctrl_Message = new ThreadProcessor.ThreadP2Ctrl_Message(0, ThreadProcessor.ThreadP2Ctrl_Message.eMessage.NONE, null, null, null);
            }
            
            switch (thread.m_ThreadP2Ctrl_MessageBox.Get(ref m_ThreadP2Ctrl_Message))
            {
                case ThreadProcessor.Result_MessageBox_Get.OK:
                    if (m_ThreadP2Ctrl_Message.Message == ThreadProcessor.ThreadP2Ctrl_Message.eMessage.START)
                    {
                        this.listBox1.Items[m_iCurrentItem] = sItem + " START";
                        break;
                    }
                    this.listBox1.Items[m_iCurrentItem] = sItem + " OK";
                    if (m_j< upgradeArray.Length-1)
                    {
                        m_j++;
                        SetVersionItem();
                        m_iCurrentItem = this.listBox1.Items.Add(sItem);
                        MessageID++;
                        m_ThreadP_Message.Set(MessageID, ThreadProcessor.ThreadP_Message.eMessage.TASK, upgradeArray[m_j].procedure, null);
                        thread.message_box.Post(m_ThreadP_Message);
                    }
                    else
                    {
                        this.listBox1.Items[m_iCurrentItem] = sItem + " OK";
                        this.listBox1.Items.Add("KONČANO!");
                        thread.End();
                        btn_Cancel.Visible = true;
                        btn_Cancel.Enabled = true;
                    }
                    break;
                case ThreadProcessor.Result_MessageBox_Get.ERROR:
                    string sErr = "";
                    if (m_ThreadP2Ctrl_Message.ErrorMessage!=null)
                    {
                        sErr = m_ThreadP2Ctrl_Message.ErrorMessage;
                    }
                    this.listBox1.Items[m_iCurrentItem] = sItem + " ->"+ sErr;
                    this.Refresh();
                    thread.End();
                    btn_Cancel.Visible = true;
                    btn_Cancel.Enabled = true;
                    bError = true;
                    break;
                case ThreadProcessor.Result_MessageBox_Get.TIMEOUT:
                    this.listBox1.Items[m_iCurrentItem] = sItem + " ERROR:TIMEOUT";
                    thread.End();
                    btn_Cancel.Visible = true;
                    btn_Cancel.Enabled = true;
                    bError = true;
                    break;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (DB_Restore())
            {
                this.DB_Backup_delete();
            }
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
