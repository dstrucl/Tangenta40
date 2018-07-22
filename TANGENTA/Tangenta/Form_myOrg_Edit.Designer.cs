namespace Tangenta
{
    partial class Form_myOrg_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_myOrg_Edit));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_BankAccounts = new System.Windows.Forms.Button();
            this.btn_Office = new System.Windows.Forms.Button();
            this.usrc_EditRow = new CodeTables.TableDocking_Form.usrc_EditRow();
            this.dgvx_MyOrganisation = new DataGridView_2xls.DataGridView2xls();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_MyOrganisation)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_BankAccounts);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Office);
            this.splitContainer1.Panel1.Controls.Add(this.usrc_EditRow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvx_MyOrganisation);
            this.splitContainer1.Size = new System.Drawing.Size(866, 596);
            this.splitContainer1.SplitterDistance = 477;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_BankAccounts
            // 
            this.btn_BankAccounts.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_BankAccounts.Location = new System.Drawing.Point(277, 0);
            this.btn_BankAccounts.Name = "btn_BankAccounts";
            this.btn_BankAccounts.Size = new System.Drawing.Size(191, 26);
            this.btn_BankAccounts.TabIndex = 10;
            this.btn_BankAccounts.Text = "Organisation Bank Account";
            this.btn_BankAccounts.UseVisualStyleBackColor = false;
            this.btn_BankAccounts.Click += new System.EventHandler(this.btn_BankAccounts_Click);
            // 
            // btn_Office
            // 
            this.btn_Office.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Office.Location = new System.Drawing.Point(6, 0);
            this.btn_Office.Name = "btn_Office";
            this.btn_Office.Size = new System.Drawing.Size(266, 26);
            this.btn_Office.TabIndex = 11;
            this.btn_Office.Text = "Office Data";
            this.btn_Office.UseVisualStyleBackColor = false;
            this.btn_Office.Click += new System.EventHandler(this.btn_Office_Edit);
            // 
            // usrc_EditRow
            // 
            this.usrc_EditRow.AllowUserToAddNew = true;
            this.usrc_EditRow.AllowUserToChange = true;
            this.usrc_EditRow.bNewDataEntry = false;
            this.usrc_EditRow.Changed = false;
            this.usrc_EditRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrc_EditRow.GetRandomData = false;
            this.usrc_EditRow.Location = new System.Drawing.Point(0, 0);
            this.usrc_EditRow.Margin = new System.Windows.Forms.Padding(4);
            this.usrc_EditRow.Name = "usrc_EditRow";
            this.usrc_EditRow.SelectionButtonVisible = true;
            this.usrc_EditRow.Size = new System.Drawing.Size(866, 477);
            this.usrc_EditRow.TabIndex = 0;
            this.usrc_EditRow.Title = "";
            this.usrc_EditRow.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditRow.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditRow.FillTable += new CodeTables.SQLTable.delegate_FillTable(this.usrc_EditRow_FillTable);
            this.usrc_EditRow.SetInputControlProperties += new CodeTables.SQLTable.delegate_mySetInputControlProperties(this.usrc_EditRow_SetInputControlProperties);
            this.usrc_EditRow.before_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditRow.delegate_before_InsertInDataBase(this.usrc_EditRow_before_InsertInDataBase);
            this.usrc_EditRow.after_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditRow.delegate_after_InsertInDataBase(this.usrc_EditRow_after_InsertInDataBase);
            this.usrc_EditRow.before_UpdateDataBase += new CodeTables.TableDocking_Form.usrc_EditRow.delegate_before_UpdateDataBase(this.usrc_EditRow_before_UpdateDataBase);
            this.usrc_EditRow.Update += new CodeTables.TableDocking_Form.usrc_EditRow.delegate_Update(this.usrc_EditTable_Update);
            // 
            // dgvx_MyOrganisation
            // 
            this.dgvx_MyOrganisation.AllowUserToAddRows = false;
            this.dgvx_MyOrganisation.AllowUserToDeleteRows = false;
            this.dgvx_MyOrganisation.AllowUserToOrderColumns = true;
            this.dgvx_MyOrganisation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvx_MyOrganisation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvx_MyOrganisation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_MyOrganisation.DataGridViewWithRowNumber = false;
            this.dgvx_MyOrganisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvx_MyOrganisation.Location = new System.Drawing.Point(0, 0);
            this.dgvx_MyOrganisation.MultiSelect = false;
            this.dgvx_MyOrganisation.Name = "dgvx_MyOrganisation";
            this.dgvx_MyOrganisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_MyOrganisation.Size = new System.Drawing.Size(866, 115);
            this.dgvx_MyOrganisation.TabIndex = 0;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(0, -1);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(866, 27);
            this.usrc_NavigationButtons1.TabIndex = 1;
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
            // Form_myOrg_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(866, 625);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_myOrg_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyOrganisationData_EditForm";
            this.Load += new System.EventHandler(this.MyOrganisationData_EditForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_myOrg_Edit_KeyUp);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_MyOrganisation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CodeTables.TableDocking_Form.usrc_EditRow usrc_EditRow;
        private DataGridView_2xls.DataGridView2xls dgvx_MyOrganisation;
        private System.Windows.Forms.Button btn_BankAccounts;
        private System.Windows.Forms.Button btn_Office;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}