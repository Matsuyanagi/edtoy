using edtoy;
using edtoy.EdwardsCurveComponents;

namespace Tests.EdwardsCurveComponents
{
    internal class EHPoint4Test
    {
        [TestCase(0, 1, 1, 43, "(0,1,1,0)")]
        [TestCase(0, 2, 2, 43, "(0,2,2,0)")]
        [TestCase(-1, -100, -10, 43, "(-1,-100,-10,14)")]
        public void TestEqualString(long x, long y, long z, long prime, string s)
        {
            Assert.That(new EHPoint4(x, y, z, prime).ToString(), Is.EqualTo(s));
        }

        [TestCase(0, 1, 1, 17, 0, 1)]
        [TestCase(0, 10, 5, 17, 0, 2)]
        [TestCase(100, 10, 8, 19, 3, 6)]
        public void TestToAFPoint(long x, long y, long z, long prime, long ax, long ay)
        {
            Assert.That(new EHPoint4(x, y, z, prime).ToAFPoint(), Is.EqualTo(new AFPoint(ax, ay)));
        }

        [TestCase(100, 10, 47, 100, 10, 1)]
        [TestCase(-10, -1, 47, -10, -1, 1)]
        public void TestFromAFPoint(long ax, long ay, long prime, long x, long y, long z)
        {
            Assert.That(new EHPoint4(new AFPoint(ax, ay), prime), Is.EqualTo(new EHPoint4(x, y, z, prime)));
        }
    }
}
