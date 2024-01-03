﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace ecc_20231118_curve448_toy.CommandLineOptions
{
	[Verb("curvepoint_add", HelpText = "Edwards Curve point add list.")]
	public class COCurvePointAddList
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

		[Option('a', "param_a", Required = true, HelpText = "Edwards Curve param 'a'.")]
		public string ParamAStr { set { ParamA = QNumberBigInteger.Parse(value); } }
		public QNumberBigInteger ParamA { get; set; }

		[Option('d', "param_d", Required = true, HelpText = "Edwards Curve param 'd'.")]
		public string ParamDStr { set { ParamD = QNumberBigInteger.Parse(value); } }
		public QNumberBigInteger ParamD { get; set; }

		[Option('n', "number", Required = false, Default = 100, HelpText = "Max number of list.")]
		public int Number { get; set; }

		[Option('l', "length", Required = false, Default = 100, HelpText = "Max length of adding list.")]
		public int Length { get; set; }

		[Option('r', "random", Required = false, Default = false, HelpText = "Random curvepoint.")]
		public bool Random { get; set; }

	}
}
