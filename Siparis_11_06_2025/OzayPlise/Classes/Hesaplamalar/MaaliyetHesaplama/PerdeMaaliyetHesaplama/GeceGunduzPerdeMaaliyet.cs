using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama
{
    internal class GeceGunduzPerdeMaaliyet:Sineklik
    {
        public string product_type = "GGPerde";
        public string Name { get; set; } = "Gece Gündüz Perde Maaliyet Hesaplama";

        public string settings_name = "gece_gunduz_perde";
        public DataTable Hesapla(double en, double boy)
        {
            double kumas_birim = RunMath("gece_gunduz_perde_kumas_birim", en, boy, DatabaseHelper.GetMalzeme(65).Price);
            double kumas_fiyat = RunMath("gece_gunduz_perde_kumas_fiyat", en, boy, DatabaseHelper.GetMalzeme(65).Price);
            
            double profil_birim = RunMath("gece_gunduz_perde_profil_birim", en, boy, DatabaseHelper.GetMalzeme(66).Price);
            double profil_fiyat = RunMath("gece_gunduz_perde_profil_fiyat", en, boy, DatabaseHelper.GetMalzeme(66).Price);
            
            double aksesuar_birim = RunMath("gece_gunduz_perde_aks_birim", en, boy, DatabaseHelper.GetMalzeme(70).Price);
            double aksesuar_fiyat = RunMath("gece_gunduz_perde_aks_fiyat", en, boy, DatabaseHelper.GetMalzeme(70).Price);
            
            double serit_birim = RunMath("gece_gunduz_perde_serit_birim", en, boy, DatabaseHelper.GetMalzeme(68).Price);
            double serit_fiyat = RunMath("gece_gunduz_perde_serit_fiyat", en, boy, DatabaseHelper.GetMalzeme(68).Price);
            
            double ip_birim = RunMath("gece_gunduz_perde_ip_birim", en, boy, DatabaseHelper.GetMalzeme(69).Price);
            double ip_fiyat = RunMath("gece_gunduz_perde_ip_fiyat", en, boy, DatabaseHelper.GetMalzeme(69).Price);
            
            double kus_gozu_birim = RunMath("gece_gunduz_perde_kus_birim", en, boy, DatabaseHelper.GetMalzeme(67).Price);
            double kus_gozu_fiyat = RunMath("gece_gunduz_perde_kus_fiyat", en, boy, DatabaseHelper.GetMalzeme(67).Price);

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
