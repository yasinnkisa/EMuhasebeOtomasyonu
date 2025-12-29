using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMuhasebeOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Şifre ve Kullanıcı Adı Kontrolü (SQL'siz, Manuel Kontrol)
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                // Bilgiler doğruysa Ana Formu (Form2) oluştur ve aç
                Form2 anaForm = new Form2();
                anaForm.Show();

                // Giriş ekranını gizle (kapatma, sadece gizle)
                this.Hide();
            }
            else
            {
                // Yanlış girerse uyarı ver
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
