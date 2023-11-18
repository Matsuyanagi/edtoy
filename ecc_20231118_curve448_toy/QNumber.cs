using System.Numerics;

namespace ecc_20231118_curve448_toy
{
	public class QNumber<T> where T : IBinaryInteger<T>
	{
		protected T innerValue = T.Zero;

		public T RawValue => innerValue;

		public int CompareTo(QNumber<T> y)
		{
			return innerValue.CompareTo(y);
		}

		public override bool Equals(object? obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return innerValue.Equals(obj);
		}

		public override int GetHashCode()
		{
			return innerValue.GetHashCode();
		}

		public override string? ToString()
		{
			return innerValue.ToString();
		}

	}
}
