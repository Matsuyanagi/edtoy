﻿using System;
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
	public readonly struct AFPoint(QNumberBigInteger x, QNumberBigInteger y) : IEquatable<AFPoint>
	{
		public QNumberBigInteger X { get; } = x;
		public QNumberBigInteger Y { get; } = y;

		public AFPoint() : this(0, 0)
		{
		}

		public static AFPoint Identity => new(0, 1);

		public override readonly string ToString() => $"({X},{Y})";

		public readonly bool Equals(AFPoint other) => X == other.X && Y == other.Y;
		public override bool Equals(object? obj) => obj is AFPoint objS && Equals(objS);

		public override int GetHashCode() => X.GetHashCode() + Y.GetHashCode();

		public static bool operator ==(AFPoint left, AFPoint right)
		{
			return left.X == right.X && left.Y == right.Y;
		}

		public static bool operator !=(AFPoint left, AFPoint right)
		{
			return !(left == right);
		}
	}
}
