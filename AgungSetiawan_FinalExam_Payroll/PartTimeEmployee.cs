using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgungSetiawan_FinalExam_Payroll.Enum;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class PartTimeEmployee
    {
        public double UpahPerHari { get; set; }
        public int TotalHariBekerja { get; set; }
        public Employee Employee { get; set; }

        public PartTimeEmployee(Employee employee, double upahPerHari, int totalHariBekerja)
        {
            this.Employee = employee;
            this.UpahPerHari = upahPerHari;
            this.TotalHariBekerja = totalHariBekerja;
        }

        public double GajiPerBulan() //menghitung gaji per bulan karyawan Part-Time
        {
            return this.TotalHariBekerja * this.UpahPerHari;
        }

    }
}
