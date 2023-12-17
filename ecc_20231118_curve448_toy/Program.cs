using CommandLine;
using ecc_20231118_curve448_toy.CommandLineOptions;
using ecc_20231118_curve448_toy.SubCommands;

namespace ecc_20231118_curve448_toy
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<COPrime, COSmallPrime>(args)
				.WithParsed<COPrime>(opt => { })
				.WithParsed<COSmallPrime>(opt => { SmallPrimes.Run(opt); })
				.WithNotParsed(err => { });
		}
	}
}
