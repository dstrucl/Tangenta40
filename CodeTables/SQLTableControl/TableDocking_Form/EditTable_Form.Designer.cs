namespace CodeTables
{
    partial class EditTable_Form
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
            this.usrc_EditRow = new CodeTables.TableDocking_Form.usrc_EditRow();
            this.SuspendLayout();
            // 
            // usrc_EditRow
            // 
            this.usrc_EditRow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditRow.bNewDataEntry = false;
            this.usrc_EditRow.Location = new System.Drawing.Point(1, 11);
            this.usrc_EditRow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usrc_EditRow.Name = "usrc_EditRow";
            this.usrc_EditRow.Size = new System.Drawing.Size(645, 528);
            this.usrc_EditRow.TabIndex = 0;
            this.usrc_EditRow.Update += new CodeTables.TableDocking_Form.usrc_EditRow.delegate_Update(this.usrc_EditTable_Update);
            // 
            // EditTable_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(648, 531);
            this.Controls.Add(this.usrc_EditRow);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditTable_Form";
            this.Text = "Edit Table";
            this.Load += new System.EventHandler(this.EditTable_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CodeTables.TableDocking_Form.usrc_EditRow usrc_EditRow;


    }
}