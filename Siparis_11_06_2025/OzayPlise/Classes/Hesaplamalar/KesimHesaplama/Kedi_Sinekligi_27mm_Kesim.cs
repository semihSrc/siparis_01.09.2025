using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Kedi_Sinekligi_27mm_Kesim : Sineklik
    {
        public string Name { get; set; } = "Kedi Sinekliği 27mm Kesim";
        public string settings_name = "kedisinekligi_27mm_kesim_";
        public DataTable Hesapla(double en, double boy)
        {
            double dikey = RunMath("kedisinekligi_27mm_kesim_dikey", en, boy);
            double yatay = RunMath("kedisinekligi_27mm_kesim_yatay", en, boy);
            double kanat = RunMath("kedisinekligi_27mm_kesim_kanat", en, boy);
            double tul = RunMath("kedisinekligi_27mm_kesim_tul", en, boy);
            double tepe = RunMath("kedisinekligi_27mm_kesim_tepe", en, boy);
            double ip_olcu = RunMath("kedisinekligi_27mm_kesim_ip_olcu", en, boy);
            return new DataTable()
            {
                Columns =
         {
             {"Dikey", typeof(double)},
             {"Yatay", typeof(double)},
             {"Kanat", typeof(double)},
             {"Tul", typeof(double)},
             {"Tepe", typeof(double)},
             {"İp Ölçü", typeof(double)}
         },
                Rows =
         {
             {dikey, yatay, kanat, tul, tepe, ip_olcu}
         }
            };
        }
    }
}
