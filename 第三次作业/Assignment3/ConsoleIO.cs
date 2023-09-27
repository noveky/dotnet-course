using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
	static class ConsoleIO
	{
		public static void Print(string? text = null, ConsoleColor? color = null)
		{
			if (color != null)
			{
				Console.ForegroundColor = (ConsoleColor)color;
			}
			Console.Write(text);
			Console.ResetColor();
		}

		public static void PrintLn(string? text = null, ConsoleColor? color = null) => Print($"{text}\n", color);

		public static void LogError(Exception ex) => PrintLn(ex.Message, ConsoleColor.Red);
	}
}
