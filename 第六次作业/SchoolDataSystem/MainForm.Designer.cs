namespace SchoolDataSystem
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
			this.lstStudents = new System.Windows.Forms.ListView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lstClasses = new System.Windows.Forms.ListView();
			this.cboSchools = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstStudents
			// 
			this.lstStudents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstStudents.Location = new System.Drawing.Point(0, 0);
			this.lstStudents.Name = "lstStudents";
			this.lstStudents.Size = new System.Drawing.Size(523, 475);
			this.lstStudents.TabIndex = 0;
			this.lstStudents.UseCompatibleStateImageBehavior = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(12, 43);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lstClasses);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lstStudents);
			this.splitContainer1.Size = new System.Drawing.Size(790, 475);
			this.splitContainer1.SplitterDistance = 263;
			this.splitContainer1.TabIndex = 4;
			// 
			// lstClasses
			// 
			this.lstClasses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstClasses.Location = new System.Drawing.Point(0, 0);
			this.lstClasses.Name = "lstClasses";
			this.lstClasses.Size = new System.Drawing.Size(263, 475);
			this.lstClasses.TabIndex = 0;
			this.lstClasses.UseCompatibleStateImageBehavior = false;
			// 
			// cboSchools
			// 
			this.cboSchools.FormattingEnabled = true;
			this.cboSchools.Location = new System.Drawing.Point(12, 12);
			this.cboSchools.Name = "cboSchools";
			this.cboSchools.Size = new System.Drawing.Size(790, 25);
			this.cboSchools.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 530);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.cboSchools);
			this.Name = "MainForm";
			this.Text = "学生管理系统";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ListView lstStudents;
		private SplitContainer splitContainer1;
		private ListView lstClasses;
		private ComboBox cboSchools;
	}
}