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
    public partial class Profil : Form
    {
        Kupac trenutniKupac = new Kupac();

        public Profil()
        {
            InitializeComponent();
        }

        internal Profil(Kupac kup)
        {
            InitializeComponent();
            trenutniKupac = kup;

            label2.Text = trenutniKupac.getUsername();
            label3.Text = trenutniKupac.getPassword();
            label5.Text = trenutniKupac.getIme();
            label7.Text = trenutniKupac.getPrezime();
            label9.Text = trenutniKupac.getAdresa();
            label11.Text = trenutniKupac.getTelefon();
            label13.Text = trenutniKupac.getEmail();
            label15.Text = trenutniKupac.getNovac().ToString();
        }

        // back
        private void button2_Click(object sender, EventArgs e)
        {
            Meni men = new Meni(trenutniKupac);
            men.Show();
            this.Hide();
        }
    }
}
