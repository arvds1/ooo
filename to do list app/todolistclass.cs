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
            todoEntries = new List<ToDoListEntry>();
        }

        List<ToDoListEntry> todoEntries;

        public void AddNewToDo(string task)
        {
            // vse usingi dajut vozmozhnostj izpoljzovatj dop funkcii. ctrl + . vizivaet raznie klassi

            Console.WriteLine("you have added a task " + task);
            ToDoListEntry usersTodo = new ToDoListEntry();
            usersTodo.Name = task;
            todoEntries.Add(usersTodo);

        }

        public void ShowAllTodos()
        {
            // (counter = counter + 1) = (counter +=1) = (counter++) 
            // i = index = skaititajs
            for (int counter = 0; counter < todoEntries.Count; counter += 1)
            {
                // novaja fishka [] indeksator, seichas budem vitaskivatj nashi zapisi
                Console.Write((counter + 1) + ". " + todoEntries[counter].Name);
                if (todoEntries[counter].isCompleted)

                {
                    Console.WriteLine("DONE");
                }

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

        string pathToTodoFile = @"C:\Users\Arvids\Documents\GitHub\ooo\to do list app\to do application settings\todos.txt";
        public void saveToFile()
        {
            
            File.Delete(pathToTodoFile);
            //Ctrl + . -> vizivaet sistemi, kotorie mi mozhem dobavljatj i togda budut vidni novie vozmozhnosti
            // dlja faila nuzhno ukazivatj putj, budet rugatssja na slash, mozhno stavitj \ pered kaszhdim slash ili dobavit @, govorja chto eto putj
            for (int i = 0; i < todoEntries.Count; i++)
            {

                File.AppendAllText(pathToTodoFile, todoEntries[i].Name + "\r\n");

                bool isCompleted = todoEntries[i].isCompleted;
                File.AppendAllText(pathToTodoFile, isCompleted + "\r\n");

                // \n -> eto enter 
            }


        }

        public void MarkTodoAsDone(int doneTodoIndex)
        {

            ToDoListEntry doneTodo = todoEntries[doneTodoIndex];
            doneTodo.isCompleted = true;
            

        }

        public void readFromFile()
        {
            if (!File.Exists(pathToTodoFile)) // mozhno pisatj == true ili false, esli dobavitj ! budet v obratku (== false)
            {
                return;
            }

            string[] allLinesFromFile = File.ReadAllLines(pathToTodoFile);
            
            for(var index = 0; index< allLinesFromFile.Length; index+=2)
            {
                string listEntry = allLinesFromFile[index];

                ToDoListEntry fileTodo = new ToDoListEntry();

                fileTodo.Name = listEntry;

                fileTodo.isCompleted = bool.Parse(allLinesFromFile[index +1]);

                todoEntries.Add(fileTodo);
            }

                
                
        }
    }


}
