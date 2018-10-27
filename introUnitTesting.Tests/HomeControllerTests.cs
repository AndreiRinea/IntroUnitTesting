using introUnitTesting.Controllers;
using introUnitTesting.Models;
using introUnitTesting.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace introUnitTesting.Tests
{
    public class HomeControllerTests
    {
        private ICalculator _calc;
        private HomeController _systemUnderTest;

        public HomeControllerTests()
        {
            _calc = Substitute.For<ICalculator>();
            _systemUnderTest = new HomeController(_calc);
        }

        [Fact]
        public void Post_Math_Calls_Calculator()
        {
            var model = new MathOperation
            {
                Operand1 = 0,
                Operand2 = 0,
                Operation = OperationType.Divide
            };

            _systemUnderTest.Math(model);

            _calc.Received().Calculate(0, 0, OperationType.Divide);
        }

        [Fact]
        public void Post_Math_Calculates()
        {
            var model = new MathOperation
            {
                Operand1 = 1,
                Operand2 = 1,
                Operation = OperationType.Add
            };
            _calc.Calculate(1, 1, OperationType.Add).Returns(2);
            
            var viewResult = (ViewResult) _systemUnderTest.Math(model);
            
            var resultModel = (MathOperation) viewResult.Model;
            Assert.Equal(2, resultModel.Result);
        }
    }
}