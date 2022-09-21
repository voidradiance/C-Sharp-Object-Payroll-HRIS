using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgungSetiawan_FinalExam_Payroll
{
    class Program
    {
        public static Dictionary<int, FullTimeEmployee> dicFullTimeEmp = new Dictionary<int, FullTimeEmployee>(); //collection Full-Time Employee dengan key int (hasil input)
        public static Dictionary<int, PartTimeEmployee> dicPartTimeEmp = new Dictionary<int, PartTimeEmployee>(); //collection Part-Time Employee dengan key int (hasil input)
        public static Dictionary<int, Employee> dicEmployee = new Dictionary<int, Employee>(); //collection Employee dengan key int (data dummy)
        public static Dictionary<int, LaporanGajiEmployee> laporanGaji = new Dictionary<int, LaporanGajiEmployee>(); //collection Laporan Gaji Employee dengan key int (hasil input)

        public static List<int> listNomorKaryawan = new List<int>(); //List nomor karyawan yang sudah pernah di input ke collection

        public static Dictionary<long, BpjsKesehatan> dicBpjsKesehatan = new Dictionary<long, BpjsKesehatan>();
        public static Dictionary<long, BpjsKetenagakerjaan> dicBpjsKetenagakerjaan = new Dictionary<long, BpjsKetenagakerjaan>();

        //buat satu buah class name BPJS, merupakan orangtua dari BPJS-kesehatan, dan ketenagakerjaan.
        //Kriteria setiap employee wajib membayarkan sekitar 3,7% dari besar gaji pokok untuk ketenagakerjaan
        //untuk kesehatan semua employee -180.000
        //kriteria bpjs by nomor ktp

        static void Main(string[] args)
        {
            DataDummy.InjectData(dicEmployee); //innject data dummy dari class DataDummy dengan parameter Employee Collection

            MenuUtama(); //menuju method menu utama
        }

        private static void MenuUtama()
        {
            string input;
            Console.WriteLine("========== Selamat datang di Payroll Module ==========");
            Console.WriteLine("Pilih nomor menu untuk masuk ke menunya : \n" +
                "1). Information All Employee\n" +
                "2). Employee Salary Report\n" +
                "3). Exit Application\n");
            Console.Write("Pilih (1/2/3) : ");
            input = Console.ReadLine().Trim();

            Console.Clear();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    AllEmployeeData();
                    break;
                case "2":
                    Console.Clear();
                    ReportSalaryEmployee();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Terimakasih telah menggunakan aplikasi ini");
                    Console.WriteLine("------------------------------------------\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Maaf pilihan tidak tersedia. Masukkan kembali\n");
                    MenuUtama();
                    break;
            }
        }

        private static void AllEmployeeData()
        {
            Console.WriteLine("=============== Daftar Employee ===============");
            foreach (Employee item in dicEmployee.Values)
            {
                item.ListInformationEmployee();
            }

            Console.WriteLine("\nPilih nomor menu untuk masuk ke menunya : \n" +
                "1). Input Employee to Payroll Group\n" +
                "2). Information Complete All Employee\n" +
                "3). Back to Main Menu\n" +
                "4). Exit Application\n");
            Console.Write("Pilih (1/2/3) : ");
            string input = Console.ReadLine().Trim();

            Console.Clear();

            switch (input)
            {
                case "1":

                    Console.WriteLine("=============== Daftar Employee ===============");
                    foreach (Employee item in dicEmployee.Values)
                    {
                        item.ListInformationEmployee();
                    }

                    if (listNomorKaryawan.Count == dicEmployee.Count) //validasi jika semua karyawan sudah di input ke payroll group
                    {
                        Console.WriteLine("\nMaaf semua Employee sudah di input ke Payroll Group!");
                        MenuTambahan();
                    }
                    else
                    {
                        Console.Write("\nMasukkan nomor karyawan yang ingin anda input ke Payroll Group : ");
                        input = Console.ReadLine().Trim();
                        while (!int.TryParse(input, out int newInput)) //validasi input harus berupa angka
                        {
                            Console.Write("\nFormat input tidak sesuai, masukan lagi : ");
                            input = Console.ReadLine().Trim();
                            continue;
                        }

                        while (listNomorKaryawan.Contains(Convert.ToInt32(input))) //validasi jika input telah ada di listNomorKaryawan
                        {
                            Console.Write("\nNomor Karyawan ini sudah terdaftar di payroll, masukan nomor lain : ");
                            input = Console.ReadLine().Trim();
                            while (!int.TryParse(input, out int newInput)) //validasi input harus berupa angka
                            {
                                Console.Write("\nFormat input tidak sesuai, masukan lagi : ");
                                input = Console.ReadLine().Trim();
                                continue;
                            }
                        }

                        while (!dicEmployee.ContainsKey(Convert.ToInt32(input)))
                        {
                            Console.Write("\nNomor karyawan tidak ditemukan, masukan lagi : ");
                            input = Console.ReadLine().Trim();
                            while (!int.TryParse(input, out int newInput)) //validasi input harus berupa angka
                            {
                                Console.Write("\nFormat input tidak sesuai, masukan lagi : ");
                                input = Console.ReadLine().Trim();
                                continue;
                            }

                            while (listNomorKaryawan.Contains(Convert.ToInt32(input))) //validasi jika input telah ada di listNomorKaryawan
                            {
                                Console.Write("\nNomor Karyawan ini sudah terdaftar di payroll, masukan nomor lain : ");
                                input = Console.ReadLine().Trim();
                                while (!int.TryParse(input, out int newInput)) //validasi input harus berupa angka
                                {
                                    Console.Write("\nFormat input tidak sesuai, masukan lagi : ");
                                    input = Console.ReadLine().Trim();
                                    continue;
                                }
                            }
                        }

                        Console.Clear();
                        PayrollGroup(input);
                    }

                    break;
                case "2":
                    //Console.Clear();
                    //Console.WriteLine("------------------------------");
                    //Console.WriteLine($"Informasi semua data Employee");
                    //Console.WriteLine("------------------------------");

                    //foreach (Employee item in dicEmployee.Values)
                    //{
                    //    item.PrintInformationEmployee();
                    //}

                    MenuInformasiEmployee();
                    break;
                case "3":
                    Console.Clear();
                    MenuUtama();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Terimakasih telah menggunakan aplikasi ini");
                    Console.WriteLine("------------------------------------------\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Maaf pilihan tidak tersedia. Masukkan kembali\n");
                    AllEmployeeData();
                    break;
            }
        }

        private static void PayrollGroup(string input)
        {
            Console.WriteLine("===============================================================");
            dicEmployee[Convert.ToInt32(input)].PrintInformationEmployee(); //menampilkan informasi employee
            Console.WriteLine("\n===============================================================");

            Console.WriteLine("\nPilih nomor menu untuk input ke Payroll Employee : \n" +
                    "1). Full-Time\n" +
                    "2). Part-Time\n" +
                    "3). Back to list employee\n");
            Console.Write("Pilih (1/2/3) : ");
            string payroll = Console.ReadLine().Trim();

            switch (payroll)
            {
                case "1":

                    listNomorKaryawan.Add(Convert.ToInt32(input)); //menambahkan value input ke dalam listNomorKaryawan

                    PayrollFullTime(input);

                    Console.WriteLine("\nKaryawan ini telah terdaftar ke Payroll Full-Time Employee");
                    MenuTambahan();
                    break;

                case "2":

                    listNomorKaryawan.Add(Convert.ToInt32(input)); //menambahkan value input ke dalam listNomorKaryawan
                    PayrollPartTime(input);

                    Console.WriteLine("\nKaryawan ini telah terdaftar ke Payroll Part-Time Employee");
                    MenuTambahan();
                    break;

                case "3":
                    Console.Clear();
                    AllEmployeeData();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Maaf pilihan tidak tersedia. Masukkan kembali\n");
                    PayrollGroup(input);
                    break;
            }
        }

        private static void PayrollFullTime(string input)
        {
            Console.WriteLine("\nKaryawan ini akan dimasukkan ke Payroll Full-Time");
            Console.Write("\nMasukkan detail gaji perbulan karyawan : ");
            string gjInput = Console.ReadLine().Trim();
            double gaji;
            while (!double.TryParse(gjInput, out gaji)) //validasi input harus angka
            {
                Console.Write("Maaf masukkan dalam angka, silahkan masukan kembali : ");
                gjInput = Console.ReadLine().Trim();
                continue;
            }

            Console.Write("\nMasukkan % tunjangan karyawan full-time : ");
            string tjInput = Console.ReadLine().Trim();
            double tunjangan;
            while (!double.TryParse(tjInput, out tunjangan)) //validasi input harus angka
            {
                Console.Write("Maaf masukkan dalam angka, silahkan masukan kembali : ");
                tjInput = Console.ReadLine().Trim();
                continue;
            }

            //Validasi input persentase antara range 0 sampai 100
            while (!(tunjangan >= 0 && tunjangan <= 100))
            {
                Console.Write("Maaf persentase tidak sesuai, masukan range 0 - 100%. Masukan kembali : ");
                tjInput = Console.ReadLine().Trim();
                while (!double.TryParse(tjInput, out tunjangan)) //validasi input harus angka
                {
                    Console.Write("Maaf masukkan dalam angka, silahkan masukan kembali : ");
                    tjInput = Console.ReadLine();
                    continue;
                }
                continue;
            }
            foreach (KeyValuePair<int, Employee> item in dicEmployee)
            {
                if (Convert.ToInt32(input).Equals(item.Key)) //validasi jika input sama dengan dicEmployee.Key
                {
                    dicFullTimeEmp.Add(Convert.ToInt32(input), new FullTimeEmployee(item.Value, gaji, tunjangan)); //menambahkan collection dicFullTimeEmp
                    laporanGaji.Add(Convert.ToInt32(input), new LaporanGajiEmployee(item.Value, Enum.PayrollGroup.Permanent)); //menambahkan collection laporanGaji
                    dicBpjsKesehatan.Add(item.Value.NomorKTP, new BpjsKesehatan(item.Value.NomorKTP, item.Value.NamaDepan, item.Value.NamaBelakang));
                    dicBpjsKetenagakerjaan.Add(item.Value.NomorKTP, new BpjsKetenagakerjaan(item.Value.NomorKTP, item.Value.NamaDepan, item.Value.NamaBelakang, (gaji * 0.037)));
                }
            }
        }

        private static void PayrollPartTime(string input)
        {
            Console.WriteLine("\nKaryawan ini akan dimasukkan ke Payroll Part-Time");
            Console.Write("\nMasukkan detail gaji perhari karyawan : ");
            string gjPerhari = Console.ReadLine().Trim();
            double upah;
            while (!double.TryParse(gjPerhari, out upah)) //validasi input harus angka
            {
                Console.Write("Maaf masukkan dalam angka, silahkan masukan kembali : ");
                gjPerhari = Console.ReadLine();
                continue;
            }

            Console.Write("\nMasukkan jumlah hari bekerja Part-Time : ");
            string jmlHari = Console.ReadLine().Trim();
            int hariKerja;
            while (!int.TryParse(jmlHari, out hariKerja)) //validasi input harus angka
            {
                Console.Write("Maaf masukkan dalam angka, silahkan masukan kembali : ");
                jmlHari = Console.ReadLine();
                continue;
            }

            while (!(hariKerja > 0 && hariKerja <= 21)) //validasi jumlah hari kerja dalam sebulan
            {
                Console.Write("Maaf jumlah hari kerja dalam sebulan tidak sesuai, masukan dalam range 1 - 21. Masukan kembali : ");
                jmlHari = Console.ReadLine().Trim();
                while (!int.TryParse(jmlHari, out hariKerja)) //validasi input harus angka
                {
                    Console.Write("Maaf masukkan dalam angka, silahkan masukan kembali : ");
                    jmlHari = Console.ReadLine();
                    continue;
                }
                continue;
            }


            foreach (KeyValuePair<int, Employee> item in dicEmployee)
            {
                if (Convert.ToInt32(input).Equals(item.Key)) //validasi jika input sama dengan dicEmployee.Key
                {
                    dicPartTimeEmp.Add(Convert.ToInt32(input), new PartTimeEmployee(item.Value, upah, hariKerja)); //menambahkan collection dicPartTimeEmp
                    laporanGaji.Add(Convert.ToInt32(input), new LaporanGajiEmployee(item.Value, Enum.PayrollGroup.Contract)); //menambahkan collection laporanGaji
                    dicBpjsKesehatan.Add(item.Value.NomorKTP, new BpjsKesehatan(item.Value.NomorKTP, item.Value.NamaDepan, item.Value.NamaBelakang));
                    dicBpjsKetenagakerjaan.Add(item.Value.NomorKTP, new BpjsKetenagakerjaan(item.Value.NomorKTP, item.Value.NamaDepan, item.Value.NamaBelakang, ((upah * hariKerja) * 0.037)));
                }
            }
        }

        private static void MenuTambahan()
        {
            Console.WriteLine("\nPilih nomor menu untuk masuk ke menunya : \n" +
                 "1). Back to Information All Employee\n" +
                 "2). Back to Main Menu\n" +
                 "3). Exit Application\n");
            Console.Write("Pilih (1/2/3) : ");
            string input = Console.ReadLine().Trim();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    AllEmployeeData();
                    break;
                case "2":
                    Console.Clear();
                    MenuUtama();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Terimakasih telah menggunakan aplikasi ini");
                    Console.WriteLine("------------------------------------------\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Maaf pilihan tidak tersedia. Masukkan kembali\n");
                    MenuTambahan();
                    break;
            }
        }

        private static void MenuInformasiEmployee()
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Informasi semua data Employee");
            Console.WriteLine("------------------------------");
            foreach (Employee item in dicEmployee.Values)
            {
                item.PrintInformationEmployee();
            }

            Console.WriteLine("\nPilih nomor menu untuk masuk ke menunya : \n" +
                "1). Print informasi Full-Time Employee\n" +
                "2). Print informasi Part-Time Employee\n" +
                "3). Back to All Employee Data\n");
            Console.Write("Pilih (1/2/3) : ");
            string input = Console.ReadLine().Trim();
            switch (input)
            {
                case "1":
                    Console.Clear();

                    if (dicFullTimeEmp.Values.Count == 0)
                    {
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine($"Maaf informasi {Helper.ParsingPayroll(Enum.PayrollGroup.Permanent)} Employee belum ada!");
                        Console.WriteLine("-----------------------------------------------\n");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Informasi semua data Full-Time Employee");
                        Console.WriteLine("------------------------------");

                        foreach (LaporanGajiEmployee item in laporanGaji.Values)
                        {
                            item.InformasiLengkap(dicFullTimeEmp);
                        }
                    }

                    Console.Write("Tekan apa saja untuk kembali ke menu Informasi Employee .... ");
                    Console.ReadLine();

                    Console.Clear();
                    MenuInformasiEmployee();

                    break;
                case "2":
                    Console.Clear();

                    if (dicPartTimeEmp.Values.Count == 0)
                    {
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine($"Maaf informasi {Helper.ParsingPayroll(Enum.PayrollGroup.Contract)} Employee belum ada!");
                        Console.WriteLine("-----------------------------------------------\n");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Informasi semua data Part-Time Employee");
                        Console.WriteLine("------------------------------");

                        foreach (LaporanGajiEmployee item in laporanGaji.Values)
                        {
                            item.InformasiLengkap(dicPartTimeEmp);
                        }
                    }

                    Console.Write("Tekan apa saja untuk kembali ke menu Informasi Employee .... ");
                    Console.ReadLine();

                    Console.Clear();
                    MenuInformasiEmployee();

                    break;
                case "3":
                    Console.Clear();
                    AllEmployeeData();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Maaf pilihan tidak tersedia. Masukkan kembali\n");
                    MenuTambahan();
                    break;
            }
        }

        private static void ReportSalaryEmployee()
        {
            Console.WriteLine("Pilih nomor menu untuk masuk ke menunya : \n" +
                 "1). Employee Full-Time Salary Report\n" +
                 "2). Employee Part-Time Salary Report\n" +
                 "3). Back to Main Menu\n" +
                 "4). Exit Application\n");
            Console.Write("Pilih (1/2/3/4) : ");
            string input = Console.ReadLine().Trim();
            switch (input)
            {
                case "1":
                    Console.Clear();

                    if (dicFullTimeEmp.Values.Count == 0) //validasi jika collection dicFullTimeEmp kosong
                    {
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine($"Maaf laporan gaji {Helper.ParsingPayroll(Enum.PayrollGroup.Permanent)} Employee belum ada!");
                        Console.WriteLine("-----------------------------------------------\n");
                    }
                    else //jika collection dicFullTimeEmp ada isinya, maka tampilkan ReportGajiFullTimeEmp
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"Berikut adalah laporan gaji {Helper.ParsingPayroll(Enum.PayrollGroup.Permanent)} Employee");
                        Console.WriteLine("----------------------------------------------\n");
                        foreach (LaporanGajiEmployee item in laporanGaji.Values)
                        {
                            item.ReportGaji(dicFullTimeEmp, dicBpjsKesehatan, dicBpjsKetenagakerjaan);
                        }
                    }

                    Console.Write("\nBack to report salary employee? (y/n) ");
                    input = Console.ReadLine();
                    while (!input.ToLower().Equals("y") && !input.ToLower().Equals("n")) //validasi input antara (y/n)
                    {
                        Console.Write("hanya input yes atau no (y/n) ");
                        input = Console.ReadLine().Trim();
                    }
                    if (input.ToLower().Equals("y"))
                    {
                        Console.Clear();
                        ReportSalaryEmployee();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Terimakasih telah menggunakan aplikasi ini");
                        Console.WriteLine("------------------------------------------\n");
                    }

                    break;
                case "2":
                    Console.Clear();

                    if (dicPartTimeEmp.Values.Count == 0) //validasi jika collection dicPartTimeEmp kosong
                    {
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine($"Maaf laporan gaji {Helper.ParsingPayroll(Enum.PayrollGroup.Contract)} Employee belum ada!");
                        Console.WriteLine("-----------------------------------------------\n");
                    }
                    else //jika collection dicPartTimeEmp ada isinya, maka tampilkan ReportGajiFullTimeEmp
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine($"Berikut adalah laporan gaji {Helper.ParsingPayroll(Enum.PayrollGroup.Contract)} Employee");
                        Console.WriteLine("----------------------------------------------\n");
                        foreach (LaporanGajiEmployee item in laporanGaji.Values)
                        {
                            item.ReportGaji(dicPartTimeEmp, dicBpjsKesehatan, dicBpjsKetenagakerjaan);
                        }
                    }

                    Console.Write("\nBack to report salary employee? (y/n) ");
                    input = Console.ReadLine();
                    while (!input.ToLower().Equals("y") && !input.ToLower().Equals("n")) //validasi input antara (y/n)
                    {
                        Console.Write("hanya input yes atau no (y/n) ");
                        input = Console.ReadLine().Trim();
                    }
                    if (input.ToLower().Equals("y"))
                    {
                        Console.Clear();
                        ReportSalaryEmployee();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Terimakasih telah menggunakan aplikasi ini");
                        Console.WriteLine("------------------------------------------\n");
                    }

                    break;
                case "3":
                    Console.Clear();
                    MenuUtama();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Terimakasih telah menggunakan aplikasi ini");
                    Console.WriteLine("------------------------------------------\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Maaf pilihan tidak tersedia. Masukkan kembali\n");
                    MenuTambahan();
                    break;
            }
        }

    }
}
