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
	public static class CreatePrimeNumberCommand
	{
		public static void Run(COPrime option)
		{
			var random = new Random();
			var bytes = CreatePrimeNumber.CreateByteBuffer(option.Length);

			for (int i = 0; i < option.Number; i++)
			{
				var prime_number = CreatePrimeNumber.CreateFakePrimeRandomBit(option.Length, option.N4_3, option.N4_1, random, bytes);
				while (!prime_number.IsPrime)
				{
					prime_number = CreatePrimeNumber.CreateFakePrimeRandomBitNextPlus4(option.Length, option.N4_3, option.N4_1, random, bytes, prime_number);
				}
				Console.WriteLine($"{prime_number}", prime_number);
				// Console.WriteLine("0x : {0:X}", prime_number);
				// Console.WriteLine("0x : {0:B}", prime_number);
			}
		}
	}
}
