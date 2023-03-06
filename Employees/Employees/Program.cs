using System;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1= new Employee("koks", 20, 50, 40);
            Employee e2 = new Employee();
            Console.WriteLine(e2);
        }
    }
}
