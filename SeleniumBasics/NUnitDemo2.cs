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
    public class NUnitDemo2
    {
        [TestFixture]
        public class TestClass
        {
            int i = 0, j = 0;
            [OneTimeSetUp]  //Marks the method which must be run only once before any other methods in the class
            public void OneTimeSetUp()
            {
                i = ++i;    //Value of i will be incremented only once before any other methods gets executed
            }
            [SetUp]     //Marks the method which should be executed just once before each test method. 
            public void Setup()
            {
                System.Console.WriteLine("Inside SetUp Method, value of i is " + i);
                j = ++j;
                System.Console.WriteLine("Inside SetUp Method, value of j is " + j);
            }
            [Test]      //Marks the method as test case
            public void Test1()
            {
                System.Console.WriteLine("Inside Test1 Method");
            }
            [Test]      //Marks the method as test case
            public void Test2()
            {
                System.Console.WriteLine("Inside Test2 Method");

            }
            [TearDown]    //Marks the method which should be executed just once after each test method. 
            public void Teardown()
            {
                System.Console.WriteLine("Inside TearDown Method, value of i is " + i);
                j = ++j;
                System.Console.WriteLine("Inside TearDown Method, value of j is " + j);
            }
            [OneTimeTearDown]   //Marks the method which must be run only once after all other methods in the class
            public void OneTimeTearDown()
            {
                i = ++i;
            }
        }
     }
}
