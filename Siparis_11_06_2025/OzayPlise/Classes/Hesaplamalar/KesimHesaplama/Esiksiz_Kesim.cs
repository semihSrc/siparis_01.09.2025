using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Esiksiz_Kesim : Sineklik
    {
        public string Name { get; set; } = "Eşiksiz Kesim";
        public string settings_name = "esiksiz_18mm_kesim_";
        public DataTable Hesapla(double en, double boy)
        {
            double dikey = RunMath("esiksiz_18mm_kesim_dikey", en, boy);
            double yatay = RunMath("esiksiz_18mm_kesim_yatay", en, boy);
            double kanat = RunMath("esiksiz_18mm_kesim_kanat", en, boy);
            double tul = RunMath("esiksiz_18mm_kesim_tul", en, boy);
            double tepe = RunMath("esiksiz_18mm_kesim_tepe", en, boy);
            double ip_olcu = RunMath("esiksiz_18mm_kesim_ip_olcu", en, boy);
            return new DataTable()
            {
                Columns =
                {
                    { "Dikey", typeof(double) },
                    { "Yatay", typeof(double) },
                    { "Kanat", typeof(double) },
                    { "Tul", typeof(double) },
                    { "Tepe", typeof(double) },
                    { "İp Ölçü", typeof(double) }
                },
                Rows =
                {
                    { dikey, yatay, kanat, tul, tepe, ip_olcu }
                }
            };
        }
    }
}
