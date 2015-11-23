namespace SQLTableControl.TableDocking_Form
{
    partial class SelectView_Form
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
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.lnlViewName = new System.Windows.Forms.Label();
            this.chkBoxSetAsDefault = new System.Windows.Forms.CheckBox();
            this.rdblist_Views = new System.Windows.Forms.SelectViewListBox();
            this.SuspendLayout();
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.Location = new System.Drawing.Point(119, 383);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(101, 35);
            this.btn_Select.TabIndex = 7;
            this.btn_Select.Text = "Select";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(308, 383);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(108, 35);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txtViewName
            // 
            this.txtViewName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViewName.Location = new System.Drawing.Point(195, 284);
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.ReadOnly = true;
            this.txtViewName.Size = new System.Drawing.Size(221, 26);
            this.txtViewName.TabIndex = 10;
            // 
            // lnlViewName
            // 
            this.lnlViewName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnlViewName.Location = new System.Drawing.Point(13, 276);
            this.lnlViewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnlViewName.Name = "lnlViewName";
            this.lnlViewName.Size = new System.Drawing.Size(175, 47);
            this.lnlViewName.TabIndex = 9;
            this.lnlViewName.Text = "label1";
            this.lnlViewName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkBoxSetAsDefault
            // 
            this.chkBoxSetAsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxSetAsDefault.AutoSize = true;
            this.chkBoxSetAsDefault.Location = new System.Drawing.Point(225, 336);
            this.chkBoxSetAsDefault.Name = "chkBoxSetAsDefault";
            this.chkBoxSetAsDefault.Size = new System.Drawing.Size(150, 24);
            this.chkBoxSetAsDefault.TabIndex = 11;
            this.chkBoxSetAsDefault.Text = "Select as Default";
            this.chkBoxSetAsDefault.UseVisualStyleBackColor = true;
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
            this.rdblist_Views.Location = new System.Drawing.Point(12, 24);
            this.rdblist_Views.Name = "rdblist_Views";
            this.rdblist_Views.Size = new System.Drawing.Size(402, 234);
            this.rdblist_Views.TabIndex = 6;
            this.rdblist_Views.SelectedIndexChanged += new System.EventHandler(this.rdblist_Views_SelectedIndexChanged);
            // 
            // SelectView_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 430);
            this.Controls.Add(this.chkBoxSetAsDefault);
            this.Controls.Add(this.txtViewName);
            this.Controls.Add(this.lnlViewName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.rdblist_Views);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SelectView_Form";
            this.Text = "SaveView_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.Label lnlViewName;
        private System.Windows.Forms.CheckBox chkBoxSetAsDefault;
        private System.Windows.Forms.SelectViewListBox rdblist_Views;
    }
}