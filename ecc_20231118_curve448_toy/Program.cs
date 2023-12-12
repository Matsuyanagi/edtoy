namespace ecc_20231118_curve448_toy
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			QNumberBigInteger x = new(2);
			QNumberBigInteger y = new(5);
			QNumberBigInteger prime = new(43);
			QNumberBigInteger d = new(2);
			EHPoint3 eh3_base_point = new(x, y, 1);
			AFPoint afp_base_point = new(x, y);
			EHPoint3 eh3 = new(x, y, 1);
			AFPoint afp = new(x, y);
			int order = 1;
			for (int i = 0; i < prime * 3; i++)
			{
				if (afp != eh3.ToAFPoint(prime)){
					Console.WriteLine( "Error:" );
					Console.WriteLine( "afp  : %s", afp.ToString() );
					Console.WriteLine( "eh3  : %s", eh3.ToAFPoint(prime).ToString() );
					return ;
				}
				Console.WriteLine( "order = {1}, afp,eh3  : {0}", eh3.ToAFPoint(prime).ToString(), order );

				if (afp == AFPoint.Identity)
				{
					break;
				}
				afp = AFPoint.EdwardsCurveAdd(afp, afp_base_point, d, prime);
				eh3 = EHPoint3.EdwardsCurveAdd(eh3, eh3_base_point, d, prime);
				order += 1;
			}
		}
	}
}
