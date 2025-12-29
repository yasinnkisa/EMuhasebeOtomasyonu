using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic; // Dictionary için eklendi
using System.Linq; // 🟢 OfType ve FirstOrDefault için gerekli
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace eMuhasebeOtomasyon
{
    public partial class FormForgetPassword : Form
    {
        // Firebase Bağlantı Ayarları
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public FormForgetPassword()
        {
            InitializeComponent();
        }

        private void btnKodGonder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Lütfen mail adresinizi giriniz.");
                return;
            }

            Random rnd = new Random();
            string dogrulamaKodu = rnd.Next(100000, 999999).ToString();

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient sc = new SmtpClient();

                sc.Credentials = new NetworkCredential("denge.yardim@gmail.com", "qjoz rkfw ysfx clbr");
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;

                mail.From = new MailAddress("denge.yardim@gmail.com", "DENGE Muhasebe");
                mail.To.Add(txtEmail.Text);
                mail.Subject = "Şifre Sıfırlama Kodu";
                mail.Body = "Şifre Yenileme İşleminiz İçin Doğrulama Kodunuz: " + dogrulamaKodu;

                sc.Send(mail);

                this.Tag = dogrulamaKodu; // Kodu Tag içerisinde saklıyoruz
                MessageBox.Show("Kod başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderme hatası: " + ex.Message);
            }
        }

        private async void btnOnayla_Click(object sender, EventArgs e)
        {
            // 1. Kod Doğruluğu Kontrolü
            if (this.Tag == null || txtKod.Text != this.Tag.ToString())
            {
                MessageBox.Show("Girdiğiniz doğrulama kodu hatalı!");
                return;
            }

            // 2. Alanların Doluluk Kontrolü
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtYeniSifre.Text))
            {
                MessageBox.Show("Lütfen E-posta ve Yeni Şifre alanlarını doldurun.");
                return;
            }

            try
            {
                client = new FireSharp.FirebaseClient(config);

                // 3. ADIM: Girilen Mail Adresine Sahip Kullanıcıyı Veritabanında Bulma
                FirebaseResponse res = await client.GetAsync("Kullanicilar");

                if (res.Body == "null")
                {
                    MessageBox.Show("Kullanıcı veritabanı boş.");
                    return;
                }

                var tumKullanicilar = res.ResultAs<Dictionary<string, KullaniciModeli>>();

                var bulunanKayit = tumKullanicilar.FirstOrDefault(x =>
                    x.Value.Mail != null &&
                    x.Value.Mail.Trim().ToLower() == txtEmail.Text.Trim().ToLower());

                if (bulunanKayit.Key == null)
                {
                    MessageBox.Show("Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı!");
                    return;
                }

                // 4. ADIM: Şifre Güncelleme
                var veri = new { Sifre = txtYeniSifre.Text };

                FirebaseResponse response = await client.UpdateAsync("Kullanicilar/" + bulunanKayit.Key, veri);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBox.Show("Şifreniz başarıyla güncellendi! Giriş ekranına yönlendiriliyorsunuz.");

                    // 🟢 PROFESYONEL DÖNÜŞ: Yeni bir Form1 açmak yerine, arkada bekleyeni bulup gösteriyoruz
                    Form1 loginForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();

                    if (loginForm != null)
                    {
                        loginForm.Show(); // Mevcut olanı göster
                        this.Close();    // Bu formu kapat
                    }
                    else
                    {
                        // Eğer Form1 bir şekilde kapandıysa mecburen yeni açıyoruz
                        Form1 login = new Form1();
                        login.Show();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata: " + ex.Message);
            }
        }

        public class KullaniciModeli
        {
            public string Mail { get; set; }
            public string Sifre { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
        }

        private void FormForgetPassword_Load(object sender, EventArgs e) { }
    }
}