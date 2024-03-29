﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace MatrixDotNet
{
    public class Vector : ICloneable
    {
        private double[] values;
        public Vector(int length)
        {
            values = new double[length];
            for (int i = 0; i < length; i++)
            {
                values[i] = 0;
            }
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
                result[i - startIndex] = this[i];
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

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !Object.Equals(v1, v2);
        }
        public static bool operator ==(Vector v1, Vector v2)
        {
            return Object.Equals(v1, v2);
        }
        public override bool Equals(object o)
        {
            Vector v = o as Vector;
            if (v == null)
            {
                return false;
            }
            if (this.Count != v.Count)
            {
                throw new Exception("Vector is not compatible");
            }

            return values.SequenceEqual(v.values);
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

        public object Clone()
        {
            return new Vector(this.values);
        }

        public int GetMaxValueIndex()
        {
            int index = 0;
            double maxValue = double.MinValue;
            for (int i = 0; i < Count; i++)
            {
                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                    index = i;
                }
            }
            return index;
        }
        public int GetMinValueIndex()
        {
            int index = 0;
            double minValue = double.MaxValue;
            for (int i = 0; i < Count; i++)
            {
                if (values[i] < minValue)
                {
                    minValue = values[i];
                    index = i;
                }
            }
            return index;
        }
        public int GetPositiveMinValueIndex()
        {
            int index = 0;
            double minValue = double.MaxValue;
            for (int i = 0; i < Count; i++)
            {
                if (values[i] > 0 && values[i] < minValue)
                {
                    minValue = values[i];
                    index = i;
                }
            }
            return index;
        }
        public bool IsAllNoLessThanTarget(double target)
        {
            return values.All(x => x >= target);
        }
        public bool IsAllNoGreatThanTarget(double target)
        {
            return values.All(x => x <= target);
        }
        public bool Contains(double target)
        {
            return values.Contains(target);
        }
        public bool IsAllInteger()
        {
            return values.All(x => (int)x == x);
        }

        public override string ToString()
        {
            string result = "";
            result += "Type: Vector, Length: " + Count + "\nData:\n";
            foreach (double x in values)
            {
                result += (x + " ");
            }
            result += "\n";
            return result;
        }

        public void Resize(int length)
        {
            if (length < Count)
            {
                values = values.Take(length).ToArray();
            }
            else if (length > Count)
            {
                values = values.Concat<double>(new double[length - Count]).ToArray();
            }
        }
    }
}
