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
            ToDoList list = new ToDoList();
            while (true)
            {
                Console.WriteLine("a = add");
                Console.WriteLine("s = show");
                Console.WriteLine("d = delete");
                Console.WriteLine("dd = delete all to do`s");
                Console.WriteLine("sv = save to do`s");
                Console.WriteLine("r = read from file");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "a":
                        // add new things to do
                        Console.WriteLine("Please add things that you would like to do:");
                        string toDoTask = Console.ReadLine();
                        list.AddNewToDo(toDoTask);
                        break;

                    case "s":
                        // put all things to do on desctop
                        list.ShowAllTodos();
                        break;

                    case "d":
                        // erase things that have been done
                        Console.WriteLine("please select which task to delete:");
                        list.ShowAllTodos();
                        int index = int.Parse(Console.ReadLine());
                        list.DeleteToDo(index - 1);                    
                        break;
                    // dobavitj funkciju, kotoraja udalit vse zapisi

                    case "dd":
                        list.DeleteAllTodos();
                        break;


                    case "sv":
                        list.saveToFile();
                        break;

                    case "r":
                        list.readFromFile();
                        break;
                }




            }



        }
    }
}
