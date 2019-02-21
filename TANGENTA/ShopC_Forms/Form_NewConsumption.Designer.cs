using System.Windows.Forms;

namespace ShopC_Forms
{
    partial class Form_NewConsumption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NewConsumption));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.usrc_Help1 = new HUDCMS.usrc_Help();
            this.dgv_ConsumptionType = new System.Windows.Forms.DataGridView();
            this.btn_NewConsumption = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConsumptionType)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(559, 5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(110, 44);
            this.btn_Cancel.TabIndex = 36;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // usrc_Help1
            // 
            this.usrc_Help1.Location = new System.Drawing.Point(487, 5);
            this.usrc_Help1.Margin = new System.Windows.Forms.Padding(6);
            this.usrc_Help1.Name = "usrc_Help1";
            this.usrc_Help1.Size = new System.Drawing.Size(63, 38);
            this.usrc_Help1.TabIndex = 40;
            // 
            // dgv_ConsumptionType
            // 
            this.dgv_ConsumptionType.AllowUserToAddRows = false;
            this.dgv_ConsumptionType.AllowUserToDeleteRows = false;
            this.dgv_ConsumptionType.AllowUserToResizeRows = false;
            this.dgv_ConsumptionType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ConsumptionType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ConsumptionType.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ConsumptionType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ConsumptionType.Location = new System.Drawing.Point(1, 53);
            this.dgv_ConsumptionType.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_ConsumptionType.Name = "dgv_ConsumptionType";
            this.dgv_ConsumptionType.ReadOnly = true;
            this.dgv_ConsumptionType.RowHeadersVisible = false;
            this.dgv_ConsumptionType.RowHeadersWidth = 81;
            this.dgv_ConsumptionType.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_ConsumptionType.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ConsumptionType.RowTemplate.Height = 80;
            this.dgv_ConsumptionType.Size = new System.Drawing.Size(679, 566);
            this.dgv_ConsumptionType.TabIndex = 41;
            // 
            // btn_NewConsumption
            // 
            this.btn_NewConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewConsumption.Location = new System.Drawing.Point(12, 650);
            this.btn_NewConsumption.Name = "btn_NewConsumption";
            this.btn_NewConsumption.Size = new System.Drawing.Size(652, 72);
            this.btn_NewConsumption.TabIndex = 42;
            this.btn_NewConsumption.Text = "button1";
            this.btn_NewConsumption.UseVisualStyleBackColor = true;
            this.btn_NewConsumption.Click += new System.EventHandler(this.btn_NewConsumption_Click);
            // 
            // Form_NewConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(676, 758);
            this.Controls.Add(this.btn_NewConsumption);
            this.Controls.Add(this.dgv_ConsumptionType);
            this.Controls.Add(this.usrc_Help1);
            this.Controls.Add(this.btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_NewConsumption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_NewConsumption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ConsumptionType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private HUDCMS.usrc_Help usrc_Help1;
        private DataGridView dgv_ConsumptionType;
        private Button btn_NewConsumption;
    }
}