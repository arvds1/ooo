using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("please enter Maximal Number: ");
            ulong maxNum = ulong.Parse(Console.ReadLine());

            for (ulong counter = 1; counter <= maxNum; counter = counter + 1)
            {

                ulong fizz = counter % 3;
                ulong buzz = counter % 5;
                if (fizz == 0 & buzz == 0)

                {
                    Console.WriteLine("FizzBuzz");
                }

                else if (fizz == 0)
                {
                    Console.WriteLine("Fizz");
                }

                else if (buzz == 0)
                {
                    Console.WriteLine("Buzz");
                }

                else
                {
                    Console.WriteLine(counter);
                }



            }



            Console.ReadLine();


        }
    }
}
