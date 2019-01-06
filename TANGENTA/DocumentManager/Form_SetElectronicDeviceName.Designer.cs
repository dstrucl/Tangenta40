namespace DocumentManager
{
    partial class Form_SetElectronicDeviceName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SetElectronicDeviceName));
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.lbl_ElectronicDevice_Name = new System.Windows.Forms.Label();
            this.txt_ElectronicDevice_Name = new System.Windows.Forms.TextBox();
            this.txt_ElectronicDevice_Description = new System.Windows.Forms.TextBox();
            this.lbl_ElectronicDevice_Description = new System.Windows.Forms.Label();
            this.lbl_ComputerName = new System.Windows.Forms.Label();
            this.txt_ComputerName = new System.Windows.Forms.TextBox();
            this.txt_ComputerUserName = new System.Windows.Forms.TextBox();
            this.lbl_ComputerUsername = new System.Windows.Forms.Label();
            this.txt_MAC_address = new System.Windows.Forms.TextBox();
            this.lbl_MAC_address = new System.Windows.Forms.Label();
            this.dgvx_ElectronicDevice = new DataGridView_2xls.DataGridView2xls();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_Write = new System.Windows.Forms.Button();
            this.txt_Office_ShortName = new System.Windows.Forms.TextBox();
            this.lbl_Office_ShortName = new System.Windows.Forms.Label();
            this.txt_Office = new System.Windows.Forms.TextBox();
            this.lbl_Office = new System.Windows.Forms.Label();
            this.lbl_SelectOffice = new System.Windows.Forms.Label();
            this.dgvx_Office = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ElectronicDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Office)).BeginInit();
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
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(799, 27);
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
            // lbl_ElectronicDevice_Name
            // 
            this.lbl_ElectronicDevice_Name.Location = new System.Drawing.Point(7, 81);
            this.lbl_ElectronicDevice_Name.Name = "lbl_ElectronicDevice_Name";
            this.lbl_ElectronicDevice_Name.Size = new System.Drawing.Size(148, 19);
            this.lbl_ElectronicDevice_Name.TabIndex = 1;
            this.lbl_ElectronicDevice_Name.Text = "Electronic Device Name:";
            // 
            // txt_ElectronicDevice_Name
            // 
            this.txt_ElectronicDevice_Name.Location = new System.Drawing.Point(161, 79);
            this.txt_ElectronicDevice_Name.Name = "txt_ElectronicDevice_Name";
            this.txt_ElectronicDevice_Name.Size = new System.Drawing.Size(244, 20);
            this.txt_ElectronicDevice_Name.TabIndex = 2;
            // 
            // txt_ElectronicDevice_Description
            // 
            this.txt_ElectronicDevice_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ElectronicDevice_Description.Location = new System.Drawing.Point(3, 121);
            this.txt_ElectronicDevice_Description.Multiline = true;
            this.txt_ElectronicDevice_Description.Name = "txt_ElectronicDevice_Description";
            this.txt_ElectronicDevice_Description.Size = new System.Drawing.Size(402, 52);
            this.txt_ElectronicDevice_Description.TabIndex = 4;
            // 
            // lbl_ElectronicDevice_Description
            // 
            this.lbl_ElectronicDevice_Description.Location = new System.Drawing.Point(7, 102);
            this.lbl_ElectronicDevice_Description.Name = "lbl_ElectronicDevice_Description";
            this.lbl_ElectronicDevice_Description.Size = new System.Drawing.Size(200, 15);
            this.lbl_ElectronicDevice_Description.TabIndex = 3;
            this.lbl_ElectronicDevice_Description.Text = "Electronic Device Description:";
            // 
            // lbl_ComputerName
            // 
            this.lbl_ComputerName.Location = new System.Drawing.Point(10, 180);
            this.lbl_ComputerName.Name = "lbl_ComputerName";
            this.lbl_ComputerName.Size = new System.Drawing.Size(145, 19);
            this.lbl_ComputerName.TabIndex = 5;
            this.lbl_ComputerName.Text = "Computer Name:";
            this.lbl_ComputerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_ComputerName
            // 
            this.txt_ComputerName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ComputerName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ComputerName.Location = new System.Drawing.Point(153, 184);
            this.txt_ComputerName.Name = "txt_ComputerName";
            this.txt_ComputerName.ReadOnly = true;
            this.txt_ComputerName.Size = new System.Drawing.Size(226, 13);
            this.txt_ComputerName.TabIndex = 6;
            // 
            // txt_ComputerUserName
            // 
            this.txt_ComputerUserName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ComputerUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ComputerUserName.Location = new System.Drawing.Point(153, 222);
            this.txt_ComputerUserName.Name = "txt_ComputerUserName";
            this.txt_ComputerUserName.ReadOnly = true;
            this.txt_ComputerUserName.Size = new System.Drawing.Size(226, 13);
            this.txt_ComputerUserName.TabIndex = 8;
            // 
            // lbl_ComputerUsername
            // 
            this.lbl_ComputerUsername.Location = new System.Drawing.Point(10, 214);
            this.lbl_ComputerUsername.Name = "lbl_ComputerUsername";
            this.lbl_ComputerUsername.Size = new System.Drawing.Size(145, 19);
            this.lbl_ComputerUsername.TabIndex = 7;
            this.lbl_ComputerUsername.Text = "Computer User Name:";
            this.lbl_ComputerUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_MAC_address
            // 
            this.txt_MAC_address.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_MAC_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_MAC_address.Location = new System.Drawing.Point(153, 203);
            this.txt_MAC_address.Name = "txt_MAC_address";
            this.txt_MAC_address.ReadOnly = true;
            this.txt_MAC_address.Size = new System.Drawing.Size(226, 13);
            this.txt_MAC_address.TabIndex = 10;
            // 
            // lbl_MAC_address
            // 
            this.lbl_MAC_address.Location = new System.Drawing.Point(10, 199);
            this.lbl_MAC_address.Name = "lbl_MAC_address";
            this.lbl_MAC_address.Size = new System.Drawing.Size(145, 19);
            this.lbl_MAC_address.TabIndex = 9;
            this.lbl_MAC_address.Text = "MAC address:";
            this.lbl_MAC_address.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvx_ElectronicDevice
            // 
            this.dgvx_ElectronicDevice.AllowUserToAddRows = false;
            this.dgvx_ElectronicDevice.AllowUserToDeleteRows = false;
            this.dgvx_ElectronicDevice.AllowUserToOrderColumns = true;
            this.dgvx_ElectronicDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_ElectronicDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_ElectronicDevice.DataGridViewWithRowNumber = false;
            this.dgvx_ElectronicDevice.Location = new System.Drawing.Point(3, 292);
            this.dgvx_ElectronicDevice.MultiSelect = false;
            this.dgvx_ElectronicDevice.Name = "dgvx_ElectronicDevice";
            this.dgvx_ElectronicDevice.ReadOnly = true;
            this.dgvx_ElectronicDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_ElectronicDevice.Size = new System.Drawing.Size(402, 208);
            this.dgvx_ElectronicDevice.TabIndex = 13;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_Write);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Office_ShortName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Office_ShortName);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Office);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Office);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ElectronicDevice_Name);
            this.splitContainer1.Panel1.Controls.Add(this.dgvx_ElectronicDevice);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ElectronicDevice_Name);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ElectronicDevice_Description);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ElectronicDevice_Description);
            this.splitContainer1.Panel1.Controls.Add(this.txt_MAC_address);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ComputerName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_MAC_address);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ComputerName);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ComputerUserName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ComputerUsername);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbl_SelectOffice);
            this.splitContainer1.Panel2.Controls.Add(this.dgvx_Office);
            this.splitContainer1.Size = new System.Drawing.Size(799, 503);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 14;
            // 
            // btn_Write
            // 
            this.btn_Write.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Write.Location = new System.Drawing.Point(3, 265);
            this.btn_Write.Name = "btn_Write";
            this.btn_Write.Size = new System.Drawing.Size(402, 22);
            this.btn_Write.TabIndex = 18;
            this.btn_Write.Text = "Add";
            this.btn_Write.UseVisualStyleBackColor = true;
            this.btn_Write.Click += new System.EventHandler(this.btn_Write_Click);
            // 
            // txt_Office_ShortName
            // 
            this.txt_Office_ShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Office_ShortName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Office_ShortName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Office_ShortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Office_ShortName.Location = new System.Drawing.Point(143, 36);
            this.txt_Office_ShortName.Name = "txt_Office_ShortName";
            this.txt_Office_ShortName.ReadOnly = true;
            this.txt_Office_ShortName.Size = new System.Drawing.Size(64, 19);
            this.txt_Office_ShortName.TabIndex = 17;
            // 
            // lbl_Office_ShortName
            // 
            this.lbl_Office_ShortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Office_ShortName.Location = new System.Drawing.Point(7, 35);
            this.lbl_Office_ShortName.Name = "lbl_Office_ShortName";
            this.lbl_Office_ShortName.Size = new System.Drawing.Size(130, 19);
            this.lbl_Office_ShortName.TabIndex = 16;
            this.lbl_Office_ShortName.Text = "Office abr.";
            this.lbl_Office_ShortName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Office
            // 
            this.txt_Office.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Office.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Office.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Office.Location = new System.Drawing.Point(143, 11);
            this.txt_Office.Name = "txt_Office";
            this.txt_Office.ReadOnly = true;
            this.txt_Office.Size = new System.Drawing.Size(262, 19);
            this.txt_Office.TabIndex = 15;
            // 
            // lbl_Office
            // 
            this.lbl_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_Office.Location = new System.Drawing.Point(7, 10);
            this.lbl_Office.Name = "lbl_Office";
            this.lbl_Office.Size = new System.Drawing.Size(130, 19);
            this.lbl_Office.TabIndex = 14;
            this.lbl_Office.Text = "Office";
            this.lbl_Office.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_SelectOffice
            // 
            this.lbl_SelectOffice.AutoSize = true;
            this.lbl_SelectOffice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_SelectOffice.Location = new System.Drawing.Point(14, 8);
            this.lbl_SelectOffice.Name = "lbl_SelectOffice";
            this.lbl_SelectOffice.Size = new System.Drawing.Size(97, 20);
            this.lbl_SelectOffice.TabIndex = 17;
            this.lbl_SelectOffice.Text = "Select office";
            // 
            // dgvx_Office
            // 
            this.dgvx_Office.AllowUserToAddRows = false;
            this.dgvx_Office.AllowUserToDeleteRows = false;
            this.dgvx_Office.AllowUserToOrderColumns = true;
            this.dgvx_Office.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvx_Office.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvx_Office.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvx_Office.DataGridViewWithRowNumber = true;
            this.dgvx_Office.Location = new System.Drawing.Point(3, 33);
            this.dgvx_Office.MultiSelect = false;
            this.dgvx_Office.Name = "dgvx_Office";
            this.dgvx_Office.ReadOnly = true;
            this.dgvx_Office.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvx_Office.ShowCellErrors = false;
            this.dgvx_Office.Size = new System.Drawing.Size(381, 458);
            this.dgvx_Office.TabIndex = 16;
            // 
            // Form_SetElectronicDeviceName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(799, 533);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SetElectronicDeviceName";
            this.Text = "Form_SetElectronicDeviceName";
            this.Load += new System.EventHandler(this.Form_SetElectronicDeviceName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_ElectronicDevice)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvx_Office)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.Label lbl_ElectronicDevice_Name;
        private System.Windows.Forms.TextBox txt_ElectronicDevice_Name;
        private System.Windows.Forms.TextBox txt_ElectronicDevice_Description;
        private System.Windows.Forms.Label lbl_ElectronicDevice_Description;
        private System.Windows.Forms.Label lbl_ComputerName;
        private System.Windows.Forms.TextBox txt_ComputerName;
        private System.Windows.Forms.TextBox txt_ComputerUserName;
        private System.Windows.Forms.Label lbl_ComputerUsername;
        private System.Windows.Forms.TextBox txt_MAC_address;
        private System.Windows.Forms.Label lbl_MAC_address;
        private DataGridView_2xls.DataGridView2xls dgvx_ElectronicDevice;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_Office;
        private System.Windows.Forms.Label lbl_Office;
        private System.Windows.Forms.Label lbl_SelectOffice;
        private DataGridView_2xls.DataGridView2xls dgvx_Office;
        private System.Windows.Forms.TextBox txt_Office_ShortName;
        private System.Windows.Forms.Label lbl_Office_ShortName;
        private System.Windows.Forms.Button btn_Write;
    }
}