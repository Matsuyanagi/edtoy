using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace ecc_20231118_curve448_toy.CommandLineOptions
{
	[Verb("smallprime", HelpText = "Small prime number list (<65536)")]
	public class COSmallPrime
	{
		[Option('l', "length", Default = 0, Required = false, HelpText = "Bit Length")]
		public int Length { get; set; }

		[Option('n', "number", Default = -1, HelpText = "Number of prime number.")]
		public int Number { get; set; }
	}
}
