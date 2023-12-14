using ecc_20231118_curve448_toy;

namespace Tests
{
	internal class EHPoint4Test
	{
		[TestCase(0, 1, 1, 0, "(0,1,1,0)")]
		[TestCase(0, 2, 2, 0, "(0,2,2,0)")]
		[TestCase(-1, -100, -10, 100, "(-1,-100,-10,100)")]
		public void TestEqualString(Int64 x, Int64 y, Int64 z, Int64 prime, string s)
		{
			Assert.That(new EHPoint4(x, y, z, prime).ToString(), Is.EqualTo(s));
		}

		[TestCase(0, 1, 1, 17, 0, 1)]
		[TestCase(0, 10, 5, 17, 0, 2)]
		[TestCase(100, 10, 8, 19, 3, 6)]
		public void TestToAFPoint(Int64 x, Int64 y, Int64 z, Int64 prime, Int64 ax, Int64 ay)
		{
			Assert.That(new EHPoint4(x, y, z, prime).ToAFPoint(), Is.EqualTo(new AFPoint(ax, ay)));
		}

		[TestCase(100, 10, 47, 100, 10, 1)]
		[TestCase(-10, -1, 47, -10, -1, 1)]
		public void TestFromAFPoint(Int64 ax, Int64 ay, Int64 prime, Int64 x, Int64 y, Int64 z)
		{
			Assert.That(new EHPoint4(new AFPoint(ax, ay), prime), Is.EqualTo(new EHPoint4(x, y, z, prime)));
		}
	}
}
