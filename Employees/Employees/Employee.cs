using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Employee : IComparable, ICloneable
    {
        private string surname;
        private double experience;
        private double wage_per_hour;
        private double minimum_amount_hour;

        public Employee()
        {
            surname = string.Empty;
            experience = 0.0;
            wage_per_hour = 0.0;
            minimum_amount_hour = 0.0;
        }
        public Employee(string _surname, double _experience, double _wage_per_hour, double _minimum_amount_hour)
        {
            surname = _surname;
            experience = _experience;
            wage_per_hour = _wage_per_hour;
            minimum_amount_hour = _minimum_amount_hour;
        }
        public double Wage_per_hour
        {
            get { return wage_per_hour; }
            set { wage_per_hour = value; }
        }
        public double Minimum_amount_hour
        {
            get { return minimum_amount_hour; }
            set { minimum_amount_hour = value; }
        }
        public virtual double Salary()
        {
            return minimum_amount_hour * wage_per_hour;
        }
        public override string ToString()
        {
            return $"Прізвище: {surname}, стаж: {experience}, заробітня плата: {Salary()} UAN;";
        }
        public static Employee operator +(Employee _employee, double new_wage_per_hour)
        {
            return new Employee(_employee.surname, _employee.experience, _employee.wage_per_hour + new_wage_per_hour, _employee.minimum_amount_hour);
        }
        public static bool operator <(Employee first, Employee second)
        {
            return first.Salary() < second.Salary();
        }
        public static bool operator >(Employee first, Employee second)
        {
            return first.Salary() > second.Salary();
        }
        public virtual void ReadFromConsole()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Введіть прізвище працівника: ");
            surname = Console.ReadLine();

            Console.Write("Введіть стаж: ");
            experience = Double.Parse(Console.ReadLine());

            Console.Write("Введіть оплату за годину: ");
            wage_per_hour = Double.Parse(Console.ReadLine());

            Console.Write("Введіть мінімальну кількість годин, які він має відпрацювати за тиждень: ");
            minimum_amount_hour = Double.Parse(Console.ReadLine());
        }

        public int CompareTo(object obj)
        {
            if(!(obj is Employee))
            {
                throw new ArgumentException("Compared Object is not of employee");
            }
            Employee employee = obj as Employee;
            return Salary().CompareTo(employee.Salary());
        }

        public object Clone()
        {
            return new Employee(surname, experience, wage_per_hour, minimum_amount_hour);
        }

    }
}
