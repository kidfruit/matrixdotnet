using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace MatrixDotNet
{
    public class Vector : IEnumerable
    {
        private double[] values;
        public Vector(int length)
        {
            values = new double[length];
        }
        public Vector(params double[] input)
        {
            values = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                values[i] = input[i];
            }

        }

        public double this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return values.Length;
            }
        }
        public void ResetVector(params double[] input)
        {
            values = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                values[i] = input[i];
            }
        }

        public Vector SubVector(int startIndex, int length)
        {
            Vector result = new Vector(length);
            for (int i = startIndex; i < startIndex + length; i++)
            {
                result[i] = this[i];
            }
            return result;

        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Count != v2.Count)
            {
                throw new Exception("Vector is not compatible");
            }
            else
            {
                Vector result = new Vector(v1.Count);
                for (int i = 0; i < v2.Count; i++)
                {
                    result[i] = v1[i] + v2[i];
                }
                return result;
            }
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.Count != v2.Count)
            {
                throw new Exception("Vector is not compatible");
            }
            else
            {
                Vector result = new Vector(v1.Count);
                for (int i = 0; i < v2.Count; i++)
                {
                    result[i] = v1[i] - v2[i];
                }
                return result;
            }
        }



        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
