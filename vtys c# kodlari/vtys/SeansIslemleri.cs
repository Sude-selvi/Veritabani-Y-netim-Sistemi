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
    public partial class SeansIslemleri : Form
    {
        public SeansIslemleri()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtys; user ID=postgres; password=sude2001");

        void yenile()
        {
          
            string sorgu = "select * from seans_islemleri_view";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        void Temizle()
        {
            combo_film_format.Text = "";
            combo_film_adi.Text = "";
            txt_tarih.Text = "";
            txt_id.Text = "";

        }
        private void SeansIslemleri_Load(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select distinct film_adi from filmler", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            combo_film_adi.DisplayMember = "film_adi";
            combo_film_adi.ValueMember = "film_no";
            combo_film_adi.DataSource = dt2;
            baglanti.Close();

            yenile();
            Temizle();
        }

        private void combo_film_format_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string seans = "";
        void RadioButtonSecildiyse()
        {
            if (radioButton1.Checked == true) seans = radioButton1.Text;
            else if (radioButton2.Checked == true) seans = radioButton2.Text;
            else if (radioButton6.Checked == true) seans = radioButton6.Text;
            else if (radioButton3.Checked == true) seans = radioButton3.Text;
            else if (radioButton4.Checked == true) seans = radioButton4.Text;
            else if (radioButton5.Checked == true) seans = radioButton5.Text;
            else if (radioButton7.Checked == true) seans = radioButton7.Text;
            else if (radioButton8.Checked == true) seans = radioButton8.Text;
            else if (radioButton9.Checked == true) seans = radioButton9.Text;

        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            RadioButtonSecildiyse();

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into film_seans (seans,film,seans_tarih) values ((select seans_id from seanslar where seans_saat='"+seans.ToString()+"'),(select film_no from filmler where film_adi='" + combo_film_adi.Text + "' and film_format='" + combo_film_format.Text + "' ),'"+txt_tarih.Text+"')", baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Seans Eklendi.");

            Temizle();
            yenile();
        }
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            RadioButtonSecildiyse();

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update film_seans set seans=(select seans_id from seanslar where seans_saat='"+seans.ToString()+"'),film=(select film_no from filmler where film_adi='"+combo_film_adi.Text+"' and film_format='"+combo_film_format.Text+"'),seans_tarih='"+txt_tarih.Text+ "' where film_seans_id='" + int.Parse(txt_id.Text) + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Salon Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();

            Temizle();
            yenile();
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
        }

        private void button1_Click(object sender, EventArgs e)      //SILINDIIIIIIIIIIIIIIIIII
        {
       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            combo_film_adi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            combo_film_format.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_tarih.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)  //SILME ISLEMI
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from film_seans where film_seans_id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_id.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Seans Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            Temizle();
            yenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from seans_islemleri_view where seans_tarih='" + txt_ara.Text + "'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            YöneticiGirisi yg = new YöneticiGirisi();
            yg.Show();
            this.Hide();
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            yenile();
        }
    }
}
