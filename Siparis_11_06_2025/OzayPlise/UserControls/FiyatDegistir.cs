using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzayPlise.UserControls
{
    public partial class FiyatDegistir : Form
    {
        private string _id;
        private string _value;
        public FiyatDegistir(string id ,string title, string value)
        {
            InitializeComponent();
            _id = id;
            _value = value;
            label2.Text = value;
            this.Text = "Fiyat Değiştiriliyor - " + title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat girin.");
                return;
            }
            if (!decimal.TryParse(textBox1.Text, out decimal newPrice))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat girin.");
                return;
            }

            // Fiyatı güncelle
            string db = Convert.ToDouble(textBox1.Text.Replace(",","."),CultureInfo.InvariantCulture).ToString();

            DatabaseHelper.UpdateMalzeme(Convert.ToInt32(_id), db);
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sayı, nokta (.) veya virgül (,) harici bir karakter girilemiyor
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;  // Geçersiz karakteri engelle
            }

            // Nokta veya virgül bir defadan fazla girilemez
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (textBox1.Text.Contains(".") || textBox1.Text.Contains(","))
                {
                    e.Handled = true;  // Zaten bir nokta/virgül varsa, bir tane daha eklenmesini engelle
                }
            }
        }

        private void FiyatDegistir_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
