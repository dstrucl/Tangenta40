namespace ShopC_Forms
{
    partial class Form_Consumption_AddOn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Consumption_AddOn));
            this.m_usrc_Consumption_AddOn = new usrc_AddOn_Consumption();
            this.SuspendLayout();
            // 
            // m_usrc_Consumption_AddOn
            // 
            this.m_usrc_Consumption_AddOn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_usrc_Consumption_AddOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_usrc_Consumption_AddOn.ForeColor = System.Drawing.Color.Black;
            this.m_usrc_Consumption_AddOn.Location = new System.Drawing.Point(0, 0);
            this.m_usrc_Consumption_AddOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_usrc_Consumption_AddOn.Name = "m_usrc_Consumption_AddOn";
            this.m_usrc_Consumption_AddOn.Size = new System.Drawing.Size(712, 657);
            this.m_usrc_Consumption_AddOn.TabIndex = 1;
            this.m_usrc_Consumption_AddOn.Issue += new usrc_AddOn_Consumption.delegate_Issue(this.m_usrc_ConsumptionAddOn_Issue);
            // 
            // Form_Consumption_AddOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(712, 657);
            this.Controls.Add(this.m_usrc_Consumption_AddOn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Consumption_AddOn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt_Preview_Form";
            this.Load += new System.EventHandler(this.Form_Consumption_AddOn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_AddOn_Consumption m_usrc_Consumption_AddOn;
    }
}