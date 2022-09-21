using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class BpjsKesehatan : Bpjs
    {
        public double Iuran {
            get { return Iuran; }
            set { Iuran = 180000;}
        }
        public int Kelas { get { return Kelas; } set { Kelas = 1; } }

        public BpjsKesehatan(long nomorKtp, string namaDepan, string namaBelakang)
            :base(nomorKtp, namaDepan, namaBelakang)
        {
        }
    }
}
