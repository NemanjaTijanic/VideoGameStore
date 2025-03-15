using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdavnicaVideoIgara
{
    public partial class DodavanjeNovca : Form
    {
        Kupac trenutniKupac = new Kupac();

        public DodavanjeNovca()
        {
            InitializeComponent();
        }

        internal DodavanjeNovca(Kupac kup)
        {
            InitializeComponent();
            trenutniKupac = kup;
        }

        // dodavanje
        private void button1_Click(object sender, EventArgs e)
        {
            bool provera = Regex.IsMatch(textBox1.Text, @"^\d+$");
            if(provera)
            {
                int novac = Int32.Parse(textBox1.Text);
                int id = trenutniKupac.getId();

                int racun = trenutniKupac.getNovac();

                if(novac > 0)
                {
                    KupacCRUD.dodajNovac(id, novac + racun);
                    MessageBox.Show("Successful transfer.");
                    textBox1.Text = "Enter Amount";
                    trenutniKupac.setNovac(novac + racun);
                }  
                else
                    MessageBox.Show("Entered amount must be positive.");
            }
            else
            {
                MessageBox.Show("Incorrect entry.");
            }
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
