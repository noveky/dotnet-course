namespace Assignment3
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rtbCounts = new System.Windows.Forms.RichTextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnFormat = new System.Windows.Forms.Button();
			this.rtbCode = new System.Windows.Forms.RichTextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnBrowse);
			this.panel1.Controls.Add(this.txtPath);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(982, 49);
			this.panel1.TabIndex = 3;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(486, 12);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(70, 23);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.Text = "浏览...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(62, 12);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(418, 23);
			this.txtPath.TabIndex = 1;
			this.txtPath.DoubleClick += new System.EventHandler(this.txtPath_DoubleClick);
			this.txtPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPath_KeyDown);
			this.txtPath.Leave += new System.EventHandler(this.txtPath_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "路径：";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 49);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(274, 613);
			this.panel2.TabIndex = 6;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.groupBox1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 42);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
			this.panel4.Size = new System.Drawing.Size(274, 571);
			this.panel4.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rtbCounts);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(10, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox1.Size = new System.Drawing.Size(254, 561);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "词频统计";
			// 
			// rtbCounts
			// 
			this.rtbCounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbCounts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbCounts.Font = new System.Drawing.Font("Fira Code", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rtbCounts.ForeColor = System.Drawing.SystemColors.WindowText;
			this.rtbCounts.Location = new System.Drawing.Point(10, 26);
			this.rtbCounts.Name = "rtbCounts";
			this.rtbCounts.ReadOnly = true;
			this.rtbCounts.Size = new System.Drawing.Size(234, 525);
			this.rtbCounts.TabIndex = 7;
			this.rtbCounts.Text = "";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnClear);
			this.panel3.Controls.Add(this.btnFormat);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(274, 42);
			this.panel3.TabIndex = 5;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(144, 6);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(110, 28);
			this.btnClear.TabIndex = 6;
			this.btnClear.Text = "清空";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnFormat
			// 
			this.btnFormat.Location = new System.Drawing.Point(20, 6);
			this.btnFormat.Name = "btnFormat";
			this.btnFormat.Size = new System.Drawing.Size(110, 28);
			this.btnFormat.TabIndex = 5;
			this.btnFormat.Text = "格式化并统计";
			this.btnFormat.UseVisualStyleBackColor = true;
			this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
			// 
			// rtbCode
			// 
			this.rtbCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.rtbCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbCode.Font = new System.Drawing.Font("Fira Code", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rtbCode.ForeColor = System.Drawing.Color.Gainsboro;
			this.rtbCode.Location = new System.Drawing.Point(274, 49);
			this.rtbCode.Name = "rtbCode";
			this.rtbCode.ReadOnly = true;
			this.rtbCode.Size = new System.Drawing.Size(708, 613);
			this.rtbCode.TabIndex = 8;
			this.rtbCode.Text = "";
			this.rtbCode.TextChanged += new System.EventHandler(this.rtbCode_TextChanged);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 662);
			this.Controls.Add(this.rtbCode);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "FormMain";
			this.Text = "代码格式化与统计";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private Panel panel1;
		private Button btnBrowse;
		private TextBox txtPath;
		private Label label1;
		private Panel panel2;
		private Panel panel3;
		private Button btnFormat;
		private Panel panel4;
		private GroupBox groupBox1;
		private RichTextBox rtbCounts;
		private RichTextBox rtbCode;
		private Button btnClear;
	}
}