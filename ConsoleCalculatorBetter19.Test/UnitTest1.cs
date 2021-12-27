using Xunit;
using System;
using ConsoleCalculatorBetter19;

namespace ConsoleCalculatorBetter19.Tests
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(5, 2, 7)]
        [InlineData(-1, 2, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, -2)]

        public void AddTest(double num1, double num2, double expectedResult)
        {
            double result = Program.Add(num1, num2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void AddArrayTest()
        {
            double[] inArray = { 1.2, 2.2, 3.3 };
            // double[] inArray = { 2.1, 1.1, 3.1 }; DENNA BLEV FEL MED 6,3? Varf�r
            double expectedResult = 6.7;

            double result = Program.Add(inArray);
            Assert.Equal(expectedResult, result, 1);
        }

        [Fact]
        public void SubtractTest()
        {
            double num1 = 5, num2 = 2, expectedResult = 3;
            // call for test
            double result = Program.Subtract(num1, num2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SubtractArrayTest()
        {
            double[] inArray = { 5.5, 5.5, 0.0, 1.0 };
            double expectedResult = -1.0;
            double result = Program.Subtract(inArray);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void MultiplayTest()
        {
            double num1 = 2.2, num2 = 3.3, expectedResult = 7.26;
            double result = Program.Multiply(num1, num2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void DivideTest()
        {
            double num1 = 55.5, num2 = 33.3, expectedResult = 1.6667;
            double result = Program.Divide(num1, num2);
            Assert.Equal(expectedResult, result, 4);
        }
        [Fact]
        public void DivideByZeroTest()
        {
            double num1 = 1;
            double num2 = 0;
            var expectedResult = Assert.Throws<DivideByZeroException>(
               () => Program.Divide(num1, num2));

            Assert.Equal("You can not divide by zero! Enter a new decimal number:", expectedResult.Message);
        }

    }
}