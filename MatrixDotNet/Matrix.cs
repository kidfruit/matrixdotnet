using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixDotNet
{
    public class Matrix:List<Vector>
    {
        private int row, column;

        public Matrix() : base() { row = 0; column = 0; }
        public Matrix(double[,] vals):base()
        {
            row = vals.GetLength(0);
            column = vals.GetLength(1);
            for (int i = 0; i < row;i++ )
            {
                Vector tempRow=new Vector();
                for (int j = 0; j < column; j++)
                {
                    tempRow.Add(vals[i, j]);
                }
                this.Add(tempRow);
            }

        }
        public Matrix(params Vector[] vals):base()
        {
            foreach(Vector item in vals)
            {
                if (item.Count!=vals[0].Count)
                {
                    throw new Exception("Vector is not compatible");
                }
            }
            this.AddRange(vals);
            row=vals.Length;
            column = vals[0].Count;
        }

        public static Matrix operator+(Matrix m1,Matrix m2)
        {
            if (m1.Count != m2.Count)
            {
                throw new Exception("Matrix is not compatible");
            }
            else
            {
                Vector[] results = new Vector[m1.Count];
                for (int i = 0; i < m2.Count; i++)
                {
                    results[i] = m1[i] + m2[i];
                }
                return new Matrix(results);
            }
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.Count != m2.Count)
            {
                throw new Exception("Matrix is not compatible");
            }
            else
            {
                Vector[] results = new Vector[m1.Count];
                for (int i = 0; i < m2.Count; i++)
                {
                    results[i] = m1[i] - m2[i];
                }
                return new Matrix(results);
            }
        }
       

    }
}
