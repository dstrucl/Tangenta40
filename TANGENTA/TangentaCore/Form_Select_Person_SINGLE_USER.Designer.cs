namespace TangentaCore
{
    partial class Form_Select_Person_SINGLE_USER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Select_Person_SINGLE_USER));
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.dgvx_my_Org_Person = new DataGridView_2xls.DataGridView2xls();
            this.lbl_Instruction = new System.Windows.Forms.Label();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_my_Org_Person)).BeginInit();
            this.SuspendLayout();
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(0, 0);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(691, 28);
            this.usrc_NavigationButtons1.TabIndex = 0;
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
            // dgvx_my_Org_Person
            // 
            this.dgvx_my_Org_Person.AllowUserToAddRows = false;
            this.dgvx_my_Org_Person.AllowUserToDeleteRows = false;
            this.dgvx_my_Org_Person.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_my_Org_Person.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_my_Org_Person.DataGridViewWithRowNumber = false;
            this.dgvx_my_Org_Person.Location = new System.Drawing.Point(0, 126);
            this.dgvx_my_Org_Person.MultiSelect = false;
            this.dgvx_my_Org_Person.Name = "dgvx_my_Org_Person";
            this.dgvx_my_Org_Person.ReadOnly = true;
            this.dgvx_my_Org_Person.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_my_Org_Person.Size = new System.Drawing.Size(690, 404);
            this.dgvx_my_Org_Person.TabIndex = 1;
            this.dgvx_my_Org_Person.SelectionChanged += new System.EventHandler(this.dgvx_my_Org_Person_SelectionChanged);
            // 
            // lbl_Instruction
            // 
            this.lbl_Instruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Instruction.ForeColor = System.Drawing.Color.Blue;
            this.lbl_Instruction.Location = new System.Drawing.Point(0, 31);
            this.lbl_Instruction.Name = "lbl_Instruction";
            this.lbl_Instruction.Size = new System.Drawing.Size(691, 43);
            this.lbl_Instruction.TabIndex = 2;
            this.lbl_Instruction.Text = "label1";
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_FirstName.Location = new System.Drawing.Point(9, 88);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(109, 21);
            this.lbl_FirstName.TabIndex = 3;
            this.lbl_FirstName.Text = "First name:";
            this.lbl_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_LastName.Location = new System.Drawing.Point(323, 88);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(109, 21);
            this.lbl_LastName.TabIndex = 4;
            this.lbl_LastName.Text = "Last name:";
            this.lbl_LastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_FirstName.Location = new System.Drawing.Point(118, 90);
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.ReadOnly = true;
            this.txt_FirstName.Size = new System.Drawing.Size(219, 19);
            this.txt_FirstName.TabIndex = 5;
            // 
            // txt_LastName
            // 
            this.txt_LastName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_LastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_LastName.Location = new System.Drawing.Point(438, 88);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.ReadOnly = true;
            this.txt_LastName.Size = new System.Drawing.Size(219, 19);
            this.txt_LastName.TabIndex = 6;
            // 
            // Form_Select_Person_SINGLE_USER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 533);
            this.Controls.Add(this.txt_LastName);
            this.Controls.Add(this.txt_FirstName);
            this.Controls.Add(this.lbl_LastName);
            this.Controls.Add(this.lbl_FirstName);
            this.Controls.Add(this.lbl_Instruction);
            this.Controls.Add(this.dgvx_my_Org_Person);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Select_Person_SINGLE_USER";
            this.Text = "Form_Select_Person_SINGLE_USER";
            this.Load += new System.EventHandler(this.Form_Select_Person_SINGLE_USER_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_my_Org_Person)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private DataGridView_2xls.DataGridView2xls dgvx_my_Org_Person;
        private System.Windows.Forms.Label lbl_Instruction;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.TextBox txt_LastName;
    }
}