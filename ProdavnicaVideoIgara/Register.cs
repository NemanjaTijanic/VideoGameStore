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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // register
        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            string ime = textBox4.Text;
            string prezime = textBox3.Text;
            string adresa = textBox6.Text;
            string telefon = textBox5.Text;
            string email = textBox7.Text;

            if(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(ime) || string.IsNullOrEmpty(prezime) || string.IsNullOrEmpty(adresa) ||
                string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("All the fields must be filled.");
            }
            else if(user == "Username" || pass == "Password" || ime == "Name" || prezime == "Last Name" || adresa == "Adress" || telefon == "Phone" || email == "Email")
            {
                MessageBox.Show("All the fields must be filled.");
            }
            else
            {
                KupacCRUD.upisiKupca(user, pass, ime, prezime, adresa, telefon, email, 0);
                MessageBox.Show("Successfully registered! You can now login to your new acount.");

                textBox1.Text = "Username";
                textBox2.Text = "Password";
                textBox3.Text = "Last Name";
                textBox4.Text = "Name";
                textBox5.Text = "Phone";
                textBox6.Text = "Adress";
                textBox7.Text = "Email";
            }
        }

        //back
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
