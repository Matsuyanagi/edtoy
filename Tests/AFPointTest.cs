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

		[TestCase(7, 31, 5, 47, 25, 17, 44)]
		[TestCase(8, 6, 5, 47, 16, 7, 44)]
		[TestCase(1, 0, 5, 47, 0, 46, 4)]
		[TestCase(10, 21, 5, 47, 41, 8, 11)]
		[TestCase(12, 11, 5, 47, 37, 26, 44)]
		[TestCase(0, 42, 2, 43, 0, 1, 2)]
		[TestCase(1, 0, 2, 43, 0, 42, 4)]
		[TestCase(4, 17, 2, 43, 34, 14, 44)]
		[TestCase(17, 22, 5, 47, 11, 12, 44)]
		[TestCase(22, 17, 5, 47, 11, 35, 22)]
		public void TestEdPoint(Int64 x, Int64 y, Int64 d, Int64 prime, Int64 add1_x, Int64 add1_y, Int64 ans_order)
		{
			var base_point = new EHPoint3(x, y, 1);
			var p = EHPoint3.Identity;
			var afp = AFPoint.Identity;
			var order = 1;

			for (int i = 0; i < prime * 2; i++)
			{
				p = EHPoint3.EdwardsCurveAdd(p, base_point, d, prime);
				afp = p.ToAFPoint(prime);

				if (i == 1)
				{
					Assert.That(afp, Is.EqualTo(new AFPoint(add1_x, add1_y)));
				}
				if (afp == AFPoint.Identity)
				{
					break;
				}
				order += 1;
			}
			Assert.That(order, Is.EqualTo(ans_order));
		}

		[TestCase(0, 1, 2, 43)]
		[TestCase(0, 42, 2, 43)]
		[TestCase(1, 0, 2, 43)]
		[TestCase(2, 5, 2, 43)]
		[TestCase(2, 38, 2, 43)]
		[TestCase(5, 41, 2, 43)]
		[TestCase(9, 14, 2, 43)]
		[TestCase(17, 4, 2, 43)]
		[TestCase(22, 25, 2, 43)]
		[TestCase(41, 38, 2, 43)]
		[TestCase(42, 0, 2, 43)]
		[TestCase(0, 1, 5, 47)]
		[TestCase(0, 46, 5, 47)]
		[TestCase(1, 0, 5, 47)]
		[TestCase(6, 8, 5, 47)]
		[TestCase(6, 39, 5, 47)]
		[TestCase(11, 12, 5, 47)]
		[TestCase(12, 36, 5, 47)]
		[TestCase(30, 25, 5, 47)]
		[TestCase(39, 41, 5, 47)]
		[TestCase(41, 39, 5, 47)]
		[TestCase(46, 0, 5, 47)]
		public void TestEHPoint3AFPointEdwardsCurveAdd(Int64 x, Int64 y, Int64 d, Int64 prime)
		{
			EHPoint3 eh3_base_point = new(x, y, 1);
			AFPoint afp_base_point = new(x, y);
			EHPoint3 eh3 = eh3_base_point;
			AFPoint afp = afp_base_point;
			int order = 1;
			for (int i = 0; i < prime * 3; i++)
			{
				Assert.That(afp, Is.EqualTo(eh3.ToAFPoint(prime)));
				if (afp == AFPoint.Identity)
				{
					break;
				}
				afp = AFPoint.EdwardsCurveAdd(afp, afp_base_point, d, prime);
				eh3 = EHPoint3.EdwardsCurveAdd(eh3, eh3_base_point, d, prime);
				order += 1;
			}
			Assert.That(order, Is.LessThan(prime * 3));
		}

		[TestCase(0, 1, 1, 2, 43)]
		[TestCase(0, 42, 1, 2, 43)]
		[TestCase(1, 0, 1, 2, 43)]
		[TestCase(2, 5, 1, 2, 43)]
		[TestCase(2, 38, 1, 2, 43)]
		[TestCase(5, 41, 1, 2, 43)]
		[TestCase(9, 14, 1, 2, 43)]
		[TestCase(17, 4, 1, 2, 43)]
		[TestCase(22, 25, 1, 2, 43)]
		[TestCase(41, 38, 1, 2, 43)]
		[TestCase(42, 0, 1, 2, 43)]
		[TestCase(0, 1, 1, 5, 47)]
		[TestCase(0, 46, 1, 5, 47)]
		[TestCase(1, 0, 1, 5, 47)]
		[TestCase(6, 8, 1, 5, 47)]
		[TestCase(6, 39, 1, 5, 47)]
		[TestCase(11, 12, 1, 5, 47)]
		[TestCase(12, 36, 1, 5, 47)]
		[TestCase(30, 25, 1, 5, 47)]
		[TestCase(39, 41, 1, 5, 47)]
		[TestCase(41, 39, 1, 5, 47)]
		[TestCase(46, 0, 1, 5, 47)]
		public void TestEHPoint4AFPointEdwardsCurveAdd(Int64 x, Int64 y, Int64 a, Int64 d, Int64 prime)
		{
			EHPoint4 eh4_base_point = new(x, y, 1, prime);
			AFPoint afp_base_point = new(x, y);
			EHPoint4 eh4 = eh4_base_point;
			AFPoint afp = afp_base_point;
			int order = 1;
			for (int i = 0; i < prime * 3; i++)
			{
				Assert.That(eh4.ToAFPoint(), Is.EqualTo(afp));
				if (afp == AFPoint.Identity)
				{
					break;
				}
				afp = AFPoint.EdwardsCurveAdd(afp, afp_base_point, d, prime);
				eh4 = EHPoint4.EdwardsCurveAdd(eh4, eh4_base_point, a, d);
				order += 1;
			}
			Assert.That(order, Is.LessThan(prime * 3));
		}
	}
}
