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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWP_Select_users_from_myOrganisation_Person_Table));
            this.dgvx_myOrganisationPerson = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
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
            this.dgvx_myOrganisationPerson.Size = new System.Drawing.Size(675, 367);
            this.dgvx_myOrganisationPerson.TabIndex = 0;
            this.dgvx_myOrganisationPerson.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvx_myOrganisationPerson_DataError);
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
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.Control;
            this.usrc_NavigationButtons1.btn1_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn2_ToolTip_Text = "";
            this.usrc_NavigationButtons1.btn3_ToolTip_Text = "";
            this.usrc_NavigationButtons1.Button_NEXT_Enabled = true;
            this.usrc_NavigationButtons1.Buttons = NavigationButtons.Navigation.eButtons.OkCancel;
            this.usrc_NavigationButtons1.ExitQuestion = "Exit Program?";
            this.usrc_NavigationButtons1.Image_Cancel = null;
            this.usrc_NavigationButtons1.Image_EXIT = null;
            this.usrc_NavigationButtons1.Image_NEXT = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_NEXT")));
            this.usrc_NavigationButtons1.Image_OK = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_OK")));
            this.usrc_NavigationButtons1.Image_PREV = ((System.Drawing.Image)(resources.GetObject("usrc_NavigationButtons1.Image_PREV")));
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(1, 442);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(675, 73);
            this.usrc_NavigationButtons1.TabIndex = 4;
            this.usrc_NavigationButtons1.Text_Cancel = "Exit";
            this.usrc_NavigationButtons1.Text_EXIT = "Exit";
            this.usrc_NavigationButtons1.Text_NEXT = "";
            this.usrc_NavigationButtons1.Text_OK = "";
            this.usrc_NavigationButtons1.Text_PREV = "";
            this.usrc_NavigationButtons1.Visible_EXIT = true;
            this.usrc_NavigationButtons1.Visible_NEXT = true;
            this.usrc_NavigationButtons1.Visible_PREV = true;
            this.usrc_NavigationButtons1.ButtonPressed += new NavigationButtons.usrc_NavigationButtons.delegate_button_pressed(this.usrc_NavigationButtons1_ButtonPressed);
            // 
            // AWP_Select_users_from_myOrganisation_Person_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 518);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.lbl_Instruction);
            this.Controls.Add(this.dgvx_myOrganisationPerson);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AWP_Select_users_from_myOrganisation_Person_Table";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AWP_Select_users_from_myOrganisation_Person_Table";
            this.Load += new System.EventHandler(this.AWP_Select_users_from_myOrganisation_Person_Table_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_myOrganisationPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView_2xls.DataGridView2xls dgvx_myOrganisationPerson;
        private System.Windows.Forms.Label lbl_Instruction;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}