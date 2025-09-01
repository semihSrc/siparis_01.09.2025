using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using OzayPlise.Classes.Hesaplamalar.KesimHesaplama;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OzayPlise.UserControls
{
    public partial class MaaliyetOlcuForm1 : Form
    {
        public dynamic sinif { get; set; }
        public MaaliyetOlcuForm1()
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
                DataTable maaliyet = (sinif).Hesapla(Convert.ToDouble(en.Text), Convert.ToDouble(boy.Text));
               
                label5.Text = (maaliyet.Rows[0][0].ToString());
                label17.Text = maaliyet.Rows[0][1].ToString();
                
                label6.Text = maaliyet.Rows[0][2].ToString();
                label18.Text = maaliyet.Rows[0][3].ToString();

                label9.Text = maaliyet.Rows[0][4].ToString();
                label19.Text = maaliyet.Rows[0][5].ToString();

                label7.Text = maaliyet.Rows[0][6].ToString();
                label21.Text = maaliyet.Rows[0][7].ToString();

                label12.Text = maaliyet.Rows[0][8].ToString();
                label20.Text = maaliyet.Rows[0][9].ToString();

                label14.Text = maaliyet.Rows[0][10].ToString();
                label22.Text = maaliyet.Rows[0][11].ToString();

                label24.Text = maaliyet.Rows[0][12].ToString();


                AddRowIfUnique(dataGridView1, en.Text, boy.Text, 
                    label5.Text,label17.Text, label6.Text,label18.Text,label9.Text,label19.Text,
                    label7.Text,label21.Text,
                    label12.Text, label20.Text, label14.Text, label22.Text, label24.Text);
            }
        }

        private void KesimOlcuForm1_Load(object sender, EventArgs e)
        {
            this.Text = sinif.Name;
            dataGridView1.Columns.Add("en", "En");
            dataGridView1.Columns.Add("boy", "Boy");
            dataGridView1.Columns.Add("kumas", "Kumaş Birim");
            dataGridView1.Columns.Add("kumas1", "Kumaş Fiyat");
            dataGridView1.Columns.Add("profil", "Profil Birim");
            dataGridView1.Columns.Add("profil1", "Profil Fiyat");
            dataGridView1.Columns.Add("aksesuar", "Aksesuar Birim");
            dataGridView1.Columns.Add("aksesuar1", "Aksesuar Fiyat");
            dataGridView1.Columns.Add("serit", "Şerit Birim");
            dataGridView1.Columns.Add("serit1", "Şerit Fiyat");
            dataGridView1.Columns.Add("ip", "İp Ölçü Birim");
            dataGridView1.Columns.Add("ip1", "İp Ölçü Fiyat");
            dataGridView1.Columns.Add("kus", "Kuş Gözü Birim");
            dataGridView1.Columns.Add("kus1", "Kuş Gözü Fiyat");
            dataGridView1.Columns.Add("toplam", "Toplam Fiyat");
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "actionButton",
                HeaderText = "İşlemler",
                Text = "Kaldır",
                UseColumnTextForButtonValue = true,
            });
            dataGridView1.Columns["actionButton"].Width = 80; // Sabit boyut

            // DataGridView fontunu büyüt
            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, 10); // 12, istediğiniz font boyutu


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

        private void formüllerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormulListesi f = new FormulListesi(sinif);
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["actionButton"].Index && e.RowIndex >= 0)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = ConvertToDataTable(dataGridView1);
            XtraReport1 report = new XtraReport1(data, this.Text);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        public DataTable ConvertToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Sadece "İşlemler" olmayan sütunları ekle
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name != "actionButton")
                    dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    var values = new List<object>();
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (col.Name != "actionButton")
                            values.Add(row.Cells[col.Index].Value);
                    }
                    dt.Rows.Add(values.ToArray());
                }
            }

            return dt;
        }
    }
}
