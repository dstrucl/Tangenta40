﻿namespace Tangenta
{
    partial class Form_myOrg_Office_Data_FVI_SLO_RealEstateBP
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
            this.usrc_EditTable1 = new SQLTableControl.TableDocking_Form.usrc_EditTable();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usrc_EditTable1
            // 
            this.usrc_EditTable1.AllowUserToAddNew = true;
            this.usrc_EditTable1.AllowUserToChange = true;
            this.usrc_EditTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrc_EditTable1.GetRandomData = false;
            this.usrc_EditTable1.Location = new System.Drawing.Point(1, 0);
            this.usrc_EditTable1.Name = "usrc_EditTable1";
            this.usrc_EditTable1.SelectionButtonVisible = true;
            this.usrc_EditTable1.Size = new System.Drawing.Size(722, 500);
            this.usrc_EditTable1.TabIndex = 0;
            this.usrc_EditTable1.Title = "Urejanje Poslovnih enot";
            this.usrc_EditTable1.Title_Color = System.Drawing.SystemColors.ControlText;
            this.usrc_EditTable1.Title_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usrc_EditTable1.FillTable += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_FillTable(this.usrc_EditTable1_FillTable);
            this.usrc_EditTable1.after_New += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_New(this.usrc_EditTable1_after_New);
            this.usrc_EditTable1.after_InsertInDataBase += new SQLTableControl.TableDocking_Form.usrc_EditTable.delegate_after_InsertInDataBase(this.usrc_EditTable1_after_InsertInDataBase);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Cancel.Image = global::Tangenta.Properties.Resources.Exit;
            this.btn_Cancel.Location = new System.Drawing.Point(3, 506);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(94, 36);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Form_myOrg_Office_Data_FVI_SLO_RealEstateBP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 547);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.usrc_EditTable1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form_myOrg_Office_Data_FVI_SLO_RealEstateBP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_myOrg_Offices_Edit";
            this.Load += new System.EventHandler(this.Form_myOrg_Offices_Edit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SQLTableControl.TableDocking_Form.usrc_EditTable usrc_EditTable1;
        private System.Windows.Forms.Button btn_Cancel;
    }
}