﻿using System.Data;
using System.Numerics;
using System.Linq;
using edtoy;

namespace Tests.EdwardsCurveComponents
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
        public void TestSimpleValue(long n, string expect)
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
        public void TestLessThan(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l), Is.LessThan(new QNumberBigInteger(r)));
        }

        [TestCase(-1, 0)]
        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(-1, -1)]
        public void TestLessThanOrEqualTo(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l), Is.LessThanOrEqualTo(new QNumberBigInteger(r)));
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(0, -1)]
        public void TestGreaterThan(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l), Is.GreaterThan(new QNumberBigInteger(r)));
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(1, 1)]
        public void TestGreaterThanOrEqualTo(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l), Is.GreaterThanOrEqualTo(new QNumberBigInteger(r)));
        }

        [TestCase(-1, 0)]
        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        public void TestLessThanSymbol(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l) < new QNumberBigInteger(r), Is.True);
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(0, -1)]
        public void TestGreaterThanSymbol(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l) > new QNumberBigInteger(r), Is.True);
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(0, -1)]
        public void TestNotEqualSymbol(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l) != new QNumberBigInteger(r), Is.True);
        }

        [TestCase(0, 0)]
        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        public void TestEqualSymbol(long l, long r)
        {
            Assert.That(new QNumberBigInteger(l) == new QNumberBigInteger(r), Is.True);
        }

        [TestCase(1, 0, 1)]
        [TestCase(1, -1, 0)]
        [TestCase(1, 1, 2)]
        public void TestSimpleArithmeticPlus(long a, long b, long r)
        {
            // 二項演算 +
            Assert.That(new QNumberBigInteger(a) + new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(r)));
        }

        [TestCase(1, 0, 1)]
        [TestCase(1, -1, 2)]
        [TestCase(1, 1, 0)]
        public void TestSimpleArithmeticMinus(long a, long b, long r)
        {
            Assert.That(new QNumberBigInteger(a) - new QNumberBigInteger(b), Is.EqualTo(new QNumberBigInteger(r)));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(-1, -1)]
        public void TestSimpleArithmeticSinglePlus(long a, long r)
        {
            // 単項 + -
            Assert.That(+new QNumberBigInteger(a), Is.EqualTo(new QNumberBigInteger(r)));
        }

        [TestCase(0, 0)]
        [TestCase(1, -1)]
        [TestCase(-1, 1)]
        public void TestSimpleArithmeticSingleMinus(long a, long r)
        {
            // 単項 + -
            Assert.That(-new QNumberBigInteger(a), Is.EqualTo(new QNumberBigInteger(r)));
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
        public void TestSimpleArithmeticMul(int a, int b, int expect)
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
        public void TestSimpleArithmeticDiv(int a, int b, int expect)
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
        [TestCase(-11, 11, 0)]
        [TestCase(-22, 11, 0)]
        [TestCase(-23, 11, -1)]
        public void TestSimpleArithmeticMod(int a, int b, int expect)
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
        public void TestSimpleArithmeticBitOpAnd(long a, long b, long r)
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
        public void TestSimpleArithmeticBitOpOr(long a, long b, long r)
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
        public void TestSimpleArithmeticBitOpXor(long a, long b, long r)
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
        public void TestSimpleArithmeticBitOpShiftL(long a, int b, long r)
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
        public void TestSimpleArithmeticBitOpShiftR(long a, int b, long r)
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
        public void TestSimpleArithmeticBitOpShiftRR(long a, int b, long r)
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

            Assert.That(new QNumberBigInteger(0).IsPowerOfTwo, Is.False);
            Assert.That(new QNumberBigInteger(1).IsPowerOfTwo, Is.True);
            Assert.That(new QNumberBigInteger(2).IsPowerOfTwo, Is.True);
            Assert.That(new QNumberBigInteger(3).IsPowerOfTwo, Is.False);
            Assert.That(new QNumberBigInteger(100).IsPowerOfTwo, Is.False);
            Assert.That(new QNumberBigInteger(127).IsPowerOfTwo, Is.False);
            Assert.That(new QNumberBigInteger(128).IsPowerOfTwo, Is.True);

            Assert.That(new QNumberBigInteger(0).IsEven, Is.True);
            Assert.That(new QNumberBigInteger(1).IsEven, Is.False);
            Assert.That(new QNumberBigInteger(2).IsEven, Is.True);
            Assert.That(new QNumberBigInteger(3).IsEven, Is.False);
            Assert.That(new QNumberBigInteger(127).IsEven, Is.False);
            Assert.That(new QNumberBigInteger(128).IsEven, Is.True);

            Assert.That(new QNumberBigInteger(-1).IsOne, Is.False);
            Assert.That(new QNumberBigInteger(0).IsOne, Is.False);
            Assert.That(new QNumberBigInteger(1).IsOne, Is.True);
            Assert.That(new QNumberBigInteger(2).IsOne, Is.False);

            Assert.That(new QNumberBigInteger(0).Sign, Is.EqualTo(0));
            Assert.That(new QNumberBigInteger(1).Sign, Is.EqualTo(1));
            Assert.That(new QNumberBigInteger(2).Sign, Is.EqualTo(1));
            Assert.That(new QNumberBigInteger(-1).Sign, Is.EqualTo(-1));
            Assert.That(new QNumberBigInteger(-100).Sign, Is.EqualTo(-1));

        }
        [TestCase(0UL)]
        [TestCase(1UL)]
        [TestCase(2047UL)]
        public void TestPrimeFalse(ulong p1)
        {
            Assert.That(new QNumberBigInteger(p1).IsPrime, Is.False);
        }
        [TestCase(2UL)]
        [TestCase(7UL)]
        [TestCase(3331UL)]
        [TestCase(18446744073709551557UL)]
        public void TestPrimeTrue(ulong p1)
        {
            Assert.That(new QNumberBigInteger(p1).IsPrime, Is.True);
        }

        [TestCase("1543267864443420616877677640751301")]
        public void TestPrimeFalseStr(string p1)
        {
            Assert.That(new QNumberBigInteger(BigInteger.Parse(p1)).IsPrime, Is.False);
        }

        [TestCase("340282366920938463463374607431768211283")]
        [TestCase("858935034755082243869059388705676768166562323327641661754278919905577283660233")]
        [TestCase("5032016309736605849599781362686227253782565233212531305818219076405603316773042020583754171682703873312704063336646392378679894476934469388536106036540387070237902240020722375527146453726028527740762821861729991833037775711364117033973976166975847399328585662507374639262965786968502687693249972814313")]
        public void TestPrimeTrueStr(string p1)
        {
            Assert.That(new QNumberBigInteger(BigInteger.Parse(p1)).IsPrime, Is.True);
        }

        [TestCase(11, 43, 11)]
        [TestCase(111, 43, 25)]
        [TestCase(1111, 43, 36)]
        [TestCase(-1, 43, 42)]
        [TestCase(-2, 43, 41)]
        [TestCase(-43, 43, 0)]
        [TestCase(-44, 43, 42)]
        [TestCase(-100, 43, 29)]
        [TestCase(-11, 11, 0)]
        [TestCase(-22, 11, 0)]
        [TestCase(-23, 11, 10)]
        public void TestMod(int n, int prime, int expect)
        {
            Assert.That(new QNumberBigInteger(n).Mod(new QNumberBigInteger(prime)), Is.EqualTo(new QNumberBigInteger(expect)));
        }

        [TestCase(2, 20, 41, 1)]
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
        public void TestPowMod(int n, int exp, int prime, int expect)
        {
            var a = new QNumberBigInteger(n);
            Assert.That(a.PowMod(new QNumberBigInteger(exp), new QNumberBigInteger(prime)), Is.EqualTo(new QNumberBigInteger(expect)));
            // -1 乗は逆数
        }

        public void TestInverse(int n)
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
        public void Recipro(int a, int prime)
        {
            var n = new QNumberBigInteger(a);
            Assert.That((n.Recipro(prime) * n).Mod(prime), Is.EqualTo(new QNumberBigInteger(1)));
        }

        [TestCase(8, 2, 17, 4)]
        [TestCase(11, 11, 17, 1)]
        [TestCase(110, 2, 17, 4)]
        [TestCase(1, 8, 47, 6)]
        public void DivMod(int _a, int _b, int prime, int result)
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
        public void DivMod2(int _a, int _b, int prime)
        {
            var a = new QNumberBigInteger(_a);
            var b = new QNumberBigInteger(_b);
            Assert.That(a.DivMod(b, prime).MulMod(b, prime), Is.EqualTo(new QNumberBigInteger(a % prime)));
        }

        [TestCase(2, 8, 17, 16)]
        [TestCase(11, 11, 17, 2)]
        [TestCase(110, 0, 17, 0)]
        [TestCase(1, 8, 47, 8)]
        public void MulMod(int _a, int _b, int prime, int result)
        {
            var a = new QNumberBigInteger(_a);
            var b = new QNumberBigInteger(_b);
            Assert.That(a.MulMod(b, prime), Is.EqualTo(new QNumberBigInteger(result)));
        }

        [TestCase(41, 5UL)]
        public void Sqrt(long prime, ulong nn)
        {
            QNumberBigInteger n = new(nn);

            var sqrt_pair = n.SqrtPrime(prime);
            List<QNumberBigInteger> act = [sqrt_pair.Item1, sqrt_pair.Item2];
            act.Sort();
            List<KeyValuePair<QNumberBigInteger, List<QNumberBigInteger>>> actual = [new KeyValuePair<QNumberBigInteger, List<QNumberBigInteger>>(new QNumberBigInteger(5), act)];
            List<KeyValuePair<QNumberBigInteger, List<QNumberBigInteger>>> expect = [new(new QNumberBigInteger(5), [new QNumberBigInteger(13), new QNumberBigInteger(28)])];
            Assert.That(actual, Is.EqualTo(expect));
        }

        // 4n+1 トネリシャンクス
        [TestCase(41)]
        [TestCase(73)]
        [TestCase(89)]
        // フェルマー素数
        [TestCase(17)]
        [TestCase(257)]
        [TestCase(65537)]

        // 4n+1 ≡5 mod 8
        [TestCase(29)]
        [TestCase(37)]
        [TestCase(53)]
        [TestCase(3733)]

        // 4n+3
        [TestCase(23)]
        [TestCase(43)]
        [TestCase(47)]
        [TestCase(59)]
        [TestCase(3947)]
        public void Sqrt(long prime)
        {
            // 平方根テーブルを作る
            // r * r => a
            Dictionary<QNumberBigInteger, List<QNumberBigInteger>> sqrt_table = new();
            for (int i = 1; i < prime; i++)
            {
                var i2 = new QNumberBigInteger(i).MulMod(i, prime);
                if (!sqrt_table.ContainsKey(i2))
                {
                    sqrt_table[i2] = new(2) { i };
                }
                else
                {
                    sqrt_table[i2].Add(i);
                    sqrt_table[i2].Sort();
                }
            }
            // リスト化
            var sqrt_table_list = sqrt_table.Select(a => new KeyValuePair<QNumberBigInteger, List<QNumberBigInteger>>(a.Key, [.. a.Value.OrderBy(x => x)])).ToList().OrderBy(y => y.Key).ToList();

            // 平方剰余判定
            // 	a^(p-1)/2 == 1 なら平方剰余
            // √a => ±r
            Dictionary<QNumberBigInteger, List<QNumberBigInteger>> actual = new();
            for (int i = 1; i < prime; i++)
            {
                var a = new QNumberBigInteger(i).PowMod(prime >> 1, prime);
                if (a == 1)
                {
                    var n = new QNumberBigInteger(i);
                    // 平方根を求める
                    var sqrt_pair = n.SqrtPrime(prime);
                    actual[n] = [sqrt_pair.Item1, sqrt_pair.Item2];
                    actual[n].Sort();
                }
            }
            var actual_list = actual.Select(a => new KeyValuePair<QNumberBigInteger, List<QNumberBigInteger>>(a.Key, [.. a.Value.OrderBy(x => x)])).ToList().OrderBy(y => y.Key).ToList();

            // 平方根テーブルと一致することを確認
            Assert.That(actual_list, Is.EqualTo(sqrt_table_list));
        }


    }
}