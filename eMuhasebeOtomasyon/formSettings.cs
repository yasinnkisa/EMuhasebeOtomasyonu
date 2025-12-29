using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using static eMuhasebeOtomasyon.Form1;
using static eMuhasebeOtomasyon.lazımlık;

namespace eMuhasebeOtomasyon
{
    public partial class formSettings : Form
    {
        string _kullaniciRolu;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public formSettings(string rol)
        {
            InitializeComponent();
            _kullaniciRolu = rol;
            client = new FireSharp.FirebaseClient(config);
        }

        private void formSettings_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_kullaniciRolu) &&
                !_kullaniciRolu.ToLower().Contains("admin"))
            {
                btnKullanicilarYetkiler.Visible = false;
                btnVeritabaniAyarlari.Visible = false;
            }
            btnGenelAyarlar_Click(null, null);
        }

        private void btnKullaniciDegistir_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kullanıcı değiştirmek istediğinize emin misiniz?",
                "Kullanıcı Değiştir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (secenek == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private async void btnGenelAyarlar_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("UygulamaAyarlari");
                if (res.Body != "null")
                {
                    var ayar = res.ResultAs<AppConfig>();
                    var ayarListesi = new List<object>
                    {
                        new { Parametre = "Şirket Ünvanı", Değer = ayar.SirketAdi },
                        new { Parametre = "Yazılım Versiyonu", Değer = ayar.Versiyon },
                        new { Parametre = "Veritabanı Durumu", Değer = "Bağlantı Sağlandı" },
                        new { Parametre = "Lisans Tipi", Değer = "Kurumsal / Aktif" }
                    };
                    dgvKullanicilar.DataSource = null;
                    dgvKullanicilar.DataSource = ayarListesi;
                    TabloyuTamBoyutYap();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ayarlar Hatası: " + ex.Message); }
        }

        // 🟢 HESAP PLANI BUTONU: YETKİYE GÖRE FİLTRELENMİŞ GÖRÜNÜM
        private async void btnMuhasebeKodlari_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Kullanicilar");

                if (res.Body == "null")
                {
                    dgvKullanicilar.DataSource = null;
                    MessageBox.Show("Sistemde kayıtlı kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var veriler = res.ResultAs<Dictionary<string, KullaniciModel>>();
                IEnumerable<KullaniciModel> listSource = veriler.Values;

                // 🔒 GİZLİLİK FİLTRESİ: Admin değilse sadece kendi mailini görsün
                if (!_kullaniciRolu.ToLower().Contains("admin"))
                {
                    string suAnkiMail = eMuhasebeOtomasyon.Form1.GirisYapanEmail.ToLower();
                    listSource = listSource.Where(u => u.Mail != null && u.Mail.ToLower() == suAnkiMail);
                }

                var aboneListesi = listSource.Select(u => new
                {
                    Kullanıcı_Maili = u.Mail,
                    Yetki_Rolü = u.Rol,
                    Hesap_Planı_Durumu = u.Rol != null && u.Rol.ToLower().Contains("admin") ? "Abone (Full Paket)" : "Hesap planı tanımlanmamış."
                }).ToList();

                dgvKullanicilar.DataSource = null;
                dgvKullanicilar.DataSource = aboneListesi;

                TabloyuTamBoyutYap();

                if (dgvKullanicilar.Columns.Count > 0)
                {
                    dgvKullanicilar.Columns[0].HeaderText = "Kullanıcı E-Posta";
                    dgvKullanicilar.Columns[1].HeaderText = "Sistem Rolü";
                    dgvKullanicilar.Columns[2].HeaderText = "Abonelik / Hesap Planı";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }

        private async void btnKullanicilarYetkiler_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Kullanicilar");
                if (res.Body != "null")
                {
                    var veriler = res.ResultAs<Dictionary<string, KullaniciModel>>();
                    dgvKullanicilar.DataSource = veriler.Values.ToList();
                    TabloyuTamBoyutYap();
                }
            }
            catch (Exception ex) { MessageBox.Show("Kullanıcı Listesi Hatası: " + ex.Message); }
        }

        private async void btnVeritabaniAyarlari_Click(object sender, EventArgs e)
        {
            try
            {
                List<DatabaseStatusModel> istatistikler = new List<DatabaseStatusModel>();
                FirebaseResponse resCari = await client.GetAsync("Cariler");
                int cariCount = resCari.Body != "null" ? resCari.ResultAs<Dictionary<string, dynamic>>().Count : 0;
                istatistikler.Add(new DatabaseStatusModel { TabloAdi = "Müşteri Kayıtları", KayitSayisi = cariCount.ToString(), Durum = "Aktif" });

                FirebaseResponse resFatura = await client.GetAsync("Faturalar");
                int faturaCount = resFatura.Body != "null" ? resFatura.ResultAs<Dictionary<string, dynamic>>().Count : 0;
                istatistikler.Add(new DatabaseStatusModel { TabloAdi = "Fatura İşlemleri", KayitSayisi = faturaCount.ToString(), Durum = "Aktif" });

                FirebaseResponse resStok = await client.GetAsync("Stoklar");
                int stokCount = resStok.Body != "null" ? resStok.ResultAs<Dictionary<string, dynamic>>().Count : 0;
                istatistikler.Add(new DatabaseStatusModel { TabloAdi = "Ürün/Stok Kartları", KayitSayisi = stokCount.ToString(), Durum = "Aktif" });

                FirebaseResponse resGider = await client.GetAsync("Giderler");
                int giderCount = resGider.Body != "null" ? resGider.ResultAs<Dictionary<string, dynamic>>().Count : 0;
                istatistikler.Add(new DatabaseStatusModel { TabloAdi = "Gider Kayıtları", KayitSayisi = giderCount.ToString(), Durum = "İşleniyor" });

                dgvKullanicilar.DataSource = null;
                dgvKullanicilar.DataSource = istatistikler;
                TabloyuTamBoyutYap();
            }
            catch (Exception ex) { MessageBox.Show("Analiz Hatası: " + ex.Message); }
        }

        private void TabloyuTamBoyutYap()
        {
            if (dgvKullanicilar.Columns.Count == 0) return;

            dgvKullanicilar.ReadOnly = true;
            dgvKullanicilar.AllowUserToAddRows = false;
            dgvKullanicilar.AllowUserToDeleteRows = false;
            dgvKullanicilar.AllowUserToResizeRows = false;
            dgvKullanicilar.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvKullanicilar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKullanicilar.RowHeadersVisible = false;
            dgvKullanicilar.BorderStyle = BorderStyle.None;

            dgvKullanicilar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKullanicilar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKullanicilar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKullanicilar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvKullanicilar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
        }
    }

    public class KullaniciModel { 
        public string Ad { get; set; } 
        public string Soyad { get; set; } 
        public string TC { get; set; } 
        public string Sifre { get; set; } 
        public string Rol { get; set; } 
        public string Mail { get; set; } 
    
    }
    public class AppConfig { 
        public string SirketAdi { get; set; }
        public string Versiyon { get; set; } 
    }

    public class AccountPlanModel { 
        public string Kod { get; set; }
        public string Aciklama { get; set; } 
    }

    public class DatabaseStatusModel { 
        public string TabloAdi { get; set; }
        public string KayitSayisi { get; set; } 
        public string Durum { get; set; } 
    }
}