using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatrixDotNet;

namespace TestForMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(new double[] { 1, 2, 3 });
            a.Add(4);
            a.AddRange(new double[] { 5, 6, 7 });
            bool x = a.Contains(4);
            Vector b = a;
            Vector c = a.SubVector(1, 3);
            Vector d = a + b;
            Matrix m1 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix m2 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix m3 = new Matrix();
            m3 = m1 - m2;

            Console.WriteLine(a.Count);
        }
    }
}
