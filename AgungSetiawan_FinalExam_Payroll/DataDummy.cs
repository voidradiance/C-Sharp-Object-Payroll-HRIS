using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgungSetiawan_FinalExam_Payroll
{
    public static class DataDummy
    {
        public static void InjectData(Dictionary<int, Employee> dicEmployee)
        {
            Employee empAmos = new Employee(1, "Amos", "Pike", Enum.EnumGender.L, new DateTime(1991, 2, 12), "Kokomo", 9187439271, Enum.EnumJob.Accountant, new DateTime(2018, 11, 1));
            Employee empBrenda = new Employee(2, "Brenda", "Cavin", Enum.EnumGender.P, new DateTime(1951, 11, 28), "New York", 8231749873, Enum.EnumJob.Programmer, new DateTime(2018, 11, 4));
            Employee empBilly = new Employee(3, "Billy", "Smith", Enum.EnumGender.L, new DateTime(1966, 8, 18), "Redmond", 1234913279, Enum.EnumJob.Programmer, new DateTime(2018, 10, 10));
            Employee empJoseph = new Employee(4, "Joseph", "Barnes", Enum.EnumGender.L, new DateTime(1991, 8, 1), "New York", 1793741932, Enum.EnumJob.Programmer, new DateTime(2018, 11, 4));
            Employee empEloise = new Employee(5, "Eloise", "Stites", Enum.EnumGender.P, new DateTime(1941, 7, 14), "Southfield", 2779348728, Enum.EnumJob.Accountant, new DateTime(2018, 11, 1));
            Employee empAllie = new Employee(6, "Allie", "Gordon", Enum.EnumGender.P, new DateTime(1974, 2, 12), "Southfield", 8934712934, Enum.EnumJob.Lawyer, new DateTime(2018, 11, 4));
            Employee empCynthia = new Employee(7, "Cynthia", "Thompson", Enum.EnumGender.P, new DateTime(1987, 11, 22), "Chandler", 8927347778, Enum.EnumJob.Lawyer, new DateTime(2018, 11, 1));

            dicEmployee.Add(1, empAmos);
            dicEmployee.Add(2, empBrenda);
            dicEmployee.Add(3, empBilly);
            dicEmployee.Add(4, empJoseph);
            dicEmployee.Add(5, empEloise);
            dicEmployee.Add(6, empAllie);
            dicEmployee.Add(7, empCynthia);

        }

    }
}
