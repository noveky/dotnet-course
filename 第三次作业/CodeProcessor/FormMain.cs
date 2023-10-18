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

					// 读文件，用 Code 属性更新“代码”文本框内容
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
		static void StylizeTextSection(RichTextBox rtb, (int Index, int Length) section, Color? foreColor = null, bool bold = false, Color? backColor = null)
		{
			int lStart = rtb.SelectionStart, lLength = rtb.SelectionLength;

			rtb.SelectionStart = section.Index;
			rtb.SelectionLength = section.Length;
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

		private void btnFormat_Click(object sender, EventArgs e)
		{
			// 格式化代码
			Code = CodeProcessor.Format(Code);

			// 统计词频
			rtbCounts.Text = string.Empty;
			CodeProcessor.GetWordCounts(Code).ForEach(wordCount =>
			{
				StylizeTextSection(rtbCounts, (rtbCounts.TextLength, 0), null, true);
				rtbCounts.AppendText($"{wordCount.Word}");
				StylizeTextSection(rtbCounts, (rtbCounts.TextLength, 0), null, false);
				rtbCounts.AppendText($": {wordCount.Count}\n");
			});

			// 给所有单词染色
			int[] colors = { 0x95CDF0, 0xF8DE9B, 0xF89B8B, 0xA5E798 };
			int colorIndex = 0;
			CodeProcessor.GetWordRanges(Code).ForEach(section =>
			{
				StylizeTextSection(rtbCode, section, Color.FromArgb(colors[colorIndex]), true);
				colorIndex = (colorIndex + 1) % colors.Length;
			});
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtPath.Clear();
			rtbCode.Clear();
			rtbCounts.Clear();
			CodePath = Code = string.Empty;
		}

		// “代码”文本框发生更新后，将其中的注释用绿色加粗显示
		private void rtbCode_TextChanged(object sender, EventArgs e)
		{
			CodeProcessor.GetMatchRanges(Regex.Matches(Code, @"(//[^\r\n]*)")).ForEach(section =>
			{
				StylizeTextSection(rtbCode, section, Color.FromArgb(0x51A044), true);
			});
		}

		// 双击“路径”文本框时，打开选择文件对话框
		private void txtPath_DoubleClick(object sender, EventArgs e)
		{
			// 清空双击导致的文本选择，并去掉控件焦点
			txtPath.SelectionLength = 0;
			ActiveControl = null;

			ShowBrowseDialog();
		}

		// 在“路径”文本框按下回车时，更新文件路径
		private void txtPath_KeyDown(object sender, KeyEventArgs e)
		{
			// 按下回车时，将控件焦点去掉，触发Leave事件
			if (e.KeyCode == Keys.Return)
			{
				e.Handled = true;
				ActiveControl = null;
			}
		}

		// “路径”文本框完成编辑时，更新文件路径
		private void txtPath_Leave(object sender, EventArgs e)
		{
			CodePath = txtPath.Text;
		}
	}
}
