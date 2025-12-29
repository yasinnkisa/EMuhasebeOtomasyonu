using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.VisualBasic; // Interaction.InputBox için gerekli
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eMuhasebeOtomasyon
{
    public partial class formBank : Form
    {
        // 1. YAPILANDIRMA VE DEĞİŞKENLER
        string _kullaniciRolu;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;
        private string seciliHesapID = "";

        public formBank(string rol)
        {
            InitializeComponent();
            _kullaniciRolu = rol;

            try
            {
                client = new FireSharp.FirebaseClient(config);
                dgvHesaplar.CellClick += dgvHesaplar_CellClick;
                txtBakiye.KeyPress += TxtBakiye_KeyPress;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Firebase Bağlantı Hatası: " + ex.Message);
            }
        }

        private void formBank_Load(object sender, EventArgs e)
        {
            rbTumu.Checked = true;
            BankaListesiniDoldur();
            VerileriListele();

            GozlemciModuUygula(this.Controls);
        }

        private void GozlemciModuUygula(Control.ControlCollection controls)
        {
            if (_kullaniciRolu != null &&
               (_kullaniciRolu.ToLower().Trim().Contains("gözlemci") || _kullaniciRolu.ToLower().Trim().Contains("gozlemci")))
            {
                foreach (Control ctrl in controls)
                {
                    if (ctrl is Button btn)
                    {
                        string btnName = btn.Name.ToLower();
                        string btnText = btn.Text.ToLower();

                        if (btnName.Contains("ekle") || btnName.Contains("sil") ||
                            btnName.Contains("giris") || btnName.Contains("cikis") ||
                            btnName.Contains("transfer") || btnName.Contains("guncelle") ||
                            btnName.Contains("temizle") || btnName.Contains("kaydet") ||
                            btnName.Contains("yenihesap") ||
                            btnText.Contains("ekle") || btnText.Contains("sil") || btnText.Contains("kaydet"))
                        {
                            btn.Enabled = false;
                            btn.BackColor = Color.LightGray;
                            btn.ForeColor = Color.DimGray;
                        }
                    }

                    if (ctrl is TextBox txt)
                    {
                        txt.ReadOnly = true;
                        txt.Enabled = false;
                        txt.BackColor = Color.WhiteSmoke;
                    }

                    if (ctrl is ComboBox cmb)
                    {
                        cmb.Enabled = false;
                    }

                    if (ctrl is DataGridView dgv)
                    {
                        dgv.ReadOnly = true;
                        dgv.AllowUserToAddRows = false;
                        dgv.AllowUserToDeleteRows = false;
                        dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
                        dgv.RowHeadersVisible = false;
                        // 🟢 SATIR BOYUTLANDIRMASINI KAPAT
                        dgv.AllowUserToResizeRows = false;
                    }

                    if (ctrl.HasChildren)
                    {
                        GozlemciModuUygula(ctrl.Controls);
                    }
                }
            }
        }

        private void TxtBakiye_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')) e.Handled = true;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1)) e.Handled = true;
        }

        private void BankaListesiniDoldur()
        {
            cmbHesapAdi.Items.Clear();
            cmbHesapAdi.Items.AddRange(new string[] { "Ziraat Bankası", "VakıfBank", "Halkbank", "İş Bankası", "Garanti BBVA", "Akbank", "Yapı Kredi", "QNB Finansbank", "Merkez Kasa" });
            if (cmbHesapAdi.Items.Count > 0) cmbHesapAdi.SelectedIndex = 0;
        }

        private async void VerileriListele()
        {
            try
            {
                if (client == null) return;
                FirebaseResponse res = await client.GetAsync("KasaBanka");
                if (res.Body == "null") { dgvHesaplar.DataSource = null; return; }

                var veriler = res.ResultAs<Dictionary<string, AccountModel>>();
                var liste = veriler.Values.ToList();

                if (rbBankaHesaplari.Checked)
                    liste = liste.Where(x => x.HesapTuru == "Banka").ToList();
                else if (rbKasaHesaplari.Checked)
                    liste = liste.Where(x => x.HesapTuru == "Kasa").ToList();

                dgvHesaplar.DataSource = null;
                dgvHesaplar.DataSource = liste;

                dgvHesaplar.RowHeadersVisible = false;
                // 🟢 TÜM KULLANICILAR İÇİN SATIR BOYUTLANDIRMAYI SABİTLE
                dgvHesaplar.AllowUserToResizeRows = false;

                dgvHesaplar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvHesaplar.Columns["HesapAdi"] != null) dgvHesaplar.Columns["HesapAdi"].FillWeight = 180;
                if (dgvHesaplar.Columns["Aciklama"] != null) dgvHesaplar.Columns["Aciklama"].FillWeight = 200;
                if (dgvHesaplar.Columns["Bakiye"] != null)
                {
                    dgvHesaplar.Columns["Bakiye"].DefaultCellStyle.Format = "C2";
                    dgvHesaplar.Columns["Bakiye"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                dgvHesaplar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
            catch { }
        }

        private void dgvHesaplar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHesaplar.Rows[e.RowIndex];
                seciliHesapID = row.Cells["HesapID"].Value?.ToString();
                cmbHesapAdi.Text = row.Cells["HesapAdi"].Value?.ToString();
                cmbHesapTuru.Text = row.Cells["HesapTuru"].Value?.ToString();
                txtBakiye.Text = row.Cells["Bakiye"].Value?.ToString();
                txtAciklama.Text = row.Cells["Aciklama"].Value?.ToString();
            }
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;
            if (string.IsNullOrEmpty(cmbHesapAdi.Text) || string.IsNullOrEmpty(cmbHesapTuru.Text))
            {
                MessageBox.Show("Lütfen Hesap Adı ve Türünü seçin.");
                return;
            }

            string id = string.IsNullOrEmpty(seciliHesapID) ? Guid.NewGuid().ToString().Substring(0, 6) : seciliHesapID;
            var hesap = new AccountModel
            {
                HesapID = id,
                HesapAdi = cmbHesapAdi.Text,
                HesapTuru = cmbHesapTuru.Text,
                Bakiye = double.TryParse(txtBakiye.Text, out double b) ? b : 0,
                Aciklama = txtAciklama.Text
            };

            await client.SetAsync("KasaBanka/" + id, hesap);
            MessageBox.Show(string.IsNullOrEmpty(seciliHesapID) ? "Hesap başarıyla eklendi." : "Hesap başarıyla güncellendi.");
            btnTemizle_Click(null, null);
            VerileriListele();
        }

        private async void btnHesapSil_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;
            if (string.IsNullOrEmpty(seciliHesapID))
            {
                MessageBox.Show("Lütfen silmek istediğiniz hesabı tablodan seçin.");
                return;
            }

            if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await client.DeleteAsync("KasaBanka/" + seciliHesapID);
                btnTemizle_Click(null, null);
                VerileriListele();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;
            seciliHesapID = "";
            cmbHesapAdi.SelectedIndex = 0;
            cmbHesapTuru.SelectedIndex = -1;
            txtBakiye.Clear();
            txtAciklama.Clear();
            VerileriListele();
        }

        private async void btnParaGiris_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;
            if (string.IsNullOrEmpty(seciliHesapID)) { MessageBox.Show("Lütfen önce bir hesap seçin."); return; }
            string m = Interaction.InputBox("Giriş yapılacak miktarı yazın:", "Para Girişi", "0");
            if (double.TryParse(m, out double g) && g > 0)
            {
                double mevcut = double.Parse(txtBakiye.Text);
                await client.SetAsync($"KasaBanka/{seciliHesapID}/Bakiye", mevcut + g);
                VerileriListele();
                btnTemizle_Click(null, null);
            }
        }

        private async void btnParaCikis_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;
            if (string.IsNullOrEmpty(seciliHesapID)) { MessageBox.Show("Lütfen önce bir hesap seçin."); return; }
            string m = Interaction.InputBox("Çıkış yapılacak miktarı yazın:", "Para Çıkışı", "0");
            if (double.TryParse(m, out double c) && c > 0)
            {
                double mevcut = double.Parse(txtBakiye.Text);
                if (mevcut >= c)
                {
                    await client.SetAsync($"KasaBanka/{seciliHesapID}/Bakiye", mevcut - c);
                    VerileriListele();
                    btnTemizle_Click(null, null);
                }
                else MessageBox.Show("Hata: Hesapta yeterli bakiye yok!");
            }
        }

        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("goz"))) return;
            if (string.IsNullOrEmpty(seciliHesapID)) { MessageBox.Show("Lütfen önce kaynak hesabı seçin."); return; }
            double kaynakBakiye = double.Parse(txtBakiye.Text);
            string hedefID = Interaction.InputBox("Paranın gönderileceği Hedef Hesap ID'sini girin:", "Para Transferi");
            string tutar = Interaction.InputBox("Transfer edilecek miktar:", "Transfer", "0");

            if (double.TryParse(tutar, out double m) && m > 0 && kaynakBakiye >= m)
            {
                FirebaseResponse res = await client.GetAsync("KasaBanka/" + hedefID);
                if (res.Body == "null") { MessageBox.Show("Hata: Hedef hesap bulunamadı!"); return; }

                var hedef = res.ResultAs<AccountModel>();
                await client.SetAsync($"KasaBanka/{seciliHesapID}/Bakiye", kaynakBakiye - m);
                await client.SetAsync($"KasaBanka/{hedefID}/Bakiye", hedef.Bakiye + m);
                VerileriListele();
                btnTemizle_Click(null, null);
                MessageBox.Show("Transfer işlemi başarıyla tamamlandı.");
            }
            else if (kaynakBakiye < m) MessageBox.Show("Yetersiz bakiye!");
        }

        private void rbBankaHesaplari_CheckedChanged(object sender, EventArgs e) { if (rbBankaHesaplari.Checked) VerileriListele(); }
        private void rbKasaHesaplari_CheckedChanged(object sender, EventArgs e) { if (rbKasaHesaplari.Checked) VerileriListele(); }
        private void rbTumu_CheckedChanged(object sender, EventArgs e) { if (rbTumu.Checked) VerileriListele(); }
    }
}