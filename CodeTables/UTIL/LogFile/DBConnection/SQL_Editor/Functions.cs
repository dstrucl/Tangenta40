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
using System.IO;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using SqlBuilder.Forms;
using SqlBuilder.Controls;

namespace SqlBuilder
{
	public class Functions
	{
		public enum eReg // where to write in the Registry
		{
			Main,      // write in MainKey
			WorkDir,   // write in MainKey\WorkDirs\DirectoryName
			WorkCountry, // write in MainKey\WorkDirs\DirectoryName\WorkCountrys\Filename
		}

		const  string ms_RegistryRoot = @"Software\ElmueSoft\SqlBuilder";
		static string ms_NullColor    = Functions.GetHtmlColor(Defaults.GridForeColor(typeof(DBNull)));
		
		public static string ExePath; // Directory where this exe runs

		#region COM / Win32 API

		// Create Shortcut

		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
		internal struct WIN32_FIND_DATAW
		{
			public const int MAX_PATH = 260;

			public uint dwFileAttributes;
			public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
			public uint nFileSizeHigh;
			public uint nFileSizeLow;
			public uint dwReserved0;
			public uint dwReserved1;
        
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
			public string cFileName;
        
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string cAlternateFileName;
		}

		[ComImport]
		[Guid("00021401-0000-0000-C000-000000000046")]
		[ClassInterface(ClassInterfaceType.None)]
		internal class ShellLinkObject {}

		[ComImport]
		[Guid("000214F9-0000-0000-C000-000000000046")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)] 
		internal interface IShellLinkW
		{
			void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cch, 
			                  [MarshalAs(UnmanagedType.Struct)] ref WIN32_FIND_DATAW pfd, uint fFlags);
			void GetIDList(out IntPtr ppidl);
			void SetIDList(IntPtr pidl);
			void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cch);
			void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
			void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cch);
			void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
			void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cch);
			void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
			void GetHotkey(out ushort pwHotkey);
			void SetHotkey(ushort wHotkey);
			void GetShowCmd(out int piShowCmd);
			void SetShowCmd(int iShowCmd);
			void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cch, out int piIcon);
			void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
			void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, uint dwReserved);
			void Resolve (IntPtr hwnd, uint fFlags );
			void SetPath( [MarshalAs(UnmanagedType.LPWStr)] string pszFile );
		}

		public enum eShowMode
		{
			Normal    = 1,
			Maximized = 3,
			Minimized = 7,
		}

		[DllImport("kernel32.dll", EntryPoint="OutputDebugStringA", CharSet=CharSet.Ansi)]
		static extern void OutputDebugStringA(string s_Text);

		[DllImport("kernel32.dll", EntryPoint="FormatMessageA", CharSet=CharSet.Ansi)]
		static extern int FormatMessageA(int Flags, int Unused1, int Error, int Unused2, StringBuilder s_Text, int BufLen, int Unused3);

		[DllImport("kernel32.dll", EntryPoint="FormatMessageW", CharSet=CharSet.Unicode)]
		static extern int FormatMessageW(int Flags, int Unused1, int Error, int Unused2, StringBuilder s_Text, int BufLen, int Unused3);

		[DllImport("kernel32.dll", EntryPoint="GetCurrentThreadId")]
		static extern int GetCurrentThreadId();

		[DllImport("user32.dll", EntryPoint="GetWindowThreadProcessId")]
		static extern int GetWindowThreadProcessId(IntPtr h_Wnd, out int ProcID);

		[DllImport("user32.dll", EntryPoint="MapVirtualKey")]
		public static extern int MapVirtualKey(int Code, int Translation);

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		static Functions()
		{
			ExePath = Terminate(Path.GetDirectoryName(Application.ExecutablePath));
		}

		/// <summary>
		/// Use DebugView from www.sysinternals.com to see this debug output
		/// </summary>
		public static void PrintDebug(string s_Text)
		{
			OutputDebugStringA(s_Text);
		}
		public static void PrintDebug(string s_Text, Type t_Origin)
		{
			if (t_Origin == Defaults.DebugType)
				OutputDebugStringA(s_Text);
		}
		public static void PrintDebug(string s_Format, object o_Para1, Type t_Origin)
		{
			if (t_Origin == Defaults.DebugType)
				OutputDebugStringA(string.Format(s_Format, o_Para1));
		}
		public static void PrintDebug(string s_Format, object o_Para1, object o_Para2, Type t_Origin)
		{
			if (t_Origin == Defaults.DebugType)
				OutputDebugStringA(string.Format(s_Format, o_Para1, o_Para2));
		}
		public static void PrintDebug(string s_Format, object o_Para1, object o_Para2, object o_Para3, Type t_Origin)
		{
			if (t_Origin == Defaults.DebugType)
				OutputDebugStringA(string.Format(s_Format, o_Para1, o_Para2, o_Para3));
		}
		public static void PrintDebug(string s_Format, object o_Para1, object o_Para2, object o_Para3, object o_Para4, Type t_Origin)
		{
			if (t_Origin == Defaults.DebugType)
				OutputDebugStringA(string.Format(s_Format, o_Para1, o_Para2, o_Para3, o_Para4));
		}

		// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		// Read / write personal settings to Registry main key
		// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //private static string GetRegPath(eReg e_Registry)
        //{
        //    //string s_Path = ms_RegistryRoot;
        //    //if (e_Registry == eReg.Main)
        //    //    return s_Path;

        //    //s_Path += @"\WorkDirs\" + frmMain.WorkDir.Replace("\\", "/");
        //    //if (e_Registry == eReg.WorkDir)
        //    //    return s_Path;

        //    //ListViewEx.cItem i_Item = frmMain.SelectedFile;
        //    //return s_Path + @"\WorkCountrys\" + i_Item.s_DataBase + "/" + i_Item.s_FileName;
        //}

        //public static void RegistryWrite(eReg e_Registry, string s_Name, object o_Value)
        //{
        //    //RegistryKey i_Key = Registry.CurrentUser.CreateSubKey(GetRegPath(e_Registry));
        //    //i_Key.SetValue(s_Name, o_Value);
        //    //i_Key.Close();
        //}

        //public static object RegistryRead(eReg e_Registry, string s_Name, object o_Default)
        //{
        //    //RegistryKey i_Key = Registry.CurrentUser.OpenSubKey(GetRegPath(e_Registry));
        //    //if (i_Key == null)
        //    //    return o_Default;
			
        //    //object o_Value = i_Key.GetValue(s_Name, o_Default);
        //    //i_Key.Close();
        //    //return o_Value;
        //}

		/// <summary>
		/// Retrieves a list of all working directories
		/// </summary>
        //public static string[] GetWorkDirectories()
        //{
        //    //RegistryKey i_Key = Registry.CurrentUser.CreateSubKey(ms_RegistryRoot + @"\WorkDirs");
        //    //string[] s_Sub = i_Key.GetSubKeyNames();

        //    //for (int i=0; i<s_Sub.Length; i++)
        //    //{
        //    //    s_Sub[i] = s_Sub[i].Replace("/", "\\");
        //    //}			
        //    //return s_Sub;
        //}

		/// <summary>
		/// Adds or removes a working directory subkey in the Registry
		/// </summary>
        //public static void AddRemoveWorkDir(bool b_Add, string s_Path)
        //{
        //    //s_Path = ms_RegistryRoot + @"\WorkDirs\" + s_Path.Replace("\\", "/");

        //    //if (b_Add) Registry.CurrentUser.CreateSubKey    (s_Path);
        //    //else       Registry.CurrentUser.DeleteSubKeyTree(s_Path);
        //}

		/// <summary>
		/// Removes a work state subkey in the Registry
		/// or delete ALL workstates
		/// </summary>
        ////public static void RemoveWorkCountry(bool b_RemoveALL)
        //{
        //    try 
        //    { 
        //        //if (b_RemoveALL)
        //        //    Registry.CurrentUser.DeleteSubKeyTree(GetRegPath(eReg.WorkDir) + @"\WorkCountrys"); 
        //        //else
        //        //    Registry.CurrentUser.DeleteSubKeyTree(GetRegPath(eReg.WorkCountry)); 
        //    }
        //    catch {}
        //}

		// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

		public static void CreateShortcut(string s_ShortcutPath, string s_ObjectPath, string s_CmdLine, eShowMode e_Mode)
		{
            //if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            //{
            //    // to run this command on Windows 98/ME use IShellLinkA instead!
            //    frmMsgBox.Err(frmMain.Instance, "CreateShortcut requires NT Platforms!");
            //    return;
            //}

            //IShellLinkW i_ShellLink = null;
            //try
            //{
            //    i_ShellLink = (IShellLinkW) new ShellLinkObject();
            //    i_ShellLink.SetPath     (s_ObjectPath);
            //    i_ShellLink.SetShowCmd  ((int) e_Mode);
            //    i_ShellLink.SetArguments(s_CmdLine);

            //    UCOMIPersistFile i_Persist = (UCOMIPersistFile)i_ShellLink;
            //    i_Persist.Save(s_ShortcutPath, true);
            //}
            //catch (Exception Ex)
            //{ frmMsgBox.Err(frmMain.Instance, "Error creating shortcut:\n"+Ex.Message); }
            //finally
            //{ Marshal.ReleaseComObject(i_ShellLink); }
		}

		/// <summary>
		/// Creates program shortcuts in Quicklaunch bar and Startmenu\Programs
		/// this is done only ONCE at the first run of the program
		/// If the user deletes the shortcuts they will not be created anew
		/// </summary>
		public static void CreateShortcuts()
		{
            //bool b_Created = (int)RegistryRead(eReg.Main, "ShortcutsCreated", 0) == 1;

            //string s_Quick = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            //               + @"\Microsoft\Internet Explorer\Quick Launch\SqlBuilder.lnk";

            //string s_Progs = Environment.GetFolderPath(Environment.SpecialFolder.Programs) 
            //               + @"\SqlBuilder.lnk";

            //// If the shortcuts already exist -> update them. 
            //// (Maybe the user has moved the Exe to another place on his harddisk)
            //if (!b_Created || File.Exists(s_Quick))
            //    CreateShortcut(s_Quick, Application.ExecutablePath, "", eShowMode.Normal);
				
            //if (!b_Created || File.Exists(s_Progs))
            //    CreateShortcut(s_Progs, Application.ExecutablePath, "", eShowMode.Normal);

			//RegistryWrite(eReg.Main, "ShortcutsCreated", 1);
		}

		/// <summary>
		/// If there is no yet any program associated with SQL files -> set SqlBuilder as handler for SQL files (create s_NewKey)
		/// If there is already  a program associated with SQL files -> add menu entry "Open with SqlBuilder" to Explorer context menu
		/// s_Ext     = "sql"
		/// s_Menu    = "Open with SqlBuilder"
		/// s_App     = Path to SqlBuilder.exe
		/// s_CmdLine = "/print" (optional)
		/// s_NewKey  = "SqlBuilder.Editor" = name of new Registry key if required
		/// </summary>
//		public static bool RegisterFileExtension(string s_Ext, string s_Menu, string s_App, string s_CmdLine, string s_NewKey)
//		{
            //RegistryKey i_Ext = Registry.CurrentUser.CreateSubKey(@"Software\Classes\." + s_Ext);
            //if (i_Ext == null)
            //    return false;

            //// open existing handler (e.g. "sqlfile.7.1") or create new Handler (e.g. "SqlBuilder.Editor")
            //string s_Handler = ToStr(i_Ext.GetValue(""));
            //if (s_Handler.Length == 0)
            //{
            //    s_Handler = s_NewKey;
            //    i_Ext.SetValue("", s_Handler);

            //    RegistryKey i_Icon = i_Ext.CreateSubKey("DefaultIcon");
            //    i_Icon.SetValue("", s_App + ",0");
            //}

            //if (string.Compare(s_Handler, s_NewKey, true) == 0)
            //    s_Menu = "open"; // Open SQL files on doubleclick with SqlBuilder

            //RegistryKey i_Handler = Registry.CurrentUser.CreateSubKey(@"Software\Classes\" + s_Handler);
            //if (i_Handler == null) // failed
            //    return false;

            //RegistryKey i_Cmd = i_Handler.CreateSubKey("shell").CreateSubKey(s_Menu).CreateSubKey("command");
            //if (i_Cmd == null)
            //    return false;

            //i_Cmd.SetValue("", string.Format("\"{0}\" {1} \"%1\"", s_App, s_CmdLine));
            //return true;
//		}

		/// <summary>
		/// Opens a text file (ANSII, UTF8 or Unicode) and reads its content into a string
		/// returns null on error
		/// </summary>
		static public string ReadFileIntoString(Form i_Owner, string s_Path)
		{
            FileStream i_Stream = null;
            StreamReader i_Reader = null;
            try
            {
                i_Stream = File.OpenRead(s_Path);
                i_Reader = new StreamReader(i_Stream, System.Text.Encoding.Default);
                // single LF -> CR + LF
                string s_Text = ReplaceCRLF(i_Reader.ReadToEnd().Trim());

                if (!(i_Reader.CurrentEncoding is UTF7Encoding) &&
                    !(i_Reader.CurrentEncoding is UTF8Encoding) &&
                    !(i_Reader.CurrentEncoding is UnicodeEncoding) &&
                    !IsStringAscii(s_Text))
                {
                    frmMsgBox.Warn(i_Owner, "ATTENTION:\nYou have saved this document neither as UTF nor as Unicode although this document contains non-ASCII characters.\nProbably some characters will not display correctly.\nAssure that you save your documents using an adequate text encoding!");
                }
                return s_Text;
            }
            catch (Exception Ex)
            {
                frmMsgBox.Err(i_Owner, "Error reading\n" + s_Path + "\n" + Ex.Message);
                return null;
            }
            finally
            {
                if (i_Reader != null) i_Reader.Close();
                if (i_Stream != null) i_Stream.Close();
            }
        }

		/// <summary>
		/// Saves the given string into a text file (Unicode, UTF8 or ANSII)
		/// </summary>
		static public bool SaveStringToFile(Form i_Owner, string s_Path, string s_Data, Encoding e_Enc)
		{
            StreamWriter i_Writer = null;
            try
            {
                if (!CreateFolderTree(i_Owner, GetPath(s_Path)))
                    return false;

                i_Writer = new StreamWriter(s_Path, false, e_Enc);
                i_Writer.Write(s_Data);
                return true;
            }
            catch (Exception Ex)
            {
                frmMsgBox.Err(i_Owner, "Error saving file:\n" + s_Path + "\n" + Ex.Message);
                return false;
            }
            finally
            {
                if (i_Writer != null) i_Writer.Close();
            }
		}

		/// <summary>
		/// Save a text file and open it with the associated program
		/// </summary>
//		public static void SaveAndOpenFile(Form i_Owner, string s_File, string s_Text, Encoding e_Enc, ProcessWindowStyle e_Wnd)
//		{
            //if (!SaveStringToFile(i_Owner, s_File, s_Text, e_Enc))
            //    return;

            //OpenFile(i_Owner, s_File, e_Wnd);
//		}

		/// <summary>
		/// Opens a Filebrowser window and retunrs the selected path or null on error
		/// </summary>
		public static string SaveFileDlg(Form i_Owner, string s_Filter, string s_DefaultFilename)
		{
			SaveFileDialog i_Dlg = new SaveFileDialog();
			i_Dlg.Title            = "Save File";
			i_Dlg.FileName         = s_DefaultFilename;
			i_Dlg.DefaultExt       = Path.GetExtension(s_DefaultFilename);
			i_Dlg.InitialDirectory = "C:\\";   /*frmMain.WorkDir;*/
			i_Dlg.CheckPathExists  = true;
			i_Dlg.DereferenceLinks = true;
			i_Dlg.RestoreDirectory = false;
			i_Dlg.AddExtension     = true;
			i_Dlg.ShowHelp         = false;
			i_Dlg.Filter           = s_Filter;
			
			if (DialogResult.Cancel == i_Dlg.ShowDialog(i_Owner))
				return null;

			return i_Dlg.FileName;
		}

		/// <summary>
		/// Opens a Filebrowser window and retunrs the selected path or null on error
		/// </summary>
		public static string OpenFileDlg(Form i_Owner, string s_Filter)
		{
			OpenFileDialog i_Dlg = new OpenFileDialog();
			i_Dlg.Title            = "Load File";
            i_Dlg.InitialDirectory = "C:\\"; // frmMain.WorkDir;
			i_Dlg.CheckPathExists  = true;
			i_Dlg.DereferenceLinks = true;
			i_Dlg.RestoreDirectory = false;
			i_Dlg.ShowHelp         = false;
			i_Dlg.Multiselect      = false;
			i_Dlg.Filter           = s_Filter;
			
			if (DialogResult.Cancel == i_Dlg.ShowDialog(i_Owner))
				return null;

			return i_Dlg.FileName;
		}
		
		public static void OpenFile(Form i_Owner, string s_File, ProcessWindowStyle e_Wnd)
		{
			try
			{
				Process i_Proc = new Process();
				i_Proc.StartInfo.FileName = s_File;
				i_Proc.StartInfo.WindowStyle = e_Wnd;
				i_Proc.Start();
			}
			catch (Exception Ex)
			{
				frmMsgBox.Err(i_Owner, "Error executing file:\n" + s_File + "\n" + Ex.Message);
			}
		}

		// creates all not yet existing subfolders in s_Path
		// Example: s_Folder = "C:\Temp\Test\Extract\"  or
		//          s_Folder = "C:\Temp\Test\Extract"
		// If only the path    "C:\Temp" exists the subfolders "Test" and "Extract" will be created
		public static bool CreateFolderTree(Form i_Owner, String s_Folder)
		{
			bool b_OK = false;
			string s_Err = "Error creating folder tree:\n" + s_Folder;
			
			try { b_OK = CreateFolderTree2(s_Folder); }
			catch (Exception Ex) { s_Err += "\n" + Ex.Message; }

			if (!b_OK) frmMsgBox.Err(i_Owner, s_Err);
			return b_OK;
		}
		private static bool CreateFolderTree2(String s_Folder)
		{
			if (s_Folder == null || s_Folder.Length == 0)
				return false;

			if (Directory.Exists(s_Folder))
				return true;

			s_Folder = s_Folder.Trim("\\".ToCharArray());

			// recursively create the parent folders by cutting the last folder
			if (!CreateFolderTree2(Path.GetDirectoryName(s_Folder)))
				return false;

			Directory.CreateDirectory(s_Folder);
			return true;
		}

		public static bool DeleteFile(Form i_Owner, string s_File)
		{
			try 
			{ 
				File.Delete(s_File); 
				return true;
			}
			catch (Exception Ex)
			{
				frmMsgBox.Err(i_Owner, "Error deleting file:\n" + s_File + "\n" + Ex.Message);
				return false;
			}
		}
		
		/// <summary>
		/// This recursive function searches all files in the given folder and its subfolders
		/// s_Filter = "*.Dll|*.Exe|*.Dat" (pipe delimited extensions)
		/// s_Path   = Start path
		/// </summary>
		static public void EnumFiles(ArrayList i_FileList, string s_Path, string s_Filter, int s32_Level)
		{
			if (!Directory.Exists(s_Path))
				return;

			string[] s_ExtList = s_Filter.Split('|');
			foreach (string s_Ext in s_ExtList)
			{
				RecursiveEnumFiles(i_FileList, s_Path, s_Ext.Trim(), s32_Level);
			}
		}

		/// <summary>
		/// Reads an embedded binary resource (e.g. Chm file) into a Byte array
		/// </summary>
		public static Byte[] ReadBinaryResource(String s_ResourceName)
		{
			Assembly i_Ass  = Assembly.GetExecutingAssembly();
			Stream   i_Strm = i_Ass.GetManifestResourceStream(s_ResourceName);

			Byte[] u8_Buf = new Byte[i_Strm.Length];
			i_Strm.Read(u8_Buf, 0, (int)i_Strm.Length);
			return u8_Buf;
		}

		/// <summary>
		/// Saves binary data into a file, throws exception on error
		/// </summary>
		static public void SaveBinaryToFile(string s_Path, byte[] u8_Data)
		{
			FileStream i_Stream = null;
			try   
			{ 
				i_Stream = File.OpenWrite(s_Path); 
				i_Stream.Write(u8_Data, 0, u8_Data.Length);
			}
			finally
			{			
				if (i_Stream != null) i_Stream.Close();
			}
		}

		public static void Execute(string s_File, ProcessWindowStyle e_Wnd)
		{
			Process i_Proc = new Process();
			i_Proc.StartInfo.FileName = s_File;
			i_Proc.StartInfo.WindowStyle = e_Wnd;
			i_Proc.Start();
		}

		/// <summary>
		/// Exception if directory does not exist
		/// </summary>
		static private void RecursiveEnumFiles(ArrayList i_FileList, string s_Path, string s_Filter, int s32_Level)
		{
			if (s_Path == null || s_Path == "")
				return;

			Application.DoEvents();

			s_Path = Terminate(s_Path);
			if (s_Path.EndsWith(".svn\\") || s_Path.EndsWith("_svn\\")) // Skip Subversion directories
				return;

			if (s_Path.EndsWith(Defaults.DelSysObj)) // Skip deleted files
				return;

			string[] s_Files = Directory.GetFiles(s_Path, s_Filter);
			foreach (string s_File in s_Files)
			{
				i_FileList.Add(s_File);
			}

			if (s32_Level > 0)
			{
				string[] s_Dirs = Directory.GetDirectories(s_Path);
				foreach (string s_Dir in s_Dirs)
				{
					RecursiveEnumFiles(i_FileList, s_Dir, s_Filter, s32_Level-1);
				}
			}
		}

		/// <summary>
		/// "C:\Temp\Test.htm"  -->  "Test.htm"
		/// </summary>
		static public string GetFileName(string s_Path)
		{
			if (s_Path == null)
				return "";

			int Pos = s_Path.LastIndexOf(@"\");
			if (Pos <= 0)
				return s_Path;

			return s_Path.Substring(Pos+1);
		}

		/// <summary>
		/// "C:\Temp\Test.htm"  -->  "C:\Temp\"
		/// </summary>
		static public string GetPath(string s_Path)
		{
			if (s_Path == null)
				return "";

			int Pos = s_Path.LastIndexOf(@"\");
			if (Pos <= 0)
				return "";

			return s_Path.Substring(0, Pos+1);
		}

		/// <summary>
		/// "C:\Temp\Test.HTM"        --> ".htm"
		/// "C:\Project\.svn\entries" --> ""
		/// </summary>
		static public string GetFileExtension(string s_Path)
		{
			s_Path = GetFileName(s_Path);

			int Pos = s_Path.LastIndexOf('.');
			if (Pos <= 0)
				return "";

			return s_Path.Substring(Pos).ToLower();
		}

		/// <summary>
		/// "C:\Temp"  -->  "C:\Temp\"
		/// </summary>
		static public string Terminate(string s_Path)
		{
			if (s_Path == null || s_Path.Length == 0)
				return "";

			if (!s_Path.EndsWith("\\")) s_Path += "\\";
			return s_Path;
		}

		/// <summary>
		/// Casting without exceptions
		/// </summary>
		public static int ToInt(object o_Value)
		{
			if (o_Value == null || o_Value is DBNull)
				return 0;

			return Convert.ToInt32(o_Value);
		}

		/// <summary>
		/// returns the .ToString() value or "" if object == null
		/// floats and doubles are displayed with a dot instead of a comma
		/// </summary>
		public static string ToStr(object Obj)
		{
			if (Obj == null || Obj is DBNull)
				return "";

			string s_Val = Obj.ToString();
			if (Obj is float || Obj is double)
				return s_Val.Replace(',' , '.');

			return s_Val;				
		}

		/// <summary>
		/// Formats a Database value for display in DataGrid
		/// </summary>
		public static string DbValueForDisplay(object o_Value, bool b_ForHtml)
		{
			if (o_Value == null)
				return "(NO QUERY RESULT)";

			if (o_Value is DBNull)
			{
				if (b_ForHtml)
					return string.Format("<font color={0}>{1}</font>", ms_NullColor, Defaults.NullText);
				else
					return Defaults.NullText;
			}

			if (o_Value is Byte[]) // print the first 20 Bytes of the array
			{
				string s_Value = "";
				Byte[] i_Array = (Byte[]) o_Value;
				for (int i=0; i<i_Array.Length; i++)
				{
					if (i >= 20)
					{
						s_Value += string.Format("..... (Length {0})", FormatSize(i_Array.Length));
						break;
					}

					if (s_Value.Length > 0) s_Value += ",";
					s_Value += i_Array[i].ToString("X2");
				}
				return s_Value;
			}

			if (o_Value is DateTime)
			{
				return ((DateTime)o_Value).ToString(Defaults.TimeFormat);
			}

			if (b_ForHtml)
				return Functions.ReplaceHtml(o_Value.ToString());
			else
				return o_Value.ToString().Replace("\r", "\\r").Replace("\n", "\\n");;
		}

		/// <summary>
		/// Formats a Database value for SQL commands
		/// </summary>
        //public static string DbValueForSql(object o_Value)
        //{
        //    if (o_Value is DBNull)
        //        return "NULL";

        //    if (o_Value is Int16 || o_Value is Int32 || o_Value is Int64)
        //        return o_Value.ToString();

        //    if (o_Value is bool)
        //        return ((bool)o_Value) ? "1" : "0";

        //    if (o_Value is double || o_Value is decimal)
        //        return o_Value.ToString().Replace(",", ".");

        //    if (o_Value is DateTime)
        //        return "'" + ((DateTime)o_Value).ToString("yyyyMMdd HH:mm") + "'";

        //    if (o_Value is Byte[]) // Database type "image" (binary data) cannot be modified in the Table Editor
        //        return "Byte[]";   // This is only required for SqlTable.CalculateTableHashes()

        //    string s_Value = o_Value.ToString().TrimEnd().Replace("'", "''");
        //    return "'" + s_Value + "'"; 
        //}

		/// <summary>
		/// Formats a Database value for XML export
		/// </summary>
		public static string DbValueSerialize(object o_Value)
		{
			if (o_Value is DBNull)
				return Defaults.XmlNullText;

			// This date format makes it easy to edit an XML file manually
			if (o_Value is DateTime)
				return ((DateTime)o_Value).ToString("yyyy.MM.dd HH:mm:ss");

			if (o_Value is Byte[])
			{
				StringBuilder s_Bin = new StringBuilder(50000);
				foreach (Byte u8_Byte in (Byte[])o_Value)
				{
					s_Bin.Append(u8_Byte.ToString("X2"));
					// break the string after 100 characters
					if ((s_Bin.Length % 100) == 0)
						 s_Bin.Append("\r\n");
				}
				return s_Bin.ToString();
			}

			return o_Value.ToString().TrimEnd();
		}

		/// <summary>
		/// Creates a Database value from a string value, returns null on invalid data
		/// </summary>
		public static object DbValueDeserialize(string s_Value, Type t_Type)
		{
			try
			{
				if (s_Value == Defaults.XmlNullText)
					return DBNull.Value;

				if (t_Type == typeof(string))
					return s_Value;

				if (t_Type == typeof(int))
					return int.Parse(s_Value);

				if (t_Type == typeof(bool))
					return bool.Parse(s_Value);

				if (t_Type == typeof(long))
					return long.Parse(s_Value);

				if (t_Type == typeof(double))
					return StrToDouble(s_Value); // Allows '.' and ','

				if (t_Type == typeof(decimal))
					return decimal.Parse(s_Value);

				// High-speed parser for "yyyy.MM.dd HH:mm:ss"
				if (t_Type == typeof(DateTime))
				{
					if (s_Value.Length != 19  || s_Value[4]  != '.' || s_Value[7]  != '.'  || 
						s_Value[10]    != ' ' || s_Value[13] != ':' || s_Value[16] != ':' )
							return null;

					int Year = int.Parse(s_Value.Substring( 0,4));
					int Mon  = int.Parse(s_Value.Substring( 5,2));
					int Day  = int.Parse(s_Value.Substring( 8,2));
					int Hour = int.Parse(s_Value.Substring(11,2));
					int Min  = int.Parse(s_Value.Substring(14,2));
					int Sec  = int.Parse(s_Value.Substring(17,2));

					return new DateTime(Year, Mon, Day, Hour, Min, Sec);
				}

				// High-speed parser for hexadecimal data string of unlimited length
				if (t_Type == typeof(Byte[]))
				{
					// remove linebreaks
					s_Value = s_Value.Replace("\r\n", "");

					if ((s_Value.Length % 2) != 0)
						return null;

					Byte[] u8_Bytes = new Byte[s_Value.Length / 2];

					int Pos = 0;
					for (int A=0; A<u8_Bytes.Length; A++)
					{						
						int s32_Val = 0;
						for (int D=0; D<2; D++)
						{
							s32_Val *= 16;
							switch (s_Value[Pos++])
							{
								case '0': s32_Val += 0x0; break;
								case '1': s32_Val += 0x1; break;
								case '2': s32_Val += 0x2; break;
								case '3': s32_Val += 0x3; break;
								case '4': s32_Val += 0x4; break;
								case '5': s32_Val += 0x5; break;
								case '6': s32_Val += 0x6; break;
								case '7': s32_Val += 0x7; break;
								case '8': s32_Val += 0x8; break;
								case '9': s32_Val += 0x9; break;
								case 'A': s32_Val += 0xA; break;
								case 'B': s32_Val += 0xB; break;
								case 'C': s32_Val += 0xC; break;
								case 'D': s32_Val += 0xD; break;
								case 'E': s32_Val += 0xE; break;
								case 'F': s32_Val += 0xF; break;
								default: return null;
							}
						}
						u8_Bytes[A] = (Byte)s32_Val;
					}
					return u8_Bytes;
				}
			}
			catch {}

			return null;
		}

		/// <summary>
		/// Converts a string "4.2" into a double without throwing an exception on error and ignoring any locale setting
		/// Stops reading at any invalid character
		/// </summary>
		public static double StrToDouble(string s_In)
		{
			double d_Val   = 0;
			double d_Fact  = 1;
			bool   b_Point = false;
			for (int i=0; i<s_In.Length; i++)
			{
				char C = s_In[i];
				if (C == '.' || C == ',')
				{
					b_Point = true;
					continue;
				}

				if (C < '0' || C > '9')
					break;

				d_Val = 10 * d_Val + (C - '0');
				if (b_Point) d_Fact *= 10;
			}

			return d_Val / d_Fact;
		}

		/// <summary>
		/// After copying files from CD/DVD with the stupid Windows Explorer they are write protected
		/// This function removes write protection
		/// </summary>
		public static void RemoveWriteProtection(string s_File)
		{
			// Files which don't exist or which are on a server and are owned by another user 
			// would crash the following command
			try   { File.SetAttributes(s_File, FileAttributes.Archive); }
			catch {}
		}

		/// <summary>
		/// cuts the beginning of the string at the first occurence of s_Delimiter
		/// </summary>
		public static string CutBeginAt(string s_In, string s_Delimiter)
		{
			if (s_In == null)
				return "";

			int Pos = IndexOf(s_In, s_Delimiter, 0);
			if (Pos >= 0) return s_In.Substring(Pos + s_Delimiter.Length);
			else          return s_In;
		}

		/// <summary>
		/// cuts the rest of the string at the LAST occurence of s_Delimiter
		/// </summary>
		public static string CutEndReverseAt(string s_In, string s_Delimiter)
		{
			if (s_In == null)
				return "";
			
			int Pos = LastIndexOf(s_In, s_Delimiter, s_In.Length-1);
			if (Pos >= 0) return s_In.Substring(0, Pos);
			else          return s_In;
		}

		/// <summary>
		/// case insensitive LastIndexOf()
		/// </summary>
		public static int LastIndexOf(string s_Source, string s_Value, int s32_StartIndex)
		{
			if (s_Source == null || s_Value == null || s_Source.Length == 0 || s_Value.Length == 0)
				return -1;

			if (s32_StartIndex < 0 || s32_StartIndex >= s_Source.Length)
				return -1;

			return CultureInfo.InvariantCulture.CompareInfo.LastIndexOf(s_Source, s_Value, s32_StartIndex, CompareOptions.IgnoreCase);
		}
		
		/// <summary>
		/// case insensitive IndexOf()
		/// </summary>
		public static int IndexOf(string s_Source, string s_Value, int s32_StartIndex)
		{
			if (s_Source == null || s_Value == null || s_Source.Length == 0 || s_Value.Length == 0)
				return -1;

			if (s32_StartIndex < 0 || s32_StartIndex >= s_Source.Length)
				return -1;

			return CultureInfo.InvariantCulture.CompareInfo.IndexOf(s_Source, s_Value, s32_StartIndex, CompareOptions.IgnoreCase);
		}

		/// <summary>
		/// Searches case insensitive for string in the source string
		/// b_Reverse   = true: Search using LastIndexOf()
		/// b_WholeWord = true: The word must not be part of another word
		///                     There must be a non-alphanumeric character before and after the word
		/// </summary>
		public static int Find(string s_Source, string s_Value, int s32_StartIndex, bool b_Reverse, bool b_WholeWord)
		{
			while (true)
			{
				int s32_Start;
				if (b_Reverse) s32_Start = LastIndexOf(s_Source, s_Value, s32_StartIndex);
				else           s32_Start = IndexOf    (s_Source, s_Value, s32_StartIndex);

				if (b_WholeWord && s32_Start >= 0)
				{
					// Get the characters before and after the word in s_Value
					int s32_After  = s32_Start + s_Value.Length;
					int s32_Before = s32_Start - 1;

					if (b_Reverse) s32_StartIndex = s32_Before;
					else           s32_StartIndex = s32_After;

					char c_Before = (char)0;
					char c_After  = (char)0;
					if (s32_Before >= 0)              c_Before = s_Source[s32_Before];
					if (s32_After  < s_Source.Length) c_After  = s_Source[s32_After];

					if (Char.IsLetterOrDigit(c_Before) || c_Before == '_' ||
						Char.IsLetterOrDigit(c_After)  || c_After  == '_')
						continue;
				}
				return s32_Start;
			}
		}

		/// <summary>
		/// Removes the content starting at position s32_Start with s32_Length characters
		/// and replaces it with s_NewValue
		/// </summary>
		public static string Replace(string s_String, int s32_Start, int s32_Length, string s_NewValue)
		{
			if (s_String == null)
				return "";

			s_String = s_String.Remove(s32_Start, s32_Length);
			s_String = s_String.Insert(s32_Start, s_NewValue);
			return s_String;
		}

		/// <summary>
		/// Case insensitive Split which allows strings as split parameter
		/// </summary>
		public static string[] SplitEx(string s_In, string s_Delim)
		{
			if (s_In == null || s_In.Trim() == "")
				return new string[] {};

			ArrayList i_PosList = new ArrayList();

			int s32_Pos = 0;
			while (true)
			{
				s32_Pos = IndexOf(s_In, s_Delim, s32_Pos);
				if (s32_Pos < 0)
					break;

				i_PosList.Add(s32_Pos);
				s32_Pos += s_Delim.Length;
			}
			i_PosList.Add(s_In.Length);

			string[] s_Split = new string[i_PosList.Count];

			int s32_Start = 0;
			for (int i=0; i<i_PosList.Count; i++)
			{
				int s32_End = (int)i_PosList[i];
				s_Split[i]  = s_In.Substring(s32_Start, s32_End - s32_Start);
				s32_Start   = s32_End + s_Delim.Length;
			}
			return s_Split;
		}

		/// <summary>
		/// The stupid string.Split() command returns an array with one empty string if s_In is empty
		/// This function returns a string array of zero length if s_In is empty
		/// </summary>
		public static string[] SplitEx(string s_In, char u16_Delim)
		{
			if (s_In == null || s_In.Trim() == "")
				return new string[] {};

			return s_In.Split(u16_Delim);
		}

		/// <summary>
		/// gets the right n characters of a string
		/// </summary>
		public static string Right(string s_In, int s32_Count)
		{
			if (s_In == null)
				return "";

			if (s32_Count <= 0)
				return "";
			
			if (s32_Count >= s_In.Length)
				return s_In;

			return s_In.Substring(s_In.Length - s32_Count);
		}

		/// <summary>
		/// gets the left n characters of a string
		/// </summary>
		public static string Left(string s_In, int s32_Count)
		{
			if (s_In == null)
				return "";

			if (s32_Count <= 0)
				return "";
			
			if (s32_Count >= s_In.Length)
				return s_In;

			return s_In.Substring(0, s32_Count);
		}

		/// <summary>
		/// converts "This is a very long long text" -->  "This is a..."
		/// </summary>
		public static string ShortenText(string s_Text, int s32_MaxLen)
		{
			if (s_Text == null)
				return "";

			if (s32_MaxLen == 0 || s_Text.Length <= s32_MaxLen) 
				return s_Text;

			return s_Text.Substring(0, s32_MaxLen) + "...";
		}

		/// <summary>
		/// single LF -> CR + LF
		/// </summary>
		public static string ReplaceCRLF(string s_In)
		{
			return s_In.Replace("\r", "").Replace("\n", "\r\n");
		}

		/// <summary>
		/// replace characters which are not valid for HTML
		/// </summary>
		static public string ReplaceHtml(string s_Text)
		{
			if (s_Text == null)
				return "";

			StringBuilder s_Out = new StringBuilder(s_Text.Length*5);
			foreach (char Chr in s_Text)
			{
				switch (Chr)
				{
					case '\r': break;
					case '&':  s_Out.Append("&amp;");    break;
					case '<':  s_Out.Append("&lt;");     break;
					case '>':  s_Out.Append("&gt;");     break;
					case '\"': s_Out.Append("&quot;");   break;
					case '\n': s_Out.Append("<br>\r\n"); break;
					case ',':  s_Out.Append(",<wbr>");   break; // break up long lines which dont have spaces at each comma
					default:
						if (Chr < 128) s_Out.Append(Chr);  // ASCII
						else           s_Out.AppendFormat("&#{0};", (uint)Chr); // UNICODE
						break;
				}
			}
			return s_Out.Replace("  ", " &nbsp;").ToString();
		}

		/// <summary>
		/// replace characters which are not valid for RTF
		/// </summary>
		static public string ReplaceRtf(string s_Text)
		{
			if (s_Text == null)
				return "";

			StringBuilder s_Out = new StringBuilder(s_Text.Length*8);
			foreach (char Chr in s_Text)
			{
				switch (Chr)
				{
					case '\r': break;
					case '\\': s_Out.Append(@"\\"); break; // Escaping
					case '{' : s_Out.Append(@"\{"); break; // Escaping
					case '}' : s_Out.Append(@"\}"); break; // Escaping
					default:
						if (Chr < 128) s_Out.Append(Chr);  // ASCII
						else           s_Out.AppendFormat(@"\u{0}?", (uint)Chr); // UNICODE
						break;
				}
			}
			return s_Out.ToString();
		}

		/// <summary>
		/// returns colors to be used in <font color=#334455>
		/// </summary>
		static public string GetHtmlColor(Color c_Col)
		{
			int s32_Color = c_Col.ToArgb() & 0xFFFFFF;
			return "#" + s32_Color.ToString("X6");
		}

		/// <summary>
		/// Converts the first character of each word to uppercase
		/// e.g. COMPUTER.Domain.Company.com  --> Computer.Domain.Company.com
		/// If s_In is a filename, the file extension will always be lowercase
		/// </summary>
		public static string FirstToUpper(string s_In, bool b_IsFile)
		{
			// start of file extention
			int s32_ExtStart = (b_IsFile) ? s_In.LastIndexOf('.') : -1;

			if (s_In == null)
				return "";

			string s_Low = s_In.ToLower();
			string s_Upr = s_In.ToUpper();

			string s_Out = "";
			bool   b_Up  = true;

			for (int i=0; i<s_In.Length; i++)
			{
				char Lo = s_Low[i];
				char Up = s_Upr[i];

				if (Lo == Up) // sign or number
				{
					b_Up = (i != s32_ExtStart);
					s_Out += Lo;
					continue;
				}

				// characters
				if (b_Up) s_Out += Up;
				else      s_Out += Lo;
				b_Up = false;
			}
			return s_Out;
		}

		/// <summary>
		/// Limits a rectangle to the screen bounds of the monitor which contains the recatngle
		/// </summary>
		public static void LimitOnScreen(ref int Left, ref int Top, ref int Width, ref int Height)
		{
			Rectangle k_Screen = Screen.FromRectangle(new Rectangle(Left, Top, Width, Height)).WorkingArea;

			Width  = Math.Max(0, Math.Min(k_Screen.Width,  Width));
			Height = Math.Max(0, Math.Min(k_Screen.Height, Height));
			Left   = Math.Max(k_Screen.X, Math.Min(k_Screen.X + k_Screen.Width  - Width,  Left));
			Top    = Math.Max(k_Screen.Y, Math.Min(k_Screen.Y + k_Screen.Height - Height, Top));
		}

		/// <summary>
		/// returns a location of a rectangle of the size k_Size which is centered inside k_Bounds
		/// </summary>
		public static Point CenterToRectangle(Rectangle k_Bounds, Size k_Size)
		{
			int X = k_Bounds.Left + (k_Bounds.Width  - k_Size.Width)  / 2;
			int Y = k_Bounds.Top  + (k_Bounds.Height - k_Size.Height) / 2;
			return new Point(X, Y);
		}

		/// <summary>
		/// Centers a window to its owner if exists or to the monitor on which the window has its largest portion
		/// (CenterParent() is not very util because the parent may not be set)
		/// If the owner is still in its OnLoad() processing (which means that the owner is not yet on the screen)
		/// the form will be centered to the owner of the owner
		/// </summary>
		public static void CenterWindow(Form frm)
		{
			Rectangle k_Bounds;
			if (frm.Owner != null) k_Bounds = new Rectangle(frm.Owner.Location, frm.Owner.Size);
			else                   k_Bounds = Screen.FromControl(frm).WorkingArea;

			frm.Location = Functions.CenterToRectangle(k_Bounds, frm.Size);
		}

		/// <summary>
		/// returns "230 Byte" or "25.3 KB" or "671.9 GB"
		/// </summary>
		public static string FormatSize(long s64_Size)
		{
			if (s64_Size < 1024)
				return s64_Size.ToString() + " Byte";

			s64_Size *= 10;
			s64_Size /= 1024;
			if (s64_Size < 10240)
				return string.Format("{0}.{1} KB", s64_Size/10, s64_Size%10);

			s64_Size /= 1024;
			if (s64_Size < 10240)
				return string.Format("{0}.{1} MB", s64_Size/10, s64_Size%10);

			s64_Size /= 1024;
			return string.Format("{0}.{1} GB", s64_Size/10, s64_Size%10);
		}

		/// <summary>
		/// s_File must be a FULL path !
		/// </summary>
		public static bool MoveToRecycleBin(Form i_Owner, string s_File)
		{
			// Recycling must run in another thread !!
			Recycler i_Recycler = new Recycler();
			return   i_Recycler.MoveToRecycleBin(i_Owner, s_File);
		}

		/// <summary>
		/// Returns a text string which explains the Win32 API error code
		/// </summary>
		public static string ExplainApiError(int s32_Error)
		{
			const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;

			StringBuilder s_Msg = new StringBuilder(1000);

			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
				FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM, 0, s32_Error, 0, s_Msg, s_Msg.Capacity, 0);
			else
				FormatMessageA(FORMAT_MESSAGE_FROM_SYSTEM, 0, s32_Error, 0, s_Msg, s_Msg.Capacity, 0);

			if (s_Msg.Length == 0)
				s_Msg.Append("Windows has no explanation for this error code.");

			return string.Format("Error {0}: {1}", s32_Error, s_Msg);
		}

		/// <summary>
		/// Calculates the MD5 of a string
		/// </summary>
		public static string CalcMD5(string s_Text)
		{
			MD5     i_MD5  = new MD5CryptoServiceProvider();
			Byte[] u8_Text = Encoding.Unicode.GetBytes(s_Text);
			byte[] u8_MD5  = i_MD5.ComputeHash(u8_Text);

			// Convert Byte array to Hex value-string
			string s_Out = "";
			for (int i=0; i<u8_MD5.Length; i++)
			{
				s_Out += u8_MD5[i].ToString("X2");
			}
			return s_Out;
		}

		/// <summary>
		/// Encrypt/Decrypt a string with a password
		/// returns "" if string cannot be decrypted
		/// </summary>
		public static string Crypt(string s_Data, string s_Password, bool b_Encrypt) 
		{ 
			byte[] u8_Salt = new byte[] {0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6}; 

			PasswordDeriveBytes i_Pass = new PasswordDeriveBytes(s_Password, u8_Salt);

			Rijndael i_Alg = Rijndael.Create();
			i_Alg.Key = i_Pass.GetBytes(32);
			i_Alg.IV  = i_Pass.GetBytes(16);

			ICryptoTransform i_Trans = (b_Encrypt) ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor();

			MemoryStream i_Mem   = new MemoryStream();
			CryptoStream i_Crypt = new CryptoStream(i_Mem, i_Trans, CryptoStreamMode.Write);

			try
			{
				byte[] u8_Data;
				if (b_Encrypt) u8_Data = Encoding.Unicode.GetBytes(s_Data);
				else           u8_Data = Convert.FromBase64String (s_Data);

				i_Crypt.Write(u8_Data, 0, u8_Data.Length);
				i_Crypt.Close();

				if (b_Encrypt) return Convert.ToBase64String    (i_Mem.ToArray());
				else           return Encoding.Unicode.GetString(i_Mem.ToArray());
			}
			catch { return ""; }
		}

		/// <summary>
		/// Reads a binary resource (The resource must be declared as "embedded" in Visual Studio!!)
		/// Example: s_IconName = "Stop.ico"
		/// </summary>
		public static Icon ReadEmbeddedIconResource(String s_IconName)
		{
			Assembly i_Ass  = Assembly.GetExecutingAssembly();
			Stream   i_Strm = i_Ass.GetManifestResourceStream("SqlBuilder.Resources." + s_IconName);
			return new Icon(i_Strm);
		}

		/// <summary>
		/// reads an embedded string resource (e.g. Sql file) into a string
		/// Example: s_ResourceName = "GetTables.sql"
		/// </summary>
		public static String ReadStringResource(String s_ResourceName)
		{
			Assembly     i_Ass  = Assembly.GetExecutingAssembly();
			Stream       i_Strm = i_Ass.GetManifestResourceStream("SqlBuilder.Resources." + s_ResourceName);
			StreamReader i_Read = new StreamReader(i_Strm);
			return       i_Read.ReadToEnd();
		}

		public static int GetCurrentThread()
		{
			return GetCurrentThreadId();
		}

		public static int GetWindowThread(IntPtr h_Wnd)
		{
			int s32_ProcessID;
			return GetWindowThreadProcessId(h_Wnd, out s32_ProcessID);
		}

		/// <summary>
		/// returns a string of random characters with the length s32_Len
		/// consisting of only characters found in s_Chars
		/// Each time this function is called with the same Seed it will return the same string!!
		/// </summary>
		public static string GetRandomString(int s32_Len, int s32_Seed, string s_Chars)
		{
			Random i_Random = new Random(s32_Seed);
			
			StringBuilder s_Out = new StringBuilder(s32_Len);
			for (int i=0; i<s32_Len; i++)
			{
				// Next() returns a nonnegative random number less than the specified maximum.
				int Pos = i_Random.Next(s_Chars.Length);
				s_Out.Append(s_Chars[Pos]);
			}
			return s_Out.ToString();
		}

		public static int GetStringChecksum(string s_String)
		{
			int s32_Sum = 0;
			foreach (char c_Chr in s_String)
			{
				s32_Sum += c_Chr;
			}
			return s32_Sum;
		}

		/// <summary>
		/// Changes the brightness of the given color
		/// s32_Percent = +5 --> add 5% to current brightness
		/// s32_Percent = -5 --> subtract 5% from current brightness
		/// s32_Percent = +100 --> white
		/// s32_Percent = -100 --> black
		/// </summary>
		public static Color ChangeBrightness(Color c_Color, int s32_Percent)
		{
			if (s32_Percent < -100 || s32_Percent > 100)
				throw new Exception("Invalid parameter");

			double d_Factor = (double)(100 - Math.Abs(s32_Percent)) / 100;
			if (s32_Percent > 0)
			{
				int R = (int)(d_Factor * (255 - c_Color.R));
				int G = (int)(d_Factor * (255 - c_Color.G));
				int B = (int)(d_Factor * (255 - c_Color.B));
				return Color.FromArgb(255-R, 255-G, 255-B);
			}
			else
			{
				int R = (int)(d_Factor * c_Color.R);
				int G = (int)(d_Factor * c_Color.G);
				int B = (int)(d_Factor * c_Color.B);
				return Color.FromArgb(R,G,B);
			}
		}

		/// <summary>
		/// returns false if the string contains any character with ASCII code > 127
		/// </summary>
		public static bool IsStringAscii(string s_Text)
		{
			foreach(char c_Char in s_Text)
			{
				if (c_Char > 127)
					return false;
			}
			return true;
		}
	}
}
