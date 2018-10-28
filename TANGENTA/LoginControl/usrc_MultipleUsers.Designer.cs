namespace LoginControl
{
    partial class usrc_MultipleUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_MultipleUsers));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_Items = new System.Windows.Forms.Panel();
            this.usrc_Item_Group_Handler1 = new usrc_Item_Group_Handler.usrc_Item_Group_Handler();
            this.lbl_GroupPath = new System.Windows.Forms.Label();
            this.lbl_Tangenta = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.usrc_Item_PageHandler1 = new usrc_Item_PageHandler.usrcG_Item_PageHandler();
            this.chk_ShowAdministrators = new System.Windows.Forms.CheckBox();
            this.btn_IdleCtrl_ShowURL1 = new System.Windows.Forms.Button();
            this.btn_IdleCtrl_ShowURL2 = new System.Windows.Forms.Button();
            this.lbl_Cashier = new System.Windows.Forms.Label();
            this.lbl_OpenedClosed = new System.Windows.Forms.Label();
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
            this.splitContainer1.Size = new System.Drawing.Size(1025, 697);
            this.splitContainer1.SplitterDistance = 800;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnl_Items
            // 
            this.pnl_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Items.Location = new System.Drawing.Point(0, 0);
            this.pnl_Items.Name = "pnl_Items";
            this.pnl_Items.Size = new System.Drawing.Size(800, 697);
            this.pnl_Items.TabIndex = 0;
            // 
            // usrc_Item_Group_Handler1
            // 
            this.usrc_Item_Group_Handler1.Button_Height = 48;
            this.usrc_Item_Group_Handler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_Item_Group_Handler1.Font_Height = 10;
            this.usrc_Item_Group_Handler1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Item_Group_Handler1.Name = "usrc_Item_Group_Handler1";
            this.usrc_Item_Group_Handler1.ShopName = "";
            this.usrc_Item_Group_Handler1.Size = new System.Drawing.Size(217, 697);
            this.usrc_Item_Group_Handler1.TabIndex = 0;
            this.usrc_Item_Group_Handler1.GroupsRedefined += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_GroupsRedefined(this.usrc_Item_Group_Handler1_GroupsRedefined);
            this.usrc_Item_Group_Handler1.PaintGroup += new usrc_Item_Group_Handler.usrc_Item_Group_Handler.delegate_PaintGroup(this.Paint_Group);
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
            this.lbl_Tangenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Tangenta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Tangenta.Location = new System.Drawing.Point(32, 38);
            this.lbl_Tangenta.Name = "lbl_Tangenta";
            this.lbl_Tangenta.Size = new System.Drawing.Size(280, 40);
            this.lbl_Tangenta.TabIndex = 5;
            this.lbl_Tangenta.Text = "TANGENTA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginControl.Properties.Resources.Tangenta_Logo_SMALL;
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
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.Location = new System.Drawing.Point(885, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(137, 55);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // usrc_Item_PageHandler1
            // 
            this.usrc_Item_PageHandler1.CurrentPage = 0;
            this.usrc_Item_PageHandler1.Location = new System.Drawing.Point(317, 36);
            this.usrc_Item_PageHandler1.Name = "usrc_Item_PageHandler1";
            this.usrc_Item_PageHandler1.Size = new System.Drawing.Size(255, 42);
            this.usrc_Item_PageHandler1.TabIndex = 1;
            this.usrc_Item_PageHandler1.ShowObject += new usrc_Item_PageHandler.usrcG_Item_PageHandler.delegate_ShowObject(this.m_usrc_Item_PageHandler_ShowObject);
            // 
            // chk_ShowAdministrators
            // 
            this.chk_ShowAdministrators.AutoSize = true;
            this.chk_ShowAdministrators.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_ShowAdministrators.Location = new System.Drawing.Point(382, 3);
            this.chk_ShowAdministrators.Name = "chk_ShowAdministrators";
            this.chk_ShowAdministrators.Size = new System.Drawing.Size(227, 29);
            this.chk_ShowAdministrators.TabIndex = 6;
            this.chk_ShowAdministrators.Text = "Show Administrators";
            this.chk_ShowAdministrators.UseVisualStyleBackColor = true;
            // 
            // btn_IdleCtrl_ShowURL1
            // 
            this.btn_IdleCtrl_ShowURL1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_IdleCtrl_ShowURL1.Location = new System.Drawing.Point(634, 0);
            this.btn_IdleCtrl_ShowURL1.Name = "btn_IdleCtrl_ShowURL1";
            this.btn_IdleCtrl_ShowURL1.Size = new System.Drawing.Size(89, 55);
            this.btn_IdleCtrl_ShowURL1.TabIndex = 7;
            this.btn_IdleCtrl_ShowURL1.Text = "URL1";
            this.btn_IdleCtrl_ShowURL1.UseVisualStyleBackColor = true;
            this.btn_IdleCtrl_ShowURL1.Click += new System.EventHandler(this.btn_IdleCtrl_ShowURL1_Click);
            // 
            // btn_IdleCtrl_ShowURL2
            // 
            this.btn_IdleCtrl_ShowURL2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_IdleCtrl_ShowURL2.Location = new System.Drawing.Point(729, 0);
            this.btn_IdleCtrl_ShowURL2.Name = "btn_IdleCtrl_ShowURL2";
            this.btn_IdleCtrl_ShowURL2.Size = new System.Drawing.Size(89, 55);
            this.btn_IdleCtrl_ShowURL2.TabIndex = 8;
            this.btn_IdleCtrl_ShowURL2.Text = "URL2";
            this.btn_IdleCtrl_ShowURL2.UseVisualStyleBackColor = true;
            this.btn_IdleCtrl_ShowURL2.Click += new System.EventHandler(this.btn_IdleCtrl_ShowURL2_Click);
            // 
            // lbl_Cashier
            // 
            this.lbl_Cashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Cashier.Location = new System.Drawing.Point(48, 9);
            this.lbl_Cashier.Name = "lbl_Cashier";
            this.lbl_Cashier.Size = new System.Drawing.Size(112, 20);
            this.lbl_Cashier.TabIndex = 9;
            this.lbl_Cashier.Text = "Cashier:";
            this.lbl_Cashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_OpenedClosed
            // 
            this.lbl_OpenedClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_OpenedClosed.Location = new System.Drawing.Point(160, 9);
            this.lbl_OpenedClosed.Name = "lbl_OpenedClosed";
            this.lbl_OpenedClosed.Size = new System.Drawing.Size(92, 20);
            this.lbl_OpenedClosed.TabIndex = 10;
            this.lbl_OpenedClosed.Text = "Closed";
            this.lbl_OpenedClosed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // usrc_MultipleUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_OpenedClosed);
            this.Controls.Add(this.lbl_Cashier);
            this.Controls.Add(this.btn_IdleCtrl_ShowURL2);
            this.Controls.Add(this.btn_IdleCtrl_ShowURL1);
            this.Controls.Add(this.chk_ShowAdministrators);
            this.Controls.Add(this.lbl_Tangenta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_GroupPath);
            this.Controls.Add(this.usrc_Item_PageHandler1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "usrc_MultipleUsers";
            this.Size = new System.Drawing.Size(1028, 781);
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
        private usrc_Item_PageHandler.usrcG_Item_PageHandler usrc_Item_PageHandler1;
        private System.Windows.Forms.Panel pnl_Items;
        private System.Windows.Forms.Label lbl_GroupPath;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Tangenta;
        internal System.Windows.Forms.CheckBox chk_ShowAdministrators;
        private System.Windows.Forms.Button btn_IdleCtrl_ShowURL1;
        private System.Windows.Forms.Button btn_IdleCtrl_ShowURL2;
        private System.Windows.Forms.Label lbl_Cashier;
        private System.Windows.Forms.Label lbl_OpenedClosed;
    }
}
