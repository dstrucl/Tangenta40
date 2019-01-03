namespace TransactionLog
{
    partial class usrc_SQL_Parameter
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
            this.lbl_ParameterName = new System.Windows.Forms.Label();
            this.txt_SQL_ParameterName = new System.Windows.Forms.TextBox();
            this.lbl_SQL_ParameterTYPE = new System.Windows.Forms.Label();
            this.txt_SQL_ParameterType = new System.Windows.Forms.TextBox();
            this.txt_SQL_ParameterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_ParameterName
            // 
            this.lbl_ParameterName.AutoSize = true;
            this.lbl_ParameterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ParameterName.Location = new System.Drawing.Point(9, 0);
            this.lbl_ParameterName.Name = "lbl_ParameterName";
            this.lbl_ParameterName.Size = new System.Drawing.Size(162, 16);
            this.lbl_ParameterName.TabIndex = 0;
            this.lbl_ParameterName.Text = "SQL Parameter Name:";
            // 
            // txt_SQL_ParameterName
            // 
            this.txt_SQL_ParameterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SQL_ParameterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SQL_ParameterName.Location = new System.Drawing.Point(3, 19);
            this.txt_SQL_ParameterName.Name = "txt_SQL_ParameterName";
            this.txt_SQL_ParameterName.ReadOnly = true;
            this.txt_SQL_ParameterName.Size = new System.Drawing.Size(615, 22);
            this.txt_SQL_ParameterName.TabIndex = 1;
            // 
            // lbl_SQL_ParameterTYPE
            // 
            this.lbl_SQL_ParameterTYPE.AutoSize = true;
            this.lbl_SQL_ParameterTYPE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SQL_ParameterTYPE.Location = new System.Drawing.Point(0, 50);
            this.lbl_SQL_ParameterTYPE.Name = "lbl_SQL_ParameterTYPE";
            this.lbl_SQL_ParameterTYPE.Size = new System.Drawing.Size(48, 16);
            this.lbl_SQL_ParameterTYPE.TabIndex = 2;
            this.lbl_SQL_ParameterTYPE.Text = "Type:";
            // 
            // txt_SQL_ParameterType
            // 
            this.txt_SQL_ParameterType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SQL_ParameterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SQL_ParameterType.Location = new System.Drawing.Point(54, 47);
            this.txt_SQL_ParameterType.Name = "txt_SQL_ParameterType";
            this.txt_SQL_ParameterType.ReadOnly = true;
            this.txt_SQL_ParameterType.Size = new System.Drawing.Size(565, 22);
            this.txt_SQL_ParameterType.TabIndex = 3;
            // 
            // txt_SQL_ParameterValue
            // 
            this.txt_SQL_ParameterValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SQL_ParameterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SQL_ParameterValue.Location = new System.Drawing.Point(54, 75);
            this.txt_SQL_ParameterValue.Multiline = true;
            this.txt_SQL_ParameterValue.Name = "txt_SQL_ParameterValue";
            this.txt_SQL_ParameterValue.ReadOnly = true;
            this.txt_SQL_ParameterValue.Size = new System.Drawing.Size(565, 20);
            this.txt_SQL_ParameterValue.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Value:";
            // 
            // usrc_SQL_Parameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txt_SQL_ParameterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_SQL_ParameterType);
            this.Controls.Add(this.lbl_SQL_ParameterTYPE);
            this.Controls.Add(this.txt_SQL_ParameterName);
            this.Controls.Add(this.lbl_ParameterName);
            this.Name = "usrc_SQL_Parameter";
            this.Size = new System.Drawing.Size(619, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ParameterName;
        private System.Windows.Forms.TextBox txt_SQL_ParameterName;
        private System.Windows.Forms.Label lbl_SQL_ParameterTYPE;
        private System.Windows.Forms.TextBox txt_SQL_ParameterType;
        private System.Windows.Forms.TextBox txt_SQL_ParameterValue;
        private System.Windows.Forms.Label label1;
    }
}
