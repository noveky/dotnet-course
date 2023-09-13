using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemGenerator
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();

			Service.OnDisplayResult += DisplayResult;
			Service.OnNextProblem += NextProblem;
			Service.OnDisplayScore += DisplayScore;

			Reset();
		}

		private void Reset()
		{
			Service.Reset();
			Service.NextProblem();

			txtAnswer.Text = string.Empty;
			OnTxtAnswerChange();
			tmrProblem.Start();
		}

		private void DisplayResult()
		{
			tmrProblem.Stop();
			tmrResult.Start();
			btnNext.Enabled = false;
			txtAnswer.BackColor = Service.Problem.Result ? Color.Lime : Color.Red;
			txtAnswer.Enabled = false;
		}

		private void NextProblem()
		{
			tmrResult.Stop();
			tmrProblem.Start();
			btnNext.Enabled = true;
			txtAnswer.BackColor = SystemColors.Window;
			txtAnswer.Text = string.Empty;
			txtAnswer.Enabled = true;
			lblProblem.Text = Service.Problem.Operand1 + " " + (Service.Problem.Operator == Operator.Addition ? "+" : "-") + " " + Service.Problem.Operand2;
			btnNext.Text = Service.ProblemIndex == Service.TotalProblemCnt ? "交卷" : "下一题";
			lblProgress.Text = "题目：" + Service.ProblemIndex + "/" + Service.TotalProblemCnt;
			txtAnswer.Focus();
		}

		private void DisplayScore()
		{
			tmrProblem.Stop();
			tmrResult.Stop();
			DialogResult dr = MessageBox.Show("答题完成，您的得分是：" + Service.Score + "\n再来一次？", "答题完成", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (dr == DialogResult.Yes)
			{
				Reset();
			}
			else
			{
				Application.Exit();
			}
		}

		private void OnTxtAnswerChange()
		{
			string s = string.Empty;
			foreach (char c in txtAnswer.Text)
			{
				if (c >= '0' && c <= '9') s += c;
			}
			int.TryParse(s, out int answer);
			Service.Problem.Answer = string.IsNullOrEmpty(s) ? int.MinValue : answer;
			txtAnswer.Text = s;
		}

		private void tmrProblem_Tick(object sender, EventArgs e)
		{
			Service.Countdown -= tmrProblem.Interval;
			lblCountdown.Text = "倒计时：" + (int)Math.Ceiling((double)Service.Countdown / 1000);
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			Service.DisplayResult();
		}

		private void tmrResult_Tick(object sender, EventArgs e)
		{
			Service.ResultCountdown -= tmrResult.Interval;
		}

		private void txtAnswer_TextChanged(object sender, EventArgs e)
		{
			OnTxtAnswerChange();
		}
	}
}
