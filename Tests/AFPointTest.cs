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
			Assert.That(new AFPoint(x, y).ToString(), Is.EqualTo(s));
		}

		[TestCase(7, 31, 2, 47, 25, 17, 44)]
		public void TestEdPoint(Int64 x, Int64 y, Int64 d, Int64 prime, Int64 add1_x, Int64 add1_y, Int64 ans_order)
		{
			var base_point = new EHPoint3(x, y, 1);
			// var p = EHPoint3.Identity;
			var p = base_point;
			var afp = AFPoint.Identity;
			var order = 1;

			for (int i = 0; i < prime * 2; i++)
			{
				p = EHPoint3.EdwardsCurveAdd(p, base_point, d, prime);
				afp = p.ToAFPoint(prime);

				if (i == 0)
				{
					// Assert.That(afp, Is.EqualTo(new AFPoint(add1_x, add1_y)));
				}
				if (afp == AFPoint.Identity)
				{
					break;
				}
				order += 1;
			}
			Assert.That(order, Is.EqualTo(ans_order));
		}




	}
}
