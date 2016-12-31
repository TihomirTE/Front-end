namespace StudentGroups
{
    using System;
    using System.Collections.Generic;

    /* Problem 9
     * Create a class Student with properties FirstName, LastName, FN,
     *  Tel, Email, Marks (a List), GroupNumber.*/

    public class Student
    {
        // properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FN { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }

        public int GroupNumber { get; set; }

        // constructor
        public Student(string firstName, string lastName, string fn, string tel, string email,
                        List<int> marks, int groupNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            FN = fn;
            Tel = tel;
            Email = email;
            Marks = marks;
            GroupNumber = groupNumber;
        }

        public override string ToString()
        {
            return String.Format($@"First Name: {FirstName}; Last Name: {LastName};
            FN: {FN}; Tel: {Tel}; Email: {Email}; Group Number {GroupNumber}.");
        }
    }
}
