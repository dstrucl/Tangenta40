namespace Tangenta
{
    partial class Form_myOrg_Person_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_myOrg_Person_Edit));
            this.usrc_NavigationButtons1 = new NavigationButtons.usrc_NavigationButtons();
            this.btn_PersonData_Edit = new System.Windows.Forms.Button();
            this.usrc_EditTable1 = new CodeTables.TableDocking_Form.usrc_EditTable();
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
            this.usrc_NavigationButtons1.Size = new System.Drawing.Size(866, 28);
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
            // btn_PersonData_Edit
            // 
            this.btn_PersonData_Edit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_PersonData_Edit.Location = new System.Drawing.Point(2, 31);
            this.btn_PersonData_Edit.Name = "btn_PersonData_Edit";
            this.btn_PersonData_Edit.Size = new System.Drawing.Size(437, 34);
            this.btn_PersonData_Edit.TabIndex = 6;
            this.btn_PersonData_Edit.Text = "More Person Data ";
            this.btn_PersonData_Edit.UseVisualStyleBackColor = false;
            this.btn_PersonData_Edit.Click += new System.EventHandler(this.btn_PersonData_Edit_Click);
            // 
            // usrc_EditTable1
            // 
            this.usrc_EditTable1.AllowUserToAddNew = true;
            this.usrc_EditTable1.AllowUserToChange = true;
            this.usrc_EditTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable1.GetRandomData = false;
            this.usrc_EditTable1.Location = new System.Drawing.Point(2, 70);
            this.usrc_EditTable1.Name = "usrc_EditTable1";
            this.usrc_EditTable1.SelectionButtonVisible = true;
            this.usrc_EditTable1.Size = new System.Drawing.Size(861, 550);
            this.usrc_EditTable1.TabIndex = 3;
            this.usrc_EditTable1.Title = "";
            this.usrc_EditTable1.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable1.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable1.after_FillDataInputControl += new CodeTables.TableDocking_Form.usrc_EditRow.delegate_after_FillDataInputControl(this.usrc_EditTable1_after_FillDataInputControl_1);
            this.usrc_EditTable1.FillTable += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_FillTable(this.usrc_EditTable1_FillTable);
            this.usrc_EditTable1.after_New += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_after_New(this.usrc_EditTable1_after_New);
            this.usrc_EditTable1.before_InsertInDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_before_InsertInDataBase(this.usrc_EditTable1_before_InsertInDataBase);
            this.usrc_EditTable1.before_UpdateDataBase += new CodeTables.TableDocking_Form.usrc_EditTable.delegate_before_UpdateDataBase(this.usrc_EditTable1_before_UpdateDataBase);
            // 
            // Form_myOrg_Person_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(866, 620);
            this.Controls.Add(this.btn_PersonData_Edit);
            this.Controls.Add(this.usrc_NavigationButtons1);
            this.Controls.Add(this.usrc_EditTable1);
            this.KeyPreview = true;
            this.Name = "Form_myOrg_Person_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyOrganisationData_EditForm";
            this.Load += new System.EventHandler(this.Form_myOrg_Person_Edit_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_myOrg_Person_Edit_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private CodeTables.TableDocking_Form.usrc_EditTable usrc_EditTable1;
        private NavigationButtons.usrc_NavigationButtons usrc_NavigationButtons1;
        private System.Windows.Forms.Button btn_PersonData_Edit;
    }
}