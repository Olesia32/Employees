using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Leader : Employee
    {
        private int junior;

        public Leader()
            : base()
        {
            junior = 0;
            Minimum_amount_hour = 40;
        }

        public Leader(string _surname, double _experience, double _wage_per_hour, double _minimum_amount_hour, int _junior)
            : base(_surname, _experience, _wage_per_hour, _minimum_amount_hour)
        {
            junior = _junior;
            Minimum_amount_hour = 40;
        }

        public override double Salary()
        {
            double salary = base.Salary();
            for (int i = 0; i < junior; i++)
            {
                salary *= 1.01;
            }
            return Math.Round(salary, 2);
        }

        public override string ToString()
        {
            return $"Працівник-керівник: {base.ToString()}";
        }

        public override void ReadFromConsole()
        {
            base.ReadFromConsole();
            Console.Write("Введіть кількість підлеглих: ");
            junior = Int32.Parse(Console.ReadLine());
        }
    }
}