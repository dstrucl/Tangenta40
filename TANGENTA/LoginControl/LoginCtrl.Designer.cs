namespace LoginControl
{
    partial class LoginCtrl
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
            this.components = new System.ComponentModel.Container();
            this.IdleCtrl = new LoginControl.IdleControl(this.components);
            // 
            // IdleCtrl
            // 
            this.IdleCtrl.Active = false;
            this.IdleCtrl.ShowURL2 = false;
            this.IdleCtrl.TimeInSecondsToActivate = 20;
            this.IdleCtrl.URL1 = null;
            this.IdleCtrl.URL2 = null;
            this.IdleCtrl.UseExitButton = true;

        }

        #endregion

        public IdleControl IdleCtrl;
    }
}
