namespace ShopC
{
    partial class Form_Item_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Item_Edit));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.usrc_EditTable = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.rdb_OnlyNotInOffer = new System.Windows.Forms.RadioButton();
            this.rdb_All = new System.Windows.Forms.RadioButton();
            this.rdb_OnlyInOffer = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(128, 578);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(55, 24);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(4, 578);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(55, 24);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // usrc_EditTable
            // 
            this.usrc_EditTable.AllowUserToAddNew = true;
            this.usrc_EditTable.AllowUserToChange = true;
            this.usrc_EditTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable.GetRandomData = false;
            this.usrc_EditTable.Location = new System.Drawing.Point(4, 3);
            this.usrc_EditTable.Name = "usrc_EditTable";
            this.usrc_EditTable.SelectionButtonVisible = false;
            this.usrc_EditTable.Size = new System.Drawing.Size(897, 569);
            this.usrc_EditTable.TabIndex = 0;
            this.usrc_EditTable.Title = "";
            this.usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable.after_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_after_InsertInDataBase);
            this.usrc_EditTable.after_UpdateDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_UpdateDataBase(this.usrc_EditTable_after_UpdateDataBase);
            this.usrc_EditTable.RowReferenceFromTable_Check_NoChangeToOther += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_RowReferenceFromTable_Check_NoChangeToOther(this.usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther);
            // 
            // rdb_OnlyNotInOffer
            // 
            this.rdb_OnlyNotInOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_OnlyNotInOffer.AutoSize = true;
            this.rdb_OnlyNotInOffer.Location = new System.Drawing.Point(411, 582);
            this.rdb_OnlyNotInOffer.Name = "rdb_OnlyNotInOffer";
            this.rdb_OnlyNotInOffer.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyNotInOffer.TabIndex = 9;
            this.rdb_OnlyNotInOffer.TabStop = true;
            this.rdb_OnlyNotInOffer.Text = "Only Valid";
            this.rdb_OnlyNotInOffer.UseVisualStyleBackColor = true;
            this.rdb_OnlyNotInOffer.CheckedChanged += new System.EventHandler(this.rdb_OnlyNotInOffer_CheckedChanged);
            // 
            // rdb_All
            // 
            this.rdb_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_All.AutoSize = true;
            this.rdb_All.Location = new System.Drawing.Point(625, 582);
            this.rdb_All.Name = "rdb_All";
            this.rdb_All.Size = new System.Drawing.Size(36, 17);
            this.rdb_All.TabIndex = 8;
            this.rdb_All.TabStop = true;
            this.rdb_All.Text = "All";
            this.rdb_All.UseVisualStyleBackColor = true;
            // 
            // rdb_OnlyInOffer
            // 
            this.rdb_OnlyInOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdb_OnlyInOffer.AutoSize = true;
            this.rdb_OnlyInOffer.Location = new System.Drawing.Point(216, 582);
            this.rdb_OnlyInOffer.Name = "rdb_OnlyInOffer";
            this.rdb_OnlyInOffer.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyInOffer.TabIndex = 7;
            this.rdb_OnlyInOffer.TabStop = true;
            this.rdb_OnlyInOffer.Text = "Only Valid";
            this.rdb_OnlyInOffer.UseVisualStyleBackColor = true;
            // 
            // Form_Item_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(905, 607);
            this.Controls.Add(this.rdb_OnlyNotInOffer);
            this.Controls.Add(this.rdb_All);
            this.Controls.Add(this.rdb_OnlyInOffer);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.usrc_EditTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Item_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Item_EditForm_FormClosing);
            this.Load += new System.EventHandler(this.MyOrganisationData_EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.RadioButton rdb_OnlyNotInOffer;
        private System.Windows.Forms.RadioButton rdb_All;
        private System.Windows.Forms.RadioButton rdb_OnlyInOffer;

    }
}