using edtoy.EdwardsCurveComponents;

namespace edtoy
{
    public readonly record struct EHPoint4(QNumberBigInteger X, QNumberBigInteger Y, QNumberBigInteger Z, QNumberBigInteger T, QNumberBigInteger Prime)
	{
		public EHPoint4(AFPoint ap, QNumberBigInteger prime) : this(ap.X, ap.Y, 1, prime)
		{
		}

		public EHPoint4(QNumberBigInteger x, QNumberBigInteger y, QNumberBigInteger z, QNumberBigInteger prime) : this(x, y, z, x.MulMod(y, prime), prime)
		{
		}

		public AFPoint ToAFPoint() => new(X.DivMod(Z, Prime), Y.DivMod(Z, Prime));

		public static EHPoint4 EdwardsCurveAdd(EHPoint4 p1, EHPoint4 p2, QNumberBigInteger a, QNumberBigInteger d)
		{
			// https://hyperelliptic.org/EFD/g1p/auto-twisted-extended.html
			var prime = p1.Prime;

			var A = p1.X.MulMod(p2.X, prime);
			var B = p1.Y.MulMod(p2.Y, prime);
			var C = p1.T.MulMod(p2.T, prime).MulMod(d, prime);
			var D = p1.Z.MulMod(p2.Z, prime);
			var E = p1.X.AddMod(p1.Y, prime).MulMod(p2.X.AddMod(p2.Y, prime), prime).AddMod(-B, prime).AddMod(-A, prime);
			var F = D.AddMod(-C, prime);
			var G = D.AddMod(C, prime);
			var H = B.AddMod(-(a.MulMod(A, prime)), prime);
			var px = E.MulMod(F, prime);
			var py = G.MulMod(H, prime);
			var pz = F.MulMod(G, prime);
			var pt = E.MulMod(H, prime);
			return new EHPoint4(px, py, pz, pt, prime);
		}

		public override string ToString()
		{
			return $"({X},{Y},{Z},{T})";
		}
	}
}
