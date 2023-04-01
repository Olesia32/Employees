using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Leader : Employee
    {
        public delegate void ExcessiveNumberJuniorsEvent(object sender, ExcessiveNumberJuniorsArgument arg);
        public event ExcessiveNumberJuniorsEvent ExcessiveNumberJuniors;
        private int junior;
        private double premium;
        private const int normal_number_juniors = 5;

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
        public int Junior
        {
            get { return junior; }
            set
            {
                junior = value;
                if (junior > normal_number_juniors)
                {
                    OnExcessiveNumberJuniors(junior - normal_number_juniors);
                }
            }
        }
        public override double Salary()
        {
            double salary = base.Salary();
            for (int i = 0; i < junior; i++)
            {
                salary *= 1.01;
            }
            if (premium != 0.0)
            {
                salary += premium;
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
        public void JuniorSuccess(object sender, ExcessiveHoursArgument arg)
        {
            Programmer programmer = sender as Programmer;
            if (arg is ExcessiveHoursArgument) (arg as ExcessiveHoursArgument).Message =
                    $"Вітаю з чудовим результатом колего {programmer.Surname}.";
        }
        public void OnExcessiveNumberJuniors(double param)
        {
            if (ExcessiveNumberJuniors != null)
            {
                ExcessiveNumberJuniorsArgument arg = new ExcessiveNumberJuniorsArgument(param);
                ExcessiveNumberJuniors(this, arg);

                if (arg.AdditionalParameter != 0.0)
                {
                    premium = arg.AdditionalParameter;
                    Console.WriteLine($"Тепер запрлата керівника становить {Salary()} UAH");
                }
            }
        }
    }
    public class ExcessiveNumberJuniorsArgument : EventArgs
    {
        public double Parameter { get; set; }
        public double AdditionalParameter { get; set; }
        public string Message { get; set; }
        public ExcessiveNumberJuniorsArgument(double param)
        {
            Parameter = param;
        }
    }
}