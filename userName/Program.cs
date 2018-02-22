using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userName
{
    class Program
    {
        public void Main(string[] args)
        {

            Console.WriteLine("Please enter your name:");
            string Name = Console.ReadLine();


            string wayToFile = @"C:\Users\Arvids\Documents\GitHub\ooo\userName\rrr\words.txt";
            string[] namesUpload = File.ReadAllLines(wayToFile);
            Console.WriteLine(wayToFile);

            foreach (string nameUp in namesUpload)

            {
                Console.WriteLine("\t" + namesUpload);
            }




        }
    }
}
