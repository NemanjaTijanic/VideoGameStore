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
    public partial class Prodavnica : Form
    {
        ArrayList igre = new ArrayList();

        Kupac trenutniKupac = new Kupac();
        public Prodavnica()
        {
            InitializeComponent();
        }

        internal Prodavnica(Kupac kup)
        {
            InitializeComponent();
            trenutniKupac = kup;

            igre = IgraCRUD.ucitajIgre();

            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM `igra`";
                MySqlDataAdapter adap = new MySqlDataAdapter();
                adap.SelectCommand = new MySqlCommand(sql, conn);

                DataSet set = new DataSet();
                adap.Fill(set);

                dataGridView1.DataSource = set.Tables[0];
                //dataGridView1.Columns[6].ReadOnly = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }

        // buy
        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string temp = row.Cells[0].Value.ToString();
                int id = Int32.Parse(temp);

                string temp2 = row.Cells[5].Value.ToString();
                int cena = Int32.Parse(temp2);

                string temp3 = row.Cells[6].Value.ToString();

                if(trenutniKupac.getNovac() < cena)
                {
                    MessageBox.Show("Error: Insufficient funds.");
                }
                else if(temp3 == "False")
                {
                    MessageBox.Show("Error: Game out of stock.");
                }
                else
                {
                    String stamp = ProdajeCRUD.GetTimestamp(DateTime.Now);
                    ProdajeCRUD.upisiProdaju(trenutniKupac.getId(), id, stamp);

                    KupacCRUD.dodajNovac(trenutniKupac.getId(), trenutniKupac.getNovac() - cena);
                    trenutniKupac.setNovac(trenutniKupac.getNovac() - cena);

                    MessageBox.Show("Purchase successful.");
                }
            }
        }

        // back
        private void button1_Click(object sender, EventArgs e)
        {
            Meni men = new Meni(trenutniKupac);
            men.Show();
            this.Hide();
        }
    }
}
