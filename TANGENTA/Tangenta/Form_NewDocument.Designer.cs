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
            this.SuspendLayout();
            // 
            // btn_New_Empty
            // 
            this.btn_New_Empty.Location = new System.Drawing.Point(12, 12);
            this.btn_New_Empty.Name = "btn_New_Empty";
            this.btn_New_Empty.Size = new System.Drawing.Size(240, 69);
            this.btn_New_Empty.TabIndex = 0;
            this.btn_New_Empty.Text = "btn_New_Empty";
            this.btn_New_Empty.UseVisualStyleBackColor = true;
            this.btn_New_Empty.Click += new System.EventHandler(this.btn_New_Empty_Click);
            // 
            // btn_New_Copy_Of_SameDocType
            // 
            this.btn_New_Copy_Of_SameDocType.Location = new System.Drawing.Point(12, 87);
            this.btn_New_Copy_Of_SameDocType.Name = "btn_New_Copy_Of_SameDocType";
            this.btn_New_Copy_Of_SameDocType.Size = new System.Drawing.Size(240, 74);
            this.btn_New_Copy_Of_SameDocType.TabIndex = 1;
            this.btn_New_Copy_Of_SameDocType.Text = "btn_New_Copy_Of_SameDocType";
            this.btn_New_Copy_Of_SameDocType.UseVisualStyleBackColor = true;
            this.btn_New_Copy_Of_SameDocType.Click += new System.EventHandler(this.btn_New_Copy_Of_SameDocType_Click);
            // 
            // btn_New_Copy_To_Another_DocType
            // 
            this.btn_New_Copy_To_Another_DocType.Location = new System.Drawing.Point(12, 167);
            this.btn_New_Copy_To_Another_DocType.Name = "btn_New_Copy_To_Another_DocType";
            this.btn_New_Copy_To_Another_DocType.Size = new System.Drawing.Size(240, 74);
            this.btn_New_Copy_To_Another_DocType.TabIndex = 4;
            this.btn_New_Copy_To_Another_DocType.Text = "btn_New_Copy_To_Another_DocType";
            this.btn_New_Copy_To_Another_DocType.UseVisualStyleBackColor = true;
            this.btn_New_Copy_To_Another_DocType.Click += new System.EventHandler(this.btn_New_Copy_To_Another_DocType_Click);
            // 
            // Form_NewDocument
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(268, 256);
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
    }
}