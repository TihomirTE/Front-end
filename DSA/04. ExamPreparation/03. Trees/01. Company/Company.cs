using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Company
{
    public class Company
    {
        private static int salaries = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            Dictionary<string, Employee> employees = new Dictionary<string, Employee>();

            string bossName = Console.ReadLine();
            Employee bigBoss = new Employee(bossName);

            employees.Add(bossName, bigBoss);

            for (int i = 1; i < n; i++)
            {
                string name = Console.ReadLine();
                Employee employee = new Employee(name);
                employees.Add(name, employee);
            }

            for (int i = 0; i < m; i++)
            {
                string relationships = Console.ReadLine();
                string[] names = relationships.Split(' ');
                string boss = names[0];
                for (int j = 1; j < names.Length; j++)
                {
                    employees[boss].AddEmployee(employees[names[j]]);
                }
            }

            CalculateSalary(bigBoss);
            Console.WriteLine(salaries);
        }

        // Implement DFS Algorithm
        private static void CalculateSalary(Employee currentBoss)
        {
            if (currentBoss.Subordinates.Count == 0)
            {
                salaries += currentBoss.Salary;
                return;
            }

            int salary = 0;
            foreach (var employee in currentBoss.Subordinates)
            {
                CalculateSalary(employee);
                salary += employee.Salary;
            }
            currentBoss.Salary = salary;
            salaries += currentBoss.Salary;
        }
    }
}
