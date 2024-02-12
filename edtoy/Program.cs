using CommandLine;
using edtoy.CommandLineOptions;
using edtoy.SubCommands;

namespace edtoy
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Parser.Default.ParseArguments<COPrime, COSmallPrime, COCurveParamA, COCurveParamD, COCurvePointList, COCurvePointAddList, CORandomNumber, COCalc>(args)
					.WithParsed<COPrime>(CreatePrimeNumberCommand.Run)
					.WithParsed<COSmallPrime>(SmallPrimesCommand.Run)
					.WithParsed<COCurveParamA>(CreateCurveParamCommand.CreateParamA)
					.WithParsed<COCurveParamD>(CreateCurveParamCommand.CreateParamD)
					.WithParsed<COCurvePointList>(CurvePointListCommand.Run)
					.WithParsed<COCurvePointAddList>(CurvePointAddListCommand.Run)
					.WithParsed<CORandomNumber>(RandomNumberCommand.Run)
					.WithParsed<COCalc>(CalcCommand.Run)
					.WithNotParsed(err => { });
			}
			catch (Exception e)
			{
				Console.Error.WriteLine($"Error : {e.Message}");
			}
		}
	}
}
