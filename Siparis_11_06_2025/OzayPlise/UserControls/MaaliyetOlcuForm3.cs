using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OzayPlise.UserControls
{
    public partial class MaaliyetOlcuForm3 : Form
    {
        public dynamic sinif { get; set; }
        public MaaliyetOlcuForm3()
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(en.Text) && !string.IsNullOrWhiteSpace(boy.Text))
            {
                DataTable maaliyet = (sinif).Hesapla(Convert.ToDouble(en.Text), Convert.ToDouble(boy.Text));
                label5.Text = (maaliyet.Rows[0][1].ToString());
                label17.Text = maaliyet.Rows[0][2].ToString();
                label42.Text = maaliyet.Rows[0][3].ToString();

                label6.Text = maaliyet.Rows[1][1].ToString();
                label18.Text = maaliyet.Rows[1][2].ToString();
                label41.Text = maaliyet.Rows[1][3].ToString();

                label9.Text = maaliyet.Rows[2][1].ToString();
                label19.Text = maaliyet.Rows[2][2].ToString();
                label40.Text = maaliyet.Rows[2][3].ToString();

                label7.Text = maaliyet.Rows[3][1].ToString();
                label21.Text = maaliyet.Rows[3][2].ToString();
                label38.Text = maaliyet.Rows[3][3].ToString();

                label12.Text = maaliyet.Rows[4][1].ToString();
                label20.Text = maaliyet.Rows[4][2].ToString();
                label39.Text = maaliyet.Rows[4][3].ToString();

                label14.Text = maaliyet.Rows[5][1].ToString();
                label22.Text = maaliyet.Rows[5][2].ToString();
                label37.Text = maaliyet.Rows[5][3].ToString();

                label24.Text = maaliyet.Rows[6][1].ToString();
                label26.Text = maaliyet.Rows[6][2].ToString();
                label36.Text = maaliyet.Rows[6][3].ToString();

                label29.Text = maaliyet.Rows[7][2].ToString();
                label35.Text = maaliyet.Rows[7][3].ToString();

                label32.Text = maaliyet.Rows[8][2].ToString();
                label34.Text = maaliyet.Rows[8][3].ToString();


                AddRowIfUnique(dataGridView1, en.Text, boy.Text,
                    label5.Text, label17.Text, label42.Text,
                    label6.Text, label18.Text, label41.Text,
                    label9.Text, label19.Text, label40.Text,
                    label7.Text, label21.Text, label38.Text,
                    label12.Text, label20.Text, label39.Text,
                    label14.Text, label22.Text, label37.Text,
                    label24.Text, label26.Text, label36.Text,
                    label29.Text, label35.Text,
                    label32.Text, label34.Text);
            }
        }

        private void KesimOlcuForm1_Load(object sender, EventArgs e)
        {
            this.Text = sinif.Name;
            // DataGridView fontunu büyüt
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10); // 12, istediğiniz font boyutu

            dataGridView1.Columns.Add("en", "En");
            dataGridView1.Columns.Add("boy", "Boy");
            dataGridView1.Columns.Add("kumas", "Kumaş Birim");
            dataGridView1.Columns.Add("kumas1", "Kumaş Fiyat");
            dataGridView1.Columns.Add("kumas2", "Kumaş RAL");

            dataGridView1.Columns.Add("profil", "Profil Birim");
            dataGridView1.Columns.Add("profil1", "Profil Fiyat");
            dataGridView1.Columns.Add("profil2", "Profil RAL");

            dataGridView1.Columns.Add("aksesuar", "Aksesuar Birim");
            dataGridView1.Columns.Add("aksesuar1", "Aksesuar Fiyat");
            dataGridView1.Columns.Add("aksesuar2", "Aksesuar RAL");

            dataGridView1.Columns.Add("serit", "Şerit Birim");
            dataGridView1.Columns.Add("serit1", "Şerit Fiyat");
            dataGridView1.Columns.Add("serit2", "Şerit RAL");

            dataGridView1.Columns.Add("ip", "İp Ölçü Birim");
            dataGridView1.Columns.Add("ip1", "İp Ölçü Fiyat");
            dataGridView1.Columns.Add("ip2", "İp Ölçü RAL");

            dataGridView1.Columns.Add("kus", "Kuş Gözü Birim");
            dataGridView1.Columns.Add("kus1", "Kuş Gözü Fiyat");
            dataGridView1.Columns.Add("kus2", "Kuş Gözü RAL");

            dataGridView1.Columns.Add("toplam", "Toplam Fiyat");
            dataGridView1.Columns.Add("toplam2", "Toplam RAL Fiyat");


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

        private void malzemeFiyatlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FiyatListesi f = new FiyatListesi(sinif);
            f.ShowDialog();
        }

        private void formüllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormulListesi f = new FormulListesi(sinif);
            f.ShowDialog();
        }
    }
}
