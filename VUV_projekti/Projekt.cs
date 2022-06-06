using ConsoleTables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_projekti
{
    class Projekt
    {
        private int _id;
        private string _naziv;
        private string _nositelj;
        private string _voditelj;
        private string _status;
        private float _vrijednost;
        private int _lokacijaId;
        private Lokacija _lokacija;
        private List<ClanProjekta> _clanovi_projekata;
        private List<Aktivnost> _aktivnostiP;
        [JsonConstructor]
        public Projekt(int i,string naz,string nos,string vod,string stas,float vri,int lId,List<ClanProjekta> c, List<Aktivnost> a, Lokacija l)
        {
            _id = i;
            _naziv = naz;
            _nositelj = nos;
            _voditelj = vod;
            _status = stas;
            _vrijednost = vri;
            _lokacijaId = lId;
            _clanovi_projekata = c;
            _aktivnostiP = a;
            _lokacija = l;
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }
        public string Nositelj
        {
            get { return _nositelj; }
            set { _nositelj = value; }
        }
        public string Voditelj
        {
            get { return _voditelj; }
            set { _voditelj = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public float Vrijednost
        {
            get { return _vrijednost; }
            set { _vrijednost = value; }
        }
        public int LokacijaID
        {
            get { return _lokacijaId; }
            set { _lokacijaId = value; }
        }
        public List<ClanProjekta> ClanoviProjekta
        {
            get { return _clanovi_projekata; }
            set { _clanovi_projekata = value; }
        }
        public Lokacija Lokacija
        {
            get { return _lokacija; }
            set { _lokacija = value; }
        }
        public List<Aktivnost> AktivnostP
        {
            get { return _aktivnostiP;}
            set { _aktivnostiP = value; }
        }
        public void Info()
        {
            var table = new ConsoleTable("Naziv", "Nostielj", "Vrijednost", "Status", "Voditelj", "Lokacija");
            table.AddRow("" + Naziv, "" + Nositelj, "" + Vrijednost, "" + Status, "" + Voditelj, "" + Lokacija.Adresa + ", " + Lokacija.Grad + ", " + Lokacija.PBR);
            table.Write(Format.Alternative);
        }
        public ConsoleTable Ispis(ConsoleTable table,int rbr)//Ispis projekta tablicno
        {
            table.AddRow(""+rbr,"" + Naziv, "" + Nositelj, "" + Vrijednost + " HRK", "" + Status, "" + Voditelj, "" + Lokacija.Adresa + ", " + Lokacija.Grad + ", " + Lokacija.PBR);
            return table;
        }
        public ConsoleTable ProjektAktivnosti(ConsoleTable table, int rbr,int i,int id)//Ispis samo aktivnosti odredenog projekta
        {
            foreach(Aktivnost a in AktivnostP)
            {
                if(id == a.ProjektId)
                {
                    table.AddRow(rbr,a.Naziv,a.Opis,a.Period,a.Clan.Ime + " " + a.Clan.Prezime);
                    rbr++;
                }
            }
            return table;
        }
        public ConsoleTable AktivnostiIspis(ConsoleTable table,int rbr)//Ispis aktivnosti
        {
           foreach(Aktivnost a in AktivnostP)
            {
                    table.AddRow(rbr,a.Naziv,a.Opis ,a.Period,Naziv,a.Clan.Ime + " " + a.Clan.Prezime);
                    rbr++;  
            }
            return table;
        }
        public ConsoleTable IspisClanova(ConsoleTable table) //Metoda za ispis clanova, vraca table s svim clanovima
        {
            string aktivnost;
            foreach(ClanProjekta c in ClanoviProjekta)
            {
                aktivnost = "";
                for (int i = 0; i < AktivnostP.Count; i++)
                {
                    if (i + 1 == AktivnostP.Count)
                    {
                        aktivnost += AktivnostP[i].Naziv;
                    }
                    else
                    {
                        aktivnost += AktivnostP[i].Naziv + ", ";
                    }
                }
                table.AddRow(c.Ime + " " + c.Prezime,c.OIB,Naziv,aktivnost);
            }
            return table;
        }

    }
}
