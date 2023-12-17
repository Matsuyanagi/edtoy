using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ecc_20231118_curve448_toy.SubCommands
{
	public static class SmallPrimes
	{
		private static readonly List<Int32> small_prime_256 = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251];
		// 65536 までの素数を列挙する
		public static List<Int32> SmallPrimeNumberList()
		{
			// 素数リスト
			List<Int32> prime_numbers = new(7000);
			// エラトステネスの篩バッファ。合成数にフラグを立てる。0で初期化する。
			List<UInt64> eratosthenes_buffer = new(65536 / 64);
			for (int i = 0; i < eratosthenes_buffer.Capacity; i++)
			{
				eratosthenes_buffer.Add(0UL);
			}

			// small_prime_256 の 256 までの素数でエラトステネスの篩バッファに合成数フラグを立てる
			foreach (var prime in small_prime_256)
			{
				int p = prime;
				bool first = true;
				while (p < 65536)
				{
					if (first)
					{
						// 素数の初回は素数としてスキップ
						first = false;
					}
					else
					{
						// 素数の倍数は合成数フラグを立てる
						// 	eratosthenes_buffer Int64 64bit のどの要素のどのビットにあたるかを求める
						int array_index = p >> 6;
						int bit_offset = p & ((1 << 6) - 1);
						// 合成数フラグを立てる
						eratosthenes_buffer[array_index] |= 1UL << bit_offset;
					}
					p += prime;
				}
			}
			// 0,1 は素数として数えて欲しくないので合成数フラグを立てる
			eratosthenes_buffer[0] |= 3UL;

			// 合成数フラグを反転させて、素数フラグとして利用する。
			int offset = 0;
			foreach (var e in eratosthenes_buffer)
			{
				var pe = ~e;
				while (pe != 0)
				{
					// 配列全体のビット番号から素数として prime_numbers へ格納する
					var bn = BitOperations.TrailingZeroCount(pe);
					prime_numbers.Add(bn + offset);
					pe &= ~(1UL << bn);
				}
				offset += 64;
			}

			return prime_numbers;
		}
	}
}
