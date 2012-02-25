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
    }
}
