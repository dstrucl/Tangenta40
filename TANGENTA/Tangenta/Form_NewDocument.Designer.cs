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
            this.btn_New_Copy_Of_SameDocType = new System.Windows.Forms.Button();
            this.btn_New_Copy_To_Another_DocType = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_New_Empty
            // 
            this.btn_New_Empty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New_Empty.Location = new System.Drawing.Point(1, 1);
            this.btn_New_Empty.Name = "btn_New_Empty";
            this.btn_New_Empty.Size = new System.Drawing.Size(519, 110);
            this.btn_New_Empty.TabIndex = 0;
            this.btn_New_Empty.Text = "btn_New_Empty";
            this.btn_New_Empty.UseVisualStyleBackColor = true;
            this.btn_New_Empty.Click += new System.EventHandler(this.btn_New_Empty_Click);
            // 
            // btn_New_Copy_Of_SameDocType
            // 
            this.btn_New_Copy_Of_SameDocType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Copy_Of_SameDocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New_Copy_Of_SameDocType.Location = new System.Drawing.Point(1, 114);
            this.btn_New_Copy_Of_SameDocType.Name = "btn_New_Copy_Of_SameDocType";
            this.btn_New_Copy_Of_SameDocType.Size = new System.Drawing.Size(519, 110);
            this.btn_New_Copy_Of_SameDocType.TabIndex = 1;
            this.btn_New_Copy_Of_SameDocType.Text = "btn_New_Copy_Of_SameDocType";
            this.btn_New_Copy_Of_SameDocType.UseVisualStyleBackColor = true;
            this.btn_New_Copy_Of_SameDocType.Click += new System.EventHandler(this.btn_New_Copy_Of_SameDocType_Click);
            // 
            // btn_New_Copy_To_Another_DocType
            // 
            this.btn_New_Copy_To_Another_DocType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New_Copy_To_Another_DocType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New_Copy_To_Another_DocType.Location = new System.Drawing.Point(1, 226);
            this.btn_New_Copy_To_Another_DocType.Name = "btn_New_Copy_To_Another_DocType";
            this.btn_New_Copy_To_Another_DocType.Size = new System.Drawing.Size(519, 110);
            this.btn_New_Copy_To_Another_DocType.TabIndex = 4;
            this.btn_New_Copy_To_Another_DocType.Text = "btn_New_Copy_To_Another_DocType";
            this.btn_New_Copy_To_Another_DocType.UseVisualStyleBackColor = true;
            this.btn_New_Copy_To_Another_DocType.Click += new System.EventHandler(this.btn_New_Copy_To_Another_DocType_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(220, 354);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(91, 36);
            this.btn_Cancel.TabIndex = 36;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_NewDocument
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(523, 402);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_New_Copy_To_Another_DocType);
            this.Controls.Add(this.btn_New_Copy_Of_SameDocType);
            this.Controls.Add(this.btn_New_Empty);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_NewDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_New_Empty;
        private System.Windows.Forms.Button btn_New_Copy_Of_SameDocType;
        private System.Windows.Forms.Button btn_New_Copy_To_Another_DocType;
        private System.Windows.Forms.Button btn_Cancel;
    }
}