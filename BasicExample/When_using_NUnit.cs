using System;
using NUnit.Framework;

namespace BasicExample
{
    [TestFixture]
    public class When_using_NUnit
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Console.WriteLine("TestFixtureSetUp - This runs once per test fixture at the beginning");
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("SetUp - This runs once per test at the beginning");
        }

        [Test]
        [Category("Foo"), Category("Bar")]
        public void Should_1()
        {
            Console.WriteLine("Should_1");
            const int expectedResult = 64;
            var squarer = new Squarer();

            int result = squarer.Square(8);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(9, 81)]
        public void Should_2(int val, int expectedResult)
        {
            Console.WriteLine("Should_2");
            var squarer = new Squarer();

            int result = squarer.Square(val);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown - This runs once per test at the end");
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Console.WriteLine("TestFixtureTearDown - This runs once per test fixture at the end");
        }

        public class Squarer
        {
            public int Square(int val)
            {
                return val*val;
            }
        }
    }
}