namespace TangentaCore
{
    partial class Form_TableInspection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TableInspection));
            this.btn_ShopB_TablesInspection = new System.Windows.Forms.Button();
            this.btn_ShopC_TablesInspection = new System.Windows.Forms.Button();
            this.btn_ShopA_TablesInspection = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_View_SQL_StateMents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ShopB_TablesInspection
            // 
            this.btn_ShopB_TablesInspection.Image = Properties.Resources.TableInspection_ShopB;
            this.btn_ShopB_TablesInspection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ShopB_TablesInspection.Location = new System.Drawing.Point(171, 66);
            this.btn_ShopB_TablesInspection.Name = "btn_ShopB_TablesInspection";
            this.btn_ShopB_TablesInspection.Size = new System.Drawing.Size(153, 48);
            this.btn_ShopB_TablesInspection.TabIndex = 0;
            this.btn_ShopB_TablesInspection.Text = "Shop";
            this.btn_ShopB_TablesInspection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ShopB_TablesInspection.UseVisualStyleBackColor = true;
            this.btn_ShopB_TablesInspection.Click += new System.EventHandler(this.btn_ShopB_TablesInspection_Click);
            // 
            // btn_ShopC_TablesInspection
            // 
            this.btn_ShopC_TablesInspection.Image = Properties.Resources.TableInspection_ShopC;
            this.btn_ShopC_TablesInspection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ShopC_TablesInspection.Location = new System.Drawing.Point(330, 66);
            this.btn_ShopC_TablesInspection.Name = "btn_ShopC_TablesInspection";
            this.btn_ShopC_TablesInspection.Size = new System.Drawing.Size(153, 48);
            this.btn_ShopC_TablesInspection.TabIndex = 1;
            this.btn_ShopC_TablesInspection.Text = "Shop";
            this.btn_ShopC_TablesInspection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ShopC_TablesInspection.UseVisualStyleBackColor = true;
            this.btn_ShopC_TablesInspection.Click += new System.EventHandler(this.btn_ShopC_TablesInspection_Click);
            // 
            // btn_ShopA_TablesInspection
            // 
            this.btn_ShopA_TablesInspection.Image = Properties.Resources.TableInspection_ShopA;
            this.btn_ShopA_TablesInspection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ShopA_TablesInspection.Location = new System.Drawing.Point(12, 66);
            this.btn_ShopA_TablesInspection.Name = "btn_ShopA_TablesInspection";
            this.btn_ShopA_TablesInspection.Size = new System.Drawing.Size(153, 48);
            this.btn_ShopA_TablesInspection.TabIndex = 2;
            this.btn_ShopA_TablesInspection.Text = "Shop";
            this.btn_ShopA_TablesInspection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ShopA_TablesInspection.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = Properties.Resources.Exit;
            this.btn_Exit.Location = new System.Drawing.Point(367, 12);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(116, 48);
            this.btn_Exit.TabIndex = 3;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_View_SQL_StateMents
            // 
            this.btn_View_SQL_StateMents.Image = Properties.Resources.TableInspection_Shop_dtSQLdb;
            this.btn_View_SQL_StateMents.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View_SQL_StateMents.Location = new System.Drawing.Point(12, 12);
            this.btn_View_SQL_StateMents.Name = "btn_View_SQL_StateMents";
            this.btn_View_SQL_StateMents.Size = new System.Drawing.Size(153, 48);
            this.btn_View_SQL_StateMents.TabIndex = 4;
            this.btn_View_SQL_StateMents.Text = "dtSQLdb";
            this.btn_View_SQL_StateMents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View_SQL_StateMents.UseVisualStyleBackColor = true;
            this.btn_View_SQL_StateMents.Click += new System.EventHandler(this.btn_View_SQL_StateMents_Click);
            // 
            // Form_TableInspection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(497, 129);
            this.Controls.Add(this.btn_View_SQL_StateMents);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_ShopA_TablesInspection);
            this.Controls.Add(this.btn_ShopC_TablesInspection);
            this.Controls.Add(this.btn_ShopB_TablesInspection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_TableInspection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_TableInspection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_ShopB_TablesInspection;
        private System.Windows.Forms.Button btn_ShopC_TablesInspection;
        private System.Windows.Forms.Button btn_ShopA_TablesInspection;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_View_SQL_StateMents;
    }
}