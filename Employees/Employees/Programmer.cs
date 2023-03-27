using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Programmer : Employee
    {
        private double hours_worked;
        public Programmer() : base() { hours_worked = 0.0; }
        public Programmer(string _surname, double _experience, double _wage_per_hour, double _minimum_amount_hour, 
            double _hours_worked) : base(_surname, _experience, _wage_per_hour, _minimum_amount_hour)
        {
            hours_worked = _hours_worked;
        }
        public Programmer(Employee _employee, double _hours_worked)
        { }
        public override string ToString()
        {
            return $"Працівник-програміст: {base.ToString()};";
        }
        public override double Salary()
        {
            double salary = Wage_per_hour * hours_worked;
            if (hours_worked < Minimum_amount_hour)
            {
                salary -= salary * 0.25;
            }
            return Math.Round(salary, 2);
        }
        public override void ReadFromConsole()
        {
            base.ReadFromConsole();
            Console.Write("Введіть кількість насправді відпрацьованих годин за тиждень: ");
            hours_worked = Double.Parse(Console.ReadLine());
        }
    }
}
