using System;
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
    }
}