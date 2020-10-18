using System;
using System.Collections.Generic;

namespace MessageBoard.ConsoleUI
{
	public static class ConsoleLogger
	{
		public static void Log(List<string> stringList)
		{
			foreach (string s in stringList)
			{
				Console.WriteLine($"> {s.Trim()}");
			}
		}

		public static void Log(string s)
		{
			Console.WriteLine($"> {s.Trim()}");
		}
	}
}