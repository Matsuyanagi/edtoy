using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using edtoy;
using edtoy.EdwardsCurveComponents;

namespace Tests.EdwardsCurveComponents
{
	internal class RandomNumberTest
	{
		[TestCase(0, 1)]
		[TestCase(10, 100)]
		[TestCase(20, 22)]
		[TestCase(30, 32)]
		[TestCase(20, 20 + 255)]
		public void TestRandomNumber(long lower, long upper)
		{
			var l = new QNumberBigInteger(lower);
			var u = new QNumberBigInteger(upper);
			var loop_max = QNumberBigInteger.Min(new QNumberBigInteger((upper - lower) * 100), new QNumberBigInteger(10000));
			for (QNumberBigInteger i = 0; i < loop_max; i += QNumberBigInteger.One)
			{
				QNumberBigInteger r = RandomNumber.GenerateRandomNumber(l, u);
				Assert.That(r, Is.GreaterThanOrEqualTo(l).And.LessThanOrEqualTo(u));
			}
		}

		[TestCase("175271659012809421538481559539804492300864191203555039392302554344118262080757", "175271659012809421538481559539804492300864191203555039392302554344118262080758")]
		[TestCase("175271659012809421538481559539804492300864191203555039392302554344118262080757", "599089435033715639295905496504527205178779601294652617905640131780422848461269")]
		public void TestRandomNumber(string lower, string upper)
		{
			var l = QNumberBigInteger.Parse(lower);
			var u = QNumberBigInteger.Parse(upper);
			var loop_max = QNumberBigInteger.Min((u - l) * new QNumberBigInteger(100), new QNumberBigInteger(10000));
			for (QNumberBigInteger i = QNumberBigInteger.Zero; i < loop_max; i += QNumberBigInteger.One)
			{
				QNumberBigInteger r = RandomNumber.GenerateRandomNumber(l, u);
				Assert.That(r, Is.GreaterThanOrEqualTo(l).And.LessThanOrEqualTo(u));
			}
		}

	}
}
