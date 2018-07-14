namespace Tangenta
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
            this.txt_IP_address = new System.Windows.Forms.TextBox();
            this.lbl_IP_address = new System.Windows.Forms.Label();
            this.dataGridView2xls1 = new DataGridView_2xls.DataGridView2xls();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2xls1)).BeginInit();
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
            // 
            // lbl_ElectronicDevice_Name
            // 
            this.lbl_ElectronicDevice_Name.Location = new System.Drawing.Point(6, 33);
            this.lbl_ElectronicDevice_Name.Name = "lbl_ElectronicDevice_Name";
            this.lbl_ElectronicDevice_Name.Size = new System.Drawing.Size(148, 19);
            this.lbl_ElectronicDevice_Name.TabIndex = 1;
            this.lbl_ElectronicDevice_Name.Text = "Electronic Device Name:";
            // 
            // txt_ElectronicDevice_Name
            // 
            this.txt_ElectronicDevice_Name.Location = new System.Drawing.Point(160, 31);
            this.txt_ElectronicDevice_Name.Name = "txt_ElectronicDevice_Name";
            this.txt_ElectronicDevice_Name.Size = new System.Drawing.Size(244, 20);
            this.txt_ElectronicDevice_Name.TabIndex = 2;
            // 
            // txt_ElectronicDevice_Description
            // 
            this.txt_ElectronicDevice_Description.Location = new System.Drawing.Point(160, 57);
            this.txt_ElectronicDevice_Description.Multiline = true;
            this.txt_ElectronicDevice_Description.Name = "txt_ElectronicDevice_Description";
            this.txt_ElectronicDevice_Description.Size = new System.Drawing.Size(469, 118);
            this.txt_ElectronicDevice_Description.TabIndex = 4;
            // 
            // lbl_ElectronicDevice_Description
            // 
            this.lbl_ElectronicDevice_Description.Location = new System.Drawing.Point(6, 59);
            this.lbl_ElectronicDevice_Description.Name = "lbl_ElectronicDevice_Description";
            this.lbl_ElectronicDevice_Description.Size = new System.Drawing.Size(148, 22);
            this.lbl_ElectronicDevice_Description.TabIndex = 3;
            this.lbl_ElectronicDevice_Description.Text = "Electronic Device Description:";
            // 
            // lbl_ComputerName
            // 
            this.lbl_ComputerName.Location = new System.Drawing.Point(9, 193);
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
            this.txt_ComputerName.Location = new System.Drawing.Point(152, 197);
            this.txt_ComputerName.Name = "txt_ComputerName";
            this.txt_ComputerName.ReadOnly = true;
            this.txt_ComputerName.Size = new System.Drawing.Size(226, 13);
            this.txt_ComputerName.TabIndex = 6;
            // 
            // txt_ComputerUserName
            // 
            this.txt_ComputerUserName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_ComputerUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ComputerUserName.Location = new System.Drawing.Point(544, 197);
            this.txt_ComputerUserName.Name = "txt_ComputerUserName";
            this.txt_ComputerUserName.ReadOnly = true;
            this.txt_ComputerUserName.Size = new System.Drawing.Size(226, 13);
            this.txt_ComputerUserName.TabIndex = 8;
            // 
            // lbl_ComputerUsername
            // 
            this.lbl_ComputerUsername.Location = new System.Drawing.Point(401, 193);
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
            this.txt_MAC_address.Location = new System.Drawing.Point(152, 216);
            this.txt_MAC_address.Name = "txt_MAC_address";
            this.txt_MAC_address.ReadOnly = true;
            this.txt_MAC_address.Size = new System.Drawing.Size(226, 13);
            this.txt_MAC_address.TabIndex = 10;
            // 
            // lbl_MAC_address
            // 
            this.lbl_MAC_address.Location = new System.Drawing.Point(9, 212);
            this.lbl_MAC_address.Name = "lbl_MAC_address";
            this.lbl_MAC_address.Size = new System.Drawing.Size(145, 19);
            this.lbl_MAC_address.TabIndex = 9;
            this.lbl_MAC_address.Text = "MAC address:";
            this.lbl_MAC_address.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_IP_address
            // 
            this.txt_IP_address.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_IP_address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_IP_address.Location = new System.Drawing.Point(544, 218);
            this.txt_IP_address.Name = "txt_IP_address";
            this.txt_IP_address.ReadOnly = true;
            this.txt_IP_address.Size = new System.Drawing.Size(226, 13);
            this.txt_IP_address.TabIndex = 12;
            // 
            // lbl_IP_address
            // 
            this.lbl_IP_address.Location = new System.Drawing.Point(401, 214);
            this.lbl_IP_address.Name = "lbl_IP_address";
            this.lbl_IP_address.Size = new System.Drawing.Size(145, 19);
            this.lbl_IP_address.TabIndex = 11;
            this.lbl_IP_address.Text = "IP address:";
            this.lbl_IP_address.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView2xls1
            // 
            this.dataGridView2xls1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2xls1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2xls1.DataGridViewWithRowNumber = false;
            this.dataGridView2xls1.Location = new System.Drawing.Point(12, 244);
            this.dataGridView2xls1.Name = "dataGridView2xls1";
            this.dataGridView2xls1.Size = new System.Drawing.Size(775, 203);
            this.dataGridView2xls1.TabIndex = 13;
            // 
            // Form_SetElectronicDeviceName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(799, 459);
            this.Controls.Add(this.dataGridView2xls1);
            this.Controls.Add(this.txt_IP_address);
            this.Controls.Add(this.lbl_IP_address);
            this.Controls.Add(this.txt_MAC_address);
            this.Controls.Add(this.lbl_MAC_address);
            this.Controls.Add(this.txt_ComputerUserName);
            this.Controls.Add(this.lbl_ComputerUsername);
            this.Controls.Add(this.txt_ComputerName);
            this.Controls.Add(this.lbl_ComputerName);
            this.Controls.Add(this.txt_ElectronicDevice_Description);
            this.Controls.Add(this.lbl_ElectronicDevice_Description);
            this.Controls.Add(this.txt_ElectronicDevice_Name);
            this.Controls.Add(this.lbl_ElectronicDevice_Name);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SetElectronicDeviceName";
            this.Text = "Form_SetElectronicDeviceName";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2xls1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox txt_IP_address;
        private System.Windows.Forms.Label lbl_IP_address;
        private DataGridView_2xls.DataGridView2xls dataGridView2xls1;
    }
}