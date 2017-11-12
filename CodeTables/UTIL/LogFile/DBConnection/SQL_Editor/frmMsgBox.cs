#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

// -------------------------------------------------------
// LogFile_SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/LogFile_SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using LogFile_SqlBuilder.Controls;


namespace LogFile_SqlBuilder.Forms
{
	/// <summary>
	/// The stupid Windows XP messagebox is centered to the screen instead of to the owner window!
	/// This messagbox always appears in the middle of the owner window
	/// </summary>
	public class frmMsgBox : Form
	{
		public enum eIcon
		{
			Butterfly,
			Error,
			Info,
			Question,
			Warning,
			Alarm,
		}

		private const int MSGMAXWIDTH = 500;   // Pixels

		/// <summary>
		/// Display OK Button and Error Icon
		/// </summary>
		public static void Err(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Error, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			i_Box.ShowDialog(i_Owner);
		}
		/// <summary>
		/// Display OK Button and Exclamation Icon
		/// </summary>
		public static void Info(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Info, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			i_Box.ShowDialog(i_Owner);
		}
		/// <summary>
		/// Display OK Button and Warning Icon
		/// </summary>
		public static void Warn(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Warning, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			i_Box.ShowDialog(i_Owner);
		}
		/// <summary>
		/// Display OK Button in a red Alarm window with STOP icon
		/// </summary>
		public static void Alarm(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Alarm, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			i_Box.ShowDialog(i_Owner);
		}
		/// <summary>
		/// displays 2 buttons: Yes, No and questionmark icon
		/// </summary>
		public static bool Ask(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Question, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
			return (i_Box.ShowDialog(i_Owner) == DialogResult.Yes);
		}
		/// <summary>
		/// displays 2 buttons: Yes, No in a red Alarm window with STOP icon
		/// </summary>
		public static bool AskAlarm(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Alarm, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
			return (i_Box.ShowDialog(i_Owner) == DialogResult.Yes);
		}
		/// <summary>
		/// displays 3 buttons: Yes, No, Cancel
		/// </summary>
		public static DialogResult Ask3(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Question, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);
			return i_Box.ShowDialog(i_Owner);
		}
		/// <summary>
		/// displays 3 buttons: Yes, No, Cancel in a red Alarm window with STOP icon
		/// </summary>
		public static DialogResult Ask3Alarm(Form i_Owner, string s_Text)
		{
			frmMsgBox i_Box = new frmMsgBox(i_Owner, s_Text, "LogFile_SqlBuilder", eIcon.Alarm, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3);
			return i_Box.ShowDialog(i_Owner);
		}

		// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		// If the messagebox is called from another thread than its owner's thread
		// --> Invoke ShowDialog() from the owner's thread
		// This is required to have a really modal messagebox which disables the owner window
		// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

		delegate DialogResult delShowDialog(IWin32Window i_Owner);

		public new DialogResult ShowDialog()
		{
			return ShowDialog(this.Owner);
		}

		public new DialogResult ShowDialog(IWin32Window i_Owner)
		{
			if (i_Owner != null && Functions.GetCurrentThread() != Functions.GetWindowThread(i_Owner.Handle))
			{
				return (DialogResult) ((Form)i_Owner).Invoke(new delShowDialog(ShowDialog), new object[]{ i_Owner });
			}

			return base.ShowDialog(i_Owner);
		}

		// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

		/// <summary>
		/// Constructor
		/// </summary>
		public frmMsgBox(Form i_Owner, string s_Text, string s_Caption, eIcon e_Icon, MessageBoxButtons e_Buttons, MessageBoxDefaultButton e_DefaultBtn)
		{
			InitializeComponent();

			this.Owner   =  i_Owner;
			this.TopMost = (i_Owner == null);
			this.ShowInTaskbar = false; // ShowInTaskbar can NOT be combined with TopMost !!!

			this.Text            = s_Caption;
			this.lblMessage.Text = s_Text;
			this.DialogResult    = DialogResult.None;

			switch (e_Buttons)
			{
				case MessageBoxButtons.OK:
					btnLeft.Text         = "OK";
					btnLeft.DialogResult = DialogResult.OK;
					btnMid.  Visible     = false;
					btnRight.Visible     = false;
					break;

				case MessageBoxButtons.OKCancel:
					btnLeft.Text          = "OK";
					btnLeft.DialogResult  = DialogResult.OK;
					btnMid.Text           = "Cancel";
					btnMid.DialogResult   = DialogResult.Cancel;
					btnRight.Visible      = false;
					break;

				case MessageBoxButtons.YesNo:
					btnLeft.Text          = "Yes";
					btnLeft.DialogResult  = DialogResult.Yes;
					btnMid.Text           = "No";
					btnMid.DialogResult   = DialogResult.No;
					btnRight.Visible      = false;
					break;

				case MessageBoxButtons.RetryCancel:
					btnLeft.Text          = "Retry";
					btnLeft.DialogResult  = DialogResult.Retry;
					btnMid.Text           = "Cancel";
					btnMid.DialogResult   = DialogResult.Cancel;
					btnRight.Visible      = false;
					break;

				case MessageBoxButtons.YesNoCancel:
					btnLeft.Text          = "Yes";
					btnLeft.DialogResult  = DialogResult.Yes;
					btnMid.Text           = "No";
					btnMid.DialogResult   = DialogResult.No;
					btnRight.Text         = "Cancel";
					btnRight.DialogResult = DialogResult.Cancel;
					break;

				default:
					throw new Exception("MessageBoxButtons not supported");
			}

			// swap the Tab indexes
			if (e_DefaultBtn == MessageBoxDefaultButton.Button2) 
			{
				btnMid. TabIndex = 1;
				btnLeft.TabIndex = 2;
			}
			if (e_DefaultBtn == MessageBoxDefaultButton.Button3) 
			{
				btnRight.TabIndex = 1;
				btnLeft. TabIndex = 2;
				btnMid.  TabIndex = 3;
			}

			switch (e_Icon)
			{
				case eIcon.Info: // == Asterisk
					picIcon.Icon = SystemIcons.Asterisk;
					break;

				case eIcon.Error:       // == Stop == Hand
					picIcon.Icon = SystemIcons.Hand;
					break;

				case eIcon.Warning:     // == Exclamation
					picIcon.Icon = SystemIcons.Warning;
					break;

				case eIcon.Question:
					picIcon.Icon = SystemIcons.Question;
					break;

				case eIcon.Butterfly:
					picIcon.Icon = null; // The icon is stored in the resources
					break;

				case eIcon.Alarm:
					picIcon.Icon = Functions.ReadEmbeddedIconResource("Stop.ico");

					// Set red messagebox background
					Color col_Back = Color.FromArgb(0xFF, 0xAA, 0x00);
					Color col_Btn  = Color.FromArgb(0xFF, 0x00, 0x00);

					this.BackColor       = col_Back;
					lblMessage.BackColor = col_Back;
					picIcon.BackColor    = col_Back;
				
					btnLeft. BackColor = col_Btn;
					btnMid.  BackColor = col_Btn;
					btnRight.BackColor = col_Btn;
					break;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			// Resize window so the text will fit
			Size k_OldSize = lblMessage.ClientRectangle.Size;
			Graphics Gr    = lblMessage.CreateGraphics();
			Size k_NewSize = Gr.MeasureString(lblMessage.Text, lblMessage.Font, MSGMAXWIDTH).ToSize();

			int MinX = -100;
			if (btnMid.  Visible) MinX = -50;
			if (btnRight.Visible) MinX =  20;

			int dX = Math.Max(MinX, k_NewSize.Width  - k_OldSize.Width  + 5);
			int dY = Math.Max(   0, k_NewSize.Height - k_OldSize.Height + 5);

			this.Size       = new Size(this.Width       + dX, this.Height       + dY);
			lblMessage.Size = new Size(lblMessage.Width + dX, lblMessage.Height + dY);

			// Move buttons vertically
			btnLeft. Top += dY;
			btnMid.  Top += dY;
			btnRight.Top += dY;

			// Move buttons horizontally
			if (btnRight.Visible)
			{
				btnMid.  Left = (this.Width - btnMid.Width) / 2;
				btnLeft. Left = btnMid.Left  - 10 - btnLeft.Width;
				btnRight.Left = btnMid.Right + 10;
			}
			else if (btnMid.Visible) // center the buttons 10 pixels away from the middle of the form
			{
				btnMid. Left = this.Width /2 + 5;
				btnLeft.Left = btnMid.Left - 10 - btnLeft.Width;
			}
			else // center the "OK" button
			{
				btnLeft.Left = (this.Width - btnLeft.Width) / 2;
			}

			Functions.CenterWindow(this);
		}

		#region " Windows Form Designer generated code "

		//Form overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing) 
		{
			if (disposing) 
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components = null;
		private Label lblMessage;
		private PictureBoxEx picIcon;
		private Button btnLeft;
		private Button btnMid;
		private Button btnRight;

		private void InitializeComponent() 
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMsgBox));
			this.btnLeft = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnRight = new System.Windows.Forms.Button();
			this.picIcon = new LogFile_SqlBuilder.Controls.PictureBoxEx();
			this.btnMid = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnLeft
			// 
			this.btnLeft.AccessibleDescription = resources.GetString("btnLeft.AccessibleDescription");
			this.btnLeft.AccessibleName = resources.GetString("btnLeft.AccessibleName");
			this.btnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnLeft.Anchor")));
			this.btnLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLeft.BackgroundImage")));
			this.btnLeft.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnLeft.Dock")));
			this.btnLeft.Enabled = ((bool)(resources.GetObject("btnLeft.Enabled")));
			this.btnLeft.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnLeft.FlatStyle")));
			this.btnLeft.Font = ((System.Drawing.Font)(resources.GetObject("btnLeft.Font")));
			this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
			this.btnLeft.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnLeft.ImageAlign")));
			this.btnLeft.ImageIndex = ((int)(resources.GetObject("btnLeft.ImageIndex")));
			this.btnLeft.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnLeft.ImeMode")));
			this.btnLeft.Location = ((System.Drawing.Point)(resources.GetObject("btnLeft.Location")));
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnLeft.RightToLeft")));
			this.btnLeft.Size = ((System.Drawing.Size)(resources.GetObject("btnLeft.Size")));
			this.btnLeft.TabIndex = ((int)(resources.GetObject("btnLeft.TabIndex")));
			this.btnLeft.Text = resources.GetString("btnLeft.Text");
			this.btnLeft.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnLeft.TextAlign")));
			this.btnLeft.Visible = ((bool)(resources.GetObject("btnLeft.Visible")));
			// 
			// lblMessage
			// 
			this.lblMessage.AccessibleDescription = resources.GetString("lblMessage.AccessibleDescription");
			this.lblMessage.AccessibleName = resources.GetString("lblMessage.AccessibleName");
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("lblMessage.Anchor")));
			this.lblMessage.AutoSize = ((bool)(resources.GetObject("lblMessage.AutoSize")));
			this.lblMessage.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("lblMessage.Dock")));
			this.lblMessage.Enabled = ((bool)(resources.GetObject("lblMessage.Enabled")));
			this.lblMessage.Font = ((System.Drawing.Font)(resources.GetObject("lblMessage.Font")));
			this.lblMessage.Image = ((System.Drawing.Image)(resources.GetObject("lblMessage.Image")));
			this.lblMessage.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMessage.ImageAlign")));
			this.lblMessage.ImageIndex = ((int)(resources.GetObject("lblMessage.ImageIndex")));
			this.lblMessage.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("lblMessage.ImeMode")));
			this.lblMessage.Location = ((System.Drawing.Point)(resources.GetObject("lblMessage.Location")));
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("lblMessage.RightToLeft")));
			this.lblMessage.Size = ((System.Drawing.Size)(resources.GetObject("lblMessage.Size")));
			this.lblMessage.TabIndex = ((int)(resources.GetObject("lblMessage.TabIndex")));
			this.lblMessage.Text = resources.GetString("lblMessage.Text");
			this.lblMessage.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("lblMessage.TextAlign")));
			this.lblMessage.Visible = ((bool)(resources.GetObject("lblMessage.Visible")));
			// 
			// btnRight
			// 
			this.btnRight.AccessibleDescription = resources.GetString("btnRight.AccessibleDescription");
			this.btnRight.AccessibleName = resources.GetString("btnRight.AccessibleName");
			this.btnRight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnRight.Anchor")));
			this.btnRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRight.BackgroundImage")));
			this.btnRight.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnRight.Dock")));
			this.btnRight.Enabled = ((bool)(resources.GetObject("btnRight.Enabled")));
			this.btnRight.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnRight.FlatStyle")));
			this.btnRight.Font = ((System.Drawing.Font)(resources.GetObject("btnRight.Font")));
			this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
			this.btnRight.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnRight.ImageAlign")));
			this.btnRight.ImageIndex = ((int)(resources.GetObject("btnRight.ImageIndex")));
			this.btnRight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnRight.ImeMode")));
			this.btnRight.Location = ((System.Drawing.Point)(resources.GetObject("btnRight.Location")));
			this.btnRight.Name = "btnRight";
			this.btnRight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnRight.RightToLeft")));
			this.btnRight.Size = ((System.Drawing.Size)(resources.GetObject("btnRight.Size")));
			this.btnRight.TabIndex = ((int)(resources.GetObject("btnRight.TabIndex")));
			this.btnRight.Text = resources.GetString("btnRight.Text");
			this.btnRight.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnRight.TextAlign")));
			this.btnRight.Visible = ((bool)(resources.GetObject("btnRight.Visible")));
			// 
			// picIcon
			// 
			this.picIcon.AccessibleDescription = resources.GetString("picIcon.AccessibleDescription");
			this.picIcon.AccessibleName = resources.GetString("picIcon.AccessibleName");
			this.picIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("picIcon.Anchor")));
			this.picIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picIcon.BackgroundImage")));
			this.picIcon.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("picIcon.Dock")));
			this.picIcon.Enabled = ((bool)(resources.GetObject("picIcon.Enabled")));
			this.picIcon.Font = ((System.Drawing.Font)(resources.GetObject("picIcon.Font")));
			this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
			this.picIcon.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("picIcon.ImeMode")));
			this.picIcon.Location = ((System.Drawing.Point)(resources.GetObject("picIcon.Location")));
			this.picIcon.Name = "picIcon";
			this.picIcon.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("picIcon.RightToLeft")));
			this.picIcon.Size = ((System.Drawing.Size)(resources.GetObject("picIcon.Size")));
			this.picIcon.SizeMode = ((System.Windows.Forms.PictureBoxSizeMode)(resources.GetObject("picIcon.SizeMode")));
			this.picIcon.TabIndex = ((int)(resources.GetObject("picIcon.TabIndex")));
			this.picIcon.TabStop = false;
			this.picIcon.Text = resources.GetString("picIcon.Text");
			this.picIcon.Visible = ((bool)(resources.GetObject("picIcon.Visible")));
			// 
			// btnMid
			// 
			this.btnMid.AccessibleDescription = resources.GetString("btnMid.AccessibleDescription");
			this.btnMid.AccessibleName = resources.GetString("btnMid.AccessibleName");
			this.btnMid.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnMid.Anchor")));
			this.btnMid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMid.BackgroundImage")));
			this.btnMid.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnMid.Dock")));
			this.btnMid.Enabled = ((bool)(resources.GetObject("btnMid.Enabled")));
			this.btnMid.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnMid.FlatStyle")));
			this.btnMid.Font = ((System.Drawing.Font)(resources.GetObject("btnMid.Font")));
			this.btnMid.Image = ((System.Drawing.Image)(resources.GetObject("btnMid.Image")));
			this.btnMid.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnMid.ImageAlign")));
			this.btnMid.ImageIndex = ((int)(resources.GetObject("btnMid.ImageIndex")));
			this.btnMid.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnMid.ImeMode")));
			this.btnMid.Location = ((System.Drawing.Point)(resources.GetObject("btnMid.Location")));
			this.btnMid.Name = "btnMid";
			this.btnMid.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnMid.RightToLeft")));
			this.btnMid.Size = ((System.Drawing.Size)(resources.GetObject("btnMid.Size")));
			this.btnMid.TabIndex = ((int)(resources.GetObject("btnMid.TabIndex")));
			this.btnMid.Text = resources.GetString("btnMid.Text");
			this.btnMid.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnMid.TextAlign")));
			this.btnMid.Visible = ((bool)(resources.GetObject("btnMid.Visible")));
			// 
			// frmMsgBox
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.ControlBox = false;
			this.Controls.Add(this.btnMid);
			this.Controls.Add(this.picIcon);
			this.Controls.Add(this.btnRight);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.btnLeft);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "frmMsgBox";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.ResumeLayout(false);

		}
		#endregion
	}
}