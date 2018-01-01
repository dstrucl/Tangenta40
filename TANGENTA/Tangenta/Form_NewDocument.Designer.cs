namespace Tangenta
{
    partial class Form_NewDocument
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
            this.btn_New_Empty = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_New_Copy_of_Another_DocType1 = new Tangenta.usrc_New_Copy_of_Another_DocType();
            this.usrc_New_Copy_of_Same_DocType1 = new Tangenta.usrc_New_Copy_of_Same_DocType();
            this.usrc_Currency1 = new Tangenta.usrc_Currency();
            this.SuspendLayout();
            // 
            // btn_New_Empty
            // 
            this.btn_New_Empty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Empty.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_New_Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New_Empty.Location = new System.Drawing.Point(3, 46);
            this.btn_New_Empty.Margin = new System.Windows.Forms.Padding(2);
            this.btn_New_Empty.Name = "btn_New_Empty";
            this.btn_New_Empty.Size = new System.Drawing.Size(415, 88);
            this.btn_New_Empty.TabIndex = 0;
            this.btn_New_Empty.Text = "btn_New_Empty";
            this.btn_New_Empty.UseVisualStyleBackColor = false;
            this.btn_New_Empty.Click += new System.EventHandler(this.btn_New_Empty_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(169, 452);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 29);
            this.btn_Cancel.TabIndex = 36;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_New_Copy_of_Another_DocType1
            // 
            this.usrc_New_Copy_of_Another_DocType1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_New_Copy_of_Another_DocType1.Location = new System.Drawing.Point(3, 291);
            this.usrc_New_Copy_of_Another_DocType1.Name = "usrc_New_Copy_of_Another_DocType1";
            this.usrc_New_Copy_of_Another_DocType1.Size = new System.Drawing.Size(416, 146);
            this.usrc_New_Copy_of_Another_DocType1.TabIndex = 38;
            this.usrc_New_Copy_of_Another_DocType1.Set_New_Copy_of_Another_DocType += new Tangenta.usrc_New_Copy_of_Another_DocType.delegate_Set_New_Copy_of_Another_DocType(this.usrc_New_Copy_of_Another_DocType1_Set_New_Copy_of_Another_DocType);
            // 
            // usrc_New_Copy_of_Same_DocType1
            // 
            this.usrc_New_Copy_of_Same_DocType1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_New_Copy_of_Same_DocType1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_New_Copy_of_Same_DocType1.Location = new System.Drawing.Point(3, 139);
            this.usrc_New_Copy_of_Same_DocType1.Name = "usrc_New_Copy_of_Same_DocType1";
            this.usrc_New_Copy_of_Same_DocType1.Size = new System.Drawing.Size(416, 146);
            this.usrc_New_Copy_of_Same_DocType1.TabIndex = 37;
            this.usrc_New_Copy_of_Same_DocType1.Set_New_Copy_of_Same_DocType += new Tangenta.usrc_New_Copy_of_Same_DocType.delegate_Set_New_Copy_of_Same_DocType(this.usrc_New_Copy_of_Same_DocType1_Set_New_Copy_of_Same_DocType);
            // 
            // usrc_Currency1
            // 
            this.usrc_Currency1.Location = new System.Drawing.Point(8, 9);
            this.usrc_Currency1.Name = "usrc_Currency1";
            this.usrc_Currency1.Size = new System.Drawing.Size(179, 31);
            this.usrc_Currency1.TabIndex = 39;
            // 
            // Form_NewDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 485);
            this.Controls.Add(this.usrc_Currency1);
            this.Controls.Add(this.usrc_New_Copy_of_Another_DocType1);
            this.Controls.Add(this.usrc_New_Copy_of_Same_DocType1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_New_Empty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_NewDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_New_Empty;
        private System.Windows.Forms.Button btn_Cancel;
        private usrc_New_Copy_of_Same_DocType usrc_New_Copy_of_Same_DocType1;
        private usrc_New_Copy_of_Another_DocType usrc_New_Copy_of_Another_DocType1;
        internal usrc_Currency usrc_Currency1;
    }
}