using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama._18mm_Karavan_Perde
{
    internal class _18mm_Karavan_Perde_Ort : Sineklik
    {
        public DataTable Hesapla(double en, double boy)
        {
            double kanat = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kanat_fiyat", en, boy, GetZ(1, 94, 96, 98));
            double kanat2 = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kanat_fiyat", en, boy, GetZ(2, 94, 96, 98));
            double kanat3 = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kanat_fiyat", en, boy, GetZ(3, 94, 96, 98));

            double kasa = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kasa_fiyat", en, boy, GetZ(1, 93, 95, 97));
            double kasa2 = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kasa_fiyat", en, boy, GetZ(2, 93, 95, 97));
            double kasa3 = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kasa_fiyat_adesen", en, boy, GetZ(3, 93, 95, 97));

            double tul = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_tul_fiyat", en, boy, DatabaseHelper.GetMalzeme(85).Price);
            double aks = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_aks_set_fiyat", en, boy, DatabaseHelper.GetMalzeme(92).Price);
            double miknatis = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_miknatis_fiyat", en, boy, DatabaseHelper.GetMalzeme(91).Price);
            double serit = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_serit_profil_fiyat", en, boy, DatabaseHelper.GetMalzeme(89).Price);
            double sineklik_ip = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_sineklik_ipi_fiyat", en, boy, DatabaseHelper.GetMalzeme(90).Price);
            double kus_gozu = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kus_gozu_fiyat", en, boy, DatabaseHelper.GetMalzeme(87).Price);
            double kumas = RunMath("karavan_18mm_oval_ort_birlesim_sineklik_kumas_fiyat", en, boy, DatabaseHelper.GetMalzeme(86).Price);

            double ral = kanat + kasa + tul + aks + serit + sineklik_ip + miknatis + kus_gozu + kumas;
            double eloksal = kanat2 + kasa2 + tul + aks + serit + sineklik_ip + miknatis + kus_gozu + kumas;
            double transfer = kanat3 + kasa3 + tul + aks + serit + sineklik_ip + miknatis + kus_gozu + kumas;

            return new DataTable
            {
                Columns =
           {
               new DataColumn("RAL", typeof(double)),
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
