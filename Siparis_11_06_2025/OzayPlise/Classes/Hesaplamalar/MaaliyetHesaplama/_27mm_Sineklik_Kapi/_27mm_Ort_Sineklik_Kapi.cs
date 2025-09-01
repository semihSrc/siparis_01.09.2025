using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Sineklik_Kapi
{
    internal class _27mm_Ort_Sineklik_Kapi : Sineklik
    {
        private List<double> price_data(short type)
        {
            List<double> tl_prices = new List<double>() {
     DatabaseHelper.GetMalzeme(22).Price,
          DatabaseHelper.GetMalzeme(21).Price,
          DatabaseHelper.GetMalzeme(24).Price,
          DatabaseHelper.GetMalzeme(23).Price,
          DatabaseHelper.GetMalzeme(26).Price,
          DatabaseHelper.GetMalzeme(25).Price,
          DatabaseHelper.GetMalzeme(14).Price,
          DatabaseHelper.GetMalzeme(20).Price,
          DatabaseHelper.GetMalzeme(17).Price,
          DatabaseHelper.GetMalzeme(18).Price,
          DatabaseHelper.GetMalzeme(19).Price,
          DatabaseHelper.GetMalzeme(15).Price
 };

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
     DatabaseHelper.GetMalzeme(143).Price,
     DatabaseHelper.GetMalzeme(139).Price
 };

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


            return (type == 1) ? tl_prices : (type == 2) ? dolar_prices : euro_prices;
        }
        public DataTable Hesapla(double en, double boy, short type = 1)
        {
            List<double> prices = price_data(type);
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
