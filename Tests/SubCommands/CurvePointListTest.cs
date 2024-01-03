using ecc_20231118_curve448_toy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecc_20231118_curve448_toy.SubCommands;
using ecc_20231118_curve448_toy.EdwardsCurveComponents;

namespace Tests.SubCommands
{
	internal class CurvePointListTest
	{
		[TestCase(41, 1, 3, 10, "(0,1),(0,40),(1,0),(2,2),(2,39),(4,8),(4,33),(8,4),(8,37),(9,12)")]
		[TestCase(41, 23, 19, 10, "(0,1),(0,40),(4,13),(4,28),(5,0),(6,15),(6,26),(7,7),(7,34),(10,4)")]
		[TestCase(43, 4, 2, 10, "(0,1),(0,42),(3,13),(3,30),(5,9),(5,34),(7,7),(7,36),(8,18),(8,25)")]
		[TestCase(47, 1, 5, 10, "(0,1),(0,46),(1,0),(6,8),(6,39),(7,16),(7,31),(8,6),(8,41),(10,21)")]
		[TestCase(47, 4, 5, 10, "(0,1),(0,46),(1,6),(1,41),(2,13),(2,34),(3,2),(3,45),(4,20),(4,27)")]
		public void TestEdwardsCurvePointList(int prime, int param_a, int param_d, int number, string result_str)
		{
			Assert.That(String.Join(',', CurvePointList.EdwardsCurvePointList(prime, param_a, param_d, false).Take(number).ToList()), Is.EqualTo(result_str));
		}

	}
}
