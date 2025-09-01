using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama
{
    internal class SurmeMaaliyet : Sineklik
    {
        public string product_type = "surme_maaliyet";
        public string Name { get; set; } = "Sürme Maaliyet Hesaplama";
        public string settings_name = "surme_maaliyet_";
        public DataTable Hesapla(double en , double boy)
        {
            double kasa_birim = RunMath("surme_maaliyet_kasa_birim", en, boy);
            double kasa_fiyat = RunMath("surme_maaliyet_kasa_fiyat", en, boy, DatabaseHelper.GetMalzeme(59).Price);
            double kasa_ral = RunMath("surme_maaliyet_kasa_ral", en, boy, DatabaseHelper.GetMalzeme(59).Price);

            double kanat_birim = RunMath("surme_maaliyet_kanat_birim", en, boy);
            double kanat_fiyat = RunMath("surme_maaliyet_kanat_fiyat", en, boy, DatabaseHelper.GetMalzeme(60).Price);
            double kanat_ral = RunMath("surme_maaliyet_kanat_ral", en, boy, DatabaseHelper.GetMalzeme(60).Price);

            double cift_birim = RunMath("surme_maaliyet_cift_tirnak_kasa_birim", en, boy);
            double cift_fiyat = RunMath("surme_maaliyet_cift_tirnak_kasa_fiyat", en, boy, DatabaseHelper.GetMalzeme(59).Price);
            //double cift_ral = RunMath("surme_maaliyet_cift_tirnak_kasa_ral", en, boy, DatabaseHelper.GetMalzeme().Price);

            double duz_birim = RunMath("surme_maaliyet_duz_birim", en, boy);
            //double duz_fiyat = RunMath("surme_maaliyet_duz_fiyat", en, boy, DatabaseHelper.GetMalzeme().Price);
           // double duz_ral = RunMath("surme_maaliyet_duz_ral", en, boy, DatabaseHelper.GetMalzeme().Price);

            double kedi_birim = RunMath("surme_maaliyet_kedi_birim", en, boy);
            double kedi_fiyat = RunMath("surme_maaliyet_kedi_fiyat", en, boy, DatabaseHelper.GetMalzeme(62).Price);
            //double kedi_ral = RunMath("surme_maaliyet_kedi_ral", en, boy, DatabaseHelper.GetMalzeme().Price);

            double kil_birim = RunMath("surme_maaliyet_kil_birim", en, boy);
            double kil_fiyat = RunMath("surme_maaliyet_kil_fiyat", en, boy, DatabaseHelper.GetMalzeme(63).Price);
           // double kil_ral = RunMath("surme_maaliyet_kil_ral", en, boy, DatabaseHelper.GetMalzeme().Price);

            double aksesuar_birim = RunMath("surme_maaliyet_aksesuar_birim", en, boy, DatabaseHelper.GetMalzeme(64).Price);
           // double aksesuar_fiyat = RunMath("surme_maaliyet_aksesuar_fiyat", en, boy, DatabaseHelper.GetMalzeme().Price);
           // double aksesuar_ral = RunMath("surme_maaliyet_aksesuar_ral", en, boy, DatabaseHelper.GetMalzeme().Price);

            double tek_kanat_fiyat = kasa_fiyat + kanat_fiyat + kedi_fiyat + kil_fiyat + aksesuar_birim + 14.16;
            double cift_kanat_fiyat =  (kanat_fiyat * 2) + cift_fiyat + (kedi_fiyat * 2) + kil_fiyat + (aksesuar_birim * 2) + 60;

            double tek_kanat_ral = tek_kanat_fiyat * 80 / 100 + tek_kanat_fiyat;
            double cift_kanat_ral = cift_kanat_fiyat * 80 / 100 + cift_kanat_fiyat;

            return new DataTable
            {
                Columns =
                {
                    new DataColumn("Malzeme", typeof(string)),
                    new DataColumn("Birim", typeof(string)),
                    new DataColumn("Fiyat", typeof(double)),
                    new DataColumn("RAL", typeof(double))
                },
                Rows =
                {
                    { "Kasa", kasa_birim.ToString("0.00"), kasa_fiyat.ToString("0.00") , kasa_ral.ToString("0.00")},
                    { "Kanat", kanat_birim.ToString("0.00"), kanat_fiyat.ToString("0.00"), kanat_ral.ToString("0.00") },
                    { "Çift Tırnak Kasa", cift_birim.ToString("0.00"), cift_fiyat.ToString("0.00"), 0.ToString("0.00") },
                    { "Düz Kasa", duz_birim.ToString("0.00"), 0.ToString("0.00"),0.ToString("0.00") },
                    { "Kedi", kedi_birim.ToString("0.00"), kedi_fiyat.ToString("0.00"),0.ToString("0.00") },
                    { "Kil Fitil", kil_birim.ToString("0.00"), kil_fiyat.ToString("0.00") ,0.ToString("0.00")},
                    { "Aksesuar", aksesuar_birim.ToString("0.00"), aksesuar_birim.ToString("0.00"),aksesuar_birim.ToString("0.00") },
                    { "Tek Kanat Fiyatı"," ", tek_kanat_fiyat.ToString("0.00"), tek_kanat_ral.ToString("0.00") },
                    { "Çift Kanat Fiyatı"," ", cift_kanat_fiyat.ToString("0.00"), cift_kanat_ral.ToString("0.00") }
                }
            };
        }
    }
}
