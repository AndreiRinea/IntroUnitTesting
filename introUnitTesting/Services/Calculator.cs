using System;
using introUnitTesting.Models;

namespace introUnitTesting.Services
{
    public class Calculator : ICalculator
    {
        public double Calculate(int operand1, int operand2, OperationType type)
        {
            switch (type)
            {
                case OperationType.Add:
                    return operand1 + operand2;
                case OperationType.Subtract:
                    return operand1 - operand2;
                case OperationType.Multiply:
                    return operand1 * operand2;
                case OperationType.Divide:
                    if (operand2 == 0)
                        throw new DivideByZeroException();
                    return (double) operand1 / operand2;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}