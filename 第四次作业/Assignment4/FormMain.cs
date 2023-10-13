using System.Runtime.CompilerServices;

namespace Assignment4
{
	public partial class FormMain : Form
	{
		const string startDir = "C:\\";
		string? lastDir = null;
		string DirPath
		{
			get => txtDirPath.Text;

			set
			{
				try
				{
					if (string.IsNullOrEmpty(value)) return;

					// 将路径的写法规范化
					value = value.Trim().Replace('/', '\\').TrimEnd('\\') + "\\";

					CheckDirExistence(value);

					txtDirPath.Text = value;
				}
				catch (Exception ex)
				{
					ShowError(ex.Message);

					lastDir ??= startDir;
					if (lastDir != value && Directory.Exists(lastDir))
					{
						txtDirPath.Text = lastDir;
					}
					else
					{
						txtDirPath.Text = string.Empty;
					}
				}
				finally
				{
					DisplayDir();
				}
			}
		}

		void ShowError(string? text)
		{
			MessageBox.Show(text, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}


		public FormMain()
		{
			InitializeComponent();

			DirPath = startDir;
		}

		void CheckDirExistence(string path)
		{
			if (!Directory.Exists(path))
			{
				throw new DirectoryNotFoundException($"路径“{path}”不存在。");
			}
		}

		void DisplayDir()
		{
			try
			{
				lstDir.BeginUpdate();

				DirectoryInfo[] dirs = Directory.GetDirectories(DirPath).Select(path => new DirectoryInfo(path)).ToArray();
				FileInfo[] files = Directory.GetFiles(DirPath).Select(path => new FileInfo(path)).ToArray();

				lstDir.Items.Clear();
				foreach (DirectoryInfo dir in dirs)
				{
					ListViewItem item = new() { Tag = dir, Text = dir.Name };
					item.SubItems.Add("目录");
					item.SubItems.Add(dir.LastWriteTime.ToString());
					item.SubItems.Add("");

					lstDir.Items.Add(item);
				}
				foreach (FileInfo file in files)
				{
					string extension = Path.GetExtension(file.FullName).ToUpper();

					ListViewItem item = new() { Tag = file, Text = file.Name };
					item.SubItems.Add(string.IsNullOrEmpty(extension) ? "文件" : $"{extension[1..]} 文件");
					item.SubItems.Add(file.LastWriteTime.ToString());
					item.SubItems.Add(FileUtility.FormatFileSize(file.Length));

					lstDir.Items.Add(item);
				}

				lstDir.EndUpdate();
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
			}
		}

		private void txtDir_Leave(object sender, EventArgs e)
		{
			DirPath = txtDirPath.Text;
		}
	}
}