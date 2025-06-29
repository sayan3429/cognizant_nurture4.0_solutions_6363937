using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    public class Tests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum()
        {
            double a = 2;
            double b = 3;
            double expected = 5;

            double result = calculator.Addition(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
