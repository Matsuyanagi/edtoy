using System.Numerics;

namespace ecc_20231118_curve448_toy
{
	public class QNumberBigInteger : QNumber<BigInteger>
	{

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

		public string? ToString(string? format)
		{
			return RawValue.ToString(format);
		}

		public string? ToString(IFormatProvider? provider)
		{
			return RawValue.ToString(provider);
		}

		public string? ToString(string? format, IFormatProvider? provider)
		{
			return RawValue.ToString(format, provider);
		}
	}
}
