using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq; // 🟢 OfType ve FirstOrDefault için şart
using System.Windows.Forms;
using System.Drawing;

namespace eMuhasebeOtomasyon
{
    public partial class formRegister : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public formRegister()
        {
            InitializeComponent();
            KisitlamalariUygula();
        }

        private void KisitlamalariUygula()
        {
            txtTC.MaxLength = 11;
            txtTC.KeyPress += SadeceSayi_KeyPress;
            txtAd.KeyPress += SadeceHarf_KeyPress;
            txtSoyad.KeyPress += SadeceHarf_KeyPress;
        }

        private void SadeceHarf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void SadeceSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtMail.Text) || string.IsNullOrWhiteSpace(textBoxSifre.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(txtTC.Text))
            {
                MessageBox.Show("Lütfen tüm alanları (TC dahil) eksiksiz doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTC.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası tam olarak 11 hane olmalıdır!", "Hatalı TC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtMail.Text.Contains("@") || !txtMail.Text.Contains("."))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz!", "Geçersiz Mail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxSifre.Text != textBoxSifreTekrar.Text)
            {
                MessageBox.Show("Girdiğiniz şifreler birbiriyle uyuşmuyor!", "Şifre Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                client = new FireSharp.FirebaseClient(config);

                if (comboBox1.Text.Contains("Admin"))
                {
                    FirebaseResponse res = await client.GetAsync("Kullanicilar");
                    if (res.Body != "null")
                    {
                        var kullanicilar = res.ResultAs<Dictionary<string, dynamic>>();
                        bool adminMevcutMu = kullanicilar.Values.Any(u => u.Rol != null && u.Rol.ToString().Contains("Admin"));

                        if (adminMevcutMu)
                        {
                            MessageBox.Show("Sistemde zaten bir Yönetici (Admin) mevcut. İkinci bir Admin hesabı açılamaz!", "Kayıt Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }

                string kullaniciID = Guid.NewGuid().ToString().Substring(0, 8);

                var veri = new
                {
                    KullaniciID = kullaniciID,
                    TC = txtTC.Text.Trim(),
                    Ad = txtAd.Text.Trim(),
                    Soyad = txtSoyad.Text.Trim(),
                    Sifre = textBoxSifre.Text,
                    Rol = comboBox1.Text,
                    Mail = txtMail.Text.Trim().ToLower()
                };

                SetResponse response = await client.SetAsync("Kullanicilar/" + kullaniciID, veri);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Kayıt işlemi başarıyla tamamlandı! Giriş yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🟢 KAYIT BAŞARILI: Yeni sayfa açmak yerine arkadaki mevcudu göster
                    Form1 loginForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                    if (loginForm != null)
                    {
                        loginForm.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxSifre.UseSystemPasswordChar)
            {
                textBoxSifre.UseSystemPasswordChar = false;
                textBoxSifreTekrar.UseSystemPasswordChar = false;
                try { button3.Image = Properties.Resources.hide; } catch { }
            }
            else
            {
                textBoxSifre.UseSystemPasswordChar = true;
                textBoxSifreTekrar.UseSystemPasswordChar = true;
                try { button3.Image = Properties.Resources.eye; } catch { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 🟢 GERİ DÖN: Yeni sayfa açmak yerine arkadaki mevcudu göster
            Form1 loginForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (loginForm != null)
            {
                loginForm.Show();
                this.Close();
            }
            else
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
        }

        private void formRegister_Load(object sender, EventArgs e)
        {
            textBoxSifre.PasswordChar = '\0';
            textBoxSifreTekrar.PasswordChar = '\0';
            textBoxSifre.UseSystemPasswordChar = true;
            textBoxSifreTekrar.UseSystemPasswordChar = true;
            try { button3.Image = Properties.Resources.eye; } catch { }
        }

        // 🟢 CS1061 HATASINI ÇÖZEN METOT (Boş olsa bile kalmalı)
        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            // Designer'daki bağlantı hatasını giderir
        }
    }
}