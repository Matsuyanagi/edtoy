using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

using ecc_20231118_curve448_toy.CommandLineOptions;
using ecc_20231118_curve448_toy.EdwardsCurveComponents;

namespace ecc_20231118_curve448_toy.SubCommands
{
	public static class CreateCurveParamCommand
	{
		/// <summary>
		/// ax^2+y^2 = 1-dx^2y^2 の パラメータ a の候補をリストアップする
		/// 素数 PrimeNumber における平方剰余
		/// </summary>
		/// <param name="option">コマンドライン引数</param>
		public static void CreateParamA(COCurveParamA option)
		{
			var prime = new QNumberBigInteger(option.PrimeNumber);

			if (option.OutputComma)
			{
				Console.WriteLine(String.Join(',', CurveParams.EnumerateParamA(prime, option.Random).Take(option.Number)));
			}
			else
			{
				foreach (var item in CurveParams.EnumerateParamA(prime, option.Random).Take(option.Number))
				{
					Console.WriteLine(item);
				}
			}
		}

		/// <summary>
		/// ax^2+y^2 = 1-dx^2y^2 の パラメータ d の候補をリストアップする
		/// 素数 PrimeNumber における非平方剰余
		/// </summary>
		/// <param name="option">コマンドライン引数</param>
		public static void CreateParamD(COCurveParamD option)
		{
			var prime = new QNumberBigInteger(option.PrimeNumber);

			if (option.OutputComma)
			{
				Console.WriteLine(String.Join(',', CurveParams.EnumerateParamD(prime, option.Random).Take(option.Number)));
			}
			else
			{
				foreach (var item in CurveParams.EnumerateParamD(prime, option.Random).Take(option.Number))
				{
					Console.WriteLine(item);
				}
			}
		}
	}
}
