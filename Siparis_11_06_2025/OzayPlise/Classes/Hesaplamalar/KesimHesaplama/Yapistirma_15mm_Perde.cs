using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.KesimHesaplama
{
    internal class Yapistirma_15mm_Perde : Sineklik
    {
        public string Name { get; set; } = "15mm Yapıştırma Perde";
        public string settings_name = "yp_yapistirma_15mm_perde_";
        public DataTable Hesapla(double en, double boy)
        {
            double yatay = RunMath("yp_yapistirma_15mm_perde_yatay", en, boy);
            double tepe = RunMath("yp_yapistirma_15mm_perde_tepe", en, boy);
            double ip_olcu = RunMath("yp_yapistirma_15mm_perde_ip_olcu", en, boy);

            return new DataTable()
            {
                Columns =
                {
                    { "Yatay Kasa", typeof(double) },
                    { "Tepe", typeof(double) },
                    { "İp Ölçü", typeof(double) },
                },
                Rows =
                {
                    { yatay,tepe, ip_olcu }
                }
            };
        }
    }
}
