using System;
using System.Collections;
using Microsoft.VisualBasic;

namespace Nacha.Core
{
	public abstract class Bank
	{
		internal string routingNumber;
		private const int _RoutingNumberRequiredLength = 9;

		public virtual bool IsValidRoutingNumber()
		{
			if (!Information.IsNumeric(routingNumber))
				return false;

			if (Convert.ToInt64(routingNumber) <= 0)
				return false;

			if (routingNumber.Length != _RoutingNumberRequiredLength)
				return false;

			var routingNumArray = new ArrayList();
			foreach (var c in routingNumber)
				routingNumArray.Add(Convert.ToInt32(c));

			if (routingNumArray.Count != _RoutingNumberRequiredLength)
				return false;

			var lastDigitIndex = routingNumArray.Count - 1;
			var expectedChecksum = (int) routingNumArray[lastDigitIndex];
			routingNumArray.RemoveAt(lastDigitIndex);

			var sum = 7 * ((int)routingNumArray[0] + (int)routingNumArray[3] + (int)routingNumArray[6]) +
			          3 * ((int)routingNumArray[1] + (int)routingNumArray[4] + (int)routingNumArray[7]) +
			          9 * ((int)routingNumArray[2] + (int)routingNumArray[5]);

			var actualChecksum = sum%10;

			return expectedChecksum == actualChecksum;
		}
	}
}
