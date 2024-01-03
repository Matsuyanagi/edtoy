using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecc_20231118_curve448_toy.EdwardsCurveComponents
{
	public static class RandomNumber
	{
		static readonly Random randomgen = new();

		/// <summary>
		/// lower_number ～ upper_number の間の乱数を生成する。両端を含む。
		/// </summary>
		/// <param name="lower_number">下限</param>
		/// <param name="upper_number">上限</param>
		/// <returns>[ lower_number～upper_number ] 間の乱数</returns>
		public static QNumberBigInteger GenerateRandomNumber(QNumberBigInteger lower_number, QNumberBigInteger upper_number)
		{
			var range_max = upper_number - lower_number;
			var bit_length = (int)range_max.GetBitLength();
			var odd_bit_num = bit_length & 7;               // 8bit 未満の半端ビット数
			var byte_length = (bit_length + 7) >> 3;        //	(odd_bit_num != 0 ? 1 : 0);
			var random_byte_buffer = new byte[byte_length + 1];
			var msb_byte_mask = (1 << odd_bit_num) - 1;     // マスクビット。半端ビットが 0 なら 0

			QNumberBigInteger r;
			while (true)
			{
				randomgen.NextBytes(random_byte_buffer);
				random_byte_buffer[^1] = 0;
				random_byte_buffer[^2] &= (byte)msb_byte_mask;
				r = new QNumberBigInteger(random_byte_buffer);
				if (r <= range_max)
				{
					break;
				}
			}

			return r + lower_number;
		}
	}
}
