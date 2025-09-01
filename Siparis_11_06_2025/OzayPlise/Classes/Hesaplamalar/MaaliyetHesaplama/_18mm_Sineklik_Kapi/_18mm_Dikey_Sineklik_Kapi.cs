using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._18mm_Sineklik_Kapi
{
    internal class _18mm_Dikey_Sineklik_Kapi : Sineklik
    {
        private List<double> price_data()
        {
            List<double> tl_prices = new List<double>() {
                DatabaseHelper.GetMalzeme(9).Price,
                DatabaseHelper.GetMalzeme(8).Price,
                DatabaseHelper.GetMalzeme(11).Price,
                DatabaseHelper.GetMalzeme(10).Price,
                DatabaseHelper.GetMalzeme(13).Price,
                DatabaseHelper.GetMalzeme(12).Price,
                DatabaseHelper.GetMalzeme(1).Price,
                DatabaseHelper.GetMalzeme(7).Price,
                DatabaseHelper.GetMalzeme(4).Price,
                DatabaseHelper.GetMalzeme(5).Price,
                DatabaseHelper.GetMalzeme(3).Price,
                DatabaseHelper.GetMalzeme(2).Price
            };

           return tl_prices;
        }
        public DataTable Hesapla(double en, double boy )
        {
            List<double> prices = price_data();
            double kanatBeyazFiyat = RunMath($"sk18mm_dikey_sineklik_kanat_fiyat", en, boy, prices[0]);
            double kasaBeyazFiyat = RunMath($"sk18mm_dikey_sineklik_kasa_fiyat", en, boy, prices[1]);
            double beyaz = kanatBeyazFiyat + kasaBeyazFiyat;

            double kanatRalFiyat = RunMath($"sk18mm_dikey_sineklik_kanat_fiyat", en, boy, prices[2]);
            double kasaRalFiyat = RunMath($"sk18mm_dikey_sineklik_kasa_fiyat", en, boy, prices[3]);
            double ral = kanatRalFiyat + kasaRalFiyat;

            double kanatAdesenFiyat = RunMath($"sk18mm_dikey_sineklik_kanat_fiyat", en, boy, prices[4]);
            double kasaAdesenFiyat = RunMath($"sk18mm_dikey_sineklik_kasa_fiyat", en, boy, prices[5]);
            double adesen = kanatAdesenFiyat + kasaAdesenFiyat;

            double tulFiyat = RunMath($"sk18mm_dikey_sineklik_tul_fiyat", en, boy, prices[6]);
            double aksSetFiyat = RunMath($"sk18mm_dikey_sineklik_aks_set_fiyat", en, boy, prices[7]);
            double seritProfilFiyat = RunMath($"sk18mm_dikey_sineklik_serit_profil_fiyat", en, boy, prices[8]);
            double sineklikIpiFiyat = RunMath($"sk18mm_dikey_sineklik_sineklik_ipi_fiyat", en, boy, prices[9]);
            double kilFitilFiyat = RunMath($"sk18mm_dikey_sineklik_kil_fitil_fiyat", en, boy, prices[10]);
            double kusGozuFiyat = RunMath($"sk18mm_dikey_sineklik_kus_gozu_fiyat", en, boy, prices[11]);
            double diger = tulFiyat + aksSetFiyat + seritProfilFiyat + sineklikIpiFiyat + kilFitilFiyat + kusGozuFiyat;

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
