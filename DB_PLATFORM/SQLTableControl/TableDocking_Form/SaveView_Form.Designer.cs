namespace SQLTableControl.TableDocking_Form
{
    partial class SaveView_Form
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
            this.lnlViewName = new System.Windows.Forms.Label();
            this.chkBoxSetAsDefault = new System.Windows.Forms.CheckBox();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rdblist_Views = new System.Windows.Forms.SelectViewListBox();
            this.SuspendLayout();
            // 
            // lnlViewName
            // 
            this.lnlViewName.Location = new System.Drawing.Point(21, 9);
            this.lnlViewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnlViewName.Name = "lnlViewName";
            this.lnlViewName.Size = new System.Drawing.Size(155, 47);
            this.lnlViewName.TabIndex = 1;
            this.lnlViewName.Text = "label1";
            this.lnlViewName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkBoxSetAsDefault
            // 
            this.chkBoxSetAsDefault.AutoSize = true;
            this.chkBoxSetAsDefault.Location = new System.Drawing.Point(26, 69);
            this.chkBoxSetAsDefault.Name = "chkBoxSetAsDefault";
            this.chkBoxSetAsDefault.Size = new System.Drawing.Size(158, 24);
            this.chkBoxSetAsDefault.TabIndex = 4;
            this.chkBoxSetAsDefault.Text = "chk_SetAsDefault";
            this.chkBoxSetAsDefault.UseVisualStyleBackColor = true;
            // 
            // txtViewName
            // 
            this.txtViewName.Location = new System.Drawing.Point(183, 17);
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.Size = new System.Drawing.Size(341, 26);
            this.txtViewName.TabIndex = 5;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Location = new System.Drawing.Point(222, 350);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(101, 35);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(450, 350);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(108, 35);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rdblist_Views
            // 
            this.rdblist_Views.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdblist_Views.BackColor = System.Drawing.SystemColors.Window;
            this.rdblist_Views.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.rdblist_Views.FormattingEnabled = true;
            this.rdblist_Views.ItemHeight = 23;
            this.rdblist_Views.Location = new System.Drawing.Point(12, 104);
            this.rdblist_Views.Name = "rdblist_Views";
            this.rdblist_Views.Size = new System.Drawing.Size(546, 234);
            this.rdblist_Views.TabIndex = 6;
            this.rdblist_Views.SelectedIndexChanged += new System.EventHandler(this.rdblist_Views_SelectedIndexChanged);
            // 
            // SaveView_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 392);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.rdblist_Views);
            this.Controls.Add(this.txtViewName);
            this.Controls.Add(this.chkBoxSetAsDefault);
            this.Controls.Add(this.lnlViewName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SaveView_Form";
            this.Text = "SaveView_Form";
            this.Load += new System.EventHandler(this.SaveView_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lnlViewName;
        private System.Windows.Forms.CheckBox chkBoxSetAsDefault;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.SelectViewListBox rdblist_Views;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
    }
}