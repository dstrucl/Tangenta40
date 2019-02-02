namespace Tangenta
{
    partial class Form_Document
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Document));
            this.loginControl1 = new LoginControl.LoginCtrl(this.components);
            this.fvI_SLO1 = new FiscalVerificationOfInvoices_SLO.FVI_SLO(this.components);
            this.SuspendLayout();
            // 
            // loginControl1
            // 
            this.loginControl1.AuthentificationType = LoginControl.LoginCtrl.eAuthentificationType.PASSWORD;
            this.loginControl1.DataTableCreationMode = LoginControl.LoginCtrl.eDataTableCreationMode.STD;
            this.loginControl1.IdleControlActive = false;
            this.loginControl1.IdleControlFileImageUrl1 = null;
            this.loginControl1.IdleControlFileImageUrl2 = null;
            this.loginControl1.IdleControlImageUrl1 = null;
            this.loginControl1.IdleControlImageUrl2 = null;
            this.loginControl1.IdleControlShowURL2 = false;
            this.loginControl1.IdleControlTimeInSecondsToActivate = -1;
            this.loginControl1.IdleControlURL1 = null;
            this.loginControl1.IdleControlURL2 = null;
            this.loginControl1.IdleControlUseExitButton = false;
            this.loginControl1.RecentItemsFolder = "";
            this.loginControl1.RecordCashierActivity = false;
            this.loginControl1.ShowAdministrators = false;
            this.loginControl1.UserLoggedIn += new LoginControl.LoginCtrl.delegate_UserLoggedIn(this.loginControl1_UserLoggedIn);
            this.loginControl1.UserLoggedOut += new LoginControl.LoginCtrl.delegate_UserLoggedOut(this.loginControl1_UserLoggedOut);
            this.loginControl1.ActivateDocumentMan += new LoginControl.LoginCtrl.delegate_ActivateDocumentMan(this.loginControl1_ActivateDocumentMan);
            this.loginControl1.EndProgram += new LoginControl.LoginCtrl.delegate_EndProgram(this.EndProgram);
            this.loginControl1.Reload += new LoginControl.LoginCtrl.delegate_ReloadDocumentMan(this.loginControl1_Reload);
            this.loginControl1.Edit_myOrganisationPerson += new LoginControl.LoginCtrl.delegate_Edit_myOrganisationPerson(this.loginControl1_Edit_myOrganisationPerson);
            // 
            // fvI_SLO1
            // 
            this.fvI_SLO1.FursD_ElectronicDeviceID = "";
            this.fvI_SLO1.FursTESTEnvironment = false;
            this.fvI_SLO1.MessageBox_Length = 100;
            // 
            // Form_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1000, 644);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_Document";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.Shown += new System.EventHandler(this.Form_Document_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_Document_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        internal LoginControl.LoginCtrl loginControl1;
        internal FiscalVerificationOfInvoices_SLO.FVI_SLO fvI_SLO1;
    }
}

