﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment3
{
	static class CodeProcessor
	{
		public static string Format(string code)
		{
			string[] lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			StringBuilder builder = new();
			foreach (string l in lines)
			{
				string line = l;
				int remPos = line.IndexOf("//");
				if (remPos != -1)
				{
					line = line[0..remPos].Trim();
				}
				if (line != string.Empty)
				{
					builder.AppendLine(line);
				}
			}
			return builder.ToString();
		}

		public static List<KeyValuePair<string, int>> CountWords(string code)
		{
			return Regex.Matches(code, @"\b\w+\b")
						.Cast<Match>()
						.Select(m => m.Value)
						.GroupBy(w => w)
						.Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
						.OrderByDescending(g => g.Value)
						.ToList();
			string[] words = code.Split(new char[] { ' ', '\n', '\r', '\t', ',', ';', '+', '-', '*', '/', '=', '*', '%', '$', '#', '@', '!', '~', '.', '[', ']', '(', ')', '{', '}', '\\', '<', '>', '"', '\'', '^', '|' , '_' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			return words.GroupBy(w => w)
						 .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
						 .OrderByDescending(g => g.Value)
						 .ToList();
		}
	}
}
