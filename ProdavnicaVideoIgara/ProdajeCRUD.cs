using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ProdavnicaVideoIgara
{
    class ProdajeCRUD
    {
        public static void upisiProdaju(int kupac, int igra, string time)
        {
            string connString = "server=localhost;user=root;database=cs322_projekat_nemanjatijanic4562";
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();

                string sql = "INSERT INTO `prodaje` (`kupac_id`, `igra_id`, `datum`) " +
                    "VALUES ('" + kupac + "', '" + igra + "', '" +  time + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
