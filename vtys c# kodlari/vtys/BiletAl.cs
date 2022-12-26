using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vtys
{
    public partial class BiletAl : Form
    {
        public BiletAl()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtys; user ID=postgres; password=sude2001");

        void temizle()
        {
            combo_film_adi.Text = "";
            combo_film_format.Text = "";
            combo_ssalon_ad.Text = "";
            combo_tarih.Text = "";
            combo_seans.Text = "";
            combo_mus.Text = "";
            txt_koltuk_no.Text = "";
            txt_ad.Text = "";
            txt_soyad.Text = "";
            txt_tel.Text = "";
            combo_yiy.Text = "";
            combo_ic.Text = "";
            combo_yiy_fiyat.Text = "0";
            combo_ic_fiyat.Text = "0";

        }

        void ucret_hesaplama()
        {
            if (combo_mus.Text == "Yetiskin")
            {
                int ucret = int.Parse(lbl_yet_fiyat.Text) + int.Parse(combo_yiy_fiyat.Text) + int.Parse(combo_ic_fiyat.Text);
                txt_ucret.Text = ucret.ToString();
            }
            else if (combo_mus.Text == "Ogrenci")
            {
                int ucret = int.Parse(lbl_og_fiyat.Text) + int.Parse(combo_yiy_fiyat.Text) + int.Parse(combo_ic_fiyat.Text);
                txt_ucret.Text = ucret.ToString();
            }

        }

        void VeriTabani_Dolu_Koltuklar()
        {
           
            NpgsqlCommand komut = new NpgsqlCommand("select koltuk_no from koltuklar where salonlar_id = (select salonlar_id from salonlar where salon_no='"+combo_salon_no.Text+"' and sinemasalonu_id =(select ssalon_id from sinemasalonu where ssalon_ad='"+combo_ssalon_ad.Text+"'))", baglanti);

            NpgsqlDataReader read = komut.ExecuteReader();
            

            while (read.Read())
            {

                foreach (Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (read["koltuk_no"].ToString() == item.Text) 
                        {
                            item.BackColor = Color.Red;
                        }

                    }
                }
            }
            read.Close();

           
        }

        void beyaza_cevir()
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }

        void yeniden_renklendir()
        {
            foreach (Control item in panel1.Controls)
            {
                if(item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }



        int sayac = 0;
        private void Seanslar_Load(object sender, EventArgs e)
        {
           

            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(j * 30 + 20, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    btn.BackColor = Color.White;
                    if (j == 4)
                    {
                        continue;
                    }
                    sayac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;

                }


            }

            baglanti.Open();
            

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from sinemasalonu", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combo_ssalon_ad.DisplayMember = "ssalon_ad";
            combo_ssalon_ad.ValueMember = "ssalon_id";
            combo_ssalon_ad.DataSource = dt;
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select distinct film_adi from filmler", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            combo_film_adi.DisplayMember = "film_adi";
            combo_film_adi.ValueMember = "film_no";
            combo_film_adi.DataSource = dt2;
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select * from yiyecekler_view ", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            combo_yiy.DisplayMember = "yiyecek_ad";
            combo_yiy.DataSource = dt3;
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter("select * from icecekler_view ", baglanti);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            combo_ic.DisplayMember = "icecek_ad";
            combo_ic.DataSource = dt4;
            baglanti.Close();


            temizle();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == Color.White)
            {
                txt_koltuk_no.Text = b.Text;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void combo_ssalon_no_SelectedIndexChanged(object sender, EventArgs e)
        {

            combo_salon_no.Text = "";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select salon_no from salonlar where sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "')", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combo_salon_no.DisplayMember = "salon_no";
            combo_salon_no.ValueMember = "salon_no";
            combo_salon_no.DataSource = dt;
            baglanti.Close();
        }

        private void combo_film_adi_SelectedIndexChanged(object sender, EventArgs e)
        {

            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select film_format from filmler where film_adi='" + combo_film_adi.Text + "'", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            combo_film_format.DisplayMember = "film_format";
            combo_film_format.ValueMember = "film_format";
            combo_film_format.DataSource = dt2;
            baglanti.Close();

            combo_film_format.Text = "";


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void combo_film_format_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select distinct seans_tarih from film_seans where film=(select film_no from filmler where film_adi ='" + combo_film_adi.Text + "' and film_format='" + combo_film_format.Text + "')", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            combo_tarih.DisplayMember = "seans_tarih";
            combo_tarih.ValueMember = "seans_tarih";
            combo_tarih.DataSource = dt3;

            baglanti.Close();
            combo_tarih.Text = "";

        }

        private void combo_seans_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void combo_tarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select seans_saat from seanslar where seans_id in(select seans from film_seans WHERE film=(select film_no from filmler where film_adi='" + combo_film_adi.Text + "' and film_format='" + combo_film_format.Text + "') and seans_tarih='" + combo_tarih.Text + "')", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            combo_seans.DisplayMember = "seans_saat";
            combo_seans.ValueMember = "seans_saat";
            combo_seans.DataSource = dt3;
            baglanti.Close();

            combo_seans.Text = "";
        }

        private void combo_salon_no_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void combo_mus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ucret_hesaplama();

            }
            catch (Exception ex)
            {

                MessageBox.Show("hata olustu");

            }

        }
        void kontrol()
        {
            string musteri = combo_mus.Text;
            if (musteri == "Yetiskin")
            {
                baglanti.Open();
                NpgsqlCommand komut6 = new NpgsqlCommand("insert into yetiskin (musteri_id,bilet_fiyat) values ((select musteri_id from musteri where musteri_ad='" + txt_ad.Text + "' and musteri_soyad='" + txt_soyad.Text + "' and musteri_tel='" + txt_tel.Text + "'),@p2)", baglanti);
                komut6.Parameters.AddWithValue("@p2", int.Parse(lbl_yet_fiyat.Text));
                komut6.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (musteri == "Ogrenci")
            {
                baglanti.Open();
                NpgsqlCommand komut7 = new NpgsqlCommand("insert into ogrenci (musteri_id,bilet_fiyat) values ((select musteri_id from musteri where musteri_ad='" + txt_ad.Text + "' and musteri_soyad='" + txt_soyad.Text + "' and musteri_tel='" + txt_tel.Text + "'),@p2)", baglanti);
                komut7.Parameters.AddWithValue("@p2", int.Parse(lbl_og_fiyat.Text));
                komut7.ExecuteNonQuery();
                baglanti.Close();
            }
        }

        private void btn_bilet_al_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string musteri = combo_mus.Text;
            if (musteri == "Yetiskin")
            {
                musteri = "Y";
            }
            else musteri = "O";

            try
            {
                NpgsqlCommand komut2 = new NpgsqlCommand("insert into musteri (musteri_ad,musteri_soyad,musteri_tel,musteri_tur) values (@p1,@p2,@p3,@p4)", baglanti);
                komut2.Parameters.AddWithValue("@p1", txt_ad.Text);
                komut2.Parameters.AddWithValue("@p2", txt_soyad.Text);
                komut2.Parameters.AddWithValue("@p3", txt_tel.Text);
                komut2.Parameters.AddWithValue("@p4", musteri);
                komut2.ExecuteNonQuery();

                NpgsqlCommand komut3 = new NpgsqlCommand("insert into koltuklar (salonlar_id,koltuk_no) values ((select salonlar_id from salonlar where salon_no='" + combo_salon_no.Text + "' and sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "')),@p2)", baglanti);
                komut3.Parameters.AddWithValue("@p2", txt_koltuk_no.Text);
                komut3.ExecuteNonQuery();

                NpgsqlCommand komut1 = new NpgsqlCommand("insert into biletler (ssalon_id,salonlar_id,film_no,bufe_id,seans_saat,seans_tarih,musteri,fiyat,koltuk_no) values ((select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "'),(select salonlar_id from salonlar where salon_no ='" + combo_salon_no.Text + "' and sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "')),(select film_no from filmler where film_adi='" + combo_film_adi.Text + "' and film_format='" + combo_film_format.Text + "'),(select bufe_id from yiyecekler where yiyecek_ad='" + combo_yiy.Text + "'),(select seans_id from seanslar where seans_saat='" + combo_seans.Text + "'),(select film_seans_id from film_seans where seans_tarih='" + combo_tarih.Text + "' and film=(select film_no from filmler where film_adi='" + combo_film_adi.Text + "' and film_format='" + combo_film_format.Text + "') and seans=(select seans_id from seanslar where seans_saat='" + combo_seans.Text + "')),(select musteri_id from musteri where  musteri_tel='" + txt_tel.Text + "'),'" + int.Parse(txt_ucret.Text) + "',(select koltuklar_id from koltuklar where koltuk_no='" + txt_koltuk_no.Text + "' and salonlar_id=(select salonlar_id from salonlar where salon_no='" + combo_salon_no.Text + "' and sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "'))))", baglanti);
                komut1.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Bileti aldiniz \n BILET BILGILERI \n Ad: " + txt_ad.Text + "'\n Soyad: " + txt_soyad.Text + "\n Film Adi: " + combo_film_adi.Text + "\n Film Formati: " + combo_film_format.Text + "\n Sinema Salonu: " + combo_ssalon_ad.Text + "\n Salon No: " + combo_salon_no.Text + "\n Tarih: " + combo_tarih.Text + "\n Seans: " + combo_seans.Text + "\n Koltuk: " + txt_koltuk_no.Text + "\n Yiyecek: " + combo_yiy.Text + "\n Icecek: " + combo_ic.Text + "\n Musteri Türü: " + combo_mus.Text + "\n Ücret: " + txt_ucret.Text + "\n Bilet Alis Tarihi:" + dateTimePicker1.Text + "\n IYI SEYIRLER :)");
                kontrol();
            }
            catch (Exception ex)
            {
                NpgsqlCommand komut4 = new NpgsqlCommand("insert into koltuklar (salonlar_id,koltuk_no) values ((select salonlar_id from salonlar where salon_no='" + combo_salon_no.Text + "' and sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "')),@p2)", baglanti);
                komut4.Parameters.AddWithValue("@p2", txt_koltuk_no.Text);
                komut4.ExecuteNonQuery();

                NpgsqlCommand komut5 = new NpgsqlCommand("insert into biletler (ssalon_id,salonlar_id,film_no,bufe_id,seans_saat,seans_tarih,musteri,fiyat,koltuk_no) values ((select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "'),(select salonlar_id from salonlar where salon_no ='" + combo_salon_no.Text + "' and sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "')),(select film_no from filmler where film_adi='" + combo_film_adi.Text + "' and film_format='" + combo_film_format.Text + "'),(select bufe_id from yiyecekler where yiyecek_ad='" + combo_yiy.Text + "'),(select seans_id from seanslar where seans_saat='" + combo_seans.Text + "'),(select film_seans_id from film_seans where seans_tarih='" + combo_tarih.Text + "' and film=(select film_no from filmler where film_adi='" + combo_film_adi.Text + "' and film_format='" + combo_film_format.Text + "') and seans=(select seans_id from seanslar where seans_saat='" + combo_seans.Text + "')),(select musteri_id from musteri where  musteri_tel='" + txt_tel.Text + "'),'" + int.Parse(txt_ucret.Text) + "',(select koltuklar_id from koltuklar where koltuk_no='" + txt_koltuk_no.Text + "' and salonlar_id=(select salonlar_id from salonlar where salon_no='" + combo_salon_no.Text + "' and sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='" + combo_ssalon_ad.Text + "'))))", baglanti);
                komut5.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Bileti aldiniz \n BILET BILGILERI \n Ad: " + txt_ad.Text + "'\n Soyad: " + txt_soyad.Text + "\n Film Adi: " + combo_film_adi.Text + "\n Film Formati: " + combo_film_format.Text + "\n Sinema Salonu: " + combo_ssalon_ad.Text + "\n Salon No: " + combo_salon_no.Text + "\n Tarih: " + combo_tarih.Text + "\n Seans: " + combo_seans.Text + "\n Koltuk: " + txt_koltuk_no.Text + "\n Yiyecek: " + combo_yiy.Text + "\n Icecek: " + combo_ic.Text + "\n Musteri Türü: " + combo_mus.Text + "\n Ücret: " + txt_ucret.Text + "\n Bilet Alis Tarihi:" + dateTimePicker1.Text + "\n IYI SEYIRLER :)");

            }



;
            temizle();
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Form1 yg = new Form1();
            yg.Show();
            this.Hide();
        }

        private void combo_yiy_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select fiyat from yiyecekler where yiyecek_ad='" + combo_yiy.Text + "'", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            combo_yiy_fiyat.DisplayMember = "fiyat";
            combo_yiy_fiyat.ValueMember = "fiyat";
            combo_yiy_fiyat.DataSource = dt3;
            baglanti.Close();
            ucret_hesaplama();
        }

        private void combo_ic_SelectedIndexChanged(object sender, EventArgs e)
        {
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select fiyat from icecekler where icecek_ad='" + combo_ic.Text + "'", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            combo_ic_fiyat.DisplayMember = "fiyat";
            combo_ic_fiyat.ValueMember = "fiyat";
            combo_ic_fiyat.DataSource = dt3;
            baglanti.Close();
            ucret_hesaplama();
        }
    }
}
