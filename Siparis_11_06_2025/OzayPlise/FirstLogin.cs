using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OzayPlise.Classes.Other;

namespace OzayPlise
{
    public partial class FirstLogin : Form
    {
        Lisans license = new Lisans();
        public FirstLogin()
        {
            InitializeComponent();
        }

        private void FirstLogin_Load(object sender, EventArgs e)
        {
            textBox1.Text = license.GetKey();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("Kopyalandı");
            }else
            {
                MessageBox.Show("Lisans anahtarı boş olduğundan kopyalanamadı");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredKey = textBox2.Text;
            try
            {
                if (license.ControlKey(enteredKey))
                {
                    // Geçerli lisans, kaydet
                    File.WriteAllText("license.dat", enteredKey);
                    MessageBox.Show("Lisans başarıyla doğrulandı.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lisans geçersiz.");
                }
            }
            catch
            {
                MessageBox.Show("Anahtar okunamadı. Hatalı giriş.");
            }
        }
    }
}
