using NUnit.Framework;
using ParallelMatrix;

namespace ParralelMatrixTest
{
	public class Tests
	{
		/// <summary>
		/// Проверка метода сравнения двух матриц
		/// </summary>
		[Test]
		public void Matrix_AreEquals()
		{
			Matrix a = new Matrix(
				new double[2, 2]
				{
					{1,1},
					{2,2}
				}
			);

			Matrix b = new Matrix(
				new double[2, 2]
				{
					{1,1},
					{2,2}
				}
			);

			Assert.IsTrue(a.Equals(b));
		}

		/// <summary>
		/// Проверка метода сравнения двух матриц 
		/// На вход подаются не равные матрицы
		/// </summary>
		[Test]
		public void Matrix_AreNotEquals()
		{
			Matrix a = new Matrix(
				new double[2, 2]
				{
					{1,1},
					{2,2}
				}
			);

			Matrix b = new Matrix(
				new double[2, 2]
				{
					{1,1},
					{2,3}
				}
			);

			Assert.IsFalse(a.Equals(b));
		}

		/// <summary>
		/// Проверка перемноженяи матриц
		/// Размерность матриц : 2
		/// </summary>
		[Test]
		public void Matrix_Multiply_2x2()
		{
			Matrix etalon = new Matrix(
				new double [2, 2]
				{
					{19, 22},
					{43, 50}
				}

			);

			Matrix a = new Matrix(
				new double[2, 2]
				{
					{1,2},
					{3,4}
				}
			);

			Matrix b = new Matrix(
				new double[2, 2]
				{
					{5,6},
					{7,8}
				}
			);

			Matrix matrixMultiplyResult = (a * b);

			
			Assert.IsTrue(etalon.Equals(matrixMultiplyResult));
		}

		/// <summary>
		/// Проверка перемноженяи матриц
		/// Размерность матриц : 1
		/// Граничный случай
		/// </summary>
		[Test]
		public void Matrix_Multiply_1x1()
		{
			Matrix etalon = new Matrix(
				new double[1, 1]
				{
					{ 6 }
				}

			);


			Matrix a = new Matrix(
				new double[1, 1]
				{
					{ 2 }
				}
			);

			Matrix b = new Matrix(
				new double[1, 1]
				{
					{ 3 }
				}
			);

			Matrix matrixMultiplyResult = (a * b);


			Assert.IsTrue(etalon.Equals(matrixMultiplyResult));
		}
	}
}