using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixEvaluator.Operations
{
    class Exponent : IOperation
    {
        public decimal CalculateResultOfOperation(List<decimal> arguments)
        {
            Console.WriteLine($"Exponent: {arguments[0]} ^ {arguments[1]} = {Convert.ToDecimal(Math.Pow(Convert.ToDouble(arguments[0]), Convert.ToDouble(arguments[1])))}");
            return Convert.ToDecimal(Math.Pow(Convert.ToDouble(arguments[0]), Convert.ToDouble(arguments[1])));
        }
    }
}