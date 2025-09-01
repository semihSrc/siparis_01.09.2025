using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama._18mm_Karavan_Perde;

namespace OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama.Karavan_Oval_Kasa_Sineklik
{
    internal class Karavan_Oval_Kasa
    {
        public string product_type = "oval_karavan";
        public string Name { get; set; } = "Oval Karavan Kasa Sineklik Maaliyet Hesaplama";

        public string setting_name = "karavan_oval_";
        public DataTable Hesapla(double en, double boy)
        {
            DataTable dikey = (new Karavan_Oval_Kasa_Dikey()).Hesapla(en, boy);
            DataTable yatay = (new Karavan_Oval_Kasa_Yatay()).Hesapla(en, boy);
            DataTable ort = (new Karavan_Oval_Kasa_Ort()).Hesapla(en, boy);

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
