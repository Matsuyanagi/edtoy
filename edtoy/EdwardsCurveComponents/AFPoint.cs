using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edtoy.EdwardsCurveComponents
{
    /// <summary>
    /// Affine Point
    /// アフィン座標点
    /// </summary>
    public readonly record struct AFPoint(QNumberBigInteger X, QNumberBigInteger Y)
    {
        public AFPoint() : this(0, 0)
        {
        }

        public static AFPoint Identity => new(0, 1);

        public static AFPoint EdwardsCurveAdd(AFPoint p1, AFPoint p2, QNumberBigInteger d, QNumberBigInteger prime)
        {
            var A = p1.X.MulMod(p2.Y, prime);   // x1y2
            var B = p1.Y.MulMod(p2.X, prime);   // y1x2
            var C = p1.Y.MulMod(p2.Y, prime);   // y1y2
            var D = p1.X.MulMod(p2.X, prime);   // x1x2
            var E = d.MulMod(A, prime).MulMod(B, prime);                // dx1x2y1y2
            var F = new QNumberBigInteger(1).AddMod(E, prime);          // 1+dx1x2y1y2
            var G = new QNumberBigInteger(1).AddMod(-E, prime);         // 1-dx1x2y1y2
            var x3 = A.AddMod(B, prime).DivMod(F, prime);               // (x1y2+y1x2)/(1+dx1x2y1y2)
            var y3 = C.AddMod(-D, prime).DivMod(G, prime);              // (y1y2-x1x2)/(1-dx1x2y1y2)
            return new AFPoint(x3, y3);
        }

        public static AFPoint EdwardsCurveAdd(AFPoint p1, AFPoint p2, QNumberBigInteger a, QNumberBigInteger d, QNumberBigInteger prime)
        {
            var A = p1.X.MulMod(p2.Y, prime);   // x1y2
            var B = p1.Y.MulMod(p2.X, prime);   // y1x2
            var C = p1.Y.MulMod(p2.Y, prime);   // y1y2
            var D = p1.X.MulMod(p2.X, prime).MulMod(a, prime);   // ax1x2
            var E = d.MulMod(A, prime).MulMod(B, prime);                // dx1x2y1y2
            var F = new QNumberBigInteger(1).AddMod(E, prime);          // 1+dx1x2y1y2
            var G = new QNumberBigInteger(1).AddMod(-E, prime);         // 1-dx1x2y1y2
            var x3 = A.AddMod(B, prime).DivMod(F, prime);               // (x1y2+y1x2)/(1+dx1x2y1y2)
            var y3 = C.AddMod(-D, prime).DivMod(G, prime);              // (y1y2-ax1x2)/(1-dx1x2y1y2)
            return new AFPoint(x3, y3);
        }

		public override string ToString()
		{
			return $"({X},{Y})";
		}
    }
}
