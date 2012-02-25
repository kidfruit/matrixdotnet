using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixDotNet
{
    public class Matrix : ICloneable
    {
        private double[,] values;

        public Matrix()
        {
            values = new double[0, 0];
        }
        public Matrix(int row, int column)
        {
            values = new double[row, column];
        }
        public Matrix(double[,] input)
        {
            try
            {
                values = input;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int Row
        { get { return values.GetLength(0); } }
        public int Column
        { get { return values.GetLength(1); } }

        public void Resize(int row, int column)
        {

            double[,] result = new double[row, column];
            int minRow = row < Row ? row : Row;
            int minColumn = column < Column ? column : Column;
            for (int i = 0; i < minRow; i++)
            {
                for (int j = 0; j < minColumn; j++)
                {
                    result[i, j] = values[i, j];
                }
            }
            values = result;
        }

        public void AddRowToRow(int src, int dest, double factor)
        {
            for (int j = 0; j < Column; j++)
            {
                values[dest, j] += values[src, j] * factor;
            }
        }

        public void MultiplyFactorToRow(int dest, double factor)
        {
            for (int j = 0; j < Column; j++)
            {
                values[dest, j] *= factor;
            }
        }

        public void AddNewRowToEnd(Vector newRow)
        {
            if (newRow.Count != Column)
            {
                throw new Exception("Matrix is not compatible");
            }

            this.Resize(Row + 1, Column);

            for (int j = 0; j < Column; j++)
            {
                values[Row - 1, j] = newRow[j];
            }
        }

        public void DelRowFromEnd()
        {
            this.Resize(Row - 1, Column);
        }

        public Matrix SubMatrix(int row, int column, int height, int weight)
        {
            Matrix result = new Matrix(height, weight);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    result[i, j] = values[row + i, column + j];
                }
            }
            return result;
        }

        public double this[int row, int column]
        {
            get
            {
                return values[row, column];
            }
            set
            {
                values[row, column] = value;
            }
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (double x in values)
            {
                hash += x.GetHashCode();
            }
            return hash;
        }

        public override bool Equals(object obj)
        {
            Matrix m = obj as Matrix;
            if (m == null)
            {
                return false;
            }
            if (Row != m.Row || Column != m.Column)
            {
                throw new Exception("Matrix is not compatible");
            }
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if (this[i, j] != m[i, j])
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public object Clone()
        {
            return new Matrix(values);
        }

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            return Object.Equals(m1, m2);
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !Object.Equals(m1, m2);
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Row != m2.Row || m1.Column != m2.Column)
            {
                throw new Exception("Matrix is not compatible");
            }
            Matrix result = new Matrix(m1.Row, m1.Column);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Column; j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }

            }
            return result;
        }
        public static Matrix operator *(Matrix m1, double factor)
        {
            Matrix result = new Matrix(m1.Row, m1.Column);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Column; j++)
                {
                    result[i, j] = m1[i, j] * factor;
                }

            }
            return result;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1.Row, m1.Column);
            result = m1 + (m2 * (-1));
            return result;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Column != m2.Row)
            {
                throw new Exception("Matrix is not compatible");
            }
            Matrix result = new Matrix(m1.Row, m2.Column);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m2.Column; j++)
                {
                    for (int k = 0; k < m2.Row; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return result;
        }

    }
}
