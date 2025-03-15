using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaVideoIgara
{
    class Igra
    {
        private int id;
        private string naziv;
        private string izdavac;
        private string zanr;
        private string platforma;
        private int cena;
        private bool naStanju;

        public Igra()
        {
            cena = 0;
            naStanju = false;
        }

        public Igra(int i, string n, string iz, string za, string plat, int c, bool na)
        {
            id = i;
            naziv = n;
            izdavac = iz;
            zanr = za;
            platforma = plat;
            cena = c;
            naStanju = na;
        }

        public void setId(int i)
        {
            id = i;
        }

        public int getId()
        {
            return id;
        }

        public void setNaziv(string n)
        {
            naziv = n;
        }

        public string getNaziv()
        {
            return naziv;
        }

        public void setIzdavac(string i)
        {
            izdavac = i;
        }

        public string getIzdavac()
        {
            return izdavac;
        }

        public void setZanr(string z)
        {
            zanr = z;
        }

        public string getZanr()
        {
            return zanr;
        }

        public void setPlatforma(string p)
        {
            platforma =p;
        }

        public string getPlatforma()
        {
            return platforma;
        }

        public void setCena(int c)
        {
            cena = c;
        }

        public int getCena()
        {
            return cena;
        }

        public void setStanje(bool s)
        {
            naStanju = s;
        }

        public bool getStanje()
        {
            return naStanju;
        }

        public override string ToString()
        {
            if(naStanju)
                return naziv + izdavac + zanr + platforma + cena.ToString() + "Da";
            else
                return naziv + izdavac + zanr + platforma + cena.ToString() + "Ne";

        }

    }
}
