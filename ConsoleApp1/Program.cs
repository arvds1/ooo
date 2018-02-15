using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            while (userInput != "x")
            {
                Console.WriteLine("please choose action");
                Console.WriteLine("a - calculate circle area");
                Console.WriteLine("c - caount two numbers togheter");
                Console.WriteLine("e - does the number divides?");
                Console.WriteLine("x - close the programm");
                userInput = Console.ReadLine();
                //esli a radius, esli c soshitatj, esli chto to drugoe vidatj oshibku
                if (userInput == "a")
                {
                    Radius();
                }

                else if (userInput == "c")
                {
                    CountTwoNumbersTogether();
                }

                else if (userInput == "e")
                {
                    DoesTheNumDivides();
                }

                else if (userInput == "x")
                {
                    break;
                }


                else
                {
                    Console.WriteLine("Sorry do not understand !");
                }
            }
            
            
            // Ctrl + K un tad D pomogaet popravitj kod, esli ego razbrosalo
            
            // double obeshjaet chto budet ne krugloe chislo, int chto krugloe chislo, string chto budet text
        }


        static void Radius()
        {
            // delajem fishku chtob podshitatj radius
            double radius;
            // delajem fishku chtob hranitj rezuljtat
            double result;
            // pridadim znachenije radiusu
            radius = GetNumberFromUser("Please input radius !");
            // delaem raschet
            result = radius * radius * 3.14;
            // dajem rezuljtat
            Console.WriteLine("Result = " + result);
            Console.ReadLine();
        }
        static double GetNumberFromUser(string msg)
        {
            // vivodim soobshenie funkcii
            Console.WriteLine(msg);
            // chitaem chto pishet user i vpisivaem v peremennuju
            string textInput = Console.ReadLine();
            // bacaem peremennuju gde budet krugloe chislo
            double parsedNumber;
            // text peredelivaem c chislo i vpisivaem
            bool parseWasSuccess = double.TryParse(textInput, out parsedNumber);
            if (parseWasSuccess == false)
            {
                Console.WriteLine("bad try" + textInput);
                Console.WriteLine("double validate number");
                parsedNumber = GetNumberFromUser(msg);

            }
            else
            {
                Console.WriteLine("Fantastic!");
            }
            return parsedNumber;
        }

        static void CountTwoNumbersTogether()
        {
            double number1;
            number1 = GetNumberFromUser("Please inpiut first number");
            double number2;
            number2 = GetNumberFromUser("Please input second number");
            Console.WriteLine(number1 + number2);
            Console.ReadLine();

        }
        static void DoesTheNumDivides()
        {
            double divisible = GetNumberFromUser("please enter divisible!!!");
            double divider = GetNumberFromUser("please enter divider!!!");
            double modulo = divisible % divider;
            if (modulo == 0)
            {
                Console.WriteLine("number divides!!!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("number does not divides!!!");
            }
        }
    }
}
