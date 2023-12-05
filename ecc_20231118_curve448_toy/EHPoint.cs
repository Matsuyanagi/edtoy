namespace ecc_20231118_curve448_toy
{
	/// <summary>
	/// Extended Homogeneous Coordinates Point
	/// 拡張同次座標
	/// </summary>
	public struct EHPoint
	{
		public QNumberBigInteger X { get; }
		public QNumberBigInteger Y { get; }
		public QNumberBigInteger Z { get; }

		public EHPoint() : this(0, 0, 1)
		{
		}

		public EHPoint(Int64 x, Int64 y, Int64 z = 1)
		{
			X = new QNumberBigInteger(x);
			Y = new QNumberBigInteger(y);
			Z = new QNumberBigInteger(z);
		}
		public static EHPoint Identity => new EHPoint(0, 1, 1);

		public override string ToString()
		{
			return $"({X},{Y},{Z})";
		}
	}
}
