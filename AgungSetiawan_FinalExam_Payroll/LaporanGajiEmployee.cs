using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgungSetiawan_FinalExam_Payroll.Enum;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class LaporanGajiEmployee
    {
        public Employee Employee { get; set; }
        public PayrollGroup PayrollGroup { get; set; }

        public LaporanGajiEmployee(Employee employee, PayrollGroup payrollGroup)
        {
            this.Employee = employee;
            this.PayrollGroup = payrollGroup;
        }

        public void ReportGaji(Dictionary<int, FullTimeEmployee> dicFullTimeEmp, Dictionary<long, BpjsKesehatan> dicBpjsKesehatan, Dictionary<long, BpjsKetenagakerjaan> dicBpjsKetenagakerjaan) //menampilkan laporan gaji karyawan full-time
        {
            if (PayrollGroup == Enum.PayrollGroup.Permanent) //validasi jika payrollGroupnya == permanent
            {
                foreach (KeyValuePair<int, FullTimeEmployee> ftEmp in dicFullTimeEmp)
                {
                    if (ftEmp.Key == Employee.NomorKaryawan) //validasi jika key FullTimeEmp sama dengan nomor karyawan employee
                    {
                        foreach (KeyValuePair<long, BpjsKesehatan> bpjsKes in dicBpjsKesehatan)
                        {
                            foreach (KeyValuePair<long, BpjsKetenagakerjaan> bpjsKet in dicBpjsKetenagakerjaan)
                            {
                                if (bpjsKes.Key == Employee.NomorKTP)
                                {
                                    Console.WriteLine($"{ftEmp.Key}). >> {ftEmp.Value.Employee.FullName()} bekerja sebagai {ftEmp.Value.Employee.Pekerjaan} Gaji : {Helper.ParsingRupiah(ftEmp.Value.GajiPerBulan())} Potongan Bpjs : {Helper.ParsingRupiah(bpjsKes.Value.Iuran + bpjsKet.Value.Iuran)}");
                                }
                                
                            }
                        }
                        
                    }
                }
            }
        }

        public void ReportGaji(Dictionary<int, PartTimeEmployee> dicPartTimeEmp, Dictionary<long, BpjsKesehatan> dicBpjsKesehatan, Dictionary<long, BpjsKetenagakerjaan> dicBpjsKetenagakerjaan) //menampilkan laporan gaji karyawan part-time
        {
            if (PayrollGroup == Enum.PayrollGroup.Contract) //validasi jika payrollGroupnya == contract
            {
                foreach (KeyValuePair<int, PartTimeEmployee> ptEmp in dicPartTimeEmp)
                {
                    if (ptEmp.Key == Employee.NomorKaryawan) //validasi jika key PartTimeEmp sama dengan nomor karyawan employee
                    {
                        foreach (KeyValuePair<long, BpjsKesehatan> bpjsKes in dicBpjsKesehatan)
                        {
                            foreach (KeyValuePair<long, BpjsKetenagakerjaan> bpjsKet in dicBpjsKetenagakerjaan)
                            {
                                if (bpjsKet.Key == Employee.NomorKTP)
                                {
                                    Console.WriteLine($"{ptEmp.Key}). >> {ptEmp.Value.Employee.FullName()} bekerja sebagai {ptEmp.Value.Employee.Pekerjaan} Gaji : {Helper.ParsingRupiah(ptEmp.Value.GajiPerBulan())} Potongan Bpjs : {Helper.ParsingRupiah(bpjsKes.Value.Iuran + bpjsKet.Value.Iuran)}");
                                }
                            }
                        }
                    }
                }
            }
        }

        public void InformasiLengkap(Dictionary<int, FullTimeEmployee> dicFullTimeEmp)
        {
            if (PayrollGroup == Enum.PayrollGroup.Permanent)
            {
                foreach (KeyValuePair<int, FullTimeEmployee> ftEmp in dicFullTimeEmp)
                {
                    if (ftEmp.Key == Employee.NomorKaryawan)
                    {
                        Employee.PrintInformationEmployee();
                        Console.WriteLine($"Payroll \t\t: {Helper.ParsingPayroll(Enum.PayrollGroup.Permanent)}");
                        Console.WriteLine($"Salary \t\t\t: {Helper.ParsingRupiah(ftEmp.Value.GajiPerBulan())}\n");
                    }
                }
            }
        }

        public void InformasiLengkap(Dictionary<int, PartTimeEmployee> dicPartTimeEmp)
        {
            if (PayrollGroup == Enum.PayrollGroup.Contract)
            {
                foreach (KeyValuePair<int, PartTimeEmployee> ptEmp in dicPartTimeEmp)
                {
                    if (ptEmp.Key == Employee.NomorKaryawan)
                    {
                        Employee.PrintInformationEmployee();
                        Console.WriteLine($"Payroll \t\t: {Helper.ParsingPayroll(Enum.PayrollGroup.Contract)}");
                        Console.WriteLine($"Salary \t\t\t: {Helper.ParsingRupiah(ptEmp.Value.GajiPerBulan())}\n");
                    }
                }
            }
        }

    }
}
