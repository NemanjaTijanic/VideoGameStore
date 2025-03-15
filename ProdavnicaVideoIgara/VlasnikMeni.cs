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
    public partial class VlasnikMeni : Form
    {
        Vlasnik trenutniVlasnik = new Vlasnik();

        public VlasnikMeni()
        {
            InitializeComponent();
        }

        internal VlasnikMeni(Vlasnik vlas)
        {
            InitializeComponent();
            trenutniVlasnik = vlas;
        }

        // log out
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            VlasnikDodajIgru vd = new VlasnikDodajIgru(trenutniVlasnik);
            vd.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VlasnikAzurirajIgru va = new VlasnikAzurirajIgru(trenutniVlasnik);
            va.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            VlasnikPregled vp = new VlasnikPregled(trenutniVlasnik);
            vp.Show();
            this.Hide();
        }
    }
}
