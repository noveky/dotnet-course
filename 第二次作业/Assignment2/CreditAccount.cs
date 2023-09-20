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

		public override void Withdraw(decimal amount)
		{
			if (Balance - amount < -CreditLimit)
			{
				throw new Exception("超出信用额度，取款失败");
			}
			Balance -= amount;
		}
	}
}
