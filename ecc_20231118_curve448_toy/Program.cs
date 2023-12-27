using CommandLine;
using ecc_20231118_curve448_toy.CommandLineOptions;
using ecc_20231118_curve448_toy.SubCommands;

namespace ecc_20231118_curve448_toy
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Parser.Default.ParseArguments<COPrime, COSmallPrime, COCurveParamA, COCurveParamD>(args)
					.WithParsed<COPrime>(CreatePrimeNumber.Run)
					.WithParsed<COSmallPrime>(SmallPrimes.Run)
					.WithParsed<COCurveParamA>(CreateCurveParam.CreateParamA)
					.WithParsed<COCurveParamD>(CreateCurveParam.CreateParamD)
					.WithNotParsed(err => { });
			}
			catch (Exception e)
			{
				Console.Error.WriteLine( $"Error : {e.Message}" );
			}
		}
	}
}
