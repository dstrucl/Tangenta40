namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            this.multiColumnComboBox1 = new MyCustomControls.InheritedCombo.MultiColumnComboBox(this.components);
            this.SuspendLayout();
            // 
            // multiColumnComboBox1
            // 
            this.multiColumnComboBox1.FormattingEnabled = true;
            this.multiColumnComboBox1.Location = new System.Drawing.Point(12, 33);
            this.multiColumnComboBox1.Name = "multiColumnComboBox1";
            this.multiColumnComboBox1.Size = new System.Drawing.Size(240, 21);
            this.multiColumnComboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.multiColumnComboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MyCustomControls.InheritedCombo.MultiColumnComboBox multiColumnComboBox1;
    }
}

