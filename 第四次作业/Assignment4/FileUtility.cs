using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
	public static class FileUtility
	{
		public static string FormatFileSize(long size)
		{
			string[] units = { "B", "KB", "MB", "GB", "TB" };
			int unitIndex = 0;
			double fileSize = size;

			while (fileSize >= 1024 && unitIndex < units.Length - 1)
			{
				fileSize /= 1024;
				unitIndex++;
			}

			// 在整数部分少于3位时，只保留3位有效数字
			if (fileSize >= 100)
			{
				return $"{fileSize:0} {units[unitIndex]}";
			}
			else
			{
				return $"{fileSize:G3} {units[unitIndex]}";
			}
		}
	}
}
