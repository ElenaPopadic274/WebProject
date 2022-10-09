using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProj.Models
{
    public class FitnesCentar
    {
        public string Naziv { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string Mesto { get; set; }
        public string PostanskiBroj { get; set; }
        public int GodinaOtvaranja { get; set; }
        public Korisnik Vlasnik { get; set; }
        public int CenaMesecne { get; set; }
        public int CenaGodisnje { get; set; }
        public int CenaPojedinacnog { get; set; }
        public int CenaGrupnog { get; set; }
        public int CenaPersonalnog { get; set; }
        public bool logObrisan { get; set; }


        public FitnesCentar() { }

        public FitnesCentar(string naziv, string ulica, int broj, string mesto, string postanskiBroj, int godinaOtvaranja, Korisnik vlasnik, int cenaMesecne, int cenaGodisnje, int cenaPojedinacnog, int cenaGrupnog, int cenaPersonalnog)
        {
            Naziv = naziv;
            Ulica = ulica;
            Broj = broj;
            Mesto = mesto;
            PostanskiBroj = postanskiBroj;
            GodinaOtvaranja = godinaOtvaranja;
            Vlasnik = vlasnik;
            CenaMesecne = cenaMesecne;
            CenaGodisnje = cenaGodisnje;
            CenaPojedinacnog = cenaPojedinacnog;
            CenaGrupnog = cenaGrupnog;
            CenaPersonalnog = cenaPersonalnog;
        }

        public FitnesCentar(string naziv, int godinaOtvaranja, Korisnik vlasnik)
        {
            Naziv = naziv;
            GodinaOtvaranja = godinaOtvaranja;
            Vlasnik = vlasnik;
        }
    }
}