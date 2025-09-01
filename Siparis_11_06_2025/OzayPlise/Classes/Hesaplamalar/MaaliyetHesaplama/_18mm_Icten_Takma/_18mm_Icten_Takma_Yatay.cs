using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._18mm_Icten_Takma
{
    internal class _18mm_Icten_Takma_Yatay : Sineklik
    {
        public DataTable Hesapla(double en , double boy)
        {
            double kanatBeyaz = RunMath($"icten_takma_18mm_yatay_kanat", en, boy, DatabaseHelper.GetMalzeme(107).Price);
            double kasaBeyaz = RunMath($"icten_takma_18mm_yatay_kasa", en, boy, DatabaseHelper.GetMalzeme(106).Price);
            double beyaz = kanatBeyaz + kasaBeyaz;

            double kanatRal = RunMath($"icten_takma_18mm_yatay_kanat", en, boy, DatabaseHelper.GetMalzeme(109).Price);
            double kasaRal = RunMath($"icten_takma_18mm_yatay_kasa", en, boy, DatabaseHelper.GetMalzeme(108).Price);
            double ral = kanatRal + kasaRal;

            double kanatAdesen = RunMath($"icten_takma_18mm_yatay_kanat", en, boy, DatabaseHelper.GetMalzeme(111).Price);
            double kasaAdesen = RunMath($"icten_takma_18mm_yatay_kasa", en, boy, DatabaseHelper.GetMalzeme(110).Price);
            double adesen = kanatAdesen + kasaAdesen;

            double tul = RunMath($"icten_takma_18mm_yatay_tul", en, boy, DatabaseHelper.GetMalzeme(99).Price);
            double aks = RunMath($"icten_takma_18mm_yatay_aks", en, boy, DatabaseHelper.GetMalzeme(105).Price);
            double serit = RunMath($"icten_takma_18mm_yatay_serit", en, boy, DatabaseHelper.GetMalzeme(102).Price);
            double sineklikIpi = RunMath($"icten_takma_18mm_yatay_sineklik_ipi", en, boy, DatabaseHelper.GetMalzeme(103).Price);
            double kilFitil = RunMath($"icten_takma_18mm_yatay_kil_fitil", en, boy, DatabaseHelper.GetMalzeme(101).Price);
            double kusGozu = RunMath($"icten_takma_18mm_yatay_kus_gozu", en, boy, DatabaseHelper.GetMalzeme(100).Price);
            double diger = tul + aks + serit + sineklikIpi + kilFitil + kusGozu;

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
                    { (beyaz + diger).ToString("0.00") , (ral + diger).ToString("0.00") , (adesen + diger).ToString("0.00") }
                }
            };
        }
    
    }
}
