using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Kanallı_Kedi_Sineklik
{
    internal class _27mm_Kanalli_Kedi_Sineklik_Ort : Sineklik
    {
        public DataTable Hesapla(double en, double boy)
        {
            double kanat = RunMath("27mm_kanalli_kedi_sineklik_ort_kanat", en, boy, GetZ(1, 54, 56, 58));
            double kanat2 = RunMath("27mm_kanalli_kedi_sineklik_ort_kanat", en, boy, GetZ(2, 54, 56, 58));
            double kanat3 = RunMath("27mm_kanalli_kedi_sineklik_ort_kanat", en, boy, GetZ(3, 54, 56, 58));

            double kasa = RunMath("27mm_kanalli_kedi_sineklik_ort_kasa", en, boy, GetZ(1, 53, 55, 57));
            double kasa2 = RunMath("27mm_kanalli_kedi_sineklik_ort_kasa", en, boy, GetZ(2, 53, 55, 57));
            double kasa3 = RunMath("27mm_kanalli_kedi_sineklik_ort_kasa_transfer", en, boy, GetZ(3, 53, 55, 57));
            
            double tul = RunMath("27mm_kanalli_kedi_sineklik_ort_tul", en, boy, DatabaseHelper.GetMalzeme(46).Price);
            double aks = RunMath("27mm_kanalli_kedi_sineklik_ort_aks", en, boy, DatabaseHelper.GetMalzeme(52).Price);
            double miknatis = RunMath("27mm_kanalli_kedi_sineklik_ort_miknatis", en, boy, DatabaseHelper.GetMalzeme(51).Price);
            double serit = RunMath("27mm_kanalli_kedi_sineklik_ort_serit_profil", en, boy, DatabaseHelper.GetMalzeme(49).Price);
            double sineklik_ip = RunMath("27mm_kanalli_kedi_sineklik_ort_sineklik_ipi", en, boy, DatabaseHelper.GetMalzeme(50).Price);
            double kus_gozu = RunMath("27mm_kanalli_kedi_sineklik_ort_kus_gozu", en, boy, DatabaseHelper.GetMalzeme(47).Price);

            double ral = kanat + kasa + tul + aks + miknatis + serit + sineklik_ip + kus_gozu;
            double eloksal = kanat2 + kasa2 + tul + aks + miknatis + serit + sineklik_ip + kus_gozu;
            double transfer = kanat3 + kasa3 + tul + aks + miknatis + serit + sineklik_ip + kus_gozu;

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
                    { ral.ToString("0.00"),eloksal.ToString("0.00"), transfer.ToString("0.00") }
                }
            };

        }
    }
}
