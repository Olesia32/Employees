using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class HumanResourcesDepartment
    {
        public void TrackingWorkEmployees(object sender, ExcessiveHoursArgument arg)
        {
            Programmer programer = sender as Programmer;
            Console.WriteLine("\n-----Відділ кадрів-----");
            Console.WriteLine($"Працівник {programer.Surname} додатково відпрацював {arg.Parameter} годин");
            if(arg.Parameter > 25)
            {
                if (arg is ExcessiveHoursArgument) (arg as ExcessiveHoursArgument).AdditionalParameter =
                    programer.Salary() * 0.2;
                Console.WriteLine($"За вражаючий понаднормовий відробіток працівник {programer.Surname} отримує " +
                    $"премію в розмірі 20% від його зарплати. Розмір премії складає {arg.AdditionalParameter} UAN");
            }
            Console.WriteLine("-----------------------\n");
        }
        public void Inform(Leader leader, Programmer programmer)
        {
            programmer.ExcessiveHours += leader.JuniorSuccess;
        }
    }
}
