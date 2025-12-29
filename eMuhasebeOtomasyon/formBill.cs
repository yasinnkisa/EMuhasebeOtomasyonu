using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMuhasebeOtomasyon
{
    public partial class formBill : Form
    {
        // 1. YAPILANDIRMA VE DEĞİŞKENLER
        string _kullaniciRolu; // Kullanıcı rolünü saklamak için

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        // 🟢 CONSTRUCTOR: Dışarıdan gelen rol bilgisini kabul eder
        public formBill(string rol)
        {
            InitializeComponent();
            _kullaniciRolu = rol; // Rol bilgisini hafızaya al

            try
            {
                client = new FireSharp.FirebaseClient(config);
                KisitlamalariUygula();

                dgvFaturalar.CellClick += dgvFaturalar_CellClick;
                txtAramaFatura.TextChanged += txtAramaFatura_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı Hatası: " + ex.Message);
            }
        }

        private void formBill_Load(object sender, EventArgs e)
        {
            if (cmbFaturaTipi.Items.Count > 0) cmbFaturaTipi.SelectedIndex = 0;
            rbTumu.Checked = true;
            VerileriListele();
            txtFaturaID.Clear();

            // 🟢 Gözlemci Modu Kısıtlamalarını Uygula
            GozlemciModuUygula(this.Controls);
        }

        // 🟢 GÖZLEMCİ MODU YARDIMCI METODU (Recursive/İç İçe Tarama)
        private void GozlemciModuUygula(Control.ControlCollection controls)
        {
            // Rol kontrolü (Gözlemci kelimesini içeren her durumda kısıtla)
            if (_kullaniciRolu != null &&
               (_kullaniciRolu.ToLower().Trim().Contains("gözlemci") || _kullaniciRolu.ToLower().Trim().Contains("gozlemci")))
            {
                foreach (Control ctrl in controls)
                {
                    // 1. BUTONLARI TAMAMEN KAPAT VE GRİ YAP
                    if (ctrl is Button btn)
                    {
                        string btnName = btn.Name.ToLower();
                        string btnText = btn.Text.ToLower();

                        if (btnName.Contains("kaydet") || btnName.Contains("sil") ||
                            btnName.Contains("ekle") || btnName.Contains("guncelle") ||
                            btnName.Contains("temizle") || btnName.Contains("goruntule") ||
                            btnText.Contains("kaydet") || btnText.Contains("sil"))
                        {
                            btn.Enabled = false;
                            btn.BackColor = Color.LightGray;
                        }
                    }

                    // 2. VERİ GİRİŞ ALANLARINI TAMAMEN KİLİTLE
                    if (ctrl is TextBox txt && txt.Name != "txtAramaFatura")
                    {
                        txt.ReadOnly = true;
                        txt.Enabled = false;
                        txt.BackColor = Color.FromArgb(240, 240, 240);
                    }

                    if (ctrl is ComboBox cmb) { cmb.Enabled = false; }
                    if (ctrl is DateTimePicker dtp) { dtp.Enabled = false; }

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
            dgvFaturalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFaturalar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvFaturalar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvFaturalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFaturalar.RowHeadersVisible = false;
            dgvFaturalar.ReadOnly = true;

            if (dgvFaturalar.Columns["ToplamTutar"] != null)
            {
                dgvFaturalar.Columns["ToplamTutar"].DefaultCellStyle.Format = "C2";
                // 🟢 HİZALAMA SOLA YATIK OLARAK KORUNDU
                dgvFaturalar.Columns["ToplamTutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            dgvFaturalar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        // --- 3. VERİ LİSTELEME VE FİLTRELEME ---
        private async void VerileriListele()
        {
            try
            {
                if (client == null) return;
                FirebaseResponse res = await client.GetAsync("Faturalar");

                if (res.Body == "null" || res.Body == "[]")
                {
                    dgvFaturalar.DataSource = null;
                    return;
                }

                var veriler = res.ResultAs<Dictionary<string, InvoiceModel>>();
                var liste = veriler.Values.ToList();

                if (rbAlisFaturasi.Checked)
                    liste = liste.Where(x => x.FaturaTipi != null && x.FaturaTipi.Trim().Equals("Alış", StringComparison.OrdinalIgnoreCase)).ToList();
                else if (rbSatisFaturasi.Checked)
                    liste = liste.Where(x => x.FaturaTipi != null && x.FaturaTipi.Trim().Equals("Satış", StringComparison.OrdinalIgnoreCase)).ToList();

                dgvFaturalar.DataSource = null;
                dgvFaturalar.DataSource = liste;
                GridStiliniDuzenle();
            }
            catch (Exception ex) { MessageBox.Show("Listeleme Hatası: " + ex.Message); }
        }

        // --- 4. CELLCLICK METODU ---
        private void dgvFaturalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvFaturalar.Rows[e.RowIndex];
                    txtFaturaID.Text = row.Cells["FaturaID"].Value?.ToString();
                    txtCariAdi.Text = row.Cells["CariAdi"].Value?.ToString();
                    txtToplamTutar.Text = row.Cells["ToplamTutar"].Value?.ToString();
                    cmbFaturaTipi.Text = row.Cells["FaturaTipi"].Value?.ToString();

                    if (DateTime.TryParse(row.Cells["Tarih"].Value?.ToString(), out DateTime dt))
                        dtpTarih.Value = dt;
                }
                catch (Exception ex) { MessageBox.Show("Veri seçme hatası: " + ex.Message); }
            }
        }

        // --- 5. KAYDET, SİL VE DİĞER İŞLEMLER ---
        private async void btnFaturaKaydet_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;

            if (string.IsNullOrWhiteSpace(txtCariAdi.Text) || string.IsNullOrWhiteSpace(txtToplamTutar.Text))
            {
                MessageBox.Show("Lütfen Cari Adı ve Tutar alanlarını doldurun!");
                return;
            }

            try
            {
                string id = string.IsNullOrWhiteSpace(txtFaturaID.Text) ? new Random().Next(100000, 999999).ToString() : txtFaturaID.Text;

                var fatura = new InvoiceModel
                {
                    FaturaID = id,
                    CariAdi = txtCariAdi.Text,
                    Tarih = dtpTarih.Value.ToShortDateString(),
                    ToplamTutar = double.TryParse(txtToplamTutar.Text, out double t) ? t : 0,
                    FaturaTipi = cmbFaturaTipi.SelectedItem?.ToString() ?? "Satış"
                };

                await client.SetAsync("Faturalar/" + id, fatura);
                MessageBox.Show("İşlem Başarılı!");
                btnTemizle_Click(null, null);
                VerileriListele();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private async void btnFaturaSil_Click_1(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;

            if (dgvFaturalar.CurrentRow != null)
            {
                string id = dgvFaturalar.CurrentRow.Cells["FaturaID"].Value.ToString();
                if (MessageBox.Show(id + " nolu faturayı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await client.DeleteAsync("Faturalar/" + id);
                    VerileriListele();
                    btnTemizle_Click(null, null);
                }
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;

            txtCariAdi.Clear();
            txtToplamTutar.Clear();
            txtAramaFatura.Clear();
            txtFaturaID.Clear();
            dtpTarih.Value = DateTime.Now;
            VerileriListele();
        }

        private async void txtAramaFatura_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAramaFatura.Text)) VerileriListele();
            else
            {
                try
                {
                    string aranan = txtAramaFatura.Text.ToLower().Trim();
                    FirebaseResponse res = await client.GetAsync("Faturalar");
                    if (res.Body == "null") return;
                    var veriler = res.ResultAs<Dictionary<string, InvoiceModel>>();
                    var filtreli = veriler.Values.Where(x => x.CariAdi.ToLower().Contains(aranan) || x.FaturaID.Contains(aranan)).ToList();
                    dgvFaturalar.DataSource = filtreli;
                }
                catch { }
            }
        }

        private void KisitlamalariUygula()
        {
            txtCariAdi.KeyPress += (s, e) => { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar)) e.Handled = true; };
            txtToplamTutar.KeyPress += (s, e) => { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',') e.Handled = true; };
        }

        private void rbTumu_CheckedChanged(object sender, EventArgs e) { if (rbTumu.Checked) VerileriListele(); }
        private void rbSatisFaturasi_CheckedChanged(object sender, EventArgs e) { if (rbSatisFaturasi.Checked) VerileriListele(); }
        private void rbAlisFaturasi_CheckedChanged(object sender, EventArgs e) { if (rbAlisFaturasi.Checked) VerileriListele(); }

        // 🟢 FATURA GÖRÜNTÜLEME MANTIĞI EKLENDİ
        private void btnFaturaGoruntule_Click(object sender, EventArgs e)
        {
            if (dgvFaturalar.CurrentRow != null)
            {
                string id = dgvFaturalar.CurrentRow.Cells["FaturaID"].Value?.ToString();
                string cari = dgvFaturalar.CurrentRow.Cells["CariAdi"].Value?.ToString();
                string tarih = dgvFaturalar.CurrentRow.Cells["Tarih"].Value?.ToString();
                string tutar = dgvFaturalar.CurrentRow.Cells["ToplamTutar"].Value?.ToString();
                string tip = dgvFaturalar.CurrentRow.Cells["FaturaTipi"].Value?.ToString();

                string detayMesaji = $"--- FATURA DETAYI ---\n\n" +
                                     $"Fatura ID: {id}\n" +
                                     $"Cari Adı: {cari}\n" +
                                     $"Tarih: {tarih}\n" +
                                     $"Fatura Tipi: {tip}\n" +
                                     $"Toplam Tutar: {tutar}\n\n" +
                                     "----------------------------";

                MessageBox.Show(detayMesaji, "Fatura Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen görüntülemek istediğiniz faturayı listeden seçin!", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}