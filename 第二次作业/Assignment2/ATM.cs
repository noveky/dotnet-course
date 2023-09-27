using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
	class ATM
	{
		readonly Bank bank;
		Account? account = null;

		public class BigMoneyArgs
		{
			public decimal Amount { get; set; }
		}
		public event Action<BigMoneyArgs> BigMoneyFetched = _ => { };

		decimal _cash = 10000.00M;
		class OutOfCashException : Exception { }
		class BadCashException : Exception { }
		decimal Cash
		{
			get => _cash;
			set
			{
				if (value < 0)
				{
					throw new OutOfCashException();
				}
				if (value > _cash)
				{
					Random rnd = new();
					if (rnd.NextDouble() < 0.3)
					{
						throw new BadCashException();
					}
				}
				_cash = value;
			}
		}

		public event Action<string> Log = _ => { };

		public ATM(Bank bank)
		{
			this.bank = bank;
		}

		public void Login(string accountId, string passcode)
		{
			if (account != null)
			{
				Logout();
			}

			account = bank.Authenticate(accountId, passcode);

			Log($"账号 {accountId} 登入成功，当前余额为 {account.Balance}");
		}

		public void Logout()
		{
			CheckLogin();

			string accountId = account!.Id;

			account = null;

			Log($"账号 {accountId} 登出成功");
		}

		void CheckLogin()
		{
			if (account == null)
			{
				throw new Exception("没有登录账户，操作失败");
			}
		}

		public void Deposit(decimal amount)
		{
			CheckLogin();

			try
			{
				Cash += amount;
			}
			catch (BadCashException ex)
			{
				throw new Exception("检测到坏钞，存款失败", ex);
			}

			account!.Deposit(amount);

			Log($"{amount} 存款成功，当前余额为 {account.Balance}");
		}

		public void Withdraw(decimal amount)
		{
			CheckLogin();

			if (!account!.CanWithdraw(amount))
			{
				// 调用，使其抛出异常，直接结束
				account.Withdraw(amount);
			}

			try
			{
				Cash -= amount;
			}
			catch (OutOfCashException ex)
			{
				throw new Exception("ATM 机现金不足，取款失败", ex);
			}

			account.Withdraw(amount);

			if (amount > 10000.00M)
			{
				BigMoneyFetched(new() { Amount = amount });
			}

			Log($"{amount} 取款成功，当前余额为 {account.Balance}");
		}
	}
}
