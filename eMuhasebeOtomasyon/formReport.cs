using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static eMuhasebeOtomasyon.formCurrent;

namespace eMuhasebeOtomasyon
{
    public partial class formReport : Form
    {
        // 1. YAPILANDIRMA VE DEĞİŞKENLER
        string _kullaniciRolu;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public formReport(string rol)
        {
            InitializeComponent();
            _kullaniciRolu = rol;
            try { client = new FireSharp.FirebaseClient(config); }
            catch (Exception ex) { MessageBox.Show("Firebase Bağlantı Hatası: " + ex.Message); }
        }

        private void formReport_Load(object sender, EventArgs e)
        {
            GozlemciModuUygula(this.Controls);
        }

        private void GozlemciModuUygula(Control.ControlCollection controls)
        {
            // Bu metot artık sadece butonlar veya diğer kontroller için rol bazlı çalışır.
            // DataGridView kilidi aşağıda tüm roller için aktif edildi.
            if (_kullaniciRolu != null &&
               (_kullaniciRolu.ToLower().Trim().Contains("gözlemci") || _kullaniciRolu.ToLower().Trim().Contains("gozlemci")))
            {
                foreach (Control ctrl in controls)
                {
                    if (ctrl.HasChildren)
                    {
                        GozlemciModuUygula(ctrl.Controls);
                    }
                }
            }
        }

        // --- 🟢 ORTAK TABLO FORMATLAMA VE GÖRSELLEŞTİRME METODU ---
        private void RaporTablosunuFormatla()
        {
            if (dgvRaporlar.Columns.Count == 0) return;

            // 🟢 HANGİ ROL OLURSA OLSUN TABLOYU KİLİTLE
            dgvRaporlar.ReadOnly = true;
            dgvRaporlar.AllowUserToAddRows = false;
            dgvRaporlar.AllowUserToDeleteRows = false;
            dgvRaporlar.AllowUserToResizeRows = false; // Satır boyutu sabitlendi
            dgvRaporlar.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvRaporlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRaporlar.RowHeadersVisible = false; // Sol boşluğu kaldırır

            dgvRaporlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRaporlar.BorderStyle = BorderStyle.None;
            dgvRaporlar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRaporlar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            string[] paraSutunlari = { "Bakiye", "Tutar", "ToplamTutar", "AlisFiyati", "SatisFiyati" };
            foreach (var sutun in paraSutunlari)
            {
                if (dgvRaporlar.Columns[sutun] != null)
                {
                    dgvRaporlar.Columns[sutun].DefaultCellStyle.Format = "C2";
                    dgvRaporlar.Columns[sutun].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private async void btnRaporMaliDurum_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("KasaBanka");
                if (res.Body == "null") { dgvRaporlar.DataSource = null; return; }
                var veriler = res.ResultAs<Dictionary<string, AccountModel>>();
                var liste = veriler.Values.ToList();
                double toplamKasa = liste.Where(x => x.HesapTuru == "Kasa").Sum(x => x.Bakiye);
                double toplamBanka = liste.Where(x => x.HesapTuru == "Banka").Sum(x => x.Bakiye);
                dgvRaporlar.DataSource = liste;
                RaporTablosunuFormatla();
                string ozet = $"💰 Kasa: {toplamKasa:C2}\n💳 Banka: {toplamBanka:C2}\n✨ Toplam: {(toplamKasa + toplamBanka):C2}";
                MessageBox.Show(ozet, "Mali Durum Özeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private async void btnRaporGelirGider_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse resFatura = await client.GetAsync("Faturalar");
                double toplamGelir = 0;
                if (resFatura.Body != "null")
                {
                    var faturalar = resFatura.ResultAs<Dictionary<string, InvoiceModel>>();
                    toplamGelir = faturalar.Values.Where(x => x.FaturaTipi == "Satış").Sum(x => x.ToplamTutar);
                }
                FirebaseResponse resGider = await client.GetAsync("Giderler");
                double toplamGider = 0;
                if (resGider.Body != "null")
                {
                    var giderler = resGider.ResultAs<Dictionary<string, CostModel>>();
                    toplamGider = giderler.Values.Sum(x => x.Tutar);
                }
                var analizListesi = new List<object>
                {
                    new { Kalem = "Toplam Satış Geliri", Tutar = toplamGelir, Tip = "Gelir (+)" },
                    new { Kalem = "Toplam İşletme Gideri", Tutar = toplamGider, Tip = "Gider (-)" },
                    new { Kalem = "NET DURUM", Tutar = (toplamGelir - toplamGider), Tip = (toplamGelir >= toplamGider ? "Kâr ✅" : "Zarar ❌") }
                };
                dgvRaporlar.DataSource = analizListesi;
                RaporTablosunuFormatla();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private async void btnRaporStok_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Stoklar");
                if (res.Body == "null") { dgvRaporlar.DataSource = null; return; }
                var veriler = res.ResultAs<Dictionary<string, ProductModel>>();
                var kritikListe = veriler.Values.Where(x => x.StokAdedi <= x.KritikSeviye).ToList();
                dgvRaporlar.DataSource = kritikListe;
                RaporTablosunuFormatla();
                if (kritikListe.Count > 0)
                    MessageBox.Show($"{kritikListe.Count} adet ürün kritik seviyenin altında!", "Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private async void btnRaporCari_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Cariler");
                if (res.Body == "null") { dgvRaporlar.DataSource = null; return; }
                var liste = res.ResultAs<Dictionary<string, CariModel>>().Values.ToList();
                dgvRaporlar.DataSource = liste;
                RaporTablosunuFormatla();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private async void btnRaporFatura_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Faturalar");
                if (res.Body == "null") { dgvRaporlar.DataSource = null; return; }
                var liste = res.ResultAs<Dictionary<string, InvoiceModel>>().Values.ToList();
                dgvRaporlar.DataSource = liste;
                RaporTablosunuFormatla();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}