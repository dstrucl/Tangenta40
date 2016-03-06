namespace CodeTables
{
    partial class usrc_RowReferencedFromTable_List_Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_RowReferencedFromTable_List_Dialog));
            this.pnl_usrc_RowReferencedTable_List = new System.Windows.Forms.Panel();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_usrc_RowReferencedTable_List
            // 
            this.pnl_usrc_RowReferencedTable_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_usrc_RowReferencedTable_List.AutoScroll = true;
            this.pnl_usrc_RowReferencedTable_List.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_usrc_RowReferencedTable_List.Location = new System.Drawing.Point(4, 104);
            this.pnl_usrc_RowReferencedTable_List.Name = "pnl_usrc_RowReferencedTable_List";
            this.pnl_usrc_RowReferencedTable_List.Size = new System.Drawing.Size(849, 293);
            this.pnl_usrc_RowReferencedTable_List.TabIndex = 0;
            // 
            // btn_Yes
            // 
            this.btn_Yes.Location = new System.Drawing.Point(90, 72);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(67, 28);
            this.btn_Yes.TabIndex = 2;
            this.btn_Yes.Text = "Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.Location = new System.Drawing.Point(4, 72);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(67, 28);
            this.btn_No.TabIndex = 1;
            this.btn_No.Text = "No";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Message.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Message.Location = new System.Drawing.Point(6, 1);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(847, 68);
            this.lbl_Message.TabIndex = 3;
            this.lbl_Message.Text = "label1";
            // 
            // usrc_RowReferencedFromTable_List_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 401);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.btn_No);
            this.Controls.Add(this.btn_Yes);
            this.Controls.Add(this.pnl_usrc_RowReferencedTable_List);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "usrc_RowReferencedFromTable_List_Dialog";
            this.Text = "usrc_RowReferencedFromTable_List_Dialog";
            this.Load += new System.EventHandler(this.usrc_RowReferencedFromTable_List_Dialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_usrc_RowReferencedTable_List;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.Label lbl_Message;
    }
}