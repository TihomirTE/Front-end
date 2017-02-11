namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Testing
    {
        /*public static void Main()
        {
            List<Student> listOfStudents = new List<Student>();
            List<Worker> listOfWorkers = new List<Worker>();

            Student ivan = new Student("Ivan", "Stamatov", 3);
            Student stamat = new Student("Stamat", "Ivanov", 5);
            Student petkan = new Student("Pesho", "Petrov", 2);
            Student mariika = new Student("Mariq", "Ivanova", 4);
            Student elena = new Student("Elena", "Hubavata", 3);
            Student iliq = new Student("Iliq", "Shishmanov", 4);
            Student simeon = new Student("Simeon", "Veliki", 6);
            Student bb = new Student("Bate", "Boiko", 2);
            Student ahmet = new Student("Ahmet", "Dogan", 3);
            Student maq = new Student("Maq", "Manolova", 5);
            listOfStudents.Add(ivan);
            listOfStudents.Add(stamat);
            listOfStudents.Add(petkan);
            listOfStudents.Add(mariika);
            listOfStudents.Add(elena);
            listOfStudents.Add(iliq);
            listOfStudents.Add(simeon);
            listOfStudents.Add(bb);
            listOfStudents.Add(ahmet);
            listOfStudents.Add(maq);

            var sortStudents = from student in listOfStudents
                               orderby student.Grade
                               select student;

            foreach (var student in sortStudents)
            {
                Console.WriteLine("Name {0} {1}: grade - {2}", student.FirstName, student.LastName, student.Grade);
            }

            Worker pesho = new Worker("Ivan", "Draganov", 300, 10, 10);
            Worker stamatikiis = new Worker("Stamat", "Stamotov", 500, 12, 8);
            Worker petkancho = new Worker("Pesho", "Kolev", 250, 8, 15);
            Worker mariq = new Worker("Mariq", "Ilieva", 400, 8, 20);
            Worker elenka = new Worker("Elena", "Elenova", 3000, 4, 200);
            Worker illiq = new Worker("Iliq", "Spiridonov", 1000, 8, 40);
            Worker simeoncho = new Worker("Simeon", "Saksa", 6000, 4, 500);
            Worker boiko = new Worker("Boiko", "Borisov", 20000, 1, 750);
            Worker ahmetcho = new Worker("Dogan", "Ahmetov", 30000, 0, 30000);
            Worker maicheto = new Worker("Maq", "Ombudswomen", 5000, 2, 650);
            Console.WriteLine();

            listOfWorkers.Add(pesho);
            listOfWorkers.Add(stamatikiis);
            listOfWorkers.Add(petkancho);
            listOfWorkers.Add(mariq);
            listOfWorkers.Add(elenka);
            listOfWorkers.Add(illiq);
            listOfWorkers.Add(simeoncho);
            listOfWorkers.Add(boiko);
            listOfWorkers.Add(ahmetcho);
            listOfWorkers.Add(maicheto);

            var sortWorkers = from worker in listOfWorkers
                              orderby worker.MoneyPerHour descending
                              select worker;

            foreach (var worker in sortWorkers)
            {
                Console.WriteLine("Name {0} {1}: earned money per hour {2}",
                    worker.FirstName, worker.LastName, worker.MoneyPerHour);
            }
            Console.WriteLine();

            var mergeLists = sortStudents.Concat<Human>(sortWorkers).ToList();

            var sortMergeList = from person in mergeLists
                                orderby person.FirstName, person.LastName
                                select person;

            foreach (var person in sortMergeList)
            {
                Console.WriteLine("Name {0} {1}", person.FirstName, person.LastName);
            }
        }*/
    }
}
