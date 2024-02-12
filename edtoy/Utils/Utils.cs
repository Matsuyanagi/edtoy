using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edtoy.Utils
{
	public static class Util
	{
		public static Int32 BalanceNumberLimit(int number, QNumberBigInteger prime)
		{
			int result_number = 1;
			if (number > 0)
			{
				result_number = number;
			}
			else
			{
				if (prime < 1000)
				{
					result_number = (int)prime;
				}
				else
				{
					result_number = 1000;
				}
			}
			return result_number;
		}
	}
}
