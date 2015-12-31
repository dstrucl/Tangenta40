namespace Tangenta
{
    partial class Form_ItemGroups_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ItemGroups_Edit));
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_EditTable = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.Location = new System.Drawing.Point(10, 299);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(46, 25);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Location = new System.Drawing.Point(102, 299);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(54, 25);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_EditTable
            // 
            this.usrc_EditTable.AllowUserToAddNew = true;
            this.usrc_EditTable.AllowUserToChange = true;
            this.usrc_EditTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable.GetRandomData = false;
            this.usrc_EditTable.Location = new System.Drawing.Point(4, 4);
            this.usrc_EditTable.Name = "usrc_EditTable";
            this.usrc_EditTable.SelectionButtonVisible = true;
            this.usrc_EditTable.Size = new System.Drawing.Size(766, 291);
            this.usrc_EditTable.TabIndex = 0;
            this.usrc_EditTable.Title = "";
            this.usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable.RowReferenceFromTable_Check_NoChangeToOther += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_RowReferenceFromTable_Check_NoChangeToOther(this.usrc_EditTable_RowReferenceFromTable_Check_NoChangeToOther);
            // 
            // Form_ItemGroups_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(774, 325);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.usrc_EditTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ItemGroups_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemGroups_EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ItemGroups_Edit_FormClosing);
            this.Load += new System.EventHandler(this.Form_ItemGroups_Edit_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}