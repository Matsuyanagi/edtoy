using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecc_20231118_curve448_toy
{
	/// <summary>
	/// Affine Point
	/// アフィン座標点
	/// </summary>
	public readonly struct AFPoint(Int64 x, Int64 y) : IEquatable<AFPoint>
	{
		public QNumberBigInteger X { get; } = new QNumberBigInteger(x);
		public QNumberBigInteger Y { get; } = new QNumberBigInteger(y);

		public AFPoint() : this(0, 0)
		{
		}

		public static AFPoint Identity => new(0, 1);

		public override readonly string ToString() => $"({X},{Y})";

		public readonly bool Equals(AFPoint other) => X == other.X && Y == other.Y;
		public override bool Equals(object? obj) => obj is AFPoint objS && Equals(objS);

		public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode();
	}
}
