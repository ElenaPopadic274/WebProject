using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProj.Models
{ 
    public enum TipTreninga { YOGA = 0, TONE, BODYPUMP, CARDIO, BOX };
   
    public class GrupniTrening
    {
        [Required(ErrorMessage = "Naziv treninga je obavezan")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Tip treninga je obavezan(YOGA/TONE/BODYPUMP/CARDIO/BOX)")]
        public TipTreninga TipTreninga { get; set; }
        [Required(ErrorMessage = "Ime fitnes centra je obavezno")]
        public FitnesCentar FCOdrzavanja { get; set; }
        [Required(ErrorMessage = "Vreme trajanja je obavezno")]
        public int Trajanje { get; set; }
        [Required(ErrorMessage = "Datum i vreme održavanja je obavezno")]
        public DateTime DatumVremeTreninga { get; set; }
        [Required(ErrorMessage = "Broj posetilaca je obavezan")]
        public int MaxPosetilaca { get; set; }

        public List<String> posetioci = new List<String>();


        public GrupniTrening() { }

        public GrupniTrening(string naziv, TipTreninga tipTreninga, FitnesCentar fCOdrzavanja, int trajanje, DateTime datumVremeTreninga, int maxPosetilaca, List<String> posetioci)
        {
            Naziv = naziv;
            TipTreninga = tipTreninga;
            FCOdrzavanja = fCOdrzavanja;
            Trajanje = trajanje;
            DatumVremeTreninga = datumVremeTreninga;
            MaxPosetilaca = maxPosetilaca;
            this.posetioci = posetioci;
        }
    }
}