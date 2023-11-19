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
		[Test]
		public void TestSimpleArithmeticPlusMinus()
		{
			QNumberBigInteger q_0 = QNumberBigInteger.Zero;
			QNumberBigInteger q_minus1 = new QNumberBigInteger(-1);
			QNumberBigInteger q_plus1 = new QNumberBigInteger(1);

			// 二項演算 + -
			Assert.That(q_plus1 + q_plus1, Is.EqualTo(new QNumberBigInteger(2)));
			Assert.That(q_plus1 + q_minus1, Is.EqualTo(q_0));

			Assert.That(q_plus1 - q_plus1, Is.EqualTo(q_0));
			Assert.That(q_plus1 - q_minus1, Is.EqualTo(new QNumberBigInteger(2)));

			// 単項 + -
			Assert.That(+q_plus1, Is.EqualTo(q_plus1));
			Assert.That(+q_0, Is.EqualTo(q_0));
			Assert.That(+q_minus1, Is.EqualTo(q_minus1));

			Assert.That(-q_plus1, Is.EqualTo(q_minus1));
			Assert.That(-q_0, Is.EqualTo(q_0));
			Assert.That(-q_minus1, Is.EqualTo(q_plus1));

			// ++ -- 前置、後置で返り値が変わる
			var q1 = new QNumberBigInteger(1);
			var q0 = new QNumberBigInteger(0);
			var qm0 = new QNumberBigInteger(-1);
			Assert.That(++q1, Is.EqualTo(new QNumberBigInteger(2)));
			q1 = new QNumberBigInteger(1);
			Assert.That(q1++, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q1, Is.EqualTo(new QNumberBigInteger(2)));

			Assert.That(++q0, Is.EqualTo(new QNumberBigInteger(1)));
			q0 = new QNumberBigInteger(0);
			Assert.That(q0++, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q0, Is.EqualTo(new QNumberBigInteger(1)));

			Assert.That(++qm0, Is.EqualTo(new QNumberBigInteger(0)));
			qm0 = new QNumberBigInteger(-1);
			Assert.That(qm0++, Is.EqualTo(new QNumberBigInteger(-1)));
			Assert.That(qm0, Is.EqualTo(new QNumberBigInteger(0)));
		}

		[Test]
		public void TestSimpleArithmeticMulDiv()
		{
			QNumberBigInteger q_0 = QNumberBigInteger.Zero;
			QNumberBigInteger q_minus1 = new QNumberBigInteger(-1);
			QNumberBigInteger q_plus1 = new QNumberBigInteger(1);
			QNumberBigInteger q_plus2 = new QNumberBigInteger(2);
			QNumberBigInteger q_plus3 = new QNumberBigInteger(3);
			QNumberBigInteger q_plus100 = new QNumberBigInteger(100);

			// * 二項乗算
			Assert.That(q_plus1 * q_plus1, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus1 * q_0, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus2 * q_plus100, Is.EqualTo(new QNumberBigInteger(200)));
			Assert.That(q_plus100 * q_plus2, Is.EqualTo(q_plus2 * q_plus100));
			Assert.That(q_plus100 * q_0, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus100 * q_plus1, Is.EqualTo(new QNumberBigInteger(100)));
			Assert.That(q_plus100 * q_minus1, Is.EqualTo(new QNumberBigInteger(-100)));
			Assert.That(q_0 * q_minus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_minus1 * q_minus1, Is.EqualTo(new QNumberBigInteger(1)));

			// / 二項除算
			Assert.That(q_plus1 / q_plus1, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus100 / q_plus1, Is.EqualTo(new QNumberBigInteger(100)));
			Assert.That(q_plus100 / q_plus100, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus1 / q_plus100, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_minus1 / q_minus1, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_0 / q_plus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_0 / q_minus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus100 / q_minus1, Is.EqualTo(new QNumberBigInteger(-100)));

			// % 剰余算
			Assert.That(q_plus1 % q_plus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus100 % q_plus2, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus100 % q_plus3, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_0 % q_plus3, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_0 % q_plus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_0 % q_minus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus100 % q_minus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus100 % (q_minus1 * q_plus3 ), Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That((q_plus100 * q_minus1) % q_plus3, Is.EqualTo(new QNumberBigInteger(-1)));
		}

		[Test]
		public void TestSimpleArithmeticBitOp()
		{
			QNumberBigInteger q_0 = QNumberBigInteger.Zero;
			QNumberBigInteger q_plus1 = new QNumberBigInteger(1);
			QNumberBigInteger q_plus2 = new QNumberBigInteger(2);
			QNumberBigInteger q_plus3 = new QNumberBigInteger(3);
			QNumberBigInteger q_plus255 = new QNumberBigInteger(255);
			QNumberBigInteger q_minus1 = new QNumberBigInteger(-1);

			// 二項演算 &
			Assert.That(q_0 & q_0, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_0 & q_plus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus1 & q_plus1, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus1 & q_plus2, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus2 & q_plus2, Is.EqualTo(new QNumberBigInteger(2)));
			Assert.That(q_plus2 & q_plus3, Is.EqualTo(new QNumberBigInteger(2)));
			Assert.That(q_plus255 & q_plus3, Is.EqualTo(new QNumberBigInteger(3)));
			
			// 二項演算 |
			Assert.That(q_0 | q_0, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_0 | q_plus1, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus1 | q_plus1, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus1 | q_plus2, Is.EqualTo(new QNumberBigInteger(3)));
			Assert.That(q_plus2 | q_plus2, Is.EqualTo(new QNumberBigInteger(2)));
			Assert.That(q_plus2 | q_plus3, Is.EqualTo(new QNumberBigInteger(3)));
			Assert.That(q_plus255 | q_plus3, Is.EqualTo(new QNumberBigInteger(255)));
			
			// 二項演算 ^
			Assert.That(q_0 ^ q_0, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_0 ^ q_plus1, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus1 ^ q_plus1, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus1 ^ q_plus2, Is.EqualTo(new QNumberBigInteger(3)));
			Assert.That(q_plus2 ^ q_plus2, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(q_plus2 ^ q_plus3, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus255 ^ q_plus3, Is.EqualTo(new QNumberBigInteger(252)));
			
			// シフト <<
			Assert.That(q_plus1 << 0, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(q_plus1 << 1, Is.EqualTo(new QNumberBigInteger(2)));
			Assert.That(q_plus1 << 2, Is.EqualTo(new QNumberBigInteger(4)));
			Assert.That(q_plus255 << 1, Is.EqualTo(new QNumberBigInteger(255<<1)));
			Assert.That(q_plus255 << 10, Is.EqualTo(new QNumberBigInteger(255<<10)));

			// シフト >>
			Assert.That(q_plus255 >> 0, Is.EqualTo(new QNumberBigInteger(255)));
			Assert.That(q_plus255 >> 1, Is.EqualTo(new QNumberBigInteger(255>>1)));
			Assert.That(q_plus255 >> 2, Is.EqualTo(new QNumberBigInteger(255>>2)));
			Assert.That(q_plus255 >> 1, Is.EqualTo(new QNumberBigInteger(255>>1)));
			Assert.That(q_plus255 >> 10, Is.EqualTo(new QNumberBigInteger(255>>10)));

			// シフト >>>
			Assert.That(q_plus255 >>> 0, Is.EqualTo(new QNumberBigInteger(255)));
			Assert.That(q_plus255 >>> 1, Is.EqualTo(new QNumberBigInteger(255>>>1)));
			Assert.That(q_plus255 >>> 2, Is.EqualTo(new QNumberBigInteger(255>>>2)));
			Assert.That(q_plus255 >>> 1, Is.EqualTo(new QNumberBigInteger(255>>>1)));
			Assert.That(q_plus255 >>> 10, Is.EqualTo(new QNumberBigInteger(255>>>10)));
			Assert.That(q_minus1 >>> 0, Is.EqualTo(new QNumberBigInteger(-1)));
		}

	}
}