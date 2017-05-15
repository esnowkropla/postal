using System;
using System.Collections.Generic;

namespace TypeInfo
{
	public enum Builtins
	{
		Uninitialized,
		Tile,
		Conveyor,
		Parcel,
		Stand,
		sheet
	}

	#pragma warning disable 0660
	public struct Type
	#pragma warning restore 0660
	{
		int data;

		static List<string> intToStr;
		static Dictionary<string, int> strToInt;

		public static void Init()
		{
			intToStr = new List<string>(100);
			strToInt = new Dictionary<string, int>(100);

			string[] names = Enum.GetNames(typeof(Builtins));
			Builtins[] values = (Builtins[]) Enum.GetValues(typeof(Builtins));

			for (int i = 0; i < names.Length; i++)
			{
				intToStr.Add(names[i]);
				strToInt.Add(names[i], (int) values[i]);
			}
		}

		public Type(int x)
		{
			data = x;
		}

		public Type(string text)
		{
			data = StrToInt(text);
		}

		public override string ToString()
		{
			if (Enum.IsDefined(typeof(Builtins), data))
			{
				return ((Builtins)data).ToString();
			}
			else if (data < intToStr.Count)
			{
				return intToStr[data];
			}
			else
			{
				Logging.Error("Couldn't convert " + data + " to string!");
				return null;
			}
		}

		public override Int32 GetHashCode() { return data; }

		public static bool operator ==(Type a, Type b) { return a.data == b.data; }
		public static bool operator !=(Type a, Type b) { return a.data != b.data; }

		public static implicit operator int(Type type)
		{
			return (int) type;
		}

		public static implicit operator Type(Builtins builtin)
		{
			Type x;
			x.data = (int) builtin;
			return x;
		}

		public static implicit operator Type(string text)
		{
			Type x;
			x.data = StrToInt(text);
			return x;
		}

		public static implicit operator Type(int x)
		{
			Type t;
			t.data = x;
			return t;
		}

		public static int StrToInt(string text)
		{
			try
			{
				Builtins type = (Builtins) Enum.Parse(typeof(Builtins), text);
				Logging.Log("Added already existing enum \"" + text + "\" with id " + (int) type);
				return (int) type;
			}
			catch (ArgumentException)
			{
				if (strToInt.ContainsKey(text))
				{
					Logging.Log("Adding already existing string \"" + text + "\" with id " + strToInt[text]);
					return strToInt[text];
				}
				else
				{
					int id = intToStr.Count;
					intToStr.Add(text);
					strToInt.Add(text, id);
					Logging.Log("Added string \"" + text + "\" with id " + id);
					return id;
				}
			}
		}
	}
}
