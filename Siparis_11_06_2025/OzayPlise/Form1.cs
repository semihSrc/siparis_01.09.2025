using System;
using System.IO;
using System.Windows.Forms;
using OzayPlise.Classes.Hesaplamalar.KesimHesaplama;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._18mm_Icten_Takma;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._18mm_Sineklik_Kapi;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Kanallı_Kedi_Sineklik;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Sineklik_Kapi;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Sineklik_Kapi.Dolar;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama._27mm_Sineklik_Kapi.Euro;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama.Karavan_Oval_Kasa_Sineklik;
using OzayPlise.Classes.Hesaplamalar.MaaliyetHesaplama.SineklikMaaliyetHesaplama;
using OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama;
using OzayPlise.Classes.Hesaplamalar.PerdeMaaliyetHesaplama._18mm_Karavan_Perde;
using OzayPlise.Classes.Hesaplamalar.SineklikMaaliyetHesaplama;
using OzayPlise.Classes.Other;
using OzayPlise.Classes.TypeOfSineklik.KesimHesaplama;
using OzayPlise.Classes.TypeOfSineklik.PerdeMaaliyetHesaplama;
using OzayPlise.UserControls;

namespace OzayPlise
{
    public partial class Form1 : Form
    {
        Lisans license = new Lisans();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string licensePath = "license.dat";

            if (File.Exists(licensePath))
            {
                string savedKey = File.ReadAllText(licensePath);
                try
                {
                    if (license.ControlKey(savedKey))
                    {
                        // Lisans geçerli, program normal şekilde açılıyor
                        return;
                    }
                }
                catch
                {
                    // Decrypt sırasında hata olduysa lisans geçersizdir
                }
            }

            // Lisans yok veya geçersiz → lisans ekranını göster
            using (var licenseForm = new FirstLogin()) // kendi lisans formunu yazdıysan
            {
                if (licenseForm.ShowDialog() != DialogResult.OK)
                {
                    // Kullanıcı lisans girmezse programdan çık
                    Application.Exit();
                }
            }
        }

        private void RunKesimOlcu1(Object sinif)
        {
            KesimOlcuForm1 kesimOlcuForm1 = new KesimOlcuForm1() { sinif = sinif };
            kesimOlcuForm1.ShowDialog();
        }
        private void RunKesimOlcu2(Object sinif)
        {
            KesimOlcuForm2 kesimOlcuForm2 = new KesimOlcuForm2() { sinif = sinif };
            kesimOlcuForm2.ShowDialog();
        }

        private void RunMaaliyetOlcu1(Object sinif)
        {
            MaaliyetOlcuForm1 mOlcuForm1 = new MaaliyetOlcuForm1() { sinif = sinif };
            mOlcuForm1.ShowDialog();
        }

        private void RunMaaliyetOlcu2(Object sinif)
        {
            MaaliyetOlcuForm2 mOlcuForm2 = new MaaliyetOlcuForm2() { sinif = sinif };
            mOlcuForm2.ShowDialog();
        }

        private void RunMaaliyetOlcu3(Object sinif)
        {
            MaaliyetOlcuForm3 mOlcuForm3 = new MaaliyetOlcuForm3() { sinif = sinif };
            mOlcuForm3.ShowDialog();
        }

        #region KesimType1
        private void button1_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1(new Plise17x25Kesim() );
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            RunKesimOlcu1(new Plise18mm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1( new Plise27mm() );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1( new Esiksiz_27mm_Kesim() );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1( new Esiksiz_Kesim() );
        }

        private void button6_Click(object sender, EventArgs e)
        {
           RunKesimOlcu1( new Icden_Takma_Plise_Kesim() );
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1( new Oval_Karava_Kesim() );
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1( new Surme_Kesim() );
        }

        #endregion


        private void button9_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new PerdeMaaliyetHesaplama());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new GeceGunduzPerdeMaaliyet());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new Sineklik_Hesaplama());
        }


        private void button12_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu3(new SurmeMaaliyet());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new _18mm_Icten_Takma_Maaliyet());
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new _27mm_Kanalli_Kedi());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new Karavan_18mm());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new Karavan_Oval_Kasa());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MaaliyetOlcuForm2 mOlcuForm1 = new MaaliyetOlcuForm2() { sinif = new _18mm_Sineklik_Kapi(), m_type = 1 };
            mOlcuForm1.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new _27mm_Sineklik_Kapi());
        }

        private void button21_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new _27mm_Sineklik_Kapi_Dolar());
        }

        private void button22_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu2(new _27mm_Sineklik_Kapi_Euro());
        }

        private void button11_Click(object sender, EventArgs e)
        {
             RunKesimOlcu2(new Vidali_15mm_Perde()) ;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            RunKesimOlcu2(new Aski_15mm_Perde());
        }

        private void button23_Click(object sender, EventArgs e)
        {
            RunKesimOlcu2(new Yapistirma_15mm_Perde());
        }

        private void button24_Click(object sender, EventArgs e)
        {
            RunKesimOlcu2(new Slim_Vida_Perde());
        }

        private void button25_Click(object sender, EventArgs e)
        {
            RunKesimOlcu2(new Slim_Aski_Perde());
        }

        private void button26_Click(object sender, EventArgs e)
        {
            RunKesimOlcu2(new Slim_Yapistirma_Perde());
        }

        private void button27_Click(object sender, EventArgs e)
        {
            RunKesimOlcu2(new Portray_15mm_Perde());
        }

        private void button28_Click(object sender, EventArgs e)
        {
            RunKesimOlcu2(new Gece_Gunduz_15mm_Perde());
        }

        private void button29_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1(new Miknatisli_27mm_Kesim());
        }

        private void button30_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1(new Kedi_Sinekligi_27mm_Kesim());
        }

        private void button31_Click(object sender, EventArgs e)
        {
            RunKesimOlcu1(new Miknatisli_18mm_Kesim());
        }

        private void button32_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new Vidali_15mm_perde_maaliyet_Maaliyet());
        }

        private void button33_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new Aski_15mm_Perde_Maaliyet());
        }

        private void button34_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new Yapistirma_15mm_Perde_Maaliyet());
        }

        private void button35_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new Slim_Perde_slim_vidali_Maaliyet() );
        }

        private void button36_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new Slim_Aski_Perde_Maaliyet());
        }

        private void button37_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new Slim_Yapistirma_Perde_Maaliyet());
        }

        private void button38_Click(object sender, EventArgs e)
        {
            RunMaaliyetOlcu1(new Portray_15mm_Perde_Maaliyet());
        }
    }
}
