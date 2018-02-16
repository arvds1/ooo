using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_app
{
    class Program
    {
        static void Main(string[] args)
        {
            todolistclass list = new todolistclass ();
            while (true)
            {

                // add new things to do
                Console.WriteLine("please add things that you would like to do");
                string toDoTask = Console.ReadLine();
                list.AddNewToDo(toDoTask);
                // erase things that have been done
                // put all things to do on desctop
                list.ShowAllTodos();

            }



        }
    }
}
