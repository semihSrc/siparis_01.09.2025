using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OzayPlise.UserControls
{
    public partial class MaaliyetOlcuForm2 : Form
    {
        public dynamic sinif { get; set; }
        public int m_type = 1;
        public MaaliyetOlcuForm2()
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
                DataTable maaliyet = (m_type != 1) ? ((sinif).Hesapla(Convert.ToDouble(en.Text), Convert.ToDouble(boy.Text))) : (sinif).Hesapla(Convert.ToDouble(en.Text), Convert.ToDouble(boy.Text));
                
                label5.Text = maaliyet.Rows[0][1].ToString();
                label17.Text = maaliyet.Rows[0][2].ToString();

                label7.Text = maaliyet.Rows[0][3].ToString();
                label6.Text = maaliyet.Rows[1][1].ToString();

                label18.Text = maaliyet.Rows[1][2].ToString();
                label21.Text = maaliyet.Rows[1][3].ToString();

                label9.Text = maaliyet.Rows[2][1].ToString();
                label19.Text = maaliyet.Rows[2][2].ToString();

                label12.Text = maaliyet.Rows[2][3].ToString();



                AddRowIfUnique(dataGridView1, en.Text, boy.Text,
                    label5.Text, label17.Text, label7.Text, label6.Text, label18.Text, label21.Text,
                label9.Text, label19.Text,
                label12.Text);
            }
        }



        private void MaaliyetOlcuForm2_Load(object sender, EventArgs e)
        {
            this.Text = sinif.Name;// DataGridView fontunu büyüt
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10); // 12, istediğiniz font boyutu

            dataGridView1.Columns.Add("en", "En");
            dataGridView1.Columns.Add("boy", "Boy");
            dataGridView1.Columns.Add("kumas", "Yatay Beyaz");
            dataGridView1.Columns.Add("kumas1", "Yatay Ral");
            dataGridView1.Columns.Add("kumas2", "Yatay A.Desen");
            dataGridView1.Columns.Add("kumas3", "Dikey Beyaz");
            dataGridView1.Columns.Add("kumas4", "Dikey Ral");
            dataGridView1.Columns.Add("kumas5", "Dikey A.Desen");
            dataGridView1.Columns.Add("profil1", "Ort. Birleşim Beyaz");
            dataGridView1.Columns.Add("profil2", "Ort. Birleşim Ral");
            dataGridView1.Columns.Add("profil3", "Ort. Birleşim A.Desen");
           
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
