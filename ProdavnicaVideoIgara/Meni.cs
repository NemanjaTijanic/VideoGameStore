using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdavnicaVideoIgara
{
    public partial class Meni : Form
    {
        Kupac trenutniKupac = new Kupac();
        public Meni()
        {
            InitializeComponent();
        }

        internal Meni(Kupac kup)
        {
            trenutniKupac = kup;
            InitializeComponent();
        }

        // log out
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        // dodavanje novca
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DodavanjeNovca dn = new DodavanjeNovca(trenutniKupac);
            dn.Show();
            this.Hide();
        }

        // profil
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Profil pf = new Profil(trenutniKupac);
            pf.Show();
            this.Hide();
        }

        // prodavnica
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Prodavnica prod = new Prodavnica(trenutniKupac);
            prod.Show();
            this.Hide();
        }
    }
}
