using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAndAwait.Library;
using TaskAndAwait.Shared;

namespace TaskAndAwait.ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository repo = new PersonRepository();

            ////// using task's result
            //List<Person> people = repo.Get().Result;
            //for (int i = 0; i < 5; i++)
            //    Console.WriteLine(i);
            //foreach (var person in people)
            //{
            //    Console.WriteLine(person.ToString());
            //}


            Task<List<Person>> peopleTask = repo.Get();
            peopleTask.ContinueWith(FillConsole);
            for (int i = 0; i < 5; i++)
                Console.WriteLine(i);



            Console.ReadLine();

        }
        private static void FillConsole(Task<List<Person>> persontask)
        {
            List<Person> people = persontask.Result;
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }

        }
    }
}
