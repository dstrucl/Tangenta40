#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

// -------------------------------------------------------
// LogFile_SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/LogFile_SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LogFile_SqlBuilder.Controls;
using LogFile;
using System.Collections.Generic;

namespace LogFile_SqlBuilder.Forms
{
    /// <summary>
    /// Summary description for frmSqlEditor.
    /// </summary>
    public class frmEditor : frmBaseForm
    {
        public string s_sql_text=null;
        public string s_sql_print = "";

        public string s_sql_MySQL_DECLARE = "";

        string ms_File = null;
        private Button btn_Execute_SQL;
        string ms_sql = null;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmi_File;
        private ToolStripMenuItem tsmi_File_Save;
        private ToolStripMenuItem tsmi_File_Save_As;
        private ToolStripMenuItem tsmi_File_New;
        private ToolStripMenuItem tsmi_File_Open;
        private Button btn_Cancel;
        private CheckBox chkBoxbPreviewSQLBeforeExecution;
        private Button btn_OK;
        private List<Log_SQL_Parameter> m_lSQL_Parameter = null;
        private ToolStripMenuItem tsmi_Params_Insert;
        private ToolStripComboBox tsmi_Params_ComboBox;
        private ToolStripMenuItem tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text;

        public frmEditor(string sql, List<Log_SQL_Parameter> lSQL_Parameter,  string title)
        {
            m_lSQL_Parameter = lSQL_Parameter;
            ms_sql = Functions.ReplaceCRLF(sql);
            InitializeComponent();
            StoreWindowPos = true; // must be set in Constructor AFTER InitializeComponent() !!
            this.Text += "SQL Commad:" + title;
            this.chkBoxbPreviewSQLBeforeExecution.Checked = LogFile.DynSettings.bPreviewSQLBeforeExecution;
        }

        public frmEditor(string ErrorMsg, string Title)
        {
            ms_sql = Functions.ReplaceCRLF(ErrorMsg);
            InitializeComponent();
            StoreWindowPos = true; // must be set in Constructor AFTER InitializeComponent() !!
            this.Text += Title;
            chkBoxbPreviewSQLBeforeExecution.Visible = false;
            //this.chkBoxbPreviewSQLBeforeExecution.Checked = Log_DBConnection.DynSettings.bPreviewSQLBeforeExecution;
        }

        public frmEditor(string s_File)
        {
            ms_File = s_File;

            InitializeComponent();
            StoreWindowPos = true; // must be set in Constructor AFTER InitializeComponent() !!

            this.Text += " version " + Defaults.Version + " - " + s_File;
        }

        protected override void OnLoadDelayed()
        {
            //if (m_lSQL_Parameter != null)
            //{
            //    if (m_lSQL_Parameter.Count > 0)
            //    {
            //        foreach (Log_SQL_Parameter sqlpar in m_lSQL_Parameter)
            //        {
            //            this.tsmi_Params_ComboBox.Items.Add(sqlpar.Name + " DBType=" + sqlpar.dbType.ToString() + " Value = ");//+ CodeTables.Func.sqlpar.Value
            //        }
            //    }
            //}
            rtfBox.ReadOnly = true;
            this.Cursor = Cursors.WaitCursor;

            Parser i_Parser = new Parser();
            if (ms_File != null)
            {
                i_Parser.Parse(Functions.ReadFileIntoString(this, ms_File), true, true);
            }
            else
            {
                i_Parser.Parse(ms_sql, true, true);
            }

            rtfBox.Rtf = i_Parser.GetRtf(rtfBox.Font);

            this.Cursor = Cursors.Arrow;
            rtfBox.ReadOnly = false;
            rtfBox.TextModified = false;
            rtfBox.StatusBar = lblStatus;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (rtfBox.TextModified && frmMsgBox.Ask(this, "Do you want to save your changes?"))
                SaveToFile();

            base.OnClosing(e);
        }

        public bool SaveToFileAs()
        {
            bool bRes = false;
            Parser i_Parser = new Parser();
            rtfBox.ReplaceRtf(i_Parser, true);
            rtfBox.TextModified = false;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "sql files (*.sgl)|*.sql|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string sFullFileName = sfd.FileName;
                bRes = Functions.SaveStringToFile(this, sFullFileName, i_Parser.SQL, Encoding.Unicode);
                this.Text = "File:\"" + sFullFileName + "\"";
                ms_File = sFullFileName;
            }
            return bRes;
        }

        public bool SaveToFile()
        {
            bool bRes = false;
            if (ms_File == null)
            {
                return SaveToFileAs();
            }
            else
            {
                Parser i_Parser = new Parser();
                rtfBox.ReplaceRtf(i_Parser, true);
                rtfBox.TextModified = false;
                bRes = Functions.SaveStringToFile(this, ms_File, i_Parser.SQL, Encoding.Unicode);
            }
            lblStatus.SetTransientText("File saved");
            return bRes;
        }


        private void OnButtonHelp(object sender, System.EventArgs e)
        {
            frmMsgBox.Info(this, "Keyboard shortcuts for SQL editor:\n\n"
                               + "CTRL + H -> Show this help\n"
                               + "CTRL + S -> Save document\n"
                               + "CTRL + A -> Select All\n"
                               + "CTRL + C,X,V -> Copy + Paste\n"
                               + "CTRL + P -> Parse Linebreaks\n"
                               + "CTRL + Z -> Undo\n"
                               + "CTRL + Y -> Redo\n\n"
                               + "CTRL + G -> Goto line\n"
                               + "CTRL + F,R -> Find / Replace text\n"
                               + "F3 -> Find next\n"
                               + "F4 -> Find previous\n");
        }

        private void OnRtfBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt || e.Shift)
                return;

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S: // Save
                        e.Handled = true;
                        SaveToFile();
                        break;

                    case Keys.H: // Help
                        e.Handled = true;
                        OnButtonHelp(sender, e);
                        break;
                }
            }
        }

        #region Windows Form Designer generated code

        private LogFile_SqlBuilder.Controls.RichTextBoxParser rtfBox;
        private LogFile_SqlBuilder.Controls.StatusInfo lblStatus;
        private System.Windows.Forms.Button btnHelp;
        private System.ComponentModel.Container components = null;


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditor));
            this.rtfBox = new LogFile_SqlBuilder.Controls.RichTextBoxParser();
            this.lblStatus = new LogFile_SqlBuilder.Controls.StatusInfo();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btn_Execute_SQL = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_File_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_File_Save_As = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_File_New = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_File_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Params_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Params_ComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.chkBoxbPreviewSQLBeforeExecution = new System.Windows.Forms.CheckBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfBox
            // 
            this.rtfBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfBox.BackColor = System.Drawing.Color.White;
            this.rtfBox.DetectUrls = false;
            this.rtfBox.FirstVisibleLine = 1;
            this.rtfBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfBox.HideSelection = false;
            this.rtfBox.Location = new System.Drawing.Point(10, 27);
            this.rtfBox.Name = "rtfBox";
            this.rtfBox.Size = new System.Drawing.Size(854, 491);
            this.rtfBox.StatusBar = null;
            this.rtfBox.TabIndex = 0;
            this.rtfBox.Text = "";
            this.rtfBox.TextModified = false;
            this.rtfBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnRtfBoxKeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(12, 529);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(853, 17);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(821, 560);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(44, 22);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.OnButtonHelp);
            // 
            // btn_Execute_SQL
            // 
            this.btn_Execute_SQL.Location = new System.Drawing.Point(272, 481);
            this.btn_Execute_SQL.Name = "btn_Execute_SQL";
            this.btn_Execute_SQL.Size = new System.Drawing.Size(139, 22);
            this.btn_Execute_SQL.TabIndex = 4;
            this.btn_Execute_SQL.Text = "Execute SQL Command";
            this.btn_Execute_SQL.UseVisualStyleBackColor = true;
            this.btn_Execute_SQL.Visible = false;
            this.btn_Execute_SQL.Click += new System.EventHandler(this.btn_Execute_SQL_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File,
            this.tsmi_Params_Insert});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            this.tsmi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File_Save,
            this.tsmi_File_Save_As,
            this.tsmi_File_New,
            this.tsmi_File_Open});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(37, 20);
            this.tsmi_File.Text = "File";
            // 
            // tsmi_File_Save
            // 
            this.tsmi_File_Save.Name = "tsmi_File_Save";
            this.tsmi_File_Save.Size = new System.Drawing.Size(114, 22);
            this.tsmi_File_Save.Text = "Save";
            this.tsmi_File_Save.Click += new System.EventHandler(this.tsmi_File_Save_Click);
            // 
            // tsmi_File_Save_As
            // 
            this.tsmi_File_Save_As.Name = "tsmi_File_Save_As";
            this.tsmi_File_Save_As.Size = new System.Drawing.Size(114, 22);
            this.tsmi_File_Save_As.Text = "Save As";
            this.tsmi_File_Save_As.Click += new System.EventHandler(this.tsmi_File_Save_As_Click);
            // 
            // tsmi_File_New
            // 
            this.tsmi_File_New.Name = "tsmi_File_New";
            this.tsmi_File_New.Size = new System.Drawing.Size(114, 22);
            this.tsmi_File_New.Text = "New";
            // 
            // tsmi_File_Open
            // 
            this.tsmi_File_Open.Name = "tsmi_File_Open";
            this.tsmi_File_Open.Size = new System.Drawing.Size(114, 22);
            this.tsmi_File_Open.Text = "Open";
            // 
            // tsmi_Params_Insert
            // 
            this.tsmi_Params_Insert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Params_ComboBox,
            this.tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text});
            this.tsmi_Params_Insert.Name = "tsmi_Params_Insert";
            this.tsmi_Params_Insert.Size = new System.Drawing.Size(58, 20);
            this.tsmi_Params_Insert.Text = "Params";
            // 
            // tsmi_Params_ComboBox
            // 
            this.tsmi_Params_ComboBox.AutoSize = false;
            this.tsmi_Params_ComboBox.Name = "tsmi_Params_ComboBox";
            this.tsmi_Params_ComboBox.Size = new System.Drawing.Size(700, 23);
            // 
            // tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text
            // 
            this.tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text.Name = "tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text";
            this.tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text.Size = new System.Drawing.Size(760, 22);
            this.tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text.Text = "Insert PRINT parameters command_at_the_top_of_the_text";
            this.tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text.Click += new System.EventHandler(this.tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(708, 560);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(94, 22);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // chkBoxbPreviewSQLBeforeExecution
            // 
            this.chkBoxbPreviewSQLBeforeExecution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxbPreviewSQLBeforeExecution.AutoSize = true;
            this.chkBoxbPreviewSQLBeforeExecution.Location = new System.Drawing.Point(12, 566);
            this.chkBoxbPreviewSQLBeforeExecution.Name = "chkBoxbPreviewSQLBeforeExecution";
            this.chkBoxbPreviewSQLBeforeExecution.Size = new System.Drawing.Size(156, 17);
            this.chkBoxbPreviewSQLBeforeExecution.TabIndex = 7;
            this.chkBoxbPreviewSQLBeforeExecution.Text = "Stop Before SQL Execution";
            this.chkBoxbPreviewSQLBeforeExecution.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.Location = new System.Drawing.Point(608, 560);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(87, 22);
            this.btn_OK.TabIndex = 8;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frmEditor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(881, 595);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.chkBoxbPreviewSQLBeforeExecution);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Execute_SQL);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.rtfBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " SQL Editor";
            this.TopMost = false;
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        private void btn_Execute_SQL_Click(object sender, EventArgs e)
        {
            //clsNBXMLInOut NBXMLInOut = (clsNBXMLInOut)this.Tag;
            //string ErrMsg=" ";
            //Parser i_Parser = new Parser();
            //rtfBox.ReplaceRtf(i_Parser, true);
            //if (NBXMLInOut.mDoc.xConn.ExecuteNonQuerySQL(i_Parser.SQL,ref  ErrMsg))
            //{
            //    lblStatus.SetTransientText("Command "+ mCommandName + " executed OK.");
            //}
            //else
            //{
            //    lblStatus.SetTransientText(ErrMsg);
            //}
        }

        private void tsmi_File_Save_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void tsmi_File_Save_As_Click(object sender, EventArgs e)
        {
            SaveToFileAs();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            LogFile.DynSettings.bPreviewSQLBeforeExecution = this.chkBoxbPreviewSQLBeforeExecution.Checked;
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            LogFile.DynSettings.bPreviewSQLBeforeExecution = this.chkBoxbPreviewSQLBeforeExecution.Checked;
            this.s_sql_text = rtfBox.Text;
            Close();
            DialogResult = DialogResult.OK;
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            if (m_lSQL_Parameter != null)
            {
                if (m_lSQL_Parameter.Count > 0)
                {
                    int iCount = 0;
                    foreach (Log_SQL_Parameter sqlpar in m_lSQL_Parameter)
                    {
                        s_sql_MySQL_DECLARE += "\nSET " + sqlpar.Name + " = " + ConevrtToString_MySQLdbTypeValue(sqlpar) + ";";

                        if (sqlpar.dbType == System.Data.SqlDbType.VarBinary)
                        {
                            s_sql_print += "\nPRINT N'" + sqlpar.Name + " = Varbinary types (..,ImageType,..) can not be print out '";
                        }
                        else
                        {
                            s_sql_print += "\nPRINT N'" + sqlpar.Name + " = '  +  CONVERT(VARCHAR(MAX)," + sqlpar.Name + ")";
                        }

                        string s = sqlpar.Name + " DBType=" + sqlpar.dbType.ToString() + " Value = " + ConvertAnyObjectToString(sqlpar.Value);

                        this.tsmi_Params_ComboBox.Items.Add(s);//+ CodeTables.Func.sqlpar.Value
                        iCount++;
                    }
                    this.tsmi_Params_ComboBox.Text = iCount.ToString() + " parameters in SQL command";
                    tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text.Enabled = true;
                    return;
                }

            }
            tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text.Enabled = false;
            this.tsmi_Params_ComboBox.Text = "No parameters in SQL command";
        }

        private string ConevrtToString_MySQLdbTypeValue(Log_SQL_Parameter sqlpar)
        {
            return "";
        }

        private string ConvertAnyObjectToString(object p)
        {
            try
            {
                return Convert.ToString(p);
            }
            catch (Exception ex)
            {
                return "Error Value of type = " + p.GetType().ToString()+ " Exception="+ex.Message;
            }

        }

        private void tsmi_Params_Insert_PRINT_parameters_command_at_the_top_of_the_text_Click(object sender, EventArgs e)
        {
            Parser i_Parser = new Parser();

            string sql = s_sql_print + "\n" + ms_sql;

            ms_sql = sql;

            i_Parser.Parse(ms_sql, true, true);

            rtfBox.Rtf = i_Parser.GetRtf(rtfBox.Font);
            
        }


    }
}
