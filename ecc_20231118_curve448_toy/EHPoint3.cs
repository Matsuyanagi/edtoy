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


		public static EHPoint3 EdwardsCurveAdd(EHPoint3 p1, EHPoint3 p2, QNumberBigInteger d, QNumberBigInteger prime)
		{
			var A = p1.Z.MulMod(p2.Z, prime);
			var B = A.MulMod(A, prime);
			var C = p1.X.MulMod(p2.X, prime);
			var D = p1.Y.MulMod(p2.Y, prime);
			var E = d.MulMod(C.MulMod(D, prime), prime);
			var F = B.AddMod(-E, prime);
			var G = B.AddMod(E, prime);
			var H = p1.X.AddMod(p1.Y, prime).MulMod(p2.X.AddMod(p2.Y, prime), prime);
			var px = A.MulMod(F, prime).MulMod(H.AddMod(-C, prime).AddMod(-D, prime), prime);
			var py = A.MulMod(G, prime).MulMod(D.AddMod(-C, prime), prime);
			var pz = F.MulMod(G, prime);
			return new EHPoint3(px, py, pz);
		}
	}
}
