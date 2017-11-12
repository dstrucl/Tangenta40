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

namespace LogFile_SqlBuilder.Controls
{
	/// <summary>
	/// The stupid .NET Picturebox does not allow to set a SystemIcon
	/// Converting an icon to a bitmap and painting it afterwards looks very ugly !
	/// </summary>
	public class PictureBoxEx : PictureBox
	{
		Icon mi_Icon = null;

		public Icon Icon
		{
			set { mi_Icon = value; }
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (mi_Icon != null)
				e.Graphics.DrawIcon(mi_Icon, this.ClientRectangle);
			else 
				base.OnPaint (e);
		}
	}
}
