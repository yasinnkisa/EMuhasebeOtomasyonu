using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMuhasebeOtomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        // Bu metot, içine gönderilen Formu, pnlIcerik panelinde açar.
        private void SayfaGetir(Form form)
        {
            mainPanel.Controls.Clear(); // Paneldeki eski sayfayı temizle
            form.TopLevel = false; // Formun "pencere" olma özelliğini kapat
            form.FormBorderStyle = FormBorderStyle.None; // Çerçevesini kaldır
            form.Dock = DockStyle.Fill; // Paneli dolduracak şekilde yay
            mainPanel.Controls.Add(form); // Panele ekle
            form.Show(); // Göster
            form.BringToFront();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            formHome frm = new formHome();
            SayfaGetir(frm);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // formHome isimli formundan bir örnek alıp ekrana getiriyoruz
            formHome frm = new formHome();
            SayfaGetir(frm);
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            formCurrent frm = new formCurrent();
            SayfaGetir(frm);
        }
    }
}
