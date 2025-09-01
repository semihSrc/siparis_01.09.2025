using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama._18mm_Karavan_Perde;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Kanallı_Kedi_Sineklik
{
    internal class _27mm_Kanalli_Kedi
    {
        public string product_type = "kanalli_kedi";
        public string Name = "27mm Kanallı Kedi Sineklik Maaliyet Hesaplama";
        public string settings_name = "27mm_kanalli";
        public DataTable Hesapla(double en, double boy)
        {
            DataTable dikey = (new _27mm_Kanalli_Kedi_Sineklik_Dikey()).Hesapla(en, boy);
            DataTable yatay = (new _27mm_Kanalli_Kedi_Sineklik_Yatay()).Hesapla(en, boy);
            DataTable ort = (new _27mm_Kanalli_Kedi_Sineklik_Ort()).Hesapla(en, boy);

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
