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
    public partial class sifreGirisi : Form
    {
        public sifreGirisi()
        {
            InitializeComponent();
        }
        string kullanici_adi = "sude selvi";
        int parola = 123;
        
        private void button1_Click(object sender, EventArgs e)
        {

            string girilen_kul_ad = txt_kul_ad.Text;
            int girilen_parola=int.Parse( txt_parola.Text);
            if (kullanici_adi == girilen_kul_ad && parola == girilen_parola)
            {
                YöneticiGirisi yoneticigirisi = new YöneticiGirisi();
                yoneticigirisi.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Yanlis sifre veya kullanici adi girdiniz", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
