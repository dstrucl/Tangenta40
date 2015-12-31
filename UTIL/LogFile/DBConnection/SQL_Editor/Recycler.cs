// -------------------------------------------------------
// SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SqlBuilder.Forms;

namespace SqlBuilder
{
	/// <summary>
	/// The stupid Windows Recycle Bin needs 30 seconds to move ONE file 
	/// into the recyler if there are 500 files in the recycler.
	/// During these 30 seconds the application will completely hang if you dont execute this in another thread!
	/// </summary>
	public class Recycler
	{
		#region Win32 API

		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
		struct SHFILEOPSTRUCTW
		{
			public IntPtr          hwnd;
			public uint            wFunc;
			public string          pFrom;
			public string          pTo;
			public uint            fFlags;
			public bool            fAnyOperationsAborted;
			public IntPtr          hNameMappings;
			public string          lpszProgressTitle;
		};

		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
		struct SHFILEOPSTRUCTA
		{
			public IntPtr          hwnd;
			public uint            wFunc;
			public string          pFrom;
			public string          pTo;
			public uint            fFlags;
			public bool            fAnyOperationsAborted;
			public IntPtr          hNameMappings;
			public string          lpszProgressTitle;
		};

		[DllImport("shell32.dll", EntryPoint="SHFileOperationW")]
		static extern int SHFileOperationW(ref SHFILEOPSTRUCTW k_FileOp);

		[DllImport("shell32.dll", EntryPoint="SHFileOperationA")]
		static extern int SHFileOperationA(ref SHFILEOPSTRUCTA k_FileOp);

		#endregion

		frmWait mi_WaitForm;
		string  ms_File;
		int     ms32_Error = 0;

		/// <summary>
		/// s_File must be a FULL path (not relative)!
		/// </summary>
		public bool MoveToRecycleBin(Form i_Owner, string s_File)
		{
			ms_File = s_File;

			if (!File.Exists(s_File))
				return true;

			mi_WaitForm = new frmWait(); // ORDER FIRST!

			Thread i_Thread = new Thread(new ThreadStart(WorkThread));
			i_Thread.Start(); // ORDER AFTER!

			int s32_Tick = Environment.TickCount;
			// The following command will block until the file is in the recycler or the user aborted
			DialogResult Res = mi_WaitForm.ShowDialog(i_Owner);
			s32_Tick = Environment.TickCount - s32_Tick;

			if (ms32_Error != 0)
				frmMsgBox.Err(i_Owner, string.Format("The following file could not be moved to the recycle bin:\n{0}\n{1}", s_File, Functions.ExplainApiError(ms32_Error)));
	
			if (s32_Tick > 2000)
				frmMsgBox.Warn(i_Owner, "You should clean up your recycle bin!!\nWindows needed "+(s32_Tick/1000)+" seconds to move only ONE file into your recycler!");

			return (Res == DialogResult.OK && ms32_Error == 0);
		}

		private void WorkThread()
		{
			mi_WaitForm.SetLabelText("Moving to recycler...");

			const int  FO_DELETE         = 0x0003;
			const int FOF_SILENT         = 0x0004;
			const int FOF_ALLOWUNDO      = 0x0040;
			const int FOF_NOERRORUI      = 0x0400;
			const int FOF_NOCONFIRMATION = 0x0010;

			Functions.RemoveWriteProtection(ms_File);

			uint u32_Flags = FOF_ALLOWUNDO |     // move to recycle bin
			                 FOF_SILENT    |     // don't show progress bar
			                 FOF_NOERRORUI |     // don't show error MessageBoxes
			                 FOF_NOCONFIRMATION; // don't ask for confirmation

			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				SHFILEOPSTRUCTW k_File = new SHFILEOPSTRUCTW();
				k_File.hwnd   = IntPtr.Zero;         // not used
				k_File.wFunc  = FO_DELETE;
				k_File.pFrom  = ms_File + "\0";      // requires !TWO! terminating zeroes
				k_File.pTo    = null;
				k_File.fFlags = u32_Flags;

				ms32_Error = SHFileOperationW(ref k_File);
			}
			else
			{
				SHFILEOPSTRUCTA k_File = new SHFILEOPSTRUCTA();
				k_File.hwnd   = IntPtr.Zero;         // not used
				k_File.wFunc  = FO_DELETE;
				k_File.pFrom  = ms_File + "\0";      // requires !TWO! terminating zeroes
				k_File.pTo    = null;
				k_File.fFlags = u32_Flags;

				ms32_Error = SHFileOperationA(ref k_File);
			}

			mi_WaitForm.Close(); // DialogResult.OK
		}
	}
}
