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
using System.Drawing;
using System.Collections;

namespace SqlBuilder
{
	/// <summary>
	/// Default settings for your company
	/// </summary>
	public class Defaults
	{
		public const string Version = "5.4";

		// Write Debug output from the specified source (e.g. typeof(Parser))
		public static Type  DebugType = null;

		public const bool   TrustedConnection = false;
		public const string Server            = "Sql Server";
		public const string User              = "sa";
		public const string Password          = "sa";

		// the default databases to be checked for Database Backup and Search
		// The databases must be separated by pipe: e.g. "Base1|Base2|Base3"
		public const string DbaseList = "GPPROD";

		// timeout for SQL commands (seconds)
		public const int    Timeout   = 120; 

		// Display of DateTime
		public const string TimeFormat = "dd.MM.yyyy HH:mm";
		public const string DateFormat = "dd.MM.yyyy";
		// Display of DBNull (do not use brackets here, as ] finishes the edit mode!)
		public const string NullText   = "(NULL)";
		// Display of IDENTITY cells which have been added via a new row
		public const string IdentText  = "(IDENT)";

		// The string to be written for DBNull values in XML export.
		// This string should be chosen that it is not probabale that it appears in a table as value in a string column.
		// But it should not be too complicated so the XML document can easily be manipulated in a text editor
		public const string XmlNullText = "@Null@";

		// When exporting a table to HTML repeat the header every n-rows (-1 for no repeat)
		public const int    HtmlHeaderRepeat = 25;
		// The header in the table export or query result export to HTML
		public const string HtmlHeaderColor  = "#E0D0C0";

		// Defaults when adding new sysobjects
		public const string CreateFunc = "CREATE FUNCTION {0} (@Param as int)\r\nRETURNS int\r\nAS\r\nBEGIN\r\nRETURN 0\r\nEND\r\n";
		public const string CreateProc = "CREATE PROCEDURE {0} AS\r\nSELECT * from Table\r\n";
		public const string CreateView = "CREATE VIEW {0}\r\nAS\r\nSELECT * from Table\r\n";
		public const string CreateTrig = "CREATE TRIGGER {0} ON Table\r\nFOR UPDATE,INSERT\r\nAS\r\n";
		public const string CreateTabl = "IF object_id('{0}') IS NULL\r\nCREATE TABLE {0}\r\n(\r\nID int IDENTITY(1,1) NOT NULL,\r\nName varchar(30) PRIMARY KEY NOT NULL\r\n)\r\nGO\r\n";

		// Folder where deleted SysObjects are temporarily saved and then moved to recycle bin
		public const string DelSysObj  = "DeletedSysObjects\\";
		// Folders to be created inside the working directory
		public const string ScriptDir  = "Scripts\\";
		public const string BackupDir  = "DatabaseBackup\\";

		// The files which are generated in the Script directory
		public const string XmlSettings    = "SqlBuilder.xml";
		public const string CompoundScript = "CompoundScript.sql";

		// The files which are generated in the Backup directory
		public const string XmlBackup      = "Backup.xml";

		// URL where to download the latest version in the format "4.1" from a text file
		public const string UpdateUrl      = "http://netcult.ch/elmue/UpdateSqlBuilder.txt"; // "" --> disabled
		public const string DownloadUrl    = "http://electronix.ch/ptbsync/SqlBuilder.zip";  // "" --> disabled
		// Check for new versions on the server every X days
		public const int    UpdateInterval = 1;

		// This string is used to encrypt the password in the XML files
		public const string EncryptionKey = "1Gsdu7s$B6(d3#H@j7kSqPlke6&?0!:M§A.-U*'Y=Fua";

		#region GUI colors

		// The background color for Listview, RichTextBox, DataGrid, ....
		public static readonly Color BkgColControl = Color.White;

		// The background color for columns in the DataGrid
		public static Color GridBackColor(bool b_Primary, bool b_Unique, bool b_Disabled)
		{
			if (b_Disabled) 
				return Color.FromArgb(0xF0, 0xF0, 0xF0);
			if (b_Primary && b_Unique) 
				return Color.FromArgb(0xFF, 0xEA, 0xFF);
			if (b_Primary)  
				return Color.FromArgb(0xFF, 0xEA, 0xEA);
			if (b_Unique)   
				return Color.FromArgb(0xFF, 0xFF, 0xE5);

			return BkgColControl;
		}
		// The grid background color of the selected cell
		public static Color GridSelectedBackColor(bool b_Disabled)
		{
			if (b_Disabled) return Color.FromArgb(0xDD, 0xDD, 0xDD);
			else            return Color.FromArgb(0xBB, 0xBB, 0xFF);
		}

		/// <summary>
		/// Colors in DataGrid in frmDataGrid
		/// </summary>
		public static Color GridForeColor(Type t_DataType)
		{
			if (t_DataType == typeof(DBNull))
				return Color.FromArgb(0xAA, 0xAA, 0xAA);

			if (t_DataType == typeof(Byte)   || 
				t_DataType == typeof(Int16)  || 
				t_DataType == typeof(Int32)  || 
				t_DataType == typeof(Int64)  || 
				t_DataType == typeof(double) || 
				t_DataType == typeof(decimal))
				return Color.DarkGreen;

			if (t_DataType == typeof(DateTime))
				return Color.DarkBlue;

			if (t_DataType == typeof(string))
				return Color.DarkRed;

			if (t_DataType == typeof(Exception)) // used to display errors
				return Color.Red;

			return Color.Black;
		}

		/// <summary>
		/// returns the text colors for the listview (file list)
		/// </summary>
		public static Color ListViewColor(string s_FileExt)
		{
			switch(s_FileExt)
			{
				case ".sql":  return Color.FromArgb(0x00, 0x00, 0xCC); // Blue  (file)
				case ".tabl": return Color.FromArgb(0x60, 0x30, 0xA0); // Blue  (file)
				case ".proc": return Color.FromArgb(0x00, 0xA0, 0x00); // Green (sysobject)
				case ".func": return Color.FromArgb(0x40, 0x70, 0x60); // Green (sysobject)
				case ".view": return Color.FromArgb(0x80, 0x80, 0x00); // Green (sysobject)
				case ".trig": return Color.FromArgb(0x00, 0x60, 0x00); // Green (sysobject)
				default: return Color.Black;
			}
		}

		#endregion

		#region Parser

		// syntax highlighting of user defined datatypes
		// you can remove the following if you dont need it
		public const string UserDataTypes = " nBinario nBoolean nDate nDecimal nFloat nGUID nLong nPrecio nStringBig nStringLong nStringMax nStringMid nStringShort nTexto ";

		// RtfHtmlBuilder
		public const int IndentPlain =   4; // spaces to indent plain SQL text
		public const int IndentHtml  =  20; // pixel to indent HTML code
		public const int IndentRtf   = 300; // millipoint to indent RTF code

		public static Hashtable DefineParserColors()
		{
			Hashtable i_Colors = new Hashtable();

			i_Colors.Add(Parser.eType.Comand,    Color.Blue);
			i_Colors.Add(Parser.eType.Keyword,   Color.BlueViolet);
			i_Colors.Add(Parser.eType.Function,  Color.Red);
			i_Colors.Add(Parser.eType.Operator,  Color.Red);
			i_Colors.Add(Parser.eType.DataType,  Color.DodgerBlue);
			i_Colors.Add(Parser.eType.String,    Color.DarkRed);
			i_Colors.Add(Parser.eType.CommentL,  Color.DarkCyan);
			i_Colors.Add(Parser.eType.CommentP,  Color.DarkCyan);
			i_Colors.Add(Parser.eType.Number,    Color.DarkGreen);

			return i_Colors;
		}

		/// <summary>
		/// return false to remove useless line comments
		/// you can remove the following if you dont need it
		/// </summary>
		public static bool CheckLineComment(string s_Text)
		{
			string s_TEXT = s_Text.Substring(2).ToUpper().Trim(); // cut "--"

			// Kill the most stupid comments like "--NAS 23_12_04", "--****BY RBO 03/12/04", "-- GAVEDANO 08.07.2005"
			while (s_TEXT.StartsWith("*") || s_TEXT.StartsWith("-"))
			       s_TEXT = s_TEXT.Substring(1);

			s_TEXT = s_TEXT.Trim();

			if (s_TEXT.StartsWith("BY "))
				s_TEXT = s_TEXT.Substring(3).Trim();

			string[] s_Parts = s_TEXT.Split(' ');

			bool b_Match = (s_Parts.Length == 2 || s_Parts.Length == 3 && s_Parts[2].Length < 5);
			if  (b_Match && s_Parts[0].Length < 13 && (s_Parts[1].Length == 8 || s_Parts[1].Length == 10))
			{
				if ((s_Parts[1][2] == '_' && s_Parts[1][5] == '_') ||
					(s_Parts[1][2] == '/' && s_Parts[1][5] == '/') ||
					(s_Parts[1][2] == '.' && s_Parts[1][5] == '.') ||
					(s_Parts[1][2] == '-' && s_Parts[1][5] == '-'))
						return false;
			}

			// Remove useless comments like --FIN ROLEA 18.08.2005
			if (s_TEXT.StartsWith("INICIO ")    || 
				s_TEXT.StartsWith("FIN ")       || 
				s_TEXT.StartsWith("END ")       || 
				s_TEXT.EndsWith(" (COMENTADO)") ||
				s_TEXT.EndsWith(" INICIO")      ||
				s_TEXT.EndsWith(" FIN"))
					return false;

			return true;
		}

		#endregion
	}
}
