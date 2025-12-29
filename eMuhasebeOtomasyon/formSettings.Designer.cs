namespace eMuhasebeOtomasyon
{
    partial class formSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlNavigasyon = new System.Windows.Forms.Panel();
            this.btnKullaniciDegistir = new System.Windows.Forms.Button();
            this.btnMuhasebeKodlari = new System.Windows.Forms.Button();
            this.btnVeritabaniAyarlari = new System.Windows.Forms.Button();
            this.btnKullanicilarYetkiler = new System.Windows.Forms.Button();
            this.btnGenelAyarlar = new System.Windows.Forms.Button();
            this.pnlIcerik = new System.Windows.Forms.Panel();
            this.dgvKullanicilar = new System.Windows.Forms.DataGridView();
            this.pnlNavigasyon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNavigasyon
            // 
            this.pnlNavigasyon.Controls.Add(this.btnKullaniciDegistir);
            this.pnlNavigasyon.Controls.Add(this.btnMuhasebeKodlari);
            this.pnlNavigasyon.Controls.Add(this.btnVeritabaniAyarlari);
            this.pnlNavigasyon.Controls.Add(this.btnKullanicilarYetkiler);
            this.pnlNavigasyon.Controls.Add(this.btnGenelAyarlar);
            this.pnlNavigasyon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigasyon.Location = new System.Drawing.Point(0, 0);
            this.pnlNavigasyon.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNavigasyon.Name = "pnlNavigasyon";
            this.pnlNavigasyon.Size = new System.Drawing.Size(150, 366);
            this.pnlNavigasyon.TabIndex = 0;
            // 
            // btnKullaniciDegistir
            // 
            this.btnKullaniciDegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciDegistir.Location = new System.Drawing.Point(9, 251);
            this.btnKullaniciDegistir.Margin = new System.Windows.Forms.Padding(2);
            this.btnKullaniciDegistir.Name = "btnKullaniciDegistir";
            this.btnKullaniciDegistir.Size = new System.Drawing.Size(136, 51);
            this.btnKullaniciDegistir.TabIndex = 4;
            this.btnKullaniciDegistir.Text = "Kullanıcı Değiştir";
            this.btnKullaniciDegistir.UseVisualStyleBackColor = true;
            this.btnKullaniciDegistir.Click += new System.EventHandler(this.btnKullaniciDegistir_Click);
            // 
            // btnMuhasebeKodlari
            // 
            this.btnMuhasebeKodlari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMuhasebeKodlari.Location = new System.Drawing.Point(9, 196);
            this.btnMuhasebeKodlari.Margin = new System.Windows.Forms.Padding(2);
            this.btnMuhasebeKodlari.Name = "btnMuhasebeKodlari";
            this.btnMuhasebeKodlari.Size = new System.Drawing.Size(136, 51);
            this.btnMuhasebeKodlari.TabIndex = 3;
            this.btnMuhasebeKodlari.Text = "Hesap Planı";
            this.btnMuhasebeKodlari.UseVisualStyleBackColor = true;
            this.btnMuhasebeKodlari.Click += new System.EventHandler(this.btnMuhasebeKodlari_Click);
            // 
            // btnVeritabaniAyarlari
            // 
            this.btnVeritabaniAyarlari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVeritabaniAyarlari.Location = new System.Drawing.Point(9, 95);
            this.btnVeritabaniAyarlari.Margin = new System.Windows.Forms.Padding(2);
            this.btnVeritabaniAyarlari.Name = "btnVeritabaniAyarlari";
            this.btnVeritabaniAyarlari.Size = new System.Drawing.Size(136, 45);
            this.btnVeritabaniAyarlari.TabIndex = 2;
            this.btnVeritabaniAyarlari.Text = "Veri Tabanı Ayarları";
            this.btnVeritabaniAyarlari.UseVisualStyleBackColor = true;
            this.btnVeritabaniAyarlari.Click += new System.EventHandler(this.btnVeritabaniAyarlari_Click);
            // 
            // btnKullanicilarYetkiler
            // 
            this.btnKullanicilarYetkiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullanicilarYetkiler.Location = new System.Drawing.Point(9, 41);
            this.btnKullanicilarYetkiler.Margin = new System.Windows.Forms.Padding(2);
            this.btnKullanicilarYetkiler.Name = "btnKullanicilarYetkiler";
            this.btnKullanicilarYetkiler.Size = new System.Drawing.Size(136, 50);
            this.btnKullanicilarYetkiler.TabIndex = 1;
            this.btnKullanicilarYetkiler.Text = "Kullanıcılar ve Yetkiler";
            this.btnKullanicilarYetkiler.UseVisualStyleBackColor = true;
            this.btnKullanicilarYetkiler.Click += new System.EventHandler(this.btnKullanicilarYetkiler_Click);
            // 
            // btnGenelAyarlar
            // 
            this.btnGenelAyarlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGenelAyarlar.Location = new System.Drawing.Point(9, 144);
            this.btnGenelAyarlar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenelAyarlar.Name = "btnGenelAyarlar";
            this.btnGenelAyarlar.Size = new System.Drawing.Size(136, 48);
            this.btnGenelAyarlar.TabIndex = 0;
            this.btnGenelAyarlar.Text = "Genel Uygulama Ayarları";
            this.btnGenelAyarlar.UseVisualStyleBackColor = true;
            this.btnGenelAyarlar.Click += new System.EventHandler(this.btnGenelAyarlar_Click);
            // 
            // pnlIcerik
            // 
            this.pnlIcerik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIcerik.Location = new System.Drawing.Point(150, 0);
            this.pnlIcerik.Margin = new System.Windows.Forms.Padding(2);
            this.pnlIcerik.Name = "pnlIcerik";
            this.pnlIcerik.Size = new System.Drawing.Size(450, 41);
            this.pnlIcerik.TabIndex = 1;
            // 
            // dgvKullanicilar
            // 
            this.dgvKullanicilar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKullanicilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKullanicilar.Location = new System.Drawing.Point(150, 41);
            this.dgvKullanicilar.Name = "dgvKullanicilar";
            this.dgvKullanicilar.Size = new System.Drawing.Size(450, 325);
            this.dgvKullanicilar.TabIndex = 2;
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.dgvKullanicilar);
            this.Controls.Add(this.pnlIcerik);
            this.Controls.Add(this.pnlNavigasyon);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formSettings";
            this.Text = "Denge";
            this.Load += new System.EventHandler(this.formSettings_Load);
            this.pnlNavigasyon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKullanicilar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavigasyon;
        private System.Windows.Forms.Panel pnlIcerik;
        private System.Windows.Forms.Button btnMuhasebeKodlari;
        private System.Windows.Forms.Button btnVeritabaniAyarlari;
        private System.Windows.Forms.Button btnKullanicilarYetkiler;
        private System.Windows.Forms.Button btnGenelAyarlar;
        private System.Windows.Forms.DataGridView dgvKullanicilar;
        private System.Windows.Forms.Button btnKullaniciDegistir;
    }
}