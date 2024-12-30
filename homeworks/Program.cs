using System;
using System.Linq;
using System.Collections.Generic;
using homeworks;



namespace Lekce10
{
    internal class Program
    {

        // Definice psaní anonymních funkcí a také používání LINQ metod. 

        static void Main(string[] args)
        {
            var random = new Random();
            var names = new List<string>
            { "Alice ",
              "Bob ",
              "Charlie ",
              "Diana ",
              "Edward ",
              "Fiona ",
              "George ",
              "Hannah ",
              "Ian ",
              "Julia "
            };

            var students = new List<Student>();
            

            for (int i = 0; i < 100; i++)
            {
                var student = new Student
                {
                    Name = names[random.Next(names.Count)] + i,
                    Age = random.Next(18, 25),
                    Grades = new List<int>
                    {
                        random.Next(20, 100),
                        random.Next(50, 100),
                        random.Next(70, 100)
                    }
                };

                students.Add(student);
            }

            Console.WriteLine();
            Console.WriteLine("1. Seznam jmen všech studentů: ");
            var jmenaStudentu = students.Select(s => s.Name);
            foreach (var student in jmenaStudentu)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();
            Console.WriteLine("2. Seznam jmen studentů kteří mají alespoň jednu známku vyšší než 90: ");
            var studentiSVysokouZnamkou = students.Where(s => s.Grades.Any(g => g > 90));
            foreach (var student in studentiSVysokouZnamkou)
            {
                Console.WriteLine(student.Name + string.Join(", ", student.Grades));

            }

            Console.WriteLine();
            Console.WriteLine("3. Studenti se všemi známkami nad 80:");
            var studentiNad80 = students.Where(s => s.Grades.All(g => g > 80)).ToList();

            if (studentiNad80.Any())
            {
                foreach (var student in studentiNad80)
                {
                    Console.WriteLine("Student {0}: známky {1}",
                        student.Name,
                        string.Join(", ", student.Grades),
                        student.Grades.Average());
                }
                Console.WriteLine("Celkový počet nalezených studentů:" + (studentiNad80.Count));
            }
            else
            {
                Console.WriteLine("Nebyl nalezen žádný student s všemi známkami nad 80.");
            }


            Console.WriteLine();
            Console.WriteLine("4. Všechny známky všech studentů:");
            var vsechnyZnamky = students.SelectMany(s => s.Grades);
            foreach (var znamka in vsechnyZnamky)
            {
                Console.WriteLine(znamka);
            }

            Console.WriteLine();
            Console.WriteLine("5. Seřazení studentů podle věku:");
            var serazeniStudentiPodleVeku = students.OrderBy(s => s.Age);
            foreach (var student in serazeniStudentiPodleVeku)
            {
                Console.WriteLine(student.Name + " věk: " + student.Age + " let.");
            }


        }
    }
}
