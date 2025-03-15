using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ProdavnicaVideoIgara
{
    class KupacCRUD
    {
        public static void upisiKupca(string user, string pass, string ime, string prezime, string adresa, string telefon, string email, int novac)
        {
            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO `kupac` (`username`, `password`, `ime`, `prezime`, `adresa`, `telefon`, `email`, `novac_na_racunu`) " +
                    "VALUES ('" + user + "', '" + pass + "', '" + ime + "', '" + prezime + "', '" + adresa + "', '" + telefon + "', '" + email + "', '" + novac + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }

        public static void dodajNovac(int id, int novac)
        {
            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "UPDATE `kupac` SET `novac_na_racunu` = '" + novac + "' WHERE `kupac`.`id` = " + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }
        
    }
}
