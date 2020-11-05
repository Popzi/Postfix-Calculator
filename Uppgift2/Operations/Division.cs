using System;
using System.Collections.Generic;

namespace PostfixEvaluator.Operations
{
    class Division : IOperation
    {
        public decimal CalculateResultOfOperation(List<decimal> arguments)
        {
            Console.WriteLine($"Division: {arguments[0]} / {arguments[1]} = {arguments[0] / arguments[1]}");
            return arguments[0] / arguments[1];
        }
    }
}