using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Sineklik_Kapi.Euro
{
    internal class _27mm_Yatay_Sineklik_Kapi_Euro : Sineklik
    {
        private List<double> price_data()
        {
           

            List<double> euro_prices = new List<double>() {
          DatabaseHelper.GetMalzeme(146).Price,
          DatabaseHelper.GetMalzeme(145).Price,
          DatabaseHelper.GetMalzeme(148).Price,
          DatabaseHelper.GetMalzeme(147).Price,
          DatabaseHelper.GetMalzeme(150).Price,
          DatabaseHelper.GetMalzeme(149).Price,
          DatabaseHelper.GetMalzeme(138).Price,
          DatabaseHelper.GetMalzeme(144).Price,
          DatabaseHelper.GetMalzeme(141).Price,
          DatabaseHelper.GetMalzeme(142).Price,
          DatabaseHelper.GetMalzeme(140).Price,
          DatabaseHelper.GetMalzeme(139).Price
      };

         


            return  euro_prices;
        }
        public DataTable Hesapla(double en, double boy)
        {
            List<double> prices = price_data();
            double beyaz = RunMath($"sk27mm_yatay_sineklik_kanat_fiyat", en, boy, prices[0]) +
                RunMath($"sk27mm_yatay_sineklik_kasa_fiyat", en, boy, prices[1]);

            double ral = RunMath($"sk27mm_yatay_sineklik_kanat_fiyat", en, boy, prices[2]) +
             RunMath($"sk27mm_yatay_sineklik_kasa_fiyat", en, boy, prices[3]);

            double adesen = RunMath($"sk27mm_yatay_sineklik_kanat_fiyat", en, boy, prices[4]) +
            RunMath($"sk27mm_yatay_sineklik_kasa_fiyat", en, boy, prices[5]);


            double diger = RunMath($"sk27mm_yatay_sineklik_tul_fiyat", en, boy, prices[6]) +
                RunMath($"sk27mm_yatay_sineklik_aks_set_fiyat", en, boy, prices[7]) +
                RunMath($"sk27mm_yatay_sineklik_serit_profil_fiyat", en, boy, prices[8]) +
                RunMath($"sk27mm_yatay_sineklik_sineklik_ipi_fiyat", en, boy, prices[9]) +
                RunMath($"sk27mm_yatay_sineklik_kil_fitil_fiyat", en, boy, prices[10]) +
                RunMath($"sk27mm_yatay_sineklik_kus_gozu_fiyat", en, boy, prices[11])
                ;
            
            return new DataTable
            {
                Columns =
                {
                    new DataColumn("Beyaz", typeof(string)),
                    new DataColumn("RAL", typeof(double)),
                    new DataColumn("A.Desen", typeof(double))
                },
                Rows =
                {
                    { beyaz + diger, ral + diger , adesen + diger }
                }
            };
        }

    }
}
