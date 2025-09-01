using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama._18mm_Karavan_Perde;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._18mm_Sineklik_Kapi
{
    internal class _18mm_Sineklik_Kapi
    {
        public string product_type = "18mm";
        public string Name = "18mm Sineklik Kapı Maaliyet Hesaplama";
        public string settings_name = "sk18mm_";
        public DataTable Hesapla(double en, double boy,short type = 1)
        {
            DataTable dikey = (new _18mm_Dikey_Sineklik_Kapi()).Hesapla(en, boy);
            DataTable yatay = (new _18mm_Yatay_Sineklik_Kapi()).Hesapla(en, boy);
            DataTable ort = (new _18mm_Ort_Sineklik_Kapi()).Hesapla(en, boy);

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
