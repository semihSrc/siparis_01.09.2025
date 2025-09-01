using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._18mm_Icten_Takma
{
    internal class _18mm_Icten_Takma_Dikey : Sineklik
    {
        public DataTable Hesapla(double en, double boy)
        {
            double beyaz_kanat = RunMath($"icten_takma_18mm_dikey_kanat", en, boy, DatabaseHelper.GetMalzeme(107).Price);
            double beyaz_kasa = RunMath($"icten_takma_18mm_dikey_kasa", en, boy, DatabaseHelper.GetMalzeme(106).Price);
            double beyaz = beyaz_kanat + beyaz_kasa;

            double ral_kanat = RunMath($"icten_takma_18mm_dikey_kanat", en, boy, DatabaseHelper.GetMalzeme(109).Price);
            double ral_kasa = RunMath($"icten_takma_18mm_dikey_kasa", en, boy, DatabaseHelper.GetMalzeme(108).Price);
            double ral = ral_kanat + ral_kasa;

            double adesen_kanat = RunMath($"icten_takma_18mm_dikey_kanat", en, boy, DatabaseHelper.GetMalzeme(111).Price);
            double adesen_kasa = RunMath($"icten_takma_18mm_dikey_kasa", en, boy, DatabaseHelper.GetMalzeme(110).Price);
            double adesen = adesen_kanat + adesen_kasa;

            double tul = RunMath($"icten_takma_18mm_dikey_tul", en, boy, DatabaseHelper.GetMalzeme(99).Price);
            double aks = RunMath($"icten_takma_18mm_dikey_aks", en, boy, DatabaseHelper.GetMalzeme(105).Price);
            double serit = RunMath($"icten_takma_18mm_dikey_serit", en, boy, DatabaseHelper.GetMalzeme(102).Price);
            double sineklik_ipi = RunMath($"icten_takma_18mm_dikey_sineklik_ipi", en, boy, DatabaseHelper.GetMalzeme(103).Price);
            double kil_fitil = RunMath($"icten_takma_18mm_dikey_kil_fitil", en, boy, DatabaseHelper.GetMalzeme(101).Price);
            double kus_gozu = RunMath($"icten_takma_18mm_dikey_kus_gozu", en, boy, DatabaseHelper.GetMalzeme(100).Price);
            double diger = tul + aks + serit + sineklik_ipi + kil_fitil + kus_gozu;

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
