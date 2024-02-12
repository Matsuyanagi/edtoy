using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using edtoy.CommandLineOptions;
using edtoy.EdwardsCurveComponents;

namespace edtoy.SubCommands
{
	public static class RandomNumberCommand
	{
		public static void Run(CORandomNumber option)
		{
			QNumberBigInteger upper_number = option.UpperNumber;
			QNumberBigInteger lower_number = option.LowerNumber;
			int number = option.Number;

			if (option.OutputComma)
			{
				bool first = true;
				for (int i = 0; i < number; i++)
				{
					QNumberBigInteger r = RandomNumber.GenerateRandomNumber(lower_number, upper_number);
					if (first)
					{
						first = false;
					}
					else
					{
						Console.Write(",");
					}
					Console.Write(r);
				}
				Console.WriteLine("");
			}
			else
			{
				for (int i = 0; i < number; i++)
				{
					QNumberBigInteger r = RandomNumber.GenerateRandomNumber(lower_number, upper_number);
					Console.WriteLine(r);
				}
			}

		}
	}
}
