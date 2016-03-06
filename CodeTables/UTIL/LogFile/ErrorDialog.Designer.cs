namespace LogFile
{
    partial class ErrorDialog
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
            this.txtErrorMessage = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorMessage.BackColor = System.Drawing.SystemColors.Info;
            this.txtErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtErrorMessage.ForeColor = System.Drawing.Color.Maroon;
            this.txtErrorMessage.Location = new System.Drawing.Point(25, 33);
            this.txtErrorMessage.Multiline = true;
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorMessage.Size = new System.Drawing.Size(597, 410);
            this.txtErrorMessage.TabIndex = 1;
            // 
            // btn1
            // 
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.Location = new System.Drawing.Point(255, 463);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(103, 34);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "OK";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn2
            // 
            this.btn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn2.Location = new System.Drawing.Point(373, 463);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(103, 34);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "OK";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn3
            // 
            this.btn3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn3.Location = new System.Drawing.Point(490, 464);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(103, 34);
            this.btn3.TabIndex = 4;
            this.btn3.Text = "OK";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn_Click);
            // 
            // ErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 509);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.txtErrorMessage);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ErrorDialog";
            this.ShowInTaskbar = false;
            this.Text = "Text Editor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ErrorDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ToolStripMenuItem ItemCopy;
        //private System.Windows.Forms.ToolStripMenuItem ItemCut;
        //private System.Windows.Forms.ToolStripMenuItem ItemPaste;
        //private System.Windows.Forms.ContextMenuStrip TextEditorMenuStrip;
        private System.Windows.Forms.TextBox txtErrorMessage;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
    }
}