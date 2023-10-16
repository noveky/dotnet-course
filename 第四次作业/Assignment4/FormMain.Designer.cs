namespace Assignment4
{
	partial class FormMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.tsiView_Details = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiView_List = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiView_Tile = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cboDirPath = new System.Windows.Forms.ComboBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnForward = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.trvHierarchy = new System.Windows.Forms.TreeView();
			this.lstDir = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.ShowItemToolTips = false;
			this.toolStrip1.Size = new System.Drawing.Size(846, 33);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.AutoSize = false;
			this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiView_Details,
            this.tsiView_List,
            this.tsiView_Tile});
			this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(60, 30);
			this.toolStripSplitButton1.Text = "查看";
			// 
			// tsiView_Details
			// 
			this.tsiView_Details.Name = "tsiView_Details";
			this.tsiView_Details.Size = new System.Drawing.Size(124, 22);
			this.tsiView_Details.Text = "详细信息";
			this.tsiView_Details.Click += new System.EventHandler(this.tsiView_Details_Click);
			// 
			// tsiView_List
			// 
			this.tsiView_List.Name = "tsiView_List";
			this.tsiView_List.Size = new System.Drawing.Size(124, 22);
			this.tsiView_List.Text = "列表";
			this.tsiView_List.Click += new System.EventHandler(this.tsiView_List_Click);
			// 
			// tsiView_Tile
			// 
			this.tsiView_Tile.Name = "tsiView_Tile";
			this.tsiView_Tile.Size = new System.Drawing.Size(124, 22);
			this.tsiView_Tile.Text = "平铺";
			this.tsiView_Tile.Click += new System.EventHandler(this.tsiView_Tile_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cboDirPath);
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Controls.Add(this.btnUp);
			this.panel1.Controls.Add(this.btnForward);
			this.panel1.Controls.Add(this.btnBack);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 33);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(846, 36);
			this.panel1.TabIndex = 1;
			this.panel1.TabStop = true;
			// 
			// cboDirPath
			// 
			this.cboDirPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboDirPath.FormattingEnabled = true;
			this.cboDirPath.Location = new System.Drawing.Point(111, 5);
			this.cboDirPath.Name = "cboDirPath";
			this.cboDirPath.Size = new System.Drawing.Size(694, 25);
			this.cboDirPath.TabIndex = 5;
			this.cboDirPath.DropDown += new System.EventHandler(this.txtDirPath_DropDown);
			this.cboDirPath.SelectedValueChanged += new System.EventHandler(this.txtDirPath_SelectedValueChanged);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnRefresh.Location = new System.Drawing.Point(811, 3);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(30, 30);
			this.btnRefresh.TabIndex = 4;
			this.btnRefresh.Text = "↻";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnUp
			// 
			this.btnUp.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnUp.Location = new System.Drawing.Point(75, 3);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(30, 30);
			this.btnUp.TabIndex = 2;
			this.btnUp.Text = "↑";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnForward
			// 
			this.btnForward.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnForward.Location = new System.Drawing.Point(39, 3);
			this.btnForward.Name = "btnForward";
			this.btnForward.Size = new System.Drawing.Size(30, 30);
			this.btnForward.TabIndex = 1;
			this.btnForward.Text = "→";
			this.btnForward.UseVisualStyleBackColor = true;
			this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
			// 
			// btnBack
			// 
			this.btnBack.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnBack.Location = new System.Drawing.Point(3, 3);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(30, 30);
			this.btnBack.TabIndex = 0;
			this.btnBack.Text = "←";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 69);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.trvHierarchy);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lstDir);
			this.splitContainer1.Size = new System.Drawing.Size(846, 490);
			this.splitContainer1.SplitterDistance = 269;
			this.splitContainer1.TabIndex = 2;
			// 
			// trvHierarchy
			// 
			this.trvHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvHierarchy.Location = new System.Drawing.Point(0, 0);
			this.trvHierarchy.Name = "trvHierarchy";
			this.trvHierarchy.Size = new System.Drawing.Size(269, 490);
			this.trvHierarchy.TabIndex = 2;
			this.trvHierarchy.TabStop = false;
			this.trvHierarchy.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.trvHierarchy_AfterCollapse);
			this.trvHierarchy.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trvHierarchy_AfterExpand);
			this.trvHierarchy.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvHierarchy_NodeMouseClick);
			// 
			// lstDir
			// 
			this.lstDir.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lstDir.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstDir.FullRowSelect = true;
			this.lstDir.Location = new System.Drawing.Point(0, 0);
			this.lstDir.Name = "lstDir";
			this.lstDir.Size = new System.Drawing.Size(573, 490);
			this.lstDir.TabIndex = 2;
			this.lstDir.UseCompatibleStateImageBehavior = false;
			this.lstDir.View = System.Windows.Forms.View.Details;
			this.lstDir.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstDir_MouseDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "名称";
			this.columnHeader1.Width = 200;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "类型";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "修改日期";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "大小";
			this.columnHeader4.Width = 100;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 559);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "FormMain";
			this.Text = "文件浏览器";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ToolStrip toolStrip1;
		private ToolStripSplitButton toolStripSplitButton1;
		private ToolStripMenuItem tsiView_Details;
		private ToolStripMenuItem tsiView_List;
		private ToolStripMenuItem tsiView_Tile;
		private Panel panel1;
		private Button btnBack;
		private Button btnForward;
		private Button btnUp;
		private Button btnRefresh;
		private SplitContainer splitContainer1;
		private TreeView trvHierarchy;
		private ListView lstDir;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private ColumnHeader columnHeader4;
		private ComboBox cboDirPath;
	}
}