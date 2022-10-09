using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebProj.Models
{
    public class Data
    {
        public static List<Korisnik> ReadKorisnik(string path)
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                Korisnik p = new Korisnik(tokens[0], tokens[1], tokens[2], tokens[3], (Pol)Enum.Parse(typeof(Pol), tokens[4]), tokens[5], Convert.ToDateTime(tokens[6]), (Uloga)Enum.Parse(typeof(Uloga), tokens[7]));

                korisnici.Add(p);
            }
            sr.Close();
            stream.Close();

            return korisnici;
        }

        public static List<FitnesCentar> ReadFCentri(string path)
        {

            List<FitnesCentar> fcentri = new List<FitnesCentar>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');
                FitnesCentar fcentar = new FitnesCentar()
                {
                    Naziv = tokens[0],
                    Ulica = tokens[1],
                    Broj = int.Parse(tokens[2]),
                    Mesto = tokens[3],
                    PostanskiBroj = tokens[4],
                    GodinaOtvaranja = int.Parse(tokens[5]),
                    Vlasnik = new Korisnik()
                    {
                        KorisnickoIme = tokens[6],
                        Lozinka = tokens[7],
                        Ime = tokens[8],
                        Prezime = tokens[9],
                        Pol = (Pol)Enum.Parse(typeof(Pol), tokens[10]),
                        Email = tokens[11],
                        DatumRodjenja = Convert.ToDateTime(tokens[12]),
                        Uloga = (Uloga)Enum.Parse(typeof(Uloga), tokens[13])
                    },
                    CenaMesecne = int.Parse(tokens[14]),
                    CenaGodisnje = int.Parse(tokens[15]),
                    CenaPojedinacnog = int.Parse(tokens[16]),
                    CenaGrupnog = int.Parse(tokens[17]),
                    CenaPersonalnog = int.Parse(tokens[18]),

                };
                fcentri.Add(fcentar);
            }
            sr.Close();
            stream.Close();

            return fcentri;
        }

        public static List<Komentar> ReadKomentar(string path)
        {
            List<Komentar> komentari = new List<Komentar>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');


                Komentar komentar = new Komentar()
                {
                    PosetilacFC = new Korisnik()
                    {
                        Ime = tokens[0],
                        Prezime = tokens[1]
                    },
                    FitnesC = new FitnesCentar()
                    {
                        Naziv = tokens[2],
                        GodinaOtvaranja = int.Parse(tokens[3])
                    },
                    Text = tokens[4],
                    Ocena = int.Parse(tokens[5]),
                };
                
                komentari.Add(komentar);

            }
            sr.Close();
            stream.Close();
            return komentari;
        }
        
        public static List<GrupniTrening> ReadGrupniTrening(string path)
        {
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');

                //Korisnik korisnik = new Korisnik(kor[0], kor[1], kor[2], kor[3], (Pol)Enum.Parse(typeof(Pol), kor[4]), kor[5], Convert.ToDateTime(kor[6]), (Uloga)Enum.Parse(typeof(Uloga), kor[7]));
                //FitnesCentar fcentar = new FitnesCentar(fc[0], fc[1], int.Parse(fc[2]), fc[3], fc[4], int.Parse(fc[5]), korisnik, int.Parse(cene[0]), int.Parse(cene[1]), int.Parse(cene[2]), int.Parse(cene[3]), int.Parse(cene[4]));

                GrupniTrening gtrening = new GrupniTrening()
                {
                    Naziv = tokens[0],
                    TipTreninga = (TipTreninga)Enum.Parse(typeof(TipTreninga), tokens[1]),
                    FCOdrzavanja = new FitnesCentar()
                    {
                        Naziv = tokens[2],
                        Ulica = tokens[3],
                        Broj = int.Parse(tokens[4]),
                        Mesto = tokens[5],
                        PostanskiBroj = tokens[6],
                        GodinaOtvaranja = int.Parse(tokens[7]),
                        Vlasnik = new Korisnik()
                        {
                            KorisnickoIme = tokens[8],
                            Ime = tokens[9],
                            Prezime = tokens[10],
                            Pol = (Pol)Enum.Parse(typeof(Pol), tokens[11]),
                            Email = tokens[12],
                            DatumRodjenja = Convert.ToDateTime(tokens[13]),
                            Uloga = (Uloga)Enum.Parse(typeof(Uloga), tokens[14]),
                        },
                        CenaMesecne = int.Parse(tokens[15]),
                        CenaGodisnje = int.Parse(tokens[16]),
                        CenaPojedinacnog = int.Parse(tokens[17]),
                        CenaGrupnog = int.Parse(tokens[18]),
                        CenaPersonalnog = int.Parse(tokens[19])
                    },
                    Trajanje = int.Parse(tokens[20]),
                    DatumVremeTreninga = Convert.ToDateTime(tokens[21]),
                    MaxPosetilaca = int.Parse(tokens[22]),
                    posetioci = tokens[23].Split(',').ToList(),
                };

                treninzi.Add(gtrening);

            }
            sr.Close();
            stream.Close();
            return treninzi;
        }

        public static List<Rezervacija> ReadRezervacije(string path)
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            List<Korisnik> k = (List<Korisnik>)HttpContext.Current.Application["korisnici"];
            path = HostingEnvironment.MapPath(path);
            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split(';');


                Rezervacija rez = new Rezervacija()
                {
                    IdRezervacije = tokens[0],
                    Posetilac = tokens[1],
                    Grupni = new GrupniTrening()
                    {
                        Naziv = tokens[0],
                        TipTreninga = (TipTreninga)Enum.Parse(typeof(TipTreninga), tokens[1]),
                        FCOdrzavanja = new FitnesCentar()
                        {
                            Naziv = tokens[2],
                            Ulica = tokens[3],
                            Broj = int.Parse(tokens[4]),
                            Mesto = tokens[5],
                            PostanskiBroj = tokens[6],
                            GodinaOtvaranja = int.Parse(tokens[7]),
                            Vlasnik = new Korisnik()
                            {
                                KorisnickoIme = tokens[8],
                                Ime = tokens[9],
                                Prezime = tokens[10],
                                Pol = (Pol)Enum.Parse(typeof(Pol), tokens[11]),
                                Email = tokens[12],
                                DatumRodjenja = Convert.ToDateTime(tokens[13]),
                                Uloga = (Uloga)Enum.Parse(typeof(Uloga), tokens[14]),
                            },
                            CenaMesecne = int.Parse(tokens[15]),
                            CenaGodisnje = int.Parse(tokens[16]),
                            CenaPojedinacnog = int.Parse(tokens[17]),
                            CenaGrupnog = int.Parse(tokens[18]),
                            CenaPersonalnog = int.Parse(tokens[19])
                        },
                        Trajanje = int.Parse(tokens[20]),
                        DatumVremeTreninga = Convert.ToDateTime(tokens[21]),
                        MaxPosetilaca = int.Parse(tokens[22]),
                    }
                };
                foreach (Korisnik item in k)
                {
                    if (item.KorisnickoIme == rez.Posetilac)
                    {
                        item.rezervacija.Add(rez);
                    }
                }

            }
            sr.Close();
            stream.Close();
            return rezervacije;

        }
        public static void SaveUser(Korisnik user)
        {
            StreamWriter file = File.AppendText(HttpContext.Current.Server.MapPath(@"~/App_Data/Vlasnik.txt"));
            file.Write("\n" + user.KorisnickoIme + ";" + user.Lozinka + ";" + user.Ime + ";" + user.Prezime + ";" + user.Pol + ";" + user.Email + ";" + user.DatumRodjenja + ";" + user.Uloga+ ";");
            file.Close();
        }       
        public static void SaveRezervacija(Rezervacija r)
        {
            StreamWriter file = File.AppendText(HttpContext.Current.Server.MapPath(@"~/App_Data/Rezervacija.txt"));
            file.Write("\n" + r.IdRezervacije + ";" + r.Posetilac + ";" + r.Grupni.Naziv + ";" + r.Grupni.TipTreninga + ";" + r.Grupni.FCOdrzavanja + ";" + r.Grupni.Trajanje + ";" + r.Grupni.DatumVremeTreninga + ";" + r.Grupni.MaxPosetilaca + ";");
            file.Close();
        }
        public static void SaveFC(FitnesCentar fc)
        {
            StreamWriter file = File.AppendText(HttpContext.Current.Server.MapPath(@"~/App_Data/FitnesCentri.txt"));
            file.Write("\n" + fc.Naziv + ";" + fc.Ulica + ";" + fc.Broj + ";" + fc.Mesto + ";" + fc.PostanskiBroj + ";" + fc.GodinaOtvaranja + ";" + fc.Vlasnik.KorisnickoIme + ";" + fc.Vlasnik.Ime + ";" + fc.Vlasnik.Prezime + ";" + fc.Vlasnik.Pol + ";" + fc.Vlasnik.Email + ";" + fc.Vlasnik.DatumRodjenja + ";" + fc.Vlasnik.Uloga + ";" + fc.CenaMesecne + ";" + fc.CenaGodisnje + ";" + fc.CenaPojedinacnog + ";" + fc.CenaGrupnog + ";" + fc.CenaPersonalnog + ";");
            file.Close();
        }
        public static void SaveGT(GrupniTrening gt)
        {
            StreamWriter file = File.AppendText(HttpContext.Current.Server.MapPath(@"~/App_Data/GrupniTreninzi.txt"));
            file.Write("\n" + gt.Naziv + ";" + gt.TipTreninga + ";" + gt.FCOdrzavanja.Naziv + ";" + gt.FCOdrzavanja.Ulica + ";" + gt.FCOdrzavanja.Broj + ";" + gt.FCOdrzavanja.Mesto + ";" + gt.FCOdrzavanja.PostanskiBroj + ";" + gt.FCOdrzavanja.GodinaOtvaranja + ";" + gt.FCOdrzavanja.Vlasnik.KorisnickoIme + ";" + gt.FCOdrzavanja.Vlasnik.Ime + ";" + gt.FCOdrzavanja.Vlasnik.Prezime + ";" + gt.FCOdrzavanja.Vlasnik.Pol + ";" + gt.FCOdrzavanja.Vlasnik.Email + ";" + gt.FCOdrzavanja.Vlasnik.DatumRodjenja + ";" + gt.FCOdrzavanja.Vlasnik.Uloga + ";" + gt.FCOdrzavanja.CenaMesecne + ";" + gt.FCOdrzavanja.CenaGodisnje + ";" + gt.FCOdrzavanja.CenaPojedinacnog + ";" + gt.FCOdrzavanja.CenaGrupnog + ";" + gt.FCOdrzavanja.CenaPersonalnog + ";" + gt.Trajanje + ";" + gt.DatumVremeTreninga + ";" + gt.MaxPosetilaca + ";" + gt.posetioci + ";");
            file.Close();
        }
    }
}