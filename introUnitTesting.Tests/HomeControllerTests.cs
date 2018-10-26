using introUnitTesting.Controllers;
using introUnitTesting.Models;
using introUnitTesting.Services;
using NSubstitute;
using Xunit;

namespace introUnitTesting.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Post_Math_Calls_Calculator()
        {
            var calc = Substitute.For<ICalculator>();
            var systemUnderTest = new HomeController(calc);
            var model = new MathOperation
            {
                Operand1 = 0,
                Operand2 = 0,
                Operation = OperationType.Divide
            };

            systemUnderTest.Math(model);

            calc.Received().Calculate(0, 1, OperationType.Divide);
        }
    }
}