using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class Bpjs
    {
        public long NomorKTP { get; set; }
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }

        public Bpjs(long nomorKTP, string namaDepan, string namaBelakang)
        {
            this.NomorKTP = nomorKTP;
            this.NamaDepan = namaDepan;
            this.NamaBelakang = namaBelakang;
        }


    }
}
