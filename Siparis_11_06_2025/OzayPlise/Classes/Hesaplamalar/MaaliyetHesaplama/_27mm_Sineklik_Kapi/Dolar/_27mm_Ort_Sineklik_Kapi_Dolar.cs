using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Sineklik_Kapi.Dolar
{
    internal class _27mm_Ort_Sineklik_Kapi_Dolar : Sineklik
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
     DatabaseHelper.GetMalzeme(156).Price,
     DatabaseHelper.GetMalzeme(152).Price
 };


            return dolar_prices;
        }
        public DataTable Hesapla(double en, double boy)
        {
            List<double> prices = price_data();
            double kanatBeyazFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_kanat_fiyat", en, boy, prices[0]);
            double kasaBeyazFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_kasa_fiyat", en, boy, prices[1]);
            double beyaz = kanatBeyazFiyat + kasaBeyazFiyat;

            double kanatRalFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_kanat_fiyat", en, boy, prices[2]);
            double kasaRalFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_kasa_fiyat", en, boy, prices[3]);
            double ral = kanatRalFiyat + kasaRalFiyat;

            double kanatAdesenFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_kanat_fiyat", en, boy, prices[4]);
            double kasaAdesenFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_kasa_fiyat_ahsap", en, boy, prices[5]);
            double adesen = kanatAdesenFiyat + kasaAdesenFiyat;

            double tulFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_tul_fiyat", en, boy, prices[6]);
            double aksSetFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_aks_set_fiyat", en, boy, prices[7]);
            double seritProfilFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_serit_profil_fiyat", en, boy, prices[8]);
            double sineklikIpiFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_sineklik_ipi_fiyat", en, boy, prices[9]);
            double miknatisFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_miknatis_fiyat", en, boy, prices[10]);
            double kusGozuFiyat = RunMath($"sk27mm_ort_birlesim_sineklik_kus_gozu_fiyat", en, boy, prices[11]);
            double diger = tulFiyat + aksSetFiyat + seritProfilFiyat + sineklikIpiFiyat + miknatisFiyat + kusGozuFiyat;

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
                    { (beyaz + diger).ToString("0.00"), (ral + diger).ToString("0.00") , (adesen + diger).ToString("0.00") }
                }
            };
        }

    }
}
