using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzayPlise.UserControls
{
    public partial class FormulDegistir : Form
    {
        private string _id;
        private string _value;
        public FormulDegistir(string id, string title, string value)
        {
            InitializeComponent();
            _id = id;
            _value = value;
            label2.Text = value;
            this.Text = "Formül Değiştiriliyor - " + title;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Lütfen bir formül girin.");
                return;
            }

            DatabaseHelper.UpdateSettings(Convert.ToInt32(_id), textBox1.Text.Trim());
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer Backspace tuşuna basılmışsa, silme işlemi yapılabilir
            if (e.KeyChar == (char)8)
            {
                e.Handled = false; // Backspace için işlem engellenmesin
                return;
            }

            // Geçerli karakterler: X, Y, Z, Sayılar, Operatörler (+,-,*,/), Parantezler
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsLetter(e.KeyChar) &&
                e.KeyChar != '+' &&
                e.KeyChar != '-' &&
                e.KeyChar != '*' &&
                e.KeyChar != '/' &&
                e.KeyChar != '(' &&
                e.KeyChar != ')')
            {
                // Eğer karakter yukarıdaki şartlardan biri değilse, tuş basımını engelle
                e.Handled = true;
            }

            // Sadece X, Y, Z harflerini kabul et
            if (char.IsLetter(e.KeyChar) && e.KeyChar != 'X' && e.KeyChar != 'Y' && e.KeyChar != 'Z')
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
