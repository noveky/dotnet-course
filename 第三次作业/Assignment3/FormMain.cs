using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
	public partial class FormMain : Form
	{
		string CodePath
		{
			get => txtPath.Text;

			set
			{
				string lPath = txtPath.Text;

				try
				{
					if (string.IsNullOrEmpty(value)) return;

					// 将路径的写法规范化
					value = value.Trim().Replace('/', '\\');

					// 检查路径是否存在
					if (!Path.Exists(value))
					{
						throw new DirectoryNotFoundException();
					}

					txtPath.Text = value;

					Code = File.ReadAllText(CodePath);
				}
				catch
				{
					txtPath.Text = string.Empty;
				}
			}
		}

		string Code
		{
			get => rtbCode.Text;
			set
			{
				rtbCode.Clear();
				rtbCode.Text = value;
			}
		}

		public FormMain()
		{
			InitializeComponent();
		}

		// 给 RichTextBox 的一段文本染色、加粗
		static void StylizeTextSection(RichTextBox rtb, Range range, Color? foreColor = null, bool bold = false, Color? backColor = null)
		{
			int lStart = rtb.SelectionStart, lLength = rtb.SelectionLength;

			rtb.SelectionStart = range.Start.Value;
			rtb.SelectionLength = range.End.Value - range.Start.Value;
			rtb.SelectionColor = foreColor ?? rtb.ForeColor;
			rtb.SelectionBackColor = backColor ?? rtb.BackColor;
			rtb.SelectionFont = new Font(rtb.Font, bold ? FontStyle.Bold : FontStyle.Regular);

			rtb.SelectionStart = lStart;
			rtb.SelectionLength = lLength;
		}

		void ShowBrowseDialog()
		{
			OpenFileDialog dialog = new()
			{
				InitialDirectory = Path.GetDirectoryName(CodePath),
				Filter = "C# 文件|*.cs",
			};
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				CodePath = dialog.FileName;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			ShowBrowseDialog();
		}

		private void txtPath_Leave(object sender, EventArgs e)
		{
			CodePath = txtPath.Text;
		}

		private void txtPath_KeyDown(object sender, KeyEventArgs e)
		{
			// 按下回车时，将控件焦点去掉，触发Leave事件
			if (e.KeyCode == Keys.Return)
			{
				ActiveControl = null;
			}
		}

		private void btnFormat_Click(object sender, EventArgs e)
		{
			Code = CodeProcessor.Format(Code);

			rtbCounts.Text = string.Empty;
			CodeProcessor.CountWords(Code).ForEach(p =>
			{
				StylizeTextSection(rtbCounts, new Range(rtbCounts.TextLength, rtbCounts.TextLength), null, true);
				rtbCounts.AppendText($"{p.Key}");
				StylizeTextSection(rtbCounts, new Range(rtbCounts.TextLength, rtbCounts.TextLength), null, false);
				rtbCounts.AppendText($": {p.Value}\n");
			});

			int[] colors = { 0x75BDE0, 0xF8DE9B, 0xF89B8B, 0xA5E798 };
			int colorIndex = 0;
			CodeProcessor.GetWordRanges(Code).ForEach(r =>
			{
				StylizeTextSection(rtbCode, r, Color.FromArgb(colors[colorIndex]), true);
				colorIndex = (colorIndex + 1) % colors.Length;
			});
		}

		private void rtbCode_TextChanged(object sender, EventArgs e)
		{
			// 高亮注释
			CodeProcessor.GetRanges(Regex.Matches(Code, @"(//[^\r\n]*)")).ForEach(r =>
			{
				StylizeTextSection(rtbCode, r, Color.FromArgb(0x51A044), true);
			});
		}

		private void txtPath_DoubleClick(object sender, EventArgs e)
		{
			// 去掉控件焦点
			txtPath.SelectionLength = 0;
			ActiveControl = null;

			ShowBrowseDialog();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtPath.Clear();
			rtbCode.Clear();
			rtbCounts.Clear();
			CodePath = Code = string.Empty;
		}
	}
}
