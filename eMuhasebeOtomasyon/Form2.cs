using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Windows.Forms;

namespace eMuhasebeOtomasyon
{
    public partial class Form2 : Form
    {
        // 1. DEĞİŞKENLER VE YAPILANDIRMA
        string _gelenRol;
        IFirebaseClient sunucu;

        IFirebaseConfig ayar = new FirebaseConfig
        {
            AuthSecret = "0mCnu7vZxDfKvAbyxvAOxu4A3L54PT91UpVPDV1i",
            BasePath = "https://emuhasebeproje-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public Form2(string rol)
        {
            InitializeComponent();
            _gelenRol = rol;
        }

        // 2. NAVİGASYON VE PANEL YÖNETİMİ
        private void SayfaGetir(Form form)
        {
            mainPanel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void HareketliCizgi(System.Windows.Forms.Button btn)
        {
            pnlIndicator.Visible = true;
            pnlIndicator.Height = btn.Height;
            pnlIndicator.Top = btn.Top;
            pnlIndicator.BringToFront();
        }

        // 3. FORM YÜKLENME VE YETKİLENDİRME
        private void Form2_Load(object sender, EventArgs e)
        {
            sunucu = new FireSharp.FirebaseClient(ayar);
            string rol = _gelenRol.ToLower(System.Globalization.CultureInfo.InvariantCulture).Trim();

            // 🟢 AYARLAR MENÜSÜ ARTIK TÜM ROLLERDE GÖRÜNÜR
            if (rol.Contains("admin"))
            {
                // Admin her şeyi görür.
            }
            else if (rol.Contains("gözlemci"))
            {
                btnStock.Enabled = true;
                btnCurrent.Enabled = true;
            }
            else if (rol.Contains("muhasebe"))
            {
                // btnSettings.Visible = false;  <- Bu satır kaldırıldı
            }
            else if (rol.Contains("personel"))
            {
                btnBill.Visible = false;
                btnSafe.Visible = false;
                btnOut.Visible = false;
                btnReport.Visible = false;
                // btnSettings.Visible = false;  <- Bu satır kaldırıldı
            }

            formHome anaSayfaFrm = new formHome();
            SayfaGetir(anaSayfaFrm);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            formHome frm = new formHome();
            SayfaGetir(frm);
            HareketliCizgi(btnHome);
        }

        private void btnCurrent_Click_1(object sender, EventArgs e)
        {
            formCurrent frm = new formCurrent(_gelenRol);
            SayfaGetir(frm);
            HareketliCizgi(btnCurrent);
        }

        private void btnStock_Click_1(object sender, EventArgs e)
        {
            formStock frm = new formStock(_gelenRol);
            SayfaGetir(frm);
            HareketliCizgi(btnStock);
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            formBill frm = new formBill(_gelenRol);
            SayfaGetir(frm);
            HareketliCizgi(btnBill);
        }

        private void btnSafe_Click(object sender, EventArgs e)
        {
            formBank frm = new formBank(_gelenRol);
            SayfaGetir(frm);
            HareketliCizgi(btnSafe);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            formCost frm = new formCost(_gelenRol);
            SayfaGetir(frm);
            HareketliCizgi(btnOut);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            formReport frm = new formReport(_gelenRol);
            SayfaGetir(frm);
            HareketliCizgi(btnReport);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            formSettings frm = new formSettings(_gelenRol);
            SayfaGetir(frm);
            HareketliCizgi(btnSettings);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes) { Application.Exit(); }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult sonuc = MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sonuc == DialogResult.No) { e.Cancel = true; }
            }
        }

        private void pnlIndicator_Paint(object sender, PaintEventArgs e) { }
        private void pnlProfileMenu_Paint(object sender, PaintEventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
    }
}