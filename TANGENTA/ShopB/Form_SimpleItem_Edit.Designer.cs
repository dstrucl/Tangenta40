namespace ShopB
{
    partial class Form_ShopBItem_Edit
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
            this.usrc_EditTable = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.rdb_OnlyNotInOffer = new System.Windows.Forms.RadioButton();
            this.rdb_All = new System.Windows.Forms.RadioButton();
            this.rdb_OnlyInOffer = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usrc_EditTable
            // 
            this.usrc_EditTable.AllowUserToAddNew = true;
            this.usrc_EditTable.AllowUserToChange = true;
            this.usrc_EditTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable.GetRandomData = false;
            this.usrc_EditTable.Location = new System.Drawing.Point(4, 2);
            this.usrc_EditTable.Name = "usrc_EditTable";
            this.usrc_EditTable.SelectionButtonVisible = false;
            this.usrc_EditTable.Size = new System.Drawing.Size(902, 585);
            this.usrc_EditTable.TabIndex = 0;
            this.usrc_EditTable.Title = "";
            this.usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_after_InsertInDataBase);
            this.usrc_EditTable.after_UpdateDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_UpdateDataBase(this.usrc_EditTable_after_UpdateDataBase);
            // 
            // rdb_OnlyNotInOffer
            // 
            this.rdb_OnlyNotInOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_OnlyNotInOffer.AutoSize = true;
            this.rdb_OnlyNotInOffer.Location = new System.Drawing.Point(416, 601);
            this.rdb_OnlyNotInOffer.Name = "rdb_OnlyNotInOffer";
            this.rdb_OnlyNotInOffer.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyNotInOffer.TabIndex = 14;
            this.rdb_OnlyNotInOffer.TabStop = true;
            this.rdb_OnlyNotInOffer.Text = "Only Valid";
            this.rdb_OnlyNotInOffer.UseVisualStyleBackColor = true;
            // 
            // rdb_All
            // 
            this.rdb_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_All.AutoSize = true;
            this.rdb_All.Location = new System.Drawing.Point(630, 601);
            this.rdb_All.Name = "rdb_All";
            this.rdb_All.Size = new System.Drawing.Size(36, 17);
            this.rdb_All.TabIndex = 13;
            this.rdb_All.TabStop = true;
            this.rdb_All.Text = "All";
            this.rdb_All.UseVisualStyleBackColor = true;
            // 
            // rdb_OnlyInOffer
            // 
            this.rdb_OnlyInOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_OnlyInOffer.AutoSize = true;
            this.rdb_OnlyInOffer.Location = new System.Drawing.Point(221, 601);
            this.rdb_OnlyInOffer.Name = "rdb_OnlyInOffer";
            this.rdb_OnlyInOffer.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyInOffer.TabIndex = 12;
            this.rdb_OnlyInOffer.TabStop = true;
            this.rdb_OnlyInOffer.Text = "Only Valid";
            this.rdb_OnlyInOffer.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(133, 597);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(55, 24);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(9, 597);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(55, 24);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // Form_ShopBItem_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(905, 630);
            this.Controls.Add(this.rdb_OnlyNotInOffer);
            this.Controls.Add(this.rdb_All);
            this.Controls.Add(this.rdb_OnlyInOffer);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.usrc_EditTable);
            this.Name = "Form_ShopBItem_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopBItem_EditForm";
            this.Load += new System.EventHandler(this.MyCompanyData_EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable;
        private System.Windows.Forms.RadioButton rdb_OnlyNotInOffer;
        private System.Windows.Forms.RadioButton rdb_All;
        private System.Windows.Forms.RadioButton rdb_OnlyInOffer;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}