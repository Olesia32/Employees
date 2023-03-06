using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Employee
    {
        private string surname;
        private double experience;
        private double wage_per_hour;
        private double minimum_amount_hour;

        public string Surname
        {
            get { return surname; }
            private set { surname = value; }
        }
        public double Experience
        {
            get { return experience; }
            private set { experience = value; }
        }
        public double Wage_per_hour
        {
            get { return wage_per_hour; }
            private set { wage_per_hour = value; }
        }
        public double Minimum_amount_hour
        {
            get { return minimum_amount_hour; }
            private set { minimum_amount_hour = value; }
        }

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
    }
}
