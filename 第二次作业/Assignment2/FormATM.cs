using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Assignment2
{
	public partial class FormATM : Form
	{
		readonly ATM atm;

		public FormATM()
		{
			InitializeComponent();

			Bank bank = new();
			List<Account> accounts = new()
			{
				bank.Signup("10001001", "123456"),
				bank.Signup("10001002", "666666"),
				bank.Signup("10002005", "456123", true),
			};
			accounts[0].Deposit(5000.00M);
			accounts[1].Deposit(4000.00M);
			accounts[2].Deposit(2000.00M);

			Log("初始账户：[", Color.Gray);
			accounts.ForEach(a => Log($"{a},", Color.Gray));
			Log("]", Color.Gray);

			atm = new(bank);

			atm.BigMoneyFetched += args => LogWarning($"进行了 {args.Amount} 的大额取款");
			atm.Log += text => Log(text);
		}

		bool Try(Action action)
		{
			try
			{
				action();
				return true;
			}
			catch (Exception ex)
			{
				LogError(ex);
				return false;
			}
			finally
			{
				Console.WriteLine();
			}
		}

		void Log(string text, Color? color = null)
		{
			int lLength = txtOutput.TextLength;

			if (txtOutput.Text.Length != 0)
			{
				txtOutput.AppendText("\n");
			}
			txtOutput.AppendText(text.Trim());

			if (color != null)
			{
				txtOutput.SelectionStart = lLength;
				txtOutput.SelectionLength = txtOutput.TextLength - lLength;
				txtOutput.SelectionColor = (Color)color;
			}

			txtOutput.SelectionStart = txtOutput.TextLength;
			txtOutput.SelectionLength = 0;
			txtOutput.ScrollToCaret();
		}

		public void LogError(Exception ex) { Log($"错误：{ex.Message}", Color.Red); }

		public void LogWarning(string text) { Log($"警告：{text}", Color.DarkMagenta); }

		private void btnLogin_Click(object sender, EventArgs e)
		{
			Try(() => atm.Login(txtAccountId.Text.Trim(), txtPasscode.Text.Trim()));
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			Try(atm.Logout);
		}

		decimal Amount => decimal.Parse(txtAmount.Text);

		private void btnDeposit_Click(object sender, EventArgs e)
		{
			Try(() => atm.Deposit(Amount));
		}

		private void btnWithdraw_Click(object sender, EventArgs e)
		{
			Try(() => atm.Withdraw(Amount));
		}
	}
}