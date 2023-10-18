namespace Assignment2
{
	partial class FormATM
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnLogout = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.txtPasscode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtAccountId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnWithdraw = new System.Windows.Forms.Button();
			this.btnDeposit = new System.Windows.Forms.Button();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtOutput = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnLogout);
			this.groupBox1.Controls.Add(this.btnLogin);
			this.groupBox1.Controls.Add(this.txtPasscode);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtAccountId);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 144);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "账户验证";
			// 
			// btnLogout
			// 
			this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLogout.Location = new System.Drawing.Point(104, 99);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(81, 28);
			this.btnLogout.TabIndex = 4;
			this.btnLogout.Text = "登出";
			this.btnLogout.UseVisualStyleBackColor = true;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnLogin.Location = new System.Drawing.Point(15, 99);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(81, 28);
			this.btnLogin.TabIndex = 3;
			this.btnLogin.Text = "登入";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// txtPasscode
			// 
			this.txtPasscode.Location = new System.Drawing.Point(70, 63);
			this.txtPasscode.Name = "txtPasscode";
			this.txtPasscode.Size = new System.Drawing.Size(112, 23);
			this.txtPasscode.TabIndex = 2;
			this.txtPasscode.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "密码：";
			// 
			// txtAccountId
			// 
			this.txtAccountId.Location = new System.Drawing.Point(70, 28);
			this.txtAccountId.Name = "txtAccountId";
			this.txtAccountId.Size = new System.Drawing.Size(112, 23);
			this.txtAccountId.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "账号：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnWithdraw);
			this.groupBox2.Controls.Add(this.btnDeposit);
			this.groupBox2.Controls.Add(this.txtAmount);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(12, 175);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 111);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "存取款";
			// 
			// btnWithdraw
			// 
			this.btnWithdraw.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnWithdraw.Location = new System.Drawing.Point(104, 65);
			this.btnWithdraw.Name = "btnWithdraw";
			this.btnWithdraw.Size = new System.Drawing.Size(81, 28);
			this.btnWithdraw.TabIndex = 3;
			this.btnWithdraw.Text = "取款";
			this.btnWithdraw.UseVisualStyleBackColor = true;
			this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
			// 
			// btnDeposit
			// 
			this.btnDeposit.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnDeposit.Location = new System.Drawing.Point(15, 65);
			this.btnDeposit.Name = "btnDeposit";
			this.btnDeposit.Size = new System.Drawing.Size(81, 28);
			this.btnDeposit.TabIndex = 2;
			this.btnDeposit.Text = "存款";
			this.btnDeposit.UseVisualStyleBackColor = true;
			this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
			// 
			// txtAmount
			// 
			this.txtAmount.Location = new System.Drawing.Point(70, 29);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(112, 23);
			this.txtAmount.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "金额：";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Location = new System.Drawing.Point(218, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(517, 274);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "输出";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtOutput);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 19);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(511, 252);
			this.panel1.TabIndex = 0;
			// 
			// txtOutput
			// 
			this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Location = new System.Drawing.Point(10, 10);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Size = new System.Drawing.Size(491, 232);
			this.txtOutput.TabIndex = 1;
			this.txtOutput.Text = "";
			// 
			// FormATM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 298);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormATM";
			this.Text = "自动提款机";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private GroupBox groupBox1;
		private TextBox txtAccountId;
		private Label label1;
		private TextBox txtPasscode;
		private Label label2;
		private Button btnLogin;
		private Button btnLogout;
		private GroupBox groupBox2;
		private Button btnWithdraw;
		private Button btnDeposit;
		private TextBox txtAmount;
		private Label label4;
		private GroupBox groupBox3;
		private Panel panel1;
		private RichTextBox txtOutput;
	}
}