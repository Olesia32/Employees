using System;
using System.Collections.Generic;
using System.IO;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Читання з файлу інформації про працівників, створення колекції
            var path  = "../../../employees.txt";
            StreamReader f = new StreamReader(path);
            List<Employee> list_of_empoyees = new List<Employee>();
            while(!f.EndOfStream)
            {
                string[] array = f.ReadLine().Split();
                if(array[0] == "Programmer")
                {
                    list_of_empoyees.Add(new Programmer(array[1], double.Parse(array[2]), double.Parse(array[3]),
                        double.Parse(array[4]), double.Parse(array[5])));
                }
                else if(array[0] == "Leader")
                {
                    list_of_empoyees.Add(new Leader(array[1], double.Parse(array[2]), double.Parse(array[3]),
                        double.Parse(array[4]), int.Parse(array[5])));
                }
                else
                {
                    list_of_empoyees.Add(new Employee(array[1], double.Parse(array[2]), double.Parse(array[3]),
                        double.Parse(array[4])));
                }
            }
            f.Close();
            Console.WriteLine("------------Працівники:------------");
            foreach (Employee i in list_of_empoyees)
            {
                Console.WriteLine(i);
            }

            //Пошук найвисокооплачуванішого працівника
            Employee highest_paid_employee = new Employee();
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
            Console.WriteLine("До: {0}", list_of_empoyees[0]);
            list_of_empoyees[0] += 5;
            Console.WriteLine("Після застосування оператора +: {0}", list_of_empoyees[0]);

            // Введення в режимі діалогу інформації про нового працівника
            Console.WriteLine("\n---------Створення нового працівника-------");
            Employee a6 = new Employee();
            a6.ReadFromConsole();
            list_of_empoyees.Add(a6);
            Console.WriteLine("Новий працівник: " + a6);

            // Створення двох нових колекцій які містять окремо програмістів та керівників
            List<Programmer> list_of_programmers = new List<Programmer>();
            List<Leader> list_of_leaders = new List<Leader>();
            foreach (Employee i in list_of_empoyees)
            {
                if (i is Programmer)
                {
                    list_of_programmers.Add(i as Programmer);
                }
                else if (i is Leader)
                {
                    list_of_leaders.Add(i as Leader);
                }
            }
            Console.WriteLine("\n-----Працівники програмісти-----");
            foreach(Programmer i in list_of_programmers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n-----Працівники керівники-----");
            foreach (Leader i in list_of_leaders)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
