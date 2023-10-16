using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Assignment4
{
	public partial class FormMain : Form
	{
		class DirHistoryNode
		{
			public string Path { get; set; }
			public DirHistoryNode? Prev { get; set; }
			public DirHistoryNode? Next { get; set; }

			public DirHistoryNode(string path)
			{
				Path = path;
			}
		}
		DirHistoryNode CurrentDir;

		const string startDirPath = "C:\\";
		string? lastDirPath = null;
		string DirPath
		{
			get => CurrentDir.Path;

			set
			{
				Exception? exception = null;
				try
				{
					if (string.IsNullOrEmpty(value)) return;

					lastDirPath ??= startDirPath;

					// 将路径的写法标准化
					value = FileUtility.StandardizePath(value);

					CheckDirAvailability(value);

					CurrentDir.Path = lastDirPath = value;
				}
				catch (Exception ex)
				{
					try
					{
						CurrentDir.Path = lastDirPath!;
					}
					catch
					{
						CurrentDir.Path = string.Empty;
					}

					exception = ex;
				}
				finally
				{
					txtDirPath.Text = CurrentDir.Path;

					if (exception != null)
					{
						ShowError(exception.Message); // 放在后面是因为弹出消息框之后会再触发一次 Leave，如果此时 txtDirPath 的文本仍保持原样会再次提示错误
					}

					UpdateDisplay();
				}
			}
		}

		void ShowError(string? text)
		{
			MessageBox.Show(text, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		static void CheckDirAvailability(string path)
		{
			try
			{
				Directory.GetDirectories(path);
			}
			catch
			{
				throw new DirectoryNotFoundException($"路径“{path}”不存在或无法访问。");
			}
		}

		public FormMain()
		{
			InitializeComponent();

			CurrentDir = new(startDirPath);
			DirPath = CurrentDir.Path;
			InitTreeView();
		}

		void InitTreeView()
		{
			string[] driveNames = Directory.GetLogicalDrives();
			foreach (string drive in driveNames)
			{
				TreeNode node = new(drive);
				trvHierarchy.Nodes.Add(node);
				GenerateSubnodes(node);
			}
		}

		void UpdateDisplay()
		{
			try
			{
				UpdateToolStrip();
				UpdateDirList();
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
			}
		}

		void UpdateToolStrip()
		{
			tsiView_Details.Checked = lstDir.View == View.Details;
			tsiView_List.Checked = lstDir.View == View.List;
			tsiView_Tile.Checked = lstDir.View == View.Tile;
		}

		void UpdateDirList()
		{
			lstDir.EndUpdate();
			lstDir.BeginUpdate();

			try
			{
				DirectoryInfo[] dirs = Directory.GetDirectories(DirPath).Select(path => new DirectoryInfo(path)).ToArray();
				FileInfo[] files = Directory.GetFiles(DirPath).Select(path => new FileInfo(path)).ToArray();

				lstDir.Items.Clear();
				foreach (DirectoryInfo dir in dirs)
				{
					ListViewItem item = new() { Tag = dir, Text = dir.Name };
					item.SubItems.Add("文件夹");
					if (lstDir.View != View.Tile)
					{
						item.SubItems.Add(dir.LastWriteTime.ToString());
						item.SubItems.Add("");
					}

					lstDir.Items.Add(item);
				}
				foreach (FileInfo file in files)
				{
					string extension = Path.GetExtension(file.FullName).ToUpper();
					string type = string.IsNullOrEmpty(extension) ? "文件" : $"{extension[1..]} 文件";
					string size = FileUtility.FormatFileSize(file.Length);

					ListViewItem item = new() { Tag = file, Text = file.Name };
					if (lstDir.View == View.Tile)
					{
						item.SubItems.Add($"{type} | {size}");
					}
					else
					{
						item.SubItems.Add(type);
						item.SubItems.Add(file.LastWriteTime.ToString());
						item.SubItems.Add(size);
					}

					lstDir.Items.Add(item);
				}
			}
			finally
			{
				lstDir.EndUpdate();
			}
		}

		static void GenerateSubnodes(TreeNode node)
		{
			if (node == null || !Directory.Exists(node.FullPath))
			{
				node?.Remove();
				return;
			}

			try
			{
				TreeNode[] dirNodes = Directory.GetDirectories(node.FullPath).Select(path => new TreeNode(Path.GetFileName(path))).ToArray();
				node.Nodes.AddRange(dirNodes);
			}
			catch { }
		}

		static void RemoveSubnodes(TreeNode node)
		{
			node.Nodes.Clear();
		}

		private void trvHierarchy_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null) return;

			foreach (TreeNode node in e.Node.Nodes)
			{
				GenerateSubnodes(node);
			}
		}

		private void trvHierarchy_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			if (e.Node == null) return;

			foreach (TreeNode node in e.Node.Nodes)
			{
				RemoveSubnodes(node);
			}
		}

		private void trvHierarchy_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			DirPath = e.Node.FullPath;
		}

		private void lstDir_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lstDir.SelectedItems.Count == 0) return;

			try
			{
				object info = lstDir.SelectedItems[0].Tag;
				if (info is FileInfo file)
				{
					Process process = new();
					process.StartInfo.FileName = "powershell";
					process.StartInfo.Arguments = $"-c {file.FullName}";
					process.StartInfo.CreateNoWindow = true;
					process.Start();
				}
				else if (info is DirectoryInfo dir)
				{
					DirPath = dir.FullName;
				}
			}
			catch (Exception ex)
			{
				ShowError(ex.Message);
			}
		}

		// 按键处理
		protected override bool ProcessDialogKey(Keys keyData)
		{
			// 在路径文本框按下回车时，将控件焦点去掉，触发Leave事件
			if (ActiveControl == txtDirPath && keyData == Keys.Return)
			{
				ActiveControl = null;
				return true;
			}

			return base.ProcessDialogKey(keyData);
		}

		private void txtDir_Leave(object sender, EventArgs e)
		{
			DirPath = txtDirPath.Text;
		}

		private void tsiView_Details_Click(object sender, EventArgs e)
		{
			lstDir.View = View.Details;
			UpdateDisplay();
		}

		private void tsiView_List_Click(object sender, EventArgs e)
		{
			lstDir.View = View.List;
			UpdateDisplay();
		}

		private void tsiView_Tile_Click(object sender, EventArgs e)
		{
			lstDir.View = View.Tile;
			UpdateDisplay();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			DirPath = Path.Combine(DirPath, "..");
		}
	}
}