using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._18mm_Icten_Takma
{
    internal class _18mm_Icten_Takma_Ort : Sineklik
    {
        public DataTable Hesapla(double en, double boy)
        {
            double kanatBeyaz = RunMath($"icten_takma_18mm_ort_kanat", en, boy, DatabaseHelper.GetMalzeme(107).Price);
            double kasaBeyaz = RunMath($"icten_takma_18mm_ort_kasa", en, boy, DatabaseHelper.GetMalzeme(106).Price);
            double beyaz = kanatBeyaz + kasaBeyaz;

            double kanatRal = RunMath($"icten_takma_18mm_ort_kanat", en, boy, DatabaseHelper.GetMalzeme(109).Price);
            double kasaRal = RunMath($"icten_takma_18mm_ort_kasa", en, boy, DatabaseHelper.GetMalzeme(108).Price);
            double ral = kanatRal + kasaRal;

            double kanatAdesen = RunMath($"icten_takma_18mm_ort_kanat", en, boy, DatabaseHelper.GetMalzeme(111).Price);
            double kasaAdesen = RunMath($"icten_takma_18mm_ort_kasa_adesen", en, boy, DatabaseHelper.GetMalzeme(110).Price);
            double adesen = kanatAdesen + kasaAdesen;

            double tulDiger = RunMath($"icten_takma_18mm_ort_tul", en, boy, DatabaseHelper.GetMalzeme(99).Price);
            double aksDiger = RunMath($"icten_takma_18mm_ort_aks", en, boy, DatabaseHelper.GetMalzeme(105).Price);
            double seritDiger = RunMath($"icten_takma_18mm_ort_serit", en, boy, DatabaseHelper.GetMalzeme(102).Price);
            double sineklikIpiDiger = RunMath($"icten_takma_18mm_ort_sineklik_ipi", en, boy, DatabaseHelper.GetMalzeme(103).Price);
            double miknatisDiger = RunMath($"icten_takma_18mm_ort_miknatis", en, boy, DatabaseHelper.GetMalzeme(104).Price);
            double kusGozuDiger = RunMath($"icten_takma_18mm_ort_kus_gozu", en, boy, DatabaseHelper.GetMalzeme(100).Price);
            double diger = tulDiger + aksDiger + seritDiger + sineklikIpiDiger + miknatisDiger + kusGozuDiger;

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
