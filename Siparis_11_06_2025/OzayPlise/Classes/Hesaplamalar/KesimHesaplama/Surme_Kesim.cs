using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Surme_Kesim : Sineklik
    {
        public string Name { get; set; } = "Sürme Kesim";
        public string settings_name = "sk_surme_kesim_";
        public DataTable Hesapla(double en , double boy)
        {
            double dikey = RunMath("sk_surme_kesim_dikey", en , boy);
            double yatay = RunMath("sk_surme_kesim_yatay", en, boy);
            double kanat_profil = RunMath("sk_surme_kesim_kanat", en, boy);

            return new DataTable()
            {
                Columns =
                {
                    { "Dikey Kasa", typeof(double) },
                    { "Yatay Kasa", typeof(double) },
                    { "Kanat Profil", typeof(double) },
                },
                Rows =
                {
                    { dikey, yatay, kanat_profil }
                }
            };
        }
    }
}
