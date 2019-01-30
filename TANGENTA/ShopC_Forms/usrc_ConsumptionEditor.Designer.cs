


namespace ShopC_Forms
{
    partial class usrc_ConsumptionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrc_ConsumptionEditor));
            this.txt_Number = new System.Windows.Forms.TextBox();
            this.lbl_Number = new System.Windows.Forms.Label();
            this.chk_Storno = new System.Windows.Forms.CheckBox();
            this.usrc_Consumption_AddOn1 = new ShopC_Forms.usrc_Consumption_AddOn();
            this.m_usrc_ConsumptionShopC = new ShopC_Forms.usrc_ConsumptionShopC();
            this.btn_New = new System.Windows.Forms.Button();
            this.usrc_Item_selected1 = new ShopC_Forms.usrc_CItem_selected();
            this.usrc_DocIssue1 = new ShopC_Forms.usrc_DocIssue();
            this.SuspendLayout();
            // 
            // txt_Number
            // 
            this.txt_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Number.Location = new System.Drawing.Point(81, 3);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.ReadOnly = true;
            this.txt_Number.Size = new System.Drawing.Size(202, 24);
            this.txt_Number.TabIndex = 22;
            // 
            // lbl_Number
            // 
            this.lbl_Number.AutoSize = true;
            this.lbl_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Number.Location = new System.Drawing.Point(2, 4);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(77, 20);
            this.lbl_Number.TabIndex = 23;
            this.lbl_Number.Text = "Številka:";
            // 
            // chk_Storno
            // 
            this.chk_Storno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_Storno.Appearance = System.Windows.Forms.Appearance.Button;
            this.chk_Storno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chk_Storno.Location = new System.Drawing.Point(938, 685);
            this.chk_Storno.Name = "chk_Storno";
            this.chk_Storno.Size = new System.Drawing.Size(60, 82);
            this.chk_Storno.TabIndex = 39;
            this.chk_Storno.Text = "Storno";
            this.chk_Storno.UseVisualStyleBackColor = true;
            this.chk_Storno.CheckedChanged += new System.EventHandler(this.chk_Storno_CheckedChanged);
            // 
            // usrc_Consumption_AddOn1
            // 
            this.usrc_Consumption_AddOn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.usrc_Consumption_AddOn1.BackColor = System.Drawing.Color.LemonChiffon;
            this.usrc_Consumption_AddOn1.Location = new System.Drawing.Point(159, 689);
            this.usrc_Consumption_AddOn1.Name = "usrc_Consumption_AddOn1";
            this.usrc_Consumption_AddOn1.Size = new System.Drawing.Size(177, 79);
            this.usrc_Consumption_AddOn1.TabIndex = 40;
            // 
            // m_usrc_ShopC
            // 
            this.m_usrc_ConsumptionShopC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_usrc_ConsumptionShopC.AutomaticSelectionOfItemsFromStock = true;
            this.m_usrc_ConsumptionShopC.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_usrc_ConsumptionShopC.Location = new System.Drawing.Point(6, 34);
            this.m_usrc_ConsumptionShopC.Margin = new System.Windows.Forms.Padding(4);
            this.m_usrc_ConsumptionShopC.Name = "m_usrc_ShopC";
            this.m_usrc_ConsumptionShopC.Size = new System.Drawing.Size(1000, 637);
            this.m_usrc_ConsumptionShopC.TabIndex = 46;
            // 
            // btn_New
            // 
            this.btn_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_New.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_New.Image = ((System.Drawing.Image)(resources.GetObject("btn_New.Image")));
            this.btn_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_New.Location = new System.Drawing.Point(756, 685);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(176, 82);
            this.btn_New.TabIndex = 48;
            this.btn_New.Text = "Nov";
            this.btn_New.UseVisualStyleBackColor = false;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // usrc_Item_selected1
            // 
            this.usrc_Item_selected1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Item_selected1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(249)))), ((int)(((byte)(166)))));
            this.usrc_Item_selected1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usrc_Item_selected1.Location = new System.Drawing.Point(338, 679);
            this.usrc_Item_selected1.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_Item_selected1.Name = "usrc_Item_selected1";
            this.usrc_Item_selected1.Size = new System.Drawing.Size(413, 88);
            this.usrc_Item_selected1.TabIndex = 49;
            // 
            // usrc_DocIssue1
            // 
            this.usrc_DocIssue1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.usrc_DocIssue1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("usrc_DocIssue1.BackgroundImage")));
            this.usrc_DocIssue1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usrc_DocIssue1.BtnIssueLabel = "Issue";
            this.usrc_DocIssue1.BtnIssueVisible = true;
            this.usrc_DocIssue1.Location = new System.Drawing.Point(5, 687);
            this.usrc_DocIssue1.Name = "usrc_DocIssue1";
            this.usrc_DocIssue1.Size = new System.Drawing.Size(150, 80);
            this.usrc_DocIssue1.TabIndex = 50;
            this.usrc_DocIssue1.Total = "SKUPAJ";
            this.usrc_DocIssue1.TotalColor = System.Drawing.SystemColors.ControlText;
            this.usrc_DocIssue1.DoClick += new ShopC_Forms.usrc_DocIssue.delegate_Click(this.btn_Issue_Click);
            // 
            // usrc_ConsumptionEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.usrc_DocIssue1);
            this.Controls.Add(this.usrc_Item_selected1);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.m_usrc_ConsumptionShopC);
            this.Controls.Add(this.usrc_Consumption_AddOn1);
            this.Controls.Add(this.chk_Storno);
            this.Controls.Add(this.lbl_Number);
            this.Controls.Add(this.txt_Number);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "usrc_ConsumptionEditor";
            this.Size = new System.Drawing.Size(1006, 768);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox txt_Number;
        private System.Windows.Forms.Label lbl_Number;
        private System.Windows.Forms.CheckBox chk_Storno;
        internal usrc_Consumption_AddOn usrc_Consumption_AddOn1;
        internal usrc_ConsumptionShopC m_usrc_ConsumptionShopC;
        internal System.Windows.Forms.Button btn_New;
        private usrc_CItem_selected usrc_Item_selected1;
        public usrc_DocIssue usrc_DocIssue1;
    }
}
