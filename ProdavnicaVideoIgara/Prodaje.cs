using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaVideoIgara
{
    class Prodaje
    {
        private int id;
        private int kupac_id;
        private int igra_id;
        private string timestamp;

        public Prodaje() { }

        public Prodaje(int i, int k, int igra, string time)
        {
            id = i;
            kupac_id = k;
            igra_id = igra;
            timestamp = time;
        }

        public void setId(int i)
        {
            id = i;
        }

        public int getId()
        {
            return id;
        }

        public void setKupacId(int i)
        {
            kupac_id = i;
        }

        public int getKupacId()
        {
            return kupac_id;
        }

        public void setIgraId(int i)
        {
            igra_id = i;
        }

        public int getIgraId()
        {
            return igra_id;
        }

        public void setTimestamp(string t)
        {
            timestamp = t;
        }

        public string getTimestamp()
        {
            return timestamp;
        }
    }
}
