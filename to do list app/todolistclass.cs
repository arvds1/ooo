using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list_app
{
    class todolistclass
    {
        // eto konstruktor, kotorij vizivaetsja posle dobavlenija novogo objekta
        // nazivaetsja vsegda kak klass
        public todolistclass()
        {
            todoEntries = new List<string>();
        }
       
        List<string> todoEntries;

        public void AddNewToDo(string task)
        {
            // vse usingi dajut vozmozhnostj izpoljzovatj dop funkcii. ctrl + . vizivaet raznie klassi
            
            Console.WriteLine("you have added a task" + task);
            todoEntries.Add(task);

        }

        public void ShowAllTodos()
        {
            // (counter = counter + 1) = (counter +=1) = (counter++) 
            // i = index = skaititajs
            for (int counter = 0; counter < todoEntries.Count; counter += 1)
            {
                // novaja fishka [] indeksator, seichas budem vitaskivatj nashi zapisi
                Console.WriteLine("your to do list is " + todoEntries[counter]);
            }
            
           
        }

    }
}
