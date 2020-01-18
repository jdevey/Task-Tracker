using System;
using System.Collections;

namespace TaskTracker
{
	public static class Printing
	{
		public static string padValue(long value)
		{
			string valueString = value.ToString();
			return valueString.Length >= Constants.MAX_VALUE_WIDTH
				? valueString
				: new string(' ', Constants.MAX_VALUE_WIDTH - valueString.Length) + valueString;
		}

		public static string makeMedium(string s)
		{
			return "--- " + s + " ---";
		}

		public static string makeLarge(string s)
		{
			return "===== " + s + " =====";
		}

		public static void printList(ArrayList a)
		{
			for (int i = 0; i < a.Count; ++i)
			{
				Console.WriteLine((i + 1).ToString() + ") " + a[i].ToString());
			}
		}
		
		public static void printWelcome()
		{
			Console.WriteLine(makeLarge("Welcome to Task Tracker!"));
			Console.WriteLine();
		}

		// TODO print all menus
		public static void printControls()
		{
			
		}
		
		public static void printMainMenu()
		{
			
		}
	}
}