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
    public partial class Filmler : Form
    {
        public Filmler()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtys; user ID=postgres; password=sude2001");
        void yenile()
        {
            string sorgu = "select * from filmler order by film_no";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        void yenile2()
        {
            string sorgu = "select distinct * from filmlerdeki_oyuncular_view order by film_adi,oyuncu_adi ";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da2.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }
        void Temizle()
        {
            txt_film_ad.Text = "";
            txt_film_no.Text = "";
            combo_film_format.Text = "";
            combo_film_tur.Text = "";
            txt_film_suresi.Text = "";
            txt_oy_film.Text = "";
            combo_oy_ad.Text = "";
            combo_oy_soyad.Text = "";
            txt_oy_id.Text = "";
        }
        private void Filmler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select distinct oyuncu_adi from oyuncular order by oyuncu_adi", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            combo_oy_ad.DisplayMember = "oyuncu_adi";
            combo_oy_ad.DataSource = dt2;
            baglanti.Close();

            

            baglanti.Open();
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select distinct oyuncu_soyadi from oyuncular order by oyuncu_soyadi", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            combo_oy_soyad.DisplayMember = "oyuncu_soyadi";
            combo_oy_soyad.DataSource = dt3;
            baglanti.Close();

            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from tur", baglanti);//tur tablosundan alincak
            DataTable dt = new DataTable();
            da.Fill(dt);
            combo_film_tur.DisplayMember = "tur_adi";
            combo_film_tur.ValueMember = "tur_id";
            combo_film_tur.DataSource = dt;
            baglanti.Close();

            yenile();
            yenile2();
            Temizle();
        }

        private void btn_flm_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut1 = new NpgsqlCommand("insert into filmler (film_adi,film_tur,film_format,film_suresi) values (@p1,@p2,@p3,@p4)", baglanti);
                komut1.Parameters.AddWithValue("@p1", txt_film_ad.Text);
                komut1.Parameters.AddWithValue("@p2", combo_film_tur.Text);
                komut1.Parameters.AddWithValue("@p3", combo_film_format.Text);
                komut1.Parameters.AddWithValue("@p4", txt_film_suresi.Text);
                komut1.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Film Eklendi.");

                Temizle();
                yenile();
                yenile2();

            }
            catch (Exception)
            {

                MessageBox.Show("Bu film daha önce eklendi", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_film_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_film_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            combo_film_tur.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            combo_film_format.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_film_suresi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btn_flm_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from filmler where film_no=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_film_no.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            Temizle();
            yenile();
            yenile2();
        }

        private void btn_flm_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update filmler set film_adi=@p1,film_tur=@p2,film_format=@p3,film_suresi=@p4 where film_no=@p5", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_film_ad.Text);
            komut.Parameters.AddWithValue("@p2", combo_film_tur.Text);
            komut.Parameters.AddWithValue("@p3", combo_film_format.Text);
            komut.Parameters.AddWithValue("@p4", txt_film_suresi.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(txt_film_no.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Film Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();

            Temizle();
            yenile();
            yenile2();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from filmler where film_adi like '%" + txt_film_ara.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YöneticiGirisi yg = new YöneticiGirisi();
            yg.Show();
            this.Hide();
        }


        private void btn_oy_ekle_Click(object sender, EventArgs e)
        {
         
                baglanti.Open();
                NpgsqlCommand komut2 = new NpgsqlCommand("insert into filmdeki_oyuncular (oyuncu,film) values ((select oyuncu_id from oyuncular where oyuncu_adi='" + combo_oy_ad.Text + "'and oyuncu_soyadi='"+combo_oy_soyad.Text+"'), (select film_no from filmler where film_adi='" + txt_oy_film.Text + "'))", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Filmdeki Oyuncu Eklendi.");

                Temizle();
                yenile();
                yenile2();

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            yenile();
        }

        private void btn_oy_ara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from oyuncu_bul('" + txt_oy_ara.Text + "')", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btn_oy_guncelle_Click(object sender, EventArgs e)        
        {

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update filmdeki_oyuncular set oyuncu=(select oyuncu_id from oyuncular where oyuncu_adi='"+combo_oy_ad.Text+"' and oyuncu_soyadi='"+combo_oy_soyad.Text+"') ,film=(select film_no from filmler where film_adi='"+txt_oy_film.Text+"')  where fo_no=@p5 ", baglanti);
            komut.Parameters.AddWithValue("@p5", int.Parse(txt_oy_id.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Filmdeki Oyuncu Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();

            Temizle();
            yenile();
            yenile2();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_oy_id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txt_oy_film.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            combo_oy_ad.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            combo_oy_soyad.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_oy_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from filmdeki_oyuncular where fo_no=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_oy_id.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Filmdeki Oyuncu Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            Temizle();
            yenile();
            yenile2();
        }

        private void btn_oy_listele_Click(object sender, EventArgs e)
        {
            yenile2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from tumfilmler()", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
