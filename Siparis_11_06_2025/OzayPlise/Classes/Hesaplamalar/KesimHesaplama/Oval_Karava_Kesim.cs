using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Oval_Karava_Kesim : Sineklik
    {
        public string Name { get; set; } = "Oval Karava Kesim";
        public string settings_name = "oval_kesim_";
        public DataTable Hesapla(double en, double boy)
        {
            double dikey = RunMath("oval_kesim_dikey", en, boy);
            double yatay = RunMath("oval_kesim_yatay", en, boy);
            double kanat = RunMath("oval_kesim_kanat", en, boy);
            double tul = RunMath("oval_kesim_tul", en, boy);
            double tepe = RunMath("oval_kesim_tepe", en, boy);

            return new DataTable()
            {
                Columns =
                {
                    { "Dikey", typeof(double) },
                    { "Yatay", typeof(double) },
                    { "Kanat", typeof(double) },
                    { "Tul", typeof(double) },
                    { "Tepe", typeof(double) }
                },
                Rows =
                {
                    { dikey, yatay, kanat, tul, tepe }
                }
            };
        }
    }
}
