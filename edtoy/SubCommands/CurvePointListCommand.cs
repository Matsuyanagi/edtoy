using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edtoy.CommandLineOptions;
using edtoy.EdwardsCurveComponents;
using edtoy.Utils;

namespace edtoy.SubCommands
{
    public static class CurvePointListCommand
	{
		public static void Run(COCurvePointList option)
		{
			QNumberBigInteger prime = option.PrimeNumber;
			QNumberBigInteger param_a = option.ParamA;
			QNumberBigInteger param_d = option.ParamD;
			int number = Util.BalanceNumberLimit(option.Number, prime);
			var list = CurvePointList.EdwardsCurvePointList(prime, param_a, param_d, option.Random).Take(number).ToList();
			foreach (var item in list)
			{
				Console.WriteLine($"({item.X},{item.Y})");
			}
		}
	}
}
