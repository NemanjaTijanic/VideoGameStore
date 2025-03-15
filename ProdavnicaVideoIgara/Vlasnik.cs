using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaVideoIgara
{
    class Vlasnik
    {
        private int id;
        private string username;
        private string password;

        public Vlasnik() { }

        public Vlasnik(int i, string u, string p)
        {
            id = i;
            username = u;
            password = p;
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
    }
}
