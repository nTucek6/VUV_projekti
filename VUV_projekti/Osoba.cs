using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_projekti
{
    abstract class Osoba
    {
        private int _id;
        private string _ime;
        private string _prezime;
        private string _oib;

        public int Id
        {
            get { return _id;}
            set { _id = value;}
        }
        public string Ime 
        {
            get { return _ime; }
            set { _ime = value; }
        }
        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }
        public string OIB
        {
            get { return _oib; }
            set { _oib = value; }
        }

    }
}
