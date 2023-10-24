namespace WebCrawler
{
	partial class MainForm
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
			this.cboSearchEngine = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtKeywords = new System.Windows.Forms.TextBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.cboPattern = new System.Windows.Forms.ComboBox();
			this.txtRegex = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageMatches = new System.Windows.Forms.TabPage();
			this.lstMatches = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.tabPageUrls = new System.Windows.Forms.TabPage();
			this.lstCrawledUrls = new System.Windows.Forms.ListView();
			this.tabControl1.SuspendLayout();
			this.tabPageMatches.SuspendLayout();
			this.tabPageUrls.SuspendLayout();
			this.SuspendLayout();
			// 
			// cboSearchEngine
			// 
			this.cboSearchEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSearchEngine.FormattingEnabled = true;
			this.cboSearchEngine.Location = new System.Drawing.Point(12, 12);
			this.cboSearchEngine.Name = "cboSearchEngine";
			this.cboSearchEngine.Size = new System.Drawing.Size(79, 25);
			this.cboSearchEngine.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "样式：";
			// 
			// txtKeywords
			// 
			this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKeywords.Location = new System.Drawing.Point(97, 12);
			this.txtKeywords.Name = "txtKeywords";
			this.txtKeywords.PlaceholderText = "输入关键词";
			this.txtKeywords.Size = new System.Drawing.Size(744, 23);
			this.txtKeywords.TabIndex = 2;
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Location = new System.Drawing.Point(766, 43);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 3;
			this.btnStart.Text = "开始";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// cboPattern
			// 
			this.cboPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPattern.FormattingEnabled = true;
			this.cboPattern.Location = new System.Drawing.Point(62, 43);
			this.cboPattern.Name = "cboPattern";
			this.cboPattern.Size = new System.Drawing.Size(108, 25);
			this.cboPattern.TabIndex = 4;
			this.cboPattern.SelectedValueChanged += new System.EventHandler(this.cboPattern_SelectedValueChanged);
			// 
			// txtRegex
			// 
			this.txtRegex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegex.Location = new System.Drawing.Point(176, 43);
			this.txtRegex.Name = "txtRegex";
			this.txtRegex.PlaceholderText = "输入正则表达式";
			this.txtRegex.Size = new System.Drawing.Size(584, 23);
			this.txtRegex.TabIndex = 5;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPageMatches);
			this.tabControl1.Controls.Add(this.tabPageUrls);
			this.tabControl1.Location = new System.Drawing.Point(12, 74);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(829, 499);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPageMatches
			// 
			this.tabPageMatches.Controls.Add(this.lstMatches);
			this.tabPageMatches.Location = new System.Drawing.Point(4, 26);
			this.tabPageMatches.Name = "tabPageMatches";
			this.tabPageMatches.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMatches.Size = new System.Drawing.Size(821, 469);
			this.tabPageMatches.TabIndex = 0;
			this.tabPageMatches.Text = "匹配";
			this.tabPageMatches.UseVisualStyleBackColor = true;
			// 
			// lstMatches
			// 
			this.lstMatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lstMatches.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstMatches.FullRowSelect = true;
			this.lstMatches.GridLines = true;
			this.lstMatches.Location = new System.Drawing.Point(3, 3);
			this.lstMatches.Name = "lstMatches";
			this.lstMatches.Size = new System.Drawing.Size(815, 463);
			this.lstMatches.TabIndex = 0;
			this.lstMatches.UseCompatibleStateImageBehavior = false;
			this.lstMatches.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "字符串";
			this.columnHeader1.Width = 300;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "来源 URL";
			this.columnHeader2.Width = 500;
			// 
			// tabPageUrls
			// 
			this.tabPageUrls.Controls.Add(this.lstCrawledUrls);
			this.tabPageUrls.Location = new System.Drawing.Point(4, 26);
			this.tabPageUrls.Name = "tabPageUrls";
			this.tabPageUrls.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageUrls.Size = new System.Drawing.Size(821, 469);
			this.tabPageUrls.TabIndex = 1;
			this.tabPageUrls.Text = "已爬取的 URL";
			this.tabPageUrls.UseVisualStyleBackColor = true;
			// 
			// lstCrawledUrls
			// 
			this.lstCrawledUrls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstCrawledUrls.FullRowSelect = true;
			this.lstCrawledUrls.GridLines = true;
			this.lstCrawledUrls.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lstCrawledUrls.Location = new System.Drawing.Point(3, 3);
			this.lstCrawledUrls.Name = "lstCrawledUrls";
			this.lstCrawledUrls.Size = new System.Drawing.Size(815, 463);
			this.lstCrawledUrls.TabIndex = 0;
			this.lstCrawledUrls.UseCompatibleStateImageBehavior = false;
			this.lstCrawledUrls.View = System.Windows.Forms.View.Details;
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnStart;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(853, 585);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtRegex);
			this.Controls.Add(this.cboPattern);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.txtKeywords);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboSearchEngine);
			this.Name = "MainForm";
			this.Text = "爬虫程序";
			this.tabControl1.ResumeLayout(false);
			this.tabPageMatches.ResumeLayout(false);
			this.tabPageUrls.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private ComboBox cboSearchEngine;
		private Label label1;
		private TextBox txtKeywords;
		private Button btnStart;
		private ComboBox cboPattern;
		private TextBox txtRegex;
		private TabControl tabControl1;
		private TabPage tabPageMatches;
		private TabPage tabPageUrls;
		private ListView lstMatches;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ListView lstCrawledUrls;
	}

	#endregion
}