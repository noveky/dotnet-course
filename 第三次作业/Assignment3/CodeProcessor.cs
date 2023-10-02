using System;
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
				if (line.Trim() != string.Empty)
				{
					builder.AppendLine(line);
				}
			}
			return builder.ToString();
		}

		public static List<KeyValuePair<string, int>> CountWords(string code)
			=> Regex.Matches(code, @"([A-Z]?[a-z]+\b)|([A-Z]+\b)|([A-Z]+(?=[A-Z][a-z]+))")
					.Select(m => m.Value)
					.GroupBy(w => w.ToList().All(char.IsUpper) ? w : w.ToLower())
					.Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
					.OrderByDescending(g => g.Value)
					.ToList();
	}
}
