﻿namespace SQLTableControl.TableDocking_Form
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
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.BtnCallSecretaryToWork = new System.Windows.Forms.Button();
            this.pnl_Editor = new myPanel();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(4, 22);
            this.btn_New.Margin = new System.Windows.Forms.Padding(2);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(60, 24);
            this.btn_New.TabIndex = 8;
            this.btn_New.Text = "New";
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(188, 22);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(84, 24);
            this.btn_Update.TabIndex = 7;
            this.btn_Update.Text = "Update";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Insert
            // 
            this.btn_Insert.Location = new System.Drawing.Point(76, 22);
            this.btn_Insert.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(105, 24);
            this.btn_Insert.TabIndex = 5;
            this.btn_Insert.Text = "Insert In Data Base";
            this.btn_Insert.Click += new System.EventHandler(this.btnInsertInDataBase_Click);
            // 
            // BtnCallSecretaryToWork
            // 
            this.BtnCallSecretaryToWork.AutoSize = true;
            this.BtnCallSecretaryToWork.Location = new System.Drawing.Point(322, 21);
            this.BtnCallSecretaryToWork.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCallSecretaryToWork.Name = "BtnCallSecretaryToWork";
            this.BtnCallSecretaryToWork.Size = new System.Drawing.Size(175, 25);
            this.BtnCallSecretaryToWork.TabIndex = 6;
            this.BtnCallSecretaryToWork.Text = "Get Random Data Parameters";
            this.BtnCallSecretaryToWork.UseVisualStyleBackColor = true;
            // 
            // pnl_Editor
            // 
            this.pnl_Editor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Editor.AutoScroll = true;
            this.pnl_Editor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnl_Editor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Editor.Location = new System.Drawing.Point(1, 48);
            this.pnl_Editor.Name = "pnl_Editor";
            this.pnl_Editor.Size = new System.Drawing.Size(537, 428);
            this.pnl_Editor.TabIndex = 9;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Title.Location = new System.Drawing.Point(9, 2);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(46, 18);
            this.lbl_Title.TabIndex = 10;
            this.lbl_Title.Text = "label1";
            // 
            // usrc_EditRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Insert);
            this.Controls.Add(this.BtnCallSecretaryToWork);
            this.Controls.Add(this.pnl_Editor);
            this.Name = "usrc_EditRow";
            this.Size = new System.Drawing.Size(537, 481);
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