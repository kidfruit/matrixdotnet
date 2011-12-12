using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixDotNet
{
    public class Vector:List<double>
    {
        public Vector():base(){}
        public Vector(params double[] vals):base()
        {
            base.AddRange(vals);
        }
        public void ResetValue(params double[] vals)
        {
            base.Clear();
            base.AddRange(vals);
        }

        public Vector SubVector(int beginIndex, int endIndex)
        {
            double[] temp = new double[endIndex - beginIndex + 1];
            base.GetRange(beginIndex, endIndex - beginIndex + 1).CopyTo(temp);
            return new Vector(temp);
        }

        public static Vector operator+(Vector v1,Vector v2)
        {
            if (v1.Count!=v2.Count)
            {
                throw new Exception("Vector is not compatible");
            }
            else
            {
                double[] results = new double[v1.Count];
                for (int i = 0; i < v2.Count; i++)
                {
                    results[i] = v1[i] + v2[i];
                }
                return new Vector(results);
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
                double[] results = new double[v1.Count];
                for (int i = 0; i < v2.Count; i++)
                {
                    results[i] = v1[i] - v2[i];
                }
                return new Vector(results);
            }
        }
    }
}
