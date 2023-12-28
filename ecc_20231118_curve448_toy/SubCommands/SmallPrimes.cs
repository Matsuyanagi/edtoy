using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using ecc_20231118_curve448_toy.CommandLineOptions;

namespace ecc_20231118_curve448_toy.SubCommands
{
	public static class SmallPrimes
	{
		private static readonly List<Int32> small_prime_256 = [3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251];
		// 65536 までの素数を列挙する
		public static IEnumerable<Int32> SmallPrimeNumberList()
		{
			// エラトステネスの篩バッファ。合成数にフラグを立てる。0で初期化する。
			const int ERATOSTHENES_BUFFER_SIZE = 65536 / 2 / 64;        // 奇数に対応するビットだけ
			List<UInt64> eratosthenes_buffer = new(ERATOSTHENES_BUFFER_SIZE);
			for (int i = 0; i < eratosthenes_buffer.Capacity; i++)
			{
				eratosthenes_buffer.Add(0UL);
			}

			// small_prime_256 の 256 までの素数でエラトステネスの篩バッファに合成数フラグを立てる
			//	偶数ビットを省略して、奇数ビットだけ(eratosthenes_buffer バッファはその半分)
			const int bit_mask = (1 << 6) - 1;
			foreach (var prime in small_prime_256)
			{
				int pbitpos = (prime >> 1) + prime;   // 初期ビット位置。(prime >> 1) は素数の位置、(+prime)は最初の合成数の位置
				while (pbitpos < ERATOSTHENES_BUFFER_SIZE * sizeof(UInt64) * 8)
				{
					// 素数の倍数は合成数フラグを立てる
					// 	eratosthenes_buffer Int64 64bit のどの要素のどのビットにあたるかを求める
					int array_index = pbitpos >> 6;
					int bit_offset = pbitpos & bit_mask;
					// 合成数フラグを立てる
					eratosthenes_buffer[array_index] |= 1UL << bit_offset;
					pbitpos += prime;
				}
			}
			// 1 は素数として数えて欲しくないので合成数フラグを立てる
			eratosthenes_buffer[0] |= 1UL;

			// 最初の素数 2
			yield return 2;
			
			// 合成数フラグを反転させて、素数フラグとして利用する。
			int offset = 1; // 奇数としての末尾 1 をすでに足しておく
			foreach (var e in eratosthenes_buffer)
			{
				var pe = ~e;
				while (pe != 0)
				{
					// 配列全体のビット番号から素数として prime_numbers へ格納する
					var bn = BitOperations.TrailingZeroCount(pe);
					yield return bn * 2 + offset;
					pe &= ~(1UL << bn);
				}
				offset += 128;
			}
		}

		public static void Run(COSmallPrime option)
		{
			// 素数リスト作成
			var prime_number_list = SmallPrimeNumberList().ToList();
			var start_index = 0;
			var end_index = prime_number_list.Count;
			if (option.Length > 0)
			{
				// 素数リストの一部、ビット数が一致する部分を出力
				int n = option.Length;

				start_index = prime_number_list.BinarySearch(1 << (n - 1));
				if (start_index < 0)
				{
					start_index = ~start_index;
				}
				end_index = prime_number_list.BinarySearch(1 << n);
				if (end_index < 0)
				{
					end_index = ~end_index;
				}
			}
			// 素数リストを出力
			var number = option.Number;
			for (int i = start_index; i < end_index; i++)
			{
				if (number >= 0)
				{
					if (number == 0)
					{
						break;
					}
					number -= 1;
				}
				Console.WriteLine(prime_number_list[i]);
			}
		}
	}
}
