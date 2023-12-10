using ecc_20231118_curve448_toy;

namespace Tests
{
	internal class EHPointTest
	{
		[TestCase(0, 1, 1, "(0,1,1)")]
		[TestCase(0, 2, 2, "(0,2,2)")]
		[TestCase(-1, -100, -10, "(-1,-100,-10)")]
		public void TestEqualString(Int64 x, Int64 y, Int64 z, string s)
		{
			Assert.That((new EHPoint(x, y, z)).ToString(), Is.EqualTo(s));
		}

	}
}
