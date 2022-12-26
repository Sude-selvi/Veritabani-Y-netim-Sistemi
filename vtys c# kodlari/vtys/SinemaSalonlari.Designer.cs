
namespace vtys
{
    partial class SinemaSalonlari
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_il = new System.Windows.Forms.ComboBox();
            this.txt_ssalon_id = new System.Windows.Forms.TextBox();
            this.txt_ssalon_ad = new System.Windows.Forms.TextBox();
            this.txt_ssalon_adres = new System.Windows.Forms.TextBox();
            this.txt_ssalon_iletisim = new System.Windows.Forms.TextBox();
            this.btn_ssalon_sil = new System.Windows.Forms.Button();
            this.btn_ssalon_guncelle = new System.Windows.Forms.Button();
            this.btn_ssalon_ekle = new System.Windows.Forms.Button();
            this.btn_ssalon_toplami = new System.Windows.Forms.Button();
            this.btn_ara = new System.Windows.Forms.Button();
            this.txt_ssalon_ara = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_listele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(479, 445);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(524, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "İletisim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(524, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Adres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(524, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(524, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "İd";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(524, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "İl";
            // 
            // combo_il
            // 
            this.combo_il.FormattingEnabled = true;
            this.combo_il.Location = new System.Drawing.Point(669, 103);
            this.combo_il.Name = "combo_il";
            this.combo_il.Size = new System.Drawing.Size(121, 21);
            this.combo_il.TabIndex = 7;
            this.combo_il.SelectedIndexChanged += new System.EventHandler(this.combo_il_SelectedIndexChanged);
            // 
            // txt_ssalon_id
            // 
            this.txt_ssalon_id.Enabled = false;
            this.txt_ssalon_id.Location = new System.Drawing.Point(669, 68);
            this.txt_ssalon_id.Name = "txt_ssalon_id";
            this.txt_ssalon_id.Size = new System.Drawing.Size(184, 20);
            this.txt_ssalon_id.TabIndex = 8;
            // 
            // txt_ssalon_ad
            // 
            this.txt_ssalon_ad.Location = new System.Drawing.Point(669, 148);
            this.txt_ssalon_ad.Name = "txt_ssalon_ad";
            this.txt_ssalon_ad.Size = new System.Drawing.Size(184, 20);
            this.txt_ssalon_ad.TabIndex = 8;
            // 
            // txt_ssalon_adres
            // 
            this.txt_ssalon_adres.Location = new System.Drawing.Point(669, 193);
            this.txt_ssalon_adres.Name = "txt_ssalon_adres";
            this.txt_ssalon_adres.Size = new System.Drawing.Size(184, 20);
            this.txt_ssalon_adres.TabIndex = 8;
            // 
            // txt_ssalon_iletisim
            // 
            this.txt_ssalon_iletisim.Location = new System.Drawing.Point(669, 238);
            this.txt_ssalon_iletisim.Name = "txt_ssalon_iletisim";
            this.txt_ssalon_iletisim.Size = new System.Drawing.Size(184, 20);
            this.txt_ssalon_iletisim.TabIndex = 8;
            // 
            // btn_ssalon_sil
            // 
            this.btn_ssalon_sil.Location = new System.Drawing.Point(633, 311);
            this.btn_ssalon_sil.Name = "btn_ssalon_sil";
            this.btn_ssalon_sil.Size = new System.Drawing.Size(89, 57);
            this.btn_ssalon_sil.TabIndex = 10;
            this.btn_ssalon_sil.Text = "Sil";
            this.btn_ssalon_sil.UseVisualStyleBackColor = true;
            this.btn_ssalon_sil.Click += new System.EventHandler(this.btn_ssalon_sil_Click);
            // 
            // btn_ssalon_guncelle
            // 
            this.btn_ssalon_guncelle.Location = new System.Drawing.Point(728, 311);
            this.btn_ssalon_guncelle.Name = "btn_ssalon_guncelle";
            this.btn_ssalon_guncelle.Size = new System.Drawing.Size(89, 57);
            this.btn_ssalon_guncelle.TabIndex = 10;
            this.btn_ssalon_guncelle.Text = "Güncelle";
            this.btn_ssalon_guncelle.UseVisualStyleBackColor = true;
            this.btn_ssalon_guncelle.Click += new System.EventHandler(this.btn_ssalon_guncelle_Click);
            // 
            // btn_ssalon_ekle
            // 
            this.btn_ssalon_ekle.Location = new System.Drawing.Point(538, 311);
            this.btn_ssalon_ekle.Name = "btn_ssalon_ekle";
            this.btn_ssalon_ekle.Size = new System.Drawing.Size(89, 57);
            this.btn_ssalon_ekle.TabIndex = 10;
            this.btn_ssalon_ekle.Text = "Ekle";
            this.btn_ssalon_ekle.UseVisualStyleBackColor = true;
            this.btn_ssalon_ekle.Click += new System.EventHandler(this.btn_ssalon_ekle_Click);
            // 
            // btn_ssalon_toplami
            // 
            this.btn_ssalon_toplami.Location = new System.Drawing.Point(586, 381);
            this.btn_ssalon_toplami.Name = "btn_ssalon_toplami";
            this.btn_ssalon_toplami.Size = new System.Drawing.Size(89, 57);
            this.btn_ssalon_toplami.TabIndex = 11;
            this.btn_ssalon_toplami.Text = "Toplam Sinema Salonu Sayisi";
            this.btn_ssalon_toplami.UseVisualStyleBackColor = true;
            this.btn_ssalon_toplami.Click += new System.EventHandler(this.btn_ssalon_toplami_Click);
            // 
            // btn_ara
            // 
            this.btn_ara.Location = new System.Drawing.Point(788, 467);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_ara.TabIndex = 12;
            this.btn_ara.Text = "Ara";
            this.btn_ara.UseVisualStyleBackColor = true;
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // txt_ssalon_ara
            // 
            this.txt_ssalon_ara.Location = new System.Drawing.Point(621, 467);
            this.txt_ssalon_ara.Name = "txt_ssalon_ara";
            this.txt_ssalon_ara.Size = new System.Drawing.Size(126, 20);
            this.txt_ssalon_ara.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Geri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_listele
            // 
            this.btn_listele.Location = new System.Drawing.Point(681, 381);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(89, 57);
            this.btn_listele.TabIndex = 16;
            this.btn_listele.Text = "Listele";
            this.btn_listele.UseVisualStyleBackColor = true;
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_Click);
            // 
            // SinemaSalonlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 509);
            this.Controls.Add(this.btn_listele);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_ssalon_ara);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.btn_ssalon_toplami);
            this.Controls.Add(this.btn_ssalon_ekle);
            this.Controls.Add(this.btn_ssalon_guncelle);
            this.Controls.Add(this.btn_ssalon_sil);
            this.Controls.Add(this.txt_ssalon_iletisim);
            this.Controls.Add(this.txt_ssalon_adres);
            this.Controls.Add(this.txt_ssalon_ad);
            this.Controls.Add(this.txt_ssalon_id);
            this.Controls.Add(this.combo_il);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SinemaSalonlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SinemaSalonlari";
            this.Load += new System.EventHandler(this.SinemaSalonlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_il;
        private System.Windows.Forms.TextBox txt_ssalon_id;
        private System.Windows.Forms.TextBox txt_ssalon_ad;
        private System.Windows.Forms.TextBox txt_ssalon_adres;
        private System.Windows.Forms.TextBox txt_ssalon_iletisim;
        private System.Windows.Forms.Button btn_ssalon_sil;
        private System.Windows.Forms.Button btn_ssalon_guncelle;
        private System.Windows.Forms.Button btn_ssalon_ekle;
        private System.Windows.Forms.Button btn_ssalon_toplami;
        private System.Windows.Forms.Button btn_ara;
        private System.Windows.Forms.TextBox txt_ssalon_ara;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_listele;
    }
}