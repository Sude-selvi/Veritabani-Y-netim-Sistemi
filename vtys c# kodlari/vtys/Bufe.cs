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
    public partial class Bufe : Form
    {
        public Bufe()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtys; user ID=postgres; password=sude2001");
        private void btn_geri_Click(object sender, EventArgs e)
        {
            YöneticiGirisi yg = new YöneticiGirisi();
            yg.Show();
            this.Hide();
        }
        void yenile()
        {
            string sorgu = "select bufe_id,yiyecek_no,yiyecek_ad,fiyat from yiyecekler order by yiyecek_no";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            datagrid_yiy.DataSource = ds.Tables[0];
        }

        void yenile2()
        {
            string sorgu = "select bufe_id,icecek_no,icecek_ad,fiyat from icecekler order by icecek_no";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            datagrid_icecek.DataSource = ds.Tables[0];
        }

        void Temizle()
        {
            txt_ic_fiyat.Text = "";
            txt_yiy_fiyat.Text = "";
            txt_yiyecek.Text = "";
            txt_icecek.Text = "";
        }
        private void Bufe_Load(object sender, EventArgs e)
        {
            yenile();
            yenile2();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("insert into icecekler (bufe_id,icecek_ad,fiyat) values (@p1,@p2,@p3)", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(txt_ic_bufe.Text));
            komut2.Parameters.AddWithValue("@p2", txt_icecek.Text);
            komut2.Parameters.AddWithValue("@p3", int.Parse(txt_ic_fiyat.Text));

            komut2.ExecuteNonQuery();
            baglanti.Close();

            yenile();
            yenile2();
            Temizle();

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update icecekler set bufe_id=@p1, icecek_ad=@p2,fiyat=@p3 where icecek_no=@p4", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(txt_ic_bufe.Text));
            komut.Parameters.AddWithValue("@p2", txt_icecek.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(txt_ic_fiyat.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(txt_ic_no.Text));

            komut.ExecuteNonQuery();

            baglanti.Close();
            yenile();
            yenile2();
            Temizle();

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {


            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from icecekler where icecek_no=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_ic_no.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
 

            yenile();
            yenile2();
            Temizle();

        }

        private void datagrid_yiy_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_yiy_no.Text = datagrid_yiy.CurrentRow.Cells[1].Value.ToString();
            txt_yiyecek.Text = datagrid_yiy.CurrentRow.Cells[2].Value.ToString();
            txt_yiy_fiyat.Text = datagrid_yiy.CurrentRow.Cells[3].Value.ToString();
        }

        private void datagrid_icecek_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_ic_no.Text = datagrid_icecek.CurrentRow.Cells[1].Value.ToString();
            txt_icecek.Text = datagrid_icecek.CurrentRow.Cells[2].Value.ToString();
            txt_ic_fiyat.Text = datagrid_icecek.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_yiy_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into yiyecekler (bufe_id,yiyecek_ad,fiyat) values (@p1,@p2,@p3)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_yiy_bufe.Text));
            komut1.Parameters.AddWithValue("@p2", txt_yiyecek.Text);
            komut1.Parameters.AddWithValue("@p3", int.Parse(txt_yiy_fiyat.Text));
  
            komut1.ExecuteNonQuery();
            baglanti.Close();


            yenile();
            yenile2();
            Temizle();

        }

        private void btn_yiy_sil_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from yiyecekler where yiyecek_no=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txt_yiy_no.Text));
            komut1.ExecuteNonQuery();
            baglanti.Close();
        
            yenile();
            yenile2();
            Temizle();
        }

        private void btn_yiy_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update yiyecekler set bufe_id=@p1, yiyecek_ad=@p2, fiyat=@p3 where yiyecek_no=@p4  ", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(txt_ic_bufe.Text));
            komut.Parameters.AddWithValue("@p2", txt_yiyecek.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(txt_yiy_fiyat.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(txt_yiy_no.Text));


            komut.ExecuteNonQuery();
           
            baglanti.Close();
            yenile();
            yenile2();
            Temizle();
        }
    }
}
