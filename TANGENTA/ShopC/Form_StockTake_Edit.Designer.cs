namespace ShopC
{
    partial class Form_StockTake_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_StockTake_Edit));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.usrc_EditTable1 = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.usrc_StockEditForSelectedStockTake1 = new ShopC.usrc_StockEditForSelectedStockTake();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.splitContainer1.CausesValidation = false;
            this.splitContainer1.Location = new System.Drawing.Point(0, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.usrc_EditTable1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.usrc_StockEditForSelectedStockTake1);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 724);
            this.splitContainer1.SplitterDistance = 526;
            this.splitContainer1.TabIndex = 0;
            // 
            // usrc_EditTable1
            // 
            this.usrc_EditTable1.AllowUserToAddNew = true;
            this.usrc_EditTable1.AllowUserToChange = true;
            this.usrc_EditTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditTable1.GetRandomData = false;
            this.usrc_EditTable1.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditTable1.Name = "usrc_EditTable1";
            this.usrc_EditTable1.SelectionButtonVisible = true;
            this.usrc_EditTable1.Size = new System.Drawing.Size(526, 724);
            this.usrc_EditTable1.TabIndex = 1;
            this.usrc_EditTable1.Title = "";
            this.usrc_EditTable1.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable1.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable1.SelectedIndexChanged += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_SelectedIndexChanged(this.usrc_EditTable1_SelectedIndexChanged);
            this.usrc_EditTable1.CellFormatting += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_CellFormatting(this.usrc_EditTable1_CellFormatting);
            // 
            // usrc_StockEditForSelectedStockTake1
            // 
            this.usrc_StockEditForSelectedStockTake1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.usrc_StockEditForSelectedStockTake1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_StockEditForSelectedStockTake1.Location = new System.Drawing.Point(0, 0);
            this.usrc_StockEditForSelectedStockTake1.Name = "usrc_StockEditForSelectedStockTake1";
            this.usrc_StockEditForSelectedStockTake1.Size = new System.Drawing.Size(478, 724);
            this.usrc_StockEditForSelectedStockTake1.TabIndex = 0;
            this.usrc_StockEditForSelectedStockTake1.BtnExitPressed += new ShopC.usrc_StockEditForSelectedStockTake.delegate_BtnExitPressed(this.usrc_StockEditForSelectedStockTake1_BtnExitPressed);
            this.usrc_StockEditForSelectedStockTake1.Load += new System.EventHandler(this.usrc_StockEditForSelectedStockTake1_Load);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help1.Location = new System.Drawing.Point(964, 1);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(41, 24);
            this.usrc_Help1.TabIndex = 2;
            // 
            // Form_StockTake_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_StockTake_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_StockTake_Edit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_StockTake_Edit_FormClosed);
            this.Load += new System.EventHandler(this.Form_StockTake_Edit_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable1;
        private usrc_StockEditForSelectedStockTake usrc_StockEditForSelectedStockTake1;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}