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
    public partial class SinemaSalonlari : Form
    {
        public SinemaSalonlari()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtys; user ID=postgres; password=sude2001"); 
        void Temizle()
        {
            txt_ssalon_ad.Text = "";
            txt_ssalon_adres.Text = "";
            txt_ssalon_id.Text = "";
            txt_ssalon_iletisim.Text = "";
            combo_il.Text = "";
        }
        void yenile()
        {
            string sorgu = "select * from sinemasalonu_view order by il_adi";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void SinemaSalonlari_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from iller", baglanti);//il tablosundan alincak
            DataTable dt = new DataTable();
            da.Fill(dt);
            combo_il.DisplayMember = "il_adi";
            combo_il.ValueMember = "il_no";
            combo_il.DataSource = dt;
            baglanti.Close();

            yenile();

        }

       
        private void btn_ssalon_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into sinemasalonu (il,ssalon_ad,ssalon_adres,ssalon_iletisim) values ((select il_no from iller where il_adi='"+combo_il.Text+"'),'"+txt_ssalon_ad.Text+"','"+txt_ssalon_adres.Text+"','"+txt_ssalon_iletisim.Text+"')", baglanti);

            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sinema Salonu Eklendi.");

            Temizle();
            yenile();
        }

        private void btn_ssalon_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from sinemasalonu where ssalon_id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_ssalon_id.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sinema Salonu Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            Temizle();
            yenile();
        }

        private void btn_ssalon_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update sinemasalonu set il=(select il_no from iller where il_adi='"+combo_il.Text+"'),ssalon_ad=@p2,ssalon_adres=@p3,ssalon_iletisim=@p4 where ssalon_id=@p5", baglanti);
            komut.Parameters.AddWithValue("@p2", txt_ssalon_ad.Text);
            komut.Parameters.AddWithValue("@p3", txt_ssalon_adres.Text);
            komut.Parameters.AddWithValue("@p4", txt_ssalon_iletisim.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(txt_ssalon_id.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Sinema Salonu Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();

            Temizle();
            yenile();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ssalon_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            combo_il.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_ssalon_ad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_ssalon_adres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_ssalon_iletisim.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btn_ssalon_toplami_Click(object sender, EventArgs e)
        {
            string sorgu = "select sayi as Toplam_Sinema_Salonu_Sayisi from ssalontoplami";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from sinemasalonu where ssalon_ad like '%" + txt_ssalon_ara.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void combo_il_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
