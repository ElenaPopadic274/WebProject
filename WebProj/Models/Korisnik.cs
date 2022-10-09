using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProj.Models
{
    public enum Pol { ZENSKI, MUSKI };
    public enum Uloga { VLASNIK = 0, TRENER, POSETILAC };

    public class Korisnik
    {
        [Required(ErrorMessage = "Korisničko ime je obavezno")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna")]
        public string Lozinka { get; set; }
        [Required(ErrorMessage = "Ime je obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Pol je obavezan")]
        public Pol Pol { get; set; }
        [Required(ErrorMessage = "Email je obavezan")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Datum rođenja je obavezno")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Uloga je obavezna")]
        public Uloga Uloga { get; set; }
        public bool Provera { get; set; } = false;
        public bool Blokiran { get; set; } = false;
        public List<GrupniTrening> grupniPos = new List<GrupniTrening>(); //Lista grupnih treninga na koje je korisnik prijavljen (ako korisnik ima ulogu Posetioca)
        public List<GrupniTrening> grupniTre = new List<GrupniTrening>(); //Lista grupnih treninga na kojima je korisnik angažovan kao trener (ako korisnik ima ulogu Trenera)
        public List<FitnesCentar> centarTre = new List<FitnesCentar>(); //Fitnes centar gde je korisnik angažovan (ako korisnik ima ulogu Trenera)
        public List<FitnesCentar> centarVla = new List<FitnesCentar>(); //Fitnes centri čiji je korisnik vlasnik (ako korisnik ima ulogu Vlasnika)
        public List<Rezervacija> rezervacija = new List<Rezervacija>();

        public Korisnik() { }
        public Korisnik(string korime, string loz, string ime, string prz, Pol poll, string email, DateTime dt, Uloga uloga)
        {
            this.KorisnickoIme = korime;
            this.Lozinka = loz;
            this.Ime = ime;
            this.Prezime = prz;
            this.Pol = poll;
            this.Email = email;
            this.DatumRodjenja = dt;
            this.Uloga = uloga;
        }
        public Korisnik(string ime, string prz)
        {
            this.Ime = ime;
            this.Prezime = Prezime;
        }
    }
}