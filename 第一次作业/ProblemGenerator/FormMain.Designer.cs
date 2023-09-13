namespace ProblemGenerator
{
	partial class FormMain
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tmrProblem = new System.Windows.Forms.Timer(this.components);
			this.tmrResult = new System.Windows.Forms.Timer(this.components);
			this.tabProblem = new System.Windows.Forms.TableLayoutPanel();
			this.lblProblem = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnNext = new System.Windows.Forms.Button();
			this.lblProgress = new System.Windows.Forms.Label();
			this.lblCountdown = new System.Windows.Forms.Label();
			this.txtAnswer = new System.Windows.Forms.TextBox();
			this.tabProblem.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrProblem
			// 
			this.tmrProblem.Tick += new System.EventHandler(this.tmrProblem_Tick);
			// 
			// tmrResult
			// 
			this.tmrResult.Tick += new System.EventHandler(this.tmrResult_Tick);
			// 
			// tabProblem
			// 
			this.tabProblem.AutoSize = true;
			this.tabProblem.ColumnCount = 1;
			this.tabProblem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tabProblem.Controls.Add(this.lblProblem, 0, 1);
			this.tabProblem.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tabProblem.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tabProblem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabProblem.Location = new System.Drawing.Point(0, 0);
			this.tabProblem.Name = "tabProblem";
			this.tabProblem.RowCount = 4;
			this.tabProblem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tabProblem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tabProblem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tabProblem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tabProblem.Size = new System.Drawing.Size(519, 313);
			this.tabProblem.TabIndex = 1;
			// 
			// lblProblem
			// 
			this.lblProblem.AutoSize = true;
			this.lblProblem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblProblem.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblProblem.Location = new System.Drawing.Point(3, 60);
			this.lblProblem.Name = "lblProblem";
			this.lblProblem.Size = new System.Drawing.Size(513, 106);
			this.lblProblem.TabIndex = 0;
			this.lblProblem.Text = "96 - 5";
			this.lblProblem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 169);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(513, 100);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.txtAnswer);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(259, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(251, 99);
			this.panel1.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(250, 105);
			this.label2.TabIndex = 0;
			this.label2.Text = "=";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel3.Controls.Add(this.btnNext, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.lblProgress, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.lblCountdown, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(513, 54);
			this.tableLayoutPanel3.TabIndex = 2;
			// 
			// btnNext
			// 
			this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnNext.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnNext.Location = new System.Drawing.Point(365, 3);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(145, 48);
			this.btnNext.TabIndex = 5;
			this.btnNext.Text = "下一题";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// lblProgress
			// 
			this.lblProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblProgress.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblProgress.Location = new System.Drawing.Point(184, 0);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(175, 54);
			this.lblProgress.TabIndex = 4;
			this.lblProgress.Text = "题目：4/10";
			this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCountdown
			// 
			this.lblCountdown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCountdown.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblCountdown.Location = new System.Drawing.Point(3, 0);
			this.lblCountdown.Name = "lblCountdown";
			this.lblCountdown.Size = new System.Drawing.Size(175, 54);
			this.lblCountdown.TabIndex = 0;
			this.lblCountdown.Text = "倒计时：6";
			this.lblCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAnswer
			// 
			this.txtAnswer.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtAnswer.Font = new System.Drawing.Font("微软雅黑", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtAnswer.Location = new System.Drawing.Point(0, 4);
			this.txtAnswer.Name = "txtAnswer";
			this.txtAnswer.Size = new System.Drawing.Size(146, 92);
			this.txtAnswer.TabIndex = 8;
			this.txtAnswer.Text = "91";
			this.txtAnswer.TextChanged += new System.EventHandler(this.txtAnswer_TextChanged);
			// 
			// FormMain
			// 
			this.AcceptButton = this.btnNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(519, 313);
			this.Controls.Add(this.tabProblem);
			this.Name = "FormMain";
			this.Text = "自动出题机";
			this.tabProblem.ResumeLayout(false);
			this.tabProblem.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer tmrProblem;
		private System.Windows.Forms.Timer tmrResult;
		private System.Windows.Forms.TableLayoutPanel tabProblem;
		private System.Windows.Forms.Label lblProblem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label lblCountdown;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.TextBox txtAnswer;
	}
}

