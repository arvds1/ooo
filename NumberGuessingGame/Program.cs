using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("please enter number till which you would like to guess:");          
            string userInput = Console.ReadLine(); 
           
            // tut generator
            int maxNumber = int.Parse(userInput);
            Random diceNumberGenerator;
            diceNumberGenerator = new Random();
            int diceValue = diceNumberGenerator.Next(1, maxNumber);

            // tut usera prosim vnesti number
            string userGuess = Console.ReadLine();
            int.Parse(userGuess);

            Console.WriteLine(" this is generated number: " + diceValue);

            if (userGuess == diceValue)
            {
                Console.WriteLine(" yoohoo!!!!");
            }

            else if (userGuess > diceValue)
            {
                Console.WriteLine("Number is lower");
            }

            else
            {
                Console.WriteLine("Number is bigger");
            }
            
           
            Console.ReadLine();
        



        }
    }
}
