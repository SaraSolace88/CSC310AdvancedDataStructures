using System;
using System.IO;

namespace HashTable
{
    internal class Program
    {
        static string dataFile = Path.Combine("usContacts.csv");

        static void Main(string[] args)
        {
            HashTable<int, Employee> employees = new HashTable<int, Employee>();

            using (StreamReader sReader = File.OpenText(dataFile))
            {
                string currString;
                while ((currString = sReader.ReadLine()) != null)
                {
                    Employee employee = new Employee(currString.Split(','));
                    employees.Insert(employee.getID(), employee);
                }
            }
            employees.IterateAll();
            Console.WriteLine($"{employees._size} employees");


            employees.TryGetValue(499, out Employee val1);
            employees.TryGetValue(1, out Employee val2);
            employees.TryGetValue(235, out Employee val3);

            Console.WriteLine("Employee 499:" + val1);
            Console.WriteLine("Employee 1:" + val2);
            Console.WriteLine("Employee 235:" + val3);

            Console.WriteLine("Deleting Employee 499");
            employees.Remove(499);
            Console.WriteLine("Deleting Employee 357");
            employees.Remove(357);
            Console.WriteLine("Deleting Employee 53");
            employees.Remove(53);



            employees.TryGetValue(499, out Employee rem1);
            employees.TryGetValue(357, out Employee rem2);
            employees.TryGetValue(53, out Employee rem3);



            Console.WriteLine("Employee 499:" + rem1);
            Console.WriteLine("Employee 357:" + rem2);
            Console.WriteLine("Employee 53:" + rem3);
        }
    }
}
