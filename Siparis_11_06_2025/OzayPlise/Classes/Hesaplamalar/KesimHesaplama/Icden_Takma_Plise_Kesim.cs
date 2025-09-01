using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Icden_Takma_Plise_Kesim: Sineklik
    {
        public string Name { get; set; } = "İçten Takma Plise Kesim";
        public string settings_name = "icten_takma_kesim_";
        public DataTable Hesapla(double en , double boy)
        {
            double dikey = RunMath("icten_takma_kesim_dikey", en, boy);
            double yatay = RunMath("icten_takma_kesim_yatay", en, boy);
            double kanat = RunMath("icten_takma_kesim_kanat", en, boy);
            double tul = RunMath("icten_takma_kesim_tul", en, boy);
            double tepe = RunMath("icten_takma_kesim_tepe", en, boy);
            double ip = RunMath("icten_takma_kesim_ip", en, boy);

            return new DataTable
            {
                Columns =
                {
                    { "Dikey", typeof(double) },
                    { "Yatay", typeof(double) },
                    { "Kanat", typeof(double) },
                    { "Tul", typeof(double) },
                    { "Tepe", typeof(double) },
                    { "Ip", typeof(double) }
                },
                Rows =
                {
                    { dikey, yatay, kanat, tul, tepe, ip }
                }
            };
        }
    }
}
