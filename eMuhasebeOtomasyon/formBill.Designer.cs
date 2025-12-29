namespace eMuhasebeOtomasyon
{
    partial class formBill
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
            this.btnFaturaGoruntule = new System.Windows.Forms.Button();
            this.btnFaturaSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSatisFaturasi = new System.Windows.Forms.RadioButton();
            this.rbAlisFaturasi = new System.Windows.Forms.RadioButton();
            this.txtAramaFatura = new System.Windows.Forms.TextBox();
            this.dgvFaturalar = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbTumu = new System.Windows.Forms.RadioButton();
            this.pnlFaturaKayit = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFaturaTipi = new System.Windows.Forms.ComboBox();
            this.btnFaturaKaydet = new System.Windows.Forms.Button();
            this.txtToplamTutar = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.txtCariAdi = new System.Windows.Forms.TextBox();
            this.txtFaturaID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturalar)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlFaturaKayit.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFaturaGoruntule
            // 
            this.btnFaturaGoruntule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFaturaGoruntule.Location = new System.Drawing.Point(122, 289);
            this.btnFaturaGoruntule.Margin = new System.Windows.Forms.Padding(2);
            this.btnFaturaGoruntule.Name = "btnFaturaGoruntule";
            this.btnFaturaGoruntule.Size = new System.Drawing.Size(96, 56);
            this.btnFaturaGoruntule.TabIndex = 8;
            this.btnFaturaGoruntule.Text = "Fatura Görüntüle";
            this.btnFaturaGoruntule.UseVisualStyleBackColor = true;
            this.btnFaturaGoruntule.Click += new System.EventHandler(this.btnFaturaGoruntule_Click);
            // 
            // btnFaturaSil
            // 
            this.btnFaturaSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFaturaSil.Location = new System.Drawing.Point(15, 289);
            this.btnFaturaSil.Margin = new System.Windows.Forms.Padding(2);
            this.btnFaturaSil.Name = "btnFaturaSil";
            this.btnFaturaSil.Size = new System.Drawing.Size(96, 56);
            this.btnFaturaSil.TabIndex = 7;
            this.btnFaturaSil.Text = "Faturayı Sil";
            this.btnFaturaSil.UseVisualStyleBackColor = true;
            this.btnFaturaSil.Click += new System.EventHandler(this.btnFaturaSil_Click_1);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(120, 215);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(96, 56);
            this.btnTemizle.TabIndex = 6;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(311, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fatura İşlemleri";
            // 
            // rbSatisFaturasi
            // 
            this.rbSatisFaturasi.AutoSize = true;
            this.rbSatisFaturasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbSatisFaturasi.Location = new System.Drawing.Point(155, 15);
            this.rbSatisFaturasi.Margin = new System.Windows.Forms.Padding(2);
            this.rbSatisFaturasi.Name = "rbSatisFaturasi";
            this.rbSatisFaturasi.Size = new System.Drawing.Size(121, 21);
            this.rbSatisFaturasi.TabIndex = 0;
            this.rbSatisFaturasi.TabStop = true;
            this.rbSatisFaturasi.Text = "Satış Faturaları";
            this.rbSatisFaturasi.UseVisualStyleBackColor = true;
            this.rbSatisFaturasi.CheckedChanged += new System.EventHandler(this.rbSatisFaturasi_CheckedChanged);
            // 
            // rbAlisFaturasi
            // 
            this.rbAlisFaturasi.AutoSize = true;
            this.rbAlisFaturasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbAlisFaturasi.Location = new System.Drawing.Point(155, 40);
            this.rbAlisFaturasi.Margin = new System.Windows.Forms.Padding(2);
            this.rbAlisFaturasi.Name = "rbAlisFaturasi";
            this.rbAlisFaturasi.Size = new System.Drawing.Size(112, 21);
            this.rbAlisFaturasi.TabIndex = 1;
            this.rbAlisFaturasi.TabStop = true;
            this.rbAlisFaturasi.Text = "Alış Faturaları";
            this.rbAlisFaturasi.UseVisualStyleBackColor = true;
            this.rbAlisFaturasi.CheckedChanged += new System.EventHandler(this.rbAlisFaturasi_CheckedChanged);
            // 
            // txtAramaFatura
            // 
            this.txtAramaFatura.Location = new System.Drawing.Point(335, 64);
            this.txtAramaFatura.Margin = new System.Windows.Forms.Padding(2);
            this.txtAramaFatura.Name = "txtAramaFatura";
            this.txtAramaFatura.Size = new System.Drawing.Size(110, 20);
            this.txtAramaFatura.TabIndex = 2;
            // 
            // dgvFaturalar
            // 
            this.dgvFaturalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaturalar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFaturalar.Location = new System.Drawing.Point(0, 96);
            this.dgvFaturalar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFaturalar.Name = "dgvFaturalar";
            this.dgvFaturalar.RowHeadersWidth = 51;
            this.dgvFaturalar.RowTemplate.Height = 24;
            this.dgvFaturalar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaturalar.Size = new System.Drawing.Size(735, 415);
            this.dgvFaturalar.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbTumu);
            this.panel2.Controls.Add(this.txtAramaFatura);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rbSatisFaturasi);
            this.panel2.Controls.Add(this.rbAlisFaturasi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 96);
            this.panel2.TabIndex = 4;
            // 
            // rbTumu
            // 
            this.rbTumu.AutoSize = true;
            this.rbTumu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbTumu.Location = new System.Drawing.Point(155, 64);
            this.rbTumu.Name = "rbTumu";
            this.rbTumu.Size = new System.Drawing.Size(68, 25);
            this.rbTumu.TabIndex = 5;
            this.rbTumu.TabStop = true;
            this.rbTumu.Text = "Tümü";
            this.rbTumu.UseVisualStyleBackColor = true;
            this.rbTumu.CheckedChanged += new System.EventHandler(this.rbTumu_CheckedChanged);
            // 
            // pnlFaturaKayit
            // 
            this.pnlFaturaKayit.Controls.Add(this.btnFaturaGoruntule);
            this.pnlFaturaKayit.Controls.Add(this.label6);
            this.pnlFaturaKayit.Controls.Add(this.btnFaturaSil);
            this.pnlFaturaKayit.Controls.Add(this.cmbFaturaTipi);
            this.pnlFaturaKayit.Controls.Add(this.btnTemizle);
            this.pnlFaturaKayit.Controls.Add(this.btnFaturaKaydet);
            this.pnlFaturaKayit.Controls.Add(this.txtToplamTutar);
            this.pnlFaturaKayit.Controls.Add(this.dtpTarih);
            this.pnlFaturaKayit.Controls.Add(this.txtCariAdi);
            this.pnlFaturaKayit.Controls.Add(this.txtFaturaID);
            this.pnlFaturaKayit.Controls.Add(this.label5);
            this.pnlFaturaKayit.Controls.Add(this.label4);
            this.pnlFaturaKayit.Controls.Add(this.label3);
            this.pnlFaturaKayit.Controls.Add(this.label2);
            this.pnlFaturaKayit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFaturaKayit.Location = new System.Drawing.Point(735, 96);
            this.pnlFaturaKayit.Name = "pnlFaturaKayit";
            this.pnlFaturaKayit.Size = new System.Drawing.Size(227, 415);
            this.pnlFaturaKayit.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(6, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fatura Tipi :";
            // 
            // cmbFaturaTipi
            // 
            this.cmbFaturaTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaturaTipi.FormattingEnabled = true;
            this.cmbFaturaTipi.Items.AddRange(new object[] {
            "Alış\t",
            "Satış"});
            this.cmbFaturaTipi.Location = new System.Drawing.Point(120, 174);
            this.cmbFaturaTipi.Name = "cmbFaturaTipi";
            this.cmbFaturaTipi.Size = new System.Drawing.Size(100, 21);
            this.cmbFaturaTipi.TabIndex = 5;
            // 
            // btnFaturaKaydet
            // 
            this.btnFaturaKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btnFaturaKaydet.Location = new System.Drawing.Point(15, 215);
            this.btnFaturaKaydet.Name = "btnFaturaKaydet";
            this.btnFaturaKaydet.Size = new System.Drawing.Size(96, 56);
            this.btnFaturaKaydet.TabIndex = 9;
            this.btnFaturaKaydet.Text = "Kaydet";
            this.btnFaturaKaydet.UseVisualStyleBackColor = true;
            this.btnFaturaKaydet.Click += new System.EventHandler(this.btnFaturaKaydet_Click);
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.Location = new System.Drawing.Point(120, 142);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.Size = new System.Drawing.Size(100, 20);
            this.txtToplamTutar.TabIndex = 4;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(73, 112);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(147, 20);
            this.dtpTarih.TabIndex = 3;
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.Location = new System.Drawing.Point(120, 79);
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.Size = new System.Drawing.Size(100, 20);
            this.txtCariAdi.TabIndex = 2;
            // 
            // txtFaturaID
            // 
            this.txtFaturaID.Location = new System.Drawing.Point(120, 48);
            this.txtFaturaID.Name = "txtFaturaID";
            this.txtFaturaID.ReadOnly = true;
            this.txtFaturaID.Size = new System.Drawing.Size(100, 20);
            this.txtFaturaID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Toplam tutar : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tarih : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Müşteri Adı : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fatura ID :";
            // 
            // formBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 511);
            this.Controls.Add(this.dgvFaturalar);
            this.Controls.Add(this.pnlFaturaKayit);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formBill";
            this.Text = "Denge";
            this.Load += new System.EventHandler(this.formBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturalar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlFaturaKayit.ResumeLayout(false);
            this.pnlFaturaKayit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtAramaFatura;
        private System.Windows.Forms.RadioButton rbAlisFaturasi;
        private System.Windows.Forms.RadioButton rbSatisFaturasi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFaturalar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFaturaGoruntule;
        private System.Windows.Forms.Button btnFaturaSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Panel pnlFaturaKayit;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.TextBox txtCariAdi;
        private System.Windows.Forms.TextBox txtFaturaID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFaturaKaydet;
        private System.Windows.Forms.TextBox txtToplamTutar;
        private System.Windows.Forms.ComboBox cmbFaturaTipi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbTumu;
    }
}