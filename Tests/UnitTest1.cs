using ecc_20231118_curve448_toy;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			QNumberBigInteger qn = new QNumberBigInteger(0);
			Assert.That(qn.ToString(), Is.EqualTo("0"));
		}
	}
}