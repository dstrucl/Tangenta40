namespace DBConnectionControl40
{
    partial class Form_TransactionBreakDialog_Activate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TransactionBreakDialog_Activate));
            this.txt_TransactionName = new System.Windows.Forms.TextBox();
            this.lbl_TransactionName = new System.Windows.Forms.Label();
            this.fsttxt_SQLCommand = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lbl_FirstSQLCommand = new System.Windows.Forms.Label();
            this.btn_NEXT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fsttxt_SQLCommand)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_TransactionName
            // 
            this.txt_TransactionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TransactionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TransactionName.Location = new System.Drawing.Point(4, 46);
            this.txt_TransactionName.Name = "txt_TransactionName";
            this.txt_TransactionName.Size = new System.Drawing.Size(746, 26);
            this.txt_TransactionName.TabIndex = 0;
            // 
            // lbl_TransactionName
            // 
            this.lbl_TransactionName.AutoSize = true;
            this.lbl_TransactionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TransactionName.Location = new System.Drawing.Point(5, 23);
            this.lbl_TransactionName.Name = "lbl_TransactionName";
            this.lbl_TransactionName.Size = new System.Drawing.Size(142, 20);
            this.lbl_TransactionName.TabIndex = 1;
            this.lbl_TransactionName.Text = "Transaction Name:";
            // 
            // fsttxt_SQLCommand
            // 
            this.fsttxt_SQLCommand.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fsttxt_SQLCommand.AutoIndentCharsPatterns = "";
            this.fsttxt_SQLCommand.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fsttxt_SQLCommand.BackBrush = null;
            this.fsttxt_SQLCommand.CharHeight = 14;
            this.fsttxt_SQLCommand.CharWidth = 8;
            this.fsttxt_SQLCommand.CommentPrefix = "--";
            this.fsttxt_SQLCommand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fsttxt_SQLCommand.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fsttxt_SQLCommand.IsReplaceMode = false;
            this.fsttxt_SQLCommand.Language = FastColoredTextBoxNS.Language.SQL;
            this.fsttxt_SQLCommand.LeftBracket = '(';
            this.fsttxt_SQLCommand.Location = new System.Drawing.Point(9, 99);
            this.fsttxt_SQLCommand.Name = "fsttxt_SQLCommand";
            this.fsttxt_SQLCommand.Paddings = new System.Windows.Forms.Padding(0);
            this.fsttxt_SQLCommand.RightBracket = ')';
            this.fsttxt_SQLCommand.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fsttxt_SQLCommand.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fsttxt_SQLCommand.ServiceColors")));
            this.fsttxt_SQLCommand.Size = new System.Drawing.Size(741, 333);
            this.fsttxt_SQLCommand.TabIndex = 2;
            this.fsttxt_SQLCommand.Zoom = 100;
            // 
            // lbl_FirstSQLCommand
            // 
            this.lbl_FirstSQLCommand.AutoSize = true;
            this.lbl_FirstSQLCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FirstSQLCommand.Location = new System.Drawing.Point(12, 75);
            this.lbl_FirstSQLCommand.Name = "lbl_FirstSQLCommand";
            this.lbl_FirstSQLCommand.Size = new System.Drawing.Size(167, 20);
            this.lbl_FirstSQLCommand.TabIndex = 3;
            this.lbl_FirstSQLCommand.Text = "First SQL comand text";
            // 
            // btn_NEXT
            // 
            this.btn_NEXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NEXT.Location = new System.Drawing.Point(629, 7);
            this.btn_NEXT.Name = "btn_NEXT";
            this.btn_NEXT.Size = new System.Drawing.Size(121, 33);
            this.btn_NEXT.TabIndex = 4;
            this.btn_NEXT.Text = "NEXT";
            this.btn_NEXT.UseVisualStyleBackColor = true;
            this.btn_NEXT.Click += new System.EventHandler(this.btn_NEXT_Click);
            // 
            // Form_TransactionBreakDialog_Activate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 434);
            this.Controls.Add(this.btn_NEXT);
            this.Controls.Add(this.lbl_FirstSQLCommand);
            this.Controls.Add(this.fsttxt_SQLCommand);
            this.Controls.Add(this.lbl_TransactionName);
            this.Controls.Add(this.txt_TransactionName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_TransactionBreakDialog_Activate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Activated";
            ((System.ComponentModel.ISupportInitialize)(this.fsttxt_SQLCommand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_TransactionName;
        private System.Windows.Forms.Label lbl_TransactionName;
        private FastColoredTextBoxNS.FastColoredTextBox fsttxt_SQLCommand;
        private System.Windows.Forms.Label lbl_FirstSQLCommand;
        private System.Windows.Forms.Button btn_NEXT;
    }
}