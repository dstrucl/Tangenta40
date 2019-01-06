namespace TangentaCore
{
    partial class Form_Customer_Org_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Customer_Org_Edit));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_BankAccounts = new System.Windows.Forms.Button();
            this.btn_OrganisationData = new System.Windows.Forms.Button();
            this.usrc_EditTable = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = TangentaResources.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(792, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(60, 24);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OK.Location = new System.Drawing.Point(713, 3);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(73, 24);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_BankAccounts
            // 
            this.btn_BankAccounts.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_BankAccounts.Location = new System.Drawing.Point(224, 1);
            this.btn_BankAccounts.Name = "btn_BankAccounts";
            this.btn_BankAccounts.Size = new System.Drawing.Size(191, 26);
            this.btn_BankAccounts.TabIndex = 8;
            this.btn_BankAccounts.Text = "Organisation Bank Account";
            this.btn_BankAccounts.UseVisualStyleBackColor = false;
            this.btn_BankAccounts.Click += new System.EventHandler(this.btn_BankAccounts_Click);
            // 
            // btn_OrganisationData
            // 
            this.btn_OrganisationData.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_OrganisationData.Location = new System.Drawing.Point(4, 1);
            this.btn_OrganisationData.Name = "btn_OrganisationData";
            this.btn_OrganisationData.Size = new System.Drawing.Size(203, 26);
            this.btn_OrganisationData.TabIndex = 7;
            this.btn_OrganisationData.Text = "Organisation Data";
            this.btn_OrganisationData.UseVisualStyleBackColor = false;
            this.btn_OrganisationData.Click += new System.EventHandler(this.btn_OrganisationData_Click);
            // 
            // usrc_EditTable
            // 
            this.usrc_EditTable.AllowUserToAddNew = true;
            this.usrc_EditTable.AllowUserToChange = true;
            this.usrc_EditTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable.GetRandomData = false;
            this.usrc_EditTable.Location = new System.Drawing.Point(4, 33);
            this.usrc_EditTable.Name = "usrc_EditTable";
            this.usrc_EditTable.SelectionButtonVisible = false;
            this.usrc_EditTable.Size = new System.Drawing.Size(897, 572);
            this.usrc_EditTable.TabIndex = 0;
            this.usrc_EditTable.Title = "";
            this.usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable.after_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_after_InsertInDataBase);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_Help1.Location = new System.Drawing.Point(861, 3);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(39, 24);
            this.usrc_Help1.TabIndex = 9;
            // 
            // Form_Customer_Org_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(905, 607);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_BankAccounts);
            this.Controls.Add(this.btn_OrganisationData);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.usrc_EditTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_Customer_Org_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Item_EditForm_FormClosing);
            this.Load += new System.EventHandler(this.Form_Customer_Person_Edit_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_Customer_Org_Edit_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_BankAccounts;
        private System.Windows.Forms.Button btn_OrganisationData;
        private HUDCMS.usrc_Help usrc_Help1;
    }
}