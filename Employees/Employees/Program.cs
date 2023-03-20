using System;
using System.Collections.Generic;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Employee a1 = new Employee("Валах", 32.4, 175.0, 25);
            Programmer a2 = new Programmer("Коваль", 20.0, 250, 45, 30);
            Employee a3 = new Employee("Боженко", 28.3, 183.5, 38);
            Employee a4 = new Employee("Абраменко", 42.1, 220.4, 27);
            Programmer a5 = new Programmer("Глоба", 11.0, 195.9, 41, 50);
            Leader l1 = new Leader("Рожко", 13.0, 280, 40, 5);
            Leader l2 = new Leader("Панчук", 15, 300, 40, 5);


            List<Employee> list_of_empoyees = new List<Employee>();
            list_of_empoyees.Add(a1);
            list_of_empoyees.Add(a2);
            list_of_empoyees.Add(a3);
            list_of_empoyees.Add(a4);
            list_of_empoyees.Add(a5);
            list_of_empoyees.Add(l1);
            list_of_empoyees.Add(l2);
            Console.WriteLine("------------Працівники:------------");
            foreach (Employee i in list_of_empoyees)
            {
                Console.WriteLine(i);
            }
            Employee highest_paid_employee = new Employee();

            //Пошук найвисокооплачуванішого працівника
            foreach (Employee i in list_of_empoyees)
            {
                if (i > highest_paid_employee)
                {
                    highest_paid_employee = i;
                }
            }
            Console.WriteLine("\n-------Найвисокооплачуваніший працівник------\n{0}", highest_paid_employee);
            if(highest_paid_employee is Programmer)
            {
                Console.WriteLine("Цей працівник є програмістом");
            }
            else
            {
                Console.WriteLine("Цей працівник не є програмістом");
            }

            // Демонстрація роботи арифметичного оператора
            Console.WriteLine("\n---Демонстрація роботи арифметичного оператора + (збільшує оплату за годину)---");
            Console.WriteLine("До: {0}", a1);
            a1 += 5;
            Console.WriteLine("Після застосування оператора +: {0}", a1);

            // Введення в режимі діалогу інформації про нового працівника
            Console.WriteLine("\n---------Створення нового працівника-------");
            Employee a6 = new Employee();
            a6.ReadFromConsole();
            Console.WriteLine("Новий працівник: " + a6);

            // Створення двох нових колекцій які містять окремо програмістів та керівників
            List<Programmer> list_of_programmer = new List<Programmer>();
            foreach (Employee i in list_of_empoyees)
            {
                if (i is Programmer)
                {
                    list_of_programmer.Add(i as Programmer);
                }
            }
            Console.WriteLine("\n-----Працівники програмісти-----");
            foreach(Programmer i in list_of_programmer)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
