using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment3
{
	partial class CodeProcessor
	{
		public const string SampleCode = """
			using System; // 123456
			using System.Collections.Generic; // 234567
			using System.Linq;
			using System.Text;
			using System.Threading.Tasks;
			//using System.IO;

			/*
			 * abcDEFGhiJKL
			 * AbcDefGHIJkl
			 * 0xBCD8AB95
			 * 1Aaa1 2aAa2 3aaA3
			 */

			namespace FTPClient
			{
				public static class FileSystem
				{
					public static string GetSizeStr(long size)
					{
						string[] units = { "B", "KB", "MB", "GB", "TB" };
						int unitIndex = 0;
						double fileSize = size;

						while (fileSize >= 0x400 && unitIndex < units.Length - 1)
						{
							fileSize /= 0x400;
							unitIndex++;
						}

						// 在整数部分少于3位时，只保留3位有效数字
						return fileSize >= 100 ? $"{fileSize:0} {units[unitIndex]}" : $"{fileSize:G3} {units[unitIndex]}";
					}

					// 为确保新文件名不会重复，若原文件名已存在，则在后面加一个(1)，如果仍然存在则括号内数字递增到不存在为止
					public static string GetUniqueNameLocalFile(string localFile)
					{
						string fileName = Path.GetFileNameWithoutExtension(localFile);
						string extension = Path.GetExtension(localFile);
						string newLocalFile = localFile;
						int count = 1;
						while (File.Exists(newLocalFile))
						{
							newLocalFile = Path.Combine(Path.GetDirectoryName(localFile) ?? "", $"{fileName} ({count}){extension}");
							++count;
						}
						return newLocalFile;
					}
				}
			}
			""";

		// 按要求格式化代码，即去掉空行和注释（仅考虑“//”开头的，且不考虑包含在字符串中等复杂情况）
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
					line = line[0..remPos];
				}
				if (line.Trim() != string.Empty)
				{
					builder.AppendLine(line);
				}
			}
			return builder.ToString();
		}

		// 获取匹配集中所有匹配位置和长度的列表
		public static List<(int Index, int Length)> GetMatchRanges(MatchCollection matches)
			=> matches
				.Select(m => (m.Index, m.Length))
				.ToList();

		// 正则表达式匹配英文单词
		[GeneratedRegex("((?<![0-9][A-Za-z]*)[A-Z]?[a-z]+)|((?<![0-9][A-Za-z]*)[A-Z]+(?![a-z]+))")]
		public static partial Regex WordRegex();
		static MatchCollection WordMatches(string code)
			=> WordRegex().Matches(code);

		// 对代码进行统计词频，降序排序，并转换为 (string, int) 列表表示
		public static List<(string Word, int Count)> GetWordCounts(string code)
			=> WordMatches(code)
				.Select(m => m.Value)
				//.GroupBy(w => w.ToList().All(char.IsUpper) ? w : w.ToLower())
				.GroupBy(w => w.ToLower())
				.Select(g => (g.Key, g.Count()))
				.OrderByDescending(g => g.Item2)
				.ToList();

		// 获取代码中所有单词位置和长度的列表
		public static List<(int Index, int Length)> GetWordRanges(string code)
			=> GetMatchRanges(WordMatches(code));
	}
}
