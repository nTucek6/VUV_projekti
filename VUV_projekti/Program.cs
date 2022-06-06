/* 
 *-----------------------------------
 *
 * Autor: Nikola Tuček
 * Projekt: VUV-projekti
 * Predmet: Objektno-orijentirano programiranje
 * Ustanova: VUV
 * Godina: 2020-2021
 *
 *-----------------------------------
 */
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ConsoleTables;
using System.Linq;
namespace VUV_projekti
{
    class Program
    {
        static string ProjektPath = @"C:\Users\Nikola\source\repos\VUV_projekti\VUV_projekti\Projekt.json";
        static string ClanProjektaPath = @"C:\Users\Nikola\source\repos\VUV_projekti\VUV_projekti\ClanProjekta.json";
        static string LokacijaPath = @"C:\Users\Nikola\source\repos\VUV_projekti\VUV_projekti\Lokacija.json";
        static string AktivnostPath = @"C:\Users\Nikola\source\repos\VUV_projekti\VUV_projekti\Aktivnost.json";
        static string GradoviRH = @"C:\Users\Nikola\source\repos\VUV_projekti\VUV_projekti\GradoviRH.json";
        static int findFirstMissing(List<int> b) //Metoda ispituje listu brojeva svih id neke lite i trazi najmanji prvi slobodan ako postoji
        {
            int r = 0;
            bool contains = true;
            for(int i = 0;i<b.Count;i++)
            {
                if (!(b.Contains(i+1)))
                {
                    r = i + 1;
                    contains = false;
                }
            }
            if(contains == true)
            {
                r = b.Count + 1;
            }
           

            return r;
        }
        static string UcitajJSON(string path) //Metoda služi za učitavanje vrijednosti datoteke koju odaberemo
        {
            string json = "";
            StreamReader sr = new StreamReader(path);
            using (sr)
            {
                json = sr.ReadToEnd();
            }
            return json;
           
        }
        static List<Projekt> UcitajProjekt(string path) //Metoda preko metoda UcitajJSON dobiva json datoteku i pretvara je u listu objekta
        {
            List<Projekt> x = new List<Projekt>();
            x = JsonConvert.DeserializeObject<List<Projekt>>(UcitajJSON(path));
            return x;
        }
        static List<ClanProjekta> UcitajClanovi(string path) //Metoda preko metoda UcitajJSON dobiva json datoteku i pretvara je u listu objekta
        {
            List<ClanProjekta> x = new List<ClanProjekta>();
            x = JsonConvert.DeserializeObject<List<ClanProjekta>>(UcitajJSON(path));
            return x;
        }
        static List<Lokacija> UcitajLokacija(string path) //Metoda preko metoda UcitajJSON dobiva json datoteku i pretvara je u listu objekta
        {
            List<Lokacija> x = new List<Lokacija>();
            x = JsonConvert.DeserializeObject<List<Lokacija>>(UcitajJSON(path));
            return x;
        }
        static List<Aktivnost> UcitajAktivnost(string path) //Metoda preko metoda UcitajJSON dobiva json datoteku i pretvara je u listu objekta
        {
            List<Aktivnost> x = new List<Aktivnost>();
            x = JsonConvert.DeserializeObject<List<Aktivnost>>(UcitajJSON(path));
            return x;
        }
        static List<ListCities> UcitajCities(string path)
        {
            List<ListCities> x = new List<ListCities>();
            x = JsonConvert.DeserializeObject<List<ListCities>>(UcitajJSON(path));
            return x;
        }
        static void UpisProjekt(List<Projekt> x,string path) //Metoda za dodavanje vrijednosti liste u json
        {
            for(int i = 0;i<x.Count;i++)
            {
                if(x[i].ID == 0)
                {
                    x.RemoveAt(i);
                }
            }
            string noviJson = JsonConvert.SerializeObject(x);
            StreamWriter sw = new StreamWriter(path);
            sw.Write(noviJson);
            sw.Close();
        }
        static void UpisLokacija(List<Lokacija> x,string path) //Metoda za dodavanje vrijednosti liste u json
        {
            string noviJson = JsonConvert.SerializeObject(x);
            StreamWriter sw = new StreamWriter(path);
            sw.Write(noviJson);
            sw.Close();
        }
        static void UpisAktivnost(List<Aktivnost> aktivnost, string path)
        {
            for (int i = 0; i < aktivnost.Count; i++)
            {
                if (aktivnost[i].Id == 0)
                {
                    aktivnost.RemoveAt(i);
                }
            }
            string noviJson = JsonConvert.SerializeObject(aktivnost);
            StreamWriter sw = new StreamWriter(path);
            sw.Write(noviJson);
            sw.Close();

        }
        static void UpisClanovi(List<ClanProjekta> clanovi, string path)
        {
            for (int i = 0; i < clanovi.Count; i++)
            {
                if (clanovi[i].Id == 0)
                {
                    clanovi.RemoveAt(i);
                }
            }
            string noviJson = JsonConvert.SerializeObject(clanovi);
            StreamWriter sw = new StreamWriter(path);
            sw.Write(noviJson);
            sw.Close();
        }
        static void Izbornik()
        {
            Console.Clear();
            bool exit = true;
            while(exit == true)
            {
                exit = false;
                try
                {
                    
                    Console.WriteLine("1 - Lista projekata\n2 - Dodavanje projekta\n3 - Azuriranje projekta\n4 - Lista Aktivnosti" +
                        "\n5 - Dodavanje aktivnosti\n6 - Lista clanova projekta\n7 - Dodavanje clana\n8 - Brisanje clana\n9 - Izlaz iz programa");
                    int broj = VratiBroj();
                    switch (broj)
                    {
                        case 1:
                            Console.Clear();
                            IspisProjekata();
                            Povratak();
                            break;
                        case 2:
                            Console.Clear();
                            DodavanjeProjekta();
                            Povratak();
                            break;
                        case 3:
                            Console.Clear();
                            AzurirajProjekt();
                            Povratak();
                            break;
                        case 4:
                            Console.Clear();
                            ListaAktivnosti();
                            Povratak();
                            break;
                        case 5:
                            Console.Clear();
                            DodavanjeAktivnosti();
                            Povratak();
                            break;
                        case 6:
                            Console.Clear();
                            IspisClanovi();
                            Povratak();
                            break;
                        case 7:
                            Console.Clear();
                            DodavanjeClana();
                            Povratak();
                            break;
                        case 8:
                            Console.Clear();
                            BrisanjeClana();
                            Povratak();
                            break;
                        case 9:
                            Console.Clear();
                            Povratak();
                            break;
                        default:
                            throw new Exception("Krivi unos broja!\nPonovite unos:");

                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    IznimkeUpis(e.Message);
                    Console.WriteLine(e.Message);
                    exit = true;
                    Console.WriteLine();
                }
            }
        }
        static void IspisProjekata() //Metoda za ispis svih vrijednosti Projekt.json u tabličnom prikazu
        {
            try
            {
                List<Projekt> lprojekta = new List<Projekt>(UcitajProjekt(ProjektPath)); //
                List<Lokacija> lLokacija = new List<Lokacija>(UcitajLokacija(LokacijaPath));
                List<Aktivnost> laktivnosti = new List<Aktivnost>(UcitajAktivnost(AktivnostPath));
                LokacijaFill(lprojekta, lLokacija);
                AktivnostFill(lprojekta, laktivnosti);
                var table = new ConsoleTable("R.br", "Naziv", "Nostielj", "Vrijednost", "Status", "Voditelj", "Lokacija");
                int Rbr = 1;
                foreach (Projekt p in lprojekta)
                {
                    p.Ispis(table, Rbr);
                    Rbr++;
                }
                table.Write(Format.Alternative);
                Console.WriteLine();
                Console.WriteLine("1. Ispis aktivnosti projekta\n2. Povratak u glavni izbornik ili izlaz iz programa");
               
                while(true)
                {
                    bool leave = true;
                    int broj = VratiBroj();
                    switch (broj)
                    {
                        case 1:
                            Console.WriteLine("Odaberite projekt za ispis njegovih aktivnosti:");
                            broj = VratiBroj();
                            Console.WriteLine();
                            var aktTable = new ConsoleTable("R.br.", "Naziv", "Opis", "Period", "Clan");
                            Rbr = 1;
                            for (int i = 0; i < lprojekta.Count; i++)
                            {
                                if (broj - 1 == i)
                                {

                                    Console.WriteLine();
                                    lprojekta[i].ProjektAktivnosti(aktTable, Rbr, i, lprojekta[i].ID);
                                }
                            }
                            if (aktTable.Rows.Count >= 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Projekt:");
                                lprojekta[broj - 1].Info();
                                Console.WriteLine("Aktivnosti:");
                                aktTable.Write(Format.Alternative);
                            }
                            else
                            {
                                Console.WriteLine("Odabrani projekt jos nema upisane aktivnosti!");
                                Console.WriteLine("1. Dodajte aktivnosti u projekt\n2. Povratak u glavni izbornik ili izlaz iz programa");
                                while(true)
                                {
                                    try
                                    {
                                        int n = VratiBroj();
                                        switch (n)
                                        {
                                            case 1:
                                                DodavanjeAktivnosti();
                                                break;
                                            case 2:
                                                break;
                                            default:
                                                throw new Exception("Pogresan odabir!");
                                        }
                                        break;
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Ponovite unos:");
                                        IznimkeUpis(e.Message);
                                    }
                                   
                                }

                            }

                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("Pogresan unos!\nPonovite unos broja");
                            IznimkeUpis("Pogresan odabir izbronika!");
                            leave = false;
                        break;
                    }
                    if(leave == true)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IznimkeUpis(e.Message);
            }
        }
        static void DodavanjeProjekta()//Dodavanje projekta u json
        {
            try
            {
                List<Projekt> x = new List<Projekt>(UcitajProjekt(ProjektPath)); 
                List<Lokacija> y = new List<Lokacija>(UcitajLokacija(LokacijaPath));
                List<ListCities> gradovi = new List<ListCities>(UcitajCities(GradoviRH));
                List<string> zupanije = GetZupanija(gradovi).Distinct().ToList(); //Lista se puni zupanijama bez duplikata
                List<int> FindPId = new List<int>();
                List<int> FindLId = new List<int>();
                for (int i = 0; i < x.Count; i++)
                {
                    if (x[i].ID == 0)
                    {
                        x.RemoveAt(i);
                    }
                    else
                    {
                        FindPId.Add(x[i].ID);
                    }
                }
                foreach (Lokacija l in y)
                {
                    FindLId.Add(l.ID);
                }
                int Pid = findFirstMissing(FindPId); //Metoda vraca prvi slobodni id
                int Lid = findFirstMissing(FindLId);

                Console.WriteLine("Unesite naziv projekta:");
                string naziv = UnosString();
                Console.WriteLine("Unesite nositelja projekta:");
                string nositelj = UnosString();
                Console.WriteLine("Unesite vrijednost projekta u kunama:");
                float vrijednost = CheckFloat();
                Console.WriteLine("Odaberite status projekta:\n1. Aktivan\n2. Neaktivan");
                string status = "";
                while (true)
                {
                    try
                    {
                        int sb = VratiBroj();
                        switch (sb)
                        {
                            case 1:
                                status += "Aktivan";
                                break;
                            case 2:
                                status += "Neaktivan";
                                break;
                            default:
                                throw new Exception("Pogresan odabir broja!");
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        IznimkeUpis(e.Message);
                    }
                }
             
                
                Console.WriteLine("Unesite voditelja projekta:");
                string voditelj = UnosString();
                Console.WriteLine("Odaberite zupaniju:");
                string zupanija = VratiZupaniju(zupanije);
                Console.WriteLine("Odaberite grad/mjesto:");
                string grad = VratiGrad(gradovi, zupanija);
                Console.WriteLine("Unesite adresu projekta:");
                string adresa = UnosString();
                Console.WriteLine("Unesite postanski broj:");
                int pbr = VratiBroj();
                if(pbr < 0)
                {
                    throw new Exception("Postanski broj ne moze bit negativan!");
                }
                string lat = "", lng = "";
                for(int i = 0;i<gradovi.Count;i++) // Pronalazak odabrane zupanije i grada da dobijemo latitudu i longitudu
                {
                    if(gradovi[i].admin_name == zupanija)
                    {
                        if(gradovi[i].city == grad)
                        {
                            lat += gradovi[i].lat;
                            lng += gradovi[i].lng;
                        }
                    }
                }
                x.Add(new Projekt(Pid, naziv, nositelj, voditelj, status, vrijednost, Lid,null,null,null));
                y.Add(new Lokacija(Lid, adresa, pbr, grad, lat, lng));
                UpisProjekt(x, ProjektPath);
                UpisLokacija(y, LokacijaPath);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                IznimkeUpis(e.Message);
            }
        }
        static void AzurirajProjekt() //Metoda za azuriranje vrijednosti klase Projekt
        {
            try
            {
                List<Projekt> x = new List<Projekt>(UcitajProjekt(ProjektPath)); //
                List<Lokacija> y = new List<Lokacija>(UcitajLokacija(LokacijaPath));
                List<ListCities> gradovi = new List<ListCities>(UcitajCities(GradoviRH));
                List<string> zupanije = GetZupanija(gradovi).Distinct().ToList(); //Lista se puni zupanijama bez duplikata
                for (int i = 0; i < x.Count; i++) // Uklanjam listu članova da ne bih kasnije stvarala probleme
                {
                    if (x[i].ID == 0)
                    {
                        x.RemoveAt(i);
                    }
                }
                var table = new ConsoleTable("Naziv", "Nostielj", "Vrijednost", "Status", "Voditelj", "Lokacija");
                Console.WriteLine("Odaberite projekt koji zelite azurirat:");
                int b = 1;
                foreach (Projekt p in x) //Ispis projekata za odabir korisnika
                {
                    Console.WriteLine("{0}. {1}", b, p.Naziv);
                    b++;
                }
                int pBroj = 0;
                pBroj += VratiBroj(); //Metoda vraca broj s tipkovnice, ako se unese string ponavlja se unos
                Console.Clear();
                for (int i = 0; i < x.Count; i++) //Ispis svih informacija projekta za odabir azuriranja
                {
                    if (pBroj == x[i].ID)
                    {
                        foreach (Lokacija l in y)
                        {
                            if (x[i].LokacijaID == l.ID)
                            {
                                table.AddRow("" + x[i].Naziv, "" + x[i].Nositelj, "" + x[i].Vrijednost + " HRK", "" + x[i].Status, "" + x[i].Voditelj, "" + l.Adresa + ", " + l.Grad + ", " + l.PBR);
                            }
                        }
                    }
                }
                table.Write(Format.Alternative);
                string naziv = "";
                string nositelj = "";
                float vrijednost = 0f;
                string status = "";
                string voditelj = "";
                Console.Write("Odaberite vrijednost koju zelite azurirati:\n1. Naziv\n2. Nositelj\n3. Vrijednost\n4. Status\n5. Voditelj\n6. Lokacija\n");
                int sb = VratiBroj();
                switch (sb)
                {
                    case 1:
                        Console.WriteLine("Unesite novi naziv projekta:");
                        naziv += UnosString();
                        UpisProjekt(UpdateNaziv(pBroj, naziv, x), ProjektPath);
                        break;
                    case 2:
                        Console.WriteLine("Unesite ime i prezime novog nositelja projekta:");
                        nositelj += UnosString();
                        UpisProjekt(UpdateNositelj(pBroj, nositelj, x), ProjektPath);
                        break;
                    case 3:
                        Console.WriteLine("Unesite novu vrijednost projekta:");
                        vrijednost += CheckFloat();
                        UpisProjekt(UpdateVrijednost(pBroj, vrijednost, x), ProjektPath);
                        break;
                    case 4:
                        Console.WriteLine("Odaberite status projekta:\n1. Aktivan\n2. Neaktivan");
                        sb = VratiBroj();
                        switch (sb)
                        {
                            case 1:
                                status += "Aktivan";
                                break;
                            case 2:
                                status += "Neaktivan";
                                break;
                            default:
                                throw new Exception("Pogresno unesen broj!");
                        }
                        UpisProjekt(UpdateStatus(pBroj, status, x), ProjektPath);
                        break;
                    case 5:
                        Console.WriteLine("Unesite ime i prezime novog voditelja projekta:");
                        voditelj += UnosString();
                        UpisProjekt(UpdateVoditelj(pBroj, voditelj, x), ProjektPath);
                        break;
                    case 6:
                        Console.WriteLine("Odaberite zupaniju:");
                        string zupanija = VratiZupaniju(zupanije);
                        Console.WriteLine("Odaberite grad/mjesto:");
                        string grad = VratiGrad(gradovi, zupanija);
                        Console.WriteLine("Unesite adresu projekta:");
                        string adresa = UnosString();
                        Console.WriteLine("Unesite postanski broj:");
                        int pbr = VratiBroj();
                        if (pbr < 0)
                        {
                            throw new Exception("Postanski broj ne moze bit negativan!");
                        }
                        string lat = "", lng = "";
                        for (int i = 0; i < gradovi.Count; i++) // Pronalazak odabrane zupanije i grada da dobijemo latitudu i longitudu
                        {
                            if (gradovi[i].admin_name == zupanija)
                            {
                                if (gradovi[i].city == grad)
                                {
                                    lat += gradovi[i].lat;
                                    lng += gradovi[i].lng;
                                }
                            }
                        }
                        UpisLokacija(UpdateLokacija(pBroj, x,y,grad,adresa,pbr,lat,lng), LokacijaPath);
                        break;
                    default:
                        Console.WriteLine("Pogresni unos broja");
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                IznimkeUpis(e.Message);
            }
                }
        static void ListaAktivnosti() // Ispis svih aktivnosti
        {
            try
            {
                List<Projekt> lprojekta = new List<Projekt>(UcitajProjekt(ProjektPath)); //
                List<Lokacija> lLokacija = new List<Lokacija>(UcitajLokacija(LokacijaPath));
                List<Aktivnost> laktivnosti = new List<Aktivnost>(UcitajAktivnost(AktivnostPath));
                LokacijaFill(lprojekta, lLokacija);
                AktivnostFill(lprojekta, laktivnosti);
                var table = new ConsoleTable("R.br.", "Naziv", "Opis", "Period", "Naziv projekta", "Clan");
                int r = 0;
                foreach (Projekt p in lprojekta)
                {
                    r = table.Rows.Count + 1;
                    p.AktivnostiIspis(table, r);
                }
                table.Write(Format.Minimal);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                IznimkeUpis(e.Message);
            }
        }
        static void DodavanjeAktivnosti()//Metoda za dodavanje nove aktivnosti nekome prpjektu u listu aktivnosti
        {
            try
            {
                List<Projekt> projekti = new List<Projekt>(UcitajProjekt(ProjektPath)); //
                List<ClanProjekta> clanovi = new List<ClanProjekta>(UcitajClanovi(ClanProjektaPath)); //Punjenje liste objekta preko metode
                List<Aktivnost> aktivnost = new List<Aktivnost>(UcitajAktivnost(AktivnostPath)); //
                List<int> aId = new List<int>();
                foreach (Aktivnost a in aktivnost)
                {
                        aId.Add(a.Id);
                }
                for (int i = 0; i < projekti.Count; i++)
                {
                    if (projekti[i].ID == 0)
                    {
                        projekti.RemoveAt(i);
                    }
                }
                int id = findFirstMissing(aId);
                int projektId = 0;
                int clanId = 0;
                int c = 1;
                int unos;
                string naziv = "";
                string opis = "";
                string period = "";
                bool noClan = true;
                List<string> pronadiClan = new List<string>();
                Console.WriteLine("Odaberite projekt kojemu dodajete novu aktivnost:");
                foreach (Projekt p in projekti)
                {
                    Console.WriteLine("{0}. {1}", c++, p.Naziv);
                }
                unos = VratiBroj();
                for (int i = 0;i<projekti.Count;i++) //Dodavanje projektaId vrijednosti
                {
                    if(unos-1 == i)
                    {
                        projektId += projekti[i].ID;
                    }
                }
                c = 1;
                Console.WriteLine();
               
                for (int i = 0; i < clanovi.Count; i++) //Trazimo sve clanove koji imaju odabrani projekt i dodajemo njihov oib u listu za pretragu kasnije u programu
                {
                    if(clanovi[i].ProjektId == projektId)
                    {
                        Console.WriteLine("{0}. {1}", c++, clanovi[i].Ime + " " + clanovi[i].Prezime);
                        pronadiClan.Add(clanovi[i].OIB);
                        noClan = false;
                    }
                }
                Console.WriteLine();
                if(noClan == false) //Ako postoji clan koji je dio projekta kojemu se dodaje aktivnos ako ne onda se ispisuje pogreska
                {
                    Console.WriteLine("Odaberite člana aktivnosti");
                    unos = VratiBroj();
                    for (int i = 0; i < pronadiClan.Count; i++) //Pretraga clana u listi clanovi specificnog projekta po oibu
                    {
                        if (unos - 1 == i)
                        {
                            foreach (ClanProjekta cl in clanovi)
                            {
                                if (pronadiClan[i] == cl.OIB)
                                {
                                    clanId += cl.Id;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Unesite naziv aktivnosti:");
                    naziv += UnosString();
                    Console.WriteLine("Navedite opis aktivnosti:");
                    opis += UnosString();
                    Console.WriteLine("Navedite mjesec ili vrijeme aktivnosti:");
                    period += UnosString();
                    aktivnost.Add(new Aktivnost(id, naziv, opis, period, projektId, clanId,null));
                    for (int i = 0; i < aktivnost.Count; i++) //Dodavanje objekta Clan u aktivnosti iz klase clanoviprojekta
                    {
                        if (aktivnost[i].Clan == null)
                        {
                            for (int j = 0; j < clanovi.Count; j++)
                            {
                                if (aktivnost[i].ClanId == clanovi[j].Id)
                                {
                                aktivnost[i].Clan = clanovi[j];
                                }
                            }
                        }
                    }
                    UpisAktivnost(aktivnost, AktivnostPath);
                }
                else 
                {
                    Console.Clear();
                    Console.WriteLine("U odabranog projektu ne postoje clanovi\nPotrebno je dodati clanove u projekt");
                    throw new Exception("Ne postoji jos nijedan clan odabranog projekta!");
                }
            }
            catch(Exception e)
            {
                IznimkeUpis(e.Message);
                Console.WriteLine();
                Console.WriteLine("1. Dodavanje clana u projekt\n2.Povratak ili izlaz iz programa");
                while (true)
                {
                    try
                    {
                        int sb = VratiBroj();
                        switch (sb)
                        {
                            case 1:
                                Console.Clear();
                                DodavanjeClana();
                                break;
                            case 2:
                                Console.Clear();
                                break;
                            default:
                                throw new Exception("Pogresan odabir broja!");
                        }
                        break;
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                        IznimkeUpis(ee.Message);
                    }
                }
            }
        }
        static void IspisClanovi()//Metoda za ispis svih clanova i njihovih projekata/aktivnosti
        {
            List<Projekt> projekti = new List<Projekt>(UcitajProjekt(ProjektPath)); //
            List<ClanProjekta> clanovi = new List<ClanProjekta>(UcitajClanovi(ClanProjektaPath)); //Punjenje liste objekta preko metode
            List<Aktivnost> aktivnosti = new List<Aktivnost>(UcitajAktivnost(AktivnostPath)); //
            ClanoviFill(projekti, clanovi);
            AktivnostFill(projekti, aktivnosti);
            var table = new ConsoleTable("Ime i Prezime","OIB","Projekt","Aktivnosti");
            foreach(Projekt p in projekti)
            {
                p.IspisClanova(table);
            }
            table.Write(Format.Alternative);
        }
        static void DodavanjeClana()//Metoda za upis novog clana
        {
                try
                {
                List<Projekt> projekti = new List<Projekt>(UcitajProjekt(ProjektPath)); //
                List<ClanProjekta> clanovi = new List<ClanProjekta>(UcitajClanovi(ClanProjektaPath)); //Punjenje liste objekta preko metode
                for (int i = 0; i < projekti.Count; i++) //Uklanjanje praznih clanova
                    {
                        if (projekti[i].ID == 0)
                        {
                            projekti.RemoveAt(i);
                        }
                    }
                    List<int> GetId = new List<int>(); // Lista za pretragu slobodnog id-a
                    foreach (ClanProjekta clan in clanovi)
                    {
                        GetId.Add(clan.Id);
                    }
                    int id = findFirstMissing(GetId);
                    string ime;
                    string prezime;
                    string oib;
                    int projektId = 0;
                    int unos;
                    Console.WriteLine("Unesite ime novog clana:");
                    ime = UnosString();
                    Console.WriteLine("Unesite prezime novog clana:");
                    prezime = UnosString();
                    
                    Console.WriteLine("Unesite OIB novog clana:");
                    oib = CheckOIB(); //Unos sa tipkovnice, vraca pravilan oib
                    Console.WriteLine("Odaberite projekt novog clana:");
                    int c = 1;
                    foreach (Projekt p in projekti)
                    {
                        Console.WriteLine("{0}. {1}", c++, p.Naziv);
                    }
                    unos = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < projekti.Count; i++)
                    {
                        if (unos - 1 == i)
                        {
                            projektId += projekti[i].ID;
                        }
                    }
                    clanovi.Add(new ClanProjekta(id, ime, prezime, oib, projektId));
                    UpisClanovi(clanovi, ClanProjektaPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    IznimkeUpis(e.Message);
                }  
        }
        static void BrisanjeClana()//Projekt postane neaktivan ako je obrisan zadnji clan projekta
        {
            try
            {
                List<ClanProjekta> clanovi = new List<ClanProjekta>(UcitajClanovi(ClanProjektaPath)); //Punjenje liste objekta preko metode
                List<Aktivnost> Aktivnosti = new List<Aktivnost>(UcitajAktivnost(AktivnostPath));
                List<Projekt> projekti = new List<Projekt>(UcitajProjekt(ProjektPath));
                int c = 1;
                int unos;
                bool cont = false;
                int id = 0;
                int projekID = 0;
                Console.WriteLine("Unesite redni broj clana kojega zelite obrisati:");
                foreach (ClanProjekta clan in clanovi)
                {
                    Console.WriteLine("{0}. {1} {2}", c++, clan.Ime, clan.Prezime);
                }
                unos = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < clanovi.Count; i++)
                {
                    if (unos - 1 == i)
                    {
                        id += clanovi[i].Id;
                        projekID += clanovi[i].ProjektId;
                        clanovi.RemoveAt(i);
                        cont = true;
                    }
                }

                if(cont  == true)
                {
                    for (int j = 0; j < Aktivnosti.Count; j++) //id clana u aktivnosti postaje nula jer vise ne postoji, objekt ostaje da se moze ispisat kasnije tko je bio clan projekta
                    {
                        if (id == Aktivnosti[j].ClanId)
                        {
                            Aktivnosti[j].ClanId = 0;
                        }
                    }

                    List<int> pId = new List<int>();
                    foreach(ClanProjekta clan in clanovi)
                    {
                        pId.Add(clan.ProjektId);
                    }
                        if(!pId.Contains(projekID))
                        {
                            for(int i = 0; i< projekti.Count;i++)
                            {
                                if(projekti[i].ID == projekID)
                                {
                                projekti[i].Status = "Neaktivan";
                                }
                            }

                        }
                }
                UpisAktivnost(Aktivnosti, AktivnostPath);
                UpisClanovi(clanovi, ClanProjektaPath);
                UpisProjekt(projekti, ProjektPath);
            }
            catch(Exception e)
            {
                IznimkeUpis(e.Message);
                Console.WriteLine(e.Message);
            }   
        }
        static List<Projekt> UpdateNaziv(int broj,string naziv,List<Projekt> x)//Prima listu i mijenja naziv odabranog projekta i vraća listu s updateom
        {
            for(int i = 0;i<x.Count;i++)
            {
                if(broj == x[i].ID)
                {
                    x[i].Naziv = naziv;
                }
            }
            return x;
        }
        static List<Projekt> UpdateNositelj(int broj, string nositelj, List<Projekt> x) //Prima listu i mijenja naziv odabranog projekta i vraća listu s updateom
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (broj == x[i].ID)
                {
                    x[i].Nositelj = nositelj;
                }
            }
            return x;
        }
        static List<Projekt> UpdateVrijednost(int broj, float vrijednost, List<Projekt> x) //Prima listu i mijenja naziv odabranog projekta i vraća listu s updateom
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (broj == x[i].ID)
                {
                    x[i].Vrijednost = vrijednost;
                }
            }
            return x;
        }
        static List<Projekt> UpdateStatus(int broj, string status, List<Projekt> x) //Prima listu i mijenja naziv odabranog projekta i vraća listu s updateom
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (broj == x[i].ID)
                {
                    x[i].Status = status;
                }
            }
            return x;
        }
        static List<Projekt> UpdateVoditelj(int broj, string voditelj, List<Projekt> x) //Prima listu i mijenja naziv odabranog projekta i vraća listu s updateom
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (broj == x[i].ID)
                {
                    x[i].Voditelj = voditelj;
                }
            }
            return x;
        }
        static  List<Lokacija> UpdateLokacija(int broj,List<Projekt> x,List<Lokacija> y,string grad,string adresa,int pbr,string lat,string lng) //Metoda prima parametre koji se koriste za azuriranje lokacije
        {
            for (int i = 0; i < x.Count; i++)
            {
                if (broj == x[i].ID)
                {
                   for(int j = 0;j<y.Count;j++)
                    {
                        if(y[j].ID == x[i].LokacijaID)
                        {
                            y[j].Grad = grad;
                            y[j].Adresa = adresa;
                            y[j].PBR = pbr;
                            y[j].Latituda = lat;
                            y[j].Longituda = lng;
                        }
                    }
                }
            }
            return y;
        }
        static List<string> GetZupanija(List<ListCities> gradovi)//Metoda vraca listu zupanija u RH
        {
            List<string> temp = new List<string>();
            foreach (ListCities g in gradovi)
            {
                temp.Add(g.admin_name);
            }
            return temp;
        }
        static string VratiZupaniju(List<string> zupanije) // Metoda vraca odabranu zupaniju kao string vrijednost
        {
            int counter = 1;
            foreach (string z in zupanije) // Ispis svih zupanije
            {
                Console.WriteLine(counter + ". " + z);
                counter++;
            }
            int odabir = Convert.ToInt32(Console.ReadLine());
            string zupanija = zupanije.ElementAt(odabir - 1);

            return zupanija;
        }
        static string VratiGrad(List<ListCities> gradovi,string zupanija)
        {
            List<string> temp = new List<string>();
            int counter = 1;
            for (int i = 0; i < gradovi.Count; i++) //Puni se lista gradova odabrane zupanije
            {
                if (zupanija == gradovi[i].admin_name)
                {
                    temp.Add(gradovi[i].city);
                }
            }
           

            foreach (string g in temp) // Biranje grada il temp liste
            {
                Console.WriteLine(counter + ". " + g);
                counter++;
            }
            int odabir = Convert.ToInt32(Console.ReadLine());
            string grad = temp.ElementAt(odabir - 1); //Sprema se odabrani grad iz liste stringa na elementu unosa - 1

            return grad;
        }
        static List<Projekt> ClanoviFill(List<Projekt> x,List<ClanProjekta> y)//Puni podatkovni clan _clanovi projekta s listom clanova pripadajuceg projekta
        {
            try
            {
                List<ClanProjekta> priv = new List<ClanProjekta>();
                foreach (Projekt p in x)
                {
                    priv.Clear();
                    foreach (ClanProjekta c in y)
                    {
                        if (c.ProjektId == p.ID)
                        {
                            priv.Add(c);
                        }
                    }
                    p.ClanoviProjekta = new List<ClanProjekta>(priv);
                }

                return x;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                IznimkeUpis(e.Message);
                return x;
            }
            
        }
        static List<Projekt> LokacijaFill(List<Projekt> x,List<Lokacija> y) //Projekt lista se puni lokacijom lista
        {
            try
            {
                foreach(Projekt p in x)
                {
                    foreach(Lokacija l in y)
                    {
                        if (p.LokacijaID == l.ID)
                        {
                            p.Lokacija = l;
                        }
                    }
                }
                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IznimkeUpis(e.Message);
                return x;
            }
        }
        static List<Projekt> AktivnostFill(List<Projekt> x, List<Aktivnost> y) //Projekt lista se puni Aktivnosti lista
        {
            try
            {
                List<Aktivnost> priv = new List<Aktivnost>();
                foreach (Projekt p in x)
                {
                    priv.Clear();
                    foreach (Aktivnost a in y)
                    {
                        if (p.ID == a.ProjektId)
                        {
                            priv.Add(a);
                        }

                    }
                    p.AktivnostP = new List<Aktivnost>(priv);
                }
                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                IznimkeUpis(e.Message);
                return x;
            }

        }
        static void Povratak() //Metoda za povratak ili izlaz iz programa
        {
            Console.WriteLine();
            Console.WriteLine("Pritisnite ENTER za povratak u glavni izbornik ili ESCAPE za izlaz iz programa");
            char odabir;
            int b;
            bool p;
            do
            {
                p = true;
                odabir = Console.ReadKey(true).KeyChar;
                b = Convert.ToInt32(odabir);
                switch (b)
                {
                    case 13: //ASCII za ENTER
                        Console.Clear();
                        Izbornik();
                        break;
                    case 27: //ASCII za ESCAPE
                        Console.Clear();
                        Console.WriteLine("Press any key to continue..");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Pogresna tipka!");
                        p = false;
                        break;
                }
            } while (!p);
        }
        static void IznimkeUpis(string message)//Metoda upisuje iznimku s vremenom događanja
        {
            FileStream fs = new FileStream("iznimke.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(message + " - " + DateTime.Now);
            sw.Close();
        }
        static string UnosString() //Metoda koja provjerava ako je uneseni string prazan
        {
            while(true)
            {
                try
                {
                    string unos = Console.ReadLine();
                    if (string.IsNullOrEmpty(unos))
                    {
                        throw new Exception("Uneseni string je prazan!");
                    }
                    return unos;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    IznimkeUpis(e.Message);
                }
            }
        }
        static int VratiBroj()//Metoda vraca uneseni int, ako se upise string ponovno se trazi upis
        {
            while(true)
            {
                try 
                {
                    int broj = Convert.ToInt32(Console.ReadLine());
                    return broj;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ponovite unos: ");
                    IznimkeUpis(e.Message);
                }
            }
        }
        static string CheckOIB()//Provjerava se ako je oib prazan ako nije onda se provjeri da je uneseni oib brojevi, i da je veličine 11
        {
            while(true)
            {
                try
                {
                    string oib = Console.ReadLine();
                    if (string.IsNullOrEmpty(oib))
                    {
                        throw new Exception("Uneseni OIB je prazan string!");
                    }
                    if (oib.All(char.IsDigit) == false || oib.Length != 11)
                    {
                        throw new Exception("Uneseni oib se sastoji od 11 znamenki!");
                    }
                    return oib;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    IznimkeUpis(e.Message);
                    Console.WriteLine("Ponovite unos:");
                }
            }  
        }
        static float CheckFloat()//Ako je unesena vrijednost veća od nula ako nije pogrešna vrjednost je unesena
        {
            while (true)
            {
                try
                {
                    float vrijednost = float.Parse(Console.ReadLine());
                    if(vrijednost < 1)
                    {
                        throw new Exception("Unesena vrijednost može samo biti broj veći od nula!");
                    }
                    return vrijednost;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    IznimkeUpis(e.Message);
                }
            } 
        }
        static void Main()
        {
            Console.WriteLine("Dobrodosli na jednostavni informacijski sustav: VUV_projekti\nPristisnite bilo koju tipku za nastavak...");
            Console.ReadKey(true);
            Izbornik();          
        }
    }
}
