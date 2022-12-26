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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_blt_al_Click(object sender, EventArgs e)
        { 
            BiletAl biletal = new BiletAl();
            biletal.Show();
            this.Hide();
        }

        private void btn_yonet_gir_Click(object sender, EventArgs e)
        {
            //      sifreGirisi sifregirisi = new sifreGirisi();
            //    sifregirisi.Show();
            //  this.Hide();

            YöneticiGirisi yg = new YöneticiGirisi();
            yg.Show();
            this.Hide();
        }
    }
}
