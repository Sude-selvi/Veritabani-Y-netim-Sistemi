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
    public partial class ToplamSatislar : Form
    {
        public ToplamSatislar()
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
            string sorgu = "select referans_no,alis_tarihi,fiyat from biletler order by referans_no";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void ToplamSatislar_Load(object sender, EventArgs e)
        {
            yenile();

            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select distinct alis_tarihi from biletler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "alis_tarihi";
            comboBox1.ValueMember = "alis_tarihi";
            comboBox1.DataSource = dt;
            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            string sorgu = "select referans_no,alis_tarihi,fiyat from biletler where alis_tarihi='" + comboBox1.Text + "'";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView1.DataSource = ds2.Tables[0];

            string sorgu3 = "select toplamfiyat from tarihe_gore_ucret_hesapla ('" + comboBox1.Text + "')";
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3);
            dataGridView2.DataSource = ds3.Tables[0];



        }
    }
}
//TOPLAM UCRETLERI TRIGGERLA VEYA FONKSIYONLA YAPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP