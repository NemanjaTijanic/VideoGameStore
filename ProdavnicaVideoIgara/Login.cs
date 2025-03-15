using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ProdavnicaVideoIgara
{
    public partial class Login : Form
    {
        ArrayList vlasnici = new ArrayList();
        ArrayList kupci = new ArrayList();
        Kupac trenutniKupac = new Kupac();
        Vlasnik trenutniVlasnik = new Vlasnik();

        public Login()
        {
            InitializeComponent();

            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM `vlasnik`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    int priv = rdr.GetInt32("id");
                    string temp = rdr.GetString("username");
                    string temp2 = rdr.GetString("password");

                    Vlasnik v = new Vlasnik(priv, temp, temp2);
                    vlasnici.Add(v);
                }
                rdr.Close();

                string sql2 = "SELECT * FROM `kupac`";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();

                while(rdr2.Read())
                {
                    int id = rdr2.GetInt32("id");
                    string username = rdr2.GetString("username");
                    string password = rdr2.GetString("password");
                    string ime = rdr2.GetString("ime");
                    string prezime = rdr2.GetString("prezime");
                    string adresa = rdr2.GetString("adresa");
                    string telefon = rdr2.GetString("telefon");
                    string email = rdr2.GetString("email");
                    int novac = rdr2.GetInt32("novac_na_racunu");

                    Kupac k = new Kupac(id, username, password, ime, prezime, adresa, telefon, email, novac);
                    kupci.Add(k);
                }
                rdr2.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }

        // Login
        private void button1_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String pass = textBox2.Text;
            bool provera = false;
            bool proveraVlasnik = false;
            bool proveraKupac = false;

            if(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("The username and password fields must be filled.");
            }
            else if(user == "Username" || pass == "Password")
            {
                MessageBox.Show("Please enter your username and password.");
            }
            else
            {
                foreach (Vlasnik vlas in vlasnici)
                {
                    if (vlas.getUsername() == user && vlas.getPassword() == pass)
                    {
                        provera = true;
                        proveraVlasnik = true;

                        trenutniVlasnik = vlas;
                    }
                        
                }

                foreach(Kupac kup in kupci)
                {
                    if (kup.getUsername() == user && kup.getPassword() == pass)
                    {
                        provera = true;
                        proveraKupac = true;

                        trenutniKupac = kup;
                    }
                        
                }

                if (provera)
                {
                    MessageBox.Show("Successfully logged in.");

                    if(proveraVlasnik)
                    {
                        VlasnikMeni vm = new VlasnikMeni(trenutniVlasnik);
                        vm.Show();
                        this.Hide();
                    }
                    else if(proveraKupac)
                    {
                        Meni men = new Meni(trenutniKupac);
                        men.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Error: Your username and/or password are invalid.");
                }
            }

        }

        // Back
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
