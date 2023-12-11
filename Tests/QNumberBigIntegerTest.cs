using System.Numerics;
using ecc_20231118_curve448_toy;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(0, "0")]
		[TestCase(1, "1")]
		[TestCase(99, "99")]
		[TestCase(-100, "-100")]
		public void TestSimpleValue(Int64 n, String expect)
		{
			QNumberBigInteger qn = new QNumberBigInteger(n);
			Assert.That(qn.ToString(), Is.EqualTo(expect));
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
			qn = QNumberBigInteger.MinusOne;
			Assert.That(qn.ToString(), Is.EqualTo("-1"));
			Assert.That(qn, Is.EqualTo(new QNumberBigInteger(-1)));
		}

		[TestCase(-1, 0)]
		[TestCase(-1, 1)]
		[TestCase(0, 1)]
		public void TestLessThan(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l), Is.LessThan(new QNumberBigInteger(r)));
		}

		[TestCase(-1, 0)]
		[TestCase(-1, 1)]
		[TestCase(0, 1)]
		[TestCase(0, 0)]
		[TestCase(1, 1)]
		[TestCase(-1, -1)]
		public void TestLessThanOrEqualTo(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l), Is.LessThanOrEqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(1, 0)]
		[TestCase(1, -1)]
		[TestCase(0, -1)]
		public void TestGreaterThan(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l), Is.GreaterThan(new QNumberBigInteger(r)));
		}

		[TestCase(1, 0)]
		[TestCase(1, -1)]
		[TestCase(1, 1)]
		public void TestGreaterThanOrEqualTo(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l), Is.GreaterThanOrEqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(-1, 0)]
		[TestCase(-1, 1)]
		[TestCase(0, 1)]
		public void TestLessThanSymbol(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l) < new QNumberBigInteger(r), Is.True);
		}

		[TestCase(1, 0)]
		[TestCase(1, -1)]
		[TestCase(0, -1)]
		public void TestGreaterThanSymbol(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l) > new QNumberBigInteger(r), Is.True);
		}

		[TestCase(1, 0)]
		[TestCase(1, -1)]
		[TestCase(0, -1)]
		public void TestNotEqualSymbol(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l) != new QNumberBigInteger(r), Is.True);
		}

		[TestCase(0, 0)]
		[TestCase(-1, -1)]
		[TestCase(1, 1)]
		public void TestEqualSymbol(Int64 l, Int64 r)
		{
			Assert.That(new QNumberBigInteger(l) == new QNumberBigInteger(r), Is.True);
		}

		[TestCase(1, 0, 1)]
		[TestCase(1, -1, 0)]
		[TestCase(1, 1, 2)]
		public void TestSimpleArithmeticPlus(Int64 a, Int64 b, Int64 r)
		{
			// 二項演算 +
			Assert.That(new QNumberBigInteger(a) + new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(1, 0, 1)]
		[TestCase(1, -1, 2)]
		[TestCase(1, 1, 0)]
		public void TestSimpleArithmeticMinus(Int64 a, Int64 b, Int64 r)
		{
			Assert.That(new QNumberBigInteger(a) - new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(0, 0)]
		[TestCase(1, 1)]
		[TestCase(-1, -1)]
		public void TestSimpleArithmeticSinglePlus(Int64 a, Int64 r)
		{
			// 単項 + -
			Assert.That(+(new QNumberBigInteger(a)), Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(0, 0)]
		[TestCase(1, -1)]
		[TestCase(-1, 1)]
		public void TestSimpleArithmeticSingleMinus(Int64 a, Int64 r)
		{
			// 単項 + -
			Assert.That(-(new QNumberBigInteger(a)), Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(1, 1, 1)]
		[TestCase(1, 0, 0)]
		[TestCase(2, 100, 200)]
		[TestCase(100, 2, 200)]
		[TestCase(100, 0, 0)]
		[TestCase(100, 1, 100)]
		[TestCase(10, -1, -10)]
		[TestCase(0, -1, 0)]
		[TestCase(-1, -1, 1)]
		public void TestSimpleArithmeticMul(Int32 a, Int32 b, Int32 expect)
		{
			// * 二項乗算
			Assert.That(new QNumberBigInteger(a) * new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(expect)));
		}

		[TestCase(1, 1, 1)]
		[TestCase(100, 1, 100)]
		[TestCase(100, 100, 1)]
		[TestCase(1, 100, 0)]
		[TestCase(-1, -1, 1)]
		[TestCase(0, 1, 0)]
		[TestCase(0, -1, 0)]
		[TestCase(100, -1, -100)]
		public void TestSimpleArithmeticDiv(Int32 a, Int32 b, Int32 expect)
		{
			// / 二項除算
			Assert.That(new QNumberBigInteger(a) / new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(expect)));
		}

		[TestCase(1, 1, 0)]
		[TestCase(100, 2, 0)]
		[TestCase(100, 3, 1)]
		[TestCase(0, 3, 0)]
		[TestCase(0, 1, 0)]
		[TestCase(0, -1, 0)]
		[TestCase(100, -1, 0)]
		[TestCase(100, -3, 1)]
		[TestCase(-100, 3, -1)]
		public void TestSimpleArithmeticMod(Int32 a, Int32 b, Int32 expect)
		{
			// % 剰余算
			Assert.That(new QNumberBigInteger(a) % new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(expect)));
		}

		[TestCase(0, 0, 0)]
		[TestCase(0, 1, 0)]
		[TestCase(1, 1, 1)]
		[TestCase(1, 2, 0)]
		[TestCase(2, 2, 2)]
		[TestCase(255, 3, 3)]
		[TestCase(-1, 3, 3)]
		public void TestSimpleArithmeticBitOpAnd(Int64 a, Int64 b, Int64 r)
		{
			// 二項演算 &
			Assert.That(new QNumberBigInteger(a) & new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(0, 0, 0)]
		[TestCase(0, 1, 1)]
		[TestCase(1, 1, 1)]
		[TestCase(1, 2, 3)]
		[TestCase(2, 2, 2)]
		[TestCase(255, 3, 255)]
		[TestCase(-1, 3, -1)]
		public void TestSimpleArithmeticBitOpOr(Int64 a, Int64 b, Int64 r)
		{
			// 二項演算 |
			Assert.That(new QNumberBigInteger(a) | new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(0, 0, 0)]
		[TestCase(0, 1, 1)]
		[TestCase(1, 1, 0)]
		[TestCase(1, 2, 3)]
		[TestCase(2, 2, 0)]
		[TestCase(255, 3, 252)]
		[TestCase(-1, 3, -4)]
		public void TestSimpleArithmeticBitOpXor(Int64 a, Int64 b, Int64 r)
		{
			// 二項演算 ^
			Assert.That(new QNumberBigInteger(a) ^ new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(0, 0, 0)]
		[TestCase(0, 1, 0)]
		[TestCase(1, 1, 1 << 1)]
		[TestCase(1, 2, 1 << 2)]
		[TestCase(2, 2, 2 << 2)]
		[TestCase(2, 10, 2 << 10)]
		public void TestSimpleArithmeticBitOpShiftL(Int64 a, Int32 b, Int64 r)
		{
			// シフト <<
			Assert.That(new QNumberBigInteger(a) << b, Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(0, 0, 0)]
		[TestCase(0, 1, 0)]
		[TestCase(1, 1, 1 >> 1)]
		[TestCase(1, 2, 1 >> 2)]
		[TestCase(255, 2, 255 >> 2)]
		[TestCase(2, 10, 2 >> 10)]
		public void TestSimpleArithmeticBitOpShiftR(Int64 a, Int32 b, Int64 r)
		{
			// シフト >>
			Assert.That(new QNumberBigInteger(a) >> b, Is.EqualTo(new QNumberBigInteger(r)));
		}

		[TestCase(0, 0, 0 >>> 0)]
		[TestCase(0, 1, 0 >>> 1)]
		[TestCase(1, 1, 1 >>> 1)]
		[TestCase(1, 2, 1 >>> 2)]
		[TestCase(255, 2, 255 >>> 2)]
		[TestCase(2, 10, 2 >>> 10)]
		public void TestSimpleArithmeticBitOpShiftRR(Int64 a, Int32 b, Int64 r)
		{
			// シフト >>>
			Assert.That(new QNumberBigInteger(a) >>> b, Is.EqualTo(new QNumberBigInteger(r)));
		}

		[Test]
		public void TestSimpleArithmeticOther()
		{
			Assert.That(QNumberBigInteger.AdditiveIdentity, Is.EqualTo(new QNumberBigInteger(0)));
			Assert.That(QNumberBigInteger.MultiplicativeIdentity, Is.EqualTo(new QNumberBigInteger(1)));
			Assert.That(QNumberBigInteger.IsNegative(new QNumberBigInteger(0)), Is.False);
			Assert.That(QNumberBigInteger.IsNegative(new QNumberBigInteger(-1)), Is.True);
			Assert.That(QNumberBigInteger.IsNegative(new QNumberBigInteger(1)), Is.False);

			Assert.That(QNumberBigInteger.IsComplexNumber(new QNumberBigInteger(1)), Is.False);

			Assert.That(QNumberBigInteger.IsEvenInteger(new QNumberBigInteger(0)), Is.True);
			Assert.That(QNumberBigInteger.IsEvenInteger(new QNumberBigInteger(1)), Is.False);
			Assert.That(QNumberBigInteger.IsEvenInteger(new QNumberBigInteger(2)), Is.True);

			Assert.That((new QNumberBigInteger(0)).IsPowerOfTwo, Is.False);
			Assert.That((new QNumberBigInteger(1)).IsPowerOfTwo, Is.True);
			Assert.That((new QNumberBigInteger(2)).IsPowerOfTwo, Is.True);
			Assert.That((new QNumberBigInteger(3)).IsPowerOfTwo, Is.False);
			Assert.That((new QNumberBigInteger(100)).IsPowerOfTwo, Is.False);
			Assert.That((new QNumberBigInteger(127)).IsPowerOfTwo, Is.False);
			Assert.That((new QNumberBigInteger(128)).IsPowerOfTwo, Is.True);

			Assert.That((new QNumberBigInteger(0)).IsEven, Is.True);
			Assert.That((new QNumberBigInteger(1)).IsEven, Is.False);
			Assert.That((new QNumberBigInteger(2)).IsEven, Is.True);
			Assert.That((new QNumberBigInteger(3)).IsEven, Is.False);
			Assert.That((new QNumberBigInteger(127)).IsEven, Is.False);
			Assert.That((new QNumberBigInteger(128)).IsEven, Is.True);

			Assert.That((new QNumberBigInteger(-1)).IsOne, Is.False);
			Assert.That((new QNumberBigInteger(0)).IsOne, Is.False);
			Assert.That((new QNumberBigInteger(1)).IsOne, Is.True);
			Assert.That((new QNumberBigInteger(2)).IsOne, Is.False);

			Assert.That((new QNumberBigInteger(0)).Sign, Is.EqualTo(0));
			Assert.That((new QNumberBigInteger(1)).Sign, Is.EqualTo(1));
			Assert.That((new QNumberBigInteger(2)).Sign, Is.EqualTo(1));
			Assert.That((new QNumberBigInteger(-1)).Sign, Is.EqualTo(-1));
			Assert.That((new QNumberBigInteger(-100)).Sign, Is.EqualTo(-1));

		}
		[Test]
		public void TestPrime()
		{
			Assert.That((new QNumberBigInteger(0)).IsPrime, Is.False);
			Assert.That((new QNumberBigInteger(1)).IsPrime, Is.False);
			var q = new QNumberBigInteger(0);
			Assert.That(q.IsPrime, Is.False);
			Assert.That(q.PossibilityPrimeState, Is.EqualTo(QNumberBigInteger.PossibilityPrime.None));
			q = new QNumberBigInteger(7);
			Assert.That(q.IsPrime, Is.True);
			Assert.That(q.PossibilityPrimeState, Is.EqualTo(QNumberBigInteger.PossibilityPrime.Prime));
			q = new QNumberBigInteger(2047);
			Assert.That(q.IsPrime, Is.False);
			Assert.That(q.PossibilityPrimeState, Is.EqualTo(QNumberBigInteger.PossibilityPrime.Composite));
			q = new QNumberBigInteger(3331);
			Assert.That(q.IsPrime, Is.True);
			Assert.That(q.PossibilityPrimeState, Is.EqualTo(QNumberBigInteger.PossibilityPrime.Prime));
			q = new QNumberBigInteger(18446744073709551557);
			Assert.That(q.IsPrime, Is.True);
			Assert.That(q.PossibilityPrimeState, Is.EqualTo(QNumberBigInteger.PossibilityPrime.Prime));
			q = new QNumberBigInteger(BigInteger.Parse("1543267864443420616877677640751301"));
			Assert.That(q.IsPrime, Is.False);
			Assert.That(q.PossibilityPrimeState, Is.EqualTo(QNumberBigInteger.PossibilityPrime.Composite));
			q = new QNumberBigInteger(BigInteger.Parse("340282366920938463463374607431768211283"));
			Assert.That(q.IsPrime, Is.True);
			Assert.That(q.PossibilityPrimeState, Is.EqualTo(QNumberBigInteger.PossibilityPrime.Prime));
		}

		[TestCase(11, 43, 11)]
		[TestCase(111, 43, 25)]
		[TestCase(1111, 43, 36)]
		[TestCase(-1, 43, 42)]
		[TestCase(-2, 43, 41)]
		[TestCase(-43, 43, 0)]
		[TestCase(-44, 43, 42)]
		[TestCase(-100, 43, 29)]
		public void TestMod(Int32 n, Int32 prime, Int32 expect)
		{
			var a = new QNumberBigInteger(n);
			Assert.That(a.Mod(new QNumberBigInteger(prime)), Is.EqualTo(new QNumberBigInteger(expect)));
		}
		[TestCase(11, 1, 43, 11)]
		[TestCase(11, 2, 43, 35)]
		[TestCase(11, 42, 43, 1)]
		[TestCase(11, 43, 43, 11)]
		[TestCase(11, 44, 43, 35)]
		[TestCase(11, 90, 43, 4)]
		[TestCase(11, 130, 43, 21)]

		[TestCase(11, -1, 43, 4)]
		[TestCase(11, -2, 43, 16)]
		[TestCase(11, -3, 43, 21)]
		[TestCase(11, -21, 43, 1)]
		[TestCase(11, -41, 43, 11)]
		[TestCase(11, -42, 43, 1)]
		[TestCase(11, -43, 43, 4)]
		[TestCase(11, -44, 43, 16)]
		public void TestPowMod(Int32 n, Int32 exp, Int32 prime, Int32 expect)
		{
			var a = new QNumberBigInteger(n);
			Assert.That(a.PowMod(new QNumberBigInteger(exp), new QNumberBigInteger(prime)), Is.EqualTo(new QNumberBigInteger(expect)));
			// -1 乗は逆数
		}

		public void TestInverse(Int32 n)
		{
			// 逆数
			var a = new QNumberBigInteger(11);
			var prime = new QNumberBigInteger(43);
			Assert.That((a.PowMod(new QNumberBigInteger(-1), prime) * a).Mod(prime), Is.EqualTo(QNumberBigInteger.One));
			Assert.That((a.PowMod(new QNumberBigInteger(-2), prime) * a * a).Mod(prime), Is.EqualTo(QNumberBigInteger.One));
			Assert.That((a.PowMod(new QNumberBigInteger(-10), prime) * a.PowMod(new QNumberBigInteger(10), prime)).Mod(prime), Is.EqualTo(QNumberBigInteger.One));
			Assert.That((a.PowMod(new QNumberBigInteger(-22), prime) * a.PowMod(new QNumberBigInteger(22), prime)).Mod(prime), Is.EqualTo(QNumberBigInteger.One));
			Assert.That((a.PowMod(new QNumberBigInteger(-100), prime) * a.PowMod(new QNumberBigInteger(100), prime)).Mod(prime), Is.EqualTo(QNumberBigInteger.One));
		}


		[TestCase(11, 17)]
		[TestCase(11, 41)]
		[TestCase(11, 43)]
		[TestCase(11, 47)]
		public void Recipro(Int32 a, Int32 prime)
		{
			var n = new QNumberBigInteger(a);
			Assert.That((n.Recipro(prime) * n).Mod(prime), Is.EqualTo(new QNumberBigInteger(1)));
		}

		[TestCase(8, 2, 17, 4)]
		[TestCase(11, 11, 17, 1)]
		[TestCase(110, 2, 17, 4)]
		[TestCase(1, 8, 47, 6)]
		public void DivMod(Int32 _a, Int32 _b, Int32 prime, Int32 result)
		{
			var a = new QNumberBigInteger(_a);
			var b = new QNumberBigInteger(_b);
			Assert.That(a.DivMod(b, prime), Is.EqualTo(new QNumberBigInteger(result)));
		}

		// a / b * b ≡ a (mod prime)
		[TestCase(111, 5, 43)]
		[TestCase(3, 5, 47)]
		[TestCase(22, 5, 47)]
		[TestCase(15, 8, 47)]
		public void DivMod2(Int32 _a, Int32 _b, Int32 prime)
		{
			var a = new QNumberBigInteger(_a);
			var b = new QNumberBigInteger(_b);
			Assert.That(a.DivMod(b, prime).MulMod(b, prime), Is.EqualTo(new QNumberBigInteger(a % prime)));
		}

		[TestCase(2, 8, 17, 16)]
		[TestCase(11, 11, 17, 2)]
		[TestCase(110, 0, 17, 0)]
		[TestCase(1, 8, 47, 8)]
		public void MulMod(Int32 _a, Int32 _b, Int32 prime, Int32 result)
		{
			var a = new QNumberBigInteger(_a);
			var b = new QNumberBigInteger(_b);
			Assert.That(a.MulMod(b, prime), Is.EqualTo(new QNumberBigInteger(result)));
		}

	}
}