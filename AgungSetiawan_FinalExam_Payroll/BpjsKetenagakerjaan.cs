using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class BpjsKetenagakerjaan : Bpjs
    {
        public double Iuran { get; set; }
        public int Kelas { get { return Kelas; } set { Kelas = 1; } }

        public BpjsKetenagakerjaan(long nomorKTP, string namaDepan, string namaBelakang, double iuran)
            : base(nomorKTP, namaDepan, namaBelakang)
        {
            this.Iuran = iuran;
        }
    }
}
