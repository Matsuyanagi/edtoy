using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecc_20231118_curve448_toy;

namespace Tests
{
	internal class AFPointTest
	{
		[TestCase(0, 1, "(0,1)")]
		[TestCase(0, 2, "(0,2)")]
		[TestCase(-1, -100, "(-1,-100)")]
		public void TestEqualString(Int64 x, Int64 y, string s)
		{
			Assert.That((new AFPoint(x, y)).ToString(), Is.EqualTo(s));
		}

	}
}
