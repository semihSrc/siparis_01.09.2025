using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzayPlise.Classes.TypeOfSineklik.PerdeMaaliyetHesaplama
{
    internal class PerdeMaaliyetHesaplama : Sineklik
    {
        public string product_type = "Perde";
        public string Name { get; set; } = "Perde Maaliyet Hesaplama";

        public string settings_name = "pm_perde_maaliyet";
        public DataTable Hesapla(double en, double boy)
        {
            double kumas = RunMath("pm_perde_maaliyet_kumas", en, boy, DatabaseHelper.GetMalzeme(27).Price);
            double profil = RunMath("pm_perde_maaliyet_profil", en, boy, DatabaseHelper.GetMalzeme(28).Price);
            double aksesuar = RunMath("pm_perde_maaliyet_aksesuar", en, boy, DatabaseHelper.GetMalzeme(32).Price);
            double serit = RunMath("pm_perde_maaliyet_serit", en, boy, DatabaseHelper.GetMalzeme(30).Price);
            double ip = RunMath("pm_perde_maaliyet_ip", en, boy, DatabaseHelper.GetMalzeme(31).Price);
            double kus_gozu = RunMath("pm_perde_maaliyet_kus", en, boy, DatabaseHelper.GetMalzeme(29).Price);


            double kumas_birim = RunMath("pm_perde_maaliyet_kumas_birim", en, boy, 1);
            double profil_birim = RunMath("pm_perde_maaliyet_profil_birim", en, boy, 1);
            double aksesuar_birim = RunMath("pm_perde_maaliyet_aksesuar_birim", en, boy, 1);
            double serit_birim = RunMath("pm_perde_maaliyet_serit_birim", en, boy, 1);
            double ip_birim = RunMath("pm_perde_maaliyet_ip_birim", en, boy, 1);
            double kus_gozu_birim = RunMath("pm_perde_maaliyet_kus_birim", en, boy, 1);

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
                        kumas.ToString("0.00"),
                        profil_birim.ToString("0.00"),
                        profil.ToString("0.00"),
                        aksesuar_birim.ToString("0.00"),
                        aksesuar.ToString("0.00"),
                        serit_birim.ToString("0.00"),
                        serit.ToString("0.00"),
                        ip_birim.ToString("0.00"),
                        ip.ToString("0.00"),
                        kus_gozu_birim.ToString("0.00"),
                        kus_gozu.ToString("0.00"),
                        (kumas + profil + aksesuar + serit + ip + kus_gozu).ToString("0.00")
                    }
                }
            };
        }
    }
}
