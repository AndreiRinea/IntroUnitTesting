using System;
using introUnitTesting.Models;
using introUnitTesting.Services;
using Xunit;

namespace introUnitTesting.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _systemUnderTest;

        public CalculatorTests()
        {
            _systemUnderTest = new Calculator();
        }

        [Fact]
        public void Test_Add()
        {
            var res = _systemUnderTest.Calculate(1, 1, OperationType.Add);
            Assert.Equal(2, res);
        }

        [Theory]
        [InlineData(1, 1, OperationType.Add, 2.0d)]
        [InlineData(1, 1, OperationType.Subtract, 0.0d)]
        public void Test_Calculate(int o1, int o2, OperationType type, double expRes)
        {
            var res = _systemUnderTest.Calculate(o1, o2, type);
            Assert.Equal(expRes, res);
        }

        [Fact]
        public void DivideByZero_Throws_Exception()
        {
            Assert.Throws<DivideByZeroException>(() => _systemUnderTest.Calculate(0, 0, OperationType.Divide));
        }
    }
}