using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace eMuhasebeOtomasyon
{
    public partial class formCost : Form
    {
        // 1. YAPILANDIRMA VE DEĞİŞKENLER
        string _kullaniciRolu; // Kullanıcı rolünü saklamak için

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;
        string seciliGiderID = "";

        // 🟢 CONSTRUCTOR: Dışarıdan gelen rol bilgisini kabul eder
        public formCost(string rol)
        {
            InitializeComponent();
            _kullaniciRolu = rol; // Rolü hafızaya al

            try
            {
                client = new FireSharp.FirebaseClient(config);
                KisitlamalariUygula();

                // Event Bağlantıları
                dgvGiderler.CellClick += dgvGiderler_CellClick;
                txtGiderAra.TextChanged += txtGiderAra_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Firebase bağlantı hatası: " + ex.Message);
            }
        }

        private void formCost_Load(object sender, EventArgs e)
        {
            if (cmbDonem.Items.Count > 0) cmbDonem.SelectedIndex = 2; // "Tümü"
            if (cmbKategori.Items.Count > 0) cmbKategori.SelectedIndex = 0;
            GiderleriListele();

            // 🟢 Gözlemci Modu Kısıtlamalarını Uygula
            GozlemciModuUygula(this.Controls);
        }

        // 🟢 GÖZLEMCİ MODU YARDIMCI METODU (Recursive/İç İçe Tarama)
        private void GozlemciModuUygula(Control.ControlCollection controls)
        {
            if (_kullaniciRolu != null &&
               (_kullaniciRolu.ToLower().Trim().Contains("gözlemci") || _kullaniciRolu.ToLower().Trim().Contains("gozlemci")))
            {
                foreach (Control ctrl in controls)
                {
                    // 1. BUTONLARI TAMAMEN KAPAT VE GRİ YAP
                    if (ctrl is Button btn)
                    {
                        string btnName = btn.Name.ToLower();
                        if (btnName.Contains("kaydet") || btnName.Contains("sil") ||
                            btnName.Contains("ekle") || btnName.Contains("temizle") ||
                            btnName.Contains("guncelle"))
                        {
                            btn.Enabled = false;
                            btn.BackColor = Color.LightGray;
                            btn.ForeColor = Color.DimGray;
                        }
                    }

                    // 2. VERİ GİRİŞ ALANLARINI TAMAMEN KİLİTLE
                    if (ctrl is TextBox txt && txt.Name != "txtGiderAra")
                    {
                        txt.ReadOnly = true;
                        txt.Enabled = false;
                        txt.BackColor = Color.FromArgb(240, 240, 240);
                    }

                    if (ctrl is ComboBox cmb && cmb.Name == "cmbGiderKategori")
                    {
                        cmb.Enabled = false;
                    }

                    if (ctrl is DateTimePicker dtp)
                    {
                        dtp.Enabled = false;
                    }

                    // 🟢 3. TABLOYU (DATAGRIDVIEW) KİLİTLE
                    if (ctrl is DataGridView dgv)
                    {
                        dgv.ReadOnly = true; // Hücrelerin değiştirilmesini engeller
                        dgv.AllowUserToAddRows = false; // Yeni satır eklemeyi kapatır
                        dgv.AllowUserToDeleteRows = false; // Satır silmeyi kapatır
                        dgv.EditMode = DataGridViewEditMode.EditProgrammatically; // Tıklamayla düzenlemeyi engeller
                    }

                    if (ctrl.HasChildren)
                    {
                        GozlemciModuUygula(ctrl.Controls);
                    }
                }
            }
        }

        // --- 2. GÖRÜNÜM VE TABLO AYARLARI ---
        private void GridStiliniDuzenle()
        {
            dgvGiderler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvGiderler.Columns["Aciklama"] != null)
            {
                dgvGiderler.Columns["Aciklama"].FillWeight = 200;
                dgvGiderler.Columns["Aciklama"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            if (dgvGiderler.Columns["GiderID"] != null) dgvGiderler.Columns["GiderID"].FillWeight = 70;
            if (dgvGiderler.Columns["GiderAdi"] != null) dgvGiderler.Columns["GiderAdi"].FillWeight = 150;
            if (dgvGiderler.Columns["Tutar"] != null)
            {
                dgvGiderler.Columns["Tutar"].FillWeight = 100;
                dgvGiderler.Columns["Tutar"].DefaultCellStyle.Format = "C2";
                dgvGiderler.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            dgvGiderler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGiderler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiderler.RowHeadersVisible = false;
        }

        private async void GiderleriListele()
        {
            try
            {
                if (client == null) return;
                FirebaseResponse res = await client.GetAsync("Giderler");
                if (res.Body == "null") { dgvGiderler.DataSource = null; return; }

                var veriler = res.ResultAs<Dictionary<string, CostModel>>();
                var liste = veriler.Values.ToList();
                DateTime bugun = DateTime.Now;

                if (cmbDonem.Text == "Bu Ay")
                {
                    liste = liste.Where(x => DateTime.TryParseExact(x.Tarih, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime d)
                                           && d.Month == bugun.Month && d.Year == bugun.Year).ToList();
                }
                else if (cmbDonem.Text == "Bu Yıl")
                {
                    liste = liste.Where(x => DateTime.TryParseExact(x.Tarih, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime d)
                                           && d.Year == bugun.Year).ToList();
                }

                if (cmbKategori.Text != "Tümü" && !string.IsNullOrEmpty(cmbKategori.Text))
                    liste = liste.Where(x => x.Kategori == cmbKategori.Text).ToList();

                if (!string.IsNullOrEmpty(txtGiderAra.Text))
                    liste = liste.Where(x => x.GiderAdi.ToLower().Contains(txtGiderAra.Text.ToLower())).ToList();

                dgvGiderler.DataSource = null;
                dgvGiderler.DataSource = liste;
                GridStiliniDuzenle();
            }
            catch { }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;

            try
            {
                if (string.IsNullOrWhiteSpace(txtGiderAdi.Text) || string.IsNullOrWhiteSpace(txtTutar.Text))
                {
                    MessageBox.Show("Gider adı ve tutar boş bırakılamaz!");
                    return;
                }
                var gider = new CostModel
                {
                    GiderID = string.IsNullOrEmpty(seciliGiderID) ? Guid.NewGuid().ToString().Substring(0, 6) : seciliGiderID,
                    GiderAdi = txtGiderAdi.Text,
                    Tutar = double.TryParse(txtTutar.Text, out double t) ? t : 0,
                    Kategori = cmbGiderKategori.Text,
                    Tarih = dtpTarih.Value.ToString("dd.MM.yyyy"),
                    Aciklama = txtAciklama.Text
                };
                await client.SetAsync("Giderler/" + gider.GiderID, gider);
                MessageBox.Show("İşlem Başarılı!");
                Temizle();
                GiderleriListele();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private async void btnGiderSil_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;

            if (dgvGiderler.CurrentRow != null)
            {
                string id = dgvGiderler.CurrentRow.Cells["GiderID"].Value.ToString();
                string ad = dgvGiderler.CurrentRow.Cells["GiderAdi"].Value.ToString();
                DialogResult onay = MessageBox.Show($"'{ad}' isimli gider kaydını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (onay == DialogResult.Yes)
                {
                    await client.DeleteAsync("Giderler/" + id);
                    MessageBox.Show("Gider başarıyla silindi.");
                    Temizle();
                    GiderleriListele();
                }
            }
            else MessageBox.Show("Lütfen silmek istediğiniz gideri tablodan seçin.");
        }

        private void dgvGiderler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGiderler.Rows[e.RowIndex];
                seciliGiderID = row.Cells["GiderID"].Value.ToString();
                txtGiderAdi.Text = row.Cells["GiderAdi"].Value.ToString();
                txtTutar.Text = row.Cells["Tutar"].Value.ToString();
                cmbGiderKategori.Text = row.Cells["Kategori"].Value.ToString();
                txtAciklama.Text = row.Cells["Aciklama"].Value?.ToString() ?? "";
                if (DateTime.TryParseExact(row.Cells["Tarih"].Value.ToString(), "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime dt))
                    dtpTarih.Value = dt;
            }
        }

        private void btnGiderRaporu_Click(object sender, EventArgs e)
        {
            if (dgvGiderler.Rows.Count == 0) return;
            double toplamGider = 0;
            int kayitSayisi = 0;
            Dictionary<string, double> kategoriAnalizi = new Dictionary<string, double>();
            try
            {
                foreach (DataGridViewRow row in dgvGiderler.Rows)
                {
                    if (row.Cells["Tutar"].Value != null)
                    {
                        double tutar = Convert.ToDouble(row.Cells["Tutar"].Value);
                        string kategori = row.Cells["Kategori"].Value.ToString();
                        toplamGider += tutar;
                        kayitSayisi++;
                        if (kategoriAnalizi.ContainsKey(kategori)) kategoriAnalizi[kategori] += tutar;
                        else kategoriAnalizi.Add(kategori, tutar);
                    }
                }
                var enCok = kategoriAnalizi.OrderByDescending(x => x.Value).FirstOrDefault();
                string rapor = $@"📊 GİDER ANALİZ RAPORU
--------------------------------------------------
💰 Toplam Harcama: {toplamGider:C2}
📝 İşlem Sayısı: {kayitSayisi} Adet
🔝 En Çok Harcanan Kategori: {enCok.Key} ({enCok.Value:C2})
--------------------------------------------------";
                MessageBox.Show(rapor, "Hızlı Analiz Özeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Rapor Hatası: " + ex.Message); }
        }

        private void KisitlamalariUygula()
        {
            txtTutar.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',') e.Handled = true;
                if (e.KeyChar == ',' && txtTutar.Text.Contains(",")) e.Handled = true;
            };
        }

        private void Temizle()
        {
            txtGiderAdi.Clear(); txtTutar.Clear(); txtAciklama.Clear();
            cmbGiderKategori.SelectedIndex = -1; dtpTarih.Value = DateTime.Now;
            seciliGiderID = "";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;
            Temizle();
        }
        private void cmbDonem_SelectedIndexChanged(object sender, EventArgs e) { GiderleriListele(); }
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e) { GiderleriListele(); }
        private void txtGiderAra_TextChanged(object sender, EventArgs e) { GiderleriListele(); }
    }
}