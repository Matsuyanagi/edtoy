namespace ecc_20231118_curve448_toy
{
	/// <summary>
	/// Extended Homogeneous Coordinates Point
	/// 拡張同次座標 (X;Y;Z)
	/// </summary>
	public readonly struct EHPoint3(QNumberBigInteger x, QNumberBigInteger y, QNumberBigInteger z) : IEquatable<EHPoint3>
	{
		public QNumberBigInteger X { get; } = x;
		public QNumberBigInteger Y { get; } = y;
		public QNumberBigInteger Z { get; } = z;

		public EHPoint3() : this(0, 0, 1)
		{
		}

		public EHPoint3(AFPoint ap) : this(ap.X, ap.Y, 1)
		{
		}

		private static readonly EHPoint3 _identity = new(0, 1, 1);
		public static EHPoint3 Identity => _identity;

		public override string ToString() => $"({X},{Y},{Z})";

		public bool Equals(EHPoint3 other) => X == other.X && Y == other.Y && Z == other.Z;

		public override bool Equals(object? obj) => obj is EHPoint3 objS && Equals(objS);

		public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();

		public AFPoint ToAFPoint(QNumberBigInteger prime) => new(X.DivMod(Z, prime), Y.DivMod(Z, prime));

	}
}
