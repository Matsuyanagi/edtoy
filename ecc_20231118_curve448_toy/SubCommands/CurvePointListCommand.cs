using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecc_20231118_curve448_toy.CommandLineOptions;
using ecc_20231118_curve448_toy.EdwardsCurveComponents;
using ecc_20231118_curve448_toy.Utils;

namespace ecc_20231118_curve448_toy.SubCommands
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
