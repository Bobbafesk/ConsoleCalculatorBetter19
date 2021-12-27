using System;
using static System.Console;

namespace ConsoleCalculatorBetter19
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isAlive = true;
            double number1 = 0;
            double number2 = 0;
            double result = 0;

            double[] inputArray1 = { 5.5, 5.5, 0.0, 1.0 };
            // double[] inputArray2 = {1.2, 2.2, 3.3};

            Write(" A array with the following numbers can be used to do Add/subtract numbers in a array: ");
            foreach (double decNumber in inputArray1)
            {
                Write(decNumber + " ");
            }
            WriteLine();

            while (isAlive)
            {
                WriteLine(" Welcome to Anders Calculator!" +
                    "\n Please insert the two numbers that shall be calculated then pick the operator.");

               // Ask for the two numbers for the operator
                number1 = GetDecimalFromUser("1");
                number2 = GetDecimalFromUser("2");



                WriteLine("\n Please, select one of the following operators or Exit:" +
                    "\n +: Add" +
                    "\n a: Add all decimals in a array" +
                    "\n -: Subtract" +
                    "\n s: Subtract all decimals in a array" +
                    "\n *: Multiply" +
                    "\n /: Divide" +
                    "\n 0: Exit calculator" +
                    "\r\n ");

                // This is the menu of the program. Inputs from the user will select operator.
                switch (ReadLine())
                {
                    case "0":
                        isAlive = false;
                        //WriteLine(" Do you really want to exit? Press y");
                        //if (ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
                        //{
                        //    isAlive = false;
                        //    Environment.Exit(0);
                        //}
                        break;
                    case "+":
                        Clear();
                        result = Add(number1, number2);
                        WriteResult(number1, number2, result, "+");
                        break;
                    case "A":
                    case "a":
                        Clear();
                        result = Add(inputArray1);
                        WriteLine("Result for adding numbers in array = " + result);
                        // WriteResult(number1, number2, result, "+");
                        break;
                    case "-":
                        Clear();
                        result = Subtract(number1, number2);
                        WriteResult(number1, number2, result, "-");
                        break;
                    case "s":
                        // "S":  VARFÖR FUNGERAR EJ DENNA RAD, NÄR OVAN MED A OCH a FUNGERAR OVAN?
                        Clear();
                        result = Subtract(inputArray1);
                        WriteLine("Result for subtract numbers in array = " + result);
                        break;
                    case "*":
                        Clear();
                        result = Multiply(number1, number2);
                        WriteResult(number1, number2, result, "*");
                        break;
                    case "/":
                        // Clear();
                        number2 = NotDivideByZero(number2);
                        result = Divide(number1, number2);
                        WriteResult(number1, number2, result, "/");
                        break;
                    default:
                        Clear();
                        WriteLine(" Invalid menu option, please write one of following operators + - * /\r\n");
                        break;
                }

            }

        }

        // This will write the name of the variable number and return a decimal
        //static double GetDecimalFromUser()
        //{
        //    double userInput = 0;
        //    bool succeeded = false;
        //    while (!succeeded)
        //    {
        //        succeeded = double.TryParse(ReadLine(), out userInput);
        //      //  double.Parse
        //        if (!succeeded)
        //        {
        //            WriteLine(" The number must be in decimal form"); 
        //        }
        //    }
        //    return userInput;
        //}

        static double GetDecimalFromUser(string text)
        {
            Write("\r\n Enter decimal number{0}: ", text);
            double inNumber = 0;
            bool success = false;
            do
            {
                try
                {
                    inNumber = double.Parse(ReadLine());
                    success = true;
                }
                catch (OverflowException)
                {
                    WriteLine("Your value is too big");
                }
                catch (ArgumentNullException)
                {
                    WriteLine("Could not parse, value was null");
                }
                catch (FormatException error)
                {
                    WriteLine(error.Message);

                    WriteLine("Enter a new decimal number: ");
                }
            } while (!success);

            return inNumber;
        }


        // This will write the two numbers with the operator between and result. Example 1 + 2 = 3
        static void WriteResult(double userInputA, double userInputB, double result, string aOperator)
        {
            WriteLine("\r\n The result for {0} {1} {2} = {3}\r\n", userInputA, aOperator, userInputB, result);
        }

        // Here are the methods for the 4 operations
        public static double Add(double userInputA, double userInputB)
        {
            return userInputA + userInputB;
        }

        public static double Add(double[] inputArray)
        {
            double result = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                result += inputArray[i];
            }
            return result;
        }

        public static double Subtract(double userInputA, double userInputB)
        {
            return userInputA - userInputB;
        }

        public static double Subtract(double[] inputArray)
        {
            double result = inputArray[0];
            for (int i = 1; i < inputArray.Length; i++)
            {
                result -= inputArray[i];
            }
            return result;
        }

        public static double Multiply(double userInputA, double userInputB)
        {
            return userInputA * userInputB;
        }

        // This will shek if input is 0 (it is not possible to divide by zero) and if 0, ask for a new number that it will return
        static double NotDivideByZero(double userInputB)
        {
            if (userInputB != 0)
            {
                return userInputB;
            }
            else
            {
                while (userInputB == 0)
                {
                    WriteLine("You can not divide by zero!");
                    userInputB = GetDecimalFromUser("2");
                }
                return userInputB;
            }
        }

        public static double Divide(double userInputA, double userInputB)
        {
            //Sheck for userInput B != 0
            // userInputB = NotDivideByZero(userInputB

            // try
            // {
            if (userInputB == 0)
            {
                throw new DivideByZeroException("You can not divide by zero! Enter a new decimal number:");
            }
            //  }
            /*
            catch (DivideByZeroException)
            {
                WriteLine("You can not divide by Zero.");
            }
            */
            return userInputA / userInputB;
        }
    }
}