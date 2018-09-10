using usrc_Item_PageHandler;

namespace usrc_Item_Group_Handler
{
    partial class usrc_Item_InsidePageGroupHandler
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usrc_Item_InsideGroup_Handler1 = new usrc_Item_InsideGroup_Handler();
            this.usrc_Item_InsidePageHandler1 = new usrc_Item_PageHandler.usrc_Item_InsidePageHandler();
            this.SuspendLayout();
            // 
            // usrc_Item_InsideGroup_Handler1
            // 
            this.usrc_Item_InsideGroup_Handler1.Button_Height = 40;
            this.usrc_Item_InsideGroup_Handler1.Font_Height = 10;
            this.usrc_Item_InsideGroup_Handler1.Location = new System.Drawing.Point(0, 200);
            this.usrc_Item_InsideGroup_Handler1.Name = "usrc_Item_InsideGroup_Handler1";
            this.usrc_Item_InsideGroup_Handler1.Size = new System.Drawing.Size(640, 120);
            this.usrc_Item_InsideGroup_Handler1.TabIndex = 0;
            this.usrc_Item_InsideGroup_Handler1.usrc_Item_InsidePageHandler_Defined = false;
            this.usrc_Item_InsideGroup_Handler1.SizeChanged += new usrc_Item_InsideGroup_Handler.delegate_SizeChanged(this.usrc_Item_InsideGroup_Handler1_SizeChanged);
            // 
            // usrc_Item_InsidePageHandler1
            // 
            this.usrc_Item_InsidePageHandler1.BackColor = System.Drawing.Color.Khaki;
            this.usrc_Item_InsidePageHandler1.Location = new System.Drawing.Point(0, 0);
            this.usrc_Item_InsidePageHandler1.Name = "usrc_Item_InsidePageHandler1";
            this.usrc_Item_InsidePageHandler1.SelectedIndex = -1;
            this.usrc_Item_InsidePageHandler1.Size = new System.Drawing.Size(640, 200);
            this.usrc_Item_InsidePageHandler1.TabIndex = 1;
            // 
            // usrc_Item_InsidePageGroupHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usrc_Item_InsidePageHandler1);
            this.Controls.Add(this.usrc_Item_InsideGroup_Handler1);
            this.Name = "usrc_Item_InsidePageGroupHandler";
            this.Size = new System.Drawing.Size(640, 320);
            this.ResumeLayout(false);

        }

        #endregion

        private usrc_Item_InsideGroup_Handler  usrc_Item_InsideGroup_Handler1;
        private usrc_Item_InsidePageHandler usrc_Item_InsidePageHandler1;
    }
}
