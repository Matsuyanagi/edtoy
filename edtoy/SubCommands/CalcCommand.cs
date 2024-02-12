using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using edtoy;
using edtoy.CommandLineOptions;

namespace edtoy.SubCommands
{
	public static class CalcCommand
	{
		public static void Run(COCalc option)
		{
			QNumberBigInteger result = new(0);
			if (option.Numbers == null)
			{
				Console.WriteLine(0);
			}
			if (option.ModeAdd)
			{
				result = option.Numbers!.Aggregate(QNumberBigInteger.Zero, (r, numberstr) => r.AddMod(QNumberBigInteger.Parse(numberstr), option.PrimeNumber));
			}
			else if (option.ModeSub)
			{
				QNumberBigInteger start = QNumberBigInteger.Parse(option.Numbers!.FirstOrDefault("0")).Mod(option.PrimeNumber);
				result = option.Numbers!.Skip(1).Aggregate(start, (r, numberstr) => r.AddMod(-QNumberBigInteger.Parse(numberstr), option.PrimeNumber));
			}
			else if (option.ModeMul)
			{
				result = option.Numbers!.Aggregate(QNumberBigInteger.One, (r, numberstr) => r.MulMod(QNumberBigInteger.Parse(numberstr), option.PrimeNumber));
			}
			else if (option.ModeDiv)
			{
				QNumberBigInteger start = QNumberBigInteger.Parse(option.Numbers!.FirstOrDefault("1")).Mod(option.PrimeNumber);
				result = option.Numbers!.Skip(1).Aggregate(start, (r, numberstr) => r.DivMod(QNumberBigInteger.Parse(numberstr), option.PrimeNumber));
			}
			else if (option.ModeRecipro)
			{
				result = option.Numbers!.Aggregate(QNumberBigInteger.One, (r, numberstr) => r.MulMod(QNumberBigInteger.Parse(numberstr).Recipro(option.PrimeNumber), option.PrimeNumber));
			}
			else if (option.ModeSqrt)
			{
				string s = "";
				foreach (var item in option.Numbers!)
				{
					QNumberBigInteger q = QNumberBigInteger.Parse(item);
					if (q.IsSquare(option.PrimeNumber))
					{
						var sqrt = q.SqrtPrime(option.PrimeNumber);
						if (sqrt.Item1 == sqrt.Item2)
						{
							s += sqrt.Item1 + "\n";
						}
						else
						{
							s += (sqrt.Item1 <= sqrt.Item2) ? $"{sqrt.Item1}\n{sqrt.Item2}\n" : $"{sqrt.Item2}\n{sqrt.Item1}\n";
						}
					}
				}
				Console.WriteLine(s);
				return;
			}
			Console.WriteLine(result);
		}
	}
}
