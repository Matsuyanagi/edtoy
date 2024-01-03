using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecc_20231118_curve448_toy.CommandLineOptions;
using ecc_20231118_curve448_toy.Utils;
using ecc_20231118_curve448_toy.EdwardsCurveComponents;

namespace ecc_20231118_curve448_toy.SubCommands
{
	public static class CurvePointAddListCommand
	{
		public static void Run(COCurvePointAddList option)
		{
			QNumberBigInteger prime = option.PrimeNumber;
			QNumberBigInteger param_a = option.ParamA;
			QNumberBigInteger param_d = option.ParamD;
			int number = Util.BalanceNumberLimit(option.Number, prime);

			foreach (var base_point in CurvePointList.EdwardsCurvePointList(prime, param_a, param_d, option.Random).Take(number))
			{
				Console.Write($"({base_point.X},{base_point.Y}):");
				AFPoint point = base_point;

				var n = 0;
				while (point != AFPoint.Identity && n < option.Length)
				{
					point = AFPoint.EdwardsCurveAdd(point, base_point, param_a, param_d, prime);
					Console.Write($"({point.X},{point.Y})");
					n += 1;
				}
				if (n == option.Length)
				{
					Console.WriteLine("...");
				}
				else
				{
					Console.WriteLine("");
				}
			}
		}
	}
}
