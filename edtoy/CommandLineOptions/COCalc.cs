using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace edtoy.CommandLineOptions
{
	[Verb("calc", HelpText = "Calculate prime numbers.")]
	public class COCalc
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
		[Option('a', "add", Required = false, HelpText = "Add and mod prime.")]
		public bool ModeAdd { get; set; }
		[Option('s', "sub", Required = false, HelpText = "Subtract and mod prime.")]
		public bool ModeSub { get; set; }
		[Option('m', "mul", Required = false, HelpText = "Multiply and mod prime.")]
		public bool ModeMul { get; set; }
		[Option('d', "div", Required = false, HelpText = "Div and mod prime.")]
		public bool ModeDiv { get; set; }
		[Option('r', "recipro", Required = false, HelpText = "Recipro mod prime.")]
		public bool ModeRecipro { get; set; }
		[Option('q', "sqrt", Required = false, HelpText = "Sqrt mod prime.")]
		public bool ModeSqrt { get; set; }
		[Value(1, MetaName = "Numbers", Required = true)]
		public IEnumerable<string> Numbers { get; set; } = new List<string>();
	}
}
