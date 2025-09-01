using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Plise17x25Kesim : Sineklik
    {

        public string Name { get; set; } = "17x25 Plise Kesim";
        public string settings_name = "17x25_kesim_";
        public DataTable Hesapla(double en , double boy)
        {
            double dikey = RunMath("17x25_kesim_dikey",en,boy);
            double yatay = RunMath("17x25_kesim_yatay",en,boy);

            return new DataTable()
            {
                Columns =
                {
                    new DataColumn("Dikey", typeof(double)),
                    new DataColumn("Yatay", typeof(double))
                },
                Rows =
                {
                    { dikey, yatay }
                }
            };
        }
    }
}
