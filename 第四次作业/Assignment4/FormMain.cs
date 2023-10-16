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

			public override string ToString() => Path;
		}

		DirHistoryNode CurrentDir;
		const string startDirPath = "C:\\";
		string DirPath
		{
			get => CurrentDir.Path;

			set
			{
				Exception? ex_ = null;
				try
				{
					if (string.IsNullOrEmpty(value)) return;

					// ��·����д����׼��
					value = FileUtility.StandardizePath(value);

					if (DirPath != value)
					{
						CheckDirAvailability(value);

						// ����ʷ��¼��������½��
						DirHistoryNode lastDir = CurrentDir;
						CurrentDir = new(value) { Prev = lastDir };
						lastDir.Next = CurrentDir;

						// ��ʷ��¼ȥ��
						for (DirHistoryNode? n = lastDir; n != null; n = n.Prev)
						{
							if (n.Path == value)
							{
								// ɾ��·����ͬ����ʷ��¼���
								if (n.Prev != null) n.Prev.Next = n.Next;
								if (n.Next != null) n.Next.Prev = n.Prev;
							}
						}
					}
				}
				catch (Exception ex)
				{
					ex_ = ex;
				}
				finally
				{
					cboDirPath.Text = CurrentDir.Path;

					if (ex_ != null)
					{
						ShowError(ex_.Message); // ���ں�������Ϊ������Ϣ��֮����ٴ���һ�� Leave�������ʱ txtDirPath ���ı��Ա���ԭ�����ٴ���ʾ����
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
				throw new DirectoryNotFoundException($"·����{path}�������ڻ��޷����ʡ�");
			}
		}

		public FormMain()
		{
			InitializeComponent();

			CurrentDir = new(startDirPath);
			UpdateDirPath();
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

		// ÿ�θ� CurrentDir ��ֵ����Ҫ�� DirPath �� setter ֪ͨ�ؼ�����
		void UpdateDirPath() => DirPath = CurrentDir.Path;

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
					item.SubItems.Add("�ļ���");
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
					string type = string.IsNullOrEmpty(extension) ? "�ļ�" : $"{extension[1..]} �ļ�";
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

			RemoveSubnodes(e.Node);
			GenerateSubnodes(e.Node);
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

		// ��������
		protected override bool ProcessDialogKey(Keys keyData)
		{
			// ��·���ı����»س�ʱ�����ؼ�����ȥ��������Leave�¼�
			if (ActiveControl == cboDirPath && keyData == Keys.Return)
			{
				ActiveControl = null;
				return true;
			}

			return base.ProcessDialogKey(keyData);
		}

		private void txtDir_Leave(object sender, EventArgs e)
		{
			DirPath = cboDirPath.Text;
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

		private void btnBack_Click(object sender, EventArgs e)
		{
			if (CurrentDir.Prev == null) return;

			CurrentDir = CurrentDir.Prev;
			UpdateDirPath();
		}

		private void btnForward_Click(object sender, EventArgs e)
		{
			if (CurrentDir.Next == null) return;

			CurrentDir = CurrentDir.Next;
			UpdateDirPath();
		}

		private void txtDirPath_DropDown(object sender, EventArgs e)
		{
			cboDirPath.EndUpdate();
			cboDirPath.BeginUpdate();

			cboDirPath.Items.Clear();
			DirHistoryNode? n = CurrentDir;
			for (; n.Prev != null; n = n.Prev) ;
			for (; n != null; n = n.Next)
			{
				cboDirPath.Items.Add(n);
			}

			cboDirPath.EndUpdate();
		}

		private void txtDirPath_SelectedValueChanged(object sender, EventArgs e)
		{
			CurrentDir = (DirHistoryNode)cboDirPath.SelectedItem;
			UpdateDirPath();
		}
	}
}