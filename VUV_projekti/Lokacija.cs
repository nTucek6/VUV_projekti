using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VUV_projekti
{
    class Lokacija
    {
        private int _id;
        private string _adresa;
        private int _pbr;
        private string _grad;
        private string _latituda;
        private string _longituda;

        [JsonConstructor]
        public Lokacija(int i,string a,int pb,string g,string lat,string lon)
        {
            _id = i;
            _adresa = a;
            _pbr = pb;
            _grad = g;
            _latituda = lat;
            _longituda = lon;
        }
        public int ID
        {
            get {return _id; }
            set { _id = value; }
        }
        public string Adresa
        {
            get { return _adresa; }
            set { _adresa = value; }
        }
        public int PBR
        {
            get { return _pbr; }
            set { _pbr = value; }
        }
        public string Grad
        {
            get { return _grad; }
            set { _grad = value; }
        }
        public string Latituda
        {
            get { return _latituda; }
            set { _latituda = value; }
        }
        public string Longituda
        {
            get { return _longituda; }
            set { _longituda = value; }
        }
    }
}
