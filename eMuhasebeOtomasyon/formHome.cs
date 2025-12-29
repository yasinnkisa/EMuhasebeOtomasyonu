using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace eMuhasebeOtomasyon
{
    public partial class formHome : Form
    {
        IFirebaseClient client;
        Panel pnlLoading; // Yükleme ekranı paneli

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public formHome()
        {
            InitializeComponent();

            // 1. Önce labelları ve grafikleri sıfırla
            DashboarduTemizle();

            // 2. YÜKLEME PANELİNİ OLUŞTUR
            pnlLoading = new Panel();
            pnlLoading.Name = "pnlLoading";
            pnlLoading.Dock = DockStyle.Fill;
            pnlLoading.BackColor = Color.White;

            Label lblMsg = new Label();
            lblMsg.Text = "Denge Verileri Hazırlanıyor, Lütfen Bekleyin...";
            lblMsg.AutoSize = false;
            lblMsg.Dock = DockStyle.Fill;
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            lblMsg.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblMsg.ForeColor = Color.FromArgb(41, 128, 185);

            pnlLoading.Controls.Add(lblMsg);
            this.Controls.Add(pnlLoading);
            pnlLoading.BringToFront();
        }

        // --- 🛠️ GÜNCELLENEN KISIM: TÜM LABELLAR ARTIK STANDART ---
        private void DashboarduTemizle()
        {
            // Kutulardaki eski yazıları temizle (Hepsi --- oldu)
            label2.Text = "---"; // Kasa Durumu (Yükleniyor yazısı kaldırıldı)
            label5.Text = "---"; // Toplam Satış
            label6.Text = "---"; // Toplam Stok
            label8.Text = "---"; // Kritik Ürünler

            // Grafikleri temizle
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();

            chart1.Titles.Clear();
            chart1.Titles.Add("Veriler Güncelleniyor...");
        }

        private async void formHome_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            pnlLoading.Visible = true;
            pnlLoading.BringToFront();

            // Verileri Firebase'den çekmeye başla
            await DashboardVerileriniGuncelle();

            // Veriler dolduğunda yükleme ekranını kaldır
            pnlLoading.Visible = false;
        }

        private async Task DashboardVerileriniGuncelle()
        {
            try
            {
                var resFaturalar = await client.GetAsync("Faturalar");
                var resGiderler = await client.GetAsync("Giderler");
                var resKasaBanka = await client.GetAsync("KasaBanka");
                var resStoklar = await client.GetAsync("Stoklar");

                chart1.Titles.Clear();

                // --- A. SATIŞ ANALİZİ ---
                double gelir = 0, gider = 0;
                int toplamSatisAdeti = 0;

                if (resFaturalar.Body != "null")
                {
                    var faturaListesi = resFaturalar.ResultAs<Dictionary<string, InvoiceModel>>().Values;
                    var satislar = faturaListesi.Where(x => x.FaturaTipi != null && x.FaturaTipi.Trim().Equals("Satış", StringComparison.OrdinalIgnoreCase));
                    gelir = satislar.Sum(x => x.ToplamTutar);
                    toplamSatisAdeti = satislar.Count();
                }

                if (resGiderler.Body != "null")
                {
                    gider = resGiderler.ResultAs<Dictionary<string, CostModel>>().Values.Sum(x => x.Tutar);
                }

                label5.Text = toplamSatisAdeti.ToString() + " Adet";

                chart1.Series.Clear();
                var s1 = chart1.Series.Add("Mali Durum");
                s1.ChartType = SeriesChartType.Column;
                s1.Points.AddXY("Gelir", gelir);
                s1.Points.AddXY("Gider", gider);
                s1.Points[0].Color = Color.SeaGreen; s1.Points[1].Color = Color.Crimson;

                // --- B. NAKİT DAĞILIMI ---
                double kasa = 0, banka = 0;
                if (resKasaBanka.Body != "null")
                {
                    var nakitVerileri = resKasaBanka.ResultAs<Dictionary<string, AccountModel>>().Values;
                    kasa = nakitVerileri.Where(x => x.HesapTuru == "Kasa").Sum(x => x.Bakiye);
                    banka = nakitVerileri.Where(x => x.HesapTuru == "Banka").Sum(x => x.Bakiye);
                }

                label2.Text = (kasa + banka).ToString("C2");

                chart2.Series.Clear();
                var s2 = chart2.Series.Add("Nakit");
                s2.ChartType = SeriesChartType.Doughnut;
                s2.Points.AddXY("Kasa", kasa);
                s2.Points.AddXY("Banka", banka);

                // --- C. STOK DURUMU ---
                if (resStoklar.Body != "null")
                {
                    var stokListesi = resStoklar.ResultAs<Dictionary<string, ProductModel>>().Values;
                    label6.Text = stokListesi.Sum(x => x.StokAdedi).ToString();
                    label8.Text = stokListesi.Count(x => x.StokAdedi <= x.KritikSeviye).ToString();

                    var kritikUrunler = stokListesi.Where(x => x.StokAdedi <= x.KritikSeviye)
                                                  .OrderBy(x => x.StokAdedi).Take(5).ToList();

                    chart3.Series.Clear();
                    var s3 = chart3.Series.Add("Kritik Stok");
                    s3.ChartType = SeriesChartType.Bar;
                    foreach (var urun in kritikUrunler) { s3.Points.AddXY(urun.UrunAdi, urun.StokAdedi); }
                }
            }
            catch (Exception ex)
            {
                pnlLoading.Visible = false;
                Console.WriteLine("Hata: " + ex.Message);
            }
        }
    }
}