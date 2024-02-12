using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edtoy.EdwardsCurveComponents
{
	public static class CurvePointList
	{
		/// <summary>
		/// エドワーズ曲線の曲線上の点を返す
		/// </summary>
		/// <param name="prime">エドワーズ曲線の素数パラメータ</param>
		/// <param name="param_a">a x^2 + y^2 = 1 + dx^2y^2 の a パラメータ</param>
		/// <param name="param_d">a x^2 + y^2 = 1 + dx^2y^2 の d パラメータ</param>
		/// <param name="is_random">true なら x をランダムに選ぶ。重複あり。false なら x=0～p-1 までを順に列挙する</param>
		/// <returns>曲線上の点 AFPoint(x,y)</returns>
		public static IEnumerable<AFPoint> EdwardsCurvePointList(QNumberBigInteger prime, QNumberBigInteger param_a, QNumberBigInteger param_d, bool is_random)
		{
			QNumberBigInteger x;
			QNumberBigInteger p_1 = prime - 1;
			for (QNumberBigInteger i = 0; i < prime; i += 1)
			{
				x = is_random ? RandomNumber.GenerateRandomNumber(QNumberBigInteger.One, p_1) : i;
				foreach (var pos in CalcEdwardsCurvePointFromX(prime, param_a, param_d, is_random, x))
				{
					yield return pos;
				}
			}
		}

		/// <summary>
		/// エドワーズ曲線上で、x に対応する点を AFPoint 配列で返す。要素は 0,1,2個
		/// </summary>
		/// <param name="prime">エドワーズ曲線の素数</param>
		/// <param name="param_a">エドワーズ曲線の a パラメータ</param>
		/// <param name="param_d">エドワーズ曲線の d パラメータ</param>
		/// <param name="is_y_only_one">true なら √y^2 のうち、小さい方を1つだけ返す</param>
		/// <param name="x">エドワーズ曲線曲線上の求める点の x 座標</param>
		/// <returns>エドワーズ曲線上の x を指定した点 AFPoint(x,y) の配列。対応する点がなければ空配列</returns>
		public static List<AFPoint> CalcEdwardsCurvePointFromX(QNumberBigInteger prime, QNumberBigInteger param_a, QNumberBigInteger param_d, bool is_y_only_one, QNumberBigInteger x)
		{
			List<AFPoint> result = [];
			var y2 = CalcY2FromX(prime, param_a, param_d, x);
			if (y2.IsSquare(prime) || y2.IsZero)
			{
				// y^2 が平方剰余なら解として (x, y 平方根) を順に返す。
				if (y2.IsZero)
				{
					// y^2 = 0 なら y=0 の重根なので1つだけ出力
					result.Add(new AFPoint(x, QNumberBigInteger.Zero));
				}
				else
				{
					// ±sqrt(y) を 小→大 の順で出力する
					// is_y_only_one=trueの場合は ±sqrt(y) のうち、小さい方を1つだけ出力する
					var sqrt = y2.SqrtPrime(prime);
					if (sqrt.Item1 < sqrt.Item2)
					{
						result.Add(new AFPoint(x, sqrt.Item1));
						if (!is_y_only_one)
						{
							result.Add(new AFPoint(x, sqrt.Item2));
						}
					}
					else
					{
						result.Add(new AFPoint(x, sqrt.Item2));
						if (!is_y_only_one)
						{
							result.Add(new AFPoint(x, sqrt.Item1));
						}
					}
				}
			}
			return result;
		}
		public static QNumberBigInteger CalcY2FromX(QNumberBigInteger prime, QNumberBigInteger param_a, QNumberBigInteger param_d, QNumberBigInteger x)
		{
			var x2 = x.MulMod(x, prime);
			var inv_1_dx2 = QNumberBigInteger.One.AddMod(-param_d.MulMod(x2, prime), prime).Recipro(prime);
			var y2 = QNumberBigInteger.One.AddMod(-x2.MulMod(param_a, prime), prime).MulMod(inv_1_dx2, prime);
			return y2;
		}
	}
}
