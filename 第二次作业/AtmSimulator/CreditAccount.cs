using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
	class CreditAccount : Account
	{
		public decimal CreditLimit { get; set; }

		public CreditAccount(string id, decimal creditLimit) : base(id)
		{
			CreditLimit = creditLimit;
		}
		public override string ToString() => $"{{ 类型: 信用账户, 账号: {Id}, 密码: {Passcode}, 余额: {Balance}, 信用额度: {CreditLimit} }}";

		public override bool CanWithdraw(decimal amount)
		{
			return Balance - amount >= -CreditLimit;
		}
	}
}
