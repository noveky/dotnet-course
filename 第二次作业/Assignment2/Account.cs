using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
	class Account
	{
		public string Id
		{
			get => id;
			set
			{
				if (value.Length != 8) throw new Exception("账号只能为 8 位");
				foreach (char ch in value)
				{
					if (!char.IsDigit(ch)) throw new Exception("账号只能为数字");
				}
				id = value;
			}
		}
		public string Passcode
		{
			get => passcode;
			set
			{
				if (value.Length != 6) throw new Exception("密码只能为 6 位");
				foreach (char ch in value)
				{
					if (!char.IsDigit(ch)) throw new Exception("密码只能为数字");
				}
				passcode = value;
			}
		}

		string id = string.Empty;
		string passcode = string.Empty;

		public decimal Balance { get; protected set; }
		
		public Account(string id)
		{
			Id = id;
			Passcode = "000000";
		}

		public override string ToString() => $"{{ 类型: 普通账户, 账号: {Id}, 密码: {Passcode}, 余额: {Balance} }}";

		public void Deposit(decimal amount)
		{
			Balance += amount;
		}

		public virtual bool CanWithdraw(decimal amount)
		{
			return Balance - amount >= 0;
		}

		public void Withdraw(decimal amount)
		{
			if (!CanWithdraw(amount))
			{
				if (this is CreditAccount) throw new Exception("超出信用额度，取款失败");
				else throw new Exception("账户余额不足，取款失败");
			}
			Balance -= amount;
		}
	}
}
