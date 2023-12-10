using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace ecc_20231118_curve448_toy
{
	public struct QNumberBigInteger : IBinaryInteger<QNumberBigInteger>
	{
		public enum PossibilityPrime
		{
			Unknown,
			Prime,
			Composite,
			None
		}

		private readonly BigInteger innerValue;
		private PossibilityPrime possibilityPrime = PossibilityPrime.Unknown;


		private static readonly QNumberBigInteger _zero = new QNumberBigInteger(0);
		private static readonly QNumberBigInteger _one = new QNumberBigInteger(1);
		private static readonly QNumberBigInteger _minus_one = new QNumberBigInteger(-1);

		public static QNumberBigInteger Zero => _zero;

		public static QNumberBigInteger One => _one;

		public static QNumberBigInteger MinusOne => _minus_one;

		public QNumberBigInteger(QNumberBigInteger x)
		{
			innerValue = x.innerValue;
			possibilityPrime = x.possibilityPrime;
		}

		public QNumberBigInteger(Int32 x)
		{
			innerValue = x;
		}

		public QNumberBigInteger(UInt32 x)
		{
			innerValue = x;
		}

		public QNumberBigInteger(Int64 x)
		{
			innerValue = x;
		}

		public QNumberBigInteger(UInt64 x)
		{
			innerValue = x;
		}

		public QNumberBigInteger(Int128 x)
		{
			innerValue = x;
		}

		public QNumberBigInteger(UInt128 x)
		{
			innerValue = x;
		}

		public QNumberBigInteger(BigInteger x)
		{
			innerValue = x;
		}

		public QNumberBigInteger(Decimal x)
		{
			innerValue = (BigInteger)x;
		}

		public QNumberBigInteger(Single x)
		{
			innerValue = (BigInteger)x;
		}

		public QNumberBigInteger(Double x)
		{
			innerValue = (BigInteger)x;
		}

		public static int Radix => throw new NotImplementedException();

		public static QNumberBigInteger AdditiveIdentity => new(Zero);

		public static QNumberBigInteger MultiplicativeIdentity => new(One);

		public static QNumberBigInteger Abs(QNumberBigInteger value)
		{
			return value.Abs();
		}

		public readonly QNumberBigInteger Abs()
		{
			return new QNumberBigInteger(BigInteger.Abs(innerValue));
		}

		public static bool IsCanonical(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsComplexNumber(QNumberBigInteger value)
		{
			return false;
		}

		public static bool IsEvenInteger(QNumberBigInteger value)
		{
			return value.innerValue.IsEven;
		}

		public bool IsEven => innerValue.IsEven;
		public bool IsOne => innerValue.IsOne;
		public bool IsPowerOfTwo => innerValue.IsPowerOfTwo;
		// public bool IsZero => innerValue.IsZero;
		public int Sign => innerValue.Sign;


		public static bool IsFinite(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsImaginaryNumber(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsInfinity(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsInteger(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsNaN(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsNegative(QNumberBigInteger value)
		{
			return BigInteger.IsNegative(value.innerValue);
		}

		public bool IsNegative()
		{
			return BigInteger.IsNegative(innerValue);
		}

		public static bool IsNegativeInfinity(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsNormal(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsOddInteger(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsPositive(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsPositiveInfinity(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsPow2(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsRealNumber(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsSubnormal(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsZero(QNumberBigInteger value)
		{
			return value.innerValue.IsZero;
		}

		public static QNumberBigInteger Log2(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger MaxMagnitude(QNumberBigInteger x, QNumberBigInteger y)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger MaxMagnitudeNumber(QNumberBigInteger x, QNumberBigInteger y)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger MinMagnitude(QNumberBigInteger x, QNumberBigInteger y)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger MinMagnitudeNumber(QNumberBigInteger x, QNumberBigInteger y)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger Parse(string s, NumberStyles style, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger Parse(string s, IFormatProvider? provider)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger PopCount(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger TrailingZeroCount(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out QNumberBigInteger result)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out QNumberBigInteger result)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out QNumberBigInteger result)
		{
			throw new NotImplementedException();
		}

		public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out QNumberBigInteger result)
		{
			throw new NotImplementedException();
		}

		public static bool TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<QNumberBigInteger>.TryConvertFromChecked<TOther>(TOther value, out QNumberBigInteger result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<QNumberBigInteger>.TryConvertFromSaturating<TOther>(TOther value, out QNumberBigInteger result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<QNumberBigInteger>.TryConvertFromTruncating<TOther>(TOther value, out QNumberBigInteger result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<QNumberBigInteger>.TryConvertToChecked<TOther>(QNumberBigInteger value, out TOther result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<QNumberBigInteger>.TryConvertToSaturating<TOther>(QNumberBigInteger value, out TOther result)
		{
			throw new NotImplementedException();
		}

		static bool INumberBase<QNumberBigInteger>.TryConvertToTruncating<TOther>(QNumberBigInteger value, out TOther result)
		{
			throw new NotImplementedException();
		}

		public readonly int CompareTo(QNumberBigInteger x)
		{
			return innerValue.CompareTo(x.innerValue);
		}

		public readonly int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		public override readonly bool Equals(object? obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return innerValue.Equals(((QNumberBigInteger)obj).innerValue);
		}

		public readonly bool Equals(QNumberBigInteger other)
		{
			return innerValue.Equals(other.innerValue);
		}

		public int GetByteCount()
		{
			throw new NotImplementedException();
		}

		public override int GetHashCode()
		{
			return innerValue.GetHashCode();
		}

		public int GetShortestBitLength()
		{
			throw new NotImplementedException();
		}

		public override readonly string? ToString()
		{
			return innerValue.ToString();
		}

		public readonly string? ToString(string? format)
		{
			return innerValue.ToString(format);
		}

		public readonly string? ToString(IFormatProvider? provider)
		{
			return innerValue.ToString(provider);
		}

		public readonly string ToString(string? format, IFormatProvider? provider)
		{
			return innerValue.ToString(format, provider);
		}

		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
		{
			return innerValue.TryFormat(destination, out charsWritten, format, provider);
		}

		public bool TryWriteBigEndian(Span<byte> destination, out int bytesWritten)
		{
			throw new NotImplementedException();
		}

		public bool TryWriteLittleEndian(Span<byte> destination, out int bytesWritten)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator +(QNumberBigInteger value)
		{
			return new QNumberBigInteger(value.innerValue);
		}

		public static QNumberBigInteger operator +(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue + right.innerValue);
		}

		public static QNumberBigInteger operator -(QNumberBigInteger value)
		{
			return new QNumberBigInteger(-value.innerValue);
		}

		public static QNumberBigInteger operator -(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue - right.innerValue);
		}

		public static QNumberBigInteger operator ~(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator ++(QNumberBigInteger value)
		{
			throw new NotImplementedException();
			// return new QNumberBigInteger(++value.innerValue);
		}

		public static QNumberBigInteger operator --(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator *(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue * right.innerValue);
		}

		public static QNumberBigInteger operator /(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue / right.innerValue);
		}

		public static QNumberBigInteger operator %(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue % right.innerValue);
		}

		public static QNumberBigInteger operator &(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue & right.innerValue);
		}

		public static QNumberBigInteger operator |(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue | right.innerValue);
		}

		public static QNumberBigInteger operator ^(QNumberBigInteger left, QNumberBigInteger right)
		{
			return new QNumberBigInteger(left.innerValue ^ right.innerValue);
		}

		public static QNumberBigInteger operator <<(QNumberBigInteger value, int shiftAmount)
		{
			return new QNumberBigInteger(value.innerValue << shiftAmount);
		}

		public static QNumberBigInteger operator >>(QNumberBigInteger value, int shiftAmount)
		{
			return new QNumberBigInteger(value.innerValue >> shiftAmount);
		}

		public static bool operator ==(QNumberBigInteger left, QNumberBigInteger right)
		{
			return left.innerValue == right.innerValue;
		}

		public static bool operator !=(QNumberBigInteger left, QNumberBigInteger right)
		{
			return left.innerValue != right.innerValue;
		}

		public static bool operator <(QNumberBigInteger left, QNumberBigInteger right)
		{
			return left.innerValue < right.innerValue;
		}

		public static bool operator >(QNumberBigInteger left, QNumberBigInteger right)
		{
			return left.innerValue > right.innerValue;
		}

		public static bool operator <=(QNumberBigInteger left, QNumberBigInteger right)
		{
			return left.innerValue <= right.innerValue;
		}

		public static bool operator >=(QNumberBigInteger left, QNumberBigInteger right)
		{
			return left.innerValue >= right.innerValue;
		}

		public static QNumberBigInteger operator >>>(QNumberBigInteger value, int shiftAmount)
		{
			return new QNumberBigInteger(value.innerValue >>> shiftAmount);
		}

		/** 素数判定
		  * 	判定の結果は possibilityPrime にキャッシュしておき、キャッシュがあれば使う。
		  *	キャッシュがない場合は素数判定演算をする
		  *
		  */
		public bool IsPrime
		{
			get
			{
				if (possibilityPrime != PossibilityPrime.Unknown)
				{
					// すでに素数判定の結果があるなら素数かどうかを返す
					return possibilityPrime == PossibilityPrime.Prime;
				}
				possibilityPrime = IsPrimeInnerImplement();

				return possibilityPrime == PossibilityPrime.Prime;
			}
		}

		// 素数、合成数、それ以外(0,1,マイナス)
		public PossibilityPrime PossibilityPrimeState
		{
			get
			{
				if (possibilityPrime != PossibilityPrime.Unknown)
				{
					// すでに素数判定の結果があるなら素数かどうかを返す
					return possibilityPrime;
				}
				possibilityPrime = IsPrimeInnerImplement();
				return possibilityPrime;
			}
		}

		// 素数判定の演算
		private readonly PossibilityPrime IsPrimeInnerImplement()
		{
			if (innerValue <= 1)
			{
				// 0,1,マイナスは None として返す
				return PossibilityPrime.None;
			}
			else if (innerValue == 4)
			{
				// 4 は合成数
				return PossibilityPrime.Composite;
			}
			else if (innerValue < 6)
			{
				// 2,3,5 は素数
				return PossibilityPrime.Prime;
			}
			else if (innerValue.IsEven)
			{
				// 偶数は合成数
				return PossibilityPrime.Composite;
			}

			// ミラーラビンテストの結果を返す
			return IsPrimeInnerMillerRabinImplement();
		}

		// ミラーラビンテストを繰り返す
		// 	一度でも合成数だと判定されれば合成数確定
		private readonly PossibilityPrime IsPrimeInnerMillerRabinImplement()
		{
			// 小さい素数でミラーラビンテスト
			(int, BigInteger)[] small_prime_upperbound_array = {
				(2,2047),
				(3,1373653),
				(5,25326001),
				(7,3215031751),
				(11,2152302898747),
				(13,3474749660383),
				(17,341550071728321),
				(19,341550071728321),
				(23,3825123056546413051),
				(29,3825123056546413051),
				(31,3825123056546413051),
				(37,BigInteger.Parse("318665857834031151167461")),
				(41,BigInteger.Parse("3317044064679887385961981")),
				(43,BigInteger.Parse("6003094289670105800312596501")),
				(47,BigInteger.Parse("59276361075595573263446330101")),
				(53,BigInteger.Parse("564132928021909221014087501701")),
				(59,BigInteger.Parse("564132928021909221014087501701")),
				(61,BigInteger.Parse("1543267864443420616877677640751301")),
				(67,BigInteger.Parse("1543267864443420616877677640751301")),
				(71,BigInteger.Parse("100000000000000000000000000000000000")),
			};

			// 判定に使う innerValue から求まる d
			var d = innerValue - 1;
			while (d.IsEven)
			{
				d >>= 1;
			}

			foreach (var (n, upper) in small_prime_upperbound_array)
			{
				if (BigInteger.GreatestCommonDivisor(n, innerValue) != BigInteger.One)
				{
					// 最大公約数1以外を持つ。約数を持っているので合成数
					return PossibilityPrime.Composite;
				}

				// ミラーラビンテスト1つの元に対しての判定
				if (IsPrimeInnerMillerRabinInnerImplement(n, d) == PossibilityPrime.Composite)
				{
					// 合成数確定
					return PossibilityPrime.Composite;
				}
				if (innerValue < upper)
				{
					// 合成数でなく(擬素数)で、強擬素数の上限未満なら、素数確定
					return PossibilityPrime.Prime;
				}
			}
			// 乱数でミラーラビンテスト 確率的に。
			// 乱数発生器
			var randomgen = new Random();
			// 繰返し回数 : 間違う確率が 4^-k だとして、ビット長の 1/2 回以上繰り返す
			var bit_length = innerValue.GetBitLength();
			var loop_count = (bit_length >> 1) + 5;
			for (int i = 0; i < loop_count; i++)
			{
				var random = randomgen.Next(41, 0x0fff_ffff + 41);
				if (BigInteger.GreatestCommonDivisor(random, innerValue) != BigInteger.One)
				{
					// 最大公約数1以外を持つ。約数を持っているので合成数
					return PossibilityPrime.Composite;
				}
				if (IsPrimeInnerMillerRabinInnerImplement(random, d) == PossibilityPrime.Composite)
				{
					return PossibilityPrime.Composite;
				}
			}

			// すべての判定をすり抜ければ(確率的)素数確定
			return PossibilityPrime.Prime;
		}

		// ミラーラビンテスト
		private readonly PossibilityPrime IsPrimeInnerMillerRabinInnerImplement(Int32 a, BigInteger d)
		{
			var t = d;
			var y = BigInteger.ModPow(a, t, innerValue);
			var innerValue_1 = innerValue - 1;
			while (t != innerValue_1 && y != 1 && y != innerValue_1)
			{
				// y = (y * y) % innerValue;
				y = BigInteger.ModPow(y, 2, innerValue);    // (y * y) % innerValue
				t <<= 1;
			}
			if (y != innerValue_1 && t.IsEven)
			{
				return PossibilityPrime.Composite;
			}
			return PossibilityPrime.Prime;
		}

		/// <summary>
		/// 累乗して剰余を求める
		/// </summary>
		/// <param name="a">累乗する底</param>
		/// <param name="exp">指数</param>
		/// <param name="modulus">剰余を求める除数</param>
		/// <returns>a^exp % modulus</returns>
		public static QNumberBigInteger ModPow(QNumberBigInteger a, QNumberBigInteger exp, QNumberBigInteger modulus)
		{
			return new QNumberBigInteger(BigInteger.ModPow(a.innerValue, exp.innerValue, modulus.innerValue));
		}

		/// <summary>
		/// 0～prime-1 までの剰余に変換する
		/// </summary>
		/// <param name="a">元の値</param>
		/// <param name="prime">除数</param>
		/// <returns></returns>
		public static QNumberBigInteger Mod(QNumberBigInteger a, QNumberBigInteger prime)
		{
			return a.Mod(prime);
		}

		/// <summary>
		/// 0～prime-1 までの剰余に変換する
		/// </summary>
		/// <param name="modulus">除数</param>
		/// <returns></returns>
		public QNumberBigInteger Mod(QNumberBigInteger modulus)
		{
			if (this > modulus)
			{
				return this % modulus;
			}
			else if (IsNegative())
			{
				var abs = Abs();
				if (abs <= modulus)
				{
					return modulus - abs;
				}
				else
				{
					return modulus - abs % modulus;
				}
			}
			return this;
		}

		/// <summary>
		/// 累乗して剰余を求める
		/// </summary>
		/// <param name="exp">指数</param>
		/// <param name="modulus">剰余を求める除数</param>
		/// <returns>self^exp % modulus</returns>
		public readonly QNumberBigInteger PowMod(QNumberBigInteger exp, QNumberBigInteger modulus)
		{
			// return new QNumberBigInteger(BigInteger.ModPow(innerValue, exp.innerValue, modulus.innerValue));
			if (exp == Zero)
			{
				return One;
			}
			QNumberBigInteger e = exp.Mod(modulus - One);
			return new QNumberBigInteger(BigInteger.ModPow(innerValue, e.innerValue, modulus.innerValue));
		}

	}
}
