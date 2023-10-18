using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    public class MyMatrix
    {
        protected int[,] matrix;
        protected int cols;
        protected int rows;

        public int Cols { get { return cols; } }
        public int Rows { get { return rows; } }

        public MyMatrix(int Cols, int Rows)
        {
            this.cols = Cols;
            this.rows = Rows;
        }
        public void Filler(int m, int n, int minValue, int maxValue)
        {
            matrix = new int[m, n];
            Random random = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

        public void Fill(int minValue, int maxValue)
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

        public void ChangeSize(int new_cols, int new_rows, int minValue, int maxValue)
        {
            Random random = new Random();
            int[,] new_matrix = new int[new_cols, new_rows];
            for (int i = 0; i < Math.Min(new_rows, matrix.GetLength(0)); i++)
            {
                for (int j = 0; j < Math.Min(new_cols, matrix.GetLength(1)); j++)
                {
                    new_matrix[i, j] = matrix[i, j];
                }
            }
            if (new_rows > matrix.GetLength(0) || new_cols > matrix.GetLength(1))
            {
                for (int i = Math.Min(new_rows, matrix.GetLength(0)); i < new_rows; i++)
                {
                    for (int j = Math.Min(matrix.GetLength(1), new_cols); j < new_cols; j++)
                    {
                        new_matrix[i, j] = random.Next(minValue, maxValue + 1);
                    }
                }
            }
            matrix = new_matrix;
        }

        public void ShowPartialy(int start_row, int end_row, int start_coll, int end_coll)
        {
            for (int i = start_row; i < end_row; i++)
            {
                for (int j =  start_coll; j < end_coll; j++)
                {
                    Console.WriteLine(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Show()
        {
            ShowPartialy(0, matrix.GetLength(0) - 1, 0, matrix.GetLength(1) - 1);
        }

        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }
    }
}
