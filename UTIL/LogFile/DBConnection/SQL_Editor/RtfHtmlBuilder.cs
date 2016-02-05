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
using System.Text;
using System.Drawing;
using System.Collections;

namespace SqlBuilder
{
	/// <summary>
	/// Builds cleanly formatted SQL code as RTF, Html and Plain Text
	/// </summary>
	public class RtfHtmlBuilder
	{
		StringBuilder ms_Rtf;
		StringBuilder ms_Html;
		StringBuilder ms_Plain;
		ArrayList     mi_Colors;
		bool          mb_Linebreak;
		bool          mb_DivOpen;
		int         ms32_Color;
		int         ms32_Indent;
		int         ms32_RtfPosition;

		public RtfHtmlBuilder()
		{
			Clear();
		}

		public void Clear()
		{
			ms_Rtf            = new StringBuilder(50000);
			ms_Html           = new StringBuilder(50000);
			ms_Plain          = new StringBuilder(50000);
			mi_Colors         = null;
			mb_Linebreak      = false;
			mb_DivOpen        = false;
			ms32_Color        = -1;
			ms32_Indent       = 0;
			ms32_RtfPosition  = 0;
		}

		public Color SelectionColor
		{
			set
			{
				if (mi_Colors == null)
					mi_Colors = new ArrayList();

				int Pos = mi_Colors.IndexOf(value);
				if (Pos < 0)
					Pos = mi_Colors.Add(value);

				ms32_Color = Pos;
			}
			get 
			{ 
				if (ms32_Color < 0)
					return Color.Black;
				else
					return (Color)mi_Colors[ms32_Color]; 
			}
		}

		public int SelectionIndent
		{
			set { ms32_Indent = Math.Max(0, value); }
			get { return ms32_Indent; }
		}

		/// <summary>
		/// Adds a single word, a line, a linebreak or multiple lines
		/// </summary>
		public void AppendText(string s_Text)
		{
			s_Text = s_Text.Replace("\r", "");

			ms32_RtfPosition += s_Text.Length;

			// Do not use Functions.SplitEx() here !!
			string[] s_Lines = s_Text.Split("\n".ToCharArray());

			for (int L=0; L<s_Lines.Length; L++)
			{
				string s_Line = s_Lines[L];

				// ############ APPEND NEWLINE #################3

				if (L>0) // s_Lines.Length > 1 if linebreak contained in s_Text
				{
					if (!mb_DivOpen)
						ms_Html.Append("<div>");

					// Indent also lines which are completely empty (for correct cursor position in RTF)
					if (mb_Linebreak)
						ms_Rtf.AppendFormat("\\li{0} ", ms32_Indent * Defaults.IndentRtf);

					ms_Plain.Append("\r\n");
					ms_Html. Append("&nbsp;</div>\r\n");
					ms_Rtf.  Append("\\par\\pard\r\n");

					// Add Indent not here but at the next time when text is output!!
					mb_Linebreak = true;
					mb_DivOpen   = false;
				}

				if (s_Line.Length == 0) // empty line if "\n" at the end of s_Text
					continue;

				// ############ APPEND INDENT #################3
					
				if (mb_Linebreak)
				{
					mb_Linebreak = false;
					if (ms32_Indent > 0)
					{
						ms_Plain.Append      (' ',                                ms32_Indent * Defaults.IndentPlain);
						ms_Rtf.  AppendFormat("\\li{0} ",                         ms32_Indent * Defaults.IndentRtf);
						ms_Html. AppendFormat("<div style='margin-left:{0}px;'>", ms32_Indent * Defaults.IndentHtml);
						mb_DivOpen = true;
					}
				}
					
				if (!mb_DivOpen)
				{
					mb_DivOpen = true;
					ms_Html.Append("<div>");
				}

				// ############ APPEND TEXT #################3

				ms_Plain.Append(s_Line);

				if (s_Line == " ")
				{
					ms_Rtf. Append(" ");
					ms_Html.Append(" ");
				}
				else 
				{
					// This is required for CommentP which spans over multiple lines
					// Removse spaces sent from the server, because the identation is done here
					// and not on the server
					s_Line = s_Line.TrimStart(' ');

					// RTF requires Color INDEX!
					ms_Rtf.AppendFormat("\\cf{0} ", ms32_Color+1);
					ms_Rtf.Append(Functions.ReplaceRtf(s_Line));

					// HTML requires Color as hex value!
					ms_Html.AppendFormat("<font color={0}>", Functions.GetHtmlColor(SelectionColor));
					ms_Html.Append(Functions.ReplaceHtml(s_Line));
					ms_Html.Append("</font>");
				}
			}
		}

		public string BuildRtf(Font i_Font)
		{
			StringBuilder s_ColorTable = new StringBuilder(1000);

			if (mi_Colors != null)
			{
				s_ColorTable.Append("{\\colortbl;");
				foreach (Color c_Col in mi_Colors)
				{
					s_ColorTable.Append("\\red");
					s_ColorTable.Append(c_Col.R);
					s_ColorTable.Append("\\green");
					s_ColorTable.Append(c_Col.G);
					s_ColorTable.Append("\\blue");
					s_ColorTable.Append(c_Col.B);
					s_ColorTable.Append(";");
				}
				s_ColorTable.Append("}\r\n");
			}

			return "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset0 "
				+ i_Font.Name
				+ ";}}\r\n"
				+ s_ColorTable
				+ "\\viewkind4\\uc1\\pard\\lang3082\\f0\\fs"
				+ (int)(i_Font.Size * 2) // Halfpoint --> Point
				+ "\r\n"
				+ ms_Rtf
				+ "\\par}\r\n";
		}

		public string GetHtml()
		{
			if (mb_DivOpen)
			{
				ms_Html.Append("&nbsp;</div>");
				mb_DivOpen = false;
			}

			return ms_Html.ToString();
		}

		public string GetText()
		{
			return ms_Plain.ToString();
		}

		/// <summary>
		/// returns the position in the Rtf code (used to restore the cursor position)
		/// </summary>
		public int RtfPosition
		{
			get { return ms32_RtfPosition; }
		}
	}
}
