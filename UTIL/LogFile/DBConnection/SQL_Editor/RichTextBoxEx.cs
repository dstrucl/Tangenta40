// -------------------------------------------------------
// SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SqlBuilder.Forms;

using FindCallback = SqlBuilder.Forms.frmFind.delFindReplace;
using FindParam    = SqlBuilder.Forms.frmFind.cParam;

namespace SqlBuilder.Controls
{
	/// <summary>
	/// Adds functionality to RichTextBox which Microsoft has forgotten to implement
	/// </summary>
	public class RichTextBoxEx : RichTextBox
	{
		#region class UndoBuffer

		public class UndoBuffer
		{
			protected class RtfData
			{
				public string s_Rtf;
				public string s_Text; // only for debugging
				public int  s32_SelStart;
				public int  s32_SelLen;

				public RtfData(RichTextBoxEx i_Box)
				{
					s_Rtf        = i_Box.Rtf;
					s32_SelStart = i_Box.SelectionStart;
					s32_SelLen   = i_Box.SelectionLength;

					// only for debugging
					if (Defaults.DebugType == typeof(UndoBuffer))
					{
						s_Text = i_Box.Text;
						while (s_Text.EndsWith("\n"))
						{
							s_Text = Functions.Left(s_Text, s_Text.Length -1);
						}					
						s_Text = "\"" + s_Text + "\""; 
					}
				}

				public void SetRtf(RichTextBoxEx i_Box)
				{
					i_Box.SetRtf(s_Rtf, s32_SelStart, s32_SelLen);
				}

				public bool Equals(RtfData i_Data)
				{
					return (s_Rtf == i_Data.s_Rtf && s32_SelStart == i_Data.s32_SelStart && s32_SelLen == i_Data.s32_SelLen);
				}
			}

			StackEx mi_Undo = new StackEx();
			StackEx mi_Redo = new StackEx();
			RichTextBoxEx mi_Box;

			public UndoBuffer(RichTextBoxEx i_Box)
			{
				mi_Box = i_Box;
			}

			public bool IsEmpty
			{
				get { return mi_Undo.Count == 0 && mi_Redo.Count == 0; }
			}

			protected bool TextChanged()
			{
				if (mi_Undo.Count == 0)
					return true;
				
				RtfData i_Data = (RtfData)mi_Undo.Peek();
				return (i_Data.s_Rtf != mi_Box.Rtf);
			}

			/// <summary>
			/// Call this when the user has typed new text
			/// </summary>
			public void SetNewText()
			{
				Functions.PrintDebug("SetNewText() called", typeof(UndoBuffer));

				// Don't store empty text for the first time
				if (mi_Box.Text.Trim().Length == 0 && mi_Undo.Count == 0)
					return;

				if (TextChanged())
				{
					mi_Redo.Clear();
					mi_Undo.Push(new RtfData(mi_Box));
				}

				DebugOut();
			}

			/// <summary>
			/// Call this when the user hits CTRL + Z
			/// </summary>
			public void Undo()
			{
				Functions.PrintDebug("Undo() called", typeof(UndoBuffer));

				if (mi_Undo.Count == 0)
				{
					mi_Box.WriteStatus("Undo not available!");
					return;
				}
				
				RtfData i_Old = (RtfData) mi_Undo.Pop();
				RtfData i_New = new RtfData(mi_Box);

				// The new text has just been pushed and nothing changed afterwards
				if (i_Old.Equals(i_New) && mi_Undo.Count > 0)
					i_Old = (RtfData) mi_Undo.Pop();
				
				i_Old.SetRtf(mi_Box);
				mi_Redo.Push (i_New);

				DebugOut();
			}

			/// <summary>
			/// Call this when the user hits CTRL + Y
			/// </summary>
			public void Redo()
			{
				Functions.PrintDebug("Redo() called", typeof(UndoBuffer));

				if (mi_Redo.Count == 0)
				{
					mi_Box.WriteStatus("Redo not available!");
					return;
				}
				
				RtfData i_Old = (RtfData) mi_Redo.Pop();
				RtfData i_New = new RtfData(mi_Box);
				
				i_Old.SetRtf(mi_Box);
				mi_Undo.Push (i_New);

				DebugOut();
			}

			private void DebugOut()
			{
				if (Defaults.DebugType != typeof(UndoBuffer))
					return;

				if (mi_Undo.Count == 0) Functions.PrintDebug("Undo Stack empty.");
				if (mi_Redo.Count == 0) Functions.PrintDebug("Redo Stack empty.");

				for (int i=0; i<mi_Undo.Count; i++)
				{
					RtfData i_Data = (RtfData)mi_Undo[i];
					Functions.PrintDebug(string.Format("Undo Stack Pos {0}: {1}", i, i_Data.s_Text));
				}
				for (int i=0; i<mi_Redo.Count; i++)
				{
					RtfData i_Data = (RtfData)mi_Redo[i];
					Functions.PrintDebug(string.Format("Redo Stack Pos {0}: {1}", i, i_Data.s_Text));
				}
				Functions.PrintDebug("------------------------------");
			}
		}

		#endregion

		#region Win32 API

		const int FALSE           = 0;
		const int TRUE            = 1;
		const int WM_SETREDRAW    = 0x000B;

		[DllImport("user32.dll", EntryPoint="SendMessageA")]
		static extern int SendMessageA(IntPtr h_Wnd, int message, int wParam, int lParam);
		
		#endregion

		FindParam  mi_FindParam   = new FindParam();
		string     ms_LastContent = "";
		int      ms32_Lock        = 0;
		Keys       me_LastKey     = Keys.None;
		StatusInfo mi_LblStatus   = null;
		UndoBuffer mi_UndoBuf;

		public RichTextBoxEx()
		{
			HideSelection = false; // do NOT execute this in OnCreateControl() !!
			DetectUrls    = false;
			mi_UndoBuf    = new UndoBuffer(this);
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl ();
			BackColor = Defaults.BkgColControl;
		}

		/// <summary>
		/// Defines the label in which to display status information
		/// </summary>
		public StatusInfo StatusBar
		{
			set { mi_LblStatus = value; }
			get { return mi_LblStatus; }
		}

		/// <summary>
		/// Writes text to the status bar if a statusbar was assigned
		/// </summary>
		public void WriteStatus(string s_Text)
		{
			if (mi_LblStatus != null)
				mi_LblStatus.SetTransientText(s_Text);
		}

		public UndoBuffer UndoRedoBuffer
		{
			get { return mi_UndoBuf; }
			set 
			{ 
				if (value == null) 
					mi_UndoBuf = new UndoBuffer(this);
				else
					mi_UndoBuf = value; 
			}
		}

		/// <summary>
		/// Avoids flickering
		/// Allows multiple calls
		/// </summary>
		private void LockWindow(bool b_Lock)
		{
			if (b_Lock)
			{
				if (ms32_Lock == 0)
				{
					SendMessageA(Handle, WM_SETREDRAW, FALSE, 0); // flicker free paiting
				}
				ms32_Lock ++;
			}
			else
			{
				ms32_Lock --;
				if (ms32_Lock == 0)	
				{
					SendMessageA(Handle, WM_SETREDRAW, TRUE, 0);
					Invalidate(); // Now paint all changes at once!
				}
			}
		}

		/// <summary>
		/// The TAB key normally switches from one control to the next.
		/// To capture the TAB key this MUST happen before the message 
		/// is processed by the default windows procedure
		/// </summary>
		public override bool PreProcessMessage(ref Message msg)
		{
			const int WM_KEYDOWN = 0x100;
			const int VK_TAB	 = 0x009;

			if (msg.Msg == WM_KEYDOWN && (int)msg.WParam == VK_TAB)
			{
				if ((int)(Control.ModifierKeys & Keys.Control) > 0) // CTRL down
				{
					// Send CTRL + TAB to frmMain.OnRtfBoxKeyDown() by firing the event
					OnKeyDown(new KeyEventArgs(Keys.Tab | Keys.Control));
					return true; // no further processing
				}
			}
			return base.PreProcessMessage (ref msg);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			bool b_Ctrl = (e.Control && !e.Alt && !e.Shift);
			if  (b_Ctrl)
			{
				switch (e.KeyCode)
				{
					case Keys.G:
						e.Handled = true;
						GotoLine();
						return;

					case Keys.F:
					case Keys.R:
						e.Handled = true;
						FindReplace(true, false, false);
						return;

					case Keys.I: // RTF formatting stuff not needed here
					case Keys.L:
						e.Handled = true;
						return;

					case Keys.Z:
						e.Handled = true;
						mi_UndoBuf.Undo();
						return;

					case Keys.Y:
						e.Handled = true;
						mi_UndoBuf.Redo();
						return;

					case Keys.V:
					case Keys.X:
						mi_UndoBuf.SetNewText();
						break;
				}
			}
			
			if (!e.Control && !e.Alt && !e.Shift)
			{
				// type new text always in black
				if (SelectionLength == 0)
					SelectionColor = Color.Black;

				switch (e.KeyCode)
				{
					case Keys.F3:
						e.Handled = true;
						FindReplace(mi_FindParam.s_Find.Length == 0, false, true);
						return;

					case Keys.F4:
						e.Handled = true;
						FindReplace(mi_FindParam.s_Find.Length == 0, true, true);
						return;
				}
			}

	
			// Store changes only once after multiple text deletes are finished !
			if ((me_LastKey == Keys.Delete || me_LastKey == Keys.Back) &&
				 me_LastKey != e.KeyCode)
			{
				mi_UndoBuf.SetNewText();
			}

			me_LastKey = e.KeyCode;
			base.OnKeyDown(e);
		}

		/// <summary>
		/// If this function is called from outside the class it seraches the first occurrence of s_Text and selects it
		/// </summary>
		public void SearchAndSelectText(FindParam i_Param)
		{
			SelectionLength = 0;
			SelectionStart  = 0;
			mi_FindParam    = i_Param;
			FindReplace(false, false, false);
		}

		/// <summary>
		/// Callback called from frmFind on button "Find" / "Replace"
		/// </summary>
		private string OnFindCallback(FindParam i_Param)
		{
			mi_FindParam = i_Param;
			return FindReplace(false, false, !i_Param.b_Replace);
		}

		/// <summary>
		/// b_OpenForm  = true  --> Open the search window (frmFind)
		/// b_Reverse   = true  --> search reverse
		/// b_Increment = false --> search from the current cursor position
		/// b_Increment = true  --> search from the current cursor position + 1
		/// returns the text to be displayed in the status bar
		/// </summary>
		private string FindReplace(bool b_OpenForm, bool b_Reverse, bool b_Increment)
		{
			if (b_OpenForm)
			{
				if (SelectedText.Length > 0) mi_FindParam.s_Find = SelectedText;
				mi_FindParam.b_Replace = !this.ReadOnly; // disable Replace

				frmFind i_Find = new frmFind(0, mi_FindParam, new FindCallback(OnFindCallback));
				
				i_Find.ShowDialog(this.TopLevelControl);
				return "";
			}

			bool b_Replaced = false;
			int  s32_Start  = SelectionStart;

			if (b_Increment)
			{
				if (b_Reverse) s32_Start --;
				else           s32_Start ++;
			}

			for (int s32_Loops=0; s32_Loops<=2; s32_Loops++)
			{
				s32_Start = Functions.Find(Text, mi_FindParam.s_Find, s32_Start, b_Reverse, mi_FindParam.b_WholeWord);

				if (s32_Start < 0) // not found
				{
					// loop back to the begin / end of the text
					if (b_Reverse) s32_Start = Text.Length-1;
					else           s32_Start = 0;
					continue;
				}

				int s32_SelBefore = SelectionStart;
				int s32_LenBefore = SelectionLength;

				SetSelection(s32_Start, mi_FindParam.s_Find.Length); // found

				if (!mi_FindParam.b_Replace)
					return ""; // Find

				if (b_Replaced)
					return ""; // replace only once

				if (s32_Start != s32_SelBefore || mi_FindParam.s_Find.Length != s32_LenBefore)
					return ""; // replace only if text to be replaced was already selected

				SelectedText = mi_FindParam.s_Replace;
				b_Replaced   = true;
				s32_Loops    = 0;
				s32_Start += mi_FindParam.s_Replace.Length;
				// don't return here -> search the next text match
			}

			SelectionLength = 0;

			WriteStatus("Not found !");
			return "Not found !";
		}

		private void GotoLine()
		{
			frmFind i_Goto = new frmFind(TotalLines, new FindParam(), null);
			if (i_Goto.ShowDialog() != DialogResult.OK)
				return;

			int s32_Pos = GetLineIndex(i_Goto.LineNumber);
			if (s32_Pos < 0)
				return;

			SetSelection(s32_Pos, 0);
		}

		public void Scroll(int cX, int cY)
		{
			const int EM_LINESCROLL = 0x00B6;
			SendMessageA(Handle, EM_LINESCROLL, cX, cY);
		}

		/// <summary>
		/// Sets selection and scrolls it to the middle of the screen
		/// </summary>
		public void SetSelection(int s32_Start, int s32_Length)
		{
			SelectionStart   = s32_Start;
			SelectionLength  = s32_Length;
			int s32_Line     = GetLineFromChar(s32_Start);
			FirstVisibleLine = s32_Line - VisibleLines / 2;
		}

		/// <summary>
		/// The line indexes are ONE based!!!
		/// </summary>
		public int FirstVisibleLine
		{
			get
			{
				const int EM_GETFIRSTVISIBLELINE = 0x00CE;
				return SendMessageA(Handle, EM_GETFIRSTVISIBLELINE, 0, 0) + 1;
			}
			set
			{
				int s32_First = FirstVisibleLine;
				int s32_Limit = Math.Max(1, TotalLines - VisibleLines +1); // don't scroll behind the last line
				int s32_Value = Math.Max(1, value);
				int s32_Diff  = Math.Min(s32_Limit, s32_Value) - s32_First;
				Scroll(0, s32_Diff);
			}
		}

		/// <summary>
		/// returns the count of lines which are displayed without cropping in the rtfBox
		/// </summary>
		public int VisibleLines
		{
			get 
			{ 
				int    s32_ClientHeight = this.Height - 4; // Subtract window border
				return s32_ClientHeight / this.Font.Height; 
			}
		}

		/// <summary>
		/// ATTENTION: This function returns the count of display lines which depends on the width of the control
		/// LineCount is NOT equal to this.Lines.Length because one (text)line may wrap over multiple (display)lines !!
		/// </summary>
		public int TotalLines
		{
			get { return GetLineFromChar(Text.Length); }
		}

		public int GetLineFromChar(int s32_Pos)
		{
			const int EM_LINEFROMCHAR = 0x00C9;
			return SendMessageA(Handle, EM_LINEFROMCHAR, s32_Pos, 0) + 1;
		}

		public int GetLineIndex(int s32_Line)
		{
			const int EM_LINEINDEX = 0x00BB;
			return SendMessageA(Handle, EM_LINEINDEX, s32_Line-1, 0);
		}

		public void GetLineAndCharPos(out int s32_Line, out int s32_CharPos)
		{
			s32_Line    = GetLineFromChar(SelectionStart);
			s32_CharPos = SelectionStart - GetLineIndex(s32_Line) +1;
		}

		/// <summary>
		/// returns true if the user has modified the text since the last setting Text
		/// This will also work correctly if parsing undoes user changes
		/// </summary>
		public bool TextModified
		{
			get
			{
				return (this.Text != ms_LastContent);
			}
			set 
			{ 
				if (value) ms_LastContent = null;
				else       ms_LastContent = this.Text;
			}
		}

		/// <summary>
		/// Sets the rtfBox content anew and sets the cursor position without flickering
		/// The scrollbar is scrolled to its origional position (unchanged)
		/// The changes are stored in the Undo Buffer
		/// </summary>
		public void ReplaceRtf(string s_Rtf, int s32_SelectionStart, int s32_SelectionLength)
		{
			const int EM_GETTHUMB  = 0x00BE;
			const int WM_VSCROLL   = 0x0115;
			const int SB_THUMBPOSITION = 4;

			LockWindow(true); // avoids flickering

			int ThumbPos = SendMessageA(Handle, EM_GETTHUMB, 0,0);

			this.Rtf = s_Rtf;

			// Restore Cursor position
			SelectionStart  = s32_SelectionStart;
			SelectionLength = s32_SelectionLength;

			// Restore Scrollbar position
			SendMessageA(Handle, WM_VSCROLL, 0x10000 * ThumbPos + SB_THUMBPOSITION, 0);

			LockWindow(false);

			mi_UndoBuf.SetNewText(); // store in UndoBuffer
		}

		/// <summary>
		/// Replace Rtf text flicker free and set cursor position
		/// The scrcollbar is scrolled that the cursor is in the middle of the RichTextBox
		/// !!! Changes are !NOT! stored in the Undo Buffer !!!
		/// This function is only for usage by the embedded class UndoBuffer (not public)
		/// </summary>
		protected void SetRtf(string s_Rtf, int s32_SelectionStart, int s32_SelectionLength)
		{
			LockWindow(true); // avoids flickering

			this.Rtf = s_Rtf;
			SetSelection(s32_SelectionStart, s32_SelectionLength);

			LockWindow(false);
		}

		protected override void OnSelectionChanged(EventArgs e)
		{
			base.OnSelectionChanged (e);

			int s32_Line, s32_CharPos;
			GetLineAndCharPos(out s32_Line, out s32_CharPos);
			WriteStatus(string.Format("Line: {0},  Character: {1},  Absolute Position: {2}", s32_Line, s32_CharPos, SelectionStart));
		}
	}
}
