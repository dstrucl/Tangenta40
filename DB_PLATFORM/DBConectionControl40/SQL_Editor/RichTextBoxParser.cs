// -------------------------------------------------------
// SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Windows.Forms;

namespace SqlBuilder.Controls
{
	/// <summary>
	/// A RichTextBoxEx with an own RTF parser
	/// The process of parsing is aborted if the user is typing
	/// </summary>
	public class RichTextBoxParser : RichTextBoxEx
	{
		bool   mb_Reparsing = false;
		Parser mi_ReParser  = new Parser();

		/// <summary>
		/// Parses the SQL code in the RTF Box and replaces it maintaining the current selection / cursor position
		/// </summary>
		public void ReplaceRtf(Parser i_Parser, bool b_ModifyLinebreaks)
		{
			int s32_CursorPos = this.SelectionStart;
			int s32_SelLen    = this.SelectionLength;

			// ParseText() stores ms32_CursorPos in the linked chain
			// and FillRtfBuilder() sets ms32_CursorPos to the new position
			if (!i_Parser.Parse(this.Text, b_ModifyLinebreaks, true, ref s32_CursorPos))
				return; // Aborted

			// replace RTF flickerless
			ReplaceRtf(i_Parser.GetRtf(this.Font), s32_CursorPos, s32_SelLen);
		}

		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			// Important: If the parser is currently working, abort it as the text has changed anew.
			// A very long text in the RTF box may need 2 seconds for parsing,
			// during this time the input is blocked and the user cannot type anything!
			mi_ReParser.Abort();

			if (!e.Alt && !e.Shift)
			{
				if (e.Control)
				{
					Parser i_Parser = new Parser();

					switch (e.KeyCode)
					{
						case Keys.X: // Cut
						case Keys.C: // Copy
							e.Handled = true;
							string s_Selected = SelectedText;
							if (s_Selected.Length == 0)
							{
								StatusBar.SetTransientText("Nothing selected!");
							}
							else
							{
								i_Parser.Parse(s_Selected, true, false);
								Clipboard.SetDataObject(i_Parser.SQL.TrimEnd(), true);
								StatusBar.SetTransientText("Selected SQL copied to clipboard");
							}
							if (e.KeyCode == Keys.X)
								SelectedText = "";
							break;

						case Keys.V: // Paste
							e.Handled    = false; // !!!!
							mb_Reparsing = true;
							break;

						case Keys.P: // Parse Linebreaks
							e.Handled = true;
							ReplaceRtf(i_Parser, true);
							break;
					}
				}
				else // without CTRL key
				{
					switch (e.KeyCode)
					{
						case Keys.Enter: // a new line has begun
						case Keys.Space: // a new word has begun
							mb_Reparsing = true;
							break;
					}
				}
			}

			base.OnKeyDown (e);
		}

		protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
		{
			// Important: If the parser is currently working, abort it as the text has changed anew.
			// A very long text in the RTF box may need 2 seconds for parsing,
			// during this time the input is blocked and the user cannot type anything!
			mi_ReParser.Abort();

			if (mb_Reparsing && !ReadOnly)
			{
				mb_Reparsing = false;
				ReplaceRtf(mi_ReParser, false);
			}

			base.OnKeyUp (e);
		}
	}
}
