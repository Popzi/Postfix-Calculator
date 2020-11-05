using System;
using System.Collections.Generic;
using ADTStack;
using PostfixEvaluator;
using PostfixEvaluator.Operations;

namespace Uppgift2
{
    class Program
        {
        static Dictionary<string, int> Operators = new Dictionary<string, int>();
        static void Main(string[] args)
            {
                        Console.WriteLine("Enter your postfix string: ");
                        String postfixeval = Console.ReadLine();
                        try
                        {
                            InitializeOperators();
                            decimal output = Evaluate(postfixeval);
                            Console.WriteLine("Result: {0}", output);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }
            Console.ReadLine();
            }

        #region postfixcalculator
        #region mathoperators
        private static void InitializeOperators()
        {
            Operators.Add("^", 2);
            Operators.Add("/", 2);
            Operators.Add("*", 2);
            Operators.Add("-", 2);
            Operators.Add("+", 2);
        }

        private static bool isOperator(String token)
        {
            return Operators.ContainsKey(token);
        }
        #endregion

        #region evaluatepostfix
        private static decimal Evaluate(string PostfixString)
        {
            try
            {
                char[] separator = { ' ' };
                string[] tokensArray = PostfixString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                ADTStack<decimal> argumentsStack = new NodeStack<decimal>();
                decimal number;
                string token;

                for (int i = 0; i < tokensArray.Length; i++)
                {
                    token = tokensArray[i];
                    number = decimal.Zero;

                    if (decimal.TryParse(token, out number))
                    {
                        argumentsStack.Push(number);
                    }
                    else if (isOperator(token))
                    {
                        int ArgumentsRequired = Operators[token];

                        if (argumentsStack.Count() < ArgumentsRequired)
                        {
                            throw new Exception("Not sufficent values in expression. (array short)");
                        }
                        else
                        {
                            List<decimal> argsList = new List<decimal>();
                            for (int k = 0; k < ArgumentsRequired; k++)
                            {
                                argsList.Add(argumentsStack.Pop());
                            }

                            argsList.Reverse();

                            IOperation IObj = ObjectFactory(token);
                            decimal val = IObj.CalculateResultOfOperation(argsList);

                            argumentsStack.Push(val);
                            Console.WriteLine("\nCurrent Stack: ");
                            argumentsStack.Display();
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        throw new Exception("Unknown operator in input: " + token);
                    }
                }

                if (argumentsStack.Count().CompareTo(1) == 0)
                {
                    return argumentsStack.Pop();
                }
                else
                {
                    throw new Exception("Too many values in input.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region isoperator
        static public IOperation ObjectFactory(string choice)
        {
            IOperation objOperator = null;

            switch (choice)
            {
                case "+":
                    objOperator = new Addition();
                    break;
                case "-":
                    objOperator = new Subtraction();
                    break;
                case "*":
                    objOperator = new Multiplication();
                    break;
                case "/":
                    objOperator = new Division();
                    break;
                case "^":
                    objOperator = new Exponent();
                    break;
            }
            return objOperator;

        }
        #endregion
        #endregion
    }
}