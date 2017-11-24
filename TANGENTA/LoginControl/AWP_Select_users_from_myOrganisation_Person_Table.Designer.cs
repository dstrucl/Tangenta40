namespace LoginControl
{
    partial class AWP_Select_users_from_myOrganisation_Person_Table
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
            this.dgvx_myOrganisationPerson = new DataGridView_2xls.DataGridView2xls();
            this.btn_Import = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_myOrganisationPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvx_myOrganisationPerson
            // 
            this.dgvx_myOrganisationPerson.AllowUserToAddRows = false;
            this.dgvx_myOrganisationPerson.AllowUserToDeleteRows = false;
            this.dgvx_myOrganisationPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_myOrganisationPerson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_myOrganisationPerson.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvx_myOrganisationPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_myOrganisationPerson.DataGridViewWithRowNumber = true;
            this.dgvx_myOrganisationPerson.Location = new System.Drawing.Point(1, 68);
            this.dgvx_myOrganisationPerson.Name = "dgvx_myOrganisationPerson";
            this.dgvx_myOrganisationPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_myOrganisationPerson.Size = new System.Drawing.Size(675, 349);
            this.dgvx_myOrganisationPerson.TabIndex = 0;
            this.dgvx_myOrganisationPerson.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvx_myOrganisationPerson_DataError);
            // 
            // btn_Import
            // 
            this.btn_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Import.Location = new System.Drawing.Point(39, 422);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(198, 29);
            this.btn_Import.TabIndex = 1;
            this.btn_Import.Text = "Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(344, 422);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(198, 29);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Instruction.Location = new System.Drawing.Point(6, 5);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(669, 63);
            this.lbl_Instruction.TabIndex = 3;
            this.lbl_Instruction.Text = "label1";
            this.lbl_Instruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AWP_Select_users_from_myOrganisation_Person_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 454);
            this.Controls.Add(this.lbl_Instruction);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.dgvx_myOrganisationPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AWP_Select_users_from_myOrganisation_Person_Table";
            this.Text = "AWP_Select_users_from_myOrganisation_Person_Table";
            this.Load += new System.EventHandler(this.AWP_Select_users_from_myOrganisation_Person_Table_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_myOrganisationPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_myOrganisationPerson;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_Instruction;
    }
}