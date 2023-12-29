using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecc_20231118_curve448_toy.CommandLineOptions;

namespace ecc_20231118_curve448_toy.EdwardsCurveComponents
{
	public static class CreatePrimeNumber
	{
		/// <summary>
		/// 素数候補生成バイトバッファ作成
		/// </summary>
		/// <param name="bit_length">ビット長</param>
		/// <returns></returns>
		public static byte[] CreateByteBuffer(int bit_length)
		{
			// バイト数
			var byte_length = (bit_length + 7) >> 3;
			byte[] bytes = new byte[byte_length + 1];
			return bytes;
		}


		/// <summary>
		/// 素数の元となる長さを持った乱数作成
		/// </summary>
		/// <param name="bit_length">ビット長</param>
		/// <param name="prime_n4_3">4N+3型素数生成</param>
		/// <param name="prime_n4_1">4N+1型素数生成</param>
		/// <param name="random">乱数発生器</param>
		/// <param name="bytes">バイトバッファ</param>
		/// <returns>指定のビット長を持つ奇数。素数判定はしていない</returns>
		public static QNumberBigInteger CreateFakePrimeRandomBit(int bit_length, bool prime_n4_3, bool prime_n4_1, Random random, byte[] bytes)
		{
			// バイト数
			var byte_length = (bit_length + 7) >> 3;
			bytes ??= new byte[byte_length + 1];
			// 全ビットランダム生成
			random.NextBytes(bytes);
			bytes[byte_length] = 0;

			// 最上位バイトの最上位ビットを立てる
			var top_byte_index = (bit_length - 1) >> 3;
			var top_bit_in_byte = 1 << ((bit_length - 1) & 7);
			var top_byte_mask = (top_bit_in_byte << 1) - 1;
			bytes[top_byte_index] |= (byte)top_bit_in_byte;
			bytes[top_byte_index] &= (byte)top_byte_mask;
			// 最下位ビットを立てる
			bytes[0] |= 1;

			if (prime_n4_3)
			{
				// 4n+3 型なら末尾 2bit を立てる
				bytes[0] |= 3;
			}
			else if (prime_n4_1)
			{
				// 4n+1 型なら末尾は 01 にする
				bytes[0] &= 0xfd;
			}

			QNumberBigInteger prime_number = new QNumberBigInteger(bytes);
			return prime_number;
		}

		/// <summary>
		/// 次の素数候補を求める
		/// </summary>
		/// <param name="bit_length">ビット長</param>
		/// <param name="prime_n4_3">4N+3型素数生成</param>
		/// <param name="prime_n4_1">4N+1型素数生成</param>
		/// <param name="random">乱数発生器</param>
		/// <param name="bytes">バイトバッファ</param>
		/// <param name="prime_number"></param>
		/// <returns>指定のビット長を持つ奇数。素数判定はしていない</returns>
		public static QNumberBigInteger CreateFakePrimeRandomBitNextPlus4(int bit_length, bool prime_n4_3, bool prime_n4_1, Random random, byte[] bytes, QNumberBigInteger prime_number)
		{
			prime_number += 4;
			if ((prime_number & (1 << (bit_length - 1))) == 0)
			{
				// 繰り上がりがあったら乱数で生成し直し
				prime_number = CreateFakePrimeRandomBit(bit_length, prime_n4_3, prime_n4_1, random, bytes);
			}
			return prime_number;
		}
	}
}
