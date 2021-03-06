#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

// -------------------------------------------------------
// LogFile_SqlBuilder by Elm�Soft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/LogFile_SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogFile_SqlBuilder.Controls
{
	/// <summary>
	/// A Label that displays status information
	/// </summary>
	public class StatusInfo : Label
	{
		Timer mi_StatusTimer = new Timer();

		public StatusInfo()
		{
			mi_StatusTimer. Tick += new EventHandler(OnTimerClearText);
			mi_StatusTimer. Interval = 3000;
		}

		/// <summary>
		/// Set bold blue font
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl ();

			Anchor      = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			BorderStyle = BorderStyle.Fixed3D;
			TextAlign   = ContentAlignment.MiddleLeft;
			Font        = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			ForeColor   = Color.Blue;
			Height      = 20;
		}

		/// <summary>
		/// Set a text which automatically disappears after 3 seconds
		/// </summary>
		public void SetTransientText(string s_Text)
		{
			mi_StatusTimer.Stop();
			Text = s_Text;
			mi_StatusTimer.Start();
		}

		public override string Text
		{
			set
			{
				base.Text = value;
				Application.DoEvents();
			}
		}

		private void OnTimerClearText(object sender, EventArgs e)
		{
			mi_StatusTimer.Stop();
			Text = "";
		}
	}
}
