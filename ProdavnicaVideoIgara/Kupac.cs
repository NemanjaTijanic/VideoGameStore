using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaVideoIgara
{
    class Kupac
    {
        private int id;
        private string username;
        private string password;
        private string ime;
        private string prezime;
        private string adresa;
        private string telefon;
        private string email;
        private int novac;

        public Kupac()
        {
            novac = 0;
        }

        public Kupac(int i, string user, string pass, string im, string prez, string adr, string tel, string em, int n)
        {
            id = i;
            username = user;
            password = pass;
            ime = im;
            prezime = prez;
            adresa = adr;
            telefon = tel;
            email = em;
            novac = n;
        }

        public void setId(int i)
        {
            id = i;
        }

        public int getId()
        {
            return id;
        }

        public void setUsername(string u)
        {
            username = u;
        }

        public string getUsername()
        {
            return username;
        }

        public void setPassword(string p)
        {
            password = p;
        }

        public string getPassword()
        {
            return password;
        }

        public void setIme(string i)
        {
            ime = i;
        }

        public string getIme()
        {
            return ime;
        }

        public void setPrezime(string p)
        {
            prezime = p;
        }

        public string getPrezime()
        {
            return prezime;
        }

        public void setAdresa(string a)
        {
            adresa = a;
        }

        public string getAdresa()
        {
            return adresa;
        }

        public void setTelefon(string t)
        {
            telefon = t;
        }

        public string getTelefon()
        {
            return telefon;
        }

        public void setEmail(string e)
        {
            email = e;
        }

        public string getEmail()
        {
            return email;
        }

        public void setNovac(int n)
        {
            novac = n;
        }

        public int getNovac()
        {
            return novac;
        }
    }
}
