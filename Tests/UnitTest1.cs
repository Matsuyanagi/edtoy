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
		[Test]
		public void TestLessAndGreater()
		{
			QNumberBigInteger q_0 = QNumberBigInteger.Zero;
			QNumberBigInteger q_minus1 = new QNumberBigInteger(-1);
			QNumberBigInteger q_plus1 = new QNumberBigInteger(1);

			Assert.That(q_minus1, Is.LessThan(q_0));
			Assert.That(q_minus1, Is.LessThan(q_plus1));
			Assert.That(q_minus1, Is.LessThanOrEqualTo(q_0));
			Assert.That(q_minus1, Is.LessThanOrEqualTo(q_plus1));

			Assert.That(q_plus1, Is.GreaterThan(q_0));
			Assert.That(q_plus1, Is.GreaterThan(q_minus1));
			Assert.That(q_plus1, Is.GreaterThanOrEqualTo(q_0));
			Assert.That(q_plus1, Is.GreaterThanOrEqualTo(q_minus1));

			Assert.That(q_minus1 < q_plus1, Is.True);
			Assert.That(q_plus1 > q_minus1, Is.True);
			Assert.That(q_minus1 != q_plus1, Is.True);
			Assert.That(q_0 == new QNumberBigInteger(0), Is.True);

			Assert.That(q_minus1 <= q_plus1, Is.True);
			Assert.That(q_plus1 >= q_minus1, Is.True);
		}
	}
}