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
    public partial class Salonlar : Form
    {
        public Salonlar()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtys; user ID=postgres; password=sude2001");
        void Temizle()
        {
            txt_salonlar_id.Text = "";
            txt_koltuk_adedi.Text = "";
            txt_salon_no.Text = "";
            combo_bulunan_ssalon.Text = "";
        }
        void yenile()
        {
            string sorgu = "select * from salonlar_view order by ssalon_ad,salon_no asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void Salonlar_Load(object sender, EventArgs e)
        {
            yenile();

            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from sinemasalonu", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combo_bulunan_ssalon.DisplayMember = "ssalon_ad";
            combo_bulunan_ssalon.ValueMember = "ssalon_id";
            combo_bulunan_ssalon.DataSource = dt;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut1 = new NpgsqlCommand("insert into salonlar (sinemasalonu_id ,salon_no,koltuk_adedi) values ((select ssalon_id from sinemasalonu where ssalon_Ad='" + combo_bulunan_ssalon.Text + "'),'" + int.Parse(txt_salon_no.Text) + "','" + txt_koltuk_adedi.Text + "')", baglanti);
                komut1.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Salon Eklendi.");

                Temizle();
                yenile();
            }
            catch (Exception)
            {

                MessageBox.Show("Salon zaten mevcut");
                baglanti.Close();
            }
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            YöneticiGirisi yg = new YöneticiGirisi();
            yg.Show();
            this.Hide();
        }


        private void btn_salon_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from salonlar where salonlar_id=@p1 ", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_salonlar_id.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Salon Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            Temizle();
            yenile();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_salonlar_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            combo_bulunan_ssalon.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_salon_no.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_koltuk_adedi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void btn_salon_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update salonlar set sinemasalonu_id=(select ssalon_id from sinemasalonu where ssalon_ad='"+combo_bulunan_ssalon.Text+"'),salon_no=@p2,koltuk_adedi=@p3 where salonlar_id=@p4", baglanti);
         
            komut.Parameters.AddWithValue("@p2", int.Parse(txt_salon_no.Text));
            komut.Parameters.AddWithValue("@p3", int.Parse(txt_koltuk_adedi.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(txt_salonlar_id.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Salon Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();

            Temizle();
            yenile();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from salonlar_view where  ssalon_ad like '%" + txt_ara.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            yenile();
        }
    }
}
