using System;
using System.Linq;
using System.Threading;

namespace ParallelMatrix
{
	/// <summary>
	/// Класс реализующий перемножение матриц
	/// Обработка каждой ячейки матрицы при умножении
	/// происходит в отдельном потоке
	/// </summary>
	public class Matrix
	{
		public double[,] Data { get; set; }
		public int Size { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="data"></param>
		public Matrix(double[,] data)
		{
			Data = data;
			Size = data.GetLength(0);
		}

		/// <summary>
		/// Конструктор
		/// Создает пустую матрицу с заданным размером
		/// </summary>
		/// <param name="size"></param>
		public Matrix(int size)
		{
			Data = new double[size, size];
			Size = size;
		}

		/// <summary>
		/// Опеератор перемножения двух матриц
		/// </summary>
		/// <returns>Матрица - результат перемножения</returns>
		public static Matrix operator * (Matrix source, Matrix factor)
		{
			Matrix result = new Matrix(source.Size);
			object locker = new object();

			for (int i = 0; i < source.Size; i++)
			{
				for (int j = 0; j < source.Size;)
				{

					Thread th = new Thread(() =>
					{
						int threadI = 0;
						int threadJ = 0;


						lock (locker)
						{
							threadI = i;
							threadJ = j;
							j++;
						}

						if (threadI < source.Size && threadJ < source.Size)
						{
							for (int k = 0; k < source.Size; k++)
							{
								result.Data[threadI, threadJ] += source.Data[threadI, k] * factor.Data[k, threadJ];
							}
						}
					});

					th.Name = String.Format("Thread ID: {0}", Guid.NewGuid());
					th.Start();
				}
			}

			return result;
		}

		/// <summary>
		/// Метод для сравнивания двух метриц
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(Object obj)
		{
			bool result = false;

			Matrix equalsMatrix = obj as Matrix;

			if (equalsMatrix != null)
			{
				result =
				Data.Rank == equalsMatrix.Data.Rank &&
				Enumerable.Range(0, Data.Rank).All(dimension => Data.GetLength(dimension) == equalsMatrix.Data.GetLength(dimension)) &&
				Data.Cast<double>().SequenceEqual(equalsMatrix.Data.Cast<double>());
			}

			return result;
		}

		/// <summary>
		/// Перепоределение метода
		/// </summary>
		/// <returns>Хэш объекта</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		/// <summary>
		/// Метод для вывода матрицы в консоль
		/// </summary>
		public string Print()
		{
			string result = string.Empty;
			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
				{
					result += (string.Format("	{0}", Data[i, j]));
				}
				result += "\n";
			}

			return result;
		}
	}
}
