using NUnit.Framework;
using System;
using System.IO;

namespace FizzBuzz.Tests
{
    public class FizzBuzzServiceTests
    {
        private Func<int, string>[] differentRules;

        [SetUp]
        public void Setup()
        {
            differentRules = new Func<int, string>[] {
                (int i) => (i % 3) == 0 ? "Fizz" : null,
                (int i) => (i % 5) == 0 ? "Buzz" : null,
                (int i) => (i % 7) == 0 ? "Sazz" : null,
            };
        }

        [Test]
        public void TestConstructor()
        {
            FizzBuzzService subject = new(1, 100);
            Assert.IsInstanceOf(typeof(FizzBuzzService), subject);
            Assert.AreEqual(1, subject.Start);
            Assert.AreEqual(100, subject.End);
        }

        [Test]
        public void TestConstructorWithDifferentRules()
        {
            FizzBuzzService subject = new(1, 100, differentRules);
            Assert.IsInstanceOf(typeof(FizzBuzzService), subject);
            Assert.AreEqual(1, subject.Start);
            Assert.AreEqual(100, subject.End);
            Assert.AreEqual(differentRules, subject.Rules);
        }

        [Test]
        public void TestRun()
        {
            FizzBuzzService subject = new(1, 9);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                subject.Run();

                string expected = string.Format(
                    "1: 1{0}2: 2{0}3: Fizz{0}4: 4{0}5: Buzz{0}6: Fizz{0}7: 7{0}8: 8{0}9: Fizz{0}",
                    Environment.NewLine
                );
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void TestParse()
        {
            FizzBuzzService subject = new(1, 105, differentRules);
            Assert.AreEqual("1", subject.Parse(1));
            Assert.AreEqual("2", subject.Parse(2));
            Assert.AreEqual("Fizz", subject.Parse(3));
            Assert.AreEqual("4", subject.Parse(4));
            Assert.AreEqual("Buzz", subject.Parse(5));
            Assert.AreEqual("Sazz", subject.Parse(7));
            Assert.AreEqual("FizzBuzz", subject.Parse(15));
            Assert.AreEqual("FizzSazz", subject.Parse(21));
            Assert.AreEqual("BuzzSazz", subject.Parse(35));
            Assert.AreEqual("97", subject.Parse(97));
            Assert.AreEqual("FizzBuzzSazz", subject.Parse(105));
        }
    }
}