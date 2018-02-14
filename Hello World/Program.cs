using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            // zabacali funkciju, eta komanda ee vizivaet. Funkcij mozhet bitj skoljko ugodno
            SayHello();
            // vizovem eshe odnu funkciju
            SayHelloToUser();
        }


        static void SayHelloToUser()
        { 
            
            // tut pishem funkciju, kotoraja prosit vvesti imja
            Console.WriteLine("Please enter your name:");
            // pishem chtob napisali svojo imja
            string userName;
            userName = Console.ReadLine();
            string age;
            Console.WriteLine("Please enter your age:");
            age = Console.ReadLine();
            age = age + 100;
            // prosim chtob posle enter vvel imja + text
            Console.WriteLine(" Dobrogo dnja, " + userName +" ! " + " Tvoi vozrast " + age); // Arvids "Dobrogo Dnja"
            Console.ReadLine();
        }



        static void SayHello()
        {
            Console.WriteLine("Hello, world!");
            Console.ReadLine();


        }


    }

}

