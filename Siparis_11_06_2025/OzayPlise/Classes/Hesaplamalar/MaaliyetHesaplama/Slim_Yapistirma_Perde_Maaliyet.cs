using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama
{
    internal class Slim_Yapistirma_Perde_Maaliyet : Sineklik
    {
        public string product_type = "slim_yapistirma";
        public string Name { get; set; } = "Slim Yapıştırma Perde Maaliyet Hesaplama";

        public string settings_name = "slim_yapistirma_perde_maaliyet_";
        public DataTable Hesapla(double en, double boy)
        {
            double kumas_birim = RunMath("slim_yapistirma_perde_maaliyet_kumas_birim", en, boy, DatabaseHelper.GetMalzeme(194).Price);
            double kumas_fiyat = RunMath("slim_yapistirma_perde_maaliyet_kumas_fiyat", en, boy, DatabaseHelper.GetMalzeme(194).Price);

            double profil_birim = RunMath("slim_yapistirma_perde_maaliyet_profil_birim", en, boy, DatabaseHelper.GetMalzeme(195).Price);
            double profil_fiyat = RunMath("slim_yapistirma_perde_maaliyet_profil_fiyat", en, boy, DatabaseHelper.GetMalzeme(195).Price);

            double aksesuar_birim = RunMath("slim_yapistirma_perde_maaliyet_aks_birim", en, boy, DatabaseHelper.GetMalzeme(199).Price);
            double aksesuar_fiyat = RunMath("slim_yapistirma_perde_maaliyet_aks_fiyat", en, boy, DatabaseHelper.GetMalzeme(199).Price);

            double serit_birim = RunMath("slim_yapistirma_perde_maaliyet_serit_birim", en, boy, DatabaseHelper.GetMalzeme(197).Price);
            double serit_fiyat = RunMath("slim_yapistirma_perde_maaliyet_serit_fiyat", en, boy, DatabaseHelper.GetMalzeme(197).Price);

            double ip_birim = RunMath("slim_yapistirma_perde_maaliyet_ip_birim", en, boy, DatabaseHelper.GetMalzeme(198).Price);
            double ip_fiyat = RunMath("slim_yapistirma_perde_maaliyet_ip_fiyat", en, boy, DatabaseHelper.GetMalzeme(198).Price);

            double kus_gozu_birim = RunMath("slim_yapistirma_perde_maaliyet_kus_birim", en, boy, DatabaseHelper.GetMalzeme(196).Price);
            double kus_gozu_fiyat = RunMath("slim_yapistirma_perde_maaliyet_kus_fiyat", en, boy, DatabaseHelper.GetMalzeme(196).Price);

            double toplam = kumas_fiyat + profil_fiyat + aksesuar_fiyat + serit_fiyat + ip_fiyat + kus_gozu_fiyat;


            return new DataTable
            {
                Columns =
                {
                    new DataColumn("Kumaş Birim"),
                    new DataColumn("Kumaş Fiyat"),
                    new DataColumn("Profil Birim"),
                    new DataColumn("Profil Fiyat"),
                    new DataColumn("Aksesuar Birim"),
                    new DataColumn("Aksesuar Fiyat"),
                    new DataColumn("Şerit Birim"),
                    new DataColumn("Şerit Fiyat"),
                    new DataColumn("İp Birim"),
                    new DataColumn("İp Fiyat"),
                    new DataColumn("Kuş Gözü Birim"),
                    new DataColumn("Kuş Gözü Fiyat"),
                    new DataColumn("Toplam Fiyat"),
                }
                ,
                Rows =
                {
                    new object[]
                    {
                        kumas_birim.ToString("0.00"),
                        kumas_fiyat.ToString("0.00"),
                        profil_birim.ToString("0.00"),
                        profil_fiyat.ToString("0.00"),
                        aksesuar_birim.ToString("0.00"),
                        aksesuar_fiyat.ToString("0.00"),
                        serit_birim.ToString("0.00"),
                        serit_fiyat.ToString("0.00"),
                        ip_birim.ToString("0.00"),
                        ip_fiyat.ToString("0.00"),
                        kus_gozu_birim.ToString("0.00"),
                        kus_gozu_fiyat.ToString("0.00"),
                        toplam.ToString("0.00")
                    }
                }
            };
        }
    }
}
