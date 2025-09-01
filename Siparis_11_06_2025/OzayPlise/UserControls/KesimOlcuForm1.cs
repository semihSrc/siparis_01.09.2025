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
using OzayPlise.Classes.TypeOfSineklik.KesimHesaplama;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OzayPlise.UserControls
{
    public partial class KesimOlcuForm1 : Form
    {
        public dynamic sinif { get; set; }
        public KesimOlcuForm1()
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
                
                label5.Text = kesim.Rows[0][0].ToString();
                label6.Text = kesim.Rows[0][1].ToString();

                if (!(sinif is Plise17x25Kesim))
                {
                    label9.Text = kesim.Rows[0][2].ToString();
                }

                if (!(sinif is Plise17x25Kesim) && !(sinif is Surme_Kesim))
                {
                    label7.Text = kesim.Rows[0][3].ToString();

                    label12.Text = kesim.Rows[0][4].ToString();

                    if (!(sinif is Oval_Karava_Kesim)) { label14.Text = kesim.Rows[0][5].ToString(); }
                }

                AddRowIfUnique(dataGridView1, en.Text, boy.Text, label5.Text, label6.Text, label9.Text, label7.Text, label12.Text, label14.Text);
            }
        }

        private void KesimOlcuForm1_Load(object sender, EventArgs e)
        {this.Text = sinif.Name;
            dataGridView1.Columns.Add("en", "En");
            dataGridView1.Columns.Add("boy", "Boy");
            dataGridView1.Columns.Add("dikey", "Dikey Kasa");
            dataGridView1.Columns.Add("yatay", "Yatay Kasa");

            // DataGridView fontunu büyüt
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10); // 12, istediğiniz font boyutu

            if (!(sinif is Plise17x25Kesim))
            {
                dataGridView1.Columns.Add("kanat", "Kanat");
                label9.Visible = true;
                label10.Visible = true;
            }

            if (!(sinif is Plise17x25Kesim) && !(sinif is Surme_Kesim))
            {
                dataGridView1.Columns.Add("tul", "Tül Ölçü");
                dataGridView1.Columns.Add("tepe", "Tepe");

                label8.Visible = true;
                label7.Visible = true;
                label12.Visible = true;
                label11.Visible = true;
                if (!(sinif is Oval_Karava_Kesim))
                {
                    dataGridView1.Columns.Add("ip", "İp Ölçü");
                    label13.Visible = true;
                    label14.Visible = true;
                }
            }
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
