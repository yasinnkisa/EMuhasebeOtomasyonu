namespace eMuhasebeOtomasyon
{
    partial class formReport
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
            this.pnlRaporKategoriMenu = new System.Windows.Forms.Panel();
            this.btnRaporFatura = new System.Windows.Forms.Button();
            this.btnRaporCari = new System.Windows.Forms.Button();
            this.btnRaporStok = new System.Windows.Forms.Button();
            this.btnRaporGelirGider = new System.Windows.Forms.Button();
            this.btnRaporMaliDurum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRaporIcerik = new System.Windows.Forms.Panel();
            this.dgvRaporlar = new System.Windows.Forms.DataGridView();
            this.pnlRaporKategoriMenu.SuspendLayout();
            this.pnlRaporIcerik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaporlar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRaporKategoriMenu
            // 
            this.pnlRaporKategoriMenu.Controls.Add(this.btnRaporFatura);
            this.pnlRaporKategoriMenu.Controls.Add(this.btnRaporCari);
            this.pnlRaporKategoriMenu.Controls.Add(this.btnRaporStok);
            this.pnlRaporKategoriMenu.Controls.Add(this.btnRaporGelirGider);
            this.pnlRaporKategoriMenu.Controls.Add(this.btnRaporMaliDurum);
            this.pnlRaporKategoriMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRaporKategoriMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlRaporKategoriMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRaporKategoriMenu.Name = "pnlRaporKategoriMenu";
            this.pnlRaporKategoriMenu.Size = new System.Drawing.Size(150, 380);
            this.pnlRaporKategoriMenu.TabIndex = 0;
            // 
            // btnRaporFatura
            // 
            this.btnRaporFatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporFatura.Location = new System.Drawing.Point(10, 327);
            this.btnRaporFatura.Margin = new System.Windows.Forms.Padding(2);
            this.btnRaporFatura.Name = "btnRaporFatura";
            this.btnRaporFatura.Size = new System.Drawing.Size(128, 37);
            this.btnRaporFatura.TabIndex = 4;
            this.btnRaporFatura.Text = "Fatura Raporları";
            this.btnRaporFatura.UseVisualStyleBackColor = true;
            this.btnRaporFatura.Click += new System.EventHandler(this.btnRaporFatura_Click);
            // 
            // btnRaporCari
            // 
            this.btnRaporCari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporCari.Location = new System.Drawing.Point(10, 274);
            this.btnRaporCari.Margin = new System.Windows.Forms.Padding(2);
            this.btnRaporCari.Name = "btnRaporCari";
            this.btnRaporCari.Size = new System.Drawing.Size(128, 42);
            this.btnRaporCari.TabIndex = 3;
            this.btnRaporCari.Text = "Cari Hesap Raporları";
            this.btnRaporCari.UseVisualStyleBackColor = true;
            this.btnRaporCari.Click += new System.EventHandler(this.btnRaporCari_Click);
            // 
            // btnRaporStok
            // 
            this.btnRaporStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporStok.Location = new System.Drawing.Point(10, 221);
            this.btnRaporStok.Margin = new System.Windows.Forms.Padding(2);
            this.btnRaporStok.Name = "btnRaporStok";
            this.btnRaporStok.Size = new System.Drawing.Size(128, 46);
            this.btnRaporStok.TabIndex = 2;
            this.btnRaporStok.Text = "Stok Durum Raporları";
            this.btnRaporStok.UseVisualStyleBackColor = true;
            this.btnRaporStok.Click += new System.EventHandler(this.btnRaporStok_Click);
            // 
            // btnRaporGelirGider
            // 
            this.btnRaporGelirGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporGelirGider.Location = new System.Drawing.Point(11, 166);
            this.btnRaporGelirGider.Margin = new System.Windows.Forms.Padding(2);
            this.btnRaporGelirGider.Name = "btnRaporGelirGider";
            this.btnRaporGelirGider.Size = new System.Drawing.Size(128, 45);
            this.btnRaporGelirGider.TabIndex = 1;
            this.btnRaporGelirGider.Text = "Gelir / Gider Analizi";
            this.btnRaporGelirGider.UseVisualStyleBackColor = true;
            this.btnRaporGelirGider.Click += new System.EventHandler(this.btnRaporGelirGider_Click);
            // 
            // btnRaporMaliDurum
            // 
            this.btnRaporMaliDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporMaliDurum.Location = new System.Drawing.Point(11, 119);
            this.btnRaporMaliDurum.Margin = new System.Windows.Forms.Padding(2);
            this.btnRaporMaliDurum.Name = "btnRaporMaliDurum";
            this.btnRaporMaliDurum.Size = new System.Drawing.Size(128, 42);
            this.btnRaporMaliDurum.TabIndex = 0;
            this.btnRaporMaliDurum.Text = "Genel Mali Durum";
            this.btnRaporMaliDurum.UseVisualStyleBackColor = true;
            this.btnRaporMaliDurum.Click += new System.EventHandler(this.btnRaporMaliDurum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Raporlama Merkezi";
            // 
            // pnlRaporIcerik
            // 
            this.pnlRaporIcerik.Controls.Add(this.label1);
            this.pnlRaporIcerik.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRaporIcerik.Location = new System.Drawing.Point(150, 0);
            this.pnlRaporIcerik.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRaporIcerik.Name = "pnlRaporIcerik";
            this.pnlRaporIcerik.Size = new System.Drawing.Size(484, 67);
            this.pnlRaporIcerik.TabIndex = 2;
            // 
            // dgvRaporlar
            // 
            this.dgvRaporlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRaporlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRaporlar.Location = new System.Drawing.Point(150, 67);
            this.dgvRaporlar.Name = "dgvRaporlar";
            this.dgvRaporlar.Size = new System.Drawing.Size(484, 313);
            this.dgvRaporlar.TabIndex = 2;
            this.dgvRaporlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // formReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 380);
            this.Controls.Add(this.dgvRaporlar);
            this.Controls.Add(this.pnlRaporIcerik);
            this.Controls.Add(this.pnlRaporKategoriMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formReport";
            this.Text = "Denge";
            this.Load += new System.EventHandler(this.formReport_Load);
            this.pnlRaporKategoriMenu.ResumeLayout(false);
            this.pnlRaporIcerik.ResumeLayout(false);
            this.pnlRaporIcerik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRaporlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRaporKategoriMenu;
        private System.Windows.Forms.Button btnRaporFatura;
        private System.Windows.Forms.Button btnRaporCari;
        private System.Windows.Forms.Button btnRaporStok;
        private System.Windows.Forms.Button btnRaporGelirGider;
        private System.Windows.Forms.Button btnRaporMaliDurum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlRaporIcerik;
        private System.Windows.Forms.DataGridView dgvRaporlar;
    }
}