namespace eMuhasebeOtomasyon
{
    partial class formCost
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.txtGiderAra = new System.Windows.Forms.TextBox();
            this.cmbDonem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.cmbGiderKategori = new System.Windows.Forms.ComboBox();
            this.lblKategori = new System.Windows.Forms.Label();
            this.lblTutar = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.txtGiderAdi = new System.Windows.Forms.TextBox();
            this.lblGiderAdi = new System.Windows.Forms.Label();
            this.btnGiderRaporu = new System.Windows.Forms.Button();
            this.btnGiderSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgvGiderler = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiderler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbKategori);
            this.panel1.Controls.Add(this.txtGiderAra);
            this.panel1.Controls.Add(this.cmbDonem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 90);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(395, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arama";
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Items.AddRange(new object[] {
            "Tümü",
            "Kira",
            "Fatura",
            "Maaş",
            "Mutfak",
            "Ulaşım"});
            this.cmbKategori.Location = new System.Drawing.Point(227, 49);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(121, 21);
            this.cmbKategori.TabIndex = 4;
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // txtGiderAra
            // 
            this.txtGiderAra.Location = new System.Drawing.Point(369, 49);
            this.txtGiderAra.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiderAra.Name = "txtGiderAra";
            this.txtGiderAra.Size = new System.Drawing.Size(126, 20);
            this.txtGiderAra.TabIndex = 2;
            this.txtGiderAra.TextChanged += new System.EventHandler(this.txtGiderAra_TextChanged);
            // 
            // cmbDonem
            // 
            this.cmbDonem.FormattingEnabled = true;
            this.cmbDonem.Items.AddRange(new object[] {
            "Bu Ay",
            "Bu Yıl",
            "Tüm Kayıtlar"});
            this.cmbDonem.Location = new System.Drawing.Point(227, 24);
            this.cmbDonem.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Size = new System.Drawing.Size(121, 21);
            this.cmbDonem.TabIndex = 1;
            this.cmbDonem.SelectedIndexChanged += new System.EventHandler(this.cmbDonem_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gider Yönetimi";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtAciklama);
            this.panel2.Controls.Add(this.dtpTarih);
            this.panel2.Controls.Add(this.btnKaydet);
            this.panel2.Controls.Add(this.cmbGiderKategori);
            this.panel2.Controls.Add(this.lblKategori);
            this.panel2.Controls.Add(this.lblTutar);
            this.panel2.Controls.Add(this.txtTutar);
            this.panel2.Controls.Add(this.txtGiderAdi);
            this.panel2.Controls.Add(this.lblGiderAdi);
            this.panel2.Controls.Add(this.btnGiderRaporu);
            this.panel2.Controls.Add(this.btnGiderSil);
            this.panel2.Controls.Add(this.btnTemizle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(700, 90);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(262, 421);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(18, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Açıklama :";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(87, 174);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(157, 64);
            this.txtAciklama.TabIndex = 13;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(40, 43);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(185, 20);
            this.dtpTarih.TabIndex = 12;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnKaydet.Location = new System.Drawing.Point(31, 253);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(97, 42);
            this.btnKaydet.TabIndex = 11;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // cmbGiderKategori
            // 
            this.cmbGiderKategori.FormattingEnabled = true;
            this.cmbGiderKategori.Items.AddRange(new object[] {
            "Kira",
            "Fatura",
            "Maaş",
            "Mutfak",
            "Ulaşım"});
            this.cmbGiderKategori.Location = new System.Drawing.Point(87, 143);
            this.cmbGiderKategori.Name = "cmbGiderKategori";
            this.cmbGiderKategori.Size = new System.Drawing.Size(121, 21);
            this.cmbGiderKategori.TabIndex = 10;
            // 
            // lblKategori
            // 
            this.lblKategori.AutoSize = true;
            this.lblKategori.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKategori.Location = new System.Drawing.Point(19, 143);
            this.lblKategori.Name = "lblKategori";
            this.lblKategori.Size = new System.Drawing.Size(65, 17);
            this.lblKategori.TabIndex = 9;
            this.lblKategori.Text = "Kategori :";
            // 
            // lblTutar
            // 
            this.lblTutar.AutoSize = true;
            this.lblTutar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTutar.Location = new System.Drawing.Point(39, 112);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(45, 17);
            this.lblTutar.TabIndex = 8;
            this.lblTutar.Text = "Tutar :";
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(87, 112);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(121, 20);
            this.txtTutar.TabIndex = 7;
            // 
            // txtGiderAdi
            // 
            this.txtGiderAdi.Location = new System.Drawing.Point(87, 77);
            this.txtGiderAdi.Name = "txtGiderAdi";
            this.txtGiderAdi.Size = new System.Drawing.Size(121, 20);
            this.txtGiderAdi.TabIndex = 6;
            // 
            // lblGiderAdi
            // 
            this.lblGiderAdi.AutoSize = true;
            this.lblGiderAdi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGiderAdi.Location = new System.Drawing.Point(37, 80);
            this.lblGiderAdi.Name = "lblGiderAdi";
            this.lblGiderAdi.Size = new System.Drawing.Size(47, 17);
            this.lblGiderAdi.TabIndex = 5;
            this.lblGiderAdi.Text = "Gider :";
            // 
            // btnGiderRaporu
            // 
            this.btnGiderRaporu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiderRaporu.Location = new System.Drawing.Point(152, 308);
            this.btnGiderRaporu.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiderRaporu.Name = "btnGiderRaporu";
            this.btnGiderRaporu.Size = new System.Drawing.Size(95, 44);
            this.btnGiderRaporu.TabIndex = 4;
            this.btnGiderRaporu.Text = "Gider Analiz Raporu";
            this.btnGiderRaporu.UseVisualStyleBackColor = true;
            this.btnGiderRaporu.Click += new System.EventHandler(this.btnGiderRaporu_Click);
            // 
            // btnGiderSil
            // 
            this.btnGiderSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGiderSil.Location = new System.Drawing.Point(152, 253);
            this.btnGiderSil.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiderSil.Name = "btnGiderSil";
            this.btnGiderSil.Size = new System.Drawing.Size(95, 42);
            this.btnGiderSil.TabIndex = 2;
            this.btnGiderSil.Text = "Gideri Sil";
            this.btnGiderSil.UseVisualStyleBackColor = true;
            this.btnGiderSil.Click += new System.EventHandler(this.btnGiderSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(31, 308);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(97, 42);
            this.btnTemizle.TabIndex = 1;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgvGiderler
            // 
            this.dgvGiderler.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvGiderler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGiderler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiderler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGiderler.Location = new System.Drawing.Point(0, 90);
            this.dgvGiderler.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGiderler.Name = "dgvGiderler";
            this.dgvGiderler.RowHeadersWidth = 51;
            this.dgvGiderler.RowTemplate.Height = 24;
            this.dgvGiderler.Size = new System.Drawing.Size(700, 421);
            this.dgvGiderler.TabIndex = 2;
            // 
            // formCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 511);
            this.Controls.Add(this.dgvGiderler);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formCost";
            this.Text = "Denge";
            this.Load += new System.EventHandler(this.formCost_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiderler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvGiderler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDonem;
        private System.Windows.Forms.Button btnGiderRaporu;
        private System.Windows.Forms.Button btnGiderSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.TextBox txtGiderAra;
        private System.Windows.Forms.ComboBox cmbGiderKategori;
        private System.Windows.Forms.Label lblKategori;
        private System.Windows.Forms.Label lblTutar;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.TextBox txtGiderAdi;
        private System.Windows.Forms.Label lblGiderAdi;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Label label3;
    }
}