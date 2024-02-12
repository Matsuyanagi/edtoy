using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace edtoy.CommandLineOptions
{
	[Verb("param_a", HelpText = "Edwards Curve param A list.")]
	public class COCurveParamA
	{
		[Option('p', "prime", Required = true, HelpText = "Prime Number.")]
		public string PrimeNumberStr
		{
			set
			{
				QNumberBigInteger p = QNumberBigInteger.Parse(value);
				if (!p.IsPrime)
				{
					throw new ArgumentException($"{p} is not prime number.");
				}
				PrimeNumber = p;
			}
		}
		public QNumberBigInteger PrimeNumber { get; set; }

		[Option('n', "number", Required = false, Default = 100, HelpText = "Max number of list.")]
		public int Number { get; set; }

		[Option('c', "comma", Required = false, Default = false, HelpText = "One line separated by commas.")]
		public bool OutputComma { get; set; }
		[Option('r', "random", Required = false, Default = false, HelpText = "Random number.")]
		public bool Random { get; set; }
	}
}
