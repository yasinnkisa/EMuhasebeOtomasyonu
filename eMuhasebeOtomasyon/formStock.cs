using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMuhasebeOtomasyon
{
    public partial class formStock : Form
    {
        // 1. YAPILANDIRMA VE DEĞİŞKENLER
        string _kullaniciRolu;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        public formStock(string rol)
        {
            InitializeComponent();
            _kullaniciRolu = rol;
            KisitlamalariUygula();

            dgvStoklar.CellClick += dgvStoklar_CellClick;
        }

        private void formStock_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            VerileriListele();

            // 🟢 Gözlemci Modu Kısıtlamalarını Uygula
            GozlemciModuUygula(this.Controls);
        }

        // 🟢 MUHASEBE VE GÖZLEMCİ ROLÜ İÇİN KISITLAMA MANTIĞI
        private void GozlemciModuUygula(Control.ControlCollection controls)
        {
            // Muhasebe rolü de artık kısıtlamalara dahil edildi
            if (_kullaniciRolu != null &&
               (_kullaniciRolu.ToLower().Trim().Contains("gözlemci") || _kullaniciRolu.ToLower().Trim().Contains("muhasebe")))
            {
                foreach (Control ctrl in controls)
                {
                    if (ctrl is Button btn)
                    {
                        string btnName = btn.Name.ToLower();
                        if (btnName.Contains("ekle") || btnName.Contains("sil") ||
                            btnName.Contains("duzenle") || btnName.Contains("kaydet") ||
                            btnName.Contains("guncelle") || btnName.Contains("temizle"))
                        {
                            btn.Enabled = false;
                            btn.BackColor = Color.LightGray;
                        }
                    }

                    if (ctrl is TextBox txt && txt.Name != "txtStokAra") { txt.ReadOnly = true; }

                    // 🟢 TABLOYU (DATAGRIDVIEW) KİLİTLE
                    if (ctrl is DataGridView dgv)
                    {
                        dgv.ReadOnly = true;
                        dgv.AllowUserToAddRows = false;
                        dgv.AllowUserToDeleteRows = false;
                        dgv.AllowUserToResizeRows = false; // Satır boyutu sabitlendi
                        dgv.RowHeadersVisible = false; // Sol boşluk kaldırıldı
                        dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
                    }

                    if (ctrl.HasChildren)
                    {
                        GozlemciModuUygula(ctrl.Controls);
                    }
                }
            }
        }

        private void KisitlamalariUygula()
        {
            txtBarkod.MaxLength = 20; // Barkod sınırı
            txtBarkod.KeyPress += SadeceSayi_KeyPress;
            txtStokAdet.KeyPress += SadeceSayi_KeyPress;
            txtKritik.KeyPress += SadeceSayi_KeyPress;
            txtAlis.KeyPress += SadeceOndalikliSayi_KeyPress;
            txtSatis.KeyPress += SadeceOndalikliSayi_KeyPress;
        }

        private void SadeceSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void SadeceOndalikliSayi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',') e.Handled = true;
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(",")) e.Handled = true;
        }

        private async void VerileriListele()
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Stoklar");
                if (res.Body == "null") { dgvStoklar.DataSource = null; return; }

                var veriler = res.ResultAs<Dictionary<string, ProductModel>>();
                dgvStoklar.DataSource = veriler.Values.ToList();
                GridStiliniDuzenle();
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void GridStiliniDuzenle()
        {
            if (dgvStoklar.Columns.Count == 0) return;

            // 🟢 PROFESYONEL GÖRÜNÜM AYARLARI
            dgvStoklar.RowHeadersVisible = false; // Sol boşluk silindi
            dgvStoklar.AllowUserToResizeRows = false; // Satır boyutu sabitlendi

            dgvStoklar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStoklar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvStoklar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            if (dgvStoklar.Columns["UrunAdi"] != null) dgvStoklar.Columns["UrunAdi"].FillWeight = 200;
            string[] paraSutunlari = { "AlisFiyati", "SatisFiyati" };
            foreach (var sutun in paraSutunlari)
            {
                if (dgvStoklar.Columns[sutun] != null)
                {
                    dgvStoklar.Columns[sutun].DefaultCellStyle.Format = "C2";
                    dgvStoklar.Columns[sutun].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
            dgvStoklar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void btnStokEkle_Click(object sender, EventArgs e)
        {
            // İşlevsel kontrol
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("muh"))) return;

            if (string.IsNullOrWhiteSpace(txtBarkod.Text) || string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Lütfen alanları eksiksiz doldurunuz!");
                return;
            }
            try
            {
                var urun = ModelDoldur();
                await client.SetAsync("Stoklar/" + txtBarkod.Text, urun);
                MessageBox.Show("Ürün stoğa eklendi.");
                btnTemizle_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private async void btnStokDuzenle_Click(object sender, EventArgs e)
        {
            // İşlevsel kontrol
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("muh"))) return;

            if (string.IsNullOrEmpty(txtBarkod.Text)) return;
            try
            {
                var urun = ModelDoldur();
                await client.UpdateAsync("Stoklar/" + txtBarkod.Text, urun);
                MessageBox.Show("Ürün güncellendi.");

                // ReadOnly kontrolü güncellendi
                if (_kullaniciRolu != null && !_kullaniciRolu.Contains("gözlemci") && !_kullaniciRolu.Contains("muhasebe"))
                    txtBarkod.ReadOnly = false;

                VerileriListele();
            }
            catch (Exception ex) { MessageBox.Show("Güncelleme hatası: " + ex.Message); }
        }

        private async void btnStokSil_Click(object sender, EventArgs e)
        {
            // İşlevsel kontrol
            if (_kullaniciRolu != null && (_kullaniciRolu.ToLower().Contains("göz") || _kullaniciRolu.ToLower().Contains("muh"))) return;

            if (string.IsNullOrEmpty(txtBarkod.Text)) return;
            if (MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await client.DeleteAsync("Stoklar/" + txtBarkod.Text);
                btnTemizle_Click(null, null);
            }
        }

        private async void txtStokAra_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStokAra.Text)) { VerileriListele(); return; }
            try
            {
                string aranan = txtStokAra.Text.ToLower().Trim();
                FirebaseResponse res = await client.GetAsync("Stoklar");
                if (res.Body == "null") return;

                var veriler = res.ResultAs<Dictionary<string, ProductModel>>();
                var filtreli = veriler.Values.Where(x =>
                    (x.UrunAdi != null && x.UrunAdi.ToLower().Contains(aranan)) ||
                    (x.Barkod != null && x.Barkod.ToLower().Contains(aranan))
                ).ToList();

                dgvStoklar.DataSource = null;
                dgvStoklar.DataSource = filtreli;
                GridStiliniDuzenle();
            }
            catch { }
        }

        private void dgvStoklar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStoklar.Rows[e.RowIndex];
                txtBarkod.Text = row.Cells["Barkod"].Value?.ToString();
                txtUrunAdi.Text = row.Cells["UrunAdi"].Value?.ToString();
                txtStokAdet.Text = row.Cells["StokAdedi"].Value?.ToString();
                txtKritik.Text = row.Cells["KritikSeviye"].Value?.ToString();
                txtAlis.Text = row.Cells["AlisFiyati"].Value?.ToString();
                txtSatis.Text = row.Cells["SatisFiyati"].Value?.ToString();

                // ReadOnly kontrolü güncellendi
                if (_kullaniciRolu != null && !_kullaniciRolu.Contains("gözlemci") && !_kullaniciRolu.Contains("muhasebe"))
                    txtBarkod.ReadOnly = true;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtBarkod.Clear(); txtUrunAdi.Clear(); txtStokAdet.Clear();
            txtKritik.Clear(); txtAlis.Clear(); txtSatis.Clear(); txtStokAra.Clear();

            // ReadOnly kontrolü güncellendi
            if (_kullaniciRolu != null && !_kullaniciRolu.Contains("gözlemci") && !_kullaniciRolu.Contains("muhasebe"))
                txtBarkod.ReadOnly = false;

            VerileriListele();
        }

        private ProductModel ModelDoldur()
        {
            return new ProductModel
            {
                Barkod = txtBarkod.Text,
                UrunAdi = txtUrunAdi.Text,
                StokAdedi = int.TryParse(txtStokAdet.Text, out int s) ? s : 0,
                KritikSeviye = int.TryParse(txtKritik.Text, out int k) ? k : 0,
                AlisFiyati = double.TryParse(txtAlis.Text.Replace(".", ","), out double a) ? a : 0,
                SatisFiyati = double.TryParse(txtSatis.Text.Replace(".", ","), out double sa) ? sa : 0
            };
        }

        private async void btnKritikStok_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Stoklar");
                if (res.Body == "null") return;

                var veriler = res.ResultAs<Dictionary<string, ProductModel>>();
                var kritikListe = veriler.Values.Where(x => x.StokAdedi <= x.KritikSeviye).ToList();

                dgvStoklar.DataSource = null;
                dgvStoklar.DataSource = kritikListe;
                GridStiliniDuzenle();

                MessageBox.Show($"{kritikListe.Count} adet kritik seviyede ürün bulundu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Kritik stok listeleme hatası: " + ex.Message); }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}