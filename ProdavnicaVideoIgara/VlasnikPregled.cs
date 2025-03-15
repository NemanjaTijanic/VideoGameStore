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
    public partial class VlasnikPregled : Form
    {
        Vlasnik trenutniVlasnik = new Vlasnik();
        public VlasnikPregled()
        {
            InitializeComponent();
        }

        internal VlasnikPregled(Vlasnik vlas)
        {
            InitializeComponent();
            trenutniVlasnik = vlas;

            // kupci
            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM `kupac`";
                MySqlDataAdapter adap = new MySqlDataAdapter();
                adap.SelectCommand = new MySqlCommand(sql, conn);

                DataSet set = new DataSet();
                adap.Fill(set);

                dataGridView1.DataSource = set.Tables[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();

            // prodaje
            string connString2 = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn2 = new MySqlConnection(connString2);

            try
            {
                conn2.Open();

                string sql2 = "SELECT * FROM `prodaje`";
                MySqlDataAdapter adap2 = new MySqlDataAdapter();
                adap2.SelectCommand = new MySqlCommand(sql2, conn2);

                DataSet set2 = new DataSet();
                adap2.Fill(set2);

                dataGridView2.DataSource = set2.Tables[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VlasnikMeni vm = new VlasnikMeni(trenutniVlasnik);
            vm.Show();
            this.Hide();
        }
    }
}
