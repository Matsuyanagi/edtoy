namespace ecc_20231118_curve448_toy
{
	/// <summary>
	/// Extended Homogeneous Coordinates Point
	/// 拡張同次座標
	/// </summary>
	public readonly struct EHPoint(Int64 x, Int64 y, Int64 z) : IEquatable<EHPoint>
	{
		public QNumberBigInteger X { get; } = new(x);
		public QNumberBigInteger Y { get; } = new(y);
		public QNumberBigInteger Z { get; } = new(z);

		public EHPoint() : this(0, 0, 1)
		{
		}

		private static EHPoint _identity = new(0, 1, 1);
		public static EHPoint Identity => _identity;

		public override string ToString() => $"({X},{Y},{Z})";

		public bool Equals(EHPoint other) => X == other.X && Y == other.Y && Z == other.Z;

		public override bool Equals(object? obj) => obj is EHPoint objS && Equals(objS);

		public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();

	}
}
