using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing; // 🟢 Resim işlemleri için

namespace eMuhasebeOtomasyon
{
    public partial class Form1 : Form
    {
        public static string GirisYapanEmail = "";

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtGirisMail.Text) || string.IsNullOrWhiteSpace(txtGirisSifre.Text))
            {
                MessageBox.Show("Lütfen E-posta ve Şifre alanlarını doldurun.");
                button1.Enabled = true;
                return;
            }

            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = await client.GetAsync("Kullanicilar");
                if (response.Body == "null")
                {
                    MessageBox.Show("Sistemde kayıtlı kullanıcı bulunamadı.");
                    button1.Enabled = true;
                    return;
                }

                var tumKullanicilar = response.ResultAs<Dictionary<string, KullaniciModeli>>();
                var bulunanKullanici = tumKullanicilar.Values.FirstOrDefault(k =>
                    k.Mail != null && k.Mail.Trim().ToLower() == txtGirisMail.Text.Trim().ToLower());

                if (bulunanKullanici != null)
                {
                    if (txtGirisSifre.Text == bulunanKullanici.Sifre)
                    {
                        GirisYapanEmail = txtGirisMail.Text.Trim().ToLower();
                        UserSession.AdSoyad = bulunanKullanici.Ad + " " + bulunanKullanici.Soyad;
                        string gelenRol = bulunanKullanici.Rol.ToString().ToLower(System.Globalization.CultureInfo.InvariantCulture).Trim();

                        Form2 anaMenu = new Form2(gelenRol);
                        anaMenu.Show();
                        this.Hide(); // Giriş başarılıysa ana ekran gelir, burası gizlenir.
                    }
                    else
                    {
                        MessageBox.Show("Şifre hatalı!");
                        button1.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Bu e-posta adresine kayıtlı kullanıcı bulunamadı.");
                    button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası oluştu: " + ex.Message);
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtGirisSifre.UseSystemPasswordChar = !txtGirisSifre.UseSystemPasswordChar;

            if (txtGirisSifre.UseSystemPasswordChar)
            {
                try { button2.Image = Properties.Resources.eye; } catch { }
            }
            else
            {
                try { button2.Image = Properties.Resources.hide; } catch { }
            }
        }

        public class KullaniciModeli
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Sifre { get; set; }
            public string TC { get; set; }
            public string Rol { get; set; }
            public string Mail { get; set; }
        }

        // 🟢 KAYIT OL LİNKİ - MODAL (DOKUNULMAZ) KONTROLÜ
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formRegister frm = new formRegister();
            // Show() yerine ShowDialog() kullanarak Form1'i arkada sabit ama dokunulmaz yaparız.
            frm.ShowDialog();
        }

        // 🟢 ŞİFREMİ UNUTTUM LİNKİ - MODAL (DOKUNULMAZ) KONTROLÜ
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForgetPassword frm = new FormForgetPassword();
            // Show() yerine ShowDialog() kullanarak Form1'i arkada sabit ama dokunulmaz yaparız.
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtGirisSifre.UseSystemPasswordChar = true;
            txtGirisSifre.PasswordChar = '\0';
            try { button2.Image = Properties.Resources.eye; } catch { }
        }
    }
}