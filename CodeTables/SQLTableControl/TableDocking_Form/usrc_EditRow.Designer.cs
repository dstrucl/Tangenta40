namespace CodeTables.TableDocking_Form
{
    partial class usrc_EditRow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_EditRow));
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.BtnCallSecretaryToWork = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pnl_Editor = new CodeTables.TableDocking_Form.myPanel();
            this.SuspendLayout();
            // 
            // btn_New
            // 
            this.btn_New.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_New.Image = ((System.Drawing.Image)(resources.GetObject("btn_New.Image")));
            this.btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_New.Location = new System.Drawing.Point(5, 27);
            this.btn_New.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(74, 30);
            this.btn_New.TabIndex = 8;
            this.btn_New.Text = "New";
            this.btn_New.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Update.Image = global::CodeTables.Properties.Resources.WriteToDB;
            this.btn_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Update.Location = new System.Drawing.Point(209, 27);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(83, 30);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "Update";
            this.btn_Update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Insert
            // 
            this.btn_Insert.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Insert.Image = ((System.Drawing.Image)(resources.GetObject("btn_Insert.Image")));
            this.btn_Insert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Insert.Location = new System.Drawing.Point(83, 27);
            this.btn_Insert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(122, 30);
            this.btn_Insert.TabIndex = 5;
            this.btn_Insert.Text = "Insert In Data Base";
            this.btn_Insert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Insert.UseVisualStyleBackColor = false;
            this.btn_Insert.Click += new System.EventHandler(this.btnInsertInDataBase_Click);
            // 
            // BtnCallSecretaryToWork
            // 
            this.BtnCallSecretaryToWork.AutoSize = true;
            this.BtnCallSecretaryToWork.Location = new System.Drawing.Point(480, 26);
            this.BtnCallSecretaryToWork.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCallSecretaryToWork.Name = "BtnCallSecretaryToWork";
            this.BtnCallSecretaryToWork.Size = new System.Drawing.Size(233, 31);
            this.BtnCallSecretaryToWork.TabIndex = 6;
            this.BtnCallSecretaryToWork.Text = "Get Random Data Parameters";
            this.BtnCallSecretaryToWork.UseVisualStyleBackColor = true;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Title.Location = new System.Drawing.Point(12, 2);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(46, 18);
            this.lbl_Title.TabIndex = 10;
            this.lbl_Title.Text = "label1";
            // 
            // pnl_Editor
            // 
            this.pnl_Editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Editor.AutoScroll = true;
            this.pnl_Editor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_Editor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Editor.Location = new System.Drawing.Point(1, 59);
            this.pnl_Editor.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_Editor.Name = "pnl_Editor";
            this.pnl_Editor.Size = new System.Drawing.Size(715, 526);
            this.pnl_Editor.TabIndex = 9;
            // 
            // usrc_EditRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.BtnCallSecretaryToWork);
            this.Controls.Add(this.pnl_Editor);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "usrc_EditRow";
            this.Size = new System.Drawing.Size(716, 592);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btn_New;
        internal System.Windows.Forms.Button btn_Update;
        internal System.Windows.Forms.Button btn_Insert;
        private System.Windows.Forms.Button BtnCallSecretaryToWork;
        internal myPanel pnl_Editor;
        private System.Windows.Forms.Label lbl_Title;
    }
}
