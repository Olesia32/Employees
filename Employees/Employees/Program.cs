using System;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Employee[] employees = new Employee[5];
            Employee a1 = new Employee("Валах", 32.4, 175.0, 25);
            Employee a2 = new Employee("Коваль", 20.0, 250, 45);
            Employee a3 = new Employee("Боженко", 28.3, 183.5, 38);
            Employee a4 = new Employee("Абраменко", 42.1, 220.4, 27);
            Employee a5 = new Employee("Глоба", 11.0, 195.9, 41);
            employees[0] = a1;
            employees[1] = a2;
            employees[2] = a3;
            employees[3] = a4;
            employees[4] = a5;
            foreach (Employee i in employees)
            {
                Console.WriteLine(i);
            }
            Employee highest_paid_employee = new Employee();
            // Пошук найвисокооплачуванішого працівника
            foreach (Employee i in employees)
            {
                if (i > highest_paid_employee)
                {
                    highest_paid_employee = i;
                }
            }
            Console.WriteLine("\nНайвисокооплачуваніший працівник: {0}", highest_paid_employee);
            // Демонстрація роботи арифметичного оператора
            Console.WriteLine("\nДемонстрація роботи арифметичного оператора + (збільшує оплату за годину)");
            Console.WriteLine("До: {0}", a1);
            a1 += 5;
            Console.WriteLine("Після застосування оператора +: {0}", a1);
            Console.ReadLine();
        }
    }
}
