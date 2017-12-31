namespace usrc_Item_PageHandler
{
    partial class usrc_Item_PageHandler
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
            this.btn_First = new System.Windows.Forms.Button();
            this.btn_Prev = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_First
            // 
            this.btn_First.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_First.Image = global::usrc_Item_PageHandler.Properties.Resources.First;
            this.btn_First.Location = new System.Drawing.Point(0, 0);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(35, 35);
            this.btn_First.TabIndex = 0;
            this.btn_First.UseVisualStyleBackColor = false;
            // 
            // btn_Prev
            // 
            this.btn_Prev.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Prev.Image = global::usrc_Item_PageHandler.Properties.Resources.Prev;
            this.btn_Prev.Location = new System.Drawing.Point(36, 0);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(35, 35);
            this.btn_Prev.TabIndex = 1;
            this.btn_Prev.UseVisualStyleBackColor = false;
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Next.Image = global::usrc_Item_PageHandler.Properties.Resources.Next;
            this.btn_Next.Location = new System.Drawing.Point(74, 0);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(35, 35);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.UseVisualStyleBackColor = false;
            // 
            // btn_Last
            // 
            this.btn_Last.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Last.Image = global::usrc_Item_PageHandler.Properties.Resources.Last;
            this.btn_Last.Location = new System.Drawing.Point(111, 0);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(39, 35);
            this.btn_Last.TabIndex = 3;
            this.btn_Last.UseVisualStyleBackColor = false;
            // 
            // usrc_Item_PageHandler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.btn_Last);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Prev);
            this.Controls.Add(this.btn_First);
            this.Name = "usrc_Item_PageHandler";
            this.Size = new System.Drawing.Size(150, 34);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_First;
        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Last;


    }
}
