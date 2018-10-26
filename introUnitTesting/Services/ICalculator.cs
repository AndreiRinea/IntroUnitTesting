using introUnitTesting.Models;

namespace introUnitTesting.Services
{
    public interface ICalculator
    {
        double Calculate(int operand1, int operand2, OperationType type);
    }
}