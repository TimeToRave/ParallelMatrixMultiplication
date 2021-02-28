using System;

namespace ParallelMatrix
{
	class Program
	{
		/// <summary>
		/// Пример использование класса Matrix
		/// </summary>
		static void Main()
		{
			Matrix a = new Matrix(
				new double[4, 4]
				{
					{1,1,1,1},
					{2,2,2,2},
					{3,3,3,3},
					{4,4,4,4}
				}
			);

			Matrix b = new Matrix(
				new double[4, 4]
				{
					{1,1,1,1},
					{2,2,2,2},
					{3,3,3,3},
					{4,4,4,4}
				}
			);

			Console.WriteLine((a * b).Print());
			Console.ReadKey();
		}

	}
}
