namespace eMuhasebeOtomasyon
{
    partial class formBank
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbTumu = new System.Windows.Forms.RadioButton();
            this.rbBankaHesaplari = new System.Windows.Forms.RadioButton();
            this.rbKasaHesaplari = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHesaplar = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbHesapAdi = new System.Windows.Forms.ComboBox();
            this.btnHesapSil = new System.Windows.Forms.Button();
            this.txtBakiye = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnParaCikis = new System.Windows.Forms.Button();
            this.cmbHesapTuru = new System.Windows.Forms.ComboBox();
            this.btnParaGiris = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnYeniHesap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHesaplar)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbTumu);
            this.panel1.Controls.Add(this.rbBankaHesaplari);
            this.panel1.Controls.Add(this.rbKasaHesaplari);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 98);
            this.panel1.TabIndex = 0;
            // 
            // rbTumu
            // 
            this.rbTumu.AutoSize = true;
            this.rbTumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbTumu.Location = new System.Drawing.Point(449, 70);
            this.rbTumu.Margin = new System.Windows.Forms.Padding(2);
            this.rbTumu.Name = "rbTumu";
            this.rbTumu.Size = new System.Drawing.Size(64, 22);
            this.rbTumu.TabIndex = 3;
            this.rbTumu.TabStop = true;
            this.rbTumu.Text = "Tümü";
            this.rbTumu.UseVisualStyleBackColor = true;
            this.rbTumu.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // rbBankaHesaplari
            // 
            this.rbBankaHesaplari.AutoSize = true;
            this.rbBankaHesaplari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbBankaHesaplari.Location = new System.Drawing.Point(139, 71);
            this.rbBankaHesaplari.Margin = new System.Windows.Forms.Padding(2);
            this.rbBankaHesaplari.Name = "rbBankaHesaplari";
            this.rbBankaHesaplari.Size = new System.Drawing.Size(134, 22);
            this.rbBankaHesaplari.TabIndex = 2;
            this.rbBankaHesaplari.TabStop = true;
            this.rbBankaHesaplari.Text = "Banka Hesapları";
            this.rbBankaHesaplari.UseVisualStyleBackColor = true;
            this.rbBankaHesaplari.CheckedChanged += new System.EventHandler(this.rbBankaHesaplari_CheckedChanged);
            // 
            // rbKasaHesaplari
            // 
            this.rbKasaHesaplari.AutoSize = true;
            this.rbKasaHesaplari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbKasaHesaplari.Location = new System.Drawing.Point(306, 70);
            this.rbKasaHesaplari.Margin = new System.Windows.Forms.Padding(2);
            this.rbKasaHesaplari.Name = "rbKasaHesaplari";
            this.rbKasaHesaplari.Size = new System.Drawing.Size(126, 22);
            this.rbKasaHesaplari.TabIndex = 1;
            this.rbKasaHesaplari.TabStop = true;
            this.rbKasaHesaplari.Text = "Kasa Hesapları";
            this.rbKasaHesaplari.UseVisualStyleBackColor = true;
            this.rbKasaHesaplari.CheckedChanged += new System.EventHandler(this.rbKasaHesaplari_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(193, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kasa ve Banka İşlemleri";
            // 
            // dgvHesaplar
            // 
            this.dgvHesaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHesaplar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHesaplar.Location = new System.Drawing.Point(0, 98);
            this.dgvHesaplar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHesaplar.Name = "dgvHesaplar";
            this.dgvHesaplar.RowHeadersWidth = 51;
            this.dgvHesaplar.RowTemplate.Height = 24;
            this.dgvHesaplar.Size = new System.Drawing.Size(680, 413);
            this.dgvHesaplar.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTemizle);
            this.panel3.Controls.Add(this.txtAciklama);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbHesapAdi);
            this.panel3.Controls.Add(this.btnHesapSil);
            this.panel3.Controls.Add(this.txtBakiye);
            this.panel3.Controls.Add(this.btnTransfer);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnParaCikis);
            this.panel3.Controls.Add(this.cmbHesapTuru);
            this.panel3.Controls.Add(this.btnParaGiris);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnYeniHesap);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel3.Location = new System.Drawing.Point(680, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(282, 413);
            this.panel3.TabIndex = 3;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(150, 195);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(127, 44);
            this.btnTemizle.TabIndex = 9;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(90, 150);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(133, 20);
            this.txtAciklama.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(8, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Açıklama :";
            // 
            // cmbHesapAdi
            // 
            this.cmbHesapAdi.FormattingEnabled = true;
            this.cmbHesapAdi.Location = new System.Drawing.Point(90, 32);
            this.cmbHesapAdi.Name = "cmbHesapAdi";
            this.cmbHesapAdi.Size = new System.Drawing.Size(133, 25);
            this.cmbHesapAdi.TabIndex = 6;
            // 
            // btnHesapSil
            // 
            this.btnHesapSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesapSil.Location = new System.Drawing.Point(143, 329);
            this.btnHesapSil.Margin = new System.Windows.Forms.Padding(2);
            this.btnHesapSil.Name = "btnHesapSil";
            this.btnHesapSil.Size = new System.Drawing.Size(97, 60);
            this.btnHesapSil.TabIndex = 4;
            this.btnHesapSil.Text = "Hesap Sil";
            this.btnHesapSil.UseVisualStyleBackColor = true;
            this.btnHesapSil.Click += new System.EventHandler(this.btnHesapSil_Click);
            // 
            // txtBakiye
            // 
            this.txtBakiye.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBakiye.Location = new System.Drawing.Point(90, 110);
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.Size = new System.Drawing.Size(133, 25);
            this.txtBakiye.TabIndex = 5;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTransfer.Location = new System.Drawing.Point(42, 329);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(95, 60);
            this.btnTransfer.TabIndex = 3;
            this.btnTransfer.Text = "Hesaplar Arası Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(33, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bakiye :";
            // 
            // btnParaCikis
            // 
            this.btnParaCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnParaCikis.Location = new System.Drawing.Point(143, 265);
            this.btnParaCikis.Margin = new System.Windows.Forms.Padding(2);
            this.btnParaCikis.Name = "btnParaCikis";
            this.btnParaCikis.Size = new System.Drawing.Size(95, 60);
            this.btnParaCikis.TabIndex = 2;
            this.btnParaCikis.Text = "Para Çıkışı";
            this.btnParaCikis.UseVisualStyleBackColor = true;
            this.btnParaCikis.Click += new System.EventHandler(this.btnParaCikis_Click);
            // 
            // cmbHesapTuru
            // 
            this.cmbHesapTuru.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbHesapTuru.FormattingEnabled = true;
            this.cmbHesapTuru.Items.AddRange(new object[] {
            "Banka",
            "Kasa"});
            this.cmbHesapTuru.Location = new System.Drawing.Point(90, 71);
            this.cmbHesapTuru.Name = "cmbHesapTuru";
            this.cmbHesapTuru.Size = new System.Drawing.Size(133, 25);
            this.cmbHesapTuru.TabIndex = 3;
            // 
            // btnParaGiris
            // 
            this.btnParaGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnParaGiris.Location = new System.Drawing.Point(42, 265);
            this.btnParaGiris.Margin = new System.Windows.Forms.Padding(2);
            this.btnParaGiris.Name = "btnParaGiris";
            this.btnParaGiris.Size = new System.Drawing.Size(95, 60);
            this.btnParaGiris.TabIndex = 1;
            this.btnParaGiris.Text = "Para Girişi";
            this.btnParaGiris.UseVisualStyleBackColor = true;
            this.btnParaGiris.Click += new System.EventHandler(this.btnParaGiris_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(2, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hesap Türü :";
            // 
            // btnYeniHesap
            // 
            this.btnYeniHesap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniHesap.Location = new System.Drawing.Point(7, 195);
            this.btnYeniHesap.Margin = new System.Windows.Forms.Padding(2);
            this.btnYeniHesap.Name = "btnYeniHesap";
            this.btnYeniHesap.Size = new System.Drawing.Size(127, 44);
            this.btnYeniHesap.TabIndex = 0;
            this.btnYeniHesap.Text = "Kaydet";
            this.btnYeniHesap.UseVisualStyleBackColor = true;
            this.btnYeniHesap.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hesap Adı :";
            // 
            // formBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 511);
            this.Controls.Add(this.dgvHesaplar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formBank";
            this.Text = "Denge";
            this.Load += new System.EventHandler(this.formBank_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHesaplar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbBankaHesaplari;
        private System.Windows.Forms.RadioButton rbKasaHesaplari;
        private System.Windows.Forms.DataGridView dgvHesaplar;
        private System.Windows.Forms.RadioButton rbTumu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBakiye;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHesapTuru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHesapSil;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnParaCikis;
        private System.Windows.Forms.Button btnParaGiris;
        private System.Windows.Forms.Button btnYeniHesap;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbHesapAdi;
        private System.Windows.Forms.Button btnTemizle;
    }
}