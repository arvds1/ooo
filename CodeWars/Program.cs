using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        public static void Main(string[] args)
        {

            /*
             

            Task
Given a list lst and a number N, create a new list that contains 
each number of lst at most N times without reordering. 
For example if N = 2, and the input is [1,2,3,1,2,1,2,3], you take [1,2,3,1,2], 
drop the next [1,2] since this would lead to 1 and 2 being in the result 3 times, 
and then take 3, which leads to [1,2,3,1,2,3].

Example
Kata.DeleteNth (new int[] {20,37,20,21}, 1) // return [20,37,21]
Kata.DeleteNth (new int[] {1,1,3,3,7,2,2,2,2}, 3) // return [1, 1, 3, 3, 7, 2, 2, 2]

             */


            /*
            int[] n;
            n = new int[] { 1, 2, 2 };
            int sqr = 0;

            for (int i = 0; i < n.Length; i++)
            {

                sqr = sqr + (n[i] * n[i]);

            }
            */


            /*XO("ooxx") => true
XO("xooxx") => false
XO("ooxXm") => true
XO("zpzpzpp") => true // when no 'x' and 'o' is present should return true
XO("zzoo") => false


            string input = "ooxXm";
            string l;
            int x = 0;
            int o = 0;
            bool ft = false;

            for (int i = 0; i < input.Length; i++)
            {
                l = input.Substring(i, 1).ToLower();
                

                if (l == "x")
                {
                    x = x + 1;
                }
                else if (l == "o")
                {
                    o = o + 1;
                }

            }


            Console.WriteLine( x == o);
            Console.ReadKey();*/

            /*It's pretty straightforward. 
Your goal is to create a function that removes the first and last characters of a string.
You're given one parameter, the original string. 
You don't have to worry with strings with less than two characters. public static string Remove_char(string s)
 */




            /* string s = "oxo";

             if(s.Length > 2) { 
             s = s.Remove(0, 1);
             s = s.Remove(s.Length - 1, 1);
             }

             Console.WriteLine(s);
             Console.ReadKey(); */


            /*Deoxyribonucleic acid, DNA is the primary information storage molecule in biological systems. 
It is composed of four nucleic acid bases Guanine('G'), Cytosine('C'), Adenine('A'), and Thymine('T').
Ribonucleic acid, RNA, is the primary messenger molecule in cells.
RNA differs slightly from DNA its chemical structure and contains no Thymine. In RNA Thymine is replaced by another nucleic acid Uracil('U').
Create a function which translates a given DNA string into RNA.
For example:
"GCAT"  =>  "GCAU"
The input string can be of arbitrary length - in particular, it may be empty. 
All input is guaranteed to be valid, i.e.each input string will only ever consist of 'G', 'C', 'A' and / or 'T'.*/



            /*string input = "GCAT";
            string l;

            l = input.Replace("T", "U").Replace("t","u");


            Console.WriteLine(l);
            Console.ReadKey();*/



            /* long[] Digitize;
            long n = 31234890;
            string l = n.ToString();

   


            for (int i = 0; i < l.Length; i++)
            {


                l = l.Substring(i, 1);
                long m = long.Parse(l);


            }


            Console.WriteLine();

            Console.ReadKey(); */


            /*double[] inputArray;
            inputArray = new double[] {-10, -9, -14};
            int Gimme = 0;
            double a = inputArray[0];
            double b = inputArray[1];
            double c = inputArray[2];

            if (a < b && a > c)
            {
                Gimme = 0;

            }

            else if (b > a && b < c)
            {
                Gimme = 1;
            }

            else if (c < b && c > a)
            {
                Gimme = 2;
            }

            else if (b < a && b > c)
            {
                Gimme = 1;
            }


            IQ Test (name of the task)

            Bob is preparing to pass IQ test.
The most frequent task in this test is to find out which one of the
given numbers differs from the others. 
Bob observed that one number usually differs from the others in evenness.
Help Bob — to check his answers, he needs a program that among the given numbers finds one that is different in evenness, 
and return a position of this number.

!Keep in mind that your task is to help Bob solve a real IQ test,
which means indexes of the elements start from 1(not 0) */


            //string numbers = "2 4 7 8 10";
            //string numbers = "1 2 1 1";
            //string numbers = "1 22 16 18 10";
            //string numbers = "3 2 2 2";
            /*string numbers = "3 2 3";

            string[] nums = numbers.Split(' ');
            int x = 0;
            int y = 0;

            int[] checks = new int[nums.Length];


            for (int i = 0; i < nums.Length; i++)
            {
                x = int.Parse(nums[i]);

                if (x % 2 == 0)
                {
                    checks[i] = 0;
                }
                else
                {
                    checks[i] = 1;
                }




            }

            
            int a = 0;
            int b = 0;
            int c = 0;

            for (int j = 0; j < checks.Length; j++)
            {
                a = checks[j];
                b = checks[j + 1];
               
                if (a != b)
                {
                    
                    if (a > b)
                    {
                        c = j + 1;
                        if (j > 0)
                        {
                            c = j + 2;
                        }
                        
                        break;
                    }

                    c = j + 2;
                    break;
                }

                
            }


            Console.WriteLine(y + " and " + c);

            Console.ReadKey(); */

            /*Complete the function that accepts a string parameter, 
            and reverses each word in the string. All spaces in the string should be retained.*/

            /*"This is an example!" ==> "sihT si na !elpmaxe"
            "double  spaces" ==> "elbuod  secaps"*/
            //kata Reverse words

            //string s = "This is an example!";
            //string[] w = s.Split(' ');
            //string[] a = new string[w.Length];

            /*string res;

            for (int i = 0; i < w.Length; i++)
            {

                res = w[i].Reverse().ToString();
                
            }

            Console.WriteLine();

            / original string
            string str = "This is an example!";
            // reverse the string
            string res = string.Join(" ", str.Split(' ').Select(s => new String(s.Reverse().ToArray())));


            Console.WriteLine(res);*/

            string str = "Website";
            Console.WriteLine("String: " + str);
            while (str.Length > 0)
            {
                Console.Write(str[0] + " = ");
                int cal = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[0] == str[j])
                    {
                        cal++;
                    }
                }
                Console.WriteLine(cal);
                str = str.Replace(str[0].ToString(), string.Empty);
            }
            Console.ReadLine();
        


        }

    }
}
