#region LICENSE 
/*
 This Source Code Form is subject to the terms of the Tangenta Public License, v. 1.0. 
 If a copy of the Tangenta Public License (TPL) was not distributed with this 
 file, You can obtain one at  https://github.com/dstrucl/Tangenta40/wiki/LICENCE 
*/
#endregion

// -------------------------------------------------------
// SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SqlBuilder.Forms
{
	/// <summary>
	/// The base for all forms which store their window position in the Registry
	/// </summary>
	public class frmBaseForm : Form
	{
		static ArrayList mi_OpenWindows = new ArrayList();
		Timer  mi_TimerLoad = new Timer();

		/// <summary>
		/// Must be set in Constructor AFTER InitializeComponent() !!
		/// =true : store position and size of the form in the Registry when the user moves or resizes the form
		/// and reload position and size when the form is opened the next time
		/// </summary>
		public bool StoreWindowPos
		{
			set
			{
				if (value)
				{
					this.StartPosition = FormStartPosition.Manual; // Avoid that the framework moves the window
					this.SizeChanged     += new EventHandler(SaveWindowPos);
					this.LocationChanged += new EventHandler(SaveWindowPos);
					RestoreWindowPos();
				}
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			mi_TimerLoad.Interval = 100;
			mi_TimerLoad.Tick    += new EventHandler(OnTimerLoad);
			mi_TimerLoad.Start();
		}

		private void OnTimerLoad(object sender, EventArgs e)
		{
			mi_TimerLoad.Stop();
			OnLoadDelayed();
		}

		/// <summary>
		/// Override this function to start an action when the form is already showing on the screen
		/// The delay assures that the GUI is drawn before e.g. trying to connect the server which may be slow
		/// </summary>
		protected virtual void OnLoadDelayed()
		{
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			mi_OpenWindows.Remove(this);
		}

		/// <summary>
		/// returns the count of windows of the same type which are open at the same time
		/// Example : 3 windows frmSearchResult are open --> returns 2
		/// </summary>
		protected int SiblingCount
		{
			get
			{
				int s32_Count = 0;
				foreach (object o_Wnd in mi_OpenWindows)
				{
					if (o_Wnd.GetType() == this.GetType())
						s32_Count ++;
				}
				return s32_Count - 1;
			}
		}

		private void SaveWindowPos(object sender, EventArgs e)
		{
			if (!this.Created || this.WindowState== FormWindowState.Minimized)
				return;

			// If there is another window of the same type open --> dont save window position
			if (SiblingCount > 0)
				return;

			if (this.WindowState== FormWindowState.Maximized)
			{
				//Functions.RegistryWrite(Functions.eReg.Main, this.Name + "Maxi", 1);
			}
			else
			{
                //Functions.RegistryWrite(Functions.eReg.Main, this.Name + "Maxi",   0);
                //Functions.RegistryWrite(Functions.eReg.Main, this.Name + "Left",   this.Location.X);
                //Functions.RegistryWrite(Functions.eReg.Main, this.Name + "Top",    this.Location.Y);
                //Functions.RegistryWrite(Functions.eReg.Main, this.Name + "Width",  this.Size.Width);
                //Functions.RegistryWrite(Functions.eReg.Main, this.Name + "Height", this.Size.Height);
			}
		}

		private void RestoreWindowPos()
		{
			mi_OpenWindows.Add(this);

            ////int X = (int)Functions.RegistryRead(Functions.eReg.Main, this.Name + "Left",   0);
            ////int Y = (int)Functions.RegistryRead(Functions.eReg.Main, this.Name + "Top",    0);
            ////int W = (int)Functions.RegistryRead(Functions.eReg.Main, this.Name + "Width",  0);
            ////int H = (int)Functions.RegistryRead(Functions.eReg.Main, this.Name + "Height", 0);
            ////int M = (int)Functions.RegistryRead(Functions.eReg.Main, this.Name + "Maxi",   0);

            //if (H==0 || W==0) // The window is opened for the very first time
            //{
            //    Functions.CenterWindow(this);
            //    return;
            //}

            //if (M == 0) this.WindowState= FormWindowState.Normal;

            //Functions.LimitOnScreen(ref X, ref Y, ref W, ref H);

            //// If a window of the same type is already open --> move this window to the right bottom by 20 pixels
            //// So the SearchResult windows open tiled
            //int s32_Siblings = SiblingCount;
            //X += 20 * s32_Siblings;
            //Y += 20 * s32_Siblings;

            //this.Location = new Point(X,Y);
            //this.Size     = new Size (W,H);

            //if (M > 0) this.WindowState= FormWindowState.Maximized;
		}
	}
}
