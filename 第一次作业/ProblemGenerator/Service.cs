using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemGenerator
{
	public enum Operator { Addition, Subtraction };
	public class Problem
	{
		public int Operand1 { get; set; }
		public int Operand2 { get; set; }
		public Operator Operator { get; set; }
		public int Answer { get; set; }
		public bool Result =>
			Operator == Operator.Addition ?
			Operand1 + Operand2 == Answer :
			Operand1 - Operand2 == Answer;

		public Problem(int operand1, int operand2, Operator @operator)
		{
			Operand1 = operand1;
			Operand2 = operand2;
			Operator = @operator;
		}
	}

	public static class Service
	{
		const int problemTime = 10000;
		const int resultTime = 1000;
		public const int TotalScore = 100;
		public const int TotalProblemCnt = 10;

		public static event Action OnDisplayResult;
		public static event Action OnNextProblem;
		public static event Action OnDisplayScore;
		
		public static Problem Problem { get; set; }

		public static int ProblemIndex { get; private set; } = 0;

		static int correctCnt = 0;
		public static int Score => (int)Math.Ceiling((double)correctCnt / TotalProblemCnt * TotalScore);

		static int countdown;
		public static int Countdown
		{
			get => countdown;
			set
			{
				countdown = value;
				if (countdown <= 0)
				{
					countdown = 0;
					DisplayResult();
				}
			}
		}

		static int resultCountdown;
		public static int ResultCountdown
		{
			get => resultCountdown;
			set
			{
				resultCountdown = value;
				if (resultCountdown <= 0)
				{
					resultCountdown = 0;
					NextProblem();
				}
			}
		}

		public static void DisplayResult()
		{
			if (Problem.Result) ++correctCnt;
			resultCountdown = resultTime;
			OnDisplayResult();
		}

		public static void NextProblem()
		{
			++ProblemIndex;
			if (ProblemIndex > TotalProblemCnt)
			{
				OnDisplayScore();
				return;
			}
			countdown = problemTime;
			GenerateProblem();
			OnNextProblem();
		}

		public static void Reset()
		{
			Problem = null;
			ProblemIndex = 0;
			correctCnt = 0;
			countdown = 0;
			resultCountdown = 0;
		}

		public static void GenerateProblem()
		{
			Random rnd = new Random();
			int opr1 = rnd.Next() % 100;
			int opr2 = rnd.Next() % 100;
			Operator opt = rnd.Next() % 2 == 0 ? Operator.Addition : Operator.Subtraction;
			while (opt == Operator.Subtraction && opr2 > opr1) opr2 -= opr1;
			Problem = new Problem(opr1, opr2, opt);
		}
	}
}
