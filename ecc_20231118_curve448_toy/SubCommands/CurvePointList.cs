using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecc_20231118_curve448_toy.CommandLineOptions;
using ecc_20231118_curve448_toy.Utils;

namespace ecc_20231118_curve448_toy.SubCommands
{
	public static class CurvePointList
	{
		public static void Run(COCurvePointList option)
		{
			QNumberBigInteger prime = option.PrimeNumber;
			QNumberBigInteger param_a = option.ParamA;
			QNumberBigInteger param_d = option.ParamD;
			int number = Util.BalanceNumberLimit(option.Number, prime);
			var list = EdwardsCurvePointList(prime, param_a, param_d).Take(number).ToList();
			foreach (var item in list)
			{
				Console.WriteLine($"({item.X},{item.Y})");
			}
		}

		/// <summary>
		/// エドワーズ曲線の曲線上の点を返す
		/// </summary>
		/// <param name="prime">素数</param>
		/// <param name="param_a">a x^2 + y^2 = 1 + dx^2y^2 の a パラメータ</param>
		/// <param name="param_d">a x^2 + y^2 = 1 + dx^2y^2 の d パラメータ</param>
		/// <returns>曲線上の点 AFPoint(x,y)</returns>
		public static IEnumerable<AFPoint> EdwardsCurvePointList(QNumberBigInteger prime, QNumberBigInteger param_a, QNumberBigInteger param_d)
		{
			for (QNumberBigInteger x = 0; x < prime; x += 1)
			{
				var x2 = x.MulMod(x, prime);
				var inv_1_dx2 = QNumberBigInteger.One.AddMod(-param_d.MulMod(x2, prime), prime).Recipro(prime);
				var y2 = QNumberBigInteger.One.AddMod(-x2.MulMod(param_a, prime), prime).MulMod(inv_1_dx2, prime);
				if (y2.IsSquare(prime) || y2 == QNumberBigInteger.Zero)
				{
					// y^2 が平方剰余なら解として (x, y 平方根) を順に返す。
					if (y2 == QNumberBigInteger.Zero)
					{
						yield return new AFPoint(x, QNumberBigInteger.Zero);
					}
					else
					{
						var sqrt = y2.SqrtPrime(prime);
						if (sqrt.Item1 < sqrt.Item2)
						{
							yield return new AFPoint(x, sqrt.Item1);
							yield return new AFPoint(x, sqrt.Item2);
						}
						else
						{
							yield return new AFPoint(x, sqrt.Item2);
							yield return new AFPoint(x, sqrt.Item1);
						}
					}
				}
				else
				{
					continue;
				}
			}
		}
	}
}
