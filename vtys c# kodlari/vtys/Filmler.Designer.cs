
namespace vtys
{
    partial class Filmler
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_film_ad = new System.Windows.Forms.TextBox();
            this.btn_flm_ekle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_flm_guncelle = new System.Windows.Forms.Button();
            this.btn_flm_sil = new System.Windows.Forms.Button();
            this.combo_film_format = new System.Windows.Forms.ComboBox();
            this.combo_film_tur = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_film_suresi = new System.Windows.Forms.TextBox();
            this.txt_film_no = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_ara = new System.Windows.Forms.Button();
            this.txt_film_ara = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_oy_film = new System.Windows.Forms.TextBox();
            this.txt_oy_ara = new System.Windows.Forms.TextBox();
            this.btn_oy_ara = new System.Windows.Forms.Button();
            this.btn_oy_ekle = new System.Windows.Forms.Button();
            this.btn_oy_guncelle = new System.Windows.Forms.Button();
            this.btn_oy_sil = new System.Windows.Forms.Button();
            this.btn_listele = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_oy_id = new System.Windows.Forms.TextBox();
            this.btn_oy_listele = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.combo_oy_ad = new System.Windows.Forms.ComboBox();
            this.combo_oy_soyad = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(576, 359);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(642, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Film Adi";
            // 
            // txt_film_ad
            // 
            this.txt_film_ad.Location = new System.Drawing.Point(772, 74);
            this.txt_film_ad.Name = "txt_film_ad";
            this.txt_film_ad.Size = new System.Drawing.Size(159, 20);
            this.txt_film_ad.TabIndex = 2;
            // 
            // btn_flm_ekle
            // 
            this.btn_flm_ekle.Location = new System.Drawing.Point(613, 250);
            this.btn_flm_ekle.Name = "btn_flm_ekle";
            this.btn_flm_ekle.Size = new System.Drawing.Size(75, 45);
            this.btn_flm_ekle.TabIndex = 3;
            this.btn_flm_ekle.Text = "Film Ekle";
            this.btn_flm_ekle.UseVisualStyleBackColor = true;
            this.btn_flm_ekle.Click += new System.EventHandler(this.btn_flm_ekle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(642, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Film Türü";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(642, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Film Formati";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btn_flm_guncelle
            // 
            this.btn_flm_guncelle.Location = new System.Drawing.Point(704, 250);
            this.btn_flm_guncelle.Name = "btn_flm_guncelle";
            this.btn_flm_guncelle.Size = new System.Drawing.Size(75, 45);
            this.btn_flm_guncelle.TabIndex = 3;
            this.btn_flm_guncelle.Text = "Film Güncelle";
            this.btn_flm_guncelle.UseVisualStyleBackColor = true;
            this.btn_flm_guncelle.Click += new System.EventHandler(this.btn_flm_guncelle_Click);
            // 
            // btn_flm_sil
            // 
            this.btn_flm_sil.Location = new System.Drawing.Point(795, 250);
            this.btn_flm_sil.Name = "btn_flm_sil";
            this.btn_flm_sil.Size = new System.Drawing.Size(75, 45);
            this.btn_flm_sil.TabIndex = 3;
            this.btn_flm_sil.Text = "Film Sil";
            this.btn_flm_sil.UseVisualStyleBackColor = true;
            this.btn_flm_sil.Click += new System.EventHandler(this.btn_flm_sil_Click);
            // 
            // combo_film_format
            // 
            this.combo_film_format.FormattingEnabled = true;
            this.combo_film_format.Items.AddRange(new object[] {
            "D",
            "A",
            "O"});
            this.combo_film_format.Location = new System.Drawing.Point(772, 166);
            this.combo_film_format.Name = "combo_film_format";
            this.combo_film_format.Size = new System.Drawing.Size(121, 21);
            this.combo_film_format.TabIndex = 5;
            // 
            // combo_film_tur
            // 
            this.combo_film_tur.FormattingEnabled = true;
            this.combo_film_tur.Location = new System.Drawing.Point(772, 117);
            this.combo_film_tur.Name = "combo_film_tur";
            this.combo_film_tur.Size = new System.Drawing.Size(121, 21);
            this.combo_film_tur.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(642, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Film Süresi";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_film_suresi
            // 
            this.txt_film_suresi.Location = new System.Drawing.Point(772, 208);
            this.txt_film_suresi.Name = "txt_film_suresi";
            this.txt_film_suresi.Size = new System.Drawing.Size(159, 20);
            this.txt_film_suresi.TabIndex = 7;
            // 
            // txt_film_no
            // 
            this.txt_film_no.Enabled = false;
            this.txt_film_no.Location = new System.Drawing.Point(772, 39);
            this.txt_film_no.Name = "txt_film_no";
            this.txt_film_no.Size = new System.Drawing.Size(159, 20);
            this.txt_film_no.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(642, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Film No";
            // 
            // btn_ara
            // 
            this.btn_ara.Location = new System.Drawing.Point(828, 322);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(91, 28);
            this.btn_ara.TabIndex = 9;
            this.btn_ara.Text = "ARA";
            this.btn_ara.UseVisualStyleBackColor = true;
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // txt_film_ara
            // 
            this.txt_film_ara.Location = new System.Drawing.Point(645, 326);
            this.txt_film_ara.Name = "txt_film_ara";
            this.txt_film_ara.Size = new System.Drawing.Size(139, 20);
            this.txt_film_ara.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 436);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(576, 201);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(641, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Oyuncu Adi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(641, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Oyuncu Soyadi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(614, 484);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Oyuncunun Oynadigi Film";
            // 
            // txt_oy_film
            // 
            this.txt_oy_film.Location = new System.Drawing.Point(840, 484);
            this.txt_oy_film.Name = "txt_oy_film";
            this.txt_oy_film.Size = new System.Drawing.Size(121, 20);
            this.txt_oy_film.TabIndex = 13;
            // 
            // txt_oy_ara
            // 
            this.txt_oy_ara.Location = new System.Drawing.Point(714, 709);
            this.txt_oy_ara.Name = "txt_oy_ara";
            this.txt_oy_ara.Size = new System.Drawing.Size(139, 20);
            this.txt_oy_ara.TabIndex = 10;
            // 
            // btn_oy_ara
            // 
            this.btn_oy_ara.Location = new System.Drawing.Point(880, 709);
            this.btn_oy_ara.Name = "btn_oy_ara";
            this.btn_oy_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_oy_ara.TabIndex = 14;
            this.btn_oy_ara.Text = "ARA";
            this.btn_oy_ara.UseVisualStyleBackColor = true;
            this.btn_oy_ara.Click += new System.EventHandler(this.btn_oy_ara_Click);
            // 
            // btn_oy_ekle
            // 
            this.btn_oy_ekle.Location = new System.Drawing.Point(633, 641);
            this.btn_oy_ekle.Name = "btn_oy_ekle";
            this.btn_oy_ekle.Size = new System.Drawing.Size(75, 42);
            this.btn_oy_ekle.TabIndex = 15;
            this.btn_oy_ekle.Text = "Ekle";
            this.btn_oy_ekle.UseVisualStyleBackColor = true;
            this.btn_oy_ekle.Click += new System.EventHandler(this.btn_oy_ekle_Click);
            // 
            // btn_oy_guncelle
            // 
            this.btn_oy_guncelle.Location = new System.Drawing.Point(725, 641);
            this.btn_oy_guncelle.Name = "btn_oy_guncelle";
            this.btn_oy_guncelle.Size = new System.Drawing.Size(75, 42);
            this.btn_oy_guncelle.TabIndex = 15;
            this.btn_oy_guncelle.Text = "Güncelle";
            this.btn_oy_guncelle.UseVisualStyleBackColor = true;
            this.btn_oy_guncelle.Click += new System.EventHandler(this.btn_oy_guncelle_Click);
            // 
            // btn_oy_sil
            // 
            this.btn_oy_sil.Location = new System.Drawing.Point(817, 641);
            this.btn_oy_sil.Name = "btn_oy_sil";
            this.btn_oy_sil.Size = new System.Drawing.Size(75, 42);
            this.btn_oy_sil.TabIndex = 15;
            this.btn_oy_sil.Text = "Sil";
            this.btn_oy_sil.UseVisualStyleBackColor = true;
            this.btn_oy_sil.Click += new System.EventHandler(this.btn_oy_sil_Click);
            // 
            // btn_listele
            // 
            this.btn_listele.Location = new System.Drawing.Point(886, 250);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(75, 45);
            this.btn_listele.TabIndex = 16;
            this.btn_listele.Text = "Film Listele";
            this.btn_listele.UseVisualStyleBackColor = true;
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(695, 446);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Id";
            // 
            // txt_oy_id
            // 
            this.txt_oy_id.Enabled = false;
            this.txt_oy_id.Location = new System.Drawing.Point(840, 446);
            this.txt_oy_id.Name = "txt_oy_id";
            this.txt_oy_id.Size = new System.Drawing.Size(121, 20);
            this.txt_oy_id.TabIndex = 17;
            // 
            // btn_oy_listele
            // 
            this.btn_oy_listele.Location = new System.Drawing.Point(909, 641);
            this.btn_oy_listele.Name = "btn_oy_listele";
            this.btn_oy_listele.Size = new System.Drawing.Size(75, 42);
            this.btn_oy_listele.TabIndex = 18;
            this.btn_oy_listele.Text = "Listele";
            this.btn_oy_listele.UseVisualStyleBackColor = true;
            this.btn_oy_listele.Click += new System.EventHandler(this.btn_oy_listele_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(520, 709);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Oyuncunun Adini Giriniz";
            this.label10.Click += new System.EventHandler(this.label3_Click);
            // 
            // combo_oy_ad
            // 
            this.combo_oy_ad.FormattingEnabled = true;
            this.combo_oy_ad.Location = new System.Drawing.Point(840, 533);
            this.combo_oy_ad.Name = "combo_oy_ad";
            this.combo_oy_ad.Size = new System.Drawing.Size(121, 21);
            this.combo_oy_ad.TabIndex = 19;
            // 
            // combo_oy_soyad
            // 
            this.combo_oy_soyad.FormattingEnabled = true;
            this.combo_oy_soyad.Location = new System.Drawing.Point(840, 585);
            this.combo_oy_soyad.Name = "combo_oy_soyad";
            this.combo_oy_soyad.Size = new System.Drawing.Size(121, 21);
            this.combo_oy_soyad.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(513, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Tüm Filmler";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Filmler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 734);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.combo_oy_soyad);
            this.Controls.Add(this.combo_oy_ad);
            this.Controls.Add(this.btn_oy_listele);
            this.Controls.Add(this.txt_oy_id);
            this.Controls.Add(this.btn_listele);
            this.Controls.Add(this.btn_oy_sil);
            this.Controls.Add(this.btn_oy_guncelle);
            this.Controls.Add(this.btn_oy_ekle);
            this.Controls.Add(this.btn_oy_ara);
            this.Controls.Add(this.txt_oy_film);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_oy_ara);
            this.Controls.Add(this.txt_film_ara);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.txt_film_no);
            this.Controls.Add(this.txt_film_suresi);
            this.Controls.Add(this.combo_film_tur);
            this.Controls.Add(this.combo_film_format);
            this.Controls.Add(this.btn_flm_sil);
            this.Controls.Add(this.btn_flm_guncelle);
            this.Controls.Add(this.btn_flm_ekle);
            this.Controls.Add(this.txt_film_ad);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Filmler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filmler";
            this.Load += new System.EventHandler(this.Filmler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_film_ad;
        private System.Windows.Forms.Button btn_flm_ekle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_flm_guncelle;
        private System.Windows.Forms.Button btn_flm_sil;
        private System.Windows.Forms.ComboBox combo_film_format;
        private System.Windows.Forms.ComboBox combo_film_tur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_film_suresi;
        private System.Windows.Forms.TextBox txt_film_no;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_ara;
        private System.Windows.Forms.TextBox txt_film_ara;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_oy_film;
        private System.Windows.Forms.TextBox txt_oy_ara;
        private System.Windows.Forms.Button btn_oy_ara;
        private System.Windows.Forms.Button btn_oy_ekle;
        private System.Windows.Forms.Button btn_oy_guncelle;
        private System.Windows.Forms.Button btn_oy_sil;
        private System.Windows.Forms.Button btn_listele;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_oy_id;
        private System.Windows.Forms.Button btn_oy_listele;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combo_oy_ad;
        private System.Windows.Forms.ComboBox combo_oy_soyad;
        private System.Windows.Forms.Button button2;
    }
}