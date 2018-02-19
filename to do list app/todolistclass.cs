using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_app
{
    class ToDoList
    {
        // eto konstruktor, kotorij vizivaetsja posle dobavlenija novogo objekta
        // nazivaetsja vsegda kak klass
        public ToDoList()
        {
            todoEntries = new List<string>();
        }

        List<string> todoEntries;

        public void AddNewToDo(string task)
        {
            // vse usingi dajut vozmozhnostj izpoljzovatj dop funkcii. ctrl + . vizivaet raznie klassi

            Console.WriteLine("you have added a task " + task);
            todoEntries.Add(task);

        }

        public void ShowAllTodos()
        {
            // (counter = counter + 1) = (counter +=1) = (counter++) 
            // i = index = skaititajs
            for (int counter = 0; counter < todoEntries.Count; counter += 1)
            {
                // novaja fishka [] indeksator, seichas budem vitaskivatj nashi zapisi
                Console.WriteLine((counter + 1) + ". " + todoEntries[counter]);
                Console.WriteLine();
            }


        }

        public void DeleteToDo(int indexOfTodo)
        {

            // dobavljaem vozmozhnostj udaljatj zadachi
            // nuzhno dobavitj funkcional maxNumber
            todoEntries.RemoveAt(indexOfTodo);

            if (indexOfTodo >= this.todoEntries.Count)
            {
                // esli v spiske 3, togda poslednij buet 2 (shitaem s 0)
                Console.WriteLine("this task does not exsist");
                return;
            }

            todoEntries.RemoveAt(indexOfTodo);

        }

        public void DeleteAllTodos()
        {
            todoEntries.Clear();
        }

        public void saveToFile()
        {
            //Ctrl + . -> vizivaet sistemi, kotorie mi mozhem dobavljatj i togda budut vidni novie vozmozhnosti
            for (int i = 0; i < todoEntries.Count; i++)
                // dlja faila nuzhno ukazivatj putj, budet rugatssja na slash, mozhno stavitj \ pered kaszhdim slash ili dobavit @, govorja chto eto putj
                File.AppendAllText(
                    @"C:\Users\Arvids\Documents\GitHub\ooo\to do list app\to do application settings\todos.txt",
                todoEntries[i] + "\r\n");
            // \n -> eto enter 



        }

        public void readFromFile()
        {
            string[] allLinesFromFile = File.ReadAllLines(@"C:\Users\Arvids\Documents\GitHub\ooo\to do list app\to do application settings\todos.txt");
            foreach(string listEntry in allLinesFromFile)
            {
                todoEntries.Add(listEntry);
            }

                
                
        }
    }


}
