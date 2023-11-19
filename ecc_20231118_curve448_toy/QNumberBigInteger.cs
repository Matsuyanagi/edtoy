using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace ecc_20231118_curve448_toy
{
	public struct QNumberBigInteger : IBinaryInteger<QNumberBigInteger>
	{
		BigInteger innerValue = BigInteger.Zero;

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

		public static QNumberBigInteger One => throw new NotImplementedException();

		public static int Radix => throw new NotImplementedException();

		public static QNumberBigInteger Zero => throw new NotImplementedException();

		public static QNumberBigInteger AdditiveIdentity => throw new NotImplementedException();

		public static QNumberBigInteger MultiplicativeIdentity => throw new NotImplementedException();

		public static QNumberBigInteger Abs(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsCanonical(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsComplexNumber(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static bool IsEvenInteger(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
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

		public int CompareTo( QNumberBigInteger x )
		{
			return innerValue.CompareTo( x.innerValue );
		}

		public int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}

		public override bool Equals(object? obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return innerValue.Equals(((QNumberBigInteger)obj).innerValue );
		}

		public bool Equals(QNumberBigInteger other)
		{
			throw new NotImplementedException();
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

		public override string? ToString()
		{
			return innerValue.ToString();
		}

		public string? ToString(string? format)
		{
			return innerValue.ToString(format);
		}

		public string? ToString(IFormatProvider? provider)
		{
			return innerValue.ToString(provider);
		}

		public string ToString(string? format, IFormatProvider? provider)
		{
			return innerValue.ToString(format, provider);
		}

		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
		{
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator +(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator -(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator -(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator ~(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator ++(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator --(QNumberBigInteger value)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator *(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator /(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator %(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator &(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator |(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator ^(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator <<(QNumberBigInteger value, int shiftAmount)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator >>(QNumberBigInteger value, int shiftAmount)
		{
			throw new NotImplementedException();
		}

		public static bool operator ==(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static bool operator !=(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static bool operator <=(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static bool operator >=(QNumberBigInteger left, QNumberBigInteger right)
		{
			throw new NotImplementedException();
		}

		public static QNumberBigInteger operator >>>(QNumberBigInteger value, int shiftAmount)
		{
			throw new NotImplementedException();
		}
	}
}
