namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestStudent
    {
        public static void Main()
        {
            var studentsList = new List<Student>
            {
                // Problem 9
                // Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks(List<int>), GroupNumber.

                new Student("Rosen", "Plevnevliev", "102030", "0288111111", "rosenpl@abv.bg", new List<int>() { 3, 4, 6 }, 2),
                new Student("Petyr", "Moskov", "112206", "0288222222", "petyrmosk@gmail.com", new List<int>() { 2, 4, 6 }, 1),
                new Student("Boiko", "Borisov", "122334", "0888333333", "bb@abv.bg", new List<int>() { 2, 2, 3 }, 2),
                new Student("Petyr", "Stoqnov", "212121", "0888444444", "petyrst@yahoo.com", new List<int>() { 4, 5, 6 }, 3),
                new Student("Georgi", "Pyrvanov", "554433", "0288555555", "georgip@gmail.com", new List<int>() { 2, 2, 5 }, 2),
                new Student("Nadejda", "Michailova", "998877", "0888989898", "nadejdamich@abv.bg", new List<int>() { 6, 4, 6 }, 1),
                new Student("Delqn", "Peevski", "787806", "088812345", "delqnpev@yahoo.com", new List<int>() { 2, 2, 2 }, 2),
                new Student("Maq", "Manolova", "123456", "0888987654", "maicheto@abv.bg", new List<int>() { 6, 4, 3 }, 3),
            };
            /* Problem 9
              Select only the students that are from group number 2.
              Order the students by FirstName. Use LINQ query*/
            // uncomment to try it
            //listStudentsLinq(studentsList);

            // Problem 10. Using extension methods.
            // uncomment to try it
            //listStudentGroupAndFirstName(studentsList);

            // Problem 11. Extract students by email - abv.bg
            // uncomment to try it
            //listStudentsEMail(studentsList);

            // Problem 12. Extract students by phone
            // uncomment to try it
            //listStudentsPhone(studentsList);

            // Problem 13. Extract students by marks
            // uncomment to try it
            //listStudentsWithExcellentMarks(studentsList);

            //Problem 14.Extract students with two marks. Use extension methods.
            // uncomment to try it
            //listStudentsWithPoorMarks(studentsList);

            //Problem 15.Extract marks
            // uncomment to try it
            //listStudentEnrolledIn2006(studentsList);

            // Problem 18. Grouped by GroupNumber
            // uncomment to try it
            //listStudentsGroupNumber(studentsList);

            // Problem 19. Grouped by GroupName extensions
            // uncomment to try it
            //listStudentsGroupNumberExtension(studentsList);
        }

        private static void listStudentsGroupNumberExtension(List<Student> students)
        {
            var studentsGroupNumberExtension = students
                                               .OrderBy(student => student.GroupNumber)
                                               .GroupBy(student => student.GroupNumber);
            foreach (var group in studentsGroupNumberExtension)
            {
                Console.WriteLine("Group: " + group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1}: {2}", student.FirstName, student.LastName, student.GroupNumber);
                }
                Console.WriteLine();
            }

        }

        public static void listStudentsGroupNumber(List<Student> students)
        {
            var studentsGroupNumber = from student in students
                                      orderby student.GroupNumber
                                      group student by student.GroupNumber into gr
                                      select gr;
            foreach (var group in studentsGroupNumber)
            {
                Console.WriteLine("Group: " + group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("{0} {1}: {2}", student.FirstName, student.LastName, student.GroupNumber);
                }
                Console.WriteLine();
            }

        }

        public static void listStudentEnrolledIn2006(List<Student> students)
        {
            var studentsEnroll = students
                                 .Where(student => student.FN.ToString()[4] == '0' && student.FN.ToString()[5] == '6')
                                 .Select(student => student);

            foreach (var student in studentsEnroll)
            {
                Console.WriteLine("Full Name: {0} {1}: Marks - {2}", student.FirstName, student.LastName, string.Join(", ", student.Marks));
            }
        }

        public static void listStudentsWithPoorMarks(List<Student> students)
        {
            var studentsPoorMarks = students.FindAll(student => student.Marks
                                                .Where(mark => mark == 2)
                                                .Count() == 2)
                                            .Select(student => new
                                            {
                                                FullName = student.FirstName + " " + student.LastName,
                                                Marks = student.Marks
                                            });
            foreach (var student in studentsPoorMarks)
            {
                Console.WriteLine("Full Name: {0}; Marks - {1}", student.FullName, string.Join(", ", student.Marks));
            }
        }

        public static void listStudentsWithExcellentMarks(List<Student> students)
        {
            var studentsExcellentMarsk = from student in students
                                         where student.Marks.Contains(6)
                                         select new
                                         {
                                             FullName = student.FirstName + " " + student.LastName,
                                             Marks = student.Marks
                                         };
            foreach (var student in studentsExcellentMarsk)
            {
                Console.WriteLine("Full Name: {0}; Marks - {1}", student.FullName, string.Join(", ", student.Marks));
            }
        }

        public static void listStudentsPhone(List<Student> students)
        {
            var studentsPhone = from student in students
                                where student.Tel.StartsWith("02")
                                select student;

            PrintListOfStudents(studentsPhone);
        }

        public static void listStudentsEMail(List<Student> students)
        {
            var studentsEMail = from student in students
                                where student.Email.Contains("abv.bg")
                                select student;

            PrintListOfStudents(studentsEMail);
        }

        public static void listStudentsLinq(List<Student> students)
        {
            var studentsLinq = from student in students
                               where student.GroupNumber == 2
                               orderby student.FirstName
                               select student;

            PrintListOfStudents(studentsLinq);
        }

        public static void listStudentGroupAndFirstName(List<Student> students)
        {
            var studentsGroupAndFirstName =
            students.FindAll(student => student.GroupNumber == 2)
                    .OrderBy(student => student.FirstName);

            PrintListOfStudents(studentsGroupAndFirstName);
        }

        // Printing Method
        public static void PrintListOfStudents(IEnumerable<Student> studentsList)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("List of students");
            Console.ResetColor();
            foreach (var student in studentsList)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}

