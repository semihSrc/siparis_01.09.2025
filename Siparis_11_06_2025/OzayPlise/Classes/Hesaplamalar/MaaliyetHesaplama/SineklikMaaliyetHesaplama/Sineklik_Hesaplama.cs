using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama._18mm_Karavan_Perde;
using OzayPlise.Classes.Hesaplamalar.SineklikMaaliyetHesaplama;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama.SineklikMaaliyetHesaplama
{
    internal class Sineklik_Hesaplama
    {
        public string product_type = "sineklik";
        public string Name { get; set; } = "Sineklik Maaliyet Hesaplama";

        public string settings_name = "skm_";
        public DataTable Hesapla(double en, double boy)
        {
            DataTable dikey = (new Dikey_SineklikMaaliyetHesaplama()).Hesapla(en, boy);
            DataTable yatay = (new Yatay_SineklikMaaliyetHesaplama()).Hesapla(en, boy);
            DataTable ort = (new OrtBirlesim_SineklikMalliyetHesaplama()).Hesapla(en, boy);

            DataTable result = new DataTable
            {
                Columns =
         {
             new DataColumn("Tür", typeof(string)),
             new DataColumn("Beyaz", typeof(double)),
             new DataColumn("RAL", typeof(double)),
             new DataColumn("A.Desen", typeof(double))
         },
                Rows =
         {
             { "Yatay", yatay.Rows[0][0], yatay.Rows[0][1], yatay.Rows[0][2]
             },
             { "Dikey", dikey.Rows[0][0], dikey.Rows[0][1], dikey.Rows[0][2]
             },
             { "Ort", ort.Rows[0][0], ort.Rows[0][1], ort.Rows[0][2]
             }
         }

            };
            return result;

        }
    }
}
