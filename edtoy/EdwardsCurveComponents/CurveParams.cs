using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edtoy.EdwardsCurveComponents
{
	public static class CurveParams
	{
		/// <summary>
		/// エドワーズ曲線のパラメータ a 、平方剰余となる n^(p-1)/2 ≡ 1 mod prime となる n を返す
		/// </summary>
		/// <param name="prime">素数</param>
		/// <returns>平方剰余 n</returns>
		public static IEnumerable<QNumberBigInteger> EnumerateParamA(QNumberBigInteger prime, bool is_random)
		{
			return PrimeHalfExp(prime, is_random, true);
		}

		/// <summary>
		/// エドワーズ曲線のパラメータ d 、非平方剰余となる n^(p-1)/2 ≠ 1 mod prime となる n を返す
		/// 	0,1 をのぞく
		/// </summary>
		/// <param name="prime">素数</param>
		/// <returns>非平方剰余 n</returns>
		public static IEnumerable<QNumberBigInteger> EnumerateParamD(QNumberBigInteger prime, bool is_random)
		{
			return PrimeHalfExp(prime, is_random, false).Where(x => x != 0 && x != 1);
		}

		/// <summary>
		/// 生成する数、ランダム性を正規化する
		/// </summary>
		/// <param name="number">生成数</param>
		/// <param name="random">ランダムか</param>
		/// <param name="prime">素数</param>
		/// <returns></returns>
		public static (QNumberBigInteger, bool) NormalizeMaxNumber(QNumberBigInteger number, bool random, QNumberBigInteger prime)
		{
			if (number < 1)
			{
				number = 1;
				random = false;
			}
			var prime_half = prime >> 1;
			if (number > prime_half)
			{
				random = false;
				number = prime_half;
			}
			return (number, random);
		}

		/// <summary>
		/// n^(p-1)/2 が 1(is_one=true) か -1(is_one=false) となる n を返す
		/// </summary>
		/// <param name="prime">素数</param>
		/// <param name="is_one">true:n^(p-1)/2=1, false:..=-1</param>
		/// <returns>n (1 <= n <= p-1)</returns>
		public static IEnumerable<QNumberBigInteger> PrimeHalfExp(QNumberBigInteger prime, bool is_random, bool is_one)
		{
			QNumberBigInteger p_1_2 = prime >> 1;
			if (is_random)
			{
				QNumberBigInteger p_1 = prime - QNumberBigInteger.One;
				for (QNumberBigInteger i = 1; i < prime; i += 1)
				{
					var r = RandomNumber.GenerateRandomNumber(1, p_1);
					var ans = r.PowMod(p_1_2, prime);
					if ((is_one && ans == 1) || (!is_one && ans != 1))
					{
						yield return r;
					}
				}
			}
			else
			{
				for (QNumberBigInteger i = 1; i < prime; i += 1)
				{
					var ans = i.PowMod(p_1_2, prime);
					if ((is_one && ans == 1) || (!is_one && ans != 1))
					{
						yield return i;
					}
				}
			}
		}

	}
}
