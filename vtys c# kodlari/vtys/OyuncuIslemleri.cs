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
    public partial class OyuncuIslemleri : Form
    {
        public OyuncuIslemleri()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtys; user ID=postgres; password=sude2001");

        void yenile()
        {
            string sorgu = "select * from oyuncular order by oyuncu_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        void Temizle()
        {
            txt_oy_ad.Text = "";
            txt_oy_soyad.Text = "";
            txt_oy_no.Text = "";
        }
        private void btn_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into oyuncular (oyuncu_adi,oyuncu_soyadi) values (@p1,@p2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", txt_oy_ad.Text);
            komut1.Parameters.AddWithValue("@p2", txt_oy_soyad.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Oyuncu Eklendi.");

            Temizle();
            yenile();
        }

        private void OyuncuIslemleri_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update oyuncular set oyuncu_adi=@p1,oyuncu_soyadi=@p2 where oyuncu_id=@p5", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_oy_ad.Text);
            komut.Parameters.AddWithValue("@p2", txt_oy_soyad.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(txt_oy_no.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Oyuncu Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();

            Temizle();
            yenile();
        }

        private void dataGridView1_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_oy_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_oy_ad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_oy_soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from oyuncular where oyuncu_id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_oy_no.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oyuncu Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            Temizle();
            yenile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YöneticiGirisi yg = new YöneticiGirisi();
            yg.Show();
            this.Hide();
        }
    }
}
