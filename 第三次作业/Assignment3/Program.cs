using System.Reflection;

namespace Assignment3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.Title = "代码格式化与统计";

				string path = "Code.cs";
				string code = File.ReadAllText(path);

				ConsoleIO.PrintLn("去除注释和空行后的代码：", ConsoleColor.White);
				string formattedCode = CodeProcessor.Format(code);
				ConsoleIO.PrintLn(CodeProcessor.Format(formattedCode));
				ConsoleIO.PrintLn();

				ConsoleIO.PrintLn("格式化后代码的词频统计：", ConsoleColor.White);
				CodeProcessor.CountWords(formattedCode).ForEach(p =>
				{
					ConsoleIO.Print($"{p.Key}: ");
					ConsoleIO.PrintLn($"{p.Value}", ConsoleColor.Yellow);
				});

				Console.ReadKey();
			}
			catch (Exception ex)
			{
				ConsoleIO.LogError(ex);
			}
		}
	}
}