using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasics
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void SetupMethod()
        {
            System.Console.WriteLine("SetUP");
        }

        [Test]
        public void TestMethod()
        {
            System.Console.WriteLine("Test");
        }

        [TearDown]
        public void TearDownMethod()
        {
            System.Console.WriteLine("TearDown");
        }
    }
}
