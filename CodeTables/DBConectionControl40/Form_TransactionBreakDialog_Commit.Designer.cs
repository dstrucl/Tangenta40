namespace DBConnectionControl40
{
    partial class Form_TransactionBreakDialog_Commit
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
            this.lbl_TransactionName = new System.Windows.Forms.Label();
            this.txt_TransactionName = new System.Windows.Forms.TextBox();
            this.btn_NEXT = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbl_TransactionName
            // 
            this.lbl_TransactionName.AutoSize = true;
            this.lbl_TransactionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TransactionName.Location = new System.Drawing.Point(12, 21);
            this.lbl_TransactionName.Name = "lbl_TransactionName";
            this.lbl_TransactionName.Size = new System.Drawing.Size(142, 20);
            this.lbl_TransactionName.TabIndex = 3;
            this.lbl_TransactionName.Text = "Transaction Name:";
            // 
            // txt_TransactionName
            // 
            this.txt_TransactionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TransactionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TransactionName.Location = new System.Drawing.Point(9, 44);
            this.txt_TransactionName.Name = "txt_TransactionName";
            this.txt_TransactionName.Size = new System.Drawing.Size(779, 26);
            this.txt_TransactionName.TabIndex = 2;
            // 
            // btn_NEXT
            // 
            this.btn_NEXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NEXT.Location = new System.Drawing.Point(676, 5);
            this.btn_NEXT.Name = "btn_NEXT";
            this.btn_NEXT.Size = new System.Drawing.Size(121, 33);
            this.btn_NEXT.TabIndex = 5;
            this.btn_NEXT.Text = "NEXT";
            this.btn_NEXT.UseVisualStyleBackColor = true;
            this.btn_NEXT.Click += new System.EventHandler(this.btn_NEXT_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(-1, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 270);
            this.panel1.TabIndex = 6;
            // 
            // Form_TransactionBreakDialog_Commit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_NEXT);
            this.Controls.Add(this.lbl_TransactionName);
            this.Controls.Add(this.txt_TransactionName);
            this.Name = "Form_TransactionBreakDialog_Commit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction commited";
            this.Load += new System.EventHandler(this.Form_TransactionBreakDialog_Commit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TransactionName;
        private System.Windows.Forms.TextBox txt_TransactionName;
        private System.Windows.Forms.Button btn_NEXT;
        private System.Windows.Forms.Panel panel1;
    }
}