using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProj.Models
{
    public class Komentar
    {
        public Korisnik PosetilacFC{ get; set; }
        public FitnesCentar FitnesC { get; set; }
        public string Text { get; set; }
        public int Ocena { get; set; }

        public Komentar() { }
        public Komentar(Korisnik k, FitnesCentar f, string text, int ocena)
        {
            this.PosetilacFC = k;
            this.FitnesC = f;
            this.Text = text;
            this.Ocena = ocena;
        }
    }
}