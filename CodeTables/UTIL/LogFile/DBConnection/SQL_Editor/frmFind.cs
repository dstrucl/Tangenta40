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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using LogFile_SqlBuilder.Controls;

namespace LogFile_SqlBuilder.Forms
{
	/// <summary>
	/// Find or Goto operation
	/// </summary>
	public class frmFind : frmBaseForm
	{
		public class cParam
		{
			public string s_Find      = "";    // The text to search for
			public string s_Replace   = "";    // The text to replace with
			public bool   b_Replace   = false; // Replace / Find operation
			public bool   b_WholeWord = false; // Search only whole words
			
			// Otpional Additional Checkbox
			public bool   b_CheckExtra1 = false;
			public string s_CheckExtra1 = null; // The text for Checkbox Extra1 (null = disabled)
		}

		public delegate string delFindReplace(cParam i_Param);

		delFindReplace mi_Callback;
		int          ms32_Line        = 0;
		int          ms32_TotalLines  = 0;

		public int LineNumber
		{
			get { return ms32_Line; }
		}

		public frmFind(int          s32_TotalLines, // only used for Goto
		               cParam         i_Param,      // i_Param.b_Replace = false -> disable Replace button
		               delFindReplace i_Callback)   // Callback for search / replace actions (null --> Goto)
		{
			InitializeComponent();

			StoreWindowPos     = true; // must be set in Constructor AFTER InitializeComponent() !!
			ms32_TotalLines    = s32_TotalLines;
			mi_Callback        = i_Callback;
			DialogResult       = DialogResult.Cancel;

			string[] s_Lines   = i_Param.s_Find.Replace("\r", "").Split('\n');
			txtInput.  Text    = Functions.Left(s_Lines[0], 50);
			txtReplace.Text    = i_Param.s_Replace;

			checkWholeWord.Checked = i_Param.b_WholeWord;
			
			// Enable the optional additional checkbox
			if (i_Param.s_CheckExtra1 != null)
			{
				checkExtra1.Text    = i_Param.s_CheckExtra1;
				checkExtra1.Checked = i_Param.b_CheckExtra1;
			}
			else checkExtra1.Visible = false;

			lblReplace.Enabled = i_Param.b_Replace;
			txtReplace.Enabled = i_Param.b_Replace;
			btnReplace.Enabled = i_Param.b_Replace;

			if (mi_Callback == null) // Goto
			{
				this.Text       = " Goto";
				btnExecute.Text = "Goto";
				lblHeading.Text = "Line";
				checkWholeWord.Enabled = false;
			}
			else // Find / Replace
			{
				if (i_Param.b_Replace) this.Text = " Find / Replace";
				else                   this.Text = " Find";

				btnExecute.Text = "Find";
				lblHeading.Text = "Search Text";
			}
		}

		private void OnButtonKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}

		private void OnTxtInputKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();

			if (e.KeyCode == Keys.Return)
				OnButtonExecute(sender, e);
		}

		private void OnTxtReplaceKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}

		/// <summary>
		/// Replace
		/// </summary>
		private void OnButtonReplace(object sender, System.EventArgs e)
		{
			if (txtInput.Text.Length == 0)
			{
				lblStatus.SetTransientText("Find what ?");
				return;
			}

			cParam i_Param = new cParam();
			i_Param.b_Replace     = true;
			i_Param.b_WholeWord   = checkWholeWord.Checked;
			i_Param.b_CheckExtra1 = checkExtra1.Checked;
			i_Param.s_Find        = txtInput.  Text;
			i_Param.s_Replace     = txtReplace.Text;

			lblStatus.SetTransientText(mi_Callback(i_Param));
		}

		/// <summary>
		/// Find or Goto
		/// </summary>
		private void OnButtonExecute(object sender, System.EventArgs e)
		{
			if (mi_Callback != null) // Find
			{
				if (txtInput.Text.Length == 0)
				{
					lblStatus.SetTransientText("Find what ?");
				}
				else
				{
					cParam i_Param = new cParam();
					i_Param.b_Replace     = false;
					i_Param.b_WholeWord   = checkWholeWord.Checked;
					i_Param.b_CheckExtra1 = checkExtra1.Checked;
					i_Param.s_Find        = txtInput.Text;

					lblStatus.Text = "Searching....";
					lblStatus.SetTransientText(mi_Callback(i_Param));
				}
			}
			else // Goto
			{
				try   { ms32_Line = int.Parse(txtInput.Text); }
				catch { ms32_Line = -1; }

				if (ms32_Line <= 0 || ms32_Line > ms32_TotalLines)
				{
					lblStatus.Text = "Searching....";
					lblStatus.SetTransientText("Invalid line number!");
				}
				else
				{
					DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		private void OnTxtBoxEnter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		#region Windows Form Designer generated code

		private LogFile_SqlBuilder.Controls.StatusInfo lblStatus;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Label lblHeading;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.TextBox txtReplace;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.Label lblReplace;
		private System.Windows.Forms.CheckBox checkWholeWord;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.CheckBox checkExtra1;
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFind));
            this.lblStatus = new LogFile_SqlBuilder.Controls.StatusInfo();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnReplace = new System.Windows.Forms.Button();
            this.lblReplace = new System.Windows.Forms.Label();
            this.checkWholeWord = new System.Windows.Forms.CheckBox();
            this.checkExtra1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(8, 132);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(427, 17);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(8, 20);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(337, 20);
            this.txtInput.TabIndex = 1;
            this.txtInput.Enter += new System.EventHandler(this.OnTxtBoxEnter);
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTxtInputKeyUp);
            // 
            // lblHeading
            // 
            this.lblHeading.Location = new System.Drawing.Point(8, 4);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(178, 12);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Text";
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(355, 20);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(80, 22);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Exec";
            this.btnExecute.Click += new System.EventHandler(this.OnButtonExecute);
            this.btnExecute.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnButtonKeyUp);
            // 
            // txtReplace
            // 
            this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplace.Location = new System.Drawing.Point(8, 64);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(337, 20);
            this.txtReplace.TabIndex = 2;
            this.txtReplace.Enter += new System.EventHandler(this.OnTxtBoxEnter);
            this.txtReplace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnTxtReplaceKeyUp);
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplace.Location = new System.Drawing.Point(355, 62);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(80, 22);
            this.btnReplace.TabIndex = 4;
            this.btnReplace.Text = "Replace";
            this.btnReplace.Click += new System.EventHandler(this.OnButtonReplace);
            this.btnReplace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnButtonKeyUp);
            // 
            // lblReplace
            // 
            this.lblReplace.Location = new System.Drawing.Point(8, 48);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(178, 12);
            this.lblReplace.TabIndex = 0;
            this.lblReplace.Text = "Replace with";
            // 
            // checkWholeWord
            // 
            this.checkWholeWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkWholeWord.Checked = true;
            this.checkWholeWord.CheckState= System.Windows.Forms.CheckState.Checked;
            this.checkWholeWord.Location = new System.Drawing.Point(8, 90);
            this.checkWholeWord.Name = "checkWholeWord";
            this.checkWholeWord.Size = new System.Drawing.Size(418, 16);
            this.checkWholeWord.TabIndex = 5;
            this.checkWholeWord.Text = "Search only whole words";
            // 
            // checkExtra1
            // 
            this.checkExtra1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkExtra1.Location = new System.Drawing.Point(8, 110);
            this.checkExtra1.Name = "checkExtra1";
            this.checkExtra1.Size = new System.Drawing.Size(418, 16);
            this.checkExtra1.TabIndex = 6;
            this.checkExtra1.Text = "Checkbox Extra 1";
            // 
            // frmFind
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(442, 158);
            this.Controls.Add(this.checkExtra1);
            this.Controls.Add(this.checkWholeWord);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFind";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " LogFile_SqlBuilder";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	}
}
