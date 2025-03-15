using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ProdavnicaVideoIgara
{
    class IgraCRUD
    {
        public static ArrayList ucitajIgre()
        {
            ArrayList igre = new ArrayList();

            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "SELECT * FROM `igra`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = rdr.GetInt32("id");
                    string naziv = rdr.GetString("naziv");
                    string izdavac = rdr.GetString("izdavac");
                    string zanr = rdr.GetString("zanr");
                    string platforma = rdr.GetString("platforma");
                    int cena = rdr.GetInt32("cena");

                    bool stanje;
                    int st = rdr.GetInt32("na_stanju");
                    if (st > 0)
                        stanje = true;
                    else
                        stanje = false;

                    Igra ig = new Igra(id, naziv, izdavac, zanr, platforma, cena, stanje);
                    igre.Add(ig);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
            return igre;
        }

        public static void upisiIgru(string naziv, string izdavac, string zanr, string platforma, int cena, int stanje)
        {
            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO `igra` (`naziv`, `izdavac`, `zanr`, `platforma`, `cena`, `na_stanju`) " +
                    "VALUES ('" + naziv + "', '" + izdavac + "', '" + zanr + "', '" + platforma + "', '" + cena + "', '" + stanje + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }

        // UPDATE `igra` SET `naziv` = 'Witcher 2', `izdavac` = 'CD Projekt ', `zanr` = 'RPD', `platforma` = 'PC, Xbox One', `cena` = '25', `na_stanju` = '1' WHERE `igra`.`id` = 3
        public static void azurirajIgru(int id, string naziv, string izdavac, string zanr, string platforma, int cena, int stanje)
        {
            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "UPDATE `igra` SET `naziv` = '" + naziv + "', `izdavac` = '" + izdavac + "', " +
                    "`zanr` = '" + zanr + "', `platforma` = '" + platforma + "', `cena` = '" + cena + "', `na_stanju` = '" + stanje + "' WHERE `igra`.`id` = " + id;
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
