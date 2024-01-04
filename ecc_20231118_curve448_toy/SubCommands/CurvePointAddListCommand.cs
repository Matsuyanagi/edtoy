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

			if (option.XPos != null)
			{
				if (option.YPos != null)
				{
					// (XPos,YPos) が曲線上の点かを確認する
					var x = option.XPos.Value;
					// var x2 = x.MulMod(x, prime);
					// var inv_1_dx2 = QNumberBigInteger.One.AddMod(-param_d.MulMod(x2, prime), prime).Recipro(prime);
					// var y2 = QNumberBigInteger.One.AddMod(-x2.MulMod(param_a, prime), prime).MulMod(inv_1_dx2, prime);
					var y2 = CurvePointList.CalcY2FromX(prime, param_a, param_d, x);

					var y = option.YPos.Value;
					if (y2 == y.MulMod(y, prime))
					{
						var point = new AFPoint(x, y);
						PrintAFPoints(point, prime, param_a, param_d, option.Length);
					}
				}
				else
				{
					// 指定された XPos に対応する YPos を求める。求まった YPos 平方剰余でなければ曲線上に点は存在しない。
					// 点が存在しないかもしれない
					var curve_points = CurvePointList.CalcEdwardsCurvePointFromX(prime, param_a, param_d, false, (QNumberBigInteger)option.XPos);
					foreach (var point in curve_points)
					{
						PrintAFPoints(point, prime, param_a, param_d, option.Length);
					}
				}
			}
			else
			{
				// x,y が指定されなかった場合は順番か、ランダムかでベースポイントを選択する
				foreach (var base_point in CurvePointList.EdwardsCurvePointList(prime, param_a, param_d, option.Random).Take(number))
				{
					PrintAFPoints(base_point, prime, param_a, param_d, option.Length);
				}
			}
		}
		/// <summary>
		/// 指定された point 点をベースポイントとして加算した点を出力する
		/// </summary>
		/// <param name="point">エドワーズ曲線上の点</param>
		/// <param name="prime">エドワーズ曲線の素数パラメータ</param>
		/// <param name="param_a">a x^2 + y^2 = 1 + dx^2y^2 の a パラメータ</param>
		/// <param name="param_d">a x^2 + y^2 = 1 + dx^2y^2 の d パラメータ</param>
		/// <param name="length">ベースポイントの最大加算回数</param>
		public static void PrintAFPoints(AFPoint point, QNumberBigInteger prime, QNumberBigInteger param_a, QNumberBigInteger param_d, int length)
		{
			Console.Write($"({point.X},{point.Y}):");
			AFPoint p = point;

			var n = 0;
			while (p != AFPoint.Identity && n < length)
			{
				p = AFPoint.EdwardsCurveAdd(p, point, param_a, param_d, prime);
				Console.Write($"({p.X},{p.Y})");
				n += 1;
			}
			Console.WriteLine(n == length ? "..." : "");
		}

	}
}
