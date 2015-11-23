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
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SqlBuilder
{
	/// <summary>
	/// This is a base class for serializable data objects to be stored in StackEx
	/// </summary>
	public class Serializable
	{
		public virtual string Serialize()
		{
			return null;
		}
		public virtual void Deserialize(string s_Serial)
		{
		}
	}

	/// <summary>
	/// Stupid .NET Stack class does not allow direct access on the elements on the stack
	/// </summary>
	public class StackEx : ArrayList
	{
		int ms32_Rotate = -1;

		/// <summary>
		/// If the object already exists -> remove it fisrt
		/// </summary>
		public void PushUnique(object o_Value)
		{
			Remove(o_Value);
			Push  (o_Value);
		}
		public void Push(object o_Value)
		{
			Add(o_Value);
			ms32_Rotate = this.Count -1;
		}
		public object Pop()
		{
			if (this.Count == 0)
				return null;

			object o_Value = this[Count-1];
			this.RemoveAt(Count-1);
			return o_Value;
		}
		public object Peek()
		{
			if (this.Count == 0)
				return null;

			return this[Count-1];
		}

		// ################## Rotation ################

		/// <summary>
		/// Abuses this stack to get the elements under the topmost element one by one.
		/// When the bottom is reached -> start again from the top of the stack.
		/// </summary>
		public object Rotate
		{
			get
			{
				if (ms32_Rotate < 0) 
					ms32_Rotate = Count-1;

				if (ms32_Rotate < 0)
					return null;

				return this[ms32_Rotate--];
			}
		}

		// ################## Serialization ################

		/// <summary>
		/// Only for stacks which store objects derived from Serializable
		/// </summary>
		public string Serialize(char c_Delimiter, int MaxCount)
		{
			string s_Serial = "";
			int Last  = Count - 1;
			int First = Math.Max(0, Last - MaxCount);

			for (int i=First; i<=Last; i++)
			{
				Serializable i_Value = (Serializable) this[i];
				if (i>First) s_Serial += c_Delimiter;
				s_Serial += i_Value.Serialize();
			}
			return s_Serial;
		}

		/// <summary>
		/// Only for stacks which store objects derived from Serializable
		/// </summary>
		public void DeSerialize(string s_Serial, Type t_ValueType, char c_Delimiter)
		{
			Clear();
			if (s_Serial.Length == 0)
				return;

			Type[] t_TypeArr = new Type[0];
			ConstructorInfo i_Const = t_ValueType.GetConstructor(t_TypeArr);

			string[] s_Parts = s_Serial.Split(c_Delimiter);
			foreach (string s_Part in s_Parts)
			{
				Serializable i_Value = (Serializable) i_Const.Invoke(null);
				i_Value.Deserialize(s_Part);
				Push(i_Value);
			}
		}
	}
}
