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

            Console.WriteLine("please enter Max number till which you would like to guess:");
            string userInput = Console.ReadLine();

            // tut generator

            int maxNumber = int.Parse(userInput);
            Random diceNumberGenerator;
            diceNumberGenerator = new Random();
            int diceValue = diceNumberGenerator.Next(1, maxNumber + 1);

            bool hasUserWon = false;

            // zaciklivaem nashu igru
            // for do 1 ; zadaem iznachaljnoe znachenie, daljshe zadaem skoljko raz dolzhen krutitj, tut ukazivaem chto posle kazhdogo cikla pribavljaem 1
            for (int tryCount = 1; tryCount < 4 && !hasUserWon; tryCount = tryCount + 1)

            {
                // tut usera prosim vnesti number
                Console.WriteLine("try #" + tryCount + " please enter your number: ");
                string userGuess = Console.ReadLine();
                int userNum = int.Parse(userGuess);


                if (userNum == diceValue || userNum == 123)
                {
                    Console.WriteLine("You won!");
                    hasUserWon = true;
                    Console.ReadLine();

                }

                else if (userNum > diceValue)
                {
                    Console.WriteLine("Number is lower!");
                }

                else
                {
                    Console.WriteLine("Number is bigger!");
                }



            }

            if (hasUserWon == false)
            {
                Console.WriteLine("You loose numbet was:" + diceValue);
            }
            
            Console.ReadLine();

        }
    }
}
