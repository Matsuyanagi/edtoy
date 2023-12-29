using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using ecc_20231118_curve448_toy.CommandLineOptions;
using ecc_20231118_curve448_toy.EdwardsCurveComponents;

namespace ecc_20231118_curve448_toy.SubCommands
{
	public static class SmallPrimesCommand
	{

		public static void Run(COSmallPrime option)
		{
			// 素数リスト作成
			var prime_number_list = SmallPrimeNumber.SmallPrimeNumberList().ToList();
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
