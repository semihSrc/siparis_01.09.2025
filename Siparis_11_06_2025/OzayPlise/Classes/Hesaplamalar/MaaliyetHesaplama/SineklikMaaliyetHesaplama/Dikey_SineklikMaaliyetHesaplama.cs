using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzayPlise.Classes.Interfaces;

namespace OzayPlise.Classes.Hesaplamalar.SineklikMaaliyetHesaplama
{
    internal class Dikey_SineklikMaaliyetHesaplama : Sineklik
    {

        public DataTable Hesapla(double en, double boy)
        {
            

                double ral = RunMath($"skm_dikey_sineklik_kanat_fiyat", en, boy, DatabaseHelper.GetMalzeme(40).Price) +
                RunMath($"skm_dikey_sineklik_kasa_fiyat", en, boy, DatabaseHelper.GetMalzeme(41).Price);
           
                double eloksal = RunMath($"skm_dikey_sineklik_kanat_fiyat", en, boy, DatabaseHelper.GetMalzeme(43).Price) +
                RunMath($"skm_dikey_sineklik_kasa_fiyat", en, boy, DatabaseHelper.GetMalzeme(42).Price);
           
                double transfer = RunMath($"skm_dikey_sineklik_kanat_fiyat", en, boy, DatabaseHelper.GetMalzeme(45).Price) +
                RunMath($"skm_dikey_sineklik_kasa_fiyat", en, boy, DatabaseHelper.GetMalzeme(44).Price);

          

            double diger =  RunMath($"skm_dikey_sineklik_tul_fiyat", en, boy, DatabaseHelper.GetMalzeme(33).Price) +
                RunMath($"skm_dikey_sineklik_aks_set_fiyat", en, boy, DatabaseHelper.GetMalzeme(39).Price) +
                RunMath($"skm_dikey_sineklik_serit_profil_fiyat", en, boy, DatabaseHelper.GetMalzeme(36).Price) +
                RunMath($"skm_dikey_sineklik_sineklik_ipi_fiyat", en, boy, DatabaseHelper.GetMalzeme(37).Price) +
                RunMath($"skm_dikey_sineklik_kil_fitil_fiyat", en, boy, DatabaseHelper.GetMalzeme(35).Price) +
                RunMath($"skm_dikey_sineklik_kus_gozu_fiyat", en, boy, DatabaseHelper.GetMalzeme(34).Price)
                ;

            return new DataTable()
            {
                Columns =
                {
                    new DataColumn("RAL", typeof(string)),
                    new DataColumn("ELOKSAL", typeof(string)),
                    new DataColumn("TRANSFER", typeof(string)),
                },
                Rows =
                {
                    { ral+ diger ,eloksal + diger , transfer + diger }
                }
            };
        }
    }
}
