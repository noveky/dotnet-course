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