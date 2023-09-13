using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactors
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.Write("Enter a number: ");
				Console.ForegroundColor = ConsoleColor.Yellow;
				int num = int.Parse(Console.ReadLine());
				Console.ResetColor();

				if (num <= 0) throw new Exception("Invalid number.");

				List<int> primeFacs = new List<int>();
				int t = num;
				for (int i = 2; i <= t; ++i)
				{
					while (t % i == 0)
					{
						t /= i;
						primeFacs.Add(i);
					}
				}

				Console.Write(num + " = ");
				for (int i = 0; i < primeFacs.Count; ++i)
				{
					Console.Write(primeFacs[i] + (i == primeFacs.Count - 1 ? "\n" : " * "));
				}
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Console.ResetColor();
			}
			finally
			{
				Console.ReadKey();
			}
		}
	}
}
