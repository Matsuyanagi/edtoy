using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace ecc_20231118_curve448_toy.CommandLineOptions
{
	[Verb("prime", HelpText = "Create prime numbers.")]
	public class COPrime
	{
		[Option('l', "length", Required = true, Default = 32, HelpText = "Bit Length(>10)")]
		public int Length { get; set; }

		[Option('n', "number", Required = false, Default = 1, HelpText = "Number of primes")]
		public int Number { get; set; }

		[Option('s', "strong", Required = false, Default = false, HelpText = "Strong Prime (4n+3)")]
		public bool Strong { get; set; }

		[Option("n4_3", Required = false, Default = false, HelpText = "4n+3 type")]
		public bool N4_3 { get; set; }

		[Option("n4_1", Required = false, Default = false, HelpText = "4n+1 type")]
		public bool N4_1 { get; set; }

	}
}
