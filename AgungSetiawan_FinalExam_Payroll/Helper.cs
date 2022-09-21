using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgungSetiawan_FinalExam_Payroll.Enum;

namespace AgungSetiawan_FinalExam_Payroll
{
    public class Helper
    {
        public static string ParsingTanggal(DateTime tanggal) //parsing tanggal menjadi format indonesia
        {
            return tanggal.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID"));
        }

        public static string ParsingRupiah(double jumlah) //parsing money menjadi format rupiah indonesia
        {
            return jumlah.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"));
        }

        public static string ParsingGender(EnumGender enumGender) //parsing enum gender
        {
            string result = string.Empty;
            if (enumGender == Enum.EnumGender.L)
            {
                result = "Laki - laki";
            }
            else
            {
                result = "Perempuan";
            }

            return result;
        }

        public static string ParsingPayroll(PayrollGroup enumPayroll) //parsing payrollgroup
        {
            string result = string.Empty;
            if (enumPayroll == Enum.PayrollGroup.Permanent)
            {
                result = "Full Time";
            }
            else
            {
                result = "Part Time";
            }

            return result;
        }

    }
}
