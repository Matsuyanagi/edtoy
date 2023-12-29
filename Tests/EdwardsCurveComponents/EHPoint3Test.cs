using ecc_20231118_curve448_toy;
using ecc_20231118_curve448_toy.EdwardsCurveComponents;

namespace Tests.EdwardsCurveComponents
{
    internal class EHPoint3Test
    {
        [TestCase(0, 1, 1, "(0,1,1)")]
        [TestCase(0, 2, 2, "(0,2,2)")]
        [TestCase(-1, -100, -10, "(-1,-100,-10)")]
        public void TestEqualString(long x, long y, long z, string s)
        {
            Assert.That(new EHPoint3(x, y, z).ToString(), Is.EqualTo(s));
        }

        [TestCase(0, 1, 1, 17, 0, 1)]
        [TestCase(0, 10, 5, 17, 0, 2)]
        [TestCase(100, 10, 8, 19, 3, 6)]
        public void TestToAFPoint(long x, long y, long z, long prime, long ax, long ay)
        {
            Assert.That(new EHPoint3(x, y, z).ToAFPoint(prime), Is.EqualTo(new AFPoint(ax, ay)));
        }

        [TestCase(100, 10, 100, 10, 1)]
        [TestCase(-10, -1, -10, -1, 1)]
        public void TestFromAFPoint(long ax, long ay, long x, long y, long z)
        {
            Assert.That(new EHPoint3(new AFPoint(ax, ay)), Is.EqualTo(new EHPoint3(x, y, 1)));
        }


    }
}
