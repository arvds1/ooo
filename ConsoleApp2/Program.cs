using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name:");
            string userName = Console.ReadLine();


            string wayToFile = @"C:\Users\Arvids\Documents\GitHub\ooo\userName\rrr\words.txt";
            string[] namesUpload = File.ReadAllLines(wayToFile);

            foreach (string name in namesUpload)

            {
                bool hasInvalidLet = false;
                foreach (char currentSymbol in userName)

                if (wayToFile.Contains(currentSymbol) == false)
                {
                        hasInvalidLet = true;
                }

                foreach (char symbol in wayToFile)
                {
                    if (userName.Contains(symbol) == false)
                    {
                        hasInvalidLet = true;
                    }
                    
                   
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
