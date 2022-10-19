// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {

            List<int> entiers = new List<int> { 4, 7, 2, 3, 8, 5, 1, 6, 4, 2, 5, 10, 12, 13 };
            var query = from n in entiers
                        where n > 5 && n < 10
                        where n != 8
                        orderby n ascending
                        select n;

            foreach (int element in query)
            {
                System.Console.WriteLine($"element= {element}");
            }

            List<string> fruits = new List<string> { "bananes", "pomme", "poires", "pommes", "prunes", "cerises" };
            var query2 = from n in fruits
                         where n.Length > 5
                         where n.StartsWith('p')
                         where n.IndexOf("o") != -1
                         where n.IndexOf("n") == -1
                         select n;



            // foreach (string element in query2)
            // {
            //     System.Console.WriteLine($"fruit : {element}");
            // }

            var query3 = from n in fruits
                         orderby n.Length descending
                         orderby n
                         select n;
            foreach (string element in query3)
            {
                System.Console.WriteLine($"fruit : {element}");
            }

            var chunked = fruits.Chunk(3);


            List<int> numbers = new List<int> { 4, 7, 2, 3, 8, 5, 1, 6, 4, 2, 5, 10, 12, 13 };
            var filteredNumbers = numbers.Where(num => num < 3 || num < 7).OrderBy(num => num).Average();
            System.Console.WriteLine("Resultat:" + string.Join(",", filteredNumbers));

            List<int> numbers2 = new List<int> { 4, 6 };
            var result = (from num in numbers2
                          select num).Average();
            System.Console.WriteLine("Resultat2:" + result);

            string texte = @"date toto titi data tutu toto data";
            string searchTerm = "da";
            var matchQuery = from word in texte
                             where word.ToString() == searchTerm
                             select word;
            System.Console.WriteLine("matchQuery=" + matchQuery.Count());

            string aString = "ak4jj4k6";
            var query4 = from c in aString
                         where char.IsDigit(c)
                         select c;
            System.Console.WriteLine($"query4= {string.Join(',',query4)} : " + query4.Count());

            string [] tab1 = new string[] {"fred", "laure", "emmy"};
            string [] tab2 = new string[] {"ALAIN", "boo", "emmy"};

            var difference = tab1.Except(tab2);
            System.Console.WriteLine("difference = "+difference); 
            foreach (var diff in difference)
            {
              System.Console.WriteLine(diff);
            }

            //Console.ReadKey();
            //double [] numbers = new double[4]  {12.7, 10.3, 6.11, 4.1};
            // var numbers = new []  {12.7, 10.3, 6.11, 4.1};
            //  grades.Add(56.1);
            /*  numbers[0] = 1.1;
              numbers[1] = 2.1;
              numbers[2] = 3.1;*/
            //var result = numbers[0] + numbers[1]  + numbers [2];

            // Book book = new InMemoryBook("fred's grade book");
            // book.GradeAdded += OnGradeAdded;
            // EnterGrades((IBook)book);
            // var stats = book.GetStatistics();

            // // System.Console.WriteLine(InMemoryBook.CATEGORY);
            // System.Console.WriteLine($"For the book named {book.Name}");
            // System.Console.WriteLine($"the average = {stats.Average:N1}");
            // System.Console.WriteLine($"the highGrade = {stats.High}");
            // System.Console.WriteLine($"the lowGrade = {stats.Low}");
            // System.Console.WriteLine($"the letter grade = {stats.Letter}");

            // List <double> grades = new List<double>()   {12.7, 10.3, 6.11, 4.1};
            // grades.Add(21.2);
            // foreach(double grade in grades) {
            //   System.Console.WriteLine($"grade = {grade}");
            //   // if(grade>highGrade) {highGrade= grade;}
            //   highGrade = Math.Max(grade, highGrade);
            //   lowGrade = Math.Min(grade, lowGrade);
            //   result += grade;
            // }
            // result = result/grades.Count;
            // System.Console.WriteLine($"moyenne = {result:N1}");
            // System.Console.WriteLine($"highGrade = {highGrade}");
            //  System.Console.WriteLine($"lowGrade = {lowGrade}");

            /* if(args.Length > 0)
             {
               Console.WriteLine($"Hello {args[0]} !" );
             } else{
               Console.WriteLine($"Hello inconu" );
             }
             Console.WriteLine($"Le resultat est : {result}");
             */



        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a value, or q to quit;");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}

