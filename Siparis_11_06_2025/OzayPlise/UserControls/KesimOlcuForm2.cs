using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OzayPlise.Classes.Hesaplamalar.KesimHesaplama;

namespace OzayPlise.UserControls
{
    public partial class KesimOlcuForm2 : Form
    {
        public dynamic sinif { get; set; }
        public KesimOlcuForm2()
        {
            InitializeComponent();

        }

        private void AddRowIfUnique(DataGridView dgv, params object[] rowValues)
        {
            // DataGridView'deki tüm satırlarda aynı değerlere sahip satır olup olmadığını kontrol et
            foreach (DataGridViewRow existingRow in dgv.Rows)
            {
                bool isDuplicate = true;

                // Her hücreyi kontrol et
                for (int i = 0; i < existingRow.Cells.Count; i++)
                {
                    // Eğer mevcut satırdaki hücre ile yeni satırdaki hücre değeri farklıysa
                    if (!existingRow.Cells[i].Value.Equals(rowValues[i]))
                    {
                        isDuplicate = false;
                        break;
                    }
                }

                // Eğer aynı satır bulunursa, fonksiyondan çık
                if (isDuplicate)
                {
                    return;
                }
            }

            // Aynı satır yoksa, yeni satırı ekle
            dgv.Rows.Add(rowValues);
        }


        // Yardımcı fonksiyon: Sayılar ve '.' için kontrol
        private bool IsAllowedKey(Keys key)
        {
            // Numpad ve standart sayılar ile '.' izin ver
            return (key >= Keys.D0 && key <= Keys.D9) || (key >= Keys.NumPad0 && key <= Keys.NumPad9) || key == Keys.OemPeriod;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(en.Text) && !string.IsNullOrWhiteSpace(boy.Text))
            {
                DataTable kesim = (sinif).Hesapla(Convert.ToDouble(en.Text), Convert.ToDouble(boy.Text));


                label6.Text = kesim.Rows[0][0].ToString();
                label12.Text = kesim.Rows[0][1].ToString();
                label14.Text = kesim.Rows[0][2].ToString();


                AddRowIfUnique(dataGridView1, en.Text, boy.Text, label6.Text, label12.Text, label14.Text);
            }
        }

        private void KesimOlcuForm1_Load(object sender, EventArgs e)
        {
            this.Text = sinif.Name;
            dataGridView1.Columns.Add("en", "En");
            dataGridView1.Columns.Add("boy", "Boy");
            dataGridView1.Columns.Add("yatay", "Yatay Kasa");

            dataGridView1.Columns.Add("tepe", "Tepe");
            dataGridView1.Columns.Add("ip", "İp Ölçü");

        }
        

        private void en_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sayı, nokta (.) veya virgül (,) harici bir karakter girilemiyor
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;  // Geçersiz karakteri engelle
            }

            // Nokta veya virgül bir defadan fazla girilemez
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (en.Text.Contains(".") || en.Text.Contains(","))
                {
                    e.Handled = true;  // Zaten bir nokta/virgül varsa, bir tane daha eklenmesini engelle
                }
            }
        }

        private void boy_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sayı, nokta (.) veya virgül (,) harici bir karakter girilemiyor
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;  // Geçersiz karakteri engelle
            }

            // Nokta veya virgül bir defadan fazla girilemez
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (boy.Text.Contains(".") || boy.Text.Contains(","))
                {
                    e.Handled = true;  // Zaten bir nokta/virgül varsa, bir tane daha eklenmesini engelle
                }
            }
        }

        private void formüllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormulListesi f = new FormulListesi(sinif);
            f.ShowDialog();
        }
    }
}
