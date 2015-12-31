// -------------------------------------------------------
// SqlBuilder by ElmüSoft
// www.netcult.ch/elmue
// www.codeproject.com/KB/database/SqlBuilder.aspx
// -------------------------------------------------------

using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SqlBuilder.Controls;

namespace SqlBuilder
{
	public class Parser
	{
		#region Constant Definitions 

		// ATTENTION: ALl strings must start end end with space !!

		const string COMMANDS  = 
			" alter backup begin break close commit continue create deallocate declare delete drop "
			+ "else end exec execute fetch go goto grant if insert load open print raiserror restore return revoke "
			+ "rollback save select set setuser shutdown update updatetext use waitfor while writetext ";

		const string KEYWORDS  = 
			" action add all and any append as asc authorization "
			+ "between browse bulk by "
			+ "cascade case check checkpoint clustered collate column committed compute confirm constraint contains containstable controlrow cross cube current current_date current_time cursor "
			+ "database dbcc default deny desc disk distinct distributed double dummy dump "
			+ "encryption errlvl errorexit escape except exists exit "
			+ "file fillfactor floppy for foreign forward_only freetext freetexttable from full function "
			+ "group grouping "
			+ "having holdlock "
			+ "identity identity_insert identitycol in index inner intersect into is isolation "
			+ "join "
			+ "key kill "
			+ "left level like lineno "
			+ "mirrorexit move "
			+ "national next no nocheck nonclustered nocount nolock not nounload null "
			+ "of off offsets on once only opendatasource openquery openrowset option or order outer over "
			+ "percent perm permanent pipe plan precision prepare primary privileges proc procedure processexit public "
			+ "read readtext read_only reconfigure recovery references repeatable replication restrict returns right rollup rowguidcol rule "
			+ "schema serializable some statistics stats "
			+ "table tape temp temporary then ties to top tran transaction trigger truncate tsequal "
			+ "uncommitted union unique "
			+ "values varying view "
			+ "when where with work ";

		const string FUNCTIONS  = 
			" abs acos app_name ascii asin atan atn2 avg "
			+ "cast case ceiling charindex checksum checksum_agg coalesce collationproperty col_length col_name columnproperty convert count cos cot count_big current_timestamp current_user cursor_status "
			+ "databaseproperty databasepropertyex datalength dateadd datediff datename datepart day db_id db_name degrees difference "
			+ "exp "
			+ "file_id file_name filegroup_id filegroup_name filegroupproperty fileproperty floor "
			+ "formatmessage fulltextcatalogproperty fulltextserviceproperty "
			+ "getansinull getdate getutcdate "
			+ "host_id host_name "
			+ "ident_current ident_incr ident_seed index_col indexkey_property indexproperty is_member is_srvrolemember isdate isnull isnumeric "
			+ "len log log10 lower ltrim "
			+ "max min month "
			+ "newid nullif "
			+ "object_id object_name objectproperty "
			+ "parsename patindex permissions pi power "
			+ "quotename "
			+ "radians rand replace replicate reverse round rtrim "
			+ "scope_identity serverproperty session_user sessionproperty sign sin soundex space sql_variant_property "
			+ "sqrt "
			+ "stats_date stdev stdevp str stuff substring sum suser_sid suser_sname system_user "
			+ "tan textptr textvalid typeproperty "
			+ "unicode upper user user_id user_name "
			+ "var varp "
			+ "year ";

		const string DATATYPES = Defaults.UserDataTypes +
			" bigint binary bit "
			+ "char character "
			+ "datetime dec decimal "
			+ "float "
			+ "image int integer "
			+ "money "
			+ "nchar ntext numeric nvarchar "
			+ "real "
			+ "smalldatetime smallint smallmoney sql_variant sysname "
			+ "text timestamp tinyint "
			+ "uniqueidentifier "
			+ "varbinary varchar ";
		
		const string OPERATORS = " + - * / % = != !> !< < > <> <= >= =* ";

		public enum eType
		{
			Comand = 1, // 1-based !! NOT zero !!
			Keyword,
			Function,
			Operator,
			Number,
			DataType,
			String,
			CommentL,   // Line
			CommentP,   // Paragraph
			ParOpen,    // (
			ParClose,   // )
			LineBreak,
			Comma,
			Unknown,
			Invalid,
		}

		public enum eCmd
		{
			Undefined,
			Alter,
			AndOr,
			As,
			Begin,
			Between,
			Case,
			Column,
			Compute,
			Create,
			Delete,
			Distributed,
			Exec,
			Else,
			End,
			For,
			From,
			Function,
			Group,
			Having,
			If,
			Insert,
			Into,
			Join,
			Left,
			On,
			Option,
			Order,
			Procedure,
			Returns,
			Right,
			Select,
			Set,
			Top,
			Transaction,
			Trigger,
			Union,
			Update,
			View,
			When,
			Where,
		}

		public enum eIndent
		{
			Normal    =  0, // do nothing
			Shift     =  1, // only indent / outdent without adding linefeed
			SingleLF  =  2, // NewLine + Item + Indent     or
			                // Item + NewLine + Outdent
			DoubleLF  =  3, // NewLine + Item + NewLine + Indent     or
			                // NewLine + Item + NewLine + Outdent
		}

		#endregion

		#region class ParseItem

		protected class ParseItem
		{
			protected Parser    mi_Parser      = null;
			protected eType     me_Type        = eType.Unknown;
			protected eCmd      me_Cmd         = eCmd. Undefined;
			protected eIndent   me_Indent      = eIndent.Normal;
			protected eIndent   me_Outdent     = eIndent.Normal;
			protected string    ms_Text        = null;
			protected ParseItem mi_Next        = null;
			protected ParseItem mi_Prev        = null;
			protected bool      mb_Permanent   = false;
			protected bool      mb_AppendSpace = true;
			protected int     ms32_RelCursor   = -1;
			protected ArrayList mi_Contains    = null;
			
			protected static Hashtable mi_Colors = null;

			// Constructor
			public ParseItem(Parser i_Parser, string s_Text)
			{
				mi_Parser = i_Parser;

				if (mi_Colors == null) // fill static table only once
					mi_Colors = Defaults.DefineParserColors();

				Text = s_Text;
			}

			public string Text
			{
				get { return ms_Text; }
				set
				{
					ms_Text = value.TrimStart(" ".ToCharArray());
					me_Type = eType.Unknown;
					me_Cmd  = eCmd.Undefined;
					mb_AppendSpace = true;

					if (ms_Text.Length == 0)
						throw new Exception("Invalid item text");

					if (ms_Text.Length == 1)
					{
						switch (ms_Text[0])
						{
							case '(':  me_Type = eType.ParOpen;   return;
							case ')':  me_Type = eType.ParClose;  return;
							case ',':  me_Type = eType.Comma;     return;
							case '\n': 
								me_Type = eType.LineBreak;
								mb_AppendSpace = false; // IMPORTANT: Otherwise every lins tarts with a space
								return;
						}
					}

					if (ms_Text.StartsWith("/*"))
					{
						me_Type = eType.CommentP;
						return;
					}

					if (ms_Text.StartsWith("'") || ms_Text.StartsWith("N'"))
					{
						me_Type = eType.String;
						return;
					}

					// remove linebreakes from all the following items
					ms_Text = ms_Text.Replace("\n", " ");

					// do NOT remove space at the end !! (the user may be typing a text with many spaces!!)
					if (ms_Text.StartsWith("--")) 
					{
						if (!Defaults.CheckLineComment(ms_Text))
							me_Type = eType.Invalid; // This comment will be deleted soon
						else
						{
							me_Type = eType.CommentL;
							mb_AppendSpace = false; // IMPORTANT: Otherwise the comment becomes longer with every parsing
						}
						return;
					}

					ms_Text = ms_Text.Trim(); // remove space and LBR !!! AFTER CommentL !!!

					// IMPORTANT: Add space before !AND! after keyword to avoid a match 
					// of "GO" in "GOTO" or "ON" in "FUNCTION"
					string s_TextSpace = " " + ms_Text + " ";

					if (Functions.IndexOf(COMMANDS, s_TextSpace, 0) >= 0)
					{
						me_Type = eType.Comand;
						ms_Text = ms_Text.ToUpper();

						switch (ms_Text)
						{
							case "ALTER":  me_Cmd = eCmd.Alter;  break;
							case "BEGIN":  me_Cmd = eCmd.Begin;  break;
							case "CREATE": me_Cmd = eCmd.Create; break;
							case "DELETE": me_Cmd = eCmd.Delete; break;
							case "EXEC":   me_Cmd = eCmd.Exec;   break;
							case "ELSE":   me_Cmd = eCmd.Else;   break;
							case "END":    me_Cmd = eCmd.End;    break;
							case "IF":     me_Cmd = eCmd.If;     break;
							case "INSERT": me_Cmd = eCmd.Insert; break;
							case "SELECT": me_Cmd = eCmd.Select; break;
							case "SET":    me_Cmd = eCmd.Set;    break;
							case "UPDATE": me_Cmd = eCmd.Update; break;
						}
						return;
					}
					if (Functions.IndexOf(KEYWORDS, s_TextSpace, 0) >= 0)
					{
						me_Type = eType.Keyword;
						ms_Text = ms_Text.ToUpper();
					
						switch (ms_Text)
						{
							case "AND":         me_Cmd = eCmd.AndOr;       break;
							case "AS":          me_Cmd = eCmd.As;          break;
							case "BETWEEN":     me_Cmd = eCmd.Between;     break;
							case "CASE":        me_Cmd = eCmd.Case;        break;
							case "COLUMN":      me_Cmd = eCmd.Column;      break;
							case "COMPUTE":     me_Cmd = eCmd.Compute;     break;
							case "DISTRIBUTED": me_Cmd = eCmd.Distributed; break;
							case "FOR":         me_Cmd = eCmd.For;         break;
							case "FROM":        me_Cmd = eCmd.From;        break;
							case "FUNCTION":    me_Cmd = eCmd.Function;    break;
							case "GROUP":       me_Cmd = eCmd.Group;       break;
							case "HAVING":      me_Cmd = eCmd.Having;      break;
							case "INTO":        me_Cmd = eCmd.Into;        break;
							case "JOIN":        me_Cmd = eCmd.Join;        break;
							case "LEFT":        me_Cmd = eCmd.Left;        break;
							case "OPTION":      me_Cmd = eCmd.Option;      break;
							case "ON":          me_Cmd = eCmd.On;          break;
							case "OR":          me_Cmd = eCmd.AndOr;       break;
							case "ORDER":       me_Cmd = eCmd.Order;       break;
							case "PROC": 
							case "PROCEDURE":   me_Cmd = eCmd.Procedure;   break;
							case "RETURNS":     me_Cmd = eCmd.Returns;     break;
							case "RIGHT":       me_Cmd = eCmd.Right;       break;
							case "TOP":         me_Cmd = eCmd.Top;         break;
							case "TRAN":
							case "TRANSACTION": me_Cmd = eCmd.Transaction; break;
							case "TRIGGER":     me_Cmd = eCmd.Trigger;     break;
							case "UNION":       me_Cmd = eCmd.Union;       break;
							case "VIEW":        me_Cmd = eCmd.View;        break;
							case "WHEN":        me_Cmd = eCmd.When;        break;
							case "WHERE":       me_Cmd = eCmd.Where;       break;
						}
						return;
					}
					if (Functions.IndexOf(FUNCTIONS, s_TextSpace, 0) >= 0)
					{
						me_Type = eType.Function;
						ms_Text = ms_Text.ToLower();
						return;
					}
					if (Functions.IndexOf(DATATYPES, s_TextSpace, 0) >= 0)
					{
						me_Type = eType.DataType;
						ms_Text = ms_Text.ToLower();
						return;
					}
					if (Functions.IndexOf(OPERATORS, s_TextSpace, 0) >= 0)
					{
						me_Type = eType.Operator;
						return;
					}

					bool b_Number = true;
					for (int i=0; i<ms_Text.Length; i++)
					{
						if (ms_Text[i] < '0' || ms_Text[i] > '9')
						{
							b_Number = false;
							break;
						}
					}
					if (b_Number)
					{
						me_Type = eType.Number;
						return;
					}

					// everything else (variable names, column names etc..)
					me_Type = eType.Unknown;
				}
			}

			public eType Type
			{
				get { return me_Type; }
				set 
				{ 
					me_Type = value; 
					if (me_Type == eType.Function)
						ms_Text = ms_Text.ToLower();

					if (me_Type == eType.Comand ||
						me_Type == eType.Keyword)
						ms_Text = ms_Text.ToUpper();
				}
			}
			public eCmd Cmd
			{
				get { return me_Cmd; }
			}

			/// <summary>
			/// The next item in the double linked chain
			/// </summary>
			public ParseItem Next
			{
				get { return mi_Next; }
			}
			/// <summary>
			/// The previous item in the double linked chain
			/// </summary>
			public ParseItem Prev
			{
				get { return mi_Prev; }
			}
			/// <summary>
			/// true -> The item can not be deleted by clean-up operations
			/// </summary>
			public bool Permanent
			{
				get { return mb_Permanent; }
				set { mb_Permanent = value; }
			}

			/// <summary>
			/// this item contains the cursor at the given relative index
			/// </summary>
			public int CursorPos
			{
				get { return ms32_RelCursor; }
				set { ms32_RelCursor = value; }
			}

			/// <summary>
			/// Remove an item from the double linked chain
			/// The item itslef stays linked and valid and Prev and Next still work !
			/// Only items which the user has put into the SQL code can be removed
			/// Linebreaks added by SetLinebreakAfter() are permanent and not deleted by Remove(false)
			/// </summary>
			public void Remove(bool b_IgnorePermanent)
			{
				if (mb_Permanent && !b_IgnorePermanent)
					return;

				if (me_Type == eType.LineBreak && !mi_Parser.mb_ModifyLineBR)
					return;

				// never remove the last 2 linebreaks!
				if (getType(this) == eType.LineBreak && this.Next == null)
					return;
				if (getType(Next) == eType.LineBreak && Next.Next == null)
					return;

				// remove item from linked chain
				if (mi_Next != null) mi_Next.mi_Prev = this.mi_Prev;
				if (mi_Prev != null) mi_Prev.mi_Next = this.mi_Next;

				if (this.CursorPos < 0)
					return;

				// ------- Inherit the cursor position of the removed item -------
				
				// If a linebreak is removed:
				// CursorPos == 0 means that the cursur is at the END   of the line (before "\n")
				// CursorPos == 1 means that the cursur is at the BEGIN of the line (behind "\n")
				if (me_Type == eType.LineBreak)
				{
					// If there is a linebreak beside inherit the curor position unchanged
					if (getType(mi_Prev) == eType.LineBreak)
					{
						mi_Prev.CursorPos = this.CursorPos;
						Functions.PrintDebug("Remove()  set CursorPos={0} to prev LBR  {1} <{2}> {3}", this.CursorPos, getDebug(this.Prev), getDebug(this), getDebug(this.Next), typeof(Parser));
						return;
					}
					
					if (getType(mi_Next) == eType.LineBreak)
					{
						mi_Next.CursorPos = this.CursorPos;
						Functions.PrintDebug("Remove()  set CursorPos={0} to next LBR  {1} <{2}> {3}", this.CursorPos, getDebug(this.Prev), getDebug(this), getDebug(this.Next), typeof(Parser));
						return;
					}

					// The next item is not a linebreak
					if (this.CursorPos == 1 && mi_Next != null)
					{
						mi_Next.CursorPos = 0;
						Functions.PrintDebug("Remove()  set CursorPos=0 to next item  {0} <{1}> {2}", getDebug(this.Prev), getDebug(this), getDebug(this.Next), typeof(Parser));
						return;
					}
				}

				// Set cursor behind the previous item's space character (space delimiter which is added in GetText())
				if (mi_Prev != null)
				{
					mi_Prev.CursorPos = mi_Prev.Text.Length + (mb_AppendSpace ? 1 : 0);
					Functions.PrintDebug("Remove()  set CursorPos={0} to prev item  {1} <{2}> {3}", mi_Prev.CursorPos, getDebug(this.Prev), getDebug(this), getDebug(this.Next), typeof(Parser));
				}
			}

			/// <summary>
			/// Inserts a new item into the double linked chain behind "this"
			/// </summary>
			public void InsertAfter(ParseItem i_Item)
			{
				i_Item.mi_Prev = this;
				i_Item.mi_Next = this.mi_Next;
				if (mi_Next != null)
					mi_Next.mi_Prev = i_Item;
				mi_Next = i_Item;
			}

			/// <summary>
			/// Inserts a new item into the double linked chain before "this"
			/// </summary>
			public void InsertBefore(ParseItem i_Item)
			{
				i_Item.mi_Next = this;
				i_Item.mi_Prev = this.mi_Prev;
				if (mi_Prev != null)
					mi_Prev.mi_Next = i_Item;
				mi_Prev = i_Item;
			}

			/// <summary>
			/// Controls the count of linebreaks before an item
			/// These linebreaks are permananet and cannot be deleted by clean-up operations
			/// It is allowed that i_Item may be null !
			/// </summary>
			static public void SetLinebreakBefore(ParseItem i_Item, int s32_Count)
			{
				if (i_Item == null || i_Item.Prev == null) // Don't insert linebreaks before the first item
					return;

				if (!i_Item.mi_Parser.mb_ModifyLineBR)
					return;

				// Assure at least s32_Count Linebreaks which are permanent
				for (int i=0; i<s32_Count; i++)
				{
					if (getType(i_Item.Prev) != eType.LineBreak)
						i_Item.InsertBefore(new ParseItem(i_Item.mi_Parser, "\n"));

					i_Item = i_Item.Prev;
					i_Item.Permanent = true;
				}
			}

			/// <summary>
			/// Controls the count of linebreaks after an item
			/// These linebreaks are permananet and cannot be deleted by clean-up operations
			/// It is allowed that i_Item may be null !
			/// </summary>
			static public void SetLinebreakAfter(ParseItem i_Item, int s32_Count)
			{
				if (i_Item == null || i_Item.Next == null) // Don't insert linebreaks after the last item
					return;

				if (!i_Item.mi_Parser.mb_ModifyLineBR)
					return;

				// Assure at least s32_Count Linebreaks which are permanent
				for (int i=0; i<s32_Count; i++)
				{
					if (getType(i_Item.Next) != eType.LineBreak)
						i_Item.InsertAfter(new ParseItem(i_Item.mi_Parser, "\n"));

					i_Item = i_Item.Next;
					i_Item.Permanent = true;
				}
			}

			/// <summary>
			/// returns the item before "this" which is not a linebreak
			/// </summary>
			public ParseItem FindBeforeLF()
			{
				ParseItem i_Prev = this.Prev;
				while (getType(i_Prev) == eType.LineBreak)
				{
					i_Prev = i_Prev.Prev;
				}
				return i_Prev;
			}

			public ParseItem FindAfterLF()
			{
				ParseItem i_Next = this.Next;
				while (getType(i_Next) == eType.LineBreak)
				{
					i_Next = i_Next.Next;
				}
				return i_Next;
			}

			public eIndent Indent
			{
				get { return me_Indent; }
				set
				{
					// set only to higher values
					if ((int)value > (int)me_Indent)
					{
						me_Indent = value;
						if ((int)value >= (int)eIndent.SingleLF)
							SetLinebreakBefore(this, 1);

						if ((int)value == (int)eIndent.DoubleLF)
							SetLinebreakAfter(this, 1);
					}
				}
			}
			public eIndent Outdent
			{
				get { return me_Outdent; }
				set
				{
					// set only to higher values
					if ((int)value > (int)me_Outdent)
					{
						me_Outdent = value;
						if ((int)value >= (int)eIndent.SingleLF)
							SetLinebreakAfter(this, 1);

						if ((int)value == (int)eIndent.DoubleLF)
							SetLinebreakBefore(this, 1);
					}
				}
			}

			public void GetText(RtfHtmlBuilder i_Builder)
			{
				if (me_Outdent != eIndent.Normal) 
					i_Builder.SelectionIndent--;

				if (mi_Colors[me_Type] != null)
					i_Builder.SelectionColor = (Color)mi_Colors[me_Type];
				else
					i_Builder.SelectionColor = Color.Black;

				// Add text
				i_Builder.AppendText(ms_Text);

				// Append space behind all items except Linebreak and LineComment
				if (mb_AppendSpace)
					i_Builder.AppendText(" ");

				if (me_Indent != eIndent.Normal)
					i_Builder.SelectionIndent++;
			}

			/// <summary>
			/// Adds an object to the list of contained objects in this item.
			/// Used for parenthesis items. If a parenthesis contains a comma
			/// the Parenthesis Parser adds a comma to the contains list.
			/// </summary>
			public void SetContains(object o_Obj)
			{
				if (mi_Contains == null)
					mi_Contains = new ArrayList();

				if (!mi_Contains.Contains(o_Obj))
					 mi_Contains.Add(o_Obj);
			}
			public bool Contains(object o_Obj)
			{
				return (mi_Contains != null && mi_Contains.Contains(o_Obj));
			}
		}

		#endregion // class ParseItem

		protected RtfHtmlBuilder  mi_RtfHtmlBuilder = new RtfHtmlBuilder();
		protected ParseItem       mi_FirstItem      = null;
		protected int           ms32_CursorPos      = 0;
		protected bool            mb_CursorStored   = false;
		protected bool            mb_ModifyLineBR   = false;
		protected bool            mb_Abort          = false;

		/// <summary>
		/// Allows to abort a lengthy parsing from another thread
		/// </summary>
		public void Abort()
		{
			mb_Abort = true;
		}

		/// <summary>
		/// This function can be called multiple times re-using an existing Parser instance
		/// b_ModifyLinebreaks = false --> leave linebreaks and indentation unchanged
		/// s32_CursorPos is modified if necessary. When calling it contains the current cursor position
		/// On return it contains the cursor position adapted to the modified RTF content
		/// </summary>
		public bool Parse(string s_SQL, bool b_ModifyLinebreaks, bool b_Append_LF)
		{
			int s32_Dummy = 0;
			return Parse(s_SQL, b_ModifyLinebreaks, b_Append_LF, ref s32_Dummy);
		}
		public bool Parse(string s_SQL, bool b_ModifyLinebreaks, bool b_Append_LF, ref int s32_CursorPos)
		{
			mb_Abort        = false;
			mb_CursorStored = false;
			ms32_CursorPos  = s32_CursorPos;
			mb_ModifyLineBR = b_ModifyLinebreaks;

			if (s_SQL == null) s_SQL = "";

			Functions.PrintDebug("-------------- Start Parsing ---------------", typeof(Parser));

			if (b_Append_LF && !s_SQL.EndsWith("\n\n")) 
				s_SQL += "\n\n"; // Assure that after the last line typing is possible
			else
				s_SQL += "  ";    // IMPORTANT: delimiter ALWAYS required

			ParseText(s_SQL);

			ParseParenthesis();

			ParseItem i_Item = mi_FirstItem;
			ParseCommands(ref i_Item);

			if (mb_ModifyLineBR)
				ParseLineBreaks();

			FillRtfBuilder();

			// return the modified cursor position
			s32_CursorPos = ms32_CursorPos;

			return !mb_Abort;
		}

		/// <summary>
		/// Prevents a crash if i_Item = null
		/// </summary>
		static protected eType getType(ParseItem i_Item)
		{
			if (i_Item == null) return eType.Invalid;
			else                return i_Item.Type;
		}
		/// <summary>
		/// Prevents a crash if i_Item = null
		/// </summary>
		static protected eCmd getCmd(ParseItem i_Item)
		{
			if (i_Item == null) return eCmd.Undefined;
			else                return i_Item.Cmd;
		}
		/// <summary>
		/// Prevents a crash if i_Item = null
		/// </summary>
		static protected string getDebug(ParseItem i_Item)
		{
			if (i_Item == null) return "[NULL]";
			return "'" + i_Item.Text.Replace("\n", "\\n") + "'";
		}

		/// <summary>
		/// Count the plain SQL characters from the start item up to the end item
		/// Both items must exist!
		/// If an optional stringbuilder is passed it receives the SQL code
		/// </summary>
		static protected int MeasureLength(ParseItem i_ItemStart, ParseItem i_ItemEnd, StringBuilder s_Sql)
		{
			int Len = 0;
			do
			{
				if (s_Sql != null) 
				{
					s_Sql.Append(i_ItemStart.Text);
					s_Sql.Append(" ");
				}

				Len += i_ItemStart.Text.Length + 1;
				i_ItemStart = i_ItemStart.Next;
			}
			while (!i_ItemStart.Equals(i_ItemEnd));
			return Len;
		}

		/// <summary>
		/// Create double linked chain (mi_FirstItem....)
		/// </summary>
		private void ParseText(string s_SQL)
		{
			const string DELIM  = "!=<> +-*/,()'\n[";
			const string COMPAR = "!=<>*";

			s_SQL = s_SQL.Replace("\r", "").Replace("\t", " ");

			         mi_FirstItem = null;
			ParseItem i_LastItem  = null;
			int s32_Len   = s_SQL.Length;
			int s32_Start = -1;

			for (int s32_Pos=0; s32_Pos<s32_Len; s32_Pos++)
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				char Chr = s_SQL[s32_Pos];

				if (DELIM.IndexOf(Chr) >= 0)
				{
					// Avoid that the asterisk in "SELECT table.* FROM ..." gets separated
					if (Chr == '*' && s32_Pos > 0 && s_SQL[s32_Pos-1] == '.')
						continue;

					if (s32_Start >= 0)
					{
						AddItem(ref s_SQL, ref s32_Start, s32_Pos, ref i_LastItem);
						// read the delimter again in the next parser instance
						if (Chr != ' ') s32_Pos--;
						continue;
					}

					if (Chr == ' ')  // ignore Space
						continue;

					s32_Start = s32_Pos;

					if (COMPAR.IndexOf(Chr) >= 0) // Operators "<=", "<>", ">=", "!<", "!>" , "!=", "=*"
					{
						while (COMPAR.IndexOf(s_SQL[s32_Pos+1]) >= 0)
							s32_Pos ++;
					}
					// N'String' will be corrected later !!!
					else if (Chr == '\'') // read whole 'String'
					{
						while (s32_Pos+1 < s32_Len)
						{
							s32_Pos ++;
							if (s_SQL[s32_Pos] == '\'')
							{
								// a double '' is an escaped apostroph
								if (s_SQL[s32_Pos+1] == '\'') s32_Pos ++;
								else break;
							}
						}
					}
					else if (Chr == '[') // read whole "[Column Name]" string
					{
						while (true)
						{
							while (s32_Pos+1 < s32_Len && s_SQL[s32_Pos+1] != ']' && s_SQL[s32_Pos+1] != '\n')
								s32_Pos ++;

							s32_Pos ++;

							int s32_Test = s32_Pos;
							while (s32_Test+2 < s32_Len && (s_SQL[s32_Test+1] == '.' || s_SQL[s32_Test+1] == ' '))
								s32_Test ++;

							s32_Test ++;
							if (s32_Test >= s32_Len || s_SQL[s32_Test] != '[')
								break;

							// found "[Dbase] . [Function]"
							s32_Pos = s32_Test +2;
						}
					}
					else if (Chr == '-' && s_SQL[s32_Pos+1] == '-') //     -- Comment
					{
						while (s32_Pos+1 < s32_Len && s_SQL[s32_Pos+1] != '\n')
							s32_Pos ++;
					}
					else if (Chr == '/' && s_SQL[s32_Pos+1] == '*') //     /* Comment */
					{
						while (s32_Pos+2 < s32_Len && (s_SQL[s32_Pos+1] != '*' || s_SQL[s32_Pos+2] != '/'))
							s32_Pos ++;

						s32_Pos +=2;
					}
					else if (Chr == '*' && s_SQL[s32_Pos+1] == '/') // There is a "end of comment" with a missing "start of comment"
					{
						s32_Pos ++; // Never split "*/" into "* /"
					}

					AddItem(ref s_SQL, ref s32_Start, s32_Pos+1, ref i_LastItem);
					continue;
				}

				if (s32_Start < 0) // not a delimter
					s32_Start = s32_Pos;
			}
		}

		/// <summary>
		/// Add a command, keyword, operator, etc to the tag list
		/// </summary>
		private void AddItem(ref string s_SQL, ref int s32_Start, int s32_End, ref ParseItem i_LastItem)
		{
			int  s32_Last = Math.Min (s32_End, s_SQL.Length);
			string s_Text = s_SQL.Substring(s32_Start, s32_Last -s32_Start);
			ParseItem i_Item = new ParseItem(this, s_Text);

			if (i_Item.Type != eType.Invalid)
			{
				if (mi_FirstItem == null)
					mi_FirstItem = i_Item;
				else
					i_LastItem.InsertAfter(i_Item);

				i_LastItem = i_Item;

				if (!mb_CursorStored && ms32_CursorPos <= s32_End)
				{
					mb_CursorStored = true;
					i_Item.CursorPos = Math.Max(0, ms32_CursorPos - s32_Start);
				
					Functions.PrintDebug("AddItem() set CursorPos={0} in Item      {1} <{2}> ...", i_Item.CursorPos, getDebug(i_Item.Prev), getDebug(i_Item), typeof(Parser));
				}
			}

			s32_Start = -1;
		}

		// ########################################################################################

		/// <summary>
		/// Set indentation inside parenthesis
		/// </summary>
		private void ParseParenthesis()
		{
			StackEx i_ParenthStack = new StackEx();

			for (ParseItem i_Item=mi_FirstItem; i_Item!=null; i_Item=i_Item.Next)
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				switch (i_Item.Type)
				{
					case eType.ParOpen:
						i_ParenthStack.Push(i_Item);
						break;

					case eType.ParClose:
						ParseItem i_Pop = (ParseItem)i_ParenthStack.Pop();
						if (i_Pop != null) 
						{
							// revert indentation
							i_Item.Outdent = i_Pop.Indent;
						}
						break;

					case eType.LineBreak:
						// Indent all parenthesis which have a linebreak inside
						for (int i=0; i<i_ParenthStack.Count; i++)
						{
							((ParseItem)i_ParenthStack[i]).Indent = eIndent.SingleLF;
						}
						break;

					case eType.Comma:
						// Store in the last parenthesis-open that this parenthesis contains a comma
						ParseItem i_Peek = (ParseItem)i_ParenthStack.Peek();
						if (i_Peek != null)
						{
							i_Peek.SetContains(eType.Comma);
						}
						break;

						// make linebreaks before Line Comments permamanet
					case eType.CommentL:
						if (getType(i_Item.Prev) == eType.LineBreak)
							i_Item.Prev.Permanent = true;

						// Insert permanent linebreak after Line Comment, if not exists
						ParseItem.SetLinebreakAfter(i_Item, 1);
						break;

						// make up to two linebreaks before Paragraph Comments permamanet
					case eType.CommentP:
						if (getType(i_Item.Prev) == eType.LineBreak)
						{
							i_Item.Prev.Permanent = true;

							if (getType(i_Item.Prev.Prev) == eType.LineBreak)
								i_Item.Prev.Prev.Permanent = true;
						}
						break;

						// convert Item(N) + Item('String') ---> Item(N'String')
					case eType.String:
						if (getType(i_Item.Prev) == eType.Unknown)
						{
							if (i_Item.Prev.Text.ToUpper() == "N")
							{
								i_Item.Prev.Remove(true);
								i_Item.Text = "N" + i_Item.Text;
							}
						}
						break;
				}

				switch (i_Item.Cmd)
				{
					// If a parenthesis contains one of the commands SELECT, AND, OR 
					// the parenthesis is displayed on an own line
					// and all enclosing parentehsis are broken on multiple lines
					case eCmd.Select:
					case eCmd.Case:
						for (int i=0; i<i_ParenthStack.Count; i++)
						{
							((ParseItem)i_ParenthStack[i]).Indent = eIndent.DoubleLF;
						}
						break;

					case eCmd.AndOr:
						for (int i=0; i<i_ParenthStack.Count-1; i++)
						{
							((ParseItem)i_ParenthStack[i]).Indent = eIndent.DoubleLF;
						}
						if (i_ParenthStack.Count > 0)
							((ParseItem)i_ParenthStack[i_ParenthStack.Count-1]).Indent = eIndent.SingleLF;
						break;

						// "LEFT JOIN" = Keyword or "left(string, count)" = Function ?
					case eCmd.Left:
					case eCmd.Right:
						if (getType(i_Item.Next) == eType.ParOpen)
							i_Item.Type = eType.Function;
						break;

						// "ALTER COLUMN" is not a command but just a Keyword inside "ALTER TABLE"
					case eCmd.Alter:
						if (getCmd(i_Item.Next) == eCmd.Column)
							i_Item.Type = eType.Keyword;
						break;
				}
			}
		}

		/// <summary>
		/// This parser is called recursively with every parenthesis
		/// </summary>
		private void ParseCommands(ref ParseItem i_Item)
		{
			while (i_Item != null)
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				switch (i_Item.Type)
				{
					case eType.ParOpen:
						i_Item = i_Item.Next;
						ParseCommands(ref i_Item);
						break;

					case eType.ParClose:
						// do not set Next here !!!!
						return;

					case eType.Keyword:
					case eType.Comand:
						switch (i_Item.Cmd)
						{
							case eCmd.Select:
								Parse_SELECT(ref i_Item);
								break;

							case eCmd.Create:
								Parse_CREATE(ref i_Item);
								break;

							// CASE may appear after a "("
							case eCmd.Case:
								Parse_CASE(ref i_Item);
								break;

							case eCmd.Begin:
								ParseItem  i_After = i_Item.FindAfterLF();
								if (getCmd(i_After) != eCmd.Distributed && 
									getCmd(i_After) != eCmd.Transaction)
										i_Item.Indent = eIndent.DoubleLF;
								break;

							case eCmd.End:
								i_Item.Outdent = eIndent.DoubleLF;
								break;

							case eCmd.Else:
								ParseItem.SetLinebreakBefore(i_Item, 1);
								break;

							case eCmd.Exec:
								ParseItem.SetLinebreakBefore(i_Item, 2);
								break;
						}
						break;
				}
				if (i_Item == null)
					break;

				i_Item = i_Item.Next;
			};
		}

		private void Parse_SELECT(ref ParseItem i_Item)
		{
			ParseItem i_SELECT    = i_Item;
			ParseItem i_INTO      = null;
			ParseItem i_FROM      = null;
			ParseItem i_WHERE     = null;
			ParseItem i_GROUP     = null;
			ParseItem i_HAVING    = null;
			ParseItem i_ORDER     = null;
			ParseItem i_UNION     = null;
			ParseItem i_FOR       = null;
			ParseItem i_OPTION    = null;
			ParseItem i_COMPUTE   = null;
			ParseItem i_CASE      = null;
			ParseItem i_NextCmd   = null; // The command after SELECT

			ArrayList i_Columns   = new ArrayList(); // comma list after SELECT
			ArrayList i_Tables    = new ArrayList(); // comma list after FROM
			ArrayList i_Groups    = new ArrayList(); // comma list after GROUP BY
			ArrayList i_Joins     = new ArrayList(); // JOIN commands
			ArrayList i_AndOrs    = new ArrayList(); // AND / OR / ON commands

			// Collect user linebreaks for current subsection.
			// These are not removed if a subsection is very long.
			ArrayList i_SectBreaks = new ArrayList();
			ParseItem i_SectStart  = i_Item;

			// Loop until next command or "("
			bool b_StopParsing = false;
			while (i_Item != null && i_Item.Next != null && !b_StopParsing)
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				i_Item = i_Item.Next;

				bool b_StopCollecting = false;
				switch (i_Item.Type)
				{
					case eType.ParOpen:
						i_Item = i_Item.Next;
						ParseCommands(ref i_Item); // recursion
						break;

					case eType.Comand:
					case eType.ParClose: // finish parsing on ")" or next command
						i_NextCmd = i_Item;
						i_Item    = i_Item.Prev;
						b_StopParsing = true;
						break;

					case eType.Comma:
						b_StopCollecting = true;
						     if (i_FROM  == null) i_Columns.Add(i_Item);
						else if (i_GROUP == null) i_Tables. Add(i_Item);
						else                      i_Groups. Add(i_Item);
						break;

					// Store linebreaks in ArrayList for later deletion
					case eType.LineBreak:
						i_SectBreaks.Add(i_Item);
						break;

					case eType.Keyword:
						b_StopCollecting = true;
						switch (i_Item.Cmd)
						{
							case eCmd.AndOr:  i_AndOrs.Add(i_Item); break;
							case eCmd.From:   i_FROM    =  i_Item;  break;
							case eCmd.Group:  i_GROUP   =  i_Item;  break;
							case eCmd.Having: i_HAVING  =  i_Item;  break;
							case eCmd.Into:   i_INTO    =  i_Item;  break;
							case eCmd.Join:   i_Joins. Add(i_Item); break;
							case eCmd.Order:  i_ORDER   =  i_Item;  break;
							case eCmd.Union:  i_UNION   =  i_Item;  break;
							case eCmd.Where:  i_WHERE   =  i_Item;  break;

							case eCmd.Case:
								i_CASE = i_Item;
								Parse_CASE(ref i_Item); 
								break;
						}
						break;
				}

				// User linebreaks inside a long calculation for a column will not be removed:
				// "isnull(tbl.value1, 'no data') + ',' + 
				//  isnull(tbl.value2, 'no data') + ',' + 
				//  isnull(tbl.value3, 'no data') + ',' + 
				//  isnull(tbl.value4, 'no data') AS ComputedValue,"
				if (b_StopCollecting)
				{
					if (MeasureLength(i_SectStart, i_Item, null) < 150)
					{
						foreach (ParseItem i_BR in i_SectBreaks)
						{
							// Remove linebreaks which the user has put into the SQL code.
							// Linebreaks set in ParseParenthesis() are permanent and will not be deleted here!
							i_BR.Remove(false);
						}
					}
					i_SectStart = i_Item;
					i_SectBreaks.Clear();
				}
			}

			ParseItem.SetLinebreakBefore(i_NextCmd, 2);

			InsertCommas(i_SELECT, i_Columns, i_FROM);
			InsertCommas(i_FROM,   i_Tables,  i_WHERE);
			InsertCommas(i_GROUP,  i_Groups,  null);

			ParseItem.SetLinebreakBefore(i_SELECT,  1);
			ParseItem.SetLinebreakBefore(i_INTO,    1);
			ParseItem.SetLinebreakBefore(i_GROUP,   1);
			ParseItem.SetLinebreakBefore(i_HAVING,  1);
			ParseItem.SetLinebreakBefore(i_ORDER,   1);
			ParseItem.SetLinebreakBefore(i_UNION,   1);
			ParseItem.SetLinebreakBefore(i_FOR,     1);
			ParseItem.SetLinebreakBefore(i_OPTION,  1);
			ParseItem.SetLinebreakBefore(i_COMPUTE, 1);

			for (int i=0; i<i_Joins.Count; i++)
			{
				ParseItem i_Join = (ParseItem)i_Joins[i];
				while (getType(i_Join.Prev) == eType.Keyword) // skip "LEFT OUTER"
					  i_Join = i_Join.Prev;

				ParseItem.SetLinebreakBefore(i_Join, 1);
			}

			if (i_AndOrs.Count >= 1)
			{
				ParseItem.SetLinebreakBefore(i_WHERE, 1);

				foreach (ParseItem i_AndOr in i_AndOrs)
				{
					ParseItem.SetLinebreakBefore(i_AndOr, 1);
					if (getType(i_AndOr.Next) == eType.ParOpen)
						ParseItem.SetLinebreakAfter(i_AndOr, 1);
				}
			}
		}

		private void Parse_CASE(ref ParseItem i_Item)
		{
			i_Item.Indent = eIndent.SingleLF;

			while (i_Item != null && i_Item.Next != null)
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				i_Item = i_Item.Next;

				switch (i_Item.Type)
				{
					// remove linebreaks which the user has put into the SQL code.
					// Linebreaks set in ParseParenthesis() are permanent and will not be deleted here!
					case eType.LineBreak:
						i_Item.Remove(false);
						break;

					case eType.ParOpen:
						i_Item = i_Item.Next;
						ParseCommands(ref i_Item);
						break;

					case eType.ParClose: // finish parsing on ")"
						i_Item = i_Item.Prev;
						return;

					case eType.Comand:
					case eType.Keyword:
						switch (i_Item.Cmd)
						{
							case eCmd.When:
								ParseItem.SetLinebreakBefore(i_Item, 1);
								break;

							// ELSE and END are commands in the IF command.
							// Here they are keywords as part of the SELECT command
							case eCmd.Else:
								i_Item.Type = eType.Keyword;
								ParseItem.SetLinebreakBefore(i_Item, 1);
								break;

							case eCmd.End:
								i_Item.Type = eType.Keyword;
								i_Item.Outdent = eIndent.DoubleLF;
								return;
						}
						break;
				}
			}
		}

		/// <summary>
		/// parses ( Variable list ) in CREATE FUNCTION, CREATE VIEW, CREATE PROCEDURE, CREATE TRIGGER 
		/// adds a newline for each comma in 
		/// CREATE PROC name (@variable, @variable)
		/// </summary>
		private void Parse_CREATE(ref ParseItem i_Item)
		{
			i_Item = i_Item.Next;
			switch (getCmd(i_Item))
			{
				case eCmd.Function:
				case eCmd.Procedure:
				case eCmd.Trigger:
				case eCmd.View:
					break;
				default:
					return; // CREATE command not supported (e.g. CREATE DATABASE)
			}

			i_Item = i_Item.Next;
			if (getType(i_Item) != eType.Unknown)
				return; // name of procedure, function,... is missing

			// Set linebreak after name
			ParseItem.SetLinebreakAfter(i_Item, 1);

			// indent only the outermost parenthesis (not "varchar(128)") if it contains a comma
			int s32_Parenth  = 0;
			bool  b_Indented = false;
			bool  b_RemoveLF = true;
			do
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				i_Item = i_Item.Next;
				switch (getType(i_Item))
				{
					case eType.ParOpen:
						if (s32_Parenth == 0)
						{
							if (i_Item.Contains(eType.Comma)) // ( .. , .. , .. ) 
							{
								i_Item.Indent = eIndent.DoubleLF;
								b_Indented = true;
							}
						}
						s32_Parenth++;
						break;

					case eType.ParClose:
						s32_Parenth--;
						if (b_Indented && s32_Parenth == 0) 
						{
							i_Item.Outdent = eIndent.DoubleLF;
							b_Indented = false;
						}
						break;

					case eType.LineBreak:
						if (b_RemoveLF)
							i_Item.Remove(false); // remove user linebreaks
						break;

					case eType.Comma: // newline for each comma in CREATE (@variable, @variable)
						if (getType(i_Item.Next) != eType.CommentL)
							ParseItem.SetLinebreakAfter(i_Item, 1); 
						break;

					case eType.Keyword:
						switch (i_Item.Cmd)
						{
							case eCmd.As:
								if (s32_Parenth == 0) // ignore AS inside parenthesis
								{
									ParseItem.SetLinebreakBefore(i_Item, 1);
									return; // stop parsing here
								}
								break;

							case eCmd.On: // Trigger
								ParseItem.SetLinebreakBefore(i_Item, 1);
								b_RemoveLF = false; // no further linebreak parsing for triggers
								break;

							case eCmd.Returns: // Function
								ParseItem.SetLinebreakBefore(i_Item, 1);
								break;
						}
						break;

					case eType.Comand:
						switch (i_Item.Cmd)
						{
							// in a Trigger these words are keywords and not commands
							case eCmd.Delete:
							case eCmd.Insert:
							case eCmd.Update:
								i_Item.Type = eType.Keyword;
								break;
						}
						break;
				}
			}
			while (i_Item != null);
		}

		/// <summary>
		/// Insert Linebreaks after commas in a comma sepated list 
		/// and before the preceeding and following keyword
		/// (e.g. SELECT Column_1, Column_2, Column_3 FROM)
		/// with i_KeyBefore = SELECT, i_KeyAfter = FROM
		/// Do not break up the command onto multiple lines if there is no comma
		/// Used for SELECT, FROM, GROUP
		/// </summary>
		private void InsertCommas(ParseItem i_KeyBefore, ArrayList i_Commas, ParseItem i_KeyAfter)
		{
			if (i_Commas.Count == 0)
				return;
			
			foreach (ParseItem i_Comma in i_Commas)
			{
				ParseItem.SetLinebreakAfter(i_Comma, 1);
			}

			if (i_KeyBefore != null)
			{
				// Insert Linebreak before first comma separated item
				ParseItem i_Item = i_KeyBefore.Next;
				// Example SELECT: skip "TOP 10 PERCENT ALL DISTINCT WITH TIES"
				// But skip nothing in in "SELECT 0 AS ColName"
				// Skip "BY" in GROUP BY
				while (getType(i_Item) == eType.Keyword)
				{
					if (getCmd(i_Item) == eCmd.Top && getType(i_Item.Next) == eType.Number)
						i_Item = i_Item.Next;  // skip the number in TOP 10

					i_Item = i_Item.Next;
				}

				// Example SELECT: insert Linebreak before first column name
				ParseItem.SetLinebreakBefore(i_Item, 1);
			}

			// Example SELECT: insert Linebreak before FROM
			ParseItem.SetLinebreakBefore(i_KeyAfter, 1);
		}

		private void ParseLineBreaks()
		{
			ParseItem i_Item  = null;
			ParseItem i_Prev  = null;
			ParseItem i_Prev2 = null;

			for (i_Item=mi_FirstItem; i_Item!=null; i_Item=i_Item.Next)
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				if (i_Prev != null && i_Prev2 != null)
				{
					switch (i_Item.Type)
					{
						// remove linebreaks before operators e.g. "(xxx) \n < 0"
						case eType.Operator:
							if (i_Prev.Type == eType.LineBreak)
								i_Prev.Remove(true);
							break;
					
						// remove linebreak between "If" and "("
						case eType.ParOpen:
							if (i_Prev.Type == eType.LineBreak && i_Prev2.Cmd == eCmd.If)
								i_Prev.Remove(true);
							break;

						// remove triple and more-tiple linebreaks
						case eType.LineBreak:
						// remove double linebreaks before ")"
						case eType.ParClose:
							if (i_Prev.Type == eType.LineBreak && i_Prev2.Type == eType.LineBreak)
								i_Prev.Remove(true);
							break;

						// remove linebreaks between ")" and ","
						case eType.Comma:
							if (i_Prev.Type == eType.LineBreak && i_Prev2.Type == eType.ParClose)
								i_Prev.Remove(true);
							break;
					}

					switch (i_Item.Cmd)
					{
						// remove all linebreaks before "(DISTRIBUTED) TRANSACTION"
						case eCmd.Transaction:
						case eCmd.Distributed:
							while (getType(i_Item.Prev) == eType.LineBreak)
							{
								i_Item.Prev.Remove(true);
							}
							break;

						// Remove linebreak in "... BETWEEN Value1 \nAND Value2 ..."
						case eCmd.Between:
							ParseItem i_Next = i_Item.Next;
							for (int i=0; i<5 && i_Next!=null; i++)
							{
								if (getType(i_Next) == eType.LineBreak && getCmd(i_Next.Next) == eCmd.AndOr)
								{
									i_Next.Remove(true);
									break;
								}
								i_Next = i_Next.Next;
							}
							break;
					}

					switch (i_Prev2.Type)
					{
						// remove double linebreaks after "("
						case eType.ParOpen:
							if (i_Prev.Type == eType.LineBreak && i_Item.Type == eType.LineBreak)
								i_Prev.Remove(true);
							break;
					}
				}
				i_Prev2 = i_Prev;
				i_Prev  = i_Item;
			}
		}

		private void FillRtfBuilder()
		{
			mi_RtfHtmlBuilder.Clear();
			for (ParseItem i_Item=mi_FirstItem; i_Item!=null; i_Item=i_Item.Next)
			{
				Application.DoEvents();
				if (mb_Abort)
					return;

				if (i_Item.CursorPos > -1)
				{
					ms32_CursorPos = mi_RtfHtmlBuilder.RtfPosition + i_Item.CursorPos;
					Functions.PrintDebug("FillRtf() get CursorPos={0} from Item    {1} <{2}> {3}", i_Item.CursorPos, getDebug(i_Item.Prev), getDebug(i_Item), getDebug(i_Item.Next), typeof(Parser));
				}

				i_Item.GetText(mi_RtfHtmlBuilder);
			}
		}

		// ########################################################################################

		public string SQL
		{
			get { return mi_RtfHtmlBuilder.GetText(); }
		}

		public string HTML
		{
			get { return mi_RtfHtmlBuilder.GetHtml(); }
		}

		public string GetRtf(Font i_Font)
		{
			return mi_RtfHtmlBuilder.BuildRtf(i_Font);
		}

		/// <summary>
		/// checks for example for existence of "CREATE FUNCTION fn_Name"
		/// if s_Obj = "FUNCTION" and s_Name = "fn_Name"
		/// returns the SQL text with "CREATE" replaced by "ALTER" on success
		/// or null on error
		/// </summary>
		public string AlterCreateCommand(string s_Obj, string s_Name)
		{
			ParseItem i_Cmd  = null;
			ParseItem i_Obj  = null;
			ParseItem i_Name = null;

			for (ParseItem i_Item=mi_FirstItem; i_Item!=null; i_Item=i_Item.Next)
			{
				if (i_Item.Type == eType.CommentL ||
					i_Item.Type == eType.CommentP ||
					i_Item.Type == eType.LineBreak)
					continue;

				     if (i_Cmd  == null)  i_Cmd  = i_Item;
				else if (i_Obj  == null)  i_Obj  = i_Item;
				else if (i_Name == null){ i_Name = i_Item; break; }
			}

			if (getType(i_Cmd) != eType.Comand || getCmd(i_Cmd) != eCmd.Create)
				return null;

			if (getType(i_Obj) != eType.Keyword || i_Obj.Text != s_Obj.ToUpper())
				return null;

			if (getType(i_Name) != eType.Unknown)
				return null;

			// i_Name.Item = "[DBase].[fn_Name]"
			string[] s_ObjParts = i_Name.Text.Split('.');
			string   s_ObjName  = s_ObjParts[s_ObjParts.Length -1];
			s_ObjName = s_ObjName.Replace("[", "").Replace("]", "");

			if (string.Compare(s_ObjName.Trim(), s_Name, true) != 0)
				return null;

			i_Cmd.Text = "ALTER";
			FillRtfBuilder();
			string s_SQL = this.SQL;
			
			i_Cmd.Text = "CREATE"; // restore origional item
			FillRtfBuilder();
			
			return s_SQL;
		}
	}
}
