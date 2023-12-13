namespace ecc_20231118_curve448_toy
{
	public readonly struct EHPoint4(QNumberBigInteger x, QNumberBigInteger y, QNumberBigInteger z, QNumberBigInteger prime) : IEquatable<EHPoint4>
	{
		public QNumberBigInteger X { get; } = x;
		public QNumberBigInteger Y { get; } = y;
		public QNumberBigInteger Z { get; } = z;
		public QNumberBigInteger T { get; } = x.MulMod(y, prime);

		public QNumberBigInteger Prime { get; } = prime;

		public EHPoint4() : this(0, 0, 1, 0)
		{
		}

		public EHPoint4(AFPoint ap, QNumberBigInteger prime) : this(ap.X, ap.Y, 1, ap.X.MulMod(ap.Y, prime))
		{
		}

		private static readonly EHPoint4 _identity = new(0, 1, 1, 0);
		public static EHPoint4 Identity => _identity;

		public override string ToString() => $"({X},{Y},{Z},{T})";

		public bool Equals(EHPoint4 other) => X == other.X && Y == other.Y && Z == other.Z && T == other.T;

		public override bool Equals(object? obj) => obj is EHPoint4 objS && Equals(objS);

		public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + Y.GetHashCode();

		public AFPoint ToAFPoint(QNumberBigInteger prime) => new(X.DivMod(Z, prime), Y.DivMod(Z, prime));


		public static EHPoint4 EdwardsCurveAdd(EHPoint4 p1, EHPoint4 p2, QNumberBigInteger a, QNumberBigInteger d)
		{
			// https://hyperelliptic.org/EFD/g1p/auto-twisted-extended.html
			var prime = p1.Prime;
			var A = p1.X.MulMod(p2.X, prime);
			var B = p1.Y.MulMod(p2.Y, prime);
			var C = p1.Z.MulMod(p2.T, prime);
			var D = p1.T.MulMod(p2.Z, prime);
			var E = D.AddMod(C, prime);
			var F = p1.X.AddMod(-p1.Y, prime).MulMod(p2.X.AddMod(p2.Y, prime).AddMod(B, prime).AddMod(-A, prime), prime);
			var G = B.AddMod(a.MulMod(A, prime), prime);
			var H = D.AddMod(-C, prime);

			var px = E.MulMod(F, prime);
			var py = G.MulMod(H, prime);
			var pz = F.MulMod(G, prime);
			return new EHPoint4(px, py, pz, prime);
		}

		public static bool operator ==(EHPoint4 left, EHPoint4 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(EHPoint4 left, EHPoint4 right)
		{
			return !(left == right);
		}
	}
}
