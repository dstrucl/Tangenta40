namespace HUDCMS
{
    partial class usrc_HelpWizzardTagDC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_HelpWizzardTagDC));
            this.lbl_Condition = new System.Windows.Forms.Label();
            this.txt_Condition = new System.Windows.Forms.TextBox();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Type = new System.Windows.Forms.TextBox();
            this.lbl_Type = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Condition
            // 
            this.lbl_Condition.Location = new System.Drawing.Point(360, 4);
            this.lbl_Condition.Name = "lbl_Condition";
            this.lbl_Condition.Size = new System.Drawing.Size(52, 20);
            this.lbl_Condition.TabIndex = 0;
            this.lbl_Condition.Text = "Condition:";
            this.lbl_Condition.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Condition
            // 
            this.txt_Condition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_Condition.Location = new System.Drawing.Point(414, 3);
            this.txt_Condition.Name = "txt_Condition";
            this.txt_Condition.ReadOnly = true;
            this.txt_Condition.Size = new System.Drawing.Size(144, 20);
            this.txt_Condition.TabIndex = 1;
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.CharHeight = 14;
            this.fastColoredTextBox1.CharWidth = 8;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(3, 33);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(555, 162);
            this.fastColoredTextBox1.TabIndex = 2;
            this.fastColoredTextBox1.Zoom = 100;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(3, 4);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(39, 20);
            this.lbl_Name.TabIndex = 3;
            this.lbl_Name.Text = "Name:";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Name
            // 
            this.txt_Name.ForeColor = System.Drawing.Color.Blue;
            this.txt_Name.Location = new System.Drawing.Point(43, 2);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(151, 20);
            this.txt_Name.TabIndex = 4;
            // 
            // txt_Type
            // 
            this.txt_Type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txt_Type.Location = new System.Drawing.Point(240, 3);
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.ReadOnly = true;
            this.txt_Type.Size = new System.Drawing.Size(101, 20);
            this.txt_Type.TabIndex = 6;
            // 
            // lbl_Type
            // 
            this.lbl_Type.Location = new System.Drawing.Point(200, 4);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(39, 20);
            this.lbl_Type.TabIndex = 5;
            this.lbl_Type.Text = "Type:";
            this.lbl_Type.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // usrc_HelpWizzardTagDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_Type);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Controls.Add(this.txt_Condition);
            this.Controls.Add(this.lbl_Condition);
            this.Name = "usrc_HelpWizzardTagDC";
            this.Size = new System.Drawing.Size(561, 198);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Condition;
        private System.Windows.Forms.TextBox txt_Condition;
        internal FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Type;
        private System.Windows.Forms.Label lbl_Type;
    }
}
