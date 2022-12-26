
namespace vtys
{
    partial class Salonlar
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
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_salon_no = new System.Windows.Forms.TextBox();
            this.txt_koltuk_adedi = new System.Windows.Forms.TextBox();
            this.combo_bulunan_ssalon = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_salon_guncelle = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_salon_sil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_salonlar_id = new System.Windows.Forms.TextBox();
            this.txt_ara = new System.Windows.Forms.TextBox();
            this.btn_ara = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_listele = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(577, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Bulundugu Sinema Salonu";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(523, 359);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(577, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Salon No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(577, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Koltuk Adedi";
            // 
            // txt_salon_no
            // 
            this.txt_salon_no.Location = new System.Drawing.Point(807, 133);
            this.txt_salon_no.Name = "txt_salon_no";
            this.txt_salon_no.Size = new System.Drawing.Size(157, 20);
            this.txt_salon_no.TabIndex = 4;
            // 
            // txt_koltuk_adedi
            // 
            this.txt_koltuk_adedi.Location = new System.Drawing.Point(807, 181);
            this.txt_koltuk_adedi.Name = "txt_koltuk_adedi";
            this.txt_koltuk_adedi.Size = new System.Drawing.Size(157, 20);
            this.txt_koltuk_adedi.TabIndex = 4;
            // 
            // combo_bulunan_ssalon
            // 
            this.combo_bulunan_ssalon.FormattingEnabled = true;
            this.combo_bulunan_ssalon.Location = new System.Drawing.Point(807, 84);
            this.combo_bulunan_ssalon.Name = "combo_bulunan_ssalon";
            this.combo_bulunan_ssalon.Size = new System.Drawing.Size(121, 21);
            this.combo_bulunan_ssalon.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 58);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_salon_guncelle
            // 
            this.btn_salon_guncelle.Location = new System.Drawing.Point(699, 248);
            this.btn_salon_guncelle.Name = "btn_salon_guncelle";
            this.btn_salon_guncelle.Size = new System.Drawing.Size(98, 58);
            this.btn_salon_guncelle.TabIndex = 6;
            this.btn_salon_guncelle.Text = "Güncelle";
            this.btn_salon_guncelle.UseVisualStyleBackColor = true;
            this.btn_salon_guncelle.Click += new System.EventHandler(this.btn_salon_guncelle_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Geri";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_salon_sil
            // 
            this.btn_salon_sil.Location = new System.Drawing.Point(816, 248);
            this.btn_salon_sil.Name = "btn_salon_sil";
            this.btn_salon_sil.Size = new System.Drawing.Size(98, 58);
            this.btn_salon_sil.TabIndex = 9;
            this.btn_salon_sil.Text = "Sil";
            this.btn_salon_sil.UseVisualStyleBackColor = true;
            this.btn_salon_sil.Click += new System.EventHandler(this.btn_salon_sil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(577, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Id";
            // 
            // txt_salonlar_id
            // 
            this.txt_salonlar_id.Location = new System.Drawing.Point(807, 36);
            this.txt_salonlar_id.Name = "txt_salonlar_id";
            this.txt_salonlar_id.Size = new System.Drawing.Size(157, 20);
            this.txt_salonlar_id.TabIndex = 10;
            // 
            // txt_ara
            // 
            this.txt_ara.Location = new System.Drawing.Point(784, 382);
            this.txt_ara.Name = "txt_ara";
            this.txt_ara.Size = new System.Drawing.Size(133, 20);
            this.txt_ara.TabIndex = 11;
            // 
            // btn_ara
            // 
            this.btn_ara.Location = new System.Drawing.Point(956, 379);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_ara.TabIndex = 12;
            this.btn_ara.Text = "Ara";
            this.btn_ara.UseVisualStyleBackColor = true;
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(794, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sinema Salonunu Giriniz";
            // 
            // btn_listele
            // 
            this.btn_listele.Location = new System.Drawing.Point(933, 248);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(98, 58);
            this.btn_listele.TabIndex = 13;
            this.btn_listele.Text = "Listele";
            this.btn_listele.UseVisualStyleBackColor = true;
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_Click);
            // 
            // Salonlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 444);
            this.Controls.Add(this.btn_listele);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.txt_ara);
            this.Controls.Add(this.txt_salonlar_id);
            this.Controls.Add(this.btn_salon_sil);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_salon_guncelle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combo_bulunan_ssalon);
            this.Controls.Add(this.txt_koltuk_adedi);
            this.Controls.Add(this.txt_salon_no);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Name = "Salonlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salonlar";
            this.Load += new System.EventHandler(this.Salonlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_salon_no;
        private System.Windows.Forms.TextBox txt_koltuk_adedi;
        private System.Windows.Forms.ComboBox combo_bulunan_ssalon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_salon_guncelle;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_salon_sil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_salonlar_id;
        private System.Windows.Forms.TextBox txt_ara;
        private System.Windows.Forms.Button btn_ara;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_listele;
    }
}