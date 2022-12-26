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
    public partial class YöneticiGirisi : Form
    {
        public YöneticiGirisi()
        {
            InitializeComponent();
        }


        private void btn_salon_isl_Click(object sender, EventArgs e)
        {
            Salonlar salon = new Salonlar();
            salon.Show();
            this.Hide();
        }

        private void btn_film_islem_Click(object sender, EventArgs e)
        {
            Filmler film = new Filmler();
            film.Show();
            this.Hide();
        }

        private void btn_seans_isl_Click(object sender, EventArgs e)
        {
            SeansIslemleri seans = new SeansIslemleri();
            seans.Show();
            this.Hide();
        }

        private void btn_sinema_salon_islem_Click(object sender, EventArgs e)
        {
            SinemaSalonlari ssalon = new SinemaSalonlari();
            ssalon.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void YöneticiGirisi_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bufe bufe = new Bufe();
            bufe.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
        }

        private void btn_koltuklar_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Sssalon_film_ekleme_Click(object sender, EventArgs e)
        {

        }

        private void btn_oyuncu_ekle_Click(object sender, EventArgs e)
        {
            OyuncuIslemleri oy = new OyuncuIslemleri();
            oy.Show();
            this.Hide();
        }

        private void btn_toplam_satis_Click(object sender, EventArgs e)
        {
            ToplamSatislar oy = new ToplamSatislar();
            oy.Show();
            this.Hide();
        }

        private void btn_izlenme_Click(object sender, EventArgs e)
        {
            izlenmeSayisi say = new izlenmeSayisi();
            say.Show();
            this.Hide();
        }
    }
}
