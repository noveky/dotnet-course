using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
	class Bank
	{
		readonly List<Account> accounts = new();

		public Bank() { }

		public Account Signup(string accountId, string passcode, bool isCredit = false)
		{
			Account account = isCredit ?
				new CreditAccount(accountId, 5000.00M) { Passcode = passcode } :
				new Account(accountId) { Passcode = passcode };
			accounts.Add(account);
			return account;
		}

		public Account Authenticate(string accountId, string passcode)
		{
			foreach (Account account in accounts)
			{
				if (account.Id == accountId)
				{
					if (account.Passcode == passcode) return account;
					throw new Exception("密码错误，验证失败");
				}
			}
			throw new Exception("账号不存在，验证失败");
		}
	}
}
