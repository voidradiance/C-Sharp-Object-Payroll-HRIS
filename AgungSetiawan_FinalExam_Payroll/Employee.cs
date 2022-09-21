using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgungSetiawan_FinalExam_Payroll.Enum;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class Employee
    {
        public int NomorKaryawan { get; set; }
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public EnumGender JenisKelamin { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string TempatLahir { get; set; }
        public long NomorKTP { get; set; }
        public EnumJob Pekerjaan { get; set; }
        public DateTime TanggalMulaiBekerja { get; set; }

        public Employee(int nomorKaryawan, string namaDepan, string namaBelakang, EnumGender jenisKelamin, DateTime tanggalLahir, string tempatLahir,
            long nomorKTP, EnumJob pekerjaan, DateTime tanggalMulaiBekerja)
        {
            this.NomorKaryawan = nomorKaryawan;
            this.NamaDepan = namaDepan;
            this.NamaBelakang = namaBelakang;
            this.JenisKelamin = jenisKelamin;
            this.TanggalLahir = tanggalLahir;
            this.TempatLahir = tempatLahir;
            this.NomorKTP = nomorKTP;
            this.Pekerjaan = pekerjaan;
            this.TanggalMulaiBekerja = tanggalMulaiBekerja;
        }

        public int Umur() //menghitung umur karyawan
        {
            return DateTime.Now.Year - this.TanggalLahir.Year;
        }

        public string FullName() //menampilkan nama lengkap karyawan
        {
            return string.Format($"{this.NamaDepan} {this.NamaBelakang}");
        }

        public void ListInformationEmployee() //menampilkan informasi karyawan
        {
            Console.WriteLine($"{NomorKaryawan}). >> {FullName()} bekerja sebagai ({Pekerjaan})");
        }

        public void PrintInformationEmployee() //menampilkan informasi karyawan
        {
            Console.WriteLine($"\n===== Information Employee {NomorKaryawan} =====");
            Console.WriteLine($"Full Name \t\t: {FullName()}");
            Console.WriteLine($"Gender \t\t\t: {Helper.ParsingGender(JenisKelamin)}");
            Console.WriteLine($"Birth Information \t: {TempatLahir}, {Helper.ParsingTanggal(TanggalLahir)} ({Umur()} tahun)");
            Console.WriteLine($"ID Card \t\t: {NomorKTP}");
            Console.WriteLine($"Job \t\t\t: {Pekerjaan}");
            Console.WriteLine($"Hire Date \t\t: {Helper.ParsingTanggal(TanggalMulaiBekerja)}");
        }

    }
}
