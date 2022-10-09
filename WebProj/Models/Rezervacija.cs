using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProj.Models
{
    public class Rezervacija
    {
        public string IdRezervacije { get; set; }
        public string Posetilac { get; set; }
        public GrupniTrening Grupni { get; set; }

        public Rezervacija() { }
        public Rezervacija(string idRezervacije, string posetilac, GrupniTrening grupni)
        {
            IdRezervacije = idRezervacije;
            Posetilac = posetilac;
            Grupni = grupni;
        }
    }
}