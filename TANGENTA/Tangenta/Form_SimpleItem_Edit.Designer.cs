namespace Tangenta
{
    partial class Form_SimpleItem_Edit
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
            this.usrc_EditTable = new SQLTableControl.TableDocking_Form.usrc_EditTable();
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
            this.usrc_EditTable.Location = new System.Drawing.Point(4, 2);
            this.usrc_EditTable.Name = "usrc_EditTable";
            this.usrc_EditTable.SelectionButtonVisible = false;
            this.usrc_EditTable.Size = new System.Drawing.Size(902, 607);
            this.usrc_EditTable.TabIndex = 0;
            this.usrc_EditTable.Title = "";
            this.usrc_EditTable.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable_after_InsertInDataBase);
            // 
            // Form_SimpleItem_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(905, 607);
            this.Controls.Add(this.usrc_EditTable);
            this.Name = "Form_SimpleItem_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleItem_EditForm";
            this.Load += new System.EventHandler(this.MyCompanyData_EditForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable;

    }
}