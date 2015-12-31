// -------------------------------------------------------
// SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SqlBuilder.Controls;

namespace SqlBuilder.Forms
{
	/// <summary>
	/// Creates a wait window which appears only for SQL command which need more than 1 second to execute
	/// </summary>
	public class frmWait : System.Windows.Forms.Form
	{
		Timer     mi_CountTimer   = new Timer();
		int     ms32_MilliSec     = 0;
		string    ms_LabelText    = "Executing...";
		bool      mb_PreventClose = true;
		bool      mb_MadeVisible  = false;

		public delegate void UserAbort();
		public event UserAbort evUserAbort;

		public frmWait()
		{
			InitializeComponent();

			mi_CountTimer.Interval = 200;
			mi_CountTimer.Tick += new EventHandler(OnSecondTimer);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			// move window far outside the screen area
			// show window only for SQL command which need more than 1 second to execute
			this.Location  = new Point(-15000,-15000);
			mi_CountTimer.Start();
		}

		private void OnSecondTimer(object sender, EventArgs e)
		{
			ms32_MilliSec += mi_CountTimer.Interval;

			// Move window back to origional position after one second
			if (!mb_MadeVisible && ms32_MilliSec > 700)
			{
				mb_MadeVisible = true;
				// Center the window to its owner
				Functions.CenterWindow(this);
			}

			this.lblText.Text = string.Format("{0} ({1} sec)", ms_LabelText, ms32_MilliSec/1000);
		}

		/// <summary>
		/// This function is threadsafe
		/// </summary>
		public void SetLabelText(string s_Text)
		{
			ms_LabelText  = s_Text;
			ms32_MilliSec = 0; // count anew
		}

		/// <summary>
		/// This function is threadsafe
		/// </summary>
		public new void Close()
		{
			if (IsDisposed)
				return;

			// avoid exception: "ClosingWhileCreatingHandle"
			while (!this.Created)
				System.Threading.Thread.Sleep(20);

			mb_PreventClose = false;
			DialogResult = DialogResult.OK;
			base.Close(); // calls SendMessage()
		}

		private void OnButtonAbort(object sender, System.EventArgs e)
		{
			// fire event
			if (evUserAbort != null)
				evUserAbort();

			mb_PreventClose = false;
			DialogResult = DialogResult.Cancel;
			base.Close();
		}

		/// <summary>
		/// avoid closing the window with ALT + F4
		/// </summary>
		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosing (e);
			e.Cancel = mb_PreventClose;
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		private System.Windows.Forms.PictureBox picBoxWait;
		private System.Windows.Forms.Button btnAbort;
		private System.Windows.Forms.Label lblText;
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmWait));
			this.btnAbort = new System.Windows.Forms.Button();
			this.picBoxWait = new System.Windows.Forms.PictureBox();
			this.lblText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnAbort
			// 
			this.btnAbort.Location = new System.Drawing.Point(76, 40);
			this.btnAbort.Name = "btnAbort";
			this.btnAbort.Size = new System.Drawing.Size(76, 24);
			this.btnAbort.TabIndex = 1;
			this.btnAbort.Text = "Abort";
			this.btnAbort.Click += new System.EventHandler(this.OnButtonAbort);
			// 
			// picBoxWait
			// 
			this.picBoxWait.Image = ((System.Drawing.Image)(resources.GetObject("picBoxWait.Image")));
			this.picBoxWait.Location = new System.Drawing.Point(8, 8);
			this.picBoxWait.Name = "picBoxWait";
			this.picBoxWait.Size = new System.Drawing.Size(36, 34);
			this.picBoxWait.TabIndex = 2;
			this.picBoxWait.TabStop = false;
			// 
			// lblText
			// 
			this.lblText.Location = new System.Drawing.Point(48, 10);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(170, 16);
			this.lblText.TabIndex = 3;
			this.lblText.Text = "Executing...";
			// 
			// frmWait
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(228, 71);
			this.ControlBox = false;
			this.Controls.Add(this.lblText);
			this.Controls.Add(this.picBoxWait);
			this.Controls.Add(this.btnAbort);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmWait";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = " Wait....";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
