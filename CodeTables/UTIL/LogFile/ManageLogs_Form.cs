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
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace LogFile
{
    public partial class ManageLogs_Form : Form
    {
        Image Image_Cancel = null;
        public ManageLogs_Form(Image xImage_Cancel)
        {
            InitializeComponent();
            Image_Cancel = xImage_Cancel;
            if (LogFile.m_eType == LogFile.eType.CLIENT)
            {
                this.btn_Log2DB.Enabled = false;
                this.chk_WriteLog2DB_on_exit.Enabled = false;
            }
            else
            {
                this.btn_Log2DB.Enabled = true;
                this.chk_WriteLog2DB_on_exit.Enabled = true;
            }
            if (Image_Cancel!=null)
            {
                btnCancel.Text = "";
                btnCancel.Image = Image_Cancel;
                btnCancel.ImageAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                btnCancel.Text = Language.sbtnCancel[Language.id];
            }
        }


        private void ManageLogs_Form_Load(object sender, EventArgs e)
        {
            txtLogFile.Text = LogFile.Log_File;
            this.Text = Language.slLogManager[Language.id];
            lbl_LogFileName.Text = Language.slLogFileName[Language.id];
            lLogFile.Text = Language.slLogFile[Language.id];
            btnBrowse.Text = Language.sbtnBrowse[Language.id];
            btn_View.Text = Language.sbtn_View[Language.id];
            lbl_LogFolder.Text = Language.slbl_LogFolder[Language.id];
            btn_Delete.Text = Language.sbtn_Delete[Language.id];
            btn_SaveSettings.Text = Language.sbtn_SaveSettings[Language.id];
            chk_WriteLog2DB_on_exit.Text = Language.s_chk_WriteLog2DB_on_exit[Language.id];
            lbl_MutexTimeout.Text = Language.s_lbl_MutexTimeout[Language.id];
  
            lLogLevel.Text = Language.slLogLevel[Language.id];
            nmUpDown_LogLevel.Value = Convert.ToDecimal(LogFile.LogLevel);
            chk_WriteLog2DB_on_exit.Checked = LogFile.WriteLog2DBOnProgramExit;
            if (chk_WriteLog2DB_on_exit.Checked)
            {
                this.btn_Log2DB.Enabled = true;
            }
            else
            {
                this.btn_Log2DB.Enabled = false;
            }

            txt_LogFileName.Text = LogFile.LogFileName;
            txt_LogFolder.Text = LogFile.LogFolder;
            int icount = LogFile.list_exlog.Count;
            if (icount >0)
            {
                txt__ExceptionLogs.Text = "Number of exception Logs = " + icount.ToString() + "\r\n";
                int iline = 1;
                foreach (CanNotWriteLogClass exl in LogFile.list_exlog)
                {
                    txt__ExceptionLogs.Text += iline.ToString() + ":" + exl.slog + "\r\n";
                    iline++;
                }
             
            }
            else
            {
                txt__ExceptionLogs.Text = " No Exception Logs";
            }
        }

        private bool SaveSettings()
        {
            if (MessageBox.Show(this,Language.s_SaveLogSettings[Language.id], "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Settings.LogFolder = txt_LogFolder.Text;
                Settings.LogFile = txt_LogFileName.Text;
                Settings.LogLevel = Convert.ToInt32(nmUpDown_LogLevel.Value);
                Settings.MutexTimeout = Convert.ToInt32(nmUpDown_MutexTimeout.Value);
                LogFile.WriteLog2DBOnProgramExit = chk_WriteLog2DB_on_exit.Checked; // write Settings.Log2DB in property
                Settings.Save();
                LogFile.SetLogFile();
                return true;
            }
            else
            {
                return false;
            }
        }

    private void btn_SaveSettings_Click(object sender, EventArgs e)
        {
            //Properties.Log.Default.LogFile = txtLogFile.Text;
            SaveSettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txt_LogFolder.Text = fbd.SelectedPath;
                LogFile.LogFolder = txt_LogFolder.Text;
                if (LogFile.LogFolder[LogFile.LogFolder.Length - 1] != '\\')
                {
                    LogFile.LogFolder += "\\";
                }
                LogFile.Log_File = LogFile.LogFolder + txt_LogFileName.Text;
                txtLogFile.Text = LogFile.Log_File;
            }
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(txtLogFile.Text))
                {
                    String s = System.IO.File.ReadAllText(txtLogFile.Text);
                    TextEditorDialog LogViewDlg = new TextEditorDialog(s, txtLogFile.Text, this);
                    LogViewDlg.Show();
                }
                else
                {
                    MessageBox.Show(LanguageControl.lngRPM.s_LogFile.s + "\"" + txtLogFile.Text + "\" " + LanguageControl.lngRPM.s_DoesNotExistOrWasDeleted.s);
                }
            }
            catch (Exception e1)
            {
                Error.Show("Error:" + e1.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (File.Exists(LogFile.Log_File))
            {
                if (MessageBox.Show(this, "Are you sure to delete log file ?\r\n File: \"" + LogFile.Log_File + "\"", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        File.Delete(LogFile.Log_File);
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(this, "ERROR deleting Log file, Exception = " + Ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Log file :\"" + LogFile.Log_File +"\" does not exist.");
            }
        }

        private void btn_Log2DB_Click(object sender, EventArgs e)
        {
            Log2DB_Form log2db_frm = new Log2DB_Form();
            log2db_frm.ShowDialog();
        }

        private void chk_WriteLog2DB_on_exit_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_WriteLog2DB_on_exit.Checked)
            {
                this.btn_Log2DB.Enabled = true;
                LogFile.WriteLog2DBOnProgramExit = true;
            }
            else
            {
                this.btn_Log2DB.Enabled = false;
                LogFile.WriteLog2DBOnProgramExit = false;
            }
        }

        private void nmUpDown_LogLevel_ValueChanged(object sender, EventArgs e)
        {
            int iLevel = Convert.ToInt32(nmUpDown_LogLevel.Value);
            lst_ActiveLogLevels.Items.Clear();
            switch (iLevel)
            {
                case 0:
                    lst_ActiveLogLevels.Items.Add(LanguageControl.lngRPM.s_DontWriteLogs.s);
                    break;

                case 1:
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_RUN_RELEASE);
                    break;
                case 2:
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_RUN_RELEASE);
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_DEBUG_RELEASE);
                    break;
                case 3:
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_RUN_RELEASE);
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_DEBUG_RELEASE);
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_DEBUG_MESSAGE_BOX);
                    break;

                default:
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_RUN_RELEASE);
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_DEBUG_RELEASE);
                    lst_ActiveLogLevels.Items.Add(LogFile.sLOG_LEVEL_DEBUG_MESSAGE_BOX);
                    break;
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
