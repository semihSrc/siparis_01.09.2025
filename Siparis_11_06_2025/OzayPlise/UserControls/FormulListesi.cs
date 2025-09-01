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
    public partial class FormulListesi : Form
    {
        private dynamic _sinif;
        public FormulListesi(dynamic sinif)
        {
            InitializeComponent();
            _sinif = sinif;
        }

        private void FormulListesi_Load(object sender, EventArgs e)
        {
            load();
            this.Text = _sinif.Name + " - Formül Listesi";
        }

        private void load()
        {
            dataGridView1.DataSource = DatabaseHelper.GetSettingsList(_sinif.settings_name);
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["SettingsName"].Visible = false;
            dataGridView1.Columns["Title"].HeaderText = "Başlık";
            dataGridView1.Columns["Value"].HeaderText = "Formül";
            dataGridView1.Font = new Font("Arial", 12);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satırdaki tüm verileri al
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = (sender as DataGridView).Rows[e.RowIndex];
                string a = selectedRow.Cells["id"].Value.ToString();
                string b = selectedRow.Cells["title"].Value.ToString();
                string c = selectedRow.Cells["value"].Value.ToString();
                // Diğer hücreler için de benzer şekilde veri alabilirsiniz

                // Verileri başka bir forma gönder
                FormulDegistir fd = new FormulDegistir(a, b, c);
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    load();
                }
            }
        }
    }
}
