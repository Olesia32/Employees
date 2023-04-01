using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Programmer : Employee
    {
        public delegate void ExcessiveHoursEvent(object sender, ExcessiveHoursArgument arg);
        public event ExcessiveHoursEvent ExcessiveHours;
        private double hours_worked;
        private double premium;
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
        public double HoursWorked
        {
            get { return hours_worked; }
            set
            {
                hours_worked = value;
                if (hours_worked > Minimum_amount_hour)
                {
                    OnExcessiveHours(hours_worked - Minimum_amount_hour);
                }
            }
        }
        public override double Salary()
        {
            double salary = Wage_per_hour * hours_worked;
            if (hours_worked < Minimum_amount_hour)
            {
                salary -= salary * 0.25;
            }
            if (premium != 0.0)
            {
                salary += premium;
            }
            return salary;
        }
        public override void ReadFromConsole()
        {
            base.ReadFromConsole();
            Console.Write("Введіть кількість насправді відпрацьованих годин за тиждень: ");
            hours_worked = Double.Parse(Console.ReadLine());
        }
        public void OnExcessiveHours(double param)
        {
            if (ExcessiveHours != null)
            {
                ExcessiveHoursArgument arg = new ExcessiveHoursArgument(param);
                ExcessiveHours(this, arg);
                if (arg.Message != string.Empty)
                {
                    Console.WriteLine($"Працівник {this.Surname} отримав повідомлення від свого керівника: '{arg.Message}'");
                }
                if (arg.AdditionalParameter != 0.0)
                {
                   premium = arg.AdditionalParameter;
                   Console.WriteLine($"Тепер запрлата працівника становить {Salary()} UAH");
                }
            }
        }
    }
    public class ExcessiveHoursArgument : EventArgs
    {
        public double Parameter { get; set; }
        public double AdditionalParameter { get; set; }
        public string Message { get; set; }
        public ExcessiveHoursArgument(double param)
        {
            Parameter = param;
        }
    }
}
