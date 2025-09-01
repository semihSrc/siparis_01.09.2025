using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzayPlise.UserControls
{
    public partial class FiyatListesi : Form
    {
        private dynamic _sinif;
        public FiyatListesi(dynamic sinif)
        {
            InitializeComponent();
            _sinif = sinif;
        }

        private void FiyatDuzenleme_Load(object sender, EventArgs e)
        {
            load();
            this.Text = _sinif.Name + " - Fiyat Listesi";
        }

        private void load()
        {
           dataGridView1.DataSource = DatabaseHelper.GetAllMalzemeler().Where(x => x.Type == _sinif.product_type).ToList();
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Price"].Visible = false;
            dataGridView1.Columns["Type"].Visible = false;
            dataGridView1.Columns["Product"].HeaderText = "Malzeme";
            dataGridView1.Columns["PriceString"].HeaderText = "Fiyat";
            dataGridView1.Font = new Font("Arial", 12);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satırdaki tüm verileri al
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = (sender as DataGridView).Rows[e.RowIndex];
                string a = selectedRow.Cells["Id"].Value.ToString();
                string b = selectedRow.Cells["Product"].Value.ToString();
                string c = selectedRow.Cells["PriceString"].Value.ToString();
                // Diğer hücreler için de benzer şekilde veri alabilirsiniz

                // Verileri başka bir forma gönder
                FiyatDegistir fd = new FiyatDegistir(a, b,c);
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    load();
                }
            }
        }
    }
}
