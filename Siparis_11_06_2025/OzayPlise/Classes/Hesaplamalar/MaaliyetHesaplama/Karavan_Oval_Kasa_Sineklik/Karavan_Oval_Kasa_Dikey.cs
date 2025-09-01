using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama.Karavan_Oval_Kasa_Sineklik
{
    internal class Karavan_Oval_Kasa_Dikey : Sineklik
    {
        public DataTable Hesapla(double en, double boy)
        {
            double kanat = RunMath("karavan_oval_dikey_sineklik_kanat_fiyat", en, boy, GetZ(1, 80, 82, 84));
            double kanat2 = RunMath("karavan_oval_dikey_sineklik_kanat_fiyat", en, boy, GetZ(2, 80, 82, 84));
            double kanat3 = RunMath("karavan_oval_dikey_sineklik_kanat_fiyat", en, boy, GetZ(3, 80, 82, 84));
            double kasa = RunMath("karavan_oval_dikey_sineklik_kasa_fiyat", en, boy, GetZ(1, 79, 81, 83));
            double kasa2 = RunMath("karavan_oval_dikey_sineklik_kasa_fiyat", en, boy, GetZ(2, 79, 81, 83));
            double kasa3 = RunMath("karavan_oval_dikey_sineklik_kasa_fiyat", en, boy, GetZ(3, 79, 81, 83));
            double tul = RunMath("karavan_oval_dikey_sineklik_tul_fiyat", en, boy, DatabaseHelper.GetMalzeme(71).Price);
            double aks = RunMath("karavan_oval_dikey_sineklik_aks_set_fiyat", en, boy, DatabaseHelper.GetMalzeme(78).Price);
            double serit = RunMath("karavan_oval_dikey_sineklik_serit_profil_fiyat", en, boy, DatabaseHelper.GetMalzeme(75).Price);
            double sineklik_ip = RunMath("karavan_oval_dikey_sineklik_sineklik_ipi_fiyat", en, boy, DatabaseHelper.GetMalzeme(76).Price);
            double kil_fitil = RunMath("karavan_oval_dikey_sineklik_kil_fitil_fiyat", en, boy, DatabaseHelper.GetMalzeme(74).Price);
            double kus_gozu = RunMath("karavan_oval_dikey_sineklik_kus_gozu_fiyat", en, boy, DatabaseHelper.GetMalzeme(73).Price);

            double ral = kanat + kasa + tul + aks + serit + sineklik_ip + kil_fitil + kus_gozu;
            double eloksal = kanat2 + kasa2 + tul + aks + serit + sineklik_ip + kil_fitil + kus_gozu;
            double transfer = kanat3 + kasa3 + tul + aks + serit + sineklik_ip + kil_fitil + kus_gozu;

            return new DataTable
            {
                Columns =
                {
                    new DataColumn("RAL", typeof(string)),
                    new DataColumn("Eloksal", typeof(double)),
                    new DataColumn("Transfer", typeof(double))
                },
                Rows =
                {
                    { ral.ToString("0.00"),eloksal.ToString("0.00"),transfer.ToString("0.00") }
                }
            };
        }
    }
}
