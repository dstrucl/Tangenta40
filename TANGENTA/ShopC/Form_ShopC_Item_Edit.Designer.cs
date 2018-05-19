namespace ShopC
{
    partial class Form_ShopC_Item_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ShopC_Item_Edit));
            this.usrc_EditTable = new CodeTables.TableDocking_Form.usrc_EditTable();
            this.rdb_OnlyNotInOffer = new System.Windows.Forms.RadioButton();
            this.rdb_All = new System.Windows.Forms.RadioButton();
            this.rdb_OnlyInOffer = new System.Windows.Forms.RadioButton();
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
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
            this.usrc_EditTable.Location = new System.Drawing.Point(4, 65);
            this.usrc_EditTable.Name = "usrc_EditTable";
            this.usrc_EditTable.SelectionButtonVisible = false;
            this.usrc_EditTable.Size = new System.Drawing.Size(897, 446);
            this.usrc_EditTable.TabIndex = 0;
            this.usrc_EditTable.Title = "";
            this.usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable.after_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_after_InsertInDataBase);
            this.usrc_EditTable.after_UpdateDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_UpdateDataBase(this.usrc_EditTable_after_UpdateDataBase);
            this.usrc_EditTable.SelectedIndexChanged += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_SelectedIndexChanged(this.usrc_EditTable_SelectedIndexChanged);
            this.usrc_EditTable.RowReferenceFromTable_Check_NoChangeToOther += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_RowReferenceFromTable_Check_NoChangeToOther(this.usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther);
            // 
            // rdb_OnlyNotInOffer
            // 
            this.rdb_OnlyNotInOffer.AutoSize = true;
            this.rdb_OnlyNotInOffer.Location = new System.Drawing.Point(201, 33);
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
            this.rdb_All.AutoSize = true;
            this.rdb_All.Location = new System.Drawing.Point(415, 33);
            this.rdb_All.Name = "rdb_All";
            this.rdb_All.Size = new System.Drawing.Size(36, 17);
            this.rdb_All.TabIndex = 8;
            this.rdb_All.TabStop = true;
            this.rdb_All.Text = "All";
            this.rdb_All.UseVisualStyleBackColor = true;
            // 
            // rdb_OnlyInOffer
            // 
            this.rdb_OnlyInOffer.AutoSize = true;
            this.rdb_OnlyInOffer.Location = new System.Drawing.Point(6, 33);
            this.rdb_OnlyInOffer.Name = "rdb_OnlyInOffer";
            this.rdb_OnlyInOffer.Size = new System.Drawing.Size(72, 17);
            this.rdb_OnlyInOffer.TabIndex = 7;
            this.rdb_OnlyInOffer.TabStop = true;
            this.rdb_OnlyInOffer.Text = "Only Valid";
            this.rdb_OnlyInOffer.UseVisualStyleBackColor = true;
            // 
            // usrc_NavigationButtons1
            // 
            this.usrc_NavigationButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_NavigationButtons1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
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
            this.usrc_NavigationButtons1.Location = new System.Drawing.Point(0, 1);
            this.usrc_NavigationButtons1.Name = "usrc_NavigationButtons1";
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(904, 26);
            this.usrc_NavigationButtons1.TabIndex = 10;
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
            // Form_ShopC_Item_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(905, 514);
            this.Controls.Add(this.rdb_OnlyNotInOffer);
            this.Controls.Add(this.rdb_All);
            this.Controls.Add(this.rdb_OnlyInOffer);
            this.Controls.Add(this.usrc_EditTable);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_ShopC_Item_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Item_EditForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_ShopC_Item_Edit_FormClosed);
            this.Load += new System.EventHandler(this.MyOrganisationData_EditForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_ShopC_Item_Edit_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable;
        private System.Windows.Forms.RadioButton rdb_OnlyNotInOffer;
        private System.Windows.Forms.RadioButton rdb_All;
        private System.Windows.Forms.RadioButton rdb_OnlyInOffer;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
    }
}