﻿namespace Tangenta
{
    partial class Form_MyCompany_Person_Data_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MyCompany_Person_Data_Edit));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_BankAccounts = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dgvx_MyCompany = new DataGridView_2xls.DataGridView2xls();
            this.usrc_EditRow = new SQLTableControl.TableDocking_Form.usrc_EditRow();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_MyCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_BankAccounts);
            this.splitContainer1.Panel1.Controls.Add(this.usrc_EditRow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvx_MyCompany);
            this.splitContainer1.Size = new System.Drawing.Size(845, 523);
            this.splitContainer1.SplitterDistance = 421;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_BankAccounts
            // 
            this.btn_BankAccounts.Location = new System.Drawing.Point(4, 2);
            this.btn_BankAccounts.Name = "btn_BankAccounts";
            this.btn_BankAccounts.Size = new System.Drawing.Size(191, 26);
            this.btn_BankAccounts.TabIndex = 10;
            this.btn_BankAccounts.Text = "Organisation Bank Account";
            this.btn_BankAccounts.UseVisualStyleBackColor = true;
            this.btn_BankAccounts.Click += new System.EventHandler(this.btn_BankAccounts_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(259, 529);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(77, 30);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(431, 529);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(77, 30);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // dgvx_MyCompany
            // 
            this.dgvx_MyCompany.AllowUserToAddRows = false;
            this.dgvx_MyCompany.AllowUserToDeleteRows = false;
            this.dgvx_MyCompany.AllowUserToOrderColumns = true;
            this.dgvx_MyCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_MyCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_MyCompany.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvx_MyCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_MyCompany.DataGridViewWithRowNumber = false;
            this.dgvx_MyCompany.Location = new System.Drawing.Point(3, 6);
            this.dgvx_MyCompany.MultiSelect = false;
            this.dgvx_MyCompany.Name = "dgvx_MyCompany";
            this.dgvx_MyCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_MyCompany.Size = new System.Drawing.Size(835, 85);
            this.dgvx_MyCompany.TabIndex = 0;
            // 
            // usrc_EditRow
            // 
            this.usrc_EditRow.AllowUserToAddNew = true;
            this.usrc_EditRow.AllowUserToChange = true;
            this.usrc_EditRow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditRow.bNewDataEntry = false;
            this.usrc_EditRow.Changed = false;
            this.usrc_EditRow.GetRandomData = false;
            this.usrc_EditRow.Location = new System.Drawing.Point(4, 37);
            this.usrc_EditRow.Name = "usrc_EditRow";
            this.usrc_EditRow.SelectionButtonVisible = true;
            this.usrc_EditRow.Size = new System.Drawing.Size(835, 379);
            this.usrc_EditRow.TabIndex = 0;
            this.usrc_EditRow.Title = "";
            this.usrc_EditRow.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditRow.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditRow.Update += new SQLTableControl.TableDocking_Form.usrc_EditRow.delegate_Update(this.usrc_EditTable_Update);
            // 
            // Form_MyCompany_Person_Data_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(845, 563);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MyCompany_Person_Data_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyCompanyData_EditForm";
            this.Load += new System.EventHandler(this.MyCompanyData_EditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_MyCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private SQLTableControl.TableDocking_Form.usrc_EditRow usrc_EditRow;
        private DataGridView_2xls.DataGridView2xls dgvx_MyCompany;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_BankAccounts;
    }
}