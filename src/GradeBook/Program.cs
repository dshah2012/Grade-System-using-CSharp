using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            //var book = new InMemoryBook("Darshan Grade Book");
            IBook book = new DiskBook("testing");
            book.gradeAdded += oneGradeAdded;
            
            EnterGrade(book);

            var result = book.getStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The highest Grade is {result.high}");
            Console.WriteLine($"The Lowest Grade is {result.low }");
            Console.WriteLine($"The average grade is {result.average:N2}");
            Console.WriteLine($"The letter grade is {result.letter}");
        }

        private static void EnterGrade(IBook book)
        {
            var done = false;

            while (!done)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
               
            }
        }

        static void oneGradeAdded(object sender, EventArgs e){
            Console.WriteLine("A grade was Added");
        }
    }
}
