using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VUV_projekti
{
   class Aktivnost
    {
        private int _id;
        private string _naziv;
        private string _opis;
        private string _period;
        private int _projektId;
        private int _clanId;
        private ClanProjekta _clan;
        //private List<Projekt> _projekti;

      //  [JsonConstructor]
      public Aktivnost() { }
        public Aktivnost(int i, string n, string o, string v, int pi, int cId, ClanProjekta c)
        {
            _id = i;
            _naziv = n;
            _opis = o;
            _period = v;
            _projektId = pi;
            _clanId = cId;
            _clan = c;
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }
        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }
        public string Period
        {
            get { return _period; }
            set { _period = value; }
        }
        public int ProjektId
        {
            get { return _projektId; }
            set { _projektId = value; }
        }
        public int ClanId
        {
            get { return _clanId; }
            set { _clanId = value; }
        }
        public ClanProjekta Clan
        {
            get { return _clan; }
            set { _clan = value; }
        }
        //public List<Projekt> Projekti
        //{
        //    get { return _projekti; }
        //    set { _projekti = value; }
        //}

    }
}
