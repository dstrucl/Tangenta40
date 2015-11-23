namespace ErrorCreateWindowHandle
{
    partial class Form1
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
            this.btn_DeleteAndCreateNew = new System.Windows.Forms.Button();
            this.m_usrc_ItemList = new ErrorCreateWindowHandle.usrc_ItemList();
            this.lbl_GDI_counts = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_DeleteAndCreateNew
            // 
            this.btn_DeleteAndCreateNew.Location = new System.Drawing.Point(108, 40);
            this.btn_DeleteAndCreateNew.Name = "btn_DeleteAndCreateNew";
            this.btn_DeleteAndCreateNew.Size = new System.Drawing.Size(226, 44);
            this.btn_DeleteAndCreateNew.TabIndex = 1;
            this.btn_DeleteAndCreateNew.Text = "Delete And Create New";
            this.btn_DeleteAndCreateNew.UseVisualStyleBackColor = true;
            this.btn_DeleteAndCreateNew.Click += new System.EventHandler(this.btn_DeleteAndCreateNew_Click);
            // 
            // m_usrc_ItemList
            // 
            this.m_usrc_ItemList.Location = new System.Drawing.Point(106, 103);
            this.m_usrc_ItemList.Margin = new System.Windows.Forms.Padding(4);
            this.m_usrc_ItemList.Name = "m_usrc_ItemList";
            this.m_usrc_ItemList.Size = new System.Drawing.Size(656, 393);
            this.m_usrc_ItemList.TabIndex = 0;
            // 
            // lbl_GDI_counts
            // 
            this.lbl_GDI_counts.AutoSize = true;
            this.lbl_GDI_counts.Location = new System.Drawing.Point(27, 9);
            this.lbl_GDI_counts.Name = "lbl_GDI_counts";
            this.lbl_GDI_counts.Size = new System.Drawing.Size(62, 13);
            this.lbl_GDI_counts.TabIndex = 2;
            this.lbl_GDI_counts.Text = "GDI Counts";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 625);
            this.Controls.Add(this.lbl_GDI_counts);
            this.Controls.Add(this.btn_DeleteAndCreateNew);
            this.Controls.Add(this.m_usrc_ItemList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private usrc_ItemList m_usrc_ItemList;
        private System.Windows.Forms.Button btn_DeleteAndCreateNew;
        private System.Windows.Forms.Label lbl_GDI_counts;
    }
}

