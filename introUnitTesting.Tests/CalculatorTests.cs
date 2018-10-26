using introUnitTesting.Models;
using introUnitTesting.Services;
using Xunit;

namespace introUnitTesting.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Test_Add()
        {
            var calc = new Calculator();
            var res = calc.Calculate(1, 1, OperationType.Add);
            Assert.Equal(2, res);
        }

        [Theory]
        [InlineData(1, 1, OperationType.Add, 2.0d)]
        [InlineData(1, 1, OperationType.Subtract, 0.0d)]
        public void Test_Calculate(int o1, int o2, OperationType type, double expRes)
        {
            var calc = new Calculator();
            var res = calc.Calculate(o1, o2, type);
            Assert.Equal(expRes, res);
        }
    }
}