using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Sineklik_Kapi.Dolar
{
    internal class _27mm_Dikey_Sineklik_Kapi_Dolar : Sineklik
    {

        private List<double> price_data()
        {
           

            List<double> dolar_prices = new List<double>() {
          DatabaseHelper.GetMalzeme(159).Price,
          DatabaseHelper.GetMalzeme(158).Price,
          DatabaseHelper.GetMalzeme(161).Price,
          DatabaseHelper.GetMalzeme(160).Price,
          DatabaseHelper.GetMalzeme(163).Price,
          DatabaseHelper.GetMalzeme(162).Price,
          DatabaseHelper.GetMalzeme(151).Price,
          DatabaseHelper.GetMalzeme(157).Price,
          DatabaseHelper.GetMalzeme(154).Price,
          DatabaseHelper.GetMalzeme(155).Price,
          DatabaseHelper.GetMalzeme(153).Price,
          DatabaseHelper.GetMalzeme(152).Price
      };


            return dolar_prices;
        }
        public DataTable Hesapla(double en, double boy)
        {
            List<double> prices = price_data();
            double beyaz = RunMath($"sk27mm_dikey_sineklik_kanat_fiyat", en, boy, prices[0]) +
                RunMath($"sk27mm_dikey_sineklik_kasa_fiyat", en, boy, prices[1]);

           double ral = RunMath($"sk27mm_dikey_sineklik_kanat_fiyat", en, boy, prices[2]) +
            RunMath($"sk27mm_dikey_sineklik_kasa_fiyat", en, boy, prices[3]);

            double adesen = RunMath($"sk27mm_dikey_sineklik_kanat_fiyat", en, boy, prices[4]) +
            RunMath($"sk27mm_dikey_sineklik_kasa_fiyat", en, boy, prices[5]);


            double diger = RunMath($"sk27mm_dikey_sineklik_tul_fiyat", en, boy, prices[6]) +
                RunMath($"sk27mm_dikey_sineklik_aks_set_fiyat", en, boy, prices[7]) +
                RunMath($"sk27mm_dikey_sineklik_serit_profil_fiyat", en, boy, prices[8]) +
                RunMath($"sk27mm_dikey_sineklik_sineklik_ipi_fiyat", en, boy, prices[9]) +
                RunMath($"sk27mm_dikey_sineklik_kil_fitil_fiyat", en, boy, prices[10]) +
                RunMath($"sk27mm_dikey_sineklik_kus_gozu_fiyat", en, boy, prices[11])
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
