using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Plise27mm : Sineklik
    {
        public string Name { get; set; } = "27mm Plise Kesim";
        public string settings_name = "27mm_plise_kesim_";
        public DataTable Hesapla(double en, double boy)
        {
            double dikey = RunMath("27mm_plise_kesim_dikey", en, boy),
                yatay =  RunMath("27mm_plise_kesim_yatay", en, boy),
                kanat =  RunMath("27mm_plise_kesim_kanat", en, boy),
                tul =  RunMath("27mm_plise_kesim_tul", en, boy),
                tepe =   RunMath("27mm_plise_kesim_tepe", en, boy),
                ip_olcu =  RunMath("27mm_plise_kesim_ip", en, boy);

            return new DataTable
            {
                Columns =
                {
                    new DataColumn("Dikey", typeof(double)),
                    new DataColumn("Yatay", typeof(double)),
                    new DataColumn("Kanat", typeof(double)),
                    new DataColumn("Tul", typeof(double)),
                    new DataColumn("Tepe", typeof(double)),
                    new DataColumn("İp Ölçüsü", typeof(double))
                },
                Rows =
                {
                    { dikey, yatay, kanat, tul, tepe, ip_olcu }
                }
            };
        }
    }
}
