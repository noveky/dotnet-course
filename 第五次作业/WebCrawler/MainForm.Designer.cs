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
			this.btnExecute = new System.Windows.Forms.Button();
			this.cboPattern = new System.Windows.Forms.ComboBox();
			this.txtRegex = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageResults = new System.Windows.Forms.TabPage();
			this.tabPageUrls = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
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
			// btnExecute
			// 
			this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExecute.Location = new System.Drawing.Point(766, 43);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(75, 23);
			this.btnExecute.TabIndex = 3;
			this.btnExecute.Text = "执行";
			this.btnExecute.UseVisualStyleBackColor = true;
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
			this.tabControl1.Controls.Add(this.tabPageResults);
			this.tabControl1.Controls.Add(this.tabPageUrls);
			this.tabControl1.Location = new System.Drawing.Point(12, 74);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(829, 499);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPageResults
			// 
			this.tabPageResults.Location = new System.Drawing.Point(4, 26);
			this.tabPageResults.Name = "tabPageResults";
			this.tabPageResults.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageResults.Size = new System.Drawing.Size(821, 469);
			this.tabPageResults.TabIndex = 0;
			this.tabPageResults.Text = "爬取结果";
			this.tabPageResults.UseVisualStyleBackColor = true;
			// 
			// tabPageUrls
			// 
			this.tabPageUrls.Location = new System.Drawing.Point(4, 26);
			this.tabPageUrls.Name = "tabPageUrls";
			this.tabPageUrls.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageUrls.Size = new System.Drawing.Size(821, 469);
			this.tabPageUrls.TabIndex = 1;
			this.tabPageUrls.Text = "已爬取的 URL";
			this.tabPageUrls.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnExecute;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(853, 585);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtRegex);
			this.Controls.Add(this.cboPattern);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.txtKeywords);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cboSearchEngine);
			this.Name = "MainForm";
			this.Text = "爬虫程序";
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private ComboBox cboSearchEngine;
		private Label label1;
		private TextBox txtKeywords;
		private Button btnExecute;
		private ComboBox cboPattern;
		private TextBox txtRegex;
		private TabControl tabControl1;
		private TabPage tabPageResults;
		private TabPage tabPageUrls;
	}

	#endregion
}