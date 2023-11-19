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
		public void TestSimpleValue()
		{
			QNumberBigInteger qn = new QNumberBigInteger(0);
			Assert.That(qn.ToString(), Is.EqualTo("0"));
			qn = new QNumberBigInteger(1);
			Assert.That(qn.ToString(), Is.EqualTo("1"));
			qn = new QNumberBigInteger(99);
			Assert.That(qn.ToString(), Is.EqualTo("99"));
			qn = new QNumberBigInteger(-100);
			Assert.That(qn.ToString(), Is.EqualTo("-100"));
		}
		[Test]
		public void TestStaticZeroOne()
		{
			QNumberBigInteger qn = QNumberBigInteger.Zero;
			Assert.That(qn.ToString(), Is.EqualTo("0"));
			Assert.That(qn, Is.EqualTo(new QNumberBigInteger(0)));
			qn = QNumberBigInteger.One;
			Assert.That(qn.ToString(), Is.EqualTo("1"));
			Assert.That(qn, Is.EqualTo(new QNumberBigInteger(1)));
		}
	}
}