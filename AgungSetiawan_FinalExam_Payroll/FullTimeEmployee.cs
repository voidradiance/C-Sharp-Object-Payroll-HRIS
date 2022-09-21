using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgungSetiawan_FinalExam_Payroll.Enum;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class FullTimeEmployee
    {
        public double GajiPokokPerBulan { get; set; }
        public double PersentaseTunjangan { get; set; }
        public Employee Employee { get; set; }

        public FullTimeEmployee(Employee employee, double gajiPokokPerBulan, double persentaseTunjangan)
        {
            this.Employee = employee;
            this.GajiPokokPerBulan = gajiPokokPerBulan;
            this.PersentaseTunjangan = persentaseTunjangan;
        }

        public double GajiPerBulan() //menghitung gaji per bulan karyawan Full-Time
        {
            return this.GajiPokokPerBulan + (this.GajiPokokPerBulan * (this.PersentaseTunjangan / 100));
        }

    }
}
