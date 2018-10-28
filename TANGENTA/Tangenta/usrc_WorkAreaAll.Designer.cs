namespace Tangenta
{
    partial class usrc_WorkAreaAll
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_Items = new System.Windows.Forms.Panel();
            this.usrc_Item_Group_Handler1 = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.usrc_Item_PageHandler1 = new usrc_Item_PageHandler4usrc_WorkArea();
            this.lbl_GroupPath = new System.Windows.Forms.Label();
            this.lbl_Tangenta = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 81);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnl_Items);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_Item_Group_Handler1);
            this.splitContainer1.Size = new System.Drawing.Size(1013, 697);
            this.splitContainer1.SplitterDistance = 790;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnl_Items
            // 
            this.pnl_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Items.Location = new System.Drawing.Point(0, 0);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(790, 697);
            this.pnl_Items.TabIndex = 0;
            // 
            // usrc_Item_Group_Handler1
            // 
            this.usrc_Item_Group_Handler1.Button_Height = 64;
            this.usrc_Item_Group_Handler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_Item_Group_Handler1.Font_Height = 10;
            this.usrc_Item_Group_Handler1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Item_Group_Handler1.Name = "usrc_Item_Group_Handler1";
            this.usrc_Item_Group_Handler1.ShopName = "";
            this.usrc_Item_Group_Handler1.Size = new System.Drawing.Size(215, 697);
            this.usrc_Item_Group_Handler1.TabIndex = 0;
            this.usrc_Item_Group_Handler1.GroupsRedefined += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_GroupsRedefined(this.usrc_Item_Group_Handler1_GroupsRedefined);
            this.usrc_Item_Group_Handler1.PaintGroup += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_PaintGroup(this.Paint_Group);
            // 
            // usrc_Item_PageHandler1
            // 
            this.usrc_Item_PageHandler1.CurrentPage = 0;
            this.usrc_Item_PageHandler1.Location = new System.Drawing.Point(348, 19);
            this.usrc_Item_PageHandler1.Name = "usrc_Item_PageHandler1";
            this.usrc_Item_PageHandler1.Size = new System.Drawing.Size(151, 37);
            this.usrc_Item_PageHandler1.TabIndex = 1;
            this.usrc_Item_PageHandler1.ShowObject += new usrc_Item_PageHandler4usrc_WorkArea.delegate_ShowObject(this.m_usrc_Item_PageHandler_ShowObject);
            // 
            // lbl_GroupPath
            // 
            this.lbl_GroupPath.AutoSize = true;
            this.lbl_GroupPath.Location = new System.Drawing.Point(726, 65);
            this.lbl_GroupPath.Name = "lbl_GroupPath";
            this.lbl_GroupPath.Size = new System.Drawing.Size(60, 13);
            this.lbl_GroupPath.TabIndex = 2;
            this.lbl_GroupPath.Text = "Group path";
            // 
            // lbl_Tangenta
            // 
            this.lbl_Tangenta.AutoSize = true;
            this.lbl_Tangenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Tangenta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Tangenta.Location = new System.Drawing.Point(26, 19);
            this.lbl_Tangenta.Name = "lbl_Tangenta";
            this.lbl_Tangenta.Size = new System.Drawing.Size(285, 55);
            this.lbl_Tangenta.TabIndex = 5;
            this.lbl_Tangenta.Text = "TANGENTA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tangenta.Properties.Resources.Tangenta_Logo_SMALL;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(873, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(137, 55);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_WorkAreaAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Tangenta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_GroupPath);
            this.Controls.Add(this.usrc_Item_PageHandler1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_WorkAreaAll";
            this.Size = new System.Drawing.Size(1016, 781);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private usrc_Item_Group_Handler.usrc_Item_Group_Handler usrc_Item_Group_Handler1;
        private usrc_Item_PageHandler4usrc_WorkArea usrc_Item_PageHandler1;
        private System.Windows.Forms.Panel pnl_Items;
        private System.Windows.Forms.Label lbl_GroupPath;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Tangenta;
    }
}
