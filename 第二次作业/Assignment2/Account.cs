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
				if (value.Length != 8) throw new Exception("账号只能为8位");
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
				if (value.Length != 6) throw new Exception("密码只能为6位");
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

		public void Deposit(decimal amount)
		{
			Balance += amount;
		}

		public virtual void Withdraw(decimal amount)
		{
			if (Balance - amount < 0)
			{
				throw new Exception("余额不足，取款失败");
			}
			Balance -= amount;
		}
	}
}
