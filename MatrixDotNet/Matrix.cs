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
        //public void AddRowToRow(int src, int dest, double val);
        //public void MultiplyValueToRow(int dest, double val);
        //public void AddRowToEnd(Vector newRow);
        //public void DelRowFromEnd();
        //public Matrix SubMatrix(int x, int y, int w, int h);

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
                throw new Exception("Vector is not compatible");
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
    }
}
