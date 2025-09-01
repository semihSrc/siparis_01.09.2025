using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.TypeOfSineklik.KesimHesaplama
{
    internal class Plise18mm : Sineklik
    {
        public string Name { get; set; } = "18mm Plise Kesim";
        public string settings_name = "18mm_plise_kesim_";

        public DataTable Hesapla(double en, double boy)
        {
            double dikey = RunMath("18mm_plise_kesim_dikey",en,boy),
                yatay = RunMath("18mm_plise_kesim_yatay", en, boy), 
                kanat = RunMath("18mm_plise_kesim_kanat", en, boy),
                tul = RunMath("18mm_plise_kesim_tul", en, boy),
                tepe = RunMath("18mm_plise_kesim_tepe", en, boy),
                ip_olcu = RunMath("18mm_plise_kesim_ip", en, boy) ;

            return new DataTable
            {
                Columns =
                {
                    new DataColumn("Dikey", typeof(double)),
                    new DataColumn("Yatay", typeof(double)),
                    new DataColumn("Kanat", typeof(double)),
                    new DataColumn("Tul", typeof(double)),
                    new DataColumn("Tepe", typeof(double)),
                    new DataColumn("İp Ölçü", typeof(double))
                },
                Rows =
                {
                    { dikey, yatay, kanat, tul, tepe, ip_olcu }
                }
            };
        }
    }
}
