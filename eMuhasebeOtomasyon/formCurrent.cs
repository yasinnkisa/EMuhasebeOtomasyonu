using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing;

namespace eMuhasebeOtomasyon
{
    public partial class formCurrent : Form
    {
        // 1. YAPILANDIRMA VE DEĞİŞKENLER
        string _rol;
        IFirebaseClient client;

        static bool mesajGosterildi = false;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public formCurrent(string rol)
        {
            InitializeComponent();
            _rol = !string.IsNullOrEmpty(rol) ? rol.ToLower().Trim() : "";
            KisitlamalariUygula();

            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
        }

        private void formCurrent_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            MenuYetkileriniAyarla(this.Controls);
            VerileriListele();
        }

        private void MenuYetkileriniAyarla(Control.ControlCollection controls)
        {
            if (_rol.Contains("gözlemci"))
            {
                foreach (Control ctrl in controls)
                {
                    if (ctrl is Button btn)
                    {
                        string btnName = btn.Name.ToLower();
                        if (btnName.Contains("kaydet") || btnName.Contains("sil") ||
                            btnName.Contains("guncelle") || btnName.Contains("ekle"))
                        {
                            btn.Enabled = false;
                            btn.BackColor = Color.LightGray;
                        }
                    }

                    if (ctrl is TextBox txt && txt.Name != "textBox5") { txt.ReadOnly = true; }
                    if (ctrl is RichTextBox rtxt) { rtxt.ReadOnly = true; }
                    if (ctrl is MaskedTextBox mtxt) { mtxt.ReadOnly = true; }

                    // 🟢 GÖZLEMCİ İÇİN TABLOYU KİLİTLE VE BAŞLIĞI GİZLE
                    if (ctrl is DataGridView dgv)
                    {
                        dgv.ReadOnly = true;
                        dgv.RowHeadersVisible = false; // Sol boşluğu kaldırır
                    }

                    if (ctrl.HasChildren)
                    {
                        MenuYetkileriniAyarla(ctrl.Controls);
                    }
                }

                if (!mesajGosterildi)
                {
                    MessageBox.Show("Gözlemci Modu: Veri değiştirme yetkiniz yoktur.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mesajGosterildi = true;
                }
            }
        }

        private void KisitlamalariUygula()
        {
            textBox4.MaxLength = 11;
            textBox4.KeyPress += SadeceSayi_KeyPress;
            txtAd.KeyPress += SadeceHarf_KeyPress;
            txtSoyad.KeyPress += SadeceHarf_KeyPress;
            mskTelefon.KeyPress += SadeceSayi_KeyPress;
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

        private async void VerileriListele()
        {
            try
            {
                FirebaseResponse res = await client.GetAsync("Cariler");
                if (res.Body == "null") { dataGridView2.DataSource = null; return; }

                Dictionary<string, CariModel> veriler = res.ResultAs<Dictionary<string, CariModel>>();
                dataGridView2.DataSource = veriler.Values.ToList();
                TabloAyarlariniYap();
            }
            catch (Exception ex) { MessageBox.Show("Listeleme hatası: " + ex.Message); }
        }

        private void TabloAyarlariniYap()
        {
            if (dataGridView2.Columns.Count > 0)
            {
                // 🟢 SOLDAKİ GEREKSİZ BOŞLUĞU SİLEN KOMUT
                dataGridView2.RowHeadersVisible = false;

                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dataGridView2.Columns["Mail"] != null) dataGridView2.Columns["Mail"].FillWeight = 150;
                if (dataGridView2.Columns["TC"] != null) dataGridView2.Columns["TC"].FillWeight = 100;
                if (dataGridView2.Columns["Ad"] != null) dataGridView2.Columns["Ad"].FillWeight = 80;
                if (dataGridView2.Columns["Soyad"] != null) dataGridView2.Columns["Soyad"].FillWeight = 80;
                if (dataGridView2.Columns["Adres"] != null) dataGridView2.Columns["Adres"].Visible = false;

                dataGridView2.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) ||
                textBox4.Text.Length != 11 || string.IsNullOrWhiteSpace(richTextBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurun!");
                return;
            }

            var veri = modelDoldur();
            SetResponse response = await client.SetAsync("Cariler/" + textBox4.Text, veri);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Müşteri başarıyla kaydedildi.");
                VerileriListele();
                TemizleSagPanel();
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Lütfen tablodan güncellenecek bir müşteri seçin.");
                return;
            }

            var guncelVeri = modelDoldur();
            FirebaseResponse response = await client.UpdateAsync("Cariler/" + guncelVeri.TC, guncelVeri);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Değişiklikler kaydedildi.");
                VerileriListele();
            }
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text)) return;

            if (MessageBox.Show("Seçili cari kaydını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FirebaseResponse response = await client.DeleteAsync("Cariler/" + textBox4.Text);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Müşteri silindi.");
                    TemizleSagPanel();
                    VerileriListele();
                }
            }
        }

        private async void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text)) VerileriListele();
            else await AramaYap();
        }

        private async Task AramaYap()
        {
            try
            {
                string aramaTerimi = textBox5.Text.ToLower(CultureInfo.InvariantCulture).Trim();
                FirebaseResponse res = await client.GetAsync("Cariler");
                if (res.Body == "null") return;

                var veriler = res.ResultAs<Dictionary<string, dynamic>>();
                var filtreliListe = new List<CariModel>();

                foreach (var item in veriler)
                {
                    var cari = new CariModel
                    {
                        Ad = item.Value.Ad?.ToString() ?? "",
                        Soyad = item.Value.Soyad?.ToString() ?? "",
                        TC = item.Value.TC?.ToString() ?? "",
                        Telefon = item.Value.Telefon?.ToString() ?? "",
                        Mail = item.Value.Mail?.ToString() ?? "",
                        Adres = item.Value.Adres?.ToString() ?? ""
                    };

                    if (cari.Ad.ToLower().Contains(aramaTerimi) || cari.Soyad.ToLower().Contains(aramaTerimi) || cari.TC.Contains(aramaTerimi))
                        filtreliListe.Add(cari);
                }

                dataGridView2.DataSource = null;
                dataGridView2.DataSource = filtreliListe;
                TabloAyarlariniYap();
            }
            catch { }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtAd.Text = row.Cells["Ad"].Value?.ToString();
                txtSoyad.Text = row.Cells["Soyad"].Value?.ToString();
                textBox4.Text = row.Cells["TC"].Value?.ToString();
                mskTelefon.Text = row.Cells["Telefon"].Value?.ToString();
                textBox3.Text = row.Cells["Mail"].Value?.ToString();
                richTextBox1.Text = row.Cells["Adres"].Value?.ToString();

                if (!_rol.Contains("gözlemci")) textBox4.ReadOnly = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            TemizleSagPanel();
            VerileriListele();
        }

        private CariModel modelDoldur()
        {
            return new CariModel
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                TC = textBox4.Text,
                Telefon = mskTelefon.Text,
                Mail = textBox3.Text,
                Adres = richTextBox1.Text
            };
        }

        private void TemizleSagPanel()
        {
            txtAd.Clear(); txtSoyad.Clear(); textBox4.Clear();
            mskTelefon.Clear(); textBox3.Clear(); richTextBox1.Clear();
            if (!_rol.Contains("gözlemci")) textBox4.ReadOnly = false;
        }

        public class CariModel
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Telefon { get; set; }
            public string Mail { get; set; }
            public string TC { get; set; }
            public string Adres { get; set; }
        }
    }
}