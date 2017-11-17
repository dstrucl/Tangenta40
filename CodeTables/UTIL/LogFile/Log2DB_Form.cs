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
using System.IO;

namespace LogFile
{
    public partial class Log2DB_Form : Form
    {
        public string col_select = "Select";
        public string col_Description = "Description";
        public string col_Content = "Content";
        DataTable dtAttachments = new DataTable();
        string[] LogFile_Lines = null;
        int iNumberOfLines = 0;
        int LogFile_id = -1;
        string LogFilePath = null;
        public Log2DB_Form()
        {
            InitializeComponent();
            LogFilePath = LogFile.LogFolder + LogFile.LogFileName;
            this.txtLogFile.Text = LogFilePath;
            this.txt_ConnectionString.Text = LogFile.m_LogDB_con.ConnectionString;
            this.Text = lng.s_ImportLogFileToDatabase.s;
            this.btn_View.Text = lng.s_View.s;
            this.lbl_Description.Text = lng.s_Description.s;
            this.lbl_LogFile.Text = lng.s_LogFile.s;
            this.lbl_LogFile_Lines.Text = lng.s_LogFile_Lines.s;
            this.lbl_ConnectionString.Text = lng.s_ConnectionToLogFileDataBase.s;
            this.btn_Write2DB.Text = lng.s_Write2DB.s;
            this.btn_Cancel.Text = lng.s_Cancel.s;
            this.btn_Attachment.Text = lng.s_Add_Picture.s;


            DataColumn dcol_select = new DataColumn(col_select, typeof(bool));
            dtAttachments.Columns.Add(dcol_select);
            DataColumn dcol_description = new DataColumn(col_Description, typeof(string));
            dtAttachments.Columns.Add(dcol_description);
            DataColumn dcol_Content = new DataColumn(col_Content, typeof(Image));
            dtAttachments.Columns.Add(dcol_Content);
            dgv_Attachments.DataSource = dtAttachments;
            Init();
        }

        public void Init()
        {
            try
            {
                if (!File.Exists(LogFilePath))
                {
                    // write to Logfile to create it
                    LogFile.Write(LogFile.LOG_LEVEL_RUN_RELEASE, "L1", "START 1 LogFile  that not exists:\"" + LogFilePath + "\"!");
                }

                LogFile_Lines = File.ReadAllLines(this.txtLogFile.Text);
                iNumberOfLines = LogFile_Lines.Count();
                this.txt_NumberOfLines.Text = iNumberOfLines.ToString();
            }
            catch (Exception ex)
            {
                Error.Show("ERROR: Can not read all lines of :\"" + this.txtLogFile.Text + "\"\r\nException = " + ex.Message);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Write2DB_Click(object sender, EventArgs e)
        {
            string Err = null;
            LogFile.WriteLog2DB(LogFile.UserName, this.txt_Description.Text,ref LogFile_id);
            if (LogFile_id >= 0)
            {
                foreach (DataRow dr in dtAttachments.Rows)
                {
                    bool bSelect = (bool)dr[col_select];
                    if (bSelect)
                    {
                        Image img = (Image)dr[col_Content];
                        string sDescription = (string)dr[col_Description];
                        byte[] data = ConvertImageToByteArray(img, System.Drawing.Imaging.ImageFormat.Jpeg);
                        if (!InsertAttachment2LogFile(data, LogFile_id, "Picture", sDescription, ref Err))
                        {
                            Error.Show("ERROR:Can not insert attachment to LogFile database!");
                        }
                    }
                }
                Init();
            }
            
        }

        private void btn_Attachment_Click(object sender, EventArgs e)
        {
            int iAttachmentCount = this.dgv_Attachments.Rows.Count;
            LogAttachments_Form log_attachment_form = new LogAttachments_Form(iAttachmentCount);
            if (log_attachment_form.ShowDialog() == DialogResult.OK)
            {

                DataRow dr = dtAttachments.NewRow();
                dr[col_select] = true;
                dr[col_Description] = log_attachment_form.Description;
                dr[col_Content] = log_attachment_form.clipboard_image;
                dtAttachments.Rows.Add(dr);
            }
        }

        private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,
                                       System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

        //Upload image to database
        public bool InsertAttachment2LogFile(byte[] data, int LogFile_id, string sAttachmentType, string sDescription, ref string Err)
        {
            object result = new object();
            List<Log_SQL_Parameter> sql_params = new List<Log_SQL_Parameter>();
            Log_SQL_Parameter parAttachment = new Log_SQL_Parameter();
            parAttachment.dbType = System.Data.SqlDbType.Image;
            parAttachment.size = data.Length;
            parAttachment.Name = "@parAttachment";
            parAttachment.IsOutputParameter = false;
            parAttachment.Value = data;
            sql_params.Add(parAttachment);

            Log_SQL_Parameter parDescription = new Log_SQL_Parameter();
            parDescription.dbType = System.Data.SqlDbType.NVarChar;
            parDescription.size = 2000;
            parDescription.Name = "@parDescription";
            parDescription.IsOutputParameter = false;
            parDescription.Value = sDescription;
            sql_params.Add(parDescription);


            string sql = @"DECLARE @AttachmentType_id int
                           set @AttachmentType_id = null
                           select @AttachmentType_id = lgfat.id from dbo.LogFile_Attachment_Type lgfat where lgfat.Attachment_type ='"+sAttachmentType+@"'
                           if (@AttachmentType_id is null)
                           begin
                                insert into dbo.LogFile_Attachment_Type
                                (
                                    Attachment_type
                                )
                                values
                                (
                                   '"+sAttachmentType+@"'
                                )
                                set @AttachmentType_id =  IDENT_CURRENT('LogFile_Attachment_Type')
                           end
                           insert into dbo.LogFile_Attachment
                           (
                            LogFile_id,
                            LogFile_Attachment_Type_id,
                            Attachment,
                            Description
                            )
                            values
                            (
                            " + LogFile_id.ToString() +@",
                            @AttachmentType_id,
                            @parAttachment,
                            @parDescription
                            )
                            ";
            if (LogFile.m_LogDB_con.ExecuteNonQuerySQL(sql, sql_params, ref result, ref Err))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txt_NumberOfLines_TextChanged(object sender, EventArgs e)
        {

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
                    this.txt_NumberOfLines.Text = "0";
                    MessageBox.Show(lng.s_LogFile.s + "\"" + txtLogFile.Text + "\" " + lng.s_DoesNotExistOrWasDeleted.s);
                }

            }
            catch (Exception e1)
            {
                Error.Show("Error:" + e1.Message);
            }

        }

        private void btn_LogFileDB_Analyzer_Click(object sender, EventArgs e)
        {
            LogFileAnalyzer_Form logfile_analyzer_frm = new LogFileAnalyzer_Form();
            logfile_analyzer_frm.ShowDialog();
        }

    }
}
