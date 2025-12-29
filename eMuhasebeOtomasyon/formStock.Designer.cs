namespace eMuhasebeOtomasyon
{
    partial class formStock
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStokAra = new System.Windows.Forms.TextBox();
            this.dgvStoklar = new System.Windows.Forms.DataGridView();
            this.btnStokEkle = new System.Windows.Forms.Button();
            this.btnStokSil = new System.Windows.Forms.Button();
            this.btnKritikStok = new System.Windows.Forms.Button();
            this.btnStokHareket = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.txtStokAdet = new System.Windows.Forms.TextBox();
            this.txtKritik = new System.Windows.Forms.TextBox();
            this.txtAlis = new System.Windows.Forms.TextBox();
            this.txtSatis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTemizle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(46, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "   Stok Yönetimi";
            // 
            // txtStokAra
            // 
            this.txtStokAra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStokAra.Location = new System.Drawing.Point(31, 99);
            this.txtStokAra.Margin = new System.Windows.Forms.Padding(2);
            this.txtStokAra.Name = "txtStokAra";
            this.txtStokAra.Size = new System.Drawing.Size(134, 20);
            this.txtStokAra.TabIndex = 1;
            this.txtStokAra.TextChanged += new System.EventHandler(this.txtStokAra_TextChanged);
            // 
            // dgvStoklar
            // 
            this.dgvStoklar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStoklar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoklar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStoklar.Location = new System.Drawing.Point(198, 87);
            this.dgvStoklar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStoklar.Name = "dgvStoklar";
            this.dgvStoklar.RowHeadersWidth = 51;
            this.dgvStoklar.RowTemplate.Height = 24;
            this.dgvStoklar.Size = new System.Drawing.Size(734, 465);
            this.dgvStoklar.TabIndex = 3;
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStokEkle.Location = new System.Drawing.Point(633, 10);
            this.btnStokEkle.Margin = new System.Windows.Forms.Padding(2);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(64, 27);
            this.btnStokEkle.TabIndex = 4;
            this.btnStokEkle.Text = "Kaydet";
            this.btnStokEkle.UseVisualStyleBackColor = true;
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // btnStokSil
            // 
            this.btnStokSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStokSil.Location = new System.Drawing.Point(36, 243);
            this.btnStokSil.Margin = new System.Windows.Forms.Padding(2);
            this.btnStokSil.Name = "btnStokSil";
            this.btnStokSil.Size = new System.Drawing.Size(123, 40);
            this.btnStokSil.TabIndex = 6;
            this.btnStokSil.Text = "Ürün Sil";
            this.btnStokSil.UseVisualStyleBackColor = true;
            this.btnStokSil.Click += new System.EventHandler(this.btnStokSil_Click);
            // 
            // btnKritikStok
            // 
            this.btnKritikStok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKritikStok.Location = new System.Drawing.Point(36, 338);
            this.btnKritikStok.Margin = new System.Windows.Forms.Padding(2);
            this.btnKritikStok.Name = "btnKritikStok";
            this.btnKritikStok.Size = new System.Drawing.Size(123, 40);
            this.btnKritikStok.TabIndex = 7;
            this.btnKritikStok.Text = "Kritik Stoklar";
            this.btnKritikStok.UseVisualStyleBackColor = true;
            this.btnKritikStok.Click += new System.EventHandler(this.btnKritikStok_Click);
            // 
            // btnStokHareket
            // 
            this.btnStokHareket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStokHareket.Location = new System.Drawing.Point(36, 434);
            this.btnStokHareket.Margin = new System.Windows.Forms.Padding(2);
            this.btnStokHareket.Name = "btnStokHareket";
            this.btnStokHareket.Size = new System.Drawing.Size(123, 39);
            this.btnStokHareket.TabIndex = 8;
            this.btnStokHareket.Text = "Hareketler";
            this.btnStokHareket.UseVisualStyleBackColor = true;
            this.btnStokHareket.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtStokAra, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStokHareket, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnKritikStok, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnStokSil, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(198, 552);
            this.tableLayoutPanel1.TabIndex = 10;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(86, 14);
            this.txtBarkod.Multiline = true;
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(106, 26);
            this.txtBarkod.TabIndex = 11;
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(294, 13);
            this.txtUrunAdi.Multiline = true;
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(106, 26);
            this.txtUrunAdi.TabIndex = 12;
            // 
            // txtStokAdet
            // 
            this.txtStokAdet.Location = new System.Drawing.Point(511, 16);
            this.txtStokAdet.Multiline = true;
            this.txtStokAdet.Name = "txtStokAdet";
            this.txtStokAdet.Size = new System.Drawing.Size(106, 26);
            this.txtStokAdet.TabIndex = 13;
            // 
            // txtKritik
            // 
            this.txtKritik.Location = new System.Drawing.Point(86, 46);
            this.txtKritik.Multiline = true;
            this.txtKritik.Name = "txtKritik";
            this.txtKritik.Size = new System.Drawing.Size(106, 26);
            this.txtKritik.TabIndex = 14;
            // 
            // txtAlis
            // 
            this.txtAlis.Location = new System.Drawing.Point(294, 46);
            this.txtAlis.Multiline = true;
            this.txtAlis.Name = "txtAlis";
            this.txtAlis.Size = new System.Drawing.Size(106, 27);
            this.txtAlis.TabIndex = 15;
            // 
            // txtSatis
            // 
            this.txtSatis.Location = new System.Drawing.Point(511, 46);
            this.txtSatis.Multiline = true;
            this.txtSatis.Name = "txtSatis";
            this.txtSatis.Size = new System.Drawing.Size(106, 28);
            this.txtSatis.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Barkod :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(209, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ürün Adı :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(416, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Stok Adedi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(-2, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Kritik Sayı :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(209, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Alış Fiyatı :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(419, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Satış Fiyatı :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTemizle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtBarkod);
            this.panel1.Controls.Add(this.btnStokEkle);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtUrunAdi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtStokAdet);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtKritik);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAlis);
            this.panel1.Controls.Add(this.txtSatis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(198, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 87);
            this.panel1.TabIndex = 23;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTemizle.Location = new System.Drawing.Point(633, 48);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(2);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(64, 27);
            this.btnTemizle.TabIndex = 23;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // formStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 552);
            this.Controls.Add(this.dgvStoklar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formStock";
            this.Text = "Denge";
            this.Load += new System.EventHandler(this.formStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoklar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStokAra;
        private System.Windows.Forms.DataGridView dgvStoklar;
        private System.Windows.Forms.Button btnStokEkle;
        private System.Windows.Forms.Button btnStokSil;
        private System.Windows.Forms.Button btnKritikStok;
        private System.Windows.Forms.Button btnStokHareket;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.TextBox txtStokAdet;
        private System.Windows.Forms.TextBox txtKritik;
        private System.Windows.Forms.TextBox txtAlis;
        private System.Windows.Forms.TextBox txtSatis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTemizle;
    }
}