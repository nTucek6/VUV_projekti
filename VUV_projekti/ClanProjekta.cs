using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VUV_projekti
{
    class ClanProjekta : Osoba
    {
        private int _projektId;
        [JsonConstructor]
        public ClanProjekta(int i,string im,string p,string o,int pr)
        {
            Id = i;
            Ime = im;
            Prezime = p;
            OIB = o;
            ProjektId = pr; 
        }
        public int ProjektId
        {
            get { return _projektId; }
            set { _projektId = value; }
        }

    }
}
