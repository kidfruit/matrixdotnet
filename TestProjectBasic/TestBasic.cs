using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixDotNet;

namespace TestProjectBasic
{
    /// <summary>
    /// TestBasic 的摘要说明
    /// </summary>
    [TestClass]
    public class TestBasic
    {
        public TestBasic()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethodVector()
        {
            Vector v1 = new Vector(3);
            v1[0] = 0; v1[1] = 1; v1[2] = 2;
            Vector v2 = new Vector(3);
            v2[0] = 1; v2[1] = 2; v2[2] = 3;
            Vector v3 = new Vector(new double[] { 1, 3, 5 });
            Assert.AreEqual(v3 - v2, v1);
            Assert.AreEqual(v1[0], 0, 0.0001);
            Assert.AreEqual(v1[2], 2, 0.0001);
            Assert.AreEqual(v1.Count, 3);
            Vector v4 = v1 + v2;
            Assert.AreEqual(v4.GetHashCode(), v3.GetHashCode());
            Assert.IsTrue(v3.Equals(v4));
            Assert.IsTrue(v3 == v4);
            Assert.IsFalse(v1.Equals(v3));
            Assert.IsTrue(v1 + v2 == v3);
            v1.ResetVector(new double[] { 1, 3, 5 });
            Assert.AreEqual(v1, v3);
            Assert.AreEqual(v1.SubVector(1, 2), new Vector(new double[] { 3, 5 }));
            Assert.AreEqual(v1.GetMaxValueIndex(), 2);
            Assert.AreEqual(v1.GetMinValueIndex(), 0);
            v1.ResetVector(new double[] { -1, 1, 3 });
            Assert.AreEqual(v1.GetPositiveMinValueIndex(), 1);
            Assert.IsTrue(v1.IsAllNoLessThanTarget(-1));
            Assert.IsFalse(v1.IsAllNoLessThanTarget(-0.5));
            Assert.IsTrue(v1.IsAllNoGreatThanTarget(3));
            Assert.IsFalse(v1.IsAllNoGreatThanTarget(2.5));
            Assert.IsTrue(v1.Contains(1));
            Assert.IsTrue(v1.IsAllInteger());
            Assert.IsFalse(new Vector(new double[] { 0.5, 0.3, 1 }).IsAllInteger());
            string output = v1.ToString();
            v1.Resize(2);
            Assert.AreEqual(v1, new Vector(new double[] { -1, 1 }));
            v1.Resize(4);
            Assert.AreEqual(v1, new Vector(new double[] { -1, 1, 0, 0 }));
        }

        [TestMethod]
        public void TestMethodMatrix()
        {
            Matrix matrix1 = new Matrix(2, 3);
            Assert.AreEqual(matrix1.Row, 2);
            Assert.AreEqual(matrix1.Column, 3);
            Matrix matrix2 = new Matrix(new double[,] { { 1, 2, 0 }, { 3, 4, 5 } });
            Assert.AreEqual(matrix2.Row, 2);
            Assert.AreEqual(matrix2.Column, 3);
            matrix2.Resize(2, 2);
            Matrix matrix3 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });
            Assert.AreEqual(matrix2.GetHashCode(), matrix3.GetHashCode());
            Assert.IsTrue(matrix2.Equals(matrix3));
            matrix3.AddRowToRow(0, 1, -1);
            Assert.AreEqual(matrix3, new Matrix(new double[,] { { 1, 2 }, { 2, 2 } }));
            matrix3.AddRowToRow(1, 0, 1);
            Assert.AreEqual(matrix3, new Matrix(new double[,] { { 3, 4 }, { 2, 2 } }));
            matrix3.MultiplyFactorToRow(1, 0.5);
            Assert.AreEqual(matrix3, new Matrix(new double[,] { { 3, 4 }, { 1, 1 } }));
            matrix3.AddNewRowToEnd(new Vector(new double[] { 5, 6 }));
            Assert.AreEqual(matrix3[2, 0], 5);
            Assert.AreEqual(matrix3[2, 1], 6);
            Matrix matrix4 = matrix3.SubMatrix(1, 1, 2, 1);
            Assert.AreEqual(matrix4, new Matrix(new double[,] { { 1 }, { 6 } }));
            Assert.AreEqual(matrix3, new Matrix(new double[,] { { 3, 4 }, { 1, 1 }, { 5, 6 } }));
            matrix3.DelRowFromEnd();
            Assert.AreEqual(matrix3, new Matrix(new double[,] { { 3, 4 }, { 1, 1 } }));
            Matrix matrix5 = new Matrix(new double[,] { { 1, 2 }, { 1, 2 } });
            Assert.AreEqual(matrix3 + matrix5, new Matrix(new double[,] { { 4, 6 }, { 2, 3 } }));
            Assert.AreEqual(matrix3 - matrix5, new Matrix(new double[,] { { 2, 2 }, { 0, -1 } }));
            Assert.AreEqual(matrix3 * matrix5, new Matrix(new double[,] { { 7, 14 }, { 2, 4 } }));
            Assert.AreEqual(matrix5 * matrix3, new Matrix(new double[,] { { 5, 6 }, { 5, 6 } }));
            Assert.AreEqual(matrix3 * matrix4, new Matrix(new double[,] { { 27 }, { 7 } }));
        }
    }
}
