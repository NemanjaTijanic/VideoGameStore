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
    public partial class VlasnikDodajIgru : Form
    {
        Vlasnik trenutniVlasnik = new Vlasnik();
        public VlasnikDodajIgru()
        {
            InitializeComponent();
        }

        internal VlasnikDodajIgru(Vlasnik vlas)
        {
            InitializeComponent();
            trenutniVlasnik = vlas;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // back
        private void button2_Click(object sender, EventArgs e)
        {
            VlasnikMeni vm = new VlasnikMeni(trenutniVlasnik);
            vm.Show();
            this.Hide();
        }

        // add
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string izdavac = textBox4.Text;
            string zanr = textBox6.Text;
            string platforma = textBox2.Text;

            string sc = textBox3.Text;
            int cena = 0;
            bool provera = System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^\d+$");
            if(provera)
                cena = Int32.Parse(sc);

            int stanje;
            if (checkBox1.Checked == true)
                stanje = 1;
            else
                stanje = 0;

            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(izdavac) || string.IsNullOrEmpty(zanr) || string.IsNullOrEmpty(platforma) || string.IsNullOrEmpty(sc))
            {
                MessageBox.Show("All the fields must be filled.");
            }
            else if(textBox1.Text == "Name" || textBox4.Text == "Publisher" || textBox6.Text == "Genre" || textBox2.Text == "Platform" || textBox3.Text == "Price")
            {
                MessageBox.Show("All the fields must be filled.");
            }
            else
            {
                if (provera)
                {
                    IgraCRUD.upisiIgru(name, izdavac, zanr, platforma, cena, stanje);
                    MessageBox.Show("Entry successful.");

                    textBox1.Text = "Name";
                    textBox4.Text = "Publisher";
                    textBox6.Text = "Genre";
                    textBox2.Text = "Platform";
                    textBox3.Text = "Price";
                }
                else
                {
                    MessageBox.Show("Incorrect entry.");
                }
            }
        }
    }
}
